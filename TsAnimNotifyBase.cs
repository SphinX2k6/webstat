using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000DA8 RID: 3496
[UClass("/Game/Aki/TypeScript/Game/AnimNotify/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyBase.TsAnimNotifyBase_C")]
public class TsAnimNotifyBase : UKuroAnimNotify, IUnrealUObject, IUnrealObject
{
	// Token: 0x170004E7 RID: 1255
	// (get) Token: 0x06004EA0 RID: 20128 RVA: 0x000B3B78 File Offset: 0x000B1D78
	[Nullable(1)]
	[UProperty(EPropertyFlags.CPF_None)]
	public TArray<SSkillBehaviorCondition> AN执行的前提条件
	{
		[NullableContext(1)]
		get
		{
			base.FastCheckIsValid();
			TArray<SSkillBehaviorCondition> result;
			if ((result = this._AN执行的前提条件) == null)
			{
				result = (this._AN执行的前提条件 = new TArray<SSkillBehaviorCondition>(base.NativePtr + (IntPtr)TsAnimNotifyBase.__PropertyOffset_AN执行的前提条件, this));
			}
			return result;
		}
	}

	// Token: 0x06004EA1 RID: 20129 RVA: 0x000B3BB4 File Offset: 0x000B1DB4
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override bool K2_NotifyConditionCheck(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("K2_NotifyConditionCheck"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UKuroAnimNotify.__K2_NotifyConditionCheck_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UKuroAnimNotify.__K2_NotifyConditionCheck_FunctionParams*)ptr + 15L / (long)sizeof(UKuroAnimNotify.__K2_NotifyConditionCheck_FunctionParams) & -16L);
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

	// Token: 0x06004EA2 RID: 20130 RVA: 0x000B3C54 File Offset: 0x000B1E54
	[NullableContext(2)]
	protected override bool K2_NotifyConditionCheck_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		if (this.AN执行的前提条件 == null || this.AN执行的前提条件.Num() == 0)
		{
			return true;
		}
		TsBaseCharacter tsBaseCharacter = ((meshComp != null) ? meshComp.GetOwner() : null) as TsBaseCharacter;
		if (tsBaseCharacter == null)
		{
			return false;
		}
		CharacterActorComponent characterActorComponent = tsBaseCharacter.CharacterActorComponent;
		Entity entity = (characterActorComponent != null) ? characterActorComponent.Entity : null;
		if (entity == null)
		{
			return false;
		}
		CharacterSkillComponent component = entity.GetComponent<CharacterSkillComponent>();
		Skill skill = (component != null) ? component.CurrentSkill : null;
		BeginSkillBehaviorConditionParam param = new BeginSkillBehaviorConditionParam
		{
			Entity = entity,
			SkillComponent = component,
			Skill = skill
		};
		return SkillBehaviorCondition.SatisfyGroup(this.AN执行的前提条件, string.Empty, param);
	}

	// Token: 0x06004EA3 RID: 20131 RVA: 0x000B3CE9 File Offset: 0x000B1EE9
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyBase._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyBase.TsAnimNotifyBase_C");
		}
		return TsAnimNotifyBase._ClassPtr;
	}

	// Token: 0x06004EA4 RID: 20132 RVA: 0x000B3D10 File Offset: 0x000B1F10
	public TsAnimNotifyBase() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyBase.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004EA5 RID: 20133 RVA: 0x000B3D38 File Offset: 0x000B1F38
	[NullableContext(1)]
	public TsAnimNotifyBase(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyBase.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004EA6 RID: 20134 RVA: 0x000B3D6B File Offset: 0x000B1F6B
	protected TsAnimNotifyBase(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004EA7 RID: 20135 RVA: 0x000B3D74 File Offset: 0x000B1F74
	protected unsafe virtual void __CPPCALL_K2_NotifyConditionCheck_Implementation(UKuroAnimNotify.__K2_NotifyConditionCheck_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyConditionCheck_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x040016D1 RID: 5841
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyBase.TsAnimNotifyBase_C";

	// Token: 0x040016D2 RID: 5842
	private static IntPtr _ClassPtr;

	// Token: 0x040016D3 RID: 5843
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x040016D4 RID: 5844
	private static int __PropertyOffset_AN执行的前提条件;

	// Token: 0x040016D5 RID: 5845
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TArray<SSkillBehaviorCondition> _AN执行的前提条件;
}
