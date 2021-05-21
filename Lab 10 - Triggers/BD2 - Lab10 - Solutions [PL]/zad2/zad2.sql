USE testCLR;
GO

CREATE TABLE student (
    student_id INT PRIMARY KEY,
    first_name VARCHAR(30),
    surname VARCHAR(30),
);

GO

CREATE TABLE subject (
    subject_id INT PRIMARY KEY,
    title VARCHAR(30),
);

GO

CREATE TABLE student_subject (
    student_id INT FOREIGN KEY REFERENCES student(student_id),
    subject_id INT FOREIGN KEY REFERENCES subject(subject_id)
);

EXEC dbo.SimpleTransactionScope;
