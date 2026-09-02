using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.ScreenEffect.Data;
using CSharpScript.Game.Render.Effect.ScreenEffectSystem;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02003404 RID: 13316
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/Render/Effect/AnimNotify/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/Render/Effect/AnimNotify/AnimNotifyStateScreenEffect.AnimNotifyStateScreenEffect_C")]
public class AnimNotifyStateScreenEffect : TsAnimNotifyStateBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170025A0 RID: 9632
	// (get) Token: 0x0601BCD1 RID: 113873 RVA: 0x0084AFF0 File Offset: 0x008491F0
	// (set) Token: 0x0601BCD2 RID: 113874 RVA: 0x0084B029 File Offset: 0x00849229
	[UProperty(EPropertyFlags.CPF_None)]
	public TSoftObjectPtr<EffectScreenPlayData_C> EffectDataAssetRef
	{
		get
		{
			base.FastCheckIsValid();
			TSoftObjectPtr<EffectScreenPlayData_C> result;
			if ((result = this._EffectDataAssetRef) == null)
			{
				result = (this._EffectDataAssetRef = new TSoftObjectPtr<EffectScreenPlayData_C>(base.NativePtr + (IntPtr)AnimNotifyStateScreenEffect.__PropertyOffset_EffectDataAssetRef, this));
			}
			return result;
		}
		set
		{
			FSoftObjectPtr.NativeCopy((value != null) ? value.NativePtr : IntPtr.Zero, base.NativePtr + (IntPtr)AnimNotifyStateScreenEffect.__PropertyOffset_EffectDataAssetRef, 1);
		}
	}

	// Token: 0x170025A1 RID: 9633
	// (get) Token: 0x0601BCD3 RID: 113875 RVA: 0x0084B04E File Offset: 0x0084924E
	// (set) Token: 0x0601BCD4 RID: 113876 RVA: 0x0084B05E File Offset: 0x0084925E
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float HandleId
	{
		get
		{
			return *(base.NativePtr + (IntPtr)AnimNotifyStateScreenEffect.__PropertyOffset_HandleId);
		}
		set
		{
			*(base.NativePtr + (IntPtr)AnimNotifyStateScreenEffect.__PropertyOffset_HandleId) = value;
		}
	}

	// Token: 0x170025A2 RID: 9634
	// (get) Token: 0x0601BCD5 RID: 113877 RVA: 0x0084B06F File Offset: 0x0084926F
	// (set) Token: 0x0601BCD6 RID: 113878 RVA: 0x0084B083 File Offset: 0x00849283
	[Nullable(2)]
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe EffectScreenPlayData_C EffectData
	{
		[NullableContext(2)]
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<EffectScreenPlayData_C>(base.NativePtr / (IntPtr)sizeof(void*) + AnimNotifyStateScreenEffect.__PropertyOffset_EffectData);
		}
		[NullableContext(2)]
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + AnimNotifyStateScreenEffect.__PropertyOffset_EffectData, value);
		}
	}

	// Token: 0x0601BCD7 RID: 113879 RVA: 0x0084B098 File Offset: 0x00849298
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

	// Token: 0x0601BCD8 RID: 113880 RVA: 0x0084B140 File Offset: 0x00849340
	[NullableContext(2)]
	protected virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		if (this.EffectDataAssetRef == null)
		{
			return false;
		}
		AActor owner = meshComp.GetOwner();
		TsBaseCharacter tsBaseCharacter = owner as TsBaseCharacter;
		if (tsBaseCharacter != null)
		{
			EntityHandle entityById = ModelBase<CreatureModel>.Instance.GetEntityById(tsBaseCharacter.EntityId);
			if (entityById != null && entityById.Valid && !CharacterUtils.CanCharacterMonsterOrSummonedDisplayEffect(entityById))
			{
				return false;
			}
		}
		bool flag = owner is TsUiSceneRoleActor;
		bool flag2 = owner is TsSkeletalObserver;
		if (!flag && !flag2)
		{
			this.HandleId = (float)ModelBase<ScreenEffectModel>.Instance.PlayScreenEffect(this.EffectDataAssetRef.ToAssetPathName(), null, null);
			return true;
		}
		this.HandleId = (float)Singleton<ResourceSystem>.Instance.LoadAsync<EffectScreenPlayData_C>(this.EffectDataAssetRef.ToAssetPathName(), delegate([Nullable(2)] EffectScreenPlayData_C res, string _)
		{
			this.EffectData = res;
			ScreenEffectSystem.GetInstance().PlayScreenEffectNoPaused(res);
		}, ResourceSystem.EResourceLoadPriority.Ui, null);
		return true;
	}

	// Token: 0x0601BCD9 RID: 113881 RVA: 0x0084B200 File Offset: 0x00849400
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

	// Token: 0x0601BCDA RID: 113882 RVA: 0x0084B2A0 File Offset: 0x008494A0
	[NullableContext(2)]
	protected virtual bool K2_NotifyEnd_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		if (this.EffectDataAssetRef == null)
		{
			return false;
		}
		AActor owner = meshComp.GetOwner();
		bool flag = owner is TsUiSceneRoleActor;
		bool flag2 = owner is TsSkeletalObserver;
		if (!flag && !flag2)
		{
			ModelBase<ScreenEffectModel>.Instance.EndScreenEffect((int)this.HandleId);
			this.HandleId = 0f;
			return true;
		}
		if (this.EffectData != null)
		{
			ScreenEffectSystem.GetInstance().EndScreenEffect(this.EffectData);
		}
		if (this.HandleId != 0f)
		{
			Singleton<ResourceSystem>.Instance.CancelAsyncLoad((int)this.HandleId);
			this.HandleId = 0f;
		}
		return true;
	}

	// Token: 0x0601BCDB RID: 113883 RVA: 0x0084B33C File Offset: 0x0084953C
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

	// Token: 0x0601BCDC RID: 113884 RVA: 0x0084B3B8 File Offset: 0x008495B8
	protected override string GetNotifyName_Implementation()
	{
		TSoftObjectPtr<EffectScreenPlayData_C> effectDataAssetRef = this.EffectDataAssetRef;
		string text = (effectDataAssetRef != null) ? effectDataAssetRef.ToAssetPathName() : null;
		if (!string.IsNullOrEmpty(text))
		{
			return UBlueprintPathsLibrary.GetBaseFilename(text, true);
		}
		return "屏幕特效数据状态";
	}

	// Token: 0x0601BCDD RID: 113885 RVA: 0x0084B3ED File Offset: 0x008495ED
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (AnimNotifyStateScreenEffect._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/Render/Effect/AnimNotify/AnimNotifyStateScreenEffect.AnimNotifyStateScreenEffect_C");
		}
		return AnimNotifyStateScreenEffect._ClassPtr;
	}

	// Token: 0x0601BCDE RID: 113886 RVA: 0x0084B414 File Offset: 0x00849614
	public AnimNotifyStateScreenEffect() : this(BuiltinUtils.AllocNativeUObject(AnimNotifyStateScreenEffect.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0601BCDF RID: 113887 RVA: 0x0084B43C File Offset: 0x0084963C
	public AnimNotifyStateScreenEffect(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(AnimNotifyStateScreenEffect.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601BCE0 RID: 113888 RVA: 0x0084B46F File Offset: 0x0084966F
	protected AnimNotifyStateScreenEffect(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601BCE1 RID: 113889 RVA: 0x0084B478 File Offset: 0x00849678
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x0601BCE2 RID: 113890 RVA: 0x0084B4B4 File Offset: 0x008496B4
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x0601BCE3 RID: 113891 RVA: 0x0084B4E7 File Offset: 0x008496E7
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotifyState.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x0400E079 RID: 57465
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/Render/Effect/AnimNotify/AnimNotifyStateScreenEffect.AnimNotifyStateScreenEffect_C";

	// Token: 0x0400E07A RID: 57466
	private static IntPtr _ClassPtr;

	// Token: 0x0400E07B RID: 57467
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400E07C RID: 57468
	private static int __PropertyOffset_EffectDataAssetRef;

	// Token: 0x0400E07D RID: 57469
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TSoftObjectPtr<EffectScreenPlayData_C> _EffectDataAssetRef;

	// Token: 0x0400E07E RID: 57470
	private static int __PropertyOffset_HandleId;

	// Token: 0x0400E07F RID: 57471
	private static int __PropertyOffset_EffectData;
}
