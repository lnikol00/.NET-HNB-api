namespace HnbREST
{
    public static class Constants
    {
        public static string LocalhostUrl = DeviceInfo.Platform == DevicePlatform.Android ? "10.0.2.2" : "localhost";
        public static string Scheme = "https";
        public static string Port = "7280";
        public static string RestUrl = $"{Scheme}://{LocalhostUrl}:{Port}/api/Currency?fromDate={{0}}&toDate={{1}}";
    }
}
