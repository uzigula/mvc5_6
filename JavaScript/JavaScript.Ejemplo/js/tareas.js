var plantilla = '<li class="task"><input class="complete" type="checkbox"/>' +
'<input class="description" type="text" placeholder="Ingresa la descripcion de la tarea"/>' +
'<button class="delete-button">Borrar</button></li>';

function mapeaTarea(tarea) {
    var $tarea = $(plantilla) // plantilla es una variable de texto con el html de una tarea

    if (tarea.terminada) {
        $tarea.find(".complete").attr("checked","checked")
    }
    $tarea.find(".description").val(tarea.descripcion);
    return $tarea;
}

function nuevaTarea() {
    var $listaTareas = $("#task-list");
    $listaTareas.prepend(mapeaTarea({}));
}


function eliminarTarea(eventData) {
    //$(eventData.target).parents("li").remove();
    $(this).parents("li").remove();
    //$(eventData.target).closest(".task").remove();
    console.log("borrado");
}


// repositorio de datos

var Repositorio = "lista_tareas"; // la llave para local storage

// tareas es un arreglo de tarea
function grabarTareas(tareas) {
    localStorage.setItem(Repositorio, JSON.stringify(tareas));
}

function grabar() {
    var tareas = []; // declara un arreglo

    $("#task-list .task").each(function (indice, tarea) {
        var $tarea = $(tarea);
        tareas.push(
            {
                terminada: $tarea.find(".complete").prop("checked"),
                descripcion: $tarea.find(".description").val()
            }
            );
    });

    grabarTareas(tareas);

}


function leerTareas() {
    var tareas = localStorage.getItem(Repositorio);

    if (tareas) return JSON.parse(tareas);

    return [];

}


function mostrar(tareas){
    var listaTareas = [];
    tareas.forEach(function (tarea, indice) {
        listaTareas.push(mapeaTarea(tarea));
    });

    $("#task-list")
        .empty()
        .append(listaTareas);
}
//IIFE
$(function () {
    $("#new-task-button").on("click", nuevaTarea);
    $("#task-list").on("click", ".delete-button", eliminarTarea);
    $("#save-button").on("click", grabar);
    mostrar(leerTareas());
});