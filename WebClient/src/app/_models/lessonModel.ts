export interface LessonModel {
  
  id: string;
  disciplineId: string;
  disciplineName: string;
  groupId: string;
  groupName: string;
  lectorId: string;
  lectorFullName: string;
  assistantsIds: string[];
  assistantsFullNames: string[];
  lessonTypeId: string;
  lessonType: string;
  date: Date | null;
  sequenceNumber: number
}
