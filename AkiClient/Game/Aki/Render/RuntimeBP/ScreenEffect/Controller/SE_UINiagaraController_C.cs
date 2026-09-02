using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.ScreenEffect.Controller
{
	// Token: 0x02003A71 RID: 14961
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/ScreenEffect/Controller/SE_UINiagaraController.SE_UINiagaraController_C")]
	[UnrealStructLayout(280, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 280)]
	public class SE_UINiagaraController_C : SE_ControllerBase_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601F313 RID: 127763 RVA: 0x0090AC0F File Offset: 0x00908E0F
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (SE_UINiagaraController_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/ScreenEffect/Controller/SE_UINiagaraController.SE_UINiagaraController_C");
			}
			return SE_UINiagaraController_C._ClassPtr;
		}

		// Token: 0x0601F314 RID: 127764 RVA: 0x0090AC34 File Offset: 0x00908E34
		public SE_UINiagaraController_C() : this(BuiltinUtils.AllocNativeUObject(SE_UINiagaraController_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601F315 RID: 127765 RVA: 0x0090AC5C File Offset: 0x00908E5C
		[NullableContext(1)]
		public SE_UINiagaraController_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(SE_UINiagaraController_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002E81 RID: 11905
		// (get) Token: 0x0601F316 RID: 127766 RVA: 0x0090AC90 File Offset: 0x00908E90
		// (set) Token: 0x0601F317 RID: 127767 RVA: 0x0090ACC9 File Offset: 0x00908EC9
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)SE_UINiagaraController_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)SE_UINiagaraController_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17002E82 RID: 11906
		// (get) Token: 0x0601F318 RID: 127768 RVA: 0x0090ACEC File Offset: 0x00908EEC
		// (set) Token: 0x0601F319 RID: 127769 RVA: 0x0090AD25 File Offset: 0x00908F25
		[Nullable(1)]
		public TArray<UUINiagara> CachedNiagara
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<UUINiagara> result;
				if ((result = this._CachedNiagara) == null)
				{
					result = (this._CachedNiagara = new TArray<UUINiagara>(base.NativePtr + (IntPtr)SE_UINiagaraController_C.__PropertyOffset_1, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.CachedNiagara.CopyAssign(value);
			}
		}

		// Token: 0x17002E83 RID: 11907
		// (get) Token: 0x0601F31A RID: 127770 RVA: 0x0090AD33 File Offset: 0x00908F33
		// (set) Token: 0x0601F31B RID: 127771 RVA: 0x0090AD43 File Offset: 0x00908F43
		public unsafe bool HasAdapted
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SE_UINiagaraController_C.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SE_UINiagaraController_C.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002E84 RID: 11908
		// (get) Token: 0x0601F31C RID: 127772 RVA: 0x0090AD54 File Offset: 0x00908F54
		// (set) Token: 0x0601F31D RID: 127773 RVA: 0x0090AD68 File Offset: 0x00908F68
		public unsafe FVector2D ViewportSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SE_UINiagaraController_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SE_UINiagaraController_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17002E85 RID: 11909
		// (get) Token: 0x0601F31E RID: 127774 RVA: 0x0090AD7D File Offset: 0x00908F7D
		// (set) Token: 0x0601F31F RID: 127775 RVA: 0x0090AD8D File Offset: 0x00908F8D
		public unsafe bool UseAspectRatio
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SE_UINiagaraController_C.__PropertyOffset_4) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SE_UINiagaraController_C.__PropertyOffset_4) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002E86 RID: 11910
		// (get) Token: 0x0601F320 RID: 127776 RVA: 0x0090AD9E File Offset: 0x00908F9E
		// (set) Token: 0x0601F321 RID: 127777 RVA: 0x0090ADAE File Offset: 0x00908FAE
		public unsafe float AspectRatio
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SE_UINiagaraController_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SE_UINiagaraController_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17002E87 RID: 11911
		// (get) Token: 0x0601F322 RID: 127778 RVA: 0x0090ADBF File Offset: 0x00908FBF
		// (set) Token: 0x0601F323 RID: 127779 RVA: 0x0090ADCF File Offset: 0x00908FCF
		public unsafe bool ControlByWidth
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SE_UINiagaraController_C.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SE_UINiagaraController_C.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002E88 RID: 11912
		// (get) Token: 0x0601F324 RID: 127780 RVA: 0x0090ADE0 File Offset: 0x00908FE0
		// (set) Token: 0x0601F325 RID: 127781 RVA: 0x0090ADF4 File Offset: 0x00908FF4
		[Nullable(2)]
		public unsafe AUIContainerActor AdaptTo
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AUIContainerActor>(base.NativePtr / (IntPtr)sizeof(void*) + SE_UINiagaraController_C.__PropertyOffset_7);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SE_UINiagaraController_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x0601F326 RID: 127782 RVA: 0x0090AE0C File Offset: 0x0090900C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void CaculatePoint(FVector2D LeftBottomPoint, FVector2D RightTopPoint, ref FVector2D NewLeftBottomPoint, ref FVector2D NewRightTopPoint)
		{
			SE_UINiagaraController_C.__CaculatePoint_FunctionParams* ptr = stackalloc SE_UINiagaraController_C.__CaculatePoint_FunctionParams[(UIntPtr)159] + 15L / (long)sizeof(SE_UINiagaraController_C.__CaculatePoint_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(SE_UINiagaraController_C.__CaculatePoint_NativeFunctionPtr, (void*)ptr, 1);
			ptr->LeftBottomPoint = LeftBottomPoint;
			ptr->RightTopPoint = RightTopPoint;
			ptr->NewLeftBottomPoint = NewLeftBottomPoint;
			ptr->NewRightTopPoint = NewRightTopPoint;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, SE_UINiagaraController_C.__CaculatePoint_NativeFunctionPtr, (void*)ptr);
			NewLeftBottomPoint = ptr->NewLeftBottomPoint;
			NewRightTopPoint = ptr->NewRightTopPoint;
		}

		// Token: 0x0601F327 RID: 127783 RVA: 0x0090AE8E File Offset: 0x0090908E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AdjustToScreenEditor()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, SE_UINiagaraController_C.__AdjustToScreenEditor_NativeFunctionPtr, null);
		}

		// Token: 0x0601F328 RID: 127784 RVA: 0x0090AEA2 File Offset: 0x009090A2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AdjustToScreen()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, SE_UINiagaraController_C.__AdjustToScreen_NativeFunctionPtr, null);
		}

		// Token: 0x0601F329 RID: 127785 RVA: 0x0090AEB6 File Offset: 0x009090B6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, SE_UINiagaraController_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0601F32A RID: 127786 RVA: 0x0090AECA File Offset: 0x009090CA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, SE_UINiagaraController_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601F32B RID: 127787 RVA: 0x0090AEE0 File Offset: 0x009090E0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			SE_UINiagaraController_C.__ReceiveTick_FunctionParams* ptr = stackalloc SE_UINiagaraController_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(SE_UINiagaraController_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(SE_UINiagaraController_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, SE_UINiagaraController_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F32C RID: 127788 RVA: 0x0090AF28 File Offset: 0x00909128
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void ReceiveTick_Implementation(float DeltaSeconds)
		{
			SE_UINiagaraController_C.__ReceiveTick_FunctionParams* ptr = stackalloc SE_UINiagaraController_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(SE_UINiagaraController_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(SE_UINiagaraController_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, SE_UINiagaraController_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F32D RID: 127789 RVA: 0x0090AF70 File Offset: 0x00909170
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ApplyAlpha(float alpha)
		{
			SE_UINiagaraController_C.__ApplyAlpha_FunctionParams* ptr = stackalloc SE_UINiagaraController_C.__ApplyAlpha_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(SE_UINiagaraController_C.__ApplyAlpha_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(SE_UINiagaraController_C.__ApplyAlpha_NativeFunctionPtr, (void*)ptr, 1);
			ptr->alpha = alpha;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, SE_UINiagaraController_C.__ApplyAlpha_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F32E RID: 127790 RVA: 0x0090AFB8 File Offset: 0x009091B8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ApplyVisibility(bool visibility)
		{
			SE_UINiagaraController_C.__ApplyVisibility_FunctionParams* ptr = stackalloc SE_UINiagaraController_C.__ApplyVisibility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(SE_UINiagaraController_C.__ApplyVisibility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(SE_UINiagaraController_C.__ApplyVisibility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->visibility = visibility;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, SE_UINiagaraController_C.__ApplyVisibility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F32F RID: 127791 RVA: 0x0090AFFE File Offset: 0x009091FE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void BeforeStart()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, SE_UINiagaraController_C.__BeforeStart_NativeFunctionPtr, null);
		}

		// Token: 0x0601F330 RID: 127792 RVA: 0x0090B014 File Offset: 0x00909214
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ApplyEnvironmentFactor(float EnvironmentFactor)
		{
			SE_UINiagaraController_C.__ApplyEnvironmentFactor_FunctionParams* ptr = stackalloc SE_UINiagaraController_C.__ApplyEnvironmentFactor_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(SE_UINiagaraController_C.__ApplyEnvironmentFactor_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(SE_UINiagaraController_C.__ApplyEnvironmentFactor_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EnvironmentFactor = EnvironmentFactor;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, SE_UINiagaraController_C.__ApplyEnvironmentFactor_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F331 RID: 127793 RVA: 0x0090B05C File Offset: 0x0090925C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_SE_UINiagaraController(int EntryPoint)
		{
			SE_UINiagaraController_C.__ExecuteUbergraph_SE_UINiagaraController_FunctionParams* ptr = stackalloc SE_UINiagaraController_C.__ExecuteUbergraph_SE_UINiagaraController_FunctionParams[(UIntPtr)215] + 15L / (long)sizeof(SE_UINiagaraController_C.__ExecuteUbergraph_SE_UINiagaraController_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(SE_UINiagaraController_C.__ExecuteUbergraph_SE_UINiagaraController_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, SE_UINiagaraController_C.__ExecuteUbergraph_SE_UINiagaraController_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F332 RID: 127794 RVA: 0x0090B0A6 File Offset: 0x009092A6
		protected SE_UINiagaraController_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400F768 RID: 63336
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/ScreenEffect/Controller/SE_UINiagaraController.SE_UINiagaraController_C";

		// Token: 0x0400F769 RID: 63337
		private static IntPtr _ClassPtr;

		// Token: 0x0400F76A RID: 63338
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400F76B RID: 63339
		internal new static int __PropertyOffset_0;

		// Token: 0x0400F76C RID: 63340
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400F76D RID: 63341
		internal static int __PropertyOffset_1;

		// Token: 0x0400F76E RID: 63342
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UUINiagara> _CachedNiagara;

		// Token: 0x0400F76F RID: 63343
		internal static int __PropertyOffset_2;

		// Token: 0x0400F770 RID: 63344
		internal static int __PropertyOffset_3;

		// Token: 0x0400F771 RID: 63345
		internal static int __PropertyOffset_4;

		// Token: 0x0400F772 RID: 63346
		internal static int __PropertyOffset_5;

		// Token: 0x0400F773 RID: 63347
		internal static int __PropertyOffset_6;

		// Token: 0x0400F774 RID: 63348
		internal static int __PropertyOffset_7;

		// Token: 0x0400F775 RID: 63349
		private static IntPtr __CaculatePoint_NativeFunctionPtr;

		// Token: 0x0400F776 RID: 63350
		private static IntPtr __AdjustToScreenEditor_NativeFunctionPtr;

		// Token: 0x0400F777 RID: 63351
		private static IntPtr __AdjustToScreen_NativeFunctionPtr;

		// Token: 0x0400F778 RID: 63352
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400F779 RID: 63353
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400F77A RID: 63354
		private static IntPtr __ApplyAlpha_NativeFunctionPtr;

		// Token: 0x0400F77B RID: 63355
		private static IntPtr __ApplyVisibility_NativeFunctionPtr;

		// Token: 0x0400F77C RID: 63356
		private static IntPtr __BeforeStart_NativeFunctionPtr;

		// Token: 0x0400F77D RID: 63357
		private static IntPtr __ApplyEnvironmentFactor_NativeFunctionPtr;

		// Token: 0x0400F77E RID: 63358
		private static IntPtr __ExecuteUbergraph_SE_UINiagaraController_NativeFunctionPtr;

		// Token: 0x02009896 RID: 39062
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 144)]
		protected ref struct __CaculatePoint_FunctionParams
		{
			// Token: 0x04031EDA RID: 204506
			[FieldOffset(0)]
			public FVector2D LeftBottomPoint;

			// Token: 0x04031EDB RID: 204507
			[FieldOffset(8)]
			public FVector2D RightTopPoint;

			// Token: 0x04031EDC RID: 204508
			[FieldOffset(16)]
			public FVector2D NewLeftBottomPoint;

			// Token: 0x04031EDD RID: 204509
			[FieldOffset(24)]
			public FVector2D NewRightTopPoint;
		}

		// Token: 0x02009897 RID: 39063
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031EDE RID: 204510
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009898 RID: 39064
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ApplyAlpha_FunctionParams
		{
			// Token: 0x04031EDF RID: 204511
			[FieldOffset(0)]
			public float alpha;
		}

		// Token: 0x02009899 RID: 39065
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __ApplyVisibility_FunctionParams
		{
			// Token: 0x04031EE0 RID: 204512
			[FieldOffset(0)]
			public bool visibility;
		}

		// Token: 0x0200989A RID: 39066
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ApplyEnvironmentFactor_FunctionParams
		{
			// Token: 0x04031EE1 RID: 204513
			[FieldOffset(0)]
			public float EnvironmentFactor;
		}

		// Token: 0x0200989B RID: 39067
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 200)]
		protected ref struct __ExecuteUbergraph_SE_UINiagaraController_FunctionParams
		{
			// Token: 0x04031EE2 RID: 204514
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
