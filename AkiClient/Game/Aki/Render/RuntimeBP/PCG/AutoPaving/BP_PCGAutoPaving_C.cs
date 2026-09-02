using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.AutoPaving
{
	// Token: 0x02003C47 RID: 15431
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/AutoPaving/BP_PCGAutoPaving.BP_PCGAutoPaving_C")]
	[UnrealStructLayout(1520, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1512)]
	public class BP_PCGAutoPaving_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602382A RID: 145450 RVA: 0x0098433C File Offset: 0x0098253C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_PCGAutoPaving_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/AutoPaving/BP_PCGAutoPaving.BP_PCGAutoPaving_C");
			}
			return BP_PCGAutoPaving_C._ClassPtr;
		}

		// Token: 0x0602382B RID: 145451 RVA: 0x00984360 File Offset: 0x00982560
		public BP_PCGAutoPaving_C() : this(BuiltinUtils.AllocNativeUObject(BP_PCGAutoPaving_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602382C RID: 145452 RVA: 0x00984388 File Offset: 0x00982588
		public BP_PCGAutoPaving_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_PCGAutoPaving_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170046D4 RID: 18132
		// (get) Token: 0x0602382D RID: 145453 RVA: 0x009843BC File Offset: 0x009825BC
		// (set) Token: 0x0602382E RID: 145454 RVA: 0x009843F5 File Offset: 0x009825F5
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_PCGAutoPaving_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_PCGAutoPaving_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170046D5 RID: 18133
		// (get) Token: 0x0602382F RID: 145455 RVA: 0x00984416 File Offset: 0x00982616
		// (set) Token: 0x06023830 RID: 145456 RVA: 0x0098442A File Offset: 0x0098262A
		[Nullable(2)]
		public unsafe UStaticMeshComponent StaticMesh
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PCGAutoPaving_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PCGAutoPaving_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170046D6 RID: 18134
		// (get) Token: 0x06023831 RID: 145457 RVA: 0x0098443F File Offset: 0x0098263F
		// (set) Token: 0x06023832 RID: 145458 RVA: 0x00984453 File Offset: 0x00982653
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PCGAutoPaving_C.__PropertyOffset_2);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PCGAutoPaving_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170046D7 RID: 18135
		// (get) Token: 0x06023833 RID: 145459 RVA: 0x00984468 File Offset: 0x00982668
		// (set) Token: 0x06023834 RID: 145460 RVA: 0x00984478 File Offset: 0x00982678
		public unsafe bool PageTurning
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PCGAutoPaving_C.__PropertyOffset_3) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PCGAutoPaving_C.__PropertyOffset_3) = (value ? 1 : 0);
			}
		}

		// Token: 0x170046D8 RID: 18136
		// (get) Token: 0x06023835 RID: 145461 RVA: 0x00984489 File Offset: 0x00982689
		// (set) Token: 0x06023836 RID: 145462 RVA: 0x00984499 File Offset: 0x00982699
		public unsafe float Speed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PCGAutoPaving_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PCGAutoPaving_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x170046D9 RID: 18137
		// (get) Token: 0x06023837 RID: 145463 RVA: 0x009844AA File Offset: 0x009826AA
		// (set) Token: 0x06023838 RID: 145464 RVA: 0x009844BE File Offset: 0x009826BE
		public unsafe FTransformDouble TransformOld
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PCGAutoPaving_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PCGAutoPaving_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x170046DA RID: 18138
		// (get) Token: 0x06023839 RID: 145465 RVA: 0x009844D3 File Offset: 0x009826D3
		// (set) Token: 0x0602383A RID: 145466 RVA: 0x009844E7 File Offset: 0x009826E7
		public unsafe FTransformDouble TransformNew
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PCGAutoPaving_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PCGAutoPaving_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x170046DB RID: 18139
		// (get) Token: 0x0602383B RID: 145467 RVA: 0x009844FC File Offset: 0x009826FC
		// (set) Token: 0x0602383C RID: 145468 RVA: 0x0098450C File Offset: 0x0098270C
		public unsafe float PavingTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PCGAutoPaving_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PCGAutoPaving_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x170046DC RID: 18140
		// (get) Token: 0x0602383D RID: 145469 RVA: 0x0098451D File Offset: 0x0098271D
		// (set) Token: 0x0602383E RID: 145470 RVA: 0x0098452D File Offset: 0x0098272D
		public unsafe bool PavingState
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PCGAutoPaving_C.__PropertyOffset_8) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PCGAutoPaving_C.__PropertyOffset_8) = (value ? 1 : 0);
			}
		}

		// Token: 0x170046DD RID: 18141
		// (get) Token: 0x0602383F RID: 145471 RVA: 0x0098453E File Offset: 0x0098273E
		// (set) Token: 0x06023840 RID: 145472 RVA: 0x0098454E File Offset: 0x0098274E
		public unsafe bool EdirotTick
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PCGAutoPaving_C.__PropertyOffset_9) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PCGAutoPaving_C.__PropertyOffset_9) = (value ? 1 : 0);
			}
		}

		// Token: 0x170046DE RID: 18142
		// (get) Token: 0x06023841 RID: 145473 RVA: 0x0098455F File Offset: 0x0098275F
		// (set) Token: 0x06023842 RID: 145474 RVA: 0x0098456F File Offset: 0x0098276F
		public unsafe float Delta_Seconds
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PCGAutoPaving_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PCGAutoPaving_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x170046DF RID: 18143
		// (get) Token: 0x06023843 RID: 145475 RVA: 0x00984580 File Offset: 0x00982780
		// (set) Token: 0x06023844 RID: 145476 RVA: 0x009845B9 File Offset: 0x009827B9
		public TArray<float> PageTimes
		{
			get
			{
				base.FastCheckIsValid();
				TArray<float> result;
				if ((result = this._PageTimes) == null)
				{
					result = (this._PageTimes = new TArray<float>(base.NativePtr + (IntPtr)BP_PCGAutoPaving_C.__PropertyOffset_11, this));
				}
				return result;
			}
			set
			{
				this.PageTimes.CopyAssign(value);
			}
		}

		// Token: 0x170046E0 RID: 18144
		// (get) Token: 0x06023845 RID: 145477 RVA: 0x009845C7 File Offset: 0x009827C7
		// (set) Token: 0x06023846 RID: 145478 RVA: 0x009845D7 File Offset: 0x009827D7
		public unsafe int Tick_Add
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PCGAutoPaving_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PCGAutoPaving_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x170046E1 RID: 18145
		// (get) Token: 0x06023847 RID: 145479 RVA: 0x009845E8 File Offset: 0x009827E8
		// (set) Token: 0x06023848 RID: 145480 RVA: 0x009845F8 File Offset: 0x009827F8
		public unsafe float Delta_Seconds_Add
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PCGAutoPaving_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PCGAutoPaving_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x06023849 RID: 145481 RVA: 0x0098460C File Offset: 0x0098280C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void PageTurningTime(bool Turning)
		{
			BP_PCGAutoPaving_C.__PageTurningTime_FunctionParams* ptr = stackalloc BP_PCGAutoPaving_C.__PageTurningTime_FunctionParams[(UIntPtr)63] + 15L / (long)sizeof(BP_PCGAutoPaving_C.__PageTurningTime_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PCGAutoPaving_C.__PageTurningTime_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Turning = Turning;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PCGAutoPaving_C.__PageTurningTime_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602384A RID: 145482 RVA: 0x00984652 File Offset: 0x00982852
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 生成静态模型_演出_()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PCGAutoPaving_C.__生成静态模型_演出__NativeFunctionPtr, null);
		}

		// Token: 0x0602384B RID: 145483 RVA: 0x00984666 File Offset: 0x00982866
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 返回原位()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PCGAutoPaving_C.__返回原位_NativeFunctionPtr, null);
		}

		// Token: 0x0602384C RID: 145484 RVA: 0x0098467A File Offset: 0x0098287A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 预览()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PCGAutoPaving_C.__预览_NativeFunctionPtr, null);
		}

		// Token: 0x0602384D RID: 145485 RVA: 0x0098468E File Offset: 0x0098288E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 计算位置()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PCGAutoPaving_C.__计算位置_NativeFunctionPtr, null);
		}

		// Token: 0x0602384E RID: 145486 RVA: 0x009846A2 File Offset: 0x009828A2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PCGAutoPaving_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0602384F RID: 145487 RVA: 0x009846B6 File Offset: 0x009828B6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PCGAutoPaving_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06023850 RID: 145488 RVA: 0x009846CC File Offset: 0x009828CC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_PCGAutoPaving_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_PCGAutoPaving_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_PCGAutoPaving_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PCGAutoPaving_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PCGAutoPaving_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06023851 RID: 145489 RVA: 0x00984714 File Offset: 0x00982914
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_PCGAutoPaving_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_PCGAutoPaving_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_PCGAutoPaving_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PCGAutoPaving_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PCGAutoPaving_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023852 RID: 145490 RVA: 0x0098475C File Offset: 0x0098295C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_PCGAutoPaving_C.__EditorTick_FunctionParams* ptr = stackalloc BP_PCGAutoPaving_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_PCGAutoPaving_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PCGAutoPaving_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PCGAutoPaving_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06023853 RID: 145491 RVA: 0x009847A4 File Offset: 0x009829A4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_PCGAutoPaving_C.__EditorTick_FunctionParams* ptr = stackalloc BP_PCGAutoPaving_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_PCGAutoPaving_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PCGAutoPaving_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PCGAutoPaving_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023854 RID: 145492 RVA: 0x009847EC File Offset: 0x009829EC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_PCGAutoPaving(int EntryPoint)
		{
			BP_PCGAutoPaving_C.__ExecuteUbergraph_BP_PCGAutoPaving_FunctionParams* ptr = stackalloc BP_PCGAutoPaving_C.__ExecuteUbergraph_BP_PCGAutoPaving_FunctionParams[(UIntPtr)431] + 15L / (long)sizeof(BP_PCGAutoPaving_C.__ExecuteUbergraph_BP_PCGAutoPaving_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PCGAutoPaving_C.__ExecuteUbergraph_BP_PCGAutoPaving_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PCGAutoPaving_C.__ExecuteUbergraph_BP_PCGAutoPaving_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023855 RID: 145493 RVA: 0x00984836 File Offset: 0x00982A36
		protected BP_PCGAutoPaving_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401214B RID: 74059
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/AutoPaving/BP_PCGAutoPaving.BP_PCGAutoPaving_C";

		// Token: 0x0401214C RID: 74060
		private static IntPtr _ClassPtr;

		// Token: 0x0401214D RID: 74061
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401214E RID: 74062
		internal static int __PropertyOffset_0;

		// Token: 0x0401214F RID: 74063
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04012150 RID: 74064
		internal static int __PropertyOffset_1;

		// Token: 0x04012151 RID: 74065
		internal static int __PropertyOffset_2;

		// Token: 0x04012152 RID: 74066
		internal static int __PropertyOffset_3;

		// Token: 0x04012153 RID: 74067
		internal static int __PropertyOffset_4;

		// Token: 0x04012154 RID: 74068
		internal static int __PropertyOffset_5;

		// Token: 0x04012155 RID: 74069
		internal static int __PropertyOffset_6;

		// Token: 0x04012156 RID: 74070
		internal static int __PropertyOffset_7;

		// Token: 0x04012157 RID: 74071
		internal static int __PropertyOffset_8;

		// Token: 0x04012158 RID: 74072
		internal static int __PropertyOffset_9;

		// Token: 0x04012159 RID: 74073
		internal static int __PropertyOffset_10;

		// Token: 0x0401215A RID: 74074
		internal static int __PropertyOffset_11;

		// Token: 0x0401215B RID: 74075
		[Nullable(2)]
		private TArray<float> _PageTimes;

		// Token: 0x0401215C RID: 74076
		internal static int __PropertyOffset_12;

		// Token: 0x0401215D RID: 74077
		internal static int __PropertyOffset_13;

		// Token: 0x0401215E RID: 74078
		private static IntPtr __PageTurningTime_NativeFunctionPtr;

		// Token: 0x0401215F RID: 74079
		private static IntPtr __生成静态模型_演出__NativeFunctionPtr;

		// Token: 0x04012160 RID: 74080
		private static IntPtr __返回原位_NativeFunctionPtr;

		// Token: 0x04012161 RID: 74081
		private static IntPtr __预览_NativeFunctionPtr;

		// Token: 0x04012162 RID: 74082
		private static IntPtr __计算位置_NativeFunctionPtr;

		// Token: 0x04012163 RID: 74083
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04012164 RID: 74084
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04012165 RID: 74085
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x04012166 RID: 74086
		private static IntPtr __ExecuteUbergraph_BP_PCGAutoPaving_NativeFunctionPtr;

		// Token: 0x02009CF4 RID: 40180
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 48)]
		protected ref struct __PageTurningTime_FunctionParams
		{
			// Token: 0x04032694 RID: 206484
			[FieldOffset(0)]
			public bool Turning;
		}

		// Token: 0x02009CF5 RID: 40181
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032695 RID: 206485
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009CF6 RID: 40182
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04032696 RID: 206486
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009CF7 RID: 40183
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 416)]
		protected ref struct __ExecuteUbergraph_BP_PCGAutoPaving_FunctionParams
		{
			// Token: 0x04032697 RID: 206487
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
