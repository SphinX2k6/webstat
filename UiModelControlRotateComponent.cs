using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.UiModel.Struct;
using CSharpScript.Core.Common;
using CSharpScript.Core.Utils.StaticVariableReset;
using UnrealEngine;

// Token: 0x02002C81 RID: 11393
[NullableContext(2)]
[Nullable(0)]
[StaticVariablePriority(100)]
public class UiModelControlRotateComponent : UiModelComponentBase
{
	// Token: 0x06016DA0 RID: 93600 RVA: 0x0065706C File Offset: 0x0065526C
	protected override void OnInit()
	{
		this.ActorComponent = base.Owner.CheckGetComponent<UiModelActorComponent>();
		this.InputDataComponent = base.Owner.CheckGetComponent<UiModelInputDataComponent>();
		this.Rotator = Rotator.Create();
		this.BaseRotator = Rotator.Create();
		this.CaptureBaseRotator();
		if (this.BaseRotator != null)
		{
			Rotator rotator = this.Rotator;
			if (rotator == null)
			{
				return;
			}
			rotator.DeepCopy(this.BaseRotator);
		}
	}

	// Token: 0x06016DA1 RID: 93601 RVA: 0x006570D8 File Offset: 0x006552D8
	[NullableContext(1)]
	public void InitDataByConfig(SUiModelRotateSetting config)
	{
		this.InitData(config.旋转中轴, config.旋转偏移, config.倍化手柄输入倍率, config.移动端旋转输入倍率, config.模型Yaw灵敏度系数, config.模型Pitch灵敏度系数, config.Yaw限制Min, config.Yaw限制Max, config.Pitch限制Min, config.Pitch限制Max);
	}

	// Token: 0x06016DA2 RID: 93602 RVA: 0x00657128 File Offset: 0x00655328
	[NullableContext(1)]
	public void InitData(string originCase, float rotateOffset, float gamepadInputRate, float mobileRotateInputRate, float sensitivityYaw, float sensitivityPitch, float yawLimitMin, float yawLimitMax, float pitchLimitMin, float pitchLimitMax)
	{
		this.OriginCase = originCase;
		this.RotateOffset = rotateOffset;
		this.GamepadInputRate = gamepadInputRate;
		this.MobileRotateInputRate = mobileRotateInputRate;
		this.SensitivityYaw = sensitivityYaw;
		this.SensitivityPitch = sensitivityPitch;
		this.YawLimitMin = yawLimitMin;
		this.YawLimitMax = yawLimitMax;
		this.PitchLimitMin = pitchLimitMin;
		this.PitchLimitMax = pitchLimitMax;
	}

	// Token: 0x06016DA3 RID: 93603 RVA: 0x00657182 File Offset: 0x00655382
	public void Activate()
	{
		this.AutoSetOriginActorByCase();
		this.CaptureBaseRotator();
		if (this.BaseRotator != null)
		{
			Rotator rotator = this.Rotator;
			if (rotator != null)
			{
				rotator.DeepCopy(this.BaseRotator);
			}
		}
		this.NeedTick = true;
		this.ApplyRotation();
	}

	// Token: 0x06016DA4 RID: 93604 RVA: 0x006571BC File Offset: 0x006553BC
	public void Deactivate()
	{
		this.NeedTick = false;
	}

	// Token: 0x06016DA5 RID: 93605 RVA: 0x006571C5 File Offset: 0x006553C5
	protected override void OnTick(float deltaTime)
	{
		this.HandleAxisInput(deltaTime);
		this.UpdateYaw();
		this.UpdatePitch();
		this.ApplyRotation();
	}

	// Token: 0x06016DA6 RID: 93606 RVA: 0x006571E0 File Offset: 0x006553E0
	public void SetIsRotatePlus(bool isRotatePlus)
	{
		this.IsRotatePlus = isRotatePlus;
	}

	// Token: 0x06016DA7 RID: 93607 RVA: 0x006571E9 File Offset: 0x006553E9
	private AActor GetOriginActor()
	{
		if (!string.IsNullOrEmpty(this.OriginCase))
		{
			AActor result;
			if ((result = this.OriginActor) == null)
			{
				UiModelActorComponent actorComponent = this.ActorComponent;
				if (actorComponent == null)
				{
					return null;
				}
				result = actorComponent.Actor;
			}
			return result;
		}
		UiModelActorComponent actorComponent2 = this.ActorComponent;
		if (actorComponent2 == null)
		{
			return null;
		}
		return actorComponent2.Actor;
	}

	// Token: 0x06016DA8 RID: 93608 RVA: 0x00657228 File Offset: 0x00655428
	private void AutoSetOriginActorByCase()
	{
		if (string.IsNullOrEmpty(this.OriginCase))
		{
			this.OriginActor = null;
			return;
		}
		FName? dynamicFName = FNameUtil.GetDynamicFName(this.OriginCase);
		this.OriginActor = ((dynamicFName == null) ? null : UKuroCollectActorComponent.GetActorWithTag(dynamicFName.Value, ECollectActorType.UI));
	}

	// Token: 0x06016DA9 RID: 93609 RVA: 0x00657278 File Offset: 0x00655478
	private void CaptureBaseRotator()
	{
		AActor originActor = this.GetOriginActor();
		if (originActor == null || this.BaseRotator == null)
		{
			return;
		}
		Rotator baseRotator = this.BaseRotator;
		FRotator frotator = originActor.K2_GetActorRotation();
		baseRotator.FromUeRotator(frotator);
		this.BaseRotator.Yaw += this.RotateOffset;
	}

