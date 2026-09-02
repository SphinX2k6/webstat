using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.SkipInterface;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001358 RID: 4952
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class LongShanTaskItem : GridProxyAbstract<LongShanTaskInfo>
{
	// Token: 0x0600879A RID: 34714 RVA: 0x0023BD00 File Offset: 0x00239F00
	protected unsafe override void OnRegisterComponent()
	{
		int num = 8;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickJump));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnClickGetButton));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600879B RID: 34715 RVA: 0x0023BE90 File Offset: 0x0023A090
	protected override UniTask OnBeforeStartAsync()
	{
		LongShanTaskItem.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<LongShanTaskItem.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600879C RID: 34716 RVA: 0x0023BED3 File Offset: 0x0023A0D3
	private CommonItemSmallItemGrid CreatePropItem()
	{
		return new CommonItemSmallItemGrid();
	}

	// Token: 0x0600879D RID: 34717 RVA: 0x0023BEDC File Offset: 0x0023A0DC
	public override void Refresh(LongShanTaskInfo data, bool isSelected, int gridIndex)
	{
		this.TaskInfo = data;
		this.TaskId = data.Id;
		LongShanTask value = ConfigLongShanTaskById.GetConfig(this.TaskId, true).Value;
		List<TItem> list = new List<TItem>();
		for (int i = 0; i < value.TaskRewardLength; i++)
		{
			int key = value.TaskReward(i).Value.Key;
			int value2 = value.TaskReward(i).Value.Value;
			TItem item = new TItem(new InventoryDefine.GetItemData(key, 0), value2);
			list.Add(item);
		}
		this.RewardScrollView.RefreshByData(list, null, false);
		base.GetButton(1).RootUIComp.Get().SetUIActive(data.IsFinished && !data.IsTaken);
		base.GetItem(3).SetUIActive(data.IsTaken);
		base.GetItem(2).SetUIActive(!data.IsFinished && value.JumpId == 0);
		base.GetButton(0).RootUIComp.Get().SetUIActive(!data.IsFinished && data.UnlockConditionFinish && value.JumpId > 0);
		FunctionalPanelConditionLock panelLock = this.PanelLock;
		if (panelLock != null)
		{
			panelLock.SetUiActive(!data.IsFinished && !data.UnlockConditionFinish && value.JumpId > 0);
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), value.TaskName, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), "LongShanStage_Progress", new <>z__ReadOnlyArray<object>(new object[]
		{
			data.Current,
			data.Target
		}));
	}

	// Token: 0x0600879E RID: 34718 RVA: 0x0023C0A8 File Offset: 0x0023A2A8
	private bool IsConditionFinished(int conditionId)
	{
		foreach (int num in this.TaskInfo.FinishConditions)
		{
			if (conditionId == num)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x0600879F RID: 34719 RVA: 0x0023C100 File Offset: 0x0023A300
	private void OnClickLockButton()
	{
		LongShanTaskInfo taskInfo = this.TaskInfo;
		if (taskInfo == null || !taskInfo.UnlockConditionFinish)
		{
			List<IActivityConditionData> list = new List<IActivityConditionData>();
			foreach (int conditionId in ConfigBase<ConditionConfig>.Instance.GetGroupConditionIds(this.TaskInfo.UnlockConditionId))
			{
				Condition value = ConfigBase<ConditionConfig>.Instance.GetConditionConfig(conditionId).Value;
				int accessType = -1;
				if (value.AccessId != 0)
				{
					accessType = ConfigBase<GetWayConfig>.Instance.GetConfigById(value.AccessId).Value.SkipName;
				}
				ActivityConditionData item = new ActivityConditionData
				{
					ConditionId = conditionId,
					ConditionTextId = value.Description,
					IsFinished = this.IsConditionFinished(conditionId),
					AccessId = value.AccessId,
					AccessType = accessType
				};
				list.Add(item);
			}
			ConditionGroupData param = new ConditionGroupData(this.TaskInfo.UnlockConditionId, list, null, false);
			Singleton<UiManager>.Instance.OpenView(EUiViewName.CommonConditionView, param, null);
		}
	}

	// Token: 0x060087A0 RID: 34720 RVA: 0x0023C210 File Offset: 0x0023A410
	private void OnClickJump()
	{
		SkipTaskManager.RunByConfigId(ConfigLongShanTaskById.GetConfig(this.TaskId, true).Value.JumpId, null);
	}

	// Token: 0x060087A1 RID: 34721 RVA: 0x0023C23F File Offset: 0x0023A43F
	private void OnClickGetButton()
	{
		ControllerBase<ActivityLongShanController>.Instance.TakeTaskReward(this.TaskId);
	}

	// Token: 0x04003FDA RID: 16346
	private int TaskId;

	// Token: 0x04003FDB RID: 16347
	[Nullable(2)]
	private LongShanTaskInfo TaskInfo;

	// Token: 0x04003FDC RID: 16348
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericScrollViewNew<CommonItemSmallItemGrid, TItem> RewardScrollView;

	// Token: 0x04003FDD RID: 16349
	[Nullable(2)]
	private FunctionalPanelConditionLock PanelLock;

	// Token: 0x020076FE RID: 30462
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x04028FAD RID: 167853
		public const int JumpBtn = 0;

		// Token: 0x04028FAE RID: 167854
		public const int GetBtn = 1;

		// Token: 0x04028FAF RID: 167855
		public const int DoingText = 2;

		// Token: 0x04028FB0 RID: 167856
		public const int FinishItem = 3;

		// Token: 0x04028FB1 RID: 167857
		public const int TxtName = 4;

		// Token: 0x04028FB2 RID: 167858
		public const int ProgressText = 5;

		// Token: 0x04028FB3 RID: 167859
		public const int RewardScroll = 6;

		// Token: 0x04028FB4 RID: 167860
		public const int ItemLockPanel = 7;
	}
}
