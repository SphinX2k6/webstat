using System;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Settlement
{
	// Token: 0x020065BD RID: 26045
	public class DamageLayoutItemData : IDamageLayoutItemData
	{
		// Token: 0x17009EDF RID: 40671
		// (get) Token: 0x06041167 RID: 266599 RVA: 0x010B34EF File Offset: 0x010B16EF
		// (set) Token: 0x06041168 RID: 266600 RVA: 0x010B34F7 File Offset: 0x010B16F7
		public int RoleId { get; set; }

		// Token: 0x17009EE0 RID: 40672
		// (get) Token: 0x06041169 RID: 266601 RVA: 0x010B3500 File Offset: 0x010B1700
		// (set) Token: 0x0604116A RID: 266602 RVA: 0x010B3508 File Offset: 0x010B1708
		public float Damage { get; set; }

		// Token: 0x17009EE1 RID: 40673
		// (get) Token: 0x0604116B RID: 266603 RVA: 0x010B3511 File Offset: 0x010B1711
		// (set) Token: 0x0604116C RID: 266604 RVA: 0x010B3519 File Offset: 0x010B1719
		public bool IsWin { get; set; }
	}
}
