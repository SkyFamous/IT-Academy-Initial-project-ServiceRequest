function showDropdown() {
    document.getElementById("myDropdown").classList.toggle("showRegisterButton");
}

// Close the dropdown if the user clicks outside of it
window.onclick = function (e) {
    if (!e.target.matches('.dropbtnRegisterButton')) {
        var myDropdown = document.getElementById("myDropdown");
        if (myDropdown.classList.contains('showRegisterButton')) {
            myDropdown.classList.remove('showRegisterButton');
        }
    }
}