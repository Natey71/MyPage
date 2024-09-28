const connection = new signalR.HubConnectionBuilder()
    .withUrl("/pingHub")
    .build();

connection.on("ReceivePingResult", function (message) {
    document.getElementById("pingResult").innerHTML = message;
});

connection.start().catch(function (err) {
    return console.error(err.toString());
});