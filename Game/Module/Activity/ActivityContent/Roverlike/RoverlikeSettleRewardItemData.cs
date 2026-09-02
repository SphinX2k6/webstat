using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x0200645E RID: 25694
	[NullableContext(1)]
	[Nullable(0)]
	public class RoverlikeSettleRewardItemData : IRoverlikeSettleRewardItemData
	{
		// Token: 0x17009E3B RID: 40507
		// (get) Token: 0x06040785 RID: 264069 RVA: 0x010854CA File Offset: 0x010836CA
		// (set) Token: 0x06040786 RID: 264070 RVA: 0x010854D2 File Offset: 0x010836D2
		public string IconPath { get; set; } = string.Empty;

		// Token: 0x17009E3C RID: 40508
		// (get) Token: 0x06040787 RID: 264071 RVA: 0x010854DB File Offset: 0x010836DB
		// (set) Token: 0x06040788 RID: 264072 RVA: 0x010854E3 File Offset: 0x010836E3
		public string NameTextId { get; set; } = string.Empty;

		// Token: 0x17009E3D RID: 40509
		// (get) Token: 0x06040789 RID: 264073 RVA: 0x010854EC File Offset: 0x010836EC
		// (set) Token: 0x0604078A RID: 264074 RVA: 0x010854F4 File Offset: 0x010836F4
		public int Num { get; set; }
	}
}
