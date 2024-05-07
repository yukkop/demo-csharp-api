{
  inputs = {
    nixpkgs.url = "github:NixOS/nixpkgs/nixos-unstable";
    flake-utils.url = "github:numtide/flake-utils";
  };

  outputs = { self, nixpkgs, flake-utils }:
    flake-utils.lib.eachDefaultSystem (system:
      let
        pkgs = import nixpkgs { inherit system; };
        
        # Define the build and native build inputs
        nativeBuildInputs = with pkgs; [ dotnet-sdk_6 ];
        buildInputs = with pkgs; [ openssl ];
      in
      with pkgs;
      {
        devShells.default = mkShell {
          inherit buildInputs nativeBuildInputs;
          shellHook = ''
            export DOTNET_ROOT=${pkgs.dotnet-sdk_6}
            # Add Entity Framework CLI tool manually
            dotnet tool install --global dotnet-ef
	    export PATH="$PATH:/home/yukkop/.dotnet/tools"
          '';
        };
      }
    );
}
