var dataTable;

$(document).ready(function () {
    LoadDataTable();
});

function LoadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Information/GetAll"
        },
        "columns": [
            { "data": "email", "width": "5%" },
            { "data": "phone", "width": "5%" },
            { "data": "findUs", "width": "5%" },
            { "data": "findUs_ar", "width": "5%" },
            { "data": "workinghours", "width": "5%" },
            { "data": "facebook", "width": "5%" },
            { "data": "twiter", "width": "5%" },
            { "data": "instgram", "width": "5%" },
            { "data": "tiktok", "width": "5%" },
            { "data": "getAquote", "width": "5%" },
            { "data": "getAquote_ar", "width": "5%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                <a class="btn-primary btn" href="./Information/Upsert?id=${data}"><i class="bi bi-pencil-square"></i></a>
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