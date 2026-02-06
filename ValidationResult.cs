namespace rentalmovie
{
    public enum RequestType
    {
        Post,
        Put,
        Get,
        Delete
    }
    [Flags]
    public enum GenreValidationResult
    {
        Default = 0,
        NotExist = 1,
        Exist = 2,
        UnAuthorized = 3,
        Required = 4,
        Ok = 5
    }
    [Flags]
    public enum MovieValidationResult
    {
        Default = 0,
        NotExist = 1,
        Exist = 2,
        UnAuthorized = 3,
        Required = 4,
        Ok = 5
    }

    [Flags]
    public enum MembershipValidationResult
    {
        Default = 0,
        NotExist = 1,
        Exist = 2,
        UnAuthorized = 3,
        Required = 4,
        Ok = 5
    }

    [Flags]
    public enum CustomerValidationResult
    {
        Default = 0,
        NotExist = 1,
        Exist = 2,
        UnAuthorized = 3,
        Required = 4,
        Ok = 5,
        MembershipTypeIdNotExist = 6
    }

    [Flags]
    public enum MovieGenresMappingValidationResult
    {
        Default = 0,
        MappingExist = 1,
        GenereNotExists = 2,
        UnAuthorized = 3,
        Ok = 128
    }

    [Flags]
    public enum CustomeremembershipMappingValidationResult
    {
        Default = 0,
        MappingExist = 1,
        GenereNotExists = 2,
        UnAuthorized = 3,
        Ok = 128
    }
}

