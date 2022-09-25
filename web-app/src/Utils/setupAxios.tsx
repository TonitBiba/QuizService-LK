import { Alert } from "@mui/material";
import { EnhancedStore } from "@reduxjs/toolkit";
import axios, { AxiosError, AxiosRequestConfig, AxiosResponse, AxiosStatic } from "axios";
import * as theme from "../Redux/Reducers/ThemeReducer";

const API_URL = process.env.REACT_APP_API_URL;
export default function setupAxios(axios: AxiosStatic, store: EnhancedStore) {
  axios.interceptors.request.use(
    (config: AxiosRequestConfig) => {
      const storedata = store.getState();
      config.url = API_URL + (config.url as string);
      if (config.headers) {
        config.headers.lang = storedata.theme.lang;
      }
      return config;
    },
    (err: any) => Promise.reject(err)
  );

  axios.interceptors.response.use(
    function (response: AxiosResponse) {
      return response;
    },
    function (error: AxiosError) {
      alert("There was an error during data procesing!");
      return Promise.reject(error);
    }
  );
}
