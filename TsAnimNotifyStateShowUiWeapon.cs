using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000D86 RID: 3462
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateShowUiWeapon.TsAnimNotifyStateShowUiWeapon_C")]
public class TsAnimNotifyStateShowUiWeapon : TsAnimNotifyStateBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000485 RID: 1157
	// (get) Token: 0x06004C36 RID: 19510 RVA: 0x000A9BB6 File Offset: 0x000A7DB6
	// (set) Token: 0x06004C37 RID: 19511 RVA: 0x000A9BC6 File Offset: 0x000A7DC6
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int WeaponIndex
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateShowUiWeapon.__PropertyOffset_WeaponIndex);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateShowUiWeapon.__PropertyOffset_WeaponIndex) = value;
		}
	}

	// Token: 0x17000486 RID: 1158
	// (get) Token: 0x06004C38 RID: 19512 RVA: 0x000A9BD7 File Offset: 0x000A7DD7
	// (set) Token: 0x06004C39 RID: 19513 RVA: 0x000A9BE7 File Offset: 0x000A7DE7
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool ShowMaterialController
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateShowUiWeapon.__PropertyOffset_ShowMaterialController) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateShowUiWeapon.__PropertyOffset_ShowMaterialController) = (value ? 1 : 0);
		}
	}

	// Token: 0x17000487 RID: 1159
	// (get) Token: 0x06004C3A RID: 19514 RVA: 0x000A9BF8 File Offset: 0x000A7DF8
	// (set) Token: 0x06004C3B RID: 19515 RVA: 0x000A9C08 File Offset: 0x000A7E08
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool HideEffect
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateShowUiWeapon.__PropertyOffset_HideEffect) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateShowUiWeapon.__PropertyOffset_HideEffect) = (value ? 1 : 0);
		}
	}

	// Token: 0x17000488 RID: 1160
	// (get) Token: 0x06004C3C RID: 19516 RVA: 0x000A9C19 File Offset: 0x000A7E19
	// (set) Token: 0x06004C3D RID: 19517 RVA: 0x000A9C2D File Offset: 0x000A7E2D
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FTransform Transform
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateShowUiWeapon.__PropertyOffset_Transform);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateShowUiWeapon.__PropertyOffset_Transform) = value;
		}
	}

	// Token: 0x17000489 RID: 1161
	// (get) Token: 0x06004C3E RID: 19518 RVA: 0x000A9C42 File Offset: 0x000A7E42
	// (set) Token: 0x06004C3F RID: 19519 RVA: 0x000A9C56 File Offset: 0x000A7E56
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FName HangSocketName
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateShowUiWeapon.__PropertyOffset_HangSocketName);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateShowUiWeapon.__PropertyOffset_HangSocketName) = value;
		}
	}

	// Token: 0x06004C40 RID: 19520 RVA: 0x000A9C6C File Offset: 0x000A7E6C
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

	// Token: 0x06004C41 RID: 19521 RVA: 0x000A9D14 File Offset: 0x000A7F14
	[NullableContext(2)]
	protected virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		AActor owner = meshComp.GetOwner();
		if (owner is TsUiSceneRoleActor)
		{
			if (this.WeaponIndex >= 0)
			{
				UiWeaponAnsContext value = new UiWeaponAnsContext(this.WeaponIndex, this.ShowMaterialController, this.HideEffect, new FTransform?(this.Transform), this.HangSocketName);
				UiModelBase model = (owner as TsUiSceneRoleActor).Model;
				if (model != null)
				{
					model.CheckGetComponent<UiModelAnsControllerComponent>().AddAns<UiWeaponAnsContext>("UiWeaponAnsContext", value);
				}
			}
			else
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Character;
				ELogAuthor author = ELogAuthor.LZK;
				string message = "UI武器显隐配置的索引不合法";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("index", this.WeaponIndex);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
		}
		return false;
	}

	// Token: 0x06004C42 RID: 19522 RVA: 0x000A9DBC File Offset: 0x000A7FBC
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

	// Token: 0x06004C43 RID: 19523 RVA: 0x000A9E5C File Offset: 0x000A805C
	[NullableContext(2)]
	protected virtual bool K2_NotifyEnd_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		AActor owner = meshComp.GetOwner();
		if (owner is TsUiSceneRoleActor)
		{
			if (this.WeaponIndex >= 0)
			{
				UiWeaponAnsContext value = new UiWeaponAnsContext(this.WeaponIndex, this.ShowMaterialController, this.HideEffect, new FTransform?(this.Transform), this.HangSocketName);
				UiModelBase model = (owner as TsUiSceneRoleActor).Model;
				if (model != null)
				{
					model.CheckGetComponent<UiModelAnsControllerComponent>().ReduceAns<UiWeaponAnsContext>("UiWeaponAnsContext", value);
				}
			}
			else
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Character;
				ELogAuthor author = ELogAuthor.LZK;
				string message = "UI武器显隐配置的索引不合法";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("index", this.WeaponIndex);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
		}
		return false;
	}

	// Token: 0x06004C44 RID: 19524 RVA: 0x000A9F04 File Offset: 0x000A8104
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

	// Token: 0x06004C45 RID: 19525 RVA: 0x000A9F7F File Offset: 0x000A817F
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "Ui界面武器显示";
	}

	// Token: 0x06004C46 RID: 19526 RVA: 0x000A9F86 File Offset: 0x000A8186
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStateShowUiWeapon._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateShowUiWeapon.TsAnimNotifyStateShowUiWeapon_C");
		}
		return TsAnimNotifyStateShowUiWeapon._ClassPtr;
	}

	// Token: 0x06004C47 RID: 19527 RVA: 0x000A9FAC File Offset: 0x000A81AC
	public TsAnimNotifyStateShowUiWeapon() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateShowUiWeapon.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004C48 RID: 19528 RVA: 0x000A9FD4 File Offset: 0x000A81D4
	[NullableContext(1)]
	public TsAnimNotifyStateShowUiWeapon(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateShowUiWeapon.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004C49 RID: 19529 RVA: 0x000AA007 File Offset: 0x000A8207
	protected TsAnimNotifyStateShowUiWeapon(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004C4A RID: 19530 RVA: 0x000AA010 File Offset: 0x000A8210
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x06004C4B RID: 19531 RVA: 0x000AA04C File Offset: 0x000A824C
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06004C4C RID: 19532 RVA: 0x000AA07F File Offset: 0x000A827F
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotifyState.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x040015D1 RID: 5585
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateShowUiWeapon.TsAnimNotifyStateShowUiWeapon_C";

	// Token: 0x040015D2 RID: 5586
	private static IntPtr _ClassPtr;

	// Token: 0x040015D3 RID: 5587
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x040015D4 RID: 5588
	private static int __PropertyOffset_WeaponIndex;

	// Token: 0x040015D5 RID: 5589
	private static int __PropertyOffset_ShowMaterialController;

	// Token: 0x040015D6 RID: 5590
	private static int __PropertyOffset_HideEffect;

	// Token: 0x040015D7 RID: 5591
	private static int __PropertyOffset_Transform;

	// Token: 0x040015D8 RID: 5592
	private static int __PropertyOffset_HangSocketName;
}
