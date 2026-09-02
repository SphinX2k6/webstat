using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Effect;
using CSharpScript.Game.Module.BlackScreen;
using CSharpScript.Game.Module.Skin;
using CSharpScript.Game.Ui;
using CSharpScript.Game.Utils;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002A42 RID: 10818
[NullableContext(1)]
[Nullable(0)]
public class SkinRootView : UiViewBase
{
	// Token: 0x06015A8F RID: 88719 RVA: 0x00603658 File Offset: 0x00601858
	public SkinRootView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06015A90 RID: 88720 RVA: 0x00603664 File Offset: 0x00601864
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIDraggableComponent)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem))
		};
	}

	// Token: 0x06015A91 RID: 88721 RVA: 0x006036EC File Offset: 0x006018EC
	protected override void OnStart()
	{
		this.ViewData = (this.OpenParam as ISkinViewData);
		this.ViewModel = new SkinRootViewModel();
		this.ViewModel.Init(this.ViewData);
		this.ViewModel.SetGetDragItemFunc(new Func<UUIDraggableComponent>(this.GetDragItem));
		this.ViewModel.Bind(new Action<ESkinRootViewData>(this.OnViewModelUpdate));
		this.FadeAnimController = new SkinFadeAnimController();
		CommonTabComponentData<SkinTabItem> data = new CommonTabComponentData<SkinTabItem>(new Func<UUIItem, int?, SkinTabItem>(this.ProxyCreate), new Action<int>(this.ToggleCallBack), new Func<int, CommonTabData>(this.GetCommonData));
		this.TabComponent = new TabComponentWithCaptionItem<SkinTabItem>(base.GetItem(0), data, new Action(this.CloseView), false);
		this.TabComponent.SetHelpButtonCallBack(new Action(this.OnClickHelpBtn));
		this.TabComponent.SetCanChange(new Func<int, bool?, bool>(this.CanToggleChange));
		this.TabViewComponent = new TabViewComponent<UiDynamicTab>(base.GetItem(1), EKeyMode.Default);
		Singleton<AudioSystem>.Instance.SetState("mute_nature_voice", ERoleMuteAudioState.Mute, true);
	}

	// Token: 0x06015A92 RID: 88722 RVA: 0x00603804 File Offset: 0x00601A04
	private void CloseView()
	{
		bool needLoadRole = this.ViewModel.NeedLoadRole;
		if (needLoadRole)
		{
			ControllerBase<BlackScreenController>.Instance.AddBlackScreenAsync("Start", "CloseRoleSkinView", "Black");
		}
		base.CloseMe(delegate(bool _)
		{
			if (needLoadRole)
			{
				ControllerBase<BlackScreenController>.Instance.RemoveBlackScreen("Close", "CloseRoleSkinView");
			}
		});
	}

	// Token: 0x06015A93 RID: 88723 RVA: 0x0060385C File Offset: 0x00601A5C
	private void OnViewModelUpdate(ESkinRootViewData data)
	{
		switch (data)
		{
		case ESkinRootViewData.RootUiVisible:
			if (this.ViewModel.GetRootUiVisible())
			{
				this.ShowView();
				return;
			}
			this.HideView();
			return;
		case ESkinRootViewData.MoveGamepadKeyTipActive:
			if (this.ViewModel.GetMoveGamepadKeyTipActive())
			{
				this.SetMoveGamepadKeyTipActive(true);
				return;
			}
			this.SetMoveGamepadKeyTipActive(false);
			return;
		case ESkinRootViewData.GamePadKeyTipRefresh:
			this.RefreshGamePadKeyTip();
			return;
		case ESkinRootViewData.ModelState:
		{
			SkinFadeAnimController fadeAnimController = this.FadeAnimController;
			if (fadeAnimController != null)
			{
				fadeAnimController.ChangeModelState(this.ViewModel.GetModelState());
			}
			EModelStateInSkinView? modelState = this.ViewModel.GetModelState();
			EModelStateInSkinView emodelStateInSkinView = EModelStateInSkinView.ShowRole;
			if ((modelState.GetValueOrDefault() == emodelStateInSkinView & modelState != null) || this.ViewModel.GetModelState().GetValueOrDefault() == EModelStateInSkinView.ShowWeapon)
			{
				this.ViewModel.TryShowRoleSystemRoleActor();
				return;
			}
			break;
		}
		case ESkinRootViewData.SelectTabViewName:
			this.SelectTabView(this.ViewModel.GetSelectTabViewName().Value);
			break;
		default:
			return;
		}
	}

	// Token: 0x06015A94 RID: 88724 RVA: 0x00603940 File Offset: 0x00601B40
	protected override void OnHandleLoadScene()
	{
		Singleton<UiSceneManager>.Instance.ShowRoleSystemRoleActor();
		if (!this.ViewModel.NeedLoadRole && !this.NeedReloadRole)
		{
			return;
		}
		AActor actorByTag = Singleton<UiSceneManager>.Instance.GetActorByTag("RoleFloorCase");
		if (actorByTag != null)
		{
			this.FloorEffect = EffectUtil.SpawnUiEffect("RoleSystemFloorEffect", "[RoleRootView.LoadFloorEffect]", new FTransformDouble?(actorByTag.D_GetTransform()), new EffectContext(null, actorByTag, false)).Value;
		}
	}

	// Token: 0x06015A95 RID: 88725 RVA: 0x006039B8 File Offset: 0x00601BB8
	protected override UniTask OnHandlePostLoadSceneAsync(bool isSceneLoad)
	{
		SkinRootView.<OnHandlePostLoadSceneAsync>d__16 <OnHandlePostLoadSceneAsync>d__;
		<OnHandlePostLoadSceneAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnHandlePostLoadSceneAsync>d__.<>4__this = this;
		<OnHandlePostLoadSceneAsync>d__.<>1__state = -1;
		<OnHandlePostLoadSceneAsync>d__.<>t__builder.Start<SkinRootView.<OnHandlePostLoadSceneAsync>d__16>(ref <OnHandlePostLoadSceneAsync>d__);
		return <OnHandlePostLoadSceneAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06015A96 RID: 88726 RVA: 0x006039FC File Offset: 0x00601BFC
	private UniTask TryLoadRoleActor()
	{
		SkinRootView.<TryLoadRoleActor>d__17 <TryLoadRoleActor>d__;
		<TryLoadRoleActor>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<TryLoadRoleActor>d__.<>4__this = this;
		<TryLoadRoleActor>d__.<>1__state = -1;
		<TryLoadRoleActor>d__.<>t__builder.Start<SkinRootView.<TryLoadRoleActor>d__17>(ref <TryLoadRoleActor>d__);
		return <TryLoadRoleActor>d__.<>t__builder.Task;
	}

	// Token: 0x06015A97 RID: 88727 RVA: 0x00603A40 File Offset: 0x00601C40
	protected override void OnHandleReleaseScene()
	{
		Singleton<UiSceneManager>.Instance.HideRoleSystemRoleActor();
		if (Singleton<EffectSystem>.Instance.IsValid(this.FloorEffect))
		{
			Singleton<EffectSystem>.Instance.StopEffectById(this.FloorEffect, "[RoleRootView.HandleReleaseScene]", false, null);
		}
		this.NeedReloadRole = true;
		this.ReleaseRoleActor();
	}

	// Token: 0x06015A98 RID: 88728 RVA: 0x00603A96 File Offset: 0x00601C96
	protected override void OnBeforeShow()
	{
		this.UpdateDynamicTabComponent();
		this.RefreshGamePadKeyTip();
	}

	// Token: 0x06015A99 RID: 88729 RVA: 0x00603AA4 File Offset: 0x00601CA4
	protected void UpdateDynamicTabComponent()
	{
		this.TabDataList = ModelBase<RoleSkinModel>.Instance.GetSkinTabList(this.ViewModel.IsMainRole, this.ViewModel.RoleId).ToArray();
		int num = this.TabDataList.Length;
		List<CommonTabItemData> list = this.TabComponent.CreateTabItemDataByLength(num);
		for (int i = 0; i < num; i++)
		{
			EUiTabViewName tabViewName = (EUiTabViewName)this.TabDataList[i].ChildViewName;
			ERedDotName? tabRedDotName = this.ViewModel.GetTabRedDotName(tabViewName);
			int? tabRedDotUid = this.ViewModel.GetTabRedDotUid(tabViewName);
			list[i].RedDotName = tabRedDotName;
			list[i].RedDotUid = tabRedDotUid;
		}
		this.TabComponent.RefreshTabItem(list, delegate
		{
			this.SelectTabView(this.ViewModel.GetCurSelectTabViewName());
		});
	}

	// Token: 0x06015A9A RID: 88730 RVA: 0x00603B68 File Offset: 0x00601D68
	private void SelectTabView(EUiTabViewName tabName)
	{
		int index = 0;
		for (int i = 0; i < this.TabDataList.Length; i++)
		{
			if ((EUiTabViewName)this.TabDataList[i].ChildViewName == tabName)
			{
				index = i;
				break;
			}
		}
		this.TabComponent.SelectToggleByIndex(index, true);
	}

	// Token: 0x06015A9B RID: 88731 RVA: 0x00603BB9 File Offset: 0x00601DB9
	protected override void OnBeforeHide()
	{
		this.TabViewComponent.HideCurrentTabView();
		if (this.LastHide)
		{
			Singleton<EventSystem>.Instance.Emit(EEventName.OnSkinRootViewDestroy);
			this.ViewModel.SetModelState(EModelStateInSkinView.ShowRole, false);
		}
	}

	// Token: 0x06015A9C RID: 88732 RVA: 0x00603BEC File Offset: 0x00601DEC
	protected override void OnBeforeDestroy()
	{
		this.ViewModel.UnBind(new Action<ESkinRootViewData>(this.OnViewModelUpdate));
		Singleton<AudioSystem>.Instance.SetState("mute_nature_voice", ERoleMuteAudioState.None, true);
		if (this.ViewModel.NeedLoadRole)
		{
			this.ReleaseRoleActor();
		}
	}

	// Token: 0x06015A9D RID: 88733 RVA: 0x00603C3D File Offset: 0x00601E3D
	private void ReleaseRoleActor()
	{
		if (this.ViewModel.TsUiSceneRoleActor == null)
		{
			return;
		}
		Singleton<UiSceneManager>.Instance.DestroyRoleSystemRoleActor(this.ViewModel.TsUiSceneRoleActor);
		this.ViewModel.TsUiSceneRoleActor = null;
		this.FadeAnimController.TsUiSceneRoleActor = null;
	}

	// Token: 0x06015A9E RID: 88734 RVA: 0x00603C7B File Offset: 0x00601E7B
	public void HideView()
	{
		this.TabComponent.SetUiActive(false);
	}

	// Token: 0x06015A9F RID: 88735 RVA: 0x00603C89 File Offset: 0x00601E89
	public void ShowView()
	{
		this.TabComponent.SetUiActive(true);
	}

	// Token: 0x06015AA0 RID: 88736 RVA: 0x00603C98 File Offset: 0x00601E98
	public void RefreshGamePadKeyTip()
	{
		UUIItem item = base.GetItem(3);
		if (item != null)
		{
			item.SetUIActive(false);
		}
		UUIItem item2 = base.GetItem(4);
		if (item2 != null)
		{
			item2.SetUIActive(false);
		}
		EUiTabViewName curSelectTabViewName = this.ViewModel.GetCurSelectTabViewName();
		if (!(curSelectTabViewName == EUiTabViewName.RoleSkinTabView) && !(curSelectTabViewName == EUiTabViewName.RoleOrnamentTabView))
		{
			if (curSelectTabViewName == EUiTabViewName.FlySkinTabView)
			{
				bool uiactive = !this.TabComponent.IsUiActiveInHierarchy();
				UUIItem item3 = base.GetItem(4);
				if (item3 == null)
				{
					return;
				}
				item3.SetUIActive(uiactive);
			}
			return;
		}
		UUIItem item4 = base.GetItem(3);
		if (item4 == null)
		{
			return;
		}
		item4.SetUIActive(true);
	}

	// Token: 0x06015AA1 RID: 88737 RVA: 0x00603D32 File Offset: 0x00601F32
	public void SetMoveGamepadKeyTipActive(bool isActive)
	{
		UUIItem item = base.GetItem(4);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(isActive);
	}

	// Token: 0x06015AA2 RID: 88738 RVA: 0x00603D46 File Offset: 0x00601F46
	private SkinTabItem ProxyCreate([Nullable(2)] UUIItem uiItem, int? index)
	{
		return new SkinTabItem();
	}

	// Token: 0x06015AA3 RID: 88739 RVA: 0x00603D50 File Offset: 0x00601F50
	private void ToggleCallBack(int index)
	{
		this.LastClickTime = Singleton<TimeUtil>.Instance.GetServerTimeStamp();
		UiDynamicTab data = this.TabDataList[index];
		EUiTabViewName euiTabViewName = (EUiTabViewName)data.ChildViewName;
		SkinTabItem tabItemByIndex = this.TabComponent.GetTabItemByIndex(index);
		this.ViewModel.SetCurSelectTabViewName(euiTabViewName, false);
		this.TabViewComponent.ToggleCallBack(data, euiTabViewName, tabItemByIndex, this.ViewModel, null);
		this.TabComponent.SetHelpButtonShowState(this.ViewModel.IsShowHelpBtn(euiTabViewName));
		this.RefreshGamePadKeyTip();
	}

	// Token: 0x06015AA4 RID: 88740 RVA: 0x00603DDC File Offset: 0x00601FDC
	private CommonTabData GetCommonData(int index)
	{
		UiDynamicTab uiDynamicTab = this.TabDataList[index];
		return new CommonTabData(uiDynamicTab.Icon, new CommonTabTitleData(uiDynamicTab.TabName, Array.Empty<object>()), null);
	}

	// Token: 0x06015AA5 RID: 88741 RVA: 0x00603E14 File Offset: 0x00602014
	protected bool CanToggleChange(int index, bool? _)
	{
		if (Singleton<Info>.Instance.IsInGamepad())
		{
			return true;
		}
		int? intConfig = ConfigCommonParamById.GetIntConfig("panel_interval_time");
		return intConfig == null || (this.LastClickTime == 0.0 || Singleton<TimeUtil>.Instance.GetServerTimeStamp() - this.LastClickTime >= (double)intConfig.Value);
	}

	// Token: 0x06015AA6 RID: 88742 RVA: 0x00603E74 File Offset: 0x00602074
	private void OnClickHelpBtn()
	{
		EUiTabViewName? currentTabViewName = this.TabViewComponent.GetCurrentTabViewName(null);
		if (currentTabViewName == null)
		{
			return;
		}
		int? helpId = this.ViewModel.GetHelpId(currentTabViewName.Value);
		if (helpId != null)
		{
			ControllerBase<HelpController>.Instance.OpenHelpById(helpId.Value);
		}
	}

	// Token: 0x06015AA7 RID: 88743 RVA: 0x00603ECD File Offset: 0x006020CD
	private UUIDraggableComponent GetDragItem()
	{
		return base.GetDraggable(2);
	}

	// Token: 0x06015AA8 RID: 88744 RVA: 0x00603ED8 File Offset: 0x006020D8
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
	{
		int param = int.Parse(configParams[0]);
		int num = Array.FindIndex<UiDynamicTab>(this.TabDataList, (UiDynamicTab data) => data.Id == param);
		if (num < 0)
		{
			return null;
		}
		TabComponentWithCaptionItem<SkinTabItem> tabComponent = this.TabComponent;
		UUIItem uuiitem;
		if (tabComponent == null)
		{
			uuiitem = null;
		}
		else
		{
			SkinTabItem tabItemByIndex = tabComponent.GetTabItemByIndex(num);
			uuiitem = ((tabItemByIndex != null) ? tabItemByIndex.GetRootItem() : null);
		}
		UUIItem uuiitem2 = uuiitem;
		if (uuiitem2 != null)
		{
			return new UUIItem[]
			{
				uuiitem2,
				uuiitem2
			};
		}
		return null;
	}

	// Token: 0x0400A662 RID: 42594
	[Nullable(2)]
	protected TabViewComponent<UiDynamicTab> TabViewComponent;

	// Token: 0x0400A663 RID: 42595
	[Nullable(new byte[]
	{
		2,
		1
	})]
	protected TabComponentWithCaptionItem<SkinTabItem> TabComponent;

	// Token: 0x0400A664 RID: 42596
	[Nullable(2)]
	protected UiDynamicTab[] TabDataList;

	// Token: 0x0400A665 RID: 42597
	[Nullable(2)]
	private ISkinViewData ViewData;

	// Token: 0x0400A666 RID: 42598
	[Nullable(2)]
	private SkinRootViewModel ViewModel;

	// Token: 0x0400A667 RID: 42599
	[Nullable(2)]
	private SkinFadeAnimController FadeAnimController;

	// Token: 0x0400A668 RID: 42600
	private double LastClickTime;

	// Token: 0x0400A669 RID: 42601
	private bool NeedReloadRole;

	// Token: 0x0400A66A RID: 42602
	private int FloorEffect;

	// Token: 0x02008DC7 RID: 36295
	[NullableContext(0)]
	private enum EComponentDefine
	{
		// Token: 0x0402FB7A RID: 195450
		CaptionItem,
		// Token: 0x0402FB7B RID: 195451
		ContentItem,
		// Token: 0x0402FB7C RID: 195452
		DragItem,
		// Token: 0x0402FB7D RID: 195453
		ItemGamePadKeyTipA,
		// Token: 0x0402FB7E RID: 195454
		ItemGamePadKeyTipB
	}
}
