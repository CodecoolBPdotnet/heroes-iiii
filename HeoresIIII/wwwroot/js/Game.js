window.addEventListener("load", this.LoadHero());

function LoadHero() {
    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            var hero = JSON.parse(this.responseText);
            console.log(hero);  // TODO remove later
            document.getElementById("name").innerHTML = hero["name"];
            document.getElementById("hp").innerHTML = hero["currentHealth"];
            document.getElementById("level").innerHTML = "Level: " + hero["level"];
            document.getElementById("skillpoint").innerHTML = "Skillpoints: " + hero["skillPoints"];
            document.getElementById("atk").innerHTML = hero["damage"];
            document.getElementById("def").innerHTML = hero["defense"];
            document.getElementById("agi").innerHTML = hero["agility"];
            document.getElementById("vit").innerHTML = hero["vitality"];

        }
    };
    xhttp.open("GET", "api/Hero/1", true);
    xhttp.send();
}
