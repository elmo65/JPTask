using System;
namespace JPTask01
{
    public class ConfigException : Exception 
    {
        public ConfigException(String msg)
            : base(msg)
        {}
    }

    class Config
    {
        private Config() {
            // Only factory methods can create class
        }
        private static String helpMessge = @"
        This application shows pictures in a carousel.
            Parameters:
            -h | --help: Shows help.
            -cf | --config-file <config-file>: Reads configuration from <config-file>.
            -d | --directory <directory>: Seach pictures from directory <directory>.
            -f | --filter <file-filter>: Select only file matching <file-filter>.
        
        Command line parameters overrides parameters from config file.
        ";
        private String configFilePath;
        private String searchDirectory;
        private String filter;
        
        public static Config ParseParameters(string[] args) {
            Config config = new Config();
            for (int i = 0; i < args.Length; ++i)
            {
                if (args[i] == "-h" || args[i] == "--help")
                {
                    throw new ConfigException(helpMessge);
                } 
                else if (args[i] == "-cf" || args[i] == "--config-file") 
                {
                    throw new ConfigException("Config file is not supported!");
                }
                else if (args[i] == "-d" || args[i] == "--directory") 
                {
                    if (i + 1 == args.Length) 
                    {
                        throw new ConfigException("No argument for '" + args[i] + "'!");
                    }
                    config.searchDirectory = args[++i];
                }
                else if (args[i] == "-f" || args[i] == "--filter") 
                {
                    throw new ConfigException("Filter is not supported!");
                }
                else 
                {
                    throw new ConfigException("Unknown parameter '" + args[i] + "'!");
                }
            }
            if (String.IsNullOrWhiteSpace(config.searchDirectory)) {
                throw new ConfigException("Search directory not set!");
            }
            return config;
        }
    }
}