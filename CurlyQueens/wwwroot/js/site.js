// site.js

document.addEventListener('DOMContentLoaded', function () {

    // --- Bootstrap 5 Tooltip Initialization ---
    // Example: Initialize all tooltips on the page
    var tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'));
    var tooltipList = tooltipTriggerList.map(function (tooltipTriggerEl) {
        return new bootstrap.Tooltip(tooltipTriggerEl);
    });


    // --- Mock Mini-Cart Counter ---
    // This is a placeholder to demonstrate the cart count updating.
    // In a real application, this logic would be driven by AJAX calls to a cart API.
    const miniCartCount = document.getElementById('mini-cart-count');
    
    // Function to be called when an item is added to the cart
    function updateMiniCart(quantity) {
        if (miniCartCount) {
            let currentCount = parseInt(miniCartCount.textContent || '0');
            currentCount += quantity;
            miniCartCount.textContent = currentCount;

            // Add a little animation to draw attention
            miniCartCount.classList.add('animate__animated', 'animate__bounce');
            setTimeout(() => {
                miniCartCount.classList.remove('animate__animated', 'animate__bounce');
            }, 1000);
        }
    }

    // Example of how you might listen for "Add to Cart" clicks
    // This assumes buttons have a class like 'add-to-cart-btn'
    document.body.addEventListener('click', function(e) {
        if (e.target && e.target.matches('.add-to-cart-btn')) {
            e.preventDefault();
            
            // In a real app, you'd get the product ID and quantity, then make an API call.
            // const productId = e.target.dataset.productId;
            // const quantity = 1; 
            // addToCartApi(productId, quantity).then(() => updateMiniCart(quantity));

            // For this demo, we just update the counter directly.
            updateMiniCart(1);

            // Provide user feedback
            const originalText = e.target.innerHTML;
            e.target.innerHTML = 'Added!';
            e.target.disabled = true;
            setTimeout(() => {
                e.target.innerHTML = originalText;
                e.target.disabled = false;
            }, 2000);
        }
    });


    // --- Navbar Toggle Behavior ---
    // Bootstrap's own JS handles the toggling of the collapsible content.
    // This is just an example if you needed to add custom logic, e.g.,
    // changing an icon on toggle.
    const navbarToggler = document.querySelector('.navbar-toggler');
    const navbarIcon = navbarToggler ? navbarToggler.querySelector('.navbar-toggler-icon') : null;

    if (navbarToggler) {
        navbarToggler.addEventListener('click', function() {
            // You could add a class to the icon to change its state, e.g., from a burger to an 'X'
            // This requires custom CSS for the icon states.
            // navbarIcon.classList.toggle('is-active');
        });
    }

});
