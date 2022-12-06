

var empInput = document.getElementById("empId");
var proarea = document.getElementById("prolist");

empInput.addEventListener("change", function () {
    fetch("https://localhost:7144/Partialview/EditSelectProject/" + empInput.value)
        .then((result) => {
            return result.text();
        }).then((data) => {
            console.log(data);
            proarea.innerHTML = data;
        });
});