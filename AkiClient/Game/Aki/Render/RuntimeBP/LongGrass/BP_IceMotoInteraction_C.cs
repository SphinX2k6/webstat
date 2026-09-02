using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.LongGrass
{
	// Token: 0x02003C5D RID: 15453
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/LongGrass/BP_IceMotoInteraction.BP_IceMotoInteraction_C")]
	[UnrealStructLayout(1544, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1540)]
	public class BP_IceMotoInteraction_C : AKuroBPActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06023BA3 RID: 146339 RVA: 0x0098A580 File Offset: 0x00988780
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_IceMotoInteraction_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/LongGrass/BP_IceMotoInteraction.BP_IceMotoInteraction_C");
			}
			return BP_IceMotoInteraction_C._ClassPtr;
		}

		// Token: 0x06023BA4 RID: 146340 RVA: 0x0098A5A4 File Offset: 0x009887A4
		public BP_IceMotoInteraction_C() : this(BuiltinUtils.AllocNativeUObject(BP_IceMotoInteraction_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06023BA5 RID: 146341 RVA: 0x0098A5CC File Offset: 0x009887CC
		[NullableContext(1)]
		public BP_IceMotoInteraction_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_IceMotoInteraction_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004803 RID: 18435
		// (get) Token: 0x06023BA6 RID: 146342 RVA: 0x0098A600 File Offset: 0x00988800
		// (set) Token: 0x06023BA7 RID: 146343 RVA: 0x0098A639 File Offset: 0x00988839
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_IceMotoInteraction_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_IceMotoInteraction_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004804 RID: 18436
		// (get) Token: 0x06023BA8 RID: 146344 RVA: 0x0098A65A File Offset: 0x0098885A
		// (set) Token: 0x06023BA9 RID: 146345 RVA: 0x0098A66E File Offset: 0x0098886E
		public unsafe UStaticMeshComponent MotoIce
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_IceMotoInteraction_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_IceMotoInteraction_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17004805 RID: 18437
		// (get) Token: 0x06023BAA RID: 146346 RVA: 0x0098A683 File Offset: 0x00988883
		// (set) Token: 0x06023BAB RID: 146347 RVA: 0x0098A697 File Offset: 0x00988897
		public unsafe UBoxComponent AreaBox
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_IceMotoInteraction_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_IceMotoInteraction_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17004806 RID: 18438
		// (get) Token: 0x06023BAC RID: 146348 RVA: 0x0098A6AC File Offset: 0x009888AC
		// (set) Token: 0x06023BAD RID: 146349 RVA: 0x0098A6C0 File Offset: 0x009888C0
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_IceMotoInteraction_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_IceMotoInteraction_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17004807 RID: 18439
		// (get) Token: 0x06023BAE RID: 146350 RVA: 0x0098A6D5 File Offset: 0x009888D5
		// (set) Token: 0x06023BAF RID: 146351 RVA: 0x0098A6E9 File Offset: 0x009888E9
		public unsafe UTextureRenderTarget2D RT_PosA
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_IceMotoInteraction_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_IceMotoInteraction_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17004808 RID: 18440
		// (get) Token: 0x06023BB0 RID: 146352 RVA: 0x0098A6FE File Offset: 0x009888FE
		// (set) Token: 0x06023BB1 RID: 146353 RVA: 0x0098A712 File Offset: 0x00988912
		public unsafe UTextureRenderTarget2D RT_PosB
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_IceMotoInteraction_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_IceMotoInteraction_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17004809 RID: 18441
		// (get) Token: 0x06023BB2 RID: 146354 RVA: 0x0098A727 File Offset: 0x00988927
		// (set) Token: 0x06023BB3 RID: 146355 RVA: 0x0098A73B File Offset: 0x0098893B
		public unsafe UMaterialInstanceDynamic MID_UpdatePos
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_IceMotoInteraction_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_IceMotoInteraction_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x1700480A RID: 18442
		// (get) Token: 0x06023BB4 RID: 146356 RVA: 0x0098A750 File Offset: 0x00988950
		// (set) Token: 0x06023BB5 RID: 146357 RVA: 0x0098A764 File Offset: 0x00988964
		public unsafe UMaterialInstanceDynamic MID_StampPos
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_IceMotoInteraction_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_IceMotoInteraction_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x1700480B RID: 18443
		// (get) Token: 0x06023BB6 RID: 146358 RVA: 0x0098A779 File Offset: 0x00988979
		// (set) Token: 0x06023BB7 RID: 146359 RVA: 0x0098A789 File Offset: 0x00988989
		public unsafe float InteractionSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_IceMotoInteraction_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_IceMotoInteraction_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x1700480C RID: 18444
		// (get) Token: 0x06023BB8 RID: 146360 RVA: 0x0098A79A File Offset: 0x0098899A
		// (set) Token: 0x06023BB9 RID: 146361 RVA: 0x0098A7AA File Offset: 0x009889AA
		public unsafe float Attenuation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_IceMotoInteraction_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_IceMotoInteraction_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x1700480D RID: 18445
		// (get) Token: 0x06023BBA RID: 146362 RVA: 0x0098A7BB File Offset: 0x009889BB
		// (set) Token: 0x06023BBB RID: 146363 RVA: 0x0098A7CF File Offset: 0x009889CF
		public unsafe FLinearColor Clear_Color
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_IceMotoInteraction_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_IceMotoInteraction_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x1700480E RID: 18446
		// (get) Token: 0x06023BBC RID: 146364 RVA: 0x0098A7E4 File Offset: 0x009889E4
		// (set) Token: 0x06023BBD RID: 146365 RVA: 0x0098A7F8 File Offset: 0x009889F8
		public unsafe FVectorDouble PlayerPixelPos_Curr
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_IceMotoInteraction_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_IceMotoInteraction_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x1700480F RID: 18447
		// (get) Token: 0x06023BBE RID: 146366 RVA: 0x0098A80D File Offset: 0x00988A0D
		// (set) Token: 0x06023BBF RID: 146367 RVA: 0x0098A821 File Offset: 0x00988A21
		public unsafe FVectorDouble PlayerPixelPos_Prev
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_IceMotoInteraction_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_IceMotoInteraction_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17004810 RID: 18448
		// (get) Token: 0x06023BC0 RID: 146368 RVA: 0x0098A836 File Offset: 0x00988A36
		// (set) Token: 0x06023BC1 RID: 146369 RVA: 0x0098A84A File Offset: 0x00988A4A
		public unsafe FVectorDouble CurrFrontWheel
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_IceMotoInteraction_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_IceMotoInteraction_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17004811 RID: 18449
		// (get) Token: 0x06023BC2 RID: 146370 RVA: 0x0098A85F File Offset: 0x00988A5F
		// (set) Token: 0x06023BC3 RID: 146371 RVA: 0x0098A873 File Offset: 0x00988A73
		public unsafe FVectorDouble CurrBackWheel
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_IceMotoInteraction_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_IceMotoInteraction_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17004812 RID: 18450
		// (get) Token: 0x06023BC4 RID: 146372 RVA: 0x0098A888 File Offset: 0x00988A88
		// (set) Token: 0x06023BC5 RID: 146373 RVA: 0x0098A89C File Offset: 0x00988A9C
		public unsafe FVectorDouble PrevFrontWheel
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_IceMotoInteraction_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_IceMotoInteraction_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17004813 RID: 18451
		// (get) Token: 0x06023BC6 RID: 146374 RVA: 0x0098A8B1 File Offset: 0x00988AB1
		// (set) Token: 0x06023BC7 RID: 146375 RVA: 0x0098A8C5 File Offset: 0x00988AC5
		public unsafe FVectorDouble PrevBackWheel
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_IceMotoInteraction_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_IceMotoInteraction_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x17004814 RID: 18452
		// (get) Token: 0x06023BC8 RID: 146376 RVA: 0x0098A8DA File Offset: 0x00988ADA
		// (set) Token: 0x06023BC9 RID: 146377 RVA: 0x0098A8EA File Offset: 0x00988AEA
		public unsafe float BulletRadius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_IceMotoInteraction_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_IceMotoInteraction_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x06023BCA RID: 146378 RVA: 0x0098A8FC File Offset: 0x00988AFC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void CalcTexCoord(FVectorDouble MainPlayerPos, FVectorDouble OtherPlayerPos, float InteractionSize, ref float TexCoord_X, ref float TexCoord_Y)
		{
			BP_IceMotoInteraction_C.__CalcTexCoord_FunctionParams* ptr = stackalloc BP_IceMotoInteraction_C.__CalcTexCoord_FunctionParams[(UIntPtr)183] + 15L / (long)sizeof(BP_IceMotoInteraction_C.__CalcTexCoord_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_IceMotoInteraction_C.__CalcTexCoord_NativeFunctionPtr, (void*)ptr, 1);
			ptr->MainPlayerPos = MainPlayerPos;
			ptr->OtherPlayerPos = OtherPlayerPos;
			ptr->InteractionSize = InteractionSize;
			ptr->TexCoord_X = TexCoord_X;
			ptr->TexCoord_Y = TexCoord_Y;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_IceMotoInteraction_C.__CalcTexCoord_NativeFunctionPtr, (void*)ptr);
			TexCoord_X = ptr->TexCoord_X;
			TexCoord_Y = ptr->TexCoord_Y;
		}

		// Token: 0x06023BCB RID: 146379 RVA: 0x0098A978 File Offset: 0x00988B78
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void CalcDistance2D(FVectorDouble V1, FVectorDouble V2, ref double Distance)
		{
			BP_IceMotoInteraction_C.__CalcDistance2D_FunctionParams* ptr = stackalloc BP_IceMotoInteraction_C.__CalcDistance2D_FunctionParams[(UIntPtr)167] + 15L / (long)sizeof(BP_IceMotoInteraction_C.__CalcDistance2D_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_IceMotoInteraction_C.__CalcDistance2D_NativeFunctionPtr, (void*)ptr, 1);
			ptr->V1 = V1;
			ptr->V2 = V2;
			ptr->Distance = Distance;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_IceMotoInteraction_C.__CalcDistance2D_NativeFunctionPtr, (void*)ptr);
			Distance = ptr->Distance;
		}

		// Token: 0x06023BCC RID: 146380 RVA: 0x0098A9D8 File Offset: 0x00988BD8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void ClearRT()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_IceMotoInteraction_C.__ClearRT_NativeFunctionPtr, null);
		}

		// Token: 0x06023BCD RID: 146381 RVA: 0x0098A9EC File Offset: 0x00988BEC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Create_MID()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_IceMotoInteraction_C.__Create_MID_NativeFunctionPtr, null);
		}

		// Token: 0x06023BCE RID: 146382 RVA: 0x0098AA00 File Offset: 0x00988C00
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_IceMotoInteraction_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06023BCF RID: 146383 RVA: 0x0098AA14 File Offset: 0x00988C14
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_IceMotoInteraction_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06023BD0 RID: 146384 RVA: 0x0098AA2C File Offset: 0x00988C2C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_IceMotoInteraction_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_IceMotoInteraction_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_IceMotoInteraction_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_IceMotoInteraction_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_IceMotoInteraction_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06023BD1 RID: 146385 RVA: 0x0098AA74 File Offset: 0x00988C74
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_IceMotoInteraction_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_IceMotoInteraction_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_IceMotoInteraction_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_IceMotoInteraction_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_IceMotoInteraction_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023BD2 RID: 146386 RVA: 0x0098AABB File Offset: 0x00988CBB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void ClearRenderTarget()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_IceMotoInteraction_C.__ClearRenderTarget_NativeFunctionPtr, null);
		}

		// Token: 0x06023BD3 RID: 146387 RVA: 0x0098AACF File Offset: 0x00988CCF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void PrintPosition()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_IceMotoInteraction_C.__PrintPosition_NativeFunctionPtr, null);
		}

		// Token: 0x06023BD4 RID: 146388 RVA: 0x0098AAE4 File Offset: 0x00988CE4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_IceMotoInteraction(int EntryPoint)
		{
			BP_IceMotoInteraction_C.__ExecuteUbergraph_BP_IceMotoInteraction_FunctionParams* ptr = stackalloc BP_IceMotoInteraction_C.__ExecuteUbergraph_BP_IceMotoInteraction_FunctionParams[(UIntPtr)887] + 15L / (long)sizeof(BP_IceMotoInteraction_C.__ExecuteUbergraph_BP_IceMotoInteraction_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_IceMotoInteraction_C.__ExecuteUbergraph_BP_IceMotoInteraction_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_IceMotoInteraction_C.__ExecuteUbergraph_BP_IceMotoInteraction_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023BD5 RID: 146389 RVA: 0x0098AB2E File Offset: 0x00988D2E
		protected BP_IceMotoInteraction_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401238F RID: 74639
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/LongGrass/BP_IceMotoInteraction.BP_IceMotoInteraction_C";

		// Token: 0x04012390 RID: 74640
		private static IntPtr _ClassPtr;

		// Token: 0x04012391 RID: 74641
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04012392 RID: 74642
		internal static int __PropertyOffset_0;

		// Token: 0x04012393 RID: 74643
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04012394 RID: 74644
		internal static int __PropertyOffset_1;

		// Token: 0x04012395 RID: 74645
		internal static int __PropertyOffset_2;

		// Token: 0x04012396 RID: 74646
		internal static int __PropertyOffset_3;

		// Token: 0x04012397 RID: 74647
		internal static int __PropertyOffset_4;

		// Token: 0x04012398 RID: 74648
		internal static int __PropertyOffset_5;

		// Token: 0x04012399 RID: 74649
		internal static int __PropertyOffset_6;

		// Token: 0x0401239A RID: 74650
		internal static int __PropertyOffset_7;

		// Token: 0x0401239B RID: 74651
		internal static int __PropertyOffset_8;

		// Token: 0x0401239C RID: 74652
		internal static int __PropertyOffset_9;

		// Token: 0x0401239D RID: 74653
		internal static int __PropertyOffset_10;

		// Token: 0x0401239E RID: 74654
		internal static int __PropertyOffset_11;

		// Token: 0x0401239F RID: 74655
		internal static int __PropertyOffset_12;

		// Token: 0x040123A0 RID: 74656
		internal static int __PropertyOffset_13;

		// Token: 0x040123A1 RID: 74657
		internal static int __PropertyOffset_14;

		// Token: 0x040123A2 RID: 74658
		internal static int __PropertyOffset_15;

		// Token: 0x040123A3 RID: 74659
		internal static int __PropertyOffset_16;

		// Token: 0x040123A4 RID: 74660
		internal static int __PropertyOffset_17;

		// Token: 0x040123A5 RID: 74661
		private static IntPtr __CalcTexCoord_NativeFunctionPtr;

		// Token: 0x040123A6 RID: 74662
		private static IntPtr __CalcDistance2D_NativeFunctionPtr;

		// Token: 0x040123A7 RID: 74663
		private static IntPtr __ClearRT_NativeFunctionPtr;

		// Token: 0x040123A8 RID: 74664
		private static IntPtr __Create_MID_NativeFunctionPtr;

		// Token: 0x040123A9 RID: 74665
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x040123AA RID: 74666
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x040123AB RID: 74667
		private static IntPtr __ClearRenderTarget_NativeFunctionPtr;

		// Token: 0x040123AC RID: 74668
		private static IntPtr __PrintPosition_NativeFunctionPtr;

		// Token: 0x040123AD RID: 74669
		private static IntPtr __ExecuteUbergraph_BP_IceMotoInteraction_NativeFunctionPtr;

		// Token: 0x02009D29 RID: 40233
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 168)]
		protected ref struct __CalcTexCoord_FunctionParams
		{
			// Token: 0x040326E9 RID: 206569
			[FieldOffset(0)]
			public FVectorDouble MainPlayerPos;

			// Token: 0x040326EA RID: 206570
			[FieldOffset(24)]
			public FVectorDouble OtherPlayerPos;

			// Token: 0x040326EB RID: 206571
			[FieldOffset(48)]
			public float InteractionSize;

			// Token: 0x040326EC RID: 206572
			[FieldOffset(52)]
			public float TexCoord_X;

			// Token: 0x040326ED RID: 206573
			[FieldOffset(56)]
			public float TexCoord_Y;
		}

		// Token: 0x02009D2A RID: 40234
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 152)]
		protected ref struct __CalcDistance2D_FunctionParams
		{
			// Token: 0x040326EE RID: 206574
			[FieldOffset(0)]
			public FVectorDouble V1;

			// Token: 0x040326EF RID: 206575
			[FieldOffset(24)]
			public FVectorDouble V2;

			// Token: 0x040326F0 RID: 206576
			[FieldOffset(48)]
			public double Distance;
		}

		// Token: 0x02009D2B RID: 40235
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x040326F1 RID: 206577
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009D2C RID: 40236
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 872)]
		protected ref struct __ExecuteUbergraph_BP_IceMotoInteraction_FunctionParams
		{
			// Token: 0x040326F2 RID: 206578
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
