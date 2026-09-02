using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.HonamiStory;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001F2B RID: 7979
[NullableContext(2)]
[Nullable(0)]
public class HonamiStoryLevelInfoView : UiViewBase
{
	// Token: 0x17001233 RID: 4659
	// (get) Token: 0x0600EE98 RID: 61080 RVA: 0x00412B2E File Offset: 0x00410D2E
	public ETarget? GetCurTarget
	{
		get
		{
			return this.CurTarget;
		}
	}

	// Token: 0x17001234 RID: 4660
	// (get) Token: 0x0600EE99 RID: 61081 RVA: 0x00412B36 File Offset: 0x00410D36
	public int GetCurDangerLv
	{
		get
		{
			return this.CurDangerLv;
		}
	}

	// Token: 0x17001235 RID: 4661
	// (get) Token: 0x0600EE9A RID: 61082 RVA: 0x00412B3E File Offset: 0x00410D3E
	public bool GetIsBuySafe
	{
		get
		{
			return this.IsBuySafe;
		}
	}

	// Token: 0x0600EE9B RID: 61083 RVA: 0x00412B48 File Offset: 0x00410D48
	[NullableContext(1)]
	public HonamiStoryLevelInfoView(UiViewInfo viewInfo)
	{
		Dictionary<int, EHonamiStoryOutDialogType> dictionary = new Dictionary<int, EHonamiStoryOutDialogType>();
		dictionary[1] = EHonamiStoryOutDialogType.LevelInfoFirst;
		dictionary[2] = EHonamiStoryOutDialogType.LevelInfoFirst;
		dictionary[3] = EHonamiStoryOutDialogType.LevelInfoSecond;
		dictionary[4] = EHonamiStoryOutDialogType.LevelInfoSecond;
		dictionary[5] = EHonamiStoryOutDialogType.LevelInfoSecond;
		this.BoZaiTalkMap = dictionary;
		this.CurDangerLv = 1;
		this.CurHonamiDangerLv = 1;
		this.CurTowerDangerLv = 1;
		this.TargetBgPath = string.Empty;
		base..ctor(viewInfo);
	}

	// Token: 0x0600EE9C RID: 61084 RVA: 0x00412BB4 File Offset: 0x00410DB4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 25;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(15, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(18, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(19, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(20, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(21, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(22, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(23, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(24, typeof(UUIText));
		this.ComponentRegisterInfos = list;
		num2 = 3;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(13, new Action(this.OnClickBtnReduce));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(14, new Action(this.OnClickBtnAdd));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(16, new Action<EToggleState>(this.OnBuySafeTogClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600EE9D RID: 61085 RVA: 0x00412FAC File Offset: 0x004111AC
	protected override UniTask OnBeforeStartAsync()
	{
		HonamiStoryLevelInfoView.<OnBeforeStartAsync>d__36 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<HonamiStoryLevelInfoView.<OnBeforeStartAsync>d__36>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600EE9E RID: 61086 RVA: 0x00412FF0 File Offset: 0x004111F0
	protected override void OnBeforeShow()
	{
		this.PnlTeam.RefreshView();
		HonamiStoryQuestPanel questPanel = this.QuestPanel;
		ETarget? curTarget = this.CurTarget;
		ETarget etarget = ETarget.HonamiCity;
		questPanel.Refresh(curTarget.GetValueOrDefault() == etarget & curTarget != null);
		this.PnlEnterProfit.RefreshNormal(true);
		this.CheckHonamiTogRedDot();
		this.CheckTowerFirstUnLockRedDot();
		this.BtnGo.RefreshView();
	}

	// Token: 0x0600EE9F RID: 61087 RVA: 0x00413054 File Offset: 0x00411254
	protected override void OnAfterShow()
	{
		this.TryShowAreaUnLockTips();
		this.TryShowHonamiTowerUnLockTips();
		EHonamiStoryOutDialogType dialogType = EHonamiStoryOutDialogType.LevelInfoFree;
		if (!this.IsOpenFreeSelect && this.BoZaiTalkMap.ContainsKey(this.CurDangerLv))
		{
			dialogType = this.BoZaiTalkMap[this.CurDangerLv];
		}
		HonamiStoryOutDialog? randomDialogData = ModelBase<HonamiStoryModel>.Instance.GetRandomDialogData((int)dialogType);
		this.TalkPanel.SetTalkInfoTextAndPlayAudio(randomDialogData);
	}

	// Token: 0x0600EEA0 RID: 61088 RVA: 0x004130B5 File Offset: 0x004112B5
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.OnActivitySequenceEmitEvent));
	}

	// Token: 0x0600EEA1 RID: 61089 RVA: 0x004130D3 File Offset: 0x004112D3
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.OnActivitySequenceEmitEvent));
	}

	// Token: 0x0600EEA2 RID: 61090 RVA: 0x004130F1 File Offset: 0x004112F1
	protected override void OnBeforeHide()
	{
		this.ActData.CurTarget = (int)this.CurTarget.Value;
		this.ActData.CurHonamiLv = this.CurHonamiDangerLv;
		this.ActData.CurTowerLv = this.CurTowerDangerLv;
	}

	// Token: 0x0600EEA3 RID: 61091 RVA: 0x0041312C File Offset: 0x0041132C
	public int GetCurSafeLeavePrice()
	{
		if (this.IsOpenBuySafe)
		{
			ETarget? curTarget = this.CurTarget;
			ETarget etarget = ETarget.HonamiCity;
			if ((curTarget.GetValueOrDefault() == etarget & curTarget != null) && this.IsBuySafe)
			{
				return ConfigBase<HonamiStoryConfig>.Instance.GetDangerLevelConfig(this.CurDangerLv).Value.SafeLeavePrice;
			}
		}
		return 0;
	}

	// Token: 0x0600EEA4 RID: 61092 RVA: 0x00413188 File Offset: 0x00411388
	private void TryShowAreaUnLockTips()
	{
		Dictionary<int, bool> player = LocalStorage.GetPlayer<Dictionary<int, bool>>(ELocalStoragePlayerKey.HonamiStorySelectLvAreaUnLockTips, null);
		if (player == null)
		{
			return;
		}
		List<int> list = new List<int>(player.Keys);
		list.Sort((int a, int b) => a.CompareTo(b));
		foreach (int num in list)
		{
			bool flag;
			if (player.TryGetValue(num, out flag) && flag)
			{
				HonamiStoryArea? honamiStoryAreaConfig = ConfigBase<HonamiStoryConfig>.Instance.GetHonamiStoryAreaConfig(num);
				if (honamiStoryAreaConfig != null && !string.IsNullOrEmpty(honamiStoryAreaConfig.Value.UnLockTips))
				{
					DifficultUnlockTipsData difficultUnlockTipsData = new DifficultUnlockTipsData();
					difficultUnlockTipsData.Text = honamiStoryAreaConfig.Value.UnLockTips;
					Singleton<UiManager>.Instance.OpenView(EUiViewName.DifficultUnlockTipView, difficultUnlockTipsData, null);
					player[num] = false;
					LocalStorage.SetPlayer<Dictionary<int, bool>>(ELocalStoragePlayerKey.HonamiStorySelectLvAreaUnLockTips, player);
					break;
				}
			}
		}
	}

	// Token: 0x0600EEA5 RID: 61093 RVA: 0x00413294 File Offset: 0x00411494
	private void TryShowHonamiTowerUnLockTips()
	{
		bool player = LocalStorage.GetPlayer<bool>(ELocalStoragePlayerKey.HonamiStorySelectLvTowerUnLockTips, true);
		if (this.IsOpenTower && player)
		{
			DifficultUnlockTipsData difficultUnlockTipsData = new DifficultUnlockTipsData();
			difficultUnlockTipsData.Text = "HonamiStory_LevelUnlocked_6";
			Singleton<UiManager>.Instance.OpenView(EUiViewName.DifficultUnlockTipView, difficultUnlockTipsData, null);
			this.TowerTog.SetRedDotShow(true);
			this.BtnGo.SetRedDotShow(true);
			LocalStorage.SetPlayer<bool>(ELocalStoragePlayerKey.HonamiStorySelectLvTowerUnLockTogRedDot, true);
			LocalStorage.SetPlayer<bool>(ELocalStoragePlayerKey.HonamiStorySelectLvTowerUnLockBtnGoRedDot, true);
			LocalStorage.SetPlayer<bool>(ELocalStoragePlayerKey.HonamiStorySelectLvTowerUnLockTips, false);
		}
	}

	// Token: 0x0600EEA6 RID: 61094 RVA: 0x00413318 File Offset: 0x00411518
	private void CheckHonamiTogRedDot()
	{
		if (!this.IsOpenFreeSelect)
		{
			List<HonamiStoryAreaData> honamiStoryAreaDataList = this.ActData.GetHonamiStoryAreaDataList();
			if (this.CurDangerLv <= honamiStoryAreaDataList.Count)
			{
				HonamiStoryAreaData honamiStoryAreaData = this.ActData.GetHonamiStoryAreaData(this.CurDangerLv);
				if (honamiStoryAreaData != null && honamiStoryAreaData.IsAreaCanEnter)
				{
					this.HonamiCityTog.SetRedDotShow(true);
					this.BtnGo.SetRedDotShow(true);
				}
			}
		}
	}

	// Token: 0x0600EEA7 RID: 61095 RVA: 0x0041337C File Offset: 0x0041157C
	private void CheckTowerFirstUnLockRedDot()
	{
		if (LocalStorage.GetPlayer<bool>(ELocalStoragePlayerKey.HonamiStorySelectLvTowerUnLockTogRedDot, false))
		{
			this.TowerTog.SetRedDotShow(true);
		}
		if (LocalStorage.GetPlayer<bool>(ELocalStoragePlayerKey.HonamiStorySelectLvTowerUnLockBtnGoRedDot, false))
		{
			this.BtnGo.SetRedDotShow(true);
		}
	}

	// Token: 0x0600EEA8 RID: 61096 RVA: 0x004133B0 File Offset: 0x004115B0
	private void OnClickHelpBtn()
	{
		ControllerBase<HelpController>.Instance.OpenHelpById(437);
	}

	// Token: 0x0600EEA9 RID: 61097 RVA: 0x004133C1 File Offset: 0x004115C1
	private void OnClickCloseBtn()
	{
		base.CloseMe(null);
	}

	// Token: 0x0600EEAA RID: 61098 RVA: 0x004133CC File Offset: 0x004115CC
	private void OnClickLeftToggle()
	{
		ETarget? curTarget = this.CurTarget;
		ETarget etarget = ETarget.HonamiCity;
		if (!(curTarget.GetValueOrDefault() == etarget & curTarget != null))
		{
			this.SwitchTarget(ETarget.HonamiCity);
		}
	}

	// Token: 0x0600EEAB RID: 61099 RVA: 0x00413400 File Offset: 0x00411600
	private void OnClickRightToggle()
	{
		if (!this.IsOpenTower)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("HonamiStory_TowerUnlockedPrompt", Array.Empty<object>());
			this.TowerTog.GetTog.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
			return;
		}
		if (this.CurTarget.GetValueOrDefault() != ETarget.Tower)
		{
			if (LocalStorage.GetPlayer<bool>(ELocalStoragePlayerKey.HonamiStorySelectLvTowerUnLockTogRedDot, false))
			{
				this.TowerTog.SetRedDotShow(false);
				LocalStorage.SetPlayer<bool>(ELocalStoragePlayerKey.HonamiStorySelectLvTowerUnLockTogRedDot, false);
			}
			this.SwitchTarget(ETarget.Tower);
		}
	}

	// Token: 0x0600EEAC RID: 61100 RVA: 0x00413479 File Offset: 0x00411679
	private bool CanToggleChange(ETarget target)
	{
		return target != this.CurTarget.Value;
	}

	// Token: 0x0600EEAD RID: 61101 RVA: 0x0041348C File Offset: 0x0041168C
	private void SwitchTarget(ETarget target)
	{
		if (target != ETarget.HonamiCity)
		{
			if (target == ETarget.Tower)
			{
				this.CurTarget = new ETarget?(ETarget.Tower);
				this.CurDangerLv = this.CurTowerDangerLv;
				this.HonamiCityTog.GetTog.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
				this.TowerTog.GetTog.SetToggleState(EToggleState.ETT_Checked, false, false, false);
				this.TargetBgPath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("HonamiSelectLvBg2");
			}
		}
		else
		{
			this.CurTarget = new ETarget?(ETarget.HonamiCity);
			this.CurDangerLv = this.CurHonamiDangerLv;
			this.HonamiCityTog.GetTog.SetToggleState(EToggleState.ETT_Checked, false, false, false);
			this.TowerTog.GetTog.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
			this.TargetBgPath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("HonamiSelectLvBg1");
		}
		LevelSequencePlayer seqPlayer = this.SeqPlayer;
		if (seqPlayer != null)
		{
			seqPlayer.StopSequenceByKey("Switch", false, false);
		}
		LevelSequencePlayer seqPlayer2 = this.SeqPlayer;
		if (seqPlayer2 != null)
		{
			seqPlayer2.PlayLevelSequenceByName("Switch", false, null, false);
		}
		HonamiStoryDangerLevel value = ConfigBase<HonamiStoryConfig>.Instance.GetDangerLevelConfig(this.CurDangerLv).Value;
		this.CurEnumDangerLv = new EDangerLv?((EDangerLv)value.DangerLv);
		this.RefreshLevelInfo();
		this.RefreshCurDangerLvInfo();
		ETarget? curTarget = this.CurTarget;
		ETarget etarget = ETarget.HonamiCity;
		bool flag = curTarget.GetValueOrDefault() == etarget & curTarget != null;
		this.QuestPanel.Refresh(flag);
		base.GetText(24).SetUIActive(flag);
		base.GetText(6).SetUIActive(flag);
		this.CheckBuySafeOrTowerLogShow();
		this.BtnGo.SetCostData(value.ConsumeItems());
	}

	// Token: 0x0600EEAE RID: 61102 RVA: 0x00413624 File Offset: 0x00411824
	[NullableContext(1)]
	private void OnActivitySequenceEmitEvent(string param)
	{
		if (param == "Enter04" && !string.IsNullOrEmpty(this.TargetBgPath))
		{
			base.SetTextureByPath(this.TargetBgPath, base.GetTexture(0), null, null);
		}
	}

	// Token: 0x0600EEAF RID: 61103 RVA: 0x00413668 File Offset: 0x00411868
	private void OnClickBtnReduce()
	{
		ETarget value = this.CurTarget.Value;
		if (value != ETarget.HonamiCity)
		{
			if (value == ETarget.Tower)
			{
				if (this.CurDangerLv <= this.MinTowerLv)
				{
					return;
				}
				this.CurDangerLv--;
				this.CurTowerDangerLv = this.CurDangerLv;
			}
		}
		else
		{
			if (this.CurDangerLv <= this.MinHonamiLv)
			{
				return;
			}
			this.CurDangerLv--;
			this.CurHonamiDangerLv = this.CurDangerLv;
		}
		HonamiStoryDangerLevel value2 = ConfigBase<HonamiStoryConfig>.Instance.GetDangerLevelConfig(this.CurDangerLv).Value;
		this.CurEnumDangerLv = new EDangerLv?((EDangerLv)value2.DangerLv);
		this.RefreshLevelInfo();
		this.RefreshCurDangerLvInfo();
		this.CheckBuySafeOrTowerLogShow();
		this.BtnGo.SetCostData(value2.ConsumeItems());
	}

	// Token: 0x0600EEB0 RID: 61104 RVA: 0x00413730 File Offset: 0x00411930
	private void OnClickBtnAdd()
	{
		ETarget value = this.CurTarget.Value;
		if (value != ETarget.HonamiCity)
		{
			if (value == ETarget.Tower)
			{
				if (this.CurDangerLv >= this.MaxTowerLv)
				{
					return;
				}
				this.CurDangerLv++;
				this.CurTowerDangerLv = this.CurDangerLv;
			}
		}
		else
		{
			if (this.CurDangerLv >= this.MaxHonamiLv)
			{
				return;
			}
			this.CurDangerLv++;
			this.CurHonamiDangerLv = this.CurDangerLv;
		}
		HonamiStoryDangerLevel value2 = ConfigBase<HonamiStoryConfig>.Instance.GetDangerLevelConfig(this.CurDangerLv).Value;
		this.CurEnumDangerLv = new EDangerLv?((EDangerLv)value2.DangerLv);
		this.RefreshLevelInfo();
		this.RefreshCurDangerLvInfo();
		this.CheckBuySafeOrTowerLogShow();
		this.BtnGo.SetCostData(value2.ConsumeItems());
	}

	// Token: 0x0600EEB1 RID: 61105 RVA: 0x004137F7 File Offset: 0x004119F7
	private void OnBuySafeTogClick(EToggleState toggleState)
	{
		this.IsBuySafe = (base.GetExtendToggle(16).GetToggleState() == EToggleState.ETT_Checked);
		this.BtnGo.RefreshView();
	}

	// Token: 0x0600EEB2 RID: 61106 RVA: 0x0041381C File Offset: 0x00411A1C
	private void RefreshLevelInfo()
	{
		HonamiStoryDangerLevel? dangerLevelConfig = ConfigBase<HonamiStoryConfig>.Instance.GetDangerLevelConfig(this.CurDangerLv);
		ETarget? curTarget = this.CurTarget;
		ETarget etarget = ETarget.HonamiCity;
		if (curTarget.GetValueOrDefault() == etarget & curTarget != null)
		{
			if (ModelBase<FunctionModel>.Instance.IsOpen(10121))
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(21), "HonamiStory_FreeRegionName", Array.Empty<object>());
			}
			else
			{
				string lvSelectName = this.ActData.GetHonamiStoryAreaData(this.CurDangerLv).Config.Value.LvSelectName;
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(21), lvSelectName, Array.Empty<object>());
			}
		}
		else
		{
			string towerName = this.ActData.TowerName;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(21), towerName, Array.Empty<object>());
		}
		base.GetText(5).SetText(dangerLevelConfig.Value.LvShow, true);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), dangerLevelConfig.Value.FallQuaId, Array.Empty<object>());
	}

	// Token: 0x0600EEB3 RID: 61107 RVA: 0x00413934 File Offset: 0x00411B34
	private void CheckBuySafeOrTowerLogShow()
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(16);
		UUIText text = base.GetText(17);
		UUITexture texture = base.GetTexture(18);
		UUIText text2 = base.GetText(19);
		ETarget? curTarget = this.CurTarget;
		ETarget etarget = ETarget.HonamiCity;
		if (!(curTarget.GetValueOrDefault() == etarget & curTarget != null))
		{
			extendToggle.RootUIComp.Get().SetUIActive(false);
			text.SetUIActive(true);
			texture.SetUIActive(false);
			text2.SetUIActive(true);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(17), "HonamiStory_PassFloors", Array.Empty<object>());
			int maxFloorByDangerLv = this.ActData.GetMaxFloorByDangerLv(this.CurDangerLv);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(19), "HonamiStory_PassFloorsNumbers", new <>z__ReadOnlySingleElementList<object>(maxFloorByDangerLv));
			return;
		}
		if (this.IsOpenBuySafe)
		{
			extendToggle.RootUIComp.Get().SetUIActive(true);
			text.SetUIActive(true);
			texture.SetUIActive(true);
			text2.SetUIActive(true);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(17), "HonamiStory_ExtractionChargeBuy", Array.Empty<object>());
			ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(this.ActData.OutCoinItemId);
			if (itemConfigData != null)
			{
				base.SetTextureByPath(itemConfigData.Icon, base.GetTexture(18), null, null);
			}
			HonamiStoryDangerLevel? dangerLevelConfig = ConfigBase<HonamiStoryConfig>.Instance.GetDangerLevelConfig(this.CurDangerLv);
			base.GetText(19).SetText(dangerLevelConfig.Value.SafeLeavePrice.ToString(), true);
			return;
		}
		extendToggle.RootUIComp.Get().SetUIActive(false);
		text.SetUIActive(true);
		texture.SetUIActive(false);
		text2.SetUIActive(false);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(17), "HonamiStory_DepartAnytime", Array.Empty<object>());
	}

	// Token: 0x0600EEB4 RID: 61108 RVA: 0x00413B14 File Offset: 0x00411D14
	private void RefreshCurDangerLvInfo()
	{
		UUIButtonComponent button = base.GetButton(13);
		UUIButtonComponent button2 = base.GetButton(14);
		UUISprite sprite = base.GetSprite(12);
		UUISprite sprite2 = base.GetSprite(15);
		UUIText text = base.GetText(9);
		UUITexture texture = base.GetTexture(10);
		UUITexture texture2 = base.GetTexture(8);
		button.RootUIComp.Get().SetUIActive(this.IsOpenFreeSelect);
		button2.RootUIComp.Get().SetUIActive(this.IsOpenFreeSelect);
		sprite.SetUIActive(this.IsOpenFreeSelect);
		sprite2.SetUIActive(!this.IsOpenFreeSelect);
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(8, 1);
		defaultInterpolatedStringHandler.AppendLiteral("RomanNum");
		defaultInterpolatedStringHandler.AppendFormatted<int>(this.CurDangerLv);
		string resourceId = defaultInterpolatedStringHandler.ToStringAndClear();
		if (!this.IsOpenFreeSelect)
		{
			this.SetSpriteByPath(ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId), sprite2, false, null, null);
		}
		else
		{
			int num = 0;
			int num2 = 0;
			ETarget value = this.CurTarget.Value;
			if (value != ETarget.HonamiCity)
			{
				if (value == ETarget.Tower)
				{
					num = this.MinTowerLv;
					num2 = this.MaxTowerLv;
				}
			}
			else
			{
				num = this.MinHonamiLv;
				num2 = this.MaxHonamiLv;
			}
			button.SetSelfInteractive(this.CurDangerLv != num);
			button2.SetSelfInteractive(this.CurDangerLv != num2);
			this.SetSpriteByPath(ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId), sprite, false, null, null);
		}
		string path;
		switch (this.CurEnumDangerLv.Value)
		{
		case EDangerLv.Safe:
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "HonamiStory_easy", Array.Empty<object>());
			text.SetColor(HonamiStoryLevelInfoView.safeColor);
			texture.SetColor(HonamiStoryLevelInfoView.safeColor);
			path = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("DangerLvBg1");
			break;
		case EDangerLv.Average:
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "HonamiStory_medium", Array.Empty<object>());
			text.SetColor(HonamiStoryLevelInfoView.averageColor);
			texture.SetColor(HonamiStoryLevelInfoView.averageColor);
			path = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("DangerLvBg2");
			break;
		case EDangerLv.Hard:
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "HonamiStory_hard", Array.Empty<object>());
			text.SetColor(HonamiStoryLevelInfoView.hardColor);
			texture.SetColor(HonamiStoryLevelInfoView.hardColor);
			path = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("DangerLvBg3");
			break;
		default:
			path = string.Empty;
			break;
		}
		base.SetTextureByPath(path, texture2, null, null);
	}

	// Token: 0x0600EEB5 RID: 61109 RVA: 0x00413D96 File Offset: 0x00411F96
	protected override void OnBeforeDestroy()
	{
		LevelSequencePlayer seqPlayer = this.SeqPlayer;
		if (seqPlayer != null)
		{
			seqPlayer.Clear();
		}
		this.SeqPlayer = null;
	}

	// Token: 0x040072A5 RID: 29349
	[StaticVariableRuleIgnore]
	private static readonly FColor safeColor = FColor.FromHex("#59859C");

	// Token: 0x040072A6 RID: 29350
	[StaticVariableRuleIgnore]
	private static readonly FColor averageColor = FColor.FromHex("#6982D1");

	// Token: 0x040072A7 RID: 29351
	[StaticVariableRuleIgnore]
	private static readonly FColor hardColor = FColor.FromHex("#A04661");

	// Token: 0x040072A8 RID: 29352
	private int MinHonamiLv;

	// Token: 0x040072A9 RID: 29353
	private int MaxHonamiLv;

	// Token: 0x040072AA RID: 29354
	private int MinTowerLv;

	// Token: 0x040072AB RID: 29355
	private int MaxTowerLv;

	// Token: 0x040072AC RID: 29356
	private PopupCaptionItem CaptionItem;

	// Token: 0x040072AD RID: 29357
	private HonamiStoryQuestPanel QuestPanel;

	// Token: 0x040072AE RID: 29358
	private TargetTog HonamiCityTog;

	// Token: 0x040072AF RID: 29359
	private TargetTog TowerTog;

	// Token: 0x040072B0 RID: 29360
	private BtnGo BtnGo;

	// Token: 0x040072B1 RID: 29361
	private PnlTeam PnlTeam;

	// Token: 0x040072B2 RID: 29362
	[Nullable(1)]
	private HonamiStoryBozaiTalkPanel TalkPanel;

	// Token: 0x040072B3 RID: 29363
	[Nullable(1)]
	private HonamiStoryProfitPanel PnlEnterProfit;

	// Token: 0x040072B4 RID: 29364
	private LevelSequencePlayer SeqPlayer;

	// Token: 0x040072B5 RID: 29365
	[Nullable(1)]
	private readonly Dictionary<int, EHonamiStoryOutDialogType> BoZaiTalkMap;

	// Token: 0x040072B6 RID: 29366
	private HonamiStoryActivityData ActData;

	// Token: 0x040072B7 RID: 29367
	private ETarget? CurTarget;

	// Token: 0x040072B8 RID: 29368
	private int CurDangerLv;

	// Token: 0x040072B9 RID: 29369
	private int CurHonamiDangerLv;

	// Token: 0x040072BA RID: 29370
	private int CurTowerDangerLv;

	// Token: 0x040072BB RID: 29371
	private bool IsBuySafe;

	// Token: 0x040072BC RID: 29372
	private EDangerLv? CurEnumDangerLv;

	// Token: 0x040072BD RID: 29373
	private bool IsOpenFreeSelect;

	// Token: 0x040072BE RID: 29374
	private bool IsOpenBuySafe;

	// Token: 0x040072BF RID: 29375
	private bool IsOpenTower;

	// Token: 0x040072C0 RID: 29376
	[Nullable(1)]
	private string TargetBgPath;
}
