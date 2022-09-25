import { Box, Button, Card, CardContent, Stack, Typography } from "@mui/material";
import React from "react";
import { useSelector, shallowEqual } from "react-redux";
import { RootState } from "../Redux/Reducers/RootReducer";
import { IThemeState } from "../Redux/Reducers/ThemeReducer";
import { Pie } from "react-chartjs-2";
import { Chart as ChartJS, ArcElement, Tooltip, Legend } from "chart.js";
import { useIntl } from "react-intl";

ChartJS.register(ArcElement, Tooltip, Legend);

export default function Result() {
  const intl = useIntl();
  const themeReducer = useSelector<RootState>(({ theme }) => theme, shallowEqual) as IThemeState;
  const correctAnswers = themeReducer.Questions?.filter((q) => q.IsCorrect === true).length as number;
  const data = {
    labels: [intl.formatMessage({ id: "Correct" }), intl.formatMessage({ id: "Incorrect" })],
    datasets: [
      {
        label: "# of questions",
        data: [correctAnswers, themeReducer.TotalQuestion - correctAnswers],
        backgroundColor: ["#36a2eb", "#ff6384"],
        borderColor: ["#36a2eb", "#ff6384"],
        borderWidth: 1
      }
    ]
  };

  return (
    <Card>
      <CardContent>
        <Typography variant="h5">{intl.formatMessage({ id: "Results" })}</Typography>
        <Typography variant="h6">
          {themeReducer.Questions?.filter((q) => q.IsCorrect === true).length}/{themeReducer.TotalQuestion} {intl.formatMessage({ id: "QuestionsAnsweredCorrectly" })} {(correctAnswers / themeReducer.TotalQuestion) * 100} %.
        </Typography>
        <Stack direction="row" justifyContent={"center"}>
          <Box maxWidth={"210px"}>
            <Pie data={data} />
          </Box>
        </Stack>

        <Typography mt={3}>{intl.formatMessage({ id: "ListCorretIncorrect" })}</Typography>
        <Stack flexWrap={"wrap"} flexGrow={"1"} flexShrink={"1"} direction={"row"} justifyContent={"center"} spacing={2} mt={1}>
          {themeReducer.Questions?.map((q) => (
            <Button variant="contained" size="small" sx={{ padding: 0 }} color={q.IsCorrect ? "success" : "error"}>
              <Typography variant="h6">{q.qnr}</Typography>
            </Button>
          ))}
        </Stack>
      </CardContent>
    </Card>
  );
}
