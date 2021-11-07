using System;

/*
    It is more logic to use separate namespace for the configuration.
*/
namespace JPTask01.Configuration
{
    /*
        Exception class to throw, when configuration generation fails.
        Not exactly needed, because we could use the base class Exception,
        but this makes visible how exceptions can be extended and used.
    */
    public class ConfigException : Exception 
    {
        public ConfigException(String msg)
            : base(msg)
        {}
    }

    /*
        Config class logically defines application configuration.
        It separates concerns and makes it possible to use same
        configuration clas in different applications without rewriting
        code.
    */
    public class Config
    {
        private Config() {
            /* 
                Only factory methods can create class. This is convinient, because
                then user's of the class cannot make invalid or not ready configuration
                objects.
            */
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
        
        /*
            ParseParameters is the factory function that parses comman line arguments,
            validates them and returns valid configuration object.

            If validation fails, exception is thrown. So it is impossible to create
            invalid configuration object.

            args    array of command line argument strings
        */
        public static Config ParseParameters(string[] args) {
            // Validata array exitence
            if (args == null) {
                throw new ConfigException("args is null!");
            }

            Config config = new Config();
            /*
                Loop through parameters and validate them
            */
            for (int i = 0; i < args.Length; ++i)
            {
                /*
                    There may be a library to handle command line parameters,
                    but I have not searched for one.
                */
                if (args[i] == "-h" || args[i] == "--help")
                {
                    /*
                        We use validation to return help message.
                        This may be a bit unusual solution.
                    */
                    throw new ConfigException(helpMessge);
                } 
                else if (args[i] == "-cf" || args[i] == "--config-file") 
                {
                    // Nice way of showing not (yet) implemented features.
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
            // After validation, we return complete and validated confgiruation object for use.
            return config;
        }
    }
}