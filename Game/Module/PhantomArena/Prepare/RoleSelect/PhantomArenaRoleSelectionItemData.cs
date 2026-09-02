using System;

namespace CSharpScript.Game.Module.PhantomArena.Prepare.RoleSelect
{
	// Token: 0x020054B5 RID: 21685
	public class PhantomArenaRoleSelectionItemData : IPhantomArenaRoleSelectionItemData
	{
		// Token: 0x17008E81 RID: 36481
		// (get) Token: 0x060373C1 RID: 226241 RVA: 0x00E0301E File Offset: 0x00E0121E
		// (set) Token: 0x060373C2 RID: 226242 RVA: 0x00E03026 File Offset: 0x00E01226
		public int CardRoleId { get; set; }

		// Token: 0x17008E82 RID: 36482
		// (get) Token: 0x060373C3 RID: 226243 RVA: 0x00E0302F File Offset: 0x00E0122F
		// (set) Token: 0x060373C4 RID: 226244 RVA: 0x00E03037 File Offset: 0x00E01237
		public bool CanReceived { get; set; }

		// Token: 0x17008E83 RID: 36483
		// (get) Token: 0x060373C5 RID: 226245 RVA: 0x00E03040 File Offset: 0x00E01240
		// (set) Token: 0x060373C6 RID: 226246 RVA: 0x00E03048 File Offset: 0x00E01248
		public bool IsLocked { get; set; }

		// Token: 0x17008E84 RID: 36484
		// (get) Token: 0x060373C7 RID: 226247 RVA: 0x00E03051 File Offset: 0x00E01251
		// (set) Token: 0x060373C8 RID: 226248 RVA: 0x00E03059 File Offset: 0x00E01259
		public bool CanSelect { get; set; }
	}
}
