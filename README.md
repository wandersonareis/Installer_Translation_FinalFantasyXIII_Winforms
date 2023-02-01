# Installer_Translation_FinalFantasyXIII_Winforms

Instalador usado para baixar o pacote de tradução do jogo
Lightning Return Final Fantasy XIII
AngularJS-powered HTML5 Markdown editor.

## Funções

- Pega informações do [JSON](https://www.npoint.io/docs/b7fa9dd201b5e145b492) hospedado no [Npoint](https://www.npoint.io)
- Estas informações contém os links de atualização do instalador, do pacote de tradução
    e changelog da tradução do jogo,
- Verifica se existe versão atualizada do instalador
- Verifica se precisa baixar o pacote de tradução
- Verifica se existe pacote de tradução mais recente que o atual instalado
- Faz a instalação e desinstalação  da tradução do jogo

## Build

Installer_Translation_FinalFantasyXIII_Winforms requer [DotNet](https://dotnet.microsoft.com/en-us/download) v6+ para funcionar.

### Build a partir do código-fonte

Para  release:

```sh
cd {Diretório do projeto}
dotnet publish -c release --sc -r win-x64 -p:PublishSingleFile=true --self-contained false
```

Ou execute:

```sh
Build.cmd
```
Dentro do diretório do projeto
## License

MIT
