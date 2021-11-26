function goToVideogame(videogameId){
    window.location.href = `company.html?companyId=${videogameId}`;
}


window.addEventListener('load', (event) => {

    if(!Boolean(sessionStorage.getItem("jwt"))){
        window.location.href = "index.html";
    }

  

    async function fetchDataAsync() {
        try {
            debugger;
            const response = await fetch('http://localhost:9236/api/companies', {
                headers: { 
                    "Content-Type": "application/json; charset=utf-8",
                    "Authorization": `Bearer ${sessionStorage.getItem("jwt")}`  
                },
                method: 'GET'
            })
            
            const json = await response.json();
            document.querySelector('body .container').innerHTML = '<ul>' + json.map(function (company) {
                return '<li>' + company.name + ' - ' + company.country +  `<button type="button" onclick="goToVideogame(${company.id})">View</button> ` + '</li>';
            }).join('') + '</ul>'
        } catch (error) {
            console.log(error);
        }
    }

    

    fetchDataAsync();
});