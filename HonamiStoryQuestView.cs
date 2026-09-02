using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.HonamiStory;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001F4D RID: 8013
[NullableContext(1)]
[Nullable(0)]
public class HonamiStoryQuestView : UiViewBase
{
	// Token: 0x0600EFEB RID: 61419 RVA: 0x00418CEA File Offset: 0x00416EEA
	public HonamiStoryQuestView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600EFEC RID: 61420 RVA: 0x00418D00 File Offset: 0x00416F00
	protected unsafe override void OnRegisterComponent()
	{
		int num = 15;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIVerticalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600EFED RID: 61421 RVA: 0x00418F20 File Offset: 0x00417120
	protected override UniTask OnBeforeStartAsync()
	{
		HonamiStoryQuestView.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<HonamiStoryQuestView.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600EFEE RID: 61422 RVA: 0x00418F63 File Offset: 0x00417163
	protected override void OnBeforeShow()
	{
		base.GetItem(11).SetUIActive(false);
		base.GetItem(6).SetUIActive(false);
		base.GetItem(5).SetUIActive(false);
		this.RefreshDetail();
	}

	// Token: 0x0600EFEF RID: 61423 RVA: 0x00418F94 File Offset: 0x00417194
	private UniTask InitTaskScrollViewAsync()
	{
		HonamiStoryQuestView.<InitTaskScrollViewAsync>d__13 <InitTaskScrollViewAsync>d__;
		<InitTaskScrollViewAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitTaskScrollViewAsync>d__.<>4__this = this;
		<InitTaskScrollViewAsync>d__.<>1__state = -1;
		<InitTaskScrollViewAsync>d__.<>t__builder.Start<HonamiStoryQuestView.<InitTaskScrollViewAsync>d__13>(ref <InitTaskScrollViewAsync>d__);
		return <InitTaskScrollViewAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600EFF0 RID: 61424 RVA: 0x00418FD8 File Offset: 0x004171D8
	private void InitTaskChildItemList()
	{
		if (this.CurSelectChildItem != null)
		{
			this.CurSelectChildItem.OnDeselected();
			this.CurSelectChildItem = null;
		}
		List<HonamiStoryQuestItem> layoutItemList = this.TaskScrollVieW.GetLayoutItemList();
		this.TaskChildItemList.Clear();
		foreach (HonamiStoryQuestItem honamiStoryQuestItem in layoutItemList)
		{
			foreach (HonamiStoryQuestItemChildItem item in honamiStoryQuestItem.GetTaskChildItemList())
			{
				this.TaskChildItemList.Add(item);
			}
		}
		if (this.TaskChildItemList.Count == 0)
		{
			Singleton<Log>.Instance.Error(ELogModule.HonamiStory, ELogAuthor.LRC, "HonamiStoryQuestView 没有任务子item", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		if (this.CurSelectChildItem == null)
		{
			this.CurSelectChildItem = this.TaskChildItemList[0];
		}
		this.CurSelectChildItem.OnSelected();
	}

	// Token: 0x0600EFF1 RID: 61425 RVA: 0x004190E0 File Offset: 0x004172E0
	private void RefreshDetail()
	{
		if (this.CurSelectChildItem == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.HonamiStory, ELogAuthor.LRC, "HonamiStoryQuestView 没有当前选中任务item", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		HonamiStoryQuestDataBase data = this.CurSelectChildItem.Data;
		if (data == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.HonamiStory, ELogAuthor.LRC, "HonamiStoryQuestView 没有任务数据", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		bool isInDungeon = data.IsInDungeon;
		this.RefreshDetailTitle(data);
		base.GetText(8).SetText(data.GetDesc(), true);
		int rewardId = data.GetRewardId();
		if (rewardId == 0)
		{
			this.RewardLayout.SetActive(false);
			base.GetText(14).SetUIActive(false);
		}
		else
		{
			List<TItem> rewardItems = this.GetRewardItems(rewardId);
			bool flag = rewardItems.Count > 0;
			this.RewardLayout.RefreshByData(rewardItems, null, false);
			this.RewardLayout.SetActive(flag);
			base.GetText(14).SetUIActive(flag);
		}
		this.ConfirmButtonItem.SetActive(false);
		if (isInDungeon && data.TaskType == EHonamiStoryQuestType.Sub)
		{
			bool flag2 = data.IsFinished();
			base.GetItem(11).SetUIActive(flag2);
			if (!flag2)
			{
				this.RefreshConfirmButtonText(data);
				this.ConfirmButtonItem.SetEnableClick(true);
				this.ConfirmButtonItem.SetActive(true);
			}
		}
		if (!isInDungeon && data.TaskType == EHonamiStoryQuestType.Main)
		{
			this.ConfirmButtonItem.SetLocalTextNew("HonamiStory_MainTask_Tracking", Array.Empty<object>());
			this.ConfirmButtonItem.SetEnableClick(false);
			this.ConfirmButtonItem.SetActive(true);
		}
		this.RefreshQuestSteps(data);
	}

	// Token: 0x0600EFF2 RID: 61426 RVA: 0x0041925C File Offset: 0x0041745C
	private void RefreshDetailTitle(HonamiStoryQuestDataBase taskData)
	{
		string localTextNew = ConfigMultiTextLang.GetLocalTextNew(taskData.GetNameKey(), null);
		UUIText text = base.GetText(3);
		string newText;
		if (taskData.TaskType == EHonamiStoryQuestType.Main)
		{
			newText = StringUtils.Format("<color=#b3dffa>{0}</color>", new string[]
			{
				localTextNew
			});
			if (text != null)
			{
				text.SetRichText(true);
			}
		}
		else if (((HonamiStorySubQuestData)taskData).Config.Value.TaskType != 1)
		{
			if (text != null)
			{
				text.SetRichText(false);
			}
			newText = localTextNew;
		}
		else
		{
			if (text != null)
			{
				text.SetRichText(true);
			}
			newText = StringUtils.Format("<color=#b3dffa>{0}</color>", new string[]
			{
				localTextNew
			});
		}
		if (text != null)
		{
			text.SetText(newText, true);
		}
	}

	// Token: 0x0600EFF3 RID: 61427 RVA: 0x00419300 File Offset: 0x00417500
	private void RefreshConfirmButtonText(HonamiStoryQuestDataBase taskData)
	{
		int id = taskData.Id;
		HonamiStoryQuestDataBase curTrackTaskData = ModelBase<HonamiStoryModel>.Instance.CurTrackTaskData;
		int? num = (curTrackTaskData != null) ? new int?(curTrackTaskData.Id) : null;
		if (id == num.GetValueOrDefault() & num != null)
		{
			this.ConfirmButtonItem.SetLocalTextNew("HonamiStory_Cancel_Track", Array.Empty<object>());
			return;
		}
		this.ConfirmButtonItem.SetLocalTextNew("HonamiStory_Track", Array.Empty<object>());
	}

	// Token: 0x0600EFF4 RID: 61428 RVA: 0x00419378 File Offset: 0x00417578
	private UniTask RefreshQuestSteps(HonamiStoryQuestDataBase taskData)
	{
		HonamiStoryQuestView.<RefreshQuestSteps>d__18 <RefreshQuestSteps>d__;
		<RefreshQuestSteps>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshQuestSteps>d__.<>4__this = this;
		<RefreshQuestSteps>d__.taskData = taskData;
		<RefreshQuestSteps>d__.<>1__state = -1;
		<RefreshQuestSteps>d__.<>t__builder.Start<HonamiStoryQuestView.<RefreshQuestSteps>d__18>(ref <RefreshQuestSteps>d__);
		return <RefreshQuestSteps>d__.<>t__builder.Task;
	}

	// Token: 0x0600EFF5 RID: 61429 RVA: 0x004193C4 File Offset: 0x004175C4
	private void OnClickTaskToggle(HonamiStoryQuestItemChildItem taskItem)
	{
		if (this.CurSelectChildItem == taskItem)
		{
			return;
		}
		HonamiStoryQuestItemChildItem curSelectChildItem = this.CurSelectChildItem;
		if (curSelectChildItem != null)
		{
			curSelectChildItem.OnDeselected();
		}
		this.CurSelectChildItem = taskItem;
		this.CurSelectChildItem.OnSelected();
		this.RefreshDetail();
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (((levelSequencePlayer != null) ? levelSequencePlayer.GetCurrentSequence() : null) != "Switch")
		{
			LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
			if (levelSequencePlayer2 == null)
			{
				return;
			}
			levelSequencePlayer2.PlayLevelSequenceByName("Switch", false, null, false);
			return;
		}
		else
		{
			LevelSequencePlayer levelSequencePlayer3 = this.LevelSequencePlayer;
			if (levelSequencePlayer3 == null)
			{
				return;
			}
			levelSequencePlayer3.ReplaySequenceByKey("Switch");
			return;
		}
	}

	// Token: 0x0600EFF6 RID: 61430 RVA: 0x00419458 File Offset: 0x00417658
	private HonamiStoryQuestItem InitTaskItem()
	{
		HonamiStoryQuestItem honamiStoryQuestItem = new HonamiStoryQuestItem();
		honamiStoryQuestItem.BindOnClickTask(new Action<HonamiStoryQuestItemChildItem>(this.OnClickTaskToggle));
		return honamiStoryQuestItem;
	}

	// Token: 0x0600EFF7 RID: 61431 RVA: 0x00419471 File Offset: 0x00417671
	private CommonItemSmallItemGrid InitRewardItem()
	{
		return new CommonItemSmallItemGrid();
	}

	// Token: 0x0600EFF8 RID: 61432 RVA: 0x00419478 File Offset: 0x00417678
	private List<TItem> GetRewardItems(int dropId)
	{
		List<TItem> list = new List<TItem>();
		Dictionary<int, int> dropPackagePreview = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackagePreview(dropId);
		HonamiStoryQuestItemChildItem curSelectChildItem = this.CurSelectChildItem;
		HonamiStoryQuestDataBase honamiStoryQuestDataBase = (curSelectChildItem != null) ? curSelectChildItem.Data : null;
		foreach (KeyValuePair<int, int> keyValuePair in dropPackagePreview)
		{
			int num;
			int num2;
			keyValuePair.Deconstruct(out num, out num2);
			int itemId = num;
			int num3 = num2;
			if (honamiStoryQuestDataBase != null && honamiStoryQuestDataBase.TaskType == EHonamiStoryQuestType.Sub)
			{
				int count = num3 * ModelBase<HonamiStoryModel>.Instance.GetSubTaskBonusDataList();
				list.Add(new TItem(new InventoryDefine.GetItemData(itemId, 0), count));
			}
			else
			{
				list.Add(new TItem(new InventoryDefine.GetItemData(itemId, 0), num3));
			}
		}
		return list;
	}

	// Token: 0x0600EFF9 RID: 61433 RVA: 0x0041953C File Offset: 0x0041773C
	private void OnClickConfirm(int _)
	{
		HonamiStoryQuestItemChildItem curSelectChildItem = this.CurSelectChildItem;
		HonamiStoryQuestDataBase honamiStoryQuestDataBase = (curSelectChildItem != null) ? curSelectChildItem.Data : null;
		if (honamiStoryQuestDataBase == null)
		{
			return;
		}
		ModelBase<HonamiStoryModel>.Instance.SetSubQuestTrack(honamiStoryQuestDataBase);
		base.CloseMe(null);
	}

	// Token: 0x04007357 RID: 29527
	[Nullable(2)]
	private PopupCaptionItem CaptionItem;

	// Token: 0x04007358 RID: 29528
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<HonamiStoryQuestItem, EHonamiStoryQuestType> TaskScrollVieW;

	// Token: 0x04007359 RID: 29529
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<CommonItemSmallItemGrid, TItem> RewardLayout;

	// Token: 0x0400735A RID: 29530
	[Nullable(2)]
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x0400735B RID: 29531
	private ButtonItem ConfirmButtonItem;

	// Token: 0x0400735C RID: 29532
	[Nullable(2)]
	private QuestViewStep QuestViewStep;

	// Token: 0x0400735D RID: 29533
	[Nullable(2)]
	private HonamiStoryQuestItemChildItem CurSelectChildItem;

	// Token: 0x0400735E RID: 29534
	private readonly List<HonamiStoryQuestItemChildItem> TaskChildItemList = new List<HonamiStoryQuestItemChildItem>();

	// Token: 0x020082D4 RID: 33492
	[NullableContext(0)]
	private enum EHonamiStoryQuestComponents
	{
		// Token: 0x0402C5BC RID: 181692
		CaptionItem,
		// Token: 0x0402C5BD RID: 181693
		TaskScrollView,
		// Token: 0x0402C5BE RID: 181694
		TaskItem,
		// Token: 0x0402C5BF RID: 181695
		TaskNameText,
		// Token: 0x0402C5C0 RID: 181696
		DetailsStepsRoot,
		// Token: 0x0402C5C1 RID: 181697
		ParentStep,
		// Token: 0x0402C5C2 RID: 181698
		TimeNode,
		// Token: 0x0402C5C3 RID: 181699
		TimeText,
		// Token: 0x0402C5C4 RID: 181700
		TaskDescriptionText,
		// Token: 0x0402C5C5 RID: 181701
		RewardScrollView,
		// Token: 0x0402C5C6 RID: 181702
		RewardItem,
		// Token: 0x0402C5C7 RID: 181703
		PanelDetailTipsNode,
		// Token: 0x0402C5C8 RID: 181704
		BtnLeft,
		// Token: 0x0402C5C9 RID: 181705
		BtnRight,
		// Token: 0x0402C5CA RID: 181706
		RewardTitleText
	}
}
