using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.AI.AIMoveSplineCount;
using CSharpScript.Game.Effect;
using UnrealEngine;

// Token: 0x02002FB4 RID: 12212
public class GameplayCueMoveSpline : GameplayCueEffect
{
	// Token: 0x06018E79 RID: 102009 RVA: 0x0070DEE4 File Offset: 0x0070C0E4
	protected override void OnTick(float delta)
	{
		base.OnTick(delta);
		if (!Singleton<EffectSystem>.Instance.IsValid(this.EffectViewHandle))
		{
			return;
		}
		AActor sureEffectActor = Singleton<EffectSystem>.Instance.GetSureEffectActor(this.EffectViewHandle);
		if (sureEffectActor != null)
		{
			MoveSplineAI_C.元素球跟随(delta, sureEffectActor, this.ActorInternal as TsBaseCharacter, this.KuroMoveSplineInternal, this.SplinePosition, 520f, 20f, this.SplineRotationSpeedAccumulation, this.IsBackward, null, ref this.SplinePosition, ref this.SplineRotationSpeedAccumulation, ref this.IsBackward);
		}
	}

	// Token: 0x06018E7A RID: 102010 RVA: 0x0070DF66 File Offset: 0x0070C166
	protected override void OnDestroy()
	{
		Singleton<ActorSystem>.Instance.Put("GameplayCueMoveSpline.OnDestroy", this.KuroMoveSplineInternal.GetOwner(), null);
		base.OnDestroy();
	}

	// Token: 0x06018E7B RID: 102011 RVA: 0x0070DF8C File Offset: 0x0070C18C
	protected unsafe override void AttachEffect(bool _ = false)
	{
		<>y__InlineArray4<FVector> <>y__InlineArray = default(<>y__InlineArray4<FVector>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<FVector>, FVector>(ref <>y__InlineArray, 0) = new FVector(-70f, 0f, 0f);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<FVector>, FVector>(ref <>y__InlineArray, 1) = new FVector(0f, 100f, 0f);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<FVector>, FVector>(ref <>y__InlineArray, 2) = new FVector(70f, 0f, 0f);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<FVector>, FVector>(ref <>y__InlineArray, 3) = new FVector(0f, -100f, 0f);
		Span<FVector> span = <PrivateImplementationDetails>.InlineArrayAsSpan<<>y__InlineArray4<FVector>, FVector>(ref <>y__InlineArray, 4);
		<>y__InlineArray4<FVector> <>y__InlineArray2 = default(<>y__InlineArray4<FVector>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<FVector>, FVector>(ref <>y__InlineArray2, 0) = new FVector(0f, 130f, 0f);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<FVector>, FVector>(ref <>y__InlineArray2, 1) = new FVector(130f, 0f, 0f);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<FVector>, FVector>(ref <>y__InlineArray2, 2) = new FVector(0f, -130f, 0f);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<FVector>, FVector>(ref <>y__InlineArray2, 3) = new FVector(-130f, 0f, 0f);
		Span<FVector> span2 = <PrivateImplementationDetails>.InlineArrayAsSpan<<>y__InlineArray4<FVector>, FVector>(ref <>y__InlineArray2, 4);
		this.KuroMoveSplineInternal = this.SpawnKuroMoveSpline();
		this.KuroMoveSplineInternal.SetClosedLoop(true, true);
		this.KuroMoveSplineInternal.ClearSplinePoints(true);
		TArray<FSplinePoint> tarray = new TArray<FSplinePoint>();
		for (int i = 0; i < span.Length; i++)
		{
			FSplinePoint value = new FSplinePoint((float)i, *span[i], *span2[i], *span2[i], Rotator.ZeroRotator, Vector.OneVector, ESplinePointType.CurveCustomTangent);
			tarray.Add(value);
		}
		this.KuroMoveSplineInternal.AddPoints(tarray, true);
	}

	// Token: 0x06018E7C RID: 102012 RVA: 0x0070E160 File Offset: 0x0070C360
	[NullableContext(1)]
	private UKuroMoveSplineComponent SpawnKuroMoveSpline()
	{
		AActor aactor = Singleton<ActorSystem>.Instance.Get(AActor.StaticClass(), this.ActorInternal.D_GetTransform(), null, true);
		TSubclassOf<UActorComponent> @class = UKuroMoveSplineComponent.StaticClass();
		bool bManualAttachment = false;
		FTransformDouble ftransformDouble = this.ActorInternal.D_GetTransform();
		return aactor.D_AddComponentByClass(@class, bManualAttachment, ftransformDouble, false, default(FName)) as UKuroMoveSplineComponent;
	}

	// Token: 0x0400C297 RID: 49815
	private const float WIDTH = 70f;

	// Token: 0x0400C298 RID: 49816
	private const float LENGTH = 100f;

	// Token: 0x0400C299 RID: 49817
	private const float TANGENT = 130f;

	// Token: 0x0400C29A RID: 49818
	private const float SPLINE_MOVE_SPEED = 520f;

	// Token: 0x0400C29B RID: 49819
	private const float SPLINE_ROTATION_SPEED = 20f;

	// Token: 0x0400C29C RID: 49820
	[Nullable(2)]
	private UKuroMoveSplineComponent KuroMoveSplineInternal;

	// Token: 0x0400C29D RID: 49821
	private float SplinePosition;

	// Token: 0x0400C29E RID: 49822
	private float SplineRotationSpeedAccumulation;

	// Token: 0x0400C29F RID: 49823
	private bool IsBackward;
}
