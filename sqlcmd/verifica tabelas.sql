use BackOffice
/****** Script do comando SelectTopNRows de SSMS  ******/
SELECT TOP (1000) [Id]
      ,[DataDaCompra]
      ,[Status]
      ,[ClienteId]
      ,[CreateDate]
      ,[UpdateDate]
      ,[RequestId]
  FROM [BackOffice].[dbo].[Pedidos]

  select * from PedidoItens
  select * from Pagamentos 


  /*
  
  delete from PedidoItens
  delete from Pagamentos 
  delete FROM [BackOffice].[dbo].[Pedidos]

  */