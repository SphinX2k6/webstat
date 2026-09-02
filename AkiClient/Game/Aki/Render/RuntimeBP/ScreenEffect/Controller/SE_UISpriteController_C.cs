using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Render.RuntimeBP.ScreenEffect.Data;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.ScreenEffect.Controller
{
	// Token: 0x02003A72 RID: 14962
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/ScreenEffect/Controller/SE_UISpriteController.SE_UISpriteController_C")]
	[UnrealStructLayout(256, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 256)]
	public class SE_UISpriteController_C : SE_ControllerBase_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601F333 RID: 127795 RVA: 0x0090B0AF File Offset: 0x009092AF
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (SE_UISpriteController_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/ScreenEffect/Controller/SE_UISpriteController.SE_UISpriteController_C");
			}
			return SE_UISpriteController_C._ClassPtr;
		}

		// Token: 0x0601F334 RID: 127796 RVA: 0x0090B0D4 File Offset: 0x009092D4
		public SE_UISpriteController_C() : this(BuiltinUtils.AllocNativeUObject(SE_UISpriteController_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601F335 RID: 127797 RVA: 0x0090B0FC File Offset: 0x009092FC
		[NullableContext(1)]
		public SE_UISpriteController_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(SE_UISpriteController_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002E89 RID: 11913
		// (get) Token: 0x0601F336 RID: 127798 RVA: 0x0090B130 File Offset: 0x00909330
		// (set) Token: 0x0601F337 RID: 127799 RVA: 0x0090B169 File Offset: 0x00909369
		[Nullable(1)]
		public new FPointerToUberGraphFrame UberGraphFrame
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)SE_UISpriteController_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)SE_UISpriteController_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17002E8A RID: 11914
		// (get) Token: 0x0601F338 RID: 127800 RVA: 0x0090B18A File Offset: 0x0090938A
		// (set) Token: 0x0601F339 RID: 127801 RVA: 0x0090B19E File Offset: 0x0090939E
		[Nullable(2)]
		public unsafe PD_SE_ControllerCommonData_C Data
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<PD_SE_ControllerCommonData_C>(base.NativePtr / (IntPtr)sizeof(void*) + SE_UISpriteController_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SE_UISpriteController_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17002E8B RID: 11915
		// (get) Token: 0x0601F33A RID: 127802 RVA: 0x0090B1B4 File Offset: 0x009093B4
		// (set) Token: 0x0601F33B RID: 127803 RVA: 0x0090B1ED File Offset: 0x009093ED
		[Nullable(1)]
		public TArray<UMaterialInstanceDynamic> CachedMaterial
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<UMaterialInstanceDynamic> result;
				if ((result = this._CachedMaterial) == null)
				{
					result = (this._CachedMaterial = new TArray<UMaterialInstanceDynamic>(base.NativePtr + (IntPtr)SE_UISpriteController_C.__PropertyOffset_2, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.CachedMaterial.CopyAssign(value);
			}
		}

		// Token: 0x0601F33C RID: 127804 RVA: 0x0090B1FC File Offset: 0x009093FC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void UpdateComponentAlpha(float Alpha)
		{
			SE_UISpriteController_C.__UpdateComponentAlpha_FunctionParams* ptr = stackalloc SE_UISpriteController_C.__UpdateComponentAlpha_FunctionParams[(UIntPtr)71] + 15L / (long)sizeof(SE_UISpriteController_C.__UpdateComponentAlpha_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(SE_UISpriteController_C.__UpdateComponentAlpha_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Alpha = Alpha;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, SE_UISpriteController_C.__UpdateComponentAlpha_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F33D RID: 127805 RVA: 0x0090B244 File Offset: 0x00909444
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void UpdateComponent(E_SE_PlayState State, float Time)
		{
			SE_UISpriteController_C.__UpdateComponent_FunctionParams* ptr = stackalloc SE_UISpriteController_C.__UpdateComponent_FunctionParams[(UIntPtr)2311] + 15L / (long)sizeof(SE_UISpriteController_C.__UpdateComponent_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(SE_UISpriteController_C.__UpdateComponent_NativeFunctionPtr, (void*)ptr, 1);
			ptr->State = State;
			ptr->Time = Time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, SE_UISpriteController_C.__UpdateComponent_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F33E RID: 127806 RVA: 0x0090B299 File Offset: 0x00909499
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, SE_UISpriteController_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0601F33F RID: 127807 RVA: 0x0090B2AD File Offset: 0x009094AD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, SE_UISpriteController_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601F340 RID: 127808 RVA: 0x0090B2C4 File Offset: 0x009094C4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			SE_UISpriteController_C.__ReceiveTick_FunctionParams* ptr = stackalloc SE_UISpriteController_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(SE_UISpriteController_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(SE_UISpriteController_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, SE_UISpriteController_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F341 RID: 127809 RVA: 0x0090B30C File Offset: 0x0090950C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void ReceiveTick_Implementation(float DeltaSeconds)
		{
			SE_UISpriteController_C.__ReceiveTick_FunctionParams* ptr = stackalloc SE_UISpriteController_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(SE_UISpriteController_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(SE_UISpriteController_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, SE_UISpriteController_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F342 RID: 127810 RVA: 0x0090B354 File Offset: 0x00909554
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void Start(float time)
		{
			SE_UISpriteController_C.__Start_FunctionParams* ptr = stackalloc SE_UISpriteController_C.__Start_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(SE_UISpriteController_C.__Start_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(SE_UISpriteController_C.__Start_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, SE_UISpriteController_C.__Start_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F343 RID: 127811 RVA: 0x0090B39C File Offset: 0x0090959C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void End(float time)
		{
			SE_UISpriteController_C.__End_FunctionParams* ptr = stackalloc SE_UISpriteController_C.__End_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(SE_UISpriteController_C.__End_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(SE_UISpriteController_C.__End_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, SE_UISpriteController_C.__End_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F344 RID: 127812 RVA: 0x0090B3E4 File Offset: 0x009095E4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void Loop(float time)
		{
			SE_UISpriteController_C.__Loop_FunctionParams* ptr = stackalloc SE_UISpriteController_C.__Loop_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(SE_UISpriteController_C.__Loop_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(SE_UISpriteController_C.__Loop_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, SE_UISpriteController_C.__Loop_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F345 RID: 127813 RVA: 0x0090B42C File Offset: 0x0090962C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ApplyAlpha(float alpha)
		{
			SE_UISpriteController_C.__ApplyAlpha_FunctionParams* ptr = stackalloc SE_UISpriteController_C.__ApplyAlpha_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(SE_UISpriteController_C.__ApplyAlpha_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(SE_UISpriteController_C.__ApplyAlpha_NativeFunctionPtr, (void*)ptr, 1);
			ptr->alpha = alpha;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, SE_UISpriteController_C.__ApplyAlpha_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F346 RID: 127814 RVA: 0x0090B474 File Offset: 0x00909674
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveEndPlay(EEndPlayReason EndPlayReason)
		{
			SE_UISpriteController_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc SE_UISpriteController_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(SE_UISpriteController_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(SE_UISpriteController_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, SE_UISpriteController_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F347 RID: 127815 RVA: 0x0090B4C0 File Offset: 0x009096C0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveEndPlay_Implementation(EEndPlayReason EndPlayReason)
		{
			SE_UISpriteController_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc SE_UISpriteController_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(SE_UISpriteController_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(SE_UISpriteController_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, SE_UISpriteController_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F348 RID: 127816 RVA: 0x0090B50C File Offset: 0x0090970C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_SE_UISpriteController(int EntryPoint)
		{
			SE_UISpriteController_C.__ExecuteUbergraph_SE_UISpriteController_FunctionParams* ptr = stackalloc SE_UISpriteController_C.__ExecuteUbergraph_SE_UISpriteController_FunctionParams[(UIntPtr)95] + 15L / (long)sizeof(SE_UISpriteController_C.__ExecuteUbergraph_SE_UISpriteController_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(SE_UISpriteController_C.__ExecuteUbergraph_SE_UISpriteController_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, SE_UISpriteController_C.__ExecuteUbergraph_SE_UISpriteController_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F349 RID: 127817 RVA: 0x0090B553 File Offset: 0x00909753
		protected SE_UISpriteController_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400F77F RID: 63359
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/ScreenEffect/Controller/SE_UISpriteController.SE_UISpriteController_C";

		// Token: 0x0400F780 RID: 63360
		private static IntPtr _ClassPtr;

		// Token: 0x0400F781 RID: 63361
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400F782 RID: 63362
		internal new static int __PropertyOffset_0;

		// Token: 0x0400F783 RID: 63363
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400F784 RID: 63364
		internal static int __PropertyOffset_1;

		// Token: 0x0400F785 RID: 63365
		internal static int __PropertyOffset_2;

		// Token: 0x0400F786 RID: 63366
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UMaterialInstanceDynamic> _CachedMaterial;

		// Token: 0x0400F787 RID: 63367
		private static IntPtr __UpdateComponentAlpha_NativeFunctionPtr;

		// Token: 0x0400F788 RID: 63368
		private static IntPtr __UpdateComponent_NativeFunctionPtr;

		// Token: 0x0400F789 RID: 63369
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400F78A RID: 63370
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400F78B RID: 63371
		private static IntPtr __Start_NativeFunctionPtr;

		// Token: 0x0400F78C RID: 63372
		private static IntPtr __End_NativeFunctionPtr;

		// Token: 0x0400F78D RID: 63373
		private static IntPtr __Loop_NativeFunctionPtr;

		// Token: 0x0400F78E RID: 63374
		private static IntPtr __ApplyAlpha_NativeFunctionPtr;

		// Token: 0x0400F78F RID: 63375
		private static IntPtr __ReceiveEndPlay_NativeFunctionPtr;

		// Token: 0x0400F790 RID: 63376
		private static IntPtr __ExecuteUbergraph_SE_UISpriteController_NativeFunctionPtr;

		// Token: 0x0200989C RID: 39068
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 56)]
		protected ref struct __UpdateComponentAlpha_FunctionParams
		{
			// Token: 0x04031EE3 RID: 204515
			[FieldOffset(0)]
			public float Alpha;
		}

		// Token: 0x0200989D RID: 39069
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 2296)]
		protected ref struct __UpdateComponent_FunctionParams
		{
			// Token: 0x04031EE4 RID: 204516
			[FieldOffset(0)]
			public TEnumAsByte<E_SE_PlayState> State;

			// Token: 0x04031EE5 RID: 204517
			[FieldOffset(4)]
			public float Time;
		}

		// Token: 0x0200989E RID: 39070
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031EE6 RID: 204518
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200989F RID: 39071
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __Start_FunctionParams
		{
			// Token: 0x04031EE7 RID: 204519
			[FieldOffset(0)]
			public float time;
		}

		// Token: 0x020098A0 RID: 39072
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __End_FunctionParams
		{
			// Token: 0x04031EE8 RID: 204520
			[FieldOffset(0)]
			public float time;
		}

		// Token: 0x020098A1 RID: 39073
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __Loop_FunctionParams
		{
			// Token: 0x04031EE9 RID: 204521
			[FieldOffset(0)]
			public float time;
		}

		// Token: 0x020098A2 RID: 39074
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ApplyAlpha_FunctionParams
		{
			// Token: 0x04031EEA RID: 204522
			[FieldOffset(0)]
			public float alpha;
		}

		// Token: 0x020098A3 RID: 39075
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __ReceiveEndPlay_FunctionParams
		{
			// Token: 0x04031EEB RID: 204523
			[FieldOffset(0)]
			public TEnumAsByte<EEndPlayReason> EndPlayReason;
		}

		// Token: 0x020098A4 RID: 39076
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 80)]
		protected ref struct __ExecuteUbergraph_SE_UISpriteController_FunctionParams
		{
			// Token: 0x04031EEC RID: 204524
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
