using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.FluidNinjaLive.Core
{
	// Token: 0x02003D13 RID: 15635
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/FluidNinjaLive/Core/Viewport_LightRotatorWidget.Viewport_LightRotatorWidget_C")]
	[UnrealStructLayout(1232, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1232)]
	public class Viewport_LightRotatorWidget_C : UUserWidget, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06025BF7 RID: 154615 RVA: 0x009C3CE9 File Offset: 0x009C1EE9
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (Viewport_LightRotatorWidget_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/FluidNinjaLive/Core/Viewport_LightRotatorWidget.Viewport_LightRotatorWidget_C");
			}
			return Viewport_LightRotatorWidget_C._ClassPtr;
		}

		// Token: 0x06025BF8 RID: 154616 RVA: 0x009C3D10 File Offset: 0x009C1F10
		public Viewport_LightRotatorWidget_C() : this(BuiltinUtils.AllocNativeUObject(Viewport_LightRotatorWidget_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06025BF9 RID: 154617 RVA: 0x009C3D38 File Offset: 0x009C1F38
		[NullableContext(1)]
		public Viewport_LightRotatorWidget_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(Viewport_LightRotatorWidget_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17005384 RID: 21380
		// (get) Token: 0x06025BFA RID: 154618 RVA: 0x009C3D6C File Offset: 0x009C1F6C
		// (set) Token: 0x06025BFB RID: 154619 RVA: 0x009C3DA5 File Offset: 0x009C1FA5
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)Viewport_LightRotatorWidget_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)Viewport_LightRotatorWidget_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005385 RID: 21381
		// (get) Token: 0x06025BFC RID: 154620 RVA: 0x009C3DC6 File Offset: 0x009C1FC6
		// (set) Token: 0x06025BFD RID: 154621 RVA: 0x009C3DDA File Offset: 0x009C1FDA
		public unsafe USlider Slider_Camera
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USlider>(base.NativePtr / (IntPtr)sizeof(void*) + Viewport_LightRotatorWidget_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Viewport_LightRotatorWidget_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17005386 RID: 21382
		// (get) Token: 0x06025BFE RID: 154622 RVA: 0x009C3DEF File Offset: 0x009C1FEF
		// (set) Token: 0x06025BFF RID: 154623 RVA: 0x009C3E03 File Offset: 0x009C2003
		public unsafe USlider Slider_LightAngle1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USlider>(base.NativePtr / (IntPtr)sizeof(void*) + Viewport_LightRotatorWidget_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Viewport_LightRotatorWidget_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17005387 RID: 21383
		// (get) Token: 0x06025C00 RID: 154624 RVA: 0x009C3E18 File Offset: 0x009C2018
		// (set) Token: 0x06025C01 RID: 154625 RVA: 0x009C3E2C File Offset: 0x009C202C
		public unsafe USlider Slider_LightAngle2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USlider>(base.NativePtr / (IntPtr)sizeof(void*) + Viewport_LightRotatorWidget_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Viewport_LightRotatorWidget_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17005388 RID: 21384
		// (get) Token: 0x06025C02 RID: 154626 RVA: 0x009C3E41 File Offset: 0x009C2041
		// (set) Token: 0x06025C03 RID: 154627 RVA: 0x009C3E55 File Offset: 0x009C2055
		public unsafe USlider Slider_LightIntensity
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USlider>(base.NativePtr / (IntPtr)sizeof(void*) + Viewport_LightRotatorWidget_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Viewport_LightRotatorWidget_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17005389 RID: 21385
		// (get) Token: 0x06025C04 RID: 154628 RVA: 0x009C3E6A File Offset: 0x009C206A
		// (set) Token: 0x06025C05 RID: 154629 RVA: 0x009C3E7E File Offset: 0x009C207E
		public unsafe FRotator InitialLightRotation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Viewport_LightRotatorWidget_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Viewport_LightRotatorWidget_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x1700538A RID: 21386
		// (get) Token: 0x06025C06 RID: 154630 RVA: 0x009C3E93 File Offset: 0x009C2093
		// (set) Token: 0x06025C07 RID: 154631 RVA: 0x009C3EA7 File Offset: 0x009C20A7
		public unsafe ADirectionalLight DirectionalLight
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<ADirectionalLight>(base.NativePtr / (IntPtr)sizeof(void*) + Viewport_LightRotatorWidget_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Viewport_LightRotatorWidget_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x06025C08 RID: 154632 RVA: 0x009C3EBC File Offset: 0x009C20BC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void PreConstruct(bool IsDesignTime)
		{
			Viewport_LightRotatorWidget_C.__PreConstruct_FunctionParams* ptr = stackalloc Viewport_LightRotatorWidget_C.__PreConstruct_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(Viewport_LightRotatorWidget_C.__PreConstruct_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(Viewport_LightRotatorWidget_C.__PreConstruct_NativeFunctionPtr, (void*)ptr, 1);
			ptr->IsDesignTime = IsDesignTime;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Viewport_LightRotatorWidget_C.__PreConstruct_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025C09 RID: 154633 RVA: 0x009C3F04 File Offset: 0x009C2104
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void PreConstruct_Implementation(bool IsDesignTime)
		{
			Viewport_LightRotatorWidget_C.__PreConstruct_FunctionParams* ptr = stackalloc Viewport_LightRotatorWidget_C.__PreConstruct_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(Viewport_LightRotatorWidget_C.__PreConstruct_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(Viewport_LightRotatorWidget_C.__PreConstruct_NativeFunctionPtr, (void*)ptr, 1);
			ptr->IsDesignTime = IsDesignTime;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, Viewport_LightRotatorWidget_C.__PreConstruct_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06025C0A RID: 154634 RVA: 0x009C3F4C File Offset: 0x009C214C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void Tick(FGeometry MyGeometry, float InDeltaTime)
		{
			Viewport_LightRotatorWidget_C.__Tick_FunctionParams* ptr = stackalloc Viewport_LightRotatorWidget_C.__Tick_FunctionParams[(UIntPtr)75] + 15L / (long)sizeof(Viewport_LightRotatorWidget_C.__Tick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(Viewport_LightRotatorWidget_C.__Tick_NativeFunctionPtr, (void*)ptr, 1);
			if (MyGeometry != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FGeometry.StaticStruct(), &ptr->MyGeometry, MyGeometry.NativePtr, 1, false);
			}
			ptr->InDeltaTime = InDeltaTime;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Viewport_LightRotatorWidget_C.__Tick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025C0B RID: 154635 RVA: 0x009C3FB4 File Offset: 0x009C21B4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void Tick_Implementation(FGeometry MyGeometry, float InDeltaTime)
		{
			Viewport_LightRotatorWidget_C.__Tick_FunctionParams* ptr = stackalloc Viewport_LightRotatorWidget_C.__Tick_FunctionParams[(UIntPtr)75] + 15L / (long)sizeof(Viewport_LightRotatorWidget_C.__Tick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(Viewport_LightRotatorWidget_C.__Tick_NativeFunctionPtr, (void*)ptr, 1);
			if (MyGeometry != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FGeometry.StaticStruct(), &ptr->MyGeometry, MyGeometry.NativePtr, 1, false);
			}
			ptr->InDeltaTime = InDeltaTime;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, Viewport_LightRotatorWidget_C.__Tick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06025C0C RID: 154636 RVA: 0x009C4020 File Offset: 0x009C2220
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__Slider_1_K2Node_ComponentBoundEvent_0_OnFloatValueChangedEvent__DelegateSignature(float Value)
		{
			Viewport_LightRotatorWidget_C.__BndEvt__Slider_1_K2Node_ComponentBoundEvent_0_OnFloatValueChangedEvent__DelegateSignature_FunctionParams* ptr = stackalloc Viewport_LightRotatorWidget_C.__BndEvt__Slider_1_K2Node_ComponentBoundEvent_0_OnFloatValueChangedEvent__DelegateSignature_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(Viewport_LightRotatorWidget_C.__BndEvt__Slider_1_K2Node_ComponentBoundEvent_0_OnFloatValueChangedEvent__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(Viewport_LightRotatorWidget_C.__BndEvt__Slider_1_K2Node_ComponentBoundEvent_0_OnFloatValueChangedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Value = Value;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Viewport_LightRotatorWidget_C.__BndEvt__Slider_1_K2Node_ComponentBoundEvent_0_OnFloatValueChangedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025C0D RID: 154637 RVA: 0x009C4068 File Offset: 0x009C2268
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__Slider_2_K2Node_ComponentBoundEvent_1_OnFloatValueChangedEvent__DelegateSignature(float Value)
		{
			Viewport_LightRotatorWidget_C.__BndEvt__Slider_2_K2Node_ComponentBoundEvent_1_OnFloatValueChangedEvent__DelegateSignature_FunctionParams* ptr = stackalloc Viewport_LightRotatorWidget_C.__BndEvt__Slider_2_K2Node_ComponentBoundEvent_1_OnFloatValueChangedEvent__DelegateSignature_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(Viewport_LightRotatorWidget_C.__BndEvt__Slider_2_K2Node_ComponentBoundEvent_1_OnFloatValueChangedEvent__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(Viewport_LightRotatorWidget_C.__BndEvt__Slider_2_K2Node_ComponentBoundEvent_1_OnFloatValueChangedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Value = Value;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Viewport_LightRotatorWidget_C.__BndEvt__Slider_2_K2Node_ComponentBoundEvent_1_OnFloatValueChangedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025C0E RID: 154638 RVA: 0x009C40B0 File Offset: 0x009C22B0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__Slider_Camera_K2Node_ComponentBoundEvent_2_OnFloatValueChangedEvent__DelegateSignature(float Value)
		{
			Viewport_LightRotatorWidget_C.__BndEvt__Slider_Camera_K2Node_ComponentBoundEvent_2_OnFloatValueChangedEvent__DelegateSignature_FunctionParams* ptr = stackalloc Viewport_LightRotatorWidget_C.__BndEvt__Slider_Camera_K2Node_ComponentBoundEvent_2_OnFloatValueChangedEvent__DelegateSignature_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(Viewport_LightRotatorWidget_C.__BndEvt__Slider_Camera_K2Node_ComponentBoundEvent_2_OnFloatValueChangedEvent__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(Viewport_LightRotatorWidget_C.__BndEvt__Slider_Camera_K2Node_ComponentBoundEvent_2_OnFloatValueChangedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Value = Value;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Viewport_LightRotatorWidget_C.__BndEvt__Slider_Camera_K2Node_ComponentBoundEvent_2_OnFloatValueChangedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025C0F RID: 154639 RVA: 0x009C40F8 File Offset: 0x009C22F8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__Slider_LightIntensity_K2Node_ComponentBoundEvent_3_OnFloatValueChangedEvent__DelegateSignature(float Value)
		{
			Viewport_LightRotatorWidget_C.__BndEvt__Slider_LightIntensity_K2Node_ComponentBoundEvent_3_OnFloatValueChangedEvent__DelegateSignature_FunctionParams* ptr = stackalloc Viewport_LightRotatorWidget_C.__BndEvt__Slider_LightIntensity_K2Node_ComponentBoundEvent_3_OnFloatValueChangedEvent__DelegateSignature_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(Viewport_LightRotatorWidget_C.__BndEvt__Slider_LightIntensity_K2Node_ComponentBoundEvent_3_OnFloatValueChangedEvent__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(Viewport_LightRotatorWidget_C.__BndEvt__Slider_LightIntensity_K2Node_ComponentBoundEvent_3_OnFloatValueChangedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Value = Value;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Viewport_LightRotatorWidget_C.__BndEvt__Slider_LightIntensity_K2Node_ComponentBoundEvent_3_OnFloatValueChangedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025C10 RID: 154640 RVA: 0x009C4140 File Offset: 0x009C2340
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_Viewport_LightRotatorWidget(int EntryPoint)
		{
			Viewport_LightRotatorWidget_C.__ExecuteUbergraph_Viewport_LightRotatorWidget_FunctionParams* ptr = stackalloc Viewport_LightRotatorWidget_C.__ExecuteUbergraph_Viewport_LightRotatorWidget_FunctionParams[(UIntPtr)231] + 15L / (long)sizeof(Viewport_LightRotatorWidget_C.__ExecuteUbergraph_Viewport_LightRotatorWidget_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(Viewport_LightRotatorWidget_C.__ExecuteUbergraph_Viewport_LightRotatorWidget_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, Viewport_LightRotatorWidget_C.__ExecuteUbergraph_Viewport_LightRotatorWidget_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06025C11 RID: 154641 RVA: 0x009C418A File Offset: 0x009C238A
		protected Viewport_LightRotatorWidget_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040137F8 RID: 79864
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/FluidNinjaLive/Core/Viewport_LightRotatorWidget.Viewport_LightRotatorWidget_C";

		// Token: 0x040137F9 RID: 79865
		private static IntPtr _ClassPtr;

		// Token: 0x040137FA RID: 79866
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040137FB RID: 79867
		internal static int __PropertyOffset_0;

		// Token: 0x040137FC RID: 79868
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040137FD RID: 79869
		internal static int __PropertyOffset_1;

		// Token: 0x040137FE RID: 79870
		internal static int __PropertyOffset_2;

		// Token: 0x040137FF RID: 79871
		internal static int __PropertyOffset_3;

		// Token: 0x04013800 RID: 79872
		internal static int __PropertyOffset_4;

		// Token: 0x04013801 RID: 79873
		internal static int __PropertyOffset_5;

		// Token: 0x04013802 RID: 79874
		internal static int __PropertyOffset_6;

		// Token: 0x04013803 RID: 79875
		private static IntPtr __PreConstruct_NativeFunctionPtr;

		// Token: 0x04013804 RID: 79876
		private static IntPtr __Tick_NativeFunctionPtr;

		// Token: 0x04013805 RID: 79877
		private static IntPtr __BndEvt__Slider_1_K2Node_ComponentBoundEvent_0_OnFloatValueChangedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04013806 RID: 79878
		private static IntPtr __BndEvt__Slider_2_K2Node_ComponentBoundEvent_1_OnFloatValueChangedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04013807 RID: 79879
		private static IntPtr __BndEvt__Slider_Camera_K2Node_ComponentBoundEvent_2_OnFloatValueChangedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04013808 RID: 79880
		private static IntPtr __BndEvt__Slider_LightIntensity_K2Node_ComponentBoundEvent_3_OnFloatValueChangedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04013809 RID: 79881
		private static IntPtr __ExecuteUbergraph_Viewport_LightRotatorWidget_NativeFunctionPtr;

		// Token: 0x02009F9B RID: 40859
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __PreConstruct_FunctionParams
		{
			// Token: 0x04032B48 RID: 207688
			[FieldOffset(0)]
			public bool IsDesignTime;
		}

		// Token: 0x02009F9C RID: 40860
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 60)]
		protected new ref struct __Tick_FunctionParams
		{
			// Token: 0x04032B49 RID: 207689
			[FieldOffset(0)]
			public byte MyGeometry;

			// Token: 0x04032B4A RID: 207690
			[FieldOffset(56)]
			public float InDeltaTime;
		}

		// Token: 0x02009F9D RID: 40861
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __BndEvt__Slider_1_K2Node_ComponentBoundEvent_0_OnFloatValueChangedEvent__DelegateSignature_FunctionParams
		{
			// Token: 0x04032B4B RID: 207691
			[FieldOffset(0)]
			public float Value;
		}

		// Token: 0x02009F9E RID: 40862
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __BndEvt__Slider_2_K2Node_ComponentBoundEvent_1_OnFloatValueChangedEvent__DelegateSignature_FunctionParams
		{
			// Token: 0x04032B4C RID: 207692
			[FieldOffset(0)]
			public float Value;
		}

		// Token: 0x02009F9F RID: 40863
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __BndEvt__Slider_Camera_K2Node_ComponentBoundEvent_2_OnFloatValueChangedEvent__DelegateSignature_FunctionParams
		{
			// Token: 0x04032B4D RID: 207693
			[FieldOffset(0)]
			public float Value;
		}

		// Token: 0x02009FA0 RID: 40864
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __BndEvt__Slider_LightIntensity_K2Node_ComponentBoundEvent_3_OnFloatValueChangedEvent__DelegateSignature_FunctionParams
		{
			// Token: 0x04032B4E RID: 207694
			[FieldOffset(0)]
			public float Value;
		}

		// Token: 0x02009FA1 RID: 40865
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 216)]
		protected ref struct __ExecuteUbergraph_Viewport_LightRotatorWidget_FunctionParams
		{
			// Token: 0x04032B4F RID: 207695
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
