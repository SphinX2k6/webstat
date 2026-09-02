using System;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001794 RID: 6036
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class AndroidBackController : UiControllerBase<AndroidBackController>
{
	// Token: 0x0600AA65 RID: 43621 RVA: 0x002D727B File Offset: 0x002D547B
	protected override bool OnInit()
	{
		if (Singleton<Info>.Instance.IsMobilePlatform())
		{
			this.IsLogOpen = true;
		}
		return true;
	}

	// Token: 0x0600AA66 RID: 43622 RVA: 0x002D7291 File Offset: 0x002D5491
	protected override void OnAddEvents()
	{
		ControllerBase<InputDistributeController>.Instance.BindKey("Android_Back", new TInputHandle<InputDistributeDefine.EActionType>(this.OnAndroidBackEvent));
	}

	// Token: 0x0600AA67 RID: 43623 RVA: 0x002D72AE File Offset: 0x002D54AE
	protected override void OnRemoveEvents()
	{
		ControllerBase<InputDistributeController>.Instance.UnBindKey("Android_Back", new TInputHandle<InputDistributeDefine.EActionType>(this.OnAndroidBackEvent));
	}

	// Token: 0x0600AA68 RID: 43624 RVA: 0x002D72CC File Offset: 0x002D54CC
	private void OnAndroidBackEvent(string keyName, InputDistributeDefine.EActionType actionType, InputIdentification inputIdentification)
	{
		if (actionType == InputDistributeDefine.EActionType.Press)
		{
			return;
		}
		if (this.IsLogOpen)
		{
			Singleton<Log>.Instance.Info(ELogModule.AndroidBack, ELogAuthor.XXJ, "安卓返回键触发", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		if (UUIAndroidBackComponent.GetActiveAndroidBackComponentSize() <= 0)
		{
			this.HandleAndroidBackEmpty();
			return;
		}
		UUIAndroidBackComponent topActiveAndroidBack = UUIAndroidBackComponent.GetTopActiveAndroidBack();
		if (this.IsLogOpen)
		{
			string empty = string.Empty;
			ULGUIBPLibrary.GetFullPathOfActor(GlobalData.World, topActiveAndroidBack.GetOwner(), ref empty);
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.AndroidBack;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "触发了关闭按钮";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("按钮的节点路径", empty);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		this.ClickButtonInternal(topActiveAndroidBack);
	}

	// Token: 0x0600AA69 RID: 43625 RVA: 0x002D736C File Offset: 0x002D556C
	private void HandleAndroidBackEmpty()
	{
		if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.LoginView))
		{
			if (this.IsLogOpen)
			{
				Singleton<Log>.Instance.Info(ELogModule.AndroidBack, ELogAuthor.XXJ, "在登录界面", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			ControllerBase<ConfirmBoxController>.Instance.ShowExitGameConfirmBox();
			return;
		}
		if (!Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.BattleView))
		{
			if (this.IsLogOpen)
			{
				Singleton<Log>.Instance.Info(ELogModule.AndroidBack, ELogAuthor.XXJ, "不在主界面", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			return;
		}
		if (ModelBase<LoadingModel>.Instance.IsLoading)
		{
			if (this.IsLogOpen)
			{
				Singleton<Log>.Instance.Info(ELogModule.AndroidBack, ELogAuthor.XXJ, "loading界面打开", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			return;
		}
		if (this.IsLogOpen)
		{
			Singleton<Log>.Instance.Info(ELogModule.AndroidBack, ELogAuthor.XXJ, "当前处于主界面并且不在loading界面", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		ControllerBase<ConfirmBoxController>.Instance.ShowReturnLoginConfirmBox();
	}

	// Token: 0x0600AA6A RID: 43626 RVA: 0x002D745C File Offset: 0x002D565C
	private void ClickButtonInternal(UUIAndroidBackComponent component)
	{
		TsLguiEventSystemActor lguiEventSystemActor = Singleton<LguiEventSystemManager>.Instance.LguiEventSystemActor;
		if (lguiEventSystemActor != null)
		{
			lguiEventSystemActor.SimulateClickButton(1, component.RootUIComp, new FVector2D?(component.ClickPivot));
		}
	}

	// Token: 0x0600AA6B RID: 43627 RVA: 0x002D7495 File Offset: 0x002D5695
	protected override bool OnClear()
	{
		UUIAndroidBackComponent.ClearAndroidBackComponent();
		return true;
	}

	// Token: 0x0600AA6C RID: 43628 RVA: 0x002D74A0 File Offset: 0x002D56A0
	public void GmTestAndroidBack()
	{
		if (this.TestAndroidBack != null)
		{
			this.CloseTestAndroidBack();
			return;
		}
		UPrefabAsset prefabAsset = Singleton<ResourceSystem>.Instance.Load<UPrefabAsset>("/Game/Aki/UI/UIResources/Common/Prefabs/UiItem_BackBtn1.UiItem_BackBtn1", "Debug");
		this.TestAndroidBack = ULGUIBPLibrary.LoadPrefabWithAsset(GlobalData.World, prefabAsset, Singleton<UiLayer>.Instance.GetLayerRootUiItem(ELayerType.Debug));
		UUIItem uuiitem = this.TestAndroidBack.GetComponentByClass(UUIItem.StaticClass()) as UUIItem;
		uuiitem.SetDisplayName("GmTestAndroidBack");
		uuiitem.SetAnchorAlign(UIAnchorHorizontalAlign.Center, UIAnchorVerticalAlign.Middle);
		uuiitem.SetAnchorOffset(new FVector2D(0f, 0f));
		UUIButtonComponent uuibuttonComponent = this.TestAndroidBack.GetComponentByClass(UUIButtonComponent.StaticClass()) as UUIButtonComponent;
		UUIAndroidBackComponent uuiandroidBackComponent = this.TestAndroidBack.GetComponentByClass(UUIAndroidBackComponent.StaticClass()) as UUIAndroidBackComponent;
		if (uuiandroidBackComponent != null)
		{
			this.TestAndroidBack.K2_DestroyComponent(uuiandroidBackComponent);
		}
		uuibuttonComponent.OnClickCallBack.Bind(delegate()
		{
			Singleton<Log>.Instance.Info(ELogModule.AndroidBack, ELogAuthor.XXJ, "安卓返回点击", default(ReadOnlySpan<ValueTuple<string, object>>));
			ControllerBase<InputDistributeController>.Instance.InputKey("Android_Back", true);
			ControllerBase<InputDistributeController>.Instance.InputKey("Android_Back", false);
		});
		Singleton<LguiUtil>.Instance.SetActorIsPermanent(this.TestAndroidBack, true, true);
	}

	// Token: 0x0600AA6D RID: 43629 RVA: 0x002D75B1 File Offset: 0x002D57B1
	private void CloseTestAndroidBack()
	{
		(this.TestAndroidBack.GetComponentByClass(UUIButtonComponent.StaticClass()) as UUIButtonComponent).OnClickCallBack.Unbind();
		this.TestAndroidBack.K2_DestroyActor();
		this.TestAndroidBack = null;
	}

	// Token: 0x04005015 RID: 20501
	private const int ANDROID_BACK_POINT_ID = 1;

	// Token: 0x04005016 RID: 20502
	public bool IsLogOpen;

	// Token: 0x04005017 RID: 20503
	[Nullable(2)]
	private AActor TestAndroidBack;
}
