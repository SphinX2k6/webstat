using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.PayShop;
using Google.Protobuf.Collections;

// Token: 0x02001254 RID: 4692
[NullableContext(1)]
[Nullable(0)]
public class BeginnerCarnivalData : ActivityBaseData
{
	// Token: 0x17000AAC RID: 2732
	// (get) Token: 0x06007D11 RID: 32017 RVA: 0x0020F137 File Offset: 0x0020D337
	public Dictionary<int, List<ActivityTask>> TaskDataMap { get; } = new Dictionary<int, List<ActivityTask>>();

	// Token: 0x17000AAD RID: 2733
	// (get) Token: 0x06007D12 RID: 32018 RVA: 0x0020F13F File Offset: 0x0020D33F
	public Dictionary<int, List<int>> JumpTaskMap { get; } = new Dictionary<int, List<int>>();

	// Token: 0x17000AAE RID: 2734
	// (get) Token: 0x06007D13 RID: 32019 RVA: 0x0020F147 File Offset: 0x0020D347
	public List<int> GachaId { get; } = new List<int>();

	// Token: 0x17000AAF RID: 2735
	// (get) Token: 0x06007D14 RID: 32020 RVA: 0x0020F14F File Offset: 0x0020D34F
	public List<int> GiftId { get; } = new List<int>();

	// Token: 0x06007D15 RID: 32021 RVA: 0x0020F158 File Offset: 0x0020D358
	protected override void PhraseEx(ActivityData data)
	{
		this.TaskDataMap.Clear();
		NewbieCarnivalData newbieCarnivalData = data.NewbieCarnivalData;
		RepeatedField<ActivityTask> repeatedField;
		if (newbieCarnivalData == null)
		{
			repeatedField = null;
		}
		else
		{
			Aki.Protocol.ActivityTaskData activityTaskData = newbieCarnivalData.ActivityTaskData;
			repeatedField = ((activityTaskData != null) ? activityTaskData.ActivityTasks : null);
		}
		RepeatedField<ActivityTask> repeatedField2 = repeatedField;
		if (repeatedField2 != null)
		{
			foreach (ActivityTask activityTask in repeatedField2)
			{
				NewbieCarnivalTask? newbieCarnivalTask = ConfigBase<BeginnerCarnivalConfig>.Instance.GetNewbieCarnivalTask(activityTask.Id);
				if (newbieCarnivalTask != null)
				{
					List<ActivityTask> list;
					if (!this.TaskDataMap.TryGetValue(newbieCarnivalTask.Value.TaskType, out list) || list == null)
					{
						list = new List<ActivityTask>();
					}
					list.Add(activityTask);
					this.TaskDataMap[newbieCarnivalTask.Value.TaskType] = list;
				}
			}
		}
		this.JumpTaskMap.Clear();
		NewbieCarnivalData newbieCarnivalData2 = data.NewbieCarnivalData;
		RepeatedField<JumpTaskCondInfo> repeatedField3 = (newbieCarnivalData2 != null) ? newbieCarnivalData2.JumpTaskCondInfos : null;
		if (repeatedField3 != null)
		{
			foreach (JumpTaskCondInfo jumpTaskCondInfo in repeatedField3)
			{
				this.JumpTaskMap[jumpTaskCondInfo.JumpTaskId] = new List<int>(jumpTaskCondInfo.ConditionGroupIds);
			}
		}
		this.ChoseRoleId = ((data.NewbieCarnivalData != null) ? data.NewbieCarnivalData.RoleId : 0);
		NewbieCarnivalParam value = ConfigBase<BeginnerCarnivalConfig>.Instance.GetNewbieCarnivalParam(data.Id).Value;
		this.ItemId = value.ItemId;
		this.GachaId.Clear();
		this.GachaId.AddRange(value.GetGachaIdsArray().ToArray<int>());
		this.GiftId.Clear();
		this.GiftId.AddRange(value.GetPayGiftsArray());
		this.GetRoleTaskId = ConfigBase<BeginnerCarnivalConfig>.Instance.GetNewbieCarnivalTaskByTaskType(0).Value.TaskId;
	}

	// Token: 0x06007D16 RID: 32022 RVA: 0x0020F350 File Offset: 0x0020D550
	[NullableContext(0)]
	public ValueTuple<int, int> GetProgress(int typeId)
	{
		List<ActivityTask> list;
		if (!this.TaskDataMap.TryGetValue(typeId, out list) || list == null)
		{
			return new ValueTuple<int, int>(0, 0);
		}
		int count = list.Count;
		int num = 0;
		using (List<ActivityTask>.Enumerator enumerator = list.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.Status == ActivityTaskState.ActivityTaskTaken)
				{
					num++;
				}
			}
		}
		return new ValueTuple<int, int>(num, count);
	}

	// Token: 0x06007D17 RID: 32023 RVA: 0x0020F3D0 File Offset: 0x0020D5D0
	[NullableContext(2)]
	public ActivityTask GetTaskDataById(int taskId)
	{
		foreach (KeyValuePair<int, List<ActivityTask>> keyValuePair in this.TaskDataMap)
		{
			foreach (ActivityTask activityTask in keyValuePair.Value)
			{
				if (activityTask.Id == taskId)
				{
					return activityTask;
				}
			}
		}
		return null;
	}

	// Token: 0x06007D18 RID: 32024 RVA: 0x0020F46C File Offset: 0x0020D66C
	public List<int> GetTaskIdListByTypeId(int typeId)
	{
		List<int> list = new List<int>();
		List<ActivityTask> list2;
		if (this.TaskDataMap.TryGetValue(typeId, out list2) && list2 != null)
		{
			foreach (ActivityTask activityTask in list2)
			{
				list.Add(activityTask.Id);
			}
		}
		return list;
	}

	// Token: 0x06007D19 RID: 32025 RVA: 0x0020F4DC File Offset: 0x0020D6DC
	public bool GetAnyRedDotShow()
	{
		foreach (KeyValuePair<int, List<ActivityTask>> keyValuePair in this.TaskDataMap)
		{
			using (List<ActivityTask>.Enumerator enumerator2 = keyValuePair.Value.GetEnumerator())
			{
				while (enumerator2.MoveNext())
				{
					if (enumerator2.Current.Status == ActivityTaskState.ActivityTaskFinish)
					{
						return true;
					}
				}
			}
		}
		if (ModelBase<FunctionModel>.Instance.IsOpen(10009) && ModelBase<GachaModel>.Instance.GachaInfoArray != null && !this.GetHaveGachaEnter())
		{
			bool gachaInfo = ModelBase<GachaModel>.Instance.GetGachaInfo(this.GachaId[0]) != null;
			ProtoGachaInfo gachaInfo2 = ModelBase<GachaModel>.Instance.GetGachaInfo(this.GachaId[1]);
			if (gachaInfo || gachaInfo2 != null)
			{
				return true;
			}
		}
		if (ModelBase<FunctionModel>.Instance.IsOpen(10010) && !this.GetHaveShopEnter())
		{
			bool flag = false;
			foreach (PayShopGoods payShopGoods in ModelBase<PayShopModel>.Instance.GetPayShopTabData(PayShopDefine.EPayShopTabType.GiftBag, 5, true))
			{
				IRemainingData remainingData = payShopGoods.GetRemainingData();
				if (remainingData != null && remainingData.Count > 0)
				{
					flag = true;
					break;
				}
			}
			if (flag)
			{
				return true;
			}
		}
		return this.ChoseRoleId == 0;
	}

	// Token: 0x06007D1A RID: 32026 RVA: 0x0020F658 File Offset: 0x0020D858
	public bool GetAnyTaskRedDotShow()
	{
		foreach (KeyValuePair<int, List<ActivityTask>> keyValuePair in this.TaskDataMap)
		{
			using (List<ActivityTask>.Enumerator enumerator2 = keyValuePair.Value.GetEnumerator())
			{
				while (enumerator2.MoveNext())
				{
					if (enumerator2.Current.Status == ActivityTaskState.ActivityTaskFinish)
					{
						return true;
					}
				}
			}
		}
		return false;
	}

	// Token: 0x06007D1B RID: 32027 RVA: 0x0020F6F0 File Offset: 0x0020D8F0
	public bool GetTabRedDotShow(int tabIndex)
	{
		List<ActivityTask> list;
		if (!this.TaskDataMap.TryGetValue(tabIndex, out list) || list == null)
		{
			return false;
		}
		using (List<ActivityTask>.Enumerator enumerator = list.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.Status == ActivityTaskState.ActivityTaskFinish)
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x06007D1C RID: 32028 RVA: 0x0020F75C File Offset: 0x0020D95C
	public bool GetRoleGetTaskTabRedDotShow(int tabIndex)
	{
		List<ActivityTask> list;
		if (!this.TaskDataMap.TryGetValue(tabIndex, out list) || list == null)
		{
			return false;
		}
		using (List<ActivityTask>.Enumerator enumerator = list.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.Status == ActivityTaskState.ActivityTaskFinish)
				{
					return true;
				}
			}
		}
		List<ActivityTask> list2;
		using (List<ActivityTask>.Enumerator enumerator = ((this.TaskDataMap.TryGetValue(0, out list2) && list2 != null) ? list2 : new List<ActivityTask>()).GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.Status == ActivityTaskState.ActivityTaskFinish)
				{
					return true;
				}
			}
		}
		return this.ChoseRoleId == 0;
	}

	// Token: 0x06007D1D RID: 32029 RVA: 0x0020F82C File Offset: 0x0020DA2C
	public override bool GetExDataRedPointShowState()
	{
		return this.GetAnyRedDotShow();
	}

	// Token: 0x06007D1E RID: 32030 RVA: 0x0020F834 File Offset: 0x0020DA34
	public int GetCurrentItemCount()
	{
		if (this.ItemId == 0)
		{
			return 0;
		}
		return ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(this.ItemId, 0);
	}

	// Token: 0x06007D1F RID: 32031 RVA: 0x0020F854 File Offset: 0x0020DA54
	public bool GetHaveShopEnter()
	{
		bool player = LocalStorage.GetPlayer<bool>(ELocalStoragePlayerKey.BeginnerCarnivalShop, false);
		return player && player;
	}

	// Token: 0x06007D20 RID: 32032 RVA: 0x0020F873 File Offset: 0x0020DA73
	public void SetShopEnter()
	{
		LocalStorage.SetPlayer<bool>(ELocalStoragePlayerKey.BeginnerCarnivalShop, true);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
	}

	// Token: 0x06007D21 RID: 32033 RVA: 0x0020F898 File Offset: 0x0020DA98
	public bool GetHaveGachaEnter()
	{
		bool player = LocalStorage.GetPlayer<bool>(ELocalStoragePlayerKey.BeginnerCarnivalGacha, false);
		return player && player;
	}

	// Token: 0x06007D22 RID: 32034 RVA: 0x0020F8B7 File Offset: 0x0020DAB7
	public void SetGachaEnter()
	{
		LocalStorage.SetPlayer<bool>(ELocalStoragePlayerKey.BeginnerCarnivalGacha, true);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
	}

	// Token: 0x06007D23 RID: 32035 RVA: 0x0020F8DC File Offset: 0x0020DADC
	public bool GetHaveChoseRoleViewEnter()
	{
		bool player = LocalStorage.GetPlayer<bool>(ELocalStoragePlayerKey.BeginnerCarnivalChoseRoleView, false);
		return player && player;
	}

	// Token: 0x06007D24 RID: 32036 RVA: 0x0020F8FB File Offset: 0x0020DAFB
	public void SetChoseRoleViewEnter()
	{
		LocalStorage.SetPlayer<bool>(ELocalStoragePlayerKey.BeginnerCarnivalChoseRoleView, true);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
	}

	// Token: 0x04003BD8 RID: 15320
	public int ChoseRoleId;

	// Token: 0x04003BD9 RID: 15321
	public int GetRoleTaskId;

	// Token: 0x04003BDA RID: 15322
	public int ItemId;
}
