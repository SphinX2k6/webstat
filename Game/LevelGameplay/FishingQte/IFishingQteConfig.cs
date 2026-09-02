using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.LevelGamePlay.FishingQte
{
	// Token: 0x02006E8E RID: 28302
	[NullableContext(1)]
	public interface IFishingQteConfig
	{
		// Token: 0x1700A3A0 RID: 41888
		// (get) Token: 0x060449D7 RID: 281047
		// (set) Token: 0x060449D8 RID: 281048
		int Id { get; set; }

		// Token: 0x1700A3A1 RID: 41889
		// (get) Token: 0x060449D9 RID: 281049
		// (set) Token: 0x060449DA RID: 281050
		List<int> RandomArea { get; set; }

		// Token: 0x1700A3A2 RID: 41890
		// (get) Token: 0x060449DB RID: 281051
		// (set) Token: 0x060449DC RID: 281052
		IntArray[] InvalidArea { get; set; }

		// Token: 0x1700A3A3 RID: 41891
		// (get) Token: 0x060449DD RID: 281053
		// (set) Token: 0x060449DE RID: 281054
		int MaxScore { get; set; }

		// Token: 0x1700A3A4 RID: 41892
		// (get) Token: 0x060449DF RID: 281055
		// (set) Token: 0x060449E0 RID: 281056
		int HitAreaScore { get; set; }

		// Token: 0x1700A3A5 RID: 41893
		// (get) Token: 0x060449E1 RID: 281057
		// (set) Token: 0x060449E2 RID: 281058
		int PerfectSize { get; set; }

		// Token: 0x1700A3A6 RID: 41894
		// (get) Token: 0x060449E3 RID: 281059
		// (set) Token: 0x060449E4 RID: 281060
		Dictionary<int, int> PerfectAppearRate { get; set; }

		// Token: 0x1700A3A7 RID: 41895
		// (get) Token: 0x060449E5 RID: 281061
		// (set) Token: 0x060449E6 RID: 281062
		int PerfectScore { get; set; }

		// Token: 0x1700A3A8 RID: 41896
		// (get) Token: 0x060449E7 RID: 281063
		// (set) Token: 0x060449E8 RID: 281064
		Dictionary<int, int> CursorSpeed { get; set; }

		// Token: 0x1700A3A9 RID: 41897
		// (get) Token: 0x060449E9 RID: 281065
		// (set) Token: 0x060449EA RID: 281066
		int HitColdTime { get; set; }

		// Token: 0x1700A3AA RID: 41898
		// (get) Token: 0x060449EB RID: 281067
		// (set) Token: 0x060449EC RID: 281068
		int ScoreUp { get; set; }

		// Token: 0x1700A3AB RID: 41899
		// (get) Token: 0x060449ED RID: 281069
		// (set) Token: 0x060449EE RID: 281070
		int MultiBoxGroup { get; set; }

		// Token: 0x1700A3AC RID: 41900
		// (get) Token: 0x060449EF RID: 281071
		// (set) Token: 0x060449F0 RID: 281072
		List<float> HiddenInterval { get; set; }

		// Token: 0x1700A3AD RID: 41901
		// (get) Token: 0x060449F1 RID: 281073
		// (set) Token: 0x060449F2 RID: 281074
		Dictionary<int, int> RouletteRotateSpeed { get; set; }

		// Token: 0x1700A3AE RID: 41902
		// (get) Token: 0x060449F3 RID: 281075
		// (set) Token: 0x060449F4 RID: 281076
		int MistakeScore { get; set; }

		// Token: 0x1700A3AF RID: 41903
		// (get) Token: 0x060449F5 RID: 281077
		// (set) Token: 0x060449F6 RID: 281078
		bool IsAnticlockwise { get; set; }

		// Token: 0x1700A3B0 RID: 41904
		// (get) Token: 0x060449F7 RID: 281079
		// (set) Token: 0x060449F8 RID: 281080
		string Comment { get; set; }

		// Token: 0x1700A3B1 RID: 41905
		// (get) Token: 0x060449F9 RID: 281081
		// (set) Token: 0x060449FA RID: 281082
		int RefreshType { get; set; }
	}
}
