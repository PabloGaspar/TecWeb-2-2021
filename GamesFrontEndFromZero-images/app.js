




window.addEventListener('DOMContentLoaded', function(event){

    let teams = [];
    const baseRawUrl = 'http://localhost:3030';
    const baseUrl = `${baseRawUrl}/api`;
    

    /*function fetchTeams()
    {
        debugger;
        const url = `${baseUrl}/teams`;
        let status;
        fetch(url)
        .then((response) => { 
            status = response.status;
            return response.json();
        })
        .then((data) => {
            if(status == 200)
            {
                console.log(data)
                let teamsLi = data.map( team => { return `<li> Name: ${team.name} | City: ${team.city} | DT: ${team.dtname} </li>`});
                var teamContent = `<ul>${teamsLi.join('')}</ul>`;
                document.getElementById('teams-container').innerHTML = teamContent;
            } else {
                alert(data);
            }
        });
    }*/

    function DeleteTeam(event){
        
        var r = confirm("Are you sure you want to delete it?");
        if (r == true) {
            let teamId = this.dataset.deleteTeamId;
            let url = `${baseUrl}/teams/${teamId}`;
            fetch(url, { 
            method: 'DELETE' 
            }).then((data)=>{
                if(data.status === 200){
                    alert('deleted');
                }
            }); 
            location.reload();
        } 
        
    }

    async function fetchTeams()
    {
        const url = `${baseUrl}/teams`;
        let response = await fetch(url);
        try{
            if(response.status == 200){
                let data = await response.json();
                let teamsLi = data.map( team => { 
                
                const imageUrl = team.imagePath? `${baseRawUrl}/${team.imagePath}` : "";
                return `
                <div> 
                    <div>
                        <img src="${imageUrl}" alt="Avatar" class="roundImage">
                    </div>
                    <div>
                        Name: ${team.name} | City: ${team.city} | DT: ${team.dtName} 
                    </div>
                    <button data-delete-team-id="${team.id}">DELETE</button>
                    <button data-edit-team-id="${team.id}">EDIT</button>
                </div>`});
                var teamContent = teamsLi.join('');
                document.getElementById('teams-container').innerHTML = teamContent;

                let buttons = document.querySelectorAll('#teams-container div button[data-delete-team-id]');
                for (const button of buttons) {
                    button.addEventListener('click', DeleteTeam);
                }
                
            } else {
                var errorText = await response.text();
                alert(errorText);
            }
        } catch(error){
            var errorText = await error.text();
            alert(errorText);
        }
    }
   
    function PostTeam(event)
    {
        debugger;
        event.preventDefault();
        let url = `${baseUrl}/teams`;
        
        if(!event.currentTarget.dtName.value)
        {
            event.currentTarget.dtName.style.backgroundColor = 'red';
            return;
        }

        var data = {
            Name: event.currentTarget.name.value,
            FundationDate: event.currentTarget.fundationDate.value,
            City: event.currentTarget.city.value,
            DTName: event.currentTarget.dtName.value
        };

        fetch(url, {
            headers: { "Content-Type": "application/json; charset=utf-8" },
            method: 'POST',
            body: JSON.stringify(data)
        }).then(response => {
            if(response.status === 201){
                alert('team was created');
                fetchTeams();
            } else {
                response.text()
                .then((error)=>{
                    alert(error);
                });
            }
        });
    }


    function PostFormTeam(event)
    {
        debugger;
        event.preventDefault();
        let url = `${baseUrl}/teams/form`;
        
        if(!event.currentTarget.dtName.value)
        {
            event.currentTarget.dtName.style.backgroundColor = 'red';
            return;
        }
        
        const formData = new FormData();
        formData.append('Name', event.currentTarget.name.value);
        formData.append('FundationDate', event.currentTarget.fundationDate.value);
        formData.append('City',event.currentTarget.city.value);
        formData.append('DTName', event.currentTarget.dtName.value);
        formData.append('Image', event.currentTarget.image.files[0]);
        debugger;
       

        fetch(url, {
            method: 'POST',
            body: formData
        }).then(response => {
            if(response.status === 201){
                alert('team was created');
                fetchTeams();
            } else {
                response.text()
                .then((error)=>{
                    alert(error);
                });
            }
        });
        fetchTeams();
    }
    

    fetchTeams();
    document.getElementById('fetch-btn').addEventListener('click', fetchTeams);
    document.getElementById('create-team-frm').addEventListener('submit', PostTeam)
    document.getElementById('create-team-form-frm').addEventListener('submit', PostFormTeam)
});

//https://www.freecodecamp.org/news/a-practical-es6-guide-on-how-to-perform-http-requests-using-the-fetch-api-594c3d91a547/