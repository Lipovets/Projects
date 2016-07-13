var grid = document.getElementById("grid");

grid.onclick = function (e) {
    if (e.target.tagName != 'TH') return;

    // Если TH -- сортируем
    sortGrid(e.target.cellIndex, e.target.getAttribute('data-type'));
}

var column;
var sortD;
function sortGrid(colNum, type) {
    if (column == colNum) {
        sortD = -sortD;
    } else {
        sortD = 1;
    }

    column = colNum;

    var tbody = grid.getElementsByTagName('tbody')[0];

    // Составить массив из TR
    var rowsArray = [].slice.call(tbody.rows);

    // определить функцию сравнения, в зависимости от типа
    var compare;

    switch (type) {
        case 'number':
            compare = function (rowA, rowB) {
                return sortD * (rowA.cells[colNum].innerHTML - rowB.cells[colNum].innerHTML);
            };
            break;
        case 'string':
            compare = function (rowA, rowB) {
                return sortD * rowA.cells[colNum].innerText.localeCompare(rowB.cells[colNum].innerText);
            };
            break;
    }

    // сортировать
    rowsArray.sort(compare);

    // Убрать tbody из большого DOM документа для лучшей производительности
    grid.removeChild(tbody);

    // добавить результат в нужном порядке в TBODY
    // они автоматически будут убраны со старых мест и вставлены в правильном порядке
    for (var i = 0; i < rowsArray.length; i++) {
        tbody.appendChild(rowsArray[i]);
    }

    grid.appendChild(tbody);

}