using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.SceneInteraction
{
	// Token: 0x02003B8B RID: 15243
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/SceneInteraction/BP_HoverCarInteraction.BP_HoverCarInteraction_C")]
	[UnrealStructLayout(1144, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1144)]
	public class BP_HoverCarInteraction_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06021BF1 RID: 138225 RVA: 0x00952097 File Offset: 0x00950297
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_HoverCarInteraction_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/SceneInteraction/BP_HoverCarInteraction.BP_HoverCarInteraction_C");
			}
			return BP_HoverCarInteraction_C._ClassPtr;
		}

		// Token: 0x06021BF2 RID: 138226 RVA: 0x009520BC File Offset: 0x009502BC
		public BP_HoverCarInteraction_C() : this(BuiltinUtils.AllocNativeUObject(BP_HoverCarInteraction_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06021BF3 RID: 138227 RVA: 0x009520E4 File Offset: 0x009502E4
		[NullableContext(1)]
		public BP_HoverCarInteraction_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_HoverCarInteraction_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003CCD RID: 15565
		// (get) Token: 0x06021BF4 RID: 138228 RVA: 0x00952118 File Offset: 0x00950318
		// (set) Token: 0x06021BF5 RID: 138229 RVA: 0x00952151 File Offset: 0x00950351
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_HoverCarInteraction_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_HoverCarInteraction_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003CCE RID: 15566
		// (get) Token: 0x06021BF6 RID: 138230 RVA: 0x00952172 File Offset: 0x00950372
		// (set) Token: 0x06021BF7 RID: 138231 RVA: 0x00952186 File Offset: 0x00950386
		public unsafe UStaticMeshComponent SM_Gel_Car_01AL
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_HoverCarInteraction_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_HoverCarInteraction_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003CCF RID: 15567
		// (get) Token: 0x06021BF8 RID: 138232 RVA: 0x0095219B File Offset: 0x0095039B
		// (set) Token: 0x06021BF9 RID: 138233 RVA: 0x009521AF File Offset: 0x009503AF
		public unsafe USkeletalMeshComponent SK_Gel_Car_01AL
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_HoverCarInteraction_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_HoverCarInteraction_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17003CD0 RID: 15568
		// (get) Token: 0x06021BFA RID: 138234 RVA: 0x009521C4 File Offset: 0x009503C4
		// (set) Token: 0x06021BFB RID: 138235 RVA: 0x009521D8 File Offset: 0x009503D8
		public unsafe UBoxComponent Box
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_HoverCarInteraction_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_HoverCarInteraction_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17003CD1 RID: 15569
		// (get) Token: 0x06021BFC RID: 138236 RVA: 0x009521ED File Offset: 0x009503ED
		// (set) Token: 0x06021BFD RID: 138237 RVA: 0x00952201 File Offset: 0x00950401
		public unsafe USceneComponent Scene
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_HoverCarInteraction_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_HoverCarInteraction_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17003CD2 RID: 15570
		// (get) Token: 0x06021BFE RID: 138238 RVA: 0x00952216 File Offset: 0x00950416
		// (set) Token: 0x06021BFF RID: 138239 RVA: 0x0095222A File Offset: 0x0095042A
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_HoverCarInteraction_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_HoverCarInteraction_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17003CD3 RID: 15571
		// (get) Token: 0x06021C00 RID: 138240 RVA: 0x0095223F File Offset: 0x0095043F
		// (set) Token: 0x06021C01 RID: 138241 RVA: 0x00952253 File Offset: 0x00950453
		public unsafe FVectorDouble LastFrameVelocity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_HoverCarInteraction_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_HoverCarInteraction_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17003CD4 RID: 15572
		// (get) Token: 0x06021C02 RID: 138242 RVA: 0x00952268 File Offset: 0x00950468
		// (set) Token: 0x06021C03 RID: 138243 RVA: 0x00952278 File Offset: 0x00950478
		public unsafe float NewVar_0
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_HoverCarInteraction_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_HoverCarInteraction_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17003CD5 RID: 15573
		// (get) Token: 0x06021C04 RID: 138244 RVA: 0x00952289 File Offset: 0x00950489
		// (set) Token: 0x06021C05 RID: 138245 RVA: 0x00952299 File Offset: 0x00950499
		public unsafe float Time
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_HoverCarInteraction_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_HoverCarInteraction_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17003CD6 RID: 15574
		// (get) Token: 0x06021C06 RID: 138246 RVA: 0x009522AA File Offset: 0x009504AA
		// (set) Token: 0x06021C07 RID: 138247 RVA: 0x009522BA File Offset: 0x009504BA
		public unsafe float NewVar_1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_HoverCarInteraction_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_HoverCarInteraction_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17003CD7 RID: 15575
		// (get) Token: 0x06021C08 RID: 138248 RVA: 0x009522CB File Offset: 0x009504CB
		// (set) Token: 0x06021C09 RID: 138249 RVA: 0x009522DB File Offset: 0x009504DB
		public unsafe bool Start
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_HoverCarInteraction_C.__PropertyOffset_10) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_HoverCarInteraction_C.__PropertyOffset_10) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003CD8 RID: 15576
		// (get) Token: 0x06021C0A RID: 138250 RVA: 0x009522EC File Offset: 0x009504EC
		// (set) Token: 0x06021C0B RID: 138251 RVA: 0x009522FC File Offset: 0x009504FC
		public unsafe float Delta_Seconds
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_HoverCarInteraction_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_HoverCarInteraction_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17003CD9 RID: 15577
		// (get) Token: 0x06021C0C RID: 138252 RVA: 0x0095230D File Offset: 0x0095050D
		// (set) Token: 0x06021C0D RID: 138253 RVA: 0x0095231D File Offset: 0x0095051D
		public unsafe float Offset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_HoverCarInteraction_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_HoverCarInteraction_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17003CDA RID: 15578
		// (get) Token: 0x06021C0E RID: 138254 RVA: 0x0095232E File Offset: 0x0095052E
		// (set) Token: 0x06021C0F RID: 138255 RVA: 0x0095233E File Offset: 0x0095053E
		public unsafe float 晃动幅度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_HoverCarInteraction_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_HoverCarInteraction_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17003CDB RID: 15579
		// (get) Token: 0x06021C10 RID: 138256 RVA: 0x0095234F File Offset: 0x0095054F
		// (set) Token: 0x06021C11 RID: 138257 RVA: 0x0095235F File Offset: 0x0095055F
		public unsafe float 晃动时长
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_HoverCarInteraction_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_HoverCarInteraction_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17003CDC RID: 15580
		// (get) Token: 0x06021C12 RID: 138258 RVA: 0x00952370 File Offset: 0x00950570
		// (set) Token: 0x06021C13 RID: 138259 RVA: 0x00952380 File Offset: 0x00950580
		public unsafe float 晃动速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_HoverCarInteraction_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_HoverCarInteraction_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17003CDD RID: 15581
		// (get) Token: 0x06021C14 RID: 138260 RVA: 0x00952391 File Offset: 0x00950591
		// (set) Token: 0x06021C15 RID: 138261 RVA: 0x009523A1 File Offset: 0x009505A1
		public unsafe float Attack
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_HoverCarInteraction_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_HoverCarInteraction_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x06021C16 RID: 138262 RVA: 0x009523B2 File Offset: 0x009505B2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_HoverCarInteraction_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06021C17 RID: 138263 RVA: 0x009523C6 File Offset: 0x009505C6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_HoverCarInteraction_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06021C18 RID: 138264 RVA: 0x009523DC File Offset: 0x009505DC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_HoverCarInteraction_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_HoverCarInteraction_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_HoverCarInteraction_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_HoverCarInteraction_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_HoverCarInteraction_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021C19 RID: 138265 RVA: 0x00952424 File Offset: 0x00950624
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_HoverCarInteraction_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_HoverCarInteraction_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_HoverCarInteraction_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_HoverCarInteraction_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_HoverCarInteraction_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021C1A RID: 138266 RVA: 0x0095246C File Offset: 0x0095066C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_Car_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex, bool bFromSweep, in FHitResult SweepResult)
		{
			BP_HoverCarInteraction_C.__BndEvt__BP_Car_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_HoverCarInteraction_C.__BndEvt__BP_Car_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(BP_HoverCarInteraction_C.__BndEvt__BP_Car_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_HoverCarInteraction_C.__BndEvt__BP_Car_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			ptr->bFromSweep = bFromSweep;
			if (SweepResult != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FHitResult.StaticStruct(), &ptr->SweepResult, SweepResult.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_HoverCarInteraction_C.__BndEvt__BP_Car_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021C1B RID: 138267 RVA: 0x00952528 File Offset: 0x00950728
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_Car_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex)
		{
			BP_HoverCarInteraction_C.__BndEvt__BP_Car_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_HoverCarInteraction_C.__BndEvt__BP_Car_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_HoverCarInteraction_C.__BndEvt__BP_Car_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_HoverCarInteraction_C.__BndEvt__BP_Car_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_HoverCarInteraction_C.__BndEvt__BP_Car_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021C1C RID: 138268 RVA: 0x009525B4 File Offset: 0x009507B4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_HoverCarInteraction(int EntryPoint)
		{
			BP_HoverCarInteraction_C.__ExecuteUbergraph_BP_HoverCarInteraction_FunctionParams* ptr = stackalloc BP_HoverCarInteraction_C.__ExecuteUbergraph_BP_HoverCarInteraction_FunctionParams[(UIntPtr)935] + 15L / (long)sizeof(BP_HoverCarInteraction_C.__ExecuteUbergraph_BP_HoverCarInteraction_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_HoverCarInteraction_C.__ExecuteUbergraph_BP_HoverCarInteraction_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_HoverCarInteraction_C.__ExecuteUbergraph_BP_HoverCarInteraction_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021C1D RID: 138269 RVA: 0x009525FE File Offset: 0x009507FE
		protected BP_HoverCarInteraction_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04011055 RID: 69717
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/SceneInteraction/BP_HoverCarInteraction.BP_HoverCarInteraction_C";

		// Token: 0x04011056 RID: 69718
		private static IntPtr _ClassPtr;

		// Token: 0x04011057 RID: 69719
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04011058 RID: 69720
		internal static int __PropertyOffset_0;

		// Token: 0x04011059 RID: 69721
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0401105A RID: 69722
		internal static int __PropertyOffset_1;

		// Token: 0x0401105B RID: 69723
		internal static int __PropertyOffset_2;

		// Token: 0x0401105C RID: 69724
		internal static int __PropertyOffset_3;

		// Token: 0x0401105D RID: 69725
		internal static int __PropertyOffset_4;

		// Token: 0x0401105E RID: 69726
		internal static int __PropertyOffset_5;

		// Token: 0x0401105F RID: 69727
		internal static int __PropertyOffset_6;

		// Token: 0x04011060 RID: 69728
		internal static int __PropertyOffset_7;

		// Token: 0x04011061 RID: 69729
		internal static int __PropertyOffset_8;

		// Token: 0x04011062 RID: 69730
		internal static int __PropertyOffset_9;

		// Token: 0x04011063 RID: 69731
		internal static int __PropertyOffset_10;

		// Token: 0x04011064 RID: 69732
		internal static int __PropertyOffset_11;

		// Token: 0x04011065 RID: 69733
		internal static int __PropertyOffset_12;

		// Token: 0x04011066 RID: 69734
		internal static int __PropertyOffset_13;

		// Token: 0x04011067 RID: 69735
		internal static int __PropertyOffset_14;

		// Token: 0x04011068 RID: 69736
		internal static int __PropertyOffset_15;

		// Token: 0x04011069 RID: 69737
		internal static int __PropertyOffset_16;

		// Token: 0x0401106A RID: 69738
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0401106B RID: 69739
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0401106C RID: 69740
		private static IntPtr __BndEvt__BP_Car_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0401106D RID: 69741
		private static IntPtr __BndEvt__BP_Car_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0401106E RID: 69742
		private static IntPtr __ExecuteUbergraph_BP_HoverCarInteraction_NativeFunctionPtr;

		// Token: 0x02009B38 RID: 39736
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032302 RID: 205570
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009B39 RID: 39737
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __BndEvt__BP_Car_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x04032303 RID: 205571
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x04032304 RID: 205572
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x04032305 RID: 205573
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x04032306 RID: 205574
			[FieldOffset(24)]
			public int OtherBodyIndex;

			// Token: 0x04032307 RID: 205575
			[FieldOffset(28)]
			public bool bFromSweep;

			// Token: 0x04032308 RID: 205576
			[FieldOffset(32)]
			public byte SweepResult;
		}

		// Token: 0x02009B3A RID: 39738
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __BndEvt__BP_Car_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x04032309 RID: 205577
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x0403230A RID: 205578
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x0403230B RID: 205579
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x0403230C RID: 205580
			[FieldOffset(24)]
			public int OtherBodyIndex;
		}

		// Token: 0x02009B3B RID: 39739
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 920)]
		protected ref struct __ExecuteUbergraph_BP_HoverCarInteraction_FunctionParams
		{
			// Token: 0x0403230D RID: 205581
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
