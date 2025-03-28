# Robo Tupiniquim

![GIF Demonstrativo](https://i.imgur.com/CniqyQG.gif)

## Descri��o
O Robo Tupiniquim � um software de navega��o desenvolvido para a AEB (Ag�ncia Espacial Brasileira), permitindo que um rob� explorador percorra uma �rea retangular de Marte.

## Funcionalidades
- Definir o tamanho do grid de explora��o
- Posicionar o rob� dentro do grid
- Enviar e executar sequ�ncias de comandos
- Alternar entre dois rob�s
- Interface interativa via terminal

## Comandos do Rob�
- **M** - Move o rob� para frente na dire��o atual
- **E** - Gira o rob� 90� para a esquerda
- **D** - Gira o rob� 90� para a direita

## Instala��o
Clone o reposit�rio ou baixe o c�digo-fonte:

```sh
https://github.com/otaviobrignoni/robo-tupiniquim.git
```

Navegue para o diret�rio do projeto:

```sh
cd robo-tupiniquim
```

Restaure as depend�ncias:

```sh
dotnet restore
```

Compile a solu��o:

```sh
dotnet build --configuration Release
```

Execute o projeto:

```sh
dotnet run --project RoboTupiniquim.ConsoleApp
```

Alternativamente, utilize o execut�vel:

1. Navegue at�:
   ```sh
   ./RoboTupiniquim.ConsoleApp/bin/Release/net8.0/
   ```
2. Abra:
   ```sh
   RoboTupiniquim.ConsoleApp.exe
   ```

## Depend�ncias
- .NET SDK (Recomendado .NET 8.0 ou mais novo) para compilar e executar o projeto.