	// Token: 0x06016DAA RID: 93610 RVA: 0x006572C4 File Offset: 0x006554C4
	public void SyncRotatorFromActor()
	{
		UiModelActorComponent actorComponent = this.ActorComponent;
		AActor aactor = (actorComponent != null) ? actorComponent.Actor : null;
		if (aactor != null && this.Rotator != null)
		{
			Rotator rotator = this.Rotator;
			FRotator frotator = aactor.K2_GetActorRotation();
			rotator.FromUeRotator(frotator);
		}
	}

	// Token: 0x06016DAB RID: 93611 RVA: 0x00657303 File Offset: 0x00655503
	public void ResumeFromCurrentActorRotation()
	{
		this.SyncRotatorFromActor();
		this.NeedTick = true;
	}

	// Token: 0x06016DAC RID: 93612 RVA: 0x00657314 File Offset: 0x00655514
	public void HandleAxisInput(float deltaTime)
	{
		UiModelInputDataComponent inputDataComponent = this.InputDataComponent;
		float num = (inputDataComponent != null) ? inputDataComponent.GetAxisInput(ERotateAxis.Yaw) : 0f;
		UiModelInputDataComponent inputDataComponent2 = this.InputDataComponent;
		float num2 = (inputDataComponent2 != null) ? inputDataComponent2.GetAxisInput(ERotateAxis.Pitch) : 0f;
		if (Singleton<MathUtils>.Instance.IsNearlyZero((double)num, null) && Singleton<MathUtils>.Instance.IsNearlyZero((double)num2, null))
		{
			return;
		}
		int num3 = this.IsRotatePlus ? 1 : -1;
		num *= (float)num3;
		num2 *= (float)num3;
		if (Singleton<Info>.Instance.IsInGamepad())
		{
			num *= this.GamepadInputRate;
			num2 *= this.GamepadInputRate;
		}
		else if (Singleton<Info>.Instance.IsInTouch())
		{
			num *= this.MobileRotateInputRate;
			num2 *= this.MobileRotateInputRate;
		}
		num = num * this.SensitivityYaw * deltaTime;
		num2 = num2 * this.SensitivityPitch * deltaTime;
		if (!Singleton<MathUtils>.Instance.IsNearlyZero((double)num, null) && this.Rotator != null)
		{
			this.Rotator.Yaw += num;
		}
		if (!Singleton<MathUtils>.Instance.IsNearlyZero((double)num2, null) && this.Rotator != null)
		{
			this.Rotator.Pitch += num2;
		}
	}

	// Token: 0x06016DAD RID: 93613 RVA: 0x00657450 File Offset: 0x00655650
	private void UpdateYaw()
	{
		if (this.Rotator == null || this.BaseRotator == null)
		{
			return;
		}
		float num = Rotator.NormalizeAxis(this.Rotator.Yaw - this.BaseRotator.Yaw);
		if (Math.Abs(this.YawLimitMin) + Math.Abs(this.YawLimitMax) < 360f)
		{
			num = Singleton<MathUtils>.Instance.Clamp(num, this.YawLimitMin, this.YawLimitMax);
		}
		this.Rotator.Yaw = this.BaseRotator.Yaw + num;
	}

	// Token: 0x06016DAE RID: 93614 RVA: 0x006574DC File Offset: 0x006556DC
	private void UpdatePitch()
	{
		if (this.Rotator == null || this.BaseRotator == null)
		{
			return;
		}
		float num = Rotator.NormalizeAxis(this.Rotator.Pitch - this.BaseRotator.Pitch);
		num = Singleton<MathUtils>.Instance.Clamp(num, this.PitchLimitMin, this.PitchLimitMax);
		this.Rotator.Pitch = this.BaseRotator.Pitch + num;
	}

	// Token: 0x06016DAF RID: 93615 RVA: 0x00657548 File Offset: 0x00655748
	private void ApplyRotation()
	{
		UiModelActorComponent actorComponent = this.ActorComponent;
		AActor aactor = (actorComponent != null) ? actorComponent.Actor : null;
		if (aactor == null || this.Rotator == null)
		{
			return;
		}
		aactor.K2_SetActorRotation(this.Rotator.ToUeRotator(), false);
	}

	// Token: 0x0400B035 RID: 45109
	private UiModelActorComponent ActorComponent;

	// Token: 0x0400B036 RID: 45110
	private UiModelInputDataComponent InputDataComponent;

	// Token: 0x0400B037 RID: 45111
	private AActor OriginActor;

	// Token: 0x0400B038 RID: 45112
	private Rotator Rotator;

	// Token: 0x0400B039 RID: 45113
	private Rotator BaseRotator;

	// Token: 0x0400B03A RID: 45114
	private float GamepadInputRate;

	// Token: 0x0400B03B RID: 45115
	private float MobileRotateInputRate;

	// Token: 0x0400B03C RID: 45116
	private float SensitivityYaw;

	// Token: 0x0400B03D RID: 45117
	private float SensitivityPitch;

	// Token: 0x0400B03E RID: 45118
	private float YawLimitMin;

	// Token: 0x0400B03F RID: 45119
	private float YawLimitMax;

	// Token: 0x0400B040 RID: 45120
	private float PitchLimitMin;

	// Token: 0x0400B041 RID: 45121
	private float PitchLimitMax;

	// Token: 0x0400B042 RID: 45122
	[Nullable(1)]
	private string OriginCase = string.Empty;

	// Token: 0x0400B043 RID: 45123
	private float RotateOffset;

	// Token: 0x0400B044 RID: 45124
	private bool IsRotatePlus;
}
