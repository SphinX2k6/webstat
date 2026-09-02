using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000D2C RID: 3372
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateBulletPattern.TsAnimNotifyStateBulletPattern_C")]
public class TsAnimNotifyStateBulletPattern : TsAnimNotifyStateBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x1700035E RID: 862
	// (get) Token: 0x0600457D RID: 17789 RVA: 0x0008A840 File Offset: 0x00088A40
	// (set) Token: 0x0600457E RID: 17790 RVA: 0x0008A879 File Offset: 0x00088A79
	[UProperty(EPropertyFlags.CPF_None)]
	public TSoftObjectPtr<UKuroBulletPatternDataAsset> 弹幕数据
	{
		get
		{
			base.FastCheckIsValid();
			TSoftObjectPtr<UKuroBulletPatternDataAsset> result;
			if ((result = this._弹幕数据) == null)
			{
				result = (this._弹幕数据 = new TSoftObjectPtr<UKuroBulletPatternDataAsset>(base.NativePtr + (IntPtr)TsAnimNotifyStateBulletPattern.__PropertyOffset_弹幕数据, this));
			}
			return result;
		}
		set
		{
			FSoftObjectPtr.NativeCopy((value != null) ? value.NativePtr : IntPtr.Zero, base.NativePtr + (IntPtr)TsAnimNotifyStateBulletPattern.__PropertyOffset_弹幕数据, 1);
		}
	}

	// Token: 0x0600457F RID: 17791 RVA: 0x0008A8A0 File Offset: 0x00088AA0
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

	// Token: 0x06004580 RID: 17792 RVA: 0x0008A948 File Offset: 0x00088B48
	[NullableContext(2)]
	protected virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		AActor owner = meshComp.GetOwner();
		if (!(owner is TsBaseCharacter))
		{
			return false;
		}
		Entity ownerEntity = (owner as TsBaseCharacter).GetEntityNoBlueprint();
		Entity ownerEntity2 = ownerEntity;
		if (ownerEntity2 == null || !ownerEntity2.Valid)
		{
			return false;
		}
		if (this.弹幕数据 == null)
		{
			return false;
		}
		BaseBuffComponent component = ownerEntity.GetComponent<BaseBuffComponent>();
		long? anMessageId = (component != null) ? component.CreateAnimNotifyContent(animation.GetName(), base.exportIndex) : null;
		BaseSkillComponent component2 = ownerEntity.GetComponent<BaseSkillComponent>();
		if (component2 == null || !component2.Valid)
		{
			return false;
		}
		int currentMontageCorrespondingSkillId = component2.GetCurrentMontageCorrespondingSkillId();
		int skillId = (currentMontageCorrespondingSkillId != 0) ? currentMontageCorrespondingSkillId : component2.GetSkillIdWithGroupId(1);
		string assetPath = this.弹幕数据.ToAssetPathName();
		Singleton<ResourceSystem>.Instance.LoadAsync<UKuroBulletPatternDataAsset>(assetPath, delegate([Nullable(2)] UKuroBulletPatternDataAsset patternData, string _)
		{
			if (patternData == null || !patternData.IsValid())
			{
				return;
			}
			this.PatternId = BulletUtil.SpawnPatternFromAN(ownerEntity, patternData, skillId, anMessageId, assetPath);
		}, 100, "js_undefined");
		return true;
	}

	// Token: 0x06004581 RID: 17793 RVA: 0x0008AA54 File Offset: 0x00088C54
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

	// Token: 0x06004582 RID: 17794 RVA: 0x0008AAF3 File Offset: 0x00088CF3
	[NullableContext(2)]
	protected virtual bool K2_NotifyEnd_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		if (this.PatternId > 0)
		{
			BulletUtil.DestroyPatternById(this.PatternId);
			this.PatternId = 0;
		}
		return true;
	}

	// Token: 0x06004583 RID: 17795 RVA: 0x0008AB14 File Offset: 0x00088D14
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

	// Token: 0x06004584 RID: 17796 RVA: 0x0008AB8F File Offset: 0x00088D8F
	protected override string GetNotifyName_Implementation()
	{
		return "子弹弹幕";
	}

	// Token: 0x06004585 RID: 17797 RVA: 0x0008AB96 File Offset: 0x00088D96
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStateBulletPattern._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateBulletPattern.TsAnimNotifyStateBulletPattern_C");
		}
		return TsAnimNotifyStateBulletPattern._ClassPtr;
	}

	// Token: 0x06004586 RID: 17798 RVA: 0x0008ABBC File Offset: 0x00088DBC
	public TsAnimNotifyStateBulletPattern() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateBulletPattern.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004587 RID: 17799 RVA: 0x0008ABE4 File Offset: 0x00088DE4
	public TsAnimNotifyStateBulletPattern(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateBulletPattern.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004588 RID: 17800 RVA: 0x0008AC17 File Offset: 0x00088E17
	protected TsAnimNotifyStateBulletPattern(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004589 RID: 17801 RVA: 0x0008AC20 File Offset: 0x00088E20
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x0600458A RID: 17802 RVA: 0x0008AC5C File Offset: 0x00088E5C
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x0600458B RID: 17803 RVA: 0x0008AC8F File Offset: 0x00088E8F
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotifyState.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x040012A5 RID: 4773
	private int PatternId;

	// Token: 0x040012A6 RID: 4774
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateBulletPattern.TsAnimNotifyStateBulletPattern_C";

	// Token: 0x040012A7 RID: 4775
	private static IntPtr _ClassPtr;

	// Token: 0x040012A8 RID: 4776
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x040012A9 RID: 4777
	private static int __PropertyOffset_弹幕数据;

	// Token: 0x040012AA RID: 4778
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TSoftObjectPtr<UKuroBulletPatternDataAsset> _弹幕数据;
}
