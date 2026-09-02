using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Core.World;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02003252 RID: 12882
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/NewWorld/SceneItem/SimpleBlueprintItem/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/NewWorld/SceneItem/SimpleBlueprintItem/TsSimpleInteractHookPoint.TsSimpleInteractHookPoint_C")]
public class TsSimpleInteractHookPoint : TsSimpleInteractBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x0601ADA1 RID: 109985 RVA: 0x00802431 File Offset: 0x00800631
	protected override bool CheckLegal()
	{
		return true;
	}

	// Token: 0x0601ADA2 RID: 109986 RVA: 0x00802434 File Offset: 0x00800634
	protected override void OnDraw()
	{
		FVectorDouble lineStart = base.D_K2_GetActorLocation();
		FTransformDouble ftransformDouble = base.D_GetTransform();
		UKismetSystemLibrary.D_DrawDebugArrow(this, lineStart, ftransformDouble.TransformPosition(TsSimpleInteractHookPoint.forwardOffset), 20f, TsSimpleInteractHookPoint.redColor, 0.05f, 4f);
		UKismetSystemLibrary.D_DrawDebugArrow(this, lineStart, ftransformDouble.TransformPosition(TsSimpleInteractHookPoint.upOffset), 20f, TsSimpleInteractHookPoint.blueColor, 0.05f, 4f);
	}

	// Token: 0x0601ADA3 RID: 109987 RVA: 0x008024A0 File Offset: 0x008006A0
	protected override void SetText(FVector offset)
	{
		base.Text.HorizontalAlignment = EHorizTextAligment.EHTA_Center;
		base.Text.SetWorldSize(80f);
		base.Text.SetTextRenderColor(TsSimpleInteractHookPoint.textColor);
		UTextRenderComponent text = base.Text;
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(10, 1);
		defaultInterpolatedStringHandler.AppendLiteral("HookPoint ");
		defaultInterpolatedStringHandler.AppendFormatted<int>(base.TypeId);
		text.Text = defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x0601ADA4 RID: 109988 RVA: 0x00802518 File Offset: 0x00800718
	protected override SSimpleInteractResult OnGetBestTransform(AActor actor, FVector moveOffset, float halfHeight, float radius)
	{
		Vector actorLocation = this.ActorLocation;
		FVectorDouble fvectorDouble = actor.D_K2_GetActorLocation();
		actorLocation.FromUeVector(fvectorDouble);
		this.ActorLocation.Subtraction(this.SelfLocation, this.SelfToActor);
		this.TmpVector1.X = (double)radius;
		this.TmpVector1.Y = 0.0;
		this.TmpVector1.Z = 0.0;
		if (this.TmpLocation == null)
		{
			this.TmpLocation = Vector.Create();
		}
		this.SelfTransform.TransformPosition(this.TmpVector1, this.TmpLocation);
		this.TmpResult.Location = this.TmpLocation.ToUeVectorOld();
		this.LineTrace.WorldContextObject = actor;
		Singleton<TraceElementCommon>.Instance.SetStartLocation(this.LineTrace, this.ActorLocation);
		Singleton<TraceElementCommon>.Instance.SetEndLocation(this.LineTrace, this.TmpResult.Location);
		this.TmpResult.Success = !Singleton<TraceElementCommon>.Instance.LineTrace(this.LineTrace, "TsSimpleInteractHookPoint_GetBestTransform");
		this.LineTrace.WorldContextObject = null;
		bool success = this.TmpResult.Success;
		return this.TmpResult;
	}

	// Token: 0x0601ADA5 RID: 109989 RVA: 0x0080264A File Offset: 0x0080084A
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsSimpleInteractHookPoint._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/NewWorld/SceneItem/SimpleBlueprintItem/TsSimpleInteractHookPoint.TsSimpleInteractHookPoint_C");
		}
		return TsSimpleInteractHookPoint._ClassPtr;
	}

	// Token: 0x0601ADA6 RID: 109990 RVA: 0x00802670 File Offset: 0x00800870
	public TsSimpleInteractHookPoint() : this(BuiltinUtils.AllocNativeUObject(TsSimpleInteractHookPoint.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0601ADA7 RID: 109991 RVA: 0x00802698 File Offset: 0x00800898
	public TsSimpleInteractHookPoint(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsSimpleInteractHookPoint.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601ADA8 RID: 109992 RVA: 0x008026CB File Offset: 0x008008CB
	protected TsSimpleInteractHookPoint(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0400D9CA RID: 55754
	private static readonly FLinearColor redColor = new FLinearColor(1f, 0f, 0f, 1f);

	// Token: 0x0400D9CB RID: 55755
	private static readonly FLinearColor blueColor = new FLinearColor(0f, 0f, 1f, 1f);

	// Token: 0x0400D9CC RID: 55756
	private const float DRAW_TIME = 0.05f;

	// Token: 0x0400D9CD RID: 55757
	private const float DEFAULT_THICKNESS = 4f;

	// Token: 0x0400D9CE RID: 55758
	private const float DEFAULT_ARROW_SIZE = 20f;

	// Token: 0x0400D9CF RID: 55759
	private const float DRAW_LENGTH = 100f;

	// Token: 0x0400D9D0 RID: 55760
	private static readonly FVectorDouble forwardOffset = new FVectorDouble(100.0, 0.0, 0.0);

	// Token: 0x0400D9D1 RID: 55761
	private static readonly FVectorDouble upOffset = new FVectorDouble(0.0, 0.0, 100.0);

	// Token: 0x0400D9D2 RID: 55762
	private static readonly FColor textColor = new FColor(byte.MaxValue, 128, 128, byte.MaxValue);

	// Token: 0x0400D9D3 RID: 55763
	private const float TEXT_SIZE = 80f;

	// Token: 0x0400D9D4 RID: 55764
	private const string PROFILE_KEY = "TsSimpleInteractHookPoint_GetBestTransform";

	// Token: 0x0400D9D5 RID: 55765
	[Nullable(2)]
	private Vector TmpLocation;

	// Token: 0x0400D9D6 RID: 55766
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/NewWorld/SceneItem/SimpleBlueprintItem/TsSimpleInteractHookPoint.TsSimpleInteractHookPoint_C";

	// Token: 0x0400D9D7 RID: 55767
	private static IntPtr _ClassPtr;

	// Token: 0x0400D9D8 RID: 55768
	private static IntPtr _ClassDefaultObjectPtr;
}
