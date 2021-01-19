using System;

namespace ControleDeAcesso
{
    class Program
    {
        
            int idAmbienteGerado = 1;
            int idUsuarioGerado = 1;
            Cadastro cadastro = new Cadastro();

            static void Main(string[] args)
            {
                Program proj = new Program();
                proj.Menu();
        }
            public void exibeMenu()
            {
                Console.WriteLine(
                    " 0. Sair" + "\n" +
                    " 1. Cadastrar ambiente" + "\n" +
                    " 2. Consultar ambiente" + "\n" +
                    " 3. Excluir ambiente" + "\n" +
                    " 4. Cadastrar usuario" + "\n" +
                    " 5. Consultar usuario" + "\n" +
                    " 6. Excluir usuario" + "\n" +
                    " 7. Conceder permissão de acesso ao usuário" + "\n" +
                    " 8. Revogar permissão de acesso ao usuário " + "\n" +
                    " 9. Registrar acesso" + "\n" +
                    "10. Consultar logs de acesso");
            }
            public void Menu()
            {
                try
                {
                    cadastro.download();
                    Console.WriteLine("Download Ok");
                }
                catch (Exception e)
                {
                }

                exibeMenu();
                Console.Write("-> Digite a opção: ");

                try
                {
                    int x = int.Parse(Console.ReadLine());
                escolha(x);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Digite uma opção válida!" + e.Message);
                    Menu();
                }
            }
            public void escolha(int x)
            {
                switch (x)
                {
                    case 0:
                        break;
                    case 1:
                        Console.Clear();
                        cadastraAmbiente();
                        Menu();
                    break;
                    case 2:
                        Console.Clear();
                        consultaAmbiente();
                        Menu();
                    break;
                    case 3:
                        Console.Clear();
                        excluiAmbiente();
                        Menu();
                    break;
                    case 4:
                        Console.Clear();
                        cadastraUsuario();
                        Menu();
                    break;
                    case 5:
                        Console.Clear();
                        consultaUsuario();
                        Menu();
                    break;
                    case 6:
                        Console.Clear();
                        excluiUsuario();
                        Menu();
                    break;
                    case 7:
                        Console.Clear();
                        concedePermissao();
                        Menu();
                    break;
                    case 8:
                        Console.Clear();
                        revogaPermissao();
                        Menu();
                    break;
                    case 9:
                        Console.Clear();
                        registraAcesso();
                        Menu();
                    break;
                    case 10:
                        Console.Clear();
                        consultaLog();
                        Menu();
                    break;
                    default:
                    Console.WriteLine("Digite uma opção válida");
                        Menu();
                    break;
                }
            }
            public void cadastraAmbiente()
            {
                string nomeAmbiente;
                Console.WriteLine("Nome do Ambiente:");
                nomeAmbiente = Console.ReadLine();
                cadastro.adicionarAmbiente(new Ambiente(idAmbienteGerado, nomeAmbiente));
                idAmbienteGerado += 1;
                Console.WriteLine("");
            }
        public void consultaAmbiente()
        {
            int idAmbiente;
            Console.WriteLine("ID do Ambiente:");
            idAmbiente = int.Parse(Console.ReadLine());
            Ambiente env;

            if ((env = cadastro.pesquisarAmbiente(new Ambiente(idAmbiente))) != null)
            {
                Console.WriteLine("Nome do ambiente: " + env.Nome);
                Console.WriteLine("");
            }
            else
            {
                if (cadastro.Ambientes.Count > 0)
                {
                    Console.WriteLine("Os ambientes existentes são:");
                    foreach (Ambiente am in cadastro.Ambientes)
                    {
                        Console.WriteLine(am.Id + " - " + am.Nome);
                        Console.WriteLine("");
                    }
                }
                else
                {
                    Console.WriteLine("Nenhum ambiente foi cadastrado ainda!");
                    Console.WriteLine("");
                }
            }
        }
            public void excluiAmbiente()
            {
                int idAmbiente;
                Console.WriteLine("ID do Ambiente:");
                idAmbiente = int.Parse(Console.ReadLine());

                if (cadastro.removerAmbiente(new Ambiente(idAmbiente))) Console.WriteLine("Excluido");
            else
                Console.WriteLine("Ambiente não existente");
                Console.WriteLine("");
            }
            public void cadastraUsuario()
            {
                string nomeUsuario;
                Console.WriteLine("Nome do Usuário:");
                nomeUsuario = Console.ReadLine();

                cadastro.adicionarUsuario(new Usuario(idUsuarioGerado, nomeUsuario));
                Console.WriteLine("Usuário Cadastrado");
                idUsuarioGerado += 1;
            }
        public void consultaUsuario()
        {
            int idUsuario;
            Console.WriteLine("ID do Usuário:");
            idUsuario = int.Parse(Console.ReadLine());
            cadastro.pesquisarUsuario(new Usuario(idUsuario));
            Usuario usuario;

            if ((usuario = cadastro.pesquisarUsuario(new Usuario(idUsuario))) != null)
            {
                Console.WriteLine("Nome do usuário: " + usuario.Nome);
                Console.WriteLine("");
            }
            else
            {
                Usuario us;
                if ((us = cadastro.pesquisarUsuario(new Usuario(idUsuario))) != null)
                {
                    Console.WriteLine(+us.Id + "Nome do usuário: " + us.Nome);
                }
                else
                {
                    if (cadastro.Usuarios.Count > 0)
                    {
                        Console.WriteLine("Usuário não encontrado, usuarios existentes são:");
                        foreach (Usuario user in cadastro.Usuarios)
                        {
                            Console.WriteLine(user.Id + " - " + user.Nome);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Nenhum usuário foi cadastrado ainda!");
                        Console.WriteLine("");
                    }
                    Console.WriteLine("");
                }
            }
        }
            public void excluiUsuario()
            {
                int idUsuario;
                Console.WriteLine("ID do Usuário");
                idUsuario = int.Parse(Console.ReadLine());

                if (cadastro.removerUsuario(new Usuario(idUsuario))) Console.WriteLine("Excluido");
                else Console.WriteLine("Não existe o usuario");
            Console.WriteLine("");
            }
            public void concedePermissao()
            {
                int idUsuario, idAmbiente;

                Console.WriteLine("ID do Ambiente: ");
                idAmbiente = int.Parse(Console.ReadLine());

                Console.WriteLine("ID do Usuário: ");
                idUsuario = int.Parse(Console.ReadLine());
                Console.WriteLine("");

                Usuario user = (cadastro.Usuarios.Find(u => u.Id == idUsuario));
                Ambiente ambiente = cadastro.pesquisarAmbiente(new Ambiente(idAmbiente));
                if (user.concederPermissao(ambiente)) Console.WriteLine("Concedida.");
                else Console.WriteLine("Não concedida.");
                Console.WriteLine("");
            }
            public void revogaPermissao()
            {
            int idUsuario, idAmbiente;

                Console.WriteLine("ID do Ambiente: ");
                idAmbiente = int.Parse(Console.ReadLine());

                Console.WriteLine("ID do Usuário: ");
                idUsuario = int.Parse(Console.ReadLine());

                Usuario user = (cadastro.Usuarios.Find(u => u.Id == idUsuario));
                Ambiente ambiente = cadastro.pesquisarAmbiente(new Ambiente(idAmbiente));
                if (user.revogarPermissao(ambiente)) Console.WriteLine("Revogada.");
                else Console.WriteLine("Não revogada");
            }
            public void registraAcesso()
            {
                int idUsuario, idAmbiente;

                Console.WriteLine("ID do Ambiente: ");
                idAmbiente = int.Parse(Console.ReadLine());

                Console.WriteLine("ID do Usuário: ");
                idUsuario = int.Parse(Console.ReadLine());

                Usuario user = cadastro.pesquisarUsuario(new Usuario(idUsuario));
                Ambiente environment = cadastro.pesquisarAmbiente(new Ambiente(idAmbiente));
                if (user.Ambientes.Contains(environment)) environment.registrarLog(new Log(DateTime.Now, true, user));
                else environment.registrarLog(new Log(DateTime.Now, false, user));
            }
            public void consultaLog()
            {
            int opcao;
                Console.WriteLine("1 - Logs de acessos autorizados" + "\n" +
                                  "2 - Logs de acessos não autorizados" + "\n" +
                                  "3 - Todos os Logs de acesso" + "\n" +
                                  "-> Opção: ", false);
                opcao = int.Parse(Console.ReadLine());
                foreach (Ambiente ambiente in cadastro.Ambientes)
                {
                    foreach (Log log in ambiente.Logs)
                    {
                        switch (opcao)
                        {
                            case 1:
                                if (log.TipoAcesso == true) Console.WriteLine(log.TipoAcesso + " | " + log.Usuario.Nome + " | " + log.DtAcesso);
                                Console.WriteLine("");
                                break;
                            case 2:
                                if (log.TipoAcesso == false) Console.WriteLine( log.TipoAcesso + " | " + log.Usuario.Nome + " | " + log.DtAcesso);
                                Console.WriteLine("");
                                break;
                            case 3:
                                Console.WriteLine(log.TipoAcesso + " | " + log.Usuario.Nome + " | " + log.DtAcesso);
                                Console.WriteLine("");
                                break;
                        }
                    }
                }
            }
        }
    }