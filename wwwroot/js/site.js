const uri = 'GameState'
let vivo = true
document.getElementById("create").addEventListener("click", createTable);


function createTable(event) {
    let playerName = document.getElementById("player_name").value;
    let height = parseInt(document.getElementById("height").value);
    let width  = parseInt(document.getElementById("width").value);
    let number = parseInt(document.getElementById("number").value);
    let form   = document.getElementById("form");

    const table = {
        PlayerName: playerName,
        Height: height,
        Width: width,
        MinesNumber: Math.round(height * width * (number / 100))
    };

    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(table)
    })
    .then(response => response.json())
    .then(() => {
        displayTable(height, width);
        form.style.display = "none";
    })
    .catch(error => console.error('Unable to add item.', error));
}

function displayTable(height, width){
    fetch(uri)
    .then(response => response.json())
    .then(data => _displayTable(data))
    .catch(error => console.error('Unable to get items.', error));

    let size = height * width;
    let table = document.getElementById("table");
    table.hidden = false;
    table.height = height;
    table.width = width;
    let buttom;
    let i, j;
    for(var index = 0; index < size; index++){
        i = parseInt((index / width) % height);
        j = parseInt(index % width);
        buttom = document.createElement("button");
        buttom.id = String(i + "/" + j);
        buttom.className = "tableBox";
        table.appendChild(buttom);
        if (j == width - 1){
            table.appendChild(document.createElement("br"));
        }
    }
}

function _displayTable(data){
    let tButtons = document.getElementById("table");
    let table = data.table;
    console.log(data);
    let i, j;
    for (var index = 0; index < table.length; index++){
        i = parseInt((index / tButtons.width) % tButtons.height);
        j = parseInt(index % tButtons.width);
        buttom = document.getElementById(String(i + "/" + j));
        buttom.innerHTML = table[index];
        if (!data.livePlayer){
            document.getElementById("tableTitle").innerHTML = "You Lose";
            buttom.disabled = true;
        }
    }
}

function getTable() {
    fetch(uri)
      .then(response => response.json())
      .then(data => _displayTable(data))
      .catch(error => console.error('Unable to get items.', error));
  }

function to_move(event){
    let movement = event.target.id.split("/");
    const move = {
        X: parseInt(movement[0]),
        Y: parseInt(movement[1])
    };
    fetch(`${uri}/unearth`, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(move)
    })
    .then(response => response.json())
    .then(() => {
        getTable();
    })
    .catch(error => console.error('Unable to add item.', error));
}