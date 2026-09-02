using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000DB0 RID: 3504
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AnimNotify/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyBulletPattern.TsAnimNotifyBulletPattern_C")]
public class TsAnimNotifyBulletPattern : TsAnimNotifyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170004F5 RID: 1269
	// (get) Token: 0x06004F08 RID: 20232 RVA: 0x000B5040 File Offset: 0x000B3240
	// (set) Token: 0x06004F09 RID: 20233 RVA: 0x000B5079 File Offset: 0x000B3279
	[UProperty(EPropertyFlags.CPF_None)]
	public TSoftObjectPtr<UKuroBulletPatternDataAsset> 弹幕数据
	{
		get
		{
			base.FastCheckIsValid();
			TSoftObjectPtr<UKuroBulletPatternDataAsset> result;
			if ((result = this._弹幕数据) == null)
			{
				result = (this._弹幕数据 = new TSoftObjectPtr<UKuroBulletPatternDataAsset>(base.NativePtr + (IntPtr)TsAnimNotifyBulletPattern.__PropertyOffset_弹幕数据, this));
			}
			return result;
		}
		set
		{
			FSoftObjectPtr.NativeCopy((value != null) ? value.NativePtr : IntPtr.Zero, base.NativePtr + (IntPtr)TsAnimNotifyBulletPattern.__PropertyOffset_弹幕数据, 1);
		}
	}

	// Token: 0x06004F0A RID: 20234 RVA: 0x000B50A0 File Offset: 0x000B32A0
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

	// Token: 0x06004F0B RID: 20235 RVA: 0x000B5140 File Offset: 0x000B3340
	[NullableContext(2)]
	protected virtual bool K2_Notify_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
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
			BulletUtil.SpawnPatternFromAN(ownerEntity, patternData, skillId, anMessageId, assetPath);
		}, 100, "js_undefined");
		return true;
	}

	// Token: 0x06004F0C RID: 20236 RVA: 0x000B5244 File Offset: 0x000B3444
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

	// Token: 0x06004F0D RID: 20237 RVA: 0x000B52BF File Offset: 0x000B34BF
	protected override string GetNotifyName_Implementation()
	{
		return "子弹弹幕";
	}

	// Token: 0x06004F0E RID: 20238 RVA: 0x000B52C6 File Offset: 0x000B34C6
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyBulletPattern._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyBulletPattern.TsAnimNotifyBulletPattern_C");
		}
		return TsAnimNotifyBulletPattern._ClassPtr;
	}

	// Token: 0x06004F0F RID: 20239 RVA: 0x000B52EC File Offset: 0x000B34EC
	public TsAnimNotifyBulletPattern() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyBulletPattern.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004F10 RID: 20240 RVA: 0x000B5314 File Offset: 0x000B3514
	public TsAnimNotifyBulletPattern(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyBulletPattern.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004F11 RID: 20241 RVA: 0x000B5347 File Offset: 0x000B3547
	protected TsAnimNotifyBulletPattern(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004F12 RID: 20242 RVA: 0x000B5350 File Offset: 0x000B3550
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_Notify_Implementation(UKuroAnimNotify.__K2_Notify_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_Notify_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06004F13 RID: 20243 RVA: 0x000B5383 File Offset: 0x000B3583
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotify.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x040016F9 RID: 5881
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyBulletPattern.TsAnimNotifyBulletPattern_C";

	// Token: 0x040016FA RID: 5882
	private static IntPtr _ClassPtr;

	// Token: 0x040016FB RID: 5883
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x040016FC RID: 5884
	private static int __PropertyOffset_弹幕数据;

	// Token: 0x040016FD RID: 5885
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TSoftObjectPtr<UKuroBulletPatternDataAsset> _弹幕数据;
}
