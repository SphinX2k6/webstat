using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000D33 RID: 3379
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateCaughtTrigger.TsAnimNotifyStateCaughtTrigger_C")]
public class TsAnimNotifyStateCaughtTrigger : TsAnimNotifyStateBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000378 RID: 888
	// (get) Token: 0x06004614 RID: 17940 RVA: 0x0008D088 File Offset: 0x0008B288
	[Nullable(1)]
	[UProperty(EPropertyFlags.CPF_None)]
	public TArray<string> CaughtIds
	{
		[NullableContext(1)]
		get
		{
			base.FastCheckIsValid();
			TArray<string> result;
			if ((result = this._CaughtIds) == null)
			{
				result = (this._CaughtIds = new TArray<string>(base.NativePtr + (IntPtr)TsAnimNotifyStateCaughtTrigger.__PropertyOffset_CaughtIds, this));
			}
			return result;
		}
	}

	// Token: 0x06004615 RID: 17941 RVA: 0x0008D0C4 File Offset: 0x0008B2C4
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override bool K2_NotifyBegin(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("K2_NotifyBegin"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams*)ptr + 15L / (long)sizeof(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->MeshComp) = ((meshComp != null) ? meshComp.NativePtr : ((IntPtr)0));
			*(&ptr2->Animation) = ((animation != null) ? animation.NativePtr : ((IntPtr)0));
			ptr2->TotalDuration = totalDuration;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x06004616 RID: 17942 RVA: 0x0008D16C File Offset: 0x0008B36C
	[NullableContext(2)]
	protected virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		TsBaseCharacter tsBaseCharacter = meshComp.GetOwner() as TsBaseCharacter;
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
		CharacterBuffComponent component = entity.GetComponent<CharacterBuffComponent>();
		long? caughtTriggerAnsInfo = (component != null) ? component.CreateAnimNotifyContent(animation.GetName(), base.exportIndex) : null;
		CharacterSkillComponent component2 = entity.GetComponent<CharacterSkillComponent>();
		CharacterCaughtNewComponent component3 = entity.GetComponent<CharacterCaughtNewComponent>();
		if (component3 != null)
		{
			component3.SetCaughtTriggerAnsInfo(caughtTriggerAnsInfo);
			CharacterCaughtNewComponent characterCaughtNewComponent = component3;
			TArray<string> caughtIds = this.CaughtIds;
			int? num;
			if (component2 == null)
			{
				num = null;
			}
			else
			{
				Skill currentSkill = component2.CurrentSkill;
				num = ((currentSkill != null) ? new int?(currentSkill.SkillId) : null);
			}
			int? num2 = num;
			characterCaughtNewComponent.BeginCaughtTrigger(caughtIds, num2.GetValueOrDefault());
			return true;
		}
		return false;
	}

	// Token: 0x06004617 RID: 17943 RVA: 0x0008D230 File Offset: 0x0008B430
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

	// Token: 0x06004618 RID: 17944 RVA: 0x0008D2D0 File Offset: 0x0008B4D0
	[NullableContext(2)]
	protected virtual bool K2_NotifyEnd_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		TsBaseCharacter tsBaseCharacter = meshComp.GetOwner() as TsBaseCharacter;
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
		CharacterCaughtNewComponent component = entity.GetComponent<CharacterCaughtNewComponent>();
		if (component != null)
		{
			component.EndCaughtTrigger();
			return true;
		}
		return false;
	}

	// Token: 0x06004619 RID: 17945 RVA: 0x0008D31C File Offset: 0x0008B51C
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override string GetNotifyName()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("GetNotifyName"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UAnimNotifyState.__GetNotifyName_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UAnimNotifyState.__GetNotifyName_FunctionParams*)ptr + 15L / (long)sizeof(UAnimNotifyState.__GetNotifyName_FunctionParams) & -16L);
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

	// Token: 0x0600461A RID: 17946 RVA: 0x0008D397 File Offset: 0x0008B597
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "抓取判定";
	}

	// Token: 0x0600461B RID: 17947 RVA: 0x0008D39E File Offset: 0x0008B59E
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStateCaughtTrigger._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateCaughtTrigger.TsAnimNotifyStateCaughtTrigger_C");
		}
		return TsAnimNotifyStateCaughtTrigger._ClassPtr;
	}

	// Token: 0x0600461C RID: 17948 RVA: 0x0008D3C4 File Offset: 0x0008B5C4
	public TsAnimNotifyStateCaughtTrigger() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateCaughtTrigger.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0600461D RID: 17949 RVA: 0x0008D3EC File Offset: 0x0008B5EC
	[NullableContext(1)]
	public TsAnimNotifyStateCaughtTrigger(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateCaughtTrigger.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0600461E RID: 17950 RVA: 0x0008D41F File Offset: 0x0008B61F
	protected TsAnimNotifyStateCaughtTrigger(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0600461F RID: 17951 RVA: 0x0008D428 File Offset: 0x0008B628
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x06004620 RID: 17952 RVA: 0x0008D464 File Offset: 0x0008B664
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06004621 RID: 17953 RVA: 0x0008D497 File Offset: 0x0008B697
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotifyState.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x040012E4 RID: 4836
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateCaughtTrigger.TsAnimNotifyStateCaughtTrigger_C";

	// Token: 0x040012E5 RID: 4837
	private static IntPtr _ClassPtr;

	// Token: 0x040012E6 RID: 4838
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x040012E7 RID: 4839
	private static int __PropertyOffset_CaughtIds;

	// Token: 0x040012E8 RID: 4840
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TArray<string> _CaughtIds;
}
