import axios from "axios";

export interface QuestionVM {
  Id: number;
  Name: string;
  TypeId: number;
  TypeName: string;
  Nr: number;
  Options: OptionVM[];
}

export interface OptionVM {
  Id: number;
  Name: string;
}

export async function GetNextQuestion(id: number | undefined, qid: number | undefined) {
  return (await axios.get<QuestionVM>("/Quiz/" + id + "/questions/" + (qid == undefined ? "" : qid))).data;
}

export async function CheckIfCorrect(id: number | undefined, qid: number | undefined, Answer: number[]) {
  return (
    await axios.post("/Quiz/" + id + "/questions/" + (qid == undefined ? "" : qid), {
      Answer: Answer
    })
  ).data;
}
