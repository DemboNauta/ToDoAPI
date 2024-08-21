document.addEventListener("DOMContentLoaded", ()=>{
    getTareas()

    let boton = document.getElementById("boton")
    boton.addEventListener("click", ()=>{
        let title = document.getElementById("title").value
        let description = document.getElementById("description").value
        fetch("http://localhost:5261/api/tasks", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify({
                "title": `${title}`,
                "description": `${description}`,
                "startDate": "2024-08-21T11:53:28.601Z",
                "endDate": "2024-08-21T11:53:28.601Z",
                "assignedUserId": 0,
                "projectId": 0
            })
                
        }).then(()=>{getTareas()})
    })
    
    
});

function getTareas(){
    fetch("http://localhost:5261/api/tasks").then(response=>response.json()).then((tasks)=>{
        let list = document.getElementById("list")
        while (list.firstChild) {
            list.removeChild(list.firstChild);
          }
        for(let task of tasks){
            console.log(task)
            let newTask= document.createElement("li")
            newTask.textContent=task.title;
            newTask.classList.add("list-group-item")
            newTask.addEventListener("click", ()=>{console.log(task.id)})
            list.appendChild(newTask)
        }
    })
}