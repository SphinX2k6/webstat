using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.AutoAttach;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using CSharpScript.Module.InstanceDungeon;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200132F RID: 4911
[NullableContext(1)]
[Nullable(0)]
public class FightPhotoMainView : UiTickViewBase
{
	// Token: 0x060085EE RID: 34286 RVA: 0x0023458C File Offset: 0x0023278C
	public FightPhotoMainView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x060085EF RID: 34287 RVA: 0x002345A8 File Offset: 0x002327A8
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUITexture)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(9, typeof(UUIText)),
			new ValueTuple<int, Type>(10, typeof(UUIItem)),
			new ValueTuple<int, Type>(11, typeof(UUIItem)),
			new ValueTuple<int, Type>(12, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(13, typeof(UUIItem)),
			new ValueTuple<int, Type>(14, typeof(UUIText)),
			new ValueTuple<int, Type>(15, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(16, typeof(UUIItem)),
			new ValueTuple<int, Type>(17, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(18, typeof(UUIItem)),
			new ValueTuple<int, Type>(19, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(20, typeof(UUIItem)),
			new ValueTuple<int, Type>(21, typeof(UUIText)),
			new ValueTuple<int, Type>(22, typeof(UUIArtText)),
			new ValueTuple<int, Type>(23, typeof(UUIArtText)),
			new ValueTuple<int, Type>(24, typeof(UUIArtText)),
			new ValueTuple<int, Type>(25, typeof(UUIArtText)),
			new ValueTuple<int, Type>(26, typeof(UUIItem)),
			new ValueTuple<int, Type>(27, typeof(UUIText)),
			new ValueTuple<int, Type>(28, typeof(UUITexture))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(19, new Action(this.OnGotoBtnClick)),
			new ValueTuple<int, Delegate>(8, new Action(this.OnRewardBtnClick))
		};
	}

	// Token: 0x060085F0 RID: 34288 RVA: 0x00234890 File Offset: 0x00232A90
	protected override UniTask OnBeforeStartAsync()
	{
		FightPhotoMainView.<OnBeforeStartAsync>d__17 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<FightPhotoMainView.<OnBeforeStartAsync>d__17>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060085F1 RID: 34289 RVA: 0x002348D4 File Offset: 0x00232AD4
	protected override void OnStart()
	{
		UUIItem item = base.GetItem(5);
		UUIItem item2 = base.GetItem(6);
		this.NoCircleAttachView = new NoCircleAttachView<FightPhotoLevelGroupData, FightPhotoLevelGroupItem>(item.GetOwner(), false);
		this.NoCircleAttachView.SetIfNeedFakeItem(true);
		this.NoCircleAttachView.CreateItems(base.GetItem(7).GetOwner(), 0f, new Func<AActor, int, int, FightPhotoLevelGroupItem>(this.CreateNoCircleAttachItem), EAttachDirection.Vertical);
		NoCircleAttachView<FightPhotoLevelGroupData, FightPhotoLevelGroupItem> noCircleAttachView = this.NoCircleAttachView;
		if (noCircleAttachView != null)
		{
			noCircleAttachView.SetControllerItem(item2);
		}
		base.GetItem(7).SetUIActive(false);
		this.LevelLayout = new GenericLayout<FightPhotoLevelItem, FightPhotoLevelData>(base.GetHorizontalLayout(12), new Func<FightPhotoLevelItem>(this.CreateLevelItem), null, false, true);
		this.TaskTargetLayout = new GenericLayout<FightPhotoTaskTargetItem, string>(base.GetVerticalLayout(15), new Func<FightPhotoTaskTargetItem>(this.CreateTaskTargetItem), null, false, true);
		this.RoleLayout = new GenericLayout<FightPhotoRoleItem, int>(base.GetHorizontalLayout(17), new Func<FightPhotoRoleItem>(this.CreateRoleItem), null, false, true);
		List<FightPhotoLevelGroupData> levelGroupDataList = this.ActivityData.GetLevelGroupDataList();
		int selectLevelGroupDataIndex = this.ActivityData.GetSelectLevelGroupDataIndex();
		this.NoCircleAttachView.ReloadView(levelGroupDataList.Count, levelGroupDataList.ToArray(), selectLevelGroupDataIndex);
	}

	// Token: 0x060085F2 RID: 34290 RVA: 0x002349ED File Offset: 0x00232BED
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnRefreshFightPhotoLevelRedDot, new Action(this.OnRefreshFightPhotoLevelRedDot));
	}

	// Token: 0x060085F3 RID: 34291 RVA: 0x00234A0C File Offset: 0x00232C0C
	protected override void OnBeforeShow()
	{
		ControllerBase<SplashScreenController>.Instance.FinishCurTask(ESplashScreenSourceModuleType.None);
		this.ActivityData.IsNeedShowFightPhotoMainView = false;
		int finishedTaskNum = this.ActivityData.GetFinishedTaskNum();
		int totalTaskNum = this.ActivityData.GetTotalTaskNum();
		UUIText text = base.GetText(21);
		if (text != null)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(finishedTaskNum);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(totalTaskNum);
			text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		}
		int num = finishedTaskNum / 10;
		UUIArtText artText = base.GetArtText(22);
		if (artText != null)
		{
			artText.SetText(num.ToString());
		}
		int num2 = finishedTaskNum % 10;
		UUIArtText artText2 = base.GetArtText(23);
		if (artText2 != null)
		{
			artText2.SetText(num2.ToString());
		}
		int num3 = totalTaskNum / 10;
		UUIArtText artText3 = base.GetArtText(24);
		if (artText3 != null)
		{
			artText3.SetText(num3.ToString());
		}
		int num4 = totalTaskNum % 10;
		UUIArtText artText4 = base.GetArtText(25);
		if (artText4 != null)
		{
			artText4.SetText(num4.ToString());
		}
		UUIItem item = base.GetItem(20);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(this.ActivityData.IsTaskHasRedDot());
	}

	// Token: 0x060085F4 RID: 34292 RVA: 0x00234B23 File Offset: 0x00232D23
	protected override void OnAfterShow()
	{
		if (this.ActivityData.IsNeedShowTip)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("FightPhotoUnlockNewLevel", Array.Empty<object>());
			this.ActivityData.IsNeedShowTip = false;
		}
	}

	// Token: 0x060085F5 RID: 34293 RVA: 0x00234B54 File Offset: 0x00232D54
	protected override void OnTick(float delta)
	{
		if (this.CurrentLevelGroupData == null)
		{
			return;
		}
		if (this.CurrentLevelGroupData.IsUnLock)
		{
			if (!this.IsCurrentLevelGroupUnlock)
			{
				this.RefreshView(this.CurrentLevelGroupData);
			}
			return;
		}
		string text = ConfigMultiTextLang.GetLocalTextNew("FightPhotoUnlockTime", null) ?? "{0}后解锁";
		string newText = ModelBase<ActivityModel>.Instance.GetRemainTimeText(this.CurrentLevelGroupData.UnlockTime, text) ?? "";
		UUIText text2 = base.GetText(27);
		if (text2 == null)
		{
			return;
		}
		text2.SetText(newText, true);
	}

	// Token: 0x060085F6 RID: 34294 RVA: 0x00234BD8 File Offset: 0x00232DD8
	private void RefreshView(FightPhotoLevelGroupData data)
	{
		UUIItem item = base.GetItem(10);
		if (item != null)
		{
			item.SetUIActive(!data.IsUnLock);
		}
		UUIItem item2 = base.GetItem(11);
		if (item2 != null)
		{
			item2.SetUIActive(data.IsUnLock);
		}
		UUIText text = base.GetText(9);
		if (text != null)
		{
			text.SetUIActive(data.IsUnLock);
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), data.TargetRoleName, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(14), data.TargetRoleName, Array.Empty<object>());
		if (this.CurrentLevelGroupData != null)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), this.CurrentLevelGroupData.TargetRoleName, Array.Empty<object>());
		}
		this.CurrentLevelGroupData = data;
		this.IsCurrentLevelGroupUnlock = data.IsUnLock;
		this.LevelLayout.DeselectCurrentGridProxy();
		this.LevelLayout.RefreshByData(data.LevelDataList, delegate
		{
			int currentLevelId = this.ActivityData.GetCurrentLevelId();
			FightPhotoLevelData fightPhotoLevelData = data.FirstUnFinishedLevelData;
			if (currentLevelId != 0)
			{
				this.ActivityData.SetCurrentLevelId(0);
				fightPhotoLevelData = this.ActivityData.GetLevelData(currentLevelId);
			}
			this.LevelLayout.SelectGridProxyByKey(fightPhotoLevelData, false);
			ModelBase<InstanceDungeonEntranceModel>.Instance.SelectInstanceId = fightPhotoLevelData.InstanceId;
			this.RefreshRightPanel(fightPhotoLevelData);
		}, false);
	}

	// Token: 0x060085F7 RID: 34295 RVA: 0x00234D10 File Offset: 0x00232F10
	private void RefreshRightPanel(FightPhotoLevelData levelData)
	{
		if (this.CurrentLevelData != null)
		{
			base.SetTextureByPath(this.CurrentLevelData.RoleBigTexture, base.GetTexture(28), null, null);
			base.SetTextureByPath(this.CurrentLevelData.RoleBigTexture, base.GetTexture(3), null, null);
		}
		this.CurrentLevelData = levelData;
		base.SetTextureByPath(levelData.RoleBigTexture, base.GetTexture(1), null, null);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(9), levelData.Name, Array.Empty<object>());
		this.TaskTargetLayout.RefreshByData(levelData.TaskTargetText, delegate
		{
			foreach (FightPhotoTaskTargetItem fightPhotoTaskTargetItem in this.TaskTargetLayout.GetLayoutItemList())
			{
				fightPhotoTaskTargetItem.SetIsFinished(this.CurrentLevelData.IsFinished);
			}
		}, false);
		this.CurrentRoleList = levelData.GetRoleIdListIncludeZero();
		this.RoleLayout.RefreshByData(this.CurrentRoleList, null, false);
		UUIButtonComponent button = base.GetButton(19);
		if (button != null)
		{
			UUIItem uuiitem = button.RootUIComp.Get();
			if (uuiitem != null)
			{
				uuiitem.SetUIActive(levelData.IsUnLock);
			}
		}
		FunctionalPanelConditionLock panelLock = this.PanelLock;
		if (panelLock != null)
		{
			panelLock.SetUiActive(levelData.LevelGroupData.IsUnLock && !levelData.IsUnLock);
		}
		if (!levelData.IsUnLock)
		{
			string localTextNew = ConfigMultiTextLang.GetLocalTextNew(levelData.PreLevelName, null);
			FunctionalPanelConditionLock panelLock2 = this.PanelLock;
			if (panelLock2 == null)
			{
				return;
			}
			panelLock2.SetTextByTextId("PrefabTextItem_28127837_Text", new string[]
			{
				localTextNew
			});
		}
	}

	// Token: 0x060085F8 RID: 34296 RVA: 0x00234E72 File Offset: 0x00233072
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRefreshFightPhotoLevelRedDot, new Action(this.OnRefreshFightPhotoLevelRedDot));
	}

	// Token: 0x060085F9 RID: 34297 RVA: 0x00234E90 File Offset: 0x00233090
	protected override void OnBeforeDestroy()
	{
		ModelBase<InstanceDungeonEntranceModel>.Instance.SelectInstanceId = 0;
	}

	// Token: 0x060085FA RID: 34298 RVA: 0x00234EA0 File Offset: 0x002330A0
	private FightPhotoLevelGroupItem CreateNoCircleAttachItem(AActor actor, int index, int showNum)
	{
		FightPhotoLevelGroupItem fightPhotoLevelGroupItem = new FightPhotoLevelGroupItem(actor);
		fightPhotoLevelGroupItem.CreateByActorAsync(actor, null, false).Forget();
		fightPhotoLevelGroupItem.OnToggleClickCallback = new Action<int, FightPhotoLevelGroupData>(this.OnItemClick);
		fightPhotoLevelGroupItem.OnSelectCallback = new Action<int, FightPhotoLevelGroupData>(this.OnItemSelectCallback);
		fightPhotoLevelGroupItem.CheckToggleCanClick = new Func<bool>(this.CheckToggleCanClick);
		return fightPhotoLevelGroupItem;
	}

	// Token: 0x060085FB RID: 34299 RVA: 0x00234EF7 File Offset: 0x002330F7
	private void OnItemClick(int index, FightPhotoLevelGroupData data)
	{
		if (this.NoCircleAttachView.IsVelocityMoveState())
		{
			return;
		}
		if (data == null)
		{
			return;
		}
		this.NoCircleAttachView.AttachToIndex(index, false);
	}

	// Token: 0x060085FC RID: 34300 RVA: 0x00234F18 File Offset: 0x00233118
	private void OnItemSelectCallback(int index, FightPhotoLevelGroupData data)
	{
		if (this.SelectedIndex != -1 && this.SelectedIndex != index)
		{
			string sequenceName = (this.SelectedIndex > index) ? "PageUp" : "PageDown";
			base.PlaySequence(sequenceName, null, false);
		}
		if (this.SelectedIndex == -1 || this.SelectedIndex != index)
		{
			this.RefreshView(data);
		}
		this.SelectedIndex = index;
		this.NoCircleAttachView.GetCurrentSelectItem().GetRootItem().SetHierarchyIndex(this.NoCircleAttachView.GetDataLength() + 1);
	}

	// Token: 0x060085FD RID: 34301 RVA: 0x00234F98 File Offset: 0x00233198
	private bool CheckToggleCanClick()
	{
		return !this.IsQuickRoleSelectViewOpen && !this.NoCircleAttachView.MovingState();
	}

	// Token: 0x060085FE RID: 34302 RVA: 0x00234FB2 File Offset: 0x002331B2
	private FightPhotoLevelItem CreateLevelItem()
	{
		return new FightPhotoLevelItem
		{
			OnToggleCallBack = new Action<FightPhotoLevelData>(this.OnLevelItemClick),
			CheckToggleCanClick = new Func<bool>(this.CheckLevelToggleCanClick)
		};
	}

	// Token: 0x060085FF RID: 34303 RVA: 0x00234FDD File Offset: 0x002331DD
	private bool CheckLevelToggleCanClick()
	{
		return !this.IsQuickRoleSelectViewOpen;
	}

	// Token: 0x06008600 RID: 34304 RVA: 0x00234FE8 File Offset: 0x002331E8
	private void OnLevelItemClick(FightPhotoLevelData data)
	{
		base.PlaySequence("InfoSwitch", null, false);
		ModelBase<InstanceDungeonEntranceModel>.Instance.SelectInstanceId = data.InstanceId;
		this.LevelLayout.SelectGridProxyByKey(data, false);
		this.RefreshRightPanel(data);
	}

	// Token: 0x06008601 RID: 34305 RVA: 0x0023501B File Offset: 0x0023321B
	private FightPhotoTaskTargetItem CreateTaskTargetItem()
	{
		return new FightPhotoTaskTargetItem();
	}

	// Token: 0x06008602 RID: 34306 RVA: 0x00235022 File Offset: 0x00233222
	private FightPhotoRoleItem CreateRoleItem()
	{
		return new FightPhotoRoleItem
		{
			OnBtnClickCallback = new Action<int>(this.OnRoleBtnClick)
		};
	}

	// Token: 0x06008603 RID: 34307 RVA: 0x0023503C File Offset: 0x0023323C
	private unsafe void OnRoleBtnClick(int index)
	{
		if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.QuickRoleSelectView))
		{
			return;
		}
		if (!this.NoCircleAttachView.MovingState() && !this.NoCircleAttachView.IsVelocityMoveState())
		{
			GenericLayout<FightPhotoLevelItem, FightPhotoLevelData> levelLayout = this.LevelLayout;
			if (levelLayout == null || !levelLayout.IsLock)
			{
				List<RoleDataBase> list = new List<RoleDataBase>();
				Span<int> trialRoleList = this.CurrentLevelData.TrialRoleList;
				for (int i = 0; i < trialRoleList.Length; i++)
				{
					int id = *trialRoleList[i];
					RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(id, true);
					list.Add(roleDataById);
				}
				foreach (RoleInstance roleInstance in ModelBase<RoleModel>.Instance.GetRoleList())
				{
					if (roleInstance.GetRoleId() != 0)
					{
						list.Add(roleInstance);
					}
				}
				QuickRoleSelectViewData quickRoleSelectViewData = new QuickRoleSelectViewData(EFilterSortGroupId.FightPhoto, this.CurrentRoleList.ToArray(), list);
				quickRoleSelectViewData.OnConfirm = new Action<int[]>(this.OnQuickSelectConfirm);
				quickRoleSelectViewData.CanConfirm = new Func<int[], bool>(this.CanConfirm);
				quickRoleSelectViewData.IsNeedChangeBtnState = true;
				quickRoleSelectViewData.YellowTipText = this.GetRoleSelectedViewTip();
				quickRoleSelectViewData.OnHideFinish = delegate()
				{
					this.SetLevelSwitchLock(false);
				};
				this.SetLevelSwitchLock(true);
				Singleton<UiManager>.Instance.OpenView(EUiViewName.QuickRoleSelectView, quickRoleSelectViewData, delegate(bool success, int viewId)
				{
					if (!success)
					{
						this.SetLevelSwitchLock(false);
					}
				});
				return;
			}
		}
	}

	// Token: 0x06008604 RID: 34308 RVA: 0x00235182 File Offset: 0x00233382
	private void SetLevelSwitchLock(bool locked)
	{
		this.IsQuickRoleSelectViewOpen = locked;
		if (locked)
		{
			NoCircleAttachView<FightPhotoLevelGroupData, FightPhotoLevelGroupItem> noCircleAttachView = this.NoCircleAttachView;
			if (noCircleAttachView == null)
			{
				return;
			}
			noCircleAttachView.DisableDragEvent();
			return;
		}
		else
		{
			NoCircleAttachView<FightPhotoLevelGroupData, FightPhotoLevelGroupItem> noCircleAttachView2 = this.NoCircleAttachView;
			if (noCircleAttachView2 == null)
			{
				return;
			}
			noCircleAttachView2.EnableDragEvent();
			return;
		}
	}

	// Token: 0x06008605 RID: 34309 RVA: 0x002351B0 File Offset: 0x002333B0
	private void OnQuickSelectConfirm(int[] roleIdList)
	{
		List<int> list = new List<int>(roleIdList);
		while (list.Count < 3)
		{
			list.Add(0);
		}
		this.CurrentRoleList = list;
		this.RoleLayout.RefreshByData(this.CurrentRoleList, null, false);
	}

	// Token: 0x06008606 RID: 34310 RVA: 0x002351F0 File Offset: 0x002333F0
	private bool CanConfirm(int[] roleIdList)
	{
		if (roleIdList.Length == 0)
		{
			return false;
		}
		List<int> list = new List<int>();
		foreach (int num in roleIdList)
		{
			if (num > 100000)
			{
				list.Add(ConfigBase<RoleConfig>.Instance.GetTrialRoleConfig(num).Value.ParentId);
			}
			else
			{
				list.Add(num);
			}
		}
		HashSet<int> hashSet = new HashSet<int>(list);
		if (hashSet.Count != list.Count)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("SameRole", Array.Empty<object>());
			return false;
		}
		if (this.CurrentLevelData.IsFinished)
		{
			return true;
		}
		foreach (int item in this.CurrentLevelData.LevelGroupData.TargetRoleIds)
		{
			if (!hashSet.Contains(item))
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x06008607 RID: 34311 RVA: 0x002352F0 File Offset: 0x002334F0
	private string GetRoleSelectedViewTip()
	{
		if (this.CurrentLevelData.IsFinished)
		{
			return ConfigMultiTextLang.GetLocalTextNew("FightPhotoCanSelectAnyRole", null) ?? "";
		}
		string targetRoleName = this.CurrentLevelData.LevelGroupData.TargetRoleName;
		return StringUtils.Format(ConfigMultiTextLang.GetLocalTextNew("FightPhotoSelectTip", null) ?? "需要选择共鸣者{0}", new string[]
		{
			ConfigMultiTextLang.GetLocalTextNew(targetRoleName, null) ?? ""
		});
	}

	// Token: 0x06008608 RID: 34312 RVA: 0x00235364 File Offset: 0x00233564
	private void OnGotoBtnClick()
	{
		if (ModelBase<GameModeModel>.Instance.IsMulti)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("ErrorCode_600064_Text", Array.Empty<object>());
			return;
		}
		ModelBase<LoadingModel>.Instance.SetSpecifiedLoadingConfigId(new int?(this.CurrentLevelData.LoadingId));
		ControllerBase<FightPhotoController>.Instance.EnterFightPhotoDungeonDirectly(this.ActivityData.Id, this.CurrentLevelData.LevelId, this.CurrentLevelData.InstanceId, this.CurrentRoleList.ToArray()).Forget();
	}

	// Token: 0x06008609 RID: 34313 RVA: 0x002353E7 File Offset: 0x002335E7
	private void OnRefreshFightPhotoLevelRedDot()
	{
		this.NoCircleAttachView.GetCurrentSelectItem().RefreshRedDot();
	}

	// Token: 0x0600860A RID: 34314 RVA: 0x002353F9 File Offset: 0x002335F9
	private void OnRewardBtnClick()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.FightPhotoRewardView, this.ActivityData, null);
	}

	// Token: 0x0600860B RID: 34315 RVA: 0x00235411 File Offset: 0x00233611
	private void OnCloseBtnClick()
	{
		base.CloseMe(null);
	}

	// Token: 0x0600860C RID: 34316 RVA: 0x0023541C File Offset: 0x0023361C
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
	{
		if (!(configParams[0] == "Difficult"))
		{
			return null;
		}
		GenericLayout<FightPhotoLevelItem, FightPhotoLevelData> levelLayout = this.LevelLayout;
		UUIItem uuiitem = (levelLayout != null) ? levelLayout.GetItemByIndex(1) : null;
		if (uuiitem == null)
		{
			return null;
		}
		return new UUIItem[]
		{
			uuiitem,
			uuiitem
		};
	}

	// Token: 0x04003F5F RID: 16223
	private const int TEAM_MAX_NUMBER = 3;

	// Token: 0x04003F60 RID: 16224
	[Nullable(2)]
	private FightPhotoActivityData ActivityData;

	// Token: 0x04003F61 RID: 16225
	[Nullable(2)]
	private FightPhotoLevelGroupData CurrentLevelGroupData;

	// Token: 0x04003F62 RID: 16226
	[Nullable(2)]
	private FightPhotoLevelData CurrentLevelData;

	// Token: 0x04003F63 RID: 16227
	private List<int> CurrentRoleList = new List<int>();

	// Token: 0x04003F64 RID: 16228
	private bool IsCurrentLevelGroupUnlock;

	// Token: 0x04003F65 RID: 16229
	private bool IsQuickRoleSelectViewOpen;

	// Token: 0x04003F66 RID: 16230
	private int SelectedIndex = -1;

	// Token: 0x04003F67 RID: 16231
	[Nullable(2)]
	private PopupCaptionItem CaptionItem;

	// Token: 0x04003F68 RID: 16232
	[Nullable(2)]
	private FunctionalPanelConditionLock PanelLock;

	// Token: 0x04003F69 RID: 16233
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private NoCircleAttachView<FightPhotoLevelGroupData, FightPhotoLevelGroupItem> NoCircleAttachView;

	// Token: 0x04003F6A RID: 16234
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<FightPhotoLevelItem, FightPhotoLevelData> LevelLayout;

	// Token: 0x04003F6B RID: 16235
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<FightPhotoTaskTargetItem, string> TaskTargetLayout;

	// Token: 0x04003F6C RID: 16236
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<FightPhotoRoleItem, int> RoleLayout;

	// Token: 0x020076D0 RID: 30416
	[NullableContext(0)]
	private enum EComponents
	{
		// Token: 0x04028EB7 RID: 167607
		ItemCaption,
		// Token: 0x04028EB8 RID: 167608
		TextureRole,
		// Token: 0x04028EB9 RID: 167609
		TextName,
		// Token: 0x04028EBA RID: 167610
		TextureLastRoleAni,
		// Token: 0x04028EBB RID: 167611
		TextLastNameAni,
		// Token: 0x04028EBC RID: 167612
		ItemDrag,
		// Token: 0x04028EBD RID: 167613
		ItemLevelGroupContent,
		// Token: 0x04028EBE RID: 167614
		ItemLevelGroup,
		// Token: 0x04028EBF RID: 167615
		BtnReward,
		// Token: 0x04028EC0 RID: 167616
		TextLevelGName,
		// Token: 0x04028EC1 RID: 167617
		ItemLockPanel,
		// Token: 0x04028EC2 RID: 167618
		ItemUnlockPanel,
		// Token: 0x04028EC3 RID: 167619
		LayoutLevel,
		// Token: 0x04028EC4 RID: 167620
		ItemContent,
		// Token: 0x04028EC5 RID: 167621
		TextTargetRole,
		// Token: 0x04028EC6 RID: 167622
		LayoutTaskTarget,
		// Token: 0x04028EC7 RID: 167623
		ItemTaskTarget,
		// Token: 0x04028EC8 RID: 167624
		LayoutRole,
		// Token: 0x04028EC9 RID: 167625
		ItemRole,
		// Token: 0x04028ECA RID: 167626
		BtnGoto,
		// Token: 0x04028ECB RID: 167627
		ItemRedPoint,
		// Token: 0x04028ECC RID: 167628
		TextReward,
		// Token: 0x04028ECD RID: 167629
		ArtTextReward1,
		// Token: 0x04028ECE RID: 167630
		ArtTextReward2,
		// Token: 0x04028ECF RID: 167631
		ArtTextReward3,
		// Token: 0x04028ED0 RID: 167632
		ArtTextReward4,
		// Token: 0x04028ED1 RID: 167633
		ItemLockTip,
		// Token: 0x04028ED2 RID: 167634
		TextLock,
		// Token: 0x04028ED3 RID: 167635
		TextureLastRole
	}
}
