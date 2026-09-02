using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200253C RID: 9532
[NullableContext(2)]
[Nullable(0)]
public class VisionNewRecommendView : UiViewBase
{
	// Token: 0x060128BE RID: 75966 RVA: 0x0051C42B File Offset: 0x0051A62B
	[NullableContext(1)]
	public VisionNewRecommendView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x060128BF RID: 75967 RVA: 0x0051C434 File Offset: 0x0051A634
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(1, new Action<EToggleState>(this.OnClickSimpleToggle))
		};
	}

	// Token: 0x060128C0 RID: 75968 RVA: 0x0051C4E0 File Offset: 0x0051A6E0
	protected override UniTask OnBeforeStartAsync()
	{
		VisionNewRecommendView.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<VisionNewRecommendView.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060128C1 RID: 75969 RVA: 0x0051C523 File Offset: 0x0051A723
	private void InitProxy()
	{
		this.Proxy = new VisionNewRecommendProxy();
		this.Proxy.MainViewSequence = this.UiViewSequence;
	}

	// Token: 0x060128C2 RID: 75970 RVA: 0x0051C544 File Offset: 0x0051A744
	private void InitButton()
	{
		this.Button = new ButtonItem(base.GetItem(4));
		if ((this.OpenParam as IVisionRecommendViewOpenParam).IsFromRoleDev)
		{
			this.Button.TrySetLocalTextNew("PhantomRecommend_Button05", Array.Empty<object>());
			this.Button.SetFunction(new Action<int>(this.OnClickChangeBtn));
			return;
		}
		this.Button.TrySetLocalTextNew("PhantomRecommend_Button03", Array.Empty<object>());
		this.Button.SetFunction(new Action<int>(this.OnClickPreviewBtn));
	}

	// Token: 0x060128C3 RID: 75971 RVA: 0x0051C5D0 File Offset: 0x0051A7D0
	private void OnClickChangeBtn(int _)
	{
		Action<int, int, int?> onChangeFetterGroupSuccessCallBack = this.OnChangeFetterGroupSuccessCallBack;
		if (onChangeFetterGroupSuccessCallBack != null)
		{
			onChangeFetterGroupSuccessCallBack(this.Proxy.CurrentSelectRoleId, this.Proxy.CurrentSelectFetterRecommendInfo.GetPlanId(), new int?(this.Proxy.CurrentSelectFirstVisionMonsterId));
		}
		base.CloseMe(null);
	}

	// Token: 0x060128C4 RID: 75972 RVA: 0x0051C620 File Offset: 0x0051A820
	private void InitCaptionItem()
	{
		this.CaptionItem = new PopupCaptionItem(base.GetItem(0));
		this.CaptionItem.SetCloseCallBack(new Action(this.CloseCallBack));
		this.CaptionItem.SetTitleLocalText("PrefabTextItem_PhantomRecommend_Text");
	}

	// Token: 0x060128C5 RID: 75973 RVA: 0x0051C65C File Offset: 0x0051A85C
	private UniTask InitLeftPanelView()
	{
		VisionNewRecommendView.<InitLeftPanelView>d__14 <InitLeftPanelView>d__;
		<InitLeftPanelView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitLeftPanelView>d__.<>4__this = this;
		<InitLeftPanelView>d__.<>1__state = -1;
		<InitLeftPanelView>d__.<>t__builder.Start<VisionNewRecommendView.<InitLeftPanelView>d__14>(ref <InitLeftPanelView>d__);
		return <InitLeftPanelView>d__.<>t__builder.Task;
	}

	// Token: 0x060128C6 RID: 75974 RVA: 0x0051C6A0 File Offset: 0x0051A8A0
	private UniTask InitRightPanelView()
	{
		VisionNewRecommendView.<InitRightPanelView>d__15 <InitRightPanelView>d__;
		<InitRightPanelView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitRightPanelView>d__.<>4__this = this;
		<InitRightPanelView>d__.<>1__state = -1;
		<InitRightPanelView>d__.<>t__builder.Start<VisionNewRecommendView.<InitRightPanelView>d__15>(ref <InitRightPanelView>d__);
		return <InitRightPanelView>d__.<>t__builder.Task;
	}

	// Token: 0x060128C7 RID: 75975 RVA: 0x0051C6E3 File Offset: 0x0051A8E3
	private void CloseCallBack()
	{
		base.CloseMe(null);
	}

	// Token: 0x060128C8 RID: 75976 RVA: 0x0051C6EC File Offset: 0x0051A8EC
	protected override void OnHandleReleaseScene()
	{
		this.TryHideUiRoleModel();
	}

	// Token: 0x060128C9 RID: 75977 RVA: 0x0051C6F4 File Offset: 0x0051A8F4
	private void TryHideUiRoleModel()
	{
		TsUiSceneRoleActor roleSystemRoleActor = Singleton<UiSceneManager>.Instance.GetRoleSystemRoleActor();
		if (roleSystemRoleActor == null)
		{
			return;
		}
		UiModelBase model = roleSystemRoleActor.Model;
		Singleton<UiModelUtil>.Instance.StopFade(model);
		Singleton<UiModelUtil>.Instance.SetDitherEffect(model, 0f);
		Singleton<UiModelUtil>.Instance.SetVisible(model, false);
	}

	// Token: 0x060128CA RID: 75978 RVA: 0x0051C73F File Offset: 0x0051A93F
	protected override void OnBeforeShow()
	{
		this.TryHideUiRoleModel();
	}

	// Token: 0x060128CB RID: 75979 RVA: 0x0051C747 File Offset: 0x0051A947
	protected override void OnStart()
	{
		this.RefreshSimpleToggleState();
	}

	// Token: 0x060128CC RID: 75980 RVA: 0x0051C750 File Offset: 0x0051A950
	private void RefreshSimpleToggleState()
	{
		EToggleState state = this.Proxy.IsSimpleMode ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		UUIExtendToggle extendToggle = base.GetExtendToggle(1);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.SetToggleState(state, false, false, true);
	}

	// Token: 0x060128CD RID: 75981 RVA: 0x0051C788 File Offset: 0x0051A988
	private void InitOpenParam()
	{
		IVisionRecommendViewOpenParam visionRecommendViewOpenParam = this.OpenParam as IVisionRecommendViewOpenParam;
		this.OnChangeFetterGroupSuccessCallBack = visionRecommendViewOpenParam.SuccessCallBack;
		this.Proxy.GetSelectedPlanIdCallBack = visionRecommendViewOpenParam.GetSelectedPlanIdCallBack;
		this.Proxy.GetSelectedFirstVisionMonsterIdCallBack = visionRecommendViewOpenParam.GetSelectedFirstVisionMonsterIdCallBack;
		this.Proxy.IsFromRoleDev = visionRecommendViewOpenParam.IsFromRoleDev;
	}

	// Token: 0x060128CE RID: 75982 RVA: 0x0051C7E0 File Offset: 0x0051A9E0
	private void OnClickGuideBtn()
	{
		bool showFastFilter = ModelBase<RoleModel>.Instance.IsRoleOwned(this.Proxy.CurrentSelectRoleId);
		ControllerBase<PhantomBattleController>.Instance.OpenPhantomBattleFetterView(this.Proxy.CurrentSelectFetterRecommendInfo.GetRecommendFetterGroupId(), this.Proxy.CurrentSelectRoleId, showFastFilter, this.Proxy.CurrentSelectFetterRecommendInfo.BuildFetterList()).Forget();
	}

	// Token: 0x060128CF RID: 75983 RVA: 0x0051C83E File Offset: 0x0051AA3E
	private void OnClickTrackBtn()
	{
		ControllerBase<CalabashController>.Instance.JumpToCalabashCollectTabView(this.Proxy.CurrentSelectFirstVisionMonsterId);
	}

	// Token: 0x060128D0 RID: 75984 RVA: 0x0051C858 File Offset: 0x0051AA58
	private void OnClickPreviewBtn(int _)
	{
		VisionNewRecommendPreviewViewOpenParam param = new VisionNewRecommendPreviewViewOpenParam
		{
			Proxy = this.Proxy,
			OnApplySuccess = delegate
			{
				base.CloseMe(null);
			}
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.VisionNewRecommendPreviewView, param, null);
	}

	// Token: 0x060128D1 RID: 75985 RVA: 0x0051C89A File Offset: 0x0051AA9A
	private void OnClickSimpleToggle(EToggleState _)
	{
		VisionNewRecommendProxy proxy = this.Proxy;
		UUIExtendToggle extendToggle = base.GetExtendToggle(1);
		proxy.IsSimpleMode = (extendToggle != null && extendToggle.GetToggleState() == EToggleState.ETT_Checked);
		VisionNewRecommendRightPanelView rightPanelView = this.RightPanelView;
		if (rightPanelView == null)
		{
			return;
		}
		rightPanelView.RefreshSimpleMode();
	}

	// Token: 0x04009088 RID: 37000
	private PopupCaptionItem CaptionItem;

	// Token: 0x04009089 RID: 37001
	private VisionNewRecommendProxy Proxy;

	// Token: 0x0400908A RID: 37002
	private VisionNewRecommendLeftPanelView LeftPanelView;

	// Token: 0x0400908B RID: 37003
	private VisionNewRecommendRightPanelView RightPanelView;

	// Token: 0x0400908C RID: 37004
	private ButtonItem Button;

	// Token: 0x0400908D RID: 37005
	private Action<int, int, int?> OnChangeFetterGroupSuccessCallBack;

	// Token: 0x02008863 RID: 34915
	[NullableContext(0)]
	private enum EComp
	{
		// Token: 0x0402E118 RID: 188696
		CaptionItem,
		// Token: 0x0402E119 RID: 188697
		SimpleToggle,
		// Token: 0x0402E11A RID: 188698
		PnlLeft,
		// Token: 0x0402E11B RID: 188699
		PnlRight,
		// Token: 0x0402E11C RID: 188700
		Button
	}
}
