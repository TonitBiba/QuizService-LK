import { all } from "redux-saga/effects";
import { combineReducers } from "redux";
import * as theme from "../Reducers/ThemeReducer";

export const rootReducer = combineReducers({
  theme: theme.reducer
});

export type RootState = ReturnType<typeof rootReducer>;

export function* rootSaga() {}
