using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Camera;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000D2F RID: 3375
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateCameraSensitivity.TsAnimNotifyStateCameraSensitivity_C")]
public class TsAnimNotifyStateCameraSensitivity : TsAnimNotifyStateBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x1700036D RID: 877
	// (get) Token: 0x060045C6 RID: 17862 RVA: 0x0008BA9F File Offset: 0x00089C9F
	// (set) Token: 0x060045C7 RID: 17863 RVA: 0x0008BAAF File Offset: 0x00089CAF
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float 水平视角灵敏度
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateCameraSensitivity.__PropertyOffset_水平视角灵敏度);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateCameraSensitivity.__PropertyOffset_水平视角灵敏度) = value;
		}
	}

	// Token: 0x1700036E RID: 878
	// (get) Token: 0x060045C8 RID: 17864 RVA: 0x0008BAC0 File Offset: 0x00089CC0
	// (set) Token: 0x060045C9 RID: 17865 RVA: 0x0008BAD0 File Offset: 0x00089CD0
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float 垂直视角灵敏度
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateCameraSensitivity.__PropertyOffset_垂直视角灵敏度);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateCameraSensitivity.__PropertyOffset_垂直视角灵敏度) = value;
		}
	}

	// Token: 0x1700036F RID: 879
	// (get) Token: 0x060045CA RID: 17866 RVA: 0x0008BAE1 File Offset: 0x00089CE1
	// (set) Token: 0x060045CB RID: 17867 RVA: 0x0008BAF1 File Offset: 0x00089CF1
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float 瞄准水平视角灵敏度
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateCameraSensitivity.__PropertyOffset_瞄准水平视角灵敏度);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateCameraSensitivity.__PropertyOffset_瞄准水平视角灵敏度) = value;
		}
	}

	// Token: 0x17000370 RID: 880
	// (get) Token: 0x060045CC RID: 17868 RVA: 0x0008BB02 File Offset: 0x00089D02
	// (set) Token: 0x060045CD RID: 17869 RVA: 0x0008BB12 File Offset: 0x00089D12
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float 瞄准垂直视角灵敏度
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateCameraSensitivity.__PropertyOffset_瞄准垂直视角灵敏度);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateCameraSensitivity.__PropertyOffset_瞄准垂直视角灵敏度) = value;
		}
	}

	// Token: 0x060045CE RID: 17870 RVA: 0x0008BB24 File Offset: 0x00089D24
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

	// Token: 0x060045CF RID: 17871 RVA: 0x0008BBCC File Offset: 0x00089DCC
	[NullableContext(2)]
	protected unsafe virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		AActor owner = meshComp.GetOwner();
		if (!(owner is TsBaseCharacter))
		{
			return false;
		}
		CharacterActorComponent characterActorComponent = (owner as TsBaseCharacter).CharacterActorComponent;
		if (characterActorComponent == null || !characterActorComponent.Valid || !characterActorComponent.IsAutonomousProxy)
		{
			return false;
		}
		if (ModelBase<CameraModel>.Instance == null)
		{
			return false;
		}
		ModelBase<CameraModel>.Instance.MainModel.IsEnableSpecificCameraSensitivity = true;
		ModelBase<CameraModel>.Instance.MainModel.SpecificCameraBaseYawSensitivity = this.水平视角灵敏度;
		ModelBase<CameraModel>.Instance.MainModel.SpecificCameraBasePitchSensitivity = this.垂直视角灵敏度;
		ModelBase<CameraModel>.Instance.MainModel.SpecificCameraAimingYawSensitivity = this.瞄准水平视角灵敏度;
		ModelBase<CameraModel>.Instance.MainModel.SpecificCameraAimingPitchSensitivity = this.瞄准垂直视角灵敏度;
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Camera;
		ELogAuthor author = ELogAuthor.LJM;
		string message = "[CameraSensitivity Ans Start]";
		<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("水平视角灵敏度", this.水平视角灵敏度);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("垂直视角灵敏度", this.垂直视角灵敏度);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("瞄准水平视角灵敏度", this.瞄准水平视角灵敏度);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("瞄准垂直视角灵敏度", this.瞄准垂直视角灵敏度);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
		return true;
	}

	// Token: 0x060045D0 RID: 17872 RVA: 0x0008BD2C File Offset: 0x00089F2C
	[NullableContext(2)]
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

	// Token: 0x060045D1 RID: 17873 RVA: 0x0008BDCC File Offset: 0x00089FCC
	[NullableContext(2)]
	protected virtual bool K2_NotifyEnd_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		AActor owner = meshComp.GetOwner();
		if (!(owner is TsBaseCharacter))
		{
			return false;
		}
		CharacterActorComponent characterActorComponent = (owner as TsBaseCharacter).CharacterActorComponent;
		if (characterActorComponent == null || !characterActorComponent.Valid || !characterActorComponent.IsAutonomousProxy)
		{
			return false;
		}
		if (ModelBase<CameraModel>.Instance == null)
		{
			return false;
		}
		ModelBase<CameraModel>.Instance.MainModel.IsEnableSpecificCameraSensitivity = false;
		Singleton<Log>.Instance.Info(ELogModule.Camera, ELogAuthor.LJM, "[CameraSensitivity Ans Stop]", default(ReadOnlySpan<ValueTuple<string, object>>));
		return true;
	}

	// Token: 0x060045D2 RID: 17874 RVA: 0x0008BE48 File Offset: 0x0008A048
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

	// Token: 0x060045D3 RID: 17875 RVA: 0x0008BEC3 File Offset: 0x0008A0C3
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "设置镜头灵敏度";
	}

	// Token: 0x060045D4 RID: 17876 RVA: 0x0008BECA File Offset: 0x0008A0CA
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStateCameraSensitivity._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateCameraSensitivity.TsAnimNotifyStateCameraSensitivity_C");
		}
		return TsAnimNotifyStateCameraSensitivity._ClassPtr;
	}

	// Token: 0x060045D5 RID: 17877 RVA: 0x0008BEF0 File Offset: 0x0008A0F0
	public TsAnimNotifyStateCameraSensitivity() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateCameraSensitivity.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x060045D6 RID: 17878 RVA: 0x0008BF18 File Offset: 0x0008A118
	[NullableContext(1)]
	public TsAnimNotifyStateCameraSensitivity(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateCameraSensitivity.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x060045D7 RID: 17879 RVA: 0x0008BF4B File Offset: 0x0008A14B
	protected TsAnimNotifyStateCameraSensitivity(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x060045D8 RID: 17880 RVA: 0x0008BF54 File Offset: 0x0008A154
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x060045D9 RID: 17881 RVA: 0x0008BF90 File Offset: 0x0008A190
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x060045DA RID: 17882 RVA: 0x0008BFC3 File Offset: 0x0008A1C3
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotifyState.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x040012C6 RID: 4806
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateCameraSensitivity.TsAnimNotifyStateCameraSensitivity_C";

	// Token: 0x040012C7 RID: 4807
	private static IntPtr _ClassPtr;

	// Token: 0x040012C8 RID: 4808
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x040012C9 RID: 4809
	private static int __PropertyOffset_水平视角灵敏度;

	// Token: 0x040012CA RID: 4810
	private static int __PropertyOffset_垂直视角灵敏度;

	// Token: 0x040012CB RID: 4811
	private static int __PropertyOffset_瞄准水平视角灵敏度;

	// Token: 0x040012CC RID: 4812
	private static int __PropertyOffset_瞄准垂直视角灵敏度;
}
