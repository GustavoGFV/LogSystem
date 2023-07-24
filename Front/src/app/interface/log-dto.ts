export interface LogDto {
    id: number;
    project: string;
    code: string;
    message: string;
    stackTrace: string;
    date: Date|null;
}
