using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02002C92 RID: 11410
[NullableContext(2)]
[Nullable(0)]
public class UiModelRotateComponent : UiModelComponentBase
{
	// Token: 0x06016E68 RID: 93800 RVA: 0x00659C8A File Offset: 0x00657E8A
	protected override void OnInit()
	{
		this.ActorComponent = base.Owner.CheckGetComponent<UiModelActorComponent>();
		this.Rotator = Rotator.Create();
	}

	// Token: 0x06016E69 RID: 93801 RVA: 0x00659CA8 File Offset: 0x00657EA8
	public void SetRotateParam(float aroundTime, ERotateAxis axis = ERotateAxis.Yaw, bool isPlus = true)
	{
		this.DeltaSecondRotate = ((aroundTime != 0f) ? (360f / aroundTime) : 0f);
		this.RotateAxis = new ERotateAxis?(axis);
		this.IsRotatePlus = isPlus;
	}

	// Token: 0x06016E6A RID: 93802 RVA: 0x00659CD9 File Offset: 0x00657ED9
	public void StartRotate()
	{
		this.IsRotating = true;
		this.NeedTick = true;
	}

	// Token: 0x06016E6B RID: 93803 RVA: 0x00659CE9 File Offset: 0x00657EE9
	public void StopRotate()
	{
		this.IsRotating = false;
		this.NeedTick = false;
	}

	// Token: 0x06016E6C RID: 93804 RVA: 0x00659CFC File Offset: 0x00657EFC
	protected override void OnTick(float deltaTime)
	{
		if (!this.IsRotating || this.DeltaSecondRotate <= 0f)
		{
			return;
		}
		int num = this.IsRotatePlus ? 1 : -1;
		float num2 = this.DeltaSecondRotate * deltaTime * 1000f * (float)num;
		ERotateAxis? rotateAxis = this.RotateAxis;
		ERotateAxis erotateAxis = ERotateAxis.Pitch;
		if (rotateAxis.GetValueOrDefault() == erotateAxis & rotateAxis != null)
		{
			this.Rotator.Pitch = num2;
		}
		else if (this.RotateAxis.GetValueOrDefault() == ERotateAxis.Yaw)
		{
			this.Rotator.Yaw = num2;
		}
		else if (this.RotateAxis.GetValueOrDefault() == ERotateAxis.Roll)
		{
			this.Rotator.Roll = num2;
		}
		FHitResult fhitResult = new FHitResult();
		this.ActorComponent.Actor.K2_AddActorLocalRotation(this.Rotator.ToUeRotator(), false, ref fhitResult, false);
	}

	// Token: 0x0400B0A1 RID: 45217
	private UiModelActorComponent ActorComponent;

	// Token: 0x0400B0A2 RID: 45218
	private float DeltaSecondRotate;

	// Token: 0x0400B0A3 RID: 45219
	private bool IsRotating;

	// Token: 0x0400B0A4 RID: 45220
	private Rotator Rotator;

	// Token: 0x0400B0A5 RID: 45221
	private ERotateAxis? RotateAxis;

	// Token: 0x0400B0A6 RID: 45222
	private bool IsRotatePlus;
}
