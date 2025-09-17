// Array enters al quadrat

function Arrayalquadrat(array) {
  if (array === undefined) {
    console.error("L'array es undefined");
    return;
  } else if (!Array.isArray(array)) {
    console.error("Te que ser un array");
    return;
  } else if (array.length === 0) {
    console.error("El array te que estar ple");
    return;
  } else {
    for (let index = 0; index < array.length; index++) {
      if (typeof array[index] !== "number") {
        console.error("El array te que tindrer valors numerics");
        return;
      }
    }
    let arrayQuadrat = new Array(array.length);
    for (let index = 0; index < array.length; index++) {
      let quadrat = Math.pow(array[index], 2);
      arrayQuadrat[index] = quadrat;
    }
    return arrayQuadrat;
  }
}

const arrayQuadrat = Arrayalquadrat([2, 5, 6, 3, 4, 6]);

console.log(arrayQuadrat);

// Max - Min d'un array

function maxMinArray(array) {
  if (array === undefined) {
    console.error("L'array es undefined");
    return;
  } else if (!Array.isArray(array)) {
    console.error("Te que ser un array");
    return;
  } else if (array.length <= 1) {
    console.error("El array te que estar ple o mes de 1 numero");
    return;
  } else {
    for (let index = 0; index < array.length; index++) {
      if (typeof array[index] !== "number") {
        console.error("El array te que tindrer valors numerics");
        return;
      }
    }
    let max = array[0];
    for (let index = 0; index < array.length; index++) {
      if (array[index] > max) {
        max = array[index];
      }
    }
    let min = array[0];
    for (let index = 0; index < array.length; index++) {
      if (array[index] < min) {
        min = array[index];
      }
    }
    return `De l'array, el numero mes gran es ${max}, i el numero mes petit es ${min}`;
  }
}

const maxMin = maxMinArray([
  87, 12, 54, 3, 99, 42, 76, 28, 65, 7, 33, 91, 18, 60, 45, 26, 81, 69, 5, 39,
]);

console.log(maxMin);

// Objete amb arrays parells i senars

function ObjectArrays(array) {
  if (array === undefined) {
    console.error("L'array es undefined");
    return;
  } else if (!Array.isArray(array)) {
    console.error("Te que ser un array");
    return;
  } else if (array.length === 0) {
    console.error("El array te que estar ple");
    return;
  } else {
    for (let index = 0; index < array.length; index++) {
      if (typeof array[index] !== "number") {
        console.error("El array te que tindrer valors numerics");
        return;
      }
    }

    let arrayParells = new Array();
    let arraySenars = new Array();

    let p = 0,
      s = 0;

    for (let index = 0; index < array.length; index++) {
      if (array[index] % 2 === 0) {
        arrayParells[p] = array[index];
        p++;

        // arrayParells.push(array[index]);
      } else {
        arraySenars[s] = array[index];
        s++;
      }
    }
    const objecte = {
      parells: arrayParells,
      senars: arraySenars,
    };

    return objecte;
  }
}

const resObj = ObjectArrays([
  87, 12, 54, 3, 99, 42, 76, 28, 65, 7, 33, 91, 18, 60, 45, 26, 81, 69, 5, 39,
]);

console.log(resObj);
