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
                            new Option { Name_SQ = "Saktë", Name_EN = "True", Name_NO = "Sant", IsCorrect = false},
                            new Option { Name_SQ = "Gabim", Name_EN = "False", Name_NO = "Falsk", IsCorrect = true},
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
            context.SaveChanges();
        }
    }
}