using System;

namespace CSharpScript.Game.Module.PhantomArena.Prepare.RoleSelect
{
	// Token: 0x020054B4 RID: 21684
	public interface IPhantomArenaRoleSelectionItemData
	{
		// Token: 0x17008E7D RID: 36477
		// (get) Token: 0x060373B9 RID: 226233
		// (set) Token: 0x060373BA RID: 226234
		int CardRoleId { get; set; }

		// Token: 0x17008E7E RID: 36478
		// (get) Token: 0x060373BB RID: 226235
		// (set) Token: 0x060373BC RID: 226236
		bool CanReceived { get; set; }

		// Token: 0x17008E7F RID: 36479
		// (get) Token: 0x060373BD RID: 226237
		// (set) Token: 0x060373BE RID: 226238
		bool IsLocked { get; set; }

		// Token: 0x17008E80 RID: 36480
		// (get) Token: 0x060373BF RID: 226239
		// (set) Token: 0x060373C0 RID: 226240
		bool CanSelect { get; set; }
	}
}
