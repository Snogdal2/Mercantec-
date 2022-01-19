var today = new Date();
var date = today.getFullYear()+'-'+(today.getMonth()+1)+'-'+today.getDate();


document.getElementById("dato").innerHTML = date;

function setup () {
    var knapper = document.getElementsByClassName("darkmode")
    for(var i = 0; i < knapper.length; i++) {
        knapper[i].addEventListener("click", onbuttonEnter)
    }
}

function onbuttonEnter (event) {
    document.getElementById("body").style.backgroundColor = "black";
    document.getElementById("side").style.backgroundColor = "gray";
}