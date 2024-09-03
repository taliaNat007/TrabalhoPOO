using tabela_marca;
using tabela_marca.Models;
using tabela_marca.DAO;

try
{
    Conexao.Conectar();

    /* MarcaDAO menu = new MarcaDAO();
     menu.Menu();*/
    

     int menu = 0;
             do
             {
                 Console.Write(@"	                   
                                                                              ------- BEM VINDO -------

                         Selecione abaixo a opção que deseja 
                             1 | CADASTRAR
                             2 | DELETAR
                             3 | ATUALIZAR
                             4 | LISTAR:   ");
                 menu = Convert.ToInt32(Console.ReadLine());

                 switch (menu)
                 {
                     // CADASTRAR/INSERT
                     case 1:
                         try
                         {
                             Console.Clear();
                             Console.WriteLine(@"	                   
                                                                              ---- CADASTRANDO NOVA MARCA ---- 
                                                 ");

                             Marca marca = new Marca();

                             Console.Write(@"          Digite o nome da marca: ");
                             marca.Nome = Console.ReadLine();
                             Console.Write(@"          Digite uma observação da marca: ");
                             marca.Observacao = Console.ReadLine();
                             Console.Write(@"          Digite a localidade da marca: ");
                             marca.Localidade = Console.ReadLine();
                                
                             MarcaDAO marcaDao = new MarcaDAO();
                             marcaDao.Insert(marca);
                             Conexao.FecharConexao();

                         }
                         catch (Exception ex)
                         {

                             Console.WriteLine(@$"            Erro ao cadastrar Marca! {ex.Message}");
                         }
                     break;

                     //DELETAR/DELETE
                     case 2:
                         try
                         {
                             Console.Clear();
                             Console.WriteLine(@"	                   
                                                                              ---- EXCLUIR CADASTRO ---- 
                                                 ");

                             Marca marca = new Marca();

                             Console.Write(@"          Digite o ID da marca que deseja excluir: ");
                             marca.Id_marca = Convert.ToInt32(Console.ReadLine());

                             MarcaDAO marcaDao = new MarcaDAO();
                             marcaDao.Delete(marca);
                             Conexao.FecharConexao();
                         }
                         catch (Exception ex)
                         {

                             Console.WriteLine(@$"            Erro ao Excluir Marca! {ex.Message}");
                         }
                     break;

                     //ATUALIZAR/UPDATE
                     case 3:
                         try
                         {
                             Console.Clear();
                             Console.WriteLine(@"	                   
                                                                              ---- ATUALIZAR CADASTRO ---- 
                                                 ");

                             Marca marca = new Marca();

                             Console.Write(@"          Digite o ID da marca que deseja atualizar: ");
                             marca.Id_marca = Convert.ToInt32(Console.ReadLine());

                             Console.WriteLine(@"	                   
                                                                              ----- CAMPO DE ATUALIZAÇÃO ----- 
                                                 ");

                             Console.Write(@"          Digite o novo nome da marca: ");
                             marca.Nome = Console.ReadLine();
                             Console.Write(@"          Digite uma nova observação da marca: ");
                             marca.Observacao = Console.ReadLine();
                             Console.Write(@"          Digite a nova localidade da marca: ");
                             marca.Localidade = Console.ReadLine();

                             MarcaDAO marcaDao = new MarcaDAO();
                             marcaDao.Update(marca);
                             Conexao.FecharConexao();

                         }
                         catch (Exception ex)
                         {

                             Console.WriteLine(@$"            Erro ao Atualizar Marca! {ex.Message}");
                         }
                     break;

                     //SELECIONAR/LISTAR
                     case 4:
                         try
                         {
                             Console.Clear();
                             var marcaDao = new MarcaDAO();

                             List<Marca> marcas = marcaDao.List();

                             Console.WriteLine(@"	                   
                                                                              ----- LISTAGEM DAS MARCAS CADASTRADAS ----- 
                                                 ");
                             foreach (var marca in marcas)
                             {
                                 Console.WriteLine($@" 
                                      ID: {marca.Id_marca}   
                                 Nome: {marca.Nome}    
                                 Observação: {marca.Observacao} 
                                 Localidade: {marca.Localidade}");

                             }
                         }
                         catch (Exception ex)
                         {
                             Console.WriteLine($"Erro! {ex.Message}");
                         }
                         break;

                     default:
                             Console.WriteLine(@" 	                   
																						   **** Opção INVÀLIDA! ****
			             |  PARA PROSSEGUIR DIGITE AS OPÇÕES DO MENU ABAIXO  |
						 |  PARA SAIR digite 0 |   ");

                break;
                 }
             } while (menu != 0);					


     

}
catch (Exception ex)
{
    Console.WriteLine($"ERRO! {ex.Message}");
}