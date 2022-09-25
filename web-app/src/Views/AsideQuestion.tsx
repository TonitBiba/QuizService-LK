import React from "react";
import { Box, Button, Card, CardContent, Stack, Typography } from "@mui/material";
import { useSelector, shallowEqual } from "react-redux";
import { RootState } from "../Redux/Reducers/RootReducer";
import { IThemeState } from "../Redux/Reducers/ThemeReducer";
import { useIntl } from "react-intl";

export default function AsideQuestion() {
  const intl = useIntl();
  const themeReducer = useSelector<RootState>(({ theme }) => theme, shallowEqual) as IThemeState;
  var TotalUnAnsweredQuestions = [] as number[];
  var questiosn = themeReducer.Questions?.map((q) => q.qnr) as number[];
  for (var i = Math.max(...questiosn, 0); i < themeReducer.TotalQuestion; i++) {
    TotalUnAnsweredQuestions.push(i + 1);
  }
  return (
    <>
      <Card sx={{ width: { xs: "100%", md: "250px" }, marginRight: "10px", marginBottom: { sx: "10px", md: "0px" } }}>
        <CardContent>
          <Typography mt={1}>{intl.formatMessage({ id: "Questions" })}</Typography>
          <Stack direction={"row"} flexWrap={"wrap"} justifyContent={"center"} spacing={2} mt={1}>
            {themeReducer.Questions?.map((q) => (
              <Box>
                <Button variant="contained" size="small" sx={{ padding: 0, marginBottom: "10px" }} color={q.IsCorrect ? "success" : "error"}>
                  <Typography variant="h6">{q.qnr}</Typography>
                </Button>
              </Box>
            ))}

            {TotalUnAnsweredQuestions.map((q) => (
              <Box>
                <Button variant="contained" size="small" sx={{ padding: 0, marginBottom: "10px" }} color={"inherit"}>
                  <Typography variant="h6">{q}</Typography>
                </Button>
              </Box>
            ))}
          </Stack>
        </CardContent>
      </Card>
    </>
  );
}
