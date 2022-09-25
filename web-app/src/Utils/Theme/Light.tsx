import { createTheme } from "@mui/material/styles";

export const LightTheme = createTheme({
  palette: {
    mode: "light",
    background: {
      default: "#f4f6f9"
    },
    primary: {
      light: "#1a73e8",
      main: "#1a73e8"
    }
  },
  typography: {
    body2: {
      lineHeight: 1.5,
      fontWeight: 700,
      fontSize: "0.6875rem",
      fontFamily: '"IBM Plex Sans", -apple-system, BlinkMacSystemFont, "Segoe UI", Roboto, "Helvetica Neue", Arial, sans-serif, "Apple Color Emoji", "Segoe UI Emoji", "Segoe UI Symbol"'
    },
    body1: {
      fontSize: "1rem",
      fontWeight: 500,
      fontFamily: '"IBM Plex Sans", -apple-system, BlinkMacSystemFont, "Segoe UI", Roboto, "Helvetica Neue", Arial, sans-serif, "Apple Color Emoji", "Segoe UI Emoji", "Segoe UI Symbol"'
    }
  },
  components: {
    MuiListItemButton: {
      styleOverrides: {
        root: {
          height: "40px",
          borderRadius: 10
        }
      }
    },
    MuiButtonGroup: {
      styleOverrides: {
        outlined: {
          borderRadius: 20
        }
      },
      defaultProps: {
        style: {
          borderRadius: 20
        }
      }
    },
    MuiCardHeader: {
      defaultProps: {
        style: {
          borderBottom: "1px solid rgba(0, 0, 0, 0.1)",
          padding: 5,
          margin: -4,
          height: 50,
          paddingLeft: 20
        }
      }
    },
    MuiCard: {
      defaultProps: {
        style: {
          padding: 4,
          borderRadius: 5,
          borderStyle: "solid",
          borderWidth: 1,
          boxShadow: "0px 10px 23px -4px rgba(0,0,0,0.1)",
          borderColor: "rgba(0, 0, 0, 0.1)"
        }
      }
    }
  }
});
