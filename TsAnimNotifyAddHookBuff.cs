using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.CombatMessage;
using CSharpScript.Game.NewWorld.Character.Common.Component.Explore;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000DA4 RID: 3492
[UClass("/Game/Aki/TypeScript/Game/AnimNotify/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyAddHookBuff.TsAnimNotifyAddHookBuff_C")]
public class TsAnimNotifyAddHookBuff : TsAnimNotifyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x06004E5D RID: 20061 RVA: 0x000B2870 File Offset: 0x000B0A70
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public unsafe override bool K2_Notify(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
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
			CharacterExploreComponent component2 = entity.GetComponent<CharacterExploreComponent>();
			if (component2 == null || !component2.Valid)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Character;
				ELogAuthor author = ELogAuthor.CK;
				string message = "[TsAnimNotifyAddHookBuff] 角色获取定点钩锁BuffId失败";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("CharacterEntityId", entity);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ExploreComponent", (component2 != null) ? new bool?(component2.Valid) : null);
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return true;
			}
			long fixHookBuffIdByTarget = component2.GetFixHookBuffIdByTarget();
			component.AddBuff(fixHookBuffIdByTarget, new AddBuffParam
			{
				InstigatorId = component.CreatureDataId,
				Reason = "动画" + ((animation != null) ? animation.GetName() : null) + "的AN添加"
			});
		}
		return true;
	}

	// Token: 0x06004E5E RID: 20062 RVA: 0x000B29BD File Offset: 0x000B0BBD
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public override string GetNotifyName()
	{
		return "添加BUFF";
	}

	// Token: 0x06004E5F RID: 20063 RVA: 0x000B29C4 File Offset: 0x000B0BC4
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyAddHookBuff._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyAddHookBuff.TsAnimNotifyAddHookBuff_C");
		}
		return TsAnimNotifyAddHookBuff._ClassPtr;
	}

	// Token: 0x06004E60 RID: 20064 RVA: 0x000B29E8 File Offset: 0x000B0BE8
	public TsAnimNotifyAddHookBuff() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyAddHookBuff.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004E61 RID: 20065 RVA: 0x000B2A10 File Offset: 0x000B0C10
	[NullableContext(1)]
	public TsAnimNotifyAddHookBuff(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyAddHookBuff.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004E62 RID: 20066 RVA: 0x000B2A43 File Offset: 0x000B0C43
	protected TsAnimNotifyAddHookBuff(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004E63 RID: 20067 RVA: 0x000B2A4C File Offset: 0x000B0C4C
	protected unsafe virtual void __CPPCALL_K2_Notify_Implementation(UKuroAnimNotify.__K2_Notify_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_Notify(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06004E64 RID: 20068 RVA: 0x000B2A7F File Offset: 0x000B0C7F
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotify.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName());
	}

	// Token: 0x040016B4 RID: 5812
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyAddHookBuff.TsAnimNotifyAddHookBuff_C";

	// Token: 0x040016B5 RID: 5813
	private static IntPtr _ClassPtr;

	// Token: 0x040016B6 RID: 5814
	private static IntPtr _ClassDefaultObjectPtr;
}
