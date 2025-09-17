export class Pelicula {
  constructor(arrayPelis) {
    // id, titol, director, any, pais, generes, qualificacio

    this.DadesObjecteObligatories(arrayPelis);

    this.pelicules = new Array();

    for (let index = 0; index < arrayPelis.length; index++) {
      this.pelicules[index] = {};
      this.pelicules[index].id = this.ValidacioID(arrayPelis[index][0])
        ? arrayPelis[index][0]
        : undefined;

      this.pelicules[index].titol = this.ValidacioTitol(arrayPelis[index][1])
        ? arrayPelis[index][1]
        : undefined;

      this.pelicules[index].director = this.ValidarDirector(
        arrayPelis[index][2]
      )
        ? arrayPelis[index][2]
        : undefined;
      this.pelicules[index].any = this.ValidarAny(arrayPelis[index][3])
        ? arrayPelis[index][3]
        : undefined;
      this.pelicules[index].paisos = this.ValidarPaisos(arrayPelis[index][4])
        ? arrayPelis[index][4]
        : undefined;
      this.pelicules[index].generes = this.ValidarGeneres(arrayPelis[index][5])
        ? arrayPelis[index][5]
        : undefined;
      this.pelicules[index].qualificacio = this.Validarqualificacio(
        arrayPelis[index][6]
      )
        ? arrayPelis[index][6]
        : undefined;
    }
  }

  // Valido de que estiguin TOTES les dades

  DadesObjecteObligatories(array) {
    for (let index = 0; index < array.length; index++) {
      if (array[index].length < 7) {
        console.error(`Falten dades al ${index + 1} array`);
      } else if (array[index].length > 7) {
        console.error(`Sobren dades al ${index + 1} array`);
      } else {
        console.log(
          `Les dades estan correctament contades al ${index + 1} array`
        );
      }
    }
  }

  // Valido que el id sigui correcte

  ValidacioID(id) {
    if (id === undefined) {
      console.error("El id es undefined");
      return false;
    } else if (typeof id !== "string") {
      console.error(
        "El id te que ser un string per almacenar lletres i numeros"
      );
      return false;
    } else if (id.length !== 9) {
      console.error("El id te que tindre 9 caracters");
      return false;
    } else {
      console.log("El id es correcte");
      return true;
    }
  }

  // Ara valido el titol

  ValidacioTitol(titolPeli) {
    if (titolPeli === undefined) {
      console.error("El Titol es undefined");
      return false;
    } else if (typeof titolPeli !== "string") {
      console.error("El titol te que ser un string");
      return false;
    } else if (titolPeli.length > 100) {
      console.error("El titol no pot tindre mes de 100 caracters");
      return false;
    } else {
      console.log("El titol es correcte");
      return true;
    }
  }

  // Validacio director

  ValidarDirector(directorPeli) {
    if (directorPeli === undefined) {
      console.error("El director es undefined");
      return false;
    } else if (typeof directorPeli !== "string") {
      console.error("El director te que ser un string");
      return false;
    } else if (directorPeli.length > 50) {
      console.error("El director no pot tindre mes de 50 caracters");
      return false;
    } else {
      console.log("El director es correcte");
      return true;
    }
  }

  // Validar any

  ValidarAny(any) {
    if (any === undefined) {
      console.error("El any es undefined");
      return false;
    } else if (isNaN(any)) {
      console.error("El any te que ser un numero");
      return false;
    } else if (any.toString().length !== 4) {
      console.error("L'any te que tindrer 4 digits");
      return false;
    } else {
      console.log("L'Any es correcte");
      return true;
    }
  }

  // Validar Paisos

  ValidarPaisos(paisos) {
    if (paisos === undefined) {
      console.error("El paisos son undefined");
      return false;
    } else if (!Array.isArray(paisos)) {
      console.error("Els paisos tenen que ser en format array");
      return false;
    } else {
      console.log("Els paisos son correctes");
      return true;
    }
  }

  // Retorn GENERES

  Generes() {
    return [
      "Action",
      "Adult",
      "Adventure",
      "Animation",
      "Biography",
      "Comedy",
      "Crime",
      "Documentary",
      "Drama",
      "Family",
      "Fantasy",
      "Film Noir",
      "Game-Show",
      "History",
      "Horror",
      "Musical",
      "Music",
      "Mystery",
      "News",
      "Reality-TV",
      "Romance",
      "Sci-Fi",
      "Short",
      "Sport",
      "Talk-Show",
      "Thriller",
      "War",
      "Western",
    ];
  }

  // Validar GENERES

  ValidarGeneres(generes) {
    if (generes === undefined) {
      console.error("Els generes son undefined");
      return false;
    } else if (!Array.isArray(generes)) {
      console.error("Els generes tenen que ser en format array");
      return false;
    } else {
      function ValidarStrings(element) {
        if (typeof element === "string") {
          return true;
        } else {
          return false;
        }
      }

      const generesPermetuts = this.Generes();

      function GeneresAcceptats(genere) {
        for (let index = 0; index < generesPermetuts.length; index++) {
          if (genere === generesPermetuts[index]) {
            return true;
          }
        }
        return false;
      }

      for (let index = 0; index < generes.length; index++) {
        let SERstring = ValidarStrings(generes[index]) ? true : false;
        let acceptat = GeneresAcceptats(generes[index]) ? true : false;
        if (SERstring === false) {
          console.error("Els generes tenen que ser STRINGS");
          return false;
        }
        if (acceptat === false) {
          console.error("Els generes tenen que ser acceptats");
          return false;
        }
      }

      console.log("Els generes son correctes");

      return true;
    }
  }

  // Validar qualificacio

  Validarqualificacio(nota) {
    if (nota === undefined) {
      console.error("La nota es undefined");
      return false;
    } else if (isNaN(nota)) {
      console.error("La nota te que ser numerica");
      return false;
    } else if (nota < 0 || nota > 10) {
      console.error("La nota te que ser entre 0 i 10");
      return false;
    } else {
      /*   let a = nota.toFixed(1);
      a = parseFloat(a);  */
      let notaSTRING = nota.toString();
      notaSTRING = notaSTRING.split("");
      let digits = notaSTRING.length - 2;
      if (digits > 1) {
        console.error("Te mes de un  decimal");
        return false;
      }
      console.log("La qualificacio es correcta");
      return true;
    }
  }
}
