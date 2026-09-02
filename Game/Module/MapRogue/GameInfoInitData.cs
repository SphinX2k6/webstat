using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.MapRogue
{
	// Token: 0x0200590A RID: 22794
	[NullableContext(1)]
	[Nullable(0)]
	public class GameInfoInitData : IGameInfoInitData
	{
		// Token: 0x170093EE RID: 37870
		// (get) Token: 0x06039D6F RID: 236911 RVA: 0x00EA4C0F File Offset: 0x00EA2E0F
		// (set) Token: 0x06039D70 RID: 236912 RVA: 0x00EA4C17 File Offset: 0x00EA2E17
		public int InstanceId { get; set; }

		// Token: 0x170093EF RID: 37871
		// (get) Token: 0x06039D71 RID: 236913 RVA: 0x00EA4C20 File Offset: 0x00EA2E20
		// (set) Token: 0x06039D72 RID: 236914 RVA: 0x00EA4C28 File Offset: 0x00EA2E28
		public int RandomSeed { get; set; }

		// Token: 0x170093F0 RID: 37872
		// (get) Token: 0x06039D73 RID: 236915 RVA: 0x00EA4C31 File Offset: 0x00EA2E31
		// (set) Token: 0x06039D74 RID: 236916 RVA: 0x00EA4C39 File Offset: 0x00EA2E39
		public int MoodMin { get; set; }

		// Token: 0x170093F1 RID: 37873
		// (get) Token: 0x06039D75 RID: 236917 RVA: 0x00EA4C42 File Offset: 0x00EA2E42
		// (set) Token: 0x06039D76 RID: 236918 RVA: 0x00EA4C4A File Offset: 0x00EA2E4A
		public int MoodMax { get; set; }

		// Token: 0x170093F2 RID: 37874
		// (get) Token: 0x06039D77 RID: 236919 RVA: 0x00EA4C53 File Offset: 0x00EA2E53
		// (set) Token: 0x06039D78 RID: 236920 RVA: 0x00EA4C5B File Offset: 0x00EA2E5B
		public int InitMood { get; set; }

		// Token: 0x170093F3 RID: 37875
		// (get) Token: 0x06039D79 RID: 236921 RVA: 0x00EA4C64 File Offset: 0x00EA2E64
		// (set) Token: 0x06039D7A RID: 236922 RVA: 0x00EA4C6C File Offset: 0x00EA2E6C
		public List<MapGridData> MapGrids { get; set; }

		// Token: 0x170093F4 RID: 37876
		// (get) Token: 0x06039D7B RID: 236923 RVA: 0x00EA4C75 File Offset: 0x00EA2E75
		// (set) Token: 0x06039D7C RID: 236924 RVA: 0x00EA4C7D File Offset: 0x00EA2E7D
		public int MapWidth { get; set; }

		// Token: 0x170093F5 RID: 37877
		// (get) Token: 0x06039D7D RID: 236925 RVA: 0x00EA4C86 File Offset: 0x00EA2E86
		// (set) Token: 0x06039D7E RID: 236926 RVA: 0x00EA4C8E File Offset: 0x00EA2E8E
		public int MapHeight { get; set; }

		// Token: 0x170093F6 RID: 37878
		// (get) Token: 0x06039D7F RID: 236927 RVA: 0x00EA4C97 File Offset: 0x00EA2E97
		// (set) Token: 0x06039D80 RID: 236928 RVA: 0x00EA4C9F File Offset: 0x00EA2E9F
		public int PlayerGridIndex { get; set; }

		// Token: 0x170093F7 RID: 37879
		// (get) Token: 0x06039D81 RID: 236929 RVA: 0x00EA4CA8 File Offset: 0x00EA2EA8
		// (set) Token: 0x06039D82 RID: 236930 RVA: 0x00EA4CB0 File Offset: 0x00EA2EB0
		public int TeamLv { get; set; }

		// Token: 0x170093F8 RID: 37880
		// (get) Token: 0x06039D83 RID: 236931 RVA: 0x00EA4CB9 File Offset: 0x00EA2EB9
		// (set) Token: 0x06039D84 RID: 236932 RVA: 0x00EA4CC1 File Offset: 0x00EA2EC1
		public bool InBattle { get; set; }

		// Token: 0x170093F9 RID: 37881
		// (get) Token: 0x06039D85 RID: 236933 RVA: 0x00EA4CCA File Offset: 0x00EA2ECA
		// (set) Token: 0x06039D86 RID: 236934 RVA: 0x00EA4CD2 File Offset: 0x00EA2ED2
		public int CurrencyItemId { get; set; }

		// Token: 0x170093FA RID: 37882
		// (get) Token: 0x06039D87 RID: 236935 RVA: 0x00EA4CDB File Offset: 0x00EA2EDB
		// (set) Token: 0x06039D88 RID: 236936 RVA: 0x00EA4CE3 File Offset: 0x00EA2EE3
		public int MoodRuleId { get; set; }

		// Token: 0x170093FB RID: 37883
		// (get) Token: 0x06039D89 RID: 236937 RVA: 0x00EA4CEC File Offset: 0x00EA2EEC
		// (set) Token: 0x06039D8A RID: 236938 RVA: 0x00EA4CF4 File Offset: 0x00EA2EF4
		public int RoleMaxStar { get; set; }

		// Token: 0x170093FC RID: 37884
		// (get) Token: 0x06039D8B RID: 236939 RVA: 0x00EA4CFD File Offset: 0x00EA2EFD
		// (set) Token: 0x06039D8C RID: 236940 RVA: 0x00EA4D05 File Offset: 0x00EA2F05
		public int RoleLevel { get; set; }
	}
}
