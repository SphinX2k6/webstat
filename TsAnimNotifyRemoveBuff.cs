using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.CombatMessage;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000DDE RID: 3550
[UClass("/Game/Aki/TypeScript/Game/AnimNotify/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyRemoveBuff.TsAnimNotifyRemoveBuff_C")]
public class TsAnimNotifyRemoveBuff : TsAnimNotifyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x1700054A RID: 1354
	// (get) Token: 0x06005176 RID: 20854 RVA: 0x000BD533 File Offset: 0x000BB733
	// (set) Token: 0x06005177 RID: 20855 RVA: 0x000BD543 File Offset: 0x000BB743
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe long BuffId
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyRemoveBuff.__PropertyOffset_BuffId);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyRemoveBuff.__PropertyOffset_BuffId) = value;
		}
	}

	// Token: 0x1700054B RID: 1355
	// (get) Token: 0x06005178 RID: 20856 RVA: 0x000BD554 File Offset: 0x000BB754
	// (set) Token: 0x06005179 RID: 20857 RVA: 0x000BD564 File Offset: 0x000BB764
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int StackCount
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyRemoveBuff.__PropertyOffset_StackCount);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyRemoveBuff.__PropertyOffset_StackCount) = value;
		}
	}

	// Token: 0x0600517A RID: 20858 RVA: 0x000BD578 File Offset: 0x000BB778
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public override bool K2_Notify(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
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
			component.RemoveBuff(this.BuffId, this.StackCount, "动画" + animation.GetName() + "的AN移除", preMessageId, null, null);
		}
		return true;
	}

	// Token: 0x0600517B RID: 20859 RVA: 0x000BD63A File Offset: 0x000BB83A
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public override string GetNotifyName()
	{
		return "移除BUFF";
	}

	// Token: 0x0600517C RID: 20860 RVA: 0x000BD641 File Offset: 0x000BB841
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyRemoveBuff._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyRemoveBuff.TsAnimNotifyRemoveBuff_C");
		}
		return TsAnimNotifyRemoveBuff._ClassPtr;
	}

	// Token: 0x0600517D RID: 20861 RVA: 0x000BD668 File Offset: 0x000BB868
	public TsAnimNotifyRemoveBuff() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyRemoveBuff.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0600517E RID: 20862 RVA: 0x000BD690 File Offset: 0x000BB890
	[NullableContext(1)]
	public TsAnimNotifyRemoveBuff(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyRemoveBuff.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0600517F RID: 20863 RVA: 0x000BD6C3 File Offset: 0x000BB8C3
	protected TsAnimNotifyRemoveBuff(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06005180 RID: 20864 RVA: 0x000BD6CC File Offset: 0x000BB8CC
	protected unsafe virtual void __CPPCALL_K2_Notify_Implementation(UKuroAnimNotify.__K2_Notify_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_Notify(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06005181 RID: 20865 RVA: 0x000BD6FF File Offset: 0x000BB8FF
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotify.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName());
	}

	// Token: 0x040017E6 RID: 6118
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyRemoveBuff.TsAnimNotifyRemoveBuff_C";

	// Token: 0x040017E7 RID: 6119
	private static IntPtr _ClassPtr;

	// Token: 0x040017E8 RID: 6120
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x040017E9 RID: 6121
	private static int __PropertyOffset_BuffId;

	// Token: 0x040017EA RID: 6122
	private static int __PropertyOffset_StackCount;
}
