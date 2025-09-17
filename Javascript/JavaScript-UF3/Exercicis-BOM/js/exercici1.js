/* 
    Primer fem una funcio que ens agafi l'imput
*/

const ls = localStorage;
const $boto = document.querySelector("#boto");

function agafarImput() {
  const $color = document.getElementById("color").value;

  ls.setItem("colorFons", $color);

  console.log(ls.getItem("colorFons"));
}

$boto.onclick = agafarImput;

function carregarPagina() {
  var body = document.getElementById("body");
  body.style.backgroundColor = ls.getItem("colorFons");
}

document.addEventListener("DOMContentLoaded", carregarPagina);
