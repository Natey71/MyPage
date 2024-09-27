$(function () {
    GetList();
});

function GetList() {
    $.ajax({
        type: "POST",
        url: "/Home/GetLanguages",
        dataType: "json",
        success: function (response) {
            var myObject = eval('(' + response + ')');
            myObject.forEach(item=> {
                const div = $('<div>', {
                    class: 'name-item',
                    id: `name-${item.Name}`
                });
                div.text(item.Name);
                console.log(item.Name);
                $('#lang-list').append(div);
            });
        }
    });
}


