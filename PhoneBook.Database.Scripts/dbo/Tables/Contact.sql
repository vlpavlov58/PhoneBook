CREATE TABLE [dbo].[Contact] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [GroupId]   INT            NULL,
    [FirstName] NVARCHAR (MAX) NULL,
    [LastName]  NVARCHAR (MAX) NULL,
    [Position]  NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Contact] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Contact_Group] FOREIGN KEY ([GroupId]) REFERENCES [dbo].[Group] ([Id])
);

