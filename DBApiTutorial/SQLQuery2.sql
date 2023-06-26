SELECT [e].[Id], [e].[FirstName], [e].[LastName], [o0].Id
FROM [Employees] AS [e]
INNER JOIN [OfficeEmployees] AS [o] ON [e].[Id] = [o].[EmployeeId]
INNER JOIN [Offices] AS [o0] ON [o].[OfficeId] = [o0].[Id]
WHERE [e].[Id] = 3