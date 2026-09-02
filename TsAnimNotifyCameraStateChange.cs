using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game;
using CSharpScript.Game.Camera;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000DB4 RID: 3508
[UClass("/Game/Aki/TypeScript/Game/AnimNotify/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyCameraStateChange.TsAnimNotifyCameraStateChange_C")]
public class TsAnimNotifyCameraStateChange : TsAnimNotifyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000505 RID: 1285
	// (get) Token: 0x06004F4F RID: 20303 RVA: 0x000B5FD3 File Offset: 0x000B41D3
	// (set) Token: 0x06004F50 RID: 20304 RVA: 0x000B5FE3 File Offset: 0x000B41E3
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool 是否为单客户端
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyCameraStateChange.__PropertyOffset_是否为单客户端) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyCameraStateChange.__PropertyOffset_是否为单客户端) = (value ? 1 : 0);
		}
	}

	// Token: 0x17000506 RID: 1286
	// (get) Token: 0x06004F51 RID: 20305 RVA: 0x000B5FF4 File Offset: 0x000B41F4
	// (set) Token: 0x06004F52 RID: 20306 RVA: 0x000B6004 File Offset: 0x000B4204
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool 是否跟随
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyCameraStateChange.__PropertyOffset_是否跟随) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyCameraStateChange.__PropertyOffset_是否跟随) = (value ? 1 : 0);
		}
	}

	// Token: 0x06004F53 RID: 20307 RVA: 0x000B6018 File Offset: 0x000B4218
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override bool K2_Notify(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("K2_Notify"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UKuroAnimNotify.__K2_Notify_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UKuroAnimNotify.__K2_Notify_FunctionParams*)ptr + 15L / (long)sizeof(UKuroAnimNotify.__K2_Notify_FunctionParams) & -16L);
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

	// Token: 0x06004F54 RID: 20308 RVA: 0x000B60B8 File Offset: 0x000B42B8
	[NullableContext(2)]
	protected virtual bool K2_Notify_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		AActor owner = meshComp.GetOwner();
		if (this.是否为单客户端)
		{
			TsBaseCharacter tsBaseCharacter = owner as TsBaseCharacter;
			if (tsBaseCharacter == null || tsBaseCharacter != Global.BaseCharacter)
			{
				return true;
			}
		}
		ControllerBase<CameraController>.Instance.MainModel.FightCamera.LogicComponent.IsFollowing = this.是否跟随;
		return true;
	}

	// Token: 0x06004F55 RID: 20309 RVA: 0x000B6108 File Offset: 0x000B4308
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override string GetNotifyName()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("GetNotifyName"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UAnimNotify.__GetNotifyName_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UAnimNotify.__GetNotifyName_FunctionParams*)ptr + 15L / (long)sizeof(UAnimNotify.__GetNotifyName_FunctionParams) & -16L);
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

	// Token: 0x06004F56 RID: 20310 RVA: 0x000B6183 File Offset: 0x000B4383
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "摄像机状态改变";
	}

	// Token: 0x06004F57 RID: 20311 RVA: 0x000B618A File Offset: 0x000B438A
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyCameraStateChange._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyCameraStateChange.TsAnimNotifyCameraStateChange_C");
		}
		return TsAnimNotifyCameraStateChange._ClassPtr;
	}

	// Token: 0x06004F58 RID: 20312 RVA: 0x000B61B0 File Offset: 0x000B43B0
	public TsAnimNotifyCameraStateChange() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyCameraStateChange.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004F59 RID: 20313 RVA: 0x000B61D8 File Offset: 0x000B43D8
	[NullableContext(1)]
	public TsAnimNotifyCameraStateChange(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyCameraStateChange.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004F5A RID: 20314 RVA: 0x000B620B File Offset: 0x000B440B
	protected TsAnimNotifyCameraStateChange(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004F5B RID: 20315 RVA: 0x000B6214 File Offset: 0x000B4414
	protected unsafe virtual void __CPPCALL_K2_Notify_Implementation(UKuroAnimNotify.__K2_Notify_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_Notify_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06004F5C RID: 20316 RVA: 0x000B6247 File Offset: 0x000B4447
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotify.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x0400171A RID: 5914
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyCameraStateChange.TsAnimNotifyCameraStateChange_C";

	// Token: 0x0400171B RID: 5915
	private static IntPtr _ClassPtr;

	// Token: 0x0400171C RID: 5916
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400171D RID: 5917
	private static int __PropertyOffset_是否为单客户端;

	// Token: 0x0400171E RID: 5918
	private static int __PropertyOffset_是否跟随;
}
