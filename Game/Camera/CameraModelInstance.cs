using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using AkiClient.Game.Aki.Character.BaseCharacter.Camera;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.Manager;
using CSharpScript.Game.Camera.CameraSubModeController;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Render.Effect.ScreenEffectSystem;
using Cysharp.Threading.Tasks;
using UnrealEngine;

namespace CSharpScript.Game.Camera
{
	// Token: 0x02007090 RID: 28816
	[NullableContext(1)]
	[Nullable(0)]
	public class CameraModelInstance
	{
		// Token: 0x1700A5A4 RID: 42404
		// (get) Token: 0x06045D4D RID: 286029 RVA: 0x0124907D File Offset: 0x0124727D
		public string CameraName { get; }

		// Token: 0x06045D4E RID: 286030 RVA: 0x01249088 File Offset: 0x01247288
		public CameraModelInstance(string cameraName)
		{
			Comparison<CameraSpecificLockTarget> compare;
			if ((compare = CameraModelInstance.<>O.<0>__CompareCameraSpecificLockIdPriority) == null)
			{
				compare = (CameraModelInstance.<>O.<0>__CompareCameraSpecificLockIdPriority = new Comparison<CameraSpecificLockTarget>(CameraModelInstance.CompareCameraSpecificLockIdPriority));
			}
			this.CameraSpecificLockTargetList = new PriorityQueue<CameraSpecificLockTarget>(compare);
			this.DitherEntityGroups = new DisjointSet<long>();
			this.HideHeadEnabledInternal = new HashSet<EHideHeadEnum>();
			this.HideHeadDisabledInternal = new HashSet<EHideHeadDisabledEnum>();
			this.HidePlayerHandle = -1;
			base..ctor();
			this.CameraName = cameraName;
			this.CurrentAimAssistMode = this.DefaultAimAssistModeInternal;
		}

		// Token: 0x1700A5A5 RID: 42405
		// (get) Token: 0x06045D4F RID: 286031 RVA: 0x01249237 File Offset: 0x01247437
		[Nullable(2)]
		public APlayerCameraManager PlayerCameraManager
		{
			[NullableContext(2)]
			get
			{
				if (this.CameraName == "MainCamera")
				{
					return Global.CharacterCameraManager;
				}
				return this.PlayerCameraManagerInternal;
			}
		}

		// Token: 0x1700A5A6 RID: 42406
		// (get) Token: 0x06045D50 RID: 286032 RVA: 0x01249257 File Offset: 0x01247457
		public double CameraBaseYawSensitivity
		{
			get
			{
				return this.CameraBaseYawSensitivityInternal;
			}
		}

		// Token: 0x1700A5A7 RID: 42407
		// (get) Token: 0x06045D51 RID: 286033 RVA: 0x0124925F File Offset: 0x0124745F
		public double CameraBasePitchSensitivity
		{
			get
			{
				return this.CameraBasePitchSensitivityInternal;
			}
		}

		// Token: 0x1700A5A8 RID: 42408
		// (get) Token: 0x06045D52 RID: 286034 RVA: 0x01249267 File Offset: 0x01247467
		public double CameraAimingYawSensitivity
		{
			get
			{
				return this.CameraAimingYawSensitivityInternal;
			}
		}

		// Token: 0x1700A5A9 RID: 42409
		// (get) Token: 0x06045D53 RID: 286035 RVA: 0x0124926F File Offset: 0x0124746F
		public double CameraAimingPitchSensitivity
		{
			get
			{
				return this.CameraAimingPitchSensitivityInternal;
			}
		}

		// Token: 0x1700A5AA RID: 42410
		// (get) Token: 0x06045D54 RID: 286036 RVA: 0x01249277 File Offset: 0x01247477
		public bool IsEnableSoftLockCameraExternal
		{
			get
			{
				return this.IsEnableSoftLockCamera;
			}
		}

		// Token: 0x1700A5AB RID: 42411
		// (get) Token: 0x06045D55 RID: 286037 RVA: 0x01249280 File Offset: 0x01247480
		public float CameraBaseYawSensitivityInputModifier
		{
			get
			{
				if (this.IsEnableSpecificCameraSensitivity)
				{
					return this.SpecificCameraBaseYawSensitivity;
				}
				FightCamera fightCamera = this.FightCamera;
				float? num;
				if (fightCamera == null)
				{
					num = null;
				}
				else
				{
					FightCameraLogicComponent logicComponent = fightCamera.LogicComponent;
					num = ((logicComponent != null) ? new float?(logicComponent.CameraInputController.SpecificCameraBaseYawSensitivity) : null);
				}
				float? num2 = num;
				if (num2.GetValueOrDefault(-1f) > 0f)
				{
					return this.FightCamera.LogicComponent.CameraInputController.SpecificCameraBaseYawSensitivity;
				}
				double cameraBaseYawSensitivityInternal = this.CameraBaseYawSensitivityInternal;
				double num3 = (cameraBaseYawSensitivityInternal < 50.0) ? Singleton<MathUtils>.Instance.RangeClamp(cameraBaseYawSensitivityInternal, 0.0, 50.0, 0.10000000149011612, 1.0) : Singleton<MathUtils>.Instance.RangeClamp(cameraBaseYawSensitivityInternal, 50.0, 100.0, 1.0, 2.0);
				return (float)(this.CameraBaseYawReverseInternal ? (-(float)num3) : num3);
			}
		}

		// Token: 0x1700A5AC RID: 42412
		// (get) Token: 0x06045D56 RID: 286038 RVA: 0x01249380 File Offset: 0x01247580
		public float CameraBasePitchSensitivityInputModifier
		{
			get
			{
				if (this.IsEnableSpecificCameraSensitivity)
				{
					return this.SpecificCameraBasePitchSensitivity;
				}
				FightCamera fightCamera = this.FightCamera;
				float? num;
				if (fightCamera == null)
				{
					num = null;
				}
				else
				{
					FightCameraLogicComponent logicComponent = fightCamera.LogicComponent;
					num = ((logicComponent != null) ? new float?(logicComponent.CameraInputController.SpecificCameraBasePitchSensitivity) : null);
				}
				float? num2 = num;
				if (num2.GetValueOrDefault(-1f) > 0f)
				{
					return this.FightCamera.LogicComponent.CameraInputController.SpecificCameraBasePitchSensitivity;
				}
				double cameraBasePitchSensitivityInternal = this.CameraBasePitchSensitivityInternal;
				double num3 = (cameraBasePitchSensitivityInternal < 50.0) ? Singleton<MathUtils>.Instance.RangeClamp(cameraBasePitchSensitivityInternal, 0.0, 50.0, 0.10000000149011612, 1.0) : Singleton<MathUtils>.Instance.RangeClamp(cameraBasePitchSensitivityInternal, 50.0, 100.0, 1.0, 2.0);
				return (float)(this.CameraBasePitchReverseInternal ? (-(float)num3) : num3);
			}
		}

		// Token: 0x1700A5AD RID: 42413
		// (get) Token: 0x06045D57 RID: 286039 RVA: 0x01249480 File Offset: 0x01247680
		public float CameraAimingYawSensitivityInputModifier
		{
			get
			{
				if (this.IsEnableSpecificCameraSensitivity)
				{
					return this.SpecificCameraAimingYawSensitivity;
				}
				FightCamera fightCamera = this.FightCamera;
				float? num;
				if (fightCamera == null)
				{
					num = null;
				}
				else
				{
					FightCameraLogicComponent logicComponent = fightCamera.LogicComponent;
					num = ((logicComponent != null) ? new float?(logicComponent.CameraInputController.SpecificCameraAimingYawSensitivity) : null);
				}
				float? num2 = num;
				if (num2.GetValueOrDefault(-1f) > 0f)
				{
					return this.FightCamera.LogicComponent.CameraInputController.SpecificCameraAimingYawSensitivity;
				}
				double cameraAimingYawSensitivityInternal = this.CameraAimingYawSensitivityInternal;
				double num3 = (cameraAimingYawSensitivityInternal < 50.0) ? Singleton<MathUtils>.Instance.RangeClamp(cameraAimingYawSensitivityInternal, 0.0, 50.0, 0.10000000149011612, 1.0) : Singleton<MathUtils>.Instance.RangeClamp(cameraAimingYawSensitivityInternal, 50.0, 100.0, 1.0, 2.0);
				return (float)(this.CameraAimingYawReverseInternal ? (-(float)num3) : num3);
			}
		}

		// Token: 0x1700A5AE RID: 42414
		// (get) Token: 0x06045D58 RID: 286040 RVA: 0x01249580 File Offset: 0x01247780
		public float CameraAimingPitchSensitivityInputModifier
		{
			get
			{
				if (this.IsEnableSpecificCameraSensitivity)
				{
					return this.SpecificCameraAimingPitchSensitivity;
				}
				FightCamera fightCamera = this.FightCamera;
				float? num;
				if (fightCamera == null)
				{
					num = null;
				}
				else
				{
					FightCameraLogicComponent logicComponent = fightCamera.LogicComponent;
					num = ((logicComponent != null) ? new float?(logicComponent.CameraInputController.SpecificCameraAimingPitchSensitivity) : null);
				}
				float? num2 = num;
				if (num2.GetValueOrDefault(-1f) > 0f)
				{
					return this.FightCamera.LogicComponent.CameraInputController.SpecificCameraAimingPitchSensitivity;
				}
				double cameraAimingPitchSensitivityInternal = this.CameraAimingPitchSensitivityInternal;
				double num3 = (cameraAimingPitchSensitivityInternal < 50.0) ? Singleton<MathUtils>.Instance.RangeClamp(cameraAimingPitchSensitivityInternal, 0.0, 50.0, 0.10000000149011612, 1.0) : Singleton<MathUtils>.Instance.RangeClamp(cameraAimingPitchSensitivityInternal, 50.0, 100.0, 1.0, 2.0);
				return (float)(this.CameraAimingPitchReverseInternal ? (-(float)num3) : num3);
			}
		}

