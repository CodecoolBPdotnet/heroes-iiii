window.addEventListener("load", this.LoadHero());

function LoadHero() {
    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = this.ShowHero();
    xhttp.open("GET", "Hero/0", true);
    xhttp.send();
}

function ShowHero() {
    if (this.readyState == 4 && this.status == 200)
    {
        var myHero = this.responseText;
        document.write(myHero);
    }
}