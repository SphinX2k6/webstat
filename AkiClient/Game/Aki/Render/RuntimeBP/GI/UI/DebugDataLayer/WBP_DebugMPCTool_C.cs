using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.GI.UI.DebugDataLayer
{
	// Token: 0x02003CA8 RID: 15528
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/GI/UI/DebugDataLayer/WBP_DebugMPCTool.WBP_DebugMPCTool_C")]
	[UnrealStructLayout(1256, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1256)]
	public class WBP_DebugMPCTool_C : UUserWidget, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060249D6 RID: 149974 RVA: 0x009A2C84 File Offset: 0x009A0E84
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (WBP_DebugMPCTool_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/GI/UI/DebugDataLayer/WBP_DebugMPCTool.WBP_DebugMPCTool_C");
			}
			return WBP_DebugMPCTool_C._ClassPtr;
		}

		// Token: 0x060249D7 RID: 149975 RVA: 0x009A2CA8 File Offset: 0x009A0EA8
		public WBP_DebugMPCTool_C() : this(BuiltinUtils.AllocNativeUObject(WBP_DebugMPCTool_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060249D8 RID: 149976 RVA: 0x009A2CD0 File Offset: 0x009A0ED0
		[NullableContext(1)]
		public WBP_DebugMPCTool_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(WBP_DebugMPCTool_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004CFA RID: 19706
		// (get) Token: 0x060249D9 RID: 149977 RVA: 0x009A2D04 File Offset: 0x009A0F04
		// (set) Token: 0x060249DA RID: 149978 RVA: 0x009A2D3D File Offset: 0x009A0F3D
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)WBP_DebugMPCTool_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)WBP_DebugMPCTool_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004CFB RID: 19707
		// (get) Token: 0x060249DB RID: 149979 RVA: 0x009A2D5E File Offset: 0x009A0F5E
		// (set) Token: 0x060249DC RID: 149980 RVA: 0x009A2D72 File Offset: 0x009A0F72
		public unsafe UButton Button_1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UButton>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_DebugMPCTool_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_DebugMPCTool_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17004CFC RID: 19708
		// (get) Token: 0x060249DD RID: 149981 RVA: 0x009A2D87 File Offset: 0x009A0F87
		// (set) Token: 0x060249DE RID: 149982 RVA: 0x009A2D9B File Offset: 0x009A0F9B
		public unsafe USlider farcloud
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USlider>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_DebugMPCTool_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_DebugMPCTool_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17004CFD RID: 19709
		// (get) Token: 0x060249DF RID: 149983 RVA: 0x009A2DB0 File Offset: 0x009A0FB0
		// (set) Token: 0x060249E0 RID: 149984 RVA: 0x009A2DC4 File Offset: 0x009A0FC4
		public unsafe UTextBlock farScale
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextBlock>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_DebugMPCTool_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_DebugMPCTool_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17004CFE RID: 19710
		// (get) Token: 0x060249E1 RID: 149985 RVA: 0x009A2DD9 File Offset: 0x009A0FD9
		// (set) Token: 0x060249E2 RID: 149986 RVA: 0x009A2DED File Offset: 0x009A0FED
		public unsafe UImage Image_50
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UImage>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_DebugMPCTool_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_DebugMPCTool_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17004CFF RID: 19711
		// (get) Token: 0x060249E3 RID: 149987 RVA: 0x009A2E02 File Offset: 0x009A1002
		// (set) Token: 0x060249E4 RID: 149988 RVA: 0x009A2E16 File Offset: 0x009A1016
		public unsafe USlider nearcloud
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USlider>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_DebugMPCTool_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_DebugMPCTool_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17004D00 RID: 19712
		// (get) Token: 0x060249E5 RID: 149989 RVA: 0x009A2E2B File Offset: 0x009A102B
		// (set) Token: 0x060249E6 RID: 149990 RVA: 0x009A2E3F File Offset: 0x009A103F
		public unsafe UTextBlock nearScale
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextBlock>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_DebugMPCTool_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_DebugMPCTool_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x17004D01 RID: 19713
		// (get) Token: 0x060249E7 RID: 149991 RVA: 0x009A2E54 File Offset: 0x009A1054
		// (set) Token: 0x060249E8 RID: 149992 RVA: 0x009A2E68 File Offset: 0x009A1068
		public unsafe USlider Slider
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USlider>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_DebugMPCTool_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_DebugMPCTool_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x17004D02 RID: 19714
		// (get) Token: 0x060249E9 RID: 149993 RVA: 0x009A2E7D File Offset: 0x009A107D
		// (set) Token: 0x060249EA RID: 149994 RVA: 0x009A2E91 File Offset: 0x009A1091
		public unsafe USlider Slider_11
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USlider>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_DebugMPCTool_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_DebugMPCTool_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x17004D03 RID: 19715
		// (get) Token: 0x060249EB RID: 149995 RVA: 0x009A2EA8 File Offset: 0x009A10A8
		// (set) Token: 0x060249EC RID: 149996 RVA: 0x009A2EE1 File Offset: 0x009A10E1
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
					result = (this._AllDataLayers = new TArray<string>(base.NativePtr + (IntPtr)WBP_DebugMPCTool_C.__PropertyOffset_9, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.AllDataLayers.CopyAssign(value);
			}
		}

		// Token: 0x060249ED RID: 149997 RVA: 0x009A2EF0 File Offset: 0x009A10F0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void Tick(FGeometry MyGeometry, float InDeltaTime)
		{
			WBP_DebugMPCTool_C.__Tick_FunctionParams* ptr = stackalloc WBP_DebugMPCTool_C.__Tick_FunctionParams[(UIntPtr)75] + 15L / (long)sizeof(WBP_DebugMPCTool_C.__Tick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(WBP_DebugMPCTool_C.__Tick_NativeFunctionPtr, (void*)ptr, 1);
			if (MyGeometry != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FGeometry.StaticStruct(), &ptr->MyGeometry, MyGeometry.NativePtr, 1, false);
			}
			ptr->InDeltaTime = InDeltaTime;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, WBP_DebugMPCTool_C.__Tick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060249EE RID: 149998 RVA: 0x009A2F58 File Offset: 0x009A1158
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void Tick_Implementation(FGeometry MyGeometry, float InDeltaTime)
		{
			WBP_DebugMPCTool_C.__Tick_FunctionParams* ptr = stackalloc WBP_DebugMPCTool_C.__Tick_FunctionParams[(UIntPtr)75] + 15L / (long)sizeof(WBP_DebugMPCTool_C.__Tick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(WBP_DebugMPCTool_C.__Tick_NativeFunctionPtr, (void*)ptr, 1);
			if (MyGeometry != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FGeometry.StaticStruct(), &ptr->MyGeometry, MyGeometry.NativePtr, 1, false);
			}
			ptr->InDeltaTime = InDeltaTime;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, WBP_DebugMPCTool_C.__Tick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060249EF RID: 149999 RVA: 0x009A2FC1 File Offset: 0x009A11C1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void BndEvt__WBP_DebugDataLayerTool_Button_1_K2Node_ComponentBoundEvent_0_OnButtonClickedEvent__DelegateSignature()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, WBP_DebugMPCTool_C.__BndEvt__WBP_DebugDataLayerTool_Button_1_K2Node_ComponentBoundEvent_0_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr, null);
		}

		// Token: 0x060249F0 RID: 150000 RVA: 0x009A2FD8 File Offset: 0x009A11D8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_WBP_DebugMPCTool(int EntryPoint)
		{
			WBP_DebugMPCTool_C.__ExecuteUbergraph_WBP_DebugMPCTool_FunctionParams* ptr = stackalloc WBP_DebugMPCTool_C.__ExecuteUbergraph_WBP_DebugMPCTool_FunctionParams[(UIntPtr)151] + 15L / (long)sizeof(WBP_DebugMPCTool_C.__ExecuteUbergraph_WBP_DebugMPCTool_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(WBP_DebugMPCTool_C.__ExecuteUbergraph_WBP_DebugMPCTool_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, WBP_DebugMPCTool_C.__ExecuteUbergraph_WBP_DebugMPCTool_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060249F1 RID: 150001 RVA: 0x009A3022 File Offset: 0x009A1222
		protected WBP_DebugMPCTool_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04012C5D RID: 76893
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/GI/UI/DebugDataLayer/WBP_DebugMPCTool.WBP_DebugMPCTool_C";

		// Token: 0x04012C5E RID: 76894
		private static IntPtr _ClassPtr;

		// Token: 0x04012C5F RID: 76895
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04012C60 RID: 76896
		internal static int __PropertyOffset_0;

		// Token: 0x04012C61 RID: 76897
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04012C62 RID: 76898
		internal static int __PropertyOffset_1;

		// Token: 0x04012C63 RID: 76899
		internal static int __PropertyOffset_2;

		// Token: 0x04012C64 RID: 76900
		internal static int __PropertyOffset_3;

		// Token: 0x04012C65 RID: 76901
		internal static int __PropertyOffset_4;

		// Token: 0x04012C66 RID: 76902
		internal static int __PropertyOffset_5;

		// Token: 0x04012C67 RID: 76903
		internal static int __PropertyOffset_6;

		// Token: 0x04012C68 RID: 76904
		internal static int __PropertyOffset_7;

		// Token: 0x04012C69 RID: 76905
		internal static int __PropertyOffset_8;

		// Token: 0x04012C6A RID: 76906
		internal static int __PropertyOffset_9;

		// Token: 0x04012C6B RID: 76907
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<string> _AllDataLayers;

		// Token: 0x04012C6C RID: 76908
		private static IntPtr __Tick_NativeFunctionPtr;

		// Token: 0x04012C6D RID: 76909
		private static IntPtr __BndEvt__WBP_DebugDataLayerTool_Button_1_K2Node_ComponentBoundEvent_0_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04012C6E RID: 76910
		private static IntPtr __ExecuteUbergraph_WBP_DebugMPCTool_NativeFunctionPtr;

		// Token: 0x02009E21 RID: 40481
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 60)]
		protected new ref struct __Tick_FunctionParams
		{
			// Token: 0x0403286C RID: 206956
			[FieldOffset(0)]
			public byte MyGeometry;

			// Token: 0x0403286D RID: 206957
			[FieldOffset(56)]
			public float InDeltaTime;
		}

		// Token: 0x02009E22 RID: 40482
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 136)]
		protected ref struct __ExecuteUbergraph_WBP_DebugMPCTool_FunctionParams
		{
			// Token: 0x0403286E RID: 206958
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
