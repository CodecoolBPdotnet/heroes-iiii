window.onload = StartUp

function SkillPointAviable() {
    document.getElementById("atk").style.backgroundColor = "rgb(237, 160, 18)";
    document.getElementById("def").style.backgroundColor = "rgb(237, 160, 18)";
    document.getElementById("agi").style.backgroundColor = "rgb(237, 160, 18)";
    document.getElementById("vit").style.backgroundColor = "rgb(237, 160, 18)";
}
function SkillPointDisable() {
    document.getElementById("atk").style.backgroundColor = "default";
    document.getElementById("def").style.backgroundColor = "default";
    document.getElementById("agi").style.backgroundColor = "default";
    document.getElementById("vit").style.backgroundColor = "default";
}

function LoadHero() {
    fetch('api/Hero/1')
        .then(function (response) {
            return response.json();
        })
        .then(function (myJson) {
            var hero = myJson;
            if (hero.skillPoints > 0) {
                SkillPointAviable();
            } else {
                SkillPointDisable()
            }
            document.getElementById("name").innerHTML = hero["name"];
            document.getElementById("hp").innerHTML = hero["currentHealth"];
            document.getElementById("level").innerHTML = "Level: " + hero["level"];
            document.getElementById("skillpoint").innerHTML = "Skillpoints: " + hero["skillPoints"];
            document.getElementById("atk").innerHTML = hero["damage"];
            document.getElementById("def").innerHTML = hero["defense"];
            document.getElementById("agi").innerHTML = hero["agility"];
            document.getElementById("vit").innerHTML = hero["vitality"];
        });
}

function Fight() {
    fetch('api/fight')
    LoadHero()
}

function ButtonSetUp() {
    var element = document.getElementById("fightbutton");
    element.addEventListener("click", Fight);
}; 

function StartUp() {
    LoadHero();
    ButtonSetUp();
}

