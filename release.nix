{ nixpkgs ? <nixpkgs>
, nixos ? <nixos>
}:

let
  jobs = rec {
    tarball =
      { disnix_stafftracker_dotnet_example ? {outPath = ./.; rev = 1234;}
      , officialRelease ? false}:
    
      let
        pkgs = import nixpkgs {};
        
        disnixos = import "${pkgs.disnixos}/share/disnixos/testing.nix" {
          inherit nixpkgs nixos;
        };
      in
      disnixos.sourceTarball {
        name = "disnix_stafftracker_dotnet_example";
        version = builtins.readFile ./version;
        src = WebServicesExampleNET;
        inherit officialRelease;
      };
  };
in
jobs
