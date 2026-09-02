using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.SplineMover
{
	// Token: 0x02003B63 RID: 15203
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/SplineMover/BP_SplineMover.BP_SplineMover_C")]
	[UnrealStructLayout(1392, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1386)]
	public class BP_SplineMover_C : AKuroBPActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06021659 RID: 136793 RVA: 0x00947F73 File Offset: 0x00946173
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SplineMover_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/SplineMover/BP_SplineMover.BP_SplineMover_C");
			}
			return BP_SplineMover_C._ClassPtr;
		}

		// Token: 0x0602165A RID: 136794 RVA: 0x00947F98 File Offset: 0x00946198
		public BP_SplineMover_C() : this(BuiltinUtils.AllocNativeUObject(BP_SplineMover_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602165B RID: 136795 RVA: 0x00947FC0 File Offset: 0x009461C0
		[NullableContext(1)]
		public BP_SplineMover_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SplineMover_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003AF4 RID: 15092
		// (get) Token: 0x0602165C RID: 136796 RVA: 0x00947FF4 File Offset: 0x009461F4
		// (set) Token: 0x0602165D RID: 136797 RVA: 0x0094802D File Offset: 0x0094622D
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_SplineMover_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_SplineMover_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003AF5 RID: 15093
		// (get) Token: 0x0602165E RID: 136798 RVA: 0x0094804E File Offset: 0x0094624E
		// (set) Token: 0x0602165F RID: 136799 RVA: 0x00948062 File Offset: 0x00946262
		public unsafe USplineComponent Spline
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USplineComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplineMover_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplineMover_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003AF6 RID: 15094
		// (get) Token: 0x06021660 RID: 136800 RVA: 0x00948077 File Offset: 0x00946277
		// (set) Token: 0x06021661 RID: 136801 RVA: 0x0094808B File Offset: 0x0094628B
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplineMover_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplineMover_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17003AF7 RID: 15095
		// (get) Token: 0x06021662 RID: 136802 RVA: 0x009480A0 File Offset: 0x009462A0
		// (set) Token: 0x06021663 RID: 136803 RVA: 0x009480D9 File Offset: 0x009462D9
		[Nullable(1)]
		public TArray<FMoveData_splineMover> MoveStates
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<FMoveData_splineMover> result;
				if ((result = this._MoveStates) == null)
				{
					result = (this._MoveStates = new TArray<FMoveData_splineMover>(base.NativePtr + (IntPtr)BP_SplineMover_C.__PropertyOffset_3, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.MoveStates.CopyAssign(value);
			}
		}

		// Token: 0x17003AF8 RID: 15096
		// (get) Token: 0x06021664 RID: 136804 RVA: 0x009480E7 File Offset: 0x009462E7
		// (set) Token: 0x06021665 RID: 136805 RVA: 0x009480F7 File Offset: 0x009462F7
		public unsafe float TotalSplineLength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplineMover_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplineMover_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17003AF9 RID: 15097
		// (get) Token: 0x06021666 RID: 136806 RVA: 0x00948108 File Offset: 0x00946308
		// (set) Token: 0x06021667 RID: 136807 RVA: 0x00948118 File Offset: 0x00946318
		public unsafe float MoveSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplineMover_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplineMover_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17003AFA RID: 15098
		// (get) Token: 0x06021668 RID: 136808 RVA: 0x00948129 File Offset: 0x00946329
		// (set) Token: 0x06021669 RID: 136809 RVA: 0x00948139 File Offset: 0x00946339
		public unsafe bool IsMove
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplineMover_C.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplineMover_C.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003AFB RID: 15099
		// (get) Token: 0x0602166A RID: 136810 RVA: 0x0094814A File Offset: 0x0094634A
		// (set) Token: 0x0602166B RID: 136811 RVA: 0x0094815E File Offset: 0x0094635E
		public unsafe AStaticMeshActor mesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AStaticMeshActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplineMover_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplineMover_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x17003AFC RID: 15100
		// (get) Token: 0x0602166C RID: 136812 RVA: 0x00948173 File Offset: 0x00946373
		// (set) Token: 0x0602166D RID: 136813 RVA: 0x00948187 File Offset: 0x00946387
		public unsafe UMaterialInstanceDynamic DMI
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplineMover_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplineMover_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x17003AFD RID: 15101
		// (get) Token: 0x0602166E RID: 136814 RVA: 0x0094819C File Offset: 0x0094639C
		// (set) Token: 0x0602166F RID: 136815 RVA: 0x009481AC File Offset: 0x009463AC
		public unsafe float Speed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplineMover_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplineMover_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17003AFE RID: 15102
		// (get) Token: 0x06021670 RID: 136816 RVA: 0x009481BD File Offset: 0x009463BD
		// (set) Token: 0x06021671 RID: 136817 RVA: 0x009481CD File Offset: 0x009463CD
		public unsafe float CustomV
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplineMover_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplineMover_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17003AFF RID: 15103
		// (get) Token: 0x06021672 RID: 136818 RVA: 0x009481DE File Offset: 0x009463DE
		// (set) Token: 0x06021673 RID: 136819 RVA: 0x009481EE File Offset: 0x009463EE
		public unsafe bool NewVar_0
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplineMover_C.__PropertyOffset_11) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplineMover_C.__PropertyOffset_11) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003B00 RID: 15104
		// (get) Token: 0x06021674 RID: 136820 RVA: 0x009481FF File Offset: 0x009463FF
		// (set) Token: 0x06021675 RID: 136821 RVA: 0x00948213 File Offset: 0x00946413
		[Nullable(0)]
		public unsafe TEnumAsByte<ECollisionEnabled> CollisionType
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplineMover_C.__PropertyOffset_12);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplineMover_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x06021676 RID: 136822 RVA: 0x00948228 File Offset: 0x00946428
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SplineMover_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06021677 RID: 136823 RVA: 0x0094823C File Offset: 0x0094643C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SplineMover_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06021678 RID: 136824 RVA: 0x00948254 File Offset: 0x00946454
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_SplineMover_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_SplineMover_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SplineMover_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SplineMover_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SplineMover_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021679 RID: 136825 RVA: 0x0094829C File Offset: 0x0094649C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_SplineMover_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_SplineMover_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SplineMover_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SplineMover_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SplineMover_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602167A RID: 136826 RVA: 0x009482E4 File Offset: 0x009464E4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveActorBeginOverlap(AActor OtherActor)
		{
			BP_SplineMover_C.__ReceiveActorBeginOverlap_FunctionParams* ptr = stackalloc BP_SplineMover_C.__ReceiveActorBeginOverlap_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_SplineMover_C.__ReceiveActorBeginOverlap_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SplineMover_C.__ReceiveActorBeginOverlap_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SplineMover_C.__ReceiveActorBeginOverlap_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602167B RID: 136827 RVA: 0x0094833C File Offset: 0x0094653C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveActorBeginOverlap_Implementation(AActor OtherActor)
		{
			BP_SplineMover_C.__ReceiveActorBeginOverlap_FunctionParams* ptr = stackalloc BP_SplineMover_C.__ReceiveActorBeginOverlap_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_SplineMover_C.__ReceiveActorBeginOverlap_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SplineMover_C.__ReceiveActorBeginOverlap_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SplineMover_C.__ReceiveActorBeginOverlap_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602167C RID: 136828 RVA: 0x00948394 File Offset: 0x00946594
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveActorEndOverlap(AActor OtherActor)
		{
			BP_SplineMover_C.__ReceiveActorEndOverlap_FunctionParams* ptr = stackalloc BP_SplineMover_C.__ReceiveActorEndOverlap_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_SplineMover_C.__ReceiveActorEndOverlap_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SplineMover_C.__ReceiveActorEndOverlap_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SplineMover_C.__ReceiveActorEndOverlap_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602167D RID: 136829 RVA: 0x009483EC File Offset: 0x009465EC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveActorEndOverlap_Implementation(AActor OtherActor)
		{
			BP_SplineMover_C.__ReceiveActorEndOverlap_FunctionParams* ptr = stackalloc BP_SplineMover_C.__ReceiveActorEndOverlap_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_SplineMover_C.__ReceiveActorEndOverlap_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SplineMover_C.__ReceiveActorEndOverlap_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SplineMover_C.__ReceiveActorEndOverlap_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602167E RID: 136830 RVA: 0x00948444 File Offset: 0x00946644
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_SplineMover(int EntryPoint)
		{
			BP_SplineMover_C.__ExecuteUbergraph_BP_SplineMover_FunctionParams* ptr = stackalloc BP_SplineMover_C.__ExecuteUbergraph_BP_SplineMover_FunctionParams[(UIntPtr)303] + 15L / (long)sizeof(BP_SplineMover_C.__ExecuteUbergraph_BP_SplineMover_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SplineMover_C.__ExecuteUbergraph_BP_SplineMover_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SplineMover_C.__ExecuteUbergraph_BP_SplineMover_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602167F RID: 136831 RVA: 0x0094848E File Offset: 0x0094668E
		protected BP_SplineMover_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04010CF7 RID: 68855
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/SplineMover/BP_SplineMover.BP_SplineMover_C";

		// Token: 0x04010CF8 RID: 68856
		private static IntPtr _ClassPtr;

		// Token: 0x04010CF9 RID: 68857
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04010CFA RID: 68858
		internal static int __PropertyOffset_0;

		// Token: 0x04010CFB RID: 68859
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04010CFC RID: 68860
		internal static int __PropertyOffset_1;

		// Token: 0x04010CFD RID: 68861
		internal static int __PropertyOffset_2;

		// Token: 0x04010CFE RID: 68862
		internal static int __PropertyOffset_3;

		// Token: 0x04010CFF RID: 68863
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<FMoveData_splineMover> _MoveStates;

		// Token: 0x04010D00 RID: 68864
		internal static int __PropertyOffset_4;

		// Token: 0x04010D01 RID: 68865
		internal static int __PropertyOffset_5;

		// Token: 0x04010D02 RID: 68866
		internal static int __PropertyOffset_6;

		// Token: 0x04010D03 RID: 68867
		internal static int __PropertyOffset_7;

		// Token: 0x04010D04 RID: 68868
		internal static int __PropertyOffset_8;

		// Token: 0x04010D05 RID: 68869
		internal static int __PropertyOffset_9;

		// Token: 0x04010D06 RID: 68870
		internal static int __PropertyOffset_10;

		// Token: 0x04010D07 RID: 68871
		internal static int __PropertyOffset_11;

		// Token: 0x04010D08 RID: 68872
		internal static int __PropertyOffset_12;

		// Token: 0x04010D09 RID: 68873
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04010D0A RID: 68874
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04010D0B RID: 68875
		private static IntPtr __ReceiveActorBeginOverlap_NativeFunctionPtr;

		// Token: 0x04010D0C RID: 68876
		private static IntPtr __ReceiveActorEndOverlap_NativeFunctionPtr;

		// Token: 0x04010D0D RID: 68877
		private static IntPtr __ExecuteUbergraph_BP_SplineMover_NativeFunctionPtr;

		// Token: 0x02009ACA RID: 39626
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x0403224E RID: 205390
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009ACB RID: 39627
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected new ref struct __ReceiveActorBeginOverlap_FunctionParams
		{
			// Token: 0x0403224F RID: 205391
			[FieldOffset(0)]
			public IntPtr OtherActor;
		}

		// Token: 0x02009ACC RID: 39628
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected new ref struct __ReceiveActorEndOverlap_FunctionParams
		{
			// Token: 0x04032250 RID: 205392
			[FieldOffset(0)]
			public IntPtr OtherActor;
		}

		// Token: 0x02009ACD RID: 39629
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 288)]
		protected ref struct __ExecuteUbergraph_BP_SplineMover_FunctionParams
		{
			// Token: 0x04032251 RID: 205393
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
