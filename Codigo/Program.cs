var builder = WebApplication.CreateBuilder(args);


#region " Configurando servi�os no container "

// Adicionando MVC no pipeline
builder.Services.AddControllersWithViews();

var app = builder.Build();

#endregion

# region " Configurando o resquest dos servi�os no pipeline "

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();

// Adicionando suporte a rotas
app.UseRouting();

// Rota padr�o
app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute("default", "{controller=FuncionarioCruds}/{action=Formulario}/{id?}");

app.Run();

#endregion