using System;
using Aki.Config;

namespace CSharpScript.Game.Module.Kurotato.Data
{
	// Token: 0x02005AEE RID: 23278
	public class KurotatoEnemyDetailBookBigItemDataWave : KurotatoEnemyDetailBookBigItemData
	{
		// Token: 0x170095B4 RID: 38324
		// (get) Token: 0x0603ADC6 RID: 241094 RVA: 0x00EEDDDC File Offset: 0x00EEBFDC
		// (set) Token: 0x0603ADC7 RID: 241095 RVA: 0x00EEDDE4 File Offset: 0x00EEBFE4
		public int ThisWave { get; set; }

		// Token: 0x170095B5 RID: 38325
		// (get) Token: 0x0603ADC8 RID: 241096 RVA: 0x00EEDDED File Offset: 0x00EEBFED
		// (set) Token: 0x0603ADC9 RID: 241097 RVA: 0x00EEDDF5 File Offset: 0x00EEBFF5
		public EKurotatoWaveStatus WaveStatus { get; set; } = EKurotatoWaveStatus.NotCompleted;

		// Token: 0x170095B6 RID: 38326
		// (get) Token: 0x0603ADCA RID: 241098 RVA: 0x00EEDDFE File Offset: 0x00EEBFFE
		// (set) Token: 0x0603ADCB RID: 241099 RVA: 0x00EEDE06 File Offset: 0x00EEC006
		public bool IsHighDiff { get; set; }

		// Token: 0x0603ADCC RID: 241100 RVA: 0x00EEDE10 File Offset: 0x00EEC010
		public KurotatoEnemyDetailBookBigItemDataWave(int targetLevel, int thisWave, int curWave = 0)
		{
			base.TabAllOrWave = EKurotatoEnemyDetailBookTabAllOrWave.Wave;
			base.TargetLevel = targetLevel;
			this.ThisWave = thisWave;
			if (thisWave == curWave)
			{
				this.WaveStatus = EKurotatoWaveStatus.Current;
			}
			else if (thisWave < curWave)
			{
				this.WaveStatus = EKurotatoWaveStatus.Completed;
			}
			else
			{
				this.WaveStatus = EKurotatoWaveStatus.NotCompleted;
			}
			KurotatoWave? monsterByLevelIdAndWaveId = ConfigBase<KurotatoConfig>.Instance.GetMonsterByLevelIdAndWaveId(targetLevel, thisWave);
			if (monsterByLevelIdAndWaveId != null)
			{
				KurotatoWave value = monsterByLevelIdAndWaveId.Value;
				int monsterSpawnGroupLength = value.MonsterSpawnGroupLength;
				for (int i = 0; i < monsterSpawnGroupLength; i++)
				{
					int spawnId = value.MonsterSpawnGroup(i);
					KurotatoSpawn? spawnById = ConfigBase<KurotatoConfig>.Instance.GetSpawnById(spawnId);
					if (spawnById != null)
					{
						int monsterIdsLength = spawnById.Value.MonsterIdsLength;
						for (int j = 0; j < monsterIdsLength; j++)
						{
							int num = spawnById.Value.MonsterIds(j);
							KurotatoMonsterType? monsterTypeById = ConfigBase<KurotatoConfig>.Instance.GetMonsterTypeById(num);
							if ((monsterTypeById == null || monsterTypeById.GetValueOrDefault().RiskType != 4) && (monsterTypeById == null || monsterTypeById.GetValueOrDefault().RiskType != 5))
							{
								if (this.WaveMonsterIdToNum.ContainsKey(num))
								{
									this.WaveMonsterIdToNum[num] = this.WaveMonsterIdToNum[num] + 1;
								}
								else
								{
									this.WaveMonsterIdToNum[num] = 1;
								}
							}
						}
					}
				}
				foreach (int monsterId in this.WaveMonsterIdToNum.Keys)
				{
					KurotatoMonster? monsterConfigById = ConfigBase<KurotatoConfig>.Instance.GetMonsterConfigById(monsterId);
					if (monsterConfigById != null && !monsterConfigById.Value.IsHideInBook)
					{
						this.MonsterGridItemDataList.Add(new KurotatoEnemyData(monsterId, 1));
					}
				}
			}
			this.MonsterGridItemDataList.Sort((KurotatoEnemyData a, KurotatoEnemyData b) => b.RiskType - a.RiskType);
		}
	}
}
