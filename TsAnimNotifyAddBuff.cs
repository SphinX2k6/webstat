using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.CombatMessage;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000DA3 RID: 3491
[UClass("/Game/Aki/TypeScript/Game/AnimNotify/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyAddBuff.TsAnimNotifyAddBuff_C")]
public class TsAnimNotifyAddBuff : TsAnimNotifyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170004DA RID: 1242
	// (get) Token: 0x06004E51 RID: 20049 RVA: 0x000B2593 File Offset: 0x000B0793
	// (set) Token: 0x06004E52 RID: 20050 RVA: 0x000B25A3 File Offset: 0x000B07A3
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe long BuffId
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyAddBuff.__PropertyOffset_BuffId);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyAddBuff.__PropertyOffset_BuffId) = value;
		}
	}

	// Token: 0x06004E53 RID: 20051 RVA: 0x000B25B4 File Offset: 0x000B07B4
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

	// Token: 0x06004E54 RID: 20052 RVA: 0x000B2654 File Offset: 0x000B0854
	[NullableContext(2)]
	protected virtual bool K2_Notify_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		TsBaseCharacter tsBaseCharacter = meshComp.GetOwner() as TsBaseCharacter;
		if (tsBaseCharacter != null)
		{
			CharacterActorComponent characterActorComponent = tsBaseCharacter.CharacterActorComponent;
			Entity entity = (characterActorComponent != null) ? characterActorComponent.Entity : null;
			CreatureDataComponent creatureDataComponent = (entity != null) ? entity.GetComponent<CreatureDataComponent>() : null;
			CharacterBuffComponent component = entity.GetComponent<CharacterBuffComponent>();
			if (component == null)
			{
				return true;
			}
			if (!component.HasBuffAuthority() && !ControllerBase<SkillMessageController>.Instance.CloseMonsterServerLogic)
			{
				return true;
			}
			if (creatureDataComponent.IsRole() && !component.HasBuffAuthority())
			{
				return true;
			}
			long? preMessageId = component.CreateAnimNotifyContent(animation.GetName(), base.exportIndex);
			component.AddBuff(this.BuffId, new AddBuffParam
			{
				InstigatorId = component.CreatureDataId,
				PreMessageId = preMessageId,
				Reason = "动画" + animation.GetName() + "的AN添加"
			});
		}
		return true;
	}

	// Token: 0x06004E55 RID: 20053 RVA: 0x000B271C File Offset: 0x000B091C
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

	// Token: 0x06004E56 RID: 20054 RVA: 0x000B2797 File Offset: 0x000B0997
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "添加BUFF";
	}

	// Token: 0x06004E57 RID: 20055 RVA: 0x000B279E File Offset: 0x000B099E
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyAddBuff._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyAddBuff.TsAnimNotifyAddBuff_C");
		}
		return TsAnimNotifyAddBuff._ClassPtr;
	}

	// Token: 0x06004E58 RID: 20056 RVA: 0x000B27C4 File Offset: 0x000B09C4
	public TsAnimNotifyAddBuff() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyAddBuff.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004E59 RID: 20057 RVA: 0x000B27EC File Offset: 0x000B09EC
	[NullableContext(1)]
	public TsAnimNotifyAddBuff(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyAddBuff.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004E5A RID: 20058 RVA: 0x000B281F File Offset: 0x000B0A1F
	protected TsAnimNotifyAddBuff(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004E5B RID: 20059 RVA: 0x000B2828 File Offset: 0x000B0A28
	protected unsafe virtual void __CPPCALL_K2_Notify_Implementation(UKuroAnimNotify.__K2_Notify_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_Notify_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06004E5C RID: 20060 RVA: 0x000B285B File Offset: 0x000B0A5B
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotify.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x040016B0 RID: 5808
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyAddBuff.TsAnimNotifyAddBuff_C";

	// Token: 0x040016B1 RID: 5809
	private static IntPtr _ClassPtr;

	// Token: 0x040016B2 RID: 5810
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x040016B3 RID: 5811
	private static int __PropertyOffset_BuffId;
}
