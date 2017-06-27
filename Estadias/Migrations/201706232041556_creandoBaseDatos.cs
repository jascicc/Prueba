namespace Estadias.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class creandoBaseDatos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Alumnoes",
                c => new
                    {
                        alumnoID = c.String(nullable: false, maxLength: 128),
                        nombreAlumno = c.String(nullable: false),
                        apellidoPaterno = c.String(nullable: false),
                        apellidoMaterno = c.String(nullable: false),
                        email = c.String(),
                        seguroSocial = c.String(nullable: false),
                        carreraID = c.String(nullable: false),
                        carrera_carreraID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.alumnoID)
                .ForeignKey("dbo.Carreras", t => t.carrera_carreraID)
                .Index(t => t.carrera_carreraID);
            
            CreateTable(
                "dbo.Carreras",
                c => new
                    {
                        carreraID = c.String(nullable: false, maxLength: 128),
                        nombreCarrera = c.String(nullable: false),
                        Alumno_alumnoID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.carreraID)
                .ForeignKey("dbo.Alumnoes", t => t.Alumno_alumnoID)
                .Index(t => t.Alumno_alumnoID);
            
            CreateTable(
                "dbo.Empresas",
                c => new
                    {
                        empresaID = c.Int(nullable: false, identity: true),
                        nombreEmpresa = c.String(nullable: false),
                        espacios = c.Int(nullable: false),
                        representanteEmpresa = c.String(nullable: false),
                        telefono = c.String(),
                        direccion = c.String(),
                    })
                .PrimaryKey(t => t.empresaID);
            
            CreateTable(
                "dbo.Registroes",
                c => new
                    {
                        registroID = c.Int(nullable: false, identity: true),
                        alumnoID = c.String(nullable: false, maxLength: 128),
                        fecha = c.DateTime(nullable: false),
                        empresaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.registroID)
                .ForeignKey("dbo.Alumnoes", t => t.alumnoID, cascadeDelete: true)
                .ForeignKey("dbo.Empresas", t => t.empresaID, cascadeDelete: true)
                .Index(t => t.alumnoID)
                .Index(t => t.empresaID);
            
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
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Registroes", "empresaID", "dbo.Empresas");
            DropForeignKey("dbo.Registroes", "alumnoID", "dbo.Alumnoes");
            DropForeignKey("dbo.Carreras", "Alumno_alumnoID", "dbo.Alumnoes");
            DropForeignKey("dbo.Alumnoes", "carrera_carreraID", "dbo.Carreras");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Registroes", new[] { "empresaID" });
            DropIndex("dbo.Registroes", new[] { "alumnoID" });
            DropIndex("dbo.Carreras", new[] { "Alumno_alumnoID" });
            DropIndex("dbo.Alumnoes", new[] { "carrera_carreraID" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Registroes");
            DropTable("dbo.Empresas");
            DropTable("dbo.Carreras");
            DropTable("dbo.Alumnoes");
        }
    }
}
