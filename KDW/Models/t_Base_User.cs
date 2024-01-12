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
    
    public partial class t_Base_User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public t_Base_User()
        {
            this.UsersKDW = new HashSet<UsersKDW>();
            this.HR_Base_User = new HashSet<HR_Base_User>();
        }
    
        public int FUserID { get; set; }
        public string FName { get; set; }
        public string FSID { get; set; }
        public short FPrimaryGroup { get; set; }
        public string FDescription { get; set; }
        public Nullable<bool> FForbidden { get; set; }
        public byte[] FRight { get; set; }
        public Nullable<int> FEmpID { get; set; }
        public Nullable<int> FDataVokeType { get; set; }
        public Nullable<bool> FIsNeedOffline { get; set; }
        public Nullable<bool> FRightChanged { get; set; }
        public Nullable<bool> FOfflineRefeshEachTime { get; set; }
        public Nullable<int> FSafeMode { get; set; }
        public Nullable<int> FHRUser { get; set; }
        public string FSSOUsername { get; set; }
        public string FSCPwd { get; set; }
        public Nullable<System.Guid> UUID { get; set; }
        public byte[] FModifyTime { get; set; }
        public Nullable<int> FAccessUUID { get; set; }
        public Nullable<System.DateTime> FUInValidDate { get; set; }
        public Nullable<System.DateTime> FPwCreateDate { get; set; }
        public Nullable<int> FPwValidDay { get; set; }
        public Nullable<int> FAuthRight { get; set; }
        public Nullable<int> FUserTypeID { get; set; }
        public string FPortUser { get; set; }
        public string FSupplierID { get; set; }
        public Nullable<int> FCustomerID { get; set; }
        public string FIMUserName { get; set; }
        public System.DateTime FCreateTime { get; set; }
        public string FSupUnit { get; set; }
        public Nullable<int> FYZJSafeMode { get; set; }
        public Nullable<bool> FFXMsgUser { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UsersKDW> UsersKDW { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HR_Base_User> HR_Base_User { get; set; }
    }
}
