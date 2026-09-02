using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Interaction
{
	// Token: 0x02003ABF RID: 15039
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Interaction/BP_MaterialRuntimeParUpdate.BP_MaterialRuntimeParUpdate_C")]
	[UnrealStructLayout(1528, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1528)]
	public class BP_MaterialRuntimeParUpdate_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06020179 RID: 131449 RVA: 0x00922178 File Offset: 0x00920378
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_MaterialRuntimeParUpdate_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Interaction/BP_MaterialRuntimeParUpdate.BP_MaterialRuntimeParUpdate_C");
			}
			return BP_MaterialRuntimeParUpdate_C._ClassPtr;
		}

		// Token: 0x0602017A RID: 131450 RVA: 0x0092219C File Offset: 0x0092039C
		public BP_MaterialRuntimeParUpdate_C() : this(BuiltinUtils.AllocNativeUObject(BP_MaterialRuntimeParUpdate_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602017B RID: 131451 RVA: 0x009221C4 File Offset: 0x009203C4
		public BP_MaterialRuntimeParUpdate_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_MaterialRuntimeParUpdate_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170033E1 RID: 13281
		// (get) Token: 0x0602017C RID: 131452 RVA: 0x009221F8 File Offset: 0x009203F8
		// (set) Token: 0x0602017D RID: 131453 RVA: 0x00922231 File Offset: 0x00920431
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_MaterialRuntimeParUpdate_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_MaterialRuntimeParUpdate_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170033E2 RID: 13282
		// (get) Token: 0x0602017E RID: 131454 RVA: 0x00922252 File Offset: 0x00920452
		// (set) Token: 0x0602017F RID: 131455 RVA: 0x00922266 File Offset: 0x00920466
		[Nullable(2)]
		public unsafe USceneComponent Target
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MaterialRuntimeParUpdate_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MaterialRuntimeParUpdate_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170033E3 RID: 13283
		// (get) Token: 0x06020180 RID: 131456 RVA: 0x0092227B File Offset: 0x0092047B
		// (set) Token: 0x06020181 RID: 131457 RVA: 0x0092228F File Offset: 0x0092048F
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MaterialRuntimeParUpdate_C.__PropertyOffset_2);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MaterialRuntimeParUpdate_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170033E4 RID: 13284
		// (get) Token: 0x06020182 RID: 131458 RVA: 0x009222A4 File Offset: 0x009204A4
		// (set) Token: 0x06020183 RID: 131459 RVA: 0x009222B4 File Offset: 0x009204B4
		public unsafe int Material_Index
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MaterialRuntimeParUpdate_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MaterialRuntimeParUpdate_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x170033E5 RID: 13285
		// (get) Token: 0x06020184 RID: 131460 RVA: 0x009222C5 File Offset: 0x009204C5
		// (set) Token: 0x06020185 RID: 131461 RVA: 0x009222D9 File Offset: 0x009204D9
		public unsafe FLinearColor NewVar_0
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MaterialRuntimeParUpdate_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MaterialRuntimeParUpdate_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x170033E6 RID: 13286
		// (get) Token: 0x06020186 RID: 131462 RVA: 0x009222EE File Offset: 0x009204EE
		// (set) Token: 0x06020187 RID: 131463 RVA: 0x00922302 File Offset: 0x00920502
		[Nullable(2)]
		public unsafe ItemMaterialControllerActorData DA
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<ItemMaterialControllerActorData>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MaterialRuntimeParUpdate_C.__PropertyOffset_5);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MaterialRuntimeParUpdate_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x170033E7 RID: 13287
		// (get) Token: 0x06020188 RID: 131464 RVA: 0x00922318 File Offset: 0x00920518
		// (set) Token: 0x06020189 RID: 131465 RVA: 0x00922351 File Offset: 0x00920551
		public TMap<FName, FKuroCurveFloat> Custom_Scalar_Par_Map
		{
			get
			{
				base.FastCheckIsValid();
				TMap<FName, FKuroCurveFloat> result;
				if ((result = this._Custom_Scalar_Par_Map) == null)
				{
					result = (this._Custom_Scalar_Par_Map = new TMap<FName, FKuroCurveFloat>(base.NativePtr + (IntPtr)BP_MaterialRuntimeParUpdate_C.__PropertyOffset_6, this));
				}
				return result;
			}
			set
			{
				this.Custom_Scalar_Par_Map.CopyAssign(value);
			}
		}

		// Token: 0x170033E8 RID: 13288
		// (get) Token: 0x0602018A RID: 131466 RVA: 0x0092235F File Offset: 0x0092055F
		// (set) Token: 0x0602018B RID: 131467 RVA: 0x0092236F File Offset: 0x0092056F
		public unsafe float DateTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MaterialRuntimeParUpdate_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MaterialRuntimeParUpdate_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x170033E9 RID: 13289
		// (get) Token: 0x0602018C RID: 131468 RVA: 0x00922380 File Offset: 0x00920580
		// (set) Token: 0x0602018D RID: 131469 RVA: 0x00922394 File Offset: 0x00920594
		public unsafe FName FloatParam_0
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MaterialRuntimeParUpdate_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MaterialRuntimeParUpdate_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x170033EA RID: 13290
		// (get) Token: 0x0602018E RID: 131470 RVA: 0x009223A9 File Offset: 0x009205A9
		// (set) Token: 0x0602018F RID: 131471 RVA: 0x009223B9 File Offset: 0x009205B9
		public unsafe float FloatParam_Value_0
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MaterialRuntimeParUpdate_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MaterialRuntimeParUpdate_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x170033EB RID: 13291
		// (get) Token: 0x06020190 RID: 131472 RVA: 0x009223CA File Offset: 0x009205CA
		// (set) Token: 0x06020191 RID: 131473 RVA: 0x009223DE File Offset: 0x009205DE
		public unsafe FName VectorParam_0
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MaterialRuntimeParUpdate_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MaterialRuntimeParUpdate_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x170033EC RID: 13292
		// (get) Token: 0x06020192 RID: 131474 RVA: 0x009223F3 File Offset: 0x009205F3
		// (set) Token: 0x06020193 RID: 131475 RVA: 0x00922407 File Offset: 0x00920607
		public unsafe FLinearColor VectorParam_Value_0
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MaterialRuntimeParUpdate_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MaterialRuntimeParUpdate_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x170033ED RID: 13293
		// (get) Token: 0x06020194 RID: 131476 RVA: 0x0092241C File Offset: 0x0092061C
		// (set) Token: 0x06020195 RID: 131477 RVA: 0x00922455 File Offset: 0x00920655
		public TArray<UMaterialInstance> Materials
		{
			get
			{
				base.FastCheckIsValid();
				TArray<UMaterialInstance> result;
				if ((result = this._Materials) == null)
				{
					result = (this._Materials = new TArray<UMaterialInstance>(base.NativePtr + (IntPtr)BP_MaterialRuntimeParUpdate_C.__PropertyOffset_12, this));
				}
				return result;
			}
			set
			{
				this.Materials.CopyAssign(value);
			}
		}

		// Token: 0x170033EE RID: 13294
		// (get) Token: 0x06020196 RID: 131478 RVA: 0x00922463 File Offset: 0x00920663
		// (set) Token: 0x06020197 RID: 131479 RVA: 0x00922473 File Offset: 0x00920673
		public unsafe bool IsPlay
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MaterialRuntimeParUpdate_C.__PropertyOffset_13) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MaterialRuntimeParUpdate_C.__PropertyOffset_13) = (value ? 1 : 0);
			}
		}

		// Token: 0x170033EF RID: 13295
		// (get) Token: 0x06020198 RID: 131480 RVA: 0x00922484 File Offset: 0x00920684
		// (set) Token: 0x06020199 RID: 131481 RVA: 0x00922494 File Offset: 0x00920694
		public unsafe float Time_Speed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MaterialRuntimeParUpdate_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MaterialRuntimeParUpdate_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x170033F0 RID: 13296
		// (get) Token: 0x0602019A RID: 131482 RVA: 0x009224A5 File Offset: 0x009206A5
		// (set) Token: 0x0602019B RID: 131483 RVA: 0x009224B5 File Offset: 0x009206B5
		public unsafe float MaxDurationTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MaterialRuntimeParUpdate_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MaterialRuntimeParUpdate_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x170033F1 RID: 13297
		// (get) Token: 0x0602019C RID: 131484 RVA: 0x009224C6 File Offset: 0x009206C6
		// (set) Token: 0x0602019D RID: 131485 RVA: 0x009224D6 File Offset: 0x009206D6
		public unsafe float Timer_0
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MaterialRuntimeParUpdate_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MaterialRuntimeParUpdate_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x0602019E RID: 131486 RVA: 0x009224E7 File Offset: 0x009206E7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CleanArray()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MaterialRuntimeParUpdate_C.__CleanArray_NativeFunctionPtr, null);
		}

		// Token: 0x0602019F RID: 131487 RVA: 0x009224FB File Offset: 0x009206FB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Play()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MaterialRuntimeParUpdate_C.__Play_NativeFunctionPtr, null);
		}

		// Token: 0x060201A0 RID: 131488 RVA: 0x0092250F File Offset: 0x0092070F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Set_Initialize()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MaterialRuntimeParUpdate_C.__Set_Initialize_NativeFunctionPtr, null);
		}

		// Token: 0x060201A1 RID: 131489 RVA: 0x00922523 File Offset: 0x00920723
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MaterialRuntimeParUpdate_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x060201A2 RID: 131490 RVA: 0x00922537 File Offset: 0x00920737
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MaterialRuntimeParUpdate_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060201A3 RID: 131491 RVA: 0x0092254C File Offset: 0x0092074C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MaterialRuntimeParUpdate_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x060201A4 RID: 131492 RVA: 0x00922560 File Offset: 0x00920760
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MaterialRuntimeParUpdate_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060201A5 RID: 131493 RVA: 0x00922578 File Offset: 0x00920778
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_MaterialRuntimeParUpdate_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_MaterialRuntimeParUpdate_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_MaterialRuntimeParUpdate_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MaterialRuntimeParUpdate_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MaterialRuntimeParUpdate_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060201A6 RID: 131494 RVA: 0x009225C0 File Offset: 0x009207C0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_MaterialRuntimeParUpdate_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_MaterialRuntimeParUpdate_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_MaterialRuntimeParUpdate_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MaterialRuntimeParUpdate_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MaterialRuntimeParUpdate_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060201A7 RID: 131495 RVA: 0x00922608 File Offset: 0x00920808
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_MaterialRuntimeParUpdate(int EntryPoint)
		{
			BP_MaterialRuntimeParUpdate_C.__ExecuteUbergraph_BP_MaterialRuntimeParUpdate_FunctionParams* ptr = stackalloc BP_MaterialRuntimeParUpdate_C.__ExecuteUbergraph_BP_MaterialRuntimeParUpdate_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_MaterialRuntimeParUpdate_C.__ExecuteUbergraph_BP_MaterialRuntimeParUpdate_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MaterialRuntimeParUpdate_C.__ExecuteUbergraph_BP_MaterialRuntimeParUpdate_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MaterialRuntimeParUpdate_C.__ExecuteUbergraph_BP_MaterialRuntimeParUpdate_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060201A8 RID: 131496 RVA: 0x0092264F File Offset: 0x0092084F
		protected BP_MaterialRuntimeParUpdate_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400FFE0 RID: 65504
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Interaction/BP_MaterialRuntimeParUpdate.BP_MaterialRuntimeParUpdate_C";

		// Token: 0x0400FFE1 RID: 65505
		private static IntPtr _ClassPtr;

		// Token: 0x0400FFE2 RID: 65506
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400FFE3 RID: 65507
		internal static int __PropertyOffset_0;

		// Token: 0x0400FFE4 RID: 65508
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400FFE5 RID: 65509
		internal static int __PropertyOffset_1;

		// Token: 0x0400FFE6 RID: 65510
		internal static int __PropertyOffset_2;

		// Token: 0x0400FFE7 RID: 65511
		internal static int __PropertyOffset_3;

		// Token: 0x0400FFE8 RID: 65512
		internal static int __PropertyOffset_4;

		// Token: 0x0400FFE9 RID: 65513
		internal static int __PropertyOffset_5;

		// Token: 0x0400FFEA RID: 65514
		internal static int __PropertyOffset_6;

		// Token: 0x0400FFEB RID: 65515
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<FName, FKuroCurveFloat> _Custom_Scalar_Par_Map;

		// Token: 0x0400FFEC RID: 65516
		internal static int __PropertyOffset_7;

		// Token: 0x0400FFED RID: 65517
		internal static int __PropertyOffset_8;

		// Token: 0x0400FFEE RID: 65518
		internal static int __PropertyOffset_9;

		// Token: 0x0400FFEF RID: 65519
		internal static int __PropertyOffset_10;

		// Token: 0x0400FFF0 RID: 65520
		internal static int __PropertyOffset_11;

		// Token: 0x0400FFF1 RID: 65521
		internal static int __PropertyOffset_12;

		// Token: 0x0400FFF2 RID: 65522
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UMaterialInstance> _Materials;

		// Token: 0x0400FFF3 RID: 65523
		internal static int __PropertyOffset_13;

		// Token: 0x0400FFF4 RID: 65524
		internal static int __PropertyOffset_14;

		// Token: 0x0400FFF5 RID: 65525
		internal static int __PropertyOffset_15;

		// Token: 0x0400FFF6 RID: 65526
		internal static int __PropertyOffset_16;

		// Token: 0x0400FFF7 RID: 65527
		private static IntPtr __CleanArray_NativeFunctionPtr;

		// Token: 0x0400FFF8 RID: 65528
		private static IntPtr __Play_NativeFunctionPtr;

		// Token: 0x0400FFF9 RID: 65529
		private static IntPtr __Set_Initialize_NativeFunctionPtr;

		// Token: 0x0400FFFA RID: 65530
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0400FFFB RID: 65531
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400FFFC RID: 65532
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400FFFD RID: 65533
		private static IntPtr __ExecuteUbergraph_BP_MaterialRuntimeParUpdate_NativeFunctionPtr;

		// Token: 0x02009961 RID: 39265
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031FCF RID: 204751
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009962 RID: 39266
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __ExecuteUbergraph_BP_MaterialRuntimeParUpdate_FunctionParams
		{
			// Token: 0x04031FD0 RID: 204752
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
