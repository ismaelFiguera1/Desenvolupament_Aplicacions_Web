const d = document,
  $form = d.querySelector("form");

const $id = d.getElementById("id"),
  $titol = d.querySelector("#titol"),
  $director = d.querySelector("#director"),
  $any = d.querySelector("#director");

const $idERROR = d.createElement("span"),
  $titolERROR = d.createElement("span"),
  $directorERROR = d.createElement("span");

$idERROR.style.color = "red";
$titolERROR.style.color = "red";
$directorERROR.style.color = "red";

$form.addEventListener("submit", (e) => {
  e.preventDefault();

  $idERROR.textContent = "";
  $titolERROR.textContent = "";
  $directorERROR.textContent = "";

  if ($id.value.length !== 9) {
    $idERROR.textContent = "El id te que tindre 9 caracters";
    $id.insertAdjacentElement("afterend", $idERROR);
  } else {
    $idERROR.textContent = "El id es valid";
    $idERROR.style.color = "green";
    $id.insertAdjacentElement("afterend", $idERROR);
  }

  if ($titol.value.length > 100) {
    $titolERROR.textContent = "El titol no pot tindre mes de 100 paraules";
    $titol.insertAdjacentElement("afterend", $titolERROR);
  } else {
    $titolERROR.textContent = "El titol es valid";
    $titolERROR.style.color = "green";
    $titol.insertAdjacentElement("afterend", $titolERROR);
  }

  if ($director.value.length > 50) {
    $directorERROR.textContent = "El director no pot tindre mes de 50 paraules";
    $director.insertAdjacentElement("afterend", $directorERROR);
  } else {
    $directorERROR.textContent = "El director es valid";
    $directorERROR.style.color = "green";
    $director.insertAdjacentElement("afterend", $directorERROR);
  }
});

let a;
