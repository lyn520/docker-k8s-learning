
SELECT ','+ Name FROM T_Cat (NOLOCK) for xml path('');
SELECT STUFF((SELECT ','+Name FROM T_Cat (NOLOCK) for xml path('')),1,1,'');


SELECT [Name],
 MAX(CASE [Subject] WHEN N'语文' THEN Score ELSE 0 end)语文,
 MAX(CASE [Subject] WHEN N'数学' THEN Score ELSE 0 end)数学,
 MAX(CASE [Subject] WHEN N'物理' THEN Score ELSE 0 end)物理
FROM T_StudentScore
GROUP BY [Name];

SELECT [Name],[Subject],Score FROM T_StudentScore;
--静态
SELECT [Name], 语文, 数学, 物理  FROM (SELECT [Name],[Subject],Score FROM T_StudentScore) src PIVOT( MAX(Score) FOR [Subject] IN ( 语文, 数学, 物理 ) ) piv;
--动态
DECLARE @subjects Nvarchar(max),@query AS NVARCHAR(MAX);
SET @subjects= STUFF((SELECT  DISTINCT ',' + QUOTENAME([Subject]) FROM T_StudentScore FOR XML PATH('')),1,1,'');
SET @query = 'SELECT [Name], ' + @subjects + ' FROM (SELECT [Name],[Subject],Score FROM T_StudentScore) src PIVOT( MAX(Score) FOR [Subject] IN (' + @subjects + ') ) piv';
EXECUTE(@query);

SELECT [Year],[Month],[Amount] FROM T_YearAmount;
--静态
SELECT [Year], [1], [2], [3], [4]  FROM (SELECT [Year],[Month],[Amount] FROM T_YearAmount) src PIVOT( MAX(Amount) FOR [Month] IN ( [1], [2], [3], [4] ) ) piv;

SELECT [Year],[Month],[Amount] FROM T_YearAmount
