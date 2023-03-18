var dataTable;

$(document).ready(function () {
    LoadDataTable();
});
var baseUrl = "http://www.imshah.com/Components/Images/Partners/";
function LoadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Partner/GetAll"
        },
        "columns": [
            {
                "data": "imageUrl", "name": "imageUrl", "defaultContent": "<i>-</i>",
                "render": function (data, type, row, meta) {

                    return '<img src=' + baseUrl + data + ' class="img-datatable" style="width:100%;object-fit:contain; height:100px;" />';;
                }, "width": "15%"
            },
            { "data": "name", "width": "15%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                <a class="btn-primary btn" href="./Partner/Upsert?id=${data}"><i class="bi bi-pencil-square"></i></a>
                <a class="btn-danger btn" onClick="Delete('./Partner/DeleteItem/${data}')" ><i class="bi bi-trash3"></i></a>
                           `
                },
                "width": "15%"
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