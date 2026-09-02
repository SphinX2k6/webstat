using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game;
using CSharpScript.Game.Camera;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000D31 RID: 3377
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateCameraStateChange.TsAnimNotifyStateCameraStateChange_C")]
public class TsAnimNotifyStateCameraStateChange : TsAnimNotifyStateBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000373 RID: 883
	// (get) Token: 0x060045EC RID: 17900 RVA: 0x0008C5A7 File Offset: 0x0008A7A7
	// (set) Token: 0x060045ED RID: 17901 RVA: 0x0008C5B7 File Offset: 0x0008A7B7
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool 是否为单客户端
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateCameraStateChange.__PropertyOffset_是否为单客户端) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateCameraStateChange.__PropertyOffset_是否为单客户端) = (value ? 1 : 0);
		}
	}

	// Token: 0x17000374 RID: 884
	// (get) Token: 0x060045EE RID: 17902 RVA: 0x0008C5C8 File Offset: 0x0008A7C8
	// (set) Token: 0x060045EF RID: 17903 RVA: 0x0008C5D8 File Offset: 0x0008A7D8
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool 是否跟随
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateCameraStateChange.__PropertyOffset_是否跟随) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateCameraStateChange.__PropertyOffset_是否跟随) = (value ? 1 : 0);
		}
	}

	// Token: 0x17000375 RID: 885
	// (get) Token: 0x060045F0 RID: 17904 RVA: 0x0008C5E9 File Offset: 0x0008A7E9
	// (set) Token: 0x060045F1 RID: 17905 RVA: 0x0008C5F9 File Offset: 0x0008A7F9
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool 切人时恢复跟随
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateCameraStateChange.__PropertyOffset_切人时恢复跟随) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateCameraStateChange.__PropertyOffset_切人时恢复跟随) = (value ? 1 : 0);
		}
	}

	// Token: 0x060045F2 RID: 17906 RVA: 0x0008C60C File Offset: 0x0008A80C
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

	// Token: 0x060045F3 RID: 17907 RVA: 0x0008C6B4 File Offset: 0x0008A8B4
	[NullableContext(2)]
	protected virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		AActor owner = meshComp.GetOwner();
		if (!this.是否为单客户端 || (owner is TsBaseCharacter && Global.BaseCharacter == owner))
		{
			ControllerBase<CameraController>.Instance.MainModel.FightCamera.LogicComponent.IsFollowing = this.是否跟随;
			ControllerBase<CameraController>.Instance.MainModel.FightCamera.LogicComponent.RestoreFollowingOnChangeRole = this.切人时恢复跟随;
			return true;
		}
		return false;
	}

	// Token: 0x060045F4 RID: 17908 RVA: 0x0008C724 File Offset: 0x0008A924
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

	// Token: 0x060045F5 RID: 17909 RVA: 0x0008C7C4 File Offset: 0x0008A9C4
	[NullableContext(2)]
	protected virtual bool K2_NotifyEnd_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		AActor owner = meshComp.GetOwner();
		if (!this.是否为单客户端 || (owner is TsBaseCharacter && Global.BaseCharacter == owner))
		{
			ControllerBase<CameraController>.Instance.MainModel.FightCamera.LogicComponent.IsFollowing = true;
			return true;
		}
		return false;
	}

	// Token: 0x060045F6 RID: 17910 RVA: 0x0008C810 File Offset: 0x0008AA10
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

	// Token: 0x060045F7 RID: 17911 RVA: 0x0008C88B File Offset: 0x0008AA8B
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "相机是否跟随角色移动";
	}

	// Token: 0x060045F8 RID: 17912 RVA: 0x0008C892 File Offset: 0x0008AA92
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStateCameraStateChange._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateCameraStateChange.TsAnimNotifyStateCameraStateChange_C");
		}
		return TsAnimNotifyStateCameraStateChange._ClassPtr;
	}

	// Token: 0x060045F9 RID: 17913 RVA: 0x0008C8B8 File Offset: 0x0008AAB8
	public TsAnimNotifyStateCameraStateChange() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateCameraStateChange.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x060045FA RID: 17914 RVA: 0x0008C8E0 File Offset: 0x0008AAE0
	[NullableContext(1)]
	public TsAnimNotifyStateCameraStateChange(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateCameraStateChange.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x060045FB RID: 17915 RVA: 0x0008C913 File Offset: 0x0008AB13
	protected TsAnimNotifyStateCameraStateChange(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x060045FC RID: 17916 RVA: 0x0008C91C File Offset: 0x0008AB1C
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x060045FD RID: 17917 RVA: 0x0008C958 File Offset: 0x0008AB58
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x060045FE RID: 17918 RVA: 0x0008C98B File Offset: 0x0008AB8B
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotifyState.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x040012D5 RID: 4821
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateCameraStateChange.TsAnimNotifyStateCameraStateChange_C";

	// Token: 0x040012D6 RID: 4822
	private static IntPtr _ClassPtr;

	// Token: 0x040012D7 RID: 4823
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x040012D8 RID: 4824
	private static int __PropertyOffset_是否为单客户端;

	// Token: 0x040012D9 RID: 4825
	private static int __PropertyOffset_是否跟随;

	// Token: 0x040012DA RID: 4826
	private static int __PropertyOffset_切人时恢复跟随;
}
