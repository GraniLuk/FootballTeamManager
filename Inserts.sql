USE [dbeaf99c4edfe04222a160a7dd010a88fa]
GO
SET IDENTITY_INSERT [dbo].[FixturesArchive] ON 

GO
INSERT [dbo].[FixturesArchive] ([Id], [Date], [FirstTeamScore], [SecondTeamScore], [FirstTeam_Id], [SecondTeam_Id], [Name]) VALUES (1, CAST(N'2017-08-22 00:00:00.000' AS DateTime), 9, 8, 1, 2, NULL)
GO
SET IDENTITY_INSERT [dbo].[FixturesArchive] OFF
GO
SET IDENTITY_INSERT [dbo].[PlayersArchive] ON 

GO
INSERT [dbo].[PlayersArchive] ([Id], [Name], [Rank], [Active]) VALUES (28, N'Adrian od Mateusza', 8, 0)
GO
INSERT [dbo].[PlayersArchive] ([Id], [Name], [Rank], [Active]) VALUES (27, N'Pawe³ Harhaj', 7, 0)
GO
INSERT [dbo].[PlayersArchive] ([Id], [Name], [Rank], [Active]) VALUES (26, N'Mateusz (od £ukasz)', 8, 1)
GO
INSERT [dbo].[PlayersArchive] ([Id], [Name], [Rank], [Active]) VALUES (25, N'Dawid (od Jarka)', 8, 1)
GO
INSERT [dbo].[PlayersArchive] ([Id], [Name], [Rank], [Active]) VALUES (24, N'Maciej (od Jarka)', 8, 0)
GO
INSERT [dbo].[PlayersArchive] ([Id], [Name], [Rank], [Active]) VALUES (23, N'Tomek(od Mateusza)', 7, 0)
GO
INSERT [dbo].[PlayersArchive] ([Id], [Name], [Rank], [Active]) VALUES (22, N'Dorian (od Mateusza)', 8, 0)
GO
INSERT [dbo].[PlayersArchive] ([Id], [Name], [Rank], [Active]) VALUES (21, N'Marcin Urbaniak', 10, 0)
GO
INSERT [dbo].[PlayersArchive] ([Id], [Name], [Rank], [Active]) VALUES (20, N'Hubert Koczergo', 13, 0)
GO
INSERT [dbo].[PlayersArchive] ([Id], [Name], [Rank], [Active]) VALUES (19, N'Kuba Krzemiñski', 9, 1)
GO
INSERT [dbo].[PlayersArchive] ([Id], [Name], [Rank], [Active]) VALUES (18, N'Wojciech Ziêtek', 3, 0)
GO
INSERT [dbo].[PlayersArchive] ([Id], [Name], [Rank], [Active]) VALUES (17, N'Sadowski Karol', 5, 0)
GO
INSERT [dbo].[PlayersArchive] ([Id], [Name], [Rank], [Active]) VALUES (16, N'Przemek Arszulik', 7, 0)
GO
INSERT [dbo].[PlayersArchive] ([Id], [Name], [Rank], [Active]) VALUES (15, N'Sasza od Vitaliya', 6, 0)
GO
INSERT [dbo].[PlayersArchive] ([Id], [Name], [Rank], [Active]) VALUES (14, N'Krzysiek Taranowski', 10, 0)
GO
INSERT [dbo].[PlayersArchive] ([Id], [Name], [Rank], [Active]) VALUES (13, N'Pawe³ Cejrowski', 6, 0)
GO
INSERT [dbo].[PlayersArchive] ([Id], [Name], [Rank], [Active]) VALUES (12, N'Sylwek Plit', 9, 1)
GO
INSERT [dbo].[PlayersArchive] ([Id], [Name], [Rank], [Active]) VALUES (11, N'£ukasz Tarnowski', 12, 1)
GO
INSERT [dbo].[PlayersArchive] ([Id], [Name], [Rank], [Active]) VALUES (10, N'£ukasz Stêpieñ', 10, 1)
GO
INSERT [dbo].[PlayersArchive] ([Id], [Name], [Rank], [Active]) VALUES (9, N'Vitaly Skripay', 14, 1)
GO
INSERT [dbo].[PlayersArchive] ([Id], [Name], [Rank], [Active]) VALUES (8, N'Krzysztof T', 9, 1)
GO
INSERT [dbo].[PlayersArchive] ([Id], [Name], [Rank], [Active]) VALUES (7, N'Jarek Mazur', 14, 1)
GO
INSERT [dbo].[PlayersArchive] ([Id], [Name], [Rank], [Active]) VALUES (6, N'Damian Kisielewski', 12, 1)
GO
INSERT [dbo].[PlayersArchive] ([Id], [Name], [Rank], [Active]) VALUES (5, N'Przemek Stolle', 9, 0)
GO
INSERT [dbo].[PlayersArchive] ([Id], [Name], [Rank], [Active]) VALUES (4, N'Karol Skupski', 11, 1)
GO
INSERT [dbo].[PlayersArchive] ([Id], [Name], [Rank], [Active]) VALUES (3, N'Kamil Pakalski', 6, 1)
GO
INSERT [dbo].[PlayersArchive] ([Id], [Name], [Rank], [Active]) VALUES (2, N'Mateusz Wantoch', 11, 1)
GO
INSERT [dbo].[PlayersArchive] ([Id], [Name], [Rank], [Active]) VALUES (1, N'£ukasz Granica', 12, 1)
GO
SET IDENTITY_INSERT [dbo].[PlayersArchive] OFF
GO
SET IDENTITY_INSERT [dbo].[TeamPlayerAssociationsArchive] ON 

