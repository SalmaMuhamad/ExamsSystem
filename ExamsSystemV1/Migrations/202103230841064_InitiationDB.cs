namespace ExamsSystemV1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitiationDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 18, scale: 0, identity: true, storeType: "numeric"),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 18, scale: 0, identity: true, storeType: "numeric"),
                        Title = c.String(),
                        Category_ID = c.Decimal(precision: 18, scale: 0, storeType: "numeric"),
                        Quiz_ID = c.Decimal(precision: 18, scale: 0, storeType: "numeric"),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.Category_ID)
                .ForeignKey("dbo.Quizs", t => t.Quiz_ID)
                .Index(t => t.Category_ID)
                .Index(t => t.Quiz_ID);
            
            CreateTable(
                "dbo.Choices",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 18, scale: 0, identity: true, storeType: "numeric"),
                        Text = c.String(),
                        Is_Correct = c.Boolean(nullable: false),
                        Degree = c.Int(nullable: false),
                        Questions_ID = c.Decimal(precision: 18, scale: 0, storeType: "numeric"),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Questions", t => t.Questions_ID)
                .Index(t => t.Questions_ID);
            
            CreateTable(
                "dbo.UserAnswers",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 18, scale: 0, identity: true, storeType: "numeric"),
                        UserDegree = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        Choice_ID = c.Decimal(precision: 18, scale: 0, storeType: "numeric"),
                        Question_ID = c.Decimal(precision: 18, scale: 0, storeType: "numeric"),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.Choices", t => t.Choice_ID)
                .ForeignKey("dbo.Questions", t => t.Question_ID)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.Choice_ID)
                .Index(t => t.Question_ID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserRole = c.Boolean(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Quizs",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 18, scale: 0, identity: true, storeType: "numeric"),
                        Name = c.String(),
                        Degree = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.QuizApplicationUsers",
                c => new
                    {
                        Quiz_ID = c.Decimal(nullable: false, precision: 18, scale: 0, storeType: "numeric"),
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Quiz_ID, t.ApplicationUser_Id })
                .ForeignKey("dbo.Quizs", t => t.Quiz_ID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .Index(t => t.Quiz_ID)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.UserAnswers", "Question_ID", "dbo.Questions");
            DropForeignKey("dbo.UserAnswers", "Choice_ID", "dbo.Choices");
            DropForeignKey("dbo.UserAnswers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Questions", "Quiz_ID", "dbo.Quizs");
            DropForeignKey("dbo.QuizApplicationUsers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.QuizApplicationUsers", "Quiz_ID", "dbo.Quizs");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Choices", "Questions_ID", "dbo.Questions");
            DropForeignKey("dbo.Questions", "Category_ID", "dbo.Categories");
            DropIndex("dbo.QuizApplicationUsers", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.QuizApplicationUsers", new[] { "Quiz_ID" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.UserAnswers", new[] { "Question_ID" });
            DropIndex("dbo.UserAnswers", new[] { "Choice_ID" });
            DropIndex("dbo.UserAnswers", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Choices", new[] { "Questions_ID" });
            DropIndex("dbo.Questions", new[] { "Quiz_ID" });
            DropIndex("dbo.Questions", new[] { "Category_ID" });
            DropTable("dbo.QuizApplicationUsers");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.Quizs");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.UserAnswers");
            DropTable("dbo.Choices");
            DropTable("dbo.Questions");
            DropTable("dbo.Categories");
        }
    }
}
