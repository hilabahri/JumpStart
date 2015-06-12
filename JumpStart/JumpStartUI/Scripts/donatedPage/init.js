//$(document).ready(function ($) {




//    $.post('DonatedController/AcuqireData', { donatedId: "bla" }).success(function (data) {
//        $.each(data.Courses, function (idx, course) {

//            var style = course.CurrentCredit >= course.Price ? "background-color:#f1f1f1" : "background-color:#f1f1f1";

//            $('#coursesRegsitered').append($('<tr>').append(
//                $('<td>').html(course.Name),
//                $('<td>').html(course.CourseDate),
//                $('<td>').html(course.CurrentCredit),
//                $('<td>').html(course.Price)
//                ));
//        });
//    });
//});


$(document).ready(function ($) {
    var requestsTable = $('#RequestsTable').dataTable({
        "ajax": "Donated/AcuqireData",
        "columns": [
            { "data": "Name" },
            { "data": "Date" },
            { "data": "Collected" },
            { "data": "Goal" }
        ]
    }).ajaxComplete(function () {
        var table = document.getElementById("RequestsTable");
        var rows = table.getElementsByTagName("tr");
        for (i = 0; i < rows.length; i++) {
            var currentRow = table.rows[i];
            var createClickHandler =
                function (row) {
                    return function () {
                        var cols = [];
                        var cell = row.getElementsByTagName("td");
                        for (var col in cell) {
                            cols.push(cell[col].innerHTML);
                        }
                        rowClick(cols);
                    };
                };

            currentRow.onclick = createClickHandler(currentRow);
        }
    });

});
function rowClick(currentRow) {

}