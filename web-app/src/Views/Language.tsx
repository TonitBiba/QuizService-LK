import { Avatar, Box, IconButton, ListItemButton, ListItemIcon, ListItemText, Menu, Stack, Tooltip, Typography } from "@mui/material";
import React from "react";
import { useSelector, shallowEqual, useDispatch } from "react-redux";
import { RootState } from "../Redux/Reducers/RootReducer";
import * as theme from "../Redux/Reducers/ThemeReducer";

export default function Language() {
  const [anchorEl, setAnchorEl] = React.useState<null | HTMLElement>(null);
  const lang = useSelector<RootState>(({ theme }) => theme.lang, shallowEqual) as string;
  const open = Boolean(anchorEl);
  const dispatch = useDispatch();
  let langFlag = "united-kingdom.png";
  if (lang === "sq") {
    langFlag = "albania.png";
  } else if (lang === "no") {
    langFlag = "norway.png";
  }

  const handleClick = (event: React.MouseEvent<HTMLElement>) => {
    setAnchorEl(event.currentTarget);
  };
  const handleClose = () => {
    setAnchorEl(null);
  };

  const ChangeLang = (l: string) => {
    dispatch(theme.actions.ChangeLanguage(l));
  };

  return (
    <>
      <Stack onClick={handleClick} width={30} height="40" direction={"row"} justifyContent="space-between" alignItems="center" sx={{ cursor: "pointer" }}>
        <Box mr={2}>
          <Tooltip onClick={handleClick} title="Change language">
            <IconButton sx={{ padding: 0 }} size="large" edge="end" aria-label="account of current user" aria-haspopup="true" color="inherit">
              <img src={"/media/flags/" + langFlag} style={{ width: "32px" }} />
            </IconButton>
          </Tooltip>
        </Box>
      </Stack>
      <Menu
        anchorEl={anchorEl}
        id="account-menu"
        open={open}
        onClose={handleClose}
        onClick={handleClose}
        PaperProps={{
          elevation: 0,
          sx: {
            width: "150px",
            overflow: "visible",
            filter: "drop-shadow(0px 2px 8px rgba(0,0,0,0.32))",
            mt: 1.5,
            "& .MuiAvatar-root": {
              width: 32,
              height: 32,
              ml: -0.5,
              mr: 1
            },
            "&:before": {
              content: '""',
              display: "block",
              position: "absolute",
              top: 0,
              right: 14,
              width: 10,
              height: 10,
              bgcolor: "background.paper",
              transform: "translateY(-50%) rotate(45deg)",
              zIndex: 0
            }
          }
        }}
        transformOrigin={{ horizontal: "right", vertical: "top" }}
        anchorOrigin={{ horizontal: "right", vertical: "bottom" }}
      >
        <Typography sx={{ marginLeft: 1 }}>Languages</Typography>
        <ListItemButton onClick={() => ChangeLang("sq")}>
          <ListItemIcon>
            <Avatar alt="Remy Sharp" src="/media/flags/albania.png" sx={{ width: 48, height: 48 }} />
          </ListItemIcon>
          <ListItemText primary="Albanian" />
        </ListItemButton>
        <ListItemButton onClick={() => ChangeLang("en")}>
          <ListItemIcon>
            <Avatar alt="Remy Sharp" src="/media/flags/united-kingdom.png" sx={{ width: 48, height: 48 }} />
          </ListItemIcon>
          <ListItemText primary="English" />
        </ListItemButton>
        <ListItemButton onClick={() => ChangeLang("no")}>
          <ListItemIcon>
            <Avatar alt="Remy Sharp" src="/media/flags/norway.png" sx={{ width: 48, height: 48 }} />
          </ListItemIcon>
          <ListItemText primary="Norway" />
        </ListItemButton>
      </Menu>
    </>
  );
}
