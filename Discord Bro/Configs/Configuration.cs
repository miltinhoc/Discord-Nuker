namespace Discord_Bro.Configs
{
    class Configuration
    {
        public string Token { get; set; }
        public string DmMessage { get; set; }
        public string ChannelsName { get; set; }

        public Configuration(string token = "Enter your token here", string dmMessage = "insert your message to mass dm users", string channelsName = "get nukedd")
        {
            Token = token;
            DmMessage = dmMessage;
            ChannelsName = channelsName;
        }
    }
}
