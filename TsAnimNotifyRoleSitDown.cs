using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000DE7 RID: 3559
[UClass("/Game/Aki/TypeScript/Game/AnimNotify/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyRoleSitDown.TsAnimNotifyRoleSitDown_C")]
public class TsAnimNotifyRoleSitDown : TsAnimNotifyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x06005204 RID: 20996 RVA: 0x000BF508 File Offset: 0x000BD708
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

	// Token: 0x06005205 RID: 20997 RVA: 0x000BF5A8 File Offset: 0x000BD7A8
	[NullableContext(2)]
	protected virtual bool K2_Notify_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		TsBaseCharacter tsBaseCharacter = meshComp.GetOwner() as TsBaseCharacter;
		if (tsBaseCharacter != null)
		{
			CharacterActionComponent component = tsBaseCharacter.CharacterActorComponent.Entity.GetComponent<CharacterActionComponent>();
			if (component != null)
			{
				component.DoSitDownAction();
				return true;
			}
			NpcSitOnChairComponent component2 = tsBaseCharacter.CharacterActorComponent.Entity.GetComponent<NpcSitOnChairComponent>();
			if (((component2 != null) ? component2.CurrentChairEntity : null) != null)
			{
				component2.DoSitDownAction(component2.CurrentChairEntity);
			}
		}
		return true;
	}

	// Token: 0x06005206 RID: 20998 RVA: 0x000BF60C File Offset: 0x000BD80C
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

	// Token: 0x06005207 RID: 20999 RVA: 0x000BF687 File Offset: 0x000BD887
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "角色坐下";
	}

	// Token: 0x06005208 RID: 21000 RVA: 0x000BF68E File Offset: 0x000BD88E
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyRoleSitDown._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyRoleSitDown.TsAnimNotifyRoleSitDown_C");
		}
		return TsAnimNotifyRoleSitDown._ClassPtr;
	}

	// Token: 0x06005209 RID: 21001 RVA: 0x000BF6B4 File Offset: 0x000BD8B4
	public TsAnimNotifyRoleSitDown() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyRoleSitDown.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0600520A RID: 21002 RVA: 0x000BF6DC File Offset: 0x000BD8DC
	[NullableContext(1)]
	public TsAnimNotifyRoleSitDown(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyRoleSitDown.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0600520B RID: 21003 RVA: 0x000BF70F File Offset: 0x000BD90F
	protected TsAnimNotifyRoleSitDown(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0600520C RID: 21004 RVA: 0x000BF718 File Offset: 0x000BD918
	protected unsafe virtual void __CPPCALL_K2_Notify_Implementation(UKuroAnimNotify.__K2_Notify_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_Notify_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x0600520D RID: 21005 RVA: 0x000BF74B File Offset: 0x000BD94B
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotify.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x04001823 RID: 6179
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyRoleSitDown.TsAnimNotifyRoleSitDown_C";

	// Token: 0x04001824 RID: 6180
	private static IntPtr _ClassPtr;

	// Token: 0x04001825 RID: 6181
	private static IntPtr _ClassDefaultObjectPtr;
}
