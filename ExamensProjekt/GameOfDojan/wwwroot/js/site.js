// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
window.onload = function () {
    if (window.File && window.FileList && window.FileReader) {
        let filesInput = document.getElementById("uploadImage");
        filesInput.addEventListener("change", function (event) {
            let files = event.target.files;
            let output = document.getElementById("result");
            for (let i = 0; i < files.length; i++) {
                let file = files[i];
                if (!file.type.match('image'))
                    continue;
                let picReader = new FileReader();
                picReader.addEventListener("load", function (event) {
                    let picFile = event.target;
                    let div = document.createElement("div");
                    div.innerHTML = "<img class='thumbnail' src='" + picFile.result + "'" +
                        "title='" + picFile.name + "'/>";
                    output.insertBefore(div, null);
                });
                picReader.readAsDataURL(file);
            }

        });
    }
}