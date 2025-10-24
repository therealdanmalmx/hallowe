<template>
  <div class="bats">
    <!-- <div class="bat" v-for="(bat, index) in bats" :key="index">
      <img :src="bat" alt="Fladdermus" />
    </div> -->

    <!-- Bakom texten -->
    <div class="bats behind">
      <div class="bat" v-for="(bat, index) in batsBehind" :key="index">
        <img :src="bat" alt="Fladdermus" />
      </div>
    </div>

    <!-- Framför texten -->
    <div class="bats front">
      <div class="bat" v-for="(bat, index) in batsFront" :key="index">
        <img :src="bat" alt="Fladdermus" />
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
  const bats = [
    'https://media1.giphy.com/media/0xR7MUO0hJfWtco7C6/giphy.gif',

    'https://media4.giphy.com/media/v1.Y2lkPTc5MGI3NjExdDlzeXc2amhyNjM4M2ttNXI3cHN2cW9zZDZpeTBpODUzb203MHY0YiZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9cw/CwUZIvby0i6rF19fTs/giphy.gif',

    // 'https://media1.giphy.com/media/0xR7MUO0hJfWtco7C6/giphy.gif',

    // 'https://media1.giphy.com/media/0xR7MUO0hJfWtco7C6/giphy.gif',

    'https://media4.giphy.com/media/v1.Y2lkPTc5MGI3NjExdDlzeXc2amhyNjM4M2ttNXI3cHN2cW9zZDZpeTBpODUzb203MHY0YiZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9cw/CwUZIvby0i6rF19fTs/giphy.gif',

    // 'https://media1.giphy.com/media/0xR7MUO0hJfWtco7C6/giphy.gif',

    'https://media4.giphy.com/media/v1.Y2lkPTc5MGI3NjExdDlzeXc2amhyNjM4M2ttNXI3cHN2cW9zZDZpeTBpODUzb203MHY0YiZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9cw/CwUZIvby0i6rF19fTs/giphy.gif',

    'https://media1.giphy.com/media/0xR7MUO0hJfWtco7C6/giphy.gif',

    'https://media4.giphy.com/media/v1.Y2lkPTc5MGI3NjExdDlzeXc2amhyNjM4M2ttNXI3cHN2cW9zZDZpeTBpODUzb203MHY0YiZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9cw/CwUZIvby0i6rF19fTs/giphy.gif',

    'https://media4.giphy.com/media/v1.Y2lkPTc5MGI3NjExdDlzeXc2amhyNjM4M2ttNXI3cHN2cW9zZDZpeTBpODUzb203MHY0YiZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9cw/CwUZIvby0i6rF19fTs/giphy.gif',

    'https://media4.giphy.com/media/v1.Y2lkPTc5MGI3NjExdDlzeXc2amhyNjM4M2ttNXI3cHN2cW9zZDZpeTBpODUzb203MHY0YiZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9cw/CwUZIvby0i6rF19fTs/giphy.gif',

    'https://media1.giphy.com/media/0xR7MUO0hJfWtco7C6/giphy.gif',
    'https://media4.giphy.com/media/v1.Y2lkPTc5MGI3NjExdDlzeXc2amhyNjM4M2ttNXI3cHN2cW9zZDZpeTBpODUzb203MHY0YiZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9cw/CwUZIvby0i6rF19fTs/giphy.gif',

    'https://media4.giphy.com/media/v1.Y2lkPTc5MGI3NjExdDlzeXc2amhyNjM4M2ttNXI3cHN2cW9zZDZpeTBpODUzb203MHY0YiZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9cw/CwUZIvby0i6rF19fTs/giphy.gif',

    'https://media1.giphy.com/media/0xR7MUO0hJfWtco7C6/giphy.gif',

    'https://media1.giphy.com/media/0xR7MUO0hJfWtco7C6/giphy.gif',

    'https://media1.giphy.com/media/0xR7MUO0hJfWtco7C6/giphy.gif',

    'https://media1.giphy.com/media/0xR7MUO0hJfWtco7C6/giphy.gif',

    'https://media1.giphy.com/media/0xR7MUO0hJfWtco7C6/giphy.gif'
  ]

  const batsFront = bats.slice(0, 4)
  const batsBehind = bats.slice(4)
</script>

