using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.ActivityGamePlay.Drinks;
using CSharpScript.Game.Module.UiCameraAnimation;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001008 RID: 4104
[NullableContext(1)]
[Nullable(0)]
public class DrinksGamePlayMainView : UiTickViewBase, IUiCameraBehavior
{
	// Token: 0x06006A98 RID: 27288 RVA: 0x001BD7EF File Offset: 0x001BB9EF
	public DrinksGamePlayMainView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06006A99 RID: 27289 RVA: 0x001BD804 File Offset: 0x001BBA04
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIItem)),
			new ValueTuple<int, Type>(10, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(4, new Action(this.OnClickedBack))
		};
	}

	// Token: 0x06006A9A RID: 27290 RVA: 0x001BD934 File Offset: 0x001BBB34
	protected override UniTask OnBeforeStartAsync()
	{
		DrinksGamePlayMainView.<OnBeforeStartAsync>d__19 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<DrinksGamePlayMainView.<OnBeforeStartAsync>d__19>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06006A9B RID: 27291 RVA: 0x001BD977 File Offset: 0x001BBB77
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseHelp));
	}

	// Token: 0x06006A9C RID: 27292 RVA: 0x001BD992 File Offset: 0x001BBB92
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseHelp));
	}

	// Token: 0x06006A9D RID: 27293 RVA: 0x001BD9AD File Offset: 0x001BBBAD
	protected override void OnStart()
	{
		this.QTELevelSequence = new LevelSequencePlayer(this.RootItem);
		this.QTELevelSequence.BindSequenceCloseEvent(new TSequenceEndEvent(this.OnQTESequenceEnd), false);
		this.OnGameCurrentStepStart();
	}

	// Token: 0x06006A9E RID: 27294 RVA: 0x001BD9DE File Offset: 0x001BBBDE
	protected override void OnBeforeShow()
	{
		this.PauseTimeDilation();
		Singleton<UiCameraAnimationManager>.Instance.DisablePlayerActor();
	}

	// Token: 0x06006A9F RID: 27295 RVA: 0x001BD9F0 File Offset: 0x001BBBF0
	protected override void OnBeforeHide()
	{
		this.ResumeTimeDilation();
	}

	// Token: 0x06006AA0 RID: 27296 RVA: 0x001BD9F8 File Offset: 0x001BBBF8
	protected override void OnBeforeDestroy()
	{
		if (this.NeedShowPlayer && ModelBase<DrinksModel>.Instance.GameplayOpenWay == EDrinksGameplayOpenWay.FromEntityNPC)
		{
			Singleton<UiCameraAnimationManager>.Instance.EnablePlayerActor();
		}
		ModelBase<DrinksModel>.Instance.RegisterProxy(false);
	}

	// Token: 0x06006AA1 RID: 27297 RVA: 0x001BDA24 File Offset: 0x001BBC24
	protected void PauseTimeDilation()
	{
		Singleton<UiTimeDilation>.Instance.AddWaitSetTimeDilationTag("DrinksGamePlayMainView");
	}

	// Token: 0x06006AA2 RID: 27298 RVA: 0x001BDA35 File Offset: 0x001BBC35
	protected void ResumeTimeDilation()
	{
		Singleton<UiTimeDilation>.Instance.DeleteWaitSetTimeDilationTag("DrinksGamePlayMainView");
	}

	// Token: 0x06006AA3 RID: 27299 RVA: 0x001BDA46 File Offset: 0x001BBC46
	public void PushCameraHandle(EUiViewName viewName, int viewId, bool isBlend)
	{
		if (!this.HasInitCamera)
		{
			this.CurCameraName = viewName.ToString();
			this.HasInitCamera = true;
			ControllerBase<UiCameraAnimationController>.Instance.PushCameraHandle(viewName, new int?(viewId), isBlend);
		}
	}

	// Token: 0x06006AA4 RID: 27300 RVA: 0x001BDA7C File Offset: 0x001BBC7C
	public void PushCamera(string cameraName)
	{
		if (cameraName != this.CurCameraName && this.HasInitCamera)
		{
			this.CurCameraName = cameraName;
			UiCameraMapping? uiCameraMappingConfig = ConfigBase<UiCameraAnimationConfig>.Instance.GetUiCameraMappingConfig(cameraName);
			Singleton<UiCameraAnimationManager>.Instance.PushCameraHandleByHandleName(uiCameraMappingConfig.Value.DefaultUiCameraSettingsName, true, true, "1001", false, null, null);
		}
	}

	// Token: 0x06006AA5 RID: 27301 RVA: 0x001BDADE File Offset: 0x001BBCDE
	public void PopCameraHandle(EUiViewName viewName, UiViewInfo stackTopInfo, int closeViewId, bool popOrDelete)
	{
		ControllerBase<UiCameraAnimationController>.Instance.PopCameraHandle(viewName, stackTopInfo, closeViewId, popOrDelete);
	}

	// Token: 0x06006AA6 RID: 27302 RVA: 0x001BDAEF File Offset: 0x001BBCEF
	protected override void OnTick(float delta)
	{
		if (this.NeedTickQTE && !this.StopTickOnClickClose)
		{
			this.QTEPanel.OnTick(delta);
		}
	}

	// Token: 0x06006AA7 RID: 27303 RVA: 0x001BDB0D File Offset: 0x001BBD0D
	protected void RegisterProxy()
	{
		DrinksModel instance = ModelBase<DrinksModel>.Instance;
		instance.RegisterProxy(true);
		instance.GetProxy().RegisterMainView(this);
	}

	// Token: 0x06006AA8 RID: 27304 RVA: 0x001BDB28 File Offset: 0x001BBD28
	public void OnGameCurrentStepStart()
	{
		PopupCaptionItem captionItem = this.CaptionItem;
		if (captionItem != null)
		{
			captionItem.SetCloseBtnActive(true);
		}
		PopupCaptionItem captionItem2 = this.CaptionItem;
		if (captionItem2 != null)
		{
			captionItem2.SetHelpBtnActive(true);
		}
		this.StopTickOnClickClose = false;
		this.RefreshButtonState(false);
		this.QTEPanel.SetUiActive(false);
		this.TopPanel.UpdateStep();
		this.CurValuePanel.UpdateStep();
		LevelSequencePlayer qtelevelSequence = this.QTELevelSequence;
		if (qtelevelSequence != null)
		{
			qtelevelSequence.PlayLevelSequenceByName("RigthUIin", false, null, false);
		}
		this.MenuPanel.UpdateOnStepStart();
		this.BubblePanel.UpdateState(false);
		this.BubbleFlavorPanel.RefreshOnStart();
		if (ModelBase<DrinksModel>.Instance.GetCurStep() < EDrinksPlayStep.Ornament)
		{
			this.PushCamera("DrinksGameplayView");
			return;
		}
		int roleId = ModelBase<DrinksModel>.Instance.GetRoleId();
		this.PushCamera(ConfigBase<DrinksConfig>.Instance.GetInviteConfigByRole(roleId).Value.OrnamentCamera);
	}

	// Token: 0x06006AA9 RID: 27305 RVA: 0x001BDC11 File Offset: 0x001BBE11
	public void OnGameCurrentStepEnd()
	{
		this.RefreshButtonState(true);
		this.TopPanel.UpdateStepItem();
		this.BubblePanel.HideBubble();
	}

	// Token: 0x06006AAA RID: 27306 RVA: 0x001BDC30 File Offset: 0x001BBE30
	public void OnDrinkBaseSelected(int drinkId, bool isEnd)
	{
		DrinksTopStepPanel topPanel = this.TopPanel;
		if (topPanel != null)
		{
			topPanel.UpdateStepItem();
		}
		this.BubblePanel.UpdateState(isEnd);
		DrinksCurrentStatePanel curValuePanel = this.CurValuePanel;
		if (curValuePanel == null)
		{
			return;
		}
		curValuePanel.OnDrinkSelected(drinkId);
	}

	// Token: 0x06006AAB RID: 27307 RVA: 0x001BDC60 File Offset: 0x001BBE60
	public void OnBatchingSelected(HashSet<int> batchingSet, bool isEnd)
	{
		DrinksTopStepPanel topPanel = this.TopPanel;
		if (topPanel != null)
		{
			topPanel.UpdateStepItem();
		}
		if (isEnd && batchingSet.Count > 0)
		{
			DrinksMenuPanel menuPanel = this.MenuPanel;
			if (menuPanel != null)
			{
				menuPanel.SetRaycastOnStepEnd();
			}
		}
		this.BubblePanel.UpdateState(isEnd);
		DrinksCurrentStatePanel curValuePanel = this.CurValuePanel;
		if (curValuePanel == null)
		{
			return;
		}
		curValuePanel.OnBatchingSelected(batchingSet);
	}

	// Token: 0x06006AAC RID: 27308 RVA: 0x001BDCB8 File Offset: 0x001BBEB8
	public void OnNoBatchingConfirm()
	{
		DrinksMenuPanel menuPanel = this.MenuPanel;
		if (menuPanel == null)
		{
			return;
		}
		menuPanel.SetRaycastOnStepEnd();
	}

	// Token: 0x06006AAD RID: 27309 RVA: 0x001BDCCA File Offset: 0x001BBECA
	public void OnOrnamentSelected(bool isEnd)
	{
		if (isEnd)
		{
			DrinksMenuPanel menuPanel = this.MenuPanel;
			if (menuPanel != null)
			{
				menuPanel.SetRaycastOnStepEnd();
			}
		}
		DrinksRoleStateItem roleStatePanel = this.RoleStatePanel;
		if (roleStatePanel != null)
		{
			roleStatePanel.RefreshCurState();
		}
		DrinksTopStepPanel topPanel = this.TopPanel;
		if (topPanel == null)
		{
			return;
		}
		topPanel.UpdateStepItem();
	}

	// Token: 0x06006AAE RID: 27310 RVA: 0x001BDD04 File Offset: 0x001BBF04
	public void OnEnterDrinkBaseQTE()
	{
		this.RefreshButtonState(true);
		this.DialogBubble.DeactivateBubble(true);
		DrinksMenuPanel menuPanel = this.MenuPanel;
		if (menuPanel != null)
		{
			menuPanel.SetRaycastOnStepEnd();
		}
		LevelSequencePlayer qtelevelSequence = this.QTELevelSequence;
		if (qtelevelSequence != null)
		{
			qtelevelSequence.PlayLevelSequenceByName("RigthUIout", false, null, false);
		}
		this.QTEPanel.StartQTE();
		this.BubblePanel.HideBubble();
	}

	// Token: 0x06006AAF RID: 27311 RVA: 0x001BDD6C File Offset: 0x001BBF6C
	public void UpdateRoleRequire()
	{
		DrinksRoleStateItem roleStatePanel = this.RoleStatePanel;
		if (roleStatePanel == null)
		{
			return;
		}
		roleStatePanel.RefreshCurState();
	}

	// Token: 0x06006AB0 RID: 27312 RVA: 0x001BDD80 File Offset: 0x001BBF80
	public void UpdateFlavorBubble()
	{
		this.RefreshButtonState(true);
		this.DialogBubble.DeactivateBubble(true);
		this.CurValuePanel.RefreshOnEnterSeq();
		if (ModelBase<DrinksModel>.Instance.GetCurStep() > EDrinksPlayStep.Drink2)
		{
			DrinksMenuPanel menuPanel = this.MenuPanel;
			if (menuPanel != null)
			{
				menuPanel.SetRaycastOnStepEnd();
			}
			LevelSequencePlayer qtelevelSequence = this.QTELevelSequence;
			if (qtelevelSequence != null)
			{
				qtelevelSequence.PlayLevelSequenceByName("RigthUIout", false, null, false);
			}
		}
		this.BubblePanel.HideBubble();
		this.BubbleFlavorPanel.Refresh();
	}

	// Token: 0x06006AB1 RID: 27313 RVA: 0x001BDE00 File Offset: 0x001BC000
	public void ActivateDialogBubble(string config, bool isLike)
	{
		this.DialogBubble.ActivateBubble(config, isLike);
	}

	// Token: 0x06006AB2 RID: 27314 RVA: 0x001BDE0F File Offset: 0x001BC00F
	public void DeactivateDialogBubble()
	{
		this.DialogBubble.DeactivateBubble(true);
	}

	// Token: 0x06006AB3 RID: 27315 RVA: 0x001BDE1D File Offset: 0x001BC01D
	public int ShowBackMask(EDrinksPlayStep curStep)
	{
		return this.MaskPanel.ShowBackMask(curStep);
	}

	// Token: 0x06006AB4 RID: 27316 RVA: 0x001BDE2C File Offset: 0x001BC02C
	protected void RefreshButtonState(bool isEnd = false)
	{
		bool flag = ModelBase<DrinksModel>.Instance.GetCurStep() > EDrinksPlayStep.Drink1;
		UUIButtonComponent button = base.GetButton(4);
		if (button == null)
		{
			return;
		}
		UUIItem uuiitem = button.RootUIComp.Get();
		if (uuiitem == null)
		{
			return;
		}
		uuiitem.SetUIActive(flag && !isEnd);
	}

	// Token: 0x06006AB5 RID: 27317 RVA: 0x001BDE74 File Offset: 0x001BC074
	public void SetNeedTickQTE(bool value)
	{
		this.NeedTickQTE = value;
		if (!value)
		{
			LevelSequencePlayer qtelevelSequence = this.QTELevelSequence;
			if (qtelevelSequence != null && qtelevelSequence.IsPlayingSequence("Qtein"))
			{
				LevelSequencePlayer qtelevelSequence2 = this.QTELevelSequence;
				if (qtelevelSequence2 != null)
				{
					qtelevelSequence2.StopCurrentSequence(false, true);
				}
			}
			TimerSystem.Instance.Delay(delegate(float _)
			{
				LevelSequencePlayer qtelevelSequence4 = this.QTELevelSequence;
				if (qtelevelSequence4 == null)
				{
					return;
				}
				qtelevelSequence4.PlayLevelSequenceByName("Qteout", false, null, false);
			}, 1000f, null, null, true, 1f);
			return;
		}
		LevelSequencePlayer qtelevelSequence3 = this.QTELevelSequence;
		if (qtelevelSequence3 == null)
		{
			return;
		}
		qtelevelSequence3.PlayLevelSequenceByName("Qtein", false, null, false);
	}

	// Token: 0x06006AB6 RID: 27318 RVA: 0x001BDEFC File Offset: 0x001BC0FC
	public void SetShakeCamera(ACameraActor camera)
	{
		ControllerBase<UiCameraAnimationController>.Instance.DeepCopyCamera(camera);
		CameraController instance = ControllerBase<CameraController>.Instance;
		UiCamera uiCamera = Singleton<UiCameraAnimationManager>.Instance.UiCamera;
		instance.SetViewTarget((uiCamera != null) ? uiCamera.GetCameraActor() : null, "DrinksGameplayView", 0f, EViewTargetBlendFunction.VTBlend_Linear, 0f, null, null, "MainCamera", null, null);
	}

	// Token: 0x06006AB7 RID: 27319 RVA: 0x001BDF5D File Offset: 0x001BC15D
	public void HideCaptionClose()
	{
		PopupCaptionItem captionItem = this.CaptionItem;
		if (captionItem != null)
		{
			captionItem.SetCloseBtnActive(false);
		}
		PopupCaptionItem captionItem2 = this.CaptionItem;
		if (captionItem2 == null)
		{
			return;
		}
		captionItem2.SetHelpBtnActive(false);
	}

	// Token: 0x06006AB8 RID: 27320 RVA: 0x001BDF84 File Offset: 0x001BC184
	private void OnClickCloseButton()
	{
		this.StopTickOnClickClose = true;
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.DrinkCloseConfirm);
		confirmBoxDataNew.IsEscViewTriggerCallBack = false;
		confirmBoxDataNew.FunctionMap[0] = delegate()
		{
			this.StopTickOnClickClose = false;
		};
		confirmBoxDataNew.FunctionMap[1] = delegate()
		{
			this.NeedTickQTE = false;
			ModelBase<DrinksModel>.Instance.RestartGame();
			Singleton<EventSystem>.Instance.Emit(EEventName.NotifyGuideBreakFocus);
		};
		confirmBoxDataNew.FunctionMap[2] = delegate()
		{
			DrinksSceneController sceneController = ModelBase<DrinksModel>.Instance.GetSceneController();
			if (ModelBase<DrinksModel>.Instance.GameplayOpenWay == EDrinksGameplayOpenWay.FromEntityNPC)
			{
				sceneController.ShowNpc();
			}
			sceneController.Destroy(true);
			this.NeedShowPlayer = true;
			base.CloseMe(null);
			if (ModelBase<DrinksModel>.Instance.GameplayIsMainQuest)
			{
				ModelBase<DrinksModel>.Instance.HideMainQuestNpcByEntityId();
			}
		};
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x06006AB9 RID: 27321 RVA: 0x001BE000 File Offset: 0x001BC200
	private void OnClickedBack()
	{
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.DrinkPrevConfirm);
		confirmBoxDataNew.FunctionMap[2] = delegate()
		{
			ModelBase<DrinksModel>.Instance.BackToPrevStep();
		};
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		Singleton<EventSystem>.Instance.Emit(EEventName.NotifyGuideBreakFocus);
	}

	// Token: 0x06006ABA RID: 27322 RVA: 0x001BE05F File Offset: 0x001BC25F
	private void OnQTESequenceEnd(string seqName)
	{
		if (seqName == "RigthUIout")
		{
			Singleton<UiLayer>.Instance.SetShowMaskLayer(EUiViewName.DrinksGameplayView, false);
			return;
		}
		if (seqName == "Qteout")
		{
			this.QTEPanel.OnFadeSequenceEnd();
		}
	}

	// Token: 0x06006ABB RID: 27323 RVA: 0x001BE09C File Offset: 0x001BC29C
	public void OnFinishMixing()
	{
		this.DeactivateDialogBubble();
		base.SetUiActive(false);
	}

	// Token: 0x06006ABC RID: 27324 RVA: 0x001BE0AC File Offset: 0x001BC2AC
	public void OnFinishMixingEnd()
	{
		DrinksResultInfo currentPlayData = ModelBase<DrinksModel>.Instance.GetCurrentPlayData();
		DrinksShowInfo param = new DrinksShowInfo
		{
			Data = currentPlayData,
			RoleId = ModelBase<DrinksModel>.Instance.GetRoleId(),
			IsGamePlay = true
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.DrinksShowView, param, delegate(bool _, int _)
		{
			this.NeedShowPlayer = false;
			base.CloseMe(null);
		});
	}

	// Token: 0x06006ABD RID: 27325 RVA: 0x001BE104 File Offset: 0x001BC304
	private void OnCloseHelp(EUiViewName viewName, int viewId)
	{
		if (viewName.ToString() != EUiViewName.HelpView.ToString())
		{
			return;
		}
		this.StopTickOnClickClose = false;
	}

	// Token: 0x06006ABE RID: 27326 RVA: 0x001BE134 File Offset: 0x001BC334
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
	{
		if (!(configParams[0] == "Ornament"))
		{
			return null;
		}
		int num = (int)float.Parse(configParams[1]);
		if (num == 0)
		{
			return null;
		}
		UUIItem uuiitem = this.MenuPanel.GuideGetOrnamentItem(num);
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

	// Token: 0x04003299 RID: 12953
	private PopupCaptionItem CaptionItem;

	// Token: 0x0400329A RID: 12954
	protected DrinksRoleStateItem RoleStatePanel;

	// Token: 0x0400329B RID: 12955
	protected DrinksTopStepPanel TopPanel;

	// Token: 0x0400329C RID: 12956
	protected DrinksMenuPanel MenuPanel;

	// Token: 0x0400329D RID: 12957
	protected DrinksCurrentStatePanel CurValuePanel;

	// Token: 0x0400329E RID: 12958
	protected DrinksQTEPanel QTEPanel;

	// Token: 0x0400329F RID: 12959
	protected DrinksBubblePanel BubblePanel;

	// Token: 0x040032A0 RID: 12960
	protected DrinksFlavorBubblePanel BubbleFlavorPanel;

	// Token: 0x040032A1 RID: 12961
	protected DrinksDialogBubble DialogBubble;

	// Token: 0x040032A2 RID: 12962
	protected DrinksBlackMask MaskPanel;

	// Token: 0x040032A3 RID: 12963
	public bool NeedTickQTE;

	// Token: 0x040032A4 RID: 12964
	protected bool StopTickOnClickClose;

	// Token: 0x040032A5 RID: 12965
	[Nullable(2)]
	protected LevelSequencePlayer QTELevelSequence;

	// Token: 0x040032A6 RID: 12966
	protected bool NeedShowPlayer;

	// Token: 0x040032A7 RID: 12967
	protected string CurCameraName = "";

	// Token: 0x040032A8 RID: 12968
	protected bool HasInitCamera;

	// Token: 0x020073EA RID: 29674
	[NullableContext(0)]
	private static class EDefine
	{
		// Token: 0x040281A3 RID: 164259
		public const int CaptionItem = 0;

		// Token: 0x040281A4 RID: 164260
		public const int PanelRoleState = 1;

		// Token: 0x040281A5 RID: 164261
		public const int PanelTopStep = 2;

		// Token: 0x040281A6 RID: 164262
		public const int PanelMenu = 3;

		// Token: 0x040281A7 RID: 164263
		public const int BtnPrevious = 4;

		// Token: 0x040281A8 RID: 164264
		public const int PanelTasteState = 5;

		// Token: 0x040281A9 RID: 164265
		public const int PanelQTE = 6;

		// Token: 0x040281AA RID: 164266
		public const int PanelAddType1 = 7;

		// Token: 0x040281AB RID: 164267
		public const int PanelAddType2 = 8;

		// Token: 0x040281AC RID: 164268
		public const int PanelBlackScreen = 9;

		// Token: 0x040281AD RID: 164269
		public const int ItemBubble = 10;
	}
}
