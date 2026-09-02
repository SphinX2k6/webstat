using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.ItemReward
{
	// Token: 0x02005B29 RID: 23337
	[NullableContext(1)]
	[Nullable(0)]
	public class RewardExploreFriendData : IRewardExploreFriendData
	{
		// Token: 0x170096FD RID: 38653
		// (get) Token: 0x0603B0C3 RID: 241859 RVA: 0x00EF28A8 File Offset: 0x00EF0AA8
		// (set) Token: 0x0603B0C4 RID: 241860 RVA: 0x00EF28B0 File Offset: 0x00EF0AB0
		public string PlayerDesc { get; set; }

		// Token: 0x170096FE RID: 38654
		// (get) Token: 0x0603B0C5 RID: 241861 RVA: 0x00EF28B9 File Offset: 0x00EF0AB9
		// (set) Token: 0x0603B0C6 RID: 241862 RVA: 0x00EF28C1 File Offset: 0x00EF0AC1
		public string PlayerName { get; set; }

		// Token: 0x170096FF RID: 38655
		// (get) Token: 0x0603B0C7 RID: 241863 RVA: 0x00EF28CA File Offset: 0x00EF0ACA
		// (set) Token: 0x0603B0C8 RID: 241864 RVA: 0x00EF28D2 File Offset: 0x00EF0AD2
		public string PlayerIndexPath { get; set; }

		// Token: 0x17009700 RID: 38656
		// (get) Token: 0x0603B0C9 RID: 241865 RVA: 0x00EF28DB File Offset: 0x00EF0ADB
		// (set) Token: 0x0603B0CA RID: 241866 RVA: 0x00EF28E3 File Offset: 0x00EF0AE3
		public string PlayerIconPath { get; set; }

		// Token: 0x17009701 RID: 38657
		// (get) Token: 0x0603B0CB RID: 241867 RVA: 0x00EF28EC File Offset: 0x00EF0AEC
		// (set) Token: 0x0603B0CC RID: 241868 RVA: 0x00EF28F4 File Offset: 0x00EF0AF4
		public int PlayerId { get; set; }

		// Token: 0x17009702 RID: 38658
		// (get) Token: 0x0603B0CD RID: 241869 RVA: 0x00EF28FD File Offset: 0x00EF0AFD
		// (set) Token: 0x0603B0CE RID: 241870 RVA: 0x00EF2905 File Offset: 0x00EF0B05
		public int PlayerLevel { get; set; }

		// Token: 0x17009703 RID: 38659
		// (get) Token: 0x0603B0CF RID: 241871 RVA: 0x00EF290E File Offset: 0x00EF0B0E
		// (set) Token: 0x0603B0D0 RID: 241872 RVA: 0x00EF2916 File Offset: 0x00EF0B16
		public bool IsMyFriend { get; set; }

		// Token: 0x17009704 RID: 38660
		// (get) Token: 0x0603B0D1 RID: 241873 RVA: 0x00EF291F File Offset: 0x00EF0B1F
		// (set) Token: 0x0603B0D2 RID: 241874 RVA: 0x00EF2927 File Offset: 0x00EF0B27
		public Action<int> OnClickCallback { get; set; }
	}
}
