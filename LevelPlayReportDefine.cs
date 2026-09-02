using System;
using System.Runtime.CompilerServices;

// Token: 0x020020B4 RID: 8372
public class LevelPlayReportDefine
{
	// Token: 0x0200843D RID: 33853
	public enum ELevelPlayReportState
	{
		// Token: 0x0402CD23 RID: 183587
		Close,
		// Token: 0x0402CD24 RID: 183588
		Wait,
		// Token: 0x0402CD25 RID: 183589
		Open,
		// Token: 0x0402CD26 RID: 183590
		Finish,
		// Token: 0x0402CD27 RID: 183591
		AllPlayerGetReward,
		// Token: 0x0402CD28 RID: 183592
		Hide
	}

	// Token: 0x0200843E RID: 33854
	[NullableContext(1)]
	public interface ILevelPlayReportConfigData
	{
		// Token: 0x1700A843 RID: 43075
		// (get) Token: 0x0604890A RID: 297226
		// (set) Token: 0x0604890B RID: 297227
		int LevelPlayId { get; set; }

		// Token: 0x1700A844 RID: 43076
		// (get) Token: 0x0604890C RID: 297228
		// (set) Token: 0x0604890D RID: 297229
		string[] Vars { get; set; }

		// Token: 0x1700A845 RID: 43077
		// (get) Token: 0x0604890E RID: 297230
		// (set) Token: 0x0604890F RID: 297231
		int[] Chests { get; set; }

		// Token: 0x1700A846 RID: 43078
		// (get) Token: 0x06048910 RID: 297232
		// (set) Token: 0x06048911 RID: 297233
		int Type { get; set; }

		// Token: 0x1700A847 RID: 43079
		// (get) Token: 0x06048912 RID: 297234
		// (set) Token: 0x06048913 RID: 297235
		string[] Descs { get; set; }

		// Token: 0x1700A848 RID: 43080
		// (get) Token: 0x06048914 RID: 297236
		// (set) Token: 0x06048915 RID: 297237
		string GetBoxNumKey { get; set; }
	}

	// Token: 0x0200843F RID: 33855
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelPlayReportConfigData : LevelPlayReportDefine.ILevelPlayReportConfigData
	{
		// Token: 0x1700A849 RID: 43081
		// (get) Token: 0x06048916 RID: 297238 RVA: 0x0137E3EE File Offset: 0x0137C5EE
		// (set) Token: 0x06048917 RID: 297239 RVA: 0x0137E3F6 File Offset: 0x0137C5F6
		public int LevelPlayId { get; set; }

		// Token: 0x1700A84A RID: 43082
		// (get) Token: 0x06048918 RID: 297240 RVA: 0x0137E3FF File Offset: 0x0137C5FF
		// (set) Token: 0x06048919 RID: 297241 RVA: 0x0137E407 File Offset: 0x0137C607
		public string[] Vars { get; set; }

		// Token: 0x1700A84B RID: 43083
		// (get) Token: 0x0604891A RID: 297242 RVA: 0x0137E410 File Offset: 0x0137C610
		// (set) Token: 0x0604891B RID: 297243 RVA: 0x0137E418 File Offset: 0x0137C618
		public int[] Chests { get; set; }

		// Token: 0x1700A84C RID: 43084
		// (get) Token: 0x0604891C RID: 297244 RVA: 0x0137E421 File Offset: 0x0137C621
		// (set) Token: 0x0604891D RID: 297245 RVA: 0x0137E429 File Offset: 0x0137C629
		public int Type { get; set; }

		// Token: 0x1700A84D RID: 43085
		// (get) Token: 0x0604891E RID: 297246 RVA: 0x0137E432 File Offset: 0x0137C632
		// (set) Token: 0x0604891F RID: 297247 RVA: 0x0137E43A File Offset: 0x0137C63A
		public string[] Descs { get; set; }

		// Token: 0x1700A84E RID: 43086
		// (get) Token: 0x06048920 RID: 297248 RVA: 0x0137E443 File Offset: 0x0137C643
		// (set) Token: 0x06048921 RID: 297249 RVA: 0x0137E44B File Offset: 0x0137C64B
		public string GetBoxNumKey { get; set; }
	}
}
