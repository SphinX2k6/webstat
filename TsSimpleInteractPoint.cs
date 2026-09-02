using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Core.World;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02003254 RID: 12884
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/NewWorld/SceneItem/SimpleBlueprintItem/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/NewWorld/SceneItem/SimpleBlueprintItem/TsSimpleInteractPoint.TsSimpleInteractPoint_C")]
public class TsSimpleInteractPoint : TsSimpleInteractBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17002476 RID: 9334
	// (get) Token: 0x0601ADBC RID: 110012 RVA: 0x00803BF5 File Offset: 0x00801DF5
	// (set) Token: 0x0601ADBD RID: 110013 RVA: 0x00803C05 File Offset: 0x00801E05
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool OnWall
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsSimpleInteractPoint.__PropertyOffset_OnWall) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsSimpleInteractPoint.__PropertyOffset_OnWall) = (value ? 1 : 0);
		}
	}

	// Token: 0x0601ADBE RID: 110014 RVA: 0x00803C16 File Offset: 0x00801E16
	protected override void OnBeginPlay()
	{
		this.OutRotator = Rotator.Create();
		this.TmpLocation = Vector.Create();
		base.OnBeginPlay();
	}

	// Token: 0x0601ADBF RID: 110015 RVA: 0x00803C34 File Offset: 0x00801E34
	protected override bool CheckLegal()
	{
		return true;
	}

	// Token: 0x0601ADC0 RID: 110016 RVA: 0x00803C38 File Offset: 0x00801E38
	protected override void OnDraw()
	{
		FVectorDouble fvectorDouble = base.D_K2_GetActorLocation();
		FTransformDouble ftransformDouble = base.D_GetTransform();
		FVectorDouble fvectorDouble2;
		if (this.OnWall)
		{
			FVectorDouble lineStart = fvectorDouble;
			fvectorDouble2 = TsSimpleInteractPoint.ForwardOffset.ToUeVector(false);
			UKismetSystemLibrary.D_DrawDebugArrow(this, lineStart, ftransformDouble.TransformPosition(fvectorDouble2), 20f, TsSimpleInteractPoint.RedColor, 0.05f, 4f);
			return;
		}
		FVectorDouble lineStart2 = fvectorDouble;
		fvectorDouble2 = TsSimpleInteractPoint.UpOffset.ToUeVector(false);
		UKismetSystemLibrary.D_DrawDebugArrow(this, lineStart2, ftransformDouble.TransformPosition(fvectorDouble2), 20f, TsSimpleInteractPoint.BlueColor, 0.05f, 4f);
	}

	// Token: 0x0601ADC1 RID: 110017 RVA: 0x00803CBC File Offset: 0x00801EBC
	protected override void SetText(FVector offset)
	{
		base.Text.HorizontalAlignment = EHorizTextAligment.EHTA_Center;
		base.Text.SetWorldSize(80f);
		base.Text.SetTextRenderColor(TsSimpleInteractPoint.TextColor);
		UTextRenderComponent text = base.Text;
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(6, 1);
		defaultInterpolatedStringHandler.AppendLiteral("Point ");
		defaultInterpolatedStringHandler.AppendFormatted<int>(base.TypeId);
		text.Text = defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x0601ADC2 RID: 110018 RVA: 0x00803D34 File Offset: 0x00801F34
	protected override SSimpleInteractResult OnGetBestTransform(AActor actor, FVector moveOffset, float halfHeight, float radius)
	{
		this.UpdateData();
		Vector actorLocation = this.ActorLocation;
		FVectorDouble fvectorDouble = actor.D_K2_GetActorLocation();
		actorLocation.FromUeVector(fvectorDouble);
		this.ActorLocation.Subtraction(this.SelfLocation, this.SelfToActor);
		if (this.OnWall && Singleton<MathUtils>.Instance.DotProduct(this.SelfToActor, base.GetActorForwardVector()) > (double)radius)
		{
			return this.TmpResult;
		}
		if (this.OnWall)
		{
			this.TmpVector1.X = (double)radius;
			this.TmpVector1.Y = 0.0;
			this.TmpVector1.Z = 0.0;
		}
		else
		{
			this.TmpVector1.X = 0.0;
			this.TmpVector1.Y = 0.0;
			this.TmpVector1.Z = (double)halfHeight;
		}
		this.SelfTransform.TransformPosition(this.TmpVector1, this.TmpLocation);
		this.TmpResult.Location = this.TmpLocation.ToUeVectorOld();
		if (!this.OnWall)
		{
			this.TmpResult.Success = true;
			this.MoveOffset.FromUeVector(moveOffset);
			this.SelfLocation.Subtraction(this.ActorLocation, this.TmpVector1);
			this.TmpResult.SquaredOffsetLength = (float)(Singleton<MathUtils>.Instance.Square(this.SelfToActor.Size2D() - this.MoveOffset.Size2D()) + Singleton<MathUtils>.Instance.Square(this.SelfToActor.Z + this.MoveOffset.Z));
			this.SelfTransform.GetRotation().RotateVector(Vector.UpVectorProxy, this.TmpVector2);
			Singleton<MathUtils>.Instance.LookRotationForwardFirst(this.TmpVector1, this.TmpVector2, this.OutRotator);
			this.TmpResult.Rotator = this.OutRotator.ToUeRotator();
			return this.TmpResult;
		}
		UTraceLineElement lineTrace = this.LineTrace;
		lineTrace.WorldContextObject = actor;
		Singleton<TraceElementCommon>.Instance.SetStartLocation(lineTrace, this.ActorLocation);
		Singleton<TraceElementCommon>.Instance.SetEndLocation(lineTrace, this.TmpResult.Location);
		this.TmpResult.Success = !Singleton<TraceElementCommon>.Instance.LineTrace(lineTrace, "TsSimpleInteractPoint_GetBestTransform");
		lineTrace.WorldContextObject = null;
		if (!this.TmpResult.Success)
		{
			return this.TmpResult;
		}
		this.MoveOffset.FromUeVector(moveOffset);
		this.SelfLocation.Subtraction(this.ActorLocation, this.TmpVector1);
		this.TmpResult.SquaredOffsetLength = (float)(Singleton<MathUtils>.Instance.Square(this.SelfToActor.Size2D() - this.MoveOffset.Size2D()) + Singleton<MathUtils>.Instance.Square(this.SelfToActor.Z + this.MoveOffset.Z));
		Quat rotation = this.SelfTransform.GetRotation();
		rotation.RotateVector(Vector.ForwardVectorProxy, this.TmpVector1);
		rotation.RotateVector(Vector.UpVectorProxy, this.TmpVector2);
		this.TmpVector1.UnaryNegation(this.TmpVector1);
		Singleton<MathUtils>.Instance.LookRotationForwardFirst(this.TmpVector1, this.TmpVector2, this.OutRotator);
		this.TmpResult.Rotator = this.OutRotator.ToUeRotator();
		return this.TmpResult;
	}

	// Token: 0x0601ADC3 RID: 110019 RVA: 0x0080407F File Offset: 0x0080227F
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsSimpleInteractPoint._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/NewWorld/SceneItem/SimpleBlueprintItem/TsSimpleInteractPoint.TsSimpleInteractPoint_C");
		}
		return TsSimpleInteractPoint._ClassPtr;
	}

	// Token: 0x0601ADC4 RID: 110020 RVA: 0x008040A4 File Offset: 0x008022A4
	public TsSimpleInteractPoint() : this(BuiltinUtils.AllocNativeUObject(TsSimpleInteractPoint.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0601ADC5 RID: 110021 RVA: 0x008040CC File Offset: 0x008022CC
	public TsSimpleInteractPoint(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsSimpleInteractPoint.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601ADC6 RID: 110022 RVA: 0x008040FF File Offset: 0x008022FF
	protected TsSimpleInteractPoint(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0400D9FA RID: 55802
	private static readonly FLinearColor RedColor = new FLinearColor(1f, 0f, 0f, 1f);

	// Token: 0x0400D9FB RID: 55803
	private static readonly FLinearColor BlueColor = new FLinearColor(0f, 0f, 1f, 1f);

	// Token: 0x0400D9FC RID: 55804
	private const float DRAW_TIME = 0.05f;

	// Token: 0x0400D9FD RID: 55805
	private const float DEFAULT_THICKNESS = 4f;

	// Token: 0x0400D9FE RID: 55806
	private const float DEFAULT_ARROW_SIZE = 20f;

	// Token: 0x0400D9FF RID: 55807
	private const float DRAW_LENGTH = 100f;

	// Token: 0x0400DA00 RID: 55808
	[StaticVariableRuleIgnore]
	private static readonly Vector ForwardOffset = Vector.Create(100.0, 0.0, 0.0);

	// Token: 0x0400DA01 RID: 55809
	[StaticVariableRuleIgnore]
	private static readonly Vector UpOffset = Vector.Create(0.0, 0.0, 100.0);

	// Token: 0x0400DA02 RID: 55810
	private static readonly FColor TextColor = new FColor(byte.MaxValue, 128, 128, byte.MaxValue);

	// Token: 0x0400DA03 RID: 55811
	private const float TEXT_SIZE = 80f;

	// Token: 0x0400DA04 RID: 55812
	private const string PROFILE_KEY = "TsSimpleInteractPoint_GetBestTransform";

	// Token: 0x0400DA05 RID: 55813
	[Nullable(2)]
	private Rotator OutRotator;

	// Token: 0x0400DA06 RID: 55814
	[Nullable(2)]
	private Vector TmpLocation;

	// Token: 0x0400DA07 RID: 55815
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/NewWorld/SceneItem/SimpleBlueprintItem/TsSimpleInteractPoint.TsSimpleInteractPoint_C";

	// Token: 0x0400DA08 RID: 55816
	private static IntPtr _ClassPtr;

	// Token: 0x0400DA09 RID: 55817
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400DA0A RID: 55818
	private static int __PropertyOffset_OnWall;
}
