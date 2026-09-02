using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.FluidNinjaLive.Water
{
	// Token: 0x02003CFC RID: 15612
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/FluidNinjaLive/Water/BP_SplineGenerator.BP_SplineGenerator_C")]
	[UnrealStructLayout(1112, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1112)]
	public class BP_SplineGenerator_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06025967 RID: 153959 RVA: 0x009BE3D2 File Offset: 0x009BC5D2
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SplineGenerator_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/FluidNinjaLive/Water/BP_SplineGenerator.BP_SplineGenerator_C");
			}
			return BP_SplineGenerator_C._ClassPtr;
		}

		// Token: 0x06025968 RID: 153960 RVA: 0x009BE3F8 File Offset: 0x009BC5F8
		public BP_SplineGenerator_C() : this(BuiltinUtils.AllocNativeUObject(BP_SplineGenerator_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06025969 RID: 153961 RVA: 0x009BE420 File Offset: 0x009BC620
		[NullableContext(1)]
		public BP_SplineGenerator_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SplineGenerator_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170052B4 RID: 21172
		// (get) Token: 0x0602596A RID: 153962 RVA: 0x009BE454 File Offset: 0x009BC654
		// (set) Token: 0x0602596B RID: 153963 RVA: 0x009BE48D File Offset: 0x009BC68D
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_SplineGenerator_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_SplineGenerator_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170052B5 RID: 21173
		// (get) Token: 0x0602596C RID: 153964 RVA: 0x009BE4AE File Offset: 0x009BC6AE
		// (set) Token: 0x0602596D RID: 153965 RVA: 0x009BE4C2 File Offset: 0x009BC6C2
		public unsafe USplineComponent Spline
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USplineComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplineGenerator_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplineGenerator_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170052B6 RID: 21174
		// (get) Token: 0x0602596E RID: 153966 RVA: 0x009BE4D7 File Offset: 0x009BC6D7
		// (set) Token: 0x0602596F RID: 153967 RVA: 0x009BE4EB File Offset: 0x009BC6EB
		public unsafe UBillboardComponent Billboard
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBillboardComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplineGenerator_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplineGenerator_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170052B7 RID: 21175
		// (get) Token: 0x06025970 RID: 153968 RVA: 0x009BE500 File Offset: 0x009BC700
		// (set) Token: 0x06025971 RID: 153969 RVA: 0x009BE514 File Offset: 0x009BC714
		public unsafe USceneComponent Scene
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplineGenerator_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplineGenerator_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x170052B8 RID: 21176
		// (get) Token: 0x06025972 RID: 153970 RVA: 0x009BE529 File Offset: 0x009BC729
		// (set) Token: 0x06025973 RID: 153971 RVA: 0x009BE53D File Offset: 0x009BC73D
		public unsafe UStaticMesh StaticMeshComponent
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplineGenerator_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplineGenerator_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x170052B9 RID: 21177
		// (get) Token: 0x06025974 RID: 153972 RVA: 0x009BE552 File Offset: 0x009BC752
		// (set) Token: 0x06025975 RID: 153973 RVA: 0x009BE566 File Offset: 0x009BC766
		[Nullable(0)]
		public unsafe TEnumAsByte<ESplineMeshAxis> In_Forward_Axis
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplineGenerator_C.__PropertyOffset_5);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplineGenerator_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x170052BA RID: 21178
		// (get) Token: 0x06025976 RID: 153974 RVA: 0x009BE57B File Offset: 0x009BC77B
		// (set) Token: 0x06025977 RID: 153975 RVA: 0x009BE58F File Offset: 0x009BC78F
		public unsafe UMaterialInstance EditorPlaceholderMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplineGenerator_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplineGenerator_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x170052BB RID: 21179
		// (get) Token: 0x06025978 RID: 153976 RVA: 0x009BE5A4 File Offset: 0x009BC7A4
		// (set) Token: 0x06025979 RID: 153977 RVA: 0x009BE5B4 File Offset: 0x009BC7B4
		public unsafe float SizeAdjutment
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplineGenerator_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplineGenerator_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x170052BC RID: 21180
		// (get) Token: 0x0602597A RID: 153978 RVA: 0x009BE5C5 File Offset: 0x009BC7C5
		// (set) Token: 0x0602597B RID: 153979 RVA: 0x009BE5D5 File Offset: 0x009BC7D5
		public unsafe float SectionLength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplineGenerator_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplineGenerator_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x170052BD RID: 21181
		// (get) Token: 0x0602597C RID: 153980 RVA: 0x009BE5E8 File Offset: 0x009BC7E8
		// (set) Token: 0x0602597D RID: 153981 RVA: 0x009BE621 File Offset: 0x009BC821
		[Nullable(1)]
		public TArray<USplineMeshComponent> SplineMeshComponents
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<USplineMeshComponent> result;
				if ((result = this._SplineMeshComponents) == null)
				{
					result = (this._SplineMeshComponents = new TArray<USplineMeshComponent>(base.NativePtr + (IntPtr)BP_SplineGenerator_C.__PropertyOffset_9, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.SplineMeshComponents.CopyAssign(value);
			}
		}

		// Token: 0x0602597E RID: 153982 RVA: 0x009BE62F File Offset: 0x009BC82F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SplineGenerator_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0602597F RID: 153983 RVA: 0x009BE643 File Offset: 0x009BC843
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SplineGenerator_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06025980 RID: 153984 RVA: 0x009BE658 File Offset: 0x009BC858
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SplineGenerator_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06025981 RID: 153985 RVA: 0x009BE66C File Offset: 0x009BC86C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SplineGenerator_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06025982 RID: 153986 RVA: 0x009BE684 File Offset: 0x009BC884
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveActorBeginOverlap(AActor OtherActor)
		{
			BP_SplineGenerator_C.__ReceiveActorBeginOverlap_FunctionParams* ptr = stackalloc BP_SplineGenerator_C.__ReceiveActorBeginOverlap_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_SplineGenerator_C.__ReceiveActorBeginOverlap_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SplineGenerator_C.__ReceiveActorBeginOverlap_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SplineGenerator_C.__ReceiveActorBeginOverlap_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025983 RID: 153987 RVA: 0x009BE6DC File Offset: 0x009BC8DC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveActorBeginOverlap_Implementation(AActor OtherActor)
		{
			BP_SplineGenerator_C.__ReceiveActorBeginOverlap_FunctionParams* ptr = stackalloc BP_SplineGenerator_C.__ReceiveActorBeginOverlap_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_SplineGenerator_C.__ReceiveActorBeginOverlap_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SplineGenerator_C.__ReceiveActorBeginOverlap_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SplineGenerator_C.__ReceiveActorBeginOverlap_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06025984 RID: 153988 RVA: 0x009BE734 File Offset: 0x009BC934
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_SplineGenerator_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_SplineGenerator_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SplineGenerator_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SplineGenerator_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SplineGenerator_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025985 RID: 153989 RVA: 0x009BE77C File Offset: 0x009BC97C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_SplineGenerator_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_SplineGenerator_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SplineGenerator_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SplineGenerator_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SplineGenerator_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06025986 RID: 153990 RVA: 0x009BE7C4 File Offset: 0x009BC9C4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_SplineGenerator(int EntryPoint)
		{
			BP_SplineGenerator_C.__ExecuteUbergraph_BP_SplineGenerator_FunctionParams* ptr = stackalloc BP_SplineGenerator_C.__ExecuteUbergraph_BP_SplineGenerator_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_SplineGenerator_C.__ExecuteUbergraph_BP_SplineGenerator_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SplineGenerator_C.__ExecuteUbergraph_BP_SplineGenerator_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SplineGenerator_C.__ExecuteUbergraph_BP_SplineGenerator_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06025987 RID: 153991 RVA: 0x009BE80B File Offset: 0x009BCA0B
		protected BP_SplineGenerator_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401363F RID: 79423
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/FluidNinjaLive/Water/BP_SplineGenerator.BP_SplineGenerator_C";

		// Token: 0x04013640 RID: 79424
		private static IntPtr _ClassPtr;

		// Token: 0x04013641 RID: 79425
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04013642 RID: 79426
		internal static int __PropertyOffset_0;

		// Token: 0x04013643 RID: 79427
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04013644 RID: 79428
		internal static int __PropertyOffset_1;

		// Token: 0x04013645 RID: 79429
		internal static int __PropertyOffset_2;

		// Token: 0x04013646 RID: 79430
		internal static int __PropertyOffset_3;

		// Token: 0x04013647 RID: 79431
		internal static int __PropertyOffset_4;

		// Token: 0x04013648 RID: 79432
		internal static int __PropertyOffset_5;

		// Token: 0x04013649 RID: 79433
		internal static int __PropertyOffset_6;

		// Token: 0x0401364A RID: 79434
		internal static int __PropertyOffset_7;

		// Token: 0x0401364B RID: 79435
		internal static int __PropertyOffset_8;

		// Token: 0x0401364C RID: 79436
		internal static int __PropertyOffset_9;

		// Token: 0x0401364D RID: 79437
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<USplineMeshComponent> _SplineMeshComponents;

		// Token: 0x0401364E RID: 79438
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0401364F RID: 79439
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04013650 RID: 79440
		private static IntPtr __ReceiveActorBeginOverlap_NativeFunctionPtr;

		// Token: 0x04013651 RID: 79441
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04013652 RID: 79442
		private static IntPtr __ExecuteUbergraph_BP_SplineGenerator_NativeFunctionPtr;

		// Token: 0x02009F34 RID: 40756
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected new ref struct __ReceiveActorBeginOverlap_FunctionParams
		{
			// Token: 0x04032A65 RID: 207461
			[FieldOffset(0)]
			public IntPtr OtherActor;
		}

		// Token: 0x02009F35 RID: 40757
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032A66 RID: 207462
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009F36 RID: 40758
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __ExecuteUbergraph_BP_SplineGenerator_FunctionParams
		{
			// Token: 0x04032A67 RID: 207463
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
