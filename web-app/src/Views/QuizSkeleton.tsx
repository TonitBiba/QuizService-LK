import { Box, Skeleton } from "@mui/material";
import React from "react";

export default function QuizSkeleton() {
  return (
    <>
      <Skeleton variant="rounded" width={345} height={164} />
      <Box mt={1}>
        <Skeleton variant="rounded" width={345} height={48} />
      </Box>
    </>
  );
}
