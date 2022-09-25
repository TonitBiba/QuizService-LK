import axios from "axios";

export interface QuizInfo {
  ID: number;
  Name: string;
  Description?: string;
  Image?: string;
  RegisterDate: Date;
  QuestionTypes: QuestionType[];
}

interface QuestionType {
  Type: string;
  Count: number;
}

export async function GetQuizInfo(id: number | undefined) {
  return (await axios.get<QuizInfo>("/Quiz/" + id)).data;
}
