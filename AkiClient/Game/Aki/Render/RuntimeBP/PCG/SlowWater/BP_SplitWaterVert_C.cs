using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.SlowWater
{
	// Token: 0x02003B73 RID: 15219
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/SlowWater/BP_SplitWaterVert.BP_SplitWaterVert_C")]
	[UnrealStructLayout(1408, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1404)]
	public class BP_SplitWaterVert_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602182F RID: 137263 RVA: 0x0094B4FC File Offset: 0x009496FC
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SplitWaterVert_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/SlowWater/BP_SplitWaterVert.BP_SplitWaterVert_C");
			}
			return BP_SplitWaterVert_C._ClassPtr;
		}

		// Token: 0x06021830 RID: 137264 RVA: 0x0094B520 File Offset: 0x00949720
		public BP_SplitWaterVert_C() : this(BuiltinUtils.AllocNativeUObject(BP_SplitWaterVert_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06021831 RID: 137265 RVA: 0x0094B548 File Offset: 0x00949748
		[NullableContext(1)]
		public BP_SplitWaterVert_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SplitWaterVert_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003B88 RID: 15240
		// (get) Token: 0x06021832 RID: 137266 RVA: 0x0094B57C File Offset: 0x0094977C
		// (set) Token: 0x06021833 RID: 137267 RVA: 0x0094B5B5 File Offset: 0x009497B5
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_SplitWaterVert_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_SplitWaterVert_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003B89 RID: 15241
		// (get) Token: 0x06021834 RID: 137268 RVA: 0x0094B5D6 File Offset: 0x009497D6
		// (set) Token: 0x06021835 RID: 137269 RVA: 0x0094B5EA File Offset: 0x009497EA
		public unsafe UStaticMeshComponent SM_SlowWater4
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplitWaterVert_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplitWaterVert_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003B8A RID: 15242
		// (get) Token: 0x06021836 RID: 137270 RVA: 0x0094B5FF File Offset: 0x009497FF
		// (set) Token: 0x06021837 RID: 137271 RVA: 0x0094B613 File Offset: 0x00949813
		public unsafe UStaticMeshComponent SM_SlowWater5
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplitWaterVert_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplitWaterVert_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17003B8B RID: 15243
		// (get) Token: 0x06021838 RID: 137272 RVA: 0x0094B628 File Offset: 0x00949828
		// (set) Token: 0x06021839 RID: 137273 RVA: 0x0094B63C File Offset: 0x0094983C
		public unsafe UStaticMeshComponent SM_SlowWater3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplitWaterVert_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplitWaterVert_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17003B8C RID: 15244
		// (get) Token: 0x0602183A RID: 137274 RVA: 0x0094B651 File Offset: 0x00949851
		// (set) Token: 0x0602183B RID: 137275 RVA: 0x0094B665 File Offset: 0x00949865
		public unsafe UStaticMeshComponent SM_SlowWater2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplitWaterVert_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplitWaterVert_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17003B8D RID: 15245
		// (get) Token: 0x0602183C RID: 137276 RVA: 0x0094B67A File Offset: 0x0094987A
		// (set) Token: 0x0602183D RID: 137277 RVA: 0x0094B68E File Offset: 0x0094988E
		public unsafe UStaticMeshComponent SM_SlowWater1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplitWaterVert_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplitWaterVert_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17003B8E RID: 15246
		// (get) Token: 0x0602183E RID: 137278 RVA: 0x0094B6A3 File Offset: 0x009498A3
		// (set) Token: 0x0602183F RID: 137279 RVA: 0x0094B6B7 File Offset: 0x009498B7
		public unsafe UStaticMeshComponent SM_SlowWater
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplitWaterVert_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplitWaterVert_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x17003B8F RID: 15247
		// (get) Token: 0x06021840 RID: 137280 RVA: 0x0094B6CC File Offset: 0x009498CC
		// (set) Token: 0x06021841 RID: 137281 RVA: 0x0094B6E0 File Offset: 0x009498E0
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplitWaterVert_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplitWaterVert_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x17003B90 RID: 15248
		// (get) Token: 0x06021842 RID: 137282 RVA: 0x0094B6F5 File Offset: 0x009498F5
		// (set) Token: 0x06021843 RID: 137283 RVA: 0x0094B705 File Offset: 0x00949905
		public unsafe bool EnableTick
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplitWaterVert_C.__PropertyOffset_8) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplitWaterVert_C.__PropertyOffset_8) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003B91 RID: 15249
		// (get) Token: 0x06021844 RID: 137284 RVA: 0x0094B716 File Offset: 0x00949916
		// (set) Token: 0x06021845 RID: 137285 RVA: 0x0094B726 File Offset: 0x00949926
		public unsafe float CustomTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplitWaterVert_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplitWaterVert_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17003B92 RID: 15250
		// (get) Token: 0x06021846 RID: 137286 RVA: 0x0094B737 File Offset: 0x00949937
		// (set) Token: 0x06021847 RID: 137287 RVA: 0x0094B747 File Offset: 0x00949947
		public unsafe float CustomTimeFade
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplitWaterVert_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplitWaterVert_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17003B93 RID: 15251
		// (get) Token: 0x06021848 RID: 137288 RVA: 0x0094B758 File Offset: 0x00949958
		// (set) Token: 0x06021849 RID: 137289 RVA: 0x0094B768 File Offset: 0x00949968
		public unsafe float Opacity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplitWaterVert_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplitWaterVert_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17003B94 RID: 15252
		// (get) Token: 0x0602184A RID: 137290 RVA: 0x0094B779 File Offset: 0x00949979
		// (set) Token: 0x0602184B RID: 137291 RVA: 0x0094B789 File Offset: 0x00949989
		public unsafe float Spacing
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplitWaterVert_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplitWaterVert_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17003B95 RID: 15253
		// (get) Token: 0x0602184C RID: 137292 RVA: 0x0094B79A File Offset: 0x0094999A
		// (set) Token: 0x0602184D RID: 137293 RVA: 0x0094B7AA File Offset: 0x009499AA
		public unsafe float LocalSpacing
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplitWaterVert_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplitWaterVert_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17003B96 RID: 15254
		// (get) Token: 0x0602184E RID: 137294 RVA: 0x0094B7BB File Offset: 0x009499BB
		// (set) Token: 0x0602184F RID: 137295 RVA: 0x0094B7CB File Offset: 0x009499CB
		public unsafe float Speed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplitWaterVert_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplitWaterVert_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x06021850 RID: 137296 RVA: 0x0094B7DC File Offset: 0x009499DC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_SplitWaterVert_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_SplitWaterVert_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SplitWaterVert_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SplitWaterVert_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SplitWaterVert_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021851 RID: 137297 RVA: 0x0094B824 File Offset: 0x00949A24
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_SplitWaterVert_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_SplitWaterVert_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SplitWaterVert_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SplitWaterVert_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SplitWaterVert_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021852 RID: 137298 RVA: 0x0094B86C File Offset: 0x00949A6C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_SplitWaterVert_C.__EditorTick_FunctionParams* ptr = stackalloc BP_SplitWaterVert_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SplitWaterVert_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SplitWaterVert_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SplitWaterVert_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021853 RID: 137299 RVA: 0x0094B8B4 File Offset: 0x00949AB4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_SplitWaterVert_C.__EditorTick_FunctionParams* ptr = stackalloc BP_SplitWaterVert_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SplitWaterVert_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SplitWaterVert_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SplitWaterVert_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021854 RID: 137300 RVA: 0x0094B8FC File Offset: 0x00949AFC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_SplitWaterVert(int EntryPoint)
		{
			BP_SplitWaterVert_C.__ExecuteUbergraph_BP_SplitWaterVert_FunctionParams* ptr = stackalloc BP_SplitWaterVert_C.__ExecuteUbergraph_BP_SplitWaterVert_FunctionParams[(UIntPtr)431] + 15L / (long)sizeof(BP_SplitWaterVert_C.__ExecuteUbergraph_BP_SplitWaterVert_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SplitWaterVert_C.__ExecuteUbergraph_BP_SplitWaterVert_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SplitWaterVert_C.__ExecuteUbergraph_BP_SplitWaterVert_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021855 RID: 137301 RVA: 0x0094B946 File Offset: 0x00949B46
		protected BP_SplitWaterVert_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04010E0A RID: 69130
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/SlowWater/BP_SplitWaterVert.BP_SplitWaterVert_C";

		// Token: 0x04010E0B RID: 69131
		private static IntPtr _ClassPtr;

		// Token: 0x04010E0C RID: 69132
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04010E0D RID: 69133
		internal static int __PropertyOffset_0;

		// Token: 0x04010E0E RID: 69134
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04010E0F RID: 69135
		internal static int __PropertyOffset_1;

		// Token: 0x04010E10 RID: 69136
		internal static int __PropertyOffset_2;

		// Token: 0x04010E11 RID: 69137
		internal static int __PropertyOffset_3;

		// Token: 0x04010E12 RID: 69138
		internal static int __PropertyOffset_4;

		// Token: 0x04010E13 RID: 69139
		internal static int __PropertyOffset_5;

		// Token: 0x04010E14 RID: 69140
		internal static int __PropertyOffset_6;

		// Token: 0x04010E15 RID: 69141
		internal static int __PropertyOffset_7;

		// Token: 0x04010E16 RID: 69142
		internal static int __PropertyOffset_8;

		// Token: 0x04010E17 RID: 69143
		internal static int __PropertyOffset_9;

		// Token: 0x04010E18 RID: 69144
		internal static int __PropertyOffset_10;

		// Token: 0x04010E19 RID: 69145
		internal static int __PropertyOffset_11;

		// Token: 0x04010E1A RID: 69146
		internal static int __PropertyOffset_12;

		// Token: 0x04010E1B RID: 69147
		internal static int __PropertyOffset_13;

		// Token: 0x04010E1C RID: 69148
		internal static int __PropertyOffset_14;

		// Token: 0x04010E1D RID: 69149
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04010E1E RID: 69150
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x04010E1F RID: 69151
		private static IntPtr __ExecuteUbergraph_BP_SplitWaterVert_NativeFunctionPtr;

		// Token: 0x02009AEF RID: 39663
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x0403228B RID: 205451
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009AF0 RID: 39664
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x0403228C RID: 205452
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009AF1 RID: 39665
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 416)]
		protected ref struct __ExecuteUbergraph_BP_SplitWaterVert_FunctionParams
		{
			// Token: 0x0403228D RID: 205453
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
