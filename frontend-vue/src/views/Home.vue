<template>
  <div>
    <h1 class="home">Home</h1>
    <section>
      <h2>Flexibility</h2>
      <p>Dit is flexibiliteit wi</p>
    </section>
  </div>
</template>

<script lang="ts">
import { Options, Vue } from "vue-class-component";

@Options({
  components: {},
})
export default class Home extends Vue {}
</script>
