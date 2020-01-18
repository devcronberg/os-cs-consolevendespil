# Udvidet C#-opgave: Vendespil

I denne opgave skal du skabe et klassisk vendespil til afvikling på konsol. Det kunne se nogenlunde således ud - her i den nemme version:

<div>
<img src="Billeder/pic1a.png" width="400" />
<img src="Billeder/pic2a.png" width="400" />
<img src="Billeder/pic3a.png" width="400" />
<img src="Billeder/pic4a.png" width="400" />
</div>

Ved spillets start kan du vælge mellem 5 forskellige sværhedsgrader der bestemmer størrelsen på matrix med tal som skal gættes.

<details>
<summary>Se de forskellige muligheder her</summary>
<div>
    <img src="Billeder/s1b.png" width="400" />
    <img src="Billeder/s2.png" width="400" />
    <img src="Billeder/s3.png" width="400" />
    <img src="Billeder/s4.png" width="400" />
    <img src="Billeder/s5.png" width="400" />
</div>
</details>

Den nemmeste måde at få en idé om opgaven er selv at spille spillet - du kan hente [en kompileret version i vendespil.zip](https://github.com/devcronberg/os-cs-consolevendespil/releases/latest) eller blot afvikle projektet i VS ved at clone hele repository'et.

## Opgave

Du kan løse opgave præcis som du vil - der er hel fri leg - men jeg har løst den som følger:

- klasse [VendeKort](ConsoleVendespil/VendeKort.cs) som repræsenterer det enkelte kort (tal, vist forside eller bagside med en [enum](ConsoleVendespil/VendeKortSide.cs))
- klasse [VendeKortSpil](ConsoleVendespil/VendeKortSpil.cs) som repræsenterer spillet - herunder gemmer kort i en matrix (2 dimensionelt array), holder styr på antal træk mv
- klasse [ConsoleFunktioner](ConsoleVendespil/ConsoleFunktioner.cs) med lidt hjælp til input på konsol

men opgaven kan løses på mange forskellige måder. Om du bliver inspireret af min løsning eller starter helt fra bunden er helt op til dig.

God fornøjelse

Michell

