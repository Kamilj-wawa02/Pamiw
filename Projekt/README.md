# Projekt na programowanie aplikacji mobilnych i webowych

## Omówienie

Projekt miał na celu stworzenie zestawu aplikacji: interfejsu API, aplikacji typu desktop, aplikacji WebAssembly oraz aplikacji mobilnej. W realizacji zadania posłużyłem się projektami wykonywanymi na laboratoriach. Wykorzystałem rozwiązania od Microsoftu w języku C#:
- internetowy interfejs API platformy ASP.NET Core
- aplikacja WPF
- aplikacja Blazor WebAssembly
- aplikacja MAUI

API oraz baza danych SQL zostały przeniesione do **Google Cloud Platform**, dzięki temu mamy do nich publiczny dostęp. Api znajduje się pod adresem: https://handy-freedom-408622.nw.r.appspot.com. Możemy przetestować jego działanie w przeglądarce wykorzystując endpoint pobierania listy książek (żądanie GET): https://handy-freedom-408622.nw.r.appspot.com/api/Book.

## Internetowy interfejs API

Projekt można uruchomić w dwóch środowiskach: **Development** i **Production**. Aby je zmienić należy odpowiednio ustawić zmienną środowiskową **ASPNETCORE_ENVIRONMENT** wykorzystując komendy **$env:ASPNETCORE_ENVIRONMENT = "Development"** oraz **$env:ASPNETCORE_ENVIRONMENT = "Production"**.
W środowisku **Development** do prawidłowego funkcjonowania wymagany jest uruchomiony w tle projekt **P05Library.API**, natomiast w przypadku **Production** posługujemy się publicznym adresem do API działającego na serwerze w Google Cloud Platform.


## Wdrożenie API do usługi chmurowej

Wykorzystałem usługę **App Engine** w Google Cloud Platform. Aby przeprowadzić wdrożenie przygotowałem specjalną wersję projektu **P05Library.API** (znajdującą się w katalogu **DeployedAPI**), w której obniżyłem środowisko dotnet do wersji 6.0 oraz scaliłem serwisy z projektu **P06Library.Shared**, ponieważ było to wymagane przez Google Cloud Platform (obsługiwane wdrożenie **jednego** pliku projektu w wersji **dotnet 6.0**).

Aby wdrożyć projekt umieściłem w jego katalogu plik **app.yaml** zawierający odpowiednią konfigurację środowiska:

```yaml
runtime: aspnetcore
env: flex

runtime_config:
  operating_system: ubuntu22

manual_scaling:
  instances: 1
resources:
  cpu: 1
  memory_gb: 0.5
  disk_size_gb: 10
```

Następnie posłużyłem się Google Cloud CLI, najpierw odpowiednio komendami: ***gcloud init***, ustawiłem aktualny projekt ***gcloud config set project handy-freedom-408622***. Przy skonfigurowanym środowisku uruchomiłem wdrożenie poprzez ***gcloud app deploy app.yaml***. Po wdrożeniu można otworzyć stronę w przeglądarce poprzez ***gcloud app browse*** (w naszym przypadku będzie pusta, bo jest to projekt API).
