using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Sequence.Seq_BP.BPGobletLiquid;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000D41 RID: 3393
[NullableContext(2)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateDrinksTalk.TsAnimNotifyStateDrinksTalk_C")]
public class TsAnimNotifyStateDrinksTalk : TsAnimNotifyStateBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170003BE RID: 958
	// (get) Token: 0x0600474F RID: 18255 RVA: 0x000942AF File Offset: 0x000924AF
	// (set) Token: 0x06004750 RID: 18256 RVA: 0x000942BF File Offset: 0x000924BF
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool bIsTick
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateDrinksTalk.__PropertyOffset_bIsTick) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateDrinksTalk.__PropertyOffset_bIsTick) = (value ? 1 : 0);
		}
	}

	// Token: 0x170003BF RID: 959
	// (get) Token: 0x06004751 RID: 18257 RVA: 0x000942D0 File Offset: 0x000924D0
	// (set) Token: 0x06004752 RID: 18258 RVA: 0x000942E0 File Offset: 0x000924E0
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool bUseSocketPosition
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateDrinksTalk.__PropertyOffset_bUseSocketPosition) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateDrinksTalk.__PropertyOffset_bUseSocketPosition) = (value ? 1 : 0);
		}
	}

	// Token: 0x170003C0 RID: 960
	// (get) Token: 0x06004753 RID: 18259 RVA: 0x000942F1 File Offset: 0x000924F1
	// (set) Token: 0x06004754 RID: 18260 RVA: 0x00094301 File Offset: 0x00092501
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float AttachTimeLength
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateDrinksTalk.__PropertyOffset_AttachTimeLength);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateDrinksTalk.__PropertyOffset_AttachTimeLength) = value;
		}
	}

	// Token: 0x170003C1 RID: 961
	// (get) Token: 0x06004755 RID: 18261 RVA: 0x00094312 File Offset: 0x00092512
	// (set) Token: 0x06004756 RID: 18262 RVA: 0x00094326 File Offset: 0x00092526
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FName ActorTag
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateDrinksTalk.__PropertyOffset_ActorTag);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateDrinksTalk.__PropertyOffset_ActorTag) = value;
		}
	}

	// Token: 0x170003C2 RID: 962
	// (get) Token: 0x06004757 RID: 18263 RVA: 0x0009433B File Offset: 0x0009253B
	// (set) Token: 0x06004758 RID: 18264 RVA: 0x0009434F File Offset: 0x0009254F
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FName AttachSocketName
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateDrinksTalk.__PropertyOffset_AttachSocketName);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateDrinksTalk.__PropertyOffset_AttachSocketName) = value;
		}
	}

	// Token: 0x170003C3 RID: 963
	// (get) Token: 0x06004759 RID: 18265 RVA: 0x00094364 File Offset: 0x00092564
	// (set) Token: 0x0600475A RID: 18266 RVA: 0x00094374 File Offset: 0x00092574
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool bIsPlayAnimSeq
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateDrinksTalk.__PropertyOffset_bIsPlayAnimSeq) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateDrinksTalk.__PropertyOffset_bIsPlayAnimSeq) = (value ? 1 : 0);
		}
	}

	// Token: 0x170003C4 RID: 964
	// (get) Token: 0x0600475B RID: 18267 RVA: 0x00094385 File Offset: 0x00092585
	// (set) Token: 0x0600475C RID: 18268 RVA: 0x00094399 File Offset: 0x00092599
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FName BatchSocketName
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateDrinksTalk.__PropertyOffset_BatchSocketName);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateDrinksTalk.__PropertyOffset_BatchSocketName) = value;
		}
	}

	// Token: 0x170003C5 RID: 965
	// (get) Token: 0x0600475D RID: 18269 RVA: 0x000943AE File Offset: 0x000925AE
	// (set) Token: 0x0600475E RID: 18270 RVA: 0x000943C2 File Offset: 0x000925C2
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe UAnimSequence AnimSeq
	{
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<UAnimSequence>(base.NativePtr / (IntPtr)sizeof(void*) + TsAnimNotifyStateDrinksTalk.__PropertyOffset_AnimSeq);
		}
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TsAnimNotifyStateDrinksTalk.__PropertyOffset_AnimSeq, value);
		}
	}

	// Token: 0x170003C6 RID: 966
	// (get) Token: 0x0600475F RID: 18271 RVA: 0x000943D8 File Offset: 0x000925D8
	// (set) Token: 0x06004760 RID: 18272 RVA: 0x00094411 File Offset: 0x00092611
	[Nullable(1)]
	[UProperty(EPropertyFlags.CPF_None)]
	public FKuroCurveFloat HighCurve
	{
		[NullableContext(1)]
		get
		{
			base.FastCheckIsValid();
			FKuroCurveFloat result;
			if ((result = this._HighCurve) == null)
			{
				result = (this._HighCurve = new FKuroCurveFloat(base.NativePtr + (IntPtr)TsAnimNotifyStateDrinksTalk.__PropertyOffset_HighCurve, this));
			}
			return result;
		}
		[NullableContext(1)]
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)TsAnimNotifyStateDrinksTalk.__PropertyOffset_HighCurve, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x170003C7 RID: 967
	// (get) Token: 0x06004761 RID: 18273 RVA: 0x00094439 File Offset: 0x00092639
	// (set) Token: 0x06004762 RID: 18274 RVA: 0x0009444D File Offset: 0x0009264D
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe UMaterialParameterCollection MPCObject
	{
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<UMaterialParameterCollection>(base.NativePtr / (IntPtr)sizeof(void*) + TsAnimNotifyStateDrinksTalk.__PropertyOffset_MPCObject);
		}
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TsAnimNotifyStateDrinksTalk.__PropertyOffset_MPCObject, value);
		}
	}

	// Token: 0x170003C8 RID: 968
	// (get) Token: 0x06004763 RID: 18275 RVA: 0x00094462 File Offset: 0x00092662
	// (set) Token: 0x06004764 RID: 18276 RVA: 0x00094472 File Offset: 0x00092672
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool IsAttach
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateDrinksTalk.__PropertyOffset_IsAttach) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateDrinksTalk.__PropertyOffset_IsAttach) = (value ? 1 : 0);
		}
	}

	// Token: 0x170003C9 RID: 969
	// (get) Token: 0x06004765 RID: 18277 RVA: 0x00094483 File Offset: 0x00092683
	// (set) Token: 0x06004766 RID: 18278 RVA: 0x00094497 File Offset: 0x00092697
	[UProperty(EPropertyFlags.CPF_None)]
	protected unsafe BP_Prop_GobletLiquid_C CupActor
	{
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<BP_Prop_GobletLiquid_C>(base.NativePtr / (IntPtr)sizeof(void*) + TsAnimNotifyStateDrinksTalk.__PropertyOffset_CupActor);
		}
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TsAnimNotifyStateDrinksTalk.__PropertyOffset_CupActor, value);
		}
	}

	// Token: 0x06004767 RID: 18279 RVA: 0x000944AC File Offset: 0x000926AC
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override bool K2_NotifyBegin(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("K2_NotifyBegin"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams*)ptr + 15L / (long)sizeof(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->MeshComp) = ((meshComp != null) ? meshComp.NativePtr : ((IntPtr)0));
			*(&ptr2->Animation) = ((animation != null) ? animation.NativePtr : ((IntPtr)0));
			ptr2->TotalDuration = totalDuration;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x06004768 RID: 18280 RVA: 0x00094554 File Offset: 0x00092754
	protected virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		this.IsAttach = false;
		this.CupActor = (UKuroCollectActorComponent.GetActorWithTag(this.ActorTag, ECollectActorType.Default) as BP_Prop_GobletLiquid_C);
		if (this.CupActor == null)
		{
			return false;
		}
		this.ActorLocation = Vector.Create();
		this.ActorRotation = Rotator.Create();
		Vector actorLocation = this.ActorLocation;
		FVectorDouble fvectorDouble = this.CupActor.D_K2_GetActorLocation();
		actorLocation.FromUeVector(fvectorDouble);
		Rotator actorRotation = this.ActorRotation;
		FRotator frotator = this.CupActor.K2_GetActorRotation();
		actorRotation.FromUeRotator(frotator);
		this.CupActor.IsTick = this.bIsTick;
		this.CupActor.UseLiquidSocketPosition = this.bUseSocketPosition;
		this.CupActor.BatchSocketName = this.BatchSocketName;
		if (this.AnimSeq == null || !this.AnimSeq.IsValid() || !this.bUseSocketPosition || !this.bIsPlayAnimSeq)
		{
			return false;
		}
		this.CupActor.UpdateGobletLiguid();
		this.CupActor.Liquid.SetAnimationMode(EAnimationMode.AnimationSingleNode);
		this.CupActor.Liquid.PlayAnimation(this.AnimSeq, false);
		return true;
	}

	// Token: 0x06004769 RID: 18281 RVA: 0x00094660 File Offset: 0x00092860
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override bool K2_NotifyTick(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float frameDeltaTime)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("K2_NotifyTick"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UKuroAnimNotifyState.__K2_NotifyTick_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UKuroAnimNotifyState.__K2_NotifyTick_FunctionParams*)ptr + 15L / (long)sizeof(UKuroAnimNotifyState.__K2_NotifyTick_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->MeshComp) = ((meshComp != null) ? meshComp.NativePtr : ((IntPtr)0));
			*(&ptr2->Animation) = ((animation != null) ? animation.NativePtr : ((IntPtr)0));
			ptr2->FrameDeltaTime = frameDeltaTime;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x0600476A RID: 18282 RVA: 0x00094708 File Offset: 0x00092908
	protected virtual bool K2_NotifyTick_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float frameDeltaTime)
	{
		if (this.CupActor == null || !this.CupActor.IsValid())
		{
			return false;
		}
		if (!this.IsAttach && base.CurrentTimeLength >= this.AttachTimeLength)
		{
			this.CupActor.K2_AttachToComponent(meshComp, this.bUseSocketPosition ? FNameUtil.GetCheckDynamicFName("Root") : this.AttachSocketName, EAttachmentRule.SnapToTarget, EAttachmentRule.SnapToTarget, EAttachmentRule.SnapToTarget, true, true);
			this.IsAttach = true;
		}
		FKuroCurveFloat highCurve = this.HighCurve;
		float value_Float = UKuroCurveLibrary.GetValue_Float(highCurve, base.CurrentTimeLength);
		this.CupActor.Water_HighProcess = value_Float;
		return true;
	}

	// Token: 0x0600476B RID: 18283 RVA: 0x00094798 File Offset: 0x00092998
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override bool K2_NotifyEnd(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("K2_NotifyEnd"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams*)ptr + 15L / (long)sizeof(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->MeshComp) = ((meshComp != null) ? meshComp.NativePtr : ((IntPtr)0));
			*(&ptr2->Animation) = ((animation != null) ? animation.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x0600476C RID: 18284 RVA: 0x00094838 File Offset: 0x00092A38
	protected virtual bool K2_NotifyEnd_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		if (this.CupActor == null || !this.CupActor.IsValid())
		{
			return false;
		}
		this.CupActor.K2_DetachFromActor(EDetachmentRule.KeepWorld, EDetachmentRule.KeepWorld, EDetachmentRule.KeepWorld);
		FHitResult fhitResult = new FHitResult();
		this.CupActor.D_K2_SetActorLocation(this.ActorLocation.ToUeVector(false), false, ref fhitResult, false);
		this.CupActor.K2_SetActorRotation(this.ActorRotation.ToUeRotator(), false);
		this.CupActor.SetActorHiddenInGame(false);
		this.CupActor.UpdateGobletLiguid();
		float playLength = animation.GetPlayLength();
		FKuroCurveFloat highCurve = this.HighCurve;
		float value_Float = UKuroCurveLibrary.GetValue_Float(highCurve, playLength);
		this.CupActor.Water_HighProcess = value_Float;
		FIntVector worldOriginLocation = UGameplayStatics.GetWorldOriginLocation(this.CupActor.Liquid);
		FVectorDouble b = UKismetMathLibrary.Conv_VectorToVectorDouble(UKismetMathLibrary.Conv_IntVectorToVector(worldOriginLocation));
		FVector inVec = UKismetMathLibrary.Conv_VectorDoubleToVector(UKismetMathLibrary.D_Subtract_VectorVector(this.CupActor.Liquid.D_K2_GetComponentLocation(), b));
		UObject liquid = this.CupActor.Liquid;
		UMaterialParameterCollection mpcobject = this.MPCObject;
		FName value = FNameUtil.GetDynamicFName("WaterCenterPosition").Value;
		FLinearColor flinearColor = UKismetMathLibrary.Conv_VectorToLinearColor(inVec);
		UKismetMaterialLibrary.SetVectorParameterValue(liquid, mpcobject, value, flinearColor);
		USkeletalMeshComponent liquid2 = this.CupActor.Liquid;
		if (liquid2 != null)
		{
			liquid2.Stop();
		}
		USkeletalMeshComponent liquid3 = this.CupActor.Liquid;
		if (liquid3 != null)
		{
			liquid3.SetAnimation(null);
		}
		this.CupActor.IsTick = false;
		return true;
	}

	// Token: 0x0600476D RID: 18285 RVA: 0x0009498C File Offset: 0x00092B8C
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override string GetNotifyName()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("GetNotifyName"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UAnimNotifyState.__GetNotifyName_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UAnimNotifyState.__GetNotifyName_FunctionParams*)ptr + 15L / (long)sizeof(UAnimNotifyState.__GetNotifyName_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		string result = FString.ToString((void*)(&ptr2->__Result));
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return result;
	}

	// Token: 0x0600476E RID: 18286 RVA: 0x00094A07 File Offset: 0x00092C07
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "春节活动饮料对话状态";
	}

	// Token: 0x0600476F RID: 18287 RVA: 0x00094A0E File Offset: 0x00092C0E
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStateDrinksTalk._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateDrinksTalk.TsAnimNotifyStateDrinksTalk_C");
		}
		return TsAnimNotifyStateDrinksTalk._ClassPtr;
	}

	// Token: 0x06004770 RID: 18288 RVA: 0x00094A34 File Offset: 0x00092C34
	public TsAnimNotifyStateDrinksTalk() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateDrinksTalk.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004771 RID: 18289 RVA: 0x00094A5C File Offset: 0x00092C5C
	[NullableContext(1)]
	public TsAnimNotifyStateDrinksTalk(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateDrinksTalk.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004772 RID: 18290 RVA: 0x00094A8F File Offset: 0x00092C8F
	protected TsAnimNotifyStateDrinksTalk(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004773 RID: 18291 RVA: 0x00094AB0 File Offset: 0x00092CB0
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x06004774 RID: 18292 RVA: 0x00094AEC File Offset: 0x00092CEC
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyTick_Implementation(UKuroAnimNotifyState.__K2_NotifyTick_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyTick_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->FrameDeltaTime);
	}

	// Token: 0x06004775 RID: 18293 RVA: 0x00094B28 File Offset: 0x00092D28
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06004776 RID: 18294 RVA: 0x00094B5B File Offset: 0x00092D5B
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotifyState.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x040013A2 RID: 5026
	[Nullable(1)]
	protected Vector ActorLocation = Vector.Create();

	// Token: 0x040013A3 RID: 5027
	[Nullable(1)]
	protected Rotator ActorRotation = Rotator.Create();

	// Token: 0x040013A4 RID: 5028
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateDrinksTalk.TsAnimNotifyStateDrinksTalk_C";

	// Token: 0x040013A5 RID: 5029
	private static IntPtr _ClassPtr;

	// Token: 0x040013A6 RID: 5030
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x040013A7 RID: 5031
	private static int __PropertyOffset_bIsTick;

	// Token: 0x040013A8 RID: 5032
	private static int __PropertyOffset_bUseSocketPosition;

	// Token: 0x040013A9 RID: 5033
	private static int __PropertyOffset_AttachTimeLength;

	// Token: 0x040013AA RID: 5034
	private static int __PropertyOffset_ActorTag;

	// Token: 0x040013AB RID: 5035
	private static int __PropertyOffset_AttachSocketName;

	// Token: 0x040013AC RID: 5036
	private static int __PropertyOffset_bIsPlayAnimSeq;

	// Token: 0x040013AD RID: 5037
	private static int __PropertyOffset_BatchSocketName;

	// Token: 0x040013AE RID: 5038
	private static int __PropertyOffset_AnimSeq;

	// Token: 0x040013AF RID: 5039
	private static int __PropertyOffset_HighCurve;

	// Token: 0x040013B0 RID: 5040
	private FKuroCurveFloat _HighCurve;

	// Token: 0x040013B1 RID: 5041
	private static int __PropertyOffset_MPCObject;

	// Token: 0x040013B2 RID: 5042
	private static int __PropertyOffset_IsAttach;

	// Token: 0x040013B3 RID: 5043
	private static int __PropertyOffset_CupActor;
}
