import { Box, Button, Divider, List, ListItem, ListItemText, Paper, Stack, Table, TableBody, TableCell, TableContainer, TableHead, TableRow, Typography } from "@mui/material";
import { Container } from "@mui/system";
import React from "react";
import { useNavigate, useParams } from "react-router-dom";
import { GetQuizInfo, QuizInfo } from "../Models/Quizzes/QuizModel";
import BackIcon from "@mui/icons-material/ArrowBack";
import SendIcon from "@mui/icons-material/Send";
import { useDispatch, useSelector, shallowEqual } from "react-redux";
import * as theme from "../Redux/Reducers/ThemeReducer";
import { useIntl } from "react-intl";
import { RootState } from "../Redux/Reducers/RootReducer";

export default function Exam() {
  let { id } = useParams() as { id: number | undefined };
  const [quiz, setQuiz] = React.useState<QuizInfo>();
  const [loading, setLoading] = React.useState<boolean>(true);
  const dispatch = useDispatch();
  let navigate = useNavigate();
  const intl = useIntl();
  const lang = useSelector<RootState>(({ theme }) => theme.lang, shallowEqual);

  React.useEffect(() => {
    const asyncGetQuiz = async () => {
      var quizData = await GetQuizInfo(id);
      setQuiz(quizData);
      setLoading(false);
      dispatch(theme.actions.SetTotalQuestions(quizData.QuestionTypes.map((t) => t.Count).reduce((partialSum, a) => partialSum + a, 0)));
      dispatch(theme.actions.SetQuestion([]));
    };

    asyncGetQuiz();
  }, [lang]);

  return (
    <Stack direction={{ xs: "column-reverse", md: "row" }} justifyContent="center">
      <Box mt={{ xs: 2, md: 0 }}>
        <img src={quiz?.Image} style={{ maxHeight: "400px", borderRadius: 10 }} />
      </Box>
      <Box>
        <Container>
          <Typography component="h6" variant="h4" align="center" gutterBottom>
            {quiz?.Name}
          </Typography>
          <Typography variant="h5" component="p">
            {quiz?.Description}
          </Typography>
          <Divider />
          <Typography variant="h6" component="p">
            {intl.formatMessage({ id: "TypeOfQuestionsForQuiz" })}:
          </Typography>
          <List>
            {quiz?.QuestionTypes.map((type) => (
              <ListItem disablePadding>
                <Stack direction={"row"} justifyContent={"space-between"}>
                  <ListItemText primary={type.Count + intl.formatMessage({ id: "questionsLower" })} />
                  <ListItemText sx={{ marginLeft: 1 }} primary={type.Type} />
                </Stack>
              </ListItem>
            ))}
          </List>
          <Stack direction="row" spacing={2} justifyContent="flex-end">
            <Button variant="outlined" startIcon={<BackIcon />} onClick={() => navigate("/Home")}>
              {intl.formatMessage({ id: "GoBack" })}
            </Button>
            <Button variant="contained" endIcon={<SendIcon />} onClick={() => navigate("/Question/" + id + "/1")}>
              {intl.formatMessage({ id: "StartQuiz" })}
            </Button>
          </Stack>
        </Container>
      </Box>
    </Stack>
  );
}
