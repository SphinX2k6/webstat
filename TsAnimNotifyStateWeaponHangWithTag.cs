using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000DA0 RID: 3488
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateWeaponHangWithTag.TsAnimNotifyStateWeaponHangWithTag_C")]
public class TsAnimNotifyStateWeaponHangWithTag : TsAnimNotifyStateBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170004C8 RID: 1224
	// (get) Token: 0x06004E0A RID: 19978 RVA: 0x000B145B File Offset: 0x000AF65B
	// (set) Token: 0x06004E0B RID: 19979 RVA: 0x000B146B File Offset: 0x000AF66B
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int Id
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateWeaponHangWithTag.__PropertyOffset_Id);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateWeaponHangWithTag.__PropertyOffset_Id) = value;
		}
	}

	// Token: 0x170004C9 RID: 1225
	// (get) Token: 0x06004E0C RID: 19980 RVA: 0x000B147C File Offset: 0x000AF67C
	[UProperty(EPropertyFlags.CPF_None)]
	public TArray<FName> 新的挂载点名
	{
		get
		{
			base.FastCheckIsValid();
			TArray<FName> result;
			if ((result = this._新的挂载点名) == null)
			{
				result = (this._新的挂载点名 = new TArray<FName>(base.NativePtr + (IntPtr)TsAnimNotifyStateWeaponHangWithTag.__PropertyOffset_新的挂载点名, this));
			}
			return result;
		}
	}

	// Token: 0x170004CA RID: 1226
	// (get) Token: 0x06004E0D RID: 19981 RVA: 0x000B14B8 File Offset: 0x000AF6B8
	[UProperty(EPropertyFlags.CPF_None)]
	public TArray<FTransform> 挂载相对位置
	{
		get
		{
			base.FastCheckIsValid();
			TArray<FTransform> result;
			if ((result = this._挂载相对位置) == null)
			{
				result = (this._挂载相对位置 = new TArray<FTransform>(base.NativePtr + (IntPtr)TsAnimNotifyStateWeaponHangWithTag.__PropertyOffset_挂载相对位置, this));
			}
			return result;
		}
	}

	// Token: 0x170004CB RID: 1227
	// (get) Token: 0x06004E0E RID: 19982 RVA: 0x000B14F1 File Offset: 0x000AF6F1
	// (set) Token: 0x06004E0F RID: 19983 RVA: 0x000B1501 File Offset: 0x000AF701
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int 结束后状态
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateWeaponHangWithTag.__PropertyOffset_结束后状态);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateWeaponHangWithTag.__PropertyOffset_结束后状态) = value;
		}
	}

	// Token: 0x170004CC RID: 1228
	// (get) Token: 0x06004E10 RID: 19984 RVA: 0x000B1512 File Offset: 0x000AF712
	// (set) Token: 0x06004E11 RID: 19985 RVA: 0x000B1522 File Offset: 0x000AF722
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float 缓冲时间
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateWeaponHangWithTag.__PropertyOffset_缓冲时间);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateWeaponHangWithTag.__PropertyOffset_缓冲时间) = value;
		}
	}

	// Token: 0x170004CD RID: 1229
	// (get) Token: 0x06004E12 RID: 19986 RVA: 0x000B1533 File Offset: 0x000AF733
	// (set) Token: 0x06004E13 RID: 19987 RVA: 0x000B1547 File Offset: 0x000AF747
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FGameplayTag ActivateTag
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateWeaponHangWithTag.__PropertyOffset_ActivateTag);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateWeaponHangWithTag.__PropertyOffset_ActivateTag) = value;
		}
	}

	// Token: 0x06004E14 RID: 19988 RVA: 0x000B155C File Offset: 0x000AF75C
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

	// Token: 0x06004E15 RID: 19989 RVA: 0x000B1604 File Offset: 0x000AF804
	[NullableContext(2)]
	protected virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		TsBaseCharacter tsBaseCharacter = meshComp.GetOwner() as TsBaseCharacter;
		if (tsBaseCharacter == null)
		{
			return false;
		}
		CharacterActorComponent characterActorComponent = tsBaseCharacter.CharacterActorComponent;
		BaseTagComponent baseTagComponent;
		if (characterActorComponent == null)
		{
			baseTagComponent = null;
		}
		else
		{
			Entity entity = characterActorComponent.Entity;
			baseTagComponent = ((entity != null) ? entity.GetComponent<BaseTagComponent>() : null);
		}
		BaseTagComponent baseTagComponent2 = baseTagComponent;
		if (baseTagComponent2 == null || !baseTagComponent2.HasTag(this.ActivateTag.TagId()))
		{
			return false;
		}
		CharacterActorComponent characterActorComponent2 = tsBaseCharacter.CharacterActorComponent;
		object obj;
		if (characterActorComponent2 == null)
		{
			obj = null;
		}
		else
		{
			Entity entity2 = characterActorComponent2.Entity;
			obj = ((entity2 != null) ? entity2.GetComponent<CharacterWeaponComponent>() : null);
		}
		object obj2 = obj;
		if (obj2 != null)
		{
			obj2.ChangeWeaponHangState(this.Id, this.新的挂载点名, this.挂载相对位置, this.缓冲时间, "TsAnimNotifyStateWeaponHangWithTag.NotifyBegin");
		}
		return true;
	}

	// Token: 0x06004E16 RID: 19990 RVA: 0x000B16A4 File Offset: 0x000AF8A4
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

	// Token: 0x06004E17 RID: 19991 RVA: 0x000B1744 File Offset: 0x000AF944
	[NullableContext(2)]
	protected virtual bool K2_NotifyEnd_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		TsBaseCharacter tsBaseCharacter = meshComp.GetOwner() as TsBaseCharacter;
		if (tsBaseCharacter != null)
		{
			CharacterActorComponent characterActorComponent = tsBaseCharacter.CharacterActorComponent;
			BaseTagComponent baseTagComponent;
			if (characterActorComponent == null)
			{
				baseTagComponent = null;
			}
			else
			{
				Entity entity = characterActorComponent.Entity;
				baseTagComponent = ((entity != null) ? entity.GetComponent<BaseTagComponent>() : null);
			}
			BaseTagComponent baseTagComponent2 = baseTagComponent;
			if (baseTagComponent2 == null || !baseTagComponent2.HasTag(this.ActivateTag.TagId()))
			{
				return false;
			}
			CharacterActorComponent characterActorComponent2 = tsBaseCharacter.CharacterActorComponent;
			CharacterWeaponComponent characterWeaponComponent;
			if (characterActorComponent2 == null)
			{
				characterWeaponComponent = null;
			}
			else
			{
				Entity entity2 = characterActorComponent2.Entity;
				characterWeaponComponent = ((entity2 != null) ? entity2.GetComponent<CharacterWeaponComponent>() : null);
			}
			CharacterWeaponComponent characterWeaponComponent2 = characterWeaponComponent;
			if (characterWeaponComponent2 == null || !characterWeaponComponent2.Valid)
			{
				return false;
			}
			if (characterWeaponComponent2.CurrentHangState == this.Id)
			{
				if (this.结束后状态 == 0 || this.结束后状态 == 1)
				{
					characterWeaponComponent2.ChangeWeaponHangState(this.结束后状态, new TArray<FName>(), new TArray<FTransform>(), this.缓冲时间, "TsAnimNotifyStateWeaponHangWithTag.NotifyEnd");
					return true;
				}
				return false;
			}
		}
		return false;
	}

	// Token: 0x06004E18 RID: 19992 RVA: 0x000B1814 File Offset: 0x000AFA14
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

	// Token: 0x06004E19 RID: 19993 RVA: 0x000B188F File Offset: 0x000AFA8F
	protected override string GetNotifyName_Implementation()
	{
		return "切换武器到挂点";
	}

	// Token: 0x06004E1A RID: 19994 RVA: 0x000B1896 File Offset: 0x000AFA96
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStateWeaponHangWithTag._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateWeaponHangWithTag.TsAnimNotifyStateWeaponHangWithTag_C");
		}
		return TsAnimNotifyStateWeaponHangWithTag._ClassPtr;
	}

	// Token: 0x06004E1B RID: 19995 RVA: 0x000B18BC File Offset: 0x000AFABC
	public TsAnimNotifyStateWeaponHangWithTag() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateWeaponHangWithTag.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004E1C RID: 19996 RVA: 0x000B18E4 File Offset: 0x000AFAE4
	public TsAnimNotifyStateWeaponHangWithTag(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateWeaponHangWithTag.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004E1D RID: 19997 RVA: 0x000B1917 File Offset: 0x000AFB17
	protected TsAnimNotifyStateWeaponHangWithTag(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004E1E RID: 19998 RVA: 0x000B1920 File Offset: 0x000AFB20
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x06004E1F RID: 19999 RVA: 0x000B195C File Offset: 0x000AFB5C
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06004E20 RID: 20000 RVA: 0x000B198F File Offset: 0x000AFB8F
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotifyState.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x0400168E RID: 5774
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateWeaponHangWithTag.TsAnimNotifyStateWeaponHangWithTag_C";

	// Token: 0x0400168F RID: 5775
	private static IntPtr _ClassPtr;

	// Token: 0x04001690 RID: 5776
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04001691 RID: 5777
	private static int __PropertyOffset_Id;

	// Token: 0x04001692 RID: 5778
	private static int __PropertyOffset_新的挂载点名;

	// Token: 0x04001693 RID: 5779
	[Nullable(2)]
	private TArray<FName> _新的挂载点名;

	// Token: 0x04001694 RID: 5780
	private static int __PropertyOffset_挂载相对位置;

	// Token: 0x04001695 RID: 5781
	[Nullable(2)]
	private TArray<FTransform> _挂载相对位置;

	// Token: 0x04001696 RID: 5782
	private static int __PropertyOffset_结束后状态;

	// Token: 0x04001697 RID: 5783
	private static int __PropertyOffset_缓冲时间;

	// Token: 0x04001698 RID: 5784
	private static int __PropertyOffset_ActivateTag;
}
