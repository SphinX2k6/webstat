using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.ScreenEffect.Controller
{
	// Token: 0x02003A70 RID: 14960
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/ScreenEffect/Controller/SE_NiagaraController.SE_NiagaraController_C")]
	[UnrealStructLayout(248, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 248)]
	public class SE_NiagaraController_C : SE_ControllerBase_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601F300 RID: 127744 RVA: 0x0090A8CA File Offset: 0x00908ACA
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (SE_NiagaraController_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/ScreenEffect/Controller/SE_NiagaraController.SE_NiagaraController_C");
			}
			return SE_NiagaraController_C._ClassPtr;
		}

		// Token: 0x0601F301 RID: 127745 RVA: 0x0090A8F0 File Offset: 0x00908AF0
		public SE_NiagaraController_C() : this(BuiltinUtils.AllocNativeUObject(SE_NiagaraController_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601F302 RID: 127746 RVA: 0x0090A918 File Offset: 0x00908B18
		[NullableContext(1)]
		public SE_NiagaraController_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(SE_NiagaraController_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002E7F RID: 11903
		// (get) Token: 0x0601F303 RID: 127747 RVA: 0x0090A94C File Offset: 0x00908B4C
		// (set) Token: 0x0601F304 RID: 127748 RVA: 0x0090A985 File Offset: 0x00908B85
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)SE_NiagaraController_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)SE_NiagaraController_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17002E80 RID: 11904
		// (get) Token: 0x0601F305 RID: 127749 RVA: 0x0090A9A8 File Offset: 0x00908BA8
		// (set) Token: 0x0601F306 RID: 127750 RVA: 0x0090A9E1 File Offset: 0x00908BE1
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
					result = (this._CachedNiagara = new TArray<UUINiagara>(base.NativePtr + (IntPtr)SE_NiagaraController_C.__PropertyOffset_1, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.CachedNiagara.CopyAssign(value);
			}
		}

		// Token: 0x0601F307 RID: 127751 RVA: 0x0090A9EF File Offset: 0x00908BEF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AdjustToScreenEditor()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, SE_NiagaraController_C.__AdjustToScreenEditor_NativeFunctionPtr, null);
		}

		// Token: 0x0601F308 RID: 127752 RVA: 0x0090AA03 File Offset: 0x00908C03
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AdjustToScreen()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, SE_NiagaraController_C.__AdjustToScreen_NativeFunctionPtr, null);
		}

		// Token: 0x0601F309 RID: 127753 RVA: 0x0090AA17 File Offset: 0x00908C17
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, SE_NiagaraController_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0601F30A RID: 127754 RVA: 0x0090AA2B File Offset: 0x00908C2B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, SE_NiagaraController_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601F30B RID: 127755 RVA: 0x0090AA40 File Offset: 0x00908C40
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			SE_NiagaraController_C.__ReceiveTick_FunctionParams* ptr = stackalloc SE_NiagaraController_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(SE_NiagaraController_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(SE_NiagaraController_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, SE_NiagaraController_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F30C RID: 127756 RVA: 0x0090AA88 File Offset: 0x00908C88
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void ReceiveTick_Implementation(float DeltaSeconds)
		{
			SE_NiagaraController_C.__ReceiveTick_FunctionParams* ptr = stackalloc SE_NiagaraController_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(SE_NiagaraController_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(SE_NiagaraController_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, SE_NiagaraController_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F30D RID: 127757 RVA: 0x0090AAD0 File Offset: 0x00908CD0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ApplyAlpha(float alpha)
		{
			SE_NiagaraController_C.__ApplyAlpha_FunctionParams* ptr = stackalloc SE_NiagaraController_C.__ApplyAlpha_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(SE_NiagaraController_C.__ApplyAlpha_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(SE_NiagaraController_C.__ApplyAlpha_NativeFunctionPtr, (void*)ptr, 1);
			ptr->alpha = alpha;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, SE_NiagaraController_C.__ApplyAlpha_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F30E RID: 127758 RVA: 0x0090AB18 File Offset: 0x00908D18
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ApplyVisibility(bool visibility)
		{
			SE_NiagaraController_C.__ApplyVisibility_FunctionParams* ptr = stackalloc SE_NiagaraController_C.__ApplyVisibility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(SE_NiagaraController_C.__ApplyVisibility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(SE_NiagaraController_C.__ApplyVisibility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->visibility = visibility;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, SE_NiagaraController_C.__ApplyVisibility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F30F RID: 127759 RVA: 0x0090AB5E File Offset: 0x00908D5E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void BeforeStart()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, SE_NiagaraController_C.__BeforeStart_NativeFunctionPtr, null);
		}

		// Token: 0x0601F310 RID: 127760 RVA: 0x0090AB74 File Offset: 0x00908D74
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ApplyEnvironmentFactor(float EnvironmentFactor)
		{
			SE_NiagaraController_C.__ApplyEnvironmentFactor_FunctionParams* ptr = stackalloc SE_NiagaraController_C.__ApplyEnvironmentFactor_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(SE_NiagaraController_C.__ApplyEnvironmentFactor_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(SE_NiagaraController_C.__ApplyEnvironmentFactor_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EnvironmentFactor = EnvironmentFactor;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, SE_NiagaraController_C.__ApplyEnvironmentFactor_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F311 RID: 127761 RVA: 0x0090ABBC File Offset: 0x00908DBC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_SE_NiagaraController(int EntryPoint)
		{
			SE_NiagaraController_C.__ExecuteUbergraph_SE_NiagaraController_FunctionParams* ptr = stackalloc SE_NiagaraController_C.__ExecuteUbergraph_SE_NiagaraController_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(SE_NiagaraController_C.__ExecuteUbergraph_SE_NiagaraController_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(SE_NiagaraController_C.__ExecuteUbergraph_SE_NiagaraController_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, SE_NiagaraController_C.__ExecuteUbergraph_SE_NiagaraController_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F312 RID: 127762 RVA: 0x0090AC06 File Offset: 0x00908E06
		protected SE_NiagaraController_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400F758 RID: 63320
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/ScreenEffect/Controller/SE_NiagaraController.SE_NiagaraController_C";

		// Token: 0x0400F759 RID: 63321
		private static IntPtr _ClassPtr;

		// Token: 0x0400F75A RID: 63322
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400F75B RID: 63323
		internal new static int __PropertyOffset_0;

		// Token: 0x0400F75C RID: 63324
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400F75D RID: 63325
		internal static int __PropertyOffset_1;

		// Token: 0x0400F75E RID: 63326
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UUINiagara> _CachedNiagara;

		// Token: 0x0400F75F RID: 63327
		private static IntPtr __AdjustToScreenEditor_NativeFunctionPtr;

		// Token: 0x0400F760 RID: 63328
		private static IntPtr __AdjustToScreen_NativeFunctionPtr;

		// Token: 0x0400F761 RID: 63329
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400F762 RID: 63330
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400F763 RID: 63331
		private static IntPtr __ApplyAlpha_NativeFunctionPtr;

		// Token: 0x0400F764 RID: 63332
		private static IntPtr __ApplyVisibility_NativeFunctionPtr;

		// Token: 0x0400F765 RID: 63333
		private static IntPtr __BeforeStart_NativeFunctionPtr;

		// Token: 0x0400F766 RID: 63334
		private static IntPtr __ApplyEnvironmentFactor_NativeFunctionPtr;

		// Token: 0x0400F767 RID: 63335
		private static IntPtr __ExecuteUbergraph_SE_NiagaraController_NativeFunctionPtr;

		// Token: 0x02009891 RID: 39057
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031ED5 RID: 204501
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009892 RID: 39058
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ApplyAlpha_FunctionParams
		{
			// Token: 0x04031ED6 RID: 204502
			[FieldOffset(0)]
			public float alpha;
		}

		// Token: 0x02009893 RID: 39059
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __ApplyVisibility_FunctionParams
		{
			// Token: 0x04031ED7 RID: 204503
			[FieldOffset(0)]
			public bool visibility;
		}

		// Token: 0x02009894 RID: 39060
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ApplyEnvironmentFactor_FunctionParams
		{
			// Token: 0x04031ED8 RID: 204504
			[FieldOffset(0)]
			public float EnvironmentFactor;
		}

		// Token: 0x02009895 RID: 39061
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __ExecuteUbergraph_SE_NiagaraController_FunctionParams
		{
			// Token: 0x04031ED9 RID: 204505
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
