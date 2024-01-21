using WelspunVessel.DAL.Entities;
using WelspunVessel.DAL.Entities.Email;
using WelspunVessel.DAL.Entities.Masters;
using WelspunVessel.DAL.Mapper;
using WelspunVessel.DAL.Mapper.Email;
using WelspunVessel.DTO;
using WelspunVessel.DTO.Email;
using WelspunVessel.DTO.Masters;
using Microsoft.EntityFrameworkCore;
using WelspunVessel.DTO.Files;

namespace WelspunVessel.DAL
{
    public class CRUDContext : DbContext
    {
        public DbSet<RoleMasterDTO> RoleMasterDTO { get; set; }
        public DbSet<ChainMasterDTO> ChainMasterDTO { get; set; }
        public DbSet<UserMasterDTO> UserMasterDTO { get; set; }
        public DbSet<BrandMasterDTO> BrandMasterDTO { get; set; }
        public DbSet<UserProfileDTO> UserProfileDTO { get; set; }
        public DbSet<ImageMasterDTO> ImageMasterDTO { get; set; }
        public DbSet<ModuleMasterDTO> ModuleMasterDTO { get; set; }
        public DbSet<ChainModuleMappingDTO> ChainModuleMappingDTO { get; set; }
        public DbSet<UserLogInOutDTO> UserLogInOutDTO { get; set; }
        public DbSet<EmailAccountDTO> EmailAccountDTO { get; set; }
        public DbSet<EmailQueueDTO> EmailQueueDTO { get; set; }
        public DbSet<EmailAttachmentDTO> EmailAttachmentDTO { get; set; }
        public DbSet<EmailTemplateDTO> EmailTemplateDTO { get; set; }
        public DbSet<RightsMasterDTO> RightsMasterDTO { get; set; }
        public DbSet<MenuMasterDTO> MenuMasterDTO { get; set; }
        public DbSet<MenuRightsMappingDTO> MenuRightsMappingDTO { get; set; }
        public DbSet<RoleRightsMasterDTO> RoleRightsMasterDTO { get; set; }
        public DbSet<UserRightsMasterDTO> UserRightsMasterDTO { get; set; }
        public DbSet<CountryMasterDDLDTO> CountryMasterDDLDTO { get; set; }
        public DbSet<CityMasterDTO> CityMasterDTO { get; set; }
        public DbSet<CountryMasterDTO> CountryMasterDTO { get; set; }
        public DbSet<VesselTripUploadDTO> VesselTripUploadDTO { get; set; }
        public DbSet<CustomerMasterDTO> CustomerMasterDTO { get; set; }
        public DbSet<CityMasterDDLDTO> CityMasterDDLDTO { get; set; }
        public DbSet<CompanyMasterDTO> CompanyMasterDTO { get; set; }
        public DbSet<VesselMasterDTO> VesselMasterDTO { get; set; }
        public DbSet<CSVFileDTO> CSVFileDTO { get; set; }
        public DbSet<ContainerMasterDTO> ContainerMasterDTO { get; set; }
        public DbSet<VesselTripUploadDetailsDTO> VesselTripUploadDetailsDTO { get; set; }
        public DbSet<PortMasterDTO> PortMasterDTO { get; set; }
        public DbSet<VesselMasterDDLDTO> VesselMasterDDLDTO { get; set; }

      public DbSet<SystemConfigDTO> SystemConfigDTO { get; set; }
        public DbSet<VesselTripDTO> VesselTripDTO { get; set; }
        public DbSet<PortMasterDDLDTO> PortMasterDDLDTO { get; set; }
        public DbSet<VesselNumberDDLDTO> VesselNumberDDLDTO { get; set; }
      
        public DbSet<VesselTripDTO> VesselTripMasterDTO { get; set; }

        public DbSet<VesselTripDetailDTO> VesselTripDetailDTO { get; set; }
        public DbSet<CustomerDetailDDLDTO> CustomerDetailDDLDTO { get; set; }

        public DbSet<CompanyMasterDDLDTO> CompanyMasterDDLDTO { get; set; }
        public DbSet<VesselTripAPIDTO> VesselTripAPIDTO { get; set; }
        public DbSet<UpdateVesselEndTripDTO> UpdateVesselEndTripDTO { get; set; }
        public DbSet<ContainerMasterDDLDTO> ContainerMasterDDLDTO { get; set; }

        public CRUDContext(DbContextOptions<CRUDContext> options) : base(options)
        {
            //this.Database.SetCommandTimeout(1000);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new RoleMasterMapper(modelBuilder.Entity<RoleMaster>());
            new ChainMasterMapper(modelBuilder.Entity<ChainMaster>());
            new UserMasterMapper(modelBuilder.Entity<UserMaster>());
            new BrandMasterMapper(modelBuilder.Entity<BrandMaster>());
            new UserProfileMapper(modelBuilder.Entity<UserProfile>());
            new ImageMasterMapper(modelBuilder.Entity<ImageMaster>());
            new ChainModuleMappingMapper(modelBuilder.Entity<ChainModuleMapping>());
            new UserLogInOutMapper(modelBuilder.Entity<UserLogInOut>());
            new EmailAccountMapper(modelBuilder.Entity<EmailAccount>());
            new EmailQueueMapper(modelBuilder.Entity<EmailQueue>());
            new EmailAttachmentMapper(modelBuilder.Entity<EmailAttachment>());
            new EmailTemplateMapper(modelBuilder.Entity<EmailTemplate>());
            new RightsMasterMapper(modelBuilder.Entity<RightsMaster>());
            new MenuMasterMapper(modelBuilder.Entity<MenuMaster>());
            new MenuRightsMappingMapper(modelBuilder.Entity<MenuRightsMapping>());
            new RoleRightsMasterMapper(modelBuilder.Entity<RoleRightsMaster>());
            new UserRightsMasterMapper(modelBuilder.Entity<UserRightsMaster>());
           
        }
    }
}