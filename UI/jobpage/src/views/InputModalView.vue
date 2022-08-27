<template>
  <div
    class="modal fade"
    id="inputModal"
    tabindex="-1"
    aria-labelledby="exampleModalLable"
    aria-hidden="true"
  >
    <div class="modal-dialog modal-lg modal-dialog-centered">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title" id="exampleModalLabel">
            {{ Title }}
          </h5>
          <button
            id="modal-close-btn"
            type="button"
            class="btn-close"
            data-bs-dismiss="modal"
            arial-label="Close"
          ></button>
        </div>
        <slot name="modalBody"></slot>
        <div class="modal-body">
          <button
            type="button"
            @click="createClick()"
            v-if="Id == 0"
            class="btn btn-primary mt-2"
          >
            {{ ja_Create }}
          </button>
          <button
            type="button"
            @click="updateClick()"
            v-if="Id != 0"
            class="btn btn-primary"
          >
            {{ ja_Update }}
          </button>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import ja from "../locales/ja.json";

export default {
  props: ["Title", "Id"],
  data() {
    return {
      ja_Update: ja.Update,
      ja_Create: ja.Create,
    };
  },
  methods: {
    createClick() {
      this.$emit("createData");
    },
    updateClick() {
      this.$emit("updateData");
    },
  },
};
</script>
