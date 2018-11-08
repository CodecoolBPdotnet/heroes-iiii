window.addEventListener("load", this.LoadHero());

function LoadHero() {
    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function() {
        if (this.readyState == 4 && this.status == 200) {
            document.getElementById
    }
  };
    xhttp.open("GET", "api/Hero/1", true);
    xhttp.send();
}
