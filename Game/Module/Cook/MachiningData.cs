using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Cook
{
	// Token: 0x02005E03 RID: 24067
	[NullableContext(1)]
	[Nullable(0)]
	public class MachiningData : IMachiningData, ICookItemData
	{
		// Token: 0x17009900 RID: 39168
		// (get) Token: 0x0603C918 RID: 248088 RVA: 0x00F622D7 File Offset: 0x00F604D7
		// (set) Token: 0x0603C919 RID: 248089 RVA: 0x00F622DF File Offset: 0x00F604DF
		public ECookListType MainType { get; set; }

		// Token: 0x17009901 RID: 39169
		// (get) Token: 0x0603C91A RID: 248090 RVA: 0x00F622E8 File Offset: 0x00F604E8
		// (set) Token: 0x0603C91B RID: 248091 RVA: 0x00F622F0 File Offset: 0x00F604F0
		public int ItemId { get; set; }

		// Token: 0x17009902 RID: 39170
		// (get) Token: 0x0603C91C RID: 248092 RVA: 0x00F622F9 File Offset: 0x00F604F9
		// (set) Token: 0x0603C91D RID: 248093 RVA: 0x00F62301 File Offset: 0x00F60501
		public bool IsNew { get; set; }

		// Token: 0x17009903 RID: 39171
		// (get) Token: 0x0603C91E RID: 248094 RVA: 0x00F6230A File Offset: 0x00F6050A
		// (set) Token: 0x0603C91F RID: 248095 RVA: 0x00F62312 File Offset: 0x00F60512
		public int Quality { get; set; }

		// Token: 0x17009904 RID: 39172
		// (get) Token: 0x0603C920 RID: 248096 RVA: 0x00F6231B File Offset: 0x00F6051B
		// (set) Token: 0x0603C921 RID: 248097 RVA: 0x00F62323 File Offset: 0x00F60523
		public bool IsUnLock { get; set; }

		// Token: 0x17009905 RID: 39173
		// (get) Token: 0x0603C922 RID: 248098 RVA: 0x00F6232C File Offset: 0x00F6052C
		// (set) Token: 0x0603C923 RID: 248099 RVA: 0x00F62334 File Offset: 0x00F60534
		public List<int> InteractiveList { get; set; }

		// Token: 0x17009906 RID: 39174
		// (get) Token: 0x0603C924 RID: 248100 RVA: 0x00F6233D File Offset: 0x00F6053D
		// (set) Token: 0x0603C925 RID: 248101 RVA: 0x00F62345 File Offset: 0x00F60545
		public List<int> UnlockList { get; set; }

		// Token: 0x17009907 RID: 39175
		// (get) Token: 0x0603C926 RID: 248102 RVA: 0x00F6234E File Offset: 0x00F6054E
		// (set) Token: 0x0603C927 RID: 248103 RVA: 0x00F62356 File Offset: 0x00F60556
		public int IsMachining { get; set; }
	}
}
