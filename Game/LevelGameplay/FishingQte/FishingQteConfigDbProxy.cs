using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.LevelGamePlay.FishingQte
{
	// Token: 0x02006E8F RID: 28303
	[NullableContext(1)]
	[Nullable(0)]
	public class FishingQteConfigDbProxy : IFishingQteConfig
	{
		// Token: 0x1700A3B2 RID: 41906
		// (get) Token: 0x060449FB RID: 281083 RVA: 0x011D6C21 File Offset: 0x011D4E21
		// (set) Token: 0x060449FC RID: 281084 RVA: 0x011D6C29 File Offset: 0x011D4E29
		public int Id { get; set; }

		// Token: 0x1700A3B3 RID: 41907
		// (get) Token: 0x060449FD RID: 281085 RVA: 0x011D6C32 File Offset: 0x011D4E32
		// (set) Token: 0x060449FE RID: 281086 RVA: 0x011D6C3A File Offset: 0x011D4E3A
		public List<int> RandomArea { get; set; }

		// Token: 0x1700A3B4 RID: 41908
		// (get) Token: 0x060449FF RID: 281087 RVA: 0x011D6C43 File Offset: 0x011D4E43
		// (set) Token: 0x06044A00 RID: 281088 RVA: 0x011D6C4B File Offset: 0x011D4E4B
		public IntArray[] InvalidArea { get; set; }

		// Token: 0x1700A3B5 RID: 41909
		// (get) Token: 0x06044A01 RID: 281089 RVA: 0x011D6C54 File Offset: 0x011D4E54
		// (set) Token: 0x06044A02 RID: 281090 RVA: 0x011D6C5C File Offset: 0x011D4E5C
		public int MaxScore { get; set; }

		// Token: 0x1700A3B6 RID: 41910
		// (get) Token: 0x06044A03 RID: 281091 RVA: 0x011D6C65 File Offset: 0x011D4E65
		// (set) Token: 0x06044A04 RID: 281092 RVA: 0x011D6C6D File Offset: 0x011D4E6D
		public int HitAreaScore { get; set; }

		// Token: 0x1700A3B7 RID: 41911
		// (get) Token: 0x06044A05 RID: 281093 RVA: 0x011D6C76 File Offset: 0x011D4E76
		// (set) Token: 0x06044A06 RID: 281094 RVA: 0x011D6C7E File Offset: 0x011D4E7E
		public int PerfectSize { get; set; }

		// Token: 0x1700A3B8 RID: 41912
		// (get) Token: 0x06044A07 RID: 281095 RVA: 0x011D6C87 File Offset: 0x011D4E87
		// (set) Token: 0x06044A08 RID: 281096 RVA: 0x011D6C8F File Offset: 0x011D4E8F
		public Dictionary<int, int> PerfectAppearRate { get; set; }

		// Token: 0x1700A3B9 RID: 41913
		// (get) Token: 0x06044A09 RID: 281097 RVA: 0x011D6C98 File Offset: 0x011D4E98
		// (set) Token: 0x06044A0A RID: 281098 RVA: 0x011D6CA0 File Offset: 0x011D4EA0
		public int PerfectScore { get; set; }

		// Token: 0x1700A3BA RID: 41914
		// (get) Token: 0x06044A0B RID: 281099 RVA: 0x011D6CA9 File Offset: 0x011D4EA9
		// (set) Token: 0x06044A0C RID: 281100 RVA: 0x011D6CB1 File Offset: 0x011D4EB1
		public Dictionary<int, int> CursorSpeed { get; set; }

		// Token: 0x1700A3BB RID: 41915
		// (get) Token: 0x06044A0D RID: 281101 RVA: 0x011D6CBA File Offset: 0x011D4EBA
		// (set) Token: 0x06044A0E RID: 281102 RVA: 0x011D6CC2 File Offset: 0x011D4EC2
		public int HitColdTime { get; set; }

		// Token: 0x1700A3BC RID: 41916
		// (get) Token: 0x06044A0F RID: 281103 RVA: 0x011D6CCB File Offset: 0x011D4ECB
		// (set) Token: 0x06044A10 RID: 281104 RVA: 0x011D6CD3 File Offset: 0x011D4ED3
		public int ScoreUp { get; set; }

		// Token: 0x1700A3BD RID: 41917
		// (get) Token: 0x06044A11 RID: 281105 RVA: 0x011D6CDC File Offset: 0x011D4EDC
		// (set) Token: 0x06044A12 RID: 281106 RVA: 0x011D6CE4 File Offset: 0x011D4EE4
		public int MultiBoxGroup { get; set; }

		// Token: 0x1700A3BE RID: 41918
		// (get) Token: 0x06044A13 RID: 281107 RVA: 0x011D6CED File Offset: 0x011D4EED
		// (set) Token: 0x06044A14 RID: 281108 RVA: 0x011D6CF5 File Offset: 0x011D4EF5
		public List<float> HiddenInterval { get; set; }

		// Token: 0x1700A3BF RID: 41919
		// (get) Token: 0x06044A15 RID: 281109 RVA: 0x011D6CFE File Offset: 0x011D4EFE
		// (set) Token: 0x06044A16 RID: 281110 RVA: 0x011D6D06 File Offset: 0x011D4F06
		public Dictionary<int, int> RouletteRotateSpeed { get; set; }

		// Token: 0x1700A3C0 RID: 41920
		// (get) Token: 0x06044A17 RID: 281111 RVA: 0x011D6D0F File Offset: 0x011D4F0F
		// (set) Token: 0x06044A18 RID: 281112 RVA: 0x011D6D17 File Offset: 0x011D4F17
		public int MistakeScore { get; set; }

		// Token: 0x1700A3C1 RID: 41921
		// (get) Token: 0x06044A19 RID: 281113 RVA: 0x011D6D20 File Offset: 0x011D4F20
		// (set) Token: 0x06044A1A RID: 281114 RVA: 0x011D6D28 File Offset: 0x011D4F28
		public bool IsAnticlockwise { get; set; }

		// Token: 0x1700A3C2 RID: 41922
		// (get) Token: 0x06044A1B RID: 281115 RVA: 0x011D6D31 File Offset: 0x011D4F31
		// (set) Token: 0x06044A1C RID: 281116 RVA: 0x011D6D39 File Offset: 0x011D4F39
		public string Comment { get; set; }

		// Token: 0x1700A3C3 RID: 41923
		// (get) Token: 0x06044A1D RID: 281117 RVA: 0x011D6D42 File Offset: 0x011D4F42
		// (set) Token: 0x06044A1E RID: 281118 RVA: 0x011D6D4A File Offset: 0x011D4F4A
		public int RefreshType { get; set; }

		// Token: 0x06044A1F RID: 281119 RVA: 0x011D6D54 File Offset: 0x011D4F54
		public FishingQteConfigDbProxy(FishingQteConfig config)
		{
			this.Id = config.Id;
			this.RandomArea = config.RandomArea().ToList<int>();
			this.InvalidArea = config.InvalidArea();
			this.MaxScore = config.MaxScore;
			this.HitAreaScore = config.HitAreaScore;
			this.PerfectSize = config.PerfectSize;
			this.PerfectAppearRate = config.PerfectAppearRate();
			this.PerfectScore = config.PerfectScore;
			this.CursorSpeed = config.CursorSpeed();
			this.HitColdTime = config.HitColdTime;
			this.ScoreUp = config.ScoreUp;
			this.MultiBoxGroup = config.MultiBoxGroup;
			this.HiddenInterval = config.HiddenInterval().ToList<float>();
			this.RouletteRotateSpeed = config.RouletteRotateSpeed();
			this.MistakeScore = config.MistakeScore;
			this.IsAnticlockwise = config.IsAnticlockwise;
			this.Comment = config.Comment;
			this.RefreshType = config.RefreshType;
		}
	}
}
