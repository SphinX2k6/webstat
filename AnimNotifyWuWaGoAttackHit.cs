using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.WuwaGo;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02002D77 RID: 11639
[UClass("/Game/Aki/TypeScript/Game/Module/WuwaGo/AnimNotify/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/Module/WuwaGo/AnimNotify/AnimNotifyWuWaGoAttackHit.AnimNotifyWuWaGoAttackHit_C")]
public class AnimNotifyWuWaGoAttackHit : UKuroAnimNotify, IUnrealUObject, IUnrealObject
{
	// Token: 0x060177C6 RID: 96198 RVA: 0x0068225C File Offset: 0x0068045C
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

	// Token: 0x060177C7 RID: 96199 RVA: 0x006822FC File Offset: 0x006804FC
	[NullableContext(2)]
	protected bool K2_Notify_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		AActor owner = meshComp.GetOwner();
		if (owner == null || !owner.IsValid())
		{
			return false;
		}
		WuWaGoFactory.DispatchAttackHit(owner);
		return true;
	}

	// Token: 0x060177C8 RID: 96200 RVA: 0x0068232A File Offset: 0x0068052A
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (AnimNotifyWuWaGoAttackHit._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/Module/WuwaGo/AnimNotify/AnimNotifyWuWaGoAttackHit.AnimNotifyWuWaGoAttackHit_C");
		}
		return AnimNotifyWuWaGoAttackHit._ClassPtr;
	}

	// Token: 0x060177C9 RID: 96201 RVA: 0x00682350 File Offset: 0x00680550
	public AnimNotifyWuWaGoAttackHit() : this(BuiltinUtils.AllocNativeUObject(AnimNotifyWuWaGoAttackHit.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x060177CA RID: 96202 RVA: 0x00682378 File Offset: 0x00680578
	[NullableContext(1)]
	public AnimNotifyWuWaGoAttackHit(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(AnimNotifyWuWaGoAttackHit.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x060177CB RID: 96203 RVA: 0x006823AB File Offset: 0x006805AB
	protected AnimNotifyWuWaGoAttackHit(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x060177CC RID: 96204 RVA: 0x006823B4 File Offset: 0x006805B4
	protected unsafe virtual void __CPPCALL_K2_Notify_Implementation(UKuroAnimNotify.__K2_Notify_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_Notify_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x0400B413 RID: 46099
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/Module/WuwaGo/AnimNotify/AnimNotifyWuWaGoAttackHit.AnimNotifyWuWaGoAttackHit_C";

	// Token: 0x0400B414 RID: 46100
	private static IntPtr _ClassPtr;

	// Token: 0x0400B415 RID: 46101
	private static IntPtr _ClassDefaultObjectPtr;
}
