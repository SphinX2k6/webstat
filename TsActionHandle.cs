using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000E67 RID: 3687
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/Controller/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/Controller/TsActionHandle.TsActionHandle_C")]
public class TsActionHandle : UObject, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000644 RID: 1604
	// (get) Token: 0x06005909 RID: 22793 RVA: 0x00109A3E File Offset: 0x00107C3E
	// (set) Token: 0x0600590A RID: 22794 RVA: 0x00109A52 File Offset: 0x00107C52
	[Nullable(2)]
	[UProperty(EPropertyFlags.CPF_None)]
	private unsafe TsBasePlayerController PlayerController
	{
		[NullableContext(2)]
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<TsBasePlayerController>(base.NativePtr / (IntPtr)sizeof(void*) + TsActionHandle.__PropertyOffset_PlayerController);
		}
		[NullableContext(2)]
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TsActionHandle.__PropertyOffset_PlayerController, value);
		}
	}

	// Token: 0x17000645 RID: 1605
	// (get) Token: 0x0600590B RID: 22795 RVA: 0x00109A67 File Offset: 0x00107C67
	// (set) Token: 0x0600590C RID: 22796 RVA: 0x00109A7B File Offset: 0x00107C7B
	[UProperty(EPropertyFlags.CPF_None)]
	private unsafe string ActionName
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsActionHandle.__PropertyOffset_ActionName)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsActionHandle.__PropertyOffset_ActionName)), value);
		}
	}

	// Token: 0x0600590D RID: 22797 RVA: 0x00109A90 File Offset: 0x00107C90
	public void Initialize(TsBasePlayerController playerController)
	{
		this.PlayerController = playerController;
		this.OnPressStat = Stat.Create("TsActionHandle.OnPressAction", "", "STATGROUP_KuroBattle");
		this.OnReleaseStat = Stat.Create("TsActionHandle.OnReleaseAction", "", "STATGROUP_KuroBattle");
	}

	// Token: 0x0600590E RID: 22798 RVA: 0x00109ACD File Offset: 0x00107CCD
	public void Reset()
	{
		this.PlayerController = null;
		this.ActionName = string.Empty;
		this.OnInputActionCallback = null;
	}

	// Token: 0x0600590F RID: 22799 RVA: 0x00109AE8 File Offset: 0x00107CE8
	public void AddActionBinding(string actionName, [Nullable(new byte[]
	{
		2,
		1,
		1
	})] Action<string, bool, FKey> onInputAction)
	{
		if (onInputAction == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Controller;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "添加Action输入绑定时，回调不存在";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("actionName", actionName);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		this.ActionName = actionName;
		this.OnInputActionCallback = onInputAction;
		FName? dynamicFName = FNameUtil.GetDynamicFName(actionName);
		if (dynamicFName == null)
		{
			return;
		}
		TsBasePlayerController playerController = this.PlayerController;
		FName value;
		FName fname;
		if (playerController != null)
		{
			value = dynamicFName.Value;
			EInputEvent keyEvent = EInputEvent.IE_Pressed;
			fname = new FName("OnPressAction");
			playerController.AddActionBinding(value, keyEvent, this, fname);
		}
		TsBasePlayerController playerController2 = this.PlayerController;
		if (playerController2 == null)
		{
			return;
		}
		value = dynamicFName.Value;
		EInputEvent keyEvent2 = EInputEvent.IE_Released;
		fname = new FName("OnReleaseAction");
		playerController2.AddActionBinding(value, keyEvent2, this, fname);
	}

	// Token: 0x06005910 RID: 22800 RVA: 0x00109B98 File Offset: 0x00107D98
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	protected unsafe virtual void OnPressAction(FKey key)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("OnPressAction"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsActionHandle.__OnPressAction_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsActionHandle.__OnPressAction_FunctionParams*)ptr + 15L / (long)sizeof(TsActionHandle.__OnPressAction_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			UnrealReflectionUtils.CopyNativeStruct(FKey.StaticStruct(), &ptr2->key, (key != null) ? key.NativePtr : ((IntPtr)0), 1, false);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x06005911 RID: 22801 RVA: 0x00109C27 File Offset: 0x00107E27
	protected void OnPressAction_Implementation(FKey key)
	{
		Action<string, bool, FKey> onInputActionCallback = this.OnInputActionCallback;
		if (onInputActionCallback == null)
		{
			return;
		}
		onInputActionCallback(this.ActionName, true, key);
	}

	// Token: 0x06005912 RID: 22802 RVA: 0x00109C44 File Offset: 0x00107E44
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	protected unsafe virtual void OnReleaseAction(FKey key)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("OnReleaseAction"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsActionHandle.__OnReleaseAction_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsActionHandle.__OnReleaseAction_FunctionParams*)ptr + 15L / (long)sizeof(TsActionHandle.__OnReleaseAction_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			UnrealReflectionUtils.CopyNativeStruct(FKey.StaticStruct(), &ptr2->key, (key != null) ? key.NativePtr : ((IntPtr)0), 1, false);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x06005913 RID: 22803 RVA: 0x00109CD3 File Offset: 0x00107ED3
	protected void OnReleaseAction_Implementation(FKey key)
	{
		Action<string, bool, FKey> onInputActionCallback = this.OnInputActionCallback;
		if (onInputActionCallback == null)
		{
			return;
		}
		onInputActionCallback(this.ActionName, false, key);
	}

	// Token: 0x06005914 RID: 22804 RVA: 0x00109CED File Offset: 0x00107EED
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsActionHandle._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/Controller/TsActionHandle.TsActionHandle_C");
		}
		return TsActionHandle._ClassPtr;
	}

	// Token: 0x06005915 RID: 22805 RVA: 0x00109D14 File Offset: 0x00107F14
	public TsActionHandle() : this(BuiltinUtils.AllocNativeUObject(TsActionHandle.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06005916 RID: 22806 RVA: 0x00109D3C File Offset: 0x00107F3C
	public TsActionHandle(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsActionHandle.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06005917 RID: 22807 RVA: 0x00109D6F File Offset: 0x00107F6F
	protected TsActionHandle(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06005918 RID: 22808 RVA: 0x00109D78 File Offset: 0x00107F78
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_OnPressAction_Implementation(TsActionHandle.__OnPressAction_FunctionParams* __Params)
	{
		FKey key = new FKey(&__Params->key, true, true);
		this.OnPressAction_Implementation(key);
	}

	// Token: 0x06005919 RID: 22809 RVA: 0x00109D9C File Offset: 0x00107F9C
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_OnReleaseAction_Implementation(TsActionHandle.__OnReleaseAction_FunctionParams* __Params)
	{
		FKey key = new FKey(&__Params->key, true, true);
		this.OnReleaseAction_Implementation(key);
	}

	// Token: 0x04002954 RID: 10580
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private Action<string, bool, FKey> OnInputActionCallback;

	// Token: 0x04002955 RID: 10581
	[Nullable(2)]
	private Stat OnPressStat;

	// Token: 0x04002956 RID: 10582
	[Nullable(2)]
	private Stat OnReleaseStat;

	// Token: 0x04002957 RID: 10583
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/Controller/TsActionHandle.TsActionHandle_C";

	// Token: 0x04002958 RID: 10584
	private static IntPtr _ClassPtr;

	// Token: 0x04002959 RID: 10585
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400295A RID: 10586
	private static int __PropertyOffset_PlayerController;

	// Token: 0x0400295B RID: 10587
	private static int __PropertyOffset_ActionName;

	// Token: 0x02007298 RID: 29336
	[NullableContext(0)]
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __OnPressAction_FunctionParams
	{
		// Token: 0x04027BED RID: 162797
		[FieldOffset(0)]
		public byte key;
	}

	// Token: 0x02007299 RID: 29337
	[NullableContext(0)]
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __OnReleaseAction_FunctionParams
	{
		// Token: 0x04027BEE RID: 162798
		[FieldOffset(0)]
		public byte key;
	}
}
