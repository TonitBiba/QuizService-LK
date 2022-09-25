import React from "react";
import { TransitionProps } from "@mui/material/transitions";
import Slide from "@mui/material/Slide";
import { Button, Dialog, DialogActions, DialogContent, DialogContentText, DialogTitle } from "@mui/material";
import { Navigate, useNavigate, useParams } from "react-router-dom";
import { useSelector, shallowEqual } from "react-redux";
import { RootState } from "../Redux/Reducers/RootReducer";
import { IThemeState } from "../Redux/Reducers/ThemeReducer";
import { useIntl } from "react-intl";

const Transition = React.forwardRef(function Transition(
  props: TransitionProps & {
    children: React.ReactElement<any, any>;
  },
  ref: React.Ref<unknown>
) {
  return <Slide direction="up" ref={ref} {...props} />;
});

export default function IsCorrect({ IsOpen, Correct }: { IsOpen: boolean; Correct: boolean }) {
  let { id, qnr } = useParams() as { id: number | undefined; qnr: number | undefined };
  let navigate = useNavigate();
  const intl = useIntl();
  const themeReducer = useSelector<RootState>(({ theme }) => theme, shallowEqual) as IThemeState;

  const [open, setOpen] = React.useState(IsOpen);

  React.useEffect(() => {
    setOpen(IsOpen);
  }, [IsOpen]);

  const handleClose = () => {
    if (themeReducer.TotalQuestion == qnr) {
      navigate("/Result");
    } else {
      navigate(`/Question/${id}/${++(qnr as number)}`, { replace: true });
    }
    setOpen(false);
  };

  return (
    <div>
      <Dialog open={open} TransitionComponent={Transition} keepMounted aria-describedby="alert-dialog-slide-description">
        <DialogTitle>{Correct ? <>{intl.formatMessage({ id: "AnswerCorrect" })}</> : <>{intl.formatMessage({ id: "AnswerIncorrect" })}</>} </DialogTitle>
        <DialogContent></DialogContent>
        <DialogActions>
          <Button onClick={handleClose}>{intl.formatMessage({ id: "Okay" })}</Button>
        </DialogActions>
      </Dialog>
    </div>
  );
}
