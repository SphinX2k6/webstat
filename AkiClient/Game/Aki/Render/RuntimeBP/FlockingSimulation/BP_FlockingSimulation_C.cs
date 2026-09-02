using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.FlockingSimulation
{
	// Token: 0x02003D19 RID: 15641
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/FlockingSimulation/BP_FlockingSimulation.BP_FlockingSimulation_C")]
	[UnrealStructLayout(2632, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2625)]
	public class BP_FlockingSimulation_C : AKuroFlockingSimulation, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06025C3C RID: 154684 RVA: 0x009C4723 File Offset: 0x009C2923
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_FlockingSimulation_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/FlockingSimulation/BP_FlockingSimulation.BP_FlockingSimulation_C");
			}
			return BP_FlockingSimulation_C._ClassPtr;
		}

		// Token: 0x06025C3D RID: 154685 RVA: 0x009C4748 File Offset: 0x009C2948
		public BP_FlockingSimulation_C() : this(BuiltinUtils.AllocNativeUObject(BP_FlockingSimulation_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06025C3E RID: 154686 RVA: 0x009C4770 File Offset: 0x009C2970
		public BP_FlockingSimulation_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_FlockingSimulation_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17005397 RID: 21399
		// (get) Token: 0x06025C3F RID: 154687 RVA: 0x009C47A4 File Offset: 0x009C29A4
		// (set) Token: 0x06025C40 RID: 154688 RVA: 0x009C47DD File Offset: 0x009C29DD
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_FlockingSimulation_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_FlockingSimulation_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005398 RID: 21400
		// (get) Token: 0x06025C41 RID: 154689 RVA: 0x009C47FE File Offset: 0x009C29FE
		// (set) Token: 0x06025C42 RID: 154690 RVA: 0x009C4812 File Offset: 0x009C2A12
		[Nullable(2)]
		public unsafe UInstancedStaticMeshComponent InstancedStaticMesh
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UInstancedStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FlockingSimulation_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FlockingSimulation_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17005399 RID: 21401
		// (get) Token: 0x06025C43 RID: 154691 RVA: 0x009C4827 File Offset: 0x009C2A27
		// (set) Token: 0x06025C44 RID: 154692 RVA: 0x009C483B File Offset: 0x009C2A3B
		[Nullable(2)]
		public unsafe UBoxComponent Box
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FlockingSimulation_C.__PropertyOffset_2);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FlockingSimulation_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x1700539A RID: 21402
		// (get) Token: 0x06025C45 RID: 154693 RVA: 0x009C4850 File Offset: 0x009C2A50
		// (set) Token: 0x06025C46 RID: 154694 RVA: 0x009C4889 File Offset: 0x009C2A89
		public FKuroFlockingSettings FlockingSettings
		{
			get
			{
				base.FastCheckIsValid();
				FKuroFlockingSettings result;
				if ((result = this._FlockingSettings) == null)
				{
					result = (this._FlockingSettings = new FKuroFlockingSettings(base.NativePtr + (IntPtr)BP_FlockingSimulation_C.__PropertyOffset_3, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroFlockingSettings.StaticStruct(), base.NativePtr + (IntPtr)BP_FlockingSimulation_C.__PropertyOffset_3, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700539B RID: 21403
		// (get) Token: 0x06025C47 RID: 154695 RVA: 0x009C48AC File Offset: 0x009C2AAC
		// (set) Token: 0x06025C48 RID: 154696 RVA: 0x009C48E5 File Offset: 0x009C2AE5
		public TArray<FKuroFlockingData> FlockingDataArray
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FKuroFlockingData> result;
				if ((result = this._FlockingDataArray) == null)
				{
					result = (this._FlockingDataArray = new TArray<FKuroFlockingData>(base.NativePtr + (IntPtr)BP_FlockingSimulation_C.__PropertyOffset_4, this));
				}
				return result;
			}
			set
			{
				this.FlockingDataArray.CopyAssign(value);
			}
		}

		// Token: 0x1700539C RID: 21404
		// (get) Token: 0x06025C49 RID: 154697 RVA: 0x009C48F3 File Offset: 0x009C2AF3
		// (set) Token: 0x06025C4A RID: 154698 RVA: 0x009C4903 File Offset: 0x009C2B03
		public unsafe int FishCountPC
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FlockingSimulation_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FlockingSimulation_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x1700539D RID: 21405
		// (get) Token: 0x06025C4B RID: 154699 RVA: 0x009C4914 File Offset: 0x009C2B14
		// (set) Token: 0x06025C4C RID: 154700 RVA: 0x009C4924 File Offset: 0x009C2B24
		public unsafe int FrameID
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FlockingSimulation_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FlockingSimulation_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x1700539E RID: 21406
		// (get) Token: 0x06025C4D RID: 154701 RVA: 0x009C4935 File Offset: 0x009C2B35
		// (set) Token: 0x06025C4E RID: 154702 RVA: 0x009C4945 File Offset: 0x009C2B45
		public unsafe float SpawnRadius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FlockingSimulation_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FlockingSimulation_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x1700539F RID: 21407
		// (get) Token: 0x06025C4F RID: 154703 RVA: 0x009C4956 File Offset: 0x009C2B56
		// (set) Token: 0x06025C50 RID: 154704 RVA: 0x009C4966 File Offset: 0x009C2B66
		public unsafe float Speed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FlockingSimulation_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FlockingSimulation_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x170053A0 RID: 21408
		// (get) Token: 0x06025C51 RID: 154705 RVA: 0x009C4977 File Offset: 0x009C2B77
		// (set) Token: 0x06025C52 RID: 154706 RVA: 0x009C4987 File Offset: 0x009C2B87
		public unsafe int MaxFishCount
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FlockingSimulation_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FlockingSimulation_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x170053A1 RID: 21409
		// (get) Token: 0x06025C53 RID: 154707 RVA: 0x009C4998 File Offset: 0x009C2B98
		// (set) Token: 0x06025C54 RID: 154708 RVA: 0x009C49A8 File Offset: 0x009C2BA8
		public unsafe bool IsPC_Platform
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FlockingSimulation_C.__PropertyOffset_10) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FlockingSimulation_C.__PropertyOffset_10) = (value ? 1 : 0);
			}
		}

		// Token: 0x170053A2 RID: 21410
		// (get) Token: 0x06025C55 RID: 154709 RVA: 0x009C49B9 File Offset: 0x009C2BB9
		// (set) Token: 0x06025C56 RID: 154710 RVA: 0x009C49C9 File Offset: 0x009C2BC9
		public unsafe float FishDensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FlockingSimulation_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FlockingSimulation_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x170053A3 RID: 21411
		// (get) Token: 0x06025C57 RID: 154711 RVA: 0x009C49DA File Offset: 0x009C2BDA
		// (set) Token: 0x06025C58 RID: 154712 RVA: 0x009C49EA File Offset: 0x009C2BEA
		public unsafe int FishCount
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FlockingSimulation_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FlockingSimulation_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x170053A4 RID: 21412
		// (get) Token: 0x06025C59 RID: 154713 RVA: 0x009C49FB File Offset: 0x009C2BFB
		// (set) Token: 0x06025C5A RID: 154714 RVA: 0x009C4A0B File Offset: 0x009C2C0B
		public unsafe float MobileFishDensityRate
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FlockingSimulation_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FlockingSimulation_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x170053A5 RID: 21413
		// (get) Token: 0x06025C5B RID: 154715 RVA: 0x009C4A1C File Offset: 0x009C2C1C
		// (set) Token: 0x06025C5C RID: 154716 RVA: 0x009C4A30 File Offset: 0x009C2C30
		public unsafe FVector BoxSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FlockingSimulation_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FlockingSimulation_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x170053A6 RID: 21414
		// (get) Token: 0x06025C5D RID: 154717 RVA: 0x009C4A45 File Offset: 0x009C2C45
		// (set) Token: 0x06025C5E RID: 154718 RVA: 0x009C4A55 File Offset: 0x009C2C55
		public unsafe bool UseAvoidance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FlockingSimulation_C.__PropertyOffset_15) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FlockingSimulation_C.__PropertyOffset_15) = (value ? 1 : 0);
			}
		}

		// Token: 0x06025C5F RID: 154719 RVA: 0x009C4A68 File Offset: 0x009C2C68
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnWorldOffset(FVector Offset)
		{
			BP_FlockingSimulation_C.__OnWorldOffset_FunctionParams* ptr = stackalloc BP_FlockingSimulation_C.__OnWorldOffset_FunctionParams[(UIntPtr)91] + 15L / (long)sizeof(BP_FlockingSimulation_C.__OnWorldOffset_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FlockingSimulation_C.__OnWorldOffset_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Offset = Offset;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FlockingSimulation_C.__OnWorldOffset_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025C60 RID: 154720 RVA: 0x009C4AAE File Offset: 0x009C2CAE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Init()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FlockingSimulation_C.__Init_NativeFunctionPtr, null);
		}

		// Token: 0x06025C61 RID: 154721 RVA: 0x009C4AC4 File Offset: 0x009C2CC4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SimGPU(float dt)
		{
			BP_FlockingSimulation_C.__SimGPU_FunctionParams* ptr = stackalloc BP_FlockingSimulation_C.__SimGPU_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(BP_FlockingSimulation_C.__SimGPU_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FlockingSimulation_C.__SimGPU_NativeFunctionPtr, (void*)ptr, 1);
			ptr->dt = dt;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FlockingSimulation_C.__SimGPU_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025C62 RID: 154722 RVA: 0x009C4B0C File Offset: 0x009C2D0C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SimCPU(float dt)
		{
			BP_FlockingSimulation_C.__SimCPU_FunctionParams* ptr = stackalloc BP_FlockingSimulation_C.__SimCPU_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(BP_FlockingSimulation_C.__SimCPU_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FlockingSimulation_C.__SimCPU_NativeFunctionPtr, (void*)ptr, 1);
			ptr->dt = dt;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FlockingSimulation_C.__SimCPU_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025C63 RID: 154723 RVA: 0x009C4B52 File Offset: 0x009C2D52
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FlockingSimulation_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06025C64 RID: 154724 RVA: 0x009C4B66 File Offset: 0x009C2D66
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_FlockingSimulation_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06025C65 RID: 154725 RVA: 0x009C4B7C File Offset: 0x009C2D7C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_FlockingSimulation_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_FlockingSimulation_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_FlockingSimulation_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FlockingSimulation_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FlockingSimulation_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025C66 RID: 154726 RVA: 0x009C4BC4 File Offset: 0x009C2DC4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_FlockingSimulation_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_FlockingSimulation_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_FlockingSimulation_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FlockingSimulation_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_FlockingSimulation_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06025C67 RID: 154727 RVA: 0x009C4C0C File Offset: 0x009C2E0C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void OnApplyWorldOffset(in FVector InWorldOffset, bool bWorldShift)
		{
			BP_FlockingSimulation_C.__OnApplyWorldOffset_FunctionParams* ptr = stackalloc BP_FlockingSimulation_C.__OnApplyWorldOffset_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(BP_FlockingSimulation_C.__OnApplyWorldOffset_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FlockingSimulation_C.__OnApplyWorldOffset_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InWorldOffset = InWorldOffset;
			ptr->bWorldShift = bWorldShift;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FlockingSimulation_C.__OnApplyWorldOffset_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025C68 RID: 154728 RVA: 0x009C4C60 File Offset: 0x009C2E60
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void OnApplyWorldOffset_Implementation(in FVector InWorldOffset, bool bWorldShift)
		{
			BP_FlockingSimulation_C.__OnApplyWorldOffset_FunctionParams* ptr = stackalloc BP_FlockingSimulation_C.__OnApplyWorldOffset_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(BP_FlockingSimulation_C.__OnApplyWorldOffset_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FlockingSimulation_C.__OnApplyWorldOffset_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InWorldOffset = InWorldOffset;
			ptr->bWorldShift = bWorldShift;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_FlockingSimulation_C.__OnApplyWorldOffset_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06025C69 RID: 154729 RVA: 0x009C4CB4 File Offset: 0x009C2EB4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_FlockingSimulation(int EntryPoint)
		{
			BP_FlockingSimulation_C.__ExecuteUbergraph_BP_FlockingSimulation_FunctionParams* ptr = stackalloc BP_FlockingSimulation_C.__ExecuteUbergraph_BP_FlockingSimulation_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_FlockingSimulation_C.__ExecuteUbergraph_BP_FlockingSimulation_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FlockingSimulation_C.__ExecuteUbergraph_BP_FlockingSimulation_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_FlockingSimulation_C.__ExecuteUbergraph_BP_FlockingSimulation_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06025C6A RID: 154730 RVA: 0x009C4CFB File Offset: 0x009C2EFB
		protected BP_FlockingSimulation_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401382D RID: 79917
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/FlockingSimulation/BP_FlockingSimulation.BP_FlockingSimulation_C";

		// Token: 0x0401382E RID: 79918
		private static IntPtr _ClassPtr;

		// Token: 0x0401382F RID: 79919
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04013830 RID: 79920
		internal static int __PropertyOffset_0;

		// Token: 0x04013831 RID: 79921
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04013832 RID: 79922
		internal static int __PropertyOffset_1;

		// Token: 0x04013833 RID: 79923
		internal static int __PropertyOffset_2;

		// Token: 0x04013834 RID: 79924
		internal static int __PropertyOffset_3;

		// Token: 0x04013835 RID: 79925
		[Nullable(2)]
		private FKuroFlockingSettings _FlockingSettings;

		// Token: 0x04013836 RID: 79926
		internal static int __PropertyOffset_4;

		// Token: 0x04013837 RID: 79927
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<FKuroFlockingData> _FlockingDataArray;

		// Token: 0x04013838 RID: 79928
		internal static int __PropertyOffset_5;

		// Token: 0x04013839 RID: 79929
		internal static int __PropertyOffset_6;

		// Token: 0x0401383A RID: 79930
		internal static int __PropertyOffset_7;

		// Token: 0x0401383B RID: 79931
		internal static int __PropertyOffset_8;

		// Token: 0x0401383C RID: 79932
		internal static int __PropertyOffset_9;

		// Token: 0x0401383D RID: 79933
		internal static int __PropertyOffset_10;

		// Token: 0x0401383E RID: 79934
		internal static int __PropertyOffset_11;

		// Token: 0x0401383F RID: 79935
		internal static int __PropertyOffset_12;

		// Token: 0x04013840 RID: 79936
		internal static int __PropertyOffset_13;

		// Token: 0x04013841 RID: 79937
		internal static int __PropertyOffset_14;

		// Token: 0x04013842 RID: 79938
		internal static int __PropertyOffset_15;

		// Token: 0x04013843 RID: 79939
		private static IntPtr __OnWorldOffset_NativeFunctionPtr;

		// Token: 0x04013844 RID: 79940
		private static IntPtr __Init_NativeFunctionPtr;

		// Token: 0x04013845 RID: 79941
		private static IntPtr __SimGPU_NativeFunctionPtr;

		// Token: 0x04013846 RID: 79942
		private static IntPtr __SimCPU_NativeFunctionPtr;

		// Token: 0x04013847 RID: 79943
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04013848 RID: 79944
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04013849 RID: 79945
		private static IntPtr __OnApplyWorldOffset_NativeFunctionPtr;

		// Token: 0x0401384A RID: 79946
		private static IntPtr __ExecuteUbergraph_BP_FlockingSimulation_NativeFunctionPtr;

		// Token: 0x02009FA8 RID: 40872
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 76)]
		protected ref struct __OnWorldOffset_FunctionParams
		{
			// Token: 0x04032B58 RID: 207704
			[FieldOffset(0)]
			public FVector Offset;
		}

		// Token: 0x02009FA9 RID: 40873
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __SimGPU_FunctionParams
		{
			// Token: 0x04032B59 RID: 207705
			[FieldOffset(0)]
			public float dt;
		}

		// Token: 0x02009FAA RID: 40874
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __SimCPU_FunctionParams
		{
			// Token: 0x04032B5A RID: 207706
			[FieldOffset(0)]
			public float dt;
		}

		// Token: 0x02009FAB RID: 40875
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032B5B RID: 207707
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009FAC RID: 40876
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected new ref struct __OnApplyWorldOffset_FunctionParams
		{
			// Token: 0x04032B5C RID: 207708
			[FieldOffset(0)]
			public FVector InWorldOffset;

			// Token: 0x04032B5D RID: 207709
			[FieldOffset(12)]
			public bool bWorldShift;
		}

		// Token: 0x02009FAD RID: 40877
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __ExecuteUbergraph_BP_FlockingSimulation_FunctionParams
		{
			// Token: 0x04032B5E RID: 207710
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
