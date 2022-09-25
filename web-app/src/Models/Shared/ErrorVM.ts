export enum StatusEnum {
  SUCCESS = 1,
  INFO = 2,
  WARNING = 3,
  ERROR = 4
}

export interface ErrorVM {
  Status: StatusEnum;
  Description: string;
  Title: string;
  Icon?: string;
}
