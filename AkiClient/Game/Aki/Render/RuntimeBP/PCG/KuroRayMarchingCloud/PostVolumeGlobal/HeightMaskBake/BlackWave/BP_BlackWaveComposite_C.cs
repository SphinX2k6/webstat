using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Render.RuntimeBP.FluidNinjaLive;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.KuroRayMarchingCloud.PostVolumeGlobal.HeightMaskBake.BlackWave
{
	// Token: 0x02003BED RID: 15341
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/KuroRayMarchingCloud/PostVolumeGlobal/HeightMaskBake/BlackWave/BP_BlackWaveComposite.BP_BlackWaveComposite_C")]
	[UnrealStructLayout(1352, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1352)]
	public class BP_BlackWaveComposite_C : AKuroBPActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06022953 RID: 141651 RVA: 0x009693E4 File Offset: 0x009675E4
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_BlackWaveComposite_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/KuroRayMarchingCloud/PostVolumeGlobal/HeightMaskBake/BlackWave/BP_BlackWaveComposite.BP_BlackWaveComposite_C");
			}
			return BP_BlackWaveComposite_C._ClassPtr;
		}

		// Token: 0x06022954 RID: 141652 RVA: 0x00969408 File Offset: 0x00967608
		public BP_BlackWaveComposite_C() : this(BuiltinUtils.AllocNativeUObject(BP_BlackWaveComposite_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06022955 RID: 141653 RVA: 0x00969430 File Offset: 0x00967630
		[NullableContext(1)]
		public BP_BlackWaveComposite_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_BlackWaveComposite_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700419D RID: 16797
		// (get) Token: 0x06022956 RID: 141654 RVA: 0x00969464 File Offset: 0x00967664
		// (set) Token: 0x06022957 RID: 141655 RVA: 0x0096949D File Offset: 0x0096769D
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_BlackWaveComposite_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_BlackWaveComposite_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700419E RID: 16798
		// (get) Token: 0x06022958 RID: 141656 RVA: 0x009694BE File Offset: 0x009676BE
		// (set) Token: 0x06022959 RID: 141657 RVA: 0x009694D2 File Offset: 0x009676D2
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BlackWaveComposite_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BlackWaveComposite_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x1700419F RID: 16799
		// (get) Token: 0x0602295A RID: 141658 RVA: 0x009694E7 File Offset: 0x009676E7
		// (set) Token: 0x0602295B RID: 141659 RVA: 0x009694FB File Offset: 0x009676FB
		public unsafe UMaterialInstanceDynamic MDI
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BlackWaveComposite_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BlackWaveComposite_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170041A0 RID: 16800
		// (get) Token: 0x0602295C RID: 141660 RVA: 0x00969510 File Offset: 0x00967710
		// (set) Token: 0x0602295D RID: 141661 RVA: 0x00969524 File Offset: 0x00967724
		public unsafe NinjaLive_C fluidR
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<NinjaLive_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BlackWaveComposite_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BlackWaveComposite_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x170041A1 RID: 16801
		// (get) Token: 0x0602295E RID: 141662 RVA: 0x00969539 File Offset: 0x00967739
		// (set) Token: 0x0602295F RID: 141663 RVA: 0x0096954D File Offset: 0x0096774D
		public unsafe NinjaLive_C fluidG
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<NinjaLive_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BlackWaveComposite_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BlackWaveComposite_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x170041A2 RID: 16802
		// (get) Token: 0x06022960 RID: 141664 RVA: 0x00969562 File Offset: 0x00967762
		// (set) Token: 0x06022961 RID: 141665 RVA: 0x00969576 File Offset: 0x00967776
		public unsafe UTextureRenderTarget2D OutputRT
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BlackWaveComposite_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BlackWaveComposite_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x06022962 RID: 141666 RVA: 0x0096958B File Offset: 0x0096778B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BlackWaveComposite_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06022963 RID: 141667 RVA: 0x0096959F File Offset: 0x0096779F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BlackWaveComposite_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06022964 RID: 141668 RVA: 0x009695B4 File Offset: 0x009677B4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_BlackWaveComposite_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_BlackWaveComposite_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_BlackWaveComposite_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BlackWaveComposite_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BlackWaveComposite_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022965 RID: 141669 RVA: 0x009695FC File Offset: 0x009677FC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_BlackWaveComposite_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_BlackWaveComposite_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_BlackWaveComposite_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BlackWaveComposite_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BlackWaveComposite_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06022966 RID: 141670 RVA: 0x00969644 File Offset: 0x00967844
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_BlackWaveComposite(int EntryPoint)
		{
			BP_BlackWaveComposite_C.__ExecuteUbergraph_BP_BlackWaveComposite_FunctionParams* ptr = stackalloc BP_BlackWaveComposite_C.__ExecuteUbergraph_BP_BlackWaveComposite_FunctionParams[(UIntPtr)111] + 15L / (long)sizeof(BP_BlackWaveComposite_C.__ExecuteUbergraph_BP_BlackWaveComposite_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BlackWaveComposite_C.__ExecuteUbergraph_BP_BlackWaveComposite_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BlackWaveComposite_C.__ExecuteUbergraph_BP_BlackWaveComposite_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06022967 RID: 141671 RVA: 0x0096968B File Offset: 0x0096788B
		protected BP_BlackWaveComposite_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401184E RID: 71758
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/KuroRayMarchingCloud/PostVolumeGlobal/HeightMaskBake/BlackWave/BP_BlackWaveComposite.BP_BlackWaveComposite_C";

		// Token: 0x0401184F RID: 71759
		private static IntPtr _ClassPtr;

		// Token: 0x04011850 RID: 71760
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04011851 RID: 71761
		internal static int __PropertyOffset_0;

		// Token: 0x04011852 RID: 71762
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04011853 RID: 71763
		internal static int __PropertyOffset_1;

		// Token: 0x04011854 RID: 71764
		internal static int __PropertyOffset_2;

		// Token: 0x04011855 RID: 71765
		internal static int __PropertyOffset_3;

		// Token: 0x04011856 RID: 71766
		internal static int __PropertyOffset_4;

		// Token: 0x04011857 RID: 71767
		internal static int __PropertyOffset_5;

		// Token: 0x04011858 RID: 71768
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04011859 RID: 71769
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0401185A RID: 71770
		private static IntPtr __ExecuteUbergraph_BP_BlackWaveComposite_NativeFunctionPtr;

		// Token: 0x02009BF9 RID: 39929
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032453 RID: 205907
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009BFA RID: 39930
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 96)]
		protected ref struct __ExecuteUbergraph_BP_BlackWaveComposite_FunctionParams
		{
			// Token: 0x04032454 RID: 205908
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
