import { Box, Card, CardActionArea, CardContent, CardMedia, Stack, Typography } from "@mui/material";
import React from "react";
import { useNavigate } from "react-router-dom";
import { GetQuizzes, QuizVM } from "../Models/Homes/HomeModel";
import QuizSkeleton from "./QuizSkeleton";
import { useIntl } from "react-intl";

export default function Home() {
  const [quizzes, setQuizzes] = React.useState<QuizVM[]>([]);
  const [loading, setLoading] = React.useState<boolean>(true);

  let navigate = useNavigate();
  const intl = useIntl();

  React.useEffect(() => {
    const asyncGetQuizzes = async () => {
      var quizes = await GetQuizzes();
      setQuizzes(quizes);
      setLoading(false);
    };

    asyncGetQuizzes();
  }, []);

  return (
    <Box>
      <Typography component="h2" variant="h3" align="center" gutterBottom>
        {intl.formatMessage({ id: "ChooseQuizToStart" })}
      </Typography>
      <Typography variant="h5" align="center" component="p">
        {intl.formatMessage({ id: "QuizDescription" })}
      </Typography>

      <Box mt={4}>
        <Stack direction="row" spacing={2} justifyContent="center">
          {loading ? (
            <>
              <QuizSkeleton />
            </>
          ) : (
            quizzes.map((quiz) => (
              <Card sx={{ maxWidth: 345 }}>
                <CardActionArea
                  onClick={() => {
                    navigate("/Exam/" + quiz.ID);
                  }}
                >
                  <CardMedia component="img" height="140" image={quiz.Image} alt="green iguana" />
                  <CardContent>
                    <Typography gutterBottom variant="h5" component="div">
                      {quiz.Name}
                    </Typography>
                    <Typography variant="body2" color="text.secondary">
                      {quiz.Description}
                    </Typography>
                  </CardContent>
                </CardActionArea>
              </Card>
            ))
          )}
        </Stack>
      </Box>
    </Box>
  );
}
