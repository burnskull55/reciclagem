# reciclagem

Um teste da criacao de uma api com o Visual studio e C#, usando o Swagger como uma ui e MS sql server como data baser.

A Api em si e uma simplificacao de um projeto anterior de fluxo de caixa e controle de estoque para uma empresa de reciclagem,
essa api faz apenas o Crud do estoque de materiais(materiais sao considerados itens unicos dentro do estoque baseado no valor da compra por esse material)
como ferro e cobre que sao posteriormente vendidos para reciclagem.

-como usar os metodos do swagger(estas instrucoes estao comentadas dentro do codigo nos metodos da classe controller) :

--get nao usa parametros, e gera uma lista de json's com todos os materiais dentro do estoque;

--get(id) recebe um numero inteiro como identificador de qual material esta dentro da tabela 


-comandos uteis:

--implementacao de banco de dados : 
Scaffold-DbContext "Server=yourServerName;Database=YourDatabaseName;
Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir YourFolder
