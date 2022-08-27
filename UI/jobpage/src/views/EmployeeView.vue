<template>
  <div class="justify-content-center mx-5">
    <div class="input-group">
      <button
        type="button"
        class="btn btn-primary m-2 fload-end"
        data-bs-toggle="modal"
        data-bs-target="#inputModal"
        @click="addClick()"
      >
        <svg
          xmlns="http://www.w3.org/2000/svg"
          width="16"
          height="16"
          fill="currentColor"
          class="bi bi-plus-square"
          viewBox="0 0 16 16"
        >
          <path
            d="M14 1a1 1 0 0 1 1 1v12a1 1 0 0 1-1 1H2a1 1 0 0 1-1-1V2a1 1 0 0 1 1-1h12zM2 0a2 2 0 0 0-2 2v12a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V2a2 2 0 0 0-2-2H2z"
          />
          <path
            d="M8 4a.5.5 0 0 1 .5.5v3h3a.5.5 0 0 1 0 1h-3v3a.5.5 0 0 1-1 0v-3h-3a.5.5 0 0 1 0-1h3v-3A.5.5 0 0 1 8 4z"
          />
        </svg>
      </button>
      <div class="mx-3 pt-2">
        <h4>{{ ja_Master }}</h4>
      </div>
    </div>
    <table class="table table-striped">
      <thead>
        <tr>
          <th>ID</th>
          <th>{{ ja_Name }}</th>
          <th>{{ ja_Department }}</th>
          <th>{{ ja_Position }}</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="dat in employees" :key="dat.employeeId">
          <td>{{ dat.employeeId }}</td>
          <td>{{ dat.name }}</td>
          <td>{{ dat.department }}</td>
          <td>{{ dat.position }}</td>
          <td>
            <button
              type="button"
              class="btn btn-light mr-1"
              data-bs-toggle="modal"
              data-bs-target="#inputModal"
              @click="editClick(dat)"
            >
              <svg
                xmlns="http://www.w3.org/2000/svg"
                width="16"
                height="16"
                fill="currentColor"
                class="bi bi-pencil-fill"
                viewBox="0 0 16 16"
              >
                <path
                  d="M12.854.146a.5.5 0 0 0-.707 0L10.5 1.793 14.207 5.5l1.647-1.646a.5.5 0 0 0 0-.708l-3-3zm.646 6.061L9.793 2.5 3.293 9H3.5a.5.5 0 0 1 .5.5v.5h.5a.5.5 0 0 1 .5.5v.5h.5a.5.5 0 0 1 .5.5v.5h.5a.5.5 0 0 1 .5.5v.207l6.5-6.5zm-7.468 7.468A.5.5 0 0 1 6 13.5V13h-.5a.5.5 0 0 1-.5-.5V12h-.5a.5.5 0 0 1-.5-.5V11h-.5a.5.5 0 0 1-.5-.5V10h-.5a.499.499 0 0 1-.175-.032l-.179.178a.5.5 0 0 0-.11.168l-2 5a.5.5 0 0 0 .65.65l5-2a.5.5 0 0 0 .168-.11l.178-.178z"
                />
              </svg>
            </button>
            <button
              type="button"
              class="btn btn-light mr-1"
              @click="deleteClick(dat.employeeId)"
            >
              <svg
                xmlns="http://www.w3.org/2000/svg"
                width="16"
                height="16"
                fill="currentColor"
                class="bi bi-trash"
                viewBox="0 0 16 16"
              >
                <path
                  fill-rule="evenodd"
                  d="M14.5 3a1 1 0 0 1-1 1H13v9a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2V4h-.5a1 1 0 0 1-1-1V2a1 1 0 0 1 1-1H6a1 1 0 0 1 1-1h2a1 1 0 0 1 1 1h3.5a1 1 0 0 1 1 1v1zM4.118 4 4 4.059V13a1 1 0 0 0 1 1h6a1 1 0 0 0 1-1V4.059L11.882 4H4.118zM2.5 3V2h11v1h-11z"
                />
              </svg>
            </button>
          </td>
        </tr>
      </tbody>
    </table>
    <input-modal-view
      :Title="modalTitle"
      :Id="EmployeeId"
      @createData="createClick"
      @updateData="updateClick"
    >
      <template v-slot:modalBody>
        <div class="modal-body">
          <div class="input-group mb-3">
            <span class="input-group-text">{{ ja_Name }}</span>
            <input type="text" class="form-control" v-model="Name" />
          </div>
          <div class="input-group mb-3">
            <span class="input-group-text">{{ ja_Department }}</span>
            <input type="text" class="form-control" v-model="Department" />
          </div>
          <div class="input-group mb-3">
            <span class="input-group-text">{{ ja_Position }}</span>
            <input type="text" class="form-control" v-model="Position" />
          </div>
        </div>
      </template>
    </input-modal-view>
  </div>
</template>
<script>
import url from "../assets/js/url.js";
import axios from "axios";
import ja from "../locales/ja.json";
import InputModalView from "./InputModalView.vue";

export default {
  components: {
    InputModalView,
  },
  data() {
    return {
      ja_Master: ja.Master,
      ja_Name: ja.Name,
      ja_Department: ja.Department,
      ja_Position: ja.Position,
      ja_Create: ja.Create,
      ja_Update: ja.Update,
      ja_New: ja.New,
      ja_Edit: ja.Edit,
      employees: [],
      modalTitle: "",
      EmployeeId: 0,
      Name: "",
      Department: "",
      Position: "",
    };
  },
  methods: {
    refreshData() {
      axios
        .get(url.API_URL + "Employee/read-all-employees")
        .then((response) => {
          console.log(response.data);
          this.employees = response.data;
        });
    },
    addClick() {
      this.modalTitle = ja.New;
      this.EmployeeId = 0;
      this.Name = "";
      this.Position = "";
      this.Department = "";
    },
    editClick(emp) {
      this.modalTitle = ja.Edit;
      this.EmployeeId = emp.employeeId;
      this.Name = emp.name;
      this.Position = emp.position;
      this.Department = emp.department;
    },
    createClick() {
      axios
        .post(url.API_URL + "Employee/create-employee", {
          Name: this.Name,
          Department: this.Department,
          Position: this.Position,
        })
        .then(() => {
          document.getElementById("modal-close-btn").click();
          this.refreshData();
        });
    },
    updateClick() {
      axios
        .put(url.API_URL + "Employee/update-employee-by-id/", {
          EmployeeId: this.EmployeeId,
          Name: this.Name,
          Department: this.Department,
          Position: this.Position,
          Email: this.Email,
        })
        .then(() => {
          document.getElementById("modal-close-btn").click();
          this.refreshData();
        });
    },
    deleteClick(id) {
      if (!confirm(ja.ConfirmDelete)) {
        return;
      }
      axios
        .delete(url.API_URL + "Employee/delete-employee-by-id/" + id)
        .then(() => {
          document.getElementById("modal-close-btn").click();
          this.refreshData();
        });
    },
  },
  mounted: function () {
    this.refreshData();
  },
};
</script>
