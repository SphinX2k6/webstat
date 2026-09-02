using System;
using Aki.Config;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Role
{
	// Token: 0x020065D5 RID: 26069
	public class PinballRoleHeadItemData : IPinballRoleHeadItemData
	{
		// Token: 0x17009F05 RID: 40709
		// (get) Token: 0x06041206 RID: 266758 RVA: 0x010B54D3 File Offset: 0x010B36D3
		// (set) Token: 0x06041207 RID: 266759 RVA: 0x010B54DB File Offset: 0x010B36DB
		public PinballRoleConfig RoleConfig { get; set; }

		// Token: 0x17009F06 RID: 40710
		// (get) Token: 0x06041208 RID: 266760 RVA: 0x010B54E4 File Offset: 0x010B36E4
		// (set) Token: 0x06041209 RID: 266761 RVA: 0x010B54EC File Offset: 0x010B36EC
		public bool IsSelected { get; set; }

		// Token: 0x17009F07 RID: 40711
		// (get) Token: 0x0604120A RID: 266762 RVA: 0x010B54F5 File Offset: 0x010B36F5
		// (set) Token: 0x0604120B RID: 266763 RVA: 0x010B54FD File Offset: 0x010B36FD
		public bool IsLocked { get; set; }

		// Token: 0x17009F08 RID: 40712
		// (get) Token: 0x0604120C RID: 266764 RVA: 0x010B5506 File Offset: 0x010B3706
		// (set) Token: 0x0604120D RID: 266765 RVA: 0x010B550E File Offset: 0x010B370E
		public bool IsTrail { get; set; }

		// Token: 0x17009F09 RID: 40713
		// (get) Token: 0x0604120E RID: 266766 RVA: 0x010B5517 File Offset: 0x010B3717
		// (set) Token: 0x0604120F RID: 266767 RVA: 0x010B551F File Offset: 0x010B371F
		public bool NeedRedDot { get; set; }
	}
}
