using System;

namespace CSharpScript.Game.Module.Cook
{
	// Token: 0x02005E01 RID: 24065
	public class CookingData : ICookingData, ICookItemData
	{
		// Token: 0x170098ED RID: 39149
		// (get) Token: 0x0603C8F1 RID: 248049 RVA: 0x00F621BF File Offset: 0x00F603BF
		// (set) Token: 0x0603C8F2 RID: 248050 RVA: 0x00F621C7 File Offset: 0x00F603C7
		public ECookListType MainType { get; set; }

		// Token: 0x170098EE RID: 39150
		// (get) Token: 0x0603C8F3 RID: 248051 RVA: 0x00F621D0 File Offset: 0x00F603D0
		// (set) Token: 0x0603C8F4 RID: 248052 RVA: 0x00F621D8 File Offset: 0x00F603D8
		public int ItemId { get; set; }

		// Token: 0x170098EF RID: 39151
		// (get) Token: 0x0603C8F5 RID: 248053 RVA: 0x00F621E1 File Offset: 0x00F603E1
		// (set) Token: 0x0603C8F6 RID: 248054 RVA: 0x00F621E9 File Offset: 0x00F603E9
		public bool IsNew { get; set; }

		// Token: 0x170098F0 RID: 39152
		// (get) Token: 0x0603C8F7 RID: 248055 RVA: 0x00F621F2 File Offset: 0x00F603F2
		// (set) Token: 0x0603C8F8 RID: 248056 RVA: 0x00F621FA File Offset: 0x00F603FA
		public int Quality { get; set; }

		// Token: 0x170098F1 RID: 39153
		// (get) Token: 0x0603C8F9 RID: 248057 RVA: 0x00F62203 File Offset: 0x00F60403
		// (set) Token: 0x0603C8FA RID: 248058 RVA: 0x00F6220B File Offset: 0x00F6040B
		public bool IsUnLock { get; set; }

		// Token: 0x170098F2 RID: 39154
		// (get) Token: 0x0603C8FB RID: 248059 RVA: 0x00F62214 File Offset: 0x00F60414
		// (set) Token: 0x0603C8FC RID: 248060 RVA: 0x00F6221C File Offset: 0x00F6041C
		public ESubCookDataType SubType { get; set; }

		// Token: 0x170098F3 RID: 39155
		// (get) Token: 0x0603C8FD RID: 248061 RVA: 0x00F62225 File Offset: 0x00F60425
		// (set) Token: 0x0603C8FE RID: 248062 RVA: 0x00F6222D File Offset: 0x00F6042D
		public int UniqueId { get; set; }

		// Token: 0x170098F4 RID: 39156
		// (get) Token: 0x0603C8FF RID: 248063 RVA: 0x00F62236 File Offset: 0x00F60436
		// (set) Token: 0x0603C900 RID: 248064 RVA: 0x00F6223E File Offset: 0x00F6043E
		public int CookCount { get; set; }

		// Token: 0x170098F5 RID: 39157
		// (get) Token: 0x0603C901 RID: 248065 RVA: 0x00F62247 File Offset: 0x00F60447
		// (set) Token: 0x0603C902 RID: 248066 RVA: 0x00F6224F File Offset: 0x00F6044F
		public int? LastRoleId { get; set; }

		// Token: 0x170098F6 RID: 39158
		// (get) Token: 0x0603C903 RID: 248067 RVA: 0x00F62258 File Offset: 0x00F60458
		// (set) Token: 0x0603C904 RID: 248068 RVA: 0x00F62260 File Offset: 0x00F60460
		public int IsCook { get; set; }

		// Token: 0x170098F7 RID: 39159
		// (get) Token: 0x0603C905 RID: 248069 RVA: 0x00F62269 File Offset: 0x00F60469
		// (set) Token: 0x0603C906 RID: 248070 RVA: 0x00F62271 File Offset: 0x00F60471
		public int EffectType { get; set; }

		// Token: 0x170098F8 RID: 39160
		// (get) Token: 0x0603C907 RID: 248071 RVA: 0x00F6227A File Offset: 0x00F6047A
		// (set) Token: 0x0603C908 RID: 248072 RVA: 0x00F62282 File Offset: 0x00F60482
		public int DataId { get; set; }

		// Token: 0x170098F9 RID: 39161
		// (get) Token: 0x0603C909 RID: 248073 RVA: 0x00F6228B File Offset: 0x00F6048B
		// (set) Token: 0x0603C90A RID: 248074 RVA: 0x00F62293 File Offset: 0x00F60493
		public int LimitTotalCount { get; set; }

		// Token: 0x170098FA RID: 39162
		// (get) Token: 0x0603C90B RID: 248075 RVA: 0x00F6229C File Offset: 0x00F6049C
		// (set) Token: 0x0603C90C RID: 248076 RVA: 0x00F622A4 File Offset: 0x00F604A4
		public int LimitedCount { get; set; }

		// Token: 0x170098FB RID: 39163
		// (get) Token: 0x0603C90D RID: 248077 RVA: 0x00F622AD File Offset: 0x00F604AD
		// (set) Token: 0x0603C90E RID: 248078 RVA: 0x00F622B5 File Offset: 0x00F604B5
		public double ExistStartTime { get; set; }

		// Token: 0x170098FC RID: 39164
		// (get) Token: 0x0603C90F RID: 248079 RVA: 0x00F622BE File Offset: 0x00F604BE
		// (set) Token: 0x0603C910 RID: 248080 RVA: 0x00F622C6 File Offset: 0x00F604C6
		public double ExistEndTime { get; set; }
	}
}
