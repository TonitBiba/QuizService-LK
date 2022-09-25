import { Box, Button, Card, CardContent, Checkbox, FormControl, FormControlLabel, Radio, RadioGroup, Stack, Typography } from "@mui/material";
import React from "react";
import { useParams } from "react-router-dom";
import { CheckIfCorrect, GetNextQuestion, QuestionVM } from "../Models/Quizzes/QuestionModel";
import NavigateNextIcon from "@mui/icons-material/NavigateNext";
import IsCorrect from "./IsCorrect";
import { useSelector, shallowEqual, useDispatch } from "react-redux";
import { RootState } from "../Redux/Reducers/RootReducer";
import * as theme from "../Redux/Reducers/ThemeReducer";
import AsideQuestion from "./AsideQuestion";
import { useIntl } from "react-intl";

export default function Question() {
  const dispatch = useDispatch();
  const intl = useIntl();
  const themeReducer = useSelector<RootState>(({ theme }) => theme, shallowEqual) as theme.IThemeState;

  let { id, qnr } = useParams() as { id: number | undefined; qnr: number | undefined };
  const [question, setQuestion] = React.useState<QuestionVM>();
  const [loading, setLoading] = React.useState<boolean>(true);
  const [showDialog, setShowDialog] = React.useState(false);
  const [isCorrect, setIsCorrect] = React.useState(false);

  const [initialState, setInitialState] = React.useState<number[]>([]);

  React.useEffect(() => {
    setInitialState([]);
    const asyncGetQuiz = async () => {
      var quiz = await GetNextQuestion(id, qnr);
      setQuestion(quiz);
      setLoading(false);
      setShowDialog(false);
    };
    asyncGetQuiz();
  }, [qnr, themeReducer.lang]);

  const changeSingleAnswer = (id: number) => {
    setInitialState([id]);
  };

  const changeMultipleAnswer = (id: number, checked: boolean) => {
    if (checked) {
      initialState.push(id);
      setInitialState(initialState);
    } else {
      setInitialState(initialState.filter((t) => t !== id));
    }
  };

  const nextQuestion = async () => {
    var IsAnswerCorrect = await CheckIfCorrect(id, qnr, initialState);
    setIsCorrect(IsAnswerCorrect);
    themeReducer.Questions?.push({
      id: id as number,
      qnr: qnr as number,
      IsCorrect: IsAnswerCorrect,
      Answer: initialState
    });
    dispatch(theme.actions.SetQuestion(themeReducer.Questions));
    setShowDialog(true);
  };

  return (
    <Box>
      <IsCorrect IsOpen={showDialog} Correct={isCorrect} />
      <Stack direction={{ sx: "column", md: "row" }}>
        <AsideQuestion />
        <Card sx={{ width: "80%" }}>
          <CardContent>
            <Typography variant="h4">{`${intl.formatMessage({ id: "Question" })} ${question?.Nr}/${themeReducer.TotalQuestion}`}</Typography>
            <Typography variant="h5">
              {question?.Nr}. {question?.Name}
            </Typography>
            {question?.TypeId == 1 || question?.TypeId == 2 ? (
              <FormControl style={{ marginLeft: "30px" }}>
                <RadioGroup aria-labelledby="demo-radio-buttons-group-label" name="radio-buttons-group">
                  {question.Options.map((opt) => (
                    <FormControlLabel key={opt.Id} value={opt.Id} control={<Radio />} onChange={() => changeSingleAnswer(opt.Id)} label={opt.Name} />
                  ))}
                </RadioGroup>
              </FormControl>
            ) : (
              <FormControl style={{ marginLeft: "30px" }}>
                {question?.Options.map((opt) => (
                  <>
                    <FormControlLabel key={opt.Id} control={<Checkbox onChange={(ev) => changeMultipleAnswer(opt.Id, ev.currentTarget.checked)} />} label={opt.Name} />
                  </>
                ))}
              </FormControl>
            )}
            <Stack direction="row" justifyContent={"end"}>
              <Button variant="contained" endIcon={<NavigateNextIcon />} onClick={nextQuestion}>
                {themeReducer.TotalQuestion == qnr ? <>{intl.formatMessage({ id: "Finish" })}</> : <>{intl.formatMessage({ id: "NextQuestion" })}</>}
              </Button>
            </Stack>
          </CardContent>
        </Card>
      </Stack>
    </Box>
  );
}
