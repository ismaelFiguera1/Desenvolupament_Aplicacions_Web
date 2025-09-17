const d = document,
  n = navigator;

function getGeolocation(id) {
  const $id = d.querySelector(".geolocation");
  const succes = (position) => {
    console.log(position);
    let coords = position.coords;
    $id.innerHTML = `<p>La teva posicio actual es: </p>
    <ul>
    <li>Latitud: <b>${coords.latitude}</b></li>
    <li>Lngitut: <b>${coords.longitude}</b></li>
    <li>Precissio: <b>${coords.accuracy}</b> metres</li>
    </ul>
    <a href="https://www.google.com/maps/@${coords.latitude},${coords.longitude},20z" target="_blank" rel="noopener">Veure a Google Maps</a>
    `;
  };
  const error = (err) => {
    console.log(err);
    $id.innerHTML = `<p><mark>ERROR : ${err.code} : - ${err.message}</mark></p>`;
  };
  const options = {
    enableHightAccuracy: true, //   Maxima precissio
    timeout: 5000, // Temps maxim d'espera
    maximumAge: 0, //   No utilitzar la cache
  };

  n.geolocation.getCurrentPosition(succes, error, options);
}

function getWatchGeolocation(id) {
  const $id = d.querySelector(".geolocation");
  const succes = (position) => {
    console.log(position);
    let coords = position.coords;
    $id.innerHTML = `<p>La teva posicio actual es: </p>
    <ul>
    <li>Latitud: <b>${coords.latitude}</b></li>
    <li>Lngitut: <b>${coords.longitude}</b></li>
    <li>Precissio: <b>${coords.accuracy}</b> metres</li>
    </ul>
    <a href="https://www.google.com/maps/@${coords.latitude},${coords.longitude},20z" target="_blank" rel="noopener">Veure a Google Maps</a>
    `;
  };
  const error = (err) => {
    console.log(err);
    $id.innerHTML = `<p><mark>ERROR : ${err.code} : - ${err.message}</mark></p>`;
  };
  const options = {
    enableHightAccuracy: true, //   Maxima precissio
    timeout: 5000, // Temps maxim d'espera
    maximumAge: 0, //   No utilitzar la cache
  };

  n.geolocation.watchPosition(succes, error, options);
}

d.addEventListener("DOMContentLoaded", getWatchGeolocation(".geolocation"));
