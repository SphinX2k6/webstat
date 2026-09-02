using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.GPUClothSimulation
{
	// Token: 0x02003C1A RID: 15386
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/GPUClothSimulation/BP_PhysicCloth_v1.BP_PhysicCloth_v1_C")]
	[UnrealStructLayout(1128, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1122)]
	public class BP_PhysicCloth_v1_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060230CE RID: 143566 RVA: 0x00977108 File Offset: 0x00975308
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_PhysicCloth_v1_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/GPUClothSimulation/BP_PhysicCloth_v1.BP_PhysicCloth_v1_C");
			}
			return BP_PhysicCloth_v1_C._ClassPtr;
		}

		// Token: 0x060230CF RID: 143567 RVA: 0x0097712C File Offset: 0x0097532C
		public BP_PhysicCloth_v1_C() : this(BuiltinUtils.AllocNativeUObject(BP_PhysicCloth_v1_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060230D0 RID: 143568 RVA: 0x00977154 File Offset: 0x00975354
		[NullableContext(1)]
		public BP_PhysicCloth_v1_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_PhysicCloth_v1_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004427 RID: 17447
		// (get) Token: 0x060230D1 RID: 143569 RVA: 0x00977188 File Offset: 0x00975388
		// (set) Token: 0x060230D2 RID: 143570 RVA: 0x009771C1 File Offset: 0x009753C1
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_PhysicCloth_v1_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_PhysicCloth_v1_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004428 RID: 17448
		// (get) Token: 0x060230D3 RID: 143571 RVA: 0x009771E2 File Offset: 0x009753E2
		// (set) Token: 0x060230D4 RID: 143572 RVA: 0x009771F6 File Offset: 0x009753F6
		public unsafe UStaticMeshComponent CollsionCube
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PhysicCloth_v1_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PhysicCloth_v1_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17004429 RID: 17449
		// (get) Token: 0x060230D5 RID: 143573 RVA: 0x0097720B File Offset: 0x0097540B
		// (set) Token: 0x060230D6 RID: 143574 RVA: 0x0097721F File Offset: 0x0097541F
		public unsafe UNiagaraComponent NS_cloth
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PhysicCloth_v1_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PhysicCloth_v1_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x1700442A RID: 17450
		// (get) Token: 0x060230D7 RID: 143575 RVA: 0x00977234 File Offset: 0x00975434
		// (set) Token: 0x060230D8 RID: 143576 RVA: 0x00977248 File Offset: 0x00975448
		public unsafe UStaticMeshComponent SM_Ves_Clo_01AS
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PhysicCloth_v1_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PhysicCloth_v1_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x1700442B RID: 17451
		// (get) Token: 0x060230D9 RID: 143577 RVA: 0x0097725D File Offset: 0x0097545D
		// (set) Token: 0x060230DA RID: 143578 RVA: 0x00977271 File Offset: 0x00975471
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PhysicCloth_v1_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PhysicCloth_v1_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x1700442C RID: 17452
		// (get) Token: 0x060230DB RID: 143579 RVA: 0x00977286 File Offset: 0x00975486
		// (set) Token: 0x060230DC RID: 143580 RVA: 0x0097729A File Offset: 0x0097549A
		public unsafe UMaterialInterface Static_Material
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInterface>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PhysicCloth_v1_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PhysicCloth_v1_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x1700442D RID: 17453
		// (get) Token: 0x060230DD RID: 143581 RVA: 0x009772AF File Offset: 0x009754AF
		// (set) Token: 0x060230DE RID: 143582 RVA: 0x009772C3 File Offset: 0x009754C3
		public unsafe UTextureRenderTarget2D RT_Pos
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PhysicCloth_v1_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PhysicCloth_v1_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x1700442E RID: 17454
		// (get) Token: 0x060230DF RID: 143583 RVA: 0x009772D8 File Offset: 0x009754D8
		// (set) Token: 0x060230E0 RID: 143584 RVA: 0x009772E8 File Offset: 0x009754E8
		public unsafe int YCount
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PhysicCloth_v1_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PhysicCloth_v1_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x1700442F RID: 17455
		// (get) Token: 0x060230E1 RID: 143585 RVA: 0x009772F9 File Offset: 0x009754F9
		// (set) Token: 0x060230E2 RID: 143586 RVA: 0x00977309 File Offset: 0x00975509
		public unsafe int XCount
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PhysicCloth_v1_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PhysicCloth_v1_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17004430 RID: 17456
		// (get) Token: 0x060230E3 RID: 143587 RVA: 0x0097731A File Offset: 0x0097551A
		// (set) Token: 0x060230E4 RID: 143588 RVA: 0x0097732A File Offset: 0x0097552A
		public unsafe float Distance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PhysicCloth_v1_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PhysicCloth_v1_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17004431 RID: 17457
		// (get) Token: 0x060230E5 RID: 143589 RVA: 0x0097733B File Offset: 0x0097553B
		// (set) Token: 0x060230E6 RID: 143590 RVA: 0x0097734F File Offset: 0x0097554F
		public unsafe UMaterialInstanceDynamic DMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PhysicCloth_v1_C.__PropertyOffset_10);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PhysicCloth_v1_C.__PropertyOffset_10, value);
			}
		}

		// Token: 0x17004432 RID: 17458
		// (get) Token: 0x060230E7 RID: 143591 RVA: 0x00977364 File Offset: 0x00975564
		// (set) Token: 0x060230E8 RID: 143592 RVA: 0x00977374 File Offset: 0x00975574
		public unsafe float RestorationRigidity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PhysicCloth_v1_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PhysicCloth_v1_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17004433 RID: 17459
		// (get) Token: 0x060230E9 RID: 143593 RVA: 0x00977385 File Offset: 0x00975585
		// (set) Token: 0x060230EA RID: 143594 RVA: 0x00977395 File Offset: 0x00975595
		public unsafe float RestorationDamp
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PhysicCloth_v1_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PhysicCloth_v1_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17004434 RID: 17460
		// (get) Token: 0x060230EB RID: 143595 RVA: 0x009773A6 File Offset: 0x009755A6
		// (set) Token: 0x060230EC RID: 143596 RVA: 0x009773B6 File Offset: 0x009755B6
		public unsafe bool EnableRestoration
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PhysicCloth_v1_C.__PropertyOffset_13) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PhysicCloth_v1_C.__PropertyOffset_13) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004435 RID: 17461
		// (get) Token: 0x060230ED RID: 143597 RVA: 0x009773C7 File Offset: 0x009755C7
		// (set) Token: 0x060230EE RID: 143598 RVA: 0x009773D7 File Offset: 0x009755D7
		public unsafe bool EnableWpo
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PhysicCloth_v1_C.__PropertyOffset_14) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PhysicCloth_v1_C.__PropertyOffset_14) = (value ? 1 : 0);
			}
		}

		// Token: 0x060230EF RID: 143599 RVA: 0x009773E8 File Offset: 0x009755E8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Input_Niagara()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PhysicCloth_v1_C.__Input_Niagara_NativeFunctionPtr, null);
		}

		// Token: 0x060230F0 RID: 143600 RVA: 0x009773FC File Offset: 0x009755FC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Input_Parameters()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PhysicCloth_v1_C.__Input_Parameters_NativeFunctionPtr, null);
		}

		// Token: 0x060230F1 RID: 143601 RVA: 0x00977410 File Offset: 0x00975610
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PhysicCloth_v1_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x060230F2 RID: 143602 RVA: 0x00977424 File Offset: 0x00975624
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PhysicCloth_v1_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060230F3 RID: 143603 RVA: 0x00977439 File Offset: 0x00975639
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PhysicCloth_v1_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x060230F4 RID: 143604 RVA: 0x0097744D File Offset: 0x0097564D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PhysicCloth_v1_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060230F5 RID: 143605 RVA: 0x00977464 File Offset: 0x00975664
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_PhysicCloth_v1_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_PhysicCloth_v1_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_PhysicCloth_v1_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PhysicCloth_v1_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PhysicCloth_v1_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060230F6 RID: 143606 RVA: 0x009774AC File Offset: 0x009756AC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_PhysicCloth_v1_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_PhysicCloth_v1_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_PhysicCloth_v1_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PhysicCloth_v1_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PhysicCloth_v1_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060230F7 RID: 143607 RVA: 0x009774F4 File Offset: 0x009756F4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_PhysicCloth_v1(int EntryPoint)
		{
			BP_PhysicCloth_v1_C.__ExecuteUbergraph_BP_PhysicCloth_v1_FunctionParams* ptr = stackalloc BP_PhysicCloth_v1_C.__ExecuteUbergraph_BP_PhysicCloth_v1_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_PhysicCloth_v1_C.__ExecuteUbergraph_BP_PhysicCloth_v1_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PhysicCloth_v1_C.__ExecuteUbergraph_BP_PhysicCloth_v1_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PhysicCloth_v1_C.__ExecuteUbergraph_BP_PhysicCloth_v1_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060230F8 RID: 143608 RVA: 0x0097753B File Offset: 0x0097573B
		protected BP_PhysicCloth_v1_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04011D0D RID: 72973
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/GPUClothSimulation/BP_PhysicCloth_v1.BP_PhysicCloth_v1_C";

		// Token: 0x04011D0E RID: 72974
		private static IntPtr _ClassPtr;

		// Token: 0x04011D0F RID: 72975
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04011D10 RID: 72976
		internal static int __PropertyOffset_0;

		// Token: 0x04011D11 RID: 72977
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04011D12 RID: 72978
		internal static int __PropertyOffset_1;

		// Token: 0x04011D13 RID: 72979
		internal static int __PropertyOffset_2;

		// Token: 0x04011D14 RID: 72980
		internal static int __PropertyOffset_3;

		// Token: 0x04011D15 RID: 72981
		internal static int __PropertyOffset_4;

		// Token: 0x04011D16 RID: 72982
		internal static int __PropertyOffset_5;

		// Token: 0x04011D17 RID: 72983
		internal static int __PropertyOffset_6;

		// Token: 0x04011D18 RID: 72984
		internal static int __PropertyOffset_7;

		// Token: 0x04011D19 RID: 72985
		internal static int __PropertyOffset_8;

		// Token: 0x04011D1A RID: 72986
		internal static int __PropertyOffset_9;

		// Token: 0x04011D1B RID: 72987
		internal static int __PropertyOffset_10;

		// Token: 0x04011D1C RID: 72988
		internal static int __PropertyOffset_11;

		// Token: 0x04011D1D RID: 72989
		internal static int __PropertyOffset_12;

		// Token: 0x04011D1E RID: 72990
		internal static int __PropertyOffset_13;

		// Token: 0x04011D1F RID: 72991
		internal static int __PropertyOffset_14;

		// Token: 0x04011D20 RID: 72992
		private static IntPtr __Input_Niagara_NativeFunctionPtr;

		// Token: 0x04011D21 RID: 72993
		private static IntPtr __Input_Parameters_NativeFunctionPtr;

		// Token: 0x04011D22 RID: 72994
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04011D23 RID: 72995
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04011D24 RID: 72996
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04011D25 RID: 72997
		private static IntPtr __ExecuteUbergraph_BP_PhysicCloth_v1_NativeFunctionPtr;

		// Token: 0x02009C7B RID: 40059
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032569 RID: 206185
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009C7C RID: 40060
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __ExecuteUbergraph_BP_PhysicCloth_v1_FunctionParams
		{
			// Token: 0x0403256A RID: 206186
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
