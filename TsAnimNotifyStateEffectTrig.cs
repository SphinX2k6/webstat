using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Effect.AnimNotifyInteraction.BP;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000D43 RID: 3395
[NullableContext(2)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateEffectTrig.TsAnimNotifyStateEffectTrig_C")]
public class TsAnimNotifyStateEffectTrig : TsAnimNotifyStateBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170003CA RID: 970
	// (get) Token: 0x06004784 RID: 18308 RVA: 0x00094EEB File Offset: 0x000930EB
	// (set) Token: 0x06004785 RID: 18309 RVA: 0x00094EFB File Offset: 0x000930FB
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int AteIndex
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateEffectTrig.__PropertyOffset_AteIndex);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateEffectTrig.__PropertyOffset_AteIndex) = value;
		}
	}

	// Token: 0x170003CB RID: 971
	// (get) Token: 0x06004786 RID: 18310 RVA: 0x00094F0C File Offset: 0x0009310C
	// (set) Token: 0x06004787 RID: 18311 RVA: 0x00094F1C File Offset: 0x0009311C
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe EEffectAction 攻击类型
	{
		get
		{
			return (EEffectAction)(*(base.NativePtr + (IntPtr)TsAnimNotifyStateEffectTrig.__PropertyOffset_攻击类型));
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateEffectTrig.__PropertyOffset_攻击类型) = (byte)value;
		}
	}

	// Token: 0x170003CC RID: 972
	// (get) Token: 0x06004788 RID: 18312 RVA: 0x00094F2D File Offset: 0x0009312D
	// (set) Token: 0x06004789 RID: 18313 RVA: 0x00094F3D File Offset: 0x0009313D
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float 攻击半径
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateEffectTrig.__PropertyOffset_攻击半径);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateEffectTrig.__PropertyOffset_攻击半径) = value;
		}
	}

	// Token: 0x170003CD RID: 973
	// (get) Token: 0x0600478A RID: 18314 RVA: 0x00094F4E File Offset: 0x0009314E
	// (set) Token: 0x0600478B RID: 18315 RVA: 0x00094F5E File Offset: 0x0009315E
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float 攻击强度
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateEffectTrig.__PropertyOffset_攻击强度);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateEffectTrig.__PropertyOffset_攻击强度) = value;
		}
	}

	// Token: 0x170003CE RID: 974
	// (get) Token: 0x0600478C RID: 18316 RVA: 0x00094F6F File Offset: 0x0009316F
	// (set) Token: 0x0600478D RID: 18317 RVA: 0x00094F7F File Offset: 0x0009317F
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float 纹理高度
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateEffectTrig.__PropertyOffset_纹理高度);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateEffectTrig.__PropertyOffset_纹理高度) = value;
		}
	}

	// Token: 0x170003CF RID: 975
	// (get) Token: 0x0600478E RID: 18318 RVA: 0x00094F90 File Offset: 0x00093190
	// (set) Token: 0x0600478F RID: 18319 RVA: 0x00094FA4 File Offset: 0x000931A4
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FVector 特效节点Location
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateEffectTrig.__PropertyOffset_特效节点Location);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateEffectTrig.__PropertyOffset_特效节点Location) = value;
		}
	}

	// Token: 0x170003D0 RID: 976
	// (get) Token: 0x06004790 RID: 18320 RVA: 0x00094FB9 File Offset: 0x000931B9
	// (set) Token: 0x06004791 RID: 18321 RVA: 0x00094FCD File Offset: 0x000931CD
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe UMaterialParameterCollection AteMPC
	{
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<UMaterialParameterCollection>(base.NativePtr / (IntPtr)sizeof(void*) + TsAnimNotifyStateEffectTrig.__PropertyOffset_AteMPC);
		}
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TsAnimNotifyStateEffectTrig.__PropertyOffset_AteMPC, value);
		}
	}

	// Token: 0x170003D1 RID: 977
	// (get) Token: 0x06004792 RID: 18322 RVA: 0x00094FE2 File Offset: 0x000931E2
	// (set) Token: 0x06004793 RID: 18323 RVA: 0x00094FF6 File Offset: 0x000931F6
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe UCurveFloat CurveFloat
	{
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<UCurveFloat>(base.NativePtr / (IntPtr)sizeof(void*) + TsAnimNotifyStateEffectTrig.__PropertyOffset_CurveFloat);
		}
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TsAnimNotifyStateEffectTrig.__PropertyOffset_CurveFloat, value);
		}
	}

	// Token: 0x06004794 RID: 18324 RVA: 0x0009500C File Offset: 0x0009320C
	[UFunction(EFunctionFlags.FUNC_None)]
	public override bool K2_NotifyBegin(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		this.NotifyTotalDuration = totalDuration;
		this.ElapsedTime = 0f;
		if (!(meshComp.GetOwner() is ACharacter))
		{
			Singleton<Log>.Instance.Warn(ELogModule.RenderEffect, ELogAuthor.ZJL, "TsAnimNotifyEffectTrig Owner非Character", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		if (this.AteMPC == null)
		{
			Singleton<Log>.Instance.Warn(ELogModule.RenderEffect, ELogAuthor.ZJL, "TsAnimNotifyEffectTrig 未配置 MPC", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		if (!EffectTriggerMaterialParameterRegistry.IsValidActionAndIndex(this.攻击类型, this.AteIndex))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.RenderEffect;
			ELogAuthor author = ELogAuthor.ZJL;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(54, 2);
			defaultInterpolatedStringHandler.AppendLiteral("TsAnimNotifyEffectTrig 攻击类型或AteIndex无效 攻击类型=");
			defaultInterpolatedStringHandler.AppendFormatted<EEffectAction>(this.攻击类型);
			defaultInterpolatedStringHandler.AppendLiteral(" AteIndex=");
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.AteIndex);
			instance.Warn(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		UKismetMaterialLibrary.SetScalarParameterValue(GlobalData.World, this.AteMPC, EffectTriggerMaterialParameterRegistry.GetTriggerParameterName(this.攻击类型, this.AteIndex), UGameplayStatics.GetRealTimeSeconds(GlobalData.World));
		UKismetMaterialLibrary.SetScalarParameterValue(GlobalData.World, this.AteMPC, EffectTriggerMaterialParameterRegistry.GetDurationParameterName(this.攻击类型, this.AteIndex), totalDuration);
		UKismetMaterialLibrary.SetScalarParameterValue(GlobalData.World, this.AteMPC, EffectTriggerMaterialParameterRegistry.GetAttackRadiusParameterName(this.攻击类型, this.AteIndex), this.攻击半径);
		UKismetMaterialLibrary.SetScalarParameterValue(GlobalData.World, this.AteMPC, EffectTriggerMaterialParameterRegistry.GetAttackMagnitudeParameterName(this.攻击类型, this.AteIndex), this.攻击强度);
		UKismetMaterialLibrary.SetScalarParameterValue(GlobalData.World, this.AteMPC, EffectTriggerMaterialParameterRegistry.GetTextureHeightParameterName(this.攻击类型, this.AteIndex), this.纹理高度);
		Vector tempVectorDouble = this.TempVectorDouble;
		FVector 特效节点Location = this.特效节点Location;
		tempVectorDouble.FromUeVector(特效节点Location);
		FTransformDouble ftransformDouble = meshComp.D_K2_GetComponentToWorld();
		Vector tempVector = this.TempVector;
		FVectorDouble fvectorDouble = this.TempVectorDouble.ToUeVector(false);
		FVectorDouble fvectorDouble2 = ftransformDouble.TransformPosition(fvectorDouble);
		tempVector.FromUeVector(fvectorDouble2);
		UObject world = GlobalData.World;
		UMaterialParameterCollection ateMPC = this.AteMPC;
		FName actorLocationParameterName = EffectTriggerMaterialParameterRegistry.GetActorLocationParameterName(this.攻击类型, this.AteIndex);
		FLinearColor flinearColor = UKismetMathLibrary.Conv_VectorDoubleToLinearColor(this.TempVector.ToUeVector(false));
		UKismetMaterialLibrary.SetVectorParameterValue(world, ateMPC, actorLocationParameterName, flinearColor);
		return true;
	}

	// Token: 0x06004795 RID: 18325 RVA: 0x00095228 File Offset: 0x00093428
	[UFunction(EFunctionFlags.FUNC_None)]
	public override bool K2_NotifyTick(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float frameDeltaTime)
	{
		if (this.AteMPC == null || this.CurveFloat == null)
		{
			return false;
		}
		this.ElapsedTime += frameDeltaTime;
		float inTime = (this.NotifyTotalDuration > 0f) ? Math.Min(this.ElapsedTime / this.NotifyTotalDuration, 1f) : 0f;
		float floatValue = this.CurveFloat.GetFloatValue(inTime);
		UKismetMaterialLibrary.SetScalarParameterValue(GlobalData.World, this.AteMPC, EffectTriggerMaterialParameterRegistry.GetCurveFloatParameterName(this.攻击类型, this.AteIndex), floatValue);
		UKismetMaterialLibrary.SetScalarParameterValue(GlobalData.World, this.AteMPC, EffectTriggerMaterialParameterRegistry.GetElapsedTimeParameterName(this.攻击类型, this.AteIndex), this.ElapsedTime);
		return true;
	}

	// Token: 0x06004796 RID: 18326 RVA: 0x000952D8 File Offset: 0x000934D8
	[UFunction(EFunctionFlags.FUNC_None)]
	public override bool K2_NotifyEnd(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		this.ElapsedTime = 0f;
		this.NotifyTotalDuration = 0f;
		return true;
	}

	// Token: 0x06004797 RID: 18327 RVA: 0x000952F1 File Offset: 0x000934F1
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public override string GetNotifyName()
	{
		return "触发特效ANS";
	}

	// Token: 0x06004798 RID: 18328 RVA: 0x000952F8 File Offset: 0x000934F8
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStateEffectTrig._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateEffectTrig.TsAnimNotifyStateEffectTrig_C");
		}
		return TsAnimNotifyStateEffectTrig._ClassPtr;
	}

	// Token: 0x06004799 RID: 18329 RVA: 0x0009531C File Offset: 0x0009351C
	public TsAnimNotifyStateEffectTrig() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateEffectTrig.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0600479A RID: 18330 RVA: 0x00095344 File Offset: 0x00093544
	[NullableContext(1)]
	public TsAnimNotifyStateEffectTrig(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateEffectTrig.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0600479B RID: 18331 RVA: 0x00095377 File Offset: 0x00093577
	protected TsAnimNotifyStateEffectTrig(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0600479C RID: 18332 RVA: 0x00095398 File Offset: 0x00093598
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x0600479D RID: 18333 RVA: 0x000953D4 File Offset: 0x000935D4
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyTick_Implementation(UKuroAnimNotifyState.__K2_NotifyTick_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyTick(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->FrameDeltaTime);
	}

	// Token: 0x0600479E RID: 18334 RVA: 0x00095410 File Offset: 0x00093610
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x0600479F RID: 18335 RVA: 0x00095443 File Offset: 0x00093643
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotifyState.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName());
	}

	// Token: 0x040013B7 RID: 5047
	[Nullable(1)]
	private readonly Vector TempVector = Vector.Create();

	// Token: 0x040013B8 RID: 5048
	[Nullable(1)]
	private readonly Vector TempVectorDouble = Vector.Create();

	// Token: 0x040013B9 RID: 5049
	private float NotifyTotalDuration;

	// Token: 0x040013BA RID: 5050
	private float ElapsedTime;

	// Token: 0x040013BB RID: 5051
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateEffectTrig.TsAnimNotifyStateEffectTrig_C";

	// Token: 0x040013BC RID: 5052
	private static IntPtr _ClassPtr;

	// Token: 0x040013BD RID: 5053
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x040013BE RID: 5054
	private static int __PropertyOffset_AteIndex;

	// Token: 0x040013BF RID: 5055
	private static int __PropertyOffset_攻击类型;

	// Token: 0x040013C0 RID: 5056
	private static int __PropertyOffset_攻击半径;

	// Token: 0x040013C1 RID: 5057
	private static int __PropertyOffset_攻击强度;

	// Token: 0x040013C2 RID: 5058
	private static int __PropertyOffset_纹理高度;

	// Token: 0x040013C3 RID: 5059
	private static int __PropertyOffset_特效节点Location;

	// Token: 0x040013C4 RID: 5060
	private static int __PropertyOffset_AteMPC;

	// Token: 0x040013C5 RID: 5061
	private static int __PropertyOffset_CurveFloat;
}
