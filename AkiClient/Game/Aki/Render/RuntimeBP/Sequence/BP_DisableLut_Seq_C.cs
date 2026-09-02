using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Sequence
{
	// Token: 0x02003A59 RID: 14937
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Sequence/BP_DisableLut_Seq.BP_DisableLut_Seq_C")]
	[UnrealStructLayout(1336, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1335)]
	public class BP_DisableLut_Seq_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601F085 RID: 127109 RVA: 0x00905798 File Offset: 0x00903998
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_DisableLut_Seq_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Sequence/BP_DisableLut_Seq.BP_DisableLut_Seq_C");
			}
			return BP_DisableLut_Seq_C._ClassPtr;
		}

		// Token: 0x0601F086 RID: 127110 RVA: 0x009057BC File Offset: 0x009039BC
		public BP_DisableLut_Seq_C() : this(BuiltinUtils.AllocNativeUObject(BP_DisableLut_Seq_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601F087 RID: 127111 RVA: 0x009057E4 File Offset: 0x009039E4
		[NullableContext(1)]
		public BP_DisableLut_Seq_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_DisableLut_Seq_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002DBF RID: 11711
		// (get) Token: 0x0601F088 RID: 127112 RVA: 0x00905818 File Offset: 0x00903A18
		// (set) Token: 0x0601F089 RID: 127113 RVA: 0x00905851 File Offset: 0x00903A51
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_DisableLut_Seq_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_DisableLut_Seq_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17002DC0 RID: 11712
		// (get) Token: 0x0601F08A RID: 127114 RVA: 0x00905872 File Offset: 0x00903A72
		// (set) Token: 0x0601F08B RID: 127115 RVA: 0x00905886 File Offset: 0x00903A86
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DisableLut_Seq_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DisableLut_Seq_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17002DC1 RID: 11713
		// (get) Token: 0x0601F08C RID: 127116 RVA: 0x0090589B File Offset: 0x00903A9B
		// (set) Token: 0x0601F08D RID: 127117 RVA: 0x009058AB File Offset: 0x00903AAB
		public unsafe float SceneLightIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DisableLut_Seq_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DisableLut_Seq_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17002DC2 RID: 11714
		// (get) Token: 0x0601F08E RID: 127118 RVA: 0x009058BC File Offset: 0x00903ABC
		// (set) Token: 0x0601F08F RID: 127119 RVA: 0x009058CC File Offset: 0x00903ACC
		public unsafe bool DisableLut_Store
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DisableLut_Seq_C.__PropertyOffset_3) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DisableLut_Seq_C.__PropertyOffset_3) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002DC3 RID: 11715
		// (get) Token: 0x0601F090 RID: 127120 RVA: 0x009058DD File Offset: 0x00903ADD
		// (set) Token: 0x0601F091 RID: 127121 RVA: 0x009058ED File Offset: 0x00903AED
		public unsafe bool DisableLut
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DisableLut_Seq_C.__PropertyOffset_4) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DisableLut_Seq_C.__PropertyOffset_4) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002DC4 RID: 11716
		// (get) Token: 0x0601F092 RID: 127122 RVA: 0x009058FE File Offset: 0x00903AFE
		// (set) Token: 0x0601F093 RID: 127123 RVA: 0x0090590E File Offset: 0x00903B0E
		public unsafe bool EnableLut_Lerp
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DisableLut_Seq_C.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DisableLut_Seq_C.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x0601F094 RID: 127124 RVA: 0x0090591F File Offset: 0x00903B1F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void TickGlobalGI()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DisableLut_Seq_C.__TickGlobalGI_NativeFunctionPtr, null);
		}

		// Token: 0x0601F095 RID: 127125 RVA: 0x00905933 File Offset: 0x00903B33
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void TickFunction()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DisableLut_Seq_C.__TickFunction_NativeFunctionPtr, null);
		}

		// Token: 0x0601F096 RID: 127126 RVA: 0x00905947 File Offset: 0x00903B47
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DisableLut_Seq_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0601F097 RID: 127127 RVA: 0x0090595B File Offset: 0x00903B5B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_DisableLut_Seq_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601F098 RID: 127128 RVA: 0x00905970 File Offset: 0x00903B70
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DisableLut_Seq_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0601F099 RID: 127129 RVA: 0x00905984 File Offset: 0x00903B84
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_DisableLut_Seq_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601F09A RID: 127130 RVA: 0x0090599C File Offset: 0x00903B9C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_DisableLut_Seq_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_DisableLut_Seq_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_DisableLut_Seq_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_DisableLut_Seq_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DisableLut_Seq_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F09B RID: 127131 RVA: 0x009059E4 File Offset: 0x00903BE4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_DisableLut_Seq_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_DisableLut_Seq_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_DisableLut_Seq_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_DisableLut_Seq_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_DisableLut_Seq_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F09C RID: 127132 RVA: 0x00905A2C File Offset: 0x00903C2C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_DisableLut_Seq_C.__EditorTick_FunctionParams* ptr = stackalloc BP_DisableLut_Seq_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_DisableLut_Seq_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_DisableLut_Seq_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DisableLut_Seq_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F09D RID: 127133 RVA: 0x00905A74 File Offset: 0x00903C74
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_DisableLut_Seq_C.__EditorTick_FunctionParams* ptr = stackalloc BP_DisableLut_Seq_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_DisableLut_Seq_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_DisableLut_Seq_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_DisableLut_Seq_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F09E RID: 127134 RVA: 0x00905ABB File Offset: 0x00903CBB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveDestroyed()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DisableLut_Seq_C.__ReceiveDestroyed_NativeFunctionPtr, null);
		}

		// Token: 0x0601F09F RID: 127135 RVA: 0x00905ACF File Offset: 0x00903CCF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveDestroyed_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_DisableLut_Seq_C.__ReceiveDestroyed_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601F0A0 RID: 127136 RVA: 0x00905AE4 File Offset: 0x00903CE4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_DisableLut_Seq(int EntryPoint)
		{
			BP_DisableLut_Seq_C.__ExecuteUbergraph_BP_DisableLut_Seq_FunctionParams* ptr = stackalloc BP_DisableLut_Seq_C.__ExecuteUbergraph_BP_DisableLut_Seq_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(BP_DisableLut_Seq_C.__ExecuteUbergraph_BP_DisableLut_Seq_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_DisableLut_Seq_C.__ExecuteUbergraph_BP_DisableLut_Seq_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_DisableLut_Seq_C.__ExecuteUbergraph_BP_DisableLut_Seq_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F0A1 RID: 127137 RVA: 0x00905B2B File Offset: 0x00903D2B
		protected BP_DisableLut_Seq_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400F5AC RID: 62892
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Sequence/BP_DisableLut_Seq.BP_DisableLut_Seq_C";

		// Token: 0x0400F5AD RID: 62893
		private static IntPtr _ClassPtr;

		// Token: 0x0400F5AE RID: 62894
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400F5AF RID: 62895
		internal static int __PropertyOffset_0;

		// Token: 0x0400F5B0 RID: 62896
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400F5B1 RID: 62897
		internal static int __PropertyOffset_1;

		// Token: 0x0400F5B2 RID: 62898
		internal static int __PropertyOffset_2;

		// Token: 0x0400F5B3 RID: 62899
		internal static int __PropertyOffset_3;

		// Token: 0x0400F5B4 RID: 62900
		internal static int __PropertyOffset_4;

		// Token: 0x0400F5B5 RID: 62901
		internal static int __PropertyOffset_5;

		// Token: 0x0400F5B6 RID: 62902
		private static IntPtr __TickGlobalGI_NativeFunctionPtr;

		// Token: 0x0400F5B7 RID: 62903
		private static IntPtr __TickFunction_NativeFunctionPtr;

		// Token: 0x0400F5B8 RID: 62904
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0400F5B9 RID: 62905
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400F5BA RID: 62906
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400F5BB RID: 62907
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x0400F5BC RID: 62908
		private static IntPtr __ReceiveDestroyed_NativeFunctionPtr;

		// Token: 0x0400F5BD RID: 62909
		private static IntPtr __ExecuteUbergraph_BP_DisableLut_Seq_NativeFunctionPtr;

		// Token: 0x02009844 RID: 38980
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031E77 RID: 204407
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009845 RID: 38981
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04031E78 RID: 204408
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009846 RID: 38982
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __ExecuteUbergraph_BP_DisableLut_Seq_FunctionParams
		{
			// Token: 0x04031E79 RID: 204409
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
