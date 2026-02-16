// Cart functionality - AJAX operations

$(function () {
    const antiForgeryToken = $('input[name="__RequestVerificationToken"]').val()
        || $('meta[name="RequestVerificationToken"]').attr('content')
        || '';

    function getAntiForgeryToken() {
        // Try to find the token from any form on the page
        return $('input[name="__RequestVerificationToken"]').first().val() || '';
    }

    function updateBadge(count) {
        const badge = $('#cart-badge-count');
        if (badge.length) {
            badge.text(count);
        }
    }

    function formatCurrency(value) {
        return '$' + parseFloat(value).toFixed(2);
    }

    // ---- Add to Cart (Product Details page) ----
    $('#add-to-cart-form').on('submit', function (e) {
        e.preventDefault();

        const btn = $('#btn-add-to-cart');
        const productId = btn.data('product-id');
        const quantity = parseInt($('#quantity').val()) || 1;
        const messageDiv = $('#add-to-cart-message');

        btn.prop('disabled', true).html('<i class="fas fa-spinner fa-spin me-2"></i>Adding...');

        $.ajax({
            url: '/Cart/AddAjax',
            type: 'POST',
            contentType: 'application/json',
            headers: { 'RequestVerificationToken': getAntiForgeryToken() },
            data: JSON.stringify({ productId: productId, quantity: quantity }),
            success: function (data) {
                if (data.success) {
                    updateBadge(data.totalItems);
                    messageDiv.html('<div class="alert alert-success"><i class="fas fa-check-circle me-2"></i>' + data.message + '</div>').show();
                } else {
                    messageDiv.html('<div class="alert alert-danger"><i class="fas fa-exclamation-circle me-2"></i>' + data.message + '</div>').show();
                }
            },
            error: function (xhr) {
                if (xhr.status === 401) {
                    window.location.href = '/Identity/Account/Login?ReturnUrl=' + encodeURIComponent(window.location.pathname);
                    return;
                }
                messageDiv.html('<div class="alert alert-danger"><i class="fas fa-exclamation-circle me-2"></i>An error occurred. Please try again.</div>').show();
            },
            complete: function () {
                btn.prop('disabled', false).html('<i class="fas fa-cart-plus me-2"></i>Add to Cart');
                setTimeout(function () { messageDiv.fadeOut(); }, 4000);
            }
        });
    });

    // ---- Quantity Minus Button ----
    $(document).on('click', '.btn-qty-minus', function () {
        const itemId = $(this).data('item-id');
        const input = $('.cart-qty-input[data-item-id="' + itemId + '"]');
        let val = parseInt(input.val()) || 1;
        if (val > 1) {
            input.val(val - 1);
            updateCartItem(itemId, val - 1);
        }
    });

    // ---- Quantity Plus Button ----
    $(document).on('click', '.btn-qty-plus', function () {
        const itemId = $(this).data('item-id');
        const input = $('.cart-qty-input[data-item-id="' + itemId + '"]');
        let val = parseInt(input.val()) || 1;
        const max = parseInt(input.attr('max')) || 100;
        if (val < max) {
            input.val(val + 1);
            updateCartItem(itemId, val + 1);
        }
    });

    // ---- Quantity Input Change ----
    $(document).on('change', '.cart-qty-input', function () {
        const itemId = $(this).data('item-id');
        let val = parseInt($(this).val()) || 1;
        const max = parseInt($(this).attr('max')) || 100;
        if (val < 1) val = 1;
        if (val > max) val = max;
        $(this).val(val);
        updateCartItem(itemId, val);
    });

    function updateCartItem(cartItemId, quantity) {
        $.ajax({
            url: '/Cart/UpdateQuantityAjax',
            type: 'POST',
            contentType: 'application/json',
            headers: { 'RequestVerificationToken': getAntiForgeryToken() },
            data: JSON.stringify({ cartItemId: cartItemId, quantity: quantity }),
            success: function (data) {
                if (data.success) {
                    // Update line total
                    $('#cart-item-' + cartItemId + ' .item-line-total').text(formatCurrency(data.lineTotal));
                    // Update summary
                    $('#cart-subtotal').text(formatCurrency(data.subtotal));
                    $('#cart-tax').text(formatCurrency(data.tax));
                    $('#cart-total').text(formatCurrency(data.total));
                    updateBadge(data.totalItems);

                    // Update button states
                    const input = $('.cart-qty-input[data-item-id="' + cartItemId + '"]');
                    const max = parseInt(input.attr('max')) || 100;
                    const minus = $('.btn-qty-minus[data-item-id="' + cartItemId + '"]');
                    const plus = $('.btn-qty-plus[data-item-id="' + cartItemId + '"]');
                    minus.prop('disabled', quantity <= 1);
                    plus.prop('disabled', quantity >= max);
                } else {
                    alert(data.message);
                }
            },
            error: function () {
                alert('Failed to update quantity. Please try again.');
            }
        });
    }

    // ---- Remove Item ----
    $(document).on('click', '.btn-remove-item', function () {
        const itemId = $(this).data('item-id');
        if (!confirm('Remove this item from cart?')) return;

        const row = $('#cart-item-' + itemId);
        row.fadeOut(300);

        $.ajax({
            url: '/Cart/RemoveAjax',
            type: 'POST',
            contentType: 'application/json',
            headers: { 'RequestVerificationToken': getAntiForgeryToken() },
            data: JSON.stringify({ cartItemId: itemId }),
            success: function (data) {
                if (data.success) {
                    row.remove();
                    $('#cart-subtotal').text(formatCurrency(data.subtotal));
                    $('#cart-tax').text(formatCurrency(data.tax));
                    $('#cart-total').text(formatCurrency(data.total));
                    updateBadge(data.totalItems);

                    // If cart is now empty, reload the page to show the empty state
                    if (data.totalItems === 0) {
                        location.reload();
                    }
                } else {
                    row.show();
                    alert(data.message);
                }
            },
            error: function () {
                row.show();
                alert('Failed to remove item. Please try again.');
            }
        });
    });
});
