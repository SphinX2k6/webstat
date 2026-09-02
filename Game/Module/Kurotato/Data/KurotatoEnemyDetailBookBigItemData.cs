using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Kurotato.Data
{
	// Token: 0x02005AEC RID: 23276
	[NullableContext(1)]
	[Nullable(0)]
	public class KurotatoEnemyDetailBookBigItemData
	{
		// Token: 0x170095B1 RID: 38321
		// (get) Token: 0x0603ADBD RID: 241085 RVA: 0x00EEDB40 File Offset: 0x00EEBD40
		// (set) Token: 0x0603ADBE RID: 241086 RVA: 0x00EEDB48 File Offset: 0x00EEBD48
		public int TargetLevel { get; set; }

		// Token: 0x170095B2 RID: 38322
		// (get) Token: 0x0603ADBF RID: 241087 RVA: 0x00EEDB51 File Offset: 0x00EEBD51
		// (set) Token: 0x0603ADC0 RID: 241088 RVA: 0x00EEDB59 File Offset: 0x00EEBD59
		public EKurotatoEnemyDetailBookTabAllOrWave TabAllOrWave { get; set; }

		// Token: 0x0603ADC1 RID: 241089 RVA: 0x00EEDB62 File Offset: 0x00EEBD62
		public List<KurotatoEnemyData> GetMonsterGridItemDataList()
		{
			return this.MonsterGridItemDataList;
		}

		// Token: 0x040213F2 RID: 136178
		protected readonly Dictionary<int, int> WaveMonsterIdToNum = new Dictionary<int, int>();

		// Token: 0x040213F3 RID: 136179
		protected readonly List<KurotatoEnemyData> MonsterGridItemDataList = new List<KurotatoEnemyData>();

		// Token: 0x040213F4 RID: 136180
		[Nullable(2)]
		public KurotatoEnemyData CurSelectedGridItemData;
	}
}
