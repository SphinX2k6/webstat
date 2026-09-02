using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.AdventureGuide;
using CSharpScript.Game.Module.Common.InputView;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001747 RID: 5959
[NullableContext(2)]
[Nullable(0)]
public class MonsterDetectView : UiTabViewBase
{
	// Token: 0x0600A7A4 RID: 42916 RVA: 0x002C980B File Offset: 0x002C7A0B
	public int GetCurrentId()
	{
		return this.CurShowingDetectingTarget;
	}

	// Token: 0x0600A7A5 RID: 42917 RVA: 0x002C9813 File Offset: 0x002C7A13
	public UUIExtendToggle GetCurrentToggle()
	{
		return this.CurrentSelectedToggle;
	}

	// Token: 0x0600A7A6 RID: 42918 RVA: 0x002C981C File Offset: 0x002C7A1C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 20;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
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
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUILoopScrollViewComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(18, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(19, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnDetectClickFunction));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(16, new Action(this.OnLeftTimeBtn));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600A7A7 RID: 42919 RVA: 0x002C9B44 File Offset: 0x002C7D44
	protected override void OnStart()
	{
		this.DetectLoopScroll = new LoopScrollView<MonsterDetectItem, MonsterDetectionRecord>(base.GetLoopScrollViewComponent(7), base.GetItem(2).GetOwner() as AUIBaseActor, delegate()
		{
			MonsterDetectItem monsterDetectItem = new MonsterDetectItem();
			monsterDetectItem.BindCallback(new Action<int, UUIExtendToggle>(this.RefreshByDetectingId));
			return monsterDetectItem;
		}, false);
		this.DetectLoopScroll.SetAnimFinishDelegate(new Action(this.OnAnimFinishDelegate));
		this.MonsterHeadItem = new CommonItemSmallItemGrid();
		this.MonsterHeadItem.Initialize(base.GetItem(14).GetOwner());
		this.DetectItemList = new List<MonsterDetectionRecord>();
		this.RewardLayout = new GenericScrollViewNew<CommonItemSmallItemGrid, TItem>(base.GetScrollViewWithScrollbar(8), new Func<CommonItemSmallItemGrid>(this.OnRewardLayoutUpdater), null, false, null);
		this.FilterBtn = new FilterSortEntrance<MonsterDetectionRecord>(base.GetItem(0), new TUpdateDataListFunction<MonsterDetectionRecord>(this.OnFilterUpdate));
		this.DetectText = base.GetText(10);
		this.DetectText.OnSelfLanguageChange.Bind(new Action(this.OnRefreshTimeLangChange));
		this.DetectBtn = base.GetButton(1);
		this.CurShowingDetectingTarget = ModelBase<AdventureGuideModel>.Instance.GetCurDetectingMonsterConfId();
		this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
		int leftIntensifyCaptureGuarantee = ModelBase<CalabashModel>.Instance.GetLeftIntensifyCaptureGuarantee();
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(15), "UpAbsorptionTimeWithTagText", new <>z__ReadOnlySingleElementList<object>(leftIntensifyCaptureGuarantee));
		this.InitNavigationParam();
		this.SearchComponent = new CommonSearchComponent(base.GetItem(17), new Action<string>(this.SearchResult), new Action(this.ResetSearch));
	}

	// Token: 0x0600A7A8 RID: 42920 RVA: 0x002C9CBC File Offset: 0x002C7EBC
	private void InitNavigationParam()
	{
		AdventureGuideViewOpenData adventureGuideViewOpenData = this.ExtraParams as AdventureGuideViewOpenData;
		int? num = (((adventureGuideViewOpenData != null) ? adventureGuideViewOpenData.OpenTabViewName : null) == EUiTabViewName.MonsterDetectView) ? adventureGuideViewOpenData.OpenParam : null;
		if (num != null)
		{
			int? num2 = num;
			int num3 = 0;
			if (num2.GetValueOrDefault() > num3 & num2 != null)
			{
				this.IsNavigationJumpToGrid = true;
			}
		}
	}

	// Token: 0x0600A7A9 RID: 42921 RVA: 0x002C9D4C File Offset: 0x002C7F4C
	private void NavigationJumpToGrid()
	{
		if (!this.IsNavigationJumpToGrid)
		{
			return;
		}
		this.IsNavigationJumpToGrid = false;
		MonsterDetectItem monsterDetectItem = this.DetectLoopScroll.UnsafeGetGridProxy(this.JumpIndex, false);
		if (monsterDetectItem == null)
		{
			return;
		}
		ControllerBase<UiNavigationNewController>.Instance.SetNavigationFocusForView(monsterDetectItem.GetToggleItem(), false, false, false);
	}

	// Token: 0x0600A7AA RID: 42922 RVA: 0x002C9D94 File Offset: 0x002C7F94
	protected override void OnBeforeShow()
	{
		AdventureGuideViewOpenData adventureGuideViewOpenData = this.ExtraParams as AdventureGuideViewOpenData;
		int? num = (((adventureGuideViewOpenData != null) ? adventureGuideViewOpenData.OpenTabViewName : null) == EUiTabViewName.MonsterDetectView) ? adventureGuideViewOpenData.OpenParam : null;
		int? num2 = null;
		if (num != null)
		{
			int? num3 = num;
			int num4 = 0;
			if (num3.GetValueOrDefault() > num4 & num3 != null)
			{
				num2 = num;
			}
			else
			{
				this.PreSelectedDangerType = -num;
			}
		}
		this.PreSelectedMonster = num2;
		ModelBase<AdventureGuideModel>.Instance.CurrentMonsterId = num2;
		List<MonsterDetectionRecord> dataList = ModelBase<AdventureGuideModel>.Instance.GetAllDetectMonsters().Values.ToList<MonsterDetectionRecord>();
		this.FilterBtn.UpdateData(EFilterSortGroupId.MonsterDetection, dataList, Array.Empty<object>());
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
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.AdventureHelpBtn, 17);
	}

	// Token: 0x0600A7AB RID: 42923 RVA: 0x002C9ED6 File Offset: 0x002C80D6
	[NullableContext(1)]
	private CommonItemSmallItemGrid OnRewardLayoutUpdater()
	{
		return new CommonItemSmallItemGrid();
	}

	// Token: 0x0600A7AC RID: 42924 RVA: 0x002C9EDD File Offset: 0x002C80DD
	private void OnRefreshTimeLangChange()
	{
		this.UpdateRefreshTime();
	}

	// Token: 0x0600A7AD RID: 42925 RVA: 0x002C9EE8 File Offset: 0x002C80E8
	protected override void OnBeforeDestroy()
	{
		this.RewardLayout = null;
		if (this.DetectLoopScroll != null)
		{
			this.DetectLoopScroll.ClearGridProxies();
			this.DetectLoopScroll = null;
		}
		this.DetectText.OnSelfLanguageChange.Unbind();
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer != null)
		{
			levelSequencePlayer.Clear();
		}
		this.LevelSequencePlayer = null;
	}

	// Token: 0x0600A7AE RID: 42926 RVA: 0x002C9F40 File Offset: 0x002C8140
	[NullableContext(1)]
	private void BuildDetectList(List<MonsterDetectionRecord> list)
	{
		this.DetectItemList.Clear();
		foreach (MonsterDetectionRecord monsterDetectionRecord in list)
		{
			this.DetectItemList.Add(monsterDetectionRecord);
			if (this.PreSelectedMonster.GetValueOrDefault() != -1)
			{
				int? preSelectedMonster = this.PreSelectedMonster;
				int id = monsterDetectionRecord.Conf.Id;
				if (preSelectedMonster.GetValueOrDefault() == id & preSelectedMonster != null)
				{
					this.PreSelectedMonster = new int?(-1);
				}
			}
		}
		if (ModelBase<AdventureGuideModel>.Instance.CurrentMonsterId == null)
		{
			int firstMonsterIdByDangerType = this.GetFirstMonsterIdByDangerType();
			ModelBase<AdventureGuideModel>.Instance.CurrentMonsterId = new int?(firstMonsterIdByDangerType);
		}
		Action callBack = delegate()
		{
			this.JumpToTarget(ModelBase<AdventureGuideModel>.Instance.CurrentMonsterId.Value);
		};
		this.DetectLoopScroll.RefreshByData(this.DetectItemList, false, callBack, true);
	}

	// Token: 0x0600A7AF RID: 42927 RVA: 0x002CA030 File Offset: 0x002C8230
	[NullableContext(1)]
	public void RefreshByDetectingId(int id, UUIExtendToggle toggle)
	{
		if (this.CurrentSelectedToggle != null && this.CurrentSelectedToggle != toggle)
		{
			this.CurrentSelectedToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		}
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer != null)
		{
			levelSequencePlayer.StopCurrentSequence(false, true);
		}
		LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
		if (levelSequencePlayer2 != null)
		{
			levelSequencePlayer2.PlayLevelSequenceByName("Switch", false, null, false);
		}
		ModelBase<AdventureGuideModel>.Instance.CurrentMonsterId = new int?(id);
		this.CurrentSelectedToggle = toggle;
		this.CurShowingDetectingTarget = id;
		MonsterDetectionRecord monsterDetectData = ModelBase<AdventureGuideModel>.Instance.GetMonsterDetectData(id);
		string name = ConfigBase<MonsterInfoConfig>.Instance.GetMonsterInfoConfig(monsterDetectData.Conf.MonsterInfoId).Value.Name;
		TItem titem = new TItem(new InventoryDefine.GetItemData(monsterDetectData.Conf.MonsterInfoId, 0), 1);
		PhantomSmallItemGrid parameters = new PhantomSmallItemGrid
		{
			Data = titem,
			BottomText = "",
			IsNotFoundVisible = new bool?(monsterDetectData.IsLock),
			IsSelectedFlag = new bool?(false),
			MonsterId = new int?(monsterDetectData.Conf.MonsterInfoId),
			IsQualityHidden = new bool?(true),
			IconHidden = new bool?(monsterDetectData.IsLock)
		};
		CommonItemSmallItemGrid monsterHeadItem = this.MonsterHeadItem;
		if (monsterHeadItem != null)
		{
			monsterHeadItem.Apply<PhantomSmallItemGrid>(parameters);
		}
		CommonItemSmallItemGrid monsterHeadItem2 = this.MonsterHeadItem;
		if (monsterHeadItem2 != null)
		{
			monsterHeadItem2.SetToggleInteractive(false);
		}
		string localTextNew = ConfigMultiTextLang.GetLocalTextNew(ConfigTextById.GetConfig("Detect", true).Value.TextContent, null);
		this.DetectText.SetText(localTextNew, true);
		if (monsterDetectData.IsLock)
		{
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(4), "Unknown", Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), monsterDetectData.Conf.AttributesDescriptionLock, Array.Empty<object>());
		}
		else
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), name, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), monsterDetectData.Conf.AttributesDescriptionUnlock, Array.Empty<object>());
			this.UpdateRefreshTime();
		}
		SecondaryGuideData? secondaryGuideDataConf = ConfigBase<AdventureGuideConfig>.Instance.GetSecondaryGuideDataConf(monsterDetectData.Conf.DangerType);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(11), ConfigBase<AdventureGuideConfig>.Instance.GetSecondaryGuideDataTextById(monsterDetectData.Conf.DangerType), Array.Empty<object>());
		this.SetSpriteByPath(secondaryGuideDataConf.Value.Icon, base.GetSprite(6), false, null, null);
		if (monsterDetectData.Conf.ShowReward == 0)
		{
			base.GetItem(9).SetUIActive(false);
		}
		else
		{
			base.GetItem(9).SetUIActive(true);
			this.BuildRewardList(monsterDetectData.Conf.ShowReward, false);
		}
		IEnumerable<int> intArrayConfig = ConfigCommonParamById.GetIntArrayConfig("CanUpAbsorbDangerTypeList");
		IReadOnlyList<int> intArrayConfig2 = ConfigCommonParamById.GetIntArrayConfig("CanUpAbsorbTypeDescription2List");
		IReadOnlyList<int> intArrayConfig3 = ConfigCommonParamById.GetIntArrayConfig("CanUpAbsorbLowDangerTypeList");
		object obj = intArrayConfig.Contains(monsterDetectData.Conf.DangerType) && intArrayConfig2.Contains(monsterDetectData.Conf.TypeDescription2);
		bool flag = intArrayConfig3.Contains(monsterDetectData.Conf.DangerType) && intArrayConfig2.Contains(monsterDetectData.Conf.TypeDescription2);
		UUIText text = base.GetText(15);
		object obj2 = obj;
		if (obj2 != null)
		{
			int leftIntensifyCaptureGuarantee = ModelBase<CalabashModel>.Instance.GetLeftIntensifyCaptureGuarantee();
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "UpAbsorptionTimeWithTagText", new <>z__ReadOnlySingleElementList<object>(leftIntensifyCaptureGuarantee));
			if (text != null)
			{
				text.SetUIActive(true);
			}
		}
		else if (flag)
		{
			int leftLowCostIntensifyCaptureGuarantee = ModelBase<CalabashModel>.Instance.GetLeftLowCostIntensifyCaptureGuarantee();
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "UpAbsorptionTimeWithTagText", new <>z__ReadOnlySingleElementList<object>(leftLowCostIntensifyCaptureGuarantee));
			if (text != null)
			{
				text.SetUIActive(true);
			}
		}
		else if (text != null)
		{
			text.SetUIActive(false);
		}
		bool uiactive = (obj2 | flag) != null;
		UUIButtonComponent button = base.GetButton(16);
		if (button == null)
		{
			return;
		}
		button.RootUIComp.Get().SetUIActive(uiactive);
	}

	// Token: 0x0600A7B0 RID: 42928 RVA: 0x002CA44C File Offset: 0x002C864C
	private int GetFirstMonsterIdByDangerType()
	{
		int? preSelectedDangerType = this.PreSelectedDangerType;
		this.PreSelectedDangerType = null;
		if (this.DetectItemList.Count <= 0)
		{
			return -1;
		}
		int id = this.DetectItemList[0].Conf.Id;
		if (preSelectedDangerType == null)
		{
			return id;
		}
		foreach (MonsterDetectionRecord monsterDetectionRecord in this.DetectItemList)
		{
			if (!monsterDetectionRecord.IsLock)
			{
				int dangerType = monsterDetectionRecord.Conf.DangerType;
				int? num = preSelectedDangerType;
				if (dangerType == num.GetValueOrDefault() & num != null)
				{
					return monsterDetectionRecord.Conf.Id;
				}
			}
		}
		return id;
	}

	// Token: 0x0600A7B1 RID: 42929 RVA: 0x002CA528 File Offset: 0x002C8728
	private void UpdateRefreshTime()
	{
		int currentId = this.GetCurrentId();
		if (currentId == 0)
		{
			return;
		}
		MonsterDetectionRecord monsterDetectData = ModelBase<AdventureGuideModel>.Instance.GetMonsterDetectData(currentId);
		if (monsterDetectData == null)
		{
			return;
		}
		base.GetItem(13).SetUIActive(monsterDetectData.IsLock);
		if (monsterDetectData.IsLock)
		{
			return;
		}
		this.DetectBtn.RootUIComp.Get().SetUIActive(true);
		if (!monsterDetectData.IsLock && !this.DetectInteractive)
		{
			this.DetectBtn.SetSelfInteractive(true);
			this.DetectInteractive = true;
		}
	}

	// Token: 0x0600A7B2 RID: 42930 RVA: 0x002CA5A8 File Offset: 0x002C87A8
	public void Tick(float delta)
	{
		this.UpdateRefreshTime();
	}

	// Token: 0x0600A7B3 RID: 42931 RVA: 0x002CA5B0 File Offset: 0x002C87B0
	private void BuildRewardList(int dropId, bool isReceived)
	{
		Dictionary<int, int> dropShowInfo = ConfigBase<AdventureGuideConfig>.Instance.GetDropShowInfo(dropId);
		List<TItem> list = new List<TItem>();
		foreach (KeyValuePair<int, int> keyValuePair in dropShowInfo)
		{
			int key = keyValuePair.Key;
			TItem item = new TItem(new InventoryDefine.GetItemData(key, 0), dropShowInfo[key]);
			list.Add(item);
		}
		this.RewardLayout.RefreshByData(list, null, false);
	}

	// Token: 0x0600A7B4 RID: 42932 RVA: 0x002CA640 File Offset: 0x002C8840
	[NullableContext(1)]
	private void OnFilterUpdate(List<MonsterDetectionRecord> list, bool result, EFilterSortType type)
	{
		List<MonsterDetectionRecord> list2 = new List<MonsterDetectionRecord>();
		foreach (MonsterDetectionRecord item in list)
		{
			list2.Add(item);
		}
		this.BuildDetectList(list2);
		this.FilterResult = list2;
		base.GetItem(18).SetUIActive(list2.Count > 0);
		base.GetItem(19).SetUIActive(list2.Count <= 0);
		this.SearchComponent.ResetSearch(true);
	}

	// Token: 0x0600A7B5 RID: 42933 RVA: 0x002CA6E0 File Offset: 0x002C88E0
	private void OnDetectClickFunction()
	{
		if (Singleton<Time>.Instance.Now - this.LastClickTime <= (double)(Singleton<TimeUtil>.Instance.InverseMillisecond * 2))
		{
			return;
		}
		this.LastClickTime = Singleton<Time>.Instance.Now;
		if (ControllerBase<GameModeController>.Instance.IsInInstance())
		{
			ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("DungeonDetection", Array.Empty<object>());
			return;
		}
		int currentId = this.GetCurrentId();
		MonsterDetectionRecord monsterDetectData = ModelBase<AdventureGuideModel>.Instance.GetMonsterDetectData(currentId);
		if (monsterDetectData != null && monsterDetectData.IsLock && monsterDetectData.Conf.TypeDescription2 == 23)
		{
			SilentAreaDetectionRecord silentAreaDetectData = ModelBase<AdventureGuideModel>.Instance.GetSilentAreaDetectData(monsterDetectData.Conf.NightMareDetectionId);
			if (silentAreaDetectData != null && silentAreaDetectData.IsLock)
			{
				if (!ModelBase<AdventureGuideModel>.Instance.CheckTargetDungeonTypeCanShow(EDungeonType.NightMare))
				{
					ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("ConditionGroup_12005113_HintText", Array.Empty<object>());
					return;
				}
				AdventureGuideViewOpenData adventureGuideViewOpenData = new AdventureGuideViewOpenData();
				adventureGuideViewOpenData.OpenTabViewName = new EUiTabViewName?(EUiTabViewName.NewSoundAreaView);
				adventureGuideViewOpenData.OpenParam = new int?(63);
				ModelBase<AdventureGuideModel>.Instance.HandleShowNightMareParam = monsterDetectData.Conf.NightMareDetectionId;
				ControllerBase<AdventureGuideController>.Instance.OpenGuideViewWithOpenData(adventureGuideViewOpenData, null);
				return;
			}
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.AdventureGuide;
		ELogAuthor author = ELogAuthor.LJQ;
		string message = "手动探测怪物";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("探测Id", currentId);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		ModelBase<AdventureGuideModel>.Instance.SetFromManualDetect(true);
		ControllerBase<AdventureGuideController>.Instance.RequestForDetection(DetectionType.NormalMonster, Array.Empty<int>(), this.CurShowingDetectingTarget);
	}

	// Token: 0x0600A7B6 RID: 42934 RVA: 0x002CA85C File Offset: 0x002C8A5C
	private void OnLeftTimeBtn()
	{
		ControllerBase<HelpController>.Instance.OpenHelpById(72);
	}

	// Token: 0x0600A7B7 RID: 42935 RVA: 0x002CA86A File Offset: 0x002C8A6A
	private void OnAnimFinishDelegate()
	{
		this.NavigationJumpToGrid();
		LoopScrollView<MonsterDetectItem, MonsterDetectionRecord> detectLoopScroll = this.DetectLoopScroll;
		if (detectLoopScroll == null)
		{
			return;
		}
		detectLoopScroll.SetAnimFinishDelegate(null);
	}

	// Token: 0x0600A7B8 RID: 42936 RVA: 0x002CA884 File Offset: 0x002C8A84
	public void JumpToTarget(int target)
	{
		int num = 0;
		foreach (MonsterDetectionRecord monsterDetectionRecord in this.DetectItemList)
		{
			if (target == monsterDetectionRecord.Conf.Id)
			{
				this.DetectLoopScroll.DeselectCurrentGridProxy(false);
				this.DetectLoopScroll.ScrollToGridIndex(num, true);
				this.DetectLoopScroll.SelectGridProxy(num, false);
				break;
			}
			num++;
		}
		this.JumpIndex = num;
	}

	// Token: 0x0600A7B9 RID: 42937 RVA: 0x002CA920 File Offset: 0x002C8B20
	[NullableContext(1)]
	private void SearchResult(string content)
	{
		AdventureGuideModel instance = ModelBase<AdventureGuideModel>.Instance;
		List<MonsterDetectionRecord> detectItemList = this.DetectItemList;
		MonsterDetectionRecord[] searchList = instance.GetSearchList(((detectItemList != null) ? detectItemList.ToArray() : null) ?? Array.Empty<MonsterDetectionRecord>(), content);
		base.GetItem(18).SetUIActive(searchList.Length != 0);
		base.GetItem(19).SetUIActive(searchList.Length == 0);
		this.DetectLoopScroll.RefreshByData(searchList.ToList<MonsterDetectionRecord>(), false, null, false);
	}

	// Token: 0x0600A7BA RID: 42938 RVA: 0x002CA98C File Offset: 0x002C8B8C
	private void ResetSearch()
	{
		if (this.FilterResult != null)
		{
			base.GetItem(18).SetUIActive(this.FilterResult.Count > 0);
			base.GetItem(19).SetUIActive(this.FilterResult.Count <= 0);
		}
		else
		{
			base.GetItem(18).SetUIActive(false);
			base.GetItem(19).SetUIActive(true);
		}
		this.DetectLoopScroll.RefreshByData(this.FilterResult ?? new List<MonsterDetectionRecord>(), false, null, false);
	}

	// Token: 0x04004F1D RID: 20253
	private const int MONSTER_HELP = 17;

	// Token: 0x04004F1E RID: 20254
	private const int LEFT_TIME_HELP = 72;

	// Token: 0x04004F1F RID: 20255
	private const int NIGHT_MARE_TYPE = 23;

	// Token: 0x04004F20 RID: 20256
	private const int NIGHT_MARE_TAG = 63;

	// Token: 0x04004F21 RID: 20257
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private LoopScrollView<MonsterDetectItem, MonsterDetectionRecord> DetectLoopScroll;

	// Token: 0x04004F22 RID: 20258
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<MonsterDetectionRecord> DetectItemList;

	// Token: 0x04004F23 RID: 20259
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericScrollViewNew<CommonItemSmallItemGrid, TItem> RewardLayout;

	// Token: 0x04004F24 RID: 20260
	private int CurShowingDetectingTarget;

	// Token: 0x04004F25 RID: 20261
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private FilterSortEntrance<MonsterDetectionRecord> FilterBtn;

	// Token: 0x04004F26 RID: 20262
	private UUIExtendToggle CurrentSelectedToggle;

	// Token: 0x04004F27 RID: 20263
	private UUIText DetectText;

	// Token: 0x04004F28 RID: 20264
	private int? PreSelectedMonster = new int?(-1);

	// Token: 0x04004F29 RID: 20265
	private int? PreSelectedDangerType;

	// Token: 0x04004F2A RID: 20266
	private UUIButtonComponent DetectBtn;

	// Token: 0x04004F2B RID: 20267
	private bool DetectInteractive = true;

	// Token: 0x04004F2C RID: 20268
	private double LastClickTime;

	// Token: 0x04004F2D RID: 20269
	private CommonItemSmallItemGrid MonsterHeadItem;

	// Token: 0x04004F2E RID: 20270
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x04004F2F RID: 20271
	private bool IsNavigationJumpToGrid;

	// Token: 0x04004F30 RID: 20272
	private int JumpIndex;

	// Token: 0x04004F31 RID: 20273
	private CommonSearchComponent SearchComponent;

	// Token: 0x04004F32 RID: 20274
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<MonsterDetectionRecord> FilterResult;

	// Token: 0x02007AB2 RID: 31410
	[NullableContext(0)]
	private enum ENodeDefine
	{
		// Token: 0x0402A073 RID: 172147
		FilterBtn,
		// Token: 0x0402A074 RID: 172148
		DetectBtn,
		// Token: 0x0402A075 RID: 172149
		DetectItem,
		// Token: 0x0402A076 RID: 172150
		RewardItem,
		// Token: 0x0402A077 RID: 172151
		NameText,
		// Token: 0x0402A078 RID: 172152
		DescText,
		// Token: 0x0402A079 RID: 172153
		LowDangerItem,
		// Token: 0x0402A07A RID: 172154
		DetectScroll,
		// Token: 0x0402A07B RID: 172155
		RewardLayout,
		// Token: 0x0402A07C RID: 172156
		DropItem,
		// Token: 0x0402A07D RID: 172157
		ConfirmText,
		// Token: 0x0402A07E RID: 172158
		LowLevelText,
		// Token: 0x0402A07F RID: 172159
		TxtUnlock,
		// Token: 0x0402A080 RID: 172160
		UnlockItem,
		// Token: 0x0402A081 RID: 172161
		MonsterItem,
		// Token: 0x0402A082 RID: 172162
		LeftTimeText,
		// Token: 0x0402A083 RID: 172163
		LeftTimeBtn,
		// Token: 0x0402A084 RID: 172164
		UiItemInputBoxItem,
		// Token: 0x0402A085 RID: 172165
		RightItem,
		// Token: 0x0402A086 RID: 172166
		EmptyItem
	}
}
