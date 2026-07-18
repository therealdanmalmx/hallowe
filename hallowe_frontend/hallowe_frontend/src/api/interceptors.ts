import { useHttpClient } from "../api/client";
import { router } from "../router";

useHttpClient().interceptors.response.use((res)=> {
  res.headers.Authorization = `Bearer ${res.data.token}`
  console.log(res.data.token)
  localStorage.setItem("token", res.data.token);
  
  router.push("/map")

  return res;

}, error => {
  if (error.response && error.response.status === 401) {
  localStorage.removeItem("token");

  if (!localStorage.getItem("token"))
  {
    router.push("/login")
  }
  }
  return Promise.reject(error);
})