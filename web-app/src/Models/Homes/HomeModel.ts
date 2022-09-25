import axios from "axios";

export interface QuizVM {
  ID: number;
  Name: string;
  Description?: string;
  Image?: string;
}

export async function GetQuizzes() {
  return (await axios.get("/Quiz")).data;
}
