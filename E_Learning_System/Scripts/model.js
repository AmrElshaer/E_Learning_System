function initModel(modalId, btnId) {
    // Get the modal
    const modal = document.getElementById(modalId);
    // Get the button that opens the modal
    const btn = document.getElementById(btnId);
    // When the user clicks the button, open the modal
    btn.addEventListener('click', () => {
        modal.style.display = "block";
    });

    // When the user clicks on <span> (x), close the modal


    // When the user clicks anywhere outside of the modal, close it
    window.onclick = function (event) {
        if (event.target == modal) {
            modal.style.display = "none";
        }
    }
}