using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Core.Common;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.QuickHack
{
	// Token: 0x02005301 RID: 21249
	[NullableContext(1)]
	[Nullable(0)]
	public class QuickHackCameraControlView : UiTickViewBase, IUiProhibitRefreshData
	{
		// Token: 0x060363D6 RID: 222166 RVA: 0x00DAB0BF File Offset: 0x00DA92BF
		public QuickHackCameraControlView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x060363D7 RID: 222167 RVA: 0x00DAB0D4 File Offset: 0x00DA92D4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 15;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISliderComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUISliderComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUISliderComponent));
			this.ComponentRegisterInfos = list;
			num2 = 4;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.OnLeftCameraClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(7, new Action(this.OnRightCameraClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(10, new Action(this.OnPhotoClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(11, new Action(this.OnQuickHackClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x060363D8 RID: 222168 RVA: 0x00DAB39C File Offset: 0x00DA959C
		protected override UniTask OnBeforeStartAsync()
		{
			QuickHackCameraControlView.<OnBeforeStartAsync>d__14 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<QuickHackCameraControlView.<OnBeforeStartAsync>d__14>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060363D9 RID: 222169 RVA: 0x00DAB3E0 File Offset: 0x00DA95E0
		protected override void OnStart()
		{
			this.CameraZoomAxisSpeed = ConfigCommonParamById.GetFloatConfig("CommonCameraZoomSpeed").GetValueOrDefault(1f);
			this.CameraPanel = new GenericLayout<QuickHackCameraControlItem, int>(base.GetHorizontalLayout(8), new Func<QuickHackCameraControlItem>(this.CreateCameraItem), base.GetItem(9).GetOwner() as AUIBaseActor, false, true);
			this.SequencePlayer = new UiSequencePlayer(this.RootItem);
			this.SequencePlayer.BindOnEndSequenceEvent(new Action<string>(this.OnSequenceEnd));
		}

		// Token: 0x060363DA RID: 222170 RVA: 0x00DAB464 File Offset: 0x00DA9664
		protected override void OnBeforeShow()
		{
			QuickHackModel instance = ModelBase<QuickHackModel>.Instance;
			if (this.CameraPanel != null)
			{
				List<int> cameraControlPbDataIdList = instance.CameraControlPbDataIdList;
				int currentCameraControlIndex = instance.CurrentCameraControlIndex;
				int num = (cameraControlPbDataIdList != null) ? cameraControlPbDataIdList.Count : -1;
				if (cameraControlPbDataIdList != null)
				{
					this.CameraPanel.RefreshByData(cameraControlPbDataIdList, null, false);
					this.CameraPanel.SelectGridProxy(currentCameraControlIndex, false);
				}
				if (num >= 2)
				{
					Singleton<EventSystem>.Instance.Emit<string>(EEventName.OnGuideTriggerEvent, "QuickHack_MultiCamera");
				}
			}
			this.UpdateKeyItem();
			Singleton<EventSystem>.Instance.Add<bool>(EEventName.OnShowMouseCursor, new Action<bool>(this.OnShowMouseCursor));
			Singleton<EventSystem>.Instance.Add<EInputControllerType, EInputControllerType>(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.OnInputControllerChange));
			Singleton<EventSystem>.Instance.Add<int>(EEventName.OnQuickHackCameraControlChange, new Action<int>(this.OnCameraControlChange));
			Singleton<UiProhibitFightInputCenter>.Instance.RegisterExtraRefreshData(this.ViewInfo.Name, this);
			ControllerBase<InputDistributeController>.Instance.RefreshInputTag();
			base.GetSlider(4).OnValueChangeCb.Bind(new Action<float>(this.OnSliderValueChange));
			this.UpdateZoomSliderDefaultValue();
		}

		// Token: 0x060363DB RID: 222171 RVA: 0x00DAB574 File Offset: 0x00DA9774
		protected override UniTask OnPlayingStartSequenceAsync()
		{
			QuickHackCameraControlView.<OnPlayingStartSequenceAsync>d__17 <OnPlayingStartSequenceAsync>d__;
			<OnPlayingStartSequenceAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnPlayingStartSequenceAsync>d__.<>4__this = this;
			<OnPlayingStartSequenceAsync>d__.<>1__state = -1;
			<OnPlayingStartSequenceAsync>d__.<>t__builder.Start<QuickHackCameraControlView.<OnPlayingStartSequenceAsync>d__17>(ref <OnPlayingStartSequenceAsync>d__);
			return <OnPlayingStartSequenceAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060363DC RID: 222172 RVA: 0x00DAB5B8 File Offset: 0x00DA97B8
		protected override void OnAfterShow()
		{
			UUIButtonComponent button = base.GetButton(3);
			button.OnPointDownCallBack.Bind(new Action(this.OnZoomIncreasePress));
			button.OnPointUpCallBack.Bind(new Action(this.OnZoomIncreaseRelease));
			button.OnPointCancelCallBack.Bind(new Action(this.OnZoomIncreaseRelease));
			UUIButtonComponent button2 = base.GetButton(5);
			button2.OnPointDownCallBack.Bind(new Action(this.OnZoomDecreasePress));
			button2.OnPointUpCallBack.Bind(new Action(this.OnZoomDecreaseRelease));
			button2.OnPointCancelCallBack.Bind(new Action(this.OnZoomDecreaseRelease));
			ControllerBase<InputDistributeController>.Instance.BindAxis("WheelAxis", new TInputHandle<float>(this.OnInputWheelAxis));
			if (ModelBase<QuickHackModel>.Instance.CameraControlAutoOpenQuickHack)
			{
				this.OpenQuickHack();
			}
		}

		// Token: 0x060363DD RID: 222173 RVA: 0x00DAB688 File Offset: 0x00DA9888
		protected override void OnTick(float delta)
		{
			this.UpdateCameraSlider(false);
		}

		// Token: 0x060363DE RID: 222174 RVA: 0x00DAB694 File Offset: 0x00DA9894
		private void UpdateCameraSlider(bool force = false)
		{
			Rotator cameraRotator = ModelBase<CameraModel>.Instance.MainModel.CameraRotator;
			float pitch = cameraRotator.Pitch;
			if (force || pitch != this.CameraPitch)
			{
				this.UpdateCameraPitch(pitch);
				this.CameraPitch = pitch;
			}
			float yaw = cameraRotator.Yaw;
			if (force || yaw != this.CameraYaw)
			{
				this.UpdateCameraYaw(yaw);
				this.CameraYaw = yaw;
			}
		}

		// Token: 0x060363DF RID: 222175 RVA: 0x00DAB6F4 File Offset: 0x00DA98F4
		private void UpdateCameraPitch(float pitch)
		{
			QuickHackModel instance = ModelBase<QuickHackModel>.Instance;
			float num = Singleton<MathUtils>.Instance.WrapAngle(pitch - instance.CameraControlDefaultPitch);
			float inValue = 0.5f;
			float cameraControlPitchMin = instance.CameraControlPitchMin;
			float cameraControlPitchMax = instance.CameraControlPitchMax;
			if ((double)Math.Abs(cameraControlPitchMin - cameraControlPitchMax) > 0.0001)
			{
				inValue = Singleton<MathUtils>.Instance.RangeClamp(num, cameraControlPitchMin, cameraControlPitchMax, 0.04f, 0.96f);
			}
			base.GetText(0).SetText(Math.Round((double)num).ToString("F0"), true);
			base.GetSlider(14).SetValue(inValue, false);
		}

		// Token: 0x060363E0 RID: 222176 RVA: 0x00DAB790 File Offset: 0x00DA9990
		private void UpdateCameraYaw(float yaw)
		{
			QuickHackModel instance = ModelBase<QuickHackModel>.Instance;
			float num = Singleton<MathUtils>.Instance.WrapAngle(yaw - instance.CameraControlDefaultYaw);
			float inValue = 0.5f;
			float cameraControlYawMin = instance.CameraControlYawMin;
			float cameraControlYawMax = instance.CameraControlYawMax;
			if ((double)Math.Abs(cameraControlYawMin - cameraControlYawMax) > 0.0001)
			{
				inValue = Singleton<MathUtils>.Instance.RangeClamp(num, cameraControlYawMin, cameraControlYawMax, 0.015f, 0.985f);
			}
			base.GetText(1).SetText(Math.Round((double)num).ToString("F0"), true);
			base.GetSlider(13).SetValue(inValue, false);
		}

		// Token: 0x060363E1 RID: 222177 RVA: 0x00DAB82A File Offset: 0x00DA9A2A
		protected override void OnBeforeDestroy()
		{
			UiSequencePlayer sequencePlayer = this.SequencePlayer;
			if (sequencePlayer != null)
			{
				sequencePlayer.Clear();
			}
			this.SequencePlayer = null;
			ControllerBase<QuickHackController>.Instance.CloseQuickHackCameraControl();
		}

		// Token: 0x060363E2 RID: 222178 RVA: 0x00DAB850 File Offset: 0x00DA9A50
		protected override void OnAfterHide()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnShowMouseCursor, new Action<bool>(this.OnShowMouseCursor));
			Singleton<EventSystem>.Instance.Remove(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.OnInputControllerChange));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnQuickHackCameraControlChange, new Action<int>(this.OnCameraControlChange));
			Singleton<UiProhibitFightInputCenter>.Instance.UnRegisterExtraRefreshData(this.ViewInfo.Name);
			ControllerBase<InputDistributeController>.Instance.RefreshInputTag();
			base.GetSlider(4).OnValueChangeCb.Unbind();
			ControllerBase<InputDistributeController>.Instance.UnBindAxis("WheelAxis", new TInputHandle<float>(this.OnInputWheelAxis));
		}

		// Token: 0x060363E3 RID: 222179 RVA: 0x00DAB901 File Offset: 0x00DA9B01
		private QuickHackCameraControlItem CreateCameraItem()
		{
			QuickHackCameraControlItem quickHackCameraControlItem = new QuickHackCameraControlItem();
			quickHackCameraControlItem.RegisterOnCameraItemClick(new Action<int>(this.OnCameraItemClick));
			return quickHackCameraControlItem;
		}

		// Token: 0x060363E4 RID: 222180 RVA: 0x00DAB91C File Offset: 0x00DA9B1C
		private void OnCameraControlChange(int pbDataId)
		{
			this.SequencePlayer.StopSequenceByKey("Switch", false, false);
			this.CameraSwitching = true;
			this.SequencePlayer.PlaySequencePurely("Switch", false, false);
			QuickHackModel instance = ModelBase<QuickHackModel>.Instance;
			List<int> cameraControlPbDataIdList = instance.CameraControlPbDataIdList;
			if (cameraControlPbDataIdList != null)
			{
				GenericLayout<QuickHackCameraControlItem, int> cameraPanel = this.CameraPanel;
				if (cameraPanel != null)
				{
					cameraPanel.RefreshByData(cameraControlPbDataIdList, null, false);
				}
				GenericLayout<QuickHackCameraControlItem, int> cameraPanel2 = this.CameraPanel;
				if (cameraPanel2 != null)
				{
					cameraPanel2.SelectGridProxy(instance.CurrentCameraControlIndex, false);
				}
			}
			this.UpdateZoomSliderDefaultValue();
			this.UpdateCameraSlider(true);
		}

		// Token: 0x060363E5 RID: 222181 RVA: 0x00DAB9A0 File Offset: 0x00DA9BA0
		private void UpdateZoomSliderDefaultValue()
		{
			UUISliderComponent slider = base.GetSlider(4);
			QuickHackModel instance = ModelBase<QuickHackModel>.Instance;
			float cameraControlMinFov = instance.CameraControlMinFov;
			float cameraControlMaxFov = instance.CameraControlMaxFov;
			float inValue = Singleton<MathUtils>.Instance.RangeClamp(instance.CameraControlDefaultFov, cameraControlMinFov, cameraControlMaxFov, cameraControlMaxFov, cameraControlMinFov);
			slider.SetMinValue(cameraControlMinFov, false, false);
			slider.SetMaxValue(cameraControlMaxFov, false, false);
			slider.SetValue(inValue, false);
		}

		// Token: 0x060363E6 RID: 222182 RVA: 0x00DAB9F6 File Offset: 0x00DA9BF6
		private void OnSequenceEnd(string sequenceName)
		{
			if (sequenceName == "Switch" && this.CameraSwitching)
			{
				this.CameraSwitching = false;
				if (ModelBase<QuickHackModel>.Instance.CameraControlAutoOpenQuickHack)
				{
					this.OpenQuickHack();
				}
			}
		}

		// Token: 0x060363E7 RID: 222183 RVA: 0x00DABA26 File Offset: 0x00DA9C26
		protected void OnShowMouseCursor(bool value)
		{
			this.UpdateKeyItem();
		}

		// Token: 0x060363E8 RID: 222184 RVA: 0x00DABA2E File Offset: 0x00DA9C2E
		private void OnInputControllerChange(EInputControllerType last, EInputControllerType now)
		{
			this.UpdateKeyItem();
		}

		// Token: 0x060363E9 RID: 222185 RVA: 0x00DABA36 File Offset: 0x00DA9C36
		private void UpdateKeyItem()
		{
			base.GetItem(12).SetUIActive(Singleton<Info>.Instance.IsInKeyBoard() && !Singleton<InputManager>.Instance.IsShowMouseCursor());
		}

		// Token: 0x060363EA RID: 222186 RVA: 0x00DABA61 File Offset: 0x00DA9C61
		public bool CheckCondition()
		{
			return !Singleton<InputManager>.Instance.IsShowMouseCursor() || !Singleton<Info>.Instance.IsInKeyBoard();
		}

		// Token: 0x060363EB RID: 222187 RVA: 0x00DABA7E File Offset: 0x00DA9C7E
		public string[] GetDistributeTags()
		{
			return new string[]
			{
				"FightInputRoot.FightInput.AxisInput.CameraInput.CameraRotation",
				"UiInputRoot.MouseInputTag",
				"UiInputRoot.Navigation"
			};
		}

		// Token: 0x060363EC RID: 222188 RVA: 0x00DABA9E File Offset: 0x00DA9C9E
		private void OnLeftCameraClick()
		{
			if (ModelBase<QuickHackModel>.Instance.IsQuickHacking)
			{
				return;
			}
			ControllerBase<QuickHackController>.Instance.ChangeNextCamera(false);
		}

		// Token: 0x060363ED RID: 222189 RVA: 0x00DABAB8 File Offset: 0x00DA9CB8
		private void OnRightCameraClick()
		{
			if (ModelBase<QuickHackModel>.Instance.IsQuickHacking)
			{
				return;
			}
			ControllerBase<QuickHackController>.Instance.ChangeNextCamera(true);
		}

		// Token: 0x060363EE RID: 222190 RVA: 0x00DABAD2 File Offset: 0x00DA9CD2
		private void OnCameraItemClick(int pbDataId)
		{
			if (ModelBase<QuickHackModel>.Instance.IsQuickHacking)
			{
				return;
			}
			ControllerBase<QuickHackController>.Instance.ChangeCameraByPbDataId(pbDataId);
		}

		// Token: 0x060363EF RID: 222191 RVA: 0x00DABAEC File Offset: 0x00DA9CEC
		private void OnPhotoClick()
		{
			if (ModelBase<QuickHackModel>.Instance.IsQuickHacking)
			{
				return;
			}
			ControllerBase<PhotographController>.Instance.ScreenShot(new PhotoSaveViewParam
			{
				ScreenShot = true,
				PrepareFullScreenShot = true,
				IsHiddenBattleView = false,
				HandBookPhotoData = null,
				GachaData = null,
				FragmentMemory = null,
				RoleSkinData = null,
				ShareId = 1
			});
		}

		// Token: 0x060363F0 RID: 222192 RVA: 0x00DABB4D File Offset: 0x00DA9D4D
		private void OnQuickHackClick()
		{
			if (base.IsShow)
			{
				this.OpenQuickHack();
			}
		}

		// Token: 0x060363F1 RID: 222193 RVA: 0x00DABB60 File Offset: 0x00DA9D60
		private void OpenQuickHack()
		{
			if (ModelBase<QuickHackModel>.Instance.IsQuickHacking)
			{
				return;
			}
			this.OnZoomIncreaseRelease();
			this.OnZoomDecreaseRelease();
			this.SequencePlayer.PlaySequencePurely("Invade", false, false);
			ControllerBase<QuickHackController>.Instance.OpenQuickHackByCameraControl(delegate
			{
				if (this.SequencePlayer != null)
				{
					this.SequencePlayer.StopSequenceByKey("Invade", false, false);
					this.SequencePlayer.PlaySequencePurely("InvadeOut", false, false);
				}
			});
		}

		// Token: 0x060363F2 RID: 222194 RVA: 0x00DABBAE File Offset: 0x00DA9DAE
		private void OnCloseClick()
		{
			if (ModelBase<QuickHackModel>.Instance.IsQuickHacking)
			{
				return;
			}
			ControllerBase<QuickHackController>.Instance.CloseQuickHackCameraControl();
		}

		// Token: 0x060363F3 RID: 222195 RVA: 0x00DABBC8 File Offset: 0x00DA9DC8
		private void OnZoomIncreasePress()
		{
			if (ModelBase<QuickHackModel>.Instance.IsQuickHacking)
			{
				return;
			}
			this.UpdateSliderByDeltaValue(1f);
			this.RemoveUpdateFovTimer();
			this.UpdateFovTimer = TimerSystem.GameplayTimeInstance.Forever(new TTimerAction(this.OnIncreaseFov), 100f, 1f, null, null, true);
		}

		// Token: 0x060363F4 RID: 222196 RVA: 0x00DABC1C File Offset: 0x00DA9E1C
		private void OnZoomDecreasePress()
		{
			if (ModelBase<QuickHackModel>.Instance.IsQuickHacking)
			{
				return;
			}
			this.UpdateSliderByDeltaValue(-1f);
			this.RemoveUpdateFovTimer();
			this.UpdateFovTimer = TimerSystem.GameplayTimeInstance.Forever(new TTimerAction(this.OnReduceFov), 100f, 1f, null, null, true);
		}

		// Token: 0x060363F5 RID: 222197 RVA: 0x00DABC70 File Offset: 0x00DA9E70
		private void OnZoomIncreaseRelease()
		{
			this.RemoveUpdateFovTimer();
		}

		// Token: 0x060363F6 RID: 222198 RVA: 0x00DABC78 File Offset: 0x00DA9E78
		private void OnZoomDecreaseRelease()
		{
			this.RemoveUpdateFovTimer();
		}

		// Token: 0x060363F7 RID: 222199 RVA: 0x00DABC80 File Offset: 0x00DA9E80
		private void RemoveUpdateFovTimer()
		{
			TimerHandle updateFovTimer = this.UpdateFovTimer;
			if (updateFovTimer != null)
			{
				updateFovTimer.Remove();
			}
			this.UpdateFovTimer = null;
		}

		// Token: 0x060363F8 RID: 222200 RVA: 0x00DABC9B File Offset: 0x00DA9E9B
		private void OnIncreaseFov(float delta)
		{
			this.UpdateSliderByDeltaValue(1f);
		}

		// Token: 0x060363F9 RID: 222201 RVA: 0x00DABCA8 File Offset: 0x00DA9EA8
		private void OnReduceFov(float delta)
		{
			this.UpdateSliderByDeltaValue(-1f);
		}

		// Token: 0x060363FA RID: 222202 RVA: 0x00DABCB5 File Offset: 0x00DA9EB5
		private void OnSliderValueChange(float value)
		{
			this.UpdateSliderValue(value);
		}

		// Token: 0x060363FB RID: 222203 RVA: 0x00DABCC0 File Offset: 0x00DA9EC0
		private void UpdateSliderByDeltaValue(float delta)
		{
			UUISliderComponent slider = base.GetSlider(4);
			float num = slider.GetValue() + delta;
			slider.SetValue(num, false);
			this.UpdateSliderValue(num);
		}

		// Token: 0x060363FC RID: 222204 RVA: 0x00DABCEC File Offset: 0x00DA9EEC
		private void UpdateSliderValue(float value)
		{
			QuickHackModel instance = ModelBase<QuickHackModel>.Instance;
			float cameraControlMinFov = instance.CameraControlMinFov;
			float cameraControlMaxFov = instance.CameraControlMaxFov;
			float fov = Singleton<MathUtils>.Instance.RangeClamp(value, cameraControlMinFov, cameraControlMaxFov, cameraControlMaxFov, cameraControlMinFov);
			ControllerBase<QuickHackController>.Instance.UpdateCameraControlFov(fov);
		}

		// Token: 0x060363FD RID: 222205 RVA: 0x00DABD26 File Offset: 0x00DA9F26
		private void OnInputWheelAxis(string name, float value, InputIdentification inputIdentification)
		{
			if (ModelBase<QuickHackModel>.Instance.IsQuickHacking)
			{
				return;
			}
			if (value != 0f)
			{
				this.UpdateSliderByDeltaValue(value * this.CameraZoomAxisSpeed);
			}
		}

		// Token: 0x0401F2FB RID: 127739
		[Nullable(2)]
		private PopupCaptionItem CaptionItem;

		// Token: 0x0401F2FC RID: 127740
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayout<QuickHackCameraControlItem, int> CameraPanel;

		// Token: 0x0401F2FD RID: 127741
		[Nullable(2)]
		private UiSequencePlayer SequencePlayer;

		// Token: 0x0401F2FE RID: 127742
		private float CameraZoomAxisSpeed = 1f;

		// Token: 0x0401F2FF RID: 127743
		[Nullable(2)]
		private TimerHandle UpdateFovTimer;

		// Token: 0x0401F300 RID: 127744
		private bool CameraSwitching;

		// Token: 0x0401F301 RID: 127745
		private float CameraPitch;

		// Token: 0x0401F302 RID: 127746
		private float CameraYaw;

		// Token: 0x0401F303 RID: 127747
		private const float CHANGE_FOV_INTERVAL = 100f;

		// Token: 0x0401F304 RID: 127748
		private const float CAMERA_YAW_SLIDER_OFFSET = 0.015f;

		// Token: 0x0401F305 RID: 127749
		private const float CAMERA_PITCH_SLIDER_OFFSET = 0.04f;

		// Token: 0x0200B233 RID: 45619
		[NullableContext(0)]
		private class EComponentType
		{
			// Token: 0x040373C4 RID: 226244
			public const int CameraPitchText = 0;

			// Token: 0x040373C5 RID: 226245
			public const int CameraYawText = 1;

			// Token: 0x040373C6 RID: 226246
			public const int CaptionItem = 2;

			// Token: 0x040373C7 RID: 226247
			public const int ZoomIncreaseButton = 3;

			// Token: 0x040373C8 RID: 226248
			public const int ZoomSlider = 4;

			// Token: 0x040373C9 RID: 226249
			public const int ZoomDecreaseButton = 5;

			// Token: 0x040373CA RID: 226250
			public const int LeftCameraButton = 6;

			// Token: 0x040373CB RID: 226251
			public const int RightCameraButton = 7;

			// Token: 0x040373CC RID: 226252
			public const int CameraListPanel = 8;

			// Token: 0x040373CD RID: 226253
			public const int CameraItem = 9;

			// Token: 0x040373CE RID: 226254
			public const int PhotoButton = 10;

			// Token: 0x040373CF RID: 226255
			public const int QuickHackButton = 11;

			// Token: 0x040373D0 RID: 226256
			public const int QuickHackKeyItem = 12;

			// Token: 0x040373D1 RID: 226257
			public const int CameraYawSlider = 13;

			// Token: 0x040373D2 RID: 226258
			public const int CameraPitchSlider = 14;
		}
	}
}
