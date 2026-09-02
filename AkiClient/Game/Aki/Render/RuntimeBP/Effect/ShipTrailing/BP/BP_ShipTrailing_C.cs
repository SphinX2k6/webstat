using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Effect.ShipTrailing.BP
{
	// Token: 0x02003D2E RID: 15662
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Effect/ShipTrailing/BP/BP_ShipTrailing.BP_ShipTrailing_C")]
	[UnrealStructLayout(1216, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1212)]
	public class BP_ShipTrailing_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06025EBA RID: 155322 RVA: 0x009C89E8 File Offset: 0x009C6BE8
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_ShipTrailing_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Effect/ShipTrailing/BP/BP_ShipTrailing.BP_ShipTrailing_C");
			}
			return BP_ShipTrailing_C._ClassPtr;
		}

		// Token: 0x06025EBB RID: 155323 RVA: 0x009C8A0C File Offset: 0x009C6C0C
		public BP_ShipTrailing_C() : this(BuiltinUtils.AllocNativeUObject(BP_ShipTrailing_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06025EBC RID: 155324 RVA: 0x009C8A34 File Offset: 0x009C6C34
		[NullableContext(1)]
		public BP_ShipTrailing_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_ShipTrailing_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700547B RID: 21627
		// (get) Token: 0x06025EBD RID: 155325 RVA: 0x009C8A68 File Offset: 0x009C6C68
		// (set) Token: 0x06025EBE RID: 155326 RVA: 0x009C8AA1 File Offset: 0x009C6CA1
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_ShipTrailing_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_ShipTrailing_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700547C RID: 21628
		// (get) Token: 0x06025EBF RID: 155327 RVA: 0x009C8AC2 File Offset: 0x009C6CC2
		// (set) Token: 0x06025EC0 RID: 155328 RVA: 0x009C8AD6 File Offset: 0x009C6CD6
		public unsafe UStaticMeshComponent Plane
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ShipTrailing_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ShipTrailing_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x1700547D RID: 21629
		// (get) Token: 0x06025EC1 RID: 155329 RVA: 0x009C8AEB File Offset: 0x009C6CEB
		// (set) Token: 0x06025EC2 RID: 155330 RVA: 0x009C8AFF File Offset: 0x009C6CFF
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ShipTrailing_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ShipTrailing_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x1700547E RID: 21630
		// (get) Token: 0x06025EC3 RID: 155331 RVA: 0x009C8B14 File Offset: 0x009C6D14
		// (set) Token: 0x06025EC4 RID: 155332 RVA: 0x009C8B4D File Offset: 0x009C6D4D
		[Nullable(1)]
		public TArray<float> offsetList
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<float> result;
				if ((result = this._offsetList) == null)
				{
					result = (this._offsetList = new TArray<float>(base.NativePtr + (IntPtr)BP_ShipTrailing_C.__PropertyOffset_3, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.offsetList.CopyAssign(value);
			}
		}

		// Token: 0x1700547F RID: 21631
		// (get) Token: 0x06025EC5 RID: 155333 RVA: 0x009C8B5B File Offset: 0x009C6D5B
		// (set) Token: 0x06025EC6 RID: 155334 RVA: 0x009C8B6F File Offset: 0x009C6D6F
		public unsafe AActor player
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ShipTrailing_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ShipTrailing_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17005480 RID: 21632
		// (get) Token: 0x06025EC7 RID: 155335 RVA: 0x009C8B84 File Offset: 0x009C6D84
		// (set) Token: 0x06025EC8 RID: 155336 RVA: 0x009C8B98 File Offset: 0x009C6D98
		public unsafe FVector playerPos
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ShipTrailing_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ShipTrailing_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17005481 RID: 21633
		// (get) Token: 0x06025EC9 RID: 155337 RVA: 0x009C8BAD File Offset: 0x009C6DAD
		// (set) Token: 0x06025ECA RID: 155338 RVA: 0x009C8BBD File Offset: 0x009C6DBD
		public unsafe float playerSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ShipTrailing_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ShipTrailing_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17005482 RID: 21634
		// (get) Token: 0x06025ECB RID: 155339 RVA: 0x009C8BCE File Offset: 0x009C6DCE
		// (set) Token: 0x06025ECC RID: 155340 RVA: 0x009C8BDE File Offset: 0x009C6DDE
		public unsafe bool showDebugInfo
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ShipTrailing_C.__PropertyOffset_7) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ShipTrailing_C.__PropertyOffset_7) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005483 RID: 21635
		// (get) Token: 0x06025ECD RID: 155341 RVA: 0x009C8BEF File Offset: 0x009C6DEF
		// (set) Token: 0x06025ECE RID: 155342 RVA: 0x009C8BFF File Offset: 0x009C6DFF
		public unsafe float timePerStamp
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ShipTrailing_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ShipTrailing_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17005484 RID: 21636
		// (get) Token: 0x06025ECF RID: 155343 RVA: 0x009C8C10 File Offset: 0x009C6E10
		// (set) Token: 0x06025ED0 RID: 155344 RVA: 0x009C8C24 File Offset: 0x009C6E24
		public unsafe UMaterialInstanceDynamic dynamicMat
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ShipTrailing_C.__PropertyOffset_9);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ShipTrailing_C.__PropertyOffset_9, value);
			}
		}

		// Token: 0x17005485 RID: 21637
		// (get) Token: 0x06025ED1 RID: 155345 RVA: 0x009C8C39 File Offset: 0x009C6E39
		// (set) Token: 0x06025ED2 RID: 155346 RVA: 0x009C8C49 File Offset: 0x009C6E49
		public unsafe float timeSum
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ShipTrailing_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ShipTrailing_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17005486 RID: 21638
		// (get) Token: 0x06025ED3 RID: 155347 RVA: 0x009C8C5C File Offset: 0x009C6E5C
		// (set) Token: 0x06025ED4 RID: 155348 RVA: 0x009C8C95 File Offset: 0x009C6E95
		[Nullable(1)]
		public TArray<FVector> posList
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<FVector> result;
				if ((result = this._posList) == null)
				{
					result = (this._posList = new TArray<FVector>(base.NativePtr + (IntPtr)BP_ShipTrailing_C.__PropertyOffset_11, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.posList.CopyAssign(value);
			}
		}

		// Token: 0x17005487 RID: 21639
		// (get) Token: 0x06025ED5 RID: 155349 RVA: 0x009C8CA3 File Offset: 0x009C6EA3
		// (set) Token: 0x06025ED6 RID: 155350 RVA: 0x009C8CB7 File Offset: 0x009C6EB7
		public unsafe FVector4 offsets
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ShipTrailing_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ShipTrailing_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17005488 RID: 21640
		// (get) Token: 0x06025ED7 RID: 155351 RVA: 0x009C8CCC File Offset: 0x009C6ECC
		// (set) Token: 0x06025ED8 RID: 155352 RVA: 0x009C8CE0 File Offset: 0x009C6EE0
		public unsafe FVector4 offsets_foe
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ShipTrailing_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ShipTrailing_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17005489 RID: 21641
		// (get) Token: 0x06025ED9 RID: 155353 RVA: 0x009C8CF5 File Offset: 0x009C6EF5
		// (set) Token: 0x06025EDA RID: 155354 RVA: 0x009C8D05 File Offset: 0x009C6F05
		public unsafe float playerSpeedFoe
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ShipTrailing_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ShipTrailing_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x1700548A RID: 21642
		// (get) Token: 0x06025EDB RID: 155355 RVA: 0x009C8D16 File Offset: 0x009C6F16
		// (set) Token: 0x06025EDC RID: 155356 RVA: 0x009C8D2A File Offset: 0x009C6F2A
		public unsafe FVector playerPosFoe
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ShipTrailing_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ShipTrailing_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x1700548B RID: 21643
		// (get) Token: 0x06025EDD RID: 155357 RVA: 0x009C8D3F File Offset: 0x009C6F3F
		// (set) Token: 0x06025EDE RID: 155358 RVA: 0x009C8D4F File Offset: 0x009C6F4F
		public unsafe float SpeedLerp
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ShipTrailing_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ShipTrailing_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x1700548C RID: 21644
		// (get) Token: 0x06025EDF RID: 155359 RVA: 0x009C8D60 File Offset: 0x009C6F60
		// (set) Token: 0x06025EE0 RID: 155360 RVA: 0x009C8D70 File Offset: 0x009C6F70
		public unsafe float OffsetLerp
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ShipTrailing_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ShipTrailing_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x1700548D RID: 21645
		// (get) Token: 0x06025EE1 RID: 155361 RVA: 0x009C8D81 File Offset: 0x009C6F81
		// (set) Token: 0x06025EE2 RID: 155362 RVA: 0x009C8D91 File Offset: 0x009C6F91
		public unsafe float Delta
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ShipTrailing_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ShipTrailing_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x1700548E RID: 21646
		// (get) Token: 0x06025EE3 RID: 155363 RVA: 0x009C8DA2 File Offset: 0x009C6FA2
		// (set) Token: 0x06025EE4 RID: 155364 RVA: 0x009C8DB6 File Offset: 0x009C6FB6
		public unsafe UMaterialInterface Mat
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInterface>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ShipTrailing_C.__PropertyOffset_19);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ShipTrailing_C.__PropertyOffset_19, value);
			}
		}

		// Token: 0x1700548F RID: 21647
		// (get) Token: 0x06025EE5 RID: 155365 RVA: 0x009C8DCB File Offset: 0x009C6FCB
		// (set) Token: 0x06025EE6 RID: 155366 RVA: 0x009C8DDB File Offset: 0x009C6FDB
		public unsafe float TexZ
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ShipTrailing_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ShipTrailing_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x06025EE7 RID: 155367 RVA: 0x009C8DEC File Offset: 0x009C6FEC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ShipTrailing_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06025EE8 RID: 155368 RVA: 0x009C8E00 File Offset: 0x009C7000
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_ShipTrailing_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06025EE9 RID: 155369 RVA: 0x009C8E18 File Offset: 0x009C7018
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_ShipTrailing_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_ShipTrailing_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_ShipTrailing_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ShipTrailing_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ShipTrailing_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025EEA RID: 155370 RVA: 0x009C8E60 File Offset: 0x009C7060
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_ShipTrailing_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_ShipTrailing_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_ShipTrailing_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ShipTrailing_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_ShipTrailing_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06025EEB RID: 155371 RVA: 0x009C8EA8 File Offset: 0x009C70A8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_ShipTrailing(int EntryPoint)
		{
			BP_ShipTrailing_C.__ExecuteUbergraph_BP_ShipTrailing_FunctionParams* ptr = stackalloc BP_ShipTrailing_C.__ExecuteUbergraph_BP_ShipTrailing_FunctionParams[(UIntPtr)1167] + 15L / (long)sizeof(BP_ShipTrailing_C.__ExecuteUbergraph_BP_ShipTrailing_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ShipTrailing_C.__ExecuteUbergraph_BP_ShipTrailing_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_ShipTrailing_C.__ExecuteUbergraph_BP_ShipTrailing_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06025EEC RID: 155372 RVA: 0x009C8EF2 File Offset: 0x009C70F2
		protected BP_ShipTrailing_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040139AB RID: 80299
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Effect/ShipTrailing/BP/BP_ShipTrailing.BP_ShipTrailing_C";

		// Token: 0x040139AC RID: 80300
		private static IntPtr _ClassPtr;

		// Token: 0x040139AD RID: 80301
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040139AE RID: 80302
		internal static int __PropertyOffset_0;

		// Token: 0x040139AF RID: 80303
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040139B0 RID: 80304
		internal static int __PropertyOffset_1;

		// Token: 0x040139B1 RID: 80305
		internal static int __PropertyOffset_2;

		// Token: 0x040139B2 RID: 80306
		internal static int __PropertyOffset_3;

		// Token: 0x040139B3 RID: 80307
		private TArray<float> _offsetList;

		// Token: 0x040139B4 RID: 80308
		internal static int __PropertyOffset_4;

		// Token: 0x040139B5 RID: 80309
		internal static int __PropertyOffset_5;

		// Token: 0x040139B6 RID: 80310
		internal static int __PropertyOffset_6;

		// Token: 0x040139B7 RID: 80311
		internal static int __PropertyOffset_7;

		// Token: 0x040139B8 RID: 80312
		internal static int __PropertyOffset_8;

		// Token: 0x040139B9 RID: 80313
		internal static int __PropertyOffset_9;

		// Token: 0x040139BA RID: 80314
		internal static int __PropertyOffset_10;

		// Token: 0x040139BB RID: 80315
		internal static int __PropertyOffset_11;

		// Token: 0x040139BC RID: 80316
		private TArray<FVector> _posList;

		// Token: 0x040139BD RID: 80317
		internal static int __PropertyOffset_12;

		// Token: 0x040139BE RID: 80318
		internal static int __PropertyOffset_13;

		// Token: 0x040139BF RID: 80319
		internal static int __PropertyOffset_14;

		// Token: 0x040139C0 RID: 80320
		internal static int __PropertyOffset_15;

		// Token: 0x040139C1 RID: 80321
		internal static int __PropertyOffset_16;

		// Token: 0x040139C2 RID: 80322
		internal static int __PropertyOffset_17;

		// Token: 0x040139C3 RID: 80323
		internal static int __PropertyOffset_18;

		// Token: 0x040139C4 RID: 80324
		internal static int __PropertyOffset_19;

		// Token: 0x040139C5 RID: 80325
		internal static int __PropertyOffset_20;

		// Token: 0x040139C6 RID: 80326
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x040139C7 RID: 80327
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x040139C8 RID: 80328
		private static IntPtr __ExecuteUbergraph_BP_ShipTrailing_NativeFunctionPtr;

		// Token: 0x02009FCD RID: 40909
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032B85 RID: 207749
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009FCE RID: 40910
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1152)]
		protected ref struct __ExecuteUbergraph_BP_ShipTrailing_FunctionParams
		{
			// Token: 0x04032B86 RID: 207750
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
