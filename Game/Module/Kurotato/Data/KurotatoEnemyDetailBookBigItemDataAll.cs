using System;
using System.Collections.Generic;
using Aki.Config;

namespace CSharpScript.Game.Module.Kurotato.Data
{
	// Token: 0x02005AED RID: 23277
	public class KurotatoEnemyDetailBookBigItemDataAll : KurotatoEnemyDetailBookBigItemData
	{
		// Token: 0x170095B3 RID: 38323
		// (get) Token: 0x0603ADC3 RID: 241091 RVA: 0x00EEDB88 File Offset: 0x00EEBD88
		// (set) Token: 0x0603ADC4 RID: 241092 RVA: 0x00EEDB90 File Offset: 0x00EEBD90
		public int RiskType { get; set; }

		// Token: 0x0603ADC5 RID: 241093 RVA: 0x00EEDB9C File Offset: 0x00EEBD9C
		public KurotatoEnemyDetailBookBigItemDataAll(int targetLevel, int riskType)
		{
			base.TabAllOrWave = EKurotatoEnemyDetailBookTabAllOrWave.All;
			base.TargetLevel = targetLevel;
			this.RiskType = riskType;
			List<KurotatoWave> waveByLevelId = ConfigBase<KurotatoConfig>.Instance.GetWaveByLevelId(targetLevel);
			if (waveByLevelId == null || waveByLevelId.Count == 0)
			{
				return;
			}
			foreach (KurotatoWave kurotatoWave in waveByLevelId)
			{
				if (kurotatoWave.WaveType != 1)
				{
					int monsterSpawnGroupLength = kurotatoWave.MonsterSpawnGroupLength;
					for (int i = 0; i < monsterSpawnGroupLength; i++)
					{
						int spawnId = kurotatoWave.MonsterSpawnGroup(i);
						KurotatoSpawn? spawnById = ConfigBase<KurotatoConfig>.Instance.GetSpawnById(spawnId);
						if (spawnById != null)
						{
							int monsterIdsLength = spawnById.Value.MonsterIdsLength;
							for (int j = 0; j < monsterIdsLength; j++)
							{
								int num = spawnById.Value.MonsterIds(j);
								if (!this.WaveMonsterIdToNum.ContainsKey(num))
								{
									KurotatoMonsterType? monsterTypeById = ConfigBase<KurotatoConfig>.Instance.GetMonsterTypeById(num);
									if ((monsterTypeById == null || monsterTypeById.GetValueOrDefault().RiskType != 4) && (monsterTypeById == null || monsterTypeById.GetValueOrDefault().RiskType != 5))
									{
										int? num2 = (monsterTypeById != null) ? new int?(monsterTypeById.GetValueOrDefault().RiskType) : null;
										int riskType2 = this.RiskType;
										if (num2.GetValueOrDefault() == riskType2 & num2 != null)
										{
											KurotatoMonster? monsterConfigById = ConfigBase<KurotatoConfig>.Instance.GetMonsterConfigById(num);
											if (monsterConfigById != null && !monsterConfigById.Value.IsHideInBook)
											{
												this.WaveMonsterIdToNum[num] = 1;
												this.MonsterGridItemDataList.Add(new KurotatoEnemyData(num, 1));
											}
										}
									}
								}
							}
						}
					}
				}
			}
			this.MonsterGridItemDataList.Sort((KurotatoEnemyData a, KurotatoEnemyData b) => b.RiskType - a.RiskType);
		}
	}
}
