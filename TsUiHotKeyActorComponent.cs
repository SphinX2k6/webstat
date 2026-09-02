using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.UiNavigation;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02002CC8 RID: 11464
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/Module/UiNavigation/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/Module/UiNavigation/TsUiHotKeyActorComponent.TsUiHotKeyActorComponent_C")]
public class TsUiHotKeyActorComponent : ULGUIBehaviour, IUnrealUObject, IUnrealObject
{
	// Token: 0x17001E66 RID: 7782
	// (get) Token: 0x0601715A RID: 94554 RVA: 0x00665BE6 File Offset: 0x00663DE6
	// (set) Token: 0x0601715B RID: 94555 RVA: 0x00665BFA File Offset: 0x00663DFA
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string Mode
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsUiHotKeyActorComponent.__PropertyOffset_Mode)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsUiHotKeyActorComponent.__PropertyOffset_Mode)), value);
		}
	}

	// Token: 0x17001E67 RID: 7783
	// (get) Token: 0x0601715C RID: 94556 RVA: 0x00665C0F File Offset: 0x00663E0F
	// (set) Token: 0x0601715D RID: 94557 RVA: 0x00665C1F File Offset: 0x00663E1F
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int Index
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsUiHotKeyActorComponent.__PropertyOffset_Index);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsUiHotKeyActorComponent.__PropertyOffset_Index) = value;
		}
	}

	// Token: 0x17001E68 RID: 7784
	// (get) Token: 0x0601715E RID: 94558 RVA: 0x00665C30 File Offset: 0x00663E30
	// (set) Token: 0x0601715F RID: 94559 RVA: 0x00665C40 File Offset: 0x00663E40
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool IsUsePool
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsUiHotKeyActorComponent.__PropertyOffset_IsUsePool) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsUiHotKeyActorComponent.__PropertyOffset_IsUsePool) = (value ? 1 : 0);
		}
	}

	// Token: 0x06017160 RID: 94560 RVA: 0x00665C54 File Offset: 0x00663E54
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void AwakeBP()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("AwakeBP"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* dest = null;
		if (num != 0)
		{
			dest = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, null);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
	}

	// Token: 0x06017161 RID: 94561 RVA: 0x00665CC4 File Offset: 0x00663EC4
	protected virtual void AwakeBP_Implementation()
	{
		this.UiHotKeyState = EUiHotKeyState.Awake;
	}

	// Token: 0x06017162 RID: 94562 RVA: 0x00665CD0 File Offset: 0x00663ED0
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void StartBP()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("StartBP"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* dest = null;
		if (num != 0)
		{
			dest = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, null);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
	}

	// Token: 0x06017163 RID: 94563 RVA: 0x00665D40 File Offset: 0x00663F40
	protected unsafe virtual void StartBP_Implementation()
	{
		if (GlobalData.GameInstance == null)
		{
			return;
		}
		if (this.Index <= 0)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.UiNavigation;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "当前配置的热键id是无效的,无法执行TsUiHotKeyActorComponent逻辑";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0);
			string item = "Path";
			UUIItem uuiitem = base.RootUIComp.Get();
			ptr = new ValueTuple<string, object>(item, UiNavigationUtil.GetFullPathOfActor((uuiitem != null) ? uuiitem.GetOwner() : null));
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Index", this.Index);
			instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return;
		}
		this.Start();
	}

	// Token: 0x06017164 RID: 94564 RVA: 0x00665DE4 File Offset: 0x00663FE4
	private UniTask Start()
	{
		TsUiHotKeyActorComponent.<Start>d__16 <Start>d__;
		<Start>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Start>d__.<>4__this = this;
		<Start>d__.<>1__state = -1;
		<Start>d__.<>t__builder.Start<TsUiHotKeyActorComponent.<Start>d__16>(ref <Start>d__);
		return <Start>d__.<>t__builder.Task;
	}

	// Token: 0x06017165 RID: 94565 RVA: 0x00665E28 File Offset: 0x00664028
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void OnEnableBP()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("OnEnableBP"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* dest = null;
		if (num != 0)
		{
			dest = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, null);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
	}

	// Token: 0x06017166 RID: 94566 RVA: 0x00665E98 File Offset: 0x00664098
	protected virtual void OnEnableBP_Implementation()
	{
		if (this.HotKeyItem == null)
		{
			return;
		}
		this.RegisterAllHotKeyComponent();
		this.TryResetPanelConfig();
	}

	// Token: 0x06017167 RID: 94567 RVA: 0x00665EB0 File Offset: 0x006640B0
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void OnDisableBP()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("OnDisableBP"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* dest = null;
		if (num != 0)
		{
			dest = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, null);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
	}

	// Token: 0x06017168 RID: 94568 RVA: 0x00665F20 File Offset: 0x00664120
	protected virtual void OnDisableBP_Implementation()
	{
		if (this.HotKeyItem == null)
		{
			return;
		}
		this.UnRegisterAllHotKeyComponent();
	}

	// Token: 0x06017169 RID: 94569 RVA: 0x00665F34 File Offset: 0x00664134
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void OnPreDestroyBP()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("OnPreDestroyBP"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* dest = null;
		if (num != 0)
		{
			dest = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, null);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
	}

	// Token: 0x0601716A RID: 94570 RVA: 0x00665FA4 File Offset: 0x006641A4
	protected virtual void OnPreDestroyBP_Implementation()
	{
		this.UnRegisterHotKeyItem();
		this.UiHotKeyState = EUiHotKeyState.Destroy;
	}

	// Token: 0x0601716B RID: 94571 RVA: 0x00665FB4 File Offset: 0x006641B4
	private UniTask RegisterHotKeyItem()
	{
		TsUiHotKeyActorComponent.<RegisterHotKeyItem>d__23 <RegisterHotKeyItem>d__;
		<RegisterHotKeyItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RegisterHotKeyItem>d__.<>4__this = this;
		<RegisterHotKeyItem>d__.<>1__state = -1;
		<RegisterHotKeyItem>d__.<>t__builder.Start<TsUiHotKeyActorComponent.<RegisterHotKeyItem>d__23>(ref <RegisterHotKeyItem>d__);
		return <RegisterHotKeyItem>d__.<>t__builder.Task;
	}

	// Token: 0x0601716C RID: 94572 RVA: 0x00665FF8 File Offset: 0x006641F8
	private unsafe void TryResetPanelConfig()
	{
		if (!this.IsUsePool)
		{
			return;
		}
		if (this.UiHotKeyState < EUiHotKeyState.Start)
		{
			return;
		}
		if (this.HotKeyItem == null)
		{
			return;
		}
		TsUiNavigationPanelConfig panelConfig = this.PanelConfig;
		if (panelConfig != null && panelConfig.IsValid())
		{
			TsUiNavigationPanelConfig panelConfig2 = this.PanelConfig;
			bool flag;
			if (panelConfig2 == null)
			{
				flag = false;
			}
			else
			{
				UUIItem uuiitem = panelConfig2.RootUIComp.Get();
				flag = ((uuiitem != null) ? new bool?(uuiitem.IsValid()) : null).GetValueOrDefault();
			}
			if (flag)
			{
				return;
			}
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.UiNavigation;
		ELogAuthor author = ELogAuthor.XXJ;
		string message = "可能存在从对象池获取的情况[UiHotKeyActorComponent]";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("GroupName", this.Index);
		ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
		string item = "Name";
		UUIItem uuiitem2 = base.RootUIComp.Get();
		ptr = new ValueTuple<string, object>(item, (uuiitem2 != null) ? uuiitem2.displayName : null);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		this.PanelConfig = UiNavigationLogic.FindUiNavigationPanelConfig(base.GetOwner());
		if (this.PanelConfig == null)
		{
			return;
		}
		this.PanelConfig.AddHotKeyItem(this.HotKeyItem);
	}

	// Token: 0x0601716D RID: 94573 RVA: 0x00666117 File Offset: 0x00664317
	private void UnRegisterHotKeyItem()
	{
		if (this.HotKeyItem == null)
		{
			return;
		}
		this.UnRegisterAllHotKeyComponent();
		this.HotKeyItem.Clear();
		if (this.PanelConfig == null)
		{
			return;
		}
		this.PanelConfig.DeleteKeyItem(this.HotKeyItem);
	}

	// Token: 0x0601716E RID: 94574 RVA: 0x00666150 File Offset: 0x00664350
	private void RegisterAllHotKeyComponent()
	{
		if (this.UiHotKeyState < EUiHotKeyState.Start)
		{
			return;
		}
		if (this.UiHotKeyState == EUiHotKeyState.Register)
		{
			return;
		}
		this.UiHotKeyState = EUiHotKeyState.Register;
		foreach (HotKeyComponent hotKeyComponent in this.HotKeyItem.GetHotKeyComponentArray())
		{
			if (hotKeyComponent != null)
			{
				this.RegisterHotKeyComponent(hotKeyComponent);
			}
		}
	}

	// Token: 0x0601716F RID: 94575 RVA: 0x006661C8 File Offset: 0x006643C8
	private void UnRegisterAllHotKeyComponent()
	{
		if (this.UiHotKeyState != EUiHotKeyState.Register)
		{
			return;
		}
		this.UiHotKeyState = EUiHotKeyState.UnRegister;
		foreach (HotKeyComponent hotKeyComponent in this.HotKeyItem.GetHotKeyComponentArray())
		{
			if (hotKeyComponent != null)
			{
				this.UnRegisterHotKeyComponent(hotKeyComponent);
			}
		}
	}

	// Token: 0x06017170 RID: 94576 RVA: 0x00666234 File Offset: 0x00664434
	private void RegisterHotKeyComponent(HotKeyComponent hotKeyComponent)
	{
		hotKeyComponent.RegisterMe();
		UiNavigationLogic.BindHotKeyComponentAction(hotKeyComponent, true);
		UiNavigationLogic.BindHotKeyComponentAxis(hotKeyComponent, true);
	}

	// Token: 0x06017171 RID: 94577 RVA: 0x0066624A File Offset: 0x0066444A
	private void UnRegisterHotKeyComponent(HotKeyComponent hotKeyComponent)
	{
		hotKeyComponent.UnRegisterMe();
		UiNavigationLogic.BindHotKeyComponentAction(hotKeyComponent, false);
		UiNavigationLogic.BindHotKeyComponentAxis(hotKeyComponent, false);
	}

	// Token: 0x06017172 RID: 94578 RVA: 0x00666260 File Offset: 0x00664460
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsUiHotKeyActorComponent._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/Module/UiNavigation/TsUiHotKeyActorComponent.TsUiHotKeyActorComponent_C");
		}
		return TsUiHotKeyActorComponent._ClassPtr;
	}

	// Token: 0x06017173 RID: 94579 RVA: 0x00666284 File Offset: 0x00664484
	public TsUiHotKeyActorComponent() : this(BuiltinUtils.AllocNativeUObject(TsUiHotKeyActorComponent.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06017174 RID: 94580 RVA: 0x006662AC File Offset: 0x006644AC
	public TsUiHotKeyActorComponent(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsUiHotKeyActorComponent.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06017175 RID: 94581 RVA: 0x006662DF File Offset: 0x006644DF
	protected TsUiHotKeyActorComponent(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06017176 RID: 94582 RVA: 0x006662E8 File Offset: 0x006644E8
	protected virtual void __CPPCALL_AwakeBP_Implementation()
	{
		this.AwakeBP_Implementation();
	}

	// Token: 0x06017177 RID: 94583 RVA: 0x006662F0 File Offset: 0x006644F0
	protected virtual void __CPPCALL_StartBP_Implementation()
	{
		this.StartBP_Implementation();
	}

	// Token: 0x06017178 RID: 94584 RVA: 0x006662F8 File Offset: 0x006644F8
	protected virtual void __CPPCALL_OnEnableBP_Implementation()
	{
		this.OnEnableBP_Implementation();
	}

	// Token: 0x06017179 RID: 94585 RVA: 0x00666300 File Offset: 0x00664500
	protected virtual void __CPPCALL_OnDisableBP_Implementation()
	{
		this.OnDisableBP_Implementation();
	}

	// Token: 0x0601717A RID: 94586 RVA: 0x00666308 File Offset: 0x00664508
	protected virtual void __CPPCALL_OnPreDestroyBP_Implementation()
	{
		this.OnPreDestroyBP_Implementation();
	}

	// Token: 0x0400B1AD RID: 45485
	[Nullable(2)]
	public HotKeyItem HotKeyItem;

	// Token: 0x0400B1AE RID: 45486
	[Nullable(2)]
	public TsUiNavigationPanelConfig PanelConfig;

	// Token: 0x0400B1AF RID: 45487
	private EUiHotKeyState UiHotKeyState;

	// Token: 0x0400B1B0 RID: 45488
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/Module/UiNavigation/TsUiHotKeyActorComponent.TsUiHotKeyActorComponent_C";

	// Token: 0x0400B1B1 RID: 45489
	private static IntPtr _ClassPtr;

	// Token: 0x0400B1B2 RID: 45490
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400B1B3 RID: 45491
	private static int __PropertyOffset_Mode;

	// Token: 0x0400B1B4 RID: 45492
	private static int __PropertyOffset_Index;

	// Token: 0x0400B1B5 RID: 45493
	private static int __PropertyOffset_IsUsePool;
}