		// Token: 0x1700A5AF RID: 42415
		// (get) Token: 0x06045D59 RID: 286041 RVA: 0x01249680 File Offset: 0x01247880
		public bool IsCameraResetPitch
		{
			get
			{
				return this.IsCameraResetPitchInternal;
			}
		}

		// Token: 0x1700A5B0 RID: 42416
		// (get) Token: 0x06045D5A RID: 286042 RVA: 0x01249688 File Offset: 0x01247888
		public double MotionBlurModifier
		{
			get
			{
				return (double)((this.MotionBlurValueInternal < 50f) ? Singleton<MathUtils>.Instance.RangeClamp(this.MotionBlurValueInternal, 0f, 50f, 0.1f, 0.25f) : Singleton<MathUtils>.Instance.RangeClamp(this.MotionBlurValueInternal, 50f, 100f, 0.25f, 0.4f));
			}
		}

		// Token: 0x1700A5B1 RID: 42417
		// (get) Token: 0x06045D5B RID: 286043 RVA: 0x012496F0 File Offset: 0x012478F0
		public double CameraSettingArmLengthPercentage
		{
			get
			{
				if (!this.FightCamera.LogicComponent.ContainsTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.进入战斗"], false))
				{
					return Singleton<MathUtils>.Instance.RangeClamp(this.CameraSettingNormalAdditionArmLength, 0.0, 100.0, 0.0, 1.0);
				}
				return Singleton<MathUtils>.Instance.RangeClamp(this.CameraSettingFightAdditionArmLength, 0.0, 100.0, 0.0, 1.0);
			}
		}

		// Token: 0x1700A5B2 RID: 42418
		// (get) Token: 0x06045D5C RID: 286044 RVA: 0x01249788 File Offset: 0x01247988
		public EAimAssistMode AimAssistMode
		{
			get
			{
				return this.CurrentAimAssistMode;
			}
		}

		// Token: 0x1700A5B3 RID: 42419
		// (get) Token: 0x06045D5D RID: 286045 RVA: 0x01249790 File Offset: 0x01247990
		[Nullable(2)]
		public FightCamera FightCamera
		{
			[NullableContext(2)]
			get
			{
				return this.FightCameraInternal;
			}
		}

		// Token: 0x1700A5B4 RID: 42420
		// (get) Token: 0x06045D5E RID: 286046 RVA: 0x01249798 File Offset: 0x01247998
		[Nullable(2)]
		public SequenceCamera SequenceCamera
		{
			[NullableContext(2)]
			get
			{
				return this.SequenceCameraInternal;
			}
		}

		// Token: 0x1700A5B5 RID: 42421
		// (get) Token: 0x06045D5F RID: 286047 RVA: 0x012497A0 File Offset: 0x012479A0
		[Nullable(2)]
		public WidgetCamera WidgetCamera
		{
			[NullableContext(2)]
			get
			{
				return this.WidgetCameraInternal;
			}
		}

		// Token: 0x1700A5B6 RID: 42422
		// (get) Token: 0x06045D60 RID: 286048 RVA: 0x012497A8 File Offset: 0x012479A8
		[Nullable(2)]
		public SceneCamera SceneCamera
		{
			[NullableContext(2)]
			get
			{
				return this.SceneCameraInternal;
			}
		}

		// Token: 0x1700A5B7 RID: 42423
		// (get) Token: 0x06045D61 RID: 286049 RVA: 0x012497B0 File Offset: 0x012479B0
		[Nullable(2)]
		public OrbitalCamera OrbitalCamera
		{
			[NullableContext(2)]
			get
			{
				return this.OrbitalCameraInternal;
			}
		}

		// Token: 0x1700A5B8 RID: 42424
		// (get) Token: 0x06045D62 RID: 286050 RVA: 0x012497B8 File Offset: 0x012479B8
		[Nullable(2)]
		public FreeCamera FreeCamera
		{
			[NullableContext(2)]
			get
			{
				return this.FreeCameraInternal;
			}
		}

		// Token: 0x1700A5B9 RID: 42425
		// (get) Token: 0x06045D63 RID: 286051 RVA: 0x012497C0 File Offset: 0x012479C0
		public ECustomCameraMode? CameraMode
		{
			get
			{
				return this.CameraModeInternal;
			}
		}

		// Token: 0x1700A5BA RID: 42426
		// (get) Token: 0x06045D64 RID: 286052 RVA: 0x012497C8 File Offset: 0x012479C8
		public float ShakeModify
		{
			get
			{
				return this.ShakeModifyInternal;
			}
		}

		// Token: 0x1700A5BB RID: 42427
		// (get) Token: 0x06045D65 RID: 286053 RVA: 0x012497D0 File Offset: 0x012479D0
		public double FightCameraFinalDistance
		{
			get
			{
				FightCamera fightCamera = this.FightCamera;
				float? num;
				if (fightCamera == null)
				{
					num = null;
				}
				else
				{
					FightCameraLogicComponent logicComponent = fightCamera.LogicComponent;
					num = ((logicComponent != null) ? new float?(logicComponent.FinalCameraDistance) : null);
				}
				float? num2 = num;
				return (double)num2.GetValueOrDefault();
			}
		}

		// Token: 0x1700A5BC RID: 42428
		// (get) Token: 0x06045D66 RID: 286054 RVA: 0x01249819 File Offset: 0x01247A19
		public bool ViewHideHeadEnabled
		{
			get
			{
				return this.HideHeadDisabledInternal.Count <= 0 && this.HideHeadEnabledInternal.Count > 0;
			}
		}

		// Token: 0x1700A5BD RID: 42429
		// (get) Token: 0x06045D67 RID: 286055 RVA: 0x01249839 File Offset: 0x01247A39
		public bool LogicHideHeadEnabled
		{
			get
			{
				return this.HideHeadEnabledInternal.Count > 0;
			}
		}

		// Token: 0x1700A5BE RID: 42430
		// (get) Token: 0x06045D68 RID: 286056 RVA: 0x01249849 File Offset: 0x01247A49
		public bool Blending
		{
			get
			{
				return this.BlendingInternal;
			}
		}

		// Token: 0x1700A5BF RID: 42431
		// (get) Token: 0x06045D69 RID: 286057 RVA: 0x01249851 File Offset: 0x01247A51
		[Nullable(2)]
		public TimerHandle BlendTimerId
		{
			[NullableContext(2)]
			get
			{
				return this.BlendTimerIdInternal;
			}
		}

		// Token: 0x06045D6A RID: 286058 RVA: 0x0124985C File Offset: 0x01247A5C
		public void SetHideHeadEnabled(bool v, EHideHeadEnum firstPersonType)
		{
			bool flag = this.HideHeadEnabledInternal.Contains(firstPersonType);
			if ((v && flag) || (!v && !flag))
			{
				return;
			}
			if (v)
			{
				this.HideHeadEnabledInternal.Add(firstPersonType);
			}
			else
			{
				this.HideHeadEnabledInternal.Remove(firstPersonType);
				foreach (object obj in Enum.GetValues(typeof(EHideHeadDisabledEnum)))
				{
					EHideHeadDisabledEnum firstPersonDisableType = (EHideHeadDisabledEnum)obj;
					this.SetHideHeadDisabled(false, firstPersonDisableType);
				}
			}
			this.UpdateHeadState();
		}

		// Token: 0x06045D6B RID: 286059 RVA: 0x01249900 File Offset: 0x01247B00
		public void SetHideHeadDisabled(bool v, EHideHeadDisabledEnum firstPersonDisableType)
		{
			bool flag = this.HideHeadDisabledInternal.Contains(firstPersonDisableType);
			if ((v && flag) || (!v && !flag))
			{
				return;
			}
			if (v)
			{
				this.HideHeadDisabledInternal.Add(firstPersonDisableType);
			}
			else
			{
				this.HideHeadDisabledInternal.Remove(firstPersonDisableType);
			}
			this.UpdateHeadState();
		}

		// Token: 0x06045D6C RID: 286060 RVA: 0x0124994C File Offset: 0x01247B4C
		private void UpdateHeadState()
		{
			if (this.ViewHideHeadEnabled)
			{
				FightCamera fightCamera = this.FightCamera;
				bool flag;
				if (fightCamera == null)
				{
					flag = false;
				}
				else
				{
					FightCameraLogicComponent logicComponent = fightCamera.LogicComponent;
					flag = ((logicComponent != null) ? new bool?(logicComponent.ContainsTag(GameplayTagDefine.EGameplayTagId["角色.Common.载具驾驶.摩托骑乘状态"], false)) : null).GetValueOrDefault();
				}
				if (!flag)
				{
					FightCamera fightCamera2 = this.FightCamera;
					bool flag2;
					if (fightCamera2 == null)
					{
						flag2 = false;
					}
					else
					{
						FightCameraLogicComponent logicComponent2 = fightCamera2.LogicComponent;
						flag2 = ((logicComponent2 != null) ? new bool?(logicComponent2.ContainsTag(GameplayTagDefine.EGameplayTagId["功能.第一人称.隐藏头部配置.基于头骨"], false)) : null).GetValueOrDefault();
					}
					if (!flag2)
					{
						FightCamera fightCamera3 = this.FightCamera;
						if (fightCamera3 == null)
						{
							goto IL_107;
						}
						FightCameraLogicComponent logicComponent3 = fightCamera3.LogicComponent;
						if (logicComponent3 == null)
						{
							goto IL_107;
						}
						TsBaseCharacter character = logicComponent3.Character;
						if (character == null)
						{
							goto IL_107;
						}
						CharRenderingComponent charRenderingComponent = character.CharRenderingComponent;
						if (charRenderingComponent == null)
						{
							goto IL_107;
						}
						charRenderingComponent.SetDitherApplyHeadsOnly();
						goto IL_107;
					}
				}
				FightCamera fightCamera4 = this.FightCamera;
				if (fightCamera4 != null)
				{
					FightCameraLogicComponent logicComponent4 = fightCamera4.LogicComponent;
					if (logicComponent4 != null)
					{
						TsBaseCharacter character2 = logicComponent4.Character;
						if (character2 != null)
						{
							CharRenderingComponent charRenderingComponent2 = character2.CharRenderingComponent;
							if (charRenderingComponent2 != null)
							{
								charRenderingComponent2.SetDitherUseHeadMaskHideEffect(true);
							}
						}
					}
				}
				UKuroStaticLibrary.SetConsoleVariableWithCurrentPriority_Int("r.Shadow.EnableCSMStable", 0);
				IL_107:
				FightCamera fightCamera5 = this.FightCamera;
				if (fightCamera5 != null)
				{
					FightCameraLogicComponent logicComponent5 = fightCamera5.LogicComponent;
					if (logicComponent5 != null)
					{
						TsBaseCharacter character3 = logicComponent5.Character;
						if (character3 != null)
						{
							CharRenderingComponent charRenderingComponent3 = character3.CharRenderingComponent;
							if (charRenderingComponent3 != null)
							{
								charRenderingComponent3.SetDitherEffect(0f, ECharacterDitherType.Fight);
							}
						}
					}
				}
				FightCamera fightCamera6 = this.FightCamera;
				if (fightCamera6 != null)
				{
					FightCameraLogicComponent logicComponent6 = fightCamera6.LogicComponent;
					if (logicComponent6 != null)
					{
						TsBaseCharacter character4 = logicComponent6.Character;
						if (character4 != null)
						{
							CharRenderingComponent charRenderingComponent4 = character4.CharRenderingComponent;
							if (charRenderingComponent4 != null)
							{
								charRenderingComponent4.UpdateMaterialEffectsOnly();
							}
						}
					}
				}
				FightCamera fightCamera7 = this.FightCamera;
				if (fightCamera7 == null)
				{
					return;
				}
				FightCameraLogicComponent logicComponent7 = fightCamera7.LogicComponent;
				if (logicComponent7 == null)
				{
					return;
				}
				VehicleActorComponent vehicleActorComponent = logicComponent7.VehicleActorComponent;
				if (vehicleActorComponent == null)
				{
					return;
				}
				vehicleActorComponent.EnterFirstPersonMode();
				return;
			}
			else
			{
				FightCamera fightCamera8 = this.FightCamera;
				bool flag3;
				if (fightCamera8 == null)
				{
					flag3 = false;
				}
				else
				{
					FightCameraLogicComponent logicComponent8 = fightCamera8.LogicComponent;
					flag3 = ((logicComponent8 != null) ? new bool?(logicComponent8.ContainsTag(GameplayTagDefine.EGameplayTagId["角色.Common.载具驾驶.摩托骑乘状态"], false)) : null).GetValueOrDefault();
				}
				if (!flag3)
				{
					FightCamera fightCamera9 = this.FightCamera;
					bool flag4;
					if (fightCamera9 == null)
					{
						flag4 = false;
					}
					else
					{
						FightCameraLogicComponent logicComponent9 = fightCamera9.LogicComponent;
						flag4 = ((logicComponent9 != null) ? new bool?(logicComponent9.ContainsTag(GameplayTagDefine.EGameplayTagId["功能.第一人称.隐藏头部配置.基于头骨"], false)) : null).GetValueOrDefault();
					}
					if (!flag4)
					{
						FightCamera fightCamera10 = this.FightCamera;
						if (fightCamera10 == null)
						{
							goto IL_292;
						}
						FightCameraLogicComponent logicComponent10 = fightCamera10.LogicComponent;
						if (logicComponent10 == null)
						{
							goto IL_292;
						}
						TsBaseCharacter character5 = logicComponent10.Character;
						if (character5 == null)
						{
							goto IL_292;
						}
						CharRenderingComponent charRenderingComponent5 = character5.CharRenderingComponent;
						if (charRenderingComponent5 == null)
						{
							goto IL_292;
						}
						charRenderingComponent5.SetDitherApplyAll();
						goto IL_292;
					}
				}
				FightCamera fightCamera11 = this.FightCamera;
				if (fightCamera11 != null)
				{
					FightCameraLogicComponent logicComponent11 = fightCamera11.LogicComponent;
					if (logicComponent11 != null)
					{
						TsBaseCharacter character6 = logicComponent11.Character;
						if (character6 != null)
						{
							CharRenderingComponent charRenderingComponent6 = character6.CharRenderingComponent;
							if (charRenderingComponent6 != null)
							{
								charRenderingComponent6.SetDitherUseHeadMaskHideEffect(false);
							}
						}
					}
				}
				UKuroStaticLibrary.SetConsoleVariableWithCurrentPriority_Int("r.Shadow.EnableCSMStable", 1);
				IL_292:
				FightCamera fightCamera12 = this.FightCamera;
				if (fightCamera12 != null)
				{
					FightCameraLogicComponent logicComponent12 = fightCamera12.LogicComponent;
					if (logicComponent12 != null)
					{
						TsBaseCharacter character7 = logicComponent12.Character;
						if (character7 != null)
						{
							CharRenderingComponent charRenderingComponent7 = character7.CharRenderingComponent;
							if (charRenderingComponent7 != null)
							{
								charRenderingComponent7.SetDitherEffect(1f, ECharacterDitherType.Fight);
							}
						}
					}
				}
				FightCamera fightCamera13 = this.FightCamera;
				if (fightCamera13 != null)
				{
					FightCameraLogicComponent logicComponent13 = fightCamera13.LogicComponent;
					if (logicComponent13 != null)
					{
						TsBaseCharacter character8 = logicComponent13.Character;
						if (character8 != null)
						{
							CharRenderingComponent charRenderingComponent8 = character8.CharRenderingComponent;
							if (charRenderingComponent8 != null)
							{
								charRenderingComponent8.UpdateMaterialEffectsOnly();
							}
						}
					}
				}
				FightCamera fightCamera14 = this.FightCamera;
				if (fightCamera14 == null)
				{
					return;
				}
				FightCameraLogicComponent logicComponent14 = fightCamera14.LogicComponent;
				if (logicComponent14 == null)
				{
					return;
				}
				VehicleActorComponent vehicleActorComponent2 = logicComponent14.VehicleActorComponent;
				if (vehicleActorComponent2 == null)
				{
					return;
				}
				vehicleActorComponent2.ExitFirstPersonMode();
				return;
			}
		}

		// Token: 0x06045D6D RID: 286061 RVA: 0x01249C7C File Offset: 0x01247E7C
		public unsafe void SetHidePlayer(bool v, bool useDither = false)
		{
			if (!v)
			{
				if (this.HidePlayerEntityId != 0)
				{
					EntityHandle entityById = ModelBase<CreatureModel>.Instance.GetEntityById(this.HidePlayerEntityId);
					CharacterActorComponent characterActorComponent;
					if (entityById == null)
					{
						characterActorComponent = null;
					}
					else
					{
						WorldEntity entity = entityById.Entity;
						characterActorComponent = ((entity != null) ? entity.GetComponent<CharacterActorComponent>() : null);
					}
					CharacterActorComponent characterActorComponent2 = characterActorComponent;
					if (characterActorComponent2 != null)
					{
						if (this.HidePlayerMode == CameraModelInstance.ECameraHidePlayerMode.Dither)
						{
							CharacterDitherEffectController ditherEffectController = characterActorComponent2.Actor.DitherEffectController;
							if (ditherEffectController != null)
							{
								ditherEffectController.EnterAppearEffect(2f, ECharacterDitherType.Temporary, true);
							}
							Log instance = Singleton<Log>.Instance;
							ELogModule module = ELogModule.Camera;
							ELogAuthor author = ELogAuthor.FZX;
							string message = "[CameraHidePlayer] 渐显恢复玩家";
							ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", this.HidePlayerEntityId);
							instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
						}
						else if (this.HidePlayerHandle != -1)
						{
							characterActorComponent2.EnableActor(this.HidePlayerHandle);
							Log instance2 = Singleton<Log>.Instance;
							ELogModule module2 = ELogModule.Camera;
							ELogAuthor author2 = ELogAuthor.FZX;
							string message2 = "[CameraHidePlayer] 恢复第一人称隐藏玩家";
							<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
							*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Id", this.HidePlayerEntityId);
							*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Handle", this.HidePlayerHandle);
							instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
						}
					}
					else if (this.HidePlayerMode == CameraModelInstance.ECameraHidePlayerMode.Instant && this.HidePlayerHandle != -1)
					{
						Log instance3 = Singleton<Log>.Instance;
						ELogModule module3 = ELogModule.Camera;
						ELogAuthor author3 = ELogAuthor.FZX;
						string message3 = "[CameraHidePlayer] 恢复第一人称隐藏玩家失败，隐藏实体不存在";
						<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("Id", this.HidePlayerEntityId);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("Handle", this.HidePlayerHandle);
						instance3.Info(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
					}
				}
				this.HidePlayerHandle = -1;
				this.HidePlayerEntityId = 0;
				this.HidePlayerMode = CameraModelInstance.ECameraHidePlayerMode.None;
				return;
			}
			if (this.HidePlayerEntityId != 0)
			{
				Singleton<Log>.Instance.Info(ELogModule.Camera, ELogAuthor.FZX, "[CameraHidePlayer] 隐藏玩家失败，已经隐藏过一次", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
			if (getCurrentEntity == null || !getCurrentEntity.Valid || getCurrentEntity.Entity == null)
			{
				Singleton<Log>.Instance.Info(ELogModule.Camera, ELogAuthor.FZX, "[CameraHidePlayer] 显隐玩家失败，当前操控角色不存在", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			CharacterActorComponent component = getCurrentEntity.Entity.GetComponent<CharacterActorComponent>();
			if (((component != null) ? component.Actor : null) == null)
			{
				Singleton<Log>.Instance.Info(ELogModule.Camera, ELogAuthor.FZX, "[CameraHidePlayer] 显隐玩家失败，角色Actor不存在", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			this.HidePlayerEntityId = getCurrentEntity.Id;
			if (!useDither)
			{
				this.HidePlayerMode = CameraModelInstance.ECameraHidePlayerMode.Instant;
				this.HidePlayerHandle = component.DisableActor("LevelEventAdjustPlayerCamera.HidePlayer");
				Log instance4 = Singleton<Log>.Instance;
				ELogModule module4 = ELogModule.Camera;
				ELogAuthor author4 = ELogAuthor.FZX;
				string message4 = "[CameraHidePlayer] 第一人称隐藏玩家";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("Id", this.HidePlayerEntityId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("Handle", this.HidePlayerHandle);
				instance4.Info(module4, author4, message4, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 2));
				return;
			}
			CharacterDitherEffectController ditherEffectController2 = component.Actor.DitherEffectController;
			if (ditherEffectController2 == null)
			{
				Singleton<Log>.Instance.Info(ELogModule.Camera, ELogAuthor.FZX, "[CameraHidePlayer] 渐隐玩家失败，Dither组件不存在", default(ReadOnlySpan<ValueTuple<string, object>>));
				this.HidePlayerEntityId = 0;
				return;
			}
			this.HidePlayerMode = CameraModelInstance.ECameraHidePlayerMode.Dither;
			ditherEffectController2.EnterDisappearEffect(2f, ECharacterDitherType.Temporary, true);
			Log instance5 = Singleton<Log>.Instance;
			ELogModule module5 = ELogModule.Camera;
			ELogAuthor author5 = ELogAuthor.FZX;
			string message5 = "[CameraHidePlayer] 渐隐隐藏玩家";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("Id", this.HidePlayerEntityId);
			instance5.Info(module5, author5, message5, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
		}

		// Token: 0x06045D6E RID: 286062 RVA: 0x01249FF0 File Offset: 0x012481F0
		public void SetCameraShakeModify(double modify)
		{
			this.ShakeModifyInternal = (float)Singleton<MathUtils>.Instance.Clamp(modify, 0.0, 2.0);
		}

		// Token: 0x06045D6F RID: 286063 RVA: 0x0124A016 File Offset: 0x01248216
		public void SetCameraMode(ECustomCameraMode mode)
		{
			Singleton<EventSystem>.Instance.Emit<ECustomCameraMode, ECustomCameraMode?, string>(EEventName.CameraModeChanged, mode, this.CameraModeInternal, this.CameraName);
			this.CameraModeInternal = new ECustomCameraMode?(mode);
			Global.PlayerController.ClientSetCameraMode(CameraUtility.GetCameraMode(mode));
		}

		// Token: 0x06045D70 RID: 286064 RVA: 0x0124A054 File Offset: 0x01248254
		private void RefreshAimAssetMode()
		{
			if (this.AimAssistModeMap.Count == 0)
			{
				this.CurrentAimAssistMode = this.DefaultAimAssistModeInternal;
				return;
			}
			this.CurrentAimAssistMode = EAimAssistMode.Closed;
			foreach (KeyValuePair<string, EAimAssistMode> keyValuePair in this.AimAssistModeMap)
			{
				this.CurrentAimAssistMode = (EAimAssistMode)Math.Max((int)this.CurrentAimAssistMode, (int)keyValuePair.Value);
			}
		}

		// Token: 0x06045D71 RID: 286065 RVA: 0x0124A0DC File Offset: 0x012482DC
		public void SetAimAssistMode(EAimAssistMode mode)
		{
			this.DefaultAimAssistModeInternal = mode;
			this.RefreshAimAssetMode();
		}

		// Token: 0x06045D72 RID: 286066 RVA: 0x0124A0EB File Offset: 0x012482EB
		public void SetAimAssistModeWithKey(string key, EAimAssistMode mode)
		{
			this.AimAssistModeMap[key] = mode;
			this.RefreshAimAssetMode();
		}

		// Token: 0x06045D73 RID: 286067 RVA: 0x0124A100 File Offset: 0x01248300
		public void ClearAimAssistModeWithKey(string key)
		{
			this.AimAssistModeMap.Remove(key);
			this.RefreshAimAssetMode();
		}

		// Token: 0x06045D74 RID: 286068 RVA: 0x0124A115 File Offset: 0x01248315
		public void SetIsCameraResetPitch(bool isReset)
		{
			this.IsCameraResetPitchInternal = isReset;
		}

		// Token: 0x06045D75 RID: 286069 RVA: 0x0124A11E File Offset: 0x0124831E
		public void SetCameraBaseYawSensitivity(double sensitivity)
		{
			this.CameraBaseYawSensitivityInternal = Singleton<MathUtils>.Instance.Clamp(sensitivity, 0.0, 100.0);
		}

		// Token: 0x06045D76 RID: 286070 RVA: 0x0124A143 File Offset: 0x01248343
		public void SetCameraBasePitchSensitivity(double sensitivity)
		{
			this.CameraBasePitchSensitivityInternal = Singleton<MathUtils>.Instance.Clamp(sensitivity, 0.0, 100.0);
		}

		// Token: 0x06045D77 RID: 286071 RVA: 0x0124A168 File Offset: 0x01248368
		public void SetCameraAimingYawSensitivity(double sensitivity)
		{
			this.CameraAimingYawSensitivityInternal = Singleton<MathUtils>.Instance.Clamp(sensitivity, 0.0, 100.0);
		}

		// Token: 0x06045D78 RID: 286072 RVA: 0x0124A18D File Offset: 0x0124838D
		public void SetCameraAimingPitchSensitivity(double sensitivity)
		{
			this.CameraAimingPitchSensitivityInternal = Singleton<MathUtils>.Instance.Clamp(sensitivity, 0.0, 100.0);
		}

		// Token: 0x06045D79 RID: 286073 RVA: 0x0124A1B2 File Offset: 0x012483B2
		public void SetCameraBaseYawReverse(bool bIsReverse)
		{
			this.CameraBaseYawReverseInternal = bIsReverse;
		}

		// Token: 0x06045D7A RID: 286074 RVA: 0x0124A1BB File Offset: 0x012483BB
		public void SetCameraBasePitchReverse(bool bIsReverse)
		{
			this.CameraBasePitchReverseInternal = bIsReverse;
		}

		// Token: 0x06045D7B RID: 286075 RVA: 0x0124A1C4 File Offset: 0x012483C4
		public void SetCameraAimingYawReverse(bool bIsReverse)
		{
			this.CameraAimingYawReverseInternal = bIsReverse;
		}

		// Token: 0x06045D7C RID: 286076 RVA: 0x0124A1CD File Offset: 0x012483CD
		public void SetCameraAimingPitchReverse(bool bIsReverse)
		{
			this.CameraAimingPitchReverseInternal = bIsReverse;
		}

		// Token: 0x06045D7D RID: 286077 RVA: 0x0124A1D6 File Offset: 0x012483D6
		public void SetMotionBlurValue(double value)
		{
			this.MotionBlurValueInternal = (float)Singleton<MathUtils>.Instance.Clamp(value, 0.0, 100.0);
			Singleton<GameSettingsManager>.Instance.HandleValueChange(EFunction.MOTIONBLUR, (int)this.MotionBlurValueInternal, EGameSettingsApplyReason.AnyTime);
		}

		// Token: 0x06045D7E RID: 286078 RVA: 0x0124A210 File Offset: 0x01248410
		public void SetBlending(bool blending)
		{
			this.BlendingInternal = blending;
		}

		// Token: 0x06045D7F RID: 286079 RVA: 0x0124A219 File Offset: 0x01248419
		[NullableContext(2)]
		public void SetBlendTimerId(TimerHandle timerId)
		{
			this.BlendTimerIdInternal = timerId;
		}

		// Token: 0x06045D80 RID: 286080 RVA: 0x0124A222 File Offset: 0x01248422
		public void EnableMode(ECustomCameraMode mode)
		{
			this.CameraModeEnabledArray[(int)mode] = true;
		}

		// Token: 0x06045D81 RID: 286081 RVA: 0x0124A231 File Offset: 0x01248431
		public void DisableMode(ECustomCameraMode mode)
		{
			this.CameraModeEnabledArray[(int)mode] = false;
		}

		// Token: 0x06045D82 RID: 286082 RVA: 0x0124A240 File Offset: 0x01248440
		public bool IsModeEnabled(ECustomCameraMode mode)
		{
			return this.CameraModeEnabledArray[(int)mode];
		}

		// Token: 0x06045D83 RID: 286083 RVA: 0x0124A250 File Offset: 0x01248450
		public ECustomCameraMode GetNextMode()
		{
			foreach (int num in this.CameraModeSequence)
			{
				if (this.CameraModeEnabledArray[num])
				{
					return (ECustomCameraMode)num;
				}
			}
			return ECustomCameraMode.LockOn;
		}

		// Token: 0x06045D84 RID: 286084 RVA: 0x0124A2B4 File Offset: 0x012484B4
		public bool IsInHigherMode(ECustomCameraMode mode)
		{
			return this.CameraMode != null && this.CameraModePriorityValues[(int)this.CameraMode.Value] > this.CameraModePriorityValues[(int)mode];
		}

		// Token: 0x06045D85 RID: 286085 RVA: 0x0124A2FA File Offset: 0x012484FA
		public void SetAimAssistEnable(bool isEnable)
		{
			this.IsAimAssistEnable = isEnable;
		}

		// Token: 0x06045D86 RID: 286086 RVA: 0x0124A303 File Offset: 0x01248503
		public bool GetAimAssistEnable()
		{
			return this.IsAimAssistEnable;
		}

		// Token: 0x06045D87 RID: 286087 RVA: 0x0124A30C File Offset: 0x0124850C
		public int EnableSoftLock(string reason)
		{
			HashSet<int> softLockEnableHandleSet = this.SoftLockEnableHandleSet;
			int num = this.SoftLockEnableHandle + 1;
			this.SoftLockEnableHandle = num;
			softLockEnableHandleSet.Add(num);
			return this.SoftLockEnableHandle;
		}

		// Token: 0x06045D88 RID: 286088 RVA: 0x0124A33C File Offset: 0x0124853C
		public void DisableSoftLock(int enableHandle, string reason)
		{
			if (!this.SoftLockEnableHandleSet.Contains(enableHandle))
			{
				return;
			}
			this.SoftLockEnableHandleSet.Remove(enableHandle);
		}

		// Token: 0x06045D89 RID: 286089 RVA: 0x0124A35A File Offset: 0x0124855A
		public void SetSettingSoftLockState(bool isEnable)
		{
			this.IsEnableSoftLockCamera = isEnable;
		}

		// Token: 0x06045D8A RID: 286090 RVA: 0x0124A363 File Offset: 0x01248563
		public bool IsSoftLockEnable()
		{
			return this.IsEnableSoftLockCamera || this.SoftLockEnableHandleSet.Count > 0;
		}

		// Token: 0x06045D8B RID: 286091 RVA: 0x0124A380 File Offset: 0x01248580
		public int EnableCameraSpecificLockEntity(int entityId, int priority)
		{
			int num = this.CameraLockId + 1;
			this.CameraLockId = num;
			CameraSpecificLockEntity cameraSpecificLockEntity = new CameraSpecificLockEntity(entityId, priority, num);
			this.CameraSpecificLockTargetList.Push(cameraSpecificLockEntity);
			this.CameraSpecificLockTargetMap[cameraSpecificLockEntity.Id] = cameraSpecificLockEntity;
			return cameraSpecificLockEntity.Id;
		}

		// Token: 0x06045D8C RID: 286092 RVA: 0x0124A3CC File Offset: 0x012485CC
		public int EnableCameraSpecificLockLocation(Vector location, int priority)
		{
			int num = this.CameraLockId + 1;
			this.CameraLockId = num;
			CameraSpecificLocLocation cameraSpecificLocLocation = new CameraSpecificLocLocation(location, priority, num);
			this.CameraSpecificLockTargetList.Push(cameraSpecificLocLocation);
			this.CameraSpecificLockTargetMap[cameraSpecificLocLocation.Id] = cameraSpecificLocLocation;
			return cameraSpecificLocLocation.Id;
		}

		// Token: 0x06045D8D RID: 286093 RVA: 0x0124A418 File Offset: 0x01248618
		public void DisableCameraSpecificLockTarget(int id)
		{
			CameraSpecificLockTarget cameraSpecificLockTarget;
			if (!this.CameraSpecificLockTargetMap.TryGetValue(id, out cameraSpecificLockTarget))
			{
				return;
			}
			cameraSpecificLockTarget.MarkDelete = true;
		}

		// Token: 0x06045D8E RID: 286094 RVA: 0x0124A440 File Offset: 0x01248640
		[NullableContext(2)]
		public CameraSpecificLockTarget GetCameraSpecificLockTarget()
		{
			while (!this.CameraSpecificLockTargetList.Empty)
			{
				CameraSpecificLockTarget top = this.CameraSpecificLockTargetList.Top;
				if (top == null)
				{
					return null;
				}
				if (!top.MarkDelete && top.IsValid())
				{
					return top;
				}
				this.CameraSpecificLockTargetList.Pop();
				this.CameraSpecificLockTargetMap.Remove(top.Id);
			}
			return null;
		}

		// Token: 0x06045D8F RID: 286095 RVA: 0x0124A4A0 File Offset: 0x012486A0
		public void PlaySpecialMovieCamera(string movieCameraConfigRowName, [Nullable(2)] Action<bool> callback = null)
		{
			if (this.CameraMovieModeController == null)
			{
				return;
			}
			this.CameraMovieModeController.PlaySpecialMovieCamera(movieCameraConfigRowName, callback).Forget();
		}

		// Token: 0x06045D90 RID: 286096 RVA: 0x0124A4BD File Offset: 0x012486BD
		public bool IsPlayingSpecialMovieCamera(string specialMovieCameraConfigKey)
		{
			return this.CameraMovieModeController != null && this.CameraMovieModeController.IsPlayingSpecialMovieCamera(specialMovieCameraConfigKey);
		}

		// Token: 0x06045D91 RID: 286097 RVA: 0x0124A4D5 File Offset: 0x012486D5
		public void PlayMovieCamera(string movieCameraConfigRowName, int initialPlayCameraIndex = -1, [Nullable(2)] Action<bool> callback = null)
		{
			if (this.CameraMovieModeController == null)
			{
				return;
			}
			this.CameraMovieModeController.PlayMovieCamera(movieCameraConfigRowName, initialPlayCameraIndex, callback).Forget();
		}

		// Token: 0x06045D92 RID: 286098 RVA: 0x0124A4F3 File Offset: 0x012486F3
		public void PauseMovieCamera()
		{
			if (this.CameraMovieModeController == null)
			{
				return;
			}
			this.CameraMovieModeController.PauseMovieCamera();
		}

		// Token: 0x06045D93 RID: 286099 RVA: 0x0124A509 File Offset: 0x01248709
		public void ResumeMovieCamera()
		{
			if (this.CameraMovieModeController == null)
			{
				return;
			}
			this.CameraMovieModeController.ResumeMovieCamera();
		}

		// Token: 0x06045D94 RID: 286100 RVA: 0x0124A51F File Offset: 0x0124871F
		public void StopMovieCamera([Nullable(2)] Action<bool> callback = null, string reason = "外部调用,停止播放")
		{
			if (this.CameraMovieModeController == null)
			{
				return;
			}
			this.CameraMovieModeController.StopMovieCamera(callback, reason);
		}

		// Token: 0x06045D95 RID: 286101 RVA: 0x0124A538 File Offset: 0x01248738
		public bool HasLockTarget()
		{
			FightCamera fightCamera = this.FightCamera;
			if (((fightCamera != null) ? fightCamera.LogicComponent : null) == null)
			{
				return false;
			}
			EntityHandle targetEntity = this.FightCamera.LogicComponent.TargetEntity;
			return targetEntity != null && targetEntity.Valid && this.FightCamera.LogicComponent.IsTargetLocationValid;
		}

		// Token: 0x06045D96 RID: 286102 RVA: 0x0124A58B File Offset: 0x0124878B
		public bool GetLockTargetLocation(Vector outVector)
		{
			outVector.Reset();
			if (!this.HasLockTarget())
			{
				return false;
			}
			outVector.DeepCopy(this.FightCamera.LogicComponent.TargetLocation);
			return true;
		}

		// Token: 0x06045D97 RID: 286103 RVA: 0x0124A5B4 File Offset: 0x012487B4
		public void SaveSeqCamera()
		{
			SequenceCamera sequenceCamera = this.SequenceCamera;
			SeqCameraThings savedSeqCameraThings;
			if (sequenceCamera == null)
			{
				savedSeqCameraThings = null;
			}
			else
			{
				SequenceCameraPlayerComponent playerComponent = sequenceCamera.PlayerComponent;
				savedSeqCameraThings = ((playerComponent != null) ? playerComponent.SaveSeqCamera() : null);
			}
			this.SavedSeqCameraThings = savedSeqCameraThings;
		}

		// Token: 0x06045D98 RID: 286104 RVA: 0x0124A5DA File Offset: 0x012487DA
		[NullableContext(2)]
		public SeqCameraThings GetSavedSeqCameraThings()
		{
			return this.SavedSeqCameraThings;
		}

		// Token: 0x06045D99 RID: 286105 RVA: 0x0124A5E2 File Offset: 0x012487E2
		public void ResetSavedSeqCameraThings()
		{
			this.SavedSeqCameraThings = null;
		}

		// Token: 0x06045D9A RID: 286106 RVA: 0x0124A5EC File Offset: 0x012487EC
		public bool IsToLockOnCameraMode()
		{
			ECustomCameraMode? cameraMode = this.CameraMode;
			ECustomCameraMode ecustomCameraMode = ECustomCameraMode.LockOn;
			return cameraMode.GetValueOrDefault() == ecustomCameraMode & cameraMode != null;
		}

		// Token: 0x06045D9B RID: 286107 RVA: 0x0124A614 File Offset: 0x01248814
		public bool IsToSceneCameraMode()
		{
			ECustomCameraMode? cameraMode = this.CameraMode;
			ECustomCameraMode ecustomCameraMode = ECustomCameraMode.Scene;
			return cameraMode.GetValueOrDefault() == ecustomCameraMode & cameraMode != null;
		}

		// Token: 0x06045D9C RID: 286108 RVA: 0x0124A63C File Offset: 0x0124883C
		public void SetViewInfo(Vector2D viewLocation, Vector2D viewSize, bool enableScissorOffset)
		{
			this.SeparateCameraLayout.SetViewInfo(viewLocation, viewSize, enableScissorOffset);
		}

		// Token: 0x06045D9D RID: 286109 RVA: 0x0124A64C File Offset: 0x0124884C
		public void SetTargetViewInfo(float blendTime, Vector2D targetViewLocation, Vector2D targetViewSize, bool enableScissorOffset = false, [Nullable(2)] UCurveFloat blendCurve = null, [Nullable(2)] Action callback = null)
		{
			this.SeparateCameraLayout.SetTargetViewInfo(blendTime, targetViewLocation, targetViewSize, enableScissorOffset, blendCurve, callback);
		}

		// Token: 0x06045D9E RID: 286110 RVA: 0x0124A662 File Offset: 0x01248862
		public void UpdateCameraLayout(float deltaTime)
		{
			this.SeparateCameraLayout.BlendToTarget(deltaTime);
			this.UpdateBoundScreenEffectsAlpha();
		}

		// Token: 0x06045D9F RID: 286111 RVA: 0x0124A676 File Offset: 0x01248876
		public void BindScreenEffect(int handleId)
		{
			this.BoundScreenEffectHandleIds.Add(handleId);
		}

		// Token: 0x06045DA0 RID: 286112 RVA: 0x0124A685 File Offset: 0x01248885
		public void UnbindScreenEffect(int handleId)
		{
			this.BoundScreenEffectHandleIds.Remove(handleId);
			ScreenEffectModel instance = ModelBase<ScreenEffectModel>.Instance;
			if (instance == null)
			{
				return;
			}
			instance.TrySetScreenEffectAlpha(handleId, 0f);
		}

		// Token: 0x06045DA1 RID: 286113 RVA: 0x0124A6AC File Offset: 0x012488AC
		private void UpdateBoundScreenEffectsAlpha()
		{
			if (this.BoundScreenEffectHandleIds.Count == 0)
			{
				return;
			}
			SeparateCameraLayout separateCameraLayout = this.SeparateCameraLayout;
			if (separateCameraLayout == null)
			{
				return;
			}
			ScreenEffectModel instance = ModelBase<ScreenEffectModel>.Instance;
			double num = separateCameraLayout.CurrentViewLocation.X + separateCameraLayout.CurrentViewSize.X;
			double num2 = double.IsFinite(num) ? Singleton<MathUtils>.Instance.Clamp(num, 0.0, 1.0) : 0.0;
			foreach (int num3 in this.BoundScreenEffectHandleIds.ToArray<int>())
			{
				if (!instance.TrySetScreenEffectAlpha(num3, (float)num2))
				{
					this.BoundScreenEffectHandleIds.Remove(num3);
				}
			}
		}

		// Token: 0x06045DA2 RID: 286114 RVA: 0x0124A762 File Offset: 0x01248962
		public bool IsEnableScissorOffsetCenter()
		{
			SeparateCameraLayout separateCameraLayout = this.SeparateCameraLayout;
			return separateCameraLayout != null && separateCameraLayout.EnableScissorOffset;
		}

		// Token: 0x06045DA3 RID: 286115 RVA: 0x0124A778 File Offset: 0x01248978
		public void UpdateCameraDitherRadius()
		{
			if (Singleton<Time>.Instance.Now < (double)this.NextFindStartHideDistanceTime)
			{
				return;
			}
			this.NextFindStartHideDistanceTime = (float)(Singleton<Time>.Instance.Now + 1000.0);
			List<EntityHandle> list = new List<EntityHandle>();
			ModelBase<CreatureModel>.Instance.GetEntitiesInRange(2000f, EEntityTypeQuery.Character, list, true, false);
			this.CameraDitherStartHideDistance = this.FightCamera.LogicComponent.StartHideDistance;
			foreach (EntityHandle entityHandle in list)
			{
				WorldEntity entity = entityHandle.Entity;
				if (entity != null && entity.Active)
				{
					CharacterActorComponent component = entityHandle.Entity.GetComponent<CharacterActorComponent>();
					if (component != null && component.StartHideDistance > this.CameraDitherStartHideDistance)
					{
						this.CameraDitherStartHideDistance = component.StartHideDistance;
					}
				}
			}
		}

		// Token: 0x06045DA4 RID: 286116 RVA: 0x0124A864 File Offset: 0x01248A64
		public bool Init()
		{
			if (this.CameraName != "MainCamera")
			{
				APlayerController playerController = Global.PlayerController;
				this.PlayerCameraManagerInternal = ((playerController != null) ? playerController.SpawnPlayerCameraManager() : null);
				if (this.PlayerCameraManagerInternal != null)
				{
					UActorComponent componentByClass = this.PlayerCameraManagerInternal.GetComponentByClass(UAkComponent.StaticClass());
					this.PlayerCameraManagerInternal.K2_DestroyComponent(componentByClass);
				}
			}
			this.SeparateCameraLayout = new SeparateCameraLayout(this);
			if (this.CameraName == "MainCamera")
			{
				this.SeparateCameraLayout.SetViewInfo(Vector2D.Create(0.0, 0.0), Vector2D.Create(1.0, 1.0), false);
			}
			else
			{
				this.SeparateCameraLayout.SetViewInfo(Vector2D.Create(1.0, 0.0), Vector2D.Create(0.0, 1.0), false);
			}
			this.SequenceCameraInternal = Singleton<EntitySystem>.Instance.Create<SequenceCamera>(-100, new EntityArgs<CameraModelInstance>(this));
			Singleton<EntitySystem>.Instance.Init(this.SequenceCameraInternal);
			Singleton<EntitySystem>.Instance.Start(this.SequenceCameraInternal);
			Singleton<EntitySystem>.Instance.Activate(this.SequenceCameraInternal);
			Singleton<EntitySystem>.Instance.PostActive(this.SequenceCameraInternal);
			this.SequenceCameraInternal.SetTimeDilation(Singleton<Time>.Instance.TimeDilation);
			this.FightCameraInternal = Singleton<EntitySystem>.Instance.Create<FightCamera>(-100, new EntityArgs<CameraModelInstance>(this));
			Singleton<EntitySystem>.Instance.Init(this.FightCameraInternal);
			Singleton<EntitySystem>.Instance.Start(this.FightCameraInternal);
			Singleton<EntitySystem>.Instance.Activate(this.FightCameraInternal);
			Singleton<EntitySystem>.Instance.PostActive(this.FightCameraInternal);
			this.FightCameraInternal.SetTimeDilation(Singleton<Time>.Instance.TimeDilation);
			this.WidgetCameraInternal = Singleton<EntitySystem>.Instance.Create<WidgetCamera>(-100, new EntityArgs<CameraModelInstance>(this));
			Singleton<EntitySystem>.Instance.Init(this.WidgetCameraInternal);
			Singleton<EntitySystem>.Instance.Start(this.WidgetCameraInternal);
			Singleton<EntitySystem>.Instance.Activate(this.WidgetCameraInternal);
			Singleton<EntitySystem>.Instance.PostActive(this.WidgetCameraInternal);
			this.WidgetCameraInternal.SetTimeDilation(Singleton<Time>.Instance.TimeDilation);
			this.SceneCameraInternal = Singleton<EntitySystem>.Instance.Create<SceneCamera>(-100, new EntityArgs<CameraModelInstance>(this));
			Singleton<EntitySystem>.Instance.Init(this.SceneCameraInternal);
			Singleton<EntitySystem>.Instance.Start(this.SceneCameraInternal);
			Singleton<EntitySystem>.Instance.Activate(this.SceneCameraInternal);
			Singleton<EntitySystem>.Instance.PostActive(this.SceneCameraInternal);
			this.SceneCameraInternal.SetTimeDilation(Singleton<Time>.Instance.TimeDilation);
			this.OrbitalCameraInternal = Singleton<EntitySystem>.Instance.Create<OrbitalCamera>(-100, new EntityArgs<CameraModelInstance>(this));
			Singleton<EntitySystem>.Instance.Init(this.OrbitalCameraInternal);
			Singleton<EntitySystem>.Instance.Start(this.OrbitalCameraInternal);
			Singleton<EntitySystem>.Instance.Activate(this.OrbitalCameraInternal);
			Singleton<EntitySystem>.Instance.PostActive(this.OrbitalCameraInternal);
			this.OrbitalCameraInternal.SetTimeDilation(Singleton<Time>.Instance.TimeDilation);
			Global.CharacterCameraManager.CameraModifyCustomTimeDilation = Singleton<Time>.Instance.TimeDilation;
			this.CameraTransform = new FTransformDouble?(new FTransformDouble());
			this.CameraMovieModeController = new CameraMovieModeController();
			this.CameraMovieModeController.Start(this);
			for (int i = 0; i <= 5; i++)
			{
				this.CameraModeEnabledArray.Add(false);
				this.CameraModePriorityValues.Add(0);
			}
			this.CameraModeEnabledArray[0] = true;
			this.CameraModeSequence.Add(1);
			this.CameraModeSequence.Add(2);
			this.CameraModeSequence.Add(3);
			this.CameraModeSequence.Add(4);
			this.CameraModeSequence.Add(5);
			this.CameraModeSequence.Add(0);
			for (int j = 0; j < this.CameraModeSequence.Count; j++)
			{
				this.CameraModePriorityValues[this.CameraModeSequence[j]] = this.CameraModeSequence.Count - j;
			}
			this.SavedSeqCameraThings = null;
			Singleton<EventSystem>.Instance.Add<float, string>(EEventName.CameraViewTargetChanged, new Action<float, string>(this.OnCameraViewTargetChanged));
			return this.FightCameraInternal.Valid && this.SequenceCameraInternal.Valid && this.WidgetCameraInternal.Valid && this.SceneCameraInternal.Valid && this.OrbitalCameraInternal.Valid;
		}

		// Token: 0x06045DA5 RID: 286117 RVA: 0x0124ACF0 File Offset: 0x01248EF0
		public bool Clear()
		{
			Singleton<EventSystem>.Instance.Remove<float, string>(EEventName.CameraViewTargetChanged, new Action<float, string>(this.OnCameraViewTargetChanged));
			this.BoundScreenEffectHandleIds.Clear();
			this.CameraSpecificLockTargetList.Clear();
			this.CameraSpecificLockTargetMap.Clear();
			Global.CharacterCameraManager.CameraModifyCustomTimeDilation = 1f;
			bool flag = Singleton<EntitySystem>.Instance.Destroy<FightCamera>(this.FightCameraInternal);
			this.FightCameraInternal = null;
			bool flag2 = flag & Singleton<EntitySystem>.Instance.Destroy<SequenceCamera>(this.SequenceCameraInternal);
			this.SequenceCameraInternal = null;
			bool flag3 = flag2 & Singleton<EntitySystem>.Instance.Destroy<WidgetCamera>(this.WidgetCameraInternal);
			this.WidgetCameraInternal = null;
			bool flag4 = flag3 & Singleton<EntitySystem>.Instance.Destroy<SceneCamera>(this.SceneCameraInternal);
			this.SceneCameraInternal = null;
			bool flag5 = flag4 & Singleton<EntitySystem>.Instance.Destroy<OrbitalCamera>(this.OrbitalCameraInternal);
			this.OrbitalCameraInternal = null;
			bool result = flag5 & this.DestroyFreeCamera();
			this.CameraTransform = null;
			this.SavedSeqCameraThings = null;
			CameraMovieModeController cameraMovieModeController = this.CameraMovieModeController;
			if (cameraMovieModeController != null)
			{
				cameraMovieModeController.End();
			}
			this.CameraMovieModeController = null;
			this.DitherEntityGroups.Clear();
			if (this.CameraName != "MainCamera" && this.PlayerCameraManagerInternal != null)
			{
				APlayerController playerController = Global.PlayerController;
				if (playerController != null)
				{
					playerController.AdditionalPlayerCameraManagers.Remove(this.PlayerCameraManagerInternal);
				}
				this.PlayerCameraManagerInternal.K2_DestroyActor();
				this.PlayerCameraManagerInternal = null;
			}
			return result;
		}

		// Token: 0x06045DA6 RID: 286118 RVA: 0x0124AE48 File Offset: 0x01249048
		public bool CreateFreeCamera()
		{
			this.FreeCameraInternal = Singleton<EntitySystem>.Instance.Create<FreeCamera>(-100, new EntityArgs<CameraModelInstance>(this));
			Singleton<EntitySystem>.Instance.Init(this.FreeCameraInternal);
			Singleton<EntitySystem>.Instance.Start(this.FreeCameraInternal);
			Singleton<EntitySystem>.Instance.Activate(this.FreeCameraInternal);
			Singleton<EntitySystem>.Instance.PostActive(this.FreeCameraInternal);
			this.FreeCameraInternal.SetTimeDilation(Singleton<Time>.Instance.TimeDilation);
			return this.FreeCameraInternal.Valid;
		}

		// Token: 0x06045DA7 RID: 286119 RVA: 0x0124AED4 File Offset: 0x012490D4
		public bool DestroyFreeCamera()
		{
			if (this.FreeCameraInternal == null)
			{
				return true;
			}
			bool result = Singleton<EntitySystem>.Instance.Destroy<FreeCamera>(this.FreeCameraInternal);
			this.FreeCameraInternal = null;
			return result;
		}

		// Token: 0x06045DA8 RID: 286120 RVA: 0x0124AEF8 File Offset: 0x012490F8
		private void OnCameraViewTargetChanged(float blendTime, string cameraName)
		{
			if (cameraName != this.CameraName)
			{
				return;
			}
			if (!this.LogicHideHeadEnabled)
			{
				return;
			}
			ECustomCameraMode? cameraMode = this.CameraMode;
			ECustomCameraMode ecustomCameraMode = ECustomCameraMode.Widget;
			if (cameraMode.GetValueOrDefault() == ecustomCameraMode & cameraMode != null)
			{
				this.SetHideHeadDisabled(true, EHideHeadDisabledEnum.UI);
				FightCamera fightCamera = this.FightCamera;
				if (fightCamera != null)
				{
					FightCameraLogicComponent logicComponent = fightCamera.LogicComponent;
					if (logicComponent != null)
					{
						logicComponent.ForceTickOutSide();
					}
				}
				FightCamera fightCamera2 = this.FightCamera;
				if (fightCamera2 == null)
				{
					return;
				}
				FightCameraLogicComponent logicComponent2 = fightCamera2.LogicComponent;
				if (logicComponent2 == null)
				{
					return;
				}
				TsBaseCharacter character = logicComponent2.Character;
				if (character == null)
				{
					return;
				}
				CharRenderingComponent charRenderingComponent = character.CharRenderingComponent;
				if (charRenderingComponent == null)
				{
					return;
				}
				charRenderingComponent.UpdateMaterialEffectsOnly();
				return;
			}
			else
			{
				this.SetHideHeadDisabled(false, EHideHeadDisabledEnum.UI);
				FightCamera fightCamera3 = this.FightCamera;
				if (fightCamera3 != null)
				{
					FightCameraLogicComponent logicComponent3 = fightCamera3.LogicComponent;
					if (logicComponent3 != null)
					{
						logicComponent3.ForceTickOutSide();
					}
				}
				FightCamera fightCamera4 = this.FightCamera;
				if (fightCamera4 == null)
				{
					return;
				}
				FightCameraLogicComponent logicComponent4 = fightCamera4.LogicComponent;
				if (logicComponent4 == null)
				{
					return;
				}
				TsBaseCharacter character2 = logicComponent4.Character;
				if (character2 == null)
				{
					return;
				}
				CharRenderingComponent charRenderingComponent2 = character2.CharRenderingComponent;
				if (charRenderingComponent2 == null)
				{
					return;
				}
				charRenderingComponent2.UpdateMaterialEffectsOnly();
				return;
			}
		}

		// Token: 0x06045DA9 RID: 286121 RVA: 0x0124AFDF File Offset: 0x012491DF
		private static int CompareCameraSpecificLockIdPriority(CameraSpecificLockTarget a, CameraSpecificLockTarget b)
		{
			if (a.Priority == b.Priority)
			{
				return -1;
			}
			return b.Priority - a.Priority;
		}

		// Token: 0x04027188 RID: 160136
		private const int CAMERA_TICK_PRIORITY = -100;

		// Token: 0x04027189 RID: 160137
		private const int CAMERA_DEFAULT_SENSITIVITY = 50;

		// Token: 0x0402718A RID: 160138
		private const int CAMERA_MAX_SENSITIVITY = 100;

		// Token: 0x0402718B RID: 160139
		private const int CAMERA_MIN_SENSITIVITY = 0;

		// Token: 0x0402718C RID: 160140
		private const int CAMERA_DEFAULT_SENSITIVITY_MODIFIER = 1;

		// Token: 0x0402718D RID: 160141
		private const int CAMERA_MAX_SENSITIVITY_MODIFIER = 2;

		// Token: 0x0402718E RID: 160142
		private const float CAMERA_MIN_SENSITIVITY_MODIFIER = 0.1f;

		// Token: 0x0402718F RID: 160143
		private const int MOTION_BLUR_DEFAULT_VALUE = 50;

		// Token: 0x04027190 RID: 160144
		private const int MOTION_BLUR_MAX_VALUE = 100;

		// Token: 0x04027191 RID: 160145
		private const int MOTION_BLUR_MIN_VALUE = 0;

		// Token: 0x04027192 RID: 160146
		private const float MOTION_BLUR_DEFAULT_MODIFIER = 0.25f;

		// Token: 0x04027193 RID: 160147
		private const float MOTION_BLUR_MAX_MODIFIER = 0.4f;

		// Token: 0x04027194 RID: 160148
		private const float MOTION_BLUR_MIN_MODIFIER = 0.1f;

		// Token: 0x04027195 RID: 160149
		private const bool CAMERA_DEFAULT_REVERSE = false;

		// Token: 0x04027196 RID: 160150
		private const int CAMERA_ADDITION_ARM_LENGTH_VALUE_MAX = 100;

		// Token: 0x04027197 RID: 160151
		private const int CAMERA_ADDITION_ARM_LENGTH_VALUE_DEFAULT = 50;

		// Token: 0x04027198 RID: 160152
		private const int CAMERA_ADDITION_ARM_LENGTH_VALUE_MIN = 0;

		// Token: 0x04027199 RID: 160153
		private const int CAMERA_SHAKE_MODIFIER_MIN = 0;

		// Token: 0x0402719A RID: 160154
		private const int CAMERA_SHAKE_MODIFIER_MAX = 2;

		// Token: 0x0402719B RID: 160155
		private const float HIDE_PLAYER_DITHER_SPEED_RATE = 2f;

		// Token: 0x0402719D RID: 160157
		public bool AimAssistDebugDraw;

		// Token: 0x0402719E RID: 160158
		public bool CameraDebugToolEnabled;

		// Token: 0x0402719F RID: 160159
		public bool CameraDebugToolDrawRotator;

		// Token: 0x040271A0 RID: 160160
		public bool CameraDebugToolDrawCameraCollision;

		// Token: 0x040271A1 RID: 160161
		public bool CameraDebugToolDrawSpringArm;

		// Token: 0x040271A2 RID: 160162
		public bool CameraDebugToolDrawFocusTargetLine;

		// Token: 0x040271A3 RID: 160163
		public bool CameraDebugToolDrawSpringArmEdgeRange;

		// Token: 0x040271A4 RID: 160164
		public bool CameraDebugToolDrawLockCameraMoveLine;

		// Token: 0x040271A5 RID: 160165
		public bool CameraDebugToolDrawSettlementCamera;

		// Token: 0x040271A6 RID: 160166
		public bool CameraDebugToolDrawCameraZone;

		// Token: 0x040271A7 RID: 160167
		public bool CameraDebugToolDrawCameraRotator;

		// Token: 0x040271A8 RID: 160168
		public bool UiCameraDebugToolEnabled;

		// Token: 0x040271A9 RID: 160169
		[Nullable(2)]
		private APlayerCameraManager PlayerCameraManagerInternal;

		// Token: 0x040271AA RID: 160170
		[Nullable(2)]
		public AActor CurrentCameraActor;

		// Token: 0x040271AB RID: 160171
		[Nullable(2)]
		public UCameraComponent CurrentCameraComponent;

		// Token: 0x040271AC RID: 160172
		public Vector CameraLocation = Vector.Create();

		// Token: 0x040271AD RID: 160173
		public Rotator CameraRotator = Rotator.Create();

		// Token: 0x040271AE RID: 160174
		public FTransformDouble? CameraTransform;

		// Token: 0x040271AF RID: 160175
		public float CameraDitherStartHideDistance;

		// Token: 0x040271B0 RID: 160176
		public float NextFindStartHideDistanceTime;

		// Token: 0x040271B1 RID: 160177
		[Nullable(2)]
		private FightCamera FightCameraInternal;

		// Token: 0x040271B2 RID: 160178
		[Nullable(2)]
		private SequenceCamera SequenceCameraInternal;

		// Token: 0x040271B3 RID: 160179
		[Nullable(2)]
		private WidgetCamera WidgetCameraInternal;

		// Token: 0x040271B4 RID: 160180
		[Nullable(2)]
		private SceneCamera SceneCameraInternal;

		// Token: 0x040271B5 RID: 160181
		[Nullable(2)]
		private OrbitalCamera OrbitalCameraInternal;

		// Token: 0x040271B6 RID: 160182
		[Nullable(2)]
		private FreeCamera FreeCameraInternal;

		// Token: 0x040271B7 RID: 160183
		private ECustomCameraMode? CameraModeInternal;

		// Token: 0x040271B8 RID: 160184
		private readonly List<bool> CameraModeEnabledArray = new List<bool>();

		// Token: 0x040271B9 RID: 160185
		private readonly List<int> CameraModeSequence = new List<int>();

		// Token: 0x040271BA RID: 160186
		private readonly List<int> CameraModePriorityValues = new List<int>();

		// Token: 0x040271BB RID: 160187
		[Nullable(2)]
		public CameraMovieModeController CameraMovieModeController;

		// Token: 0x040271BC RID: 160188
		public bool IsInCameraModeBlending;

		// Token: 0x040271BD RID: 160189
		private bool BlendingInternal;

		// Token: 0x040271BE RID: 160190
		[Nullable(2)]
		private TimerHandle BlendTimerIdInternal;

		// Token: 0x040271BF RID: 160191
		private float ShakeModifyInternal = 1f;

		// Token: 0x040271C0 RID: 160192
		private EAimAssistMode DefaultAimAssistModeInternal = EAimAssistMode.OpenOnStart;

		// Token: 0x040271C1 RID: 160193
		private readonly Dictionary<string, EAimAssistMode> AimAssistModeMap = new Dictionary<string, EAimAssistMode>();

		// Token: 0x040271C2 RID: 160194
		private EAimAssistMode CurrentAimAssistMode;

		// Token: 0x040271C3 RID: 160195
		public int CameraShakeInstanceId = -1;

		// Token: 0x040271C4 RID: 160196
		public readonly Dictionary<int, UCameraShakeBase> CameraShakeMap = new Dictionary<int, UCameraShakeBase>();

		// Token: 0x040271C5 RID: 160197
		[Nullable(2)]
		public SeparateCameraLayout SeparateCameraLayout;

		// Token: 0x040271C6 RID: 160198
		private readonly HashSet<int> BoundScreenEffectHandleIds = new HashSet<int>();

		// Token: 0x040271C7 RID: 160199
		private double CameraBaseYawSensitivityInternal = 50.0;

		// Token: 0x040271C8 RID: 160200
		private double CameraBasePitchSensitivityInternal = 50.0;

		// Token: 0x040271C9 RID: 160201
		private double CameraAimingYawSensitivityInternal = 50.0;

		// Token: 0x040271CA RID: 160202
		private double CameraAimingPitchSensitivityInternal = 50.0;

		// Token: 0x040271CB RID: 160203
		public bool IsEnableSpecificCameraSensitivity;

		// Token: 0x040271CC RID: 160204
		public float SpecificCameraBaseYawSensitivity = 1f;

		// Token: 0x040271CD RID: 160205
		public float SpecificCameraBasePitchSensitivity = 1f;

		// Token: 0x040271CE RID: 160206
		public float SpecificCameraAimingYawSensitivity = 1f;

		// Token: 0x040271CF RID: 160207
		public float SpecificCameraAimingPitchSensitivity = 1f;

		// Token: 0x040271D0 RID: 160208
		private bool CameraBaseYawReverseInternal;

		// Token: 0x040271D1 RID: 160209
		private bool CameraBasePitchReverseInternal;

		// Token: 0x040271D2 RID: 160210
		private bool CameraAimingYawReverseInternal;

		// Token: 0x040271D3 RID: 160211
		private bool CameraAimingPitchReverseInternal;

		// Token: 0x040271D4 RID: 160212
		private bool IsCameraResetPitchInternal = true;

		// Token: 0x040271D5 RID: 160213
		private float MotionBlurValueInternal = 50f;

		// Token: 0x040271D6 RID: 160214
		public bool IsEnableResetFocus = true;

		// Token: 0x040271D7 RID: 160215
		public bool IsEnableSidestepCamera = true;

		// Token: 0x040271D8 RID: 160216
		private bool IsEnableSoftLockCamera = true;

		// Token: 0x040271D9 RID: 160217
		public double CameraSettingFightAdditionArmLength = 50.0;

		// Token: 0x040271DA RID: 160218
		public double CameraSettingNormalAdditionArmLength = 50.0;

		// Token: 0x040271DB RID: 160219
		[Nullable(2)]
		private SeqCameraThings SavedSeqCameraThings;

		// Token: 0x040271DC RID: 160220
		private bool IsAimAssistEnable = true;

		// Token: 0x040271DD RID: 160221
		private readonly HashSet<int> SoftLockEnableHandleSet = new HashSet<int>();

		// Token: 0x040271DE RID: 160222
		private int SoftLockEnableHandle;

		// Token: 0x040271DF RID: 160223
		private int CameraLockId;

		// Token: 0x040271E0 RID: 160224
		private readonly Dictionary<int, CameraSpecificLockTarget> CameraSpecificLockTargetMap = new Dictionary<int, CameraSpecificLockTarget>();

		// Token: 0x040271E1 RID: 160225
		private readonly PriorityQueue<CameraSpecificLockTarget> CameraSpecificLockTargetList;

		// Token: 0x040271E2 RID: 160226
		public readonly DisjointSet<long> DitherEntityGroups;

		// Token: 0x040271E3 RID: 160227
		private readonly HashSet<EHideHeadEnum> HideHeadEnabledInternal;

		// Token: 0x040271E4 RID: 160228
		private readonly HashSet<EHideHeadDisabledEnum> HideHeadDisabledInternal;

		// Token: 0x040271E5 RID: 160229
		private int HidePlayerHandle;

		// Token: 0x040271E6 RID: 160230
		private int HidePlayerEntityId;

		// Token: 0x040271E7 RID: 160231
		private CameraModelInstance.ECameraHidePlayerMode HidePlayerMode;

		// Token: 0x040271E8 RID: 160232
		public int CurSeqCameraIndex;

		// Token: 0x0200CCB7 RID: 52407
		[NullableContext(0)]
		private enum ECameraHidePlayerMode
		{
			// Token: 0x0403EC9F RID: 257183
			None,
			// Token: 0x0403ECA0 RID: 257184
			Instant,
			// Token: 0x0403ECA1 RID: 257185
			Dither
		}

		// Token: 0x0200CCB8 RID: 52408
		[CompilerGenerated]
		private static class <>O
		{
			// Token: 0x0403ECA2 RID: 257186
			[Nullable(new byte[]
			{
				0,
				1
			})]
			public static Comparison<CameraSpecificLockTarget> <0>__CompareCameraSpecificLockIdPriority;
		}
	}
}
