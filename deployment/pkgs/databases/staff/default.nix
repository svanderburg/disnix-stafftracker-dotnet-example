{stdenv}:

stdenv.mkDerivation {
  name = "staff";
  src = ../../../../services/databases/staff;
  installPhase = ''
    mkdir -p $out/mssql-databases
    cp *.sql $out/mssql-databases
  '';
}