GO
INSERT [dbo].[TeamPlayerAssociationsArchive] ([Id], [Player_Id], [Team_Id]) VALUES (65, 25, 3)
GO
INSERT [dbo].[TeamPlayerAssociationsArchive] ([Id], [Player_Id], [Team_Id]) VALUES (64, 9, 4)
GO
INSERT [dbo].[TeamPlayerAssociationsArchive] ([Id], [Player_Id], [Team_Id]) VALUES (63, 22, 4)
GO
INSERT [dbo].[TeamPlayerAssociationsArchive] ([Id], [Player_Id], [Team_Id]) VALUES (62, 19, 4)
GO
INSERT [dbo].[TeamPlayerAssociationsArchive] ([Id], [Player_Id], [Team_Id]) VALUES (61, 12, 4)
GO
INSERT [dbo].[TeamPlayerAssociationsArchive] ([Id], [Player_Id], [Team_Id]) VALUES (60, 8, 4)
GO
INSERT [dbo].[TeamPlayerAssociationsArchive] ([Id], [Player_Id], [Team_Id]) VALUES (59, 4, 4)
GO
INSERT [dbo].[TeamPlayerAssociationsArchive] ([Id], [Player_Id], [Team_Id]) VALUES (58, 6, 4)
GO
INSERT [dbo].[TeamPlayerAssociationsArchive] ([Id], [Player_Id], [Team_Id]) VALUES (56, 14, 3)
GO
INSERT [dbo].[TeamPlayerAssociationsArchive] ([Id], [Player_Id], [Team_Id]) VALUES (55, 20, 3)
GO
INSERT [dbo].[TeamPlayerAssociationsArchive] ([Id], [Player_Id], [Team_Id]) VALUES (54, 11, 3)
GO
INSERT [dbo].[TeamPlayerAssociationsArchive] ([Id], [Player_Id], [Team_Id]) VALUES (53, 7, 3)
GO
INSERT [dbo].[TeamPlayerAssociationsArchive] ([Id], [Player_Id], [Team_Id]) VALUES (52, 2, 3)
GO
INSERT [dbo].[TeamPlayerAssociationsArchive] ([Id], [Player_Id], [Team_Id]) VALUES (51, 1, 3)
GO
INSERT [dbo].[TeamPlayerAssociationsArchive] ([Id], [Player_Id], [Team_Id]) VALUES (50, 27, 2)
GO
INSERT [dbo].[TeamPlayerAssociationsArchive] ([Id], [Player_Id], [Team_Id]) VALUES (49, 26, 1)
GO
INSERT [dbo].[TeamPlayerAssociationsArchive] ([Id], [Player_Id], [Team_Id]) VALUES (48, 25, 1)
GO
INSERT [dbo].[TeamPlayerAssociationsArchive] ([Id], [Player_Id], [Team_Id]) VALUES (47, 19, 2)
GO
INSERT [dbo].[TeamPlayerAssociationsArchive] ([Id], [Player_Id], [Team_Id]) VALUES (46, 12, 2)
GO
INSERT [dbo].[TeamPlayerAssociationsArchive] ([Id], [Player_Id], [Team_Id]) VALUES (45, 11, 1)
GO
INSERT [dbo].[TeamPlayerAssociationsArchive] ([Id], [Player_Id], [Team_Id]) VALUES (44, 10, 2)
GO
INSERT [dbo].[TeamPlayerAssociationsArchive] ([Id], [Player_Id], [Team_Id]) VALUES (43, 9, 2)
GO
INSERT [dbo].[TeamPlayerAssociationsArchive] ([Id], [Player_Id], [Team_Id]) VALUES (42, 8, 2)
GO
INSERT [dbo].[TeamPlayerAssociationsArchive] ([Id], [Player_Id], [Team_Id]) VALUES (41, 7, 1)
GO
INSERT [dbo].[TeamPlayerAssociationsArchive] ([Id], [Player_Id], [Team_Id]) VALUES (40, 4, 1)
GO
INSERT [dbo].[TeamPlayerAssociationsArchive] ([Id], [Player_Id], [Team_Id]) VALUES (39, 3, 2)
GO
INSERT [dbo].[TeamPlayerAssociationsArchive] ([Id], [Player_Id], [Team_Id]) VALUES (38, 2, 1)
GO
INSERT [dbo].[TeamPlayerAssociationsArchive] ([Id], [Player_Id], [Team_Id]) VALUES (37, 1, 1)
GO
SET IDENTITY_INSERT [dbo].[TeamPlayerAssociationsArchive] OFF
GO
SET IDENTITY_INSERT [dbo].[TeamsArchive] ON 

GO
INSERT [dbo].[TeamsArchive] ([Id], [Name]) VALUES (4, N'Druga')
GO
INSERT [dbo].[TeamsArchive] ([Id], [Name]) VALUES (3, N'Pierwsza')
GO
INSERT [dbo].[TeamsArchive] ([Id], [Name]) VALUES (2, N'Cieniasy')
GO
INSERT [dbo].[TeamsArchive] ([Id], [Name]) VALUES (1, N'Cwaniaki')
GO
SET IDENTITY_INSERT [dbo].[TeamsArchive] OFF
GO
