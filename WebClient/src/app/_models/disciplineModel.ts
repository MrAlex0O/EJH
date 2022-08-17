import { Guid } from 'guid-typescript';

export interface DisciplineModel {
  id: Guid;
  name: string;
  lectorId: Guid;
  lectorFullName: string;
  groupId: Guid;
  groupName: string;
  semester: number;
  assistantsIds: Guid[];
  assistantsFullNames: string[];
}

