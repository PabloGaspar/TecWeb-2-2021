document.addEventListener('DOMContentLoaded', function(event) {

    let people = [];

    const baseUrl = 'http://localhost:5077/api'
    
    async function fetGetPeople()
    {
        debugger;
        let response = await fetch(`${baseUrl}/people`);
        if(response.status === 200){
            var data = await response.json();
            var peopleLiMapped = data.map(p => `<li> NAME: ${p.name} | AGE: ${p.age} </li>`);
            var peopleContent = `<ul style="color:blue;"> ${peopleLiMapped.join('')} </ul>`;
            document.getElementById('people-list-content').innerHTML = peopleContent;
            people = data;

        } else { 
            var error = await response.text();
            alert(error)
        }
    }

    function fetchPostPeople(event)
    {
        debugger;
        console.log(event.currentTarget);
        event.preventDefault();

        var person = {
            name: event.currentTarget.name.value,
            age: parseInt(event.currentTarget.age.value)
        };

        var personJson = JSON.stringify(person)

        let url = `${baseUrl}/people`;

        fetch(url, {
            headers: { "Content-Type": "application/json; charset=utf-8" },
            method: 'POST',
            body: personJson
        }).then((response) => {
            if (response.status === 201) {
                alert("person created successfuly");
                fetGetPeople();
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

    document.getElementById('fetch-btn').addEventListener('click', fetGetPeople);
    document.getElementById('fetch-frm').addEventListener('submit', fetchPostPeople)

    /*function fetGetPeople()
    {
        debugger;
        fetch(baseUrl)
        .then((response) =>{ 
            if(response.status === 200){
                response.json().then((data) => {
                    var peopleLiMapped = data.map(p => `<li> NAME: ${p.name} | AGE: ${p.age} </li>`);
                    var peopleContent = `<ul style="color:blue;"> ${peopleLiMapped.join('')} </ul>`;
                    document.getElementById('people-list-content').innerHTML = peopleContent;
                });
            } else { 
                response.text().then((error)=>{alert(error)});
            }
        });
    }*/

});