window.addEventListener('load', (event) => {

    const baseUrl = 'http://localhost:9236/api';
    
    function login(event) {
        debugger;
        console.log(event.currentTarget);
        event.preventDefault();
        const url = `${baseUrl}/auth/Login`;

        if(!Boolean(event.currentTarget["user-name"].value)){
            var usernameErrorElement = document.getElementById("login-errors");
            usernameErrorElement.textContent= "username is requered"
            usernameErrorElement.style.display = "block"
            return;
        }    


        var data = {
            Email: event.currentTarget["user-name"].value,
            Password: event.currentTarget.password.value
        }

        fetch(url, {
            headers: { "Content-Type": "application/json; charset=utf-8" },
            method: 'POST',
            body: JSON.stringify(data)
        }).then((response) => {
            if (response.status === 200) {
                
                response.json().then((data)=>{
                    debugger;
                    sessionStorage.setItem("jwt", data.token);
                    window.location.href = "companies.html";
                    
                });
            } else {
                response.text().then((data) => {
                    debugger;
                    console.log(data);
                });
            }
        }).catch((response) => {

            debugger;
            console.log(data);
        });

    }

    document.getElementById("login-frm").addEventListener("submit", login);

});




//     function fetchData(){
//         fetch('http://localhost:57891/api/values')
//         .then(function(response){
//             console.log( response);
//             if(response.status === 200){
//                 return response.json();
//             } else{
//                 console.log(response);
//             }

//         })
//         .catch(error => console.error('Error:', error))
//         .then((data) =>{
//             console.log(data);
//         } )
//     }
//     document.getElementById('fetchBtn').addEventListener('click', fetchData);
//   });


// //https://www.freecodecamp.org/news/a-practical-es6-guide-on-how-to-perform-http-requests-using-the-fetch-api-594c3d91a547/
// //document.querySelector("input[type=button]").addEventListener("click", fetchData);
// document.getElementById("fetchbtn").addEventListener("click", fetchData);
// document.getElementById("postbtn").addEventListener("click", postData);
// document.getElementById("myForm").addEventListener("submit", postData);

// function fetchData(){
//     fetch('http://localhost:57891/api/values')
//     .then((res) => {
//         console.log('res:', res);
//         return res.json()})
//     .catch(error => console.error('Error:', error))
//     .then((json) => {
//         console.log('Success:', json)

//         document.querySelector('body .container').innerHTML = '<ul>' + json.map(function (element) {
//             return '<li>' + element + '</li>';
//         }).join('') + '</ul>'
//     });
// }

// async function fetchDataAsync(){
//     try {
//         const response = await fetch('http://localhost:57891/api/values');
//         const json = await response.json();
//         document.querySelector('body .container').innerHTML = '<ul>' + json.map(function (element) {
//             return '<li>' + element + '</li>';
//         }).join('') + '</ul>'
//     } catch (error) {
//         console.log(error);
//     }


// }

// function postData (event){
//     console.log('event target', event.target.elements.name.value);
//     event.preventDefault();
//     var url = 'http://localhost:57891/api/values';
//     //var data = {username: 'example'};
//     var data = 'example';
//     fetch(url, {
//     method: 'POST', // or 'PUT'
//     body: JSON.stringify(data), // data can be `string` or {object}!
//     headers:{
//         'Content-Type': 'application/json'
//     }
//     }).then((res) => {
//         return res.json()})
//     .catch(error => console.error('Error:', error))
//     .then((response) => {
//         console.log('Success:', response)
//     });
// }

