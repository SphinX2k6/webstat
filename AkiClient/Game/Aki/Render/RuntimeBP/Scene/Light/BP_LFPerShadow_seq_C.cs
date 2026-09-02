using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Light
{
	// Token: 0x02003A8D RID: 14989
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Light/BP_LFPerShadow_seq.BP_LFPerShadow_seq_C")]
	[UnrealStructLayout(1112, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1108)]
	public class BP_LFPerShadow_seq_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601F7F8 RID: 129016 RVA: 0x0091306C File Offset: 0x0091126C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_LFPerShadow_seq_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_LFPerShadow_seq.BP_LFPerShadow_seq_C");
			}
			return BP_LFPerShadow_seq_C._ClassPtr;
		}

		// Token: 0x0601F7F9 RID: 129017 RVA: 0x00913090 File Offset: 0x00911290
		public BP_LFPerShadow_seq_C() : this(BuiltinUtils.AllocNativeUObject(BP_LFPerShadow_seq_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601F7FA RID: 129018 RVA: 0x009130B8 File Offset: 0x009112B8
		[NullableContext(1)]
		public BP_LFPerShadow_seq_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_LFPerShadow_seq_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700304D RID: 12365
		// (get) Token: 0x0601F7FB RID: 129019 RVA: 0x009130EC File Offset: 0x009112EC
		// (set) Token: 0x0601F7FC RID: 129020 RVA: 0x00913125 File Offset: 0x00911325
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_LFPerShadow_seq_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_LFPerShadow_seq_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700304E RID: 12366
		// (get) Token: 0x0601F7FD RID: 129021 RVA: 0x00913146 File Offset: 0x00911346
		// (set) Token: 0x0601F7FE RID: 129022 RVA: 0x0091315A File Offset: 0x0091135A
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LFPerShadow_seq_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LFPerShadow_seq_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x1700304F RID: 12367
		// (get) Token: 0x0601F7FF RID: 129023 RVA: 0x0091316F File Offset: 0x0091136F
		// (set) Token: 0x0601F800 RID: 129024 RVA: 0x00913183 File Offset: 0x00911383
		public unsafe UMaterialParameterCollection LightFunction
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialParameterCollection>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LFPerShadow_seq_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LFPerShadow_seq_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17003050 RID: 12368
		// (get) Token: 0x0601F801 RID: 129025 RVA: 0x00913198 File Offset: 0x00911398
		// (set) Token: 0x0601F802 RID: 129026 RVA: 0x009131A8 File Offset: 0x009113A8
		public unsafe float ShadowIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LFPerShadow_seq_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LFPerShadow_seq_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17003051 RID: 12369
		// (get) Token: 0x0601F803 RID: 129027 RVA: 0x009131B9 File Offset: 0x009113B9
		// (set) Token: 0x0601F804 RID: 129028 RVA: 0x009131CD File Offset: 0x009113CD
		public unsafe FName VectorName
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LFPerShadow_seq_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LFPerShadow_seq_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17003052 RID: 12370
		// (get) Token: 0x0601F805 RID: 129029 RVA: 0x009131E2 File Offset: 0x009113E2
		// (set) Token: 0x0601F806 RID: 129030 RVA: 0x009131F2 File Offset: 0x009113F2
		public unsafe float Contrast
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LFPerShadow_seq_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LFPerShadow_seq_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17003053 RID: 12371
		// (get) Token: 0x0601F807 RID: 129031 RVA: 0x00913203 File Offset: 0x00911403
		// (set) Token: 0x0601F808 RID: 129032 RVA: 0x00913217 File Offset: 0x00911417
		public unsafe FName RotationAndOther
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LFPerShadow_seq_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LFPerShadow_seq_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17003054 RID: 12372
		// (get) Token: 0x0601F809 RID: 129033 RVA: 0x0091322C File Offset: 0x0091142C
		// (set) Token: 0x0601F80A RID: 129034 RVA: 0x0091323C File Offset: 0x0091143C
		public unsafe float Evolutionary_rate
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LFPerShadow_seq_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LFPerShadow_seq_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17003055 RID: 12373
		// (get) Token: 0x0601F80B RID: 129035 RVA: 0x0091324D File Offset: 0x0091144D
		// (set) Token: 0x0601F80C RID: 129036 RVA: 0x00913261 File Offset: 0x00911461
		public unsafe FName EvolutionaryInten
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LFPerShadow_seq_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LFPerShadow_seq_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17003056 RID: 12374
		// (get) Token: 0x0601F80D RID: 129037 RVA: 0x00913276 File Offset: 0x00911476
		// (set) Token: 0x0601F80E RID: 129038 RVA: 0x00913286 File Offset: 0x00911486
		public unsafe float EvolutionaryIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LFPerShadow_seq_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LFPerShadow_seq_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x0601F80F RID: 129039 RVA: 0x00913297 File Offset: 0x00911497
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SetMPC()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LFPerShadow_seq_C.__SetMPC_NativeFunctionPtr, null);
		}

		// Token: 0x0601F810 RID: 129040 RVA: 0x009132AB File Offset: 0x009114AB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LFPerShadow_seq_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0601F811 RID: 129041 RVA: 0x009132BF File Offset: 0x009114BF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_LFPerShadow_seq_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601F812 RID: 129042 RVA: 0x009132D4 File Offset: 0x009114D4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_LFPerShadow_seq_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_LFPerShadow_seq_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_LFPerShadow_seq_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LFPerShadow_seq_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LFPerShadow_seq_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F813 RID: 129043 RVA: 0x0091331C File Offset: 0x0091151C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_LFPerShadow_seq_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_LFPerShadow_seq_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_LFPerShadow_seq_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LFPerShadow_seq_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_LFPerShadow_seq_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F814 RID: 129044 RVA: 0x00913364 File Offset: 0x00911564
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_LFPerShadow_seq(int EntryPoint)
		{
			BP_LFPerShadow_seq_C.__ExecuteUbergraph_BP_LFPerShadow_seq_FunctionParams* ptr = stackalloc BP_LFPerShadow_seq_C.__ExecuteUbergraph_BP_LFPerShadow_seq_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_LFPerShadow_seq_C.__ExecuteUbergraph_BP_LFPerShadow_seq_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LFPerShadow_seq_C.__ExecuteUbergraph_BP_LFPerShadow_seq_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_LFPerShadow_seq_C.__ExecuteUbergraph_BP_LFPerShadow_seq_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F815 RID: 129045 RVA: 0x009133AB File Offset: 0x009115AB
		protected BP_LFPerShadow_seq_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400FA5C RID: 64092
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_LFPerShadow_seq.BP_LFPerShadow_seq_C";

		// Token: 0x0400FA5D RID: 64093
		private static IntPtr _ClassPtr;

		// Token: 0x0400FA5E RID: 64094
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400FA5F RID: 64095
		internal static int __PropertyOffset_0;

		// Token: 0x0400FA60 RID: 64096
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400FA61 RID: 64097
		internal static int __PropertyOffset_1;

		// Token: 0x0400FA62 RID: 64098
		internal static int __PropertyOffset_2;

		// Token: 0x0400FA63 RID: 64099
		internal static int __PropertyOffset_3;

		// Token: 0x0400FA64 RID: 64100
		internal static int __PropertyOffset_4;

		// Token: 0x0400FA65 RID: 64101
		internal static int __PropertyOffset_5;

		// Token: 0x0400FA66 RID: 64102
		internal static int __PropertyOffset_6;

		// Token: 0x0400FA67 RID: 64103
		internal static int __PropertyOffset_7;

		// Token: 0x0400FA68 RID: 64104
		internal static int __PropertyOffset_8;

		// Token: 0x0400FA69 RID: 64105
		internal static int __PropertyOffset_9;

		// Token: 0x0400FA6A RID: 64106
		private static IntPtr __SetMPC_NativeFunctionPtr;

		// Token: 0x0400FA6B RID: 64107
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0400FA6C RID: 64108
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400FA6D RID: 64109
		private static IntPtr __ExecuteUbergraph_BP_LFPerShadow_seq_NativeFunctionPtr;

		// Token: 0x020098E7 RID: 39143
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031F44 RID: 204612
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x020098E8 RID: 39144
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __ExecuteUbergraph_BP_LFPerShadow_seq_FunctionParams
		{
			// Token: 0x04031F45 RID: 204613
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
