

$(document).ready(function () {

    //GET SINGLE EMPLOYEE FROM DATABASE
    $('#getEmp').click(function () {
        var inputId = $('#empId').val();
        if (inputId > 0) {
            var urls = 'https://localhost:44376/api/Employee/' + inputId;
            fetch(urls)
                .then((response) => {
                    return response.json();
                })
                .then((myJson) => {
                    console.log(myJson);
                    if (myJson != null) {
                        $(myJson).each(function (index, item) {
                            $('#firstName').val((`${item.FirstName}`));
                            $('#lastName').val((`${item.LastName}`));
                            $('#companyName').val((`${item.CompanyName}`));
                        })
                    } else {
                        alert('No Employee with Id = ' + inputId);
                    }
                });
        } else {
            $('#empId').val('Id required');
        }
    })

    //ADD EMPLOYEE TO THE DATABASE
    $('#addEmp').click(function () {
        var firstN = $('#firstName').val();
        var lastN = $('#lastName').val();
        var companyN = $('#companyName').val();
        if (firstN.length > 0 && lastN.length > 0 && companyN.length > 0) {
            const employee = {
                'FirstName': firstN,
                'LastName': lastN,
                'CompanyName': companyN
            };
            const option = {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(employee)
            };

            fetch("https://localhost:44376/api/Employee", option)
                .then(response => {
                    console.log(response);
                    var lastIdAdded = $('#lastAddedId');
                    if (response.status == 201) {
                        lastIdAdded.css({ 'background-color': 'green', 'color': 'white' });
                    } else {
                        lastIdAdded.css({'background-color': 'red', 'color': 'white'})
                        lastIdAdded.html('Unsuccessful transaction');
                    }
                    response.json().then((myJson) => {
                        console.log(myJson);
                        $(myJson).each(function (index, item) {
                            lastIdAdded.html(`Employee Id = ${item.Id}`);
                        });
                        
                    });
            });
        } else {
            $('#firstName').val('First Name required');
            $('#lastName').val('Last Name required');
            $('#companyName').val('Company Name required');
        }
    });


    //GET ALL EMPLOYE FROM DATABASE
    $('#getAllEmployee').click(function () {
        var employeestbl = $('#tblEmployee tbody');
            var urls = 'https://localhost:44376/api/Employee/';
            fetch(urls)
                .then((response) => {
                    return response.json();
                })
                .then((myJson) => {
                    employeestbl.empty();
                    if (myJson != null) {
                        $(myJson).each(function (index, emp) {
                            employeestbl.append(`<tr><td>${emp.Id}</td><td>${emp.FirstName}</td><td>${emp.LastName}</td><td>${emp.CompanyName}</td></tr>`);  
                        })
                    } else {
                        alert('No Employee with Id = ' + inputId);
                    }
                });
    });


    ////// Example POST method implementation:
    ////$('#addEmp').click(function () {
    ////    //var firstN = $('#firstName').val();
    ////    //var lastN = $('#lastName').val();
    ////    //var companyN = $('#companyName').val();
        
    ////    async function postData(url = 'https://localhost:44376/api/Employee',
    ////        data = {
    ////            'FirstName': 'Sir',
    ////            'LastName': Noble,
    ////            'CompanyName': 'NNPC'
    ////        }) {
    ////        // Default options are marked with *
    ////        const response = await fetch(url, {
    ////            method: 'POST', // *GET, POST, PUT, DELETE, etc.
    ////            mode: 'cors', // no-cors, *cors, same-origin
    ////            cache: 'no-cache', // *default, no-cache, reload, force-cache, only-if-cached
    ////            credentials: 'same-origin', // include, *same-origin, omit
    ////            headers: {
    ////                'Content-Type': 'application/json'
    ////                // 'Content-Type': 'application/x-www-form-urlencoded',
    ////            },
    ////            redirect: 'follow', // manual, *follow, error
    ////            referrerPolicy: 'no-referrer', // no-referrer, *client
    ////            body: JSON.stringify(data) // body data type must match "Content-Type" header
    ////        });
    ////        return await response.json(); // parses JSON response into native JavaScript objects
    ////        console.log(response.json);
    ////    }
    ////});








   /* var textBox = $('input[type = "text"]');
    textBox.focus(function () {
        var helpDiv = $(this).attr('id') + 'HelpDiv';
        $('#' + helpDiv).load('Help.html #' + helpDiv);
    });
    textBox.blur(function () {
        var helpDiv = $(this).attr('id') + 'HelpDiv';
        $('#' + helpDiv).html('');
    });*/

});


////if ('geolocation' in navigator) {
////    console.log('geolocation available');
////    navigator.geolocation.getCurrentPosition(position => {
////        const lat = position.coords.latitued;
////        const lon = position.coords.longitude;
////        document.getElementById('latitude').textContent = lat;
////        document.getElementById('longitude').textContent = lon;
////        // console.log(position);

////        const data = { lat, lon };
////        const options = {
////            method: 'POST',
////            headers: {
////                'Content-Type': 'application/json'
////            },
////            body: JSON.stringify(data)
////        };
////        fetch("/api", options).then(response => {
////            console.log(response);
////        });
////    });
////} else {
////    console.log('geolocation not available');
////}