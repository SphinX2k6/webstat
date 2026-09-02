using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Input;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x0200607D RID: 24701
	[NullableContext(2)]
	[Nullable(0)]
	public class MotorcycleControlHudPanel : BattleVisibleChildView
	{
		// Token: 0x0603E49C RID: 255132 RVA: 0x00FE7204 File Offset: 0x00FE5404
		[NullableContext(1)]
		public UniTask Init(UUIItem parentItem, string resourceId)
		{
			MotorcycleControlHudPanel.<Init>d__31 <Init>d__;
			<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Init>d__.<>4__this = this;
			<Init>d__.parentItem = parentItem;
			<Init>d__.resourceId = resourceId;
			<Init>d__.<>1__state = -1;
			<Init>d__.<>t__builder.Start<MotorcycleControlHudPanel.<Init>d__31>(ref <Init>d__);
			return <Init>d__.<>t__builder.Task;
		}

		// Token: 0x0603E49D RID: 255133 RVA: 0x00FE7258 File Offset: 0x00FE5458
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603E49E RID: 255134 RVA: 0x00FE72E4 File Offset: 0x00FE54E4
		protected override UniTask OnBeforeStartAsync()
		{
			MotorcycleControlHudPanel.<OnBeforeStartAsync>d__33 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MotorcycleControlHudPanel.<OnBeforeStartAsync>d__33>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603E49F RID: 255135 RVA: 0x00FE7328 File Offset: 0x00FE5528
		protected override void OnStart()
		{
			base.InitChildType(EBattleUiChild.MotorcycleControlHud);
			this.ConfigRotateYaw = ConfigCommonParamById.GetFloatConfig("MotorHudRotateYaw").Value;
			this.ConfigRotateSpeed = ConfigCommonParamById.GetFloatConfig("MotorHudRotateSpeed").Value;
			this.ConfigRotateBackSpeed = ConfigCommonParamById.GetFloatConfig("MotorHudRotateBackSpeed").Value;
			this.ConfigRotateOutSpeed = ConfigCommonParamById.GetFloatConfig("MotorHudRotateOutSpeed").Value;
			this.ConfigSoarPitch = ConfigCommonParamById.GetFloatConfig("MotorHudSoarPitch").Value;
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
			this.RotateItem = base.GetItem(2);
			this.AddEvents();
			this.RefreshMotorcycleSpeed(true);
			base.SetVisible(1, ModelBase<BattleUiModel>.Instance.MotorcycleData.GetHudVisible());
		}

		// Token: 0x0603E4A0 RID: 255136 RVA: 0x00FE73F6 File Offset: 0x00FE55F6
		public void OnShowBattleChildViewPanel()
		{
		}

		// Token: 0x0603E4A1 RID: 255137 RVA: 0x00FE73F8 File Offset: 0x00FE55F8
		public void OnHideBattleChildViewPanel()
		{
		}

		// Token: 0x0603E4A2 RID: 255138 RVA: 0x00FE73FA File Offset: 0x00FE55FA
		protected override void OnBeforeShow()
		{
			base.OnBeforeShow();
			this.RefreshMotorcycleSpeed(true);
		}

		// Token: 0x0603E4A3 RID: 255139 RVA: 0x00FE7409 File Offset: 0x00FE5609
		protected override void OnAfterHide()
		{
			base.OnAfterHide();
			this.MotorcycleEntityHandle = null;
			this.VehicleActorComponent = null;
			this.ClearTagTask();
		}

		// Token: 0x0603E4A4 RID: 255140 RVA: 0x00FE7428 File Offset: 0x00FE5628
		protected override void OnAfterShow()
		{
			this.UpdateAlpha(0f, true);
			this.IsEnableAlphaUpdate = true;
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer == null)
			{
				return;
			}
			levelSequencePlayer.PlayLevelSequenceByName("Start", false, null, false);
		}

		// Token: 0x0603E4A5 RID: 255141 RVA: 0x00FE7468 File Offset: 0x00FE5668
		protected override UniTask OnBeforeHideAsync()
		{
			MotorcycleControlHudPanel.<OnBeforeHideAsync>d__40 <OnBeforeHideAsync>d__;
			<OnBeforeHideAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeHideAsync>d__.<>4__this = this;
			<OnBeforeHideAsync>d__.<>1__state = -1;
			<OnBeforeHideAsync>d__.<>t__builder.Start<MotorcycleControlHudPanel.<OnBeforeHideAsync>d__40>(ref <OnBeforeHideAsync>d__);
			return <OnBeforeHideAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603E4A6 RID: 255142 RVA: 0x00FE74AC File Offset: 0x00FE56AC
		protected override void OnBeforeDestroy()
		{
			this.Reset();
			this.RemoveEvents();
			this.ClearTagTask();
			this.SpeedColorMPC = null;
			foreach (MotorcycleControlHudPanel.SpeedColorObj speedColorObj in this.SpeedColorObjs)
			{
				speedColorObj.Clear();
			}
			this.SpeedColorObjs.Clear();
		}

		// Token: 0x0603E4A7 RID: 255143 RVA: 0x00FE7520 File Offset: 0x00FE5720
		private void AddEvents()
		{
			Singleton<EventSystem>.Instance.Add<bool>(EEventName.BattleUiMotorcycleHudVisibleChanged, new Action<bool>(this.OnMotorcycleHudVisibleChanged));
			Singleton<EventSystem>.Instance.Add<EMotorcycleHudColorState>(EEventName.BattleUiMotorcycleHudColorStateChanged, new Action<EMotorcycleHudColorState>(this.OnHudColorStateChanged));
			Singleton<EventSystem>.Instance.Add<ERoleSpecialState, bool>(EEventName.BattleUiRoleSpecialStateChanged, new Action<ERoleSpecialState, bool>(this.OnBattleUiRoleSpecialStateChanged));
		}

		// Token: 0x0603E4A8 RID: 255144 RVA: 0x00FE7584 File Offset: 0x00FE5784
		private void RemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.BattleUiMotorcycleHudVisibleChanged, new Action<bool>(this.OnMotorcycleHudVisibleChanged));
			Singleton<EventSystem>.Instance.Remove(EEventName.BattleUiMotorcycleHudColorStateChanged, new Action<EMotorcycleHudColorState>(this.OnHudColorStateChanged));
			Singleton<EventSystem>.Instance.Remove(EEventName.BattleUiRoleSpecialStateChanged, new Action<ERoleSpecialState, bool>(this.OnBattleUiRoleSpecialStateChanged));
		}

		// Token: 0x0603E4A9 RID: 255145 RVA: 0x00FE75E5 File Offset: 0x00FE57E5
		private void OnMotorcycleHudVisibleChanged(bool visible)
		{
			base.SetVisible(1, visible);
		}

		// Token: 0x0603E4AA RID: 255146 RVA: 0x00FE75F0 File Offset: 0x00FE57F0
		private void OnHudColorStateChanged(EMotorcycleHudColorState state)
		{
			if (this.ColorState == EMotorcycleHudColorState.Normal && state != EMotorcycleHudColorState.Normal)
			{
				LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
				if (levelSequencePlayer != null && levelSequencePlayer.IsPlayingSequence("BoostOut"))
				{
					LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
					if (levelSequencePlayer2 != null)
					{
						levelSequencePlayer2.StopSequenceByKey("BoostOut", false, false);
					}
				}
				LevelSequencePlayer levelSequencePlayer3 = this.LevelSequencePlayer;
				if (levelSequencePlayer3 != null)
				{
					levelSequencePlayer3.PlayLevelSequenceByName("BoostIn", false, null, false);
				}
			}
			else if (this.ColorState != EMotorcycleHudColorState.Normal && state == EMotorcycleHudColorState.Normal)
			{
				LevelSequencePlayer levelSequencePlayer4 = this.LevelSequencePlayer;
				if (levelSequencePlayer4 != null && levelSequencePlayer4.IsPlayingSequence("BoostIn"))
				{
					LevelSequencePlayer levelSequencePlayer5 = this.LevelSequencePlayer;
					if (levelSequencePlayer5 != null)
					{
						levelSequencePlayer5.StopSequenceByKey("BoostIn", false, false);
					}
				}
				LevelSequencePlayer levelSequencePlayer6 = this.LevelSequencePlayer;
				if (levelSequencePlayer6 != null)
				{
					levelSequencePlayer6.PlayLevelSequenceByName("BoostOut", false, null, false);
				}
			}
			this.SetColorState(state);
		}

		// Token: 0x0603E4AB RID: 255147 RVA: 0x00FE76C0 File Offset: 0x00FE58C0
		private void OnBattleUiRoleSpecialStateChanged(ERoleSpecialState state, bool enable)
		{
			if (state == ERoleSpecialState.MotorcycleFirstPersonDisabled)
			{
				bool isFirstPersonDisabled = false;
				BattleUiRoleData curRoleData = ModelBase<BattleUiModel>.Instance.GetCurRoleData();
				if (curRoleData != null)
				{
					curRoleData.SpecialStateMap.TryGetValue(state, out isFirstPersonDisabled);
				}
				this.IsFirstPersonDisabled = isFirstPersonDisabled;
			}
		}

		// Token: 0x0603E4AC RID: 255148 RVA: 0x00FE76F8 File Offset: 0x00FE58F8
		private unsafe void RefreshMotorcycleSpeed(bool isStart)
		{
			this.NextRefreshSpeedTime = 100f;
			if (this.MotorcycleEntityHandle == ModelBase<BattleUiModel>.Instance.MotorcycleData.MotorcycleEntityHandle)
			{
				EntityHandle motorcycleEntityHandle = this.MotorcycleEntityHandle;
				if (motorcycleEntityHandle != null && motorcycleEntityHandle.Valid)
				{
					goto IL_3F;
				}
			}
			this.InitMotorcycleEntity();
			IL_3F:
			VehicleActorComponent vehicleActorComponent = this.VehicleActorComponent;
			UKuroVehicleMovementComponent ukuroVehicleMovementComponent;
			if (vehicleActorComponent == null)
			{
				ukuroVehicleMovementComponent = null;
			}
			else
			{
				VehicleMoveComponent vehicleMoveComp = vehicleActorComponent.VehicleMoveComp;
				ukuroVehicleMovementComponent = ((vehicleMoveComp != null) ? vehicleMoveComp.VehicleMovement : null);
			}
			UKuroVehicleMovementComponent ukuroVehicleMovementComponent2 = ukuroVehicleMovementComponent;
			if (ukuroVehicleMovementComponent2 == null)
			{
				return;
			}
			UMotorWheelDisplayInfoObject wheelDisplayInfosObj = ukuroVehicleMovementComponent2.WheelDisplayInfosObj;
			TArray<FMotorWheelDisplayInfo> tarray = (wheelDisplayInfosObj != null) ? wheelDisplayInfosObj.DisplayInfos : null;
			float num = 0f;
			if (this.IsVehicleSoar)
			{
				num = ukuroVehicleMovementComponent2.Velocity.Size();
			}
			else if (tarray != null && tarray.Num() >= 2)
			{
				FMotorShapeConfig motorShapeConfig = ukuroVehicleMovementComponent2.MotorShapeConfig;
				num = Math.Max(Math.Abs(tarray.Get(0).WheelSpeed * motorShapeConfig.FrontWheelShape.Radius), Math.Abs(tarray.Get(1).WheelSpeed * motorShapeConfig.BackWheelShape.Radius));
				if (ModelBase<BattleUiModel>.Instance.MotorcycleData.DebugLog)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Battle;
					ELogAuthor author = ELogAuthor.CFT;
					string message = "MotorcycleControlHud WheelInfo";
					<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("speed0", tarray.Get(0).WheelSpeed.ToString("F2"));
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("speed1", tarray.Get(1).WheelSpeed.ToString("F2"));
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("radius0", motorShapeConfig.FrontWheelShape.Radius.ToString("F2"));
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("radius1", motorShapeConfig.BackWheelShape.Radius.ToString("F2"));
					instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
				}
			}
			float maxSpeed = ukuroVehicleMovementComponent2.MotorAccelConfig.MaxSpeed;
			this.LeftSpeedItem.SetSpeed(num, maxSpeed);
			if (this.IsVehicleSoar)
			{
				float configSoarPitch = this.ConfigSoarPitch;
				float num2 = Singleton<MathUtils>.Instance.Clamp(this.VehicleActorComponent.ActorRotationProxy.Pitch, -configSoarPitch, configSoarPitch);
				float num3 = (num2 + configSoarPitch) / (configSoarPitch * 2f) * configSoarPitch;
				this.RightSpeedItem.SetSpeed(num3, configSoarPitch);
				if (ModelBase<BattleUiModel>.Instance.MotorcycleData.DebugLog)
				{
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module2 = ELogModule.Battle;
					ELogAuthor author2 = ELogAuthor.HWR;
					string message2 = "MotorcycleControlHud Soar";
					<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray4<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("speed", num);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("mSpeed", maxSpeed);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("pitch", num2);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 3) = new ValueTuple<string, object>("value", num3);
					instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 4));
					return;
				}
			}
			else
			{
				float toMax = ukuroVehicleMovementComponent2.MotorAccelConfig.PowerAccel.ToMax;
				float currentMotorPower = ukuroVehicleMovementComponent2.GetCurrentMotorPower();
				this.RightSpeedItem.SetSpeed(currentMotorPower, toMax);
				if (ModelBase<BattleUiModel>.Instance.MotorcycleData.DebugLog)
				{
					Log instance3 = Singleton<Log>.Instance;
					ELogModule module3 = ELogModule.Battle;
					ELogAuthor author3 = ELogAuthor.CFT;
					string message3 = "MotorcycleControlHud";
					<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray4<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("speed", num);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("mSpeed", maxSpeed);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 2) = new ValueTuple<string, object>("acc", currentMotorPower);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 3) = new ValueTuple<string, object>("mAcc", toMax);
					instance3.Info(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 4));
				}
			}
		}

		// Token: 0x0603E4AD RID: 255149 RVA: 0x00FE7AE8 File Offset: 0x00FE5CE8
		private void InitMotorcycleEntity()
		{
			BattleUiMotorcycleData motorcycleData = ModelBase<BattleUiModel>.Instance.MotorcycleData;
			this.MotorcycleEntityHandle = motorcycleData.MotorcycleEntityHandle;
			EntityHandle motorcycleEntityHandle = this.MotorcycleEntityHandle;
			this.VehicleActorComponent = ((motorcycleEntityHandle != null && motorcycleEntityHandle.Valid) ? this.MotorcycleEntityHandle.Entity.GetComponent<VehicleActorComponent>() : null);
			this.ClearTagTask();
			if (this.VehicleActorComponent != null)
			{
				BaseTagComponent component = this.MotorcycleEntityHandle.Entity.GetComponent<BaseTagComponent>();
				this.VehicleSoarTagTask = component.ListenForTagAddOrRemove(new int?(GameplayTagDefine.EGameplayTagId["载具.摩托.状态.空中.翱翔"]), delegate(int tagId, bool tagExist)
				{
					this.IsVehicleSoar = tagExist;
					MotorcycleHudSpeedItem rightSpeedItem = this.RightSpeedItem;
					if (rightSpeedItem == null)
					{
						return;
					}
					rightSpeedItem.SetSoarMode(tagExist);
				}, null);
				this.IsVehicleSoar = component.HasTag(GameplayTagDefine.EGameplayTagId["载具.摩托.状态.空中.翱翔"]);
				this.RightSpeedItem.SetSoarMode(this.IsVehicleSoar);
			}
		}

		// Token: 0x0603E4AE RID: 255150 RVA: 0x00FE7BB1 File Offset: 0x00FE5DB1
		private void ClearTagTask()
		{
			if (this.VehicleSoarTagTask != null)
			{
				this.VehicleSoarTagTask.EndTask();
				this.VehicleSoarTagTask = null;
			}
		}

		// Token: 0x0603E4AF RID: 255151 RVA: 0x00FE7BD0 File Offset: 0x00FE5DD0
		public void Tick(float delta)
		{
			if (!base.IsShowOrShowing)
			{
				return;
			}
			this.NextRefreshSpeedTime -= delta;
			if (this.NextRefreshSpeedTime <= 0f)
			{
				this.RefreshMotorcycleSpeed(false);
			}
			this.LeftSpeedItem.Tick(delta);
			this.RightSpeedItem.Tick(delta);
			if (this.IsEnableAlphaUpdate)
			{
				this.UpdateAlpha(delta, false);
			}
			foreach (MotorcycleControlHudPanel.SpeedColorObj speedColorObj in this.SpeedColorObjs)
			{
				speedColorObj.Update(delta);
			}
			this.OnTickRotateHud(delta);
		}

		// Token: 0x0603E4B0 RID: 255152 RVA: 0x00FE7C7C File Offset: 0x00FE5E7C
		private void UpdateAlpha(float delta, bool force = false)
		{
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			CharacterActorComponent characterActorComponent = (baseCharacter != null) ? baseCharacter.CharacterActorComponent : null;
			if (characterActorComponent == null)
			{
				return;
			}
			if (Math.Abs((double)(ControllerBase<CameraController>.Instance.MainModel.CameraRotator.Yaw * 0.017453292f) - characterActorComponent.ActorForwardProxy.HeadingAngle()) < (double)this.AlphaAngleRange)
			{
				this.SetAlphaState(MotorcycleControlHudPanel.EAlphaState.Normal, force);
			}
			else
			{
				this.SetAlphaState(MotorcycleControlHudPanel.EAlphaState.Transparent, force);
			}
			if (force || this.AlphaMachine.Update(delta))
			{
				base.GetRootItem().SetAlpha(this.AlphaMachine.GetCurPercent());
			}
		}

		// Token: 0x0603E4B1 RID: 255153 RVA: 0x00FE7D10 File Offset: 0x00FE5F10
		private void SetAlphaState(MotorcycleControlHudPanel.EAlphaState state, bool force = false)
		{
			if (state == this.AlphaState && !force)
			{
				return;
			}
			this.AlphaState = state;
			float num = (state == MotorcycleControlHudPanel.EAlphaState.Normal) ? 1f : this.AlphaTargetValue;
			if (!force)
			{
				this.AlphaMachine.SetTargetPercent(num);
				return;
			}
			this.AlphaMachine.Init(num, new float?(this.AlphaChangeDuration));
		}

		// Token: 0x0603E4B2 RID: 255154 RVA: 0x00FE7D6C File Offset: 0x00FE5F6C
		private void InitAlphaParams()
		{
			IReadOnlyList<float> floatArrayConfig = ConfigCommonParamById.GetFloatArrayConfig("MotorHudAlphaParams");
			if (floatArrayConfig != null)
			{
				if (floatArrayConfig.Count > 0)
				{
					this.AlphaAngleRange = floatArrayConfig[0] * 0.5f * 0.017453292f;
				}
				if (floatArrayConfig.Count > 1)
				{
					this.AlphaTargetValue = floatArrayConfig[1];
				}
				if (floatArrayConfig.Count > 2)
				{
					this.AlphaChangeDuration = floatArrayConfig[2] * (float)Singleton<TimeUtil>.Instance.InverseMillisecond;
				}
			}
		}

		// Token: 0x0603E4B3 RID: 255155 RVA: 0x00FE7DE4 File Offset: 0x00FE5FE4
		private void SetColorState(EMotorcycleHudColorState state)
		{
			if (this.ColorState == state)
			{
				return;
			}
			this.ColorState = state;
			foreach (MotorcycleControlHudPanel.SpeedColorObj speedColorObj in this.SpeedColorObjs)
			{
				string targetColor;
				if (speedColorObj.ColorMap.TryGetValue(state, out targetColor))
				{
					speedColorObj.ColorMachine.SetTargetColor(targetColor);
				}
			}
		}

		// Token: 0x0603E4B4 RID: 255156 RVA: 0x00FE7E60 File Offset: 0x00FE6060
		private void OnMainColorUpdate(in FLinearColor color)
		{
			if (this.SpeedColorMPC != null)
			{
				UKismetMaterialLibrary.SetVectorParameterValue(GlobalData.World, this.SpeedColorMPC, FNameUtil.GetDynamicFName("MainColor").Value, color);
			}
			MotorcycleHudSpeedItem leftSpeedItem = this.LeftSpeedItem;
			if (leftSpeedItem != null)
			{
				leftSpeedItem.SetMainColor(color);
			}
			MotorcycleHudSpeedItem rightSpeedItem = this.RightSpeedItem;
			if (rightSpeedItem == null)
			{
				return;
			}
			rightSpeedItem.SetMainColor(color);
		}

		// Token: 0x0603E4B5 RID: 255157 RVA: 0x00FE7EBC File Offset: 0x00FE60BC
		private void OnColorAUpdate(in FLinearColor color)
		{
			if (this.SpeedColorMPC != null)
			{
				UKismetMaterialLibrary.SetVectorParameterValue(GlobalData.World, this.SpeedColorMPC, FNameUtil.GetDynamicFName("ColorA").Value, color);
			}
		}

		// Token: 0x0603E4B6 RID: 255158 RVA: 0x00FE7EF4 File Offset: 0x00FE60F4
		private void OnColorBUpdate(in FLinearColor color)
		{
			if (this.SpeedColorMPC != null)
			{
				UKismetMaterialLibrary.SetVectorParameterValue(GlobalData.World, this.SpeedColorMPC, FNameUtil.GetDynamicFName("ColorB").Value, color);
			}
		}

		// Token: 0x0603E4B7 RID: 255159 RVA: 0x00FE7F2C File Offset: 0x00FE612C
		private void OnPointerColorUpdate(in FLinearColor color)
		{
			MotorcycleHudSpeedItem leftSpeedItem = this.LeftSpeedItem;
			if (leftSpeedItem != null)
			{
				leftSpeedItem.SetPointerColor(color);
			}
			MotorcycleHudSpeedItem rightSpeedItem = this.RightSpeedItem;
			if (rightSpeedItem == null)
			{
				return;
			}
			rightSpeedItem.SetPointerColor(color);
		}

		// Token: 0x0603E4B8 RID: 255160 RVA: 0x00FE7F51 File Offset: 0x00FE6151
		private void OnTextColorUpdate(in FLinearColor color)
		{
			MotorcycleHudSpeedItem leftSpeedItem = this.LeftSpeedItem;
			if (leftSpeedItem == null)
			{
				return;
			}
			leftSpeedItem.SetNumTextColor(color);
		}

		// Token: 0x0603E4B9 RID: 255161 RVA: 0x00FE7F64 File Offset: 0x00FE6164
		private void OnTextStrokeColorUpdate(in FLinearColor color)
		{
			MotorcycleHudSpeedItem leftSpeedItem = this.LeftSpeedItem;
			if (leftSpeedItem == null)
			{
				return;
			}
			leftSpeedItem.SetNumTextStrokeColor(color);
		}

		// Token: 0x0603E4BA RID: 255162 RVA: 0x00FE7F77 File Offset: 0x00FE6177
		private void OnTextGlowColorUpdate(in FLinearColor color)
		{
			MotorcycleHudSpeedItem leftSpeedItem = this.LeftSpeedItem;
			if (leftSpeedItem == null)
			{
				return;
			}
			leftSpeedItem.SetNumTextGlowColor(color);
		}

		// Token: 0x0603E4BB RID: 255163 RVA: 0x00FE7F8C File Offset: 0x00FE618C
		private void OnDecoColorUpdate(in FLinearColor color)
		{
			if (this.SpeedColorMPC != null)
			{
				UKismetMaterialLibrary.SetVectorParameterValue(GlobalData.World, this.SpeedColorMPC, FNameUtil.GetDynamicFName("DecoColor").Value, color);
			}
		}

		// Token: 0x0603E4BC RID: 255164 RVA: 0x00FE7FC4 File Offset: 0x00FE61C4
		[NullableContext(0)]
		private UniTask<bool> LoadSpeedColorMPC()
		{
			MotorcycleControlHudPanel.<LoadSpeedColorMPC>d__66 <LoadSpeedColorMPC>d__;
			<LoadSpeedColorMPC>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<LoadSpeedColorMPC>d__.<>4__this = this;
			<LoadSpeedColorMPC>d__.<>1__state = -1;
			<LoadSpeedColorMPC>d__.<>t__builder.Start<MotorcycleControlHudPanel.<LoadSpeedColorMPC>d__66>(ref <LoadSpeedColorMPC>d__);
			return <LoadSpeedColorMPC>d__.<>t__builder.Task;
		}

		// Token: 0x0603E4BD RID: 255165 RVA: 0x00FE8008 File Offset: 0x00FE6208
		private void InitSpeedColorObjs()
		{
			string[] array = new string[]
			{
				"MotorHudMainColor",
				"MotorHudColorA",
				"MotorHudColorB",
				"MotorHudPointerColor",
				"MotorHudTextColor",
				"MotorHudTextStrokeColor",
				"MotorHudTextGlowColor",
				"MotorHudDecoColor"
			};
			MotorcycleControlHudPanel.SpeedColorObj.UpdateFuncDelegate[] array2 = new MotorcycleControlHudPanel.SpeedColorObj.UpdateFuncDelegate[]
			{
				new MotorcycleControlHudPanel.SpeedColorObj.UpdateFuncDelegate(this.OnMainColorUpdate),
				new MotorcycleControlHudPanel.SpeedColorObj.UpdateFuncDelegate(this.OnColorAUpdate),
				new MotorcycleControlHudPanel.SpeedColorObj.UpdateFuncDelegate(this.OnColorBUpdate),
				new MotorcycleControlHudPanel.SpeedColorObj.UpdateFuncDelegate(this.OnPointerColorUpdate),
				new MotorcycleControlHudPanel.SpeedColorObj.UpdateFuncDelegate(this.OnTextColorUpdate),
				new MotorcycleControlHudPanel.SpeedColorObj.UpdateFuncDelegate(this.OnTextStrokeColorUpdate),
				new MotorcycleControlHudPanel.SpeedColorObj.UpdateFuncDelegate(this.OnTextGlowColorUpdate),
				new MotorcycleControlHudPanel.SpeedColorObj.UpdateFuncDelegate(this.OnDecoColorUpdate)
			};
			for (int i = 0; i < array.Length; i++)
			{
				MotorcycleControlHudPanel.SpeedColorObj speedColorObj = new MotorcycleControlHudPanel.SpeedColorObj();
				speedColorObj.UpdateFunc = array2[i];
				IReadOnlyList<string> stringArrayConfig = ConfigCommonParamById.GetStringArrayConfig(array[i]);
				if (stringArrayConfig != null)
				{
					for (int j = 0; j < 3; j++)
					{
						if (j < stringArrayConfig.Count && !string.IsNullOrEmpty(stringArrayConfig[j]))
						{
							speedColorObj.ColorMap[(EMotorcycleHudColorState)j] = stringArrayConfig[j];
						}
					}
				}
				speedColorObj.Init();
				this.SpeedColorObjs.Add(speedColorObj);
			}
		}

		// Token: 0x0603E4BE RID: 255166 RVA: 0x00FE815C File Offset: 0x00FE635C
		private void OnTickRotateHud(float delta)
		{
			bool flag = ModelBase<BattleUiModel>.Instance.MotorcycleData.IsInFirstPersonMode() && !this.IsFirstPersonDisabled;
			if (this.IsPlayingFirstPerson != flag)
			{
				this.IsPlayingFirstPerson = flag;
				LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
				if (levelSequencePlayer != null)
				{
					levelSequencePlayer.PlaySequencePurely(flag ? "FPVIn" : "FPVOut", false, false, null, null, false);
				}
			}
			if (flag)
			{
				float valueOrDefault = ModelBase<InputModel>.Instance.GetAxisValues().GetValueOrDefault(EInputAxis.MoveRight, 0f);
				if (valueOrDefault == 0f)
				{
					this.TargetYaw = 0f;
					this.RotateSpeed = this.ConfigRotateBackSpeed;
				}
				else if (valueOrDefault > 0f)
				{
					this.TargetYaw = -this.ConfigRotateYaw;
					this.RotateSpeed = this.ConfigRotateSpeed;
				}
				else
				{
					this.TargetYaw = this.ConfigRotateYaw;
					this.RotateSpeed = this.ConfigRotateSpeed;
				}
			}
			else
			{
				this.TargetYaw = 0f;
				this.RotateSpeed = this.ConfigRotateOutSpeed;
			}
			if (this.CurYaw == this.TargetYaw)
			{
				return;
			}
			if (this.CurYaw < this.TargetYaw)
			{
				this.CurYaw += this.RotateSpeed * delta;
				this.CurYaw = Math.Min(this.CurYaw, this.TargetYaw);
			}
			else
			{
				this.CurYaw -= this.RotateSpeed * delta;
				this.CurYaw = Math.Max(this.CurYaw, this.TargetYaw);
			}
			UUIItem rotateItem = this.RotateItem;
			if (rotateItem == null)
			{
				return;
			}
			FRotator frotator = new FRotator();
			frotator.Yaw = this.CurYaw;
			rotateItem.SetUIRelativeRotation(frotator);
		}

		// Token: 0x04022E98 RID: 143000
		private const float TICK_INTERVAL = 100f;

		// Token: 0x04022E99 RID: 143001
		[Nullable(1)]
		private const string SPEED_COLOR_MPC_PATH = "/Game/Aki/UI/Framework/MPC/UiActivity/Activity30/MotoParkour/GamePlay/MPC_MotoHUD_MainColor.MPC_MotoHUD_MainColor";

		// Token: 0x04022E9A RID: 143002
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x04022E9B RID: 143003
		private MotorcycleHudSpeedItem LeftSpeedItem;

		// Token: 0x04022E9C RID: 143004
		private MotorcycleHudSpeedItem RightSpeedItem;

		// Token: 0x04022E9D RID: 143005
		private EntityHandle MotorcycleEntityHandle;

		// Token: 0x04022E9E RID: 143006
		private VehicleActorComponent VehicleActorComponent;

		// Token: 0x04022E9F RID: 143007
		private float NextRefreshSpeedTime;

		// Token: 0x04022EA0 RID: 143008
		private bool IsPlayingFirstPerson;

		// Token: 0x04022EA1 RID: 143009
		private MotorcycleControlHudPanel.EAlphaState AlphaState;

		// Token: 0x04022EA2 RID: 143010
		private float AlphaAngleRange;

		// Token: 0x04022EA3 RID: 143011
		private float AlphaChangeDuration = 300f;

		// Token: 0x04022EA4 RID: 143012
		private float AlphaTargetValue;

		// Token: 0x04022EA5 RID: 143013
		private bool IsEnableAlphaUpdate;

		// Token: 0x04022EA6 RID: 143014
		[Nullable(1)]
		private readonly MotorcyclePercentMachine AlphaMachine = new MotorcyclePercentMachine();

		// Token: 0x04022EA7 RID: 143015
		private EMotorcycleHudColorState ColorState;

		// Token: 0x04022EA8 RID: 143016
		private UMaterialParameterCollection SpeedColorMPC;

		// Token: 0x04022EA9 RID: 143017
		[Nullable(1)]
		private readonly List<MotorcycleControlHudPanel.SpeedColorObj> SpeedColorObjs = new List<MotorcycleControlHudPanel.SpeedColorObj>();

		// Token: 0x04022EAA RID: 143018
		private UUIItem RotateItem;

		// Token: 0x04022EAB RID: 143019
		private float TargetYaw;

		// Token: 0x04022EAC RID: 143020
		private float CurYaw;

		// Token: 0x04022EAD RID: 143021
		private float RotateSpeed;

		// Token: 0x04022EAE RID: 143022
		private float ConfigRotateYaw;

		// Token: 0x04022EAF RID: 143023
		private float ConfigRotateSpeed;

		// Token: 0x04022EB0 RID: 143024
		private float ConfigRotateBackSpeed;

		// Token: 0x04022EB1 RID: 143025
		private float ConfigRotateOutSpeed;

		// Token: 0x04022EB2 RID: 143026
		private float ConfigSoarPitch;

		// Token: 0x04022EB3 RID: 143027
		private bool IsFirstPersonDisabled;

		// Token: 0x04022EB4 RID: 143028
		private ITagTask VehicleSoarTagTask;

		// Token: 0x04022EB5 RID: 143029
		private bool IsVehicleSoar;

		// Token: 0x0200C152 RID: 49490
		[NullableContext(0)]
		private class SpeedColorObj
		{
			// Token: 0x0604E4E5 RID: 320741 RVA: 0x015B1DFC File Offset: 0x015AFFFC
			public void Init()
			{
				string color;
				if (this.ColorMap.TryGetValue(EMotorcycleHudColorState.Normal, out color))
				{
					this.ColorMachine.Init(color, null);
					MotorcycleControlHudPanel.SpeedColorObj.UpdateFuncDelegate updateFunc = this.UpdateFunc;
					if (updateFunc == null)
					{
						return;
					}
					FLinearColor color2 = this.ColorMachine.GetColor();
					updateFunc(color2);
				}
			}

			// Token: 0x0604E4E6 RID: 320742 RVA: 0x015B1E4C File Offset: 0x015B004C
			public void Update(float delta)
			{
				if (this.ColorMachine.Update((double)delta))
				{
					MotorcycleControlHudPanel.SpeedColorObj.UpdateFuncDelegate updateFunc = this.UpdateFunc;
					if (updateFunc == null)
					{
						return;
					}
					FLinearColor color = this.ColorMachine.GetColor();
					updateFunc(color);
				}
			}

			// Token: 0x0604E4E7 RID: 320743 RVA: 0x015B1E86 File Offset: 0x015B0086
			public void Clear()
			{
				this.UpdateFunc = null;
			}

			// Token: 0x0403B87B RID: 243835
			[Nullable(1)]
			public readonly Dictionary<EMotorcycleHudColorState, string> ColorMap = new Dictionary<EMotorcycleHudColorState, string>();

			// Token: 0x0403B87C RID: 243836
			[Nullable(1)]
			public readonly MotorcycleSpeedColorMachine ColorMachine = new MotorcycleSpeedColorMachine();

			// Token: 0x0403B87D RID: 243837
			[Nullable(2)]
			public MotorcycleControlHudPanel.SpeedColorObj.UpdateFuncDelegate UpdateFunc;

			// Token: 0x0200CF5C RID: 53084
			// (Invoke) Token: 0x06050994 RID: 330132
			public delegate void UpdateFuncDelegate(in FLinearColor color);
		}

		// Token: 0x0200C153 RID: 49491
		[NullableContext(0)]
		private enum EChildType
		{
			// Token: 0x0403B87F RID: 243839
			LeftItem,
			// Token: 0x0403B880 RID: 243840
			RightItem,
			// Token: 0x0403B881 RID: 243841
			RotateItem
		}

		// Token: 0x0200C154 RID: 49492
		[NullableContext(0)]
		private enum EAlphaState
		{
			// Token: 0x0403B883 RID: 243843
			Normal,
			// Token: 0x0403B884 RID: 243844
			Transparent
		}

		// Token: 0x0200C155 RID: 49493
		[NullableContext(0)]
		private enum EVisibleReason
		{
			// Token: 0x0403B886 RID: 243846
			MotorcycleHudVisible = 1
		}
	}
}
