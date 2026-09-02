using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.AdventureGuide;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;

// Token: 0x02001743 RID: 5955
[NullableContext(1)]
[Nullable(0)]
public class AdventureTargetView : UiTabViewBase
{
	// Token: 0x0600A761 RID: 42849 RVA: 0x002C7B80 File Offset: 0x002C5D80
	protected unsafe override void OnRegisterComponent()
	{
		int num = 20;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUILayoutBase));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(19, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(20, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(21, typeof(UUIText));
		this.ComponentRegisterInfos = list;
		num2 = 3;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnRewardBtnClick));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnPreBtnClick));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.OnNextBtnClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600A762 RID: 42850 RVA: 0x002C7ECC File Offset: 0x002C60CC
	protected override void AddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<IReadOnlyList<int>>(EEventName.AdventureTaskStateChange, new Action<IReadOnlyList<int>>(this.OnTaskStateChange));
		Singleton<EventSystem>.Instance.Add(EEventName.ChapterRewardReceived, new Action<int>(this.OnChapterRewardReceived));
		Singleton<EventSystem>.Instance.Add(EEventName.OnCloseRewardView, new Action(this.OnCloseRewardView));
	}

	// Token: 0x0600A763 RID: 42851 RVA: 0x002C7F30 File Offset: 0x002C6130
	protected override void RemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.AdventureTaskStateChange, new Action<IReadOnlyList<int>>(this.OnTaskStateChange));
		Singleton<EventSystem>.Instance.Remove(EEventName.ChapterRewardReceived, new Action<int>(this.OnChapterRewardReceived));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnCloseRewardView, new Action(this.OnCloseRewardView));
	}

	// Token: 0x0600A764 RID: 42852 RVA: 0x002C7F94 File Offset: 0x002C6194
	protected override void OnTickUiTabViewBase(float deltaTime)
	{
		if (this.StopFront)
		{
			return;
		}
		float fillAmount = this.FrontBarSprite.fillAmount;
		if (fillAmount < this.TargetFront)
		{
			float fillAmount2 = Math.Min(fillAmount + 0.01f, this.TargetFront);
			this.FrontBarSprite.SetFillAmount(fillAmount2);
		}
	}

	// Token: 0x0600A765 RID: 42853 RVA: 0x002C7FE0 File Offset: 0x002C61E0
	protected override void OnStart()
	{
		base.GetText(1).SetUIActive(false);
		this.FrontBarSprite = base.GetSprite(8);
		base.GetItem(14).SetUIActive(true);
		this.RewardBtn = base.GetButton(0);
		base.GetItem(5).SetUIActive(false);
		base.GetItem(2).SetUIActive(false);
		this.RewardLayout = new GenericLayout<AdventureTargetRewardItem, TItem>(base.GetLayoutBase(7), new Func<AdventureTargetRewardItem>(this.OnRewardLayoutUpdater), null, false, true);
		this.TargetItemLayout = new GenericScrollViewNew<AdventureTargetItem, AdventureTaskRecord>(base.GetScrollViewWithScrollbar(12), new Func<AdventureTargetItem>(this.OnTaskLayoutUpdater), null, false, null);
		this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
	}

	// Token: 0x0600A766 RID: 42854 RVA: 0x002C8090 File Offset: 0x002C6290
	private AdventureTargetRewardItem OnRewardLayoutUpdater()
	{
		AdventureTargetRewardItem adventureTargetRewardItem = new AdventureTargetRewardItem();
		adventureTargetRewardItem.BindOnExtendToggleClicked(new Action<MediumItemGridExtendCallback>(this.OnRewardItemClick));
		adventureTargetRewardItem.BindOnCanExecuteChange(new Func<object, bool, EToggleState, bool>(this.CanRewardItemChangeToggle));
		return adventureTargetRewardItem;
	}

	// Token: 0x0600A767 RID: 42855 RVA: 0x002C80BB File Offset: 0x002C62BB
	private void OnRewardItemClick(MediumItemGridExtendCallback callbackParameter)
	{
		ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(((TItem)callbackParameter.Data).ItemData.ItemId, true, null);
	}

	// Token: 0x0600A768 RID: 42856 RVA: 0x002C80DE File Offset: 0x002C62DE
	private bool CanRewardItemChangeToggle(object _, bool result, EToggleState state)
	{
		return false;
	}

	// Token: 0x0600A769 RID: 42857 RVA: 0x002C80E1 File Offset: 0x002C62E1
	private AdventureTargetItem OnTaskLayoutUpdater()
	{
		AdventureTargetItem adventureTargetItem = new AdventureTargetItem();
		adventureTargetItem.SetClickGetButtonCb(new Action<int>(this.OnTaskItemGetClick));
		return adventureTargetItem;
	}

	// Token: 0x0600A76A RID: 42858 RVA: 0x002C80FC File Offset: 0x002C62FC
	private void OnTaskItemGetClick(int adventureId)
	{
		if (this.Clicking)
		{
			return;
		}
		this.Clicking = true;
		AdventureTaskRecord[] chapterTasks = ModelBase<AdventureGuideModel>.Instance.GetChapterTasks(this.NowShowingChapter);
		List<int> list = new List<int>();
		if (chapterTasks != null)
		{
			foreach (AdventureTaskRecord adventureTaskRecord in chapterTasks)
			{
				if (adventureTaskRecord.Status == AdventreTaskSate.Finish)
				{
					list.Add(adventureTaskRecord.AdventureTaskBase.Id);
				}
			}
		}
		ControllerBase<AdventureGuideController>.Instance.RequestMultiForAdventureReward(list.ToArray()).ContinueWith(delegate()
		{
			this.Clicking = false;
		});
	}

	// Token: 0x0600A76B RID: 42859 RVA: 0x002C8186 File Offset: 0x002C6386
	protected override void OnBeforeDestroy()
	{
		this.RewardLayout = null;
		this.TargetItemLayout = null;
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer != null)
		{
			levelSequencePlayer.Clear();
		}
		this.LevelSequencePlayer = null;
	}

	// Token: 0x0600A76C RID: 42860 RVA: 0x002C81B0 File Offset: 0x002C63B0
	private void UpdateBtnStatus(int nowChapter)
	{
		UUIButtonComponent button = base.GetButton(3);
		UUIButtonComponent button2 = base.GetButton(4);
		if (button != null)
		{
			button.SetSelfInteractive(true);
		}
		if (button2 != null)
		{
			button2.SetSelfInteractive(true);
		}
		if (nowChapter == 1 && button != null)
		{
			button.SetSelfInteractive(false);
		}
		if (nowChapter == ConfigBase<AdventureGuideConfig>.Instance.GetMaxChapter() && button2 != null)
		{
			button2.SetSelfInteractive(false);
		}
	}

	// Token: 0x0600A76D RID: 42861 RVA: 0x002C8208 File Offset: 0x002C6408
	protected override void OnBeforeShow()
	{
		this.FrontBarSprite.SetFillAmount(0f);
		int[] unLockChaptersList = ModelBase<AdventureGuideModel>.Instance.GetUnLockChaptersList();
		int i = 1;
		int[] rewardChaptersList = ModelBase<AdventureGuideModel>.Instance.GetRewardChaptersList();
		int num = 1;
		bool flag = false;
		int num2 = 1;
		bool flag2 = false;
		int num3 = 1;
		bool flag3 = false;
		while (i <= unLockChaptersList.Length)
		{
			AdventureTaskChapter? chapterAdventureConfig = ConfigBase<AdventureGuideConfig>.Instance.GetChapterAdventureConfig(i);
			if (chapterAdventureConfig != null)
			{
				int chapterReceivedCount = ModelBase<AdventureGuideModel>.Instance.GetChapterReceivedCount(i);
				int rewardUnlockCount = chapterAdventureConfig.Value.RewardUnlockCount;
				if (!rewardChaptersList.Contains(i) && chapterReceivedCount >= rewardUnlockCount && num <= i)
				{
					num = i;
					flag = true;
				}
				if (ModelBase<AdventureGuideModel>.Instance.HaveChapterTasksFinish(i) && num2 <= i)
				{
					num2 = i;
					flag2 = true;
				}
				if (ModelBase<AdventureGuideModel>.Instance.HaveChapterTasksUnFinish(i) && num3 <= i)
				{
					num3 = i;
					flag3 = true;
				}
			}
			i++;
		}
		int maxChapter = ConfigBase<AdventureGuideConfig>.Instance.GetMaxChapter();
		if (flag)
		{
			i = num;
		}
		else if (flag2)
		{
			i = num2;
		}
		else if (flag3)
		{
			i = num3;
		}
		this.SetAdventureTargetInfoByChapter(Math.Min(i, maxChapter), true);
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer != null)
		{
			levelSequencePlayer.StopCurrentSequence(false, false);
		}
		LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
		if (levelSequencePlayer2 != null)
		{
			levelSequencePlayer2.PlayLevelSequenceByName("Start", false, null, false);
		}
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.AdventureHelpBtn, 0);
	}

	// Token: 0x0600A76E RID: 42862 RVA: 0x002C8358 File Offset: 0x002C6558
	public void SetAdventureTargetInfoByChapter(int chapter, bool rebuildList = true)
	{
		this.NowShowingChapter = chapter;
		this.SetChapterInfo(chapter);
		if (rebuildList)
		{
			AdventureTaskRecord[] taskList = ModelBase<AdventureGuideModel>.Instance.SortChapterTasks(chapter);
			this.BuildTaskList(taskList);
		}
		this.UpdateBtnStatus(chapter);
		this.SetAdventureProgress(chapter);
	}

	// Token: 0x0600A76F RID: 42863 RVA: 0x002C8398 File Offset: 0x002C6598
	public void SetChapterInfo(int chapter)
	{
		AdventureTaskChapter? chapterAdventureConfig = ConfigBase<AdventureGuideConfig>.Instance.GetChapterAdventureConfig(chapter);
		Dictionary<int, int> dropShowInfo = ConfigBase<AdventureGuideConfig>.Instance.GetDropShowInfo(chapterAdventureConfig.Value.DropIds);
		List<TItem> list = new List<TItem>();
		int[] rewardChaptersList = ModelBase<AdventureGuideModel>.Instance.GetRewardChaptersList();
		int[] unLockChaptersList = ModelBase<AdventureGuideModel>.Instance.GetUnLockChaptersList();
		UUIItem item = base.GetItem(11);
		UUIItem rootComponent = base.GetScrollViewWithScrollbar(12).GetRootComponent();
		UUIItem item2 = base.GetItem(13);
		UUIText text = base.GetText(10);
		foreach (KeyValuePair<int, int> keyValuePair in dropShowInfo)
		{
			int key = keyValuePair.Key;
			InventoryDefine.GetItemData itemData = new InventoryDefine.GetItemData(key, 0);
			TItem item3 = new TItem(itemData, dropShowInfo[key]);
			list.Add(item3);
		}
		this.RewardLayout.RefreshByData(list, new Action(this.RefreshRewardItemReceive), false);
		int chapterReceivedCount = ModelBase<AdventureGuideModel>.Instance.GetChapterReceivedCount(chapter);
		int rewardUnlockCount = chapterAdventureConfig.Value.RewardUnlockCount;
		UUIButtonComponent rewardBtn = this.RewardBtn;
		if (rewardBtn != null)
		{
			rewardBtn.RootUIComp.Get().SetUIActive(unLockChaptersList.Contains(chapter));
		}
		this.RewardBtn.SetSelfInteractive(chapterReceivedCount >= rewardUnlockCount && !rewardChaptersList.Contains(chapter));
		if (unLockChaptersList.Contains(chapter))
		{
			if (rewardChaptersList.Contains(chapter))
			{
				Singleton<LguiUtil>.Instance.SetLocalText(text, "ChapterRewardGet", Array.Empty<object>());
			}
			else if (chapterReceivedCount >= rewardUnlockCount)
			{
				Singleton<LguiUtil>.Instance.SetLocalText(text, "GetReward", Array.Empty<object>());
			}
			else
			{
				Singleton<LguiUtil>.Instance.SetLocalText(text, "Doing", Array.Empty<object>());
			}
			item.SetUIActive(true);
			rootComponent.SetUIActive(true);
			item2.SetUIActive(false);
			return;
		}
		rootComponent.SetUIActive(false);
		item2.SetUIActive(true);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(16), "Adventure_Taget_UnlockTips", new <>z__ReadOnlyArray<object>(new object[]
		{
			chapter - 1,
			(chapterAdventureConfig != null) ? new int?(chapterAdventureConfig.GetValueOrDefault().LevelUnlockCount) : null
		}));
	}

	// Token: 0x0600A770 RID: 42864 RVA: 0x002C85E4 File Offset: 0x002C67E4
	private void BuildTaskList(AdventureTaskRecord[] taskList)
	{
		GenericScrollViewNew<AdventureTargetItem, AdventureTaskRecord> targetItemLayout = this.TargetItemLayout;
		if (targetItemLayout == null)
		{
			return;
		}
		targetItemLayout.RefreshByData(taskList.ToList<AdventureTaskRecord>(), null, true);
	}

	// Token: 0x0600A771 RID: 42865 RVA: 0x002C8600 File Offset: 0x002C6800
	private void SetAdventureProgress(int chapter)
	{
		AdventureTaskChapter? chapterAdventureConfig = ConfigBase<AdventureGuideConfig>.Instance.GetChapterAdventureConfig(chapter);
		if (chapterAdventureConfig == null)
		{
			return;
		}
		bool flag = chapter >= ConfigBase<AdventureGuideConfig>.Instance.GetMaxChapter();
		int chapterReceivedCount = ModelBase<AdventureGuideModel>.Instance.GetChapterReceivedCount(chapter);
		int rewardUnlockCount = chapterAdventureConfig.Value.RewardUnlockCount;
		if (flag)
		{
			base.GetText(6).SetText(chapterReceivedCount.ToString(), true);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(21), "Wandering_Log_Prograss", new <>z__ReadOnlySingleElementList<object>(chapterAdventureConfig.Value.LevelUnlockCount));
			this.TargetFront = Math.Min(1f, (float)chapterReceivedCount / (float)rewardUnlockCount);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(19), "Adventure_Taget_LastLevel", Array.Empty<object>());
		}
		else
		{
			int levelUnlockCount = ConfigBase<AdventureGuideConfig>.Instance.GetChapterAdventureConfig(chapter + 1).Value.LevelUnlockCount;
			base.GetText(6).SetText(chapterReceivedCount.ToString(), true);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(21), "Wandering_Log_Prograss", new <>z__ReadOnlySingleElementList<object>(levelUnlockCount));
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(19), (chapterReceivedCount < levelUnlockCount) ? "Adventure_Taget_NextLevelLock" : "Adventure_Taget_NextLevelUnlock", new <>z__ReadOnlySingleElementList<object>(chapter + 1));
			this.TargetFront = Math.Min(1f, (float)chapterReceivedCount / (float)levelUnlockCount);
		}
		bool uiactive = ModelBase<AdventureGuideModel>.Instance.GetUnLockChaptersList().Contains(chapter);
		base.GetText(19).SetUIActive(uiactive);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(15), "Adventure_Taget_State_Number", new <>z__ReadOnlySingleElementList<object>(chapter));
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(20), "Adventure_Taget_RewardUnlock", new <>z__ReadOnlyArray<object>(new object[]
		{
			Math.Min(chapterReceivedCount, rewardUnlockCount),
			rewardUnlockCount
		}));
		base.GetItem(9).SetUIActive(chapterReceivedCount >= rewardUnlockCount && !ModelBase<AdventureGuideModel>.Instance.GetRewardChaptersList().Contains(chapter));
	}

	// Token: 0x0600A772 RID: 42866 RVA: 0x002C8810 File Offset: 0x002C6A10
	private void RefreshRewardItemReceive()
	{
		if (ConfigBase<AdventureGuideConfig>.Instance.GetChapterAdventureConfig(this.NowShowingChapter) == null)
		{
			return;
		}
		int[] rewardChaptersList = ModelBase<AdventureGuideModel>.Instance.GetRewardChaptersList();
		GenericLayout<AdventureTargetRewardItem, TItem> rewardLayout = this.RewardLayout;
		foreach (AdventureTargetRewardItem adventureTargetRewardItem in (((rewardLayout != null) ? rewardLayout.GetLayoutItemList() : null) ?? new List<AdventureTargetRewardItem>()))
		{
			adventureTargetRewardItem.SetReceivedFlagVisible(new bool?(rewardChaptersList.Contains(this.NowShowingChapter)));
		}
	}

	// Token: 0x0600A773 RID: 42867 RVA: 0x002C88AC File Offset: 0x002C6AAC
	private void OnPreBtnClick()
	{
		if (this.NowShowingChapter > 1)
		{
			UUISprite frontBarSprite = this.FrontBarSprite;
			if (frontBarSprite != null)
			{
				frontBarSprite.SetFillAmount(0f);
			}
			int num = this.NowShowingChapter - 1;
			this.SetAdventureTargetInfoByChapter(num, ModelBase<AdventureGuideModel>.Instance.GetUnLockChaptersList().Contains(num));
		}
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer != null)
		{
			levelSequencePlayer.StopCurrentSequence(false, true);
		}
		LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
		if (levelSequencePlayer2 == null)
		{
			return;
		}
		levelSequencePlayer2.PlayLevelSequenceByName("Switch", false, null, false);
	}

	// Token: 0x0600A774 RID: 42868 RVA: 0x002C892C File Offset: 0x002C6B2C
	private void OnNextBtnClick()
	{
		if (this.NowShowingChapter < ConfigBase<AdventureGuideConfig>.Instance.GetMaxChapter())
		{
			UUISprite frontBarSprite = this.FrontBarSprite;
			if (frontBarSprite != null)
			{
				frontBarSprite.SetFillAmount(0f);
			}
			int num = this.NowShowingChapter + 1;
			this.SetAdventureTargetInfoByChapter(num, ModelBase<AdventureGuideModel>.Instance.GetUnLockChaptersList().Contains(num));
		}
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer != null)
		{
			levelSequencePlayer.StopCurrentSequence(false, true);
		}
		LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
		if (levelSequencePlayer2 == null)
		{
			return;
		}
		levelSequencePlayer2.PlayLevelSequenceByName("Switch", false, null, false);
	}

	// Token: 0x0600A775 RID: 42869 RVA: 0x002C89B4 File Offset: 0x002C6BB4
	private void OnRewardBtnClick()
	{
		AdventureTaskChapter? chapterAdventureConfig = ConfigBase<AdventureGuideConfig>.Instance.GetChapterAdventureConfig(this.NowShowingChapter);
		if (chapterAdventureConfig == null)
		{
			return;
		}
		int chapterReceivedCount = ModelBase<AdventureGuideModel>.Instance.GetChapterReceivedCount(this.NowShowingChapter);
		int rewardUnlockCount = chapterAdventureConfig.Value.RewardUnlockCount;
		if (chapterReceivedCount >= rewardUnlockCount)
		{
			ControllerBase<AdventureGuideController>.Instance.RequestForChapterReward(this.NowShowingChapter);
			this.RewardBtn.SetSelfInteractive(false);
			return;
		}
		string textById = ConfigBase<TextConfig>.Instance.GetTextById("NotFinishedTip");
		ControllerBase<ScrollingTipsController>.Instance.ShowTipsByText(textById);
	}

	// Token: 0x0600A776 RID: 42870 RVA: 0x002C8A37 File Offset: 0x002C6C37
	private void OnChapterRewardReceived(int id)
	{
		if (this.NowShowingChapter == id)
		{
			this.SetAdventureTargetInfoByChapter(id, false);
			base.GetItem(9).SetUIActive(false);
			this.OnNextBtnClick();
			this.RefreshRewardItemReceive();
		}
	}

	// Token: 0x0600A777 RID: 42871 RVA: 0x002C8A64 File Offset: 0x002C6C64
	private void OnTaskStateChange(IReadOnlyList<int> ids)
	{
		bool flag = false;
		foreach (int id in ids)
		{
			if (ModelBase<AdventureGuideModel>.Instance.IsTaskOfChapter(id, this.NowShowingChapter))
			{
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			return;
		}
		AdventureTaskRecord[] source = ModelBase<AdventureGuideModel>.Instance.GetChapterTasks(this.NowShowingChapter);
		this.SetAdventureTargetInfoByChapter(this.NowShowingChapter, false);
		source = ModelBase<AdventureGuideModel>.Instance.SortChapterTasks(this.NowShowingChapter);
		GenericScrollViewNew<AdventureTargetItem, AdventureTaskRecord> targetItemLayout = this.TargetItemLayout;
		if (targetItemLayout == null)
		{
			return;
		}
		targetItemLayout.RefreshByData(source.ToList<AdventureTaskRecord>(), null, false);
	}

	// Token: 0x0600A778 RID: 42872 RVA: 0x002C8B0C File Offset: 0x002C6D0C
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
	{
		int displayIndex = int.Parse(configParams[0]);
		UUIItem gridByDisplayIndex = this.RewardLayout.GetGridByDisplayIndex(displayIndex);
		if (gridByDisplayIndex != null)
		{
			return new UUIItem[]
			{
				gridByDisplayIndex,
				gridByDisplayIndex
			};
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Guide;
		ELogAuthor author = ELogAuthor.JT;
		string message = "聚焦引导extraParam项配置有误";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("configParams", configParams);
		instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		return null;
	}

	// Token: 0x0600A779 RID: 42873 RVA: 0x002C8B69 File Offset: 0x002C6D69
	private void OnCloseRewardView()
	{
		this.StopFront = false;
	}

	// Token: 0x04004F01 RID: 20225
	private const string REWARD_RECEIVED = "ChapterRewardGet";

	// Token: 0x04004F02 RID: 20226
	private const string NOT_FINISH_TIP = "NotFinishedTip";

	// Token: 0x04004F03 RID: 20227
	private const string GET_REWARD = "GetReward";

	// Token: 0x04004F04 RID: 20228
	private const float FRONT_ADD_FRAME = 0.01f;

	// Token: 0x04004F05 RID: 20229
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<AdventureTargetRewardItem, TItem> RewardLayout;

	// Token: 0x04004F06 RID: 20230
	private int NowShowingChapter;

	// Token: 0x04004F07 RID: 20231
	[Nullable(2)]
	private UUIButtonComponent RewardBtn;

	// Token: 0x04004F08 RID: 20232
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericScrollViewNew<AdventureTargetItem, AdventureTaskRecord> TargetItemLayout;

	// Token: 0x04004F09 RID: 20233
	[Nullable(2)]
	private UUISprite FrontBarSprite;

	// Token: 0x04004F0A RID: 20234
	private float TargetFront;

	// Token: 0x04004F0B RID: 20235
	private bool StopFront;

	// Token: 0x04004F0C RID: 20236
	[Nullable(2)]
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x04004F0D RID: 20237
	private bool Clicking;

	// Token: 0x02007AAB RID: 31403
	[NullableContext(0)]
	private enum ENodeDefine
	{
		// Token: 0x0402A041 RID: 172097
		RewardBtn,
		// Token: 0x0402A042 RID: 172098
		ProgressText,
		// Token: 0x0402A043 RID: 172099
		TargetItem,
		// Token: 0x0402A044 RID: 172100
		PreBtn,
		// Token: 0x0402A045 RID: 172101
		NextBtn,
		// Token: 0x0402A046 RID: 172102
		RewardItem,
		// Token: 0x0402A047 RID: 172103
		ChapterText,
		// Token: 0x0402A048 RID: 172104
		RewardLayout,
		// Token: 0x0402A049 RID: 172105
		FrontBar,
		// Token: 0x0402A04A RID: 172106
		RedDotItem,
		// Token: 0x0402A04B RID: 172107
		ConfirmText,
		// Token: 0x0402A04C RID: 172108
		PanelExpItem,
		// Token: 0x0402A04D RID: 172109
		TaskScroll,
		// Token: 0x0402A04E RID: 172110
		NextChapterTip,
		// Token: 0x0402A04F RID: 172111
		AdventureTaskItem,
		// Token: 0x0402A050 RID: 172112
		StateText,
		// Token: 0x0402A051 RID: 172113
		EmptyText,
		// Token: 0x0402A052 RID: 172114
		LeftRedDotItem,
		// Token: 0x0402A053 RID: 172115
		RightRedDotItem,
		// Token: 0x0402A054 RID: 172116
		NextLevelProgressText,
		// Token: 0x0402A055 RID: 172117
		CurrentRewardText,
		// Token: 0x0402A056 RID: 172118
		ChapterTargetText
	}
}
