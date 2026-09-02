using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Effect.Spline
{
	// Token: 0x02003D2D RID: 15661
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Effect/Spline/BP_Fx_BirdsFlySpline.BP_Fx_BirdsFlySpline_C")]
	[UnrealStructLayout(1072, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1068)]
	public class BP_Fx_BirdsFlySpline_C : AKuroEffectActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06025EA3 RID: 155299 RVA: 0x009C866C File Offset: 0x009C686C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_Fx_BirdsFlySpline_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Effect/Spline/BP_Fx_BirdsFlySpline.BP_Fx_BirdsFlySpline_C");
			}
			return BP_Fx_BirdsFlySpline_C._ClassPtr;
		}

		// Token: 0x06025EA4 RID: 155300 RVA: 0x009C8690 File Offset: 0x009C6890
		public BP_Fx_BirdsFlySpline_C() : this(BuiltinUtils.AllocNativeUObject(BP_Fx_BirdsFlySpline_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06025EA5 RID: 155301 RVA: 0x009C86B8 File Offset: 0x009C68B8
		[NullableContext(1)]
		public BP_Fx_BirdsFlySpline_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_Fx_BirdsFlySpline_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17005477 RID: 21623
		// (get) Token: 0x06025EA6 RID: 155302 RVA: 0x009C86EC File Offset: 0x009C68EC
		// (set) Token: 0x06025EA7 RID: 155303 RVA: 0x009C8725 File Offset: 0x009C6925
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_Fx_BirdsFlySpline_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_Fx_BirdsFlySpline_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005478 RID: 21624
		// (get) Token: 0x06025EA8 RID: 155304 RVA: 0x009C8746 File Offset: 0x009C6946
		// (set) Token: 0x06025EA9 RID: 155305 RVA: 0x009C875A File Offset: 0x009C695A
		[Nullable(2)]
		public unsafe USplineComponent Spline
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USplineComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Fx_BirdsFlySpline_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Fx_BirdsFlySpline_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17005479 RID: 21625
		// (get) Token: 0x06025EAA RID: 155306 RVA: 0x009C876F File Offset: 0x009C696F
		// (set) Token: 0x06025EAB RID: 155307 RVA: 0x009C8783 File Offset: 0x009C6983
		[Nullable(2)]
		public unsafe EffectModelNiagara EffectModelNiagara
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<EffectModelNiagara>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Fx_BirdsFlySpline_C.__PropertyOffset_2);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Fx_BirdsFlySpline_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x1700547A RID: 21626
		// (get) Token: 0x06025EAC RID: 155308 RVA: 0x009C8798 File Offset: 0x009C6998
		// (set) Token: 0x06025EAD RID: 155309 RVA: 0x009C87A8 File Offset: 0x009C69A8
		public unsafe int TsEffectComponent
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Fx_BirdsFlySpline_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Fx_BirdsFlySpline_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x06025EAE RID: 155310 RVA: 0x009C87BC File Offset: 0x009C69BC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void IsEditor(ref bool IsEditor)
		{
			BP_Fx_BirdsFlySpline_C.__IsEditor_FunctionParams* ptr = stackalloc BP_Fx_BirdsFlySpline_C.__IsEditor_FunctionParams[(UIntPtr)20] + 15L / (long)sizeof(BP_Fx_BirdsFlySpline_C.__IsEditor_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Fx_BirdsFlySpline_C.__IsEditor_NativeFunctionPtr, (void*)ptr, 1);
			ptr->IsEditor = IsEditor;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Fx_BirdsFlySpline_C.__IsEditor_NativeFunctionPtr, (void*)ptr);
			IsEditor = ptr->IsEditor;
		}

		// Token: 0x06025EAF RID: 155311 RVA: 0x009C880B File Offset: 0x009C6A0B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void StopEditor()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Fx_BirdsFlySpline_C.__StopEditor_NativeFunctionPtr, null);
		}

		// Token: 0x06025EB0 RID: 155312 RVA: 0x009C881F File Offset: 0x009C6A1F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void PlayEditor()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Fx_BirdsFlySpline_C.__PlayEditor_NativeFunctionPtr, null);
		}

		// Token: 0x06025EB1 RID: 155313 RVA: 0x009C8833 File Offset: 0x009C6A33
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Reset()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Fx_BirdsFlySpline_C.__Reset_NativeFunctionPtr, null);
		}

		// Token: 0x06025EB2 RID: 155314 RVA: 0x009C8847 File Offset: 0x009C6A47
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Fx_BirdsFlySpline_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06025EB3 RID: 155315 RVA: 0x009C885B File Offset: 0x009C6A5B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Fx_BirdsFlySpline_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06025EB4 RID: 155316 RVA: 0x009C8870 File Offset: 0x009C6A70
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveEndPlay(EEndPlayReason EndPlayReason)
		{
			BP_Fx_BirdsFlySpline_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_Fx_BirdsFlySpline_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_Fx_BirdsFlySpline_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Fx_BirdsFlySpline_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Fx_BirdsFlySpline_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025EB5 RID: 155317 RVA: 0x009C88BC File Offset: 0x009C6ABC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveEndPlay_Implementation(EEndPlayReason EndPlayReason)
		{
			BP_Fx_BirdsFlySpline_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_Fx_BirdsFlySpline_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_Fx_BirdsFlySpline_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Fx_BirdsFlySpline_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Fx_BirdsFlySpline_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06025EB6 RID: 155318 RVA: 0x009C8908 File Offset: 0x009C6B08
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_Fx_BirdsFlySpline_C.__EditorTick_FunctionParams* ptr = stackalloc BP_Fx_BirdsFlySpline_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Fx_BirdsFlySpline_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Fx_BirdsFlySpline_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Fx_BirdsFlySpline_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025EB7 RID: 155319 RVA: 0x009C8950 File Offset: 0x009C6B50
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_Fx_BirdsFlySpline_C.__EditorTick_FunctionParams* ptr = stackalloc BP_Fx_BirdsFlySpline_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Fx_BirdsFlySpline_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Fx_BirdsFlySpline_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Fx_BirdsFlySpline_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06025EB8 RID: 155320 RVA: 0x009C8998 File Offset: 0x009C6B98
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_Fx_BirdsFlySpline(int EntryPoint)
		{
			BP_Fx_BirdsFlySpline_C.__ExecuteUbergraph_BP_Fx_BirdsFlySpline_FunctionParams* ptr = stackalloc BP_Fx_BirdsFlySpline_C.__ExecuteUbergraph_BP_Fx_BirdsFlySpline_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(BP_Fx_BirdsFlySpline_C.__ExecuteUbergraph_BP_Fx_BirdsFlySpline_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Fx_BirdsFlySpline_C.__ExecuteUbergraph_BP_Fx_BirdsFlySpline_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Fx_BirdsFlySpline_C.__ExecuteUbergraph_BP_Fx_BirdsFlySpline_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06025EB9 RID: 155321 RVA: 0x009C89DF File Offset: 0x009C6BDF
		protected BP_Fx_BirdsFlySpline_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401399B RID: 80283
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Effect/Spline/BP_Fx_BirdsFlySpline.BP_Fx_BirdsFlySpline_C";

		// Token: 0x0401399C RID: 80284
		private static IntPtr _ClassPtr;

		// Token: 0x0401399D RID: 80285
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401399E RID: 80286
		internal static int __PropertyOffset_0;

		// Token: 0x0401399F RID: 80287
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040139A0 RID: 80288
		internal static int __PropertyOffset_1;

		// Token: 0x040139A1 RID: 80289
		internal static int __PropertyOffset_2;

		// Token: 0x040139A2 RID: 80290
		internal static int __PropertyOffset_3;

		// Token: 0x040139A3 RID: 80291
		private static IntPtr __IsEditor_NativeFunctionPtr;

		// Token: 0x040139A4 RID: 80292
		private static IntPtr __StopEditor_NativeFunctionPtr;

		// Token: 0x040139A5 RID: 80293
		private static IntPtr __PlayEditor_NativeFunctionPtr;

		// Token: 0x040139A6 RID: 80294
		private static IntPtr __Reset_NativeFunctionPtr;

		// Token: 0x040139A7 RID: 80295
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x040139A8 RID: 80296
		private static IntPtr __ReceiveEndPlay_NativeFunctionPtr;

		// Token: 0x040139A9 RID: 80297
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x040139AA RID: 80298
		private static IntPtr __ExecuteUbergraph_BP_Fx_BirdsFlySpline_NativeFunctionPtr;

		// Token: 0x02009FC9 RID: 40905
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 5)]
		protected ref struct __IsEditor_FunctionParams
		{
			// Token: 0x04032B81 RID: 207745
			[FieldOffset(0)]
			public bool IsEditor;
		}

		// Token: 0x02009FCA RID: 40906
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __ReceiveEndPlay_FunctionParams
		{
			// Token: 0x04032B82 RID: 207746
			[FieldOffset(0)]
			public TEnumAsByte<EEndPlayReason> EndPlayReason;
		}

		// Token: 0x02009FCB RID: 40907
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04032B83 RID: 207747
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009FCC RID: 40908
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __ExecuteUbergraph_BP_Fx_BirdsFlySpline_FunctionParams
		{
			// Token: 0x04032B84 RID: 207748
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
