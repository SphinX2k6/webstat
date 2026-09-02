using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000D83 RID: 3459
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateShowUiCalabash.TsAnimNotifyStateShowUiCalabash_C")]
public class TsAnimNotifyStateShowUiCalabash : TsAnimNotifyStateBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x1700047E RID: 1150
	// (get) Token: 0x06004C07 RID: 19463 RVA: 0x000A8F87 File Offset: 0x000A7187
	// (set) Token: 0x06004C08 RID: 19464 RVA: 0x000A8F9B File Offset: 0x000A719B
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FName Socket
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateShowUiCalabash.__PropertyOffset_Socket);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateShowUiCalabash.__PropertyOffset_Socket) = value;
		}
	}

	// Token: 0x1700047F RID: 1151
	// (get) Token: 0x06004C09 RID: 19465 RVA: 0x000A8FB0 File Offset: 0x000A71B0
	// (set) Token: 0x06004C0A RID: 19466 RVA: 0x000A8FC0 File Offset: 0x000A71C0
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool IsRotate
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateShowUiCalabash.__PropertyOffset_IsRotate) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateShowUiCalabash.__PropertyOffset_IsRotate) = (value ? 1 : 0);
		}
	}

	// Token: 0x06004C0B RID: 19467 RVA: 0x000A8FD4 File Offset: 0x000A71D4
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

	// Token: 0x06004C0C RID: 19468 RVA: 0x000A907C File Offset: 0x000A727C
	[NullableContext(2)]
	protected unsafe virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		if (this.Socket == FName.NAME_None)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Character;
			ELogAuthor author = ELogAuthor.LZK;
			string message = "Ui界面葫芦显示动画通知中socket配置为空";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("meshComp", meshComp);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("animation", animation);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return false;
		}
		AActor owner = meshComp.GetOwner();
		if (owner is TsUiSceneRoleActor)
		{
			UiCalabashAnsContext value = new UiCalabashAnsContext(this.Socket, this.IsRotate);
			UiModelBase model = (owner as TsUiSceneRoleActor).Model;
			if (model != null)
			{
				model.CheckGetComponent<UiModelAnsControllerComponent>().AddAns<UiCalabashAnsContext>("UiCalabashAnsContext", value);
			}
		}
		return false;
	}

	// Token: 0x06004C0D RID: 19469 RVA: 0x000A9134 File Offset: 0x000A7334
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

	// Token: 0x06004C0E RID: 19470 RVA: 0x000A91D4 File Offset: 0x000A73D4
	[NullableContext(2)]
	protected unsafe virtual bool K2_NotifyEnd_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		if (this.Socket == FName.NAME_None)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Character;
			ELogAuthor author = ELogAuthor.LZK;
			string message = "Ui界面葫芦显示动画通知中socket配置为空";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("meshComp", meshComp);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("animation", animation);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return false;
		}
		AActor owner = meshComp.GetOwner();
		if (owner is TsUiSceneRoleActor)
		{
			UiCalabashAnsContext value = new UiCalabashAnsContext(this.Socket, this.IsRotate);
			UiModelBase model = (owner as TsUiSceneRoleActor).Model;
			if (model != null)
			{
				model.CheckGetComponent<UiModelAnsControllerComponent>().ReduceAns<UiCalabashAnsContext>("UiCalabashAnsContext", value);
			}
		}
		return false;
	}

	// Token: 0x06004C0F RID: 19471 RVA: 0x000A928C File Offset: 0x000A748C
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

	// Token: 0x06004C10 RID: 19472 RVA: 0x000A9307 File Offset: 0x000A7507
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "Ui界面葫芦显示";
	}

	// Token: 0x06004C11 RID: 19473 RVA: 0x000A930E File Offset: 0x000A750E
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStateShowUiCalabash._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateShowUiCalabash.TsAnimNotifyStateShowUiCalabash_C");
		}
		return TsAnimNotifyStateShowUiCalabash._ClassPtr;
	}

	// Token: 0x06004C12 RID: 19474 RVA: 0x000A9334 File Offset: 0x000A7534
	public TsAnimNotifyStateShowUiCalabash() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateShowUiCalabash.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004C13 RID: 19475 RVA: 0x000A935C File Offset: 0x000A755C
	[NullableContext(1)]
	public TsAnimNotifyStateShowUiCalabash(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateShowUiCalabash.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004C14 RID: 19476 RVA: 0x000A938F File Offset: 0x000A758F
	protected TsAnimNotifyStateShowUiCalabash(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004C15 RID: 19477 RVA: 0x000A9398 File Offset: 0x000A7598
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x06004C16 RID: 19478 RVA: 0x000A93D4 File Offset: 0x000A75D4
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06004C17 RID: 19479 RVA: 0x000A9407 File Offset: 0x000A7607
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotifyState.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x040015C1 RID: 5569
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateShowUiCalabash.TsAnimNotifyStateShowUiCalabash_C";

	// Token: 0x040015C2 RID: 5570
	private static IntPtr _ClassPtr;

	// Token: 0x040015C3 RID: 5571
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x040015C4 RID: 5572
	private static int __PropertyOffset_Socket;

	// Token: 0x040015C5 RID: 5573
	private static int __PropertyOffset_IsRotate;
}
