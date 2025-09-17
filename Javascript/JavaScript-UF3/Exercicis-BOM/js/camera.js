const d = document,
  n = navigator,
  w = window;

function webcam(id) {
  const $video = d.getElementById(id);
  console.log($video);
  //  si existeix la funcio getUserMedia
  if (n.mediaDevices.getUserMedia) {
    // getUserMedia retorna una promesa
    n.mediaDevices
      .getUserMedia({ video: true, audio: false })
      .then((stream) => {
        console.log(stream);
        $video.srcObject = stream;
        $video.play();
      })
      .catch((err) => {
        console.log(`Error: ${err}`);
        $video.insertAdjacentHTML("beforebegin", `<p><mark>${err}</mark></p>`);
      });
  }
}

d.addEventListener("DOMContentLoaded", webcam("webCam"));
