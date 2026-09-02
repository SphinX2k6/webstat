using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000DED RID: 3565
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AnimNotify/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifySetTransformWithModelBuffer.TsAnimNotifySetTransformWithModelBuffer_C")]
public class TsAnimNotifySetTransformWithModelBuffer : TsAnimNotifyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x1700056C RID: 1388
	// (get) Token: 0x0600524C RID: 21068 RVA: 0x000C03F3 File Offset: 0x000BE5F3
	// (set) Token: 0x0600524D RID: 21069 RVA: 0x000C0407 File Offset: 0x000BE607
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string LocationKey
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsAnimNotifySetTransformWithModelBuffer.__PropertyOffset_LocationKey)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsAnimNotifySetTransformWithModelBuffer.__PropertyOffset_LocationKey)), value);
		}
	}

	// Token: 0x1700056D RID: 1389
	// (get) Token: 0x0600524E RID: 21070 RVA: 0x000C041C File Offset: 0x000BE61C
	// (set) Token: 0x0600524F RID: 21071 RVA: 0x000C0430 File Offset: 0x000BE630
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string RotatorKey
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsAnimNotifySetTransformWithModelBuffer.__PropertyOffset_RotatorKey)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsAnimNotifySetTransformWithModelBuffer.__PropertyOffset_RotatorKey)), value);
		}
	}

	// Token: 0x1700056E RID: 1390
	// (get) Token: 0x06005250 RID: 21072 RVA: 0x000C0445 File Offset: 0x000BE645
	// (set) Token: 0x06005251 RID: 21073 RVA: 0x000C0455 File Offset: 0x000BE655
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float TimeLength
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifySetTransformWithModelBuffer.__PropertyOffset_TimeLength);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifySetTransformWithModelBuffer.__PropertyOffset_TimeLength) = value;
		}
	}

	// Token: 0x06005252 RID: 21074 RVA: 0x000C0468 File Offset: 0x000BE668
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

	// Token: 0x06005253 RID: 21075 RVA: 0x000C0508 File Offset: 0x000BE708
	[NullableContext(2)]
	protected virtual bool K2_Notify_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		AActor owner = meshComp.GetOwner();
		if (!(owner is TsBaseCharacter))
		{
			return false;
		}
		CharacterActorComponent characterActorComponent = (owner as TsBaseCharacter).CharacterActorComponent;
		Entity entity = characterActorComponent.Entity;
		FTransformDouble ftransformDouble = (owner as TsBaseCharacter).D_GetTransform();
		if (!string.IsNullOrEmpty(this.LocationKey))
		{
			Aki.Protocol.Vector vectorValueByEntity = ControllerBase<BlackboardController>.Instance.GetVectorValueByEntity(entity.Id, this.LocationKey);
			if (vectorValueByEntity != null)
			{
				FVectorDouble fvectorDouble = WorldGlobal.ToUeVector(vectorValueByEntity);
				ftransformDouble.SetLocation(fvectorDouble);
			}
		}
		if (!string.IsNullOrEmpty(this.RotatorKey))
		{
			Aki.Protocol.Rotator rotatorValueByEntity = ControllerBase<BlackboardController>.Instance.GetRotatorValueByEntity(entity.Id, this.RotatorKey);
			if (rotatorValueByEntity != null)
			{
				FQuat fquat = WorldGlobal.ToUeRotator(rotatorValueByEntity).Quaternion();
				ftransformDouble.SetRotation(fquat);
			}
		}
		CharacterAnimationComponent component = entity.GetComponent<CharacterAnimationComponent>();
		if (component == null || !component.Valid)
		{
			characterActorComponent.SetActorTransform(ftransformDouble, "TsAnimNotifySetTransformWithModelBuffer", true, null);
		}
		else
		{
			component.SetTransformWithModelBuffer(ftransformDouble, this.TimeLength, null, true);
		}
		return true;
	}

	// Token: 0x06005254 RID: 21076 RVA: 0x000C0614 File Offset: 0x000BE814
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

	// Token: 0x06005255 RID: 21077 RVA: 0x000C068F File Offset: 0x000BE88F
	protected override string GetNotifyName_Implementation()
	{
		return "怪物趴墙";
	}

	// Token: 0x06005256 RID: 21078 RVA: 0x000C0696 File Offset: 0x000BE896
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifySetTransformWithModelBuffer._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifySetTransformWithModelBuffer.TsAnimNotifySetTransformWithModelBuffer_C");
		}
		return TsAnimNotifySetTransformWithModelBuffer._ClassPtr;
	}

	// Token: 0x06005257 RID: 21079 RVA: 0x000C06BC File Offset: 0x000BE8BC
	public TsAnimNotifySetTransformWithModelBuffer() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifySetTransformWithModelBuffer.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06005258 RID: 21080 RVA: 0x000C06E4 File Offset: 0x000BE8E4
	public TsAnimNotifySetTransformWithModelBuffer(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifySetTransformWithModelBuffer.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06005259 RID: 21081 RVA: 0x000C0717 File Offset: 0x000BE917
	protected TsAnimNotifySetTransformWithModelBuffer(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0600525A RID: 21082 RVA: 0x000C0720 File Offset: 0x000BE920
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_Notify_Implementation(UKuroAnimNotify.__K2_Notify_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_Notify_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x0600525B RID: 21083 RVA: 0x000C0753 File Offset: 0x000BE953
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotify.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x0400183B RID: 6203
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifySetTransformWithModelBuffer.TsAnimNotifySetTransformWithModelBuffer_C";

	// Token: 0x0400183C RID: 6204
	private static IntPtr _ClassPtr;

	// Token: 0x0400183D RID: 6205
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400183E RID: 6206
	private static int __PropertyOffset_LocationKey;

	// Token: 0x0400183F RID: 6207
	private static int __PropertyOffset_RotatorKey;

	// Token: 0x04001840 RID: 6208
	private static int __PropertyOffset_TimeLength;
}
