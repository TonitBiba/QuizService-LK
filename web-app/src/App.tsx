import React from "react";
import { CssBaseline, ThemeProvider } from "@mui/material";
import { useSelector, shallowEqual } from "react-redux";
import { LightTheme } from "./Utils/Theme/Light";
import { DarkTheme } from "./Utils/Theme/Dark";
import { RootState } from "./Redux/Reducers/RootReducer";
import I18nProvider from "./Utils/Resources/i18nProvider";
import Router from "./Routing/Router";

function App() {
  const themeMode = useSelector<RootState>(({ theme }) => theme.mode, shallowEqual);

  return (
    <ThemeProvider theme={themeMode == "light" ? LightTheme : DarkTheme}>
      <CssBaseline />
      <I18nProvider>
        <Router />
      </I18nProvider>
    </ThemeProvider>
  );
}

export default App;
