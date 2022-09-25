import { Action } from "@reduxjs/toolkit";
import persistReducer from "redux-persist/es/persistReducer";
import storage from "redux-persist/lib/storage";
import { ErrorVM } from "../../Models/Shared/ErrorVM";
import { SETTHEME, SET_ERROR, SET_LANGUAGE, SET_QUESTION, SET_TOTAL_QUESTION } from "../ActionTypes";

export interface ActionWithPayload<T> extends Action {
  payload?: T;
}

export interface IThemeState {
  mode?: string;
  alert?: ErrorVM;
  lang?: string;
  TotalQuestion: number;
  Questions?: Question[];
}

export interface Question {
  id: number;
  qnr: number;
  IsCorrect: boolean;
  Answer: number[];
}

const initialThemeMode: IThemeState = {
  mode: "light",
  lang: "en",
  TotalQuestion: 0,
  Questions: []
};

export const reducer = persistReducer({ storage, key: "Quiz_Theme", whitelist: ["mode", "alert", "lang", "Questions", "TotalQuestion"] }, (state: IThemeState = initialThemeMode, action: ActionWithPayload<IThemeState>) => {
  switch (action.type) {
    case SETTHEME:
      return { ...state, mode: action.payload?.mode };
    case SET_ERROR:
      return { ...state, alert: action.payload?.alert };
    case SET_QUESTION:
      return { ...state, Questions: action.payload?.Questions };
    case SET_TOTAL_QUESTION:
      return { ...state, TotalQuestion: action.payload?.TotalQuestion as number };
    case SET_LANGUAGE:
      return { ...state, lang: action.payload?.lang };
    default:
      return state;
  }
});

export const actions = {
  SetThemeMode: (mode: string) => ({ type: SETTHEME, payload: { mode: mode } }),
  SetError: (error?: ErrorVM) => ({ type: SET_ERROR, payload: { alert: error } }),
  SetQuestion: (Questions?: Question[]) => ({ type: SET_QUESTION, payload: { Questions: Questions } }),
  SetTotalQuestions: (TotalQuestion: number) => ({ type: SET_TOTAL_QUESTION, payload: { TotalQuestion: TotalQuestion } }),
  ChangeLanguage: (lang: string) => ({ type: SET_LANGUAGE, payload: { lang: lang } })
};
