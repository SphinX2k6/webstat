using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Effect.Scene
{
	// Token: 0x02003D32 RID: 15666
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Effect/Scene/BP_NiagaraGroundBox.BP_NiagaraGroundBox_C")]
	[UnrealStructLayout(1112, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1112)]
	public class BP_NiagaraGroundBox_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06025F8E RID: 155534 RVA: 0x009CA024 File Offset: 0x009C8224
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_NiagaraGroundBox_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Effect/Scene/BP_NiagaraGroundBox.BP_NiagaraGroundBox_C");
			}
			return BP_NiagaraGroundBox_C._ClassPtr;
		}

		// Token: 0x06025F8F RID: 155535 RVA: 0x009CA048 File Offset: 0x009C8248
		public BP_NiagaraGroundBox_C() : this(BuiltinUtils.AllocNativeUObject(BP_NiagaraGroundBox_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06025F90 RID: 155536 RVA: 0x009CA070 File Offset: 0x009C8270
		[NullableContext(1)]
		public BP_NiagaraGroundBox_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_NiagaraGroundBox_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170054CF RID: 21711
		// (get) Token: 0x06025F91 RID: 155537 RVA: 0x009CA0A4 File Offset: 0x009C82A4
		// (set) Token: 0x06025F92 RID: 155538 RVA: 0x009CA0DD File Offset: 0x009C82DD
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_NiagaraGroundBox_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_NiagaraGroundBox_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170054D0 RID: 21712
		// (get) Token: 0x06025F93 RID: 155539 RVA: 0x009CA0FE File Offset: 0x009C82FE
		// (set) Token: 0x06025F94 RID: 155540 RVA: 0x009CA112 File Offset: 0x009C8312
		public unsafe UNiagaraComponent Niagara
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_NiagaraGroundBox_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_NiagaraGroundBox_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170054D1 RID: 21713
		// (get) Token: 0x06025F95 RID: 155541 RVA: 0x009CA127 File Offset: 0x009C8327
		// (set) Token: 0x06025F96 RID: 155542 RVA: 0x009CA13B File Offset: 0x009C833B
		public unsafe UBoxComponent Box
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_NiagaraGroundBox_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_NiagaraGroundBox_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170054D2 RID: 21714
		// (get) Token: 0x06025F97 RID: 155543 RVA: 0x009CA150 File Offset: 0x009C8350
		// (set) Token: 0x06025F98 RID: 155544 RVA: 0x009CA160 File Offset: 0x009C8360
		public unsafe float Precision
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_NiagaraGroundBox_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_NiagaraGroundBox_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x170054D3 RID: 21715
		// (get) Token: 0x06025F99 RID: 155545 RVA: 0x009CA171 File Offset: 0x009C8371
		// (set) Token: 0x06025F9A RID: 155546 RVA: 0x009CA181 File Offset: 0x009C8381
		public unsafe int MaxSample
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_NiagaraGroundBox_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_NiagaraGroundBox_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x170054D4 RID: 21716
		// (get) Token: 0x06025F9B RID: 155547 RVA: 0x009CA194 File Offset: 0x009C8394
		// (set) Token: 0x06025F9C RID: 155548 RVA: 0x009CA1CD File Offset: 0x009C83CD
		[Nullable(1)]
		public TArray<FVector> ResArray
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<FVector> result;
				if ((result = this._ResArray) == null)
				{
					result = (this._ResArray = new TArray<FVector>(base.NativePtr + (IntPtr)BP_NiagaraGroundBox_C.__PropertyOffset_5, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.ResArray.CopyAssign(value);
			}
		}

		// Token: 0x170054D5 RID: 21717
		// (get) Token: 0x06025F9D RID: 155549 RVA: 0x009CA1DB File Offset: 0x009C83DB
		// (set) Token: 0x06025F9E RID: 155550 RVA: 0x009CA1EB File Offset: 0x009C83EB
		public unsafe float TraceElement
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_NiagaraGroundBox_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_NiagaraGroundBox_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x170054D6 RID: 21718
		// (get) Token: 0x06025F9F RID: 155551 RVA: 0x009CA1FC File Offset: 0x009C83FC
		// (set) Token: 0x06025FA0 RID: 155552 RVA: 0x009CA20C File Offset: 0x009C840C
		public unsafe int XSample
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_NiagaraGroundBox_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_NiagaraGroundBox_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x170054D7 RID: 21719
		// (get) Token: 0x06025FA1 RID: 155553 RVA: 0x009CA21D File Offset: 0x009C841D
		// (set) Token: 0x06025FA2 RID: 155554 RVA: 0x009CA22D File Offset: 0x009C842D
		public unsafe int YSample
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_NiagaraGroundBox_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_NiagaraGroundBox_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x170054D8 RID: 21720
		// (get) Token: 0x06025FA3 RID: 155555 RVA: 0x009CA23E File Offset: 0x009C843E
		// (set) Token: 0x06025FA4 RID: 155556 RVA: 0x009CA24E File Offset: 0x009C844E
		public unsafe bool EnableDebugDraw
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_NiagaraGroundBox_C.__PropertyOffset_9) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_NiagaraGroundBox_C.__PropertyOffset_9) = (value ? 1 : 0);
			}
		}

		// Token: 0x170054D9 RID: 21721
		// (get) Token: 0x06025FA5 RID: 155557 RVA: 0x009CA25F File Offset: 0x009C845F
		// (set) Token: 0x06025FA6 RID: 155558 RVA: 0x009CA26F File Offset: 0x009C846F
		public unsafe int TempIndex
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_NiagaraGroundBox_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_NiagaraGroundBox_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x170054DA RID: 21722
		// (get) Token: 0x06025FA7 RID: 155559 RVA: 0x009CA280 File Offset: 0x009C8480
		// (set) Token: 0x06025FA8 RID: 155560 RVA: 0x009CA294 File Offset: 0x009C8494
		public unsafe UNiagaraSystem NiagaraAsset
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraSystem>(base.NativePtr / (IntPtr)sizeof(void*) + BP_NiagaraGroundBox_C.__PropertyOffset_11);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_NiagaraGroundBox_C.__PropertyOffset_11, value);
			}
		}

		// Token: 0x06025FA9 RID: 155561 RVA: 0x009CA2A9 File Offset: 0x009C84A9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvalSample()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_NiagaraGroundBox_C.__EvalSample_NativeFunctionPtr, null);
		}

		// Token: 0x06025FAA RID: 155562 RVA: 0x009CA2BD File Offset: 0x009C84BD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Refresh()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_NiagaraGroundBox_C.__Refresh_NativeFunctionPtr, null);
		}

		// Token: 0x06025FAB RID: 155563 RVA: 0x009CA2D4 File Offset: 0x009C84D4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void TraceImpl(bool DrawOnly)
		{
			BP_NiagaraGroundBox_C.__TraceImpl_FunctionParams* ptr = stackalloc BP_NiagaraGroundBox_C.__TraceImpl_FunctionParams[(UIntPtr)671] + 15L / (long)sizeof(BP_NiagaraGroundBox_C.__TraceImpl_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_NiagaraGroundBox_C.__TraceImpl_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DrawOnly = DrawOnly;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_NiagaraGroundBox_C.__TraceImpl_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025FAC RID: 155564 RVA: 0x009CA31D File Offset: 0x009C851D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Calculate()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_NiagaraGroundBox_C.__Calculate_NativeFunctionPtr, null);
		}

		// Token: 0x06025FAD RID: 155565 RVA: 0x009CA331 File Offset: 0x009C8531
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void DebugDraw()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_NiagaraGroundBox_C.__DebugDraw_NativeFunctionPtr, null);
		}

		// Token: 0x06025FAE RID: 155566 RVA: 0x009CA348 File Offset: 0x009C8548
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_NiagaraGroundBox_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_NiagaraGroundBox_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_NiagaraGroundBox_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_NiagaraGroundBox_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_NiagaraGroundBox_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025FAF RID: 155567 RVA: 0x009CA390 File Offset: 0x009C8590
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_NiagaraGroundBox_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_NiagaraGroundBox_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_NiagaraGroundBox_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_NiagaraGroundBox_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_NiagaraGroundBox_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06025FB0 RID: 155568 RVA: 0x009CA3D8 File Offset: 0x009C85D8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_NiagaraGroundBox(int EntryPoint)
		{
			BP_NiagaraGroundBox_C.__ExecuteUbergraph_BP_NiagaraGroundBox_FunctionParams* ptr = stackalloc BP_NiagaraGroundBox_C.__ExecuteUbergraph_BP_NiagaraGroundBox_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_NiagaraGroundBox_C.__ExecuteUbergraph_BP_NiagaraGroundBox_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_NiagaraGroundBox_C.__ExecuteUbergraph_BP_NiagaraGroundBox_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_NiagaraGroundBox_C.__ExecuteUbergraph_BP_NiagaraGroundBox_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06025FB1 RID: 155569 RVA: 0x009CA41F File Offset: 0x009C861F
		protected BP_NiagaraGroundBox_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04013A2C RID: 80428
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Effect/Scene/BP_NiagaraGroundBox.BP_NiagaraGroundBox_C";

		// Token: 0x04013A2D RID: 80429
		private static IntPtr _ClassPtr;

		// Token: 0x04013A2E RID: 80430
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04013A2F RID: 80431
		internal static int __PropertyOffset_0;

		// Token: 0x04013A30 RID: 80432
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04013A31 RID: 80433
		internal static int __PropertyOffset_1;

		// Token: 0x04013A32 RID: 80434
		internal static int __PropertyOffset_2;

		// Token: 0x04013A33 RID: 80435
		internal static int __PropertyOffset_3;

		// Token: 0x04013A34 RID: 80436
		internal static int __PropertyOffset_4;

		// Token: 0x04013A35 RID: 80437
		internal static int __PropertyOffset_5;

		// Token: 0x04013A36 RID: 80438
		private TArray<FVector> _ResArray;

		// Token: 0x04013A37 RID: 80439
		internal static int __PropertyOffset_6;

		// Token: 0x04013A38 RID: 80440
		internal static int __PropertyOffset_7;

		// Token: 0x04013A39 RID: 80441
		internal static int __PropertyOffset_8;

		// Token: 0x04013A3A RID: 80442
		internal static int __PropertyOffset_9;

		// Token: 0x04013A3B RID: 80443
		internal static int __PropertyOffset_10;

		// Token: 0x04013A3C RID: 80444
		internal static int __PropertyOffset_11;

		// Token: 0x04013A3D RID: 80445
		private static IntPtr __EvalSample_NativeFunctionPtr;

		// Token: 0x04013A3E RID: 80446
		private static IntPtr __Refresh_NativeFunctionPtr;

		// Token: 0x04013A3F RID: 80447
		private static IntPtr __TraceImpl_NativeFunctionPtr;

		// Token: 0x04013A40 RID: 80448
		private static IntPtr __Calculate_NativeFunctionPtr;

		// Token: 0x04013A41 RID: 80449
		private static IntPtr __DebugDraw_NativeFunctionPtr;

		// Token: 0x04013A42 RID: 80450
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04013A43 RID: 80451
		private static IntPtr __ExecuteUbergraph_BP_NiagaraGroundBox_NativeFunctionPtr;

		// Token: 0x02009FD7 RID: 40919
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 656)]
		protected ref struct __TraceImpl_FunctionParams
		{
			// Token: 0x04032B8F RID: 207759
			[FieldOffset(0)]
			public bool DrawOnly;
		}

		// Token: 0x02009FD8 RID: 40920
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032B90 RID: 207760
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009FD9 RID: 40921
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __ExecuteUbergraph_BP_NiagaraGroundBox_FunctionParams
		{
			// Token: 0x04032B91 RID: 207761
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
