using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.Input.Enum;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000D36 RID: 3382
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateClearInputCache.TsAnimNotifyStateClearInputCache_C")]
public class TsAnimNotifyStateClearInputCache : TsAnimNotifyStateBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x1700037F RID: 895
	// (get) Token: 0x0600464C RID: 17996 RVA: 0x0008E04B File Offset: 0x0008C24B
	// (set) Token: 0x0600464D RID: 17997 RVA: 0x0008E05B File Offset: 0x0008C25B
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe EInputAction InputAction
	{
		get
		{
			return (EInputAction)(*(base.NativePtr + (IntPtr)TsAnimNotifyStateClearInputCache.__PropertyOffset_InputAction));
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateClearInputCache.__PropertyOffset_InputAction) = (byte)value;
		}
	}

	// Token: 0x17000380 RID: 896
	// (get) Token: 0x0600464E RID: 17998 RVA: 0x0008E06C File Offset: 0x0008C26C
	// (set) Token: 0x0600464F RID: 17999 RVA: 0x0008E07C File Offset: 0x0008C27C
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe EInputState InputState
	{
		get
		{
			return (EInputState)(*(base.NativePtr + (IntPtr)TsAnimNotifyStateClearInputCache.__PropertyOffset_InputState));
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateClearInputCache.__PropertyOffset_InputState) = (byte)value;
		}
	}

	// Token: 0x06004650 RID: 18000 RVA: 0x0008E090 File Offset: 0x0008C290
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

	// Token: 0x06004651 RID: 18001 RVA: 0x0008E130 File Offset: 0x0008C330
	[NullableContext(2)]
	protected virtual bool K2_NotifyEnd_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		AActor owner = meshComp.GetOwner();
		if (owner is TsBaseCharacter)
		{
			CharacterInputComponent component = (owner as TsBaseCharacter).CharacterActorComponent.Entity.GetComponent<CharacterInputComponent>();
			if (component != null)
			{
				component.ClearInputCache((int)this.InputAction, this.InputState);
			}
		}
		return true;
	}

	// Token: 0x06004652 RID: 18002 RVA: 0x0008E178 File Offset: 0x0008C378
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStateClearInputCache._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateClearInputCache.TsAnimNotifyStateClearInputCache_C");
		}
		return TsAnimNotifyStateClearInputCache._ClassPtr;
	}

	// Token: 0x06004653 RID: 18003 RVA: 0x0008E19C File Offset: 0x0008C39C
	public TsAnimNotifyStateClearInputCache() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateClearInputCache.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004654 RID: 18004 RVA: 0x0008E1C4 File Offset: 0x0008C3C4
	[NullableContext(1)]
	public TsAnimNotifyStateClearInputCache(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateClearInputCache.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004655 RID: 18005 RVA: 0x0008E1F7 File Offset: 0x0008C3F7
	protected TsAnimNotifyStateClearInputCache(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004656 RID: 18006 RVA: 0x0008E200 File Offset: 0x0008C400
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x040012F9 RID: 4857
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateClearInputCache.TsAnimNotifyStateClearInputCache_C";

	// Token: 0x040012FA RID: 4858
	private static IntPtr _ClassPtr;

	// Token: 0x040012FB RID: 4859
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x040012FC RID: 4860
	private static int __PropertyOffset_InputAction;

	// Token: 0x040012FD RID: 4861
	private static int __PropertyOffset_InputState;
}
