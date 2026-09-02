using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.LevelGamePlay.LevelConditions;

// Token: 0x02002745 RID: 10053
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class RandomPlotController : ControllerBase<RandomPlotController>
{
	// Token: 0x06013DA7 RID: 81319 RVA: 0x00588A08 File Offset: 0x00586C08
	protected override bool OnInit()
	{
		Singleton<EventSystem>.Instance.Add<int, int>(EEventName.OnInstanceChange, new Action<int, int>(this.OnInstanceChange));
		IReadOnlyList<InstanceRandomPlot> configList = ConfigInstanceRandomPlotAll.GetConfigList(true);
		if (configList != null)
		{
			Dictionary<int, int[]> instanceTriggerGroupMap = ModelBase<RandomPlotModel>.Instance.InstanceTriggerGroupMap;
			foreach (InstanceRandomPlot instanceRandomPlot in configList)
			{
				int[] activeTriggerGroupIdListArray = instanceRandomPlot.GetActiveTriggerGroupIdListArray();
				instanceTriggerGroupMap[instanceRandomPlot.InstId] = (activeTriggerGroupIdListArray ?? Array.Empty<int>());
			}
		}
		return true;
	}

	// Token: 0x06013DA8 RID: 81320 RVA: 0x00588A9C File Offset: 0x00586C9C
	protected override bool OnClear()
	{
		Singleton<EventSystem>.Instance.Remove<int, int>(EEventName.OnInstanceChange, new Action<int, int>(this.OnInstanceChange));
		this.ClearAllCondition();
		ModelBase<RandomPlotModel>.Instance.RandomPlotMap.Clear();
		ModelBase<RandomPlotModel>.Instance.InstanceTriggerGroupMap.Clear();
		return true;
	}

	// Token: 0x06013DA9 RID: 81321 RVA: 0x00588AEA File Offset: 0x00586CEA
	protected override bool OnLeaveLevel()
	{
		ModelBase<RandomPlotModel>.Instance.RandomPlotMap.Clear();
		return true;
	}

	// Token: 0x06013DAA RID: 81322 RVA: 0x00588AFC File Offset: 0x00586CFC
	private void OnInstanceChange(int oldInstanceId, int newInstanceId)
	{
		if (oldInstanceId == newInstanceId)
		{
			return;
		}
		this.ClearAllCondition();
		int[] array;
		if (!ModelBase<RandomPlotModel>.Instance.InstanceTriggerGroupMap.TryGetValue(newInstanceId, out array) || array == null || array.Length == 0)
		{
			return;
		}
		Dictionary<int, IRandomPlotCondition> dictionary = new Dictionary<int, IRandomPlotCondition>();
		ModelBase<RandomPlotModel>.Instance.InstanceConditionMap = dictionary;
		int[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			IReadOnlyList<RandomPlotTrigger> configList = ConfigRandomPlotTriggerByTriggerGroupId.GetConfigList(array2[i], true);
			if (configList != null)
			{
				foreach (RandomPlotTrigger randomPlotTrigger in configList)
				{
					int id = randomPlotTrigger.Id;
					if (!dictionary.ContainsKey(id))
					{
						int triggerCondition = randomPlotTrigger.TriggerCondition;
						bool resetCondition = randomPlotTrigger.ResetCondition;
						ConditionPassCallback conditionPassCallback = new ConditionPassCallback(new TConditionPassCallback(this.OnConditionPass), new object[]
						{
							randomPlotTrigger.RandomPlotId,
							resetCondition,
							id
						});
						Singleton<LevelConditionRegistry>.Instance.RegisterConditionGroup(triggerCondition, conditionPassCallback);
						dictionary[id] = new RandomPlotCondition
						{
							ConditionGroupId = triggerCondition,
							Callback = conditionPassCallback
						};
					}
				}
			}
		}
	}

	// Token: 0x06013DAB RID: 81323 RVA: 0x00588C38 File Offset: 0x00586E38
	private void OnConditionPass([Nullable(new byte[]
	{
		2,
		1
	})] object[] parameters)
	{
		if (parameters == null)
		{
			return;
		}
		int randomPlotId = (int)parameters[0];
		this.PlayRandomPlot(randomPlotId);
		if (!(bool)parameters[1])
		{
			return;
		}
		int key = (int)parameters[2];
		Dictionary<int, IRandomPlotCondition> instanceConditionMap = ModelBase<RandomPlotModel>.Instance.InstanceConditionMap;
		IRandomPlotCondition randomPlotCondition;
		if (instanceConditionMap == null || !instanceConditionMap.TryGetValue(key, out randomPlotCondition) || randomPlotCondition == null)
		{
			return;
		}
		int conditionGroupId = randomPlotCondition.ConditionGroupId;
		ConditionPassCallback callback = randomPlotCondition.Callback;
		Singleton<LevelConditionRegistry>.Instance.UnRegisterConditionGroup(conditionGroupId, callback);
		Singleton<LevelConditionRegistry>.Instance.RegisterConditionGroup(conditionGroupId, callback);
	}

	// Token: 0x06013DAC RID: 81324 RVA: 0x00588CB8 File Offset: 0x00586EB8
	public void PlayRandomPlot(int randomPlotId)
	{
		RandomPlotItem randomPlotItem;
		if (!ModelBase<RandomPlotModel>.Instance.RandomPlotMap.TryGetValue(randomPlotId, out randomPlotItem))
		{
			RandomPlot? config = ConfigRandomPlotById.GetConfig(randomPlotId, true);
			if (config == null)
			{
				return;
			}
			randomPlotItem = RandomPlotItem.Create(config.Value);
			ModelBase<RandomPlotModel>.Instance.RandomPlotMap[randomPlotId] = randomPlotItem;
		}
		randomPlotItem.PlayRandomPlot();
	}

	// Token: 0x06013DAD RID: 81325 RVA: 0x00588D10 File Offset: 0x00586F10
	private void ClearAllCondition()
	{
		Dictionary<int, IRandomPlotCondition> instanceConditionMap = ModelBase<RandomPlotModel>.Instance.InstanceConditionMap;
		if (instanceConditionMap != null)
		{
			foreach (IRandomPlotCondition randomPlotCondition in instanceConditionMap.Values)
			{
				Singleton<LevelConditionRegistry>.Instance.UnRegisterConditionGroup(randomPlotCondition.ConditionGroupId, randomPlotCondition.Callback);
			}
			instanceConditionMap.Clear();
		}
		ModelBase<RandomPlotModel>.Instance.InstanceConditionMap = null;
	}
}
