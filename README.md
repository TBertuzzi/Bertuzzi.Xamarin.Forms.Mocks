# Bertuzzi.Xamarin.Forms.Mocks

Apenas um Mock para você utilizar em suas aplicações Xamarin.Forms
 
 ###### This is the component, works on iOS, Android and UWP.
 
 **NuGet**

|Name|Info|
| ------------------- | :------------------: |
|Bertuzzi.Xamarin.Forms.Mocks|[![NuGet](https://buildstats.info/nuget/Bertuzzi.Xamarin.Forms.Mocks)](https://www.nuget.org/packages/Bertuzzi.Xamarin.Forms.Mocks/)|

**Platform Support**

Bertuzzi.Xamarin.Forms.Mocks is a .NET Standard 2.0 library.Its only dependency is the Xamarin.Forms

## Setup / Usage

Em sua ViewModel utilize a BaseViewModel para obter as funcionalidades basica e o carregamento assíncrono.

```csharp

public class MainViewModel : BaseViewModel

public override async Task LoadAsync()

```

Em sua View utilize a BaseViewModel, isso fara que o LoadAsync seja chamado a partir da ViewModel do seu BindingContext.

```csharp

<base:BaseView   xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:d="http://xamarin.com/schemas/2014/forms/design"
             xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
             xmlns:base="clr-namespace:Bertuzzi.Xamarin.Forms.Mocks.Views;assembly=Bertuzzi.Xamarin.Forms.Mocks"> 

</base:BaseView>



```

Em seguida é possivel utilizar o PokemonService do Mock para suas aplicações de Teste, como no Exemplo abaixo :

```csharp

public class MainViewModel : BaseViewModel
    {
        public ObservableCollection<Pokemon> Pokemons { get; }
        private readonly PokemonService _pokemonService;


        public MainViewModel()
        {
            Pokemons = new ObservableCollection<Pokemon>();
            _pokemonService = new PokemonService();

        }


        public override async Task LoadAsync()
        {
            Ocupado = true;
            try
            {
                //Antiga Logica de Carregamento
                var pokemonsAPI = await _pokemonService.GetPokemonsAsync();

                Pokemons.Clear();

                foreach (var pokemon in pokemonsAPI)
                {
                    pokemon.Image = _pokemonService.GetImageStreamFromUrl(pokemon.Sprites.FrontDefault.AbsoluteUri);
                    Pokemons.Add(pokemon);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Erro", ex.Message);
            }
            finally
            {
                Ocupado = false;
            }

        }

        
    }

```



