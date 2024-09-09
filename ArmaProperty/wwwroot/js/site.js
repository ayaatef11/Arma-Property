

ShowMassage = (type, title, body) => {
     
    if (type == 'Seccess') {

        Swal.fire({
            title: title,
            text: body,
            confirmButtonText: 'نعم',
            icon: 'success'
        });
    }
    else {

        Swal.fire({
            title: title,
            text: body,
            confirmButtonText: 'نعم',
            icon: 'error'
        });
    }
}



