using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.UI.Module.Common.View.Widget;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.GI.UI.DebugPostProcess
{
	// Token: 0x02003CA4 RID: 15524
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/GI/UI/DebugPostProcess/WBP_DebugPostProcess.WBP_DebugPostProcess_C")]
	[UnrealStructLayout(1248, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1244)]
	public class WBP_DebugPostProcess_C : UUserWidget, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602497C RID: 149884 RVA: 0x009A208F File Offset: 0x009A028F
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (WBP_DebugPostProcess_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/GI/UI/DebugPostProcess/WBP_DebugPostProcess.WBP_DebugPostProcess_C");
			}
			return WBP_DebugPostProcess_C._ClassPtr;
		}

		// Token: 0x0602497D RID: 149885 RVA: 0x009A20B4 File Offset: 0x009A02B4
		public WBP_DebugPostProcess_C() : this(BuiltinUtils.AllocNativeUObject(WBP_DebugPostProcess_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602497E RID: 149886 RVA: 0x009A20DC File Offset: 0x009A02DC
		[NullableContext(1)]
		public WBP_DebugPostProcess_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(WBP_DebugPostProcess_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004CE1 RID: 19681
		// (get) Token: 0x0602497F RID: 149887 RVA: 0x009A2110 File Offset: 0x009A0310
		// (set) Token: 0x06024980 RID: 149888 RVA: 0x009A2149 File Offset: 0x009A0349
		[Nullable(1)]
		public FPointerToUberGraphFrame UberGraphFrame
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)WBP_DebugPostProcess_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)WBP_DebugPostProcess_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004CE2 RID: 19682
		// (get) Token: 0x06024981 RID: 149889 RVA: 0x009A216A File Offset: 0x009A036A
		// (set) Token: 0x06024982 RID: 149890 RVA: 0x009A217E File Offset: 0x009A037E
		public unsafe KuroImage_C BG
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<KuroImage_C>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_DebugPostProcess_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_DebugPostProcess_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17004CE3 RID: 19683
		// (get) Token: 0x06024983 RID: 149891 RVA: 0x009A2193 File Offset: 0x009A0393
		// (set) Token: 0x06024984 RID: 149892 RVA: 0x009A21A7 File Offset: 0x009A03A7
		public unsafe UButton BtnClose
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UButton>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_DebugPostProcess_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_DebugPostProcess_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17004CE4 RID: 19684
		// (get) Token: 0x06024985 RID: 149893 RVA: 0x009A21BC File Offset: 0x009A03BC
		// (set) Token: 0x06024986 RID: 149894 RVA: 0x009A21D0 File Offset: 0x009A03D0
		public unsafe UButton Button_46
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UButton>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_DebugPostProcess_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_DebugPostProcess_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17004CE5 RID: 19685
		// (get) Token: 0x06024987 RID: 149895 RVA: 0x009A21E5 File Offset: 0x009A03E5
		// (set) Token: 0x06024988 RID: 149896 RVA: 0x009A21F9 File Offset: 0x009A03F9
		public unsafe UCheckBox CheckIsAutoRefresh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCheckBox>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_DebugPostProcess_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_DebugPostProcess_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17004CE6 RID: 19686
		// (get) Token: 0x06024989 RID: 149897 RVA: 0x009A220E File Offset: 0x009A040E
		// (set) Token: 0x0602498A RID: 149898 RVA: 0x009A2222 File Offset: 0x009A0422
		public unsafe UComboBoxString ComboBoxString_3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UComboBoxString>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_DebugPostProcess_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_DebugPostProcess_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17004CE7 RID: 19687
		// (get) Token: 0x0602498B RID: 149899 RVA: 0x009A2237 File Offset: 0x009A0437
		// (set) Token: 0x0602498C RID: 149900 RVA: 0x009A224B File Offset: 0x009A044B
		public unsafe UListView ListInfo
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UListView>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_DebugPostProcess_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_DebugPostProcess_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x17004CE8 RID: 19688
		// (get) Token: 0x0602498D RID: 149901 RVA: 0x009A2260 File Offset: 0x009A0460
		// (set) Token: 0x0602498E RID: 149902 RVA: 0x009A2274 File Offset: 0x009A0474
		public unsafe KuroImage_C TitleBG
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<KuroImage_C>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_DebugPostProcess_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_DebugPostProcess_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x17004CE9 RID: 19689
		// (get) Token: 0x0602498F RID: 149903 RVA: 0x009A2289 File Offset: 0x009A0489
		// (set) Token: 0x06024990 RID: 149904 RVA: 0x009A229D File Offset: 0x009A049D
		public unsafe UWidgetSwitcher WidgetSwitcher_0
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UWidgetSwitcher>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_DebugPostProcess_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_DebugPostProcess_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x17004CEA RID: 19690
		// (get) Token: 0x06024991 RID: 149905 RVA: 0x009A22B2 File Offset: 0x009A04B2
		// (set) Token: 0x06024992 RID: 149906 RVA: 0x009A22C2 File Offset: 0x009A04C2
		public unsafe float Timer
		{
			get
			{
				return *(base.NativePtr + (IntPtr)WBP_DebugPostProcess_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)WBP_DebugPostProcess_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x06024993 RID: 149907 RVA: 0x009A22D3 File Offset: 0x009A04D3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Init()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, WBP_DebugPostProcess_C.__Init_NativeFunctionPtr, null);
		}

		// Token: 0x06024994 RID: 149908 RVA: 0x009A22E8 File Offset: 0x009A04E8
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual FText Get_TxtPostProcessCount_ToolTipText_0()
		{
			WBP_DebugPostProcess_C.__Get_TxtPostProcessCount_ToolTipText_0_FunctionParams* ptr = stackalloc WBP_DebugPostProcess_C.__Get_TxtPostProcessCount_ToolTipText_0_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(WBP_DebugPostProcess_C.__Get_TxtPostProcessCount_ToolTipText_0_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(WBP_DebugPostProcess_C.__Get_TxtPostProcessCount_ToolTipText_0_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, WBP_DebugPostProcess_C.__Get_TxtPostProcessCount_ToolTipText_0_NativeFunctionPtr, (void*)ptr);
			FText result = new FText(&ptr->__Result, true, true);
			UnrealReflectionUtils.DestroyStruct(WBP_DebugPostProcess_C.__Get_TxtPostProcessCount_ToolTipText_0_NativeFunctionPtr, (void*)ptr, 1);
			return result;
		}

		// Token: 0x06024995 RID: 149909 RVA: 0x009A2346 File Offset: 0x009A0546
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void BndEvt__WBP_DebugPostProcess_BtnClose_K2Node_ComponentBoundEvent_0_OnButtonClickedEvent__DelegateSignature()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, WBP_DebugPostProcess_C.__BndEvt__WBP_DebugPostProcess_BtnClose_K2Node_ComponentBoundEvent_0_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr, null);
		}

		// Token: 0x06024996 RID: 149910 RVA: 0x009A235C File Offset: 0x009A055C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void Tick(FGeometry MyGeometry, float InDeltaTime)
		{
			WBP_DebugPostProcess_C.__Tick_FunctionParams* ptr = stackalloc WBP_DebugPostProcess_C.__Tick_FunctionParams[(UIntPtr)75] + 15L / (long)sizeof(WBP_DebugPostProcess_C.__Tick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(WBP_DebugPostProcess_C.__Tick_NativeFunctionPtr, (void*)ptr, 1);
			if (MyGeometry != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FGeometry.StaticStruct(), &ptr->MyGeometry, MyGeometry.NativePtr, 1, false);
			}
			ptr->InDeltaTime = InDeltaTime;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, WBP_DebugPostProcess_C.__Tick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024997 RID: 149911 RVA: 0x009A23C4 File Offset: 0x009A05C4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void Tick_Implementation(FGeometry MyGeometry, float InDeltaTime)
		{
			WBP_DebugPostProcess_C.__Tick_FunctionParams* ptr = stackalloc WBP_DebugPostProcess_C.__Tick_FunctionParams[(UIntPtr)75] + 15L / (long)sizeof(WBP_DebugPostProcess_C.__Tick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(WBP_DebugPostProcess_C.__Tick_NativeFunctionPtr, (void*)ptr, 1);
			if (MyGeometry != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FGeometry.StaticStruct(), &ptr->MyGeometry, MyGeometry.NativePtr, 1, false);
			}
			ptr->InDeltaTime = InDeltaTime;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, WBP_DebugPostProcess_C.__Tick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024998 RID: 149912 RVA: 0x009A242D File Offset: 0x009A062D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void BndEvt__WBP_DebugPostProcess_Button_46_K2Node_ComponentBoundEvent_1_OnButtonClickedEvent__DelegateSignature()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, WBP_DebugPostProcess_C.__BndEvt__WBP_DebugPostProcess_Button_46_K2Node_ComponentBoundEvent_1_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr, null);
		}

		// Token: 0x06024999 RID: 149913 RVA: 0x009A2444 File Offset: 0x009A0644
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_WBP_DebugPostProcess(int EntryPoint)
		{
			WBP_DebugPostProcess_C.__ExecuteUbergraph_WBP_DebugPostProcess_FunctionParams* ptr = stackalloc WBP_DebugPostProcess_C.__ExecuteUbergraph_WBP_DebugPostProcess_FunctionParams[(UIntPtr)623] + 15L / (long)sizeof(WBP_DebugPostProcess_C.__ExecuteUbergraph_WBP_DebugPostProcess_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(WBP_DebugPostProcess_C.__ExecuteUbergraph_WBP_DebugPostProcess_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, WBP_DebugPostProcess_C.__ExecuteUbergraph_WBP_DebugPostProcess_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602499A RID: 149914 RVA: 0x009A248E File Offset: 0x009A068E
		protected WBP_DebugPostProcess_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04012C21 RID: 76833
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/GI/UI/DebugPostProcess/WBP_DebugPostProcess.WBP_DebugPostProcess_C";

		// Token: 0x04012C22 RID: 76834
		private static IntPtr _ClassPtr;

		// Token: 0x04012C23 RID: 76835
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04012C24 RID: 76836
		internal static int __PropertyOffset_0;

		// Token: 0x04012C25 RID: 76837
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04012C26 RID: 76838
		internal static int __PropertyOffset_1;

		// Token: 0x04012C27 RID: 76839
		internal static int __PropertyOffset_2;

		// Token: 0x04012C28 RID: 76840
		internal static int __PropertyOffset_3;

		// Token: 0x04012C29 RID: 76841
		internal static int __PropertyOffset_4;

		// Token: 0x04012C2A RID: 76842
		internal static int __PropertyOffset_5;

		// Token: 0x04012C2B RID: 76843
		internal static int __PropertyOffset_6;

		// Token: 0x04012C2C RID: 76844
		internal static int __PropertyOffset_7;

		// Token: 0x04012C2D RID: 76845
		internal static int __PropertyOffset_8;

		// Token: 0x04012C2E RID: 76846
		internal static int __PropertyOffset_9;

		// Token: 0x04012C2F RID: 76847
		private static IntPtr __Init_NativeFunctionPtr;

		// Token: 0x04012C30 RID: 76848
		private static IntPtr __Get_TxtPostProcessCount_ToolTipText_0_NativeFunctionPtr;

		// Token: 0x04012C31 RID: 76849
		private static IntPtr __BndEvt__WBP_DebugPostProcess_BtnClose_K2Node_ComponentBoundEvent_0_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04012C32 RID: 76850
		private static IntPtr __Tick_NativeFunctionPtr;

		// Token: 0x04012C33 RID: 76851
		private static IntPtr __BndEvt__WBP_DebugPostProcess_Button_46_K2Node_ComponentBoundEvent_1_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04012C34 RID: 76852
		private static IntPtr __ExecuteUbergraph_WBP_DebugPostProcess_NativeFunctionPtr;

		// Token: 0x02009E18 RID: 40472
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __Get_TxtPostProcessCount_ToolTipText_0_FunctionParams
		{
			// Token: 0x04032861 RID: 206945
			[FieldOffset(0)]
			public byte __Result;
		}

		// Token: 0x02009E19 RID: 40473
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 60)]
		protected new ref struct __Tick_FunctionParams
		{
			// Token: 0x04032862 RID: 206946
			[FieldOffset(0)]
			public byte MyGeometry;

			// Token: 0x04032863 RID: 206947
			[FieldOffset(56)]
			public float InDeltaTime;
		}

		// Token: 0x02009E1A RID: 40474
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 608)]
		protected ref struct __ExecuteUbergraph_WBP_DebugPostProcess_FunctionParams
		{
			// Token: 0x04032864 RID: 206948
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
