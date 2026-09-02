using System;
using System.Runtime.CompilerServices;
using Aki.Protocol.Summon;
using AkiClient.Game.Aki.Character.BaseCharacter;
using Cysharp.Threading.Tasks;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000DEF RID: 3567
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AnimNotify/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifySummonBeginSkill.TsAnimNotifySummonBeginSkill_C")]
public class TsAnimNotifySummonBeginSkill : TsAnimNotifyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000570 RID: 1392
	// (get) Token: 0x06005267 RID: 21095 RVA: 0x000C0ABF File Offset: 0x000BECBF
	// (set) Token: 0x06005268 RID: 21096 RVA: 0x000C0ACF File Offset: 0x000BECCF
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int SummonIndex
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifySummonBeginSkill.__PropertyOffset_SummonIndex);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifySummonBeginSkill.__PropertyOffset_SummonIndex) = value;
		}
	}

	// Token: 0x17000571 RID: 1393
	// (get) Token: 0x06005269 RID: 21097 RVA: 0x000C0AE0 File Offset: 0x000BECE0
	// (set) Token: 0x0600526A RID: 21098 RVA: 0x000C0B19 File Offset: 0x000BED19
	[UProperty(EPropertyFlags.CPF_None)]
	public SSkillBehaviorAction ActionSetLocation
	{
		get
		{
			base.FastCheckIsValid();
			SSkillBehaviorAction result;
			if ((result = this._ActionSetLocation) == null)
			{
				result = (this._ActionSetLocation = new SSkillBehaviorAction(base.NativePtr + (IntPtr)TsAnimNotifySummonBeginSkill.__PropertyOffset_ActionSetLocation, this));
			}
			return result;
		}
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(SSkillBehaviorAction.StaticStruct(), base.NativePtr + (IntPtr)TsAnimNotifySummonBeginSkill.__PropertyOffset_ActionSetLocation, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x17000572 RID: 1394
	// (get) Token: 0x0600526B RID: 21099 RVA: 0x000C0B44 File Offset: 0x000BED44
	// (set) Token: 0x0600526C RID: 21100 RVA: 0x000C0B7D File Offset: 0x000BED7D
	[UProperty(EPropertyFlags.CPF_None)]
	public SSkillBehaviorAction ActionSetRotation
	{
		get
		{
			base.FastCheckIsValid();
			SSkillBehaviorAction result;
			if ((result = this._ActionSetRotation) == null)
			{
				result = (this._ActionSetRotation = new SSkillBehaviorAction(base.NativePtr + (IntPtr)TsAnimNotifySummonBeginSkill.__PropertyOffset_ActionSetRotation, this));
			}
			return result;
		}
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(SSkillBehaviorAction.StaticStruct(), base.NativePtr + (IntPtr)TsAnimNotifySummonBeginSkill.__PropertyOffset_ActionSetRotation, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x17000573 RID: 1395
	// (get) Token: 0x0600526D RID: 21101 RVA: 0x000C0BA5 File Offset: 0x000BEDA5
	// (set) Token: 0x0600526E RID: 21102 RVA: 0x000C0BB5 File Offset: 0x000BEDB5
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int SkillId
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifySummonBeginSkill.__PropertyOffset_SkillId);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifySummonBeginSkill.__PropertyOffset_SkillId) = value;
		}
	}

	// Token: 0x17000574 RID: 1396
	// (get) Token: 0x0600526F RID: 21103 RVA: 0x000C0BC6 File Offset: 0x000BEDC6
	// (set) Token: 0x06005270 RID: 21104 RVA: 0x000C0BD6 File Offset: 0x000BEDD6
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool EnableEntity
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifySummonBeginSkill.__PropertyOffset_EnableEntity) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifySummonBeginSkill.__PropertyOffset_EnableEntity) = (value ? 1 : 0);
		}
	}

	// Token: 0x06005271 RID: 21105 RVA: 0x000C0BE8 File Offset: 0x000BEDE8
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

	// Token: 0x06005272 RID: 21106 RVA: 0x000C0C88 File Offset: 0x000BEE88
	[NullableContext(2)]
	protected unsafe virtual bool K2_Notify_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		AActor owner = meshComp.GetOwner();
		if (owner == null || !(owner is TsBaseCharacter))
		{
			return false;
		}
		if (this.ActionSetLocation == null || this.ActionSetRotation == null)
		{
			return false;
		}
		TsBaseCharacter tsBaseCharacter = owner as TsBaseCharacter;
		Entity entity;
		if (tsBaseCharacter == null)
		{
			entity = null;
		}
		else
		{
			CharacterActorComponent characterActorComponent = tsBaseCharacter.CharacterActorComponent;
			entity = ((characterActorComponent != null) ? characterActorComponent.Entity : null);
		}
		Entity entity2 = entity;
		if (entity2 == null || !entity2.Valid)
		{
			return false;
		}
		CharacterSkillComponent component = entity2.GetComponent<CharacterSkillComponent>();
		if (component == null || component.CurrentSkill == null)
		{
			return false;
		}
		EntityHandle summonedEntity = PhantomUtil.GetSummonedEntity(entity2, ESummonType.ConcomitantCustom, this.SummonIndex);
		if (summonedEntity == null || !summonedEntity.Valid)
		{
			return false;
		}
		CharacterSkillComponent component2 = summonedEntity.Entity.GetComponent<CharacterSkillComponent>();
		if (component2 == null)
		{
			return false;
		}
		BeginSkillBehaviorActionParam param = new BeginSkillBehaviorActionParam
		{
			Entity = entity2,
			SkillComponent = component,
			Skill = component.CurrentSkill
		};
		FVectorDouble fvectorDouble = SkillBehaviorAction.CalculateLocation(this.ActionSetLocation, param);
		FRotator frotator = SkillBehaviorAction.CalculateRotation(this.ActionSetRotation, param);
		if (!fvectorDouble.Equals(Vector.ZeroVectorDouble, 9.999999747378752E-05))
		{
			BaseActorComponent component3 = summonedEntity.Entity.GetComponent<CharacterActorComponent>();
			CombatLog instance = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag = CombatLog.EDebugModule.Skill;
			Entity entity3 = summonedEntity.Entity;
			string message = "TsAnimNotifySummonBeginSkill.SetActorLocationAndRotation";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("位置", fvectorDouble);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("旋转", frotator);
			instance.Info(flag, entity3, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			component3.SetActorLocationAndRotation(fvectorDouble, frotator, "TsAnimNotifySummonBeginSkill.SetActorLocationAndRotation", false, null);
		}
		if (this.EnableEntity)
		{
			ControllerBase<CreatureController>.Instance.SetEntityEnable(summonedEntity.Entity, true, "TsAnimNotifySummonBeginSkill.SetEntityEnable", true);
		}
		BaseSkillComponent baseSkillComponent = component2;
		int skillId = this.SkillId;
		SkillParam skillParam = new SkillParam();
		EntityHandle skillTarget = component.SkillTarget;
		skillParam.Target = ((skillTarget != null) ? skillTarget.Entity : null);
		skillParam.Reason = "TsAnimNotifySummonBeginSkill.UseSummonSkill";
		baseSkillComponent.BeginSkillAsync(skillId, skillParam).Forget<bool>();
		return true;
	}

	// Token: 0x06005273 RID: 21107 RVA: 0x000C0E7C File Offset: 0x000BF07C
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

	// Token: 0x06005274 RID: 21108 RVA: 0x000C0EF7 File Offset: 0x000BF0F7
	protected override string GetNotifyName_Implementation()
	{
		return "召唤伴生物释放技能";
	}

	// Token: 0x06005275 RID: 21109 RVA: 0x000C0EFE File Offset: 0x000BF0FE
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifySummonBeginSkill._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifySummonBeginSkill.TsAnimNotifySummonBeginSkill_C");
		}
		return TsAnimNotifySummonBeginSkill._ClassPtr;
	}

	// Token: 0x06005276 RID: 21110 RVA: 0x000C0F24 File Offset: 0x000BF124
	public TsAnimNotifySummonBeginSkill() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifySummonBeginSkill.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06005277 RID: 21111 RVA: 0x000C0F4C File Offset: 0x000BF14C
	public TsAnimNotifySummonBeginSkill(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifySummonBeginSkill.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06005278 RID: 21112 RVA: 0x000C0F7F File Offset: 0x000BF17F
	protected TsAnimNotifySummonBeginSkill(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06005279 RID: 21113 RVA: 0x000C0F88 File Offset: 0x000BF188
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_Notify_Implementation(UKuroAnimNotify.__K2_Notify_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_Notify_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x0600527A RID: 21114 RVA: 0x000C0FBB File Offset: 0x000BF1BB
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotify.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x04001846 RID: 6214
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifySummonBeginSkill.TsAnimNotifySummonBeginSkill_C";

	// Token: 0x04001847 RID: 6215
	private static IntPtr _ClassPtr;

	// Token: 0x04001848 RID: 6216
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04001849 RID: 6217
	private static int __PropertyOffset_SummonIndex;

	// Token: 0x0400184A RID: 6218
	private static int __PropertyOffset_ActionSetLocation;

	// Token: 0x0400184B RID: 6219
	[Nullable(2)]
	private SSkillBehaviorAction _ActionSetLocation;

	// Token: 0x0400184C RID: 6220
	private static int __PropertyOffset_ActionSetRotation;

	// Token: 0x0400184D RID: 6221
	[Nullable(2)]
	private SSkillBehaviorAction _ActionSetRotation;

	// Token: 0x0400184E RID: 6222
	private static int __PropertyOffset_SkillId;

	// Token: 0x0400184F RID: 6223
	private static int __PropertyOffset_EnableEntity;
}
