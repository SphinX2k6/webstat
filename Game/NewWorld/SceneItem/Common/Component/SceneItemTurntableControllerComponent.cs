using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.NewWorld.Common.Component;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.SceneItem.Common.Component
{
	// Token: 0x02004891 RID: 18577
	[NullableContext(2)]
	[Nullable(0)]
	public class SceneItemTurntableControllerComponent : EntityComponent
	{
		// Token: 0x0603066F RID: 198255 RVA: 0x00BDA43C File Offset: 0x00BD863C
		protected override bool OnInitData(IEntityArgs args = null)
		{
			TurntableControlComponent turntableControlComponent = ((args != null) ? args.GetP1<CreateEntityData>() : null).GetParam<SceneItemTurntableControllerComponent>() as TurntableControlComponent;
			CreatureDataComponent component = base.Entity.GetComponent<CreatureDataComponent>();
			if (component == null)
			{
				return false;
			}
			if (turntableControlComponent == null)
			{
				return true;
			}
			int? num = null;
			IFixedAngleTurntable fixedAngleTurntable = turntableControlComponent.Config as IFixedAngleTurntable;
			if (fixedAngleTurntable != null)
			{
				num = new int?(fixedAngleTurntable.ItemConfig.Count);
			}
			else
			{
				IFreeAngleTurntable freeAngleTurntable = turntableControlComponent.Config as IFreeAngleTurntable;
				if (freeAngleTurntable != null)
				{
					num = new int?(freeAngleTurntable.ItemConfig.Count);
				}
			}
			if (num != null)
			{
				int? num2 = num;
				int num3 = 0;
				if (!(num2.GetValueOrDefault() <= num3 & num2 != null))
				{
					this.CreatureDataComponent = component;
					this.ControllerConfig = turntableControlComponent.Config;
					this.RotatingRings = new List<SceneItemTurntableControllerComponent.RotatingRing>();
					int num4 = 0;
					for (;;)
					{
						int num5 = num4;
						num2 = num;
						if (!(num5 < num2.GetValueOrDefault() & num2 != null))
						{
							break;
						}
						SceneItemTurntableControllerComponent.RotatingRing item = new SceneItemTurntableControllerComponent.RotatingRing
						{
							Index = num4,
							IsAtTarget = false,
							IsSelected = false,
							IsRotating = false,
							CurSpeed = 0f,
							AccumulateAngle = 0f
						};
						this.RotatingRings.Add(item);
						num4++;
					}
					this.IsInitComplete = false;
					return true;
				}
			}
			Singleton<Log>.Instance.Error(ELogModule.SceneItem, ELogAuthor.ZYL, "稷廷开门机关组件创建错误，圈数不对", default(ReadOnlySpan<ValueTuple<string, object>>));
			return true;
		}

		// Token: 0x06030670 RID: 198256 RVA: 0x00BDA59C File Offset: 0x00BD879C
		protected override bool OnStart()
		{
			this.TagComponent = base.Entity.GetComponent<LevelTagComponent>();
			if (this.TagComponent == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.SceneItem, ELogAuthor.ZYL, "稷廷开门机关组件初始化错误，找不到LevelTagComponent", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			if (this.ControllerConfig == null)
			{
				return true;
			}
			Singleton<EventSystem>.Instance.AddWithTarget(base.Entity, EEventName.OnSceneInteractionShowCompleted, new Action(this.OnSceneInteractionLoadCompleted));
			return true;
		}

		// Token: 0x06030671 RID: 198257 RVA: 0x00BDA610 File Offset: 0x00BD8810
		protected override void OnActivate()
		{
			this.SetAllowRotate(false);
			if (Singleton<EventSystem>.Instance.HasWithTarget(base.Entity, EEventName.OnSceneItemStateChange, new Action<int, bool>(this.HandleUpdateState)))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.SceneItem;
				ELogAuthor author = ELogAuthor.ZYL;
				string message = "SceneItemTurntableControllerComponent.OnActivate，重复添加事件";
				string item = "PbDataId";
				CreatureDataComponent component = base.Entity.GetComponent<CreatureDataComponent>();
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>(item, (component != null) ? new int?(component.GetPbDataId()) : null);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			Singleton<EventSystem>.Instance.AddWithTarget(base.Entity, EEventName.OnSceneItemStateChange, new Action<int, bool>(this.HandleUpdateState));
		}

		// Token: 0x06030672 RID: 198258 RVA: 0x00BDA6B9 File Offset: 0x00BD88B9
		protected override void OnTick(float delta)
		{
			if (!this.IsInitComplete)
			{
				return;
			}
			if (this.GetControlType() == Aki.TDConfigMgr.Component.EControllerType.FixedAngle)
			{
				this.TickFixedAngleRotate(delta);
			}
			else
			{
				this.TickFreeAngleRotate(delta);
			}
			this.TickAngleCorrectionRotate(delta);
		}

		// Token: 0x06030673 RID: 198259 RVA: 0x00BDA6E4 File Offset: 0x00BD88E4
		protected override bool OnEnd()
		{
			if (Singleton<EventSystem>.Instance.HasWithTarget(base.Entity, EEventName.OnSceneItemStateChange, new Action<int, bool>(this.HandleUpdateState)))
			{
				Singleton<EventSystem>.Instance.RemoveWithTarget(base.Entity, EEventName.OnSceneItemStateChange, new Action<int, bool>(this.HandleUpdateState));
			}
			if (Singleton<EventSystem>.Instance.HasWithTarget(base.Entity, EEventName.OnSceneInteractionShowCompleted, new Action(this.OnSceneInteractionLoadCompleted)))
			{
				Singleton<EventSystem>.Instance.RemoveWithTarget(base.Entity, EEventName.OnSceneInteractionShowCompleted, new Action(this.OnSceneInteractionLoadCompleted));
			}
			return true;
		}

		// Token: 0x06030674 RID: 198260 RVA: 0x00BDA77C File Offset: 0x00BD897C
		private void OnSceneInteractionLoadCompleted()
		{
			Singleton<EventSystem>.Instance.RemoveWithTarget(base.Entity, EEventName.OnSceneInteractionShowCompleted, new Action(this.OnSceneInteractionLoadCompleted));
			if (!this.InitRingActorArray())
			{
				return;
			}
			this.InitRingActorAngle();
			this.IsInitComplete = true;
			if (this.UpdateAllRingsAtTarget(true))
			{
				LevelTagComponent tagComponent = this.TagComponent;
				if (tagComponent == null || !tagComponent.HasTag(GameplayTagDefine.EGameplayTagId["关卡.Common.状态.完成"]))
				{
					this.RequestTurntableComplete();
				}
			}
		}

		// Token: 0x06030675 RID: 198261 RVA: 0x00BDA7F8 File Offset: 0x00BD89F8
		private bool InitRingActorArray()
		{
			SceneItemActorComponent component = base.Entity.GetComponent<SceneItemActorComponent>();
			if (component == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.SceneItem, ELogAuthor.ZYL, "稷廷开门机关组件初始化错误，SceneItemActorComponent组件获取失败", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			foreach (SceneItemTurntableControllerComponent.RotatingRing rotatingRing in this.RotatingRings)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(4, 1);
				defaultInterpolatedStringHandler.AppendLiteral("Ring");
				defaultInterpolatedStringHandler.AppendFormatted<int>(rotatingRing.Index);
				string text = defaultInterpolatedStringHandler.ToStringAndClear();
				AActor actorInSceneInteraction = component.GetActorInSceneInteraction(text);
				if (actorInSceneInteraction == null || !actorInSceneInteraction.IsValid())
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.SceneItem;
					ELogAuthor author = ELogAuthor.ZYL;
					string message = "稷廷开门机关组件初始化错误，对应Actor无效";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("key", text);
					instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					return false;
				}
				rotatingRing.ControllerRingActor = actorInSceneInteraction;
			}
			return true;
		}

		// Token: 0x06030676 RID: 198262 RVA: 0x00BDA8FC File Offset: 0x00BD8AFC
		private void InitRingActorAngle()
		{
			LevelTagComponent tagComponent = this.TagComponent;
			bool flag = tagComponent != null && tagComponent.HasTag(GameplayTagDefine.EGameplayTagId["关卡.Common.状态.完成"]);
			foreach (SceneItemTurntableControllerComponent.RotatingRing rotatingRing in this.RotatingRings)
			{
				ITurntableControlType controllerConfig = this.ControllerConfig;
				IFixedAngleTurntable fixedAngleTurntable = controllerConfig as IFixedAngleTurntable;
				if (fixedAngleTurntable == null)
				{
					IFreeAngleTurntable freeAngleTurntable = controllerConfig as IFreeAngleTurntable;
					if (freeAngleTurntable != null)
					{
						int initAngle = freeAngleTurntable.ItemConfig[rotatingRing.Index].InitAngle;
						int targetAngle = freeAngleTurntable.ItemConfig[rotatingRing.Index].TargetAngle;
						this.SetRingAngle(rotatingRing, (float)(flag ? targetAngle : initAngle));
					}
				}
				else
				{
					int initAngle2 = fixedAngleTurntable.ItemConfig[rotatingRing.Index].InitAngle;
					int targetAngle2 = fixedAngleTurntable.ItemConfig[rotatingRing.Index].TargetAngle;
					this.SetRingAngle(rotatingRing, (float)(flag ? targetAngle2 : initAngle2));
				}
			}
		}

		// Token: 0x06030677 RID: 198263 RVA: 0x00BDAA1C File Offset: 0x00BD8C1C
		public void DeselectAllRings(bool updateEffect)
		{
			foreach (SceneItemTurntableControllerComponent.RotatingRing rotatingRing in this.RotatingRings)
			{
				rotatingRing.IsSelected = false;
			}
			if (updateEffect)
			{
				this.UpdateAllRingsSelectedEffect();
			}
		}

		// Token: 0x06030678 RID: 198264 RVA: 0x00BDAA78 File Offset: 0x00BD8C78
		public void SelectRingByIndex(int index, bool updateEffect)
		{
			SceneItemTurntableControllerComponent.RotatingRing rotatingRing;
			if (!this.RotatingRings.TryGetValue(index, out rotatingRing))
			{
				return;
			}
			rotatingRing.IsSelected = true;
			if (updateEffect)
			{
				this.UpdateRingSelectedEffectByIndex(rotatingRing.Index);
			}
		}

		// Token: 0x06030679 RID: 198265 RVA: 0x00BDAAAC File Offset: 0x00BD8CAC
		public void DeselectRingByIndex(int index, bool updateEffect)
		{
			SceneItemTurntableControllerComponent.RotatingRing rotatingRing;
			if (!this.RotatingRings.TryGetValue(index, out rotatingRing))
			{
				return;
			}
			rotatingRing.IsSelected = false;
			if (updateEffect)
			{
				this.UpdateRingSelectedEffectByIndex(rotatingRing.Index);
			}
		}

		// Token: 0x0603067A RID: 198266 RVA: 0x00BDAAE0 File Offset: 0x00BD8CE0
		private int GetSelectedTagByIndex(int index)
		{
			switch (index)
			{
			case 0:
				return GameplayTagDefine.EGameplayTagId["关卡.转盘机关主控.圆环选中.环0"];
			case 1:
				return GameplayTagDefine.EGameplayTagId["关卡.转盘机关主控.圆环选中.环1"];
			case 2:
				return GameplayTagDefine.EGameplayTagId["关卡.转盘机关主控.圆环选中.环2"];
			default:
				return 0;
			}
		}

		// Token: 0x0603067B RID: 198267 RVA: 0x00BDAB34 File Offset: 0x00BD8D34
		private int GetAtTargetTagByIndex(int index)
		{
			switch (index)
			{
			case 0:
				return GameplayTagDefine.EGameplayTagId["关卡.转盘机关主控.圆环到位.环0"];
			case 1:
				return GameplayTagDefine.EGameplayTagId["关卡.转盘机关主控.圆环到位.环1"];
			case 2:
				return GameplayTagDefine.EGameplayTagId["关卡.转盘机关主控.圆环到位.环2"];
			default:
				return 0;
			}
		}

		// Token: 0x0603067C RID: 198268 RVA: 0x00BDAB88 File Offset: 0x00BD8D88
		private void StartRingRotateByIndex(int index, bool clockwise)
		{
			SceneItemTurntableControllerComponent.RotatingRing rotatingRing;
			if (!this.RotatingRings.TryGetValue(index, out rotatingRing))
			{
				return;
			}
			if (!this.IsInitComplete || !this.GetRotateAllowed() || this.IsBusyRotating())
			{
				return;
			}
			rotatingRing.AccumulateAngle = 0f;
			rotatingRing.CurSpeed = (float)Math.Abs(this.ControllerConfig.RotationSpeed) * (clockwise ? 1f : -1f) / 1000f;
			rotatingRing.IsRotating = true;
		}

		// Token: 0x0603067D RID: 198269 RVA: 0x00BDAC00 File Offset: 0x00BD8E00
		private void StopRingsRotateByIndex(int index)
		{
			SceneItemTurntableControllerComponent.RotatingRing rotatingRing;
			if (!this.RotatingRings.TryGetValue(index, out rotatingRing))
			{
				return;
			}
			if (!this.IsInitComplete || !this.GetRotateAllowed())
			{
				return;
			}
			rotatingRing.AccumulateAngle = 0f;
			rotatingRing.CurSpeed = 0f;
			rotatingRing.IsRotating = false;
		}

		// Token: 0x0603067E RID: 198270 RVA: 0x00BDAC4C File Offset: 0x00BD8E4C
		public void TriggerStartSelectedRingsRotate()
		{
			if (this.ControllerConfig.Type == Aki.TDConfigMgr.Component.EControllerType.FixedAngle)
			{
				this.TriggerStartSelectedFixedAngleRingsRotate();
				return;
			}
			this.TriggerStartSelectedFreeAngleRingsRotate();
		}

		// Token: 0x0603067F RID: 198271 RVA: 0x00BDAC6C File Offset: 0x00BD8E6C
		private void TriggerStartSelectedFixedAngleRingsRotate()
		{
			if (!this.IsInitComplete || !this.GetRotateAllowed())
			{
				return;
			}
			if (this.ControllerConfig.Type != Aki.TDConfigMgr.Component.EControllerType.FixedAngle)
			{
				return;
			}
			foreach (SceneItemTurntableControllerComponent.RotatingRing rotatingRing in this.RotatingRings)
			{
				if (rotatingRing.IsSelected)
				{
					bool clockwise = this.ControllerConfig.RotationSpeed > 0;
					this.StartRingRotateByIndex(rotatingRing.Index, clockwise);
				}
			}
			Singleton<EventSystem>.Instance.EmitWithTarget<bool, bool>(base.Entity, EEventName.OnTurntableControllerBusyStateChange, true, false);
		}

		// Token: 0x06030680 RID: 198272 RVA: 0x00BDAD14 File Offset: 0x00BD8F14
		private void TriggerStartSelectedFreeAngleRingsRotate()
		{
			if (!this.IsInitComplete || !this.GetRotateAllowed())
			{
				return;
			}
			if (this.ControllerConfig.Type != Aki.TDConfigMgr.Component.EControllerType.FreeAngle)
			{
				return;
			}
			foreach (SceneItemTurntableControllerComponent.RotatingRing rotatingRing in this.RotatingRings)
			{
				if (rotatingRing.IsSelected)
				{
					bool clockwise = this.ControllerConfig.RotationSpeed > 0;
					this.StartRingRotateByIndex(rotatingRing.Index, clockwise);
				}
			}
			Singleton<EventSystem>.Instance.EmitWithTarget<bool, bool>(base.Entity, EEventName.OnTurntableControllerBusyStateChange, true, false);
		}

		// Token: 0x06030681 RID: 198273 RVA: 0x00BDADBC File Offset: 0x00BD8FBC
		public void TriggerStopAllRingsRotate()
		{
			if (this.ControllerConfig.Type == Aki.TDConfigMgr.Component.EControllerType.FixedAngle)
			{
				this.TriggerStopAllFixedAngleRingsRotate();
				return;
			}
			this.TriggerStopAllFreeAngleRingsRotate();
		}

		// Token: 0x06030682 RID: 198274 RVA: 0x00BDADDC File Offset: 0x00BD8FDC
		private void TriggerStopAllFixedAngleRingsRotate()
		{
			if (!this.IsInitComplete || !this.GetRotateAllowed() || !this.IsBusyRotating())
			{
				return;
			}
			if (this.ControllerConfig.Type != Aki.TDConfigMgr.Component.EControllerType.FixedAngle)
			{
				return;
			}
			foreach (SceneItemTurntableControllerComponent.RotatingRing rotatingRing in this.RotatingRings)
			{
				if (rotatingRing.IsRotating)
				{
					this.AddRingAngle(rotatingRing, -rotatingRing.AccumulateAngle);
				}
				this.StopRingsRotateByIndex(rotatingRing.Index);
			}
			if (this.UpdateAllRingsAtTarget(true))
			{
				this.RequestTurntableComplete();
			}
			Singleton<EventSystem>.Instance.EmitWithTarget<bool, bool>(base.Entity, EEventName.OnTurntableControllerBusyStateChange, false, this.IsAllRingsAtTarget());
		}

		// Token: 0x06030683 RID: 198275 RVA: 0x00BDAEA0 File Offset: 0x00BD90A0
		private void TriggerStopAllFreeAngleRingsRotate()
		{
			if (!this.IsInitComplete || !this.GetRotateAllowed() || !this.IsBusyRotating())
			{
				return;
			}
			if (this.ControllerConfig.Type != Aki.TDConfigMgr.Component.EControllerType.FreeAngle)
			{
				return;
			}
			foreach (SceneItemTurntableControllerComponent.RotatingRing rotatingRing in this.RotatingRings)
			{
				this.StopRingsRotateByIndex(rotatingRing.Index);
			}
			if (this.UpdateAllRingsAtTarget(true))
			{
				this.RequestTurntableComplete();
			}
			Singleton<EventSystem>.Instance.EmitWithTarget<bool, bool>(base.Entity, EEventName.OnTurntableControllerBusyStateChange, false, this.IsAllRingsAtTarget());
		}

		// Token: 0x06030684 RID: 198276 RVA: 0x00BDAF4C File Offset: 0x00BD914C
		public void TriggerResetAllRingsToInitAngle(bool bForceReset = false)
		{
			if (!this.IsInitComplete || !this.GetRotateAllowed() || this.IsBusyRotating())
			{
				return;
			}
			if (this.IsAllRingsAtTarget() && !bForceReset)
			{
				return;
			}
			foreach (SceneItemTurntableControllerComponent.RotatingRing rotatingRing in this.RotatingRings)
			{
				ITurntableControlType controllerConfig = this.ControllerConfig;
				IFixedAngleTurntable fixedAngleTurntable = controllerConfig as IFixedAngleTurntable;
				if (fixedAngleTurntable == null)
				{
					IFreeAngleTurntable freeAngleTurntable = controllerConfig as IFreeAngleTurntable;
					if (freeAngleTurntable != null)
					{
						int initAngle = freeAngleTurntable.ItemConfig[rotatingRing.Index].InitAngle;
						this.SetRingAngle(rotatingRing, (float)initAngle);
					}
				}
				else
				{
					int initAngle2 = fixedAngleTurntable.ItemConfig[rotatingRing.Index].InitAngle;
					this.SetRingAngle(rotatingRing, (float)initAngle2);
				}
			}
			this.UpdateAllRingsAtTarget(true);
		}

		// Token: 0x06030685 RID: 198277 RVA: 0x00BDB02C File Offset: 0x00BD922C
		private void TickFixedAngleRotate(float delta)
		{
			if (!this.IsInitComplete)
			{
				return;
			}
			IFixedAngleTurntable fixedAngleTurntable = this.ControllerConfig as IFixedAngleTurntable;
			if (fixedAngleTurntable == null)
			{
				return;
			}
			foreach (SceneItemTurntableControllerComponent.RotatingRing rotatingRing in this.RotatingRings)
			{
				if (rotatingRing.IsRotating)
				{
					float num = rotatingRing.CurSpeed * delta;
					float num2 = rotatingRing.AccumulateAngle + num;
					int rotateAngle = fixedAngleTurntable.ItemConfig[rotatingRing.Index].RotateAngle;
					if (Math.Abs(num2) >= (float)Math.Abs(rotateAngle))
					{
						bool flag = rotatingRing.CurSpeed > 0f;
						num -= num2 - (float)(Math.Abs(rotateAngle) * (flag ? 1 : -1));
						this.AddRingAngle(rotatingRing, num);
						rotatingRing.AccumulateAngle += num;
						this.StopRingsRotateByIndex(rotatingRing.Index);
						if (this.IsBusyRotating())
						{
							this.UpdateRingAtTarget(rotatingRing.Index, true);
						}
						else
						{
							if (this.UpdateAllRingsAtTarget(true))
							{
								this.RequestTurntableComplete();
							}
							Singleton<EventSystem>.Instance.EmitWithTarget<bool, bool>(base.Entity, EEventName.OnTurntableControllerBusyStateChange, false, this.IsAllRingsAtTarget());
						}
					}
					else
					{
						this.AddRingAngle(rotatingRing, num);
						rotatingRing.AccumulateAngle += num;
						if (rotatingRing.IsAtTarget)
						{
							this.UpdateRingAtTarget(rotatingRing.Index, true);
						}
					}
				}
			}
		}

		// Token: 0x06030686 RID: 198278 RVA: 0x00BDB1A8 File Offset: 0x00BD93A8
		private void TickFreeAngleRotate(float delta)
		{
			if (!this.IsInitComplete)
			{
				return;
			}
			foreach (SceneItemTurntableControllerComponent.RotatingRing rotatingRing in this.RotatingRings)
			{
				if (rotatingRing.IsRotating)
				{
					float deltaAngle = rotatingRing.CurSpeed * delta;
					this.AddRingAngle(rotatingRing, deltaAngle);
					if (rotatingRing.IsAtTarget)
					{
						this.UpdateRingAtTarget(rotatingRing.Index, true);
					}
				}
			}
		}

		// Token: 0x06030687 RID: 198279 RVA: 0x00BDB22C File Offset: 0x00BD942C
		private void TickAngleCorrectionRotate(float delta)
		{
			if (!this.IsInitComplete)
			{
				return;
			}
			foreach (SceneItemTurntableControllerComponent.RotatingRing rotatingRing in this.RotatingRings)
			{
				if (!rotatingRing.IsRotating && rotatingRing.IsAtTarget)
				{
					IFixedAngleTurntable fixedAngleTurntable = this.ControllerConfig as IFixedAngleTurntable;
					int targetAngle;
					if (fixedAngleTurntable != null)
					{
						targetAngle = fixedAngleTurntable.ItemConfig[rotatingRing.Index].TargetAngle;
					}
					else
					{
						IFreeAngleTurntable freeAngleTurntable = this.ControllerConfig as IFreeAngleTurntable;
						if (freeAngleTurntable == null)
						{
							continue;
						}
						targetAngle = freeAngleTurntable.ItemConfig[rotatingRing.Index].TargetAngle;
					}
					float num = this.AngleDiff(this.GetRingAngle(rotatingRing).Value, (float)targetAngle);
					if (!Singleton<MathUtils>.Instance.IsNearlyZero((double)num, null))
					{
						bool flag = num > 0f;
						int num2 = this.ControllerConfig.RotationSpeed / 1000;
						float deltaAngle = Math.Min(Math.Abs(num), Math.Abs((float)num2 * delta)) * (float)(flag ? 1 : -1);
						this.AddRingAngle(rotatingRing, deltaAngle);
					}
				}
			}
		}

		// Token: 0x06030688 RID: 198280 RVA: 0x00BDB37C File Offset: 0x00BD957C
		[NullableContext(1)]
		private float? GetRingAngle(SceneItemTurntableControllerComponent.RotatingRing ring)
		{
			AActor controllerRingActor = ring.ControllerRingActor;
			if (controllerRingActor != null && controllerRingActor.IsValid())
			{
				if (ring.RingRotator == null)
				{
					ring.RingRotator = global::Rotator.Create(ring.ControllerRingActor.RootComponent.D_GetRelativeTransform().Rotator());
				}
				return new float?(-ring.RingRotator.Pitch);
			}
			return null;
		}

		// Token: 0x06030689 RID: 198281 RVA: 0x00BDB3EC File Offset: 0x00BD95EC
		[NullableContext(1)]
		private void SetRingAngle(SceneItemTurntableControllerComponent.RotatingRing ring, float angle)
		{
			AActor controllerRingActor = ring.ControllerRingActor;
			if (controllerRingActor != null && controllerRingActor.IsValid())
			{
				if (ring.RingRotator == null)
				{
					ring.RingRotator = global::Rotator.Create();
				}
				ring.RingRotator.Pitch = -angle;
				ring.ControllerRingActor.RootComponent.K2_SetRelativeRotation(ring.RingRotator.ToUeRotator(), false, ref WorldGlobal.SweepHitResult, false);
			}
		}

		// Token: 0x0603068A RID: 198282 RVA: 0x00BDB454 File Offset: 0x00BD9654
		[NullableContext(1)]
		private void AddRingAngle(SceneItemTurntableControllerComponent.RotatingRing ring, float deltaAngle)
		{
			AActor controllerRingActor = ring.ControllerRingActor;
			if (controllerRingActor != null && controllerRingActor.IsValid())
			{
				if (ring.RingRotator == null)
				{
					ring.RingRotator = global::Rotator.Create();
				}
				ring.RingRotator.Pitch -= deltaAngle;
				ring.ControllerRingActor.RootComponent.K2_SetRelativeRotation(ring.RingRotator.ToUeRotator(), false, ref WorldGlobal.SweepHitResult, false);
			}
		}

		// Token: 0x0603068B RID: 198283 RVA: 0x00BDB4C0 File Offset: 0x00BD96C0
		public bool UpdateAllRingsAtTarget(bool updateEffect)
		{
			bool result = true;
			foreach (SceneItemTurntableControllerComponent.RotatingRing rotatingRing in this.RotatingRings)
			{
				if (!this.UpdateRingAtTarget(rotatingRing.Index, false))
				{
					result = false;
				}
			}
			if (updateEffect)
			{
				this.UpdateAllRingsAtTargetEffect();
			}
			return result;
		}

		// Token: 0x0603068C RID: 198284 RVA: 0x00BDB52C File Offset: 0x00BD972C
		public bool UpdateRingAtTarget(int index, bool updateEffect)
		{
			SceneItemTurntableControllerComponent.RotatingRing rotatingRing;
			if (!this.RotatingRings.TryGetValue(index, out rotatingRing))
			{
				return false;
			}
			if (!this.IsInitComplete)
			{
				return false;
			}
			if (rotatingRing.RingRotator != null)
			{
				float value = this.GetRingAngle(rotatingRing).Value;
				IFixedAngleTurntable fixedAngleTurntable = this.ControllerConfig as IFixedAngleTurntable;
				int targetAngle;
				int num;
				if (fixedAngleTurntable != null)
				{
					targetAngle = fixedAngleTurntable.ItemConfig[rotatingRing.Index].TargetAngle;
					num = 1;
				}
				else
				{
					IFreeAngleTurntable freeAngleTurntable = this.ControllerConfig as IFreeAngleTurntable;
					if (freeAngleTurntable == null)
					{
						return false;
					}
					targetAngle = freeAngleTurntable.ItemConfig[rotatingRing.Index].TargetAngle;
					num = freeAngleTurntable.IntervalAngle;
				}
				if (Math.Abs(this.AngleDiff(value, (float)targetAngle)) <= (float)num)
				{
					rotatingRing.IsAtTarget = true;
				}
				else
				{
					rotatingRing.IsAtTarget = false;
				}
				if (updateEffect)
				{
					this.UpdateRingAtTargetEffectByIndex(rotatingRing.Index);
				}
				return rotatingRing.IsAtTarget;
			}
			return false;
		}

		// Token: 0x0603068D RID: 198285 RVA: 0x00BDB60C File Offset: 0x00BD980C
		public bool IsBusyRotating()
		{
			using (List<SceneItemTurntableControllerComponent.RotatingRing>.Enumerator enumerator = this.RotatingRings.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.IsRotating)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x0603068E RID: 198286 RVA: 0x00BDB668 File Offset: 0x00BD9868
		public bool IsRingRotatingByIndex(int index)
		{
			SceneItemTurntableControllerComponent.RotatingRing rotatingRing;
			return this.RotatingRings.TryGetValue(index, out rotatingRing) && this.IsInitComplete && rotatingRing.IsRotating;
		}

		// Token: 0x0603068F RID: 198287 RVA: 0x00BDB698 File Offset: 0x00BD9898
		public int? GetRingsNum()
		{
			List<SceneItemTurntableControllerComponent.RotatingRing> rotatingRings = this.RotatingRings;
			if (rotatingRings == null)
			{
				return null;
			}
			return new int?(rotatingRings.Count);
		}

		// Token: 0x06030690 RID: 198288 RVA: 0x00BDB6C3 File Offset: 0x00BD98C3
		public Aki.TDConfigMgr.Component.EControllerType GetControlType()
		{
			return this.ControllerConfig.Type;
		}

		// Token: 0x06030691 RID: 198289 RVA: 0x00BDB6D0 File Offset: 0x00BD98D0
		public bool IsAllRingsAtTarget()
		{
			using (List<SceneItemTurntableControllerComponent.RotatingRing>.Enumerator enumerator = this.RotatingRings.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (!enumerator.Current.IsAtTarget)
					{
						return false;
					}
				}
			}
			return true;
		}

		// Token: 0x06030692 RID: 198290 RVA: 0x00BDB72C File Offset: 0x00BD992C
		public bool IsRingAtTargetByIndex(int index)
		{
			SceneItemTurntableControllerComponent.RotatingRing rotatingRing;
			return this.RotatingRings.TryGetValue(index, out rotatingRing) && this.IsInitComplete && rotatingRing.IsAtTarget;
		}

		// Token: 0x06030693 RID: 198291 RVA: 0x00BDB75C File Offset: 0x00BD995C
		public bool IsRingSelectedByIndex(int index)
		{
			SceneItemTurntableControllerComponent.RotatingRing rotatingRing;
			return this.RotatingRings.TryGetValue(index, out rotatingRing) && this.IsInitComplete && rotatingRing.IsSelected;
		}

		// Token: 0x06030694 RID: 198292 RVA: 0x00BDB78C File Offset: 0x00BD998C
		public void UpdateAllRingsAtTargetEffect()
		{
			if (this.TagComponent == null)
			{
				return;
			}
			LevelTagComponent tagComponent = this.TagComponent;
			long notifyLock = tagComponent.NotifyLock;
			tagComponent.NotifyLock = notifyLock + 1L;
			foreach (SceneItemTurntableControllerComponent.RotatingRing rotatingRing in this.RotatingRings)
			{
				if (rotatingRing.IsAtTarget)
				{
					int atTargetTagByIndex = this.GetAtTargetTagByIndex(rotatingRing.Index);
					if (!this.TagComponent.HasTag(atTargetTagByIndex))
					{
						this.TagComponent.AddTag(new int?(atTargetTagByIndex));
					}
				}
				else
				{
					int atTargetTagByIndex2 = this.GetAtTargetTagByIndex(rotatingRing.Index);
					if (this.TagComponent.HasTag(atTargetTagByIndex2))
					{
						this.TagComponent.RemoveTag(new int?(atTargetTagByIndex2));
					}
				}
			}
			LevelTagComponent tagComponent2 = this.TagComponent;
			notifyLock = tagComponent2.NotifyLock;
			tagComponent2.NotifyLock = notifyLock - 1L;
		}

		// Token: 0x06030695 RID: 198293 RVA: 0x00BDB874 File Offset: 0x00BD9A74
		public void UpdateRingAtTargetEffectByIndex(int index)
		{
			SceneItemTurntableControllerComponent.RotatingRing rotatingRing;
			if (!this.RotatingRings.TryGetValue(index, out rotatingRing))
			{
				return;
			}
			if (!this.IsInitComplete)
			{
				return;
			}
			if (rotatingRing.IsAtTarget)
			{
				int atTargetTagByIndex = this.GetAtTargetTagByIndex(rotatingRing.Index);
				LevelTagComponent tagComponent = this.TagComponent;
				if (tagComponent == null || !tagComponent.HasTag(atTargetTagByIndex))
				{
					LevelTagComponent tagComponent2 = this.TagComponent;
					if (tagComponent2 == null)
					{
						return;
					}
					tagComponent2.AddTag(new int?(atTargetTagByIndex));
					return;
				}
			}
			else
			{
				int atTargetTagByIndex2 = this.GetAtTargetTagByIndex(rotatingRing.Index);
				LevelTagComponent tagComponent3 = this.TagComponent;
				if (tagComponent3 != null && tagComponent3.HasTag(atTargetTagByIndex2))
				{
					LevelTagComponent tagComponent4 = this.TagComponent;
					if (tagComponent4 == null)
					{
						return;
					}
					tagComponent4.RemoveTag(new int?(atTargetTagByIndex2));
				}
			}
		}

		// Token: 0x06030696 RID: 198294 RVA: 0x00BDB918 File Offset: 0x00BD9B18
		public void UpdateAllRingsSelectedEffect()
		{
			if (this.TagComponent == null)
			{
				return;
			}
			LevelTagComponent tagComponent = this.TagComponent;
			long notifyLock = tagComponent.NotifyLock;
			tagComponent.NotifyLock = notifyLock + 1L;
			foreach (SceneItemTurntableControllerComponent.RotatingRing rotatingRing in this.RotatingRings)
			{
				if (rotatingRing.IsSelected)
				{
					int selectedTagByIndex = this.GetSelectedTagByIndex(rotatingRing.Index);
					if (!this.TagComponent.HasTag(selectedTagByIndex))
					{
						this.TagComponent.AddTag(new int?(selectedTagByIndex));
					}
				}
				else
				{
					int selectedTagByIndex2 = this.GetSelectedTagByIndex(rotatingRing.Index);
					if (this.TagComponent.HasTag(selectedTagByIndex2))
					{
						this.TagComponent.RemoveTag(new int?(selectedTagByIndex2));
					}
				}
			}
			LevelTagComponent tagComponent2 = this.TagComponent;
			notifyLock = tagComponent2.NotifyLock;
			tagComponent2.NotifyLock = notifyLock - 1L;
		}

		// Token: 0x06030697 RID: 198295 RVA: 0x00BDBA00 File Offset: 0x00BD9C00
		public void UpdateRingSelectedEffectByIndex(int index)
		{
			SceneItemTurntableControllerComponent.RotatingRing rotatingRing;
			if (!this.RotatingRings.TryGetValue(index, out rotatingRing))
			{
				return;
			}
			if (!this.IsInitComplete)
			{
				return;
			}
			if (rotatingRing.IsSelected)
			{
				int selectedTagByIndex = this.GetSelectedTagByIndex(rotatingRing.Index);
				if (!this.TagComponent.HasTag(selectedTagByIndex))
				{
					this.TagComponent.AddTag(new int?(selectedTagByIndex));
					return;
				}
			}
			else
			{
				int selectedTagByIndex2 = this.GetSelectedTagByIndex(rotatingRing.Index);
				if (this.TagComponent.HasTag(selectedTagByIndex2))
				{
					this.TagComponent.RemoveTag(new int?(selectedTagByIndex2));
				}
			}
		}

		// Token: 0x06030698 RID: 198296 RVA: 0x00BDBA8C File Offset: 0x00BD9C8C
		public void SetAllowRotate(bool allow)
		{
			if (allow && !this.GetRotateAllowed())
			{
				base.Enable(this.DisableHandle, "SceneItemTurntableControllerComponent.SetAllowRotate");
				this.DisableHandle = null;
				return;
			}
			if (!allow && this.GetRotateAllowed())
			{
				this.DisableHandle = new int?(base.Disable("稷廷开门主控机关: 旋转被禁止，禁用组件"));
			}
		}

		// Token: 0x06030699 RID: 198297 RVA: 0x00BDBAE4 File Offset: 0x00BD9CE4
		public bool GetRotateAllowed()
		{
			return this.DisableHandle == null;
		}

		// Token: 0x0603069A RID: 198298 RVA: 0x00BDBAF4 File Offset: 0x00BD9CF4
		private void HandleUpdateState(int stateId, bool isReady)
		{
			if (!this.IsInitComplete)
			{
				return;
			}
			if (stateId == GameplayTagDefine.EGameplayTagId["关卡.Common.状态.完成"])
			{
				this.SetAllowRotate(false);
				foreach (SceneItemTurntableControllerComponent.RotatingRing rotatingRing in this.RotatingRings)
				{
					IFreeAngleTurntable freeAngleTurntable = this.ControllerConfig as IFreeAngleTurntable;
					int? num;
					if (freeAngleTurntable != null)
					{
						num = new int?(freeAngleTurntable.ItemConfig[rotatingRing.Index].TargetAngle);
					}
					else
					{
						IFixedAngleTurntable fixedAngleTurntable = this.ControllerConfig as IFixedAngleTurntable;
						if (fixedAngleTurntable == null)
						{
							continue;
						}
						num = new int?(fixedAngleTurntable.ItemConfig[rotatingRing.Index].TargetAngle);
					}
					if (!rotatingRing.IsAtTarget)
					{
						this.SetRingAngle(rotatingRing, (float)num.Value);
						this.UpdateRingAtTarget(rotatingRing.Index, false);
					}
				}
				this.UpdateAllRingsAtTargetEffect();
				if (isReady)
				{
					Singleton<EventSystem>.Instance.EmitWithTarget<bool, bool>(base.Entity, EEventName.OnTurntableControllerBusyStateChange, false, false);
				}
			}
		}

		// Token: 0x0603069B RID: 198299 RVA: 0x00BDBC10 File Offset: 0x00BD9E10
		private void RequestTurntableComplete()
		{
			if (this.CreatureDataComponent == null)
			{
				return;
			}
			TurntableCompleteRequest turntableCompleteRequest = TurntableCompleteRequest.Create();
			turntableCompleteRequest.EntityId = this.CreatureDataComponent.GetCreatureDataId();
			Singleton<Net>.Instance.Call<TurntableCompleteResponse>(ERequestMessageId.TurntableCompleteRequest, turntableCompleteRequest, delegate(TurntableCompleteResponse response, Net.CallbackStatus _)
			{
				if ((response == null || response.ErrCode > ErrorCode.Success) && (response == null || response.ErrCode != ErrorCode.ErrStateEntityStateNoChange))
				{
					if (this.IsInitComplete && this.GetRotateAllowed() && this.IsBusyRotating())
					{
						this.TriggerStopAllRingsRotate();
					}
					this.TriggerResetAllRingsToInitAngle(true);
					Singleton<EventSystem>.Instance.EmitWithTarget<bool, bool>(base.Entity, EEventName.OnTurntableControllerBusyStateChange, false, false);
				}
			}, 0);
		}

		// Token: 0x0603069C RID: 198300 RVA: 0x00BDBC5A File Offset: 0x00BD9E5A
		private float AngleDiff(float angle1, float angle2)
		{
			return this.AngleClamp(angle2 - angle1, -180f, 180f);
		}

		// Token: 0x0603069D RID: 198301 RVA: 0x00BDBC70 File Offset: 0x00BD9E70
		private float AngleClamp(float angle, float min, float max)
		{
			float num;
			for (num = angle; num < min; num += 360f)
			{
			}
			while (num >= max)
			{
				num -= 360f;
			}
			return num;
		}

		// Token: 0x0603069E RID: 198302 RVA: 0x00BDBC9C File Offset: 0x00BD9E9C
		[NullableContext(1)]
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			SceneItemTurntableControllerComponent sceneItemTurntableControllerComponent = (SceneItemTurntableControllerComponent)componentTemplate;
			if (base.CanResetComponentProperty("ControllerConfig"))
			{
				if (sceneItemTurntableControllerComponent.ControllerConfig == null)
				{
					this.ControllerConfig = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<ITurntableControlType>(this.ControllerConfig), "ControllerConfig"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("RotatingRings"))
			{
				if (sceneItemTurntableControllerComponent.RotatingRings == null)
				{
					this.RotatingRings = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<List<SceneItemTurntableControllerComponent.RotatingRing>>(this.RotatingRings), "RotatingRings"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("DisableHandle"))
			{
				this.DisableHandle = sceneItemTurntableControllerComponent.DisableHandle;
			}
			if (base.CanResetComponentProperty("TagComponent"))
			{
				if (sceneItemTurntableControllerComponent.TagComponent == null)
				{
					this.TagComponent = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<LevelTagComponent>(this.TagComponent), "TagComponent"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("CreatureDataComponent"))
			{
				if (sceneItemTurntableControllerComponent.CreatureDataComponent == null)
				{
					this.CreatureDataComponent = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CreatureDataComponent>(this.CreatureDataComponent), "CreatureDataComponent"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("IsInitComplete"))
			{
				this.IsInitComplete = sceneItemTurntableControllerComponent.IsInitComplete;
			}
			return true;
		}

		// Token: 0x0401BCD0 RID: 113872
		private ITurntableControlType ControllerConfig;

		// Token: 0x0401BCD1 RID: 113873
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private List<SceneItemTurntableControllerComponent.RotatingRing> RotatingRings;

		// Token: 0x0401BCD2 RID: 113874
		private int? DisableHandle;

		// Token: 0x0401BCD3 RID: 113875
		private LevelTagComponent TagComponent;

		// Token: 0x0401BCD4 RID: 113876
		private CreatureDataComponent CreatureDataComponent;

		// Token: 0x0401BCD5 RID: 113877
		private bool IsInitComplete;

		// Token: 0x0200A97D RID: 43389
		[Nullable(0)]
		private class RotatingRing
		{
			// Token: 0x040347F1 RID: 215025
			public int Index;

			// Token: 0x040347F2 RID: 215026
			public AActor ControllerRingActor;

			// Token: 0x040347F3 RID: 215027
			public global::Rotator RingRotator;

			// Token: 0x040347F4 RID: 215028
			public float CurSpeed;

			// Token: 0x040347F5 RID: 215029
			public float AccumulateAngle;

			// Token: 0x040347F6 RID: 215030
			public bool IsSelected;

			// Token: 0x040347F7 RID: 215031
			public bool IsAtTarget;

			// Token: 0x040347F8 RID: 215032
			public bool IsRotating;
		}
	}
}
