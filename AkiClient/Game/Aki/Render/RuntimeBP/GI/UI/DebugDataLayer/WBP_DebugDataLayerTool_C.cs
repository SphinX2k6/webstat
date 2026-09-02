using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.GI.UI.DebugDataLayer
{
	// Token: 0x02003CA7 RID: 15527
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/GI/UI/DebugDataLayer/WBP_DebugDataLayerTool.WBP_DebugDataLayerTool_C")]
	[UnrealStructLayout(1216, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1216)]
	public class WBP_DebugDataLayerTool_C : UUserWidget, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060249C5 RID: 149957 RVA: 0x009A2A6C File Offset: 0x009A0C6C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (WBP_DebugDataLayerTool_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/GI/UI/DebugDataLayer/WBP_DebugDataLayerTool.WBP_DebugDataLayerTool_C");
			}
			return WBP_DebugDataLayerTool_C._ClassPtr;
		}

		// Token: 0x060249C6 RID: 149958 RVA: 0x009A2A90 File Offset: 0x009A0C90
		public WBP_DebugDataLayerTool_C() : this(BuiltinUtils.AllocNativeUObject(WBP_DebugDataLayerTool_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060249C7 RID: 149959 RVA: 0x009A2AB8 File Offset: 0x009A0CB8
		[NullableContext(1)]
		public WBP_DebugDataLayerTool_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(WBP_DebugDataLayerTool_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004CF5 RID: 19701
		// (get) Token: 0x060249C8 RID: 149960 RVA: 0x009A2AEC File Offset: 0x009A0CEC
		// (set) Token: 0x060249C9 RID: 149961 RVA: 0x009A2B25 File Offset: 0x009A0D25
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)WBP_DebugDataLayerTool_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)WBP_DebugDataLayerTool_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004CF6 RID: 19702
		// (get) Token: 0x060249CA RID: 149962 RVA: 0x009A2B46 File Offset: 0x009A0D46
		// (set) Token: 0x060249CB RID: 149963 RVA: 0x009A2B5A File Offset: 0x009A0D5A
		public unsafe UButton Button_1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UButton>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_DebugDataLayerTool_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_DebugDataLayerTool_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17004CF7 RID: 19703
		// (get) Token: 0x060249CC RID: 149964 RVA: 0x009A2B6F File Offset: 0x009A0D6F
		// (set) Token: 0x060249CD RID: 149965 RVA: 0x009A2B83 File Offset: 0x009A0D83
		public unsafe UImage Image_50
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UImage>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_DebugDataLayerTool_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_DebugDataLayerTool_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17004CF8 RID: 19704
		// (get) Token: 0x060249CE RID: 149966 RVA: 0x009A2B98 File Offset: 0x009A0D98
		// (set) Token: 0x060249CF RID: 149967 RVA: 0x009A2BAC File Offset: 0x009A0DAC
		public unsafe UListView VIew
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UListView>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_DebugDataLayerTool_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_DebugDataLayerTool_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17004CF9 RID: 19705
		// (get) Token: 0x060249D0 RID: 149968 RVA: 0x009A2BC4 File Offset: 0x009A0DC4
		// (set) Token: 0x060249D1 RID: 149969 RVA: 0x009A2BFD File Offset: 0x009A0DFD
		[Nullable(1)]
		public TArray<string> AllDataLayers
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<string> result;
				if ((result = this._AllDataLayers) == null)
				{
					result = (this._AllDataLayers = new TArray<string>(base.NativePtr + (IntPtr)WBP_DebugDataLayerTool_C.__PropertyOffset_4, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.AllDataLayers.CopyAssign(value);
			}
		}

		// Token: 0x060249D2 RID: 149970 RVA: 0x009A2C0B File Offset: 0x009A0E0B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Init()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, WBP_DebugDataLayerTool_C.__Init_NativeFunctionPtr, null);
		}

		// Token: 0x060249D3 RID: 149971 RVA: 0x009A2C1F File Offset: 0x009A0E1F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void BndEvt__WBP_DebugDataLayerTool_Button_1_K2Node_ComponentBoundEvent_0_OnButtonClickedEvent__DelegateSignature()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, WBP_DebugDataLayerTool_C.__BndEvt__WBP_DebugDataLayerTool_Button_1_K2Node_ComponentBoundEvent_0_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr, null);
		}

		// Token: 0x060249D4 RID: 149972 RVA: 0x009A2C34 File Offset: 0x009A0E34
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_WBP_DebugDataLayerTool(int EntryPoint)
		{
			WBP_DebugDataLayerTool_C.__ExecuteUbergraph_WBP_DebugDataLayerTool_FunctionParams* ptr = stackalloc WBP_DebugDataLayerTool_C.__ExecuteUbergraph_WBP_DebugDataLayerTool_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(WBP_DebugDataLayerTool_C.__ExecuteUbergraph_WBP_DebugDataLayerTool_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(WBP_DebugDataLayerTool_C.__ExecuteUbergraph_WBP_DebugDataLayerTool_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, WBP_DebugDataLayerTool_C.__ExecuteUbergraph_WBP_DebugDataLayerTool_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060249D5 RID: 149973 RVA: 0x009A2C7B File Offset: 0x009A0E7B
		protected WBP_DebugDataLayerTool_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04012C50 RID: 76880
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/GI/UI/DebugDataLayer/WBP_DebugDataLayerTool.WBP_DebugDataLayerTool_C";

		// Token: 0x04012C51 RID: 76881
		private static IntPtr _ClassPtr;

		// Token: 0x04012C52 RID: 76882
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04012C53 RID: 76883
		internal static int __PropertyOffset_0;

		// Token: 0x04012C54 RID: 76884
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04012C55 RID: 76885
		internal static int __PropertyOffset_1;

		// Token: 0x04012C56 RID: 76886
		internal static int __PropertyOffset_2;

		// Token: 0x04012C57 RID: 76887
		internal static int __PropertyOffset_3;

		// Token: 0x04012C58 RID: 76888
		internal static int __PropertyOffset_4;

		// Token: 0x04012C59 RID: 76889
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<string> _AllDataLayers;

		// Token: 0x04012C5A RID: 76890
		private static IntPtr __Init_NativeFunctionPtr;

		// Token: 0x04012C5B RID: 76891
		private static IntPtr __BndEvt__WBP_DebugDataLayerTool_Button_1_K2Node_ComponentBoundEvent_0_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04012C5C RID: 76892
		private static IntPtr __ExecuteUbergraph_WBP_DebugDataLayerTool_NativeFunctionPtr;

		// Token: 0x02009E20 RID: 40480
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __ExecuteUbergraph_WBP_DebugDataLayerTool_FunctionParams
		{
			// Token: 0x0403286B RID: 206955
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
