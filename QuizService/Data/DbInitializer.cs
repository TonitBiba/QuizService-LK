namespace QuizService.Data {
    public static class DbInitializer {
        public static void Initialize(QuizContext context) {

            if (context.Quiz.Any())
            {
                return; //Db has been seeded
            }

            QuestionType[] questionTypes = new[] {
                new QuestionType{ ID = 1, Name_SQ = "Saktë/Gabim", Name_EN ="True/False", Name_NO = "Sant/Falsk" },
                new QuestionType{ ID = 2, Name_SQ = "Një përgjigje e saktë", Name_EN ="Select single answer", Name_NO = "Velg enkeltsvar" },
                new QuestionType{ ID = 3, Name_SQ = "Shumë përgjigje të sakta", Name_EN ="Select multiple answers", Name_NO = "Velg flere svar" }
            };

            context.QuestionType.AddRange(questionTypes);

            context.SaveChanges();

            Quiz newQuiz = new()
            {
                Name_SQ = "Anatomia e njeriut",
                Name_EN = "Anatomy of the human body",
                Name_NO = "Menneskekroppens anatomi",
                Image = "/media/quizzes/Anatomy_share.jpg",
                Description_SQ = "Quizi për anatominë e trupit të njeriut",
                Description_EN = "Quiz about the anatomy of the human body",
                Description_NO = "Quiz om menneskekroppens anatomi",
                Questions = new[]
                {
                    new Question { Nr = 1, Name_SQ = "Trupi i njeriut ka 206 kocka?", Name_EN = "The human body has 206 bones?", Name_NO = "Menneskekroppen har 206 bein?", QuestionTypeID = 1,
                        Options = new[]{ 
                            new Option { Name_SQ = "Saktë", Name_EN = "True", Name_NO = "Sant", IsCorrect = true}, 
                            new Option { Name_SQ = "Gabim", Name_EN = "False", Name_NO = "Falsk", IsCorrect = false}, 
                        }
                    },
                    new Question { Nr = 2, Name_SQ = "Si quhet sistemi në trupin e njeriut që transporton gjakun?", Name_EN = "What is the name of the system in the human body that transports blood?", Name_NO = "Hva heter systemet i menneskekroppen som transporterer blod?", QuestionTypeID = 2,
                        Options = new[]{
                            new Option { Name_SQ = "Kardiovaskulare", Name_EN = "Cardiovascular", Name_NO = "Kardiovaskulær", IsCorrect = true},
                            new Option { Name_SQ = "Limfatike", Name_EN = "Lymphatic", Name_NO = "Lymfatisk", IsCorrect = false},
                            new Option { Name_SQ = "Respiratore", Name_EN = "Respiratory", Name_NO = "Luftveiene", IsCorrect = false},
                            new Option { Name_SQ = "Digjestiv", Name_EN = "Digestive", Name_NO = "Fordøyelseskanal", IsCorrect = false},
                        }
                    },
                    new Question { Nr = 3, Name_SQ = "Cili hormon, i prodhuar në pankreas, rregullon nivelet e sheqerit në gjak?", Name_EN = "What hormone, produced in the pancreas, regulates blood sugar levels?", Name_NO = "Hvilket hormon, produsert i bukspyttkjertelen, regulerer blodsukkernivået?", QuestionTypeID = 2,
                        Options = new[]{
                            new Option { Name_SQ = "Prolaktina", Name_EN = "Prolactin", Name_NO = "Prolaktin", IsCorrect = false},
                            new Option { Name_SQ = "Oksitocina", Name_EN = "Oxytocin", Name_NO = "Oksytocin", IsCorrect = false},
                            new Option { Name_SQ = "Adrenalina", Name_EN = "Epinephrine", Name_NO = "Adrenalin", IsCorrect = false},
                            new Option { Name_SQ = "Insulinë", Name_EN = "Insulin", Name_NO = "Insulin", IsCorrect = true},
                        }
                    },
                    new Question { Nr = 4, Name_SQ = "Cila është gjëndra më e madhe në trupin e njeriut?", Name_EN = "Which is the largest gland in the human body?", Name_NO = "Hvilken er den største kjertelen i menneskekroppen?", QuestionTypeID = 2,
                        Options = new[]{
                            new Option { Name_SQ = "Mëlçisë", Name_EN = "Liver", Name_NO = "Lever", IsCorrect = true},
                            new Option { Name_SQ = "Gjëndër pineale", Name_EN = "Pineal gland", Name_NO = "Pinealkjertel", IsCorrect = false},
                            new Option { Name_SQ = "Pankreasi", Name_EN = "Pancreas", Name_NO = "Bukspyttkjertelen", IsCorrect = false},
                            new Option { Name_SQ = "Tiroide", Name_EN = "Thyroid", Name_NO = "Skjoldbruskkjertelen", IsCorrect = false},
                        }
                    },
                    new Question { Nr = 5, Name_SQ = "Cila pjesë e kafkës përmban trurin?", Name_EN = "Which part of the skull contains the brain?", Name_NO = "Hvilken del av hodeskallen inneholder hjernen?", QuestionTypeID = 2,
                        Options = new[]{
                            new Option { Name_SQ = "Mandibula", Name_EN = "Mandible", Name_NO = "Mandible", IsCorrect = false},
                            new Option { Name_SQ = "Kocka okupitale", Name_EN = "Occipital bone", Name_NO = "Occipital bein", IsCorrect = false},
                            new Option { Name_SQ = "Kraniumi", Name_EN = "Cranium", Name_NO = "Kranium", IsCorrect = true},
                            new Option { Name_SQ = "Maxilla", Name_EN = "Maxilla", Name_NO = "Maksila", IsCorrect = false},
                        }
                    },
                    new Question { Nr = 6, Name_SQ = "Cili prej tyre është muskuli kryesor i frymëmarrjes?", Name_EN = "Which of these is the principal muscle of respiration?", Name_NO = "Hvilken av disse er den viktigste respirasjonsmuskelen?", QuestionTypeID = 2,
                        Options = new[]{
                            new Option { Name_SQ = "Flagjela", Name_EN = "Flagella", Name_NO = "Flagella", IsCorrect = false},
                            new Option { Name_SQ = "Cilia", Name_EN = "Cilia", Name_NO = "Cilia", IsCorrect = false},
                            new Option { Name_SQ = "Muskuli kardiak", Name_EN = "Cardiac muscle", Name_NO = "Hjertemuskelen", IsCorrect = false},
                            new Option { Name_SQ = "Diafragma", Name_EN = "Diaphragm", Name_NO = "Diafragma", IsCorrect = true},
                        }
                    },
                    new Question { Nr = 7, Name_SQ = "Njeriu i rritur ka 36 dhëmbë?", Name_EN = "An adult man has 36 teeth?", Name_NO = "En voksen mann har 36 tenner?", QuestionTypeID = 1,
                        Options = new[]{
                            new Option { Name_SQ = "Saktë", Name_EN = "True", Name_NO = "Sant", IsCorrect = false},
                            new Option { Name_SQ = "Gabim", Name_EN = "False", Name_NO = "Falsk", IsCorrect = true},
                        }
                    },
                    new Question { Nr = 8, Name_SQ = "Kocka më e gjatë në trupin e njeriut është Femuri?", Name_EN = "The longest bone in the human body is the Femur?", Name_NO = "Det lengste beinet i menneskekroppen er lårbenet?", QuestionTypeID = 1,
                        Options = new[]{
                            new Option { Name_SQ = "Saktë", Name_EN = "True", Name_NO = "Sant", IsCorrect = true},
                            new Option { Name_SQ = "Gabim", Name_EN = "False", Name_NO = "Falsk", IsCorrect = false},
                        }
                    },
                    new Question { Nr = 9, Name_SQ = "Cilat janë llojet e vertebrave në trupin e njeriut?", Name_EN = "What are the types of vertebrae in the human body?", Name_NO = "Hva er typene ryggvirvler i menneskekroppen?", QuestionTypeID = 3,
                        Options = new[]{
                            new Option { Name_SQ = "Rruazat e qafës së mitrës", Name_EN = "Cervical vertebrae", Name_NO = "Nakkevirvler", IsCorrect = true },
                            new Option { Name_SQ = "Rruazat e mesit", Name_EN = "Lumbar vertebrae", Name_NO = "Korsryggvirvler", IsCorrect = true },
                            new Option { Name_SQ = "Sacrum", Name_EN = "Sacrum", Name_NO = "Sacrum", IsCorrect = true },
                            new Option { Name_SQ = "Sternum", Name_EN = "Sternum", Name_NO = "Brystbein", IsCorrect = false },
                        }
                    },
                    new Question { Nr = 10, Name_SQ = "Cilat nga opsionet e mëposhtme janë arterie?", Name_EN = "Which of the following options are arteries?", Name_NO = "Hvilke av følgende alternativer er arterier?", QuestionTypeID = 3,
                        Options = new[]{
                            new Option { Name_SQ = "Aorta", Name_EN = "Aorta", Name_NO = "Aorta", IsCorrect = true },
                            new Option { Name_SQ = "Vena e vogël kardiake", Name_EN = "Small cardiac vein", Name_NO = "Liten hjertevene", IsCorrect = false },
                            new Option { Name_SQ = "Vene e madhe kardiake", Name_EN = "Great cardiac vein", Name_NO = "Flott hjertevene", IsCorrect = false },
                            new Option { Name_SQ = "Arteriet koronare", Name_EN = "Coronary arteries", Name_NO = "Koronararterier", IsCorrect = true },
                        }
                    }
                }
            };

            context.Quiz.Add(newQuiz);

            Quiz newQuizProgramming = new()
            {
                Name_SQ = "SQL Quiz",
                Name_EN = "SQL Quiz",
                Name_NO = "SQL Quiz",
                Image = "/media/quizzes/sql.png",
                Description_SQ = "Në këtë SQL Quiz, ne do të përpiqemi të testojmë njohuritë tona për konceptet SQL.",
                Description_EN = "In this SQL Quiz, we will try to test our knowledge of the SQL Concepts.",
                Description_NO = "I denne SQL-quizen vil vi prøve å teste kunnskapen vår om SQL-konseptene.",
                Questions = new[]
                {
                    new Question { Nr = 1, Name_SQ = "Çfarë do të thotë SQL?", Name_EN = "What does SQL stand for?", Name_NO = "Hva står SQL for?", QuestionTypeID = 2,
                        Options = new[]{
                            new Option { Name_SQ = "Strong Question Language", Name_EN = "Strong Question Language", Name_NO = "Strong Question Language", IsCorrect = false},
                            new Option { Name_SQ = "Structured Query Language", Name_EN = "Structured Query Language", Name_NO = "Structured Query Language", IsCorrect = true},
                            new Option { Name_SQ = "Structured Question Language", Name_EN = "Structured Question Language", Name_NO = "Structured Question Language", IsCorrect = false},
                        }
                    },
                    new Question { Nr = 2, Name_SQ = "Cila deklaratë SQL përdoret për të përditësuar të dhënat në një bazë të dhënash?", Name_EN = "Which SQL statement is used to update data in a database?", Name_NO = "Hvilken SQL-setning brukes til å oppdatere data i en database?", QuestionTypeID = 2,
                        Options = new[]{
                            new Option { Name_SQ = "Update", Name_EN = "Update", Name_NO = "Update", IsCorrect = true},
                            new Option { Name_SQ = "Save", Name_EN = "Save", Name_NO = "Save", IsCorrect = false},
                            new Option { Name_SQ = "Copy", Name_EN = "Copy", Name_NO = "Copy", IsCorrect = false},
                            new Option { Name_SQ = "Save as", Name_EN = "Save as", Name_NO = "Save as", IsCorrect = false},
                        }
                    },
                    new Question { Nr = 3, Name_SQ = "Me SQL, si i zgjidhni të gjitha kolonat nga një tabelë me emrin 'Persons'?", Name_EN = "With SQL, how do you select all the columns from a table named 'Persons'?", Name_NO = "Med SQL, hvordan velger du alle kolonnene fra en tabell som heter 'Personer'?", QuestionTypeID = 2,
                        Options = new[]{
                            new Option { Name_SQ = "SELECT Persons", Name_EN = "SELECT Persons", Name_NO = "SELECT Persons", IsCorrect = false},
                            new Option { Name_SQ = "SELECT * FROM Persons", Name_EN = "SELECT * FROM Persons", Name_NO = "SELECT * FROM Persons", IsCorrect = true},
                            new Option { Name_SQ = "SELECT [all] FROM Persons", Name_EN = "SELECT [all] FROM Persons", Name_NO = "SELECT [all] FROM Persons", IsCorrect = false},
                            new Option { Name_SQ = "SELECT *.Persons", Name_EN = "SELECT *.Persons", Name_NO = "SELECT *.Persons", IsCorrect = false},
                        }
                    },
                    new Question { Nr = 4, Name_SQ = "", Name_EN = "With SQL, how do you select all the records from a table named 'Persons' where the value of the column 'FirstName' starts with an 'a'?", Name_NO = "", QuestionTypeID = 2,
                        Options = new[]{
                            new Option { Name_SQ = "SELECT * FROM Persons WHERE FirstName LIKE '%a'", Name_EN = "SELECT * FROM Persons WHERE FirstName LIKE '%a'", Name_NO = "SELECT * FROM Persons WHERE FirstName LIKE '%a'", IsCorrect = true},
                            new Option { Name_SQ = "SELECT * FROM Persons WHERE FirstName='%a%'", Name_EN = "SELECT * FROM Persons WHERE FirstName='%a%'", Name_NO = "SELECT * FROM Persons WHERE FirstName='%a%'", IsCorrect = false},
                            new Option { Name_SQ = "SELECT * FROM Persons WHERE FirstName='a'", Name_EN = "SELECT * FROM Persons WHERE FirstName='a'", Name_NO = "SELECT * FROM Persons WHERE FirstName='a'", IsCorrect = false},
                            new Option { Name_SQ = "SELECT * FROM Persons WHERE FirstName LIKE 'a%'", Name_EN = "SELECT * FROM Persons WHERE FirstName LIKE 'a%'", Name_NO = "SELECT * FROM Persons WHERE FirstName LIKE 'a%'", IsCorrect = false},
                        }
                    },
                    new Question { Nr = 5, Name_SQ = "", Name_EN = "Which of the following are keys in SQL?", Name_NO = "", QuestionTypeID = 3,
                        Options = new[]{
                            new Option { Name_SQ = "Primary Key", Name_EN = "Primary Key", Name_NO = "Primary Key", IsCorrect = true},
                            new Option { Name_SQ = "Foreign Key", Name_EN = "Foreign Key", Name_NO = "Foreign Key", IsCorrect = true},
                            new Option { Name_SQ = "Unique Key", Name_EN = "Unique Key", Name_NO = "Unique Key", IsCorrect = true},
                            new Option { Name_SQ = "Implicit Key", Name_EN = "Implicit Key", Name_NO = "Implicit Key", IsCorrect = false},
                        }
                    },
                    new Question { Nr = 6, Name_SQ = "Cilat nga këto janë llojet e transaksioneve në SQL?", Name_EN = "Which of the following are type of Transactions in SQL?", Name_NO = "Hvilke av følgende er typene transaksjoner i SQL?", QuestionTypeID = 3,
                        Options = new[]{
                            new Option { Name_SQ = "Modeli i transaksionit", Name_EN = "Model transaction", Name_NO = "Modelltransaksjon", IsCorrect = false},
                            new Option { Name_SQ = "Transaksioni i nënkuptuar", Name_EN = "Implicit Transaction", Name_NO = "Implisitt transaksjon", IsCorrect = true},
                            new Option { Name_SQ = "Transaksione të avancuara", Name_EN = "Advanced transactions", Name_NO = "Avanserte transaksjoner", IsCorrect = false},
                            new Option { Name_SQ = "Transaksion i qartë", Name_EN = "Explicit Transaction", Name_NO = "Eksplisitt transaksjon", IsCorrect = true},
                        }
                    },
                    new Question { Nr = 7, Name_SQ = "Operatori OR shfaq një rekord nëse NDONJË kusht i listuar është i vërtetë. Operatori AND shfaq një rekord nëse TË GJITHA kushtet e listuara janë të vërteta", Name_EN = "The OR operator displays a record if ANY conditions listed are true. The AND operator displays a record if ALL of the conditions listed are true", Name_NO = "ELLER-operatøren viser en post hvis NOEN vilkår som er oppført er sanne. OG-operatoren viser en post hvis ALLE betingelsene som er oppført er sanne", QuestionTypeID = 1,
                        Options = new[]{
                            new Option { Name_SQ = "Saktë", Name_EN = "True", Name_NO = "Sant", IsCorrect = true},
                            new Option { Name_SQ = "Gabim", Name_EN = "False", Name_NO = "Falsk", IsCorrect = false},
                        }
                    },
                    new Question { Nr = 8, Name_SQ = "Cili deklaratë SQL përdoret për të kthyer vetëm vlera të ndryshme?", Name_EN = "Which SQL statement is used to return only different values?", Name_NO = "Hvilken SQL-setning brukes til å returnere bare forskjellige verdier?", QuestionTypeID = 2,
                        Options = new[]{
                            new Option { Name_SQ = "SELECT UNIQUE", Name_EN = "SELECT UNIQUE", Name_NO = "SELECT UNIQUE", IsCorrect = false},
                            new Option { Name_SQ = "SELECT DISTINCT", Name_EN = "SELECT DISTINCT", Name_NO = "SELECT DISTINCT", IsCorrect = true},
                            new Option { Name_SQ = "SELECT DIFFERENT", Name_EN = "SELECT DIFFERENT", Name_NO = "SELECT DIFFERENT", IsCorrect = false},
                        }
                    },
                    new Question { Nr = 9, Name_SQ = "Me SQL, si mund ta ktheni numrin e regjistrimeve në tabelën 'Personat'?", Name_EN = "With SQL, how can you return the number of records in the 'Persons' table?", Name_NO = "Hvordan kan du returnere antall poster i 'Personer'-tabellen med SQL?", QuestionTypeID = 2,
                        Options = new[]{
                            new Option { Name_SQ = "SELECT COUNT(*) FROM Persons", Name_EN = "SELECT COUNT(*) FROM Persons", Name_NO = "SELECT COUNT(*) FROM Persons", IsCorrect = true },
                            new Option { Name_SQ = "", Name_EN = "SELECT LEN(*) FROM Persons", Name_NO = "", IsCorrect = false },
                            new Option { Name_SQ = "", Name_EN = "SELECT COLUMNS(*) FROM Persons", Name_NO = "", IsCorrect = false },
                            new Option { Name_SQ = "", Name_EN = "SELECT NO(*) FROM Persons", Name_NO = "", IsCorrect = false },
                        }
                    },
                    new Question { Nr = 10, Name_SQ = "", Name_EN = "Which of the folliwing are type of joins in SQL?", Name_NO = "", QuestionTypeID = 3,
                        Options = new[]{
                            new Option { Name_SQ = "Aorta", Name_EN = "Aorta", Name_NO = "INNER LEFT JOIN", IsCorrect = false },
                            new Option { Name_SQ = "Vena e vogël kardiake", Name_EN = "FULL OUTER JOIN", Name_NO = "Liten hjertevene", IsCorrect = true },
                            new Option { Name_SQ = "Vene e madhe kardiake", Name_EN = "RIGHT OUTER JOIN", Name_NO = "Flott hjertevene", IsCorrect = true },
                            new Option { Name_SQ = "Arteriet koronare", Name_EN = "JOIN", Name_NO = "Koronararterier", IsCorrect = true },
                        }
                    },
                     new Question { Nr = 11, Name_SQ = "", Name_EN = "The NOT NULL constraint enforces a column to not accept NULL values.", Name_NO = "", QuestionTypeID = 1,
                        Options = new[]{
                            new Option { Name_SQ = "Saktë", Name_EN = "True", Name_NO = "Sant", IsCorrect = true},
                            new Option { Name_SQ = "Gabim", Name_EN = "False", Name_NO = "Falsk", IsCorrect = false},
                        }
                    },
                      new Question { Nr = 12, Name_SQ = "", Name_EN = "Which SQL statement is used to create a database table called 'Customers'?", Name_NO = "", QuestionTypeID = 2,
                        Options = new[]{
                            new Option { Name_SQ = "", Name_EN = "CREATE DATABASE TAB Customers", Name_NO = "", IsCorrect = false },
                            new Option { Name_SQ = "", Name_EN = "CREATE TABLE Customers", Name_NO = "", IsCorrect = true },
                            new Option { Name_SQ = "", Name_EN = "CREATE DB Customers", Name_NO = "", IsCorrect = false },
                            new Option { Name_SQ = "", Name_EN = "CREATE DATABASE TABLE Customers", Name_NO = "", IsCorrect = false },
                        }
                    },
                }
            };

            context.Quiz.Add(newQuiz);
            context.Quiz.Add(newQuizProgramming);
            context.SaveChanges();
        }
    }
}