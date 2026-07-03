// *********************************
// General
window.clickElementById = function (id) {
    document.getElementById(id).click();
}
// *********************************


// *********************************
// FileUploader
window.carbonBlazorFileUploader = window.carbonBlazorFileUploader || {};

window.carbonBlazorFileUploader.init = function (dropZoneId, inputId, allowMultiple) {
    var dropZone = document.getElementById(dropZoneId);
    var input = document.getElementById(inputId);

    if (!dropZone || !input || dropZone.dataset.cbFileUploaderInitialized === "true") {
        return;
    }

    dropZone.dataset.cbFileUploaderInitialized = "true";

    dropZone.addEventListener("dragover", function (event) {
        event.preventDefault();
        dropZone.classList.add("dragging");
    });

    dropZone.addEventListener("dragleave", function () {
        dropZone.classList.remove("dragging");
    });

    dropZone.addEventListener("drop", function (event) {
        event.preventDefault();
        dropZone.classList.remove("dragging");

        if (!event.dataTransfer || event.dataTransfer.files.length === 0) {
            return;
        }

        var transfer = new DataTransfer();

        if (allowMultiple) {
            Array.from(event.dataTransfer.files).forEach(function (file) {
                transfer.items.add(file);
            });
        } else {
            transfer.items.add(event.dataTransfer.files[0]);
        }

        input.files = transfer.files;
        input.dispatchEvent(new Event("change", { bubbles: true }));
    });
};
// *********************************
