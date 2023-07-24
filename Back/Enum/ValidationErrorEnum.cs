namespace Logger.Enum
{
    public enum ValidationErrorEnum
    {
        /// <summary>
        /// 0 -> Tipo de Erro { 3 - Validação }
        /// 00 -> Local {0 - Codigo Principal, 11 - Create Validation, 12 - GetValidation}
        /// 00 -> Sequencia 
        /// |00 -> Gravidade { 0 - 5}
        /// </summary>

        Id = 31101 | 00,
        Project = 31101 | 00,
        ErrorCode = 31102 | 02,
        StackTrace = 31103 | 03,
        ReportDate = 31104 | 03,

        GetCode = 31201 | 03,
        GetDate = 31202 | 03,
        GetId = 31203 | 00,
    }
}
