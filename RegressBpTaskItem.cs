using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x0200153A RID: 5434
internal class RegressBpTaskItem : GridProxyAbstract<RegressQuest>
{
	// Token: 0x0600985C RID: 39004 RVA: 0x0027E438 File Offset: 0x0027C638
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(5, typeof(UUISprite)),
			new ValueTuple<int, Type>(6, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(7, typeof(UUIText)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUISprite)),
			new ValueTuple<int, Type>(10, typeof(UUISprite)),
			new ValueTuple<int, Type>(11, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(4, new Action(this.OnClickBtn)),
			new ValueTuple<int, Delegate>(6, new Action(this.OnClickBtn))
		};
	}

	// Token: 0x0600985D RID: 39005 RVA: 0x0027E596 File Offset: 0x0027C796
	protected override void OnStart()
	{
		this.RewardListView = new GenericScrollViewNew<CommonItemSmallItemGrid, TItem>(base.GetScrollViewWithScrollbar(2), new Func<CommonItemSmallItemGrid>(this.CreateRewardItem), null, false, null);
	}

	// Token: 0x0600985E RID: 39006 RVA: 0x0027E5B9 File Offset: 0x0027C7B9
	[NullableContext(1)]
	private CommonItemSmallItemGrid CreateRewardItem()
	{
		return new CommonItemSmallItemGrid();
	}

	// Token: 0x0600985F RID: 39007 RVA: 0x0027E5C0 File Offset: 0x0027C7C0
	public override void Refresh(RegressQuest data, bool isSelected, int gridIndex)
	{
		this.Data = new RegressQuest?(data);
		base.GridIndex = gridIndex;
		UUIText text = base.GetText(0);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text, data.TargetName, Array.Empty<object>());
		int id = data.Id;
		ValueTuple<int, int> taskProgressTuple = ModelBase<ActivityRegressModel>.Instance.ActivityData.GetTaskProgressTuple(id);
		int item = taskProgressTuple.Item1;
		int item2 = taskProgressTuple.Item2;
		UUIText text2 = base.GetText(1);
		if (this.IsShowTag() && data.TaskType == 0)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text2, "Recall_BP_Task_Repeat", new <>z__ReadOnlyArray<object>(new object[]
			{
				item,
				item2
			}));
		}
		else
		{
			UUIText uuitext = text2;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(item);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(item2);
			uuitext.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		}
		ERegressRewardState taskRewardState = ModelBase<ActivityRegressModel>.Instance.ActivityData.GetTaskRewardState(id);
		this.RefreshRewardLayout();
		base.GetButton(4).RootUIComp.Get().SetUIActive(taskRewardState == ERegressRewardState.UnReach);
		base.GetButton(6).RootUIComp.Get().SetUIActive(taskRewardState == ERegressRewardState.Reached);
		base.GetSprite(5).SetUIActive(taskRewardState == ERegressRewardState.Claim);
		this.RefreshTag();
	}

	// Token: 0x06009860 RID: 39008 RVA: 0x0027E710 File Offset: 0x0027C910
	private void RefreshRewardLayout()
	{
		List<TItem> dropPreviewRewardItemListForPreview = ModelBase<ActivityRegressModel>.Instance.GetDropPreviewRewardItemListForPreview(this.Data.Value.TargetReward);
		this.RewardListView.RefreshByData(dropPreviewRewardItemListForPreview, null, false);
	}

	// Token: 0x06009861 RID: 39009 RVA: 0x0027E74C File Offset: 0x0027C94C
	private bool IsShowTag()
	{
		RegressQuest value = this.Data.Value;
		ERegressTaskType taskType = (ERegressTaskType)value.TaskType;
		ERegressConstantTaskSubType taskSubType = (ERegressConstantTaskSubType)value.TaskSubType;
		bool flag = taskType == ERegressTaskType.Cultivate || taskType == ERegressTaskType.Once;
		if (taskType == ERegressTaskType.Constant && taskSubType != ERegressConstantTaskSubType.Explore && taskSubType != ERegressConstantTaskSubType.MainQuestAndRole)
		{
			flag = true;
		}
		return !flag;
	}

	// Token: 0x06009862 RID: 39010 RVA: 0x0027E794 File Offset: 0x0027C994
	private void RefreshTag()
	{
		RegressQuest value = this.Data.Value;
		UUIItem item = base.GetItem(8);
		ERegressTaskType taskType = (ERegressTaskType)value.TaskType;
		if (!this.IsShowTag())
		{
			item.SetUIActive(false);
			return;
		}
		item.SetUIActive(true);
		UUISprite sprite = base.GetSprite(9);
		UUISprite sprite2 = base.GetSprite(10);
		UUIText text = base.GetText(11);
		if (taskType == ERegressTaskType.Constant)
		{
			sprite.SetUIActive(true);
			sprite2.SetUIActive(false);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "Recall_BP_Task_Type_2", Array.Empty<object>());
			return;
		}
		if (taskType == ERegressTaskType.Daily)
		{
			sprite.SetUIActive(false);
			sprite2.SetUIActive(true);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "Recall_BP_Task_Type_1", Array.Empty<object>());
		}
	}

	// Token: 0x06009863 RID: 39011 RVA: 0x0027E844 File Offset: 0x0027CA44
	private void OnClickBtn()
	{
		RegressQuest value = this.Data.Value;
		int id = value.Id;
		ERegressRewardState taskRewardState = ModelBase<ActivityRegressModel>.Instance.ActivityData.GetTaskRewardState(id);
		if (taskRewardState == ERegressRewardState.UnReach)
		{
			ControllerBase<ActivityRegressController>.Instance.JumpByQuestConfig(value);
			return;
		}
		if (taskRewardState == ERegressRewardState.Reached)
		{
			if (ModelBase<ActivityRegressModel>.Instance.ActivityData.IsRegressTaskScoreOverExp())
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("RecallActivity_Task_Max", Array.Empty<object>());
			}
			ControllerBase<ActivityRegressController>.Instance.RequestClaimTaskReward(id);
		}
	}

	// Token: 0x0400468D RID: 18061
	private RegressQuest? Data;

	// Token: 0x0400468E RID: 18062
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericScrollViewNew<CommonItemSmallItemGrid, TItem> RewardListView;

	// Token: 0x020078F1 RID: 30961
	private class EMissionComponents
	{
		// Token: 0x04029908 RID: 170248
		public const int TxtName = 0;

		// Token: 0x04029909 RID: 170249
		public const int TxtProgress = 1;

		// Token: 0x0402990A RID: 170250
		public const int RewardScroll = 2;

		// Token: 0x0402990B RID: 170251
		public const int ItemReward = 3;

		// Token: 0x0402990C RID: 170252
		public const int BtnJump = 4;

		// Token: 0x0402990D RID: 170253
		public const int SpriteMask = 5;

		// Token: 0x0402990E RID: 170254
		public const int BtnGetReward = 6;

		// Token: 0x0402990F RID: 170255
		public const int TxtDoing = 7;

		// Token: 0x04029910 RID: 170256
		public const int PanelTag = 8;

		// Token: 0x04029911 RID: 170257
		public const int SpriteTagBlue = 9;

		// Token: 0x04029912 RID: 170258
		public const int SpriteTagYellow = 10;

		// Token: 0x04029913 RID: 170259
		public const int TxtTagDesc = 11;
	}
}
