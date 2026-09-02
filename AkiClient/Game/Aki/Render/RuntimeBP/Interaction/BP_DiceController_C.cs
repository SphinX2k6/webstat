using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Interaction
{
	// Token: 0x02003C79 RID: 15481
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Interaction/BP_DiceController.BP_DiceController_C")]
	[UnrealStructLayout(1168, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1168)]
	public class BP_DiceController_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06023F88 RID: 147336 RVA: 0x009911A4 File Offset: 0x0098F3A4
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_DiceController_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Interaction/BP_DiceController.BP_DiceController_C");
			}
			return BP_DiceController_C._ClassPtr;
		}

		// Token: 0x06023F89 RID: 147337 RVA: 0x009911C8 File Offset: 0x0098F3C8
		public BP_DiceController_C() : this(BuiltinUtils.AllocNativeUObject(BP_DiceController_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06023F8A RID: 147338 RVA: 0x009911F0 File Offset: 0x0098F3F0
		public BP_DiceController_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_DiceController_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004951 RID: 18769
		// (get) Token: 0x06023F8B RID: 147339 RVA: 0x00991224 File Offset: 0x0098F424
		// (set) Token: 0x06023F8C RID: 147340 RVA: 0x0099125D File Offset: 0x0098F45D
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_DiceController_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_DiceController_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004952 RID: 18770
		// (get) Token: 0x06023F8D RID: 147341 RVA: 0x0099127E File Offset: 0x0098F47E
		// (set) Token: 0x06023F8E RID: 147342 RVA: 0x00991292 File Offset: 0x0098F492
		[Nullable(2)]
		public unsafe UStaticMeshComponent SM_Act_Pro_101AS
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DiceController_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DiceController_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17004953 RID: 18771
		// (get) Token: 0x06023F8F RID: 147343 RVA: 0x009912A7 File Offset: 0x0098F4A7
		// (set) Token: 0x06023F90 RID: 147344 RVA: 0x009912BB File Offset: 0x0098F4BB
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DiceController_C.__PropertyOffset_2);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DiceController_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17004954 RID: 18772
		// (get) Token: 0x06023F91 RID: 147345 RVA: 0x009912D0 File Offset: 0x0098F4D0
		// (set) Token: 0x06023F92 RID: 147346 RVA: 0x00991309 File Offset: 0x0098F509
		public TArray<UMaterialInstanceDynamic> DynamicMaterialInstance
		{
			get
			{
				base.FastCheckIsValid();
				TArray<UMaterialInstanceDynamic> result;
				if ((result = this._DynamicMaterialInstance) == null)
				{
					result = (this._DynamicMaterialInstance = new TArray<UMaterialInstanceDynamic>(base.NativePtr + (IntPtr)BP_DiceController_C.__PropertyOffset_3, this));
				}
				return result;
			}
			set
			{
				this.DynamicMaterialInstance.CopyAssign(value);
			}
		}

		// Token: 0x17004955 RID: 18773
		// (get) Token: 0x06023F93 RID: 147347 RVA: 0x00991317 File Offset: 0x0098F517
		// (set) Token: 0x06023F94 RID: 147348 RVA: 0x00991327 File Offset: 0x0098F527
		public unsafe float Speed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DiceController_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DiceController_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17004956 RID: 18774
		// (get) Token: 0x06023F95 RID: 147349 RVA: 0x00991338 File Offset: 0x0098F538
		// (set) Token: 0x06023F96 RID: 147350 RVA: 0x00991371 File Offset: 0x0098F571
		public TMap<FName, float> DicePoints
		{
			get
			{
				base.FastCheckIsValid();
				TMap<FName, float> result;
				if ((result = this._DicePoints) == null)
				{
					result = (this._DicePoints = new TMap<FName, float>(base.NativePtr + (IntPtr)BP_DiceController_C.__PropertyOffset_5, this));
				}
				return result;
			}
			set
			{
				this.DicePoints.CopyAssign(value);
			}
		}

		// Token: 0x17004957 RID: 18775
		// (get) Token: 0x06023F97 RID: 147351 RVA: 0x0099137F File Offset: 0x0098F57F
		// (set) Token: 0x06023F98 RID: 147352 RVA: 0x0099138F File Offset: 0x0098F58F
		public unsafe bool IsPlaying
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DiceController_C.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DiceController_C.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004958 RID: 18776
		// (get) Token: 0x06023F99 RID: 147353 RVA: 0x009913A0 File Offset: 0x0098F5A0
		// (set) Token: 0x06023F9A RID: 147354 RVA: 0x009913B0 File Offset: 0x0098F5B0
		public unsafe float Timer
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DiceController_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DiceController_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x06023F9B RID: 147355 RVA: 0x009913C1 File Offset: 0x0098F5C1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Play()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DiceController_C.__Play_NativeFunctionPtr, null);
		}

		// Token: 0x06023F9C RID: 147356 RVA: 0x009913D5 File Offset: 0x0098F5D5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DiceController_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06023F9D RID: 147357 RVA: 0x009913E9 File Offset: 0x0098F5E9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_DiceController_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06023F9E RID: 147358 RVA: 0x009913FE File Offset: 0x0098F5FE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DiceController_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06023F9F RID: 147359 RVA: 0x00991412 File Offset: 0x0098F612
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_DiceController_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06023FA0 RID: 147360 RVA: 0x00991428 File Offset: 0x0098F628
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_DiceController_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_DiceController_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_DiceController_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_DiceController_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DiceController_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06023FA1 RID: 147361 RVA: 0x00991470 File Offset: 0x0098F670
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_DiceController_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_DiceController_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_DiceController_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_DiceController_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_DiceController_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023FA2 RID: 147362 RVA: 0x009914B8 File Offset: 0x0098F6B8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_DiceController(int EntryPoint)
		{
			BP_DiceController_C.__ExecuteUbergraph_BP_DiceController_FunctionParams* ptr = stackalloc BP_DiceController_C.__ExecuteUbergraph_BP_DiceController_FunctionParams[(UIntPtr)127] + 15L / (long)sizeof(BP_DiceController_C.__ExecuteUbergraph_BP_DiceController_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_DiceController_C.__ExecuteUbergraph_BP_DiceController_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_DiceController_C.__ExecuteUbergraph_BP_DiceController_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023FA3 RID: 147363 RVA: 0x009914FF File Offset: 0x0098F6FF
		protected BP_DiceController_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04012611 RID: 75281
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Interaction/BP_DiceController.BP_DiceController_C";

		// Token: 0x04012612 RID: 75282
		private static IntPtr _ClassPtr;

		// Token: 0x04012613 RID: 75283
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04012614 RID: 75284
		internal static int __PropertyOffset_0;

		// Token: 0x04012615 RID: 75285
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04012616 RID: 75286
		internal static int __PropertyOffset_1;

		// Token: 0x04012617 RID: 75287
		internal static int __PropertyOffset_2;

		// Token: 0x04012618 RID: 75288
		internal static int __PropertyOffset_3;

		// Token: 0x04012619 RID: 75289
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UMaterialInstanceDynamic> _DynamicMaterialInstance;

		// Token: 0x0401261A RID: 75290
		internal static int __PropertyOffset_4;

		// Token: 0x0401261B RID: 75291
		internal static int __PropertyOffset_5;

		// Token: 0x0401261C RID: 75292
		[Nullable(2)]
		private TMap<FName, float> _DicePoints;

		// Token: 0x0401261D RID: 75293
		internal static int __PropertyOffset_6;

		// Token: 0x0401261E RID: 75294
		internal static int __PropertyOffset_7;

		// Token: 0x0401261F RID: 75295
		private static IntPtr __Play_NativeFunctionPtr;

		// Token: 0x04012620 RID: 75296
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04012621 RID: 75297
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04012622 RID: 75298
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04012623 RID: 75299
		private static IntPtr __ExecuteUbergraph_BP_DiceController_NativeFunctionPtr;

		// Token: 0x02009D6F RID: 40303
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032764 RID: 206692
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009D70 RID: 40304
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 112)]
		protected ref struct __ExecuteUbergraph_BP_DiceController_FunctionParams
		{
			// Token: 0x04032765 RID: 206693
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
