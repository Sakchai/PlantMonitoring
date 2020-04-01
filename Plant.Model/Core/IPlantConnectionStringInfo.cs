namespace Plant.Model
{
    /// <summary>
    /// Represents a connection string info
    /// </summary>
    public interface IPlantConnectionStringInfo
    {
        /// <summary>
        /// DatabaseName
        /// </summary>
        string DatabaseName { get; set; }
        /// <summary>
        /// Server name or IP adress
        /// </summary>
        string ServerName { get; set; }

        /// <summary>
        /// Port
        /// </summary>
        string Port { get; set; }

        /// <summary>
        /// UID
        /// </summary>
        string Username { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        string Password { get; set; }
    }
}
