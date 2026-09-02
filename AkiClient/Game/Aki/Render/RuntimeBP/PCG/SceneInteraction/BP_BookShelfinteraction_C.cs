using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Core.Fight;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.SceneInteraction
{
	// Token: 0x02003B8A RID: 15242
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/SceneInteraction/BP_BookShelfinteraction.BP_BookShelfinteraction_C")]
	[UnrealStructLayout(1136, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1129)]
	public class BP_BookShelfinteraction_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06021BCF RID: 138191 RVA: 0x00951B6F File Offset: 0x0094FD6F
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_BookShelfinteraction_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/SceneInteraction/BP_BookShelfinteraction.BP_BookShelfinteraction_C");
			}
			return BP_BookShelfinteraction_C._ClassPtr;
		}

		// Token: 0x06021BD0 RID: 138192 RVA: 0x00951B94 File Offset: 0x0094FD94
		public BP_BookShelfinteraction_C() : this(BuiltinUtils.AllocNativeUObject(BP_BookShelfinteraction_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06021BD1 RID: 138193 RVA: 0x00951BBC File Offset: 0x0094FDBC
		[NullableContext(1)]
		public BP_BookShelfinteraction_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_BookShelfinteraction_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003CC1 RID: 15553
		// (get) Token: 0x06021BD2 RID: 138194 RVA: 0x00951BF0 File Offset: 0x0094FDF0
		// (set) Token: 0x06021BD3 RID: 138195 RVA: 0x00951C29 File Offset: 0x0094FE29
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_BookShelfinteraction_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_BookShelfinteraction_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003CC2 RID: 15554
		// (get) Token: 0x06021BD4 RID: 138196 RVA: 0x00951C4A File Offset: 0x0094FE4A
		// (set) Token: 0x06021BD5 RID: 138197 RVA: 0x00951C5E File Offset: 0x0094FE5E
		public unsafe UBoxComponent Box
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BookShelfinteraction_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BookShelfinteraction_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003CC3 RID: 15555
		// (get) Token: 0x06021BD6 RID: 138198 RVA: 0x00951C73 File Offset: 0x0094FE73
		// (set) Token: 0x06021BD7 RID: 138199 RVA: 0x00951C87 File Offset: 0x0094FE87
		public unsafe UKuroRegionBoxComponent KuroRegionBox
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroRegionBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BookShelfinteraction_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BookShelfinteraction_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17003CC4 RID: 15556
		// (get) Token: 0x06021BD8 RID: 138200 RVA: 0x00951C9C File Offset: 0x0094FE9C
		// (set) Token: 0x06021BD9 RID: 138201 RVA: 0x00951CB0 File Offset: 0x0094FEB0
		public unsafe UStaticMeshComponent StaticMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BookShelfinteraction_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BookShelfinteraction_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17003CC5 RID: 15557
		// (get) Token: 0x06021BDA RID: 138202 RVA: 0x00951CC5 File Offset: 0x0094FEC5
		// (set) Token: 0x06021BDB RID: 138203 RVA: 0x00951CD9 File Offset: 0x0094FED9
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BookShelfinteraction_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BookShelfinteraction_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17003CC6 RID: 15558
		// (get) Token: 0x06021BDC RID: 138204 RVA: 0x00951CEE File Offset: 0x0094FEEE
		// (set) Token: 0x06021BDD RID: 138205 RVA: 0x00951D02 File Offset: 0x0094FF02
		public unsafe FVectorDouble AttackPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BookShelfinteraction_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BookShelfinteraction_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17003CC7 RID: 15559
		// (get) Token: 0x06021BDE RID: 138206 RVA: 0x00951D17 File Offset: 0x0094FF17
		// (set) Token: 0x06021BDF RID: 138207 RVA: 0x00951D27 File Offset: 0x0094FF27
		public unsafe bool Active
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BookShelfinteraction_C.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BookShelfinteraction_C.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003CC8 RID: 15560
		// (get) Token: 0x06021BE0 RID: 138208 RVA: 0x00951D38 File Offset: 0x0094FF38
		// (set) Token: 0x06021BE1 RID: 138209 RVA: 0x00951D48 File Offset: 0x0094FF48
		public unsafe float CustomTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BookShelfinteraction_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BookShelfinteraction_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17003CC9 RID: 15561
		// (get) Token: 0x06021BE2 RID: 138210 RVA: 0x00951D5C File Offset: 0x0094FF5C
		// (set) Token: 0x06021BE3 RID: 138211 RVA: 0x00951D95 File Offset: 0x0094FF95
		[Nullable(1)]
		public TArray<int> Frames
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<int> result;
				if ((result = this._Frames) == null)
				{
					result = (this._Frames = new TArray<int>(base.NativePtr + (IntPtr)BP_BookShelfinteraction_C.__PropertyOffset_8, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Frames.CopyAssign(value);
			}
		}

		// Token: 0x17003CCA RID: 15562
		// (get) Token: 0x06021BE4 RID: 138212 RVA: 0x00951DA3 File Offset: 0x0094FFA3
		// (set) Token: 0x06021BE5 RID: 138213 RVA: 0x00951DB3 File Offset: 0x0094FFB3
		public unsafe int ActiveTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BookShelfinteraction_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BookShelfinteraction_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17003CCB RID: 15563
		// (get) Token: 0x06021BE6 RID: 138214 RVA: 0x00951DC4 File Offset: 0x0094FFC4
		// (set) Token: 0x06021BE7 RID: 138215 RVA: 0x00951DD4 File Offset: 0x0094FFD4
		public unsafe float NewVar_0
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BookShelfinteraction_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BookShelfinteraction_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17003CCC RID: 15564
		// (get) Token: 0x06021BE8 RID: 138216 RVA: 0x00951DE5 File Offset: 0x0094FFE5
		// (set) Token: 0x06021BE9 RID: 138217 RVA: 0x00951DF5 File Offset: 0x0094FFF5
		public unsafe bool NewVar_1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BookShelfinteraction_C.__PropertyOffset_11) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BookShelfinteraction_C.__PropertyOffset_11) = (value ? 1 : 0);
			}
		}

		// Token: 0x06021BEA RID: 138218 RVA: 0x00951E08 File Offset: 0x00950008
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnWeaponInteraction(FVectorDouble OriginPoint, BP_SceneBattleInteract_C Config, int Id)
		{
			BP_BookShelfinteraction_C.__OnWeaponInteraction_FunctionParams* ptr = stackalloc BP_BookShelfinteraction_C.__OnWeaponInteraction_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(BP_BookShelfinteraction_C.__OnWeaponInteraction_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BookShelfinteraction_C.__OnWeaponInteraction_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OriginPoint = OriginPoint;
			ptr->Config = ((Config != null) ? Config.NativePtr : IntPtr.Zero);
			ptr->Id = Id;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BookShelfinteraction_C.__OnWeaponInteraction_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021BEB RID: 138219 RVA: 0x00951E6C File Offset: 0x0095006C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_BookShelfinteraction_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_BookShelfinteraction_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_BookShelfinteraction_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BookShelfinteraction_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BookShelfinteraction_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021BEC RID: 138220 RVA: 0x00951EB4 File Offset: 0x009500B4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_BookShelfinteraction_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_BookShelfinteraction_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_BookShelfinteraction_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BookShelfinteraction_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BookShelfinteraction_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021BED RID: 138221 RVA: 0x00951EFC File Offset: 0x009500FC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_BookShelfinteraction_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex, bool bFromSweep, in FHitResult SweepResult)
		{
			BP_BookShelfinteraction_C.__BndEvt__BP_BookShelfinteraction_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_BookShelfinteraction_C.__BndEvt__BP_BookShelfinteraction_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(BP_BookShelfinteraction_C.__BndEvt__BP_BookShelfinteraction_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BookShelfinteraction_C.__BndEvt__BP_BookShelfinteraction_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			ptr->bFromSweep = bFromSweep;
			if (SweepResult != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FHitResult.StaticStruct(), &ptr->SweepResult, SweepResult.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BookShelfinteraction_C.__BndEvt__BP_BookShelfinteraction_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021BEE RID: 138222 RVA: 0x00951FB8 File Offset: 0x009501B8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_BookShelfinteraction_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex)
		{
			BP_BookShelfinteraction_C.__BndEvt__BP_BookShelfinteraction_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_BookShelfinteraction_C.__BndEvt__BP_BookShelfinteraction_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_BookShelfinteraction_C.__BndEvt__BP_BookShelfinteraction_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BookShelfinteraction_C.__BndEvt__BP_BookShelfinteraction_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BookShelfinteraction_C.__BndEvt__BP_BookShelfinteraction_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021BEF RID: 138223 RVA: 0x00952044 File Offset: 0x00950244
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_BookShelfinteraction(int EntryPoint)
		{
			BP_BookShelfinteraction_C.__ExecuteUbergraph_BP_BookShelfinteraction_FunctionParams* ptr = stackalloc BP_BookShelfinteraction_C.__ExecuteUbergraph_BP_BookShelfinteraction_FunctionParams[(UIntPtr)607] + 15L / (long)sizeof(BP_BookShelfinteraction_C.__ExecuteUbergraph_BP_BookShelfinteraction_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BookShelfinteraction_C.__ExecuteUbergraph_BP_BookShelfinteraction_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BookShelfinteraction_C.__ExecuteUbergraph_BP_BookShelfinteraction_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021BF0 RID: 138224 RVA: 0x0095208E File Offset: 0x0095028E
		protected BP_BookShelfinteraction_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401103F RID: 69695
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/SceneInteraction/BP_BookShelfinteraction.BP_BookShelfinteraction_C";

		// Token: 0x04011040 RID: 69696
		private static IntPtr _ClassPtr;

		// Token: 0x04011041 RID: 69697
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04011042 RID: 69698
		internal static int __PropertyOffset_0;

		// Token: 0x04011043 RID: 69699
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04011044 RID: 69700
		internal static int __PropertyOffset_1;

		// Token: 0x04011045 RID: 69701
		internal static int __PropertyOffset_2;

		// Token: 0x04011046 RID: 69702
		internal static int __PropertyOffset_3;

		// Token: 0x04011047 RID: 69703
		internal static int __PropertyOffset_4;

		// Token: 0x04011048 RID: 69704
		internal static int __PropertyOffset_5;

		// Token: 0x04011049 RID: 69705
		internal static int __PropertyOffset_6;

		// Token: 0x0401104A RID: 69706
		internal static int __PropertyOffset_7;

		// Token: 0x0401104B RID: 69707
		internal static int __PropertyOffset_8;

		// Token: 0x0401104C RID: 69708
		private TArray<int> _Frames;

		// Token: 0x0401104D RID: 69709
		internal static int __PropertyOffset_9;

		// Token: 0x0401104E RID: 69710
		internal static int __PropertyOffset_10;

		// Token: 0x0401104F RID: 69711
		internal static int __PropertyOffset_11;

		// Token: 0x04011050 RID: 69712
		private static IntPtr __OnWeaponInteraction_NativeFunctionPtr;

		// Token: 0x04011051 RID: 69713
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04011052 RID: 69714
		private static IntPtr __BndEvt__BP_BookShelfinteraction_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04011053 RID: 69715
		private static IntPtr __BndEvt__BP_BookShelfinteraction_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04011054 RID: 69716
		private static IntPtr __ExecuteUbergraph_BP_BookShelfinteraction_NativeFunctionPtr;

		// Token: 0x02009B33 RID: 39731
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __OnWeaponInteraction_FunctionParams
		{
			// Token: 0x040322F3 RID: 205555
			[FieldOffset(0)]
			public FVectorDouble OriginPoint;

			// Token: 0x040322F4 RID: 205556
			[FieldOffset(24)]
			public IntPtr Config;

			// Token: 0x040322F5 RID: 205557
			[FieldOffset(32)]
			public int Id;
		}

		// Token: 0x02009B34 RID: 39732
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x040322F6 RID: 205558
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009B35 RID: 39733
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __BndEvt__BP_BookShelfinteraction_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x040322F7 RID: 205559
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x040322F8 RID: 205560
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x040322F9 RID: 205561
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x040322FA RID: 205562
			[FieldOffset(24)]
			public int OtherBodyIndex;

			// Token: 0x040322FB RID: 205563
			[FieldOffset(28)]
			public bool bFromSweep;

			// Token: 0x040322FC RID: 205564
			[FieldOffset(32)]
			public byte SweepResult;
		}

		// Token: 0x02009B36 RID: 39734
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __BndEvt__BP_BookShelfinteraction_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x040322FD RID: 205565
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x040322FE RID: 205566
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x040322FF RID: 205567
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x04032300 RID: 205568
			[FieldOffset(24)]
			public int OtherBodyIndex;
		}

		// Token: 0x02009B37 RID: 39735
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 592)]
		protected ref struct __ExecuteUbergraph_BP_BookShelfinteraction_FunctionParams
		{
			// Token: 0x04032301 RID: 205569
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
