using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.BossPiling
{
	// Token: 0x02005EF2 RID: 24306
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class BossPilingModel : ModelBase<BossPilingModel>
	{
		// Token: 0x0603D108 RID: 250120 RVA: 0x00F8137B File Offset: 0x00F7F57B
		public BossPilingActivityData GetActivityData()
		{
			if (this.ActivityData == null)
			{
				this.ActivityData = ControllerBase<BossPilingController>.Instance.GetActivityData();
			}
			return this.ActivityData;
		}

		// Token: 0x0603D109 RID: 250121 RVA: 0x00F8139C File Offset: 0x00F7F59C
		public Dictionary<int, List<BossPilingBuffCountInfo>> GetBuffList(int levelId, bool inGame)
		{
			Dictionary<int, List<BossPilingBuffCountInfo>> dictionary = new Dictionary<int, List<BossPilingBuffCountInfo>>();
			if (!inGame)
			{
				BossPilingLevels? levelInfo = ConfigBase<BossPilingConfig>.Instance.GetLevelInfo(levelId);
				if (levelInfo.Value.RareBuffGroup().Length != 0)
				{
					List<BossPilingBuffCountInfo> list = new List<BossPilingBuffCountInfo>();
					foreach (int buffId in levelInfo.Value.RareBuffGroupIter())
					{
						BossPilingBuffCountInfo item = new BossPilingBuffCountInfo
						{
							BuffId = buffId,
							Count = 1
						};
						list.Add(item);
					}
					dictionary[5] = list;
				}
				if (levelInfo.Value.BuffGroup().Length != 0)
				{
					List<BossPilingBuffCountInfo> list2 = new List<BossPilingBuffCountInfo>();
					foreach (int buffId2 in levelInfo.Value.BuffGroupIter())
					{
						BossPilingBuffCountInfo item2 = new BossPilingBuffCountInfo
						{
							BuffId = buffId2,
							Count = 1
						};
						list2.Add(item2);
					}
					dictionary[4] = list2;
				}
			}
			else
			{
				Dictionary<int, int> dungeonBuff = this.GetActivityData().GetDungeonBuff();
				List<BossPilingBuffCountInfo> list3 = new List<BossPilingBuffCountInfo>();
				List<BossPilingBuffCountInfo> list4 = new List<BossPilingBuffCountInfo>();
				foreach (KeyValuePair<int, int> keyValuePair in dungeonBuff)
				{
					int num;
					int num2;
					keyValuePair.Deconstruct(out num, out num2);
					int num3 = num;
					int count = num2;
					int quality = ConfigBase<BossPilingConfig>.Instance.GetBuffInfo(num3).Value.Quality;
					BossPilingBuffCountInfo item3 = new BossPilingBuffCountInfo
					{
						BuffId = num3,
						Count = count
					};
					if (quality < 5)
					{
						list4.Add(item3);
					}
					else
					{
						list3.Add(item3);
					}
				}
				if (list3.Count > 0)
				{
					dictionary[5] = list3;
				}
				if (list4.Count > 0)
				{
					dictionary[4] = list4;
				}
			}
			return dictionary;
		}

		// Token: 0x0603D10A RID: 250122 RVA: 0x00F815AC File Offset: 0x00F7F7AC
		public bool CheckIsBossPiling()
		{
			InstanceDungeon? instanceDungeon;
			return ((ModelBase<GameModeModel>.Instance.InstanceDungeon != null) ? instanceDungeon.GetValueOrDefault().InstSubType : -1) == 55;
		}

		// Token: 0x0603D10B RID: 250123 RVA: 0x00F815E4 File Offset: 0x00F7F7E4
		[NullableContext(0)]
		public ValueTuple<int, bool> GetLevelIdAndHalfByInstId(int instId)
		{
			if (this.InstLevelInfo.Count == 0)
			{
				foreach (BossPilingLevelInfo bossPilingLevelInfo in this.ActivityData.GetAllLevelInfo())
				{
					BossPilingLevels? levelInfo = ConfigBase<BossPilingConfig>.Instance.GetLevelInfo(bossPilingLevelInfo.Id);
					for (int i = 0; i < levelInfo.Value.InstIds().Length; i++)
					{
						this.InstLevelInfo[levelInfo.Value.InstIds()[i]] = new ValueTuple<int, bool>(bossPilingLevelInfo.Id, i == 0);
					}
				}
			}
			return this.InstLevelInfo[instId];
		}

		// Token: 0x0603D10C RID: 250124 RVA: 0x00F816AC File Offset: 0x00F7F8AC
		public void CloseActivityView(IReadOnlySet<int> closeActivities)
		{
			if (closeActivities.Contains(ControllerBase<BossPilingController>.Instance.ActivityId))
			{
				ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.ActivityEnd);
				confirmBoxDataNew.FunctionMap[1] = new Action(this.<CloseActivityView>g__ConfirmCallback|8_0);
				confirmBoxDataNew.FunctionMap[0] = new Action(this.<CloseActivityView>g__ConfirmCallback|8_0);
				ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
			}
		}

		// Token: 0x0603D10E RID: 250126 RVA: 0x00F8172D File Offset: 0x00F7F92D
		[CompilerGenerated]
		private void <CloseActivityView>g__ConfirmCallback|8_0()
		{
			if (this.CheckIsBossPiling())
			{
				ControllerBase<InstanceDungeonEntranceController>.Instance.LeaveInstanceDungeonRequest(LeaveInstWay.Default);
				return;
			}
			Singleton<UiManager>.Instance.ResetToBattleView(null);
		}

		// Token: 0x04022408 RID: 140296
		[Nullable(2)]
		protected BossPilingActivityData ActivityData;

		// Token: 0x04022409 RID: 140297
		[Nullable(new byte[]
		{
			1,
			0
		})]
		protected Dictionary<int, ValueTuple<int, bool>> InstLevelInfo = new Dictionary<int, ValueTuple<int, bool>>();

		// Token: 0x0402240A RID: 140298
		public List<int> InstKeyBuffList = new List<int>();

		// Token: 0x0402240B RID: 140299
		public int InstBuffAcquireCount;
	}
}
