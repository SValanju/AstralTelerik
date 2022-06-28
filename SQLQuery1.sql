Create database Astral;

use Astral;

create table TelerikMVC(
Id int primary key identity,
FName varchar(50),
LName varchar(50),
Country varchar(50),
Mobile varchar(50),
Email varchar(50),
ActiveStatus bit default 1,
FName2 varchar(50),
LName2 varchar(50),
Country2 varchar(50),
Mobile2 varchar(50),
Email2 varchar(50),
ActiveStatus2 bit default 1,
FName3 varchar(50),
LName3 varchar(50),
Country3 varchar(50),
Mobile3 varchar(50),
Email3 varchar(50),
ActiveStatus3 bit default 1);

select * from TelerikMVC;




Declare @Id int
Set @Id = 1
While @Id <= 500000
Begin 
   Insert Into TelerikMVC(FName,LName,Country,Mobile,Email,
							FName2,LName2,Country2,Mobile2,Email2,
							FName3,LName3,Country3,Mobile3,Email3) values ('fname - ' + CAST(@Id as varchar(10)), 'lname - ' + CAST(@Id as varchar(10)), 'country - ' + CAST(@Id as varchar(10)), 'mobile - ' + CAST(@Id as varchar(10)), 'email - ' + CAST(@Id as varchar(10)),
																			'fname2 - ' + CAST(@Id as varchar(10)), 'lname2 - ' + CAST(@Id as varchar(10)), 'country2 - ' + CAST(@Id as varchar(10)), 'mobile2 - ' + CAST(@Id as varchar(10)), 'email2 - ' + CAST(@Id as varchar(10)),
																			'fname3 - ' + CAST(@Id as varchar(10)), 'lname3 - ' + CAST(@Id as varchar(10)), 'country3 - ' + CAST(@Id as varchar(10)), 'mobile3 - ' + CAST(@Id as varchar(10)), 'email3 - ' + CAST(@Id as varchar(10)))
   Print @Id
   Set @Id = @Id + 1
End