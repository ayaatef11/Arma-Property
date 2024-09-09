namespace ArmaProperty.Domain.Constants
{
    public static class Const
    {
        public const string PathWWWRoot = @"wwwroot/";
        public const string ImageDefault = "default-image.png";
        public const string PathImgeUser = "/dist/img";
        //Session
        public const string TypeMsg = "TypeMsg";
        public const string Title = "Title";
        public const string Msg = "Msg";
        public const string Seccess = "Seccess";
        public const string Error = "Error";

        //
        public const string Admin = "Admin";

        //Roles
        public const string SuperAdmin = "SuperAdmin";
        public const string EmailSuperAdmin = "superadmin@app.com";
        public const string Password = "P@$$w0rd";

        public const string Publisher = "Publisher";
        public const string EmailPublisher = "publisher@app.com";

        public const string Author = "Author";
        public const string EmailAuthor = "author@app.com";

        public const string User = "User";
        public const string EmailUser = "user@app.com";

        //Permission
        public const string Permission = "Permission";
        public const string LOCALAUTHORITY = "LOCAL AUTHORITY";

        public enum eTypePublisher
        {
            Author = 1,
            Publisher = 2
        };
    }
}
