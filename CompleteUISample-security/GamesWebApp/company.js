window.addEventListener('load', (event) => {
    if(!Boolean(sessionStorage.getItem("jwt"))){
        window.location.href = "index.html";
    }
    
    var queryParams = window.location.search.split('?');
    var companyId= queryParams[1].split('=')[1];

    document.getElementById("companyId").textContent= companyId;
    async function getCompany(){
        var response = await fetch(`http://localhost:9236/api/companies/${companyId}`, {
            headers: { 
                "Content-Type": "application/json; charset=utf-8",
                "Authorization": `Bearer ${sessionStorage.getItem("jwt")}`  
            },
            method: 'GET'
        });
        var data = await response.json();
        var editForm = document.getElementById('edit-frm');
        editForm.name.value = data.name;
        editForm.country.value = data.country;
    }

    getCompany();
    
});