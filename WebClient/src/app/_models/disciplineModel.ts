export interface DisciplineModel {
  id: string;
  name: string;
  lectorId: string;
  lectorFullName: string;
  groupId: string;
  groupName: string;
  semester: number;
  assistantsIds: string[];
  assistantsFullNames: string[];
}

