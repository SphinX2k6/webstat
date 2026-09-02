using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000DF1 RID: 3569
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AnimNotify/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifySummonRandom.TsAnimNotifySummonRandom_C")]
public class TsAnimNotifySummonRandom : TsAnimNotifyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000575 RID: 1397
	// (get) Token: 0x06005282 RID: 21122 RVA: 0x000C12AB File Offset: 0x000BF4AB
	// (set) Token: 0x06005283 RID: 21123 RVA: 0x000C12BB File Offset: 0x000BF4BB
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int SummonIndex
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifySummonRandom.__PropertyOffset_SummonIndex);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifySummonRandom.__PropertyOffset_SummonIndex) = value;
		}
	}

	// Token: 0x17000576 RID: 1398
	// (get) Token: 0x06005284 RID: 21124 RVA: 0x000C12CC File Offset: 0x000BF4CC
	// (set) Token: 0x06005285 RID: 21125 RVA: 0x000C1305 File Offset: 0x000BF505
	[UProperty(EPropertyFlags.CPF_None)]
	public SSkillBehaviorAction Action
	{
		get
		{
			base.FastCheckIsValid();
			SSkillBehaviorAction result;
			if ((result = this._Action) == null)
			{
				result = (this._Action = new SSkillBehaviorAction(base.NativePtr + (IntPtr)TsAnimNotifySummonRandom.__PropertyOffset_Action, this));
			}
			return result;
		}
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(SSkillBehaviorAction.StaticStruct(), base.NativePtr + (IntPtr)TsAnimNotifySummonRandom.__PropertyOffset_Action, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x17000577 RID: 1399
	// (get) Token: 0x06005286 RID: 21126 RVA: 0x000C132D File Offset: 0x000BF52D
	// (set) Token: 0x06005287 RID: 21127 RVA: 0x000C133D File Offset: 0x000BF53D
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int SkillId
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifySummonRandom.__PropertyOffset_SkillId);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifySummonRandom.__PropertyOffset_SkillId) = value;
		}
	}

	// Token: 0x17000578 RID: 1400
	// (get) Token: 0x06005288 RID: 21128 RVA: 0x000C134E File Offset: 0x000BF54E
	// (set) Token: 0x06005289 RID: 21129 RVA: 0x000C135E File Offset: 0x000BF55E
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool IsVisible
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifySummonRandom.__PropertyOffset_IsVisible) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifySummonRandom.__PropertyOffset_IsVisible) = (value ? 1 : 0);
		}
	}

	// Token: 0x0600528A RID: 21130 RVA: 0x000C1370 File Offset: 0x000BF570
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

	// Token: 0x0600528B RID: 21131 RVA: 0x000C1410 File Offset: 0x000BF610
	[NullableContext(2)]
	protected virtual bool K2_Notify_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		AActor owner = meshComp.GetOwner();
		if (owner == null || !(owner is TsBaseCharacter))
		{
			return false;
		}
		TsBaseCharacter tsBaseCharacter = owner as TsBaseCharacter;
		bool flag;
		if (tsBaseCharacter == null)
		{
			flag = true;
		}
		else
		{
			CharacterActorComponent characterActorComponent = tsBaseCharacter.CharacterActorComponent;
			flag = !((characterActorComponent != null) ? new bool?(characterActorComponent.IsAutonomousProxy) : null).GetValueOrDefault();
		}
		if (flag)
		{
			return false;
		}
		TsBaseCharacter tsBaseCharacter2 = owner as TsBaseCharacter;
		Entity entity;
		if (tsBaseCharacter2 == null)
		{
			entity = null;
		}
		else
		{
			CharacterActorComponent characterActorComponent2 = tsBaseCharacter2.CharacterActorComponent;
			entity = ((characterActorComponent2 != null) ? characterActorComponent2.Entity : null);
		}
		Entity entity2 = entity;
		if (entity2 == null || !entity2.Valid)
		{
			return false;
		}
		CharacterSkillComponent component = entity2.GetComponent<CharacterSkillComponent>();
		if (component == null || component.CurrentSkill == null || this.Action == null)
		{
			return false;
		}
		BeginSkillBehaviorActionParam param = new BeginSkillBehaviorActionParam
		{
			Entity = entity2,
			SkillComponent = component,
			Skill = component.CurrentSkill
		};
		FVectorDouble fvectorDouble = SkillBehaviorAction.CalculateLocation(this.Action, param);
		FRotator frotator = SkillBehaviorAction.CalculateRotation(this.Action, param);
		FVector fvector = Vector.OneVectorDouble;
		FTransformDouble transform = new FTransformDouble(ref frotator, ref fvectorDouble, ref fvector);
		ControllerBase<CreatureController>.Instance.SummonRandomRequest(entity2.Id, this.SummonIndex, transform, this.SkillId, this.IsVisible);
		return true;
	}

	// Token: 0x0600528C RID: 21132 RVA: 0x000C153C File Offset: 0x000BF73C
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

	// Token: 0x0600528D RID: 21133 RVA: 0x000C15B7 File Offset: 0x000BF7B7
	protected override string GetNotifyName_Implementation()
	{
		return "随机召唤";
	}

	// Token: 0x0600528E RID: 21134 RVA: 0x000C15BE File Offset: 0x000BF7BE
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifySummonRandom._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifySummonRandom.TsAnimNotifySummonRandom_C");
		}
		return TsAnimNotifySummonRandom._ClassPtr;
	}

	// Token: 0x0600528F RID: 21135 RVA: 0x000C15E4 File Offset: 0x000BF7E4
	public TsAnimNotifySummonRandom() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifySummonRandom.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06005290 RID: 21136 RVA: 0x000C160C File Offset: 0x000BF80C
	public TsAnimNotifySummonRandom(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifySummonRandom.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06005291 RID: 21137 RVA: 0x000C163F File Offset: 0x000BF83F
	protected TsAnimNotifySummonRandom(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06005292 RID: 21138 RVA: 0x000C1648 File Offset: 0x000BF848
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_Notify_Implementation(UKuroAnimNotify.__K2_Notify_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_Notify_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06005293 RID: 21139 RVA: 0x000C167B File Offset: 0x000BF87B
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotify.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x04001853 RID: 6227
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifySummonRandom.TsAnimNotifySummonRandom_C";

	// Token: 0x04001854 RID: 6228
	private static IntPtr _ClassPtr;

	// Token: 0x04001855 RID: 6229
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04001856 RID: 6230
	private static int __PropertyOffset_SummonIndex;

	// Token: 0x04001857 RID: 6231
	private static int __PropertyOffset_Action;

	// Token: 0x04001858 RID: 6232
	[Nullable(2)]
	private SSkillBehaviorAction _Action;

	// Token: 0x04001859 RID: 6233
	private static int __PropertyOffset_SkillId;

	// Token: 0x0400185A RID: 6234
	private static int __PropertyOffset_IsVisible;
}
