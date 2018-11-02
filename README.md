# CSharpGenerics

CSharpGenerics


Adicione uma string de conexão válida e confira o provider do Entity Framework Core

Se quiser utilizar esse projeto como base para o seu próprio faça o seguinte:

Na pasta `Data/Migrations` remove  arquivo os arquivos:

* `20181102171552_EcommerceSellFunctionlity.cs`
* `20181102171552_EcommerceSellFunctionlity.Designer.cs`

Após feito isso remova as migrações com o comando `Remove-Migration`

No arquivo `DbSetApplicationDbContext.cs` remova os DbSet's, para futuramente adicionar os seus.

Remova as pastas `Models/Ecommerce` que contém classes utilizadas para o projeto exemplo

Após isso podem ser removido as controladoras:

* CategoriesController.cs
* ProductsController.cs

Remova as Views correspondents a essas controllers:

* Views/Categories
* Views/Products

Remova a pasta `Services/Category` onde ficou a implementação específica do serviço de categoria.

Por fim remova a linha 37 do arquivo `Startup.cs` que contém a seguinte linha de código:

```csharp
services.AddScoped<Services.Category.ICategoryService, Services.Category.CategoryService>();
```

Isso já será possível continuar um novo projeto a partir desse.

Ou você também pode adicionar os arquivos ao seu projeto:

* `Controllers/GenericController.cs`
* `Data/DbSetApplicationDbContext.cs`
* `Services/Generic/IGenericService.cs`
* `Services/Generic/GenericService.cs`

E por fim configurar a injeção de dependência no seu arquivo `Startup.cs`


```csharp
// Add generic service
services.AddScoped(typeof(Services.Generic.IGenericService<>), typeof(Services.Generic.GenericService<>));
```
