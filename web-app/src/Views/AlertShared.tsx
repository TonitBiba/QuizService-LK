import { Box, Collapse, IconButton, Alert, Button, AlertColor, Typography, AlertTitle, Slide } from "@mui/material";
import CloseIcon from "@mui/icons-material/Close";
import React from "react";
import { ErrorVM, StatusEnum } from "../Models/Shared/ErrorVM";
import { useDispatch } from "react-redux";
import * as theme from "../Redux/Reducers/ThemeReducer";

export default function AlertShared({ error, setError }: { error: ErrorVM | null; setError: any }) {
  const [open, setOpen] = React.useState<boolean>(true);

  const dispatch = useDispatch();

  let severityType: AlertColor = "success";
  switch (error?.Status) {
    case StatusEnum.SUCCESS:
      severityType = "success";
      break;
    case StatusEnum.INFO:
      severityType = "info";
      break;
    case StatusEnum.WARNING:
      severityType = "warning";
      break;
    case StatusEnum.ERROR:
      severityType = "error";
      break;
  }

  return (
    <Box sx={{ width: "100%" }}>
      <Slide direction="down" in={open}>
        <Alert
          severity={severityType}
          action={
            <IconButton
              aria-label="close"
              color="inherit"
              size="small"
              onClick={() => {
                setOpen(false);
                setTimeout(() => {
                  dispatch(theme.actions.SetError());
                }, 500);
              }}
            >
              <CloseIcon fontSize="inherit" />
            </IconButton>
          }
          sx={{ mb: 2 }}
        >
          <AlertTitle>{error?.Title}</AlertTitle>

          {error?.Description}
        </Alert>
      </Slide>
    </Box>
  );
}
