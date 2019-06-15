
// Accommodation

var objSel = document.getElementById("DirectoryStatusAccommodationID");
var blockHidden_1 = document.getElementById("block_for_hidden__accommodation_1");
var blockHidden_2 = document.getElementById("block_for_hidden__accommodation_2");


if (objSel.options[objSel.selectedIndex].text == "Бронирование") {
    blockHidden_1.style.display = 'none';
    blockHidden_2.style.display = 'none';
}

objSel.addEventListener("change", function () {

    if (objSel.options[objSel.selectedIndex].text == "Бронирование") {
        blockHidden_1.style.display = 'none';
        blockHidden_2.style.display = 'none';
    }
    if (objSel.options[objSel.selectedIndex].text == "Заселение") {
        blockHidden_1.style.display = 'block';
        blockHidden_2.style.display = 'block';
    }
    if (objSel.options[objSel.selectedIndex].text == "Выселение") {
        blockHidden_1.style.display = 'block';
        blockHidden_2.style.display = 'block';
    }
    if (objSel.options[objSel.selectedIndex].text == "Отмена") {
        blockHidden_1.style.display = 'block';
        blockHidden_2.style.display = 'block';
    }

})



