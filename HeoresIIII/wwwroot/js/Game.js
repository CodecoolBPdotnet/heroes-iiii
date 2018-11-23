window.onload = StartUp

var game = {};

function SkillPointAvailable() {
    for (let i = 0; i < skillPointElems.length; i++) {
        let elem = document.getElementById(skillPointElems[i]);
        elem.style.backgroundColor = "rgb(237, 160, 18)";
        elem.style.cursor = "pointer";
        elem.addEventListener("click", IncreaseAttributeHandler);
    }
}
function SkillPointDisable() {
    for (let i = 0; i < skillPointElems.length; i++) {
        let elem = document.getElementById(skillPointElems[i]);
        elem.style.backgroundColor = "gray";
        elem.style.cursor = "auto";
        elem.removeEventListener("click", IncreaseAttributeHandler);
    }
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
                SkillPointDisable();
            }
            document.getElementById("avatar").src = game.hero.picture;
            document.getElementById("expbar").value = game.hero.experience;
            document.getElementById("expbar").max = game.hero.nextLevelExperienceLimit;
            document.getElementById("expcount").innerHTML = game.hero.experience + " / " + game.hero.nextLevelExperienceLimit;
            document.getElementById("name").innerHTML = hero.name;
            document.getElementById("hp").innerHTML = hero.currentHealth + " HP";
            document.getElementById("level").innerHTML = "Level: " + hero.level;
            document.getElementById("skillpoint").innerHTML = hero.skillPoints;
            document.getElementById("atk").innerHTML = hero.damage;
            document.getElementById("def").innerHTML = hero.defense;
            document.getElementById("agi").innerHTML = hero.agility;
            document.getElementById("vit").innerHTML = hero.vitality;
            EnableSkills(hero);
        });
}

function EnableSkills(hero) {
    let regularExpression = /\HeroesIIII\.[A-z]*(?:\.\S+)?\.(\w+)/;
    for (let i = 0; i < hero.learnedSkills.length; i++) {
        let skillString = hero.learnedSkills[i];
        let skill = regularExpression.exec(skillString)[1];
        let element = document.getElementById(skill);
        element.style.backgroundColor = "#ffad33";
    }
}

function IncreaseAttributeHandler(event) {
    let attribute = event.currentTarget.id;

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
                        game.hero.currentHealth = game.hero.currentHealth + 10;
                        document.getElementById("hp").innerHTML = game.hero.currentHealth + " HP";
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

function ShowFightResult(result) {
    document.getElementById("enemy-name").innerHTML = result["defeatedEnemy"]["name"];
    document.getElementById("enemy-attributes-container").style.display = "table";
    document.getElementById("result-title").style.display = "grid";
    document.getElementById("enemy-atk").innerHTML = result.defeatedEnemy.damage;
    document.getElementById("enemy-def").innerHTML = result["defeatedEnemy"]["defense"];
    document.getElementById("enemy-agi").innerHTML = result["defeatedEnemy"]["agility"];
    document.getElementById("enemy-vit").innerHTML = result["defeatedEnemy"]["vitality"];
    document.getElementById("enemy-hp").innerHTML = "Maximum HP: " + result["defeatedEnemy"]["maximumHealth"];
    document.getElementById("fightlog").innerHTML = "";
    for (var i = 0; i < result.fightLog.length; i++) {
        if (result.fightLog[i].item1 == "Hero") {
            document.getElementById("fightlog").innerHTML += '<div style="color:dodgerblue;text-align: left">' + result.fightLog[i].item2 + "</div>"
        } else {
            document.getElementById("fightlog").innerHTML += '<div style="color:crimson;text-align: right">' + result.fightLog[i].item2 + "</div>"
        }
    }
    document.getElementById("endmessage").innerHTML = result.fightEndMessage;
}


function Fight() {
    fetch('api/fight').then(
        function (response) {
            if (response.status == 200) {
                LoadHero();
                return response.json();
            }
        }
    ).then(function (myJson) {
        ShowFightResult(myJson)
    })
}

function ButtonSetUp() {
    var element = document.getElementById("fightbutton");
    element.addEventListener("click", Fight);
}

function SetUpConstants() {
    skillPointElems = ["atk","def", "agi", "vit"]
}

function StartUp() {
    SetUpConstants();
    LoadHero();
    ButtonSetUp();
}

skillPointElems = null;