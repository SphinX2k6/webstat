using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004DAD RID: 19885
	[NullableContext(1)]
	[Nullable(0)]
	public class TrapDefenseMonsterTypeData
	{
		// Token: 0x0603381B RID: 210971 RVA: 0x00CE23A1 File Offset: 0x00CE05A1
		public static TrapDefenseMonsterTypeData Create(TrapDefenseMonsterRisk config)
		{
			TrapDefenseMonsterTypeData trapDefenseMonsterTypeData = new TrapDefenseMonsterTypeData(config.Id);
			trapDefenseMonsterTypeData.Config = config;
			trapDefenseMonsterTypeData.Init();
			return trapDefenseMonsterTypeData;
		}

		// Token: 0x0603381C RID: 210972 RVA: 0x00CE23BC File Offset: 0x00CE05BC
		private TrapDefenseMonsterTypeData(int id)
		{
			this.Id = id;
		}

		// Token: 0x0603381D RID: 210973 RVA: 0x00CE23D6 File Offset: 0x00CE05D6
		private void Init()
		{
		}

		// Token: 0x0603381E RID: 210974 RVA: 0x00CE23D8 File Offset: 0x00CE05D8
		public List<TrapDefenseMonsterData> GetMonsterDataList(bool showInInstance = true)
		{
			if (this.MonsterDataList.Count <= 0)
			{
				foreach (TrapDefenseMonsterData trapDefenseMonsterData in ModelBase<TrapDefenseModel>.Instance.ViewModelMonster.GetMonsterMap().Values)
				{
					if (trapDefenseMonsterData.ConfigType.RiskType == this.Id)
					{
						this.MonsterDataList.Add(trapDefenseMonsterData);
					}
				}
				List<TrapDefenseMonsterData> list = new List<TrapDefenseMonsterData>(this.MonsterDataList);
				Dictionary<TrapDefenseMonsterData, int> orderIndexMap = new Dictionary<TrapDefenseMonsterData, int>();
				for (int i = 0; i < list.Count; i++)
				{
					orderIndexMap[list[i]] = i;
				}
				list.Sort(delegate(TrapDefenseMonsterData a, TrapDefenseMonsterData b)
				{
					if (a.SortId != b.SortId)
					{
						return a.SortId - b.SortId;
					}
					return orderIndexMap[a] - orderIndexMap[b];
				});
				this.MonsterDataList = list;
			}
			if (showInInstance)
			{
				List<TrapDefenseMonsterData> list2 = new List<TrapDefenseMonsterData>();
				foreach (TrapDefenseMonsterData trapDefenseMonsterData2 in this.MonsterDataList)
				{
					if (trapDefenseMonsterData2.InTheInstance)
					{
						list2.Add(trapDefenseMonsterData2);
					}
				}
				return list2;
			}
			return this.MonsterDataList;
		}

		// Token: 0x0401DD43 RID: 122179
		public int Id;

		// Token: 0x0401DD44 RID: 122180
		public TrapDefenseMonsterRisk Config;

		// Token: 0x0401DD45 RID: 122181
		private List<TrapDefenseMonsterData> MonsterDataList = new List<TrapDefenseMonsterData>();
	}
}
