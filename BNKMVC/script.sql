USE [mbank]
GO
/****** Object:  Table [dbo].[ForwardTransfer]    Script Date: 2/13/2019 4:56:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ForwardTransfer](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AccountID] [varchar](50) NULL,
	[BeneficaryBank] [varchar](50) NULL,
	[BeneficaryName] [nchar](10) NULL,
	[DestinationAccountNo] [varchar](50) NULL,
	[BeneficarySwiftCode] [int] NULL,
	[BeneficaryAddress] [varchar](1000) NULL,
	[IBAN] [varchar](50) NULL,
	[Amount] [decimal](18, 2) NULL,
	[Purpose] [varchar](500) NULL,
	[Status] [varchar](50) NULL,
 CONSTRAINT [PK_ForwardTransfer] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblAccount]    Script Date: 2/13/2019 4:56:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblAccount](
	[acctNo] [varchar](50) NOT NULL,
	[ActiveAmount] [nchar](10) NULL,
	[currency] [varchar](50) NULL,
 CONSTRAINT [PK_tblAccount] PRIMARY KEY CLUSTERED 
(
	[acctNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblAdminLogin]    Script Date: 2/13/2019 4:56:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblAdminLogin](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[AdminUsername] [varchar](50) NULL,
	[AdminPassword] [varchar](50) NULL,
	[role] [varchar](50) NULL,
 CONSTRAINT [PK_tblAdminLogin] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblfeedbacks]    Script Date: 2/13/2019 4:56:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblfeedbacks](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Clientname] [varchar](50) NULL,
	[email] [varchar](50) NULL,
	[Message] [varchar](max) NULL,
	[datesent] [varchar](50) NULL,
 CONSTRAINT [PK_tblfeedbacks] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblLogins]    Script Date: 2/13/2019 4:56:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblLogins](
	[loginId] [int] IDENTITY(1,1) NOT NULL,
	[LoginUsername] [varchar](max) NULL,
	[LoginPassword] [varchar](50) NULL,
	[status] [varchar](50) NULL,
 CONSTRAINT [PK_tblLogins] PRIMARY KEY CLUSTERED 
(
	[loginId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblRegister]    Script Date: 2/13/2019 4:56:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblRegister](
	[tblRegID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[Othername] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[phone] [varchar](50) NULL,
	[address] [varchar](400) NULL,
	[AccountType] [varchar](50) NULL,
	[DOB] [varchar](50) NULL,
	[AccountNo] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
	[currencyType] [varchar](50) NULL,
 CONSTRAINT [PK_tblRegister_1] PRIMARY KEY CLUSTERED 
(
	[tblRegID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblTransfer]    Script Date: 2/13/2019 4:56:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblTransfer](
	[transferID] [int] IDENTITY(1,1) NOT NULL,
	[AcctNo] [varchar](50) NULL,
	[RecipientAcctNo] [varchar](50) NULL,
	[IBAN] [varchar](50) NULL,
	[BIC] [varchar](50) NULL,
	[RoutingNumber] [varchar](50) NULL,
	[Amount] [varchar](50) NULL,
	[Status] [varchar](50) NULL,
	[DateSent] [varchar](50) NULL,
 CONSTRAINT [PK_tblTransfer] PRIMARY KEY CLUSTERED 
(
	[transferID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TransactionCode]    Script Date: 2/13/2019 4:56:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TransactionCode](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AccountNo] [varchar](50) NULL,
	[COT] [varchar](50) NULL,
	[TAX] [varchar](50) NULL,
	[IMF] [varchar](50) NULL,
	[DateGenerated] [datetime] NULL,
	[Status] [varchar](50) NULL,
 CONSTRAINT [PK_TransactionCode] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[ForwardTransfer]  WITH CHECK ADD  CONSTRAINT [FK_ForwardTransfer_tblAccount] FOREIGN KEY([AccountID])
REFERENCES [dbo].[tblAccount] ([acctNo])
GO
ALTER TABLE [dbo].[ForwardTransfer] CHECK CONSTRAINT [FK_ForwardTransfer_tblAccount]
GO
ALTER TABLE [dbo].[tblRegister]  WITH CHECK ADD  CONSTRAINT [FK_tblRegister_tblAccount] FOREIGN KEY([AccountNo])
REFERENCES [dbo].[tblAccount] ([acctNo])
GO
ALTER TABLE [dbo].[tblRegister] CHECK CONSTRAINT [FK_tblRegister_tblAccount]
GO
ALTER TABLE [dbo].[TransactionCode]  WITH CHECK ADD  CONSTRAINT [FK_TransactionCode_tblAccount] FOREIGN KEY([AccountNo])
REFERENCES [dbo].[tblAccount] ([acctNo])
GO
ALTER TABLE [dbo].[TransactionCode] CHECK CONSTRAINT [FK_TransactionCode_tblAccount]
GO
