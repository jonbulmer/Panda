CREATE PROCEDURE [dbo].[Global_Confirmed]
	@Date_From	VARCHAR,
	@Date_To	VARCHAR,
	@Contient	VARCHAR,
	@Region		VARCHAR,
	@Country	VARCHAR
AS
BEGIN 
	SELECT total_cases
	FROM [dbo].[Global_Confirmed]
	WHERE ([date] BETWEEN @Date_From AND @Date_To OR @Date_to IS NULL)
END