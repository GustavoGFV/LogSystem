namespace Logger.Enum
{
    public enum InternalErrorEnum
    {
        /// <summary>
        /// 0 -> Tipo de Erro { 3 - Validação }
        /// 00 -> Local {0 - Codigo Principal, 11 - Create Validation, 12 - GetValidation}
        /// 00 -> Sequencia 
        /// |00 -> Gravidade { 0 - 5}
        /// </summary>

        Create = 10001 | 00,
        GetAll = 20001 | 01,
        GetID = 20002 | 00,
        GetDate = 20003 | 03,
        GetCode = 20004 | 03,
        GetCodeDate = 20005 | 04,
    }
}
