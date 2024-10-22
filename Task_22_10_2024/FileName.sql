CREATE TABLE Utente (
UtenteID INT PRIMARY KEY IDENTITY (1,1),
Nome VARCHAR(250) NOT NULL,
Cognome VARCHAR(250) NOT NULL,
Email VARCHAR (250) NOT NULL,
Codice_Utente VARCHAR (36) NOT NULL DEFAULT NEWID(),

);

CREATE TABLE Corso(
CorsoID INT PRIMARY KEY IDENTITY (1,1),
Nome VARCHAR(250) NOT NULL,
Codice_Corso VARCHAR (36) NOT NULL DEFAULT NEWID(),
Descrizione TEXT,
Prezzo DECIMAL (5,2) CHECK (Prezzo>0) NOT NULL, 
MaxPartecipanti INT CHECK (MaxPartecipanti > 0 AND MaxPartecipanti <= 20) NOT NULL,
);
CREATE TABLE Iscrizione (
IscrizioneID INT PRIMARY KEY IDENTITY (1,1),
Data_Iscrizione DATE NOT NULL,
UtenteRIF INT NOT NULL,
CorsoRIF INT NOT NULL,
FOREIGN KEY (UtenteRIF)REFERENCES Utente(UtenteID) ON DELETE CASCADE,
FOREIGN KEY (CorsoRIF)REFERENCES Corso(CorsoID) ON DELETE CASCADE,
);

INSERT INTO Utente (Nome, Cognome, Email)
VALUES 
('Mario', 'Rossi', 'mario.rossi@example.com'),
('Giulia', 'Verdi', 'giulia.verdi@example.com'),
('Luigi', 'Bianchi', 'luigi.bianchi@example.com'),
('Sara', 'Neri', 'sara.neri@example.com'),
('Elena', 'Gialli', 'elena.gialli@example.com');

-- Popolamento della tabella Corso
INSERT INTO Corso (Nome, Descrizione, Prezzo, MaxPartecipanti)
VALUES 
('Corso di Programmazione', 'Introduzione alla programmazione con C#', 150.00, 20),
('Corso di Web Design', 'Corso avanzato di Web Design con HTML e CSS', 200.00, 15),
('Corso di Database', 'Corso base di gestione database con SQL', 120.00, 18),
('Corso di Data Science', 'Introduzione alla Data Science e Machine Learning', 250.00, 20),
('Corso di Sicurezza Informatica', 'Corso base di sicurezza informatica', 180.00, 10);

-- Popolamento della tabella Iscrizione
INSERT INTO Iscrizione (Data_Iscrizione, UtenteRIF, CorsoRIF)
VALUES 
('2024-01-15', 1, 1), -- Mario Rossi si iscrive al Corso di Programmazione
('2024-01-16', 2, 2), -- Giulia Verdi si iscrive al Corso di Web Design
('2024-01-17', 3, 3), -- Luigi Bianchi si iscrive al Corso di Database
('2024-01-18', 4, 4), -- Sara Neri si iscrive al Corso di Data Science
('2024-01-19', 5, 5), -- Elena Gialli si iscrive al Corso di Sicurezza Informatica
('2024-01-20', 1, 2), -- Mario Rossi si iscrive anche al Corso di Web Design
('2024-01-21', 2, 3); -- Giulia Verdi si iscrive al Corso di Database

-- Query di controllo per verificare i dati inseriti

-- Verifica utenti inseriti
SELECT * FROM Utente;

-- Verifica corsi inseriti
SELECT * FROM Corso;

-- Verifica iscrizioni inserite
SELECT * FROM Iscrizione;