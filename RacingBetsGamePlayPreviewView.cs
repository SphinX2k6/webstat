using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.RacingBets;
using CSharpScript.Game.Module.UiCameraAnimation.UiCameraContext;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200273B RID: 10043
[NullableContext(1)]
[Nullable(0)]
public class RacingBetsGamePlayPreviewView : UiViewBase, IUiCameraBehavior
{
	// Token: 0x06013CED RID: 81133 RVA: 0x0058358D File Offset: 0x0058178D
	public RacingBetsGamePlayPreviewView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06013CEE RID: 81134 RVA: 0x005835A4 File Offset: 0x005817A4
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIDraggableComponent)),
			new ValueTuple<int, Type>(5, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(8, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(10, typeof(UUISprite)),
			new ValueTuple<int, Type>(11, typeof(UUISprite)),
			new ValueTuple<int, Type>(12, typeof(UUISprite)),
			new ValueTuple<int, Type>(13, typeof(UUISprite)),
			new ValueTuple<int, Type>(14, typeof(UUISprite)),
			new ValueTuple<int, Type>(15, typeof(UUIText)),
			new ValueTuple<int, Type>(16, typeof(UUIText)),
			new ValueTuple<int, Type>(17, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnClickCloseButton)),
			new ValueTuple<int, Delegate>(5, new Action<EToggleState>(this.OnToggleClick)),
			new ValueTuple<int, Delegate>(7, new Action(this.OnDangoSkillBtnClick))
		};
	}

	// Token: 0x06013CEF RID: 81135 RVA: 0x00583778 File Offset: 0x00581978
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnActivateUiCameraAnimationHandle, new Action<UiCameraHandleData>(this.OnActivateUiCameraAnimationHandle));
		ControllerBase<InputDistributeController>.Instance.BindAxis("UiMoveForward", new TInputHandle<float>(this.OnUiMove));
		ControllerBase<InputDistributeController>.Instance.BindAxis("UiMoveRight", new TInputHandle<float>(this.OnUiMove));
		UUIDraggableComponent draggable = base.GetDraggable(4);
		if (draggable == null)
		{
			return;
		}
		draggable.OnPointerDownCallBack.Bind(delegate(ULGUIPointerEventData _)
		{
			this.OnMovedCallback();
		});
	}

	// Token: 0x06013CF0 RID: 81136 RVA: 0x005837FC File Offset: 0x005819FC
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnActivateUiCameraAnimationHandle, new Action<UiCameraHandleData>(this.OnActivateUiCameraAnimationHandle));
		ControllerBase<InputDistributeController>.Instance.UnBindAxis("UiMoveForward", new TInputHandle<float>(this.OnUiMove));
		ControllerBase<InputDistributeController>.Instance.UnBindAxis("UiMoveRight", new TInputHandle<float>(this.OnUiMove));
		UUIDraggableComponent draggable = base.GetDraggable(4);
		if (draggable == null)
		{
			return;
		}
		draggable.OnPointerDownCallBack.Unbind();
	}

	// Token: 0x06013CF1 RID: 81137 RVA: 0x00583874 File Offset: 0x00581A74
	protected override UniTask OnBeforeStartAsync()
	{
		RacingBetsGamePlayPreviewView.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<RacingBetsGamePlayPreviewView.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06013CF2 RID: 81138 RVA: 0x005838B7 File Offset: 0x00581AB7
	public void PushCameraHandle(EUiViewName viewName, int viewId, bool isBlend)
	{
		ControllerBase<UiCameraAnimationController>.Instance.PushCameraHandle(viewName, new int?(viewId), true);
	}

	// Token: 0x06013CF3 RID: 81139 RVA: 0x005838CC File Offset: 0x00581ACC
	protected override void OnBeforeShow()
	{
		UUIItem item = base.GetItem(17);
		if (item != null)
		{
			item.SetUIActive(true);
		}
		int valueOrDefault = ConfigCommonParamById.GetIntConfig("RacingBetsPreviewViewIntervalTime").GetValueOrDefault(5000);
		this.TimerHandle = TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
		{
			this.TimerHandle = null;
			UUIItem item2 = base.GetItem(17);
			if (item2 != null)
			{
				item2.SetUIActive(true);
			}
			base.PlaySequence("DragTipsShow", null, false);
			this.IsDragTipShowed = true;
		}, (float)valueOrDefault, null, null, true, 1f);
	}

	// Token: 0x06013CF4 RID: 81140 RVA: 0x0058392B File Offset: 0x00581B2B
	protected override void OnBeforeHide()
	{
		TimerHandle timerHandle = this.TimerHandle;
		if (timerHandle != null)
		{
			timerHandle.Remove();
		}
		this.TimerHandle = null;
	}

	// Token: 0x06013CF5 RID: 81141 RVA: 0x00583948 File Offset: 0x00581B48
	[NullableContext(2)]
	public void PopCameraHandle(EUiViewName viewName, UiViewInfo stackTopInfo, int closeViewId, bool popOrDelete)
	{
		if (this.CanCameraInput)
		{
			FreeCamera freeCamera = ControllerBase<CameraController>.Instance.MainModel.FreeCamera;
			if (freeCamera != null)
			{
				FreeCameraInputComponent inputComponent = freeCamera.InputComponent;
				if (inputComponent != null)
				{
					inputComponent.ResetInputData();
				}
			}
			FreeCamera freeCamera2 = ControllerBase<CameraController>.Instance.MainModel.FreeCamera;
			if (freeCamera2 != null)
			{
				FreeCameraInputComponent inputComponent2 = freeCamera2.InputComponent;
				if (inputComponent2 != null)
				{
					inputComponent2.UnBindAxes();
				}
			}
		}
		ControllerBase<UiCameraAnimationController>.Instance.DeepCopyCamera(ControllerBase<CameraController>.Instance.MainModel.FreeCamera.DisplayComponent.CameraActor);
		CameraController instance = ControllerBase<CameraController>.Instance;
		UiCamera uiCamera = Singleton<UiCameraAnimationManager>.Instance.UiCamera;
		instance.SetViewTarget((uiCamera != null) ? uiCamera.GetCameraActor() : null, "RacingBetsGamePlayPreviewView", 0f, EViewTargetBlendFunction.VTBlend_Linear, 0f, null, null, "MainCamera", null, null);
		ControllerBase<UiCameraAnimationController>.Instance.PopCameraHandle(viewName, stackTopInfo, closeViewId, popOrDelete);
	}

	// Token: 0x06013CF6 RID: 81142 RVA: 0x00583A24 File Offset: 0x00581C24
	private void OnActivateUiCameraAnimationHandle(UiCameraHandleData handleData)
	{
		if (handleData.ViewName == EUiViewName.RacingBetsGamePlayPreviewView && this.CanCameraInput)
		{
			ControllerBase<CameraController>.Instance.MainModel.FreeCamera.LogicComponent.InitConfig(RacingBetsGamePlayPreviewView.ToFloatArray(ConfigCommonParamById.GetIntArrayConfig("RacingBetsPreviewViewCameraIdList"), RacingBetsGamePlayPreviewView.defaultFreeCameraConfigList));
			ControllerBase<CameraController>.Instance.MainModel.FreeCamera.InputComponent.CanCameraInput = true;
			ControllerBase<CameraController>.Instance.MainModel.FreeCamera.InputComponent.SetIsMoveBySelf(false);
			ControllerBase<CameraController>.Instance.MainModel.FreeCamera.InputComponent.BindAxes(base.GetDraggable(4));
			ControllerBase<UiCameraAnimationController>.Instance.ExitUiCameraMode();
		}
	}

	// Token: 0x06013CF7 RID: 81143 RVA: 0x00583AE1 File Offset: 0x00581CE1
	private RacingBetsPreviewViewOrganItem CreateOrganItem()
	{
		return new RacingBetsPreviewViewOrganItem
		{
			OnToggleCallBack = new Action<int, int>(this.OnOrganItemClick)
		};
	}

	// Token: 0x06013CF8 RID: 81144 RVA: 0x00583AFC File Offset: 0x00581CFC
	private void OnOrganItemClick(int index, int id)
	{
		GenericLayout<RacingBetsPreviewViewOrganItem, int> organLayout = this.OrganLayout;
		if (organLayout != null)
		{
			organLayout.SelectGridProxy(index, false);
		}
		RacingBetsOrgan? organConfig = ConfigBase<RacingBetsConfig>.Instance.GetOrganConfig(id);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(15), organConfig.Value.Name, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(16), organConfig.Value.Description, Array.Empty<object>());
		int num = 10 + index;
		for (int i = 10; i <= 14; i++)
		{
			UUISprite sprite = base.GetSprite(i);
			if (sprite != null)
			{
				sprite.SetUIActive(i == num);
			}
		}
	}

	// Token: 0x06013CF9 RID: 81145 RVA: 0x00583B9D File Offset: 0x00581D9D
	private void OnClickCloseButton()
	{
		ModelBase<RacingBetsModel>.Instance.CloseDangoGamePlayPreviewView();
	}

	// Token: 0x06013CFA RID: 81146 RVA: 0x00583BAC File Offset: 0x00581DAC
	private void OnToggleClick(EToggleState state)
	{
		bool hide = state == EToggleState.ETT_Checked;
		string sequenceName = hide ? "Hide" : "Show";
		base.PlaySequence(sequenceName, delegate
		{
			UUIItem item = this.GetItem(6);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(!hide);
		}, false);
	}

	// Token: 0x06013CFB RID: 81147 RVA: 0x00583BFC File Offset: 0x00581DFC
	private void OnDangoSkillBtnClick()
	{
		if (this.CanCameraInput)
		{
			FreeCamera freeCamera = ControllerBase<CameraController>.Instance.MainModel.FreeCamera;
			if (freeCamera != null)
			{
				FreeCameraInputComponent inputComponent = freeCamera.InputComponent;
				if (inputComponent != null)
				{
					inputComponent.UnBindAxes();
				}
			}
		}
		ControllerBase<InputDistributeController>.Instance.UnBindAxis("UiMoveForward", new TInputHandle<float>(this.OnUiMove));
		ControllerBase<InputDistributeController>.Instance.UnBindAxis("UiMoveRight", new TInputHandle<float>(this.OnUiMove));
		RacingBetsDangoSkillViewParam param = new RacingBetsDangoSkillViewParam
		{
			DangoList = this.DungeonDangoSortList,
			CloseCallback = new Action(this.OnDangoSkillViewClose)
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.RacingBetsDangoSkillView, param, null);
	}

	// Token: 0x06013CFC RID: 81148 RVA: 0x00583CA4 File Offset: 0x00581EA4
	private void OnDangoSkillViewClose()
	{
		if (this.CanCameraInput)
		{
			FreeCamera freeCamera = ControllerBase<CameraController>.Instance.MainModel.FreeCamera;
			if (freeCamera != null)
			{
				FreeCameraInputComponent inputComponent = freeCamera.InputComponent;
				if (inputComponent != null)
				{
					inputComponent.BindAxes(base.GetDraggable(4));
				}
			}
		}
		ControllerBase<InputDistributeController>.Instance.BindAxis("UiMoveForward", new TInputHandle<float>(this.OnUiMove));
		ControllerBase<InputDistributeController>.Instance.BindAxis("UiMoveRight", new TInputHandle<float>(this.OnUiMove));
	}

	// Token: 0x06013CFD RID: 81149 RVA: 0x00583D1C File Offset: 0x00581F1C
	private void OnMovedCallback()
	{
		TimerHandle timerHandle = this.TimerHandle;
		if (timerHandle != null)
		{
			timerHandle.Remove();
		}
		this.TimerHandle = null;
		if (this.IsDragTipShowed)
		{
			base.PlaySequence("DragTipsHide", delegate
			{
				UUIItem item = base.GetItem(17);
				if (item == null)
				{
					return;
				}
				item.SetUIActive(false);
			}, false);
		}
		UUIDraggableComponent draggable = base.GetDraggable(4);
		if (draggable != null)
		{
			draggable.OnPointerDownCallBack.Unbind();
		}
		ControllerBase<InputDistributeController>.Instance.UnBindAxis("UiMoveForward", new TInputHandle<float>(this.OnUiMove));
		ControllerBase<InputDistributeController>.Instance.UnBindAxis("UiMoveRight", new TInputHandle<float>(this.OnUiMove));
	}

	// Token: 0x06013CFE RID: 81150 RVA: 0x00583DAF File Offset: 0x00581FAF
	protected void OnUiMove(string axisName, float value, InputIdentification inputIdentification)
	{
		if (value == 0f)
		{
			return;
		}
		this.OnMovedCallback();
	}

	// Token: 0x06013D00 RID: 81152 RVA: 0x00583DD4 File Offset: 0x00581FD4
	private static float[] ToFloatArray([Nullable(2)] IReadOnlyList<int> intList, int[] fallback)
	{
		IReadOnlyList<int> readOnlyList = intList ?? fallback;
		float[] array = new float[readOnlyList.Count];
		for (int i = 0; i < readOnlyList.Count; i++)
		{
			array[i] = (float)readOnlyList[i];
		}
		return array;
	}

	// Token: 0x04009A21 RID: 39457
	private bool CanCameraInput;

	// Token: 0x04009A22 RID: 39458
	private List<RacingBetsDungeonDangoInfo> DungeonDangoSortList = new List<RacingBetsDungeonDangoInfo>();

	// Token: 0x04009A23 RID: 39459
	private RacingBetsDangoRankPanel DangoRankPanel;

	// Token: 0x04009A24 RID: 39460
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<RacingBetsPreviewViewOrganItem, int> OrganLayout;

	// Token: 0x04009A25 RID: 39461
	[Nullable(2)]
	private TimerHandle TimerHandle;

	// Token: 0x04009A26 RID: 39462
	private bool IsDragTipShowed;

	// Token: 0x04009A27 RID: 39463
	private static readonly int[] defaultFreeCameraConfigList = new int[]
	{
		106
	};

	// Token: 0x02008AEB RID: 35563
	[NullableContext(0)]
	private class EComponent
	{
		// Token: 0x0402ED6A RID: 191850
		public const int CloseButton = 0;

		// Token: 0x0402ED6B RID: 191851
		public const int RaycastButton = 1;

		// Token: 0x0402ED6C RID: 191852
		public const int DangoPanel = 2;

		// Token: 0x0402ED6D RID: 191853
		public const int DangoItem = 3;

		// Token: 0x0402ED6E RID: 191854
		public const int Drag = 4;

		// Token: 0x0402ED6F RID: 191855
		public const int ToggleHide = 5;

		// Token: 0x0402ED70 RID: 191856
		public const int ItemHidePanel = 6;

		// Token: 0x0402ED71 RID: 191857
		public const int BtnDangoSkill = 7;

		// Token: 0x0402ED72 RID: 191858
		public const int LayoutOrgan = 8;

		// Token: 0x0402ED73 RID: 191859
		public const int ItemOrgan = 9;

		// Token: 0x0402ED74 RID: 191860
		public const int SpriteDetail1Bg = 10;

		// Token: 0x0402ED75 RID: 191861
		public const int SpriteDetail2Bg = 11;

		// Token: 0x0402ED76 RID: 191862
		public const int SpriteDetail3Bg = 12;

		// Token: 0x0402ED77 RID: 191863
		public const int SpriteDetail4Bg = 13;

		// Token: 0x0402ED78 RID: 191864
		public const int SpriteDetail5Bg = 14;

		// Token: 0x0402ED79 RID: 191865
		public const int TextName = 15;

		// Token: 0x0402ED7A RID: 191866
		public const int TextDesc = 16;

		// Token: 0x0402ED7B RID: 191867
		public const int ItemDragTip = 17;
	}
}
