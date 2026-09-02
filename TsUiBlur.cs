using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Extension;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02002C50 RID: 11344
[NullableContext(2)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/Module/UiComponent/Effect/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/Module/UiComponent/Effect/TsUiBlur.TsUiBlur_C")]
public class TsUiBlur : ULGUIBehaviour, IUnrealUObject, IUnrealObject
{
	// Token: 0x17001DCF RID: 7631
	// (get) Token: 0x06016BD8 RID: 93144 RVA: 0x0064F51F File Offset: 0x0064D71F
	// (set) Token: 0x06016BD9 RID: 93145 RVA: 0x0064F533 File Offset: 0x0064D733
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe AActor OverrideItem
	{
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + TsUiBlur.__PropertyOffset_OverrideItem);
		}
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TsUiBlur.__PropertyOffset_OverrideItem, value);
		}
	}

	// Token: 0x17001DD0 RID: 7632
	// (get) Token: 0x06016BDA RID: 93146 RVA: 0x0064F548 File Offset: 0x0064D748
	// (set) Token: 0x06016BDB RID: 93147 RVA: 0x0064F558 File Offset: 0x0064D758
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool EnableUiBlur
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsUiBlur.__PropertyOffset_EnableUiBlur) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsUiBlur.__PropertyOffset_EnableUiBlur) = (value ? 1 : 0);
		}
	}

	// Token: 0x17001DD1 RID: 7633
	// (get) Token: 0x06016BDC RID: 93148 RVA: 0x0064F569 File Offset: 0x0064D769
	// (set) Token: 0x06016BDD RID: 93149 RVA: 0x0064F57D File Offset: 0x0064D77D
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe UUIItem ApplyItem
	{
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<UUIItem>(base.NativePtr / (IntPtr)sizeof(void*) + TsUiBlur.__PropertyOffset_ApplyItem);
		}
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TsUiBlur.__PropertyOffset_ApplyItem, value);
		}
	}

	// Token: 0x06016BDE RID: 93150 RVA: 0x0064F592 File Offset: 0x0064D792
	[NullableContext(1)]
	private UUIItem GetUiBlurComponent()
	{
		if (this.OverrideItem != null)
		{
			return this.OverrideItem.RootComponent as UUIItem;
		}
		return this.ApplyItem;
	}

	// Token: 0x06016BDF RID: 93151 RVA: 0x0064F5B3 File Offset: 0x0064D7B3
	private void SetGlobalBlurUiItem()
	{
		if (this.ApplyItem != null)
		{
			ULGUIBPLibrary.SetGlobalBlurUIItem(this.GetUiBlurComponent(), this.ApplyItem.GetWorld());
		}
	}

	// Token: 0x06016BE0 RID: 93152 RVA: 0x0064F5D3 File Offset: 0x0064D7D3
	private void ResetGlobalBlurUiItem()
	{
		ULGUIBPLibrary.ResetGlobalBlurUIItem(GlobalData.GameInstance.GetWorld());
	}

	// Token: 0x06016BE1 RID: 93153 RVA: 0x0064F5E4 File Offset: 0x0064D7E4
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void SetEnableUiBlur(bool value)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("SetEnableUiBlur"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsUiBlur.__SetEnableUiBlur_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsUiBlur.__SetEnableUiBlur_FunctionParams*)ptr + 15L / (long)sizeof(TsUiBlur.__SetEnableUiBlur_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->value = value;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x06016BE2 RID: 93154 RVA: 0x0064F65A File Offset: 0x0064D85A
	protected void SetEnableUiBlur_Implementation(bool value)
	{
		this.EnableUiBlur = value;
		if (value)
		{
			this.SetGlobalBlurUiItem();
			return;
		}
		this.ResetGlobalBlurUiItem();
	}

	// Token: 0x06016BE3 RID: 93155 RVA: 0x0064F673 File Offset: 0x0064D873
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsUiBlur._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/Module/UiComponent/Effect/TsUiBlur.TsUiBlur_C");
		}
		return TsUiBlur._ClassPtr;
	}

	// Token: 0x06016BE4 RID: 93156 RVA: 0x0064F698 File Offset: 0x0064D898
	public TsUiBlur() : this(BuiltinUtils.AllocNativeUObject(TsUiBlur.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06016BE5 RID: 93157 RVA: 0x0064F6C0 File Offset: 0x0064D8C0
	[NullableContext(1)]
	public TsUiBlur(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsUiBlur.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06016BE6 RID: 93158 RVA: 0x0064F6F3 File Offset: 0x0064D8F3
	protected TsUiBlur(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06016BE7 RID: 93159 RVA: 0x0064F6FC File Offset: 0x0064D8FC
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_SetEnableUiBlur_Implementation(TsUiBlur.__SetEnableUiBlur_FunctionParams* __Params)
	{
		this.SetEnableUiBlur_Implementation(__Params->value);
	}

	// Token: 0x0400AF44 RID: 44868
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/Module/UiComponent/Effect/TsUiBlur.TsUiBlur_C";

	// Token: 0x0400AF45 RID: 44869
	private static IntPtr _ClassPtr;

	// Token: 0x0400AF46 RID: 44870
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400AF47 RID: 44871
	private static int __PropertyOffset_OverrideItem;

	// Token: 0x0400AF48 RID: 44872
	private static int __PropertyOffset_EnableUiBlur;

	// Token: 0x0400AF49 RID: 44873
	private static int __PropertyOffset_ApplyItem;

	// Token: 0x02008F6B RID: 36715
	[NullableContext(0)]
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 1)]
	protected ref struct __SetEnableUiBlur_FunctionParams
	{
		// Token: 0x04030286 RID: 197254
		[FieldOffset(0)]
		public bool value;
	}
}
