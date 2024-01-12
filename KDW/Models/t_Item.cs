//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KDW.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class t_Item
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public t_Item()
        {
            this.POOrderEntry = new HashSet<POOrderEntry>();
            this.ICMO = new HashSet<ICMO>();
            this.NomenklaturaEnterprise = new HashSet<NomenklaturaEnterprise>();
            this.StocksRusKit = new HashSet<StocksRusKit>();
            this.STOCKinMOL = new HashSet<StocksMOL>();
            this.ICInventory = new HashSet<ICInventory>();
            this.MOLinStock = new HashSet<StocksMOL>();
            this.PPBOM = new HashSet<PPBOM>();
            this.PPBOMEntry = new HashSet<PPBOMEntry>();
            this.ICStockBillEntry = new HashSet<ICStockBillEntry>();
            this.Dvigenie = new HashSet<Dvigenie>();
            this.DvigenieStock = new HashSet<Dvigenie>();
            this.DepartmentsToUsers = new HashSet<DepartmentsToUsers>();
            this.DepartmentsToUsers1 = new HashSet<DepartmentsToUsers>();
            this.StarMehWorks = new HashSet<StarMehWorks>();
            this.OcheredWorks = new HashSet<OcheredWorks>();
            this.OcheredWorksDepartment = new HashSet<OcheredWorks>();
            this.DepartmentToLine = new HashSet<DepartmentToLine>();
            this.DepartmentToLineDepartment = new HashSet<DepartmentToLine>();
            this.MolsOfDepartments = new HashSet<MolsOfDepartments>();
            this.MolsOfDepartmentsMOL = new HashSet<MolsOfDepartments>();
            this.NZP = new HashSet<NZP>();
            this.NZPStock = new HashSet<NZP>();
            this.NZPDepartment = new HashSet<NZP>();
            this.Komplekt = new HashSet<Komplekt>();
            this.NomenklaturaPlace = new HashSet<NomenklaturaPlace>();
            this.ICSubContractEntry = new HashSet<ICSubContractEntry>();
            this.ICSubContractDepartment = new HashSet<ICSubContract>();
            this.DepartmentToStocks = new HashSet<DepartmentToStocks>();
            this.DepartmentToStocksStock = new HashSet<DepartmentToStocks>();
            this.DepartmentToStocksMOL = new HashSet<DepartmentToStocks>();
            this.StockMol = new HashSet<DepartmentToStocks>();
            this.MOL = new HashSet<t_User>();
            this.UsersKDW = new HashSet<UsersKDW>();
            this.StockPriem = new HashSet<StockPriem>();
            this.StockWorkEntrys = new HashSet<StockWorkEntrys>();
            this.StockWorkEntrys1 = new HashSet<StockWorkEntrys>();
            this.t_ICItem = new HashSet<t_ICItem>();
            this.InventVedomost = new HashSet<InventVedomost>();
            this.PeremeshenieWorks = new HashSet<PeremeshenieWorks>();
            this.ICBOMChild = new HashSet<ICBOMChild>();
            this.PostuplenieNaSklad = new HashSet<PostuplenieNaSklad>();
            this.DvigenieNEW = new HashSet<DvigenieNEW>();
        }
    
        public int FItemID { get; set; }
        public int FItemClassID { get; set; }
        public int FExternID { get; set; }
        public string FNumber { get; set; }
        public int FParentID { get; set; }
        public short FLevel { get; set; }
        public bool FDetail { get; set; }
        public string FName { get; set; }
        public Nullable<bool> FUnUsed { get; set; }
        public string FBrNo { get; set; }
        public string FFullNumber { get; set; }
        public bool FDiff { get; set; }
        public short FDeleted { get; set; }
        public string FShortNumber { get; set; }
        public string FFullName { get; set; }
        public System.Guid UUID { get; set; }
        public int FGRCommonID { get; set; }
        public int FSystemType { get; set; }
        public int FUseSign { get; set; }
        public Nullable<int> FChkUserID { get; set; }
        public short FAccessory { get; set; }
        public int FGrControl { get; set; }
        public byte[] FModifyTime { get; set; }
        public short FHavePicture { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<POOrderEntry> POOrderEntry { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ICMO> ICMO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NomenklaturaEnterprise> NomenklaturaEnterprise { get; set; }
        public virtual t_Stock t_Stock { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StocksRusKit> StocksRusKit { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StocksMOL> STOCKinMOL { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ICInventory> ICInventory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StocksMOL> MOLinStock { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PPBOM> PPBOM { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PPBOMEntry> PPBOMEntry { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ICStockBillEntry> ICStockBillEntry { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Dvigenie> Dvigenie { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Dvigenie> DvigenieStock { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DepartmentsToUsers> DepartmentsToUsers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DepartmentsToUsers> DepartmentsToUsers1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StarMehWorks> StarMehWorks { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OcheredWorks> OcheredWorks { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OcheredWorks> OcheredWorksDepartment { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DepartmentToLine> DepartmentToLine { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DepartmentToLine> DepartmentToLineDepartment { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MolsOfDepartments> MolsOfDepartments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MolsOfDepartments> MolsOfDepartmentsMOL { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NZP> NZP { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NZP> NZPStock { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NZP> NZPDepartment { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Komplekt> Komplekt { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NomenklaturaPlace> NomenklaturaPlace { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ICSubContractEntry> ICSubContractEntry { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ICSubContract> ICSubContractDepartment { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DepartmentToStocks> DepartmentToStocks { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DepartmentToStocks> DepartmentToStocksStock { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DepartmentToStocks> DepartmentToStocksMOL { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DepartmentToStocks> StockMol { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_User> MOL { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UsersKDW> UsersKDW { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StockPriem> StockPriem { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StockWorkEntrys> StockWorkEntrys { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StockWorkEntrys> StockWorkEntrys1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_ICItem> t_ICItem { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InventVedomost> InventVedomost { get; set; }
        public virtual t_ICItemMaterial t_ICItemMaterial { get; set; }
        public virtual LastDvigs LastDvigs { get; set; }
        public virtual t_ICItemMaterial t_ICItemMaterial1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PeremeshenieWorks> PeremeshenieWorks { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ICBOMChild> ICBOMChild { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PostuplenieNaSklad> PostuplenieNaSklad { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DvigenieNEW> DvigenieNEW { get; set; }
    }
}