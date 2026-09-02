using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Module.SkipInterface;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001260 RID: 4704
[NullableContext(1)]
[Nullable(0)]
public class BeginnerCarnivalTaskItem : GridProxyAbstract<int>
{
	// Token: 0x06007D58 RID: 32088 RVA: 0x00211024 File Offset: 0x0020F224
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(6, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(9, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(1, new Action(this.OnClickGetBtn)),
			new ValueTuple<int, Delegate>(8, new Action(this.OnClickCanNotJumpBtn)),
			new ValueTuple<int, Delegate>(0, new Action(this.OnClickJumpBtn))
		};
	}

	// Token: 0x06007D59 RID: 32089 RVA: 0x0021116C File Offset: 0x0020F36C
	protected override void OnStart()
	{
		this.ScrollView = new GenericScrollViewNew<CommonItemSmallItemGrid, TItem>(base.GetScrollViewWithScrollbar(6), new Func<CommonItemSmallItemGrid>(this.CreatePropItem), null, false, null);
	}

	// Token: 0x06007D5A RID: 32090 RVA: 0x0021118F File Offset: 0x0020F38F
	private CommonItemSmallItemGrid CreatePropItem()
	{
		return new CommonItemSmallItemGrid();
	}

	// Token: 0x06007D5B RID: 32091 RVA: 0x00211198 File Offset: 0x0020F398
	public override void Refresh(int data, bool isSelected, int gridIndex)
	{
		this.TaskId = data;
		BeginnerCarnivalData beginnerCarnivalData = ControllerBase<BeginnerCarnivalController>.Instance.GetBeginnerCarnivalData();
		ActivityTask taskDataById = beginnerCarnivalData.GetTaskDataById(this.TaskId);
		NewbieCarnivalTask? newbieCarnivalTask = ConfigBase<BeginnerCarnivalConfig>.Instance.GetNewbieCarnivalTask(this.TaskId);
		this.SkipId = newbieCarnivalTask.Value.JumpId;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), newbieCarnivalTask.Value.TaskName, Array.Empty<object>());
		UUIText text = base.GetText(5);
		int num = taskDataById.Current;
		text.SetText(num.ToString() + "/" + taskDataById.Target.ToString(), true);
		List<TItem> dropPackagePreviewItemList = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackagePreviewItemList(newbieCarnivalTask.Value.TaskReward);
		this.ScrollView.RefreshByData(dropPackagePreviewItemList, null, false);
		bool uiactive = taskDataById.Status == ActivityTaskState.ActivityTaskTaken;
		base.GetItem(3).SetUIActive(uiactive);
		bool uiactive2 = taskDataById.Status == ActivityTaskState.ActivityTaskFinish;
		base.GetButton(1).RootUIComp.Get().SetUIActive(uiactive2);
		base.GetItem(9).SetUIActive(uiactive2);
		bool flag = taskDataById.Status == ActivityTaskState.ActivityTaskRunning;
		bool flag2 = newbieCarnivalTask.Value.JumpId > 0;
		List<int> list;
		if (!beginnerCarnivalData.JumpTaskMap.TryGetValue(this.TaskId, out list) || list == null)
		{
			list = new List<int>();
		}
		bool flag3 = list.Count >= newbieCarnivalTask.Value.JumpConditionGroupsLength;
		this.HaveDoneConditionGroupList = list;
		base.GetButton(0).RootUIComp.Get().SetUIActive(flag && flag2 && flag3);
		base.GetItem(7).SetUIActive(flag && flag2 && !flag3);
		base.GetText(2).SetUIActive(flag && !flag2);
	}

	// Token: 0x06007D5C RID: 32092 RVA: 0x00211375 File Offset: 0x0020F575
	private void OnClickGetBtn()
	{
		ControllerBase<BeginnerCarnivalController>.Instance.NewbieCarnivalAwardRequest(this.TaskId);
	}

	// Token: 0x06007D5D RID: 32093 RVA: 0x00211388 File Offset: 0x0020F588
	private void OnClickCanNotJumpBtn()
	{
		List<IActivityConditionData> list = new List<IActivityConditionData>();
		NewbieCarnivalTask value = ConfigBase<BeginnerCarnivalConfig>.Instance.GetNewbieCarnivalTask(this.TaskId).Value;
		for (int i = 0; i < value.JumpConditionGroupsLength; i++)
		{
			int conditionGroupId = value.JumpConditionGroups(i);
			foreach (int num in ConfigBase<ConditionConfig>.Instance.GetGroupConditionIds(conditionGroupId))
			{
				Condition value2 = ConfigBase<ConditionConfig>.Instance.GetConditionConfig(num).Value;
				int accessType = -1;
				if (value2.AccessId != 0)
				{
					accessType = ConfigBase<GetWayConfig>.Instance.GetConfigById(value2.AccessId).Value.SkipName;
				}
				ActivityConditionData item = new ActivityConditionData
				{
					ConditionId = num,
					ConditionTextId = value2.Description,
					IsFinished = this.IsConditionFinished(num),
					AccessId = value2.AccessId,
					AccessType = accessType
				};
				list.Add(item);
			}
		}
		ConditionGroupData param = new ConditionGroupData(value.JumpConditionGroup, list, "", false);
		Singleton<UiManager>.Instance.OpenView(EUiViewName.CommonConditionView, param, null);
	}

	// Token: 0x06007D5E RID: 32094 RVA: 0x002114BD File Offset: 0x0020F6BD
	private bool IsConditionFinished(int conditionGroupId)
	{
		return this.HaveDoneConditionGroupList.Contains(conditionGroupId);
	}

	// Token: 0x06007D5F RID: 32095 RVA: 0x002114CB File Offset: 0x0020F6CB
	private void OnClickJumpBtn()
	{
		if (this.SkipId <= 0)
		{
			return;
		}
		SkipTaskManager.RunByConfigId(this.SkipId, null);
	}

	// Token: 0x04003C2D RID: 15405
	private int TaskId;

	// Token: 0x04003C2E RID: 15406
	private int SkipId;

	// Token: 0x04003C2F RID: 15407
	private List<int> HaveDoneConditionGroupList = new List<int>();

	// Token: 0x04003C30 RID: 15408
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericScrollViewNew<CommonItemSmallItemGrid, TItem> ScrollView;
}
