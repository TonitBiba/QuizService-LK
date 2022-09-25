import React from "react";

import { AppBar, Badge, Box, IconButton, Toolbar, Typography } from "@mui/material";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import Home from "../Views/Home";
import Layout from "../Views/Layout";
import Exam from "../Views/Exam";
import Question from "../Views/Question";
import Result from "../Views/Result";

export default function Router() {
  return (
    <BrowserRouter>
      <Layout>
        <Routes>
          <Route>
            <Route path="/" element={<Home />} />
            <Route path="/Home" element={<Home />} />
            <Route path="/Exam/:id" element={<Exam />} />
            <Route path="/Question/:id/:qnr" element={<Question />} />
            <Route path="/Result" element={<Result />} />
            <Route path="*" element={<Home />} />
          </Route>
        </Routes>
      </Layout>
    </BrowserRouter>
  );
}
