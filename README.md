# Blazor-Logistics-Demo

A small shipment-management demo that runs as both a **Blazor Web App** (server-rendered, interactive over SignalR) and a **Blazor Hybrid** .NET MAUI app — sharing the same pages, layout and styling.

## Solution layout

```
Blazor-Logistics-Demo.slnx
├── Logistics.Core     net10.0        Models, IShipmentService, in-memory implementation, AddLogisticsCore()
├── Logistics.UI       net10.0 (RCL)  Shared pages, layout, components and the design-system stylesheet
├── Logistics.Web      net10.0        Blazor Web App host (App.razor, Routes, /Error, ReconnectModal)
└── Logistics.Maui     net10.0-android; net10.0-ios
                                      MAUI Blazor Hybrid host (MauiProgram, MainPage + BlazorWebView)
```

Both hosts reference `Logistics.UI` and call `AddLogisticsCore()`, so they resolve the same services with
the same lifetimes. Everything routable lives in `Logistics.UI` except the web host's `/Error` page, which
needs `HttpContext` and therefore cannot be shared.

## Running

```bash
# Web
dotnet run --project Logistics.Web --launch-profile http     # http://localhost:5194

# MAUI (Android emulator/device)
dotnet build Logistics.Maui -f net10.0-android -t:Run
```

The web host must run in the **Development** environment locally: outside Development, ASP.NET Core does not
load the static-web-assets manifest, so the stylesheet served from `_content/Logistics.UI/` 404s until the
app is published.

`Platforms/Windows` and `Platforms/MacCatalyst` are still present — add `net10.0-windows10.0.19041.0` or
`net10.0-maccatalyst` to `TargetFrameworks` in `Logistics.Maui.csproj` to build those heads.

## Features
- Dashboard with KPI cards
- Shipment list with filtering/search
- Shipment details page
- Create form with validation
- Service abstraction with dependency injection
- One component set shared across web and native

## Tech Stack
- .NET 10
- Blazor Web App (Interactive Server) + Blazor Hybrid (.NET MAUI, BlazorWebView)
- Razor Class Library for shared UI
- Dependency Injection
- DataAnnotations validation

## Why I built this
I created this project to strengthen my practical Blazor experience in a logistics-oriented domain close to the enterprise systems I work on professionally.

## Next Improvements
- Replace mock service with ASP.NET Core Web API
- Add edit/delete operations
- Add authentication/authorization
- Add pagination and toast notifications
