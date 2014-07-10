drop table Chat;

CREATE TABLE [dbo].[Chat] (
    [Id]             INT            IDENTITY (1, 1) NOT NULL,
    [SenderUserId]   INT            NOT NULL,
    [RecieverUserId] INT            NOT NULL,
    [Message]        NVARCHAR (MAX) NULL,
    [Time]           DATETIME       NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC), 
    CONSTRAINT [FK_Chat_ToSender] FOREIGN KEY ([SenderUserId]) REFERENCES [UserProfile]([UserId]), 
    CONSTRAINT [FK_Chat_ToReciever] FOREIGN KEY ([RecieverUserId]) REFERENCES [UserProfile]([UserId])
);

