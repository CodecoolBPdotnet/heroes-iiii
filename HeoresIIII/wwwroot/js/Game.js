window.onload = StartUp

var game = {};

function SkillPointAvailable() {
    document.getElementById("atk").style.backgroundColor = "rgb(237, 160, 18)";
    document.getElementById("def").style.backgroundColor = "rgb(237, 160, 18)";
    document.getElementById("agi").style.backgroundColor = "rgb(237, 160, 18)";
    document.getElementById("vit").style.backgroundColor = "rgb(237, 160, 18)";
}
function SkillPointDisable() {
    document.getElementById("atk").style.backgroundColor = "gray";
    document.getElementById("def").style.backgroundColor = "gray";
    document.getElementById("agi").style.backgroundColor = "gray";
    document.getElementById("vit").style.backgroundColor = "gray";
}

function LoadHero() {
    fetch('api/Hero/1')
        .then(function (response) {
            return response.json();
        })
        .then(function (myJson) {
            var hero = myJson;
            game.hero = hero;
            if (hero.skillPoints > 0) {
                SkillPointAvailable();
            } else {
                SkillPointDisable()
            }
            document.getElementById("avatar").src = game.hero.picture;
            document.getElementById("expbar").value = game.hero.experience;
            document.getElementById("expbar").max = game.hero.nextLevelExperienceLimit;
            document.getElementById("expcount").innerHTML = game.hero.experience + " / " + game.hero.nextLevelExperienceLimit;
            document.getElementById("name").innerHTML = hero["name"];
            document.getElementById("hp").innerHTML = hero["currentHealth"] + " HP";
            document.getElementById("level").innerHTML = "Level: " + hero["level"];
            document.getElementById("skillpoint").innerHTML = hero["skillPoints"];
            document.getElementById("atk").innerHTML = hero["damage"];
            document.getElementById("def").innerHTML = hero["defense"];
            document.getElementById("agi").innerHTML = hero["agility"];
            document.getElementById("vit").innerHTML = hero["vitality"];
        });
}

function IncreaseAttribute(attribute) {
    if (game.hero.skillPoints > 0) {
        fetch('api/hero/1/' + attribute, {
            method: "put",
        }).then(function (response) {
            if (response.status == 200) {

                switch (attribute) {
                    case "atk":
                        game.hero.damage++;
                        document.getElementById("atk").innerHTML = game.hero.damage;
                        break;
                    case "def":
                        game.hero.defense++;
                        document.getElementById("def").innerHTML = game.hero.defense;
                        break;
                    case "agi":
                        game.hero.agility++;
                        document.getElementById("agi").innerHTML = game.hero.agility;
                        break;
                    case "vit":
                        game.hero.vitality++;
                        document.getElementById("vit").innerHTML = game.hero.vitality;
                        break;
                }
                game.hero.skillPoints--;
                document.getElementById("skillpoint").innerHTML = game.hero.skillPoints;
                if (game.hero.skillPoints < 1) {
                    SkillPointDisable();
                }
            }
        })
    }
}

function Fight() {
    fetch('api/fight').then(
        function (response) {
            if (response.status == 200) {
                LoadHero();
            }
        }
    )
}

function ButtonSetUp() {
    var element = document.getElementById("fightbutton");
    element.addEventListener("click", Fight);
    document.getElementById("atk").addEventListener("click", function () { IncreaseAttribute("atk") });
    document.getElementById("def").addEventListener("click", function () { IncreaseAttribute("def") });
    document.getElementById("agi").addEventListener("click", function () { IncreaseAttribute("agi") });
    document.getElementById("vit").addEventListener("click", function () { IncreaseAttribute("vit") });
}

function StartUp() {
    LoadHero();
    ButtonSetUp();
}

