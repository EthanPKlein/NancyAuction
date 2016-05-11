var elemIndex = 0;

$(document).ready(function () {
    $("#addAnother").click(function () {
        addAnother();
    });
    addAnother();
});

function addAnother() {
    var name = "<p>Name of Item:  <input type='text' name='Name[" + elemIndex + "]' value='' required></p>";
    var description = "<p>Description:  <input type='text' name='Description[" + elemIndex + "]' value='' required></p>";
    var startingBid = "<p>Starting Bid:  $<input type='text' name='StartingBid[" + elemIndex + "]' value='' required></p>";
    var autobuy = "<p>Autobuy Limit:  $<input type='text' name='AutoBuy[" + elemIndex + "]' value='' required></p>";
    var posterName = "<p>Your Name:  <input type='text' name='OwnerName[" + elemIndex + "]' value='' required></p>";

    $("#list").append("<div class='listing'>" + name + description + startingBid + autobuy + posterName + "<hr></div>");
    elemIndex++;
}