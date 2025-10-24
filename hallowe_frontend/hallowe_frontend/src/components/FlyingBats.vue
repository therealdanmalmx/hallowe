<!-- <script setup lang="ts">
// import { onMounted } from "vue";
// import bat from "../assets/images/bat.png";
</script> -->

<template>
  <div class="bats">
    <div class="bat">
      <img
        src="https://media4.giphy.com/media/v1.Y2lkPTc5MGI3NjExdDlzeXc2amhyNjM4M2ttNXI3cHN2cW9zZDZpeTBpODUzb203MHY0YiZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9cw/CwUZIvby0i6rF19fTs/giphy.gif"
      />
    </div>
    <div class="bat">
      <img src="https://media1.giphy.com/media/0xR7MUO0hJfWtco7C6/giphy.gif" />
    </div>
    <div class="bat">
      <img
        src="https://media2.giphy.com/media/v1.Y2lkPTc5MGI3NjExeDhjZzcyMXRsdG9ya2hrMDk2dDN0ZmlqczYybmFpNDVnNm1rN29wdiZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9cw/uH1EPGpCkk8i5QdlPQ/giphy.gif"
      />
    </div>
    <div class="bat">
      <img src="https://media1.giphy.com/media/0xR7MUO0hJfWtco7C6/giphy.gif" />
    </div>
    <div class="bat">
      <img src="https://media1.giphy.com/media/0xR7MUO0hJfWtco7C6/giphy.gif" />
    </div>
    <div class="bat">
      <img
        src="https://media4.giphy.com/media/v1.Y2lkPTc5MGI3NjExbGUwaXQ4c2s2NG0xcmc3YzBpZmdjaHp6bTJiaXpobmhjaHl6bHFrYiZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9cw/ZW0kB5NhxGQ3vAkMUv/giphy.gif"
      />
    </div>
    <div class="bat">
      <img src="https://media1.giphy.com/media/0xR7MUO0hJfWtco7C6/giphy.gif" />
    </div>
    <div class="bat">
      <img src="https://media1.giphy.com/media/0xR7MUO0hJfWtco7C6/giphy.gif" />
    </div>
    <div class="bat">
      <img
        src="https://media1.giphy.com/media/v1.Y2lkPTc5MGI3NjExOWJ6bWY2MGt4OHgwbWVsa29xanl5OXc2NHhrbDZvd2gwdXdtMDB6diZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9cw/kZoOGch6g3TsNJyBqZ/giphy.gif"
      />
    </div>
    <div class="bat">
      <img
        src="https://media4.giphy.com/media/v1.Y2lkPTc5MGI3NjExazIwZzE4b2pxYW4zdHg5NDJ1bWY2eDg2bDkzYmduaDRzcGtzNnBweCZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9cw/CbVwI3N0sS2sct7G2z/giphy.gif"
      />
    </div>
  </div>
</template>

<style scoped>
.bat {
  color: #ffffff00;
  font-size: 1.5em;
  font-family: Serif;
  text-shadow: 0 0 1px #000;
}

@-webkit-keyframes bats-fall {
  0% {
    top: -10%;
  }
  100% {
    top: 100%;
  }
}
@-webkit-keyframes bats-shake {
  0% {
    -webkit-transform: translateX(0px);
    transform: translateX(0px);
  }
  50% {
    -webkit-transform: translateX(80px);
    transform: translateX(80px);
  }
  100% {
    -webkit-transform: translateX(0px);
    transform: translateX(0px);
  }
}
@keyframes bats-fall {
  0% {
    top: -10%;
  }
  100% {
    top: 100%;
  }
}
@keyframes bats-shake {
  0% {
    transform: translateX(0px);
  }
  50% {
    transform: translateX(80px);
  }
  100% {
    transform: translateX(0px);
  }
}
.bat {
  position: fixed;
  top: -10%;
  z-index: 9999;
  -webkit-user-select: none;
  -moz-user-select: none;
  -ms-user-select: none;
  user-select: none;
  cursor: default;
  -webkit-animation-name: bats-fall, bats-shake;
  -webkit-animation-duration: 10s, 3s;
  -webkit-animation-timing-function: linear, ease-in-out;
  -webkit-animation-iteration-count: infinite, infinite;
  -webkit-animation-play-state: running, running;
  animation-name: bats-fall, bats-shake;
  animation-duration: 10s, 3s;
  animation-timing-function: linear, ease-in-out;
  animation-iteration-count: infinite, infinite;
  animation-play-state: running, running;
}
.bat:nth-of-type(0) {
  left: 1%;
  -webkit-animation-delay: 0s, 0s;
  animation-delay: 0s, 0s;
}
.bat:nth-of-type(1) {
  left: 10%;
  -webkit-animation-delay: 1s, 1s;
  animation-delay: 1s, 1s;
}
.bat:nth-of-type(2) {
  left: 20%;
  -webkit-animation-delay: 6s, 0.5s;
  animation-delay: 6s, 0.5s;
}
.bat:nth-of-type(3) {
  left: 30%;
  -webkit-animation-delay: 4s, 2s;
  animation-delay: 4s, 2s;
}
.bat:nth-of-type(4) {
  left: 40%;
  -webkit-animation-delay: 2s, 2s;
  animation-delay: 2s, 2s;
}
.bat:nth-of-type(5) {
  left: 50%;
  -webkit-animation-delay: 8s, 3s;
  animation-delay: 8s, 3s;
}
.bat:nth-of-type(6) {
  left: 60%;
  -webkit-animation-delay: 6s, 2s;
  animation-delay: 6s, 2s;
}
.bat:nth-of-type(7) {
  left: 70%;
  -webkit-animation-delay: 2s, 1s;
  animation-delay: 2s, 1s;
}
.bat:nth-of-type(8) {
  left: 80%;
  -webkit-animation-delay: 1s, 0s;
  animation-delay: 1s, 0s;
}
.bat:nth-of-type(9) {
  left: 90%;
  -webkit-animation-delay: 3s, 1s;
  animation-delay: 3s, 1s;
}
.bat:nth-of-type(10) .demo {
  /* font-family: "Raleway", sans-serif; */
  color: #fff;
  display: block;
  margin: 0 auto;
  padding: 10px 0;
  text-align: center;
}
/* .demo a {
  font-family: "Raleway", sans-serif;
  color: #000;
} */

.bat img {
  height: 50px;
  bottom: 0;
  background-color: #00000000;
  display: block;
}
</style>
