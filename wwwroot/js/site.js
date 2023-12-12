let cardCount = 0;

function addCard() {
    const cardList = document.getElementById('cardList');
    const card = document.createElement('div');
    card.className = 'card';

    card.innerHTML = `
        <img src="https://via.placeholder.com/150" alt="Product Image">
        <div class="card-info">
            <h3>Product ${++cardCount}</h3>
            <p>Description of product ${cardCount}.</p>
            <p class="price">$19.99</p>
            <button onclick="addToCart(${cardCount})">Add to Cart</button>
        </div>
    `;

    cardList.appendChild(card);
}

function addToCart(productId) {
    // Implement your logic to add the product to the shopping cart
    console.log('Product ${ productId } added to cart');
}