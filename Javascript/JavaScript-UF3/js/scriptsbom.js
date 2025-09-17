window.addEventListener("resize", (e) => {
  console.clear();
  console.log("********Event resize *********");
  console.log(window.innerWidth);
  console.log(window.innerHeight);
  console.log(window.outerWidth);
  console.log(window.outerHeight);
});

window.addEventListener("scroll", (e) => {
  console.clear();
  console.log("********Event Scroll *********");
  console.log(window.scrollX);
  console.log(window.scrollY);
});

window.addEventListener("load", (e) => {
  console.clear();
  console.log("********Event load *********");
  console.log(window.screenX);
  console.log(window.screenY);
});

//alternatives al load (OLD)
/*
window.load(function)
document.ready(function)
documen.on("ready",function)
*/

document.addEventListener("DOMContentLoaded", (e) => {
  console.log("******** DOM Content Loaded *********");
  console.log(window.screenX);
  console.log(window.screenY);
  console.log(e);
});

/*
    L'elementDOMContentLoaded s'executa quant el document HTML ha estat carregat i parsejat, quan el navegador te totes les etiquetes validades. En canvi, no espera que carreguin els fulls d'estils, les imatges, els scripts... Es per tant la opcio mes optima
*/

const $botoObrir = document.getElementById("obrir-finestra"),
  $botoTancar = document.getElementById("tancar-finestra"),
  $botoImprimir = document.getElementById("imprimir-finestra");

let finestra = undefined;
$botoObrir.addEventListener("click", (e) => {
  finestra = window.open("http://127.0.0.1:5500/bom.html");
});

$botoTancar.addEventListener("click", (e) => {
  finestra.close();
});

$botoImprimir.addEventListener("click", (e) => {
  window.print();
});

// alert, confirm, prompt

window.alert("Exemple de alert");

window.confirm();

if (window.confirm("El javscript es genial")) {
  alert("El JS es genial");
} else {
  alert("El JS NO es genial");
}

window.prompt();

let nom = prompt("Com et dius?");

if (nom === "Ismael") alert("benvingut");
else alert("No ets tu");
