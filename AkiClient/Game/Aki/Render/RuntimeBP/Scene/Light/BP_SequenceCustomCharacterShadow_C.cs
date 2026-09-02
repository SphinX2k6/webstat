using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Light
{
	// Token: 0x02003A94 RID: 14996
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Light/BP_SequenceCustomCharacterShadow.BP_SequenceCustomCharacterShadow_C")]
	[UnrealStructLayout(1384, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1384)]
	public class BP_SequenceCustomCharacterShadow_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601F92D RID: 129325 RVA: 0x009152D0 File Offset: 0x009134D0
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SequenceCustomCharacterShadow_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_SequenceCustomCharacterShadow.BP_SequenceCustomCharacterShadow_C");
			}
			return BP_SequenceCustomCharacterShadow_C._ClassPtr;
		}

		// Token: 0x0601F92E RID: 129326 RVA: 0x009152F4 File Offset: 0x009134F4
		public BP_SequenceCustomCharacterShadow_C() : this(BuiltinUtils.AllocNativeUObject(BP_SequenceCustomCharacterShadow_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601F92F RID: 129327 RVA: 0x0091531C File Offset: 0x0091351C
		[NullableContext(1)]
		public BP_SequenceCustomCharacterShadow_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SequenceCustomCharacterShadow_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170030B1 RID: 12465
		// (get) Token: 0x0601F930 RID: 129328 RVA: 0x00915350 File Offset: 0x00913550
		// (set) Token: 0x0601F931 RID: 129329 RVA: 0x00915389 File Offset: 0x00913589
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_SequenceCustomCharacterShadow_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_SequenceCustomCharacterShadow_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170030B2 RID: 12466
		// (get) Token: 0x0601F932 RID: 129330 RVA: 0x009153AA File Offset: 0x009135AA
		// (set) Token: 0x0601F933 RID: 129331 RVA: 0x009153BE File Offset: 0x009135BE
		public unsafe UStaticMeshComponent StaticMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SequenceCustomCharacterShadow_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SequenceCustomCharacterShadow_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170030B3 RID: 12467
		// (get) Token: 0x0601F934 RID: 129332 RVA: 0x009153D3 File Offset: 0x009135D3
		// (set) Token: 0x0601F935 RID: 129333 RVA: 0x009153E7 File Offset: 0x009135E7
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SequenceCustomCharacterShadow_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SequenceCustomCharacterShadow_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170030B4 RID: 12468
		// (get) Token: 0x0601F936 RID: 129334 RVA: 0x009153FC File Offset: 0x009135FC
		// (set) Token: 0x0601F937 RID: 129335 RVA: 0x0091540C File Offset: 0x0091360C
		public unsafe float EvolutionaryRate
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SequenceCustomCharacterShadow_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SequenceCustomCharacterShadow_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x170030B5 RID: 12469
		// (get) Token: 0x0601F938 RID: 129336 RVA: 0x0091541D File Offset: 0x0091361D
		// (set) Token: 0x0601F939 RID: 129337 RVA: 0x0091542D File Offset: 0x0091362D
		public unsafe float EvolutionaryIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SequenceCustomCharacterShadow_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SequenceCustomCharacterShadow_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x170030B6 RID: 12470
		// (get) Token: 0x0601F93A RID: 129338 RVA: 0x0091543E File Offset: 0x0091363E
		// (set) Token: 0x0601F93B RID: 129339 RVA: 0x0091544E File Offset: 0x0091364E
		public unsafe float Range
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SequenceCustomCharacterShadow_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SequenceCustomCharacterShadow_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x170030B7 RID: 12471
		// (get) Token: 0x0601F93C RID: 129340 RVA: 0x0091545F File Offset: 0x0091365F
		// (set) Token: 0x0601F93D RID: 129341 RVA: 0x00915473 File Offset: 0x00913673
		public unsafe UMaterialInstanceDynamic MDY
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SequenceCustomCharacterShadow_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SequenceCustomCharacterShadow_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x170030B8 RID: 12472
		// (get) Token: 0x0601F93E RID: 129342 RVA: 0x00915488 File Offset: 0x00913688
		// (set) Token: 0x0601F93F RID: 129343 RVA: 0x0091549C File Offset: 0x0091369C
		public unsafe UTexture2D MaskTexture
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SequenceCustomCharacterShadow_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SequenceCustomCharacterShadow_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x170030B9 RID: 12473
		// (get) Token: 0x0601F940 RID: 129344 RVA: 0x009154B1 File Offset: 0x009136B1
		// (set) Token: 0x0601F941 RID: 129345 RVA: 0x009154C1 File Offset: 0x009136C1
		public unsafe bool Reverse
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SequenceCustomCharacterShadow_C.__PropertyOffset_8) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SequenceCustomCharacterShadow_C.__PropertyOffset_8) = (value ? 1 : 0);
			}
		}

		// Token: 0x170030BA RID: 12474
		// (get) Token: 0x0601F942 RID: 129346 RVA: 0x009154D2 File Offset: 0x009136D2
		// (set) Token: 0x0601F943 RID: 129347 RVA: 0x009154E6 File Offset: 0x009136E6
		public unsafe UTexture2D FlowMaskTexture
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SequenceCustomCharacterShadow_C.__PropertyOffset_9);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SequenceCustomCharacterShadow_C.__PropertyOffset_9, value);
			}
		}

		// Token: 0x0601F944 RID: 129348 RVA: 0x009154FB File Offset: 0x009136FB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SetCustomShadowParameter()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SequenceCustomCharacterShadow_C.__SetCustomShadowParameter_NativeFunctionPtr, null);
		}

		// Token: 0x0601F945 RID: 129349 RVA: 0x0091550F File Offset: 0x0091370F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SequenceCustomCharacterShadow_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0601F946 RID: 129350 RVA: 0x00915523 File Offset: 0x00913723
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SequenceCustomCharacterShadow_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601F947 RID: 129351 RVA: 0x00915538 File Offset: 0x00913738
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SequenceCustomCharacterShadow_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0601F948 RID: 129352 RVA: 0x0091554C File Offset: 0x0091374C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SequenceCustomCharacterShadow_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601F949 RID: 129353 RVA: 0x00915564 File Offset: 0x00913764
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_SequenceCustomCharacterShadow_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_SequenceCustomCharacterShadow_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SequenceCustomCharacterShadow_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SequenceCustomCharacterShadow_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SequenceCustomCharacterShadow_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F94A RID: 129354 RVA: 0x009155AC File Offset: 0x009137AC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_SequenceCustomCharacterShadow_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_SequenceCustomCharacterShadow_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SequenceCustomCharacterShadow_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SequenceCustomCharacterShadow_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SequenceCustomCharacterShadow_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F94B RID: 129355 RVA: 0x009155F4 File Offset: 0x009137F4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_SequenceCustomCharacterShadow_C.__EditorTick_FunctionParams* ptr = stackalloc BP_SequenceCustomCharacterShadow_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SequenceCustomCharacterShadow_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SequenceCustomCharacterShadow_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SequenceCustomCharacterShadow_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F94C RID: 129356 RVA: 0x0091563C File Offset: 0x0091383C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_SequenceCustomCharacterShadow_C.__EditorTick_FunctionParams* ptr = stackalloc BP_SequenceCustomCharacterShadow_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SequenceCustomCharacterShadow_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SequenceCustomCharacterShadow_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SequenceCustomCharacterShadow_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F94D RID: 129357 RVA: 0x00915684 File Offset: 0x00913884
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_SequenceCustomCharacterShadow(int EntryPoint)
		{
			BP_SequenceCustomCharacterShadow_C.__ExecuteUbergraph_BP_SequenceCustomCharacterShadow_FunctionParams* ptr = stackalloc BP_SequenceCustomCharacterShadow_C.__ExecuteUbergraph_BP_SequenceCustomCharacterShadow_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(BP_SequenceCustomCharacterShadow_C.__ExecuteUbergraph_BP_SequenceCustomCharacterShadow_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SequenceCustomCharacterShadow_C.__ExecuteUbergraph_BP_SequenceCustomCharacterShadow_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SequenceCustomCharacterShadow_C.__ExecuteUbergraph_BP_SequenceCustomCharacterShadow_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F94E RID: 129358 RVA: 0x009156CB File Offset: 0x009138CB
		protected BP_SequenceCustomCharacterShadow_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400FB1A RID: 64282
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_SequenceCustomCharacterShadow.BP_SequenceCustomCharacterShadow_C";

		// Token: 0x0400FB1B RID: 64283
		private static IntPtr _ClassPtr;

		// Token: 0x0400FB1C RID: 64284
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400FB1D RID: 64285
		internal static int __PropertyOffset_0;

		// Token: 0x0400FB1E RID: 64286
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400FB1F RID: 64287
		internal static int __PropertyOffset_1;

		// Token: 0x0400FB20 RID: 64288
		internal static int __PropertyOffset_2;

		// Token: 0x0400FB21 RID: 64289
		internal static int __PropertyOffset_3;

		// Token: 0x0400FB22 RID: 64290
		internal static int __PropertyOffset_4;

		// Token: 0x0400FB23 RID: 64291
		internal static int __PropertyOffset_5;

		// Token: 0x0400FB24 RID: 64292
		internal static int __PropertyOffset_6;

		// Token: 0x0400FB25 RID: 64293
		internal static int __PropertyOffset_7;

		// Token: 0x0400FB26 RID: 64294
		internal static int __PropertyOffset_8;

		// Token: 0x0400FB27 RID: 64295
		internal static int __PropertyOffset_9;

		// Token: 0x0400FB28 RID: 64296
		private static IntPtr __SetCustomShadowParameter_NativeFunctionPtr;

		// Token: 0x0400FB29 RID: 64297
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0400FB2A RID: 64298
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400FB2B RID: 64299
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400FB2C RID: 64300
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x0400FB2D RID: 64301
		private static IntPtr __ExecuteUbergraph_BP_SequenceCustomCharacterShadow_NativeFunctionPtr;

		// Token: 0x020098FF RID: 39167
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031F5E RID: 204638
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009900 RID: 39168
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04031F5F RID: 204639
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009901 RID: 39169
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __ExecuteUbergraph_BP_SequenceCustomCharacterShadow_FunctionParams
		{
			// Token: 0x04031F60 RID: 204640
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
