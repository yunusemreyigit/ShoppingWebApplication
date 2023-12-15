let cardCount = 0;
function addToCart(productId) {
    fetch(`/Home/AddToCart/${productId}`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
    })
        .then(response => response.json())
        .then(data => {
            const cartItems = document.getElementById('cartItems');
            const cartItem = document.createElement('div');
            cartItem.className = 'cart-item';
            cartItem.innerHTML = `
            <img src="https://via.placeholder.com/60" alt="${data.name} Image">
            <div class="cart-item-info">
                <h4>${data.name}</h4>
                <p>${data.details}</p>
            </div>
            <button onclick="removeFromCart(${data.productId})">Remove</button>
        `;
            cartItems.appendChild(cartItem);

            const cartContainer = document.getElementById('cartContainer');
            cartContainer.style.display = 'block';
        });
}

function removeFromCart(productId) {
    fetch(`/Cart/RemoveFromCart/${productId}`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
    })
        .then(response => response.json())
        .then(data => {
            const cartItems = document.getElementById('cartItems');
            const cartItem = document.querySelector(`.cart-item img[alt="${data.name} Image"][src="https://via.placeholder.com/60"]`);
            if (cartItem) {
                cartItems.removeChild(cartItem.parentElement);
            }

            if (cartItems.childElementCount === 0) {
                const cartContainer = document.getElementById('cartContainer');
                cartContainer.style.display = 'none';
            }
        });
}