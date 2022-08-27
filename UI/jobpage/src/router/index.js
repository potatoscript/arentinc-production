import { createRouter, createWebHistory } from 'vue-router'
import JobView from '../views/JobView.vue'
const routes = [
  {
    path: '/',
    name: 'job',
    component: JobView
  },
  {
    path: '/employee',
    name: 'employee',
    component: () => import('../views/EmployeeView.vue')
  }
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})
export default router