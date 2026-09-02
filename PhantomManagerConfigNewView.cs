using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002496 RID: 9366
[NullableContext(1)]
[Nullable(0)]
public class PhantomManagerConfigNewView : UiTabViewBase
{
	// Token: 0x060122BD RID: 74429 RVA: 0x004FF79C File Offset: 0x004FD99C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 16;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUILoopScrollViewComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 5;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickedToggleDiscard));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClickedApplyPlan));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.OnClickedRecommendAll));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(13, new Action(this.OnClickedEdit));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(5, new Action(this.OnClickedDelete));
		this.BtnBindInfo = list2;
	}

	// Token: 0x060122BE RID: 74430 RVA: 0x004FFAA5 File Offset: 0x004FDCA5
	protected override void AddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<bool>(EEventName.OnPhantomConfigManagerDataUpdate, new Action<bool>(this.OnEmitUpdate));
	}

	// Token: 0x060122BF RID: 74431 RVA: 0x004FFAC3 File Offset: 0x004FDCC3
	protected override void RemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove<bool>(EEventName.OnPhantomConfigManagerDataUpdate, new Action<bool>(this.OnEmitUpdate));
	}

	// Token: 0x060122C0 RID: 74432 RVA: 0x004FFAE4 File Offset: 0x004FDCE4
	protected override UniTask OnBeforeStartAsync()
	{
		PhantomManagerConfigNewView.<OnBeforeStartAsync>d__14 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<PhantomManagerConfigNewView.<OnBeforeStartAsync>d__14>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060122C1 RID: 74433 RVA: 0x004FFB28 File Offset: 0x004FDD28
	protected override void OnStart()
	{
		this.LevelSequence = new LevelSequencePlayer(base.GetItem(14));
		this.ScrollConfig = new LoopScrollView<PhantomManagerConfigNewFetterItem, IPhantomManagerFetterInfo>(base.GetLoopScrollViewComponent(1), base.GetItem(2).GetOwner() as AUIBaseActor, new Func<PhantomManagerConfigNewFetterItem>(this.CreateConfigItem), true);
		this.ScrollSetting = new GenericScrollViewNew<PhantomManagerConfigNewSettingItem, IPhantomManagerConfigNewSettingInfo>(base.GetScrollViewWithScrollbar(10), new Func<PhantomManagerConfigNewSettingItem>(this.CreateSettingTitleItem), null, false, null);
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle != null)
		{
			extendToggle.SetToggleState(this.ConfigData.DownFiveStarSwitch ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
		}
		this.InitElementList();
		this.RefreshNormalState(true);
	}

	// Token: 0x060122C2 RID: 74434 RVA: 0x004FFBD0 File Offset: 0x004FDDD0
	protected override void OnBeforeShow()
	{
		this.FetterGroupInfoDataList.Clear();
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		foreach (PhantomItemData phantomItemData in ModelBase<InventoryModel>.Instance.GetPhantomItemDataList())
		{
			int id = phantomItemData.GetFetterGroupConfig().Value.Id;
			dictionary[id] = dictionary.GetValueOrDefault(id, 0) + 1;
		}
		foreach (int num in this.FetterGroupDataList)
		{
			this.FetterGroupInfoDataList.Add(new PhantomManagerFetterInfo
			{
				FetterId = num,
				Count = dictionary.GetValueOrDefault(num, 0)
			});
		}
		this.ScrollConfig.RefreshByData(this.FetterGroupInfoDataList, false, null, true);
	}

	// Token: 0x060122C3 RID: 74435 RVA: 0x004FFCD0 File Offset: 0x004FDED0
	protected void InitElementList()
	{
		Dictionary<int, PhantomFetterGroup> tmpMap = new Dictionary<int, PhantomFetterGroup>();
		foreach (PhantomFetterGroup value in ConfigBase<PhantomBattleConfig>.Instance.GetPhantomFetterGroupList())
		{
			this.FetterGroupDataList.Add(value.Id);
			tmpMap[value.Id] = value;
		}
		this.FetterGroupDataList.Sort((int a, int b) => tmpMap[b].SortId - tmpMap[a].SortId);
		if (this.FetterGroupDataList.Count > 0)
		{
			this.CurrentSelectId = this.FetterGroupDataList[0];
		}
	}

	// Token: 0x060122C4 RID: 74436 RVA: 0x004FFD88 File Offset: 0x004FDF88
	protected void RefreshNormalState(bool isSelectOther = false)
	{
		if (this.CurrentSelectId < 0)
		{
			return;
		}
		UUIItem item = base.GetItem(12);
		if (item != null)
		{
			item.SetUIActive(true);
		}
		PhantomFetterGroup fetterGroupById = ConfigBase<PhantomBattleConfig>.Instance.GetFetterGroupById(this.CurrentSelectId);
		base.SetTextureByPath(fetterGroupById.FetterElementPath, base.GetTexture(6), null, null);
		string configTextByKey = Singleton<PublicUtil>.Instance.GetConfigTextByKey(fetterGroupById.FetterGroupName);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(7), "PhantomProject_PlanName", new <>z__ReadOnlySingleElementList<object>(configTextByKey));
		this.ScrollSetting.RefreshByData(this.GetDetailDataList(false), null, true);
		bool fetterConfigIsOpen = this.ConfigData.GetFetterConfigIsOpen(this.CurrentSelectId);
		UUITexture texture = base.GetTexture(8);
		if (texture != null)
		{
			texture.SetUIActive(!fetterConfigIsOpen);
		}
		this.SetActivatePanelState(fetterConfigIsOpen, isSelectOther);
		ButtonItem fetterUseBtn = this.FetterUseBtn;
		if (fetterUseBtn == null)
		{
			return;
		}
		fetterUseBtn.SetLocalTextNew(fetterConfigIsOpen ? "PhantomProject_ClosePlan_Title" : "PhantomProject_StartPlan_Title", Array.Empty<object>());
	}

	// Token: 0x060122C5 RID: 74437 RVA: 0x004FFE78 File Offset: 0x004FE078
	protected List<IPhantomManagerConfigNewSettingInfo> GetDetailDataList(bool needRefresh = false)
	{
		List<IPhantomManagerConfigNewSettingInfo> result;
		if (this.FetterDataMap.TryGetValue(this.CurrentSelectId, out result) && !needRefresh)
		{
			return result;
		}
		List<IPhantomManagerConfigNewSettingInfo> list = new List<IPhantomManagerConfigNewSettingInfo>();
		int[] fetterGroupMonsterIdArray = ModelBase<PhantomBattleModel>.Instance.GetFetterGroupMonsterIdArray(this.CurrentSelectId);
		HashSet<int> hashSet = new HashSet<int>();
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		Dictionary<int, int> dictionary2 = new Dictionary<int, int>();
		foreach (int monsterId in fetterGroupMonsterIdArray)
		{
			PhantomItem phantomItem = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomItemByMonsterId(monsterId)[0];
			int cost = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomRareConfig(phantomItem.Rarity).Value.Cost;
			hashSet.Add(cost);
			dictionary[cost] = 0;
			if (!dictionary2.ContainsKey(cost))
			{
				dictionary2[cost] = phantomItem.ItemId;
			}
		}
		foreach (PhantomItemData phantomItemData in ModelBase<InventoryModel>.Instance.GetPhantomItemDataList())
		{
			if (phantomItemData.GetFetterGroupConfig().Value.Id == this.CurrentSelectId)
			{
				int cost2 = ModelBase<PhantomBattleModel>.Instance.GetPhantomBattleData(phantomItemData.GetUniqueId()).GetCost();
				dictionary[cost2] = dictionary.GetValueOrDefault(cost2, 0) + 1;
			}
		}
		foreach (int num in from o in hashSet
		orderby o descending
		select o)
		{
			list.Add(new PhantomManagerConfigNewSettingInfo
			{
				FetterId = this.CurrentSelectId,
				Cost = num,
				Count = dictionary.GetValueOrDefault(num, 0),
				ItemId = dictionary2[num],
				IsEdit = false
			});
		}
		this.FetterDataMap[this.CurrentSelectId] = list;
		return list;
	}

	// Token: 0x060122C6 RID: 74438 RVA: 0x0050008C File Offset: 0x004FE28C
	private void SetActivatePanelState(bool isVisible, bool noAnim)
	{
		if (isVisible)
		{
			if (this.LevelSequence.IsPlayingSequence("Off"))
			{
				this.LevelSequence.StopSequenceByKey("Off", false, false);
			}
			TimerSystem.Instance.Next(delegate(float _)
			{
				if (!noAnim)
				{
					UUIItem item = this.GetItem(15);
					if (item != null)
					{
						item.SetUIActive(false);
					}
					this.LevelSequence.PlayOrReplaySequenceByName("Press", false, null);
					return;
				}
				UUIItem item2 = this.GetItem(9);
				if (item2 != null)
				{
					item2.SetUIActive(false);
				}
				UUIItem item3 = this.GetItem(15);
				if (item3 == null)
				{
					return;
				}
				item3.SetUIActive(true);
			}, null, null);
			return;
		}
		if (this.LevelSequence.IsPlayingSequence("Press"))
		{
			this.LevelSequence.StopSequenceByKey("Press", false, false);
		}
		TimerSystem.Instance.Next(delegate(float _)
		{
			if (!noAnim)
			{
				UUIItem item = this.GetItem(15);
				if (item != null)
				{
					item.SetUIActive(false);
				}
				this.LevelSequence.PlayOrReplaySequenceByName("Off", false, null);
				return;
			}
			UUIItem item2 = this.GetItem(9);
			if (item2 != null)
			{
				item2.SetUIActive(false);
			}
			UUIItem item3 = this.GetItem(15);
			if (item3 == null)
			{
				return;
			}
			item3.SetUIActive(false);
		}, null, null);
	}

	// Token: 0x060122C7 RID: 74439 RVA: 0x0050012C File Offset: 0x004FE32C
	private void OnClickedToggleDiscard(EToggleState state)
	{
		bool downFiveStarSwitch = this.ConfigData.DownFiveStarSwitch;
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle != null)
		{
			extendToggle.SetToggleState(downFiveStarSwitch ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, true);
		}
		PhantomDiscardPlanAutoDiscardFiveReport logData = new PhantomDiscardPlanAutoDiscardFiveReport();
		logData.i_type = (downFiveStarSwitch ? 2 : 1);
		if (!downFiveStarSwitch)
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.PhantomConfigAutoDiscardNot5Confirm);
			confirmBoxDataNew.FunctionMap[1] = delegate()
			{
				UUIExtendToggle extendToggle2 = this.GetExtendToggle(0);
				if (extendToggle2 == null)
				{
					return;
				}
				extendToggle2.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
			};
			confirmBoxDataNew.FunctionMap[2] = delegate()
			{
				this.UpdateDiscardToggleState();
				ControllerBase<LogReportController>.Instance.LogReport(logData);
			};
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
			return;
		}
		this.UpdateDiscardToggleState();
		ControllerBase<LogReportController>.Instance.LogReport(logData);
	}

	// Token: 0x060122C8 RID: 74440 RVA: 0x005001ED File Offset: 0x004FE3ED
	private void UpdateDiscardToggleState()
	{
		ControllerBase<PhantomBattleController>.Instance.RequestPhBaPlanSetFiveStarSwitch().ContinueWith(delegate(bool value)
		{
			if (value)
			{
				UUIExtendToggle extendToggle = base.GetExtendToggle(0);
				if (extendToggle == null)
				{
					return;
				}
				extendToggle.SetToggleState(this.ConfigData.DownFiveStarSwitch ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
			}
		}).Forget();
	}

	// Token: 0x060122C9 RID: 74441 RVA: 0x0050020F File Offset: 0x004FE40F
	private PhantomManagerConfigNewFetterItem CreateConfigItem()
	{
		return new PhantomManagerConfigNewFetterItem
		{
			IsSelectOnCb = new Func<int, bool>(this.GetToggleStateSelected),
			OnToggleStateChangeFunction = new Action<int>(this.OnToggleStateChange)
		};
	}

	// Token: 0x060122CA RID: 74442 RVA: 0x0050023A File Offset: 0x004FE43A
	private PhantomManagerConfigNewSettingItem CreateSettingTitleItem()
	{
		return new PhantomManagerConfigNewSettingItem();
	}

	// Token: 0x060122CB RID: 74443 RVA: 0x00500241 File Offset: 0x004FE441
	private bool GetToggleStateSelected(int awardId)
	{
		return this.CurrentSelectId == awardId;
	}

	// Token: 0x060122CC RID: 74444 RVA: 0x0050024C File Offset: 0x004FE44C
	private void OnToggleStateChange(int id)
	{
		this.CurrentSelectId = id;
		this.ScrollConfig.RefreshByData(this.FetterGroupInfoDataList, false, null, false);
		this.RefreshNormalState(true);
	}

	// Token: 0x060122CD RID: 74445 RVA: 0x00500270 File Offset: 0x004FE470
	private void OnClickedEdit()
	{
		base.GetLoopScrollViewComponent(1).StopMovement();
		this.ScrollConfig.ScrollToGridIndex(this.FetterGroupDataList.IndexOf(this.CurrentSelectId), true);
		UUIItem item = base.GetItem(12);
		if (item != null)
		{
			item.SetUIActive(false);
		}
		IPhantomManagerFetterInfo phantomManagerFetterInfo = this.FetterGroupInfoDataList.FirstOrDefault((IPhantomManagerFetterInfo o) => o.FetterId == this.CurrentSelectId);
		int count = (phantomManagerFetterInfo != null) ? phantomManagerFetterInfo.Count : 0;
		Singleton<UiManager>.Instance.OpenView(EUiViewName.PhantomManagerConfigEditPopItem, new PhantomManagerEditPopInfo
		{
			FetterId = this.CurrentSelectId,
			Count = count,
			DataList = this.GetDetailDataList(false),
			CloseCb = new Action(this.OnClosedEdit)
		}, null);
	}

	// Token: 0x060122CE RID: 74446 RVA: 0x00500325 File Offset: 0x004FE525
	private void OnEmitUpdate(bool needScroll)
	{
		if (needScroll)
		{
			this.CurrentSelectId = this.FetterGroupDataList[0];
			this.ScrollConfig.ScrollToGridIndex(0, true);
		}
		this.ScrollConfig.RefreshByData(this.FetterGroupInfoDataList, false, null, false);
		this.RefreshNormalState(false);
	}

	// Token: 0x060122CF RID: 74447 RVA: 0x00500364 File Offset: 0x004FE564
	private void OnClickedDelete()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.PhantomManagerConfigResetPopItem, new Action(this.OnDeleteSuccess), null);
	}

	// Token: 0x060122D0 RID: 74448 RVA: 0x00500382 File Offset: 0x004FE582
	private void OnDeleteSuccess()
	{
		this.ScrollConfig.RefreshByData(this.FetterGroupInfoDataList, false, null, true);
		this.RefreshNormalState(false);
	}

	// Token: 0x060122D1 RID: 74449 RVA: 0x005003A0 File Offset: 0x004FE5A0
	private void OnClickedApplyPlan()
	{
		IPhantomManagerApplySettingDetailInfo phantomPlanMatchApplyData = this.ConfigData.GetPhantomPlanMatchApplyData();
		if (phantomPlanMatchApplyData.DiscardList.Count == 0 && phantomPlanMatchApplyData.LockList.Count == 0)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("PhantomProject_Reorganize_Des_5", Array.Empty<object>());
		}
		else
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.PhantomManagerConfigRemovePopItem, phantomPlanMatchApplyData, null);
		}
		this.ConfigData.DoLogReport(new List<int>
		{
			this.CurrentSelectId
		}, false);
	}

	// Token: 0x060122D2 RID: 74450 RVA: 0x00500418 File Offset: 0x004FE618
	private void OnClickedRecommendAll()
	{
		bool flag = false;
		foreach (int num in this.FetterGroupDataList)
		{
			flag = (this.ConfigData.SetFetterConfigRecommend(num) || flag);
			flag = (!this.ConfigData.GetFetterConfigIsOpen(num) || flag);
		}
		if (!flag)
		{
			this.ConfigData.DoCacheDataUpdate(false);
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("PhantomProject_UsePreparatoryPlan_Des_1", Array.Empty<object>());
			return;
		}
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.PhantomConfigApplyPreRecommendConfirm);
		confirmBoxDataNew.HasToggle = true;
		confirmBoxDataNew.ToggleText = Singleton<PublicUtil>.Instance.GetConfigTextByKey("PhantomProject_UsePreparatoryPlan_Des_3");
		this.ConfirmBoxRecommendApplyPlan = false;
		confirmBoxDataNew.SetToggleFunction(new Action<bool>(this.OnRecommendAllToggle));
		confirmBoxDataNew.FunctionMap[1] = delegate()
		{
			this.ConfigData.DoCacheDataUpdate(false);
		};
		confirmBoxDataNew.FunctionMap[2] = delegate()
		{
			ControllerBase<PhantomBattleController>.Instance.RequestPhBaPlanSaveUsePlan(false, this.FetterGroupDataList.ToHashSet<int>()).ContinueWith(delegate(bool value)
			{
				if (!value)
				{
					this.ConfigData.DoCacheDataUpdate(false);
				}
				else if (this.ConfirmBoxRecommendApplyPlan)
				{
					IPhantomManagerApplySettingDetailInfo phantomPlanMatchApplyData = this.ConfigData.GetPhantomPlanMatchApplyData();
					this.ConfigData.DoApplyOpera(phantomPlanMatchApplyData).Forget<bool>();
				}
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("PhantomProject_UsePreparatoryPlan_Des_4", Array.Empty<object>());
				ControllerBase<PhantomBattleController>.Instance.RequestPhBaPlanSetPlanStatus(this.FetterGroupDataList, true).ContinueWith(delegate(bool _)
				{
					this.RefreshNormalState(false);
					this.ScrollConfig.RefreshByData(this.FetterGroupInfoDataList, false, null, false);
					this.ConfigData.DoLogReport(this.FetterGroupDataList, true);
				}).Forget();
			}).Forget();
		};
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x060122D3 RID: 74451 RVA: 0x00500528 File Offset: 0x004FE728
	private void OnRecommendAllToggle(bool toggleState)
	{
		this.ConfirmBoxRecommendApplyPlan = toggleState;
	}

	// Token: 0x060122D4 RID: 74452 RVA: 0x00500531 File Offset: 0x004FE731
	private void OnClosedEdit()
	{
		UUIItem item = base.GetItem(12);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(true);
	}

	// Token: 0x060122D5 RID: 74453 RVA: 0x00500548 File Offset: 0x004FE748
	private void OnClickedFetterUsed(int _)
	{
		int curFetter = this.CurrentSelectId;
		bool fetterConfigIsOpen = this.ConfigData.GetFetterConfigIsOpen(curFetter);
		ControllerBase<PhantomBattleController>.Instance.RequestPhBaPlanSetPlanStatus(new List<int>
		{
			curFetter
		}, !fetterConfigIsOpen).ContinueWith(delegate(bool value)
		{
			if (!value)
			{
				return;
			}
			bool fetterConfigIsOpen2 = this.ConfigData.GetFetterConfigIsOpen(curFetter);
			if (curFetter == this.CurrentSelectId)
			{
				this.ScrollConfig.RefreshByData(this.FetterGroupInfoDataList, false, null, false);
				UUITexture texture = this.GetTexture(8);
				if (texture != null)
				{
					texture.SetUIActive(!fetterConfigIsOpen2);
				}
				this.SetActivatePanelState(fetterConfigIsOpen2, false);
				ButtonItem fetterUseBtn = this.FetterUseBtn;
				if (fetterUseBtn != null)
				{
					fetterUseBtn.SetLocalTextNew(fetterConfigIsOpen2 ? "PhantomProject_ClosePlan_Title" : "PhantomProject_StartPlan_Title", Array.Empty<object>());
				}
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId(fetterConfigIsOpen2 ? "PhantomProject_StartPlan_Des_1" : "PhantomProject_ClosePlan_Des_1", Array.Empty<object>());
			}
		}).Forget();
	}

	// Token: 0x04008DDB RID: 36315
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private LoopScrollView<PhantomManagerConfigNewFetterItem, IPhantomManagerFetterInfo> ScrollConfig;

	// Token: 0x04008DDC RID: 36316
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericScrollViewNew<PhantomManagerConfigNewSettingItem, IPhantomManagerConfigNewSettingInfo> ScrollSetting;

	// Token: 0x04008DDD RID: 36317
	private readonly Dictionary<int, List<IPhantomManagerConfigNewSettingInfo>> FetterDataMap = new Dictionary<int, List<IPhantomManagerConfigNewSettingInfo>>();

	// Token: 0x04008DDE RID: 36318
	private readonly List<int> FetterGroupDataList = new List<int>();

	// Token: 0x04008DDF RID: 36319
	private readonly List<IPhantomManagerFetterInfo> FetterGroupInfoDataList = new List<IPhantomManagerFetterInfo>();

	// Token: 0x04008DE0 RID: 36320
	private int CurrentSelectId = -1;

	// Token: 0x04008DE1 RID: 36321
	protected PhantomManagerConfigData ConfigData = new PhantomManagerConfigData();

	// Token: 0x04008DE2 RID: 36322
	[Nullable(2)]
	protected ButtonItem FetterUseBtn;

	// Token: 0x04008DE3 RID: 36323
	[Nullable(2)]
	protected LevelSequencePlayer LevelSequence;

	// Token: 0x04008DE4 RID: 36324
	private bool ConfirmBoxRecommendApplyPlan;

	// Token: 0x020087B3 RID: 34739
	[NullableContext(0)]
	private enum EDefine
	{
		// Token: 0x0402DDDE RID: 187870
		ToggleAutoDiscard,
		// Token: 0x0402DDDF RID: 187871
		LoopScrollElement,
		// Token: 0x0402DDE0 RID: 187872
		ElementItem,
		// Token: 0x0402DDE1 RID: 187873
		BtnLeft1,
		// Token: 0x0402DDE2 RID: 187874
		BtnLeft2,
		// Token: 0x0402DDE3 RID: 187875
		BtnDelete,
		// Token: 0x0402DDE4 RID: 187876
		TexEchoIcon,
		// Token: 0x0402DDE5 RID: 187877
		TxtPlanName,
		// Token: 0x0402DDE6 RID: 187878
		TexTitleBg,
		// Token: 0x0402DDE7 RID: 187879
		PanelActivation,
		// Token: 0x0402DDE8 RID: 187880
		ScrollSetting,
		// Token: 0x0402DDE9 RID: 187881
		CostGroupItem,
		// Token: 0x0402DDEA RID: 187882
		PanelBtnOverview,
		// Token: 0x0402DDEB RID: 187883
		BtnEdit,
		// Token: 0x0402DDEC RID: 187884
		BtnActivate,
		// Token: 0x0402DDED RID: 187885
		PanelActivationStatic
	}
}
