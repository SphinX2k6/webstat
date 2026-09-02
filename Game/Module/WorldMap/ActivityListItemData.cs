using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.WorldMap
{
	// Token: 0x02004B39 RID: 19257
	[NullableContext(1)]
	[Nullable(0)]
	public class ActivityListItemData : IActivityListItemData
	{
		// Token: 0x17008617 RID: 34327
		// (get) Token: 0x060323C0 RID: 205760 RVA: 0x00C8FB70 File Offset: 0x00C8DD70
		// (set) Token: 0x060323C1 RID: 205761 RVA: 0x00C8FB78 File Offset: 0x00C8DD78
		public EMapPeriodicActivityId Id { get; set; }

		// Token: 0x17008618 RID: 34328
		// (get) Token: 0x060323C2 RID: 205762 RVA: 0x00C8FB81 File Offset: 0x00C8DD81
		// (set) Token: 0x060323C3 RID: 205763 RVA: 0x00C8FB89 File Offset: 0x00C8DD89
		public double LeftTime { get; set; }

		// Token: 0x17008619 RID: 34329
		// (get) Token: 0x060323C4 RID: 205764 RVA: 0x00C8FB92 File Offset: 0x00C8DD92
		// (set) Token: 0x060323C5 RID: 205765 RVA: 0x00C8FB9A File Offset: 0x00C8DD9A
		public string LeftTimeText { get; set; }

		// Token: 0x1700861A RID: 34330
		// (get) Token: 0x060323C6 RID: 205766 RVA: 0x00C8FBA3 File Offset: 0x00C8DDA3
		// (set) Token: 0x060323C7 RID: 205767 RVA: 0x00C8FBAB File Offset: 0x00C8DDAB
		public int CurrentNum { get; set; }

		// Token: 0x1700861B RID: 34331
		// (get) Token: 0x060323C8 RID: 205768 RVA: 0x00C8FBB4 File Offset: 0x00C8DDB4
		// (set) Token: 0x060323C9 RID: 205769 RVA: 0x00C8FBBC File Offset: 0x00C8DDBC
		public int TotalNum { get; set; }

		// Token: 0x1700861C RID: 34332
		// (get) Token: 0x060323CA RID: 205770 RVA: 0x00C8FBC5 File Offset: 0x00C8DDC5
		// (set) Token: 0x060323CB RID: 205771 RVA: 0x00C8FBCD File Offset: 0x00C8DDCD
		public bool IsFinish { get; set; }

		// Token: 0x1700861D RID: 34333
		// (get) Token: 0x060323CC RID: 205772 RVA: 0x00C8FBD6 File Offset: 0x00C8DDD6
		// (set) Token: 0x060323CD RID: 205773 RVA: 0x00C8FBDE File Offset: 0x00C8DDDE
		public bool RedPoint { get; set; }

		// Token: 0x1700861E RID: 34334
		// (get) Token: 0x060323CE RID: 205774 RVA: 0x00C8FBE7 File Offset: 0x00C8DDE7
		// (set) Token: 0x060323CF RID: 205775 RVA: 0x00C8FBEF File Offset: 0x00C8DDEF
		public Action OnClickCb { get; set; }

		// Token: 0x1700861F RID: 34335
		// (get) Token: 0x060323D0 RID: 205776 RVA: 0x00C8FBF8 File Offset: 0x00C8DDF8
		// (set) Token: 0x060323D1 RID: 205777 RVA: 0x00C8FC00 File Offset: 0x00C8DE00
		public Action<IActivityListItemData> OnLeftTimeRefreshCb { get; set; }
	}
}
