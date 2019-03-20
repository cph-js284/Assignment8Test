// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function AddPizza(){
    if(document.getElementById('pizzaselect_id').selectedIndex === 0){
        alert("Please select a pizza");
    }else{
        document.getElementById('ordercsv_id').value += document.getElementById('pizzaselect_id').selectedIndex + ",";
        document.getElementById('currentorders_id').innerHTML += document.getElementById('pizzaselect_id').value + '<br />';
    }
}