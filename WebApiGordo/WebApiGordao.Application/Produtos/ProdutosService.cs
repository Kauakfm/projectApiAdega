using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiGordao.Application.Model;
using WebApiGordao.Repository;
using WebApiGordao.Repository.Models;

namespace WebApiGordao.Application.Produtos
{
    public class ProdutosService
    {
        private readonly GordaoEntities _gordo;

        public ProdutosService(GordaoEntities context)
        {
            _gordo = context;
        }


        public List<Produto> ObterProdutos()
        {
            try
            {
                var objProd = _gordo.tabProdutos.ToList();
                List<Produto> produto = new List<Produto>();
                foreach (var item in objProd)
                {
                    produto.Add(new Produto
                    {
                        numeroProduto = item.id,
                        nome = item.nomeProduto,
                        valor = item.valor,
                        ml = item.quantidadeMl,
                        tipo = item.tipoId,
                        Foto = item.Foto
                    });
                }
                return produto;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<string>> InserirFoto(List<FileUploadModel> files, int id)
        {
            if (files == null || files.Count == 0)
                throw new ArgumentException("Nenhum arquivo foi fornecido para upload.");

            var fotosSalvas = new List<string>();

            foreach (var file in files)
            {
                if (file.Data.Length > 0)
                {
                    file.FileName = id.ToString() + $".{file.FileName.Split(".")[1]}";
                    // Salvar a foto em um diretório (por exemplo, "Fotos") e obter o caminho completo do arquivo salvo
                    string filePath = "C:\\inetpub\\wwwroot\\images\\" + file.FileName;

                    // Verificar se o diretório "Fotos" existe e criar se não existir
                    if (!Directory.Exists("C:\\inetpub\\wwwroot\\images"))
                    {
                        Directory.CreateDirectory("C:\\inetpub\\wwwroot\\images");
                    }

                    // Salvar o arquivo no diretório
                    await File.WriteAllBytesAsync(filePath, file.Data);
                    var user = _gordo.tabProdutos.FirstOrDefault(x => x.id == id);
                    user.Foto = file.FileName;
                    _gordo.tabProdutos.Update(user);
                    _gordo.SaveChanges();


                    fotosSalvas.Add(filePath);
                }
            }

            return fotosSalvas;
        }

        public UsuarioResponse atualizarUsuario(UsuarioRequest request, int id)
        {
            try
            {
                UsuarioResponse response = new UsuarioResponse();
                var user = _gordo.Usuario.FirstOrDefault(y => y.id == id);
                if (user == null)
                {
                    response.mensagem = "Usuario não encontrado";
                    response.sucesso = false;
                    return response;
                }

                user.nome = request.Nome;
                user.telefone = request.Telefone;
                user.dataNascimento = request.dataNascimento;
                user.sexo = request.Sexo;
                user.cep = request.Cep;
                user.bairro = request.Bairro;
                user.cidade = request.Cidade;
                user.rua = request.Rua;
                user.numero = request.Numero;

                _gordo.Usuario.Update(user);
                _gordo.SaveChanges();

                response.mensagem = "Usuario atualizado com sucesso";
                response.sucesso = true;
                return response;
            }
            catch (Exception ex)
            {
                UsuarioResponse usuarioResponse = new UsuarioResponse();
                usuarioResponse.mensagem = ex.Message;
                usuarioResponse.sucesso = false;
                return usuarioResponse;
            }
        }
        public UsuarioResponse inserirUsuario(UsuarioRequest request)
        {
            try
            {
                UsuarioResponse response = new UsuarioResponse();
                var usuario = new tabUsuario()
                {
                    nome = request.Nome,
                    telefone = request.Telefone,
                    dataNascimento = request.dataNascimento,
                    sexo = request.Sexo,
                    cep = request.Cep,
                    cidade = request.Cidade,
                    bairro = request.Bairro,
                    rua = request.Rua,
                    numero = request.Numero,
                };
                if (request.Nome == null)
                {
                    response.mensagem = "Insira um nome";
                    response.sucesso = false;
                    return response;
                }

                if (request.Telefone == null)
                {
                    response.mensagem = "Insira um numero de telefone";
                    response.sucesso = false;
                    return response;
                }
                if (request.Sexo == null)
                {
                    response.mensagem = "Insira um sexo";
                    response.sucesso = false;
                    return response;
                }
                if (request.Cep == null)
                {
                    response.mensagem = "Insira um Cep";
                    response.sucesso = false;
                    return response;
                }
                if (request.Numero == null)
                {
                    response.mensagem = "Insira o numero da residencia";
                    response.sucesso = false;
                    return response;
                }
                _gordo.Usuario.Add(usuario);
                _gordo.SaveChanges();
                response.mensagem = "Usuario inserido com sucesso";
                response.sucesso = true;
                return response;

            }
            catch (Exception ex)
            {
                UsuarioResponse usuario = new UsuarioResponse();
                usuario.mensagem = "usurio não inserido";
                usuario.sucesso = false;
                return usuario;
            }
        }

        public UsuarioResponse editarProduto(ProdutoRequest request, int id)
        {

            try
            {
                UsuarioResponse response = new UsuarioResponse();
                var objprod = _gordo.tabProdutos.FirstOrDefault(c => c.id == id);
                if(objprod == null)                 
                {
                    response.mensagem = "Produto não identificado";
                    response.sucesso = false;
                    return response;
                }
                objprod.nomeProduto = request.nomeProduto;
                objprod.valor = request.valor;
                objprod.quantidadeMl = request.quantidadeMl;
                _gordo.tabProdutos.Update(objprod);
                _gordo.SaveChanges();
                response.mensagem = "Produto editado com sucesso";
                response.sucesso = true;
                return response;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public UsuarioResponse inserirProduto(ProdutoRequest request)
        {
            try
            {
                UsuarioResponse response = new UsuarioResponse();
                var prod = new tabProdutos()
                {
                    nomeProduto = request.nomeProduto,
                    quantidadeMl = request.quantidadeMl,
                    valor = request.valor,
                    tipoId = request.tipoId
                };
                if(request.nomeProduto == null)
                {
                    response.mensagem = "insira o nome de produto";
                    response.sucesso = false;
                    return response;
                }
                if(request.quantidadeMl == null)
                {
                    response.mensagem = "inisira um ml";
                    response.sucesso = false;
                    return response;
                }
                if(request.valor == null)
                {
                    response.mensagem = "insira um valor";
                    response.sucesso = false;
                    return response;
                }
                if(request.tipoId == null)
                {
                    response.mensagem = "insira o tipo de produto";
                    response.sucesso = false;
                    return response;
                }
                _gordo.tabProdutos.Add(prod);
                _gordo.SaveChanges();

                response.mensagem = "Produto inserido com sucesso";
                response.sucesso = true;
                return response;    
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Usuario> obterUsuarios() 
        {
            try
            {
                var objUser = _gordo.Usuario.ToList();
                List<Usuario> user = new List<Usuario>();
                foreach (var item in objUser)
                {
                    user.Add(new Usuario
                    {
                        Id = item.id,
                        Nome = item.nome,
                        Telefone = item.telefone,
                        DataNascimento = item.dataNascimento,
                        Sexo = item.sexo,
                        Cep = item.cep,
                        Cidade = item.cidade,
                        Rua = item.rua,
                        Bairro = item.bairro,
                        Numero = item.numero,
                    });
                }
                return user;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Fiado> obterFiado(int idCodigo)
        {
            try
            {
                var user = _gordo.Fiado.Where(c => c.idUsuario == idCodigo && c.dataLiquidacao == null).ToList();
                List<Fiado> fiado = new List<Fiado>();
                foreach(var item in user)
                {
                    fiado.Add(new Fiado
                    {
                        Id =item.id,
                        IdUsuario = item.idUsuario,
                        Competencia = item.competencia,
                        DataFiado = item.dataFiado,
                        Valor = item.valor,
                        DataLiquidacao = item.dataLiquidacao,
                        FormaPagamento = item.formaPagamento,
                        ValorPago = item.valorPago,
                        Observacao = item.observacao
                    });
                }
                return fiado;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
