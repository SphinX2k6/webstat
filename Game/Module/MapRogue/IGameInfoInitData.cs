using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.MapRogue
{
	// Token: 0x02005909 RID: 22793
	[NullableContext(1)]
	public interface IGameInfoInitData
	{
		// Token: 0x170093DF RID: 37855
		// (get) Token: 0x06039D51 RID: 236881
		// (set) Token: 0x06039D52 RID: 236882
		int InstanceId { get; set; }

		// Token: 0x170093E0 RID: 37856
		// (get) Token: 0x06039D53 RID: 236883
		// (set) Token: 0x06039D54 RID: 236884
		int RandomSeed { get; set; }

		// Token: 0x170093E1 RID: 37857
		// (get) Token: 0x06039D55 RID: 236885
		// (set) Token: 0x06039D56 RID: 236886
		int MoodMin { get; set; }

		// Token: 0x170093E2 RID: 37858
		// (get) Token: 0x06039D57 RID: 236887
		// (set) Token: 0x06039D58 RID: 236888
		int MoodMax { get; set; }

		// Token: 0x170093E3 RID: 37859
		// (get) Token: 0x06039D59 RID: 236889
		// (set) Token: 0x06039D5A RID: 236890
		int InitMood { get; set; }

		// Token: 0x170093E4 RID: 37860
		// (get) Token: 0x06039D5B RID: 236891
		// (set) Token: 0x06039D5C RID: 236892
		List<MapGridData> MapGrids { get; set; }

		// Token: 0x170093E5 RID: 37861
		// (get) Token: 0x06039D5D RID: 236893
		// (set) Token: 0x06039D5E RID: 236894
		int MapWidth { get; set; }

		// Token: 0x170093E6 RID: 37862
		// (get) Token: 0x06039D5F RID: 236895
		// (set) Token: 0x06039D60 RID: 236896
		int MapHeight { get; set; }

		// Token: 0x170093E7 RID: 37863
		// (get) Token: 0x06039D61 RID: 236897
		// (set) Token: 0x06039D62 RID: 236898
		int PlayerGridIndex { get; set; }

		// Token: 0x170093E8 RID: 37864
		// (get) Token: 0x06039D63 RID: 236899
		// (set) Token: 0x06039D64 RID: 236900
		int TeamLv { get; set; }

		// Token: 0x170093E9 RID: 37865
		// (get) Token: 0x06039D65 RID: 236901
		// (set) Token: 0x06039D66 RID: 236902
		bool InBattle { get; set; }

		// Token: 0x170093EA RID: 37866
		// (get) Token: 0x06039D67 RID: 236903
		// (set) Token: 0x06039D68 RID: 236904
		int CurrencyItemId { get; set; }

		// Token: 0x170093EB RID: 37867
		// (get) Token: 0x06039D69 RID: 236905
		// (set) Token: 0x06039D6A RID: 236906
		int MoodRuleId { get; set; }

		// Token: 0x170093EC RID: 37868
		// (get) Token: 0x06039D6B RID: 236907
		// (set) Token: 0x06039D6C RID: 236908
		int RoleMaxStar { get; set; }

		// Token: 0x170093ED RID: 37869
		// (get) Token: 0x06039D6D RID: 236909
		// (set) Token: 0x06039D6E RID: 236910
		int RoleLevel { get; set; }
	}
}
