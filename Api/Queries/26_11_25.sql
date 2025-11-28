select * from Presenze

select * from Lezioni

SELECT * FROM Corsi

INSERT INTO Corsi (NomeCorso, Descrizione, Crediti)
VALUES ('C#', 'Programmazone in c#', 30),
	   ('SQL', 'BigData', 10)

select * from Docenti

INSERT INTO Docenti (Nome, Cognome, Email, Telefono)
VALUES ('Norberto', 'Tessi', 'n.tessi@gmail.com', '12354687')

select * from Aule

select * from  Lezioni

INSERT INTO Lezioni 
	(CorsoId, DocenteId, AulaId, Inizio, Fine, Argomento)
VALUES
	(1, 2, 2, '2023-10-08', '2023-12-15', 'Sviluppo software e applicazioni android')


SELECT
	l.LezioneId,
	d.Nome AS 'Nome del docente',
	d.Email AS 'Indirizzo mail del docente',
	l.Argomento AS 'Argomento del corso',
	c.NomeCorso AS 'Nome del corso',
	c.Descrizione AS 'Descrizione del corso'
FROM Lezioni AS l
INNER JOIN Docenti AS d ON l.DocenteId = d.DocenteId
INNER JOIN Corsi AS c ON c.CorsoId = l.CorsoId

SELECT * FROM Valutazioni

INSERT INTO Valutazioni
	(CorsoId, DocenteId, Titolo, Tipo, PunteggioMassimo, Data)
VALUES 
	(1, 3, 'Sviluppo App', 'programmazione in c#', 30, '2025-11-27')