<style scoped>
  .bats {
    position: absolute;
  }

  .bats.behind {
    z-index: 1;
  }

  .bats.front {
    z-index: 20;
  }

  .bat {
    position: fixed;
    z-index: 9999;
    user-select: none;
    cursor: default;
    animation-duration: 5s;
    animation-timing-function: linear;
    animation-iteration-count: infinite, infinite;
    animation-direction: alternate;
  }

  @-webkit-keyframes bats-fall {
    0% {
      top: -10%;
    }
    100% {
      top: 45%;
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
      top: 45%;
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
    -webkit-animation-duration: 5s, 3s;
    -webkit-animation-timing-function: linear, ease-in-out;
    -webkit-animation-iteration-count: infinite, infinite;
    -webkit-animation-play-state: running, running;
    animation-name: bats-fall, bats-shake;
    animation-duration: 5s, 3s;
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
    -webkit-animation-delay: 0.5s, 2s;
    animation-delay: 0.5s, 2s;
  }
  .bat:nth-of-type(2) {
    left: 90%;
    -webkit-animation-delay: 1s, 1.5s;
    animation-delay: 1s, 1.5s;
  }
  .bat:nth-of-type(3) {
    left: 20%;
    -webkit-animation-delay: 2s, 2s;
    animation-delay: 2s, 2s;
  }
  .bat:nth-of-type(4) {
    left: 80%;
    -webkit-animation-delay: 2.5s, 2s;
    animation-delay: 2.5s, 2s;
  }
  .bat:nth-of-type(5) {
    left: 30%;
    -webkit-animation-delay: 3s, 3s;
    animation-delay: 3s, 3s;
  }
  .bat:nth-of-type(6) {
    left: 70%;
    -webkit-animation-delay: 3.5s, 2s;
    animation-delay: 3.5s, 2s;
  }
  .bat:nth-of-type(7) {
    left: 40%;
    -webkit-animation-delay: 4s, 1s;
    animation-delay: 4s, 1s;
  }
  .bat:nth-of-type(8) {
    left: 60%;
    -webkit-animation-delay: 4.5s, 0.5s;
    animation-delay: 4.5s, 0.5s;
  }
  .bat:nth-of-type(9) {
    left: 15%;
    -webkit-animation-delay: 4.5s, 1s;
    animation-delay: 4.5s, 1s;
  }
  .bat:nth-of-type(10) .bat img {
    left: 85%;
    -webkit-animation-delay: 0.5s, 1s;
    animation-delay: 0.5s, 1s;
  }
  .bat:nth-of-type(11) .bat img {
    left: 45%;
    -webkit-animation-delay: 1s, 0.5s;
    animation-delay: 1s, 0.5s;
  }
  .bat:nth-of-type(12) .bat img {
    left: 55%;
    -webkit-animation-delay: 2.5s, 2s;
    animation-delay: 2.5s, 2s;
  }
  .bat:nth-of-type(12) .bat img {
    left: 75%;
    -webkit-animation-delay: 3.5s, 0.5s;
    animation-delay: 3.5s, 0.5s;
  }
  .bat:nth-of-type(12) .bat img {
    left: 35%;
    -webkit-animation-delay: 5s, 4s;
    animation-delay: 5s, 4s;
  }
  .bat:nth-of-type(13) .bat img {
    left: 65%;
    -webkit-animation-delay: 5s, 1s;
    animation-delay: 5s, 1s;
  }
  .bat:nth-of-type(14) {
    left: 33%;
    -webkit-animation-delay: 2.5s, 3s;
    animation-delay: 2.5s, 3s;
  }
  .bat:nth-of-type(15) {
    left: 66%;
    -webkit-animation-delay: 1.5s, 2s;
    animation-delay: 1.5s, 2s;
  }
  .bat:nth-of-type(16) {
    left: 45%;
    -webkit-animation-delay: 2.5s, 3s;
    animation-delay: 2.5s, 3s;
  }
  .bat:nth-of-type(17) {
    left: 13%;
    -webkit-animation-delay: 1.5s, 2s;
    animation-delay: 1.5s, 2s;
  }
  .bat:nth-of-type(18) {
    height: 50px;
    display: block;
  }
  .bat:nth-of-type(19) .demo {
    color: #fff;
    display: block;
    margin: 0 auto;
    padding: 10px 0;
    text-align: center;
  }

  .bat img {
    height: 50px;
    bottom: 0;
    background-color: #00000000;
    display: block;
  }
</style>
