var dataTable;

$(document).ready(function () {
    LoadDataTable();
});

function LoadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Quotes/GetAll"
        },
        "columns": [
            { "data": "fullName", "width": "5%" },
            { "data": "companyName", "width": "5%" },
            { "data": "email", "width": "5%" },
            { "data": "subject", "width": "5%" },
            { "data": "message", "width": "5%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                <a class="btn-danger btn" href="./Quotes/Delete?id=${data}" ><i class="bi bi-trash3"></i></a>
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