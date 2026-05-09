# AWS S3 DotNet WebAPI

Uma aplicação ASP.NET Core Web API para gerenciar buckets e arquivos no Amazon S3, baseada no tutorial [Working with AWS S3 using ASP.NET Core](https://codewithmukesh.com/blog/working-with-aws-s3-using-aspnet-core/) com modificações e ajustes para compatibilidade com versões mais novas.

## 📋 Sobre o Projeto

Este projeto implementa uma API RESTful que permite operações completas com o Amazon S3, incluindo gerenciamento de buckets e upload/download de arquivos. O código foi modernizado para trabalhar com as versões atuais do .NET e AWS SDK.

## 🛠️ Stack Tecnológico

- **Framework**: ASP.NET Core
- **Linguagem**: C#
- **AWS SDK**: AWSSDK.S3
- **Padrão**: REST API

## 📦 Dependências

- .NET 6.0 ou superior
- AWSSDK.S3 NuGet Package
- Credenciais AWS configuradas

## 🚀 Pré-requisitos

- .NET SDK instalado
- Conta AWS ativa
- Credenciais AWS configuradas (Access Key ID e Secret Access Key)
- AWS CLI configurado ou variáveis de ambiente com as credenciais

## ⚙️ Setup

1. **Clone o repositório**
```bash
git clone https://github.com/GuilhermeYasuda/aws-s3-dotnet-webapi.git
cd aws-s3-dotnet-webapi
```

2. **Configure as credenciais AWS**
```bash
# Opção 1: Variáveis de ambiente
export AWS_ACCESS_KEY_ID=sua_access_key
export AWS_SECRET_ACCESS_KEY=sua_secret_key
export AWS_DEFAULT_REGION=us-east-1

# Opção 2: Arquivo appsettings.json
```

3. **Restaure as dependências**
```bash
dotnet restore
```

4. **Execute a aplicação**
```bash
dotnet run
```

A API estará disponível em `https://localhost:5001`

## 📚 Funcionalidades da API

### 🪣 Gerenciamento de Buckets

#### Criar Bucket
```http
POST /api/buckets/create?bucketName=meu-bucket
```
- Cria um novo bucket no S3
- Retorna erro se o bucket já existe

#### Listar Todos os Buckets
```http
GET /api/buckets/get-all
```
- Retorna lista de todos os buckets da conta AWS

#### Deletar Bucket
```http
DELETE /api/buckets/delete?bucketName=meu-bucket
```
- Remove um bucket do S3
- Retorna erro se o bucket não existe

### 📁 Gerenciamento de Arquivos

#### Upload de Arquivo
```http
POST /api/files/upload
```
**Parâmetros:**
- `file` (FormFile): Arquivo a ser enviado
- `bucketName` (string): Nome do bucket destino
- `prefix` (string, opcional): Caminho/pasta dentro do bucket

**Exemplo:**
```bash
curl -X POST "https://localhost:5001/api/files/upload" \
  -F "file=@meu-arquivo.pdf" \
  -F "bucketName=meu-bucket" \
  -F "prefix=documentos"
```

#### Listar Todos os Arquivos
```http
GET /api/files/get-all?bucketName=meu-bucket&prefix=documentos
```
- Retorna lista de arquivos no bucket (com URLs pré-assinadas)
- `prefix` (opcional): Filtra por caminho específico
- URLs válidas por 1 minuto

#### Obter Arquivo por Chave
```http
GET /api/files/get-by-key?bucketName=meu-bucket&key=documentos/arquivo.pdf
```
- Retorna o arquivo para download

#### Deletar Arquivo
```http
DELETE /api/files/delete-by-key?bucketName=meu-bucket&key=documentos/arquivo.pdf
```
- Remove um arquivo específico do bucket

## 🔗 Referências

- [Tutorial Original - Code with Mukesh](https://codewithmukesh.com/blog/working-with-aws-s3-using-aspnet-core/)
- [AWS SDK for .NET Documentation](https://docs.aws.amazon.com/sdk-for-net/)
- [Amazon S3 API Reference](https://docs.aws.amazon.com/AmazonS3/latest/API/Welcome.html)
- [ASP.NET Core Documentation](https://docs.microsoft.com/en-us/aspnet/core/)

## 📝 Modificações e Ajustes Realizados

Este projeto incorpora melhorias em relação ao tutorial original para compatibilidade com versões mais recentes:

- ✅ Atualização da sintaxe C# para versões modernas
- ✅ Compatibilidade com .NET 6.0+
- ✅ Uso de async/await patterns atualizados
- ✅ APIs do AWS SDK modernizadas
- ✅ Melhor tratamento de exceções
- ✅ Estrutura de projeto melhorada

## 💡 Exemplos de Uso

### Exemplo 1: Criar bucket e fazer upload
```bash
# Criar bucket
curl -X POST "https://localhost:5001/api/buckets/create?bucketName=meu-bucket"

# Upload de arquivo
curl -X POST "https://localhost:5001/api/files/upload" \
  -F "file=@documento.pdf" \
  -F "bucketName=meu-bucket"
```

### Exemplo 2: Listar e baixar arquivos
```bash
# Listar arquivos
curl -X GET "https://localhost:5001/api/files/get-all?bucketName=meu-bucket"

# Obter arquivo
curl -X GET "https://localhost:5001/api/files/get-by-key?bucketName=meu-bucket&key=documento.pdf" -O
```

## 🤝 Contribuições

Sinta-se livre para fazer fork, abrir issues e enviar pull requests!

## 📄 Licença

Este projeto é baseado no trabalho de [Mukesh Murugan](https://codewithmukesh.com/) com modificações adicionais.

---

**Desenvolvido por:** GuilhermeYasuda
