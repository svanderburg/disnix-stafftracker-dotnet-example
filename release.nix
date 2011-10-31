{ nixpkgs ? <nixpkgs>
, nixos ? <nixos>
}:

let
  jobs = rec {
    tarball =
      { WebServicesExampleNET ? {outPath = ./.; rev = 1234;}
      , officialRelease ? false}:
    
      let
        pkgs = import nixpkgs {};
	
        disnixos = import "${pkgs.disnixos}/share/disnixos/testing.nix" {
          inherit nixpkgs nixos;
        };
      in
      disnixos.sourceTarball {
        name = "WebServicesExample.NET";
	version = builtins.readFile ./version;
	src = WebServicesExampleNET;
        inherit officialRelease;
      };    
  };
in
jobs
