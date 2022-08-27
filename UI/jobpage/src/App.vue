<template>
  <div class="p-3">
    <nav class="navbar navbar-expand-sm bg-light navbar-dark">
      <ul class="navbar-nav">
        <li>
          <h3 class="d-flex justify-content-center">{{ ja_Title }}</h3>
        </li>
        <li class="nav-item">
          <router-link
            class="btn btn-light btn-outline-primary m-1 mx-3"
            to="/"
            >{{ ja_Job }}</router-link
          >
        </li>
        <li class="nav-item m-1">
          <router-link
            class="btn btn-light btn-outline-primary"
            :to="{ name: 'employee' }"
            >{{ ja_Master }}</router-link
          >
        </li>
      </ul>
    </nav>
    <router-view />
  </div>
</template>
<script>
import ja from "./locales/ja.json";
export default {
  data() {
    return {
      ja_Title: ja.Title,
      ja_Master: ja.Master,
      ja_Job: ja.Job,
    };
  },
};
</script>

<style>
#nav {
  padding: 30px;
}
#nav a {
  font-weight: bold;
  color: #2c3e50;
  text-decoration: none;
  padding: 10px;
  border-radius: 4px;
}
#nav a.router-link-exact-active {
  color: white;
  background: crimson;
}
</style>
