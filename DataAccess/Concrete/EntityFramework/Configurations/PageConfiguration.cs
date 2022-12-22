using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Configurations
{
    public class PageConfiguration : IEntityTypeConfiguration<Page>
    {
        public void Configure(EntityTypeBuilder<Page> builder)
        {
            builder.ToTable("Pages", @"dbo");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.PageName)
                .HasColumnName("PageName")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.PageUrl)
              .HasColumnName("PageUrl")
              .HasMaxLength(250)
              .IsRequired();

            builder.Property(x => x.ParentId)
             .HasColumnName("ParentID");

            builder.Property(x => x.PageSeoUrl)
            .HasColumnName("PageSeoUrl")
            .HasMaxLength(250);

            builder.Property(x => x.PageTypeId)
            .HasColumnName("PageTypeId")
            .IsRequired();

            builder.Property(x => x.DisplayOrder)
           .HasColumnName("DisplayOrder")
           .IsRequired();

            builder.Property(x => x.MetaTitle)
           .HasColumnName("MetaTitle")
           .HasMaxLength(70);

            builder.Property(x => x.MetaKeywords)
           .HasColumnName("MetaKeywords")
           .HasMaxLength(260);

            builder.Property(x => x.MetaDescription)
           .HasColumnName("MetaDescription")
           .HasMaxLength(160);

            builder.HasData(
                new Page() { Id = 1, PageName = "Sistem Ayarları", DisplayOrder = 1, PageTypeId = 1, PageUrl = "#", ParentId = null, IsActive = true, PageSeoUrl = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },
                new Page() { Id = 2, PageName = "Kullanıcılar", DisplayOrder = 1, PageTypeId = 1, PageUrl = "/Admin/AppUsers/List", ParentId = 1, IsActive = true, PageSeoUrl = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },
                new Page() { Id = 3, PageName = "Kullanıcı Tipleri", DisplayOrder = 1, PageTypeId = 1, PageUrl = "/Admin/AppUserTypes/List", ParentId = 1, IsActive = true, PageSeoUrl = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },
                new Page() { Id = 4, PageName = "Sayfalar", DisplayOrder = 1, PageTypeId = 1, PageUrl = "/Admin/Pages/List", ParentId = 1, IsActive = true, PageSeoUrl = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },
                new Page() { Id = 5, PageName = "Sayfa Yetkileri", DisplayOrder = 1, PageTypeId = 1, PageUrl = "/Admin/PagePermissons/List", ParentId = 1, IsActive = true, PageSeoUrl = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" }
            );
        }
    }
}