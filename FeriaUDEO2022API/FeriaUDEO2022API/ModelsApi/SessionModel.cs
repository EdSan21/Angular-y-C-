namespace FeriaUDEO2022API.ModelsApi
{
    public class SessionModel
    {
        public int SessionId { get; set; }
        public string SessionUser { get; set; }
        public string SessionName { get; set; }
        public string SessionImg { get; set; }

    }

    public class SessionReqModel
    {
        public int SessionId { get; set; }
        public string SessionUser { get; set; }
    }

    public class LoginModel
    {
        public string User { get; set; }
        public string Password { get; set; }
    }
}
