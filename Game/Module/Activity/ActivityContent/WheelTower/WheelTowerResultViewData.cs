using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.WheelTower
{
	// Token: 0x0200621A RID: 25114
	[NullableContext(2)]
	[Nullable(0)]
	public class WheelTowerResultViewData : IWheelTowerResultViewData
	{
		// Token: 0x17009BE5 RID: 39909
		// (get) Token: 0x0603F5CD RID: 259533 RVA: 0x0103EBD7 File Offset: 0x0103CDD7
		// (set) Token: 0x0603F5CE RID: 259534 RVA: 0x0103EBDF File Offset: 0x0103CDDF
		public bool EndlessMode { get; set; }

		// Token: 0x17009BE6 RID: 39910
		// (get) Token: 0x0603F5CF RID: 259535 RVA: 0x0103EBE8 File Offset: 0x0103CDE8
		// (set) Token: 0x0603F5D0 RID: 259536 RVA: 0x0103EBF0 File Offset: 0x0103CDF0
		public int TotalRound { get; set; }

		// Token: 0x17009BE7 RID: 39911
		// (get) Token: 0x0603F5D1 RID: 259537 RVA: 0x0103EBF9 File Offset: 0x0103CDF9
		// (set) Token: 0x0603F5D2 RID: 259538 RVA: 0x0103EC01 File Offset: 0x0103CE01
		public int CurrentRound { get; set; }

		// Token: 0x17009BE8 RID: 39912
		// (get) Token: 0x0603F5D3 RID: 259539 RVA: 0x0103EC0A File Offset: 0x0103CE0A
		// (set) Token: 0x0603F5D4 RID: 259540 RVA: 0x0103EC12 File Offset: 0x0103CE12
		public int TotalScore { get; set; }

		// Token: 0x17009BE9 RID: 39913
		// (get) Token: 0x0603F5D5 RID: 259541 RVA: 0x0103EC1B File Offset: 0x0103CE1B
		// (set) Token: 0x0603F5D6 RID: 259542 RVA: 0x0103EC23 File Offset: 0x0103CE23
		public int CurrentScore { get; set; }

		// Token: 0x17009BEA RID: 39914
		// (get) Token: 0x0603F5D7 RID: 259543 RVA: 0x0103EC2C File Offset: 0x0103CE2C
		// (set) Token: 0x0603F5D8 RID: 259544 RVA: 0x0103EC34 File Offset: 0x0103CE34
		[Nullable(1)]
		public List<IBossItemData> BossInfoList { [NullableContext(1)] get; [NullableContext(1)] set; } = new List<IBossItemData>();

		// Token: 0x17009BEB RID: 39915
		// (get) Token: 0x0603F5D9 RID: 259545 RVA: 0x0103EC3D File Offset: 0x0103CE3D
		// (set) Token: 0x0603F5DA RID: 259546 RVA: 0x0103EC45 File Offset: 0x0103CE45
		public IWheelTowerResultViewButtonData LeftButtonData { get; set; }

		// Token: 0x17009BEC RID: 39916
		// (get) Token: 0x0603F5DB RID: 259547 RVA: 0x0103EC4E File Offset: 0x0103CE4E
		// (set) Token: 0x0603F5DC RID: 259548 RVA: 0x0103EC56 File Offset: 0x0103CE56
		public IWheelTowerResultViewButtonData CenterButtonData { get; set; }

		// Token: 0x17009BED RID: 39917
		// (get) Token: 0x0603F5DD RID: 259549 RVA: 0x0103EC5F File Offset: 0x0103CE5F
		// (set) Token: 0x0603F5DE RID: 259550 RVA: 0x0103EC67 File Offset: 0x0103CE67
		public IWheelTowerResultViewButtonData RightButtonData { get; set; }

		// Token: 0x17009BEE RID: 39918
		// (get) Token: 0x0603F5DF RID: 259551 RVA: 0x0103EC70 File Offset: 0x0103CE70
		// (set) Token: 0x0603F5E0 RID: 259552 RVA: 0x0103EC78 File Offset: 0x0103CE78
		public bool? ShowEndlessUnlockTips { get; set; }
	}
}
