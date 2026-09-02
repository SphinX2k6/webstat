using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Sequence
{
	// Token: 0x02003A56 RID: 14934
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Sequence/BP_CameraBreathe.BP_CameraBreathe_C")]
	[UnrealStructLayout(1424, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1424)]
	public class BP_CameraBreathe_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601F036 RID: 127030 RVA: 0x00904E18 File Offset: 0x00903018
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_CameraBreathe_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Sequence/BP_CameraBreathe.BP_CameraBreathe_C");
			}
			return BP_CameraBreathe_C._ClassPtr;
		}

		// Token: 0x0601F037 RID: 127031 RVA: 0x00904E3C File Offset: 0x0090303C
		public BP_CameraBreathe_C() : this(BuiltinUtils.AllocNativeUObject(BP_CameraBreathe_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601F038 RID: 127032 RVA: 0x00904E64 File Offset: 0x00903064
		[NullableContext(1)]
		public BP_CameraBreathe_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_CameraBreathe_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002DAA RID: 11690
		// (get) Token: 0x0601F039 RID: 127033 RVA: 0x00904E98 File Offset: 0x00903098
		// (set) Token: 0x0601F03A RID: 127034 RVA: 0x00904ED1 File Offset: 0x009030D1
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_CameraBreathe_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_CameraBreathe_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17002DAB RID: 11691
		// (get) Token: 0x0601F03B RID: 127035 RVA: 0x00904EF2 File Offset: 0x009030F2
		// (set) Token: 0x0601F03C RID: 127036 RVA: 0x00904F06 File Offset: 0x00903106
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CameraBreathe_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CameraBreathe_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17002DAC RID: 11692
		// (get) Token: 0x0601F03D RID: 127037 RVA: 0x00904F1B File Offset: 0x0090311B
		// (set) Token: 0x0601F03E RID: 127038 RVA: 0x00904F2F File Offset: 0x0090312F
		public unsafe ACameraActor Camera
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<ACameraActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CameraBreathe_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CameraBreathe_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17002DAD RID: 11693
		// (get) Token: 0x0601F03F RID: 127039 RVA: 0x00904F44 File Offset: 0x00903144
		// (set) Token: 0x0601F040 RID: 127040 RVA: 0x00904F58 File Offset: 0x00903158
		public unsafe AActor CameraAttachActor
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CameraBreathe_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CameraBreathe_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17002DAE RID: 11694
		// (get) Token: 0x0601F041 RID: 127041 RVA: 0x00904F6D File Offset: 0x0090316D
		// (set) Token: 0x0601F042 RID: 127042 RVA: 0x00904F7D File Offset: 0x0090317D
		public unsafe float CameraNewFocalLength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraBreathe_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraBreathe_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17002DAF RID: 11695
		// (get) Token: 0x0601F043 RID: 127043 RVA: 0x00904F8E File Offset: 0x0090318E
		// (set) Token: 0x0601F044 RID: 127044 RVA: 0x00904FA2 File Offset: 0x009031A2
		public unsafe FVectorDouble CameraMoveTransform_D
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraBreathe_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraBreathe_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17002DB0 RID: 11696
		// (get) Token: 0x0601F045 RID: 127045 RVA: 0x00904FB7 File Offset: 0x009031B7
		// (set) Token: 0x0601F046 RID: 127046 RVA: 0x00904FC7 File Offset: 0x009031C7
		public unsafe float PositionIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraBreathe_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraBreathe_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17002DB1 RID: 11697
		// (get) Token: 0x0601F047 RID: 127047 RVA: 0x00904FD8 File Offset: 0x009031D8
		// (set) Token: 0x0601F048 RID: 127048 RVA: 0x00904FE8 File Offset: 0x009031E8
		public unsafe float FOVIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraBreathe_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraBreathe_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17002DB2 RID: 11698
		// (get) Token: 0x0601F049 RID: 127049 RVA: 0x00904FF9 File Offset: 0x009031F9
		// (set) Token: 0x0601F04A RID: 127050 RVA: 0x00905009 File Offset: 0x00903209
		public unsafe float StartManualFocusDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraBreathe_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraBreathe_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17002DB3 RID: 11699
		// (get) Token: 0x0601F04B RID: 127051 RVA: 0x0090501A File Offset: 0x0090321A
		// (set) Token: 0x0601F04C RID: 127052 RVA: 0x0090502A File Offset: 0x0090322A
		public unsafe float DifParameter
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraBreathe_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraBreathe_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17002DB4 RID: 11700
		// (get) Token: 0x0601F04D RID: 127053 RVA: 0x0090503B File Offset: 0x0090323B
		// (set) Token: 0x0601F04E RID: 127054 RVA: 0x0090504B File Offset: 0x0090324B
		public unsafe float K_ManualFocusDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraBreathe_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraBreathe_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17002DB5 RID: 11701
		// (get) Token: 0x0601F04F RID: 127055 RVA: 0x0090505C File Offset: 0x0090325C
		// (set) Token: 0x0601F050 RID: 127056 RVA: 0x00905070 File Offset: 0x00903270
		public unsafe FVectorDouble SequenceCenterPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraBreathe_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraBreathe_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x0601F051 RID: 127057 RVA: 0x00905085 File Offset: 0x00903285
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SetParameter()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CameraBreathe_C.__SetParameter_NativeFunctionPtr, null);
		}

		// Token: 0x0601F052 RID: 127058 RVA: 0x00905099 File Offset: 0x00903299
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CameraBreathe_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0601F053 RID: 127059 RVA: 0x009050AD File Offset: 0x009032AD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CameraBreathe_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601F054 RID: 127060 RVA: 0x009050C4 File Offset: 0x009032C4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_CameraBreathe_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_CameraBreathe_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_CameraBreathe_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CameraBreathe_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CameraBreathe_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F055 RID: 127061 RVA: 0x0090510C File Offset: 0x0090330C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_CameraBreathe_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_CameraBreathe_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_CameraBreathe_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CameraBreathe_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CameraBreathe_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F056 RID: 127062 RVA: 0x00905154 File Offset: 0x00903354
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_CameraBreathe_C.__EditorTick_FunctionParams* ptr = stackalloc BP_CameraBreathe_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_CameraBreathe_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CameraBreathe_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CameraBreathe_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F057 RID: 127063 RVA: 0x0090519C File Offset: 0x0090339C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_CameraBreathe_C.__EditorTick_FunctionParams* ptr = stackalloc BP_CameraBreathe_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_CameraBreathe_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CameraBreathe_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CameraBreathe_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F058 RID: 127064 RVA: 0x009051E3 File Offset: 0x009033E3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveDestroyed()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CameraBreathe_C.__ReceiveDestroyed_NativeFunctionPtr, null);
		}

		// Token: 0x0601F059 RID: 127065 RVA: 0x009051F7 File Offset: 0x009033F7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveDestroyed_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CameraBreathe_C.__ReceiveDestroyed_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601F05A RID: 127066 RVA: 0x0090520C File Offset: 0x0090340C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_CameraBreathe(int EntryPoint)
		{
			BP_CameraBreathe_C.__ExecuteUbergraph_BP_CameraBreathe_FunctionParams* ptr = stackalloc BP_CameraBreathe_C.__ExecuteUbergraph_BP_CameraBreathe_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_CameraBreathe_C.__ExecuteUbergraph_BP_CameraBreathe_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CameraBreathe_C.__ExecuteUbergraph_BP_CameraBreathe_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CameraBreathe_C.__ExecuteUbergraph_BP_CameraBreathe_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F05B RID: 127067 RVA: 0x00905253 File Offset: 0x00903453
		protected BP_CameraBreathe_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400F57C RID: 62844
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Sequence/BP_CameraBreathe.BP_CameraBreathe_C";

		// Token: 0x0400F57D RID: 62845
		private static IntPtr _ClassPtr;

		// Token: 0x0400F57E RID: 62846
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400F57F RID: 62847
		internal static int __PropertyOffset_0;

		// Token: 0x0400F580 RID: 62848
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400F581 RID: 62849
		internal static int __PropertyOffset_1;

		// Token: 0x0400F582 RID: 62850
		internal static int __PropertyOffset_2;

		// Token: 0x0400F583 RID: 62851
		internal static int __PropertyOffset_3;

		// Token: 0x0400F584 RID: 62852
		internal static int __PropertyOffset_4;

		// Token: 0x0400F585 RID: 62853
		internal static int __PropertyOffset_5;

		// Token: 0x0400F586 RID: 62854
		internal static int __PropertyOffset_6;

		// Token: 0x0400F587 RID: 62855
		internal static int __PropertyOffset_7;

		// Token: 0x0400F588 RID: 62856
		internal static int __PropertyOffset_8;

		// Token: 0x0400F589 RID: 62857
		internal static int __PropertyOffset_9;

		// Token: 0x0400F58A RID: 62858
		internal static int __PropertyOffset_10;

		// Token: 0x0400F58B RID: 62859
		internal static int __PropertyOffset_11;

		// Token: 0x0400F58C RID: 62860
		private static IntPtr __SetParameter_NativeFunctionPtr;

		// Token: 0x0400F58D RID: 62861
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0400F58E RID: 62862
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400F58F RID: 62863
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x0400F590 RID: 62864
		private static IntPtr __ReceiveDestroyed_NativeFunctionPtr;

		// Token: 0x0400F591 RID: 62865
		private static IntPtr __ExecuteUbergraph_BP_CameraBreathe_NativeFunctionPtr;

		// Token: 0x0200983D RID: 38973
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031E70 RID: 204400
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200983E RID: 38974
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04031E71 RID: 204401
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200983F RID: 38975
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __ExecuteUbergraph_BP_CameraBreathe_FunctionParams
		{
			// Token: 0x04031E72 RID: 204402
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
