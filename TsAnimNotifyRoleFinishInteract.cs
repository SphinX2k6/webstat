using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Role.Enum;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000DE5 RID: 3557
[UClass("/Game/Aki/TypeScript/Game/AnimNotify/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyRoleFinishInteract.TsAnimNotifyRoleFinishInteract_C")]
public class TsAnimNotifyRoleFinishInteract : TsAnimNotifyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000563 RID: 1379
	// (get) Token: 0x060051EA RID: 20970 RVA: 0x000BEFF7 File Offset: 0x000BD1F7
	// (set) Token: 0x060051EB RID: 20971 RVA: 0x000BF007 File Offset: 0x000BD207
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe ERoleInteractType Type
	{
		get
		{
			return (ERoleInteractType)(*(base.NativePtr + (IntPtr)TsAnimNotifyRoleFinishInteract.__PropertyOffset_Type));
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyRoleFinishInteract.__PropertyOffset_Type) = (byte)value;
		}
	}

	// Token: 0x060051EC RID: 20972 RVA: 0x000BF018 File Offset: 0x000BD218
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override bool K2_Notify(USkeletalMeshComponent MeshComp, UAnimSequenceBase Animation)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("K2_Notify"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UKuroAnimNotify.__K2_Notify_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UKuroAnimNotify.__K2_Notify_FunctionParams*)ptr + 15L / (long)sizeof(UKuroAnimNotify.__K2_Notify_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->MeshComp) = ((MeshComp != null) ? MeshComp.NativePtr : ((IntPtr)0));
			*(&ptr2->Animation) = ((Animation != null) ? Animation.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x060051ED RID: 20973 RVA: 0x000BF0B8 File Offset: 0x000BD2B8
	[NullableContext(2)]
	protected virtual bool K2_Notify_Implementation(USkeletalMeshComponent MeshComp, UAnimSequenceBase Animation)
	{
		TsBaseCharacter tsBaseCharacter = MeshComp.GetOwner() as TsBaseCharacter;
		if (tsBaseCharacter != null)
		{
			CharacterActionComponent component = tsBaseCharacter.CharacterActorComponent.Entity.GetComponent<CharacterActionComponent>();
			if (component != null)
			{
				ERoleInteractType type = this.Type;
				if (type != ERoleInteractType.Bounce)
				{
					if (type == ERoleInteractType.Catapult)
					{
						component.EndCatapult();
					}
				}
				else
				{
					component.EndBounce();
				}
			}
		}
		return true;
	}

	// Token: 0x060051EE RID: 20974 RVA: 0x000BF108 File Offset: 0x000BD308
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

	// Token: 0x060051EF RID: 20975 RVA: 0x000BF183 File Offset: 0x000BD383
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "设置角色交互";
	}

	// Token: 0x060051F0 RID: 20976 RVA: 0x000BF18A File Offset: 0x000BD38A
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyRoleFinishInteract._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyRoleFinishInteract.TsAnimNotifyRoleFinishInteract_C");
		}
		return TsAnimNotifyRoleFinishInteract._ClassPtr;
	}

	// Token: 0x060051F1 RID: 20977 RVA: 0x000BF1B0 File Offset: 0x000BD3B0
	public TsAnimNotifyRoleFinishInteract() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyRoleFinishInteract.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x060051F2 RID: 20978 RVA: 0x000BF1D8 File Offset: 0x000BD3D8
	[NullableContext(1)]
	public TsAnimNotifyRoleFinishInteract(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyRoleFinishInteract.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x060051F3 RID: 20979 RVA: 0x000BF20B File Offset: 0x000BD40B
	protected TsAnimNotifyRoleFinishInteract(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x060051F4 RID: 20980 RVA: 0x000BF214 File Offset: 0x000BD414
	protected unsafe virtual void __CPPCALL_K2_Notify_Implementation(UKuroAnimNotify.__K2_Notify_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_Notify_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x060051F5 RID: 20981 RVA: 0x000BF247 File Offset: 0x000BD447
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotify.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x0400181A RID: 6170
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyRoleFinishInteract.TsAnimNotifyRoleFinishInteract_C";

	// Token: 0x0400181B RID: 6171
	private static IntPtr _ClassPtr;

	// Token: 0x0400181C RID: 6172
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400181D RID: 6173
	private static int __PropertyOffset_Type;
}
