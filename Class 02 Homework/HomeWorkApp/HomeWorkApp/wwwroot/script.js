let getAllBtn = document.querySelector("#btn1");
let getByIdBtn = document.querySelector("#btn2");
let addUserBtn = document.querySelector("#btn3");
let getAllTagsBtn = document.querySelector("#btn4");
let getTagByIdBtn = document.querySelector("#btn5");
let getByIdInput = document.querySelector("#input2");
let addNoteInput = document.querySelector("#input3");
let renderUser = document.querySelector("#renderUser");
let showAllUsers = document.querySelector("#showAllUsers");
let showAddedUser = document.querySelector("#showAddedUser");

let usersNames = [];
function renderUsers(inputData) {

}

let port = "5294";
let getAllUsers = async () => {
    let url = "http://localhost:" + port + "/api/Users";

    let response = await fetch(url);
    console.log(response);
    let data = await response.json();
    console.log(data);
    showAllUsers.innerText = data;
};

let getUserById = async () => {
    let url = "http://localhost:" + port + "/api/Users/user/" + getByIdInput.value;
    let response = await fetch(url, {
        method: 'GET',
        headers: {
            'Access-Control-Allow-Origin': '*'
        }
    });
    let data = await response.text();
    console.log(data);
    renderUser.innerText = data;
    showAllUsers.innerHTML = data;
};

let addUser = async () => {
    let url = "http://localhost:" + port + "/api/Users/add/";
    var response = await fetch(url, {
        method: 'POST',
        headers: {
            'Content-Type': 'text/plain'
        },
        body: addNoteInput.value
    });
    var data = await response.text();
    console.log(data);
    showAddedUser.innerHTML = `the user with name ${data} was addded to the base. Click get All Button to show all users`;
}

getAllBtn.addEventListener("click", getAllUsers);
getByIdBtn.addEventListener("click", getUserById);
addUserBtn.addEventListener("click", addUser);