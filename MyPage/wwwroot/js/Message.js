
var connection = new signalR.HubConnectionBuilder().withUrl("/messageHub").build();

//Disable the send button until connection is established.
document.getElementById("sendButton").disabled = true;

connection.on("RecieveMessage", function (user, message) {
    console.log("Message Recieved: " + message);
    var li = $('<li>', {
        class: 'message',
        id: `message-${user}`
    });
    const msg = `${user} says ${message}`;
    li.text(msg);
    $('#messagesList').append(li);
    // We can assign user-supplied strings to an element's textContent because it
    // is not interpreted as markup. If you're assigning in any other way, you 
    // should be aware of possible script injection concerns.
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = $('#userInput').val();
    console.log(user);
    var message = $('#messageInput').val();
    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});