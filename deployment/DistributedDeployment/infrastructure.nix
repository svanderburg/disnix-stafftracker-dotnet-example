{
  test1 = {
    hostname = "localhost";
    msSqlUsername = "sa";
    msSqlPassword = builtins.readFile ./mssqlpw;
    iisWwwRoot = "/cygdrive/c/inetpub/wwwroot";
  };
}
