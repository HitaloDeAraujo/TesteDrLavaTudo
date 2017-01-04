# TesteDrLavaTudo
Teste feito por Hitalo Filipe Silva de Araujo


1- Podemos criar uma terceira entidade nomeada como "ServicoPorOS", que ira mapear as relações de um ou mais serviços para cada Ordem de Serviço. Como o atributo ID Serviço da entidade Ordem de Serviço não será mais útil, ela deverá ser excluida.

Como alternativa mais custosa no que se diz respeito a inserção de dados, poderiamos excluir o atributo "ID Serviço" de Ordem de Serviço e criar uma chave estrangeira de nome "ID Ordem de Serviço" em "Serviços" para relacionar cada serviço a alguma ordem de serviço, entretanto nesse caso não seria possivel manter uma base de serviços pré cadastrados. Tem-se como pressuposto que a primeira alternativa seria melhor, ou seja, a criação da entidade "ServicoPorOS".

2- Para que seja possível uma mesma ordem de serviço ter serviços para endereços diferentes basta acrescentar os atributos relacionados a endereço na entidade "ServicoPorOS" mancionada no item anterior. Esses atributos podem ser Numero, Rua, Bairro, Cidade, Estado e País.

3- 

a)

SELECT Nome, COUNT(OS.Cliente) AS Quant
FROM Cliente C, OrdemServico OS
WHERE C.IdCliente = OS.Cliente
GROUP BY C.Nome
ORDER BY Quant DESC;

b)

SELECT OS.IdOS, COUNT(*) AS Quant
FROM OrdemServico OS RIGHT JOIN ServicoPorOS SOS ON OS.IdOS = SOS.IdOS
GROUP BY OS.IdOS
HAVING COUNT(*) > 1
ORDER BY Quant DESC;

c)

SELECT TOP 3 S.IdServico, COUNT(*) AS Quant
FROM ServicoPorOS SOS LEFT JOIN Servico S ON SOS.IdServico = S.IdServico
GROUP BY S.IdServico
ORDER BY Quant DESC, S.IdServico;

d)

UPDATE Servico
SET ValorFinal = ValorFinal * 1.12;

e)

DELETE FROM ServicoPorOS
WHERE ServicoPorOS.IdOS = (SELECT MAX(OrdemServico.IdOS) FROM OrdemServico);

DELETE FROM OrdemServico
WHERE IdOS = (SELECT MAX(IdOS) FROM OrdemServico);

f)

INSERT INTO Cliente VALUES ('12834', 'Hitalo', 'hitalofilipe.hitalofilipe@gmail.com', '1994/12/29', '31998564477', '3198564477');
