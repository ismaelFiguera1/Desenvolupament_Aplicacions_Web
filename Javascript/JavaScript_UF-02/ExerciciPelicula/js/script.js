import { Pelicula } from "./Pelicula.js";
/*
const peli = new Pelicula(
  "1ghOP6987",
  "Colmillo blanco",
  "jose",
  1998,
  ["Spain", "France"],
  ["Game-Show", "History", "Romance", "Western"],
  4.6
);

console.log(peli);
*/
const arrayInfo = new Array(
  [
    "abcdefgh1",
    "Narnia",
    "Spielberg",
    2004,
    ["Spain", "France"],
    ["Action"],
    2.3,
  ],
  [
    "mnbvcxzñ0",
    "Colmillo Blanco",
    "Randal Kleiser",
    1991,
    ["Colombia", "Bolivia", "Uruguay", "Honduras"],
    ["Adventure", "Biography"],
    5.7,
  ],
  [
    "poi333re7",
    "The bear",
    "Jean-Jacques Annaud",
    1988,
    ["China", "Japan", "Taiwan", "S. Corea", "Vietnam"],
    ["Drama", "Adventure", "Documentary", "Biography"],
    7.1,
  ]
);

const pelicula2 = new Pelicula(arrayInfo);

console.log(pelicula2);


let a;
