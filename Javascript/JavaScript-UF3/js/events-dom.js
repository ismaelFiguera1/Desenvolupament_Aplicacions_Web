function holaMon() {
  alert("Event cridat desde una funcio");
  console.log(event);
}

function holaMon1(nom = "desconegut") {
  alert(`Hola ${nom}`);
  console.log(event);
}

const $eventSemantic = document.querySelector("#event-semantic");
$eventSemantic.onclick = holaMon; //  Compte, holaMon va sense parentesis

//  Alternatives
//  Com una funcio anonima
$eventSemantic.onclick = function () {
  alert("Event cridat com una funcio anonima");
};

//  2 Amb arrowfunctions

$eventSemantic.onclick = () => alert("Event cridat com una arrowfunction");
/*  Com que el que s'executa de l'arrowfunction es sol una linea, no van les "{}"   */

const $eventMultiple = document.getElementById("event-multiple");

//  addEventListener es per executar diverser coses en la mateixa accio

$eventMultiple.addEventListener("click", holaMon);
$eventMultiple.addEventListener("click", () => {
  alert("Segon handler sobre el click");
});
$eventMultiple.addEventListener("click", () => {
  holaMon1("Ismael");
});
/*  
Compte, no es onclick sino en "click"
La crida de la funcio va sense parentesis
*/

$eventMultiple.addEventListener("dblclick", () => alert("doble click 3.0"));

const $eventDobleClick = document.getElementById("event-dblclick");

$eventDobleClick.addEventListener("dblclick", function () {
  alert("doble click 2.0");
});

//  remove event click      nomes funciona si s'utilitza diferents events amb addeventlistener

/*
La 
*/

const removeEventClick = (e) => {
  alert(`eliminant l'event ${e.type}`);
  $removeEvent.removeEventListener("click", removeEventClick);
  // $removeEvent.disabled = true;
};

const $removeEvent = document.getElementById("remove-event");

$removeEvent.addEventListener("click", removeEventClick);
$removeEvent.addEventListener("dblclick", () => alert("doouble click"));

/* Flux d'events --- Bombolla i captura */

const $divEvents = document.querySelectorAll(".flux-events div");

console.log($divEvents);

function fluxEvents(e) {
  console.log(`Hola, soc ${this.className}, origen ${e.target.className}`);
  e.stopPropagation();
}

//  assignarem dinamicament listeners

$divEvents.forEach((div) => {
  //  div.addEventListener("click", fluxEvents /*{ once: true }*/);
});

const $linkEvents = document.querySelector(".flux-events a");

console.log($linkEvents);

$linkEvents.addEventListener("click", (e) => {
  // alert("Has fet click a google");
  e.preventDefault(); //  Cancela l'accio per defecte
  //e.stopPropagation();
});

/*
    Delegacio d'events al DOM
*/
/*
    La idea es delegar events a un element pare o superior, a partir de aqui cal detectar el node o element que ha activat l'event i llavors desencadenar la programacio. exemple: en un formulari podriam assignar l'event a nivell de formulari en comptes de fero per cada input, inclus podriem delegar l'event al document.
    
    Amb  un sol listener detectem l'element que ha desencadenat l'event i actuem en consequencia.
    A mes no hi ha propagacio perque l'element es al nivell superior
*/

document.addEventListener("click", (e) => {
  alert(`Event click capturat al document ${e.target}`);
  if (e.target.matches(".flux-events a")) {
    alert("L'ha trobat");
    e.preventDefault();
  }
});

/*




AQUEST DIA VAIG FALTAR



*/

/*
    Eevent DOMContentLoaded
*/

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

window.addEventListener("load", (e) => {
  console.log("******** Content Load *********");
  console.log(window.screenX);
  console.log(window.screenY);
});
