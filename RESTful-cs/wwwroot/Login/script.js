let loginButton = document.querySelector('#login-button');
let regButton = document.querySelector('#reg-button');
let username = document.querySelector('#username');
let password = document.querySelector('#password');
let regUsername = document.querySelector("#reg-username");
let regPassword = document.querySelector("#reg-password");

regButton.addEventListener('click', async (e) => {

    if (regUsername.value === "" || regPassword.value === "") {
        alert("please enter userame and password");
        return;
    }

    const data = {
        Username: regUsername.value,
        Password: regPassword.value
    }
    console.log(JSON.stringify(data));
    const options = {
        method: "POST",
        body: JSON.stringify(data),
        headers: {
            "content-type": "application/json"
        }
    }

    const response = await fetch("/Accounts", options);
    const final = await response.text();

    console.log(final.slice(0,7));

    if (final.slice(0, 7) === "success") {
        alert("Account Registered");
        //window.location.replace("http://localhost:8000");
    }
    else {
        alert(`Resiter failed: ${final}`);
    }

    regUsername.value == "";
    regPassword.value == "";
    console.log(final);
});

loginButton.addEventListener('click', async (e) => {

    console.log("hello");

    const data = {
        Username: username.value,
        Password: password.value
    }

    console.log(JSON.stringify(data));

    const options = {
        method: "POST",
        body: JSON.stringify(data),
        headers: {
            "content-type": "application/json"
        }
    }

    const response = await fetch("/Accounts/Verify", options);
    const final = await response.json();

    if (final.success === true) {
        location.replace("http://localhost:8000");
        document.querySelector("#user-email").textContent = final.username;
    }
    else {
        alert("Login Failed");
    }

    username.value = "";
    password.value = "";
    console.log(final);

});