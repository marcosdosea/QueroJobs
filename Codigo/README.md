 - Abrir o arquivo DER.mwb que está dentro da pasta AnaliseProjeto
 - Dentro do MySql Workbench clicar em: Database -> Synchronize model -> Prosseguir até o final
 - Abrir o arquivo QueroJobs.sln que está dentro da pasta Código
 - Dentro do Visual Studio clicar em: Tools -> NuGet Package Manager -> Package Manager Console
 - No terminal, digitar os comandos abaixo:
 
 Para instalar os pacotes
 ```CMD
dotnet restore
 ```
Para instalar o dotnet tool (Basta executar esse comando 1 vez por máquina)
```CMD
dotnet tool install --global dotnet-ef 
 ```
Atualizar as entidade do código (Executar esse comando a cada atualização na modelagem do Banco)
```CMD
dotnet ef dbcontext scaffold "server=localhost;port=3306;user=root;password=123456;database=querojobs" MySql.EntityFrameworkCore -p Core -c BibliotecaContext -v -f 
 ```
Alterar o comando acima de acordo com as configurações da sua instância do mysql.