CREATE TABLE [dbo].[ContactPhone] (
    [ContactId] INT NOT NULL,
    [PhoneId]   INT NOT NULL,
    CONSTRAINT [PK_ContactPhone] PRIMARY KEY CLUSTERED ([ContactId] ASC, [PhoneId] ASC),
    CONSTRAINT [FK_ContactPhone_Contact] FOREIGN KEY ([ContactId]) REFERENCES [dbo].[Contact] ([Id]),
    CONSTRAINT [FK_ContactPhone_Phone] FOREIGN KEY ([PhoneId]) REFERENCES [dbo].[Phone] ([Id])
);

