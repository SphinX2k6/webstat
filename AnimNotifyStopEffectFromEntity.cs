using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02003406 RID: 13318
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/Render/Effect/AnimNotify/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/Render/Effect/AnimNotify/AnimNotifyStopEffectFromEntity.AnimNotifyStopEffectFromEntity_C")]
public class AnimNotifyStopEffectFromEntity : UKuroEffectMakerAN, IUnrealUObject, IUnrealObject
{
	// Token: 0x170025A6 RID: 9638
	// (get) Token: 0x0601BCF8 RID: 113912 RVA: 0x0084BAB4 File Offset: 0x00849CB4
	// (set) Token: 0x0601BCF9 RID: 113913 RVA: 0x0084BAED File Offset: 0x00849CED
	[UProperty(EPropertyFlags.CPF_None)]
	public TSoftObjectPtr<UEffectModelBase> EffectDataAssetRef
	{
		get
		{
			base.FastCheckIsValid();
			TSoftObjectPtr<UEffectModelBase> result;
			if ((result = this._EffectDataAssetRef) == null)
			{
				result = (this._EffectDataAssetRef = new TSoftObjectPtr<UEffectModelBase>(base.NativePtr + (IntPtr)AnimNotifyStopEffectFromEntity.__PropertyOffset_EffectDataAssetRef, this));
			}
			return result;
		}
		set
		{
			FSoftObjectPtr.NativeCopy((value != null) ? value.NativePtr : IntPtr.Zero, base.NativePtr + (IntPtr)AnimNotifyStopEffectFromEntity.__PropertyOffset_EffectDataAssetRef, 1);
		}
	}

	// Token: 0x170025A7 RID: 9639
	// (get) Token: 0x0601BCFA RID: 113914 RVA: 0x0084BB12 File Offset: 0x00849D12
	// (set) Token: 0x0601BCFB RID: 113915 RVA: 0x0084BB22 File Offset: 0x00849D22
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool Immediately
	{
		get
		{
			return *(base.NativePtr + (IntPtr)AnimNotifyStopEffectFromEntity.__PropertyOffset_Immediately) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)AnimNotifyStopEffectFromEntity.__PropertyOffset_Immediately) = (value ? 1 : 0);
		}
	}

	// Token: 0x0601BCFC RID: 113916 RVA: 0x0084BB34 File Offset: 0x00849D34
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

	// Token: 0x0601BCFD RID: 113917 RVA: 0x0084BBD4 File Offset: 0x00849DD4
	[NullableContext(2)]
	protected virtual bool K2_Notify_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		AActor owner = meshComp.GetOwner();
		int num = 0;
		TsBaseCharacter tsBaseCharacter = owner as TsBaseCharacter;
		if (tsBaseCharacter != null)
		{
			CharacterActorComponent characterActorComponent = tsBaseCharacter.CharacterActorComponent;
			if (((characterActorComponent != null) ? characterActorComponent.Entity : null) != null)
			{
				CharacterActorComponent characterActorComponent2 = tsBaseCharacter.CharacterActorComponent;
				num = ((characterActorComponent2 != null) ? characterActorComponent2.Entity.Id : 0);
				goto IL_55;
			}
		}
		AEffectSystemActor aeffectSystemActor = owner as AEffectSystemActor;
		if (aeffectSystemActor != null)
		{
			num = aeffectSystemActor.GetOwnerEntityId();
		}
		IL_55:
		if (num == 0)
		{
			return true;
		}
		string text = this.EffectDataAssetRef.ToAssetPathName();
		if (text == null)
		{
			return true;
		}
		UKuroEffectSystemFunctionLibrary.StopEffectFromEntity(num, text, this.Immediately);
		return true;
	}

	// Token: 0x0601BCFE RID: 113918 RVA: 0x0084BC5F File Offset: 0x00849E5F
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (AnimNotifyStopEffectFromEntity._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/Render/Effect/AnimNotify/AnimNotifyStopEffectFromEntity.AnimNotifyStopEffectFromEntity_C");
		}
		return AnimNotifyStopEffectFromEntity._ClassPtr;
	}

	// Token: 0x0601BCFF RID: 113919 RVA: 0x0084BC84 File Offset: 0x00849E84
	public AnimNotifyStopEffectFromEntity() : this(BuiltinUtils.AllocNativeUObject(AnimNotifyStopEffectFromEntity.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0601BD00 RID: 113920 RVA: 0x0084BCAC File Offset: 0x00849EAC
	public AnimNotifyStopEffectFromEntity(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(AnimNotifyStopEffectFromEntity.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601BD01 RID: 113921 RVA: 0x0084BCDF File Offset: 0x00849EDF
	protected AnimNotifyStopEffectFromEntity(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601BD02 RID: 113922 RVA: 0x0084BCE8 File Offset: 0x00849EE8
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_Notify_Implementation(UKuroAnimNotify.__K2_Notify_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_Notify_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x0400E088 RID: 57480
	[StaticVariableRuleIgnore]
	private static readonly Stat NotifyStat = Stat.Create("AnimNotifyStopEffectFromEntity_K2_Notify", "", "");

	// Token: 0x0400E089 RID: 57481
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/Render/Effect/AnimNotify/AnimNotifyStopEffectFromEntity.AnimNotifyStopEffectFromEntity_C";

	// Token: 0x0400E08A RID: 57482
	private static IntPtr _ClassPtr;

	// Token: 0x0400E08B RID: 57483
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400E08C RID: 57484
	private static int __PropertyOffset_EffectDataAssetRef;

	// Token: 0x0400E08D RID: 57485
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TSoftObjectPtr<UEffectModelBase> _EffectDataAssetRef;

	// Token: 0x0400E08E RID: 57486
	private static int __PropertyOffset_Immediately;
}
