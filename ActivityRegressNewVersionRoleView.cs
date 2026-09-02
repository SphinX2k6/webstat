using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020014F6 RID: 5366
[NullableContext(1)]
[Nullable(0)]
public class ActivityRegressNewVersionRoleView : ActivityRegressMainSubViewBase
{
	// Token: 0x06009630 RID: 38448 RVA: 0x00273C34 File Offset: 0x00271E34
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(3, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(4, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(5, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(6, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(7, typeof(UUITexture)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIText)),
			new ValueTuple<int, Type>(10, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(5, new Action(this.OnClickUrlBtn)),
			new ValueTuple<int, Delegate>(6, new Action(this.OnClickJumpBtn)),
			new ValueTuple<int, Delegate>(3, new Action(this.OnClickLeftBtn)),
			new ValueTuple<int, Delegate>(4, new Action(this.OnClickRightBtn))
		};
	}

	// Token: 0x06009631 RID: 38449 RVA: 0x00273DAC File Offset: 0x00271FAC
	protected override UniTask OnBeforeStartAsync()
	{
		ActivityRegressNewVersionRoleView.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ActivityRegressNewVersionRoleView.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06009632 RID: 38450 RVA: 0x00273DF0 File Offset: 0x00271FF0
	protected override void OnStart()
	{
		base.OnStart();
		this.PoolScrollView = new GenericScrollViewNew<PoolScrollItem, ProtoGachaPoolInfo>(base.GetScrollViewWithScrollbar(2), new Func<PoolScrollItem>(this.OnInitItem), null, false, null);
		this.PoolInfoList = ModelBase<ActivityRegressModel>.Instance.GetGachaPoolUpPool();
		this.PoolScrollView.RefreshByData(this.PoolInfoList, delegate
		{
			GenericScrollViewNew<PoolScrollItem, ProtoGachaPoolInfo> poolScrollView = this.PoolScrollView;
			if (poolScrollView == null)
			{
				return;
			}
			PoolScrollItem scrollItemByIndex = poolScrollView.GetScrollItemByIndex(0);
			if (scrollItemByIndex == null)
			{
				return;
			}
			scrollItemByIndex.SelectedToggle();
		}, false);
		UUIItem uuiitem = this.PoolScrollView.ContentItem.Value.Get();
		float width = uuiitem.Width;
		USceneComponent childComponent = uuiitem.GetChildComponent(0);
		if (childComponent != null)
		{
			float num = (childComponent.GetOwner().GetComponentByClass(UUIItem.StaticClass()) as UUIItem).GetWidth() + 15f;
			if (width <= num * (float)this.PoolInfoList.Count)
			{
				uuiitem.SetAnchorAlign(UIAnchorHorizontalAlign.Left, UIAnchorVerticalAlign.Middle);
				uuiitem.SetWidth(num * (float)this.PoolInfoList.Count);
			}
		}
	}

	// Token: 0x06009633 RID: 38451 RVA: 0x00273ED7 File Offset: 0x002720D7
	private PoolScrollItem OnInitItem()
	{
		return new PoolScrollItem
		{
			OnClickToggleCallBack = new Action<ProtoGachaPoolInfo, UUIExtendToggle>(this.OnClickPoolItemToggle)
		};
	}

	// Token: 0x06009634 RID: 38452 RVA: 0x00273EF0 File Offset: 0x002720F0
	private void OnClickPoolItemToggle([Nullable(2)] ProtoGachaPoolInfo poolInfo, UUIExtendToggle toggle)
	{
		if (poolInfo == null || this.CurrentSelectPoolInfo == poolInfo)
		{
			return;
		}
		this.CurrentSelectPoolInfo = poolInfo;
		UUIExtendToggle currentSelectToggle = this.CurrentSelectToggle;
		if (currentSelectToggle != null)
		{
			currentSelectToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		}
		this.CurrentSelectToggle = toggle;
		this.RefreshView();
	}

	// Token: 0x06009635 RID: 38453 RVA: 0x00273F2C File Offset: 0x0027212C
	private void RefreshView()
	{
		if (this.CurrentSelectPoolInfo == null)
		{
			return;
		}
		RoleDescribeComponent roleDescribeComponent = this.RoleDescribeComponent;
		if (roleDescribeComponent != null)
		{
			roleDescribeComponent.Update(this.CurrentSelectPoolInfo.PreviewIdList[0], false);
		}
		GachaViewInfo? gachaViewInfo = ConfigBase<GachaConfig>.Instance.GetGachaViewInfo(this.CurrentSelectPoolInfo.Id);
		if (gachaViewInfo == null)
		{
			return;
		}
		GachaViewInfo value = gachaViewInfo.Value;
		base.SetTextureByPath(value.UnderBgTexturePath, base.GetTexture(7), null, null);
		int uiType = this.CurrentSelectPoolInfo.UiType;
		if (uiType == 0)
		{
			return;
		}
		GachaViewTypeInfo? gachaViewTypeConfig = ConfigBase<GachaConfig>.Instance.GetGachaViewTypeConfig(uiType);
		if (gachaViewTypeConfig == null)
		{
			return;
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(10), gachaViewTypeConfig.Value.TypeText, Array.Empty<object>());
		base.GetText(9).SetText(this.CurrentSelectPoolInfo.Title, true);
		GachaPool? gachaPoolConfig = ConfigBase<GachaConfig>.Instance.GetGachaPoolConfig(this.CurrentSelectPoolInfo.Id);
		if (gachaPoolConfig == null)
		{
			return;
		}
		ProtoGachaInfo gachaInfo = ModelBase<GachaModel>.Instance.GetGachaInfo(gachaPoolConfig.Value.GachaId);
		if (gachaInfo == null)
		{
			this.CloseView();
			return;
		}
		double poolEndTimeByPoolInfo = gachaInfo.GetPoolEndTimeByPoolInfo(this.CurrentSelectPoolInfo);
		if (poolEndTimeByPoolInfo == 0.0)
		{
			return;
		}
		double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
		double remainTime = poolEndTimeByPoolInfo - serverTime;
		CommonDefine.ICountDown remainTimeDataFormat = Singleton<TimeUtil>.Instance.GetRemainTimeDataFormat(remainTime);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), "Text_GachaRemainingTime_Text", new <>z__ReadOnlySingleElementList<object>(remainTimeDataFormat.CountDownText));
		this.RefreshButtonUiActivity();
		this.RefreshRoleItemAsync(value.SpinePrefabResource, (value.TrialRoleId > 0) ? value.TrialRoleId : value.Id);
	}

	// Token: 0x06009636 RID: 38454 RVA: 0x002740E4 File Offset: 0x002722E4
	private UniTask RefreshRoleItemAsync(string resourceId, int roleId)
	{
		ActivityRegressNewVersionRoleView.<RefreshRoleItemAsync>d__16 <RefreshRoleItemAsync>d__;
		<RefreshRoleItemAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshRoleItemAsync>d__.<>4__this = this;
		<RefreshRoleItemAsync>d__.resourceId = resourceId;
		<RefreshRoleItemAsync>d__.roleId = roleId;
		<RefreshRoleItemAsync>d__.<>1__state = -1;
		<RefreshRoleItemAsync>d__.<>t__builder.Start<ActivityRegressNewVersionRoleView.<RefreshRoleItemAsync>d__16>(ref <RefreshRoleItemAsync>d__);
		return <RefreshRoleItemAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06009637 RID: 38455 RVA: 0x00274138 File Offset: 0x00272338
	private UniTask InitRoleSpineItem(string resourceId, int roleId)
	{
		ActivityRegressNewVersionRoleView.<InitRoleSpineItem>d__17 <InitRoleSpineItem>d__;
		<InitRoleSpineItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitRoleSpineItem>d__.<>4__this = this;
		<InitRoleSpineItem>d__.resourceId = resourceId;
		<InitRoleSpineItem>d__.roleId = roleId;
		<InitRoleSpineItem>d__.<>1__state = -1;
		<InitRoleSpineItem>d__.<>t__builder.Start<ActivityRegressNewVersionRoleView.<InitRoleSpineItem>d__17>(ref <InitRoleSpineItem>d__);
		return <InitRoleSpineItem>d__.<>t__builder.Task;
	}

	// Token: 0x06009638 RID: 38456 RVA: 0x0027418C File Offset: 0x0027238C
	private UniTask InitRoleCommonItem()
	{
		ActivityRegressNewVersionRoleView.<InitRoleCommonItem>d__18 <InitRoleCommonItem>d__;
		<InitRoleCommonItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitRoleCommonItem>d__.<>4__this = this;
		<InitRoleCommonItem>d__.<>1__state = -1;
		<InitRoleCommonItem>d__.<>t__builder.Start<ActivityRegressNewVersionRoleView.<InitRoleCommonItem>d__18>(ref <InitRoleCommonItem>d__);
		return <InitRoleCommonItem>d__.<>t__builder.Task;
	}

	// Token: 0x06009639 RID: 38457 RVA: 0x002741D0 File Offset: 0x002723D0
	private void RefreshButtonUiActivity()
	{
		if (this.CurrentSelectPoolInfo == null)
		{
			return;
		}
		int num = this.PoolInfoList.IndexOf(this.CurrentSelectPoolInfo);
		if (num <= 0)
		{
			base.GetButton(3).RootUIComp.Get().SetUIActive(false);
		}
		else
		{
			base.GetButton(3).RootUIComp.Get().SetUIActive(true);
		}
		if (num >= this.PoolInfoList.Count - 1)
		{
			base.GetButton(4).RootUIComp.Get().SetUIActive(false);
			return;
		}
		base.GetButton(4).RootUIComp.Get().SetUIActive(true);
	}

	// Token: 0x0600963A RID: 38458 RVA: 0x00274275 File Offset: 0x00272475
	private void OnClickUrlBtn()
	{
		if (this.CurrentSelectPoolInfo == null)
		{
			return;
		}
		ActivityRegressController.OpenGameIntroductionByRoleId(this.CurrentSelectPoolInfo.PreviewIdList[0]);
	}

	// Token: 0x0600963B RID: 38459 RVA: 0x00274294 File Offset: 0x00272494
	private void OnClickJumpBtn()
	{
		if (this.CurrentSelectPoolInfo == null)
		{
			return;
		}
		GachaPool? gachaPoolConfig = ConfigBase<GachaConfig>.Instance.GetGachaPoolConfig(this.CurrentSelectPoolInfo.Id);
		if (gachaPoolConfig == null)
		{
			return;
		}
		ProtoGachaInfo gachaInfo = ModelBase<GachaModel>.Instance.GetGachaInfo(gachaPoolConfig.Value.GachaId);
		if (gachaInfo == null)
		{
			this.CloseView();
			return;
		}
		bool flag = Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.ActivityRegressNewVersionMainView);
		Singleton<UiManager>.Instance.OpenView(EUiViewName.GachaMainView, gachaInfo.Id, null);
		Singleton<UiManager>.Instance.CloseView(flag ? EUiViewName.ActivityRegressNewVersionMainView : EUiViewName.ActivityRegressMainView, null);
		Singleton<UiManager>.Instance.CloseView(EUiViewName.CommonActivityView, null);
	}

	// Token: 0x0600963C RID: 38460 RVA: 0x00274344 File Offset: 0x00272544
	private void CloseView()
	{
		if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.ActivityRegressMainView))
		{
			Singleton<UiManager>.Instance.CloseView(EUiViewName.ActivityRegressMainView, null);
		}
		if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.ActivityRegressNewVersionMainView))
		{
			Singleton<UiManager>.Instance.CloseView(EUiViewName.ActivityRegressNewVersionMainView, null);
		}
	}

	// Token: 0x0600963D RID: 38461 RVA: 0x00274394 File Offset: 0x00272594
	private void OnClickLeftBtn()
	{
		if (this.CurrentSelectPoolInfo == null)
		{
			return;
		}
		int num = this.PoolInfoList.IndexOf(this.CurrentSelectPoolInfo);
		if (num <= 0)
		{
			return;
		}
		num--;
		GenericScrollViewNew<PoolScrollItem, ProtoGachaPoolInfo> poolScrollView = this.PoolScrollView;
		PoolScrollItem poolScrollItem = (poolScrollView != null) ? poolScrollView.GetScrollItemByIndex(num) : null;
		if (poolScrollItem == null)
		{
			return;
		}
		poolScrollItem.SelectedToggle();
	}

	// Token: 0x0600963E RID: 38462 RVA: 0x002743E4 File Offset: 0x002725E4
	private void OnClickRightBtn()
	{
		if (this.CurrentSelectPoolInfo == null)
		{
			return;
		}
		int num = this.PoolInfoList.IndexOf(this.CurrentSelectPoolInfo);
		if (num >= this.PoolInfoList.Count - 1)
		{
			return;
		}
		num++;
		GenericScrollViewNew<PoolScrollItem, ProtoGachaPoolInfo> poolScrollView = this.PoolScrollView;
		PoolScrollItem poolScrollItem = (poolScrollView != null) ? poolScrollView.GetScrollItemByIndex(num) : null;
		if (poolScrollItem == null)
		{
			return;
		}
		poolScrollItem.SelectedToggle();
	}

	// Token: 0x04004593 RID: 17811
	private const int POOL_ITEM_PADDING = 15;

	// Token: 0x04004594 RID: 17812
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericScrollViewNew<PoolScrollItem, ProtoGachaPoolInfo> PoolScrollView;

	// Token: 0x04004595 RID: 17813
	[Nullable(2)]
	private RoleDescribeComponent RoleDescribeComponent;

	// Token: 0x04004596 RID: 17814
	[Nullable(2)]
	private ProtoGachaPoolInfo CurrentSelectPoolInfo;

	// Token: 0x04004597 RID: 17815
	private List<ProtoGachaPoolInfo> PoolInfoList = new List<ProtoGachaPoolInfo>();

	// Token: 0x04004598 RID: 17816
	[Nullable(2)]
	private UUIExtendToggle CurrentSelectToggle;

	// Token: 0x04004599 RID: 17817
	private readonly Dictionary<int, NewPlayerSupportRoleSpineItem> RoleSpineItemMap = new Dictionary<int, NewPlayerSupportRoleSpineItem>();

	// Token: 0x0400459A RID: 17818
	[Nullable(2)]
	private NewPlayerSupportRoleBaseItem CurRoleItem;

	// Token: 0x0400459B RID: 17819
	[Nullable(2)]
	private NewPlayerSupportRoleCommonItem RoleCommonItem;

	// Token: 0x020078B9 RID: 30905
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x040297F7 RID: 169975
		public const int LeftTimeText = 0;

		// Token: 0x040297F8 RID: 169976
		public const int RoleInfoItem = 1;

		// Token: 0x040297F9 RID: 169977
		public const int PoolListScrollView = 2;

		// Token: 0x040297FA RID: 169978
		public const int LeftBtn = 3;

		// Token: 0x040297FB RID: 169979
		public const int RightBtn = 4;

		// Token: 0x040297FC RID: 169980
		public const int UrlBtn = 5;

		// Token: 0x040297FD RID: 169981
		public const int JumpToBtn = 6;

		// Token: 0x040297FE RID: 169982
		public const int BgTexture = 7;

		// Token: 0x040297FF RID: 169983
		public const int RoleSpineItem = 8;

		// Token: 0x04029800 RID: 169984
		public const int TitleText = 9;

		// Token: 0x04029801 RID: 169985
		public const int SubTitleText = 10;
	}
}
