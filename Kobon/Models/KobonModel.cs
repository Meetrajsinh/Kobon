namespace Kobon.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class KobonModel : DbContext
    {
        public KobonModel()
            : base("name=KobonDb")
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<AvailGiftCard> AvailGiftCards { get; set; }
        public virtual DbSet<ClaimedOffer> ClaimedOffers { get; set; }
        public virtual DbSet<ClaimOffer> ClaimOffers { get; set; }
        public virtual DbSet<GiftCard> GiftCards { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<NotificationSetting> NotificationSettings { get; set; }
        public virtual DbSet<Offer> Offers { get; set; }
        public virtual DbSet<Receipt> Receipts { get; set; }
        public virtual DbSet<RequestForGiftCard> RequestForGiftCards { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<StoreReceiptDetail> StoreReceiptDetails { get; set; }
        public virtual DbSet<Wallet> Wallets { get; set; }
        public virtual DbSet<WalletTransaction> WalletTransactions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.EmailId)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.ReferralCode)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.HaveReferralCode)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.Token)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.UserType)
                .IsUnicode(false);

            modelBuilder.Entity<AvailGiftCard>()
                .Property(e => e.ClaimCode)
                .IsUnicode(false);

            modelBuilder.Entity<AvailGiftCard>()
                .Property(e => e.Value)
                .IsUnicode(false);

            modelBuilder.Entity<AvailGiftCard>()
                .Property(e => e.GiftCardStatus)
                .IsUnicode(false);

            modelBuilder.Entity<ClaimOffer>()
                .Property(e => e.CashBackAmount)
                .IsUnicode(false);

            modelBuilder.Entity<ClaimOffer>()
                .Property(e => e.ClaimingStatus)
                .IsUnicode(false);

            modelBuilder.Entity<GiftCard>()
                .Property(e => e.CompanyName)
                .IsUnicode(false);

            modelBuilder.Entity<GiftCard>()
                .Property(e => e.CompanyLogo)
                .IsUnicode(false);

            modelBuilder.Entity<GiftCard>()
                .Property(e => e.TermsAndConditions)
                .IsUnicode(false);

            modelBuilder.Entity<GiftCard>()
                .Property(e => e.Instructions)
                .IsUnicode(false);

            modelBuilder.Entity<Notification>()
                .Property(e => e.NotificationType)
                .IsUnicode(false);

            modelBuilder.Entity<Notification>()
                .Property(e => e.NotificationTitle)
                .IsUnicode(false);

            modelBuilder.Entity<Notification>()
                .Property(e => e.NotificationDesc)
                .IsUnicode(false);

            modelBuilder.Entity<Notification>()
                .Property(e => e.NotificationStatus)
                .IsUnicode(false);

            modelBuilder.Entity<NotificationSetting>()
                .Property(e => e.RemainderOnClaimOffer)
                .IsUnicode(false);

            modelBuilder.Entity<NotificationSetting>()
                .Property(e => e.OffersMyLocation)
                .IsUnicode(false);

            modelBuilder.Entity<NotificationSetting>()
                .Property(e => e.NewsUpdatesOffer)
                .IsUnicode(false);

            modelBuilder.Entity<NotificationSetting>()
                .Property(e => e.CashbackOffers)
                .IsUnicode(false);

            modelBuilder.Entity<NotificationSetting>()
                .Property(e => e.CashbackReferrals)
                .IsUnicode(false);

            modelBuilder.Entity<NotificationSetting>()
                .Property(e => e.CashbackEarnedByReferrer)
                .IsUnicode(false);

            modelBuilder.Entity<Offer>()
                .Property(e => e.ProductName)
                .IsUnicode(false);

            modelBuilder.Entity<Offer>()
                .Property(e => e.OriginalPrice)
                .IsUnicode(false);

            modelBuilder.Entity<Offer>()
                .Property(e => e.DiscountPrice)
                .IsUnicode(false);

            modelBuilder.Entity<Offer>()
                .Property(e => e.OfferDescription)
                .IsUnicode(false);

            modelBuilder.Entity<Offer>()
                .Property(e => e.Duration)
                .IsUnicode(false);

            modelBuilder.Entity<Offer>()
                .Property(e => e.PaymentMethod)
                .IsUnicode(false);

            modelBuilder.Entity<Offer>()
                .Property(e => e.OfferStatus)
                .IsUnicode(false);

            modelBuilder.Entity<Receipt>()
                .Property(e => e.ReceiptFields)
                .IsUnicode(false);

            modelBuilder.Entity<Receipt>()
                .Property(e => e.ReceiptInfo)
                .IsUnicode(false);

            modelBuilder.Entity<Receipt>()
                .Property(e => e.FilePath)
                .IsUnicode(false);

            modelBuilder.Entity<Receipt>()
                .Property(e => e.ReceiptStatus)
                .IsUnicode(false);

            modelBuilder.Entity<RequestForGiftCard>()
                .Property(e => e.DeliverEmail)
                .IsUnicode(false);

            modelBuilder.Entity<RequestForGiftCard>()
                .Property(e => e.RequestStatus)
                .IsUnicode(false);

            modelBuilder.Entity<Store>()
                .Property(e => e.StoreName)
                .IsUnicode(false);

            modelBuilder.Entity<Store>()
                .Property(e => e.StoreLogo)
                .IsUnicode(false);

            modelBuilder.Entity<Store>()
                .Property(e => e.TypeOfStore)
                .IsUnicode(false);

            modelBuilder.Entity<Store>()
                .Property(e => e.StoreAddress)
                .IsUnicode(false);

            modelBuilder.Entity<Store>()
                .Property(e => e.Latitude)
                .IsUnicode(false);

            modelBuilder.Entity<Store>()
                .Property(e => e.Longitude)
                .IsUnicode(false);

            modelBuilder.Entity<Store>()
                .Property(e => e.Website)
                .IsUnicode(false);

            modelBuilder.Entity<StoreReceiptDetail>()
                .Property(e => e.TypeOfStore)
                .IsUnicode(false);

            modelBuilder.Entity<StoreReceiptDetail>()
                .Property(e => e.Fields)
                .IsUnicode(false);

            modelBuilder.Entity<Wallet>()
                .Property(e => e.Amount)
                .IsUnicode(false);

            modelBuilder.Entity<WalletTransaction>()
                .Property(e => e.TransactionType)
                .IsUnicode(false);

            modelBuilder.Entity<WalletTransaction>()
                .Property(e => e.TransactionDesc)
                .IsUnicode(false);

            modelBuilder.Entity<WalletTransaction>()
                .Property(e => e.Amount)
                .IsUnicode(false);
        }
    }
}
