using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.Ice
{
	// Token: 0x02003C0C RID: 15372
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/Ice/BP_IceCollision.BP_IceCollision_C")]
	[UnrealStructLayout(1328, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1328)]
	public class BP_IceCollision_C : AKuroCSSimpleCollision, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06022EC8 RID: 143048 RVA: 0x009732C7 File Offset: 0x009714C7
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_IceCollision_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/Ice/BP_IceCollision.BP_IceCollision_C");
			}
			return BP_IceCollision_C._ClassPtr;
		}

		// Token: 0x06022EC9 RID: 143049 RVA: 0x009732EC File Offset: 0x009714EC
		public BP_IceCollision_C() : this(BuiltinUtils.AllocNativeUObject(BP_IceCollision_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06022ECA RID: 143050 RVA: 0x00973314 File Offset: 0x00971514
		[NullableContext(1)]
		public BP_IceCollision_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_IceCollision_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700437A RID: 17274
		// (get) Token: 0x06022ECB RID: 143051 RVA: 0x00973348 File Offset: 0x00971548
		// (set) Token: 0x06022ECC RID: 143052 RVA: 0x00973381 File Offset: 0x00971581
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_IceCollision_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_IceCollision_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700437B RID: 17275
		// (get) Token: 0x06022ECD RID: 143053 RVA: 0x009733A2 File Offset: 0x009715A2
		// (set) Token: 0x06022ECE RID: 143054 RVA: 0x009733B6 File Offset: 0x009715B6
		public unsafe UBoxComponent Box
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_IceCollision_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_IceCollision_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x1700437C RID: 17276
		// (get) Token: 0x06022ECF RID: 143055 RVA: 0x009733CB File Offset: 0x009715CB
		// (set) Token: 0x06022ED0 RID: 143056 RVA: 0x009733DF File Offset: 0x009715DF
		public unsafe UMaterialInterface RenderMat
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInterface>(base.NativePtr / (IntPtr)sizeof(void*) + BP_IceCollision_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_IceCollision_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x1700437D RID: 17277
		// (get) Token: 0x06022ED1 RID: 143057 RVA: 0x009733F4 File Offset: 0x009715F4
		// (set) Token: 0x06022ED2 RID: 143058 RVA: 0x00973408 File Offset: 0x00971608
		public unsafe UMaterialInterface RenderMat_OceanWave
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInterface>(base.NativePtr / (IntPtr)sizeof(void*) + BP_IceCollision_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_IceCollision_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x1700437E RID: 17278
		// (get) Token: 0x06022ED3 RID: 143059 RVA: 0x0097341D File Offset: 0x0097161D
		// (set) Token: 0x06022ED4 RID: 143060 RVA: 0x00973431 File Offset: 0x00971631
		public unsafe UTextureRenderTarget2D T_Particle_Pivot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_IceCollision_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_IceCollision_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x1700437F RID: 17279
		// (get) Token: 0x06022ED5 RID: 143061 RVA: 0x00973446 File Offset: 0x00971646
		// (set) Token: 0x06022ED6 RID: 143062 RVA: 0x00973456 File Offset: 0x00971656
		public unsafe bool Debug
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_IceCollision_C.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_IceCollision_C.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004380 RID: 17280
		// (get) Token: 0x06022ED7 RID: 143063 RVA: 0x00973467 File Offset: 0x00971667
		// (set) Token: 0x06022ED8 RID: 143064 RVA: 0x00973477 File Offset: 0x00971677
		public unsafe bool NewVar_0
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_IceCollision_C.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_IceCollision_C.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004381 RID: 17281
		// (get) Token: 0x06022ED9 RID: 143065 RVA: 0x00973488 File Offset: 0x00971688
		// (set) Token: 0x06022EDA RID: 143066 RVA: 0x0097349C File Offset: 0x0097169C
		public unsafe UMaterialInterface CopyTexMat
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInterface>(base.NativePtr / (IntPtr)sizeof(void*) + BP_IceCollision_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_IceCollision_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x17004382 RID: 17282
		// (get) Token: 0x06022EDB RID: 143067 RVA: 0x009734B1 File Offset: 0x009716B1
		// (set) Token: 0x06022EDC RID: 143068 RVA: 0x009734C5 File Offset: 0x009716C5
		public unsafe UMaterialInstanceDynamic RenderMID
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_IceCollision_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_IceCollision_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x17004383 RID: 17283
		// (get) Token: 0x06022EDD RID: 143069 RVA: 0x009734DA File Offset: 0x009716DA
		// (set) Token: 0x06022EDE RID: 143070 RVA: 0x009734EE File Offset: 0x009716EE
		public unsafe UStaticMesh SM_Ice1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + BP_IceCollision_C.__PropertyOffset_9);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_IceCollision_C.__PropertyOffset_9, value);
			}
		}

		// Token: 0x17004384 RID: 17284
		// (get) Token: 0x06022EDF RID: 143071 RVA: 0x00973503 File Offset: 0x00971703
		// (set) Token: 0x06022EE0 RID: 143072 RVA: 0x00973517 File Offset: 0x00971717
		public unsafe UStaticMesh SM_Ice2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + BP_IceCollision_C.__PropertyOffset_10);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_IceCollision_C.__PropertyOffset_10, value);
			}
		}

		// Token: 0x17004385 RID: 17285
		// (get) Token: 0x06022EE1 RID: 143073 RVA: 0x0097352C File Offset: 0x0097172C
		// (set) Token: 0x06022EE2 RID: 143074 RVA: 0x00973540 File Offset: 0x00971740
		public unsafe UStaticMesh SM_Ice3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + BP_IceCollision_C.__PropertyOffset_11);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_IceCollision_C.__PropertyOffset_11, value);
			}
		}

		// Token: 0x17004386 RID: 17286
		// (get) Token: 0x06022EE3 RID: 143075 RVA: 0x00973555 File Offset: 0x00971755
		// (set) Token: 0x06022EE4 RID: 143076 RVA: 0x00973569 File Offset: 0x00971769
		public unsafe UTexture2D Input_Texture
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_IceCollision_C.__PropertyOffset_12);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_IceCollision_C.__PropertyOffset_12, value);
			}
		}

		// Token: 0x17004387 RID: 17287
		// (get) Token: 0x06022EE5 RID: 143077 RVA: 0x0097357E File Offset: 0x0097177E
		// (set) Token: 0x06022EE6 RID: 143078 RVA: 0x00973592 File Offset: 0x00971792
		public unsafe UTexture2D Input_Texture_1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_IceCollision_C.__PropertyOffset_13);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_IceCollision_C.__PropertyOffset_13, value);
			}
		}

		// Token: 0x17004388 RID: 17288
		// (get) Token: 0x06022EE7 RID: 143079 RVA: 0x009735A7 File Offset: 0x009717A7
		// (set) Token: 0x06022EE8 RID: 143080 RVA: 0x009735BB File Offset: 0x009717BB
		public unsafe UTexture2D Input_Texture_2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_IceCollision_C.__PropertyOffset_14);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_IceCollision_C.__PropertyOffset_14, value);
			}
		}

		// Token: 0x17004389 RID: 17289
		// (get) Token: 0x06022EE9 RID: 143081 RVA: 0x009735D0 File Offset: 0x009717D0
		// (set) Token: 0x06022EEA RID: 143082 RVA: 0x009735E0 File Offset: 0x009717E0
		public unsafe bool 使用跟随海浪起伏
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_IceCollision_C.__PropertyOffset_15) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_IceCollision_C.__PropertyOffset_15) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700438A RID: 17290
		// (get) Token: 0x06022EEB RID: 143083 RVA: 0x009735F1 File Offset: 0x009717F1
		// (set) Token: 0x06022EEC RID: 143084 RVA: 0x00973601 File Offset: 0x00971801
		public unsafe float 跟随海浪起伏强度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_IceCollision_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_IceCollision_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x06022EED RID: 143085 RVA: 0x00973612 File Offset: 0x00971812
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 应用贴图材质()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_IceCollision_C.__应用贴图材质_NativeFunctionPtr, null);
		}

		// Token: 0x06022EEE RID: 143086 RVA: 0x00973626 File Offset: 0x00971826
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_IceCollision_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06022EEF RID: 143087 RVA: 0x0097363A File Offset: 0x0097183A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_IceCollision_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06022EF0 RID: 143088 RVA: 0x0097364F File Offset: 0x0097184F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_IceCollision_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06022EF1 RID: 143089 RVA: 0x00973663 File Offset: 0x00971863
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_IceCollision_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06022EF2 RID: 143090 RVA: 0x00973678 File Offset: 0x00971878
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_IceCollision_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_IceCollision_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_IceCollision_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_IceCollision_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_IceCollision_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022EF3 RID: 143091 RVA: 0x009736C0 File Offset: 0x009718C0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_IceCollision_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_IceCollision_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_IceCollision_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_IceCollision_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_IceCollision_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06022EF4 RID: 143092 RVA: 0x00973708 File Offset: 0x00971908
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_IceCollision_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex, bool bFromSweep, in FHitResult SweepResult)
		{
			BP_IceCollision_C.__BndEvt__BP_IceCollision_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_IceCollision_C.__BndEvt__BP_IceCollision_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(BP_IceCollision_C.__BndEvt__BP_IceCollision_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_IceCollision_C.__BndEvt__BP_IceCollision_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			ptr->bFromSweep = bFromSweep;
			if (SweepResult != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FHitResult.StaticStruct(), &ptr->SweepResult, SweepResult.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_IceCollision_C.__BndEvt__BP_IceCollision_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022EF5 RID: 143093 RVA: 0x009737C4 File Offset: 0x009719C4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_IceCollision_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex)
		{
			BP_IceCollision_C.__BndEvt__BP_IceCollision_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_IceCollision_C.__BndEvt__BP_IceCollision_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_IceCollision_C.__BndEvt__BP_IceCollision_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_IceCollision_C.__BndEvt__BP_IceCollision_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_IceCollision_C.__BndEvt__BP_IceCollision_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022EF6 RID: 143094 RVA: 0x00973850 File Offset: 0x00971A50
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_IceCollision(int EntryPoint)
		{
			BP_IceCollision_C.__ExecuteUbergraph_BP_IceCollision_FunctionParams* ptr = stackalloc BP_IceCollision_C.__ExecuteUbergraph_BP_IceCollision_FunctionParams[(UIntPtr)479] + 15L / (long)sizeof(BP_IceCollision_C.__ExecuteUbergraph_BP_IceCollision_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_IceCollision_C.__ExecuteUbergraph_BP_IceCollision_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_IceCollision_C.__ExecuteUbergraph_BP_IceCollision_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06022EF7 RID: 143095 RVA: 0x0097389A File Offset: 0x00971A9A
		protected BP_IceCollision_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04011BC8 RID: 72648
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/Ice/BP_IceCollision.BP_IceCollision_C";

		// Token: 0x04011BC9 RID: 72649
		private static IntPtr _ClassPtr;

		// Token: 0x04011BCA RID: 72650
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04011BCB RID: 72651
		internal static int __PropertyOffset_0;

		// Token: 0x04011BCC RID: 72652
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04011BCD RID: 72653
		internal static int __PropertyOffset_1;

		// Token: 0x04011BCE RID: 72654
		internal static int __PropertyOffset_2;

		// Token: 0x04011BCF RID: 72655
		internal static int __PropertyOffset_3;

		// Token: 0x04011BD0 RID: 72656
		internal static int __PropertyOffset_4;

		// Token: 0x04011BD1 RID: 72657
		internal static int __PropertyOffset_5;

		// Token: 0x04011BD2 RID: 72658
		internal static int __PropertyOffset_6;

		// Token: 0x04011BD3 RID: 72659
		internal static int __PropertyOffset_7;

		// Token: 0x04011BD4 RID: 72660
		internal static int __PropertyOffset_8;

		// Token: 0x04011BD5 RID: 72661
		internal static int __PropertyOffset_9;

		// Token: 0x04011BD6 RID: 72662
		internal static int __PropertyOffset_10;

		// Token: 0x04011BD7 RID: 72663
		internal static int __PropertyOffset_11;

		// Token: 0x04011BD8 RID: 72664
		internal static int __PropertyOffset_12;

		// Token: 0x04011BD9 RID: 72665
		internal static int __PropertyOffset_13;

		// Token: 0x04011BDA RID: 72666
		internal static int __PropertyOffset_14;

		// Token: 0x04011BDB RID: 72667
		internal static int __PropertyOffset_15;

		// Token: 0x04011BDC RID: 72668
		internal static int __PropertyOffset_16;

		// Token: 0x04011BDD RID: 72669
		private static IntPtr __应用贴图材质_NativeFunctionPtr;

		// Token: 0x04011BDE RID: 72670
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04011BDF RID: 72671
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04011BE0 RID: 72672
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04011BE1 RID: 72673
		private static IntPtr __BndEvt__BP_IceCollision_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04011BE2 RID: 72674
		private static IntPtr __BndEvt__BP_IceCollision_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04011BE3 RID: 72675
		private static IntPtr __ExecuteUbergraph_BP_IceCollision_NativeFunctionPtr;

		// Token: 0x02009C51 RID: 40017
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032508 RID: 206088
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009C52 RID: 40018
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __BndEvt__BP_IceCollision_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x04032509 RID: 206089
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x0403250A RID: 206090
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x0403250B RID: 206091
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x0403250C RID: 206092
			[FieldOffset(24)]
			public int OtherBodyIndex;

			// Token: 0x0403250D RID: 206093
			[FieldOffset(28)]
			public bool bFromSweep;

			// Token: 0x0403250E RID: 206094
			[FieldOffset(32)]
			public byte SweepResult;
		}

		// Token: 0x02009C53 RID: 40019
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __BndEvt__BP_IceCollision_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x0403250F RID: 206095
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x04032510 RID: 206096
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x04032511 RID: 206097
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x04032512 RID: 206098
			[FieldOffset(24)]
			public int OtherBodyIndex;
		}

		// Token: 0x02009C54 RID: 40020
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 464)]
		protected ref struct __ExecuteUbergraph_BP_IceCollision_FunctionParams
		{
			// Token: 0x04032513 RID: 206099
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
