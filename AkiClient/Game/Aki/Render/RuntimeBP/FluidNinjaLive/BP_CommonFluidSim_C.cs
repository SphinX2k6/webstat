using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.FluidNinjaLive
{
	// Token: 0x02003CEE RID: 15598
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/FluidNinjaLive/BP_CommonFluidSim.BP_CommonFluidSim_C")]
	[UnrealStructLayout(1392, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1390)]
	public class BP_CommonFluidSim_C : AKuroBPActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06025436 RID: 152630 RVA: 0x009B59D3 File Offset: 0x009B3BD3
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_CommonFluidSim_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/FluidNinjaLive/BP_CommonFluidSim.BP_CommonFluidSim_C");
			}
			return BP_CommonFluidSim_C._ClassPtr;
		}

		// Token: 0x06025437 RID: 152631 RVA: 0x009B59F8 File Offset: 0x009B3BF8
		public BP_CommonFluidSim_C() : this(BuiltinUtils.AllocNativeUObject(BP_CommonFluidSim_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06025438 RID: 152632 RVA: 0x009B5A20 File Offset: 0x009B3C20
		[NullableContext(1)]
		public BP_CommonFluidSim_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_CommonFluidSim_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700507F RID: 20607
		// (get) Token: 0x06025439 RID: 152633 RVA: 0x009B5A54 File Offset: 0x009B3C54
		// (set) Token: 0x0602543A RID: 152634 RVA: 0x009B5A8D File Offset: 0x009B3C8D
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_CommonFluidSim_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_CommonFluidSim_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005080 RID: 20608
		// (get) Token: 0x0602543B RID: 152635 RVA: 0x009B5AAE File Offset: 0x009B3CAE
		// (set) Token: 0x0602543C RID: 152636 RVA: 0x009B5AC2 File Offset: 0x009B3CC2
		public unsafe UStaticMeshComponent TraceMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CommonFluidSim_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CommonFluidSim_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17005081 RID: 20609
		// (get) Token: 0x0602543D RID: 152637 RVA: 0x009B5AD7 File Offset: 0x009B3CD7
		// (set) Token: 0x0602543E RID: 152638 RVA: 0x009B5AEB File Offset: 0x009B3CEB
		public unsafe USceneComponent Root
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CommonFluidSim_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CommonFluidSim_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17005082 RID: 20610
		// (get) Token: 0x0602543F RID: 152639 RVA: 0x009B5B00 File Offset: 0x009B3D00
		// (set) Token: 0x06025440 RID: 152640 RVA: 0x009B5B14 File Offset: 0x009B3D14
		public unsafe NinjaLiveComponent_C NinjaLiveComponent
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<NinjaLiveComponent_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CommonFluidSim_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CommonFluidSim_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17005083 RID: 20611
		// (get) Token: 0x06025441 RID: 152641 RVA: 0x009B5B29 File Offset: 0x009B3D29
		// (set) Token: 0x06025442 RID: 152642 RVA: 0x009B5B3D File Offset: 0x009B3D3D
		public unsafe FVectorDouble lastPos
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CommonFluidSim_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CommonFluidSim_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17005084 RID: 20612
		// (get) Token: 0x06025443 RID: 152643 RVA: 0x009B5B52 File Offset: 0x009B3D52
		// (set) Token: 0x06025444 RID: 152644 RVA: 0x009B5B62 File Offset: 0x009B3D62
		public unsafe float CachedStrength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CommonFluidSim_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CommonFluidSim_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17005085 RID: 20613
		// (get) Token: 0x06025445 RID: 152645 RVA: 0x009B5B73 File Offset: 0x009B3D73
		// (set) Token: 0x06025446 RID: 152646 RVA: 0x009B5B83 File Offset: 0x009B3D83
		public unsafe double MinVelocity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CommonFluidSim_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CommonFluidSim_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17005086 RID: 20614
		// (get) Token: 0x06025447 RID: 152647 RVA: 0x009B5B94 File Offset: 0x009B3D94
		// (set) Token: 0x06025448 RID: 152648 RVA: 0x009B5BA4 File Offset: 0x009B3DA4
		public unsafe bool bEnable
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CommonFluidSim_C.__PropertyOffset_7) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CommonFluidSim_C.__PropertyOffset_7) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005087 RID: 20615
		// (get) Token: 0x06025449 RID: 152649 RVA: 0x009B5BB5 File Offset: 0x009B3DB5
		// (set) Token: 0x0602544A RID: 152650 RVA: 0x009B5BC5 File Offset: 0x009B3DC5
		public unsafe float FadeTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CommonFluidSim_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CommonFluidSim_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17005088 RID: 20616
		// (get) Token: 0x0602544B RID: 152651 RVA: 0x009B5BD6 File Offset: 0x009B3DD6
		// (set) Token: 0x0602544C RID: 152652 RVA: 0x009B5BE6 File Offset: 0x009B3DE6
		public unsafe float FadeSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CommonFluidSim_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CommonFluidSim_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17005089 RID: 20617
		// (get) Token: 0x0602544D RID: 152653 RVA: 0x009B5BF7 File Offset: 0x009B3DF7
		// (set) Token: 0x0602544E RID: 152654 RVA: 0x009B5C07 File Offset: 0x009B3E07
		public unsafe bool bStoped
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CommonFluidSim_C.__PropertyOffset_10) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CommonFluidSim_C.__PropertyOffset_10) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700508A RID: 20618
		// (get) Token: 0x0602544F RID: 152655 RVA: 0x009B5C18 File Offset: 0x009B3E18
		// (set) Token: 0x06025450 RID: 152656 RVA: 0x009B5C28 File Offset: 0x009B3E28
		public unsafe bool bStarted
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CommonFluidSim_C.__PropertyOffset_11) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CommonFluidSim_C.__PropertyOffset_11) = (value ? 1 : 0);
			}
		}

		// Token: 0x06025451 RID: 152657 RVA: 0x009B5C39 File Offset: 0x009B3E39
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CheckSimEnable()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CommonFluidSim_C.__CheckSimEnable_NativeFunctionPtr, null);
		}

		// Token: 0x06025452 RID: 152658 RVA: 0x009B5C4D File Offset: 0x009B3E4D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CommonFluidSim_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06025453 RID: 152659 RVA: 0x009B5C61 File Offset: 0x009B3E61
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CommonFluidSim_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06025454 RID: 152660 RVA: 0x009B5C78 File Offset: 0x009B3E78
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_CommonFluidSim_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_CommonFluidSim_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_CommonFluidSim_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CommonFluidSim_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CommonFluidSim_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025455 RID: 152661 RVA: 0x009B5CC0 File Offset: 0x009B3EC0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_CommonFluidSim_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_CommonFluidSim_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_CommonFluidSim_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CommonFluidSim_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CommonFluidSim_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06025456 RID: 152662 RVA: 0x009B5D08 File Offset: 0x009B3F08
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_CommonFluidSim(int EntryPoint)
		{
			BP_CommonFluidSim_C.__ExecuteUbergraph_BP_CommonFluidSim_FunctionParams* ptr = stackalloc BP_CommonFluidSim_C.__ExecuteUbergraph_BP_CommonFluidSim_FunctionParams[(UIntPtr)431] + 15L / (long)sizeof(BP_CommonFluidSim_C.__ExecuteUbergraph_BP_CommonFluidSim_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CommonFluidSim_C.__ExecuteUbergraph_BP_CommonFluidSim_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CommonFluidSim_C.__ExecuteUbergraph_BP_CommonFluidSim_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06025457 RID: 152663 RVA: 0x009B5D52 File Offset: 0x009B3F52
		protected BP_CommonFluidSim_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04013323 RID: 78627
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/FluidNinjaLive/BP_CommonFluidSim.BP_CommonFluidSim_C";

		// Token: 0x04013324 RID: 78628
		private static IntPtr _ClassPtr;

		// Token: 0x04013325 RID: 78629
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04013326 RID: 78630
		internal static int __PropertyOffset_0;

		// Token: 0x04013327 RID: 78631
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04013328 RID: 78632
		internal static int __PropertyOffset_1;

		// Token: 0x04013329 RID: 78633
		internal static int __PropertyOffset_2;

		// Token: 0x0401332A RID: 78634
		internal static int __PropertyOffset_3;

		// Token: 0x0401332B RID: 78635
		internal static int __PropertyOffset_4;

		// Token: 0x0401332C RID: 78636
		internal static int __PropertyOffset_5;

		// Token: 0x0401332D RID: 78637
		internal static int __PropertyOffset_6;

		// Token: 0x0401332E RID: 78638
		internal static int __PropertyOffset_7;

		// Token: 0x0401332F RID: 78639
		internal static int __PropertyOffset_8;

		// Token: 0x04013330 RID: 78640
		internal static int __PropertyOffset_9;

		// Token: 0x04013331 RID: 78641
		internal static int __PropertyOffset_10;

		// Token: 0x04013332 RID: 78642
		internal static int __PropertyOffset_11;

		// Token: 0x04013333 RID: 78643
		private static IntPtr __CheckSimEnable_NativeFunctionPtr;

		// Token: 0x04013334 RID: 78644
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04013335 RID: 78645
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04013336 RID: 78646
		private static IntPtr __ExecuteUbergraph_BP_CommonFluidSim_NativeFunctionPtr;

		// Token: 0x02009EF0 RID: 40688
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x040329E5 RID: 207333
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009EF1 RID: 40689
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 416)]
		protected ref struct __ExecuteUbergraph_BP_CommonFluidSim_FunctionParams
		{
			// Token: 0x040329E6 RID: 207334
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
