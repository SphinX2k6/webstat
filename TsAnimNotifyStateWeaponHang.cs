using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000D9F RID: 3487
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateWeaponHang.TsAnimNotifyStateWeaponHang_C")]
public class TsAnimNotifyStateWeaponHang : TsAnimNotifyStateBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170004C3 RID: 1219
	// (get) Token: 0x06004DF5 RID: 19957 RVA: 0x000B0FAF File Offset: 0x000AF1AF
	// (set) Token: 0x06004DF6 RID: 19958 RVA: 0x000B0FBF File Offset: 0x000AF1BF
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int Id
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateWeaponHang.__PropertyOffset_Id);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateWeaponHang.__PropertyOffset_Id) = value;
		}
	}

	// Token: 0x170004C4 RID: 1220
	// (get) Token: 0x06004DF7 RID: 19959 RVA: 0x000B0FD0 File Offset: 0x000AF1D0
	[UProperty(EPropertyFlags.CPF_None)]
	public TArray<FName> 新的挂载点名
	{
		get
		{
			base.FastCheckIsValid();
			TArray<FName> result;
			if ((result = this._新的挂载点名) == null)
			{
				result = (this._新的挂载点名 = new TArray<FName>(base.NativePtr + (IntPtr)TsAnimNotifyStateWeaponHang.__PropertyOffset_新的挂载点名, this));
			}
			return result;
		}
	}

	// Token: 0x170004C5 RID: 1221
	// (get) Token: 0x06004DF8 RID: 19960 RVA: 0x000B100C File Offset: 0x000AF20C
	[UProperty(EPropertyFlags.CPF_None)]
	public TArray<FTransform> 挂载相对位置
	{
		get
		{
			base.FastCheckIsValid();
			TArray<FTransform> result;
			if ((result = this._挂载相对位置) == null)
			{
				result = (this._挂载相对位置 = new TArray<FTransform>(base.NativePtr + (IntPtr)TsAnimNotifyStateWeaponHang.__PropertyOffset_挂载相对位置, this));
			}
			return result;
		}
	}

	// Token: 0x170004C6 RID: 1222
	// (get) Token: 0x06004DF9 RID: 19961 RVA: 0x000B1045 File Offset: 0x000AF245
	// (set) Token: 0x06004DFA RID: 19962 RVA: 0x000B1055 File Offset: 0x000AF255
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int 结束后状态
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateWeaponHang.__PropertyOffset_结束后状态);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateWeaponHang.__PropertyOffset_结束后状态) = value;
		}
	}

	// Token: 0x170004C7 RID: 1223
	// (get) Token: 0x06004DFB RID: 19963 RVA: 0x000B1066 File Offset: 0x000AF266
	// (set) Token: 0x06004DFC RID: 19964 RVA: 0x000B1076 File Offset: 0x000AF276
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float 缓冲时间
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateWeaponHang.__PropertyOffset_缓冲时间);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateWeaponHang.__PropertyOffset_缓冲时间) = value;
		}
	}

	// Token: 0x06004DFD RID: 19965 RVA: 0x000B1088 File Offset: 0x000AF288
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

	// Token: 0x06004DFE RID: 19966 RVA: 0x000B1130 File Offset: 0x000AF330
	[NullableContext(2)]
	protected virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		TsBaseCharacter tsBaseCharacter = meshComp.GetOwner() as TsBaseCharacter;
		if (tsBaseCharacter != null)
		{
			CharacterActorComponent characterActorComponent = tsBaseCharacter.CharacterActorComponent;
			object obj;
			if (characterActorComponent == null)
			{
				obj = null;
			}
			else
			{
				Entity entity = characterActorComponent.Entity;
				obj = ((entity != null) ? entity.GetComponent<CharacterWeaponComponent>() : null);
			}
			object obj2 = obj;
			if (obj2 != null)
			{
				obj2.ChangeWeaponHangState(this.Id, this.新的挂载点名, this.挂载相对位置, this.缓冲时间, "TsAnimNotifyStateWeaponHang.NotifyBegin");
			}
			return true;
		}
		return false;
	}

	// Token: 0x06004DFF RID: 19967 RVA: 0x000B1198 File Offset: 0x000AF398
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

	// Token: 0x06004E00 RID: 19968 RVA: 0x000B1238 File Offset: 0x000AF438
	[NullableContext(2)]
	protected virtual bool K2_NotifyEnd_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		TsBaseCharacter tsBaseCharacter = meshComp.GetOwner() as TsBaseCharacter;
		if (tsBaseCharacter != null)
		{
			CharacterActorComponent characterActorComponent = tsBaseCharacter.CharacterActorComponent;
			CharacterWeaponComponent characterWeaponComponent;
			if (characterActorComponent == null)
			{
				characterWeaponComponent = null;
			}
			else
			{
				Entity entity = characterActorComponent.Entity;
				characterWeaponComponent = ((entity != null) ? entity.GetComponent<CharacterWeaponComponent>() : null);
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
					characterWeaponComponent2.ChangeWeaponHangState(this.结束后状态, new TArray<FName>(), new TArray<FTransform>(), this.缓冲时间, "TsAnimNotifyStateWeaponHang.NotifyEnd");
					return true;
				}
				return false;
			}
		}
		return false;
	}

	// Token: 0x06004E01 RID: 19969 RVA: 0x000B12CC File Offset: 0x000AF4CC
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

	// Token: 0x06004E02 RID: 19970 RVA: 0x000B1347 File Offset: 0x000AF547
	protected override string GetNotifyName_Implementation()
	{
		return "切换武器到挂点";
	}

	// Token: 0x06004E03 RID: 19971 RVA: 0x000B134E File Offset: 0x000AF54E
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStateWeaponHang._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateWeaponHang.TsAnimNotifyStateWeaponHang_C");
		}
		return TsAnimNotifyStateWeaponHang._ClassPtr;
	}

	// Token: 0x06004E04 RID: 19972 RVA: 0x000B1374 File Offset: 0x000AF574
	public TsAnimNotifyStateWeaponHang() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateWeaponHang.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004E05 RID: 19973 RVA: 0x000B139C File Offset: 0x000AF59C
	public TsAnimNotifyStateWeaponHang(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateWeaponHang.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004E06 RID: 19974 RVA: 0x000B13CF File Offset: 0x000AF5CF
	protected TsAnimNotifyStateWeaponHang(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004E07 RID: 19975 RVA: 0x000B13D8 File Offset: 0x000AF5D8
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x06004E08 RID: 19976 RVA: 0x000B1414 File Offset: 0x000AF614
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06004E09 RID: 19977 RVA: 0x000B1447 File Offset: 0x000AF647
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotifyState.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x04001684 RID: 5764
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateWeaponHang.TsAnimNotifyStateWeaponHang_C";

	// Token: 0x04001685 RID: 5765
	private static IntPtr _ClassPtr;

	// Token: 0x04001686 RID: 5766
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04001687 RID: 5767
	private static int __PropertyOffset_Id;

	// Token: 0x04001688 RID: 5768
	private static int __PropertyOffset_新的挂载点名;

	// Token: 0x04001689 RID: 5769
	[Nullable(2)]
	private TArray<FName> _新的挂载点名;

	// Token: 0x0400168A RID: 5770
	private static int __PropertyOffset_挂载相对位置;

	// Token: 0x0400168B RID: 5771
	[Nullable(2)]
	private TArray<FTransform> _挂载相对位置;

	// Token: 0x0400168C RID: 5772
	private static int __PropertyOffset_结束后状态;

	// Token: 0x0400168D RID: 5773
	private static int __PropertyOffset_缓冲时间;
}
