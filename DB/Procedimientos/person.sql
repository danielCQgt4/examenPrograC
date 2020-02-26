/*
SP para crear persona
*/
drop procedure if exists agregarPersona;
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/25
-- =============================================
CREATE PROCEDURE agregarPersona
	@firstName varchar(45),
    @lastName varchar(45),
    @genderId int
AS
BEGIN
	SET NOCOUNT ON;
    declare @personId int;
    select @personId = max(personId) + 1 from person;
    if  @personId is null BEGIN
        set @personId = 1;
    end;
    insert into person values (@personId,@firstName,@lastName,@genderId);
END
GO

/*
SP para actualizar persona
*/
drop procedure if exists actualizarPersona;
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/25
-- =============================================
CREATE PROCEDURE actualizarPersona
    @personId int,
    @firstName varchar(45),
    @lastName varchar(45),
    @genderId int
AS
BEGIN
	SET NOCOUNT ON;
    update person set firstName = @firstName,
        lastName = @lastName,
        genderId = @genderId
    where personId = @personId;
END
GO

/*
SP para leer persona
*/
drop procedure if exists consultarPersona;
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/25
-- =============================================
CREATE PROCEDURE consultarPersona
    @personId int
AS
BEGIN
	SET NOCOUNT ON;
    select p.personId,p.firstName,p.lastName,g.label
    from person p, gender g 
    where (p.genderId = g.genderId) and (personId = @personId);
END
GO

/*
SP para leer personas
*/
drop procedure if exists consultarPersonas;
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/25
-- =============================================
CREATE PROCEDURE consultarPersonas
AS
BEGIN
	SET NOCOUNT ON;
    select p.personId,p.firstName,p.lastName,g.label
    from person p, gender g 
    where (p.genderId = g.genderId);
END
GO

/*
SP para eliminar personas
*/
drop procedure if exists eliminarPersonas;
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/25
-- =============================================
CREATE PROCEDURE eliminarPersonas
    @personId int
AS
BEGIN
	SET NOCOUNT ON;
    delete from person where personId = @personId;
END
GO
