var dataTable;

$(document).ready(function () {
    LoadDataTable();
});
var baseUrl = "Components/Images/Abouts/";
function LoadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/About/GetAll"
        },
        "columns": [
            {
                "data": "imageUrl", "name": "imageUrl", "defaultContent": "<i>-</i>",
                "render": function (data, type, row, meta) {

                    return '<img src=' + baseUrl + data + ' class="img-datatable" />';;
                }, "width": "5%"
            },
            {
                "data": "imageUrl2", "name": "imageUrl2", "defaultContent": "<i>-</i>",
                "render": function (data, type, row, meta) {

                    return '<img src=' + baseUrl + data + ' class="img-datatable" />';;
                }, "width": "5%"
            },
            { "data": "text1", "width": "5%" },
            { "data": "text2", "width": "5%" },
            { "data": "text3", "width": "5%" },
            { "data": "text_ar1", "width": "5%" },
            { "data": "text_ar2", "width": "5%" },
            { "data": "text_ar3", "width": "5%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                <a class="btn-primary btn" href="./About/Upsert?id=${data}"><i class="bi bi-pencil-square"></i></a>
                           `
                },
                "width": " 5%"
            }
        ]
    });
}

function Delete(url) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    if (data.success) {
                        dataTable.ajax.reload();
                        toastr.success(data.message);
                    } else {
                        toastr.error(data.message);
                    }
                }
            })
        }
    })
}