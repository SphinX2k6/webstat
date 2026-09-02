using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.SpringManor;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200100A RID: 4106
[NullableContext(1)]
[Nullable(0)]
public class DrinksSelectRoleView : UiViewBase, IUiCameraBehavior
{
	// Token: 0x06006AC5 RID: 27333 RVA: 0x001BE25E File Offset: 0x001BC45E
	public DrinksSelectRoleView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06006AC6 RID: 27334 RVA: 0x001BE278 File Offset: 0x001BC478
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUISprite)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIText)),
			new ValueTuple<int, Type>(7, typeof(UUIText)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUITexture)),
			new ValueTuple<int, Type>(10, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(11, typeof(UUIItem)),
			new ValueTuple<int, Type>(12, typeof(UUISprite)),
			new ValueTuple<int, Type>(13, typeof(UUISprite)),
			new ValueTuple<int, Type>(14, typeof(UUIItem)),
			new ValueTuple<int, Type>(15, typeof(UUIItem)),
			new ValueTuple<int, Type>(16, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(17, typeof(UUINiagara)),
			new ValueTuple<int, Type>(18, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(19, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(16, new Action(this.OnClickedWine)),
			new ValueTuple<int, Delegate>(18, new Action(this.OnClickedReward))
		};
	}

	// Token: 0x06006AC7 RID: 27335 RVA: 0x001BE490 File Offset: 0x001BC690
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.PlotViewChange, new Action<EUiViewName, bool>(this.OnPlotStart));
		Singleton<EventSystem>.Instance.Add(EEventName.OnDrinksUnlockClickedNotify, new Action(this.OnRedDotRefresh));
		this.NeedRemove = true;
	}

	// Token: 0x06006AC8 RID: 27336 RVA: 0x001BE4DC File Offset: 0x001BC6DC
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnDrinksUnlockClickedNotify, new Action(this.OnRedDotRefresh));
		if (this.NeedRemove)
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.PlotViewChange, new Action<EUiViewName, bool>(this.OnPlotStart));
		}
	}

	// Token: 0x06006AC9 RID: 27337 RVA: 0x001BE52C File Offset: 0x001BC72C
	protected override UniTask OnBeforeStartAsync()
	{
		DrinksSelectRoleView.<OnBeforeStartAsync>d__13 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<DrinksSelectRoleView.<OnBeforeStartAsync>d__13>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06006ACA RID: 27338 RVA: 0x001BE570 File Offset: 0x001BC770
	protected override void OnStart()
	{
		this.ConfirmBtn = new ButtonItem(base.GetItem(14));
		this.ConfirmBtn.SetFunction(new Action<int>(this.OnClickedConfirm));
		this.InitRoleSelect();
		string cameraNameByLevelId = ModelBase<DrinksModel>.Instance.GetCameraNameByLevelId(this.CurSelectConfig);
		this.CurCameraName = cameraNameByLevelId;
	}

	// Token: 0x06006ACB RID: 27339 RVA: 0x001BE5C5 File Offset: 0x001BC7C5
	protected override void OnBeforeShow()
	{
		this.PauseTimeDilation();
		ModelBase<DrinksModel>.Instance.GetSceneController().HideNpc();
		Singleton<UiCameraAnimationManager>.Instance.DisablePlayerActor();
		this.OnRedDotRefresh();
		this.RefreshRoleSelect(true);
		ModelBase<DrinksModel>.Instance.EntityShowOnOpenInviteView();
	}

	// Token: 0x06006ACC RID: 27340 RVA: 0x001BE5FD File Offset: 0x001BC7FD
	protected override void OnBeforeHide()
	{
		if (this.IsConfirmHide)
		{
			this.IsConfirmHide = false;
		}
		else
		{
			Singleton<UiCameraAnimationManager>.Instance.EnablePlayerActor();
		}
		this.ResumeTimeDilation();
	}

	// Token: 0x06006ACD RID: 27341 RVA: 0x001BE620 File Offset: 0x001BC820
	protected void PauseTimeDilation()
	{
		Singleton<UiTimeDilation>.Instance.AddWaitSetTimeDilationTag("DrinksSelectRoleView");
	}

	// Token: 0x06006ACE RID: 27342 RVA: 0x001BE631 File Offset: 0x001BC831
	protected void ResumeTimeDilation()
	{
		Singleton<UiTimeDilation>.Instance.DeleteWaitSetTimeDilationTag("DrinksSelectRoleView");
	}

	// Token: 0x06006ACF RID: 27343 RVA: 0x001BE644 File Offset: 0x001BC844
	protected void InitRoleSelect()
	{
		IEnumerable<DrinksRoleInvite> allInvite = ConfigBase<DrinksConfig>.Instance.GetAllInvite();
		List<int> list = new List<int>();
		foreach (DrinksRoleInvite drinksRoleInvite in allInvite)
		{
			if (ModelBase<DrinksModel>.Instance.CheckLevelIsUnlock(drinksRoleInvite.Id))
			{
				this.CurSelectConfig = drinksRoleInvite.Id;
			}
			list.Add(drinksRoleInvite.Id);
		}
		if (this.CurSelectConfig == -1)
		{
			this.CurSelectConfig = list[0];
		}
		this.RoleLayout.RefreshByData(list, null, true);
	}

	// Token: 0x06006AD0 RID: 27344 RVA: 0x001BE6E8 File Offset: 0x001BC8E8
	protected void RefreshRoleSelect(bool isInit = false)
	{
		DrinksRoleInvite? inviteConfig = ConfigBase<DrinksConfig>.Instance.GetInviteConfig(this.CurSelectConfig);
		RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(inviteConfig.Value.RoleId);
		string cameraNameByLevelId = ModelBase<DrinksModel>.Instance.GetCameraNameByLevelId(this.CurSelectConfig);
		this.CurCameraName = cameraNameByLevelId;
		if (!isInit)
		{
			this.PushCamera();
		}
		base.GetText(3).ShowTextNew(roleConfig.Value.Name);
		DrinksDrinkMix? drinkMix = ConfigBase<DrinksConfig>.Instance.GetDrinkMix(inviteConfig.Value.DrinksFavor);
		bool flag = ModelBase<DrinksModel>.Instance.CheckLevelIsUnlock(this.CurSelectConfig);
		bool flag2 = false;
		Dictionary<int, IDrinksMixRoleInfo> drinksProgressMap = ModelBase<SpringManorModel>.Instance.ActivityData.GetDrinksProgressMap();
		if (flag)
		{
			IDrinksMixRoleInfo drinksMixRoleInfo;
			drinksProgressMap.TryGetValue(inviteConfig.Value.RoleId, out drinksMixRoleInfo);
			flag2 = (drinksMixRoleInfo != null && drinksMixRoleInfo.MaxLike);
			this.UpdatePlayerStorage();
		}
		else
		{
			this.PanelLock.SetTextByTextId(inviteConfig.Value.LockTxt, Array.Empty<string>());
		}
		FColor changeColor = base.GetText(6).changeColor;
		UUIText text = base.GetText(6);
		if (text != null)
		{
			bool bUseChangeColor = flag2;
			FColor? fcolor = new FColor?(changeColor);
			text.SetChangeColor(bUseChangeColor, fcolor);
		}
		UUIItem item = base.GetItem(8);
		if (item != null)
		{
			item.SetUIActive(!flag2);
		}
		UUITexture texture = base.GetTexture(9);
		if (texture != null)
		{
			texture.SetUIActive(flag2);
		}
		UUISprite sprite = base.GetSprite(4);
		if (sprite != null)
		{
			sprite.SetUIActive(!flag2);
		}
		UUIItem item2 = base.GetItem(5);
		if (item2 != null)
		{
			item2.SetUIActive(flag2);
		}
		UUIButtonComponent button = base.GetButton(16);
		if (button != null)
		{
			button.RootUIComp.Get().SetUIActive(flag2);
		}
		this.ConfirmBtn.SetUiActive(flag);
		IDrinksMixRoleInfo drinksMixRoleInfo2;
		drinksProgressMap.TryGetValue(inviteConfig.Value.RoleId, out drinksMixRoleInfo2);
		string textId = (drinksMixRoleInfo2 != null) ? "Drinks_Button_Next" : "Drinks_Button_First";
		this.ConfirmBtn.SetLocalTextNew(textId, Array.Empty<object>());
		this.PanelLock.SetUiActive(!flag);
		if (flag2)
		{
			base.SetTextureByPath(drinkMix.Value.Icon, base.GetTexture(9), null, null);
			base.GetText(6).ShowTextNew(drinkMix.Value.Name);
			base.GetText(7).ShowTextNew(inviteConfig.Value.DrinksUnlock);
		}
		else
		{
			base.GetText(6).SetText("???", true);
			base.GetText(7).ShowTextNew(inviteConfig.Value.DrinksLock);
		}
		this.RefreshReward();
	}

	// Token: 0x06006AD1 RID: 27345 RVA: 0x001BE994 File Offset: 0x001BCB94
	private void RefreshReward()
	{
		bool flag = ModelBase<DrinksModel>.Instance.CheckLevelIsUnlock(this.CurSelectConfig);
		DrinksRoleInvite? inviteConfig = ConfigBase<DrinksConfig>.Instance.GetInviteConfig(this.CurSelectConfig);
		bool flag2 = false;
		bool flag3 = false;
		if (flag)
		{
			IDrinksMixRoleInfo drinksMixRoleInfo;
			ModelBase<SpringManorModel>.Instance.ActivityData.GetDrinksProgressMap().TryGetValue(inviteConfig.Value.RoleId, out drinksMixRoleInfo);
			flag2 = (drinksMixRoleInfo != null && drinksMixRoleInfo.FirstPass);
			flag3 = (drinksMixRoleInfo != null && drinksMixRoleInfo.RewardGet);
			this.UpdatePlayerStorage();
		}
		List<TItem> dropPackagePreviewItemList = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackagePreviewItemList(inviteConfig.Value.FirstAward);
		UUISprite sprite = base.GetSprite(12);
		if (sprite != null)
		{
			sprite.SetUIActive(!flag2);
		}
		UUIItem item = base.GetItem(19);
		if (item != null)
		{
			item.SetUIActive(flag2 && !flag3);
		}
		UUIButtonComponent button = base.GetButton(18);
		if (button != null)
		{
			button.RootUIComp.Get().SetUIActive(flag2 && !flag3);
		}
		UUISprite sprite2 = base.GetSprite(13);
		if (sprite2 != null)
		{
			sprite2.SetUIActive(flag3);
		}
		bool capturedIsReceive = flag3;
		this.RewardScrollView.RefreshByData(dropPackagePreviewItemList, delegate
		{
			foreach (CommonItemSmallItemGrid commonItemSmallItemGrid in this.RewardScrollView.GetScrollItemList())
			{
				commonItemSmallItemGrid.SetReceivedVisible(capturedIsReceive);
			}
		}, false);
	}

	// Token: 0x06006AD2 RID: 27346 RVA: 0x001BEAD0 File Offset: 0x001BCCD0
	public void PushCameraHandle(EUiViewName viewName, int viewId, bool isBlend)
	{
		if (this.CurCameraName != null)
		{
			ControllerBase<UiCameraAnimationController>.Instance.PushCameraHandle((EUiViewName)this.CurCameraName, new int?(viewId), isBlend);
		}
	}

	// Token: 0x06006AD3 RID: 27347 RVA: 0x001BEAF6 File Offset: 0x001BCCF6
	[NullableContext(2)]
	public void PopCameraHandle(EUiViewName viewName, UiViewInfo stackTopInfo, int closeViewId, bool popOrDelete)
	{
		if (this.CurCameraName != null)
		{
			ControllerBase<UiCameraAnimationController>.Instance.PopCameraHandle((EUiViewName)this.CurCameraName, stackTopInfo, closeViewId, popOrDelete);
		}
	}

	// Token: 0x06006AD4 RID: 27348 RVA: 0x001BEB1C File Offset: 0x001BCD1C
	private void PushCamera()
	{
		if (this.CurCameraName != null)
		{
			Singleton<UiCameraAnimationManager>.Instance.PushCameraHandleByOpenView(this.CurCameraName, null, true);
		}
	}

	// Token: 0x06006AD5 RID: 27349 RVA: 0x001BEB4C File Offset: 0x001BCD4C
	private void UpdatePlayerStorage()
	{
		HashSet<int> player = LocalStorage.GetPlayer<HashSet<int>>(ELocalStoragePlayerKey.DrinksUnlockLevelClicked, null);
		bool flag = false;
		if (player == null || !player.Contains(this.CurSelectConfig))
		{
			flag = true;
		}
		if (player != null)
		{
			if (player.Contains(this.CurSelectConfig))
			{
				return;
			}
			player.Add(this.CurSelectConfig);
			LocalStorage.SetPlayer<HashSet<int>>(ELocalStoragePlayerKey.DrinksUnlockLevelClicked, player);
		}
		else
		{
			LocalStorage.SetPlayer<HashSet<int>>(ELocalStoragePlayerKey.DrinksUnlockLevelClicked, new HashSet<int>
			{
				this.CurSelectConfig
			});
		}
		if (flag)
		{
			Singleton<EventSystem>.Instance.Emit(EEventName.OnDrinksUnlockClickedNotify);
		}
	}

	// Token: 0x06006AD6 RID: 27350 RVA: 0x001BEBD7 File Offset: 0x001BCDD7
	private void OnToggleStateChange(int id)
	{
		this.CurSelectConfig = id;
		this.RoleLayout.RefreshWithoutDataSync();
		this.RefreshRoleSelect(false);
	}

	// Token: 0x06006AD7 RID: 27351 RVA: 0x001BEBF2 File Offset: 0x001BCDF2
	private bool GetToggleStateSelected(int id)
	{
		return this.CurSelectConfig == id;
	}

	// Token: 0x06006AD8 RID: 27352 RVA: 0x001BEBFD File Offset: 0x001BCDFD
	private CommonItemSmallItemGrid CreatePropItem()
	{
		return new CommonItemSmallItemGrid();
	}

	// Token: 0x06006AD9 RID: 27353 RVA: 0x001BEC04 File Offset: 0x001BCE04
	private DrinksRoleSelectItem CreateRoleItem()
	{
		return new DrinksRoleSelectItem
		{
			IsSelectOnCb = new Func<int, bool>(this.GetToggleStateSelected),
			OnToggleStateChangeFunction = new Action<int>(this.OnToggleStateChange)
		};
	}

	// Token: 0x06006ADA RID: 27354 RVA: 0x001BEC2F File Offset: 0x001BCE2F
	private void OnClickedClose()
	{
		ModelBase<DrinksModel>.Instance.GetSceneController().ShowNpc();
		ModelBase<DrinksModel>.Instance.EntityHideOnCloseInviteView();
		Singleton<UiManager>.Instance.ResetToBattleView(null);
	}

	// Token: 0x06006ADB RID: 27355 RVA: 0x001BEC58 File Offset: 0x001BCE58
	private void OnClickedConfirm(int _)
	{
		this.NeedRemove = false;
		Singleton<UiLayer>.Instance.SetShowMaskLayer(EUiViewName.DrinksSelectRoleView, true);
		DrinksRoleInvite? inviteConfig = ConfigBase<DrinksConfig>.Instance.GetInviteConfig(this.CurSelectConfig);
		EDrinksGameplayOpenWay openWay = (EDrinksGameplayOpenWay)this.OpenParam;
		ControllerBase<DrinksController>.Instance.SelectRoleAndPlaySeq(inviteConfig.Value.RoleId, openWay, null).ContinueWith(delegate(bool value)
		{
			this.IsConfirmHide = value;
			return value;
		});
	}

	// Token: 0x06006ADC RID: 27356 RVA: 0x001BECD4 File Offset: 0x001BCED4
	private unsafe void OnClickedWine()
	{
		DrinksRoleInvite? inviteConfig = ConfigBase<DrinksConfig>.Instance.GetInviteConfig(this.CurSelectConfig);
		int[] mixArrayArray = ConfigBase<DrinksConfig>.Instance.GetDrinkMix(inviteConfig.Value.DrinksFavor).Value.GetMixArrayArray();
		DrinksSoftDrinkData drinksConfigById = ModelBase<DrinksModel>.Instance.GetDrinksConfigById(mixArrayArray[0]);
		DrinksSoftDrinkData drinksConfigById2 = ModelBase<DrinksModel>.Instance.GetDrinksConfigById(mixArrayArray[1]);
		DrinksResultInfo drinksResultInfo = new DrinksResultInfo();
		drinksResultInfo.RequireId = 0;
		int num = 2;
		List<int> list = new List<int>(num);
		CollectionsMarshal.SetCount<int>(list, num);
		Span<int> span = CollectionsMarshal.AsSpan<int>(list);
		int num2 = 0;
		*span[num2] = drinksConfigById.GetMenuBaseId();
		num2++;
		*span[num2] = drinksConfigById2.GetMenuBaseId();
		drinksResultInfo.DrinkBase = list;
		drinksResultInfo.Batching = inviteConfig.Value.GetDrinksFavorBatchingArray();
		drinksResultInfo.Ornament = inviteConfig.Value.DrinksFavorOrnament;
		DrinksResultInfo data = drinksResultInfo;
		DrinksShowInfo param = new DrinksShowInfo
		{
			Data = data,
			RoleId = inviteConfig.Value.RoleId,
			IsGamePlay = false
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.DrinksShowView, param, null);
	}

	// Token: 0x06006ADD RID: 27357 RVA: 0x001BEE00 File Offset: 0x001BD000
	private void OnClickedReward()
	{
		DrinksRoleInvite? inviteConfig = ConfigBase<DrinksConfig>.Instance.GetInviteConfig(this.CurSelectConfig);
		ControllerBase<DrinksController>.Instance.RequestMixDrinkRoleReward(this.CurSelectConfig, inviteConfig.Value.RoleId).ContinueWith(delegate(bool value)
		{
			if (value)
			{
				this.RefreshReward();
			}
		});
	}

	// Token: 0x06006ADE RID: 27358 RVA: 0x001BEE4F File Offset: 0x001BD04F
	private void OnPlotStart(EUiViewName _, bool __)
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.PlotViewChange, new Action<EUiViewName, bool>(this.OnPlotStart));
		Singleton<UiLayer>.Instance.SetShowMaskLayer(EUiViewName.DrinksSelectRoleView, false);
	}

	// Token: 0x06006ADF RID: 27359 RVA: 0x001BEE84 File Offset: 0x001BD084
	private void OnRedDotRefresh()
	{
		IEnumerable<DrinksRoleInvite> allInvite = ConfigBase<DrinksConfig>.Instance.GetAllInvite();
		List<int> list = new List<int>();
		foreach (DrinksRoleInvite drinksRoleInvite in allInvite)
		{
			list.Add(drinksRoleInvite.Id);
		}
		this.RoleLayout.RefreshByData(list, null, false);
	}

	// Token: 0x040032BE RID: 12990
	public PopupCaptionItem CaptionItem;

	// Token: 0x040032BF RID: 12991
	private GenericLayout<DrinksRoleSelectItem, int> RoleLayout;

	// Token: 0x040032C0 RID: 12992
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericScrollViewNew<CommonItemSmallItemGrid, TItem> RewardScrollView;

	// Token: 0x040032C1 RID: 12993
	private FunctionalPanelConditionLock PanelLock;

	// Token: 0x040032C2 RID: 12994
	private int CurSelectConfig = -1;

	// Token: 0x040032C3 RID: 12995
	[Nullable(2)]
	private string CurCameraName;

	// Token: 0x040032C4 RID: 12996
	private bool NeedRemove = true;

	// Token: 0x040032C5 RID: 12997
	private ButtonItem ConfirmBtn;

	// Token: 0x040032C6 RID: 12998
	private bool IsConfirmHide;
}
