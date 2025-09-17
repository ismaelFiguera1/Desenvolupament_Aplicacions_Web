// Array sense repetits

function arraySenseRepetits(array) {
  if (array === undefined) {
    console.error("L'array no pot ser undefined");
    return;
  } else if (array.length <= 1) {
    console.error("Te que haver mes d'un valor");
    return;
  } else {
    const set = new Set(array);
    const arrayNET = Array.from(set);
    let a;
    return arrayNET;
  }
}

const arrayNet = arraySenseRepetits([
  42,
  "Hola",
  true,
  3.14,
  "Adeu",
  false,
  100,
  "Hola",
  42,
  true,
  "JavaScript",
  0,
  "Test",
  false,
  99,
  true,
  "Hola",
  3.14,
  "OpenAI",
  42,
  true,
  "Hola",
  false,
  "Test",
  1,
  "Examen",
  0,
  99,
  100,
  "Adeu",
]);

console.log(arrayNet);

// Valor mitja d'array d'enters

function Mitjana(array) {
  if (array === undefined) {
    console.error("L'array es undefined");
    return;
  } else if (!Array.isArray(array)) {
    console.error("Te que ser un array");
    return;
  } else if (array.length === 0) {
    console.error("El array te que estar ple o mes de 1 numero");
    return;
  } else {
    for (let index = 0; index < array.length; index++) {
      if (typeof array[index] !== "number") {
        console.error("El array te que tindrer valors numerics");
        return;
      }
    }

    let suma = 0;

    for (let index = 0; index < array.length; index++) {
      suma = suma + array[index];
    }

    return suma / array.length;
  }
}

const mitjanaArray = Mitjana([9, 8, 7, 6, 5, 4, 3, 2, 1, 0]);

console.log(`La mitjana es ${mitjanaArray}`);
