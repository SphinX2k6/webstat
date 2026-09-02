using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Render.RuntimeBP.GI;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.VolumeGroupFade
{
	// Token: 0x02003B5C RID: 15196
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/VolumeGroupFade/BP_LightGroup_SyncToMainLight.BP_LightGroup_SyncToMainLight_C")]
	[UnrealStructLayout(1480, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1477)]
	public class BP_LightGroup_SyncToMainLight_C : AKuroBPActor, IUnrealUObject, IUnrealObject, IInterface_KuroLightBP, IUnrealNativeInterface, IUnrealInterface
	{
		// Token: 0x06021349 RID: 136009 RVA: 0x0094304C File Offset: 0x0094124C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_LightGroup_SyncToMainLight_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/VolumeGroupFade/BP_LightGroup_SyncToMainLight.BP_LightGroup_SyncToMainLight_C");
			}
			return BP_LightGroup_SyncToMainLight_C._ClassPtr;
		}

		// Token: 0x0602134A RID: 136010 RVA: 0x00943070 File Offset: 0x00941270
		int IInterface_KuroLightBP.InterfaceOffset()
		{
			return BP_LightGroup_SyncToMainLight_C.__InterfaceOffset_IInterface_KuroLightBP;
		}

		// Token: 0x0602134B RID: 136011 RVA: 0x00943078 File Offset: 0x00941278
		public BP_LightGroup_SyncToMainLight_C() : this(BuiltinUtils.AllocNativeUObject(BP_LightGroup_SyncToMainLight_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602134C RID: 136012 RVA: 0x009430A0 File Offset: 0x009412A0
		public BP_LightGroup_SyncToMainLight_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_LightGroup_SyncToMainLight_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170039B6 RID: 14774
		// (get) Token: 0x0602134D RID: 136013 RVA: 0x009430D4 File Offset: 0x009412D4
		// (set) Token: 0x0602134E RID: 136014 RVA: 0x0094310D File Offset: 0x0094130D
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_LightGroup_SyncToMainLight_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_LightGroup_SyncToMainLight_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170039B7 RID: 14775
		// (get) Token: 0x0602134F RID: 136015 RVA: 0x0094312E File Offset: 0x0094132E
		// (set) Token: 0x06021350 RID: 136016 RVA: 0x00943142 File Offset: 0x00941342
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LightGroup_SyncToMainLight_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LightGroup_SyncToMainLight_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170039B8 RID: 14776
		// (get) Token: 0x06021351 RID: 136017 RVA: 0x00943157 File Offset: 0x00941357
		// (set) Token: 0x06021352 RID: 136018 RVA: 0x00943167 File Offset: 0x00941367
		public unsafe bool bEditorTick
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LightGroup_SyncToMainLight_C.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LightGroup_SyncToMainLight_C.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x170039B9 RID: 14777
		// (get) Token: 0x06021353 RID: 136019 RVA: 0x00943178 File Offset: 0x00941378
		// (set) Token: 0x06021354 RID: 136020 RVA: 0x0094318C File Offset: 0x0094138C
		[Nullable(2)]
		public unsafe BP_GlobalGI_C CachedGI
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_GlobalGI_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LightGroup_SyncToMainLight_C.__PropertyOffset_3);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LightGroup_SyncToMainLight_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x170039BA RID: 14778
		// (get) Token: 0x06021355 RID: 136021 RVA: 0x009431A4 File Offset: 0x009413A4
		// (set) Token: 0x06021356 RID: 136022 RVA: 0x009431DD File Offset: 0x009413DD
		public TMap<ALight, float> LightInstensityMap
		{
			get
			{
				base.FastCheckIsValid();
				TMap<ALight, float> result;
				if ((result = this._LightInstensityMap) == null)
				{
					result = (this._LightInstensityMap = new TMap<ALight, float>(base.NativePtr + (IntPtr)BP_LightGroup_SyncToMainLight_C.__PropertyOffset_4, this));
				}
				return result;
			}
			set
			{
				this.LightInstensityMap.CopyAssign(value);
			}
		}

		// Token: 0x170039BB RID: 14779
		// (get) Token: 0x06021357 RID: 136023 RVA: 0x009431EB File Offset: 0x009413EB
		// (set) Token: 0x06021358 RID: 136024 RVA: 0x009431FB File Offset: 0x009413FB
		public unsafe float TargetMainLightIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LightGroup_SyncToMainLight_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LightGroup_SyncToMainLight_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x170039BC RID: 14780
		// (get) Token: 0x06021359 RID: 136025 RVA: 0x0094320C File Offset: 0x0094140C
		// (set) Token: 0x0602135A RID: 136026 RVA: 0x0094321C File Offset: 0x0094141C
		public unsafe int MaxProcessCount
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LightGroup_SyncToMainLight_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LightGroup_SyncToMainLight_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x170039BD RID: 14781
		// (get) Token: 0x0602135B RID: 136027 RVA: 0x0094322D File Offset: 0x0094142D
		// (set) Token: 0x0602135C RID: 136028 RVA: 0x0094323D File Offset: 0x0094143D
		public unsafe int NowProcessIndex
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LightGroup_SyncToMainLight_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LightGroup_SyncToMainLight_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x170039BE RID: 14782
		// (get) Token: 0x0602135D RID: 136029 RVA: 0x0094324E File Offset: 0x0094144E
		// (set) Token: 0x0602135E RID: 136030 RVA: 0x00943262 File Offset: 0x00941462
		public unsafe FLinearColor TargetMainLightColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LightGroup_SyncToMainLight_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LightGroup_SyncToMainLight_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x170039BF RID: 14783
		// (get) Token: 0x0602135F RID: 136031 RVA: 0x00943278 File Offset: 0x00941478
		// (set) Token: 0x06021360 RID: 136032 RVA: 0x009432B1 File Offset: 0x009414B1
		public TArray<ALight> Keys
		{
			get
			{
				base.FastCheckIsValid();
				TArray<ALight> result;
				if ((result = this._Keys) == null)
				{
					result = (this._Keys = new TArray<ALight>(base.NativePtr + (IntPtr)BP_LightGroup_SyncToMainLight_C.__PropertyOffset_9, this));
				}
				return result;
			}
			set
			{
				this.Keys.CopyAssign(value);
			}
		}

		// Token: 0x170039C0 RID: 14784
		// (get) Token: 0x06021361 RID: 136033 RVA: 0x009432BF File Offset: 0x009414BF
		// (set) Token: 0x06021362 RID: 136034 RVA: 0x009432CF File Offset: 0x009414CF
		public unsafe int MapLength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LightGroup_SyncToMainLight_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LightGroup_SyncToMainLight_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x170039C1 RID: 14785
		// (get) Token: 0x06021363 RID: 136035 RVA: 0x009432E0 File Offset: 0x009414E0
		// (set) Token: 0x06021364 RID: 136036 RVA: 0x009432F0 File Offset: 0x009414F0
		public unsafe bool bLightNotChange
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LightGroup_SyncToMainLight_C.__PropertyOffset_11) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LightGroup_SyncToMainLight_C.__PropertyOffset_11) = (value ? 1 : 0);
			}
		}

		// Token: 0x170039C2 RID: 14786
		// (get) Token: 0x06021365 RID: 136037 RVA: 0x00943301 File Offset: 0x00941501
		// (set) Token: 0x06021366 RID: 136038 RVA: 0x00943311 File Offset: 0x00941511
		public unsafe float NightMulti
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LightGroup_SyncToMainLight_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LightGroup_SyncToMainLight_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x170039C3 RID: 14787
		// (get) Token: 0x06021367 RID: 136039 RVA: 0x00943322 File Offset: 0x00941522
		// (set) Token: 0x06021368 RID: 136040 RVA: 0x00943332 File Offset: 0x00941532
		public unsafe bool TargetBNight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LightGroup_SyncToMainLight_C.__PropertyOffset_13) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LightGroup_SyncToMainLight_C.__PropertyOffset_13) = (value ? 1 : 0);
			}
		}

		// Token: 0x06021369 RID: 136041 RVA: 0x00943344 File Offset: 0x00941544
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual int GetPlacementSortOrder()
		{
			BP_LightGroup_SyncToMainLight_C.__GetPlacementSortOrder_FunctionParams* ptr = stackalloc BP_LightGroup_SyncToMainLight_C.__GetPlacementSortOrder_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_LightGroup_SyncToMainLight_C.__GetPlacementSortOrder_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LightGroup_SyncToMainLight_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LightGroup_SyncToMainLight_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr);
			return ptr->__Result;
		}

		// Token: 0x0602136A RID: 136042 RVA: 0x0094338C File Offset: 0x0094158C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual int GetPlacementSortOrder_Implementation()
		{
			BP_LightGroup_SyncToMainLight_C.__GetPlacementSortOrder_FunctionParams* ptr = stackalloc BP_LightGroup_SyncToMainLight_C.__GetPlacementSortOrder_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_LightGroup_SyncToMainLight_C.__GetPlacementSortOrder_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LightGroup_SyncToMainLight_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_LightGroup_SyncToMainLight_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr, 0);
			return ptr->__Result;
		}

		// Token: 0x0602136B RID: 136043 RVA: 0x009433D2 File Offset: 0x009415D2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Update()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LightGroup_SyncToMainLight_C.__Update_NativeFunctionPtr, null);
		}

		// Token: 0x0602136C RID: 136044 RVA: 0x009433E6 File Offset: 0x009415E6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LightGroup_SyncToMainLight_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0602136D RID: 136045 RVA: 0x009433FA File Offset: 0x009415FA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_LightGroup_SyncToMainLight_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602136E RID: 136046 RVA: 0x0094340F File Offset: 0x0094160F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EditorTick()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LightGroup_SyncToMainLight_C.__EditorTick_NativeFunctionPtr, null);
		}

		// Token: 0x0602136F RID: 136047 RVA: 0x00943423 File Offset: 0x00941623
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LightGroup_SyncToMainLight_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06021370 RID: 136048 RVA: 0x00943437 File Offset: 0x00941637
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_LightGroup_SyncToMainLight_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06021371 RID: 136049 RVA: 0x0094344C File Offset: 0x0094164C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void TimeSlicedTick()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LightGroup_SyncToMainLight_C.__TimeSlicedTick_NativeFunctionPtr, null);
		}

		// Token: 0x06021372 RID: 136050 RVA: 0x00943460 File Offset: 0x00941660
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_LightGroup_SyncToMainLight_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_LightGroup_SyncToMainLight_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_LightGroup_SyncToMainLight_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LightGroup_SyncToMainLight_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LightGroup_SyncToMainLight_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021373 RID: 136051 RVA: 0x009434A8 File Offset: 0x009416A8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_LightGroup_SyncToMainLight_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_LightGroup_SyncToMainLight_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_LightGroup_SyncToMainLight_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LightGroup_SyncToMainLight_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_LightGroup_SyncToMainLight_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021374 RID: 136052 RVA: 0x009434F0 File Offset: 0x009416F0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_LightGroup_SyncToMainLight(int EntryPoint)
		{
			BP_LightGroup_SyncToMainLight_C.__ExecuteUbergraph_BP_LightGroup_SyncToMainLight_FunctionParams* ptr = stackalloc BP_LightGroup_SyncToMainLight_C.__ExecuteUbergraph_BP_LightGroup_SyncToMainLight_FunctionParams[(UIntPtr)71] + 15L / (long)sizeof(BP_LightGroup_SyncToMainLight_C.__ExecuteUbergraph_BP_LightGroup_SyncToMainLight_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LightGroup_SyncToMainLight_C.__ExecuteUbergraph_BP_LightGroup_SyncToMainLight_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_LightGroup_SyncToMainLight_C.__ExecuteUbergraph_BP_LightGroup_SyncToMainLight_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021375 RID: 136053 RVA: 0x00943537 File Offset: 0x00941737
		protected BP_LightGroup_SyncToMainLight_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04010B25 RID: 68389
		internal static int __InterfaceOffset_IInterface_KuroLightBP;

		// Token: 0x04010B26 RID: 68390
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/VolumeGroupFade/BP_LightGroup_SyncToMainLight.BP_LightGroup_SyncToMainLight_C";

		// Token: 0x04010B27 RID: 68391
		private static IntPtr _ClassPtr;

		// Token: 0x04010B28 RID: 68392
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04010B29 RID: 68393
		internal static int __PropertyOffset_0;

		// Token: 0x04010B2A RID: 68394
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04010B2B RID: 68395
		internal static int __PropertyOffset_1;

		// Token: 0x04010B2C RID: 68396
		internal static int __PropertyOffset_2;

		// Token: 0x04010B2D RID: 68397
		internal static int __PropertyOffset_3;

		// Token: 0x04010B2E RID: 68398
		internal static int __PropertyOffset_4;

		// Token: 0x04010B2F RID: 68399
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<ALight, float> _LightInstensityMap;

		// Token: 0x04010B30 RID: 68400
		internal static int __PropertyOffset_5;

		// Token: 0x04010B31 RID: 68401
		internal static int __PropertyOffset_6;

		// Token: 0x04010B32 RID: 68402
		internal static int __PropertyOffset_7;

		// Token: 0x04010B33 RID: 68403
		internal static int __PropertyOffset_8;

		// Token: 0x04010B34 RID: 68404
		internal static int __PropertyOffset_9;

		// Token: 0x04010B35 RID: 68405
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<ALight> _Keys;

		// Token: 0x04010B36 RID: 68406
		internal static int __PropertyOffset_10;

		// Token: 0x04010B37 RID: 68407
		internal static int __PropertyOffset_11;

		// Token: 0x04010B38 RID: 68408
		internal static int __PropertyOffset_12;

		// Token: 0x04010B39 RID: 68409
		internal static int __PropertyOffset_13;

		// Token: 0x04010B3A RID: 68410
		private static IntPtr __GetPlacementSortOrder_NativeFunctionPtr;

		// Token: 0x04010B3B RID: 68411
		private static IntPtr __Update_NativeFunctionPtr;

		// Token: 0x04010B3C RID: 68412
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04010B3D RID: 68413
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x04010B3E RID: 68414
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04010B3F RID: 68415
		private static IntPtr __TimeSlicedTick_NativeFunctionPtr;

		// Token: 0x04010B40 RID: 68416
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04010B41 RID: 68417
		private static IntPtr __ExecuteUbergraph_BP_LightGroup_SyncToMainLight_NativeFunctionPtr;

		// Token: 0x02009A9D RID: 39581
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __GetPlacementSortOrder_FunctionParams
		{
			// Token: 0x04032202 RID: 205314
			[FieldOffset(0)]
			public int __Result;
		}

		// Token: 0x02009A9E RID: 39582
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032203 RID: 205315
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009A9F RID: 39583
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 56)]
		protected ref struct __ExecuteUbergraph_BP_LightGroup_SyncToMainLight_FunctionParams
		{
			// Token: 0x04032204 RID: 205316
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
