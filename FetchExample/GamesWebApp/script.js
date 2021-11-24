document.addEventListener('DOMContentLoaded', function(event) {

    let people = [];

    const baseUrl = 'http://localhost:5077/api/people'
    
    function fetGetPeople()
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
    }

    document.getElementById('fetch-btn').addEventListener('click', fetGetPeople);
});