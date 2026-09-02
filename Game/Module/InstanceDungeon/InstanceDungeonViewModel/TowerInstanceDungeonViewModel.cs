using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.InstanceDungeon.Define;
using CSharpScript.Game.Module.InstanceDungeon.InstanceDungeonComponentModel;
using CSharpScript.Game.Module.TowerDefence;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.InstanceDungeon.InstanceDungeonViewModel
{
	// Token: 0x02005BDE RID: 23518
	[NullableContext(2)]
	[Nullable(0)]
	public class TowerInstanceDungeonViewModel : InstanceDungeonViewModelBase
	{
		// Token: 0x1700979D RID: 38813
		// (get) Token: 0x0603B8A9 RID: 243881 RVA: 0x00F17D98 File Offset: 0x00F15F98
		// (set) Token: 0x0603B8AA RID: 243882 RVA: 0x00F17DA0 File Offset: 0x00F15FA0
		public override RankTimeItemModelBase RankItemModel { get; set; } = new TowerDefenseRankTimeModel();

		// Token: 0x0603B8AB RID: 243883 RVA: 0x00F17DAC File Offset: 0x00F15FAC
		[NullableContext(1)]
		protected unsafe override Dictionary<int, List<int>> GetInstanceByTitleMap()
		{
			Dictionary<int, int> sortedByTitleEntranceInstanceIdList = ModelBase<TowerDefenseModel>.Instance.GetSortedByTitleEntranceInstanceIdList();
			Dictionary<int, List<int>> dictionary = new Dictionary<int, List<int>>();
			foreach (KeyValuePair<int, int> keyValuePair in sortedByTitleEntranceInstanceIdList)
			{
				int num;
				int num2;
				keyValuePair.Deconstruct(out num, out num2);
				int num3 = num;
				int num4 = num2;
				List<int> value;
				if (!dictionary.TryGetValue(num4, out value))
				{
					value = new List<int>();
					dictionary[num4] = value;
				}
				Dictionary<int, List<int>> dictionary2 = dictionary;
				int key = num4;
				List<int> list = dictionary[num4];
				num2 = 1 + list.Count;
				List<int> list2 = new List<int>(num2);
				CollectionsMarshal.SetCount<int>(list2, num2);
				Span<int> span = CollectionsMarshal.AsSpan<int>(list2);
				num = 0;
				Span<int> span2 = CollectionsMarshal.AsSpan<int>(list);
				span2.CopyTo(span.Slice(num, span2.Length));
				num += span2.Length;
				*span[num] = num3;
				dictionary2[key] = list2;
			}
			return dictionary;
		}

		// Token: 0x0603B8AC RID: 243884 RVA: 0x00F17EA4 File Offset: 0x00F160A4
		[NullableContext(1)]
		protected override void OnSortInstanceArray(List<int> instanceArray)
		{
			instanceArray.Sort(delegate(int aInstanceId, int bInstanceId)
			{
				TowerDefenceInstance? towerDefenseInstanceByInstance = ConfigBase<InstanceDungeonConfig>.Instance.GetTowerDefenseInstanceByInstance(aInstanceId);
				TowerDefenceInstance? towerDefenseInstanceByInstance2 = ConfigBase<InstanceDungeonConfig>.Instance.GetTowerDefenseInstanceByInstance(bInstanceId);
				if (towerDefenseInstanceByInstance != null && towerDefenseInstanceByInstance2 != null)
				{
					return towerDefenseInstanceByInstance.Value.Difficulty - towerDefenseInstanceByInstance2.Value.Difficulty;
				}
				return 0;
			});
		}

		// Token: 0x0603B8AD RID: 243885 RVA: 0x00F17ECC File Offset: 0x00F160CC
		[NullableContext(1)]
		protected override string OnGetInstanceItemTextureBg(int instanceId)
		{
			TowerDefenceInstance? towerDefenseInstanceByInstance = ConfigBase<InstanceDungeonConfig>.Instance.GetTowerDefenseInstanceByInstance(instanceId);
			if (towerDefenseInstanceByInstance != null && towerDefenseInstanceByInstance.Value.IsDifficult)
			{
				return "T_TogHoldDeathmatch";
			}
			return "T_TogListNor";
		}

		// Token: 0x0603B8AE RID: 243886 RVA: 0x00F17F0C File Offset: 0x00F1610C
		protected override TableTextArgNew OnGetUnlockConditionTextId(int instanceId)
		{
			int[] unlockCondition = ConfigBase<InstanceDungeonConfig>.Instance.GetUnlockCondition(instanceId);
			TowerDefenceInstance? towerDefenseConfigById = ConfigBase<InstanceDungeonConfig>.Instance.GetTowerDefenseConfigById(unlockCondition[2]);
			if (ModelBase<TowerDefenseModel>.Instance.PhantomMessageCache.IsStageUnLocked(towerDefenseConfigById.Value.InstanceId))
			{
				return new TableTextArgNew("OnlineGymnasium_LevelRst", Array.Empty<object>());
			}
			string text = ControllerBase<TowerDefenseController>.Instance.BuildInstanceCountDownTextParam(instanceId);
			if (text != null)
			{
				return new TableTextArgNew("OnlineGymnasium_LevelRst", new <>z__ReadOnlySingleElementList<object>(text));
			}
			return null;
		}

		// Token: 0x0603B8AF RID: 243887 RVA: 0x00F17F84 File Offset: 0x00F16184
		protected override bool OnIsFinishInstance(int instanceId)
		{
			return ControllerBase<TowerDefenseController>.Instance.CheckInstancePassedByInstanceId(instanceId);
		}

		// Token: 0x0603B8B0 RID: 243888 RVA: 0x00F17F91 File Offset: 0x00F16191
		[NullableContext(1)]
		protected override string OnGetInstanceDetectItemIcon(int instanceId)
		{
			return "";
		}

		// Token: 0x0603B8B1 RID: 243889 RVA: 0x00F17F98 File Offset: 0x00F16198
		protected override InstanceDungeonEntranceViewSelectData OnGetDefaultSelectData()
		{
			if (ControllerBase<TowerDefenseController>.Instance.CheckInUiFlow())
			{
				int suitableInstanceId = ControllerBase<TowerDefenseController>.Instance.GetSuitableInstanceId();
				InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(suitableInstanceId);
				if (config != null)
				{
					return new InstanceDungeonEntranceViewSelectData
					{
						InstanceId = suitableInstanceId,
						SeriesId = config.Value.Title
					};
				}
			}
			return null;
		}

		// Token: 0x0603B8B2 RID: 243890 RVA: 0x00F17FF4 File Offset: 0x00F161F4
		protected override bool OnCheckNeedOnTimer(int instanceId)
		{
			return ControllerBase<TowerDefenseController>.Instance.CheckInUiFlow() && !ControllerBase<TowerDefenseController>.Instance.CheckIsInstanceUnlock(instanceId);
		}

		// Token: 0x0603B8B3 RID: 243891 RVA: 0x00F18012 File Offset: 0x00F16212
		protected override void OnTimerRefreshFunction(float delta)
		{
			this.View.RefreshTowerDefenseInstance();
		}

		// Token: 0x0603B8B4 RID: 243892 RVA: 0x00F18020 File Offset: 0x00F16220
		protected override UniTask OnRequestServerData()
		{
			TowerInstanceDungeonViewModel.<OnRequestServerData>d__13 <OnRequestServerData>d__;
			<OnRequestServerData>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnRequestServerData>d__.<>4__this = this;
			<OnRequestServerData>d__.<>1__state = -1;
			<OnRequestServerData>d__.<>t__builder.Start<TowerInstanceDungeonViewModel.<OnRequestServerData>d__13>(ref <OnRequestServerData>d__);
			return <OnRequestServerData>d__.<>t__builder.Task;
		}

		// Token: 0x0603B8B5 RID: 243893 RVA: 0x00F18063 File Offset: 0x00F16263
		protected override bool OnCheckInstanceHasRedDot(int instanceId)
		{
			return ModelBase<TowerDefenseModel>.Instance.CheckTowerDefenseInstanceHasRedDot(instanceId);
		}
	}
}
