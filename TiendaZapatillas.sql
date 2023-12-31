USE [TiendaZapatillas]
GO
/****** Object:  Table [dbo].[Empleados]    Script Date: 12/11/2022 09:45:17 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleados](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Apellido] [varchar](50) NULL,
	[Telefono] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Puesto] [varchar](50) NULL,
	[Sueldo] [float] NULL,
	[Faltas] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 12/11/2022 09:45:17 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[Codigo] [int] IDENTITY(1,1) NOT NULL,
	[Producto] [varchar](50) NULL,
	[Modelo] [varchar](50) NULL,
	[Cantidad] [int] NULL,
	[Precio unitario] [float] NULL,
	[Precio total] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StockProducto]    Script Date: 12/11/2022 09:45:17 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StockProducto](
	[Codigo] [int] IDENTITY(1,1) NOT NULL,
	[Producto] [varchar](50) NULL,
	[Modelo] [varchar](50) NULL,
	[PrecioUnitario] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 12/11/2022 09:45:17 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Usuario] [varchar](50) NULL,
	[Contraseña] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Empleados] ON 

INSERT [dbo].[Empleados] ([Id], [Nombre], [Apellido], [Telefono], [Email], [Puesto], [Sueldo], [Faltas]) VALUES (1, N'Juan', N'Fernandez', N'3817728394', N'juean1234@gmail.com', N'Venta', 15546.4, 3)
INSERT [dbo].[Empleados] ([Id], [Nombre], [Apellido], [Telefono], [Email], [Puesto], [Sueldo], [Faltas]) VALUES (2, N'Exequiel', N'Gonzales', N'3816237495', N'LIAN@gmail.com', N'Ventas', 15000, 2)
INSERT [dbo].[Empleados] ([Id], [Nombre], [Apellido], [Telefono], [Email], [Puesto], [Sueldo], [Faltas]) VALUES (3, N'Fernandez', N'Agustin', N'3817732245', N'AGUS@gmail.com', N'Encargado', 30000, 3)
SET IDENTITY_INSERT [dbo].[Empleados] OFF
GO
SET IDENTITY_INSERT [dbo].[Producto] ON 

INSERT [dbo].[Producto] ([Codigo], [Producto], [Modelo], [Cantidad], [Precio unitario], [Precio total]) VALUES (1, N'Zapatilla', N'Air Force 1', 2, 20000, 40000)
INSERT [dbo].[Producto] ([Codigo], [Producto], [Modelo], [Cantidad], [Precio unitario], [Precio total]) VALUES (2, N'Zapatilla', N'Air Max 9', 1, 36000, 36000)
INSERT [dbo].[Producto] ([Codigo], [Producto], [Modelo], [Cantidad], [Precio unitario], [Precio total]) VALUES (3, N'Zapatilla', N'Jordan 1', 2, 25000, 50000)
INSERT [dbo].[Producto] ([Codigo], [Producto], [Modelo], [Cantidad], [Precio unitario], [Precio total]) VALUES (4, N'Calcetines', N'Ekin', 2, 400, 800)
SET IDENTITY_INSERT [dbo].[Producto] OFF
GO
SET IDENTITY_INSERT [dbo].[StockProducto] ON 

INSERT [dbo].[StockProducto] ([Codigo], [Producto], [Modelo], [PrecioUnitario]) VALUES (1, N'Zapatillas', N'Air Force 1', 22000)
INSERT [dbo].[StockProducto] ([Codigo], [Producto], [Modelo], [PrecioUnitario]) VALUES (2, N'Zapatillas', N'Air Force 29', 29000)
INSERT [dbo].[StockProducto] ([Codigo], [Producto], [Modelo], [PrecioUnitario]) VALUES (3, N'Zapatillas', N'Jordan 1', 50000)
INSERT [dbo].[StockProducto] ([Codigo], [Producto], [Modelo], [PrecioUnitario]) VALUES (4, N'Zapatillas', N'Jordan 99', 90000)
INSERT [dbo].[StockProducto] ([Codigo], [Producto], [Modelo], [PrecioUnitario]) VALUES (5, N'Zapatillas', N'Air Max', 32000)
INSERT [dbo].[StockProducto] ([Codigo], [Producto], [Modelo], [PrecioUnitario]) VALUES (6, N'Zapatillas', N'Blazer', 15000)
INSERT [dbo].[StockProducto] ([Codigo], [Producto], [Modelo], [PrecioUnitario]) VALUES (7, N'Calcetines', N'Jordan', 900)
INSERT [dbo].[StockProducto] ([Codigo], [Producto], [Modelo], [PrecioUnitario]) VALUES (8, N'Calcetines', N'Nike', 300)
INSERT [dbo].[StockProducto] ([Codigo], [Producto], [Modelo], [PrecioUnitario]) VALUES (9, N'Calcetines', N'Ekin', 400)
INSERT [dbo].[StockProducto] ([Codigo], [Producto], [Modelo], [PrecioUnitario]) VALUES (10, N'Calcetines', N'Sportswear', 600)
SET IDENTITY_INSERT [dbo].[StockProducto] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuarios] ON 

INSERT [dbo].[Usuarios] ([Id], [Usuario], [Contraseña]) VALUES (1, N'cristian', N'123456')
INSERT [dbo].[Usuarios] ([Id], [Usuario], [Contraseña]) VALUES (2, N'user', N'bocapasion')
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
GO
