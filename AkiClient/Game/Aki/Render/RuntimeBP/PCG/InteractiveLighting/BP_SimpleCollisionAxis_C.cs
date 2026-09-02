using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.InteractiveLighting
{
	// Token: 0x02003C09 RID: 15369
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/InteractiveLighting/BP_SimpleCollisionAxis.BP_SimpleCollisionAxis_C")]
	[UnrealStructLayout(1440, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1440)]
	public class BP_SimpleCollisionAxis_C : AKuroCSSimpleCollisionAxis, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06022E3E RID: 142910 RVA: 0x009721EC File Offset: 0x009703EC
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SimpleCollisionAxis_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/InteractiveLighting/BP_SimpleCollisionAxis.BP_SimpleCollisionAxis_C");
			}
			return BP_SimpleCollisionAxis_C._ClassPtr;
		}

		// Token: 0x06022E3F RID: 142911 RVA: 0x00972210 File Offset: 0x00970410
		public BP_SimpleCollisionAxis_C() : this(BuiltinUtils.AllocNativeUObject(BP_SimpleCollisionAxis_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06022E40 RID: 142912 RVA: 0x00972238 File Offset: 0x00970438
		[NullableContext(1)]
		public BP_SimpleCollisionAxis_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SimpleCollisionAxis_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700434A RID: 17226
		// (get) Token: 0x06022E41 RID: 142913 RVA: 0x0097226C File Offset: 0x0097046C
		// (set) Token: 0x06022E42 RID: 142914 RVA: 0x009722A5 File Offset: 0x009704A5
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_SimpleCollisionAxis_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_SimpleCollisionAxis_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700434B RID: 17227
		// (get) Token: 0x06022E43 RID: 142915 RVA: 0x009722C6 File Offset: 0x009704C6
		// (set) Token: 0x06022E44 RID: 142916 RVA: 0x009722DA File Offset: 0x009704DA
		public unsafe UBoxComponent Box
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SimpleCollisionAxis_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SimpleCollisionAxis_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x1700434C RID: 17228
		// (get) Token: 0x06022E45 RID: 142917 RVA: 0x009722EF File Offset: 0x009704EF
		// (set) Token: 0x06022E46 RID: 142918 RVA: 0x00972303 File Offset: 0x00970503
		public unsafe UTextureRenderTarget2D T_Particle_Pivot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SimpleCollisionAxis_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SimpleCollisionAxis_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x1700434D RID: 17229
		// (get) Token: 0x06022E47 RID: 142919 RVA: 0x00972318 File Offset: 0x00970518
		// (set) Token: 0x06022E48 RID: 142920 RVA: 0x00972328 File Offset: 0x00970528
		public unsafe bool Debug
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SimpleCollisionAxis_C.__PropertyOffset_3) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SimpleCollisionAxis_C.__PropertyOffset_3) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700434E RID: 17230
		// (get) Token: 0x06022E49 RID: 142921 RVA: 0x00972339 File Offset: 0x00970539
		// (set) Token: 0x06022E4A RID: 142922 RVA: 0x00972349 File Offset: 0x00970549
		public unsafe bool NewVar_0
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SimpleCollisionAxis_C.__PropertyOffset_4) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SimpleCollisionAxis_C.__PropertyOffset_4) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700434F RID: 17231
		// (get) Token: 0x06022E4B RID: 142923 RVA: 0x0097235A File Offset: 0x0097055A
		// (set) Token: 0x06022E4C RID: 142924 RVA: 0x0097236E File Offset: 0x0097056E
		public unsafe UMaterialInterface CopyTexMat
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInterface>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SimpleCollisionAxis_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SimpleCollisionAxis_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17004350 RID: 17232
		// (get) Token: 0x06022E4D RID: 142925 RVA: 0x00972384 File Offset: 0x00970584
		// (set) Token: 0x06022E4E RID: 142926 RVA: 0x009723BD File Offset: 0x009705BD
		[Nullable(1)]
		public TArray<UMaterialInstanceDynamic> RenderMID
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<UMaterialInstanceDynamic> result;
				if ((result = this._RenderMID) == null)
				{
					result = (this._RenderMID = new TArray<UMaterialInstanceDynamic>(base.NativePtr + (IntPtr)BP_SimpleCollisionAxis_C.__PropertyOffset_6, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.RenderMID.CopyAssign(value);
			}
		}

		// Token: 0x17004351 RID: 17233
		// (get) Token: 0x06022E4F RID: 142927 RVA: 0x009723CB File Offset: 0x009705CB
		// (set) Token: 0x06022E50 RID: 142928 RVA: 0x009723DF File Offset: 0x009705DF
		public unsafe UStaticMesh SM_Ice1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SimpleCollisionAxis_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SimpleCollisionAxis_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x17004352 RID: 17234
		// (get) Token: 0x06022E51 RID: 142929 RVA: 0x009723F4 File Offset: 0x009705F4
		// (set) Token: 0x06022E52 RID: 142930 RVA: 0x00972408 File Offset: 0x00970608
		public unsafe UStaticMesh SM_Ice2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SimpleCollisionAxis_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SimpleCollisionAxis_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x17004353 RID: 17235
		// (get) Token: 0x06022E53 RID: 142931 RVA: 0x0097241D File Offset: 0x0097061D
		// (set) Token: 0x06022E54 RID: 142932 RVA: 0x00972431 File Offset: 0x00970631
		public unsafe UStaticMesh SM_Ice3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SimpleCollisionAxis_C.__PropertyOffset_9);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SimpleCollisionAxis_C.__PropertyOffset_9, value);
			}
		}

		// Token: 0x17004354 RID: 17236
		// (get) Token: 0x06022E55 RID: 142933 RVA: 0x00972446 File Offset: 0x00970646
		// (set) Token: 0x06022E56 RID: 142934 RVA: 0x0097245A File Offset: 0x0097065A
		public unsafe UTexture2D Input_Texture
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SimpleCollisionAxis_C.__PropertyOffset_10);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SimpleCollisionAxis_C.__PropertyOffset_10, value);
			}
		}

		// Token: 0x17004355 RID: 17237
		// (get) Token: 0x06022E57 RID: 142935 RVA: 0x0097246F File Offset: 0x0097066F
		// (set) Token: 0x06022E58 RID: 142936 RVA: 0x00972483 File Offset: 0x00970683
		public unsafe UTexture2D Input_Texture_1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SimpleCollisionAxis_C.__PropertyOffset_11);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SimpleCollisionAxis_C.__PropertyOffset_11, value);
			}
		}

		// Token: 0x17004356 RID: 17238
		// (get) Token: 0x06022E59 RID: 142937 RVA: 0x00972498 File Offset: 0x00970698
		// (set) Token: 0x06022E5A RID: 142938 RVA: 0x009724AC File Offset: 0x009706AC
		public unsafe UTexture2D Input_Texture_2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SimpleCollisionAxis_C.__PropertyOffset_12);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SimpleCollisionAxis_C.__PropertyOffset_12, value);
			}
		}

		// Token: 0x06022E5B RID: 142939 RVA: 0x009724C1 File Offset: 0x009706C1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 应用贴图材质()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SimpleCollisionAxis_C.__应用贴图材质_NativeFunctionPtr, null);
		}

		// Token: 0x06022E5C RID: 142940 RVA: 0x009724D5 File Offset: 0x009706D5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SimpleCollisionAxis_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06022E5D RID: 142941 RVA: 0x009724E9 File Offset: 0x009706E9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SimpleCollisionAxis_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06022E5E RID: 142942 RVA: 0x00972500 File Offset: 0x00970700
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_SimpleCollisionAxis_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_SimpleCollisionAxis_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SimpleCollisionAxis_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SimpleCollisionAxis_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SimpleCollisionAxis_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022E5F RID: 142943 RVA: 0x00972548 File Offset: 0x00970748
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_SimpleCollisionAxis_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_SimpleCollisionAxis_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SimpleCollisionAxis_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SimpleCollisionAxis_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SimpleCollisionAxis_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06022E60 RID: 142944 RVA: 0x0097258F File Offset: 0x0097078F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SimpleCollisionAxis_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06022E61 RID: 142945 RVA: 0x009725A3 File Offset: 0x009707A3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SimpleCollisionAxis_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06022E62 RID: 142946 RVA: 0x009725B8 File Offset: 0x009707B8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_IceCollision_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex, bool bFromSweep, in FHitResult SweepResult)
		{
			BP_SimpleCollisionAxis_C.__BndEvt__BP_IceCollision_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_SimpleCollisionAxis_C.__BndEvt__BP_IceCollision_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(BP_SimpleCollisionAxis_C.__BndEvt__BP_IceCollision_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SimpleCollisionAxis_C.__BndEvt__BP_IceCollision_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			ptr->bFromSweep = bFromSweep;
			if (SweepResult != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FHitResult.StaticStruct(), &ptr->SweepResult, SweepResult.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SimpleCollisionAxis_C.__BndEvt__BP_IceCollision_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022E63 RID: 142947 RVA: 0x00972674 File Offset: 0x00970874
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_IceCollision_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex)
		{
			BP_SimpleCollisionAxis_C.__BndEvt__BP_IceCollision_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_SimpleCollisionAxis_C.__BndEvt__BP_IceCollision_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_SimpleCollisionAxis_C.__BndEvt__BP_IceCollision_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SimpleCollisionAxis_C.__BndEvt__BP_IceCollision_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SimpleCollisionAxis_C.__BndEvt__BP_IceCollision_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022E64 RID: 142948 RVA: 0x00972700 File Offset: 0x00970900
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_SimpleCollisionAxis(int EntryPoint)
		{
			BP_SimpleCollisionAxis_C.__ExecuteUbergraph_BP_SimpleCollisionAxis_FunctionParams* ptr = stackalloc BP_SimpleCollisionAxis_C.__ExecuteUbergraph_BP_SimpleCollisionAxis_FunctionParams[(UIntPtr)263] + 15L / (long)sizeof(BP_SimpleCollisionAxis_C.__ExecuteUbergraph_BP_SimpleCollisionAxis_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SimpleCollisionAxis_C.__ExecuteUbergraph_BP_SimpleCollisionAxis_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SimpleCollisionAxis_C.__ExecuteUbergraph_BP_SimpleCollisionAxis_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06022E65 RID: 142949 RVA: 0x0097274A File Offset: 0x0097094A
		protected BP_SimpleCollisionAxis_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04011B73 RID: 72563
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/InteractiveLighting/BP_SimpleCollisionAxis.BP_SimpleCollisionAxis_C";

		// Token: 0x04011B74 RID: 72564
		private static IntPtr _ClassPtr;

		// Token: 0x04011B75 RID: 72565
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04011B76 RID: 72566
		internal static int __PropertyOffset_0;

		// Token: 0x04011B77 RID: 72567
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04011B78 RID: 72568
		internal static int __PropertyOffset_1;

		// Token: 0x04011B79 RID: 72569
		internal static int __PropertyOffset_2;

		// Token: 0x04011B7A RID: 72570
		internal static int __PropertyOffset_3;

		// Token: 0x04011B7B RID: 72571
		internal static int __PropertyOffset_4;

		// Token: 0x04011B7C RID: 72572
		internal static int __PropertyOffset_5;

		// Token: 0x04011B7D RID: 72573
		internal static int __PropertyOffset_6;

		// Token: 0x04011B7E RID: 72574
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UMaterialInstanceDynamic> _RenderMID;

		// Token: 0x04011B7F RID: 72575
		internal static int __PropertyOffset_7;

		// Token: 0x04011B80 RID: 72576
		internal static int __PropertyOffset_8;

		// Token: 0x04011B81 RID: 72577
		internal static int __PropertyOffset_9;

		// Token: 0x04011B82 RID: 72578
		internal static int __PropertyOffset_10;

		// Token: 0x04011B83 RID: 72579
		internal static int __PropertyOffset_11;

		// Token: 0x04011B84 RID: 72580
		internal static int __PropertyOffset_12;

		// Token: 0x04011B85 RID: 72581
		private static IntPtr __应用贴图材质_NativeFunctionPtr;

		// Token: 0x04011B86 RID: 72582
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04011B87 RID: 72583
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04011B88 RID: 72584
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04011B89 RID: 72585
		private static IntPtr __BndEvt__BP_IceCollision_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04011B8A RID: 72586
		private static IntPtr __BndEvt__BP_IceCollision_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04011B8B RID: 72587
		private static IntPtr __ExecuteUbergraph_BP_SimpleCollisionAxis_NativeFunctionPtr;

		// Token: 0x02009C45 RID: 40005
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x040324EA RID: 206058
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009C46 RID: 40006
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __BndEvt__BP_IceCollision_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x040324EB RID: 206059
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x040324EC RID: 206060
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x040324ED RID: 206061
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x040324EE RID: 206062
			[FieldOffset(24)]
			public int OtherBodyIndex;

			// Token: 0x040324EF RID: 206063
			[FieldOffset(28)]
			public bool bFromSweep;

			// Token: 0x040324F0 RID: 206064
			[FieldOffset(32)]
			public byte SweepResult;
		}

		// Token: 0x02009C47 RID: 40007
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __BndEvt__BP_IceCollision_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x040324F1 RID: 206065
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x040324F2 RID: 206066
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x040324F3 RID: 206067
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x040324F4 RID: 206068
			[FieldOffset(24)]
			public int OtherBodyIndex;
		}

		// Token: 0x02009C48 RID: 40008
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 248)]
		protected ref struct __ExecuteUbergraph_BP_SimpleCollisionAxis_FunctionParams
		{
			// Token: 0x040324F5 RID: 206069
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
