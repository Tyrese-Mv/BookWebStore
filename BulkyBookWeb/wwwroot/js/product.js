﻿var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Admin/Product/GetAll"
        },
        "columns": [
            { "data": "title", "width": "15%" },
            { "data": "isbn", "width": "15%" },
            { "data": "price", "width": "15%" },
            { "data": "author", "width": "15%" },
            { "data": "category.name", "width": "15%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                           <div>
                    <a href="/Admin/Product/Upsert?id${data}" class="btn btn-success" ><i class="bi bi-pencil-square"></i> &nbsp;Edit</a> |
                    <a class="btn btn-danger" "><i class="bi bi-x-circle-fill"></i> &nbsp;Delete</a>
                </div>
                        `
                },
                "width": "15%"
            }
        ]
    });
}