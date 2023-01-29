var dataTable;

$(document).ready(function () {
    LoadDataTable();
});

function LoadDataTable() {
 
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Goal/GetAll"
        },
        "columns": [
            {
                "data": "imageUrl", "name": "imageUrl", "defaultContent": "<i>-</i>",
                "render": function (data, type, row, meta) {
                 
                    return '<img src="' + data + '" class="img-datatable" />';
                }, "width": "5%"
            },
            { "data": "name", "width": "5%" },
            { "data": "name_ar", "width": "5%" },
            { "data": "text", "width": "25%" },
            { "data": "text_ar", "width": "25%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                <a class="btn-primary btn" href="./Goal/Upsert?id=${data}"><i class="bi bi-pencil-square"></i></a>
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