let orders = [];
getData();
function getData() {
    fetch('http://localhost:4112/order')
        .then(x => x.json())
        .then(y => {
            orders = y;
            console.log(orders);
            display();
        });
}
function display() {
    let htmlContent = '';

    orders.forEach(t => {
        const orderId = t.orderId;
        const adventurerName = t.adventurer ? t.adventurer.adventurerName : 'Unknown';
        const itemName = t.item ? t.item.itemName : 'Unknown';

        htmlContent += '<tr><td>' + orderId + '</td><td>' + adventurerName + '</td><td>' + itemName + '</td></tr>';

        document.getElementById('rows').innerHTML = htmlContent;
    });

}

function createOrder() {
    let adventurerId = document.getElementById('adventurerId').value;
    let itemId = document.getElementById('itemId').value;
    let orderId = document.getElementById('orderId').value;

    fetch('http://localhost:4112/order', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            OrderId: orderId,
            AdventurerId: adventurerId,
            ItemId: itemId
        })
    })
        .then(response => response/*{
            if (!response.ok) {
                throw new Error('Failed to create order');
            }
            return response.json();
        }*/)
        .then(data => {
            console.log('Success:', data);
            getData();
            display();
        })
        .catch(error => {
            console.error('Error:', error);
        });
}


