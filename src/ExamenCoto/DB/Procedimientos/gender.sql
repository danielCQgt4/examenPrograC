/*
SP para crear genero
*/
drop procedure if exists agregarGenero;
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/25
-- =============================================
CREATE PROCEDURE agregarGenero
	@label varchar(45)
AS
BEGIN
	SET NOCOUNT ON;
    declare @genderId int;
    select @genderId = max(genderId) + 1 from gender;
    if  @genderId is null BEGIN
        set @genderId = 1;
    end;
    insert into gender values (@genderId,@label);
END
GO

/*
SP para actualizar genero
*/
drop procedure if exists actualizarGenero;
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/25
-- =============================================
CREATE PROCEDURE actualizarGenero
    @genderId int,
    @label varchar(45)
AS
BEGIN
	SET NOCOUNT ON;
    update gender set label = @label
    where genderId = @genderId;
END
GO

/*
SP para leer genero
*/
drop procedure if exists consultarGenero;
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/25
-- =============================================
CREATE PROCEDURE consultarGenero
    @genderId int
AS
BEGIN
	SET NOCOUNT ON;
    select genderId, label
    from gender 
    where (genderId = @genderId);
END
GO

/*
SP para leer generos
*/
drop procedure if exists consultarGeneros;
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/25
-- =============================================
CREATE PROCEDURE consultarGeneros
AS
BEGIN
	SET NOCOUNT ON;
    select genderId,label
    from gender;
END
GO

/*
SP para eliminar personas
*/
drop procedure if exists eliminarGenero;
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Coto Quiros
-- Create date: 2020/02/25
-- =============================================
CREATE PROCEDURE eliminarGenero
    @genderId int
AS
BEGIN
	SET NOCOUNT ON;
    delete from gender where genderId = @genderId;
END
GO
