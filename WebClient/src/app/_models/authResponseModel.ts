import { Guid } from 'guid-typescript';

export class AuthReponseModel {
  
  id: Guid | undefined;
  name: string = "";
  surname: string = "";
  midname: string = "";
  username: string = "";
  password: string = "";
  token: string = "";
}
