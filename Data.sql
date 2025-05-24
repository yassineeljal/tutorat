PRAGMA foreign_keys = OFF;

DELETE FROM Meetings;
DELETE FROM Availabilities;
DELETE FROM Requests;
DELETE FROM Tutors;
DELETE FROM Teachers;
DELETE FROM Students;

INSERT INTO Students (Id, FirstName, LastName, Da) VALUES
  (1, 'Alice', 'Dupont', 1234),
  (2, 'Bob',   'Martin', 2345),
  (3, 'Chloé', 'Bernard',3456),
  (4, 'David', 'Moreau', 4567),
  (5, 'Emma',  'Lambert',5678);
INSERT INTO Teachers (Id, FirstName, LastName) VALUES
  (1, 'François', 'Petit'),
  (2, 'Isabelle','Robert'),
  (3, 'Jean',     'Lefevre'),
  (4, 'Marie',    'Durand'),
  (5, 'Nathalie', 'Mercier');

INSERT INTO Tutors (Id, Da, FirstName, LastName) VALUES
  (1, 1001, 'Paul',  'Michel'),
  (2, 1002, 'Sophie','Martin'),
  (3, 1003, 'Luc',   'Garcia'),
  (4, 1004, 'Anne',  'Rousseau'),
  (5, 1005, 'Marc',  'Blanc');

INSERT INTO Requests (Id, Subject, Category, Note, StudentId) VALUES
  (1,  'Mathématiques', 'Algèbre',      8, 1),
  (2,  'Physique',      'Mécanique',     6, 2),
  (3,  'Chimie',        'Organique',     9, 3),
  (4,  'Anglais',       'Grammaire',     7, 4),
  (5,  'Histoire',      'Médiévale',    10, 5),
  (6,  'Biologie',      'Cellulaire',    5, 1),
  (7,  'Informatique',  'Programmation', 9, 2),
  (8,  'Français',      'Littérature',   8, 3),
  (9,  'Philosophie',   'Éthique',       7, 4),
  (10, 'SVT',           'Géologie',      6, 5);

INSERT INTO Availabilities (Id, DayOfWeek, StartTime, EndTime, StudentId, TutorId) VALUES
  (1, 1, '09:00:00', '11:00:00', 1, 1),
  (2, 3, '14:00:00', '16:00:00', 1, 2),
  (3, 5, '10:00:00', '12:00:00', 2, 1),
  (4, 2, '08:30:00', '10:30:00', 3, 3),
  (5, 4, '13:00:00', '15:00:00', 4, 4),
  (6, 6, '09:00:00', '11:00:00', 5, 5),
  (7, 0, '15:00:00', '17:00:00', 2, 2),
  (8, 2, '09:00:00', '11:00:00', 3, 4),
  (9, 4, '10:00:00', '12:00:00', 4, 5),
  (10,1, '14:00:00', '16:00:00', 5, 3);

INSERT INTO Meetings (Id, Name, Description, DateMeeting, TutorId, StudentId) VALUES
  (1,  'Session Maths 1',     'Révision algèbre linéaire',          '2025-05-20 10:00:00', 1, 1),
  (2,  'Session Physique',    'Étude de la dynamique',              '2025-05-22 15:00:00', 2, 2),
  (3,  'Session Chimie',      'Pratique réactions organiques',      '2025-05-25 11:00:00', 3, 3),
  (4,  'Session Anglais',     'Exercices grammaire avancée',        '2025-06-01 14:00:00', 4, 4),
  (5,  'Session Histoire',    'Analyse historique médiévale',       '2025-06-03 09:00:00', 5, 5),
  (6,  'Session Info C#',     'Introduction à C# et EF Core',       '2025-06-05 16:00:00', 2, 2),
  (7,  'Session Français',    'Lecture et commentaire de texte',    '2025-06-07 10:00:00', 3, 3),
  (8,  'Session Biologie',    'Observation cellules végétales',     '2025-06-10 13:00:00', 1, 1),
  (9,  'Session Philosophie', 'Discussion sur l''éthique',          '2025-06-12 11:00:00', 4, 4),
  (10, 'Session SVT',         'Géologie du sol',                    '2025-06-15 15:00:00', 5, 5);

PRAGMA foreign_keys = ON;
