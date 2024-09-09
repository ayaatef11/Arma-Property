let dataTable;

$(document).ready(() => {

    $(".select2").select2({
        allowClear: false,
    });

    $('#js-ListProperties').addClass('active');
    $('#js-TreeView-Settings').addClass("menu-open");

    dataTable = $("#js-TableProperties").DataTable({
        paging: true,
        ordering: true,
        info: false,
        autoWidth: true,
        searching: false,
        responsive: true,
        "jQueryUI": true,
        "serverSide": true,
        "filter": true,
        "processing": true,

        "language": {
            "processing": `<div class="overlay new-loading">
                <img alt="loading" src="/Images/Loader/03-42-11-849_512.gif" />
            </div>`,
            "lengthMenu": "عرض _MENU_ السجلات لكل صفحة",
            "zeroRecords": "عفوا لا توجد بيانات للعرض",
            "info": "عرض الصفحة _PAGE_ من _PAGES_",
            "infoEmpty": "لا توجد سجلات متاحة",
            "infoFiltered": "(تصفية من  _MAX_ اجمالي السجلات)",
            "search": "بحث :",
            "oPaginate": {
                "sPrevious": "السابق",
                "sNext": "التالي",
                "sFirst": "الاول",
                "sLast": "الاخير",
                "copy": "نسخ"
            },
        },
        "ajax": {
            "url": "/Properties/GetProperties",
            "type": "POST",
            "data": function (data) {
                data.search = $("#Search").val();
                data.ownerId = $("#Owner").val();
                data.propertyTypeId = $("#Type").val();
                data.properTystatusId = $("#Status").val();
            }
        },
        order: [[0, 'desc']],
        "columnDefs": [{
            "targets": [0],
            "visible": true,
            "searchable": false
        }],
        "columns": [
            { "data": "id" },
            { "data": "name" },
            { "data": "ownerName" },
            { "data": "propertyTypeName" },
            { "data": "area" },
            { "data": "rent" },
            { "data": "propertyStatusName" },
            { "data": "id", "render": function (data, type, row) {
                    return `<div class="dropdown text-center">
                                    <a class="text-info" href="#" id="dropdownMenu2" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                        <i class="fa fa-bars"></i>
                                    </a>
                                    <div class="dropdown-menu text-center" aria-labelledby="dropdownMenu2">
                                        <a class="text-info dropdown-item" href="/Properties/Edit/${row.id}"><i class="fas fa-edit"></i> تعديل</a>
                                        <a class="text-danger dropdown-item" href="javascript:;" onclick="OnDelete(${row.id})"><i class="fas fa-trash"></i> حذف</a>
                                    </div>
                                </div>`;
                }
            }
        ],
        //"createdRow": function (row, data, dataIndex) {
        //    if (!data.isActive)
        //        $(row).addClass('disabled');
        //}

    });
});

$('#Owner').on("change", function () {
    dataTable.ajax.reload();
});
$('#Type').on("change", function () {
    dataTable.ajax.reload();
});
$('#Status').on("change", function () {
    dataTable.ajax.reload();
});
$('#SearchButton').on("click", function () {
    dataTable.ajax.reload();
});
$('#Search').on("keyup", function (e) {
    if (e.key === "Enter") {
        e.preventDefault();
        $('#SearchButton').trigger("click");
    }
});
$('#js-btnReset').on('click', () => {
    $("#Search").val('');
    $('#Type').val('');
    $('#Status').val('');
    $('#Owner').val('').trigger("change");
});
function OnDelete(id) {
    Swal.fire({
        title: "هل أنت متأكد؟",
        text: "لن تتمكن من التراجع عن هذا!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "نعم، احذفه!",
        cancelButtonText: "الغاء"
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: '/Properties/Delete/' + id,
                method:'POST',
                async: true,
                cache: false,
                success: (data) => {
                    console.warn(data,"Data!!!!!!!!!")
                    if (data === "Ok") {
                        Swal.fire({
                            title: "تم الحذف!",
                            text: "قد تم حذف الملف الخاص بك.",
                            icon: "success"
                        });
                        dataTable.ajax.reload();
                    }
                    if (data === "ExistProperty") {
                        Swal.fire({
                            title: "لم يتم الحذف!",
                            text: "لم يتم الحذف بسبب وجود الوحدة علي عقد.",
                            icon: "error"
                        });
                    }
                    if (data ==="Error"){
                        Swal.fire({
                            title: "لم يتم الحذف!",
                            text: "لم يتم الحذف بسبب وجود مشكلة.",
                            icon: "error"
                        });
                    }
                    
                }, error: (error) => {
                    let err = JSON.stringify(error);
                    console.error('Function Delete Property !!!!!',err);
                }
            })  
        }
    });
}