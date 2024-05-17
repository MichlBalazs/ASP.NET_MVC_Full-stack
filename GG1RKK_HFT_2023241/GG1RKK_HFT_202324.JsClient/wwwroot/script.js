let orders = [];
let connection = null;
getData();
setupSignalR();
function getData() {
    fetch('http://localhost:4112/order')
        .then(x => x.json())
        .then(y => {
            orders = y;
            //console.log(orders);
            display();
        });
}

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        //setTimeout(start, 5000);
    }
};


function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:4112/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("OrderCreated", (user, message) => {
        getdata();
    });

    connection.on("OrderDeleted", (user, message) => {
        getdata();
    });

    connection.on("OrderUpdated", (user, message) => {
        getdata();
    });

    connection.onclose(async () => {
        await start();
    });
    start();
}

function display() {
    document.getElementById('rows').innerHTML = '';
    let htmlContent = '';
    orders.forEach(t => {
        const orderId = t.orderId;
        const adventurerName = t.adventurer ? t.adventurer.adventurerName : 'Unknown';
        const itemName = t.item ? t.item.itemName : 'Unknown';

        htmlContent += '<tr><td>' + orderId + '</td><td>' + adventurerName + '</td><td>' + itemName + '</td><td><button type="button" id="delete-button" onclick="removeOrder(' + `${orderId}` + ')">Delete</button><button type="button" id="update-button" onclick="showupdateOrder(' + `${orderId}` + ')">Update</button></td></tr>';
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
    });
    getData();
}

function updateOrder() {
    let adventurerId = document.getElementById('adventurerIdtoupdate').value;
    let itemId = document.getElementById('itemIdtoupdate').value;
    let orderId = document.getElementById('orderIdtoupdate').value;


    fetch('http://localhost:4112/order', {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            OrderId: orderId,
            AdventurerId: adventurerId,
            ItemId: itemId
        })
    });

    getData();
    location.reload();
}

function removeOrder(id) {
    fetch('http://localhost:4112/order/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    });
    getData();
    location.reload();
}

function showupdateOrder(id) {
    document.getElementById('orderIdtoupdate').value = orders.find(t => t.orderId = id).orderId;
    document.getElementById('adventurerIdtoupdate').value = orders.find(t => t.orderId = id).adventurerId;
    document.getElementById('itemIdtoupdate').value = orders.find(t => t.orderId = id).itemId;
}

display();