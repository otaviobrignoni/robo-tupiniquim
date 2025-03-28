# Robo Tupiniquim

![GIF Demonstrativo](https://i.imgur.com/CniqyQG.gif)

## Descrição
O Robo Tupiniquim é um software de navegação desenvolvido para a AEB (Agência Espacial Brasileira), permitindo que um robô explorador percorra uma área retangular de Marte.

## Funcionalidades
- Definir o tamanho do grid de exploração
- Posicionar o robô dentro do grid
- Enviar e executar sequências de comandos
- Alternar entre dois robôs
- Interface interativa via terminal

## Comandos do Robô
- **M** - Move o robô para frente na direção atual
- **E** - Gira o robô 90° para a esquerda
- **D** - Gira o robô 90° para a direita

## Instalação
Clone o repositório ou baixe o código-fonte:

```sh
https://github.com/otaviobrignoni/robo-tupiniquim.git
```

Navegue para o diretório do projeto:

```sh
cd robo-tupiniquim
```

Restaure as dependências:

```sh
dotnet restore
```

Compile a solução:

```sh
dotnet build --configuration Release
```

Execute o projeto:

```sh
dotnet run --project RoboTupiniquim.ConsoleApp
```

Alternativamente, utilize o executável:

1. Navegue até:
   ```sh
   ./RoboTupiniquim.ConsoleApp/bin/Release/net8.0/
   ```
2. Abra:
   ```sh
   RoboTupiniquim.ConsoleApp.exe
   ```

## Dependências
- .NET SDK (Recomendado .NET 8.0 ou mais novo) para compilar e executar o projeto.

