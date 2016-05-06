{
  test1 = {
    properties = {
      hostname = "localhost";
    };
    
    containers = {
      mssql-database = {
        msSqlUsername = "sa";
        msSqlPassword = builtins.readFile ./mssqlpw;
      };
      
      iis-webapplication = {
        iisWwwRoot = "/cygdrive/c/inetpub/wwwroot";
      };
    };
  };
}
