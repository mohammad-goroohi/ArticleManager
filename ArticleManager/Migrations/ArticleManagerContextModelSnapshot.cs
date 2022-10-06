﻿// <auto-generated />
using ArticleManager.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ArticleManager.Migrations
{
    [DbContext(typeof(ArticleManagerContext))]
    partial class ArticleManagerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.29")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ArticleManager.Models.Article", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ArticleDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FilePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsRead")
                        .HasColumnType("bit");

                    b.Property<string>("Link")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MyDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("Link")
                        .IsUnique()
                        .HasFilter("[Link] IS NOT NULL");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("ArticleManager.Models.ArticleArticle", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DestinationArticleID")
                        .HasColumnType("int");

                    b.Property<int>("SourceArticleID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("DestinationArticleID");

                    b.HasIndex("SourceArticleID");

                    b.ToTable("ArticleArticles");
                });

            modelBuilder.Entity("ArticleManager.Models.ArticleArticle", b =>
                {
                    b.HasOne("ArticleManager.Models.Article", "DestinationArticle")
                        .WithMany("CitedBys")
                        .HasForeignKey("DestinationArticleID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ArticleManager.Models.Article", "SourceArticle")
                        .WithMany("Cites")
                        .HasForeignKey("SourceArticleID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
