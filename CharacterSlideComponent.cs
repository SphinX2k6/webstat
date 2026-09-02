using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using Aki.TDConfigMgr.Action;
using AkiClient.Game.Aki.Character.Role.Common;
using AkiClient.Game.Aki.Data.Level.Ski;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

// Token: 0x020030D3 RID: 12499
[NullableContext(1)]
[Nullable(0)]
public class CharacterSlideComponent : EntityComponent, IComponentDependency, IStaticVariableResetter
{
	// Token: 0x06019C9B RID: 105627 RVA: 0x00784A30 File Offset: 0x00782C30
	static CharacterSlideComponent()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(CharacterSlideComponent.CreateStaticDefaultValue), new Action(CharacterSlideComponent.ResetStaticDefaultValue));
	}

	// Token: 0x170022D4 RID: 8916
	// (get) Token: 0x06019C9C RID: 105628 RVA: 0x00784A9B File Offset: 0x00782C9B
	protected static float[] SlideFallingCoefficientArray
	{
		get
		{
			return CharacterSlideComponent._SlideFallingCoefficientArray;
		}
	}

	// Token: 0x170022D5 RID: 8917
	// (get) Token: 0x06019C9D RID: 105629 RVA: 0x00784AA2 File Offset: 0x00782CA2
	public static Slide SlideConfig
	{
		get
		{
			if (CharacterSlideComponent.SlideConfigInternal == null)
			{
				CharacterSlideComponent.SetSlideConfig(0);
			}
			return CharacterSlideComponent.SlideConfigInternal.Value;
		}
	}

	// Token: 0x06019C9E RID: 105630 RVA: 0x00784AC0 File Offset: 0x00782CC0
	public static void SetSlideConfig(int slideId)
	{
		if (((CharacterSlideComponent.SlideConfigInternal != null) ? CharacterSlideComponent.SlideConfigInternal.GetValueOrDefault().Id : null) == slideId.ToString())
		{
			return;
		}
		CharacterSlideComponent.SlideConfigInternal = ConfigSlideById.GetConfig(slideId.ToString(), true);
		List<float[]> list = new List<float[]>();
		foreach (DicIntFloat dicIntFloat in CharacterSlideComponent.SlideConfigInternal.Value.FallingLateralFrictionsIter())
		{
			float key = (float)dicIntFloat.Key;
			float value = dicIntFloat.Value;
			float num = (float)Math.Cos((double)(key * 0.017453292f));
			float[] item = new float[]
			{
				num * num * num,
				num * num,
				num,
				1f,
				value
			};
			list.Add(item);
		}
		for (int i = list.Count - 1; i >= 0; i--)
		{
			for (int j = 0; j < i; j++)
			{
				float num2 = list[j][i] / list[i][i];
				for (int k = 0; k < list[i].Length; k++)
				{
					list[j][k] -= list[i][k] * num2;
				}
			}
		}
		for (int l = 0; l < list.Count; l++)
		{
			for (int m = l + 1; m < list.Count; m++)
			{
				float num3 = list[m][l] / list[l][l];
				for (int n = 0; n < list[l].Length; n++)
				{
					list[m][n] -= list[l][n] * num3;
				}
			}
			CharacterSlideComponent.SlideFallingCoefficientArray[l] = list[l][4] / list[l][l];
		}
		if (!string.IsNullOrEmpty(CharacterSlideComponent.SlideConfigInternal.Value.SpeedReduceCurve))
		{
			Singleton<ResourceSystem>.Instance.LoadAsync<UCurveFloat>(CharacterSlideComponent.SlideConfigInternal.Value.SpeedReduceCurve, delegate([Nullable(2)] UCurveFloat curve, string _)
			{
				CharacterSlideComponent.SpeedReduceCurve = curve;
			}, 100, "js_undefined");
			return;
		}
		CharacterSlideComponent.SpeedReduceCurve = null;
	}

	// Token: 0x06019C9F RID: 105631 RVA: 0x00784D30 File Offset: 0x00782F30
	protected static float GetSlideFallingFriction(float cos)
	{
		if (CharacterSlideComponent.SlideConfigInternal == null)
		{
			CharacterSlideComponent.SetSlideConfig(0);
		}
		float num = 0f;
		foreach (float num2 in CharacterSlideComponent.SlideFallingCoefficientArray)
		{
			num = num * cos + num2;
		}
		return num;
	}

	// Token: 0x170022D6 RID: 8918
	// (get) Token: 0x06019CA0 RID: 105632 RVA: 0x00784D74 File Offset: 0x00782F74
	protected static UCurveFloat JumpAddMoveCurve
	{
		get
		{
			if (CharacterSlideComponent._jumpAddMoveCurveInternal == null)
			{
				CharacterSlideComponent._jumpAddMoveCurveInternal = Singleton<ResourceSystem>.Instance.GetLoadedAsset<UCurveFloat>("/Game/Aki/Character/BaseCharacter/Curves/CharacterMovementCurves/SpeedAirSlideSprint.SpeedAirSlideSprint");
			}
			return CharacterSlideComponent._jumpAddMoveCurveInternal;
		}
	}

	// Token: 0x170022D7 RID: 8919
	// (get) Token: 0x06019CA1 RID: 105633 RVA: 0x00784D96 File Offset: 0x00782F96
	[StaticVariableRuleIgnore]
	public static Type[] Dependencies
	{
		get
		{
			return new Type[]
			{
				typeof(CharacterActorComponent),
				typeof(CharacterMoveComponent),
				typeof(CharacterUnifiedStateComponent)
			};
		}
	}

	// Token: 0x06019CA2 RID: 105634 RVA: 0x00784DC8 File Offset: 0x00782FC8
	private void OnMoveStateChanged(global::ECharMoveState oldState, global::ECharMoveState newState)
	{
		if (newState != global::ECharMoveState.Slide)
		{
			this.MoveComp.CharacterMovement.FallingLateralFriction = 0f;
		}
		if (newState == global::ECharMoveState.NormalSki)
		{
			this.SkiDirection.DeepCopy(this.ActorComp.ActorForwardProxy);
			this.MoveComp.ResetTurnRate();
			if (!this.VelocityBeforeJump.Equality(global::Vector.ZeroVectorProxy))
			{
				this.TmpVector.DeepCopy(this.VelocityBeforeJump);
				this.CacheBlockDirect.Multiply(this.TmpVector.DotProduct(this.CacheBlockDirect), this.TmpVector2);
				this.TmpVector.Subtraction(this.TmpVector2, this.TmpVector2);
				double inB = Math.Min(this.TmpVector2.Size(), 3500.0);
				this.TmpVector.DeepCopy(this.ActorComp.ActorForwardProxy);
				this.CacheBlockDirect.Multiply(this.TmpVector.DotProduct(this.CacheBlockDirect), this.TmpVector3);
				this.TmpVector.Subtraction(this.TmpVector3, this.TmpVector3);
				if (!this.TmpVector3.Normalize(9.99999993922529E-09))
				{
					this.TmpVector3.DeepCopy(this.ActorComp.ActorForwardProxy);
				}
				this.TmpVector3.MultiplyEqual(inB);
				this.MoveComp.SetForceSpeed(this.TmpVector3);
				this.VelocityBeforeJump.Reset();
			}
		}
	}

	// Token: 0x06019CA3 RID: 105635 RVA: 0x00784F3C File Offset: 0x0078313C
	private unsafe void OnMoveSki(float delta)
	{
		if (this.NeedInitSpeed)
		{
			this.ActorComp.ActorForwardProxy.Multiply((double)this.SkiConfig.InitSpeed, this.TmpVector);
			this.MoveComp.SetForceSpeed(this.TmpVector);
			this.NeedInitSpeed = false;
		}
		this.CalcSkiDirection(delta, this.SkiDirection);
		this.CalcSkiSpeedParams(this.TmpVector);
		int num = UKuroMovementBPLibrary.KuroSki(delta, this.MoveComp.CharacterMovement, this.GroundNormal.ToUeVectorOld(), this.SkiDirection.ToUeVectorOld(), this.TmpVector.ToUeVectorOld(), this.SkiConfig.IgnoreStepHeight, null);
		if (num != 0)
		{
			if (this.DetectFloor() != null)
			{
				CharacterActorComponent actorComp = this.ActorComp;
				if (actorComp != null)
				{
					actorComp.Actor.KuroSetMovementMode(new SetMovementModeInfo
					{
						Mode = EMovementMode.MOVE_Walking,
						Context = "[CharacterSlideComponent.OnMoveSki] Walking"
					});
				}
				this.UnifiedStateComp.SetMoveState(global::ECharMoveState.Run);
			}
			else
			{
				CharacterActorComponent actorComp2 = this.ActorComp;
				if (actorComp2 != null)
				{
					actorComp2.Actor.KuroSetMovementMode(new SetMovementModeInfo
					{
						Mode = EMovementMode.MOVE_Falling,
						Context = "[CharacterSlideComponent.OnMoveSki] Falling"
					});
				}
			}
			this.ExitSlideThisFrame = true;
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.Movement;
			ELogAuthor author = ELogAuthor.YJX;
			string message = "滑雪中断";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Type", num);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		if (!this.CheckSkiException(delta))
		{
			this.LeaveSlideCountDown -= delta;
			if (this.LeaveSlideCountDown < 0f)
			{
				global::Log instance2 = Singleton<global::Log>.Instance;
				ELogModule module2 = ELogModule.Movement;
				ELogAuthor author2 = ELogAuthor.YJX;
				string message2 = "检测到异常，退出滑雪模式";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Angle", Math.Acos(global::Vector.DotProduct(this.GroundNormal, this.ActorComp.MoveComp.GravityUp)));
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("MoveDelta", global::Vector.Dist(this.ActorComp.LastActorLocation, this.TmpVector));
				instance2.Warn(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				this.ExitSkiMode(true);
			}
		}
	}

	// Token: 0x06019CA4 RID: 105636 RVA: 0x00785150 File Offset: 0x00783350
	private void CalcSkiSpeedParams(global::Vector outVec)
	{
		float num = this.SkiConfig.BaseAccForSpeedUp;
		float num2 = this.SkiConfig.BaseTargetSpeed;
		global::Vector gravityUp = this.ActorComp.MoveComp.GravityUp;
		float num3 = (float)(Math.Acos(Singleton<MathUtils>.Instance.Clamp(global::Vector.DotProduct(this.SlideForward, gravityUp), -1.0, 1.0)) * 57.295780181884766) / 90f;
		float num4 = this.SkiConfig.SlopExtraAccel * num3;
		float num5 = this.SkiConfig.SlopExtraTargetSpeed * num3;
		int num6 = Math.Sign(global::Vector.DotProduct(this.ActorComp.ActorForwardProxy, this.SlideForward));
		num += (float)num6 * num4;
		num2 += (float)num6 * num5;
		if (this.SkiAccelConfig != null)
		{
			num += (float)this.SkiAccelConfig.Acceleration;
			num2 += (float)this.SkiAccelConfig.LimitSpeed;
		}
		num2 = Math.Min(num2, 3500f);
		outVec.Set((double)num, (double)this.SkiConfig.BaseAccForSpeedDown, (double)num2);
	}

	// Token: 0x06019CA5 RID: 105637 RVA: 0x0078525C File Offset: 0x0078345C
	private void CalcSkiDirection(float deltaTime, global::Vector outDirection)
	{
		global::Vector tmpVector = this.TmpVector;
		global::Vector tmpVector2 = this.TmpVector2;
		global::Vector tmpVector3 = this.TmpVector3;
		global::Vector tmpVector4 = this.TmpVector4;
		float turnSpeed = this.SkiConfig.TurnSpeed;
		float num = -50f;
		float num2 = 50f;
		CharacterSplineMoveComponent component = base.Entity.GetComponent<CharacterSplineMoveComponent>();
		tmpVector.DeepCopy(this.ActorComp.ActorForwardProxy);
		if (component != null && component.Active)
		{
			num = component.MinTurnAngle;
			num2 = component.MaxTurnAngle;
			tmpVector.DeepCopy(component.SplineDirection);
		}
		double inB = global::Vector.DotProduct(tmpVector, this.SlideForward);
		this.SlideForward.Multiply(inB, this.TmpVector5);
		tmpVector.SubtractionEqual(this.TmpVector5);
		tmpVector.Normalize(9.99999993922529E-09);
		this.SlideForward.CrossProduct(tmpVector, tmpVector3);
		if (!tmpVector3.Normalize(9.99999993922529E-09))
		{
			tmpVector3.DeepCopy(this.ActorComp.ActorRightProxy);
		}
		tmpVector2.DeepCopy(this.ActorComp.InputDirectProxy);
		if (!tmpVector2.Normalize(9.99999993922529E-09))
		{
			tmpVector2.Reset();
		}
		else
		{
			tmpVector3.Multiply(tmpVector3.DotProduct(tmpVector2), tmpVector2);
		}
		if (tmpVector2.ContainsNaN())
		{
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.Movement;
			ELogAuthor author = ELogAuthor.YJX;
			string message = "滑雪输入中有NaN";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Input", tmpVector2);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		tmpVector4.DeepCopy(this.ActorComp.ActorVelocityProxy);
		if (!tmpVector4.Normalize(9.99999993922529E-09))
		{
			tmpVector4.DeepCopy(this.ActorComp.ActorForwardProxy);
		}
		inB = global::Vector.DotProduct(tmpVector4, this.SlideForward);
		this.SlideForward.Multiply(inB, this.TmpVector5);
		tmpVector4.SubtractionEqual(this.TmpVector5);
		tmpVector4.Normalize(9.99999993922529E-09);
		float num3 = (float)(Math.Acos(Singleton<MathUtils>.Instance.Clamp(tmpVector4.DotProduct(tmpVector), -1.0, 1.0)) * 57.295780181884766);
		float num4 = this.AngleNormalize((float)Math.Sign(tmpVector4.DotProduct(tmpVector3)) * num3);
		double num5 = tmpVector2.DotProduct(tmpVector3) * (double)turnSpeed * (double)deltaTime;
		double num6 = Singleton<MathUtils>.Instance.Clamp((double)num4 + num5, (double)num, (double)num2);
		this.TmpVector5.DeepCopy(this.SlideForward);
		this.TmpVector5.MultiplyEqual((double)((float)Math.Sin(num6 * 0.01745329238474369 * 0.5)));
		this.TmpQuat.Set((float)this.TmpVector5.X, (float)this.TmpVector5.Y, (float)this.TmpVector5.Z, (float)Math.Cos(num6 * 0.01745329238474369 * 0.5));
		this.TmpQuat.RotateVector(tmpVector, outDirection);
		inB = global::Vector.DotProduct(outDirection, this.SlideForward);
		this.SlideForward.Multiply(inB, this.TmpVector5);
		outDirection.SubtractionEqual(this.TmpVector5);
		outDirection.Normalize(9.99999993922529E-09);
	}

	// Token: 0x06019CA6 RID: 105638 RVA: 0x00785578 File Offset: 0x00783778
	private float AngleNormalize(float angle)
	{
		float num;
		for (num = angle; num > 180f; num -= 360f)
		{
		}
		while (num < -180f)
		{
			num += 360f;
		}
		return num;
	}

	// Token: 0x06019CA7 RID: 105639 RVA: 0x007855AC File Offset: 0x007837AC
	private void OnMoveSlide(float delta)
	{
		Slide slideConfig = CharacterSlideComponent.SlideConfig;
		this.TmpVector3.DeepCopy(this.ActorComp.InputDirectProxy);
		global::Vector tmpVector = this.TmpVector3;
		bool flag = false;
		if (tmpVector.Normalize(9.99999993922529E-09))
		{
			flag = slideConfig.Ski;
			this.TmpVector.DeepCopy(this.SlideForward);
			this.MoveComp.GravityDirect.CrossProduct(this.TmpVector, this.TmpVector2);
			this.TmpVector2.CrossProduct(this.TmpVector, this.SlideUp);
			if (this.SlideUp.Normalize(9.99999993922529E-09))
			{
				bool flag2 = true;
				if (slideConfig.Ski)
				{
					this.TmpVector.DeepCopy(this.SlideForward);
					Singleton<GravityUtils>.Instance.ConvertToPlanarVectorForActor(this.ActorComp, this.TmpVector);
					this.TmpVector.Normalize(9.99999993922529E-09);
					flag2 = (Singleton<GravityUtils>.Instance.GetAngleOffsetInGravityAbsForActor(this.ActorComp, this.TmpVector, tmpVector) < 135f);
					if (flag2)
					{
						this.TmpVector.DeepCopy(this.ActorComp.ActorVelocityProxy);
						Singleton<GravityUtils>.Instance.ConvertToPlanarVectorForActor(this.ActorComp, this.TmpVector);
						if (!this.TmpVector.Normalize(9.99999993922529E-09))
						{
							this.SlideUp.UnaryNegation(this.TmpVector);
						}
						float angleOffsetInGravityForActor = Singleton<GravityUtils>.Instance.GetAngleOffsetInGravityForActor(this.ActorComp, this.TmpVector, this.ActorComp.InputDirectProxy);
						if (Math.Abs(angleOffsetInGravityForActor) > 135f)
						{
							this.MoveComp.GravityDirect.CrossProduct(this.TmpVector, this.TmpVector2);
							float num = (float)Math.Sign(angleOffsetInGravityForActor) * 135f * 0.017453292f;
							this.TmpVector.MultiplyEqual((double)((float)Math.Cos((double)num)));
							this.TmpVector2.MultiplyEqual((double)((float)Math.Sin((double)num)));
							this.TmpVector.Addition(this.TmpVector2, tmpVector);
						}
					}
				}
				double num2 = tmpVector.DotProduct(this.SlideUp);
				double num3;
				if (num2 > 0.0)
				{
					num3 = num2 * (double)slideConfig.SlideAccelUp;
					double num4 = this.ActorComp.ActorVelocityProxy.DotProduct(this.SlideUp);
					if (slideConfig.Ski)
					{
						num3 *= Singleton<MathUtils>.Instance.RangeClamp(num4, (double)(-(double)slideConfig.SkiHorizontalInputSpeedThreshold.Value.Max), (double)(-(double)slideConfig.SkiHorizontalInputSpeedThreshold.Value.Min), 1.0, 0.0);
					}
					else if (num3 * (double)slideConfig.SlideAccel * (double)delta > num4)
					{
						num3 = 0.0;
					}
				}
				else
				{
					num3 = num2 * (double)slideConfig.SlideAccelDown;
				}
				this.SlideUp.Multiply(num3, this.TmpVector);
				if (flag2)
				{
					this.TmpVector2.MultiplyEqual(this.TmpVector2.DotProduct(tmpVector) / this.TmpVector2.SizeSquared());
					this.TmpVector.AdditionEqual(this.TmpVector2);
				}
				this.TmpVector.MultiplyEqual((double)slideConfig.SlideAccel);
			}
			else
			{
				tmpVector.Multiply((double)slideConfig.SlideAccel, this.TmpVector);
			}
		}
		else
		{
			this.TmpVector.Reset();
		}
		if (this.TmpVector.ContainsNaN())
		{
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.Movement;
			ELogAuthor author = ELogAuthor.LCZ;
			string message = "Slide speed has NaN";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("velocity", this.TmpVector);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		float airFriction;
		float slideFriction;
		float num5;
		float maxSlideVerticalSpeed;
		if (this.SkiAccelConfig != null)
		{
			airFriction = 0f;
			slideFriction = 0f;
			num5 = (float)this.SkiAccelConfig.LimitSpeed;
			maxSlideVerticalSpeed = num5;
		}
		else
		{
			airFriction = this.CurrentAirFriction;
			slideFriction = slideConfig.SlideFriction;
			if (flag)
			{
				num5 = slideConfig.SkiMaxSpHor;
				maxSlideVerticalSpeed = slideConfig.SkiMaxSpVer;
			}
			else
			{
				num5 = slideConfig.MaxSlideHorizontalSeed;
				maxSlideVerticalSpeed = -1f;
			}
		}
		if (!this.MoveComp.CharacterMovement.KuroSlide(delta, airFriction, slideFriction, (this.LeaveSlideCountDown == 0.25f) ? this.TmpVector.ToUeVectorOld() : global::Vector.ZeroVector, num5, this.GroundNormal.ToUeVectorOld(), maxSlideVerticalSpeed, CharacterSlideComponent.SpeedReduceCurve))
		{
			if (this.MoveComp.CharacterMovement.Kuro_GetBlockActorWhenMove() != null)
			{
				CharacterActorComponent actorComp = this.ActorComp;
				if (actorComp != null)
				{
					actorComp.Actor.KuroSetMovementMode(new SetMovementModeInfo
					{
						Mode = EMovementMode.MOVE_Walking,
						Context = "[CharacterSlideComponent.OnMoveSlide] Walking"
					});
				}
				this.ExitSlideThisFrame = true;
				return;
			}
			this.LeaveSlideCountDown -= delta;
			if (this.LeaveSlideCountDown < 0f && this.CheckExitSlide())
			{
				CharacterActorComponent actorComp2 = this.ActorComp;
				if (actorComp2 != null)
				{
					actorComp2.Actor.KuroSetMovementMode(new SetMovementModeInfo
					{
						Mode = EMovementMode.MOVE_Falling,
						Context = "[CharacterSlideComponent.OnMoveSlide] Falling"
					});
				}
				this.ExitSlideThisFrame = true;
				return;
			}
		}
		else
		{
			this.LeaveSlideCountDown = 0.25f;
		}
	}

	// Token: 0x06019CA8 RID: 105640 RVA: 0x00785AA8 File Offset: 0x00783CA8
	private void OnInherit(Entity oldEntity, bool notInheritMoveAndAnim)
	{
		if (notInheritMoveAndAnim)
		{
			return;
		}
		CharacterSlideComponent component = oldEntity.GetComponent<CharacterSlideComponent>();
		if (this.UnifiedStateComp.MoveState != global::ECharMoveState.Slide && this.UnifiedStateComp.MoveState != global::ECharMoveState.NormalSki && component.UnifiedStateComp.MoveState != global::ECharMoveState.Slide && component.UnifiedStateComp.MoveState != global::ECharMoveState.NormalSki)
		{
			return;
		}
		this.LeaveSlideCountDown = component.LeaveSlideCountDown;
		this.SlideForward.DeepCopy(component.SlideForward);
		this.LastZ = component.LastZ;
		this.CurrentAirFriction = component.CurrentAirFriction;
		this.SlideSwitchThisFrame = component.SlideSwitchThisFrame;
		this.StandMode = component.StandMode;
		this.LastAngleOffset = component.LastAngleOffset;
		this.SkiConfig = component.SkiConfig;
		this.SkiAccelConfig = component.SkiAccelConfig;
		this.SkiAccelCountDown = component.SkiAccelCountDown;
	}

	// Token: 0x06019CA9 RID: 105641 RVA: 0x00785B7C File Offset: 0x00783D7C
	protected override bool OnStart()
	{
		this.ActorComp = base.Entity.GetComponent<CharacterActorComponent>();
		this.MoveComp = base.Entity.GetComponent<CharacterMoveComponent>();
		this.AnimComp = base.Entity.GetComponent<CharacterAnimationComponent>();
		this.AttributeComp = base.Entity.GetComponent<BaseAttributeComponent>();
		this.InputComp = base.Entity.GetComponent<CharacterInputComponent>();
		this.UnifiedStateComp = base.Entity.GetComponent<CharacterUnifiedStateComponent>();
		this.SkillComp = base.Entity.GetComponent<CharacterSkillComponent>();
		this.TagComp = base.Entity.GetComponent<BaseTagComponent>();
		this.TmpVector.Reset();
		this.SlideUp.Reset();
		BaseTagComponent tagComp = this.TagComp;
		if (tagComp != null && tagComp.Valid)
		{
			int[] disableTags = CharacterSlideComponent.DisableTags;
			for (int i = 0; i < disableTags.Length; i++)
			{
				int tagId = disableTags[i];
				this.TagListeners.Add(this.TagComp.ListenForTagAnyCountChanged(tagId, delegate(int newCount, int _, int _, int _)
				{
					this.OnDisableTagChanged(tagId, newCount);
				}));
				if (this.TagComp.HasTag(tagId))
				{
					this.DisableTagSet.Add(tagId);
				}
			}
		}
		Singleton<EventSystem>.Instance.AddWithTarget(base.Entity, EEventName.CharOnUnifiedMoveStateChanged, new Action<global::ECharMoveState, global::ECharMoveState>(this.OnMoveStateChanged));
		Singleton<EventSystem>.Instance.AddWithTarget(base.Entity, EEventName.CustomMoveSlide, new Action<float>(this.OnMoveSlide));
		Singleton<EventSystem>.Instance.AddWithTarget(base.Entity, EEventName.CustomMoveSki, new Action<float>(this.OnMoveSki));
		Singleton<EventSystem>.Instance.AddWithTarget(base.Entity, EEventName.RoleOnStateInherit, new Action<Entity, bool>(this.OnInherit));
		return true;
	}

	// Token: 0x06019CAA RID: 105642 RVA: 0x00785D38 File Offset: 0x00783F38
	protected override bool OnEnd()
	{
		Singleton<EventSystem>.Instance.RemoveWithTarget(base.Entity, EEventName.CharOnUnifiedMoveStateChanged, new Action<global::ECharMoveState, global::ECharMoveState>(this.OnMoveStateChanged));
		Singleton<EventSystem>.Instance.RemoveWithTarget(base.Entity, EEventName.CustomMoveSlide, new Action<float>(this.OnMoveSlide));
		Singleton<EventSystem>.Instance.RemoveWithTarget(base.Entity, EEventName.CustomMoveSki, new Action<float>(this.OnMoveSki));
		Singleton<EventSystem>.Instance.RemoveWithTarget(base.Entity, EEventName.RoleOnStateInherit, new Action<Entity, bool>(this.OnInherit));
		foreach (ITagTask tagTask in this.TagListeners)
		{
			tagTask.EndTask();
		}
		this.TagListeners.Clear();
		return true;
	}

	// Token: 0x06019CAB RID: 105643 RVA: 0x00785E18 File Offset: 0x00784018
	protected override void OnTick(float delta)
	{
		CharacterActorComponent actorComp = this.ActorComp;
		if (actorComp == null || !actorComp.IsMoveAutonomousProxy)
		{
			return;
		}
		if (this.UnifiedStateComp.MoveState == global::ECharMoveState.Glide || this.UnifiedStateComp.MoveState == global::ECharMoveState.Soar || this.MoveComp.IsJump)
		{
			return;
		}
		if (this.UnifiedStateComp.PositionState == global::ECharPositionState.Ride)
		{
			return;
		}
		CharacterSkillComponent skillComp = this.SkillComp;
		if (((skillComp != null) ? skillComp.CurrentSkill : null) != null)
		{
			CharacterUnifiedStateComponent unifiedStateComp = this.UnifiedStateComp;
			if (unifiedStateComp != null && unifiedStateComp.MoveState == global::ECharMoveState.Slide)
			{
				CharacterActorComponent actorComp2 = this.ActorComp;
				if (actorComp2 == null)
				{
					return;
				}
				actorComp2.Actor.KuroSetMovementMode(new SetMovementModeInfo
				{
					Mode = EMovementMode.MOVE_Falling,
					Context = "[CharacterSlideComponent.OnTick]"
				});
			}
			return;
		}
		if (this.InputComp.IsInAutomaticFlightMode())
		{
			return;
		}
		if (this.IsInSkiMode)
		{
			this.TickSkiMode(delta);
			return;
		}
		this.TickSlideMode(delta);
	}

	// Token: 0x06019CAC RID: 105644 RVA: 0x00785EF8 File Offset: 0x007840F8
	private void FindStandMode(bool enterSlideFrame, Slide slideConfig)
	{
		this.SlideSwitchThisFrame = false;
		if (this.SkiConfig != null)
		{
			if (enterSlideFrame)
			{
				this.SlideSwitchThisFrame = false;
			}
			else
			{
				this.SlideSwitchThisFrame = !this.StandMode;
			}
			this.StandMode = true;
			return;
		}
		if (enterSlideFrame)
		{
			this.SlideSwitchThisFrame = false;
			this.StandMode = (Singleton<GravityUtils>.Instance.GetZnInGravityForActor(this.ActorComp, this.SlideForward) > (double)((float)Math.Cos((double)((slideConfig.SlideModeSwitchRange.Value.Min + slideConfig.SlideModeSwitchRange.Value.Max) / 2f * 0.017453292f))));
			return;
		}
		if (this.StandMode)
		{
			if (Singleton<GravityUtils>.Instance.GetZnInGravityForActor(this.ActorComp, this.SlideForward) < (double)((float)Math.Cos((double)(slideConfig.SlideModeSwitchRange.Value.Max * 0.017453292f))))
			{
				this.StandMode = false;
				this.SlideSwitchThisFrame = true;
				return;
			}
		}
		else if (Singleton<GravityUtils>.Instance.GetZnInGravityForActor(this.ActorComp, this.SlideForward) > (double)((float)Math.Cos((double)(slideConfig.SlideModeSwitchRange.Value.Min * 0.017453292f))))
		{
			this.StandMode = true;
			this.SlideSwitchThisFrame = true;
		}
	}

	// Token: 0x06019CAD RID: 105645 RVA: 0x00786044 File Offset: 0x00784244
	private void SetInputRotator(bool enterSlideFrame)
	{
		if (this.SkiConfig != null)
		{
			global::Vector tmpVector = this.TmpVector;
			FVector velocity = this.MoveComp.CharacterMovement.Velocity;
			tmpVector.FromUeVector(velocity);
			this.ActorComp.SetInputFacing(this.TmpVector, true);
			this.ActorComp.SetOverrideTurnSpeed(new float?(this.SkiConfig.TurnSpeed));
			return;
		}
		if (this.TagComp.HasTag(GameplayTagDefine.EGameplayTagId["关卡.关卡运动.屏蔽滑坡转体"]) || this.StandMode)
		{
			this.ActorComp.SetInputFacing(this.SlideForward, true);
			this.LastAngleOffset = 0f;
		}
		else
		{
			if (enterSlideFrame || this.ActorComp.InputDirectProxy.IsNearlyZero(9.999999747378752E-05))
			{
				this.TmpVector.DeepCopy(this.ActorComp.ActorForwardProxy);
			}
			else
			{
				this.TmpVector.DeepCopy(this.ActorComp.InputDirectProxy);
			}
			Singleton<GravityUtils>.Instance.GetBaseQuatInGravityForActor(this.ActorComp, this.TmpQuat2);
			this.TmpQuat2.Inverse(this.TmpQuat);
			this.TmpQuat.RotateVector(this.SlideForward, this.TmpVector2);
			this.TmpQuat.RotateVector(this.TmpVector, this.TmpVector3);
			double angleByVector2D = Singleton<MathUtils>.Instance.GetAngleByVector2D(this.TmpVector2);
			double angleByVector2D2 = Singleton<MathUtils>.Instance.GetAngleByVector2D(this.TmpVector3);
			double num = Singleton<MathUtils>.Instance.WrapAngle(angleByVector2D2 - angleByVector2D);
			if (enterSlideFrame)
			{
				this.LastAngleOffset = (float)Math.Round(num / 180.0) * 180f;
			}
			else if (Math.Abs(Singleton<MathUtils>.Instance.WrapAngle((double)this.LastAngleOffset - num)) > 135.0)
			{
				this.LastAngleOffset = (float)Math.Round(num / 180.0) * 180f;
			}
			this.TmpRotator.Set(0f, (float)(angleByVector2D + (double)this.LastAngleOffset), 0f);
			this.TmpQuat2.Multiply(this.TmpRotator.Quaternion(null), this.TmpQuat);
			this.ActorComp.SetInputRotator(this.TmpQuat.Rotator(null));
		}
		this.ActorComp.SetOverrideTurnSpeed(new float?(CharacterSlideComponent.SlideConfig.TurnSpeed));
	}

	// Token: 0x06019CAE RID: 105646 RVA: 0x00786299 File Offset: 0x00784499
	private void OnDisableTagChanged(int tagId, int newCount)
	{
		if (newCount == 0)
		{
			this.DisableTagSet.Remove(tagId);
			return;
		}
		this.DisableTagSet.Add(tagId);
	}

	// Token: 0x06019CAF RID: 105647 RVA: 0x007862BC File Offset: 0x007844BC
	private bool CheckExitSlide()
	{
		UTraceSphereElement actorTrace = ModelBase<TraceElementModel>.Instance.GetActorTrace();
		actorTrace.WorldContextObject = this.ActorComp.Actor;
		actorTrace.Radius = this.ActorComp.ScaledRadius;
		Singleton<TraceElementCommon>.Instance.SetStartLocation(actorTrace, this.ActorComp.ActorLocationProxy);
		this.TmpVector.DeepCopy(this.ActorComp.ActorLocationProxy);
		Singleton<GravityUtils>.Instance.AddZnInGravityForActor(this.ActorComp, this.TmpVector, (double)(-(double)(this.ActorComp.ScaledHalfHeight - this.ActorComp.Radius + 5f)));
		Singleton<TraceElementCommon>.Instance.SetEndLocation(actorTrace, this.TmpVector);
		return !Singleton<TraceElementCommon>.Instance.ShapeTrace(this.ActorComp.Actor.CapsuleComponent, actorTrace, "slide", "slide");
	}

	// Token: 0x06019CB0 RID: 105648 RVA: 0x00786394 File Offset: 0x00784594
	[NullableContext(2)]
	private UKuroHitResult DetectFloor()
	{
		UTraceSphereElement actorTrace = ModelBase<TraceElementModel>.Instance.GetActorTrace();
		actorTrace.WorldContextObject = this.ActorComp.Actor;
		actorTrace.Radius = this.ActorComp.ScaledRadius;
		this.TmpVector.DeepCopy(this.ActorComp.ActorLocationProxy);
		Singleton<GravityUtils>.Instance.AddZnInGravityForActor(this.ActorComp, this.TmpVector, (double)(-(double)(this.ActorComp.ScaledHalfHeight - this.ActorComp.ScaledRadius)));
		Singleton<TraceElementCommon>.Instance.SetStartLocation(actorTrace, this.TmpVector);
		this.TmpVector2.DeepCopy(this.ActorComp.ActorLocationProxy);
		Singleton<GravityUtils>.Instance.AddZnInGravityForActor(this.ActorComp, this.TmpVector2, (double)(-(double)this.ActorComp.ScaledHalfHeight));
		Singleton<TraceElementCommon>.Instance.SetEndLocation(actorTrace, this.TmpVector2);
		actorTrace.ActorsToIgnore.Empty(true);
		foreach (AActor value in ModelBase<WorldModel>.Instance.ActorsToIgnoreSet)
		{
			actorTrace.ActorsToIgnore.Add(value);
		}
		if (!Singleton<TraceElementCommon>.Instance.ShapeTrace(this.ActorComp.Actor.CapsuleComponent, actorTrace, "slide", "slide"))
		{
			return null;
		}
		return actorTrace.HitResult;
	}

	// Token: 0x06019CB1 RID: 105649 RVA: 0x007864F8 File Offset: 0x007846F8
	private bool TraceDetect()
	{
		UTraceSphereElement actorTrace = ModelBase<TraceElementModel>.Instance.GetActorTrace();
		actorTrace.WorldContextObject = this.ActorComp.Actor;
		actorTrace.Radius = this.ActorComp.ScaledRadius;
		this.TmpVector.DeepCopy(this.ActorComp.ActorLocationProxy);
		Singleton<GravityUtils>.Instance.AddZnInGravityForActor(this.ActorComp, this.TmpVector, (double)(-(double)(this.ActorComp.ScaledHalfHeight - this.ActorComp.ScaledRadius)));
		Singleton<TraceElementCommon>.Instance.SetStartLocation(actorTrace, this.TmpVector);
		this.ActorComp.MoveComp.GravityUp.CrossProduct(this.SlideForward, this.TmpVector3);
		this.TmpVector3.CrossProduct(this.SlideForward, this.TmpVector3);
		this.TmpVector3.Normalize(9.99999993922529E-09);
		this.TmpVector3.MultiplyEqual(100.0);
		this.TmpVector.Addition(this.TmpVector3, this.TmpVector2);
		Singleton<TraceElementCommon>.Instance.SetEndLocation(actorTrace, this.TmpVector2);
		actorTrace.ActorsToIgnore.Empty(true);
		foreach (AActor value in ModelBase<WorldModel>.Instance.ActorsToIgnoreSet)
		{
			actorTrace.ActorsToIgnore.Add(value);
		}
		if (Singleton<TraceElementCommon>.Instance.ShapeTrace(this.ActorComp.Actor.CapsuleComponent, actorTrace, "slide", "slide"))
		{
			Singleton<TraceElementCommon>.Instance.GetImpactNormal(actorTrace.HitResult, 0, this.TmpVector3);
			this.TmpVector3.AdditionEqual(this.SlideForward);
			return this.TmpVector3.Normalize(9.99999993922529E-09) && Singleton<GravityUtils>.Instance.GetZnInGravityForActor(this.ActorComp, this.TmpVector3) < 0.7070000171661377;
		}
		return true;
	}

	// Token: 0x06019CB2 RID: 105650 RVA: 0x007866FC File Offset: 0x007848FC
	private bool TraceDetect2()
	{
		UTraceSphereElement actorTrace = ModelBase<TraceElementModel>.Instance.GetActorTrace();
		actorTrace.WorldContextObject = this.ActorComp.Actor;
		actorTrace.Radius = this.ActorComp.ScaledRadius;
		this.TmpVector.DeepCopy(this.ActorComp.ActorLocationProxy);
		Singleton<GravityUtils>.Instance.AddZnInGravityForActor(this.ActorComp, this.TmpVector, (double)(-(double)(this.ActorComp.ScaledHalfHeight - this.ActorComp.ScaledRadius)));
		Singleton<TraceElementCommon>.Instance.SetStartLocation(actorTrace, this.TmpVector);
		this.ActorComp.MoveComp.GravityUp.CrossProduct(this.SlideForward, this.TmpVector3);
		this.TmpVector3.CrossProduct(this.SlideForward, this.TmpVector3);
		this.TmpVector3.Normalize(9.99999993922529E-09);
		this.TmpVector3.MultiplyEqual(100.0);
		this.TmpVector.Addition(this.TmpVector3, this.TmpVector2);
		Singleton<TraceElementCommon>.Instance.SetEndLocation(actorTrace, this.TmpVector2);
		actorTrace.ActorsToIgnore.Empty(true);
		foreach (AActor value in ModelBase<WorldModel>.Instance.ActorsToIgnoreSet)
		{
			actorTrace.ActorsToIgnore.Add(value);
		}
		if (!Singleton<TraceElementCommon>.Instance.ShapeTrace(this.ActorComp.Actor.CapsuleComponent, actorTrace, "slide", "slide"))
		{
			return true;
		}
		Singleton<TraceElementCommon>.Instance.GetImpactNormal(actorTrace.HitResult, 0, this.TmpVector3);
		this.TmpVector3.AdditionEqual(this.SlideForward);
		return this.TmpVector3.Normalize(9.99999993922529E-09);
	}

	// Token: 0x06019CB3 RID: 105651 RVA: 0x007868E0 File Offset: 0x00784AE0
	public void OnJump()
	{
		if (this.ActorComp == null)
		{
			return;
		}
		this.VelocityBeforeJump.DeepCopy(this.ActorComp.ActorVelocityProxy);
		this.TmpVector.DeepCopy(this.ActorComp.ActorVelocityProxy);
		this.CacheBlockDirect.Multiply(this.TmpVector.DotProduct(this.CacheBlockDirect), this.TmpVector2);
		this.TmpVector.Subtraction(this.TmpVector2, this.TmpVector3);
		CharacterMoveComponent moveComp = this.MoveComp;
		this.JumpAddMoveHandler = ((moveComp != null) ? new int?(moveComp.SetAddMoveWorld(new FVectorDouble?(this.TmpVector3.ToUeVector(false)), 2f, null, this.JumpAddMoveHandler, null, EVelocityCurveType.LinearityDown, 0f, 1f)) : null);
		this.MoveComp.SetTurnRate(this.SkiConfig.JumpTurnRate);
		this.TagComp.AddTagAddOrRemoveListener(GameplayTagDefine.EGameplayTagId["关卡.关卡运动.关卡运动类型.滑雪"], new BaseTagComponent.TTagSwitchedCallback(this.OnExitSkiWhenJump), null);
	}

	// Token: 0x06019CB4 RID: 105652 RVA: 0x007869F0 File Offset: 0x00784BF0
	public void SetSkiAccel(IAccelerateSkiConfig config)
	{
		CharacterUnifiedStateComponent unifiedStateComp = this.UnifiedStateComp;
		if (unifiedStateComp == null || unifiedStateComp.PositionState > global::ECharPositionState.Ground)
		{
			CharacterUnifiedStateComponent unifiedStateComp2 = this.UnifiedStateComp;
			if (unifiedStateComp2 == null || unifiedStateComp2.MoveState != global::ECharMoveState.NormalSki)
			{
				return;
			}
		}
		this.SkiAccelCountDown = (float)config.Duration;
		this.SkiAccelConfig = config;
		int? instantSpeed = this.SkiAccelConfig.InstantSpeed;
		if (instantSpeed != null && instantSpeed.GetValueOrDefault() != 0)
		{
			double inB = Math.Min(this.ActorComp.ActorVelocityProxy.Size() + (double)this.SkiAccelConfig.InstantSpeed.Value, 3500.0);
			this.TmpVector.DeepCopy(this.ActorComp.ActorVelocityProxy);
			if (!this.TmpVector.Normalize(9.99999993922529E-09))
			{
				this.TmpVector.DeepCopy(this.ActorComp.ActorForwardProxy);
			}
			this.TmpVector.MultiplyEqual(inB);
			this.MoveComp.SetForceSpeed(this.TmpVector);
		}
		this.TagComp.AddTag(new int?(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.滑雪加速"]));
	}

	// Token: 0x06019CB5 RID: 105653 RVA: 0x00786B1C File Offset: 0x00784D1C
	public void TickSlideMode(float delta)
	{
		if (this.ExitSlideThisFrame)
		{
			this.ExitSlideThisFrame = false;
			return;
		}
		if (this.DisableTagSet.Count <= 0)
		{
			CharacterAnimationComponent animComp = this.AnimComp;
			if (animComp == null || !animComp.Valid || !animComp.HasKuroRootMotion)
			{
				bool flag = false;
				FVector fvector = this.MoveComp.CharacterMovement.Kuro_GetBlockDirectWhenMove();
				this.TmpVector.FromUeVector(fvector);
				AActor aactor = this.MoveComp.CharacterMovement.Kuro_GetBlockActorWhenMove();
				int instanceIndex = this.MoveComp.CharacterMovement.Kuro_GetKuroBlockHitIndexWhenMove();
				Slide slideConfig = CharacterSlideComponent.SlideConfig;
				this.GroundNormal.Reset();
				global::Vector tmpVector = this.TmpVector3;
				FVector velocity = this.MoveComp.CharacterMovement.Velocity;
				tmpVector.FromUeVector(velocity);
				if (Singleton<GravityUtils>.Instance.GetZnInGravityForActor(this.ActorComp, this.TmpVector) > 0.10000000149011612 && (this.SkiConfig != null || Singleton<GravityUtils>.Instance.GetZnInGravityForActor(this.ActorComp, this.TmpVector3) < -0.0001) && aactor != null && !UKuroCollisionLibrary.ActorHasTag(aactor, Singleton<CharacterNameDefines>.Instance.NO_SLIDE, instanceIndex))
				{
					this.SlideForward.FromUeVector(fvector);
					this.GroundNormal.DeepCopy(this.SlideForward);
					if (this.UnifiedStateComp.MoveState != global::ECharMoveState.Slide && !this.TraceDetect())
					{
						return;
					}
					if (this.UnifiedStateComp.MoveState != global::ECharMoveState.Slide)
					{
						CharacterActorComponent actorComp = this.ActorComp;
						if (actorComp != null)
						{
							actorComp.Actor.KuroSetMovementMode(new SetMovementModeInfo
							{
								Mode = EMovementMode.MOVE_Custom,
								CustomMode = 4,
								Context = "[CharacterSlideComponent.TickSlideMode]"
							});
						}
						this.UnifiedStateComp.SetMoveState(global::ECharMoveState.Slide);
						flag = true;
						this.LastZ = 0f;
						this.LeaveSlideCountDown = 0.25f;
					}
				}
				else if (this.UnifiedStateComp.MoveState != global::ECharMoveState.Slide)
				{
					return;
				}
				double znInGravityForActor = Singleton<GravityUtils>.Instance.GetZnInGravityForActor(this.ActorComp, this.SlideForward);
				if (Math.Abs((double)this.LastZ - znInGravityForActor) > 0.0001)
				{
					this.LastZ = (float)znInGravityForActor;
					this.CurrentAirFriction = CharacterSlideComponent.GetSlideFallingFriction(this.LastZ);
				}
				this.SetInputRotator(flag);
				this.FindStandMode(flag, slideConfig);
				return;
			}
		}
		if (this.UnifiedStateComp.MoveState == global::ECharMoveState.Slide)
		{
			CharacterActorComponent actorComp2 = this.ActorComp;
			if (actorComp2 == null)
			{
				return;
			}
			actorComp2.Actor.KuroSetMovementMode(new SetMovementModeInfo
			{
				Mode = EMovementMode.MOVE_Falling,
				Context = "[CharacterSlideComponent.TickSlideMode]"
			});
		}
	}

	// Token: 0x06019CB6 RID: 105654 RVA: 0x00786D8C File Offset: 0x00784F8C
	public void TickSkiMode(float delta)
	{
		if (this.SkiAccelCountDown > 0f)
		{
			float customTimeDilation = this.ActorComp.Owner.CustomTimeDilation;
			this.SkiAccelCountDown -= delta * 0.001f * customTimeDilation;
			if (this.SkiAccelCountDown < 0f)
			{
				this.SkiAccelCountDown = 0f;
				this.SkiAccelConfig = null;
				this.TagComp.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.滑雪加速"]));
			}
		}
		if (this.ExitSlideThisFrame)
		{
			this.ExitSlideThisFrame = false;
			return;
		}
		CharacterWalkOnWaterComponent component = base.Entity.GetComponent<CharacterWalkOnWaterComponent>();
		if (component != null && component.IsActive && component.WalkOnWaterStage != EWalkOnWaterStage.WalkOnWaterSurface)
		{
			return;
		}
		if (this.UnifiedStateComp.PositionState != global::ECharPositionState.Ground && this.UnifiedStateComp.PositionState != global::ECharPositionState.Floating && this.UnifiedStateComp.PositionState != global::ECharPositionState.Ski)
		{
			return;
		}
		if (this.DisableTagSet.Count <= 0)
		{
			CharacterAnimationComponent animComp = this.AnimComp;
			if (animComp == null || !animComp.Valid || !animComp.HasKuroRootMotion)
			{
				this.GroundNormal.Reset();
				global::Vector tmpVector = this.TmpVector3;
				FVector velocity = this.MoveComp.CharacterMovement.Velocity;
				tmpVector.FromUeVector(velocity);
				bool flag = false;
				UKuroHitResult ukuroHitResult = this.DetectFloor();
				if (ukuroHitResult == null)
				{
					this.CacheBlockComp = null;
					this.CacheBlockActor = null;
					this.CacheBlockIndex = 0;
					this.CacheBlockDirect.Reset();
				}
				else
				{
					this.CacheBlockComp = ukuroHitResult.Components.Get(0);
					UPrimitiveComponent cacheBlockComp = this.CacheBlockComp;
					this.CacheBlockActor = ((cacheBlockComp != null) ? cacheBlockComp.GetOwner() : null);
					this.CacheBlockIndex = ukuroHitResult.ItemArray.Get(0);
					Singleton<TraceElementCommon>.Instance.GetImpactNormal(ukuroHitResult, 0, this.CacheBlockDirect);
				}
				if (this.CheckSkiCondition())
				{
					this.SlideForward.DeepCopy(this.CacheBlockDirect);
					this.GroundNormal.DeepCopy(this.SlideForward);
					if (this.SkiNeedSetBase)
					{
						UKuroStaticLibrary.SetBaseAndSaveBaseLocation(this.ActorComp.Actor.CharacterMovement, this.CacheBlockComp);
					}
					if (this.UnifiedStateComp.MoveState != global::ECharMoveState.NormalSki)
					{
						if (!this.TraceDetect2())
						{
							return;
						}
						UTraceSphereElement actorTrace = ModelBase<TraceElementModel>.Instance.GetActorTrace();
						CharacterAnimationComponent component2 = base.Entity.GetComponent<CharacterAnimationComponent>();
						Singleton<TraceElementCommon>.Instance.GetHitLocation(actorTrace.HitResult, 0, this.TmpVector);
						if (component2 != null)
						{
							component2.SetLocationAndRotatorWithModelBuffer(this.TmpVector.ToUeVector(false), this.ActorComp.ActorRotation, 300f, "CharacterSlideComp.EnterSki", ESetRotationPriority.Anim, true);
						}
						CharacterMoveComponent moveComp = this.MoveComp;
						if (moveComp != null)
						{
							CharacterActorComponent actorComp = moveComp.ActorComp;
							if (actorComp != null)
							{
								actorComp.Actor.KuroSetMovementMode(new SetMovementModeInfo
								{
									Mode = EMovementMode.MOVE_Custom,
									CustomMode = 8,
									Context = "[CharacterSlideComponent.TickSkiMode]"
								});
							}
						}
						this.UnifiedStateComp.SetMoveState(global::ECharMoveState.NormalSki);
						flag = true;
						this.LastZ = 0f;
					}
				}
				else if (this.UnifiedStateComp.MoveState != global::ECharMoveState.NormalSki)
				{
					return;
				}
				Slide slideConfig = CharacterSlideComponent.SlideConfig;
				this.SetInputRotator(flag);
				this.FindStandMode(flag, slideConfig);
				return;
			}
		}
		if (this.UnifiedStateComp.MoveState == global::ECharMoveState.NormalSki)
		{
			CharacterActorComponent actorComp2 = this.ActorComp;
			if (actorComp2 != null)
			{
				actorComp2.Actor.KuroSetMovementMode(new SetMovementModeInfo
				{
					Mode = EMovementMode.MOVE_Walking,
					Context = "[CharacterSlideComponent.TickSkiMode]"
				});
			}
			this.UnifiedStateComp.SetMoveState(global::ECharMoveState.Run);
		}
	}

	// Token: 0x06019CB7 RID: 105655 RVA: 0x007870D4 File Offset: 0x007852D4
	public void EnterSkiMode(IOpenSkiConfig config, bool needSetBase = false)
	{
		if (this.SkiConfig != null)
		{
			return;
		}
		if (!this.InitSkiParams(config))
		{
			return;
		}
		this.ApplySkiSpecialSettings();
		this.TagComp.AddTag(new int?(GameplayTagDefine.EGameplayTagId["关卡.关卡运动.关卡运动类型.滑雪"]));
		this.TagComp.AddTag(new int?(GameplayTagDefine.EGameplayTagId["角色.Common.BUFF通用标识.不能切人"]));
		this.IsInSkiMode = true;
		this.NeedInitSpeed = true;
		this.SkiNeedSetBase = needSetBase;
		this.LeaveSlideCountDown = 3f;
		this.VelocityBeforeJump.Reset();
		this.EnterSkiModeRequest();
	}

	// Token: 0x06019CB8 RID: 105656 RVA: 0x0078716C File Offset: 0x0078536C
	public void ExitSkiMode(bool sync = true)
	{
		if (this.SkiConfig == null)
		{
			return;
		}
		this.RemoveSkiSpecialSettings();
		this.TagComp.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["关卡.关卡运动.关卡运动类型.滑雪"]));
		this.TagComp.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["角色.Common.BUFF通用标识.不能切人"]));
		this.SkiConfig = null;
		this.NeedInitSpeed = false;
		this.SkiNeedSetBase = false;
		this.IsInSkiMode = false;
		this.VelocityBeforeJump.Reset();
		if (this.UnifiedStateComp.PositionState == global::ECharPositionState.Ski)
		{
			if (this.DetectFloor() != null)
			{
				CharacterActorComponent actorComp = this.ActorComp;
				if (actorComp != null)
				{
					actorComp.Actor.KuroSetMovementMode(new SetMovementModeInfo
					{
						Mode = EMovementMode.MOVE_Walking,
						Context = "[CharacterSlideComponent.ExitSkiMode] Walking"
					});
				}
				this.UnifiedStateComp.SetMoveState(global::ECharMoveState.Run);
			}
			else
			{
				CharacterActorComponent actorComp2 = this.ActorComp;
				if (actorComp2 != null)
				{
					actorComp2.Actor.KuroSetMovementMode(new SetMovementModeInfo
					{
						Mode = EMovementMode.MOVE_Falling,
						Context = "[CharacterSlideComponent.ExitSkiMode] Falling"
					});
				}
			}
		}
		if (sync)
		{
			this.ExitSkiModeRequest();
		}
	}

	// Token: 0x06019CB9 RID: 105657 RVA: 0x00787278 File Offset: 0x00785478
	private bool CheckSkiCondition()
	{
		return this.CacheBlockComp != null && (this.CacheBlockActor == null || !UKuroCollisionLibrary.ActorHasTag(this.CacheBlockActor, Singleton<CharacterNameDefines>.Instance.NO_SLIDE, this.CacheBlockIndex)) && !this.CacheBlockDirect.ContainsNaN() && Singleton<GravityUtils>.Instance.GetZnInGravityForActor(this.ActorComp, this.CacheBlockDirect) != 0.0 && (float)Math.Acos(global::Vector.DotProduct(this.CacheBlockDirect, this.ActorComp.MoveComp.GravityUp)) * 57.29578f < 75f;
	}

	// Token: 0x06019CBA RID: 105658 RVA: 0x00787318 File Offset: 0x00785518
	private bool CheckSkiException(float delta)
	{
		if ((float)Math.Acos(global::Vector.DotProduct(this.GroundNormal, this.ActorComp.MoveComp.GravityUp)) * 57.29578f >= 75f)
		{
			return false;
		}
		global::Vector tmpVector = this.TmpVector;
		FVectorDouble fvectorDouble = this.ActorComp.Actor.D_K2_GetActorLocation();
		tmpVector.FromUeVector(fvectorDouble);
		if (global::Vector.Dist(this.ActorComp.LastActorLocation, this.TmpVector) < (double)(delta * 20f))
		{
			return false;
		}
		this.LeaveSlideCountDown = 3f;
		return true;
	}

	// Token: 0x06019CBB RID: 105659 RVA: 0x007873A4 File Offset: 0x007855A4
	private void OnExitSkiWhenJump(int tagId, bool tagExist)
	{
		if (!tagExist)
		{
			if (this.JumpAddMoveHandler != null)
			{
				this.MoveComp.StopAddMove(this.JumpAddMoveHandler.Value);
			}
			this.MoveComp.ResetTurnRate();
			this.TagComp.RemoveTagAddOrRemoveListener(GameplayTagDefine.EGameplayTagId["关卡.关卡运动.关卡运动类型.滑雪"], new BaseTagComponent.TTagSwitchedCallback(this.OnExitSkiWhenJump));
		}
	}

	// Token: 0x06019CBC RID: 105660 RVA: 0x0078740C File Offset: 0x0078560C
	private void EnterSkiModeRequest()
	{
		LevelPlaySwitchSportModeRequest levelPlaySwitchSportModeRequest = LevelPlaySwitchSportModeRequest.Create();
		levelPlaySwitchSportModeRequest.OldSportMode = ELevelPlaySportMode.None;
		levelPlaySwitchSportModeRequest.NewSportMode = ELevelPlaySportMode.Ski;
		Singleton<Net>.Instance.Call<LevelPlaySwitchSportModeResponse>(ERequestMessageId.LevelPlaySwitchSportModeRequest, levelPlaySwitchSportModeRequest, delegate(LevelPlaySwitchSportModeResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				Singleton<global::Log>.Instance.Warn(ELogModule.Movement, ELogAuthor.YJX, "请求切换滑雪模式失败", default(ReadOnlySpan<ValueTuple<string, object>>));
				this.ExitSkiMode(false);
			}
		}, 0);
	}

	// Token: 0x06019CBD RID: 105661 RVA: 0x0078744C File Offset: 0x0078564C
	private void ExitSkiModeRequest()
	{
		LevelPlaySwitchSportModeRequest levelPlaySwitchSportModeRequest = LevelPlaySwitchSportModeRequest.Create();
		levelPlaySwitchSportModeRequest.OldSportMode = ELevelPlaySportMode.Ski;
		levelPlaySwitchSportModeRequest.NewSportMode = ELevelPlaySportMode.None;
		Singleton<Net>.Instance.Call<LevelPlaySwitchSportModeResponse>(ERequestMessageId.LevelPlaySwitchSportModeRequest, levelPlaySwitchSportModeRequest, null, 0);
	}

	// Token: 0x06019CBE RID: 105662 RVA: 0x00787480 File Offset: 0x00785680
	private void ApplySkiSpecialSettings()
	{
		if (this.SkiConfig == null)
		{
			return;
		}
		this.ApplySpecialJumpSettings();
		foreach (int value in this.SkiConfig.TagList)
		{
			BaseTagComponent tagComp = this.TagComp;
			if (tagComp != null)
			{
				tagComp.AddTag(new int?(value));
			}
		}
	}

	// Token: 0x06019CBF RID: 105663 RVA: 0x007874F8 File Offset: 0x007856F8
	private void RemoveSkiSpecialSettings()
	{
		this.RemoveSpecialJumpSettings();
		foreach (int value in this.SkiConfig.TagList)
		{
			BaseTagComponent tagComp = this.TagComp;
			if (tagComp != null)
			{
				tagComp.RemoveTag(new int?(value));
			}
		}
	}

	// Token: 0x06019CC0 RID: 105664 RVA: 0x00787568 File Offset: 0x00785768
	private void ApplySpecialJumpSettings()
	{
		this.TagComp.AddTag(new int?(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.超级跳跃"]));
		this.MoveComp.SetFallingHorizontalMaxSpeed(this.SkiConfig.JumpMaxHorizontalSpeed);
		CharacterAnimationComponent animComp = this.AnimComp;
		UAnimInstance uanimInstance = (animComp != null) ? animComp.MainAnimInstance : null;
		if (UKuroStaticLibrary.IsObjectClassByName(uanimInstance, Singleton<CharacterNameDefines>.Instance.ABP_BASEROLE))
		{
			((ABP_BaseRole_C)uanimInstance).设置跳跃速率(this.SkiConfig.JumpTimeScale);
		}
		this.AttributeComp.SetBaseValue(EAttributeType.Jump, 10000f * this.SkiConfig.JumpHeightRate);
	}

	// Token: 0x06019CC1 RID: 105665 RVA: 0x00787608 File Offset: 0x00785808
	private void RemoveSpecialJumpSettings()
	{
		this.TagComp.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.超级跳跃"]));
		this.MoveComp.ClearFallingHorizontalMaxSpeed();
		CharacterAnimationComponent animComp = this.AnimComp;
		UAnimInstance uanimInstance = (animComp != null) ? animComp.MainAnimInstance : null;
		if (UKuroStaticLibrary.IsObjectClassByName(uanimInstance, Singleton<CharacterNameDefines>.Instance.ABP_BASEROLE))
		{
			((ABP_BaseRole_C)uanimInstance).设置跳跃速率(1f);
		}
		this.AttributeComp.SetBaseValue(EAttributeType.Jump, 10000f);
	}

	// Token: 0x06019CC2 RID: 105666 RVA: 0x0078768C File Offset: 0x0078588C
	private unsafe bool InitSkiParams(IOpenSkiConfig config)
	{
		string skiConfig = config.SkiConfig;
		BP_SkiConfig_C bp_SkiConfig_C = Singleton<ResourceSystem>.Instance.Load<BP_SkiConfig_C>(skiConfig, "js_undefined");
		if (bp_SkiConfig_C == null || !bp_SkiConfig_C.IsValid())
		{
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.Movement;
			ELogAuthor author = ELogAuthor.YJX;
			string message = "获取滑雪参数DA失败";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("DaPath", skiConfig);
			ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
			string item = "PbDataId";
			CharacterActorComponent actorComp = this.ActorComp;
			ptr = new ValueTuple<string, object>(item, (actorComp != null) ? new int?(actorComp.CreatureData.GetPbDataId()) : null);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return false;
		}
		this.SkiConfig = new SkiParams(bp_SkiConfig_C);
		return true;
	}

	// Token: 0x06019CC3 RID: 105667 RVA: 0x00787746 File Offset: 0x00785946
	public static void CreateStaticDefaultValue()
	{
		CharacterSlideComponent.SlideConfigInternal = null;
		CharacterSlideComponent.SpeedReduceCurve = null;
		CharacterSlideComponent._jumpAddMoveCurveInternal = null;
		CharacterSlideComponent._SlideFallingCoefficientArray = new float[4];
	}

	// Token: 0x06019CC4 RID: 105668 RVA: 0x0078776A File Offset: 0x0078596A
	public static void ResetStaticDefaultValue()
	{
		CharacterSlideComponent.SlideConfigInternal = null;
		CharacterSlideComponent.SpeedReduceCurve = null;
		CharacterSlideComponent._jumpAddMoveCurveInternal = null;
		CharacterSlideComponent._SlideFallingCoefficientArray = null;
	}

	// Token: 0x06019CC5 RID: 105669 RVA: 0x0078778C File Offset: 0x0078598C
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		CharacterSlideComponent characterSlideComponent = (CharacterSlideComponent)componentTemplate;
		if (base.CanResetComponentProperty("ActorComp"))
		{
			if (characterSlideComponent.ActorComp == null)
			{
				this.ActorComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterActorComponent>(this.ActorComp), "ActorComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("MoveComp"))
		{
			if (characterSlideComponent.MoveComp == null)
			{
				this.MoveComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterMoveComponent>(this.MoveComp), "MoveComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("AnimComp"))
		{
			if (characterSlideComponent.AnimComp == null)
			{
				this.AnimComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterAnimationComponent>(this.AnimComp), "AnimComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("AttributeComp"))
		{
			if (characterSlideComponent.AttributeComp == null)
			{
				this.AttributeComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseAttributeComponent>(this.AttributeComp), "AttributeComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("UnifiedStateComp"))
		{
			if (characterSlideComponent.UnifiedStateComp == null)
			{
				this.UnifiedStateComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterUnifiedStateComponent>(this.UnifiedStateComp), "UnifiedStateComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("SkillComp"))
		{
			if (characterSlideComponent.SkillComp == null)
			{
				this.SkillComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterSkillComponent>(this.SkillComp), "SkillComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("TagComp"))
		{
			if (characterSlideComponent.TagComp == null)
			{
				this.TagComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseTagComponent>(this.TagComp), "TagComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("InputComp"))
		{
			if (characterSlideComponent.InputComp == null)
			{
				this.InputComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterInputComponent>(this.InputComp), "InputComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("TmpVector") && characterSlideComponent.TmpVector != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.TmpVector), "TmpVector"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("TmpVector2") && characterSlideComponent.TmpVector2 != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.TmpVector2), "TmpVector2"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("TmpVector3") && characterSlideComponent.TmpVector3 != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.TmpVector3), "TmpVector3"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("TmpVector4") && characterSlideComponent.TmpVector4 != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.TmpVector4), "TmpVector4"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("TmpVector5") && characterSlideComponent.TmpVector5 != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.TmpVector5), "TmpVector5"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("TmpRotator") && characterSlideComponent.TmpRotator != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<global::Rotator>(this.TmpRotator), "TmpRotator"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("TmpQuat") && characterSlideComponent.TmpQuat != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Quat>(this.TmpQuat), "TmpQuat"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("TmpQuat2") && characterSlideComponent.TmpQuat2 != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Quat>(this.TmpQuat2), "TmpQuat2"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("SlideUp") && characterSlideComponent.SlideUp != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.SlideUp), "SlideUp"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("LeaveSlideCountDown"))
		{
			this.LeaveSlideCountDown = characterSlideComponent.LeaveSlideCountDown;
		}
		if (base.CanResetComponentProperty("SlideForward") && characterSlideComponent.SlideForward != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.SlideForward), "SlideForward"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("GroundNormal") && characterSlideComponent.GroundNormal != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.GroundNormal), "GroundNormal"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("TagListeners") && characterSlideComponent.TagListeners != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<List<ITagTask>>(this.TagListeners), "TagListeners"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("DisableTagSet") && characterSlideComponent.DisableTagSet != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<int>(this.DisableTagSet), "DisableTagSet"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("LastZ"))
		{
			this.LastZ = characterSlideComponent.LastZ;
		}
		if (base.CanResetComponentProperty("CurrentAirFriction"))
		{
			this.CurrentAirFriction = characterSlideComponent.CurrentAirFriction;
		}
		if (base.CanResetComponentProperty("SlideSwitchThisFrame"))
		{
			this.SlideSwitchThisFrame = characterSlideComponent.SlideSwitchThisFrame;
		}
		if (base.CanResetComponentProperty("StandMode"))
		{
			this.StandMode = characterSlideComponent.StandMode;
		}
		if (base.CanResetComponentProperty("LastAngleOffset"))
		{
			this.LastAngleOffset = characterSlideComponent.LastAngleOffset;
		}
		if (base.CanResetComponentProperty("JumpAddMoveHandler"))
		{
			this.JumpAddMoveHandler = characterSlideComponent.JumpAddMoveHandler;
		}
		if (base.CanResetComponentProperty("SkiAccelConfig"))
		{
			if (characterSlideComponent.SkiAccelConfig == null)
			{
				this.SkiAccelConfig = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<IAccelerateSkiConfig>(this.SkiAccelConfig), "SkiAccelConfig"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("SkiAccelCountDown"))
		{
			this.SkiAccelCountDown = characterSlideComponent.SkiAccelCountDown;
		}
		if (base.CanResetComponentProperty("SkiConfig"))
		{
			if (characterSlideComponent.SkiConfig == null)
			{
				this.SkiConfig = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<SkiParams>(this.SkiConfig), "SkiConfig"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("NeedInitSpeed"))
		{
			this.NeedInitSpeed = characterSlideComponent.NeedInitSpeed;
		}
		if (base.CanResetComponentProperty("IsInSkiMode"))
		{
			this.IsInSkiMode = characterSlideComponent.IsInSkiMode;
		}
		if (base.CanResetComponentProperty("CacheBlockActor"))
		{
			if (characterSlideComponent.CacheBlockActor == null)
			{
				this.CacheBlockActor = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<AActor>(this.CacheBlockActor), "CacheBlockActor"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("CacheBlockComp"))
		{
			if (characterSlideComponent.CacheBlockComp == null)
			{
				this.CacheBlockComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<UPrimitiveComponent>(this.CacheBlockComp), "CacheBlockComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("CacheBlockIndex"))
		{
			this.CacheBlockIndex = characterSlideComponent.CacheBlockIndex;
		}
		if (base.CanResetComponentProperty("CacheBlockDirect") && characterSlideComponent.CacheBlockDirect != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.CacheBlockDirect), "CacheBlockDirect"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("VelocityBeforeJump") && characterSlideComponent.VelocityBeforeJump != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.VelocityBeforeJump), "VelocityBeforeJump"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("SkiDirection") && characterSlideComponent.SkiDirection != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.SkiDirection), "SkiDirection"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("SkiNeedSetBase"))
		{
			this.SkiNeedSetBase = characterSlideComponent.SkiNeedSetBase;
		}
		if (base.CanResetComponentProperty("ExitSlideThisFrame"))
		{
			this.ExitSlideThisFrame = characterSlideComponent.ExitSlideThisFrame;
		}
		return true;
	}

	// Token: 0x0400CDCC RID: 52684
	private const float LEAVE_SLIDE_TIME = 0.25f;

	// Token: 0x0400CDCD RID: 52685
	private const float LEAVE_SLIDE_MIN_HEIGHT = 5f;

	// Token: 0x0400CDCE RID: 52686
	private const string PROFILE_KEY = "slide";

	// Token: 0x0400CDCF RID: 52687
	private const float CHANGE_FORWARD_ANGLE_THRESHOLD = 135f;

	// Token: 0x0400CDD0 RID: 52688
	private const float COMBINE_NORMAL_Z_THRESHOLD = 0.707f;

	// Token: 0x0400CDD1 RID: 52689
	private const float SLIDE_Z_THRESHOLD = 0.1f;

	// Token: 0x0400CDD2 RID: 52690
	private const float LEAVE_SKI_TIME = 3f;

	// Token: 0x0400CDD3 RID: 52691
	private const float SKI_GROUND_MAX_ANGLE = 75f;

	// Token: 0x0400CDD4 RID: 52692
	private const float SKI_BRAKE_ANGLE_THRESHOLD = 135f;

	// Token: 0x0400CDD5 RID: 52693
	private const float SKI_MAX_INPUT_ANGLE = 135f;

	// Token: 0x0400CDD6 RID: 52694
	private const float DEFAULT_SKI_MAX_TURN_ANGLE = 50f;

	// Token: 0x0400CDD7 RID: 52695
	private const float DEFAULT_SKI_MAX_SPEED = 3500f;

	// Token: 0x0400CDD8 RID: 52696
	private const float DEFAULT_SKI_MIN_SPEED = 20f;

	// Token: 0x0400CDD9 RID: 52697
	private const float ENTER_SKI_BUFFER_TIME = 300f;

	// Token: 0x0400CDDA RID: 52698
	protected static Slide? SlideConfigInternal;

	// Token: 0x0400CDDB RID: 52699
	[Nullable(2)]
	private static float[] _SlideFallingCoefficientArray;

	// Token: 0x0400CDDC RID: 52700
	[Nullable(2)]
	protected static UCurveFloat SpeedReduceCurve;

	// Token: 0x0400CDDD RID: 52701
	[Nullable(2)]
	private static UCurveFloat _jumpAddMoveCurveInternal;

	// Token: 0x0400CDDE RID: 52702
	[Nullable(2)]
	private CharacterActorComponent ActorComp;

	// Token: 0x0400CDDF RID: 52703
	[Nullable(2)]
	private CharacterMoveComponent MoveComp;

	// Token: 0x0400CDE0 RID: 52704
	[Nullable(2)]
	private CharacterAnimationComponent AnimComp;

	// Token: 0x0400CDE1 RID: 52705
	[Nullable(2)]
	private BaseAttributeComponent AttributeComp;

	// Token: 0x0400CDE2 RID: 52706
	[Nullable(2)]
	private CharacterUnifiedStateComponent UnifiedStateComp;

	// Token: 0x0400CDE3 RID: 52707
	[Nullable(2)]
	private CharacterSkillComponent SkillComp;

	// Token: 0x0400CDE4 RID: 52708
	[Nullable(2)]
	private BaseTagComponent TagComp;

	// Token: 0x0400CDE5 RID: 52709
	[Nullable(2)]
	private CharacterInputComponent InputComp;

	// Token: 0x0400CDE6 RID: 52710
	private readonly global::Vector TmpVector = global::Vector.Create();

	// Token: 0x0400CDE7 RID: 52711
	private readonly global::Vector TmpVector2 = global::Vector.Create();

	// Token: 0x0400CDE8 RID: 52712
	private readonly global::Vector TmpVector3 = global::Vector.Create();

	// Token: 0x0400CDE9 RID: 52713
	private readonly global::Vector TmpVector4 = global::Vector.Create();

	// Token: 0x0400CDEA RID: 52714
	private readonly global::Vector TmpVector5 = global::Vector.Create();

	// Token: 0x0400CDEB RID: 52715
	private readonly global::Rotator TmpRotator = global::Rotator.Create();

	// Token: 0x0400CDEC RID: 52716
	private readonly Quat TmpQuat = Quat.Create(0f, 0f, 0f, 1f);

	// Token: 0x0400CDED RID: 52717
	private readonly Quat TmpQuat2 = Quat.Create(0f, 0f, 0f, 1f);

	// Token: 0x0400CDEE RID: 52718
	private readonly global::Vector SlideUp = global::Vector.Create();

	// Token: 0x0400CDEF RID: 52719
	private float LeaveSlideCountDown;

	// Token: 0x0400CDF0 RID: 52720
	public readonly global::Vector SlideForward = global::Vector.Create();

	// Token: 0x0400CDF1 RID: 52721
	public readonly global::Vector GroundNormal = global::Vector.Create();

	// Token: 0x0400CDF2 RID: 52722
	private readonly List<ITagTask> TagListeners = new List<ITagTask>();

	// Token: 0x0400CDF3 RID: 52723
	private readonly HashSet<int> DisableTagSet = new HashSet<int>();

	// Token: 0x0400CDF4 RID: 52724
	private float LastZ;

	// Token: 0x0400CDF5 RID: 52725
	private float CurrentAirFriction;

	// Token: 0x0400CDF6 RID: 52726
	public bool SlideSwitchThisFrame;

	// Token: 0x0400CDF7 RID: 52727
	public bool StandMode;

	// Token: 0x0400CDF8 RID: 52728
	public float LastAngleOffset;

	// Token: 0x0400CDF9 RID: 52729
	private int? JumpAddMoveHandler;

	// Token: 0x0400CDFA RID: 52730
	[Nullable(2)]
	private IAccelerateSkiConfig SkiAccelConfig;

	// Token: 0x0400CDFB RID: 52731
	private float SkiAccelCountDown;

	// Token: 0x0400CDFC RID: 52732
	[Nullable(2)]
	private SkiParams SkiConfig;

	// Token: 0x0400CDFD RID: 52733
	private bool NeedInitSpeed;

	// Token: 0x0400CDFE RID: 52734
	private bool IsInSkiMode;

	// Token: 0x0400CDFF RID: 52735
	[Nullable(2)]
	private AActor CacheBlockActor;

	// Token: 0x0400CE00 RID: 52736
	[Nullable(2)]
	private UPrimitiveComponent CacheBlockComp;

	// Token: 0x0400CE01 RID: 52737
	private int CacheBlockIndex;

	// Token: 0x0400CE02 RID: 52738
	private readonly global::Vector CacheBlockDirect = global::Vector.Create();

	// Token: 0x0400CE03 RID: 52739
	private readonly global::Vector VelocityBeforeJump = global::Vector.Create();

	// Token: 0x0400CE04 RID: 52740
	private readonly global::Vector SkiDirection = global::Vector.Create();

	// Token: 0x0400CE05 RID: 52741
	[StaticVariableRuleIgnore]
	private static readonly int[] DisableTags = new int[]
	{
		GameplayTagDefine.EGameplayTagId["行为状态.动作状态.受击"],
		GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.濒死"],
		GameplayTagDefine.EGameplayTagId["Damage.Frozen"]
	};

	// Token: 0x0400CE06 RID: 52742
	private bool SkiNeedSetBase;

	// Token: 0x0400CE07 RID: 52743
	private bool ExitSlideThisFrame;
}
