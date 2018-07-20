SET IDENTITY_INSERT [dbo].[Products] ON
INSERT INTO [dbo].[Products] ([ProductId], [Name], [Description], [Category], [Price]) VALUES (1, N'Kajak', N'Łódka przeznaczona dla jednej osoby', N'Sporty wodne', CAST(275.00 AS Decimal(16, 2)))
INSERT INTO [dbo].[Products] ([ProductId], [Name], [Description], [Category], [Price]) VALUES (2, N'Kamizelak ratunkowa', N'Chroni i dodaje uroku', N'Sporty wodne', CAST(48.95 AS Decimal(16, 2)))
INSERT INTO [dbo].[Products] ([ProductId], [Name], [Description], [Category], [Price]) VALUES (3, N'Piłka', N'Piłka do nogi', N'Piłka nożna', CAST(19.50 AS Decimal(16, 2)))
INSERT INTO [dbo].[Products] ([ProductId], [Name], [Description], [Category], [Price]) VALUES (4, N'Czapka', N'Zwiększa efektywność mózgu', N'Szachy', CAST(20.00 AS Decimal(16, 2)))
SET IDENTITY_INSERT [dbo].[Products] OFF
