import { BaseModel } from "./BaseModel";

export interface RoleModel extends BaseModel {
  name: string;
}

export enum Role {
  Admin = 'Admin',
  Teacher = 'Teacher',
  Headman = 'Headman'
}
