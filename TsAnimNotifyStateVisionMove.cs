using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.Vision;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000D9B RID: 3483
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateVisionMove.TsAnimNotifyStateVisionMove_C")]
public class TsAnimNotifyStateVisionMove : TsAnimNotifyStateBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170004B9 RID: 1209
	// (get) Token: 0x06004DA5 RID: 19877 RVA: 0x000AF9FF File Offset: 0x000ADBFF
	// (set) Token: 0x06004DA6 RID: 19878 RVA: 0x000AFA13 File Offset: 0x000ADC13
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FVector 移动速度
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateVisionMove.__PropertyOffset_移动速度);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateVisionMove.__PropertyOffset_移动速度) = value;
		}
	}

	// Token: 0x06004DA7 RID: 19879 RVA: 0x000AFA28 File Offset: 0x000ADC28
	[NullableContext(2)]
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

	// Token: 0x06004DA8 RID: 19880 RVA: 0x000AFAD0 File Offset: 0x000ADCD0
	[NullableContext(2)]
	protected virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		this.Init();
		if (UKuroStaticLibrary.IsObjectClassByName(meshComp.GetOwner(), Singleton<CharacterNameDefines>.Instance.BP_BASEVISION))
		{
			Vector velocity = this.Velocity;
			FVector 移动速度 = this.移动速度;
			velocity.FromUeVector(移动速度);
			return true;
		}
		return false;
	}

	// Token: 0x06004DA9 RID: 19881 RVA: 0x000AFB14 File Offset: 0x000ADD14
	[NullableContext(2)]
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

	// Token: 0x06004DAA RID: 19882 RVA: 0x000AFBBC File Offset: 0x000ADDBC
	[NullableContext(2)]
	protected virtual bool K2_NotifyTick_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float frameDeltaTime)
	{
		AActor owner = meshComp.GetOwner();
		if (!UKuroStaticLibrary.IsObjectClassByName(owner, Singleton<CharacterNameDefines>.Instance.BP_BASEVISION))
		{
			return false;
		}
		CharacterActorComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterActorComponent>((owner as BP_BaseVision_C).EntityId);
		if (component == null || !component.Valid)
		{
			return false;
		}
		component.AddActorLocalOffset(this.Velocity.Multiply((double)frameDeltaTime, this.TmpVector).ToUeVector(false), "TsAnimNotifyStateVisionMove", true);
		return true;
	}

	// Token: 0x06004DAB RID: 19883 RVA: 0x000AFC33 File Offset: 0x000ADE33
	private void Init()
	{
		this.Velocity = Vector.Create();
		this.TmpVector = Vector.Create();
	}

	// Token: 0x06004DAC RID: 19884 RVA: 0x000AFC4C File Offset: 0x000ADE4C
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

	// Token: 0x06004DAD RID: 19885 RVA: 0x000AFCC7 File Offset: 0x000ADEC7
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "幻象移动";
	}

	// Token: 0x06004DAE RID: 19886 RVA: 0x000AFCCE File Offset: 0x000ADECE
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStateVisionMove._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateVisionMove.TsAnimNotifyStateVisionMove_C");
		}
		return TsAnimNotifyStateVisionMove._ClassPtr;
	}

	// Token: 0x06004DAF RID: 19887 RVA: 0x000AFCF4 File Offset: 0x000ADEF4
	public TsAnimNotifyStateVisionMove() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateVisionMove.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004DB0 RID: 19888 RVA: 0x000AFD1C File Offset: 0x000ADF1C
	[NullableContext(1)]
	public TsAnimNotifyStateVisionMove(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateVisionMove.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004DB1 RID: 19889 RVA: 0x000AFD4F File Offset: 0x000ADF4F
	protected TsAnimNotifyStateVisionMove(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004DB2 RID: 19890 RVA: 0x000AFD58 File Offset: 0x000ADF58
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x06004DB3 RID: 19891 RVA: 0x000AFD94 File Offset: 0x000ADF94
	protected unsafe virtual void __CPPCALL_K2_NotifyTick_Implementation(UKuroAnimNotifyState.__K2_NotifyTick_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyTick_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->FrameDeltaTime);
	}

	// Token: 0x06004DB4 RID: 19892 RVA: 0x000AFDCD File Offset: 0x000ADFCD
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotifyState.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x04001665 RID: 5733
	[Nullable(2)]
	private Vector Velocity;

	// Token: 0x04001666 RID: 5734
	[Nullable(2)]
	private Vector TmpVector;

	// Token: 0x04001667 RID: 5735
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateVisionMove.TsAnimNotifyStateVisionMove_C";

	// Token: 0x04001668 RID: 5736
	private static IntPtr _ClassPtr;

	// Token: 0x04001669 RID: 5737
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400166A RID: 5738
	private static int __PropertyOffset_移动速度;
}
