using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.LongGrass
{
	// Token: 0x02003C5C RID: 15452
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/LongGrass/BP_FoliageSoftInteraction.BP_FoliageSoftInteraction_C")]
	[UnrealStructLayout(1392, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1389)]
	public class BP_FoliageSoftInteraction_C : AKuroBPEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06023B81 RID: 146305 RVA: 0x0098A115 File Offset: 0x00988315
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_FoliageSoftInteraction_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/LongGrass/BP_FoliageSoftInteraction.BP_FoliageSoftInteraction_C");
			}
			return BP_FoliageSoftInteraction_C._ClassPtr;
		}

		// Token: 0x06023B82 RID: 146306 RVA: 0x0098A13C File Offset: 0x0098833C
		public BP_FoliageSoftInteraction_C() : this(BuiltinUtils.AllocNativeUObject(BP_FoliageSoftInteraction_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06023B83 RID: 146307 RVA: 0x0098A164 File Offset: 0x00988364
		[NullableContext(1)]
		public BP_FoliageSoftInteraction_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_FoliageSoftInteraction_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170047F9 RID: 18425
		// (get) Token: 0x06023B84 RID: 146308 RVA: 0x0098A198 File Offset: 0x00988398
		// (set) Token: 0x06023B85 RID: 146309 RVA: 0x0098A1D1 File Offset: 0x009883D1
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_FoliageSoftInteraction_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_FoliageSoftInteraction_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170047FA RID: 18426
		// (get) Token: 0x06023B86 RID: 146310 RVA: 0x0098A1F2 File Offset: 0x009883F2
		// (set) Token: 0x06023B87 RID: 146311 RVA: 0x0098A206 File Offset: 0x00988406
		public unsafe UBoxComponent AreaBox
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FoliageSoftInteraction_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FoliageSoftInteraction_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170047FB RID: 18427
		// (get) Token: 0x06023B88 RID: 146312 RVA: 0x0098A21B File Offset: 0x0098841B
		// (set) Token: 0x06023B89 RID: 146313 RVA: 0x0098A22F File Offset: 0x0098842F
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FoliageSoftInteraction_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FoliageSoftInteraction_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170047FC RID: 18428
		// (get) Token: 0x06023B8A RID: 146314 RVA: 0x0098A244 File Offset: 0x00988444
		// (set) Token: 0x06023B8B RID: 146315 RVA: 0x0098A258 File Offset: 0x00988458
		public unsafe AActor TestActor
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FoliageSoftInteraction_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FoliageSoftInteraction_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x170047FD RID: 18429
		// (get) Token: 0x06023B8C RID: 146316 RVA: 0x0098A26D File Offset: 0x0098846D
		// (set) Token: 0x06023B8D RID: 146317 RVA: 0x0098A281 File Offset: 0x00988481
		public unsafe FVector PlayerPos
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FoliageSoftInteraction_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FoliageSoftInteraction_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x170047FE RID: 18430
		// (get) Token: 0x06023B8E RID: 146318 RVA: 0x0098A296 File Offset: 0x00988496
		// (set) Token: 0x06023B8F RID: 146319 RVA: 0x0098A2A6 File Offset: 0x009884A6
		public unsafe float Delta_Seconds
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FoliageSoftInteraction_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FoliageSoftInteraction_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x170047FF RID: 18431
		// (get) Token: 0x06023B90 RID: 146320 RVA: 0x0098A2B7 File Offset: 0x009884B7
		// (set) Token: 0x06023B91 RID: 146321 RVA: 0x0098A2CB File Offset: 0x009884CB
		public unsafe UMaterialParameterCollection Global_MPC
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialParameterCollection>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FoliageSoftInteraction_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FoliageSoftInteraction_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x17004800 RID: 18432
		// (get) Token: 0x06023B92 RID: 146322 RVA: 0x0098A2E0 File Offset: 0x009884E0
		// (set) Token: 0x06023B93 RID: 146323 RVA: 0x0098A2F4 File Offset: 0x009884F4
		public unsafe UMaterialParameterCollection Scene_MPC
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialParameterCollection>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FoliageSoftInteraction_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FoliageSoftInteraction_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x17004801 RID: 18433
		// (get) Token: 0x06023B94 RID: 146324 RVA: 0x0098A309 File Offset: 0x00988509
		// (set) Token: 0x06023B95 RID: 146325 RVA: 0x0098A319 File Offset: 0x00988519
		public unsafe int OtherCharacterCount
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FoliageSoftInteraction_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FoliageSoftInteraction_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17004802 RID: 18434
		// (get) Token: 0x06023B96 RID: 146326 RVA: 0x0098A32A File Offset: 0x0098852A
		// (set) Token: 0x06023B97 RID: 146327 RVA: 0x0098A33A File Offset: 0x0098853A
		public unsafe bool DisablePartnerInteraction
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FoliageSoftInteraction_C.__PropertyOffset_9) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FoliageSoftInteraction_C.__PropertyOffset_9) = (value ? 1 : 0);
			}
		}

		// Token: 0x06023B98 RID: 146328 RVA: 0x0098A34C File Offset: 0x0098854C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void CalcTexCoord(FVectorDouble MainPlayerPos, FVectorDouble OtherPlayerPos, float InteractionSize, ref FVector2D TexCoord)
		{
			BP_FoliageSoftInteraction_C.__CalcTexCoord_FunctionParams* ptr = stackalloc BP_FoliageSoftInteraction_C.__CalcTexCoord_FunctionParams[(UIntPtr)191] + 15L / (long)sizeof(BP_FoliageSoftInteraction_C.__CalcTexCoord_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FoliageSoftInteraction_C.__CalcTexCoord_NativeFunctionPtr, (void*)ptr, 1);
			ptr->MainPlayerPos = MainPlayerPos;
			ptr->OtherPlayerPos = OtherPlayerPos;
			ptr->InteractionSize = InteractionSize;
			ptr->TexCoord = TexCoord;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FoliageSoftInteraction_C.__CalcTexCoord_NativeFunctionPtr, (void*)ptr);
			TexCoord = ptr->TexCoord;
		}

		// Token: 0x06023B99 RID: 146329 RVA: 0x0098A3BD File Offset: 0x009885BD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FoliageSoftInteraction_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06023B9A RID: 146330 RVA: 0x0098A3D1 File Offset: 0x009885D1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_FoliageSoftInteraction_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06023B9B RID: 146331 RVA: 0x0098A3E8 File Offset: 0x009885E8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_FoliageSoftInteraction_C.__EditorTick_FunctionParams* ptr = stackalloc BP_FoliageSoftInteraction_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_FoliageSoftInteraction_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FoliageSoftInteraction_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FoliageSoftInteraction_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06023B9C RID: 146332 RVA: 0x0098A430 File Offset: 0x00988630
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_FoliageSoftInteraction_C.__EditorTick_FunctionParams* ptr = stackalloc BP_FoliageSoftInteraction_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_FoliageSoftInteraction_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FoliageSoftInteraction_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_FoliageSoftInteraction_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023B9D RID: 146333 RVA: 0x0098A478 File Offset: 0x00988678
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_FoliageSoftInteraction_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_FoliageSoftInteraction_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_FoliageSoftInteraction_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FoliageSoftInteraction_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FoliageSoftInteraction_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06023B9E RID: 146334 RVA: 0x0098A4C0 File Offset: 0x009886C0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_FoliageSoftInteraction_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_FoliageSoftInteraction_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_FoliageSoftInteraction_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FoliageSoftInteraction_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_FoliageSoftInteraction_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023B9F RID: 146335 RVA: 0x0098A507 File Offset: 0x00988707
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FoliageSoftInteraction_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06023BA0 RID: 146336 RVA: 0x0098A51B File Offset: 0x0098871B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_FoliageSoftInteraction_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06023BA1 RID: 146337 RVA: 0x0098A530 File Offset: 0x00988730
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_FoliageSoftInteraction(int EntryPoint)
		{
			BP_FoliageSoftInteraction_C.__ExecuteUbergraph_BP_FoliageSoftInteraction_FunctionParams* ptr = stackalloc BP_FoliageSoftInteraction_C.__ExecuteUbergraph_BP_FoliageSoftInteraction_FunctionParams[(UIntPtr)103] + 15L / (long)sizeof(BP_FoliageSoftInteraction_C.__ExecuteUbergraph_BP_FoliageSoftInteraction_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FoliageSoftInteraction_C.__ExecuteUbergraph_BP_FoliageSoftInteraction_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_FoliageSoftInteraction_C.__ExecuteUbergraph_BP_FoliageSoftInteraction_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023BA2 RID: 146338 RVA: 0x0098A577 File Offset: 0x00988777
		protected BP_FoliageSoftInteraction_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401237B RID: 74619
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/LongGrass/BP_FoliageSoftInteraction.BP_FoliageSoftInteraction_C";

		// Token: 0x0401237C RID: 74620
		private static IntPtr _ClassPtr;

		// Token: 0x0401237D RID: 74621
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401237E RID: 74622
		internal static int __PropertyOffset_0;

		// Token: 0x0401237F RID: 74623
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04012380 RID: 74624
		internal static int __PropertyOffset_1;

		// Token: 0x04012381 RID: 74625
		internal static int __PropertyOffset_2;

		// Token: 0x04012382 RID: 74626
		internal static int __PropertyOffset_3;

		// Token: 0x04012383 RID: 74627
		internal static int __PropertyOffset_4;

		// Token: 0x04012384 RID: 74628
		internal static int __PropertyOffset_5;

		// Token: 0x04012385 RID: 74629
		internal static int __PropertyOffset_6;

		// Token: 0x04012386 RID: 74630
		internal static int __PropertyOffset_7;

		// Token: 0x04012387 RID: 74631
		internal static int __PropertyOffset_8;

		// Token: 0x04012388 RID: 74632
		internal static int __PropertyOffset_9;

		// Token: 0x04012389 RID: 74633
		private static IntPtr __CalcTexCoord_NativeFunctionPtr;

		// Token: 0x0401238A RID: 74634
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0401238B RID: 74635
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x0401238C RID: 74636
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0401238D RID: 74637
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0401238E RID: 74638
		private static IntPtr __ExecuteUbergraph_BP_FoliageSoftInteraction_NativeFunctionPtr;

		// Token: 0x02009D25 RID: 40229
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 176)]
		protected ref struct __CalcTexCoord_FunctionParams
		{
			// Token: 0x040326E2 RID: 206562
			[FieldOffset(0)]
			public FVectorDouble MainPlayerPos;

			// Token: 0x040326E3 RID: 206563
			[FieldOffset(24)]
			public FVectorDouble OtherPlayerPos;

			// Token: 0x040326E4 RID: 206564
			[FieldOffset(48)]
			public float InteractionSize;

			// Token: 0x040326E5 RID: 206565
			[FieldOffset(52)]
			public FVector2D TexCoord;
		}

		// Token: 0x02009D26 RID: 40230
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x040326E6 RID: 206566
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009D27 RID: 40231
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x040326E7 RID: 206567
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009D28 RID: 40232
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 88)]
		protected ref struct __ExecuteUbergraph_BP_FoliageSoftInteraction_FunctionParams
		{
			// Token: 0x040326E8 RID: 206568
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
