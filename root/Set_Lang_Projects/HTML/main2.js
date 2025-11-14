

window.addEventListener('load', () => {
    const form = document.querySelector('#new-task-form');
    const input = document.querySelector('#new-task-input');
    const list_el = document.querySelector('#tasks');
    const year = document.getElementById('cur_year');
    function updateTime(){
        const currentDate = new Date();
        // Format the date and time according to the locale settings
        const options = { 
            year: 'numeric', 
            month: '2-digit', 
            day: '2-digit', 
            hour: '2-digit', 
            minute: '2-digit', 
            second: '2-digit',
            hour12: false // 24-hour format
        };
        const formattedDateTime = currentDate.toLocaleString('en-US', options);

        // Display the current date and time in the span element
        document.getElementById("date-time").textContent = formattedDateTime;

        year.innerHTML = new Date().getFullYear();
    }

    updateTime();

    setInterval(updateTime, 1000);
    

    // Load tasks from local storage when the page loads
    const tasks = JSON.parse(localStorage.getItem('tasks')) || [];
    tasks.forEach((task) => {
        const task_el = createTaskElement(task);

        list_el.appendChild(task_el);
    });

    form.addEventListener('submit', (e) => {
        e.preventDefault();

        const task_raw = input.value;
        const task = task_raw[0].toUpperCase() + task_raw.slice(1)


        if(!task){
            alert("Please fill out the task");
            return;
        }
        
        const task_el = createTaskElement(task);
        list_el.appendChild(task_el);

        // Save tasks to local storage
        tasks.push(task);
        localStorage.setItem('tasks', JSON.stringify(tasks));

        input.value = "";
    });

    function createTaskElement(task) {
        const task_el = document.createElement('div');
        task_el.classList.add("task");

        const task_content_el = document.createElement('div');
        task_content_el.classList.add("content");

        
        task_el.appendChild(task_content_el);


        const task_input_el = document.createElement('input');
        task_input_el.classList.add("text");
        task_input_el.type = 'text';
        task_input_el.value = task;
        task_input_el.setAttribute("readOnly", "readOnly");

        task_content_el.appendChild(task_input_el);

        const task_action_el =  document.createElement('div');
        task_action_el.classList.add("actions");

        const task_check_el = document.createElement('input');
        task_check_el.type = "checkbox"
        task_check_el.classList.add("checked")

        task_action_el.appendChild(task_check_el);


        const task_edit_el = document.createElement("button");
        task_edit_el.classList.add("edit");
        task_edit_el.innerHTML ="Edit";

        const task_delete_el = document.createElement("button");
        task_delete_el.classList.add("delete");
        task_delete_el.innerHTML ="Delete";

        
        task_action_el.appendChild(task_edit_el);
        task_action_el.appendChild(task_delete_el);

        task_el.appendChild(task_action_el);

        task_check_el.addEventListener("change", () => {
           if(task_check_el.checked) {
            task_input_el.classList.add("completed");
            }else{
            task_input_el.classList.remove("completed");
 
           }
        });

        task_edit_el.addEventListener("click", () => {
            if (task_edit_el.innerText.toLowerCase() == "edit") {
                task_input_el.removeAttribute("readonly");
                task_input_el.focus();
                task_edit_el.innerText = "Save";
            }else{
                task_input_el.setAttribute("readonly", "readonly");
                task_edit_el.innerText = "Edit";

                // Update task in local storage
                const index = tasks.indexOf(task);
                if (index !== -1) {
                    tasks[index] = task_input_el.value;
                    localStorage.setItem('tasks', JSON.stringify(tasks));
                }
            }
        });

        task_delete_el.addEventListener("click", () => {
            list_el.removeChild(task_el);

            // Remove task from local storage
            const index = tasks.indexOf(task);
            if (index !== -1) {
                tasks.splice(index, 1);
                localStorage.setItem('tasks', JSON.stringify(tasks));
            }
        });

        return task_el;
    }
});