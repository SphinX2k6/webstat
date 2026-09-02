using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Sequence
{
	// Token: 0x02003A61 RID: 14945
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Sequence/BP_StillFramePicturePostProcess.BP_StillFramePicturePostProcess_C")]
	[UnrealStructLayout(1400, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1396)]
	public class BP_StillFramePicturePostProcess_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601F14D RID: 127309 RVA: 0x009073C7 File Offset: 0x009055C7
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_StillFramePicturePostProcess_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Sequence/BP_StillFramePicturePostProcess.BP_StillFramePicturePostProcess_C");
			}
			return BP_StillFramePicturePostProcess_C._ClassPtr;
		}

		// Token: 0x0601F14E RID: 127310 RVA: 0x009073EC File Offset: 0x009055EC
		public BP_StillFramePicturePostProcess_C() : this(BuiltinUtils.AllocNativeUObject(BP_StillFramePicturePostProcess_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601F14F RID: 127311 RVA: 0x00907414 File Offset: 0x00905614
		[NullableContext(1)]
		public BP_StillFramePicturePostProcess_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_StillFramePicturePostProcess_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002DF6 RID: 11766
		// (get) Token: 0x0601F150 RID: 127312 RVA: 0x00907448 File Offset: 0x00905648
		// (set) Token: 0x0601F151 RID: 127313 RVA: 0x00907481 File Offset: 0x00905681
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_StillFramePicturePostProcess_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_StillFramePicturePostProcess_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17002DF7 RID: 11767
		// (get) Token: 0x0601F152 RID: 127314 RVA: 0x009074A2 File Offset: 0x009056A2
		// (set) Token: 0x0601F153 RID: 127315 RVA: 0x009074B6 File Offset: 0x009056B6
		public unsafe UKuroPostProcessComponent KuroPostProcess
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroPostProcessComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_StillFramePicturePostProcess_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_StillFramePicturePostProcess_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17002DF8 RID: 11768
		// (get) Token: 0x0601F154 RID: 127316 RVA: 0x009074CB File Offset: 0x009056CB
		// (set) Token: 0x0601F155 RID: 127317 RVA: 0x009074DF File Offset: 0x009056DF
		public unsafe UMaterialInterface MainMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInterface>(base.NativePtr / (IntPtr)sizeof(void*) + BP_StillFramePicturePostProcess_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_StillFramePicturePostProcess_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17002DF9 RID: 11769
		// (get) Token: 0x0601F156 RID: 127318 RVA: 0x009074F4 File Offset: 0x009056F4
		// (set) Token: 0x0601F157 RID: 127319 RVA: 0x00907508 File Offset: 0x00905708
		public unsafe UMaterialInstanceDynamic DynamicMaterialInstance
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_StillFramePicturePostProcess_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_StillFramePicturePostProcess_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17002DFA RID: 11770
		// (get) Token: 0x0601F158 RID: 127320 RVA: 0x0090751D File Offset: 0x0090571D
		// (set) Token: 0x0601F159 RID: 127321 RVA: 0x00907531 File Offset: 0x00905731
		public unsafe UTexture FirstTexture
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture>(base.NativePtr / (IntPtr)sizeof(void*) + BP_StillFramePicturePostProcess_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_StillFramePicturePostProcess_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17002DFB RID: 11771
		// (get) Token: 0x0601F15A RID: 127322 RVA: 0x00907546 File Offset: 0x00905746
		// (set) Token: 0x0601F15B RID: 127323 RVA: 0x0090755A File Offset: 0x0090575A
		public unsafe UTexture SecondTexture
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture>(base.NativePtr / (IntPtr)sizeof(void*) + BP_StillFramePicturePostProcess_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_StillFramePicturePostProcess_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17002DFC RID: 11772
		// (get) Token: 0x0601F15C RID: 127324 RVA: 0x0090756F File Offset: 0x0090576F
		// (set) Token: 0x0601F15D RID: 127325 RVA: 0x0090757F File Offset: 0x0090577F
		public unsafe float Alpha
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_StillFramePicturePostProcess_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_StillFramePicturePostProcess_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17002DFD RID: 11773
		// (get) Token: 0x0601F15E RID: 127326 RVA: 0x00907590 File Offset: 0x00905790
		// (set) Token: 0x0601F15F RID: 127327 RVA: 0x009075A0 File Offset: 0x009057A0
		public unsafe float First_V_Pos
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_StillFramePicturePostProcess_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_StillFramePicturePostProcess_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17002DFE RID: 11774
		// (get) Token: 0x0601F160 RID: 127328 RVA: 0x009075B1 File Offset: 0x009057B1
		// (set) Token: 0x0601F161 RID: 127329 RVA: 0x009075C1 File Offset: 0x009057C1
		public unsafe float First_U_Pos
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_StillFramePicturePostProcess_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_StillFramePicturePostProcess_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17002DFF RID: 11775
		// (get) Token: 0x0601F162 RID: 127330 RVA: 0x009075D2 File Offset: 0x009057D2
		// (set) Token: 0x0601F163 RID: 127331 RVA: 0x009075E2 File Offset: 0x009057E2
		public unsafe float First_UV_Scale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_StillFramePicturePostProcess_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_StillFramePicturePostProcess_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17002E00 RID: 11776
		// (get) Token: 0x0601F164 RID: 127332 RVA: 0x009075F3 File Offset: 0x009057F3
		// (set) Token: 0x0601F165 RID: 127333 RVA: 0x00907603 File Offset: 0x00905803
		public unsafe float First_Saturation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_StillFramePicturePostProcess_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_StillFramePicturePostProcess_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17002E01 RID: 11777
		// (get) Token: 0x0601F166 RID: 127334 RVA: 0x00907614 File Offset: 0x00905814
		// (set) Token: 0x0601F167 RID: 127335 RVA: 0x00907624 File Offset: 0x00905824
		public unsafe float Second_U_Pos
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_StillFramePicturePostProcess_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_StillFramePicturePostProcess_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17002E02 RID: 11778
		// (get) Token: 0x0601F168 RID: 127336 RVA: 0x00907635 File Offset: 0x00905835
		// (set) Token: 0x0601F169 RID: 127337 RVA: 0x00907645 File Offset: 0x00905845
		public unsafe float Second_V_Pos
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_StillFramePicturePostProcess_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_StillFramePicturePostProcess_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17002E03 RID: 11779
		// (get) Token: 0x0601F16A RID: 127338 RVA: 0x00907656 File Offset: 0x00905856
		// (set) Token: 0x0601F16B RID: 127339 RVA: 0x00907666 File Offset: 0x00905866
		public unsafe float Second_UV_Scale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_StillFramePicturePostProcess_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_StillFramePicturePostProcess_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17002E04 RID: 11780
		// (get) Token: 0x0601F16C RID: 127340 RVA: 0x00907677 File Offset: 0x00905877
		// (set) Token: 0x0601F16D RID: 127341 RVA: 0x00907687 File Offset: 0x00905887
		public unsafe float Second_Saturation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_StillFramePicturePostProcess_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_StillFramePicturePostProcess_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x0601F16E RID: 127342 RVA: 0x00907698 File Offset: 0x00905898
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_StillFramePicturePostProcess_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0601F16F RID: 127343 RVA: 0x009076AC File Offset: 0x009058AC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_StillFramePicturePostProcess_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601F170 RID: 127344 RVA: 0x009076C4 File Offset: 0x009058C4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_StillFramePicturePostProcess_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_StillFramePicturePostProcess_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_StillFramePicturePostProcess_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_StillFramePicturePostProcess_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_StillFramePicturePostProcess_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F171 RID: 127345 RVA: 0x0090770C File Offset: 0x0090590C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_StillFramePicturePostProcess_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_StillFramePicturePostProcess_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_StillFramePicturePostProcess_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_StillFramePicturePostProcess_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_StillFramePicturePostProcess_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F172 RID: 127346 RVA: 0x00907753 File Offset: 0x00905953
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_StillFramePicturePostProcess_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0601F173 RID: 127347 RVA: 0x00907767 File Offset: 0x00905967
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_StillFramePicturePostProcess_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601F174 RID: 127348 RVA: 0x0090777C File Offset: 0x0090597C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_StillFramePicturePostProcess_C.__EditorTick_FunctionParams* ptr = stackalloc BP_StillFramePicturePostProcess_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_StillFramePicturePostProcess_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_StillFramePicturePostProcess_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_StillFramePicturePostProcess_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F175 RID: 127349 RVA: 0x009077C4 File Offset: 0x009059C4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_StillFramePicturePostProcess_C.__EditorTick_FunctionParams* ptr = stackalloc BP_StillFramePicturePostProcess_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_StillFramePicturePostProcess_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_StillFramePicturePostProcess_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_StillFramePicturePostProcess_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F176 RID: 127350 RVA: 0x0090780C File Offset: 0x00905A0C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_StillFramePicturePostProcess(int EntryPoint)
		{
			BP_StillFramePicturePostProcess_C.__ExecuteUbergraph_BP_StillFramePicturePostProcess_FunctionParams* ptr = stackalloc BP_StillFramePicturePostProcess_C.__ExecuteUbergraph_BP_StillFramePicturePostProcess_FunctionParams[(UIntPtr)111] + 15L / (long)sizeof(BP_StillFramePicturePostProcess_C.__ExecuteUbergraph_BP_StillFramePicturePostProcess_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_StillFramePicturePostProcess_C.__ExecuteUbergraph_BP_StillFramePicturePostProcess_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_StillFramePicturePostProcess_C.__ExecuteUbergraph_BP_StillFramePicturePostProcess_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F177 RID: 127351 RVA: 0x00907853 File Offset: 0x00905A53
		protected BP_StillFramePicturePostProcess_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400F634 RID: 63028
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Sequence/BP_StillFramePicturePostProcess.BP_StillFramePicturePostProcess_C";

		// Token: 0x0400F635 RID: 63029
		private static IntPtr _ClassPtr;

		// Token: 0x0400F636 RID: 63030
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400F637 RID: 63031
		internal static int __PropertyOffset_0;

		// Token: 0x0400F638 RID: 63032
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400F639 RID: 63033
		internal static int __PropertyOffset_1;

		// Token: 0x0400F63A RID: 63034
		internal static int __PropertyOffset_2;

		// Token: 0x0400F63B RID: 63035
		internal static int __PropertyOffset_3;

		// Token: 0x0400F63C RID: 63036
		internal static int __PropertyOffset_4;

		// Token: 0x0400F63D RID: 63037
		internal static int __PropertyOffset_5;

		// Token: 0x0400F63E RID: 63038
		internal static int __PropertyOffset_6;

		// Token: 0x0400F63F RID: 63039
		internal static int __PropertyOffset_7;

		// Token: 0x0400F640 RID: 63040
		internal static int __PropertyOffset_8;

		// Token: 0x0400F641 RID: 63041
		internal static int __PropertyOffset_9;

		// Token: 0x0400F642 RID: 63042
		internal static int __PropertyOffset_10;

		// Token: 0x0400F643 RID: 63043
		internal static int __PropertyOffset_11;

		// Token: 0x0400F644 RID: 63044
		internal static int __PropertyOffset_12;

		// Token: 0x0400F645 RID: 63045
		internal static int __PropertyOffset_13;

		// Token: 0x0400F646 RID: 63046
		internal static int __PropertyOffset_14;

		// Token: 0x0400F647 RID: 63047
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0400F648 RID: 63048
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400F649 RID: 63049
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400F64A RID: 63050
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x0400F64B RID: 63051
		private static IntPtr __ExecuteUbergraph_BP_StillFramePicturePostProcess_NativeFunctionPtr;

		// Token: 0x0200985A RID: 39002
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031E8F RID: 204431
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200985B RID: 39003
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04031E90 RID: 204432
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200985C RID: 39004
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 96)]
		protected ref struct __ExecuteUbergraph_BP_StillFramePicturePostProcess_FunctionParams
		{
			// Token: 0x04031E91 RID: 204433
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
