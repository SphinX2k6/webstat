using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02003426 RID: 13350
[UClass("/Game/Aki/TypeScript/Game/Render/Scene/Item/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/Render/Scene/Item/AnimNotifyDaiyuAnimEnd.AnimNotifyDaiyuAnimEnd_C")]
public class AnimNotifyDaiyuAnimEnd : UKuroAnimNotify, IUnrealUObject, IUnrealObject
{
	// Token: 0x0601BDD3 RID: 114131 RVA: 0x0084EBD4 File Offset: 0x0084CDD4
	[NullableContext(1)]
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

	// Token: 0x0601BDD4 RID: 114132 RVA: 0x0084EC74 File Offset: 0x0084CE74
	[NullableContext(1)]
	protected virtual bool K2_Notify_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		if (!meshComp.IsVisible())
		{
			return false;
		}
		AActor owner = meshComp.GetOwner();
		SceneInteractionActor sceneInteractionActor = ((owner != null) ? owner.GetAttachParentActor() : null) as SceneInteractionActor;
		if (sceneInteractionActor != null)
		{
			sceneInteractionActor.OnAnimPlayEnd(animation.GetName());
		}
		return true;
	}

	// Token: 0x0601BDD5 RID: 114133 RVA: 0x0084ECB3 File Offset: 0x0084CEB3
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (AnimNotifyDaiyuAnimEnd._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/Render/Scene/Item/AnimNotifyDaiyuAnimEnd.AnimNotifyDaiyuAnimEnd_C");
		}
		return AnimNotifyDaiyuAnimEnd._ClassPtr;
	}

	// Token: 0x0601BDD6 RID: 114134 RVA: 0x0084ECD8 File Offset: 0x0084CED8
	public AnimNotifyDaiyuAnimEnd() : this(BuiltinUtils.AllocNativeUObject(AnimNotifyDaiyuAnimEnd.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0601BDD7 RID: 114135 RVA: 0x0084ED00 File Offset: 0x0084CF00
	[NullableContext(1)]
	public AnimNotifyDaiyuAnimEnd(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(AnimNotifyDaiyuAnimEnd.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601BDD8 RID: 114136 RVA: 0x0084ED33 File Offset: 0x0084CF33
	protected AnimNotifyDaiyuAnimEnd(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601BDD9 RID: 114137 RVA: 0x0084ED3C File Offset: 0x0084CF3C
	protected unsafe virtual void __CPPCALL_K2_Notify_Implementation(UKuroAnimNotify.__K2_Notify_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_Notify_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x0400E12D RID: 57645
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/Render/Scene/Item/AnimNotifyDaiyuAnimEnd.AnimNotifyDaiyuAnimEnd_C";

	// Token: 0x0400E12E RID: 57646
	private static IntPtr _ClassPtr;

	// Token: 0x0400E12F RID: 57647
	private static IntPtr _ClassDefaultObjectPtr;
}
