USE [Dormitories_LNU]
GO

--Faculties initialization
SET IDENTITY_INSERT [dbo].[Faculties] ON
INSERT [dbo].[Faculties] ([Id], [Name]) VALUES (1, N'Прикладної математики та інформатики')
INSERT [dbo].[Faculties] ([Id], [Name]) VALUES (2, N'Фізичний')
INSERT [dbo].[Faculties] ([Id], [Name]) VALUES (3, N'Механіко - Математичний')
SET IDENTITY_INSERT [dbo].[Faculties] OFF

SET IDENTITY_INSERT [dbo].[Groups] ON
INSERT [dbo].[Groups] ([Id],[FacultyId], [Name]) VALUES (1, 1, N'ПМП-42')
SET IDENTITY_INSERT [dbo].[Groups] OFF

--StudentCategories initialization
SET IDENTITY_INSERT [dbo].[StudentCategories] ON
INSERT [dbo].[StudentCategories] ([Id], [Description], [Priority]) VALUES (1, N'Інвалід', 1000)
INSERT [dbo].[StudentCategories] ([Id], [Description], [Priority]) VALUES (2, N'Багатодітна сім''я', 900)
SET IDENTITY_INSERT [dbo].[StudentCategories] OFF

--Create Super Admin login: admin@admin.admin pwd: Aa123456
SET IDENTITY_INSERT [dbo].[Users] ON
INSERT [dbo].[Users] ([Id], [FullName], [FacultyId], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName])
VALUES (1, N'Super Admin', NULL, N'admin@admin.admin', 0, N'AD4G5UH/rhoHQjjXn1OLqk2B7qhA0UMzwqeUiLGDIiISYcz+PoB+OMcFMvQlc3ezow==', N'9c71cb5d-185b-41b7-a6e1-d244a802e423', NULL, 0, 0, NULL, 0, 0, N'admin@admin.admin')
SET IDENTITY_INSERT [dbo].[Users] OFF

--Roles initialization
SET IDENTITY_INSERT [dbo].[Roles] ON
INSERT [dbo].[Roles] ([Id], [Name]) VALUES (1, N'Admin')
INSERT [dbo].[Roles] ([Id], [Name]) VALUES (2, N'DormitoryAdmin')
INSERT [dbo].[Roles] ([Id], [Name]) VALUES (3, N'FacultyAdmin')
INSERT [dbo].[Roles] ([Id], [Name]) VALUES (4, N'Student')
SET IDENTITY_INSERT [dbo].[Roles] OFF

--UserRoles initialization
INSERT [dbo].[UserRoles] ([UserId], [RoleId], [CustomRole_Id]) VALUES (1, 1, NULL)
INSERT [dbo].[Administrators] ([Id], [DormitoryId]) VALUES (1, NULL)


