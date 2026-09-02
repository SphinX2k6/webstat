using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.SceneInteraction
{
	// Token: 0x02003B8E RID: 15246
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/SceneInteraction/BP_PlantGrowthPoint_Sequence.BP_PlantGrowthPoint_Sequence_C")]
	[UnrealStructLayout(1352, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1345)]
	public class BP_PlantGrowthPoint_Sequence_C : AKuroBPEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06021C46 RID: 138310 RVA: 0x00952C83 File Offset: 0x00950E83
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_PlantGrowthPoint_Sequence_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/SceneInteraction/BP_PlantGrowthPoint_Sequence.BP_PlantGrowthPoint_Sequence_C");
			}
			return BP_PlantGrowthPoint_Sequence_C._ClassPtr;
		}

		// Token: 0x06021C47 RID: 138311 RVA: 0x00952CA8 File Offset: 0x00950EA8
		public BP_PlantGrowthPoint_Sequence_C() : this(BuiltinUtils.AllocNativeUObject(BP_PlantGrowthPoint_Sequence_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06021C48 RID: 138312 RVA: 0x00952CD0 File Offset: 0x00950ED0
		[NullableContext(1)]
		public BP_PlantGrowthPoint_Sequence_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_PlantGrowthPoint_Sequence_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003CE9 RID: 15593
		// (get) Token: 0x06021C49 RID: 138313 RVA: 0x00952D04 File Offset: 0x00950F04
		// (set) Token: 0x06021C4A RID: 138314 RVA: 0x00952D3D File Offset: 0x00950F3D
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_PlantGrowthPoint_Sequence_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_PlantGrowthPoint_Sequence_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003CEA RID: 15594
		// (get) Token: 0x06021C4B RID: 138315 RVA: 0x00952D5E File Offset: 0x00950F5E
		// (set) Token: 0x06021C4C RID: 138316 RVA: 0x00952D72 File Offset: 0x00950F72
		public unsafe USphereComponent Sphere
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USphereComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PlantGrowthPoint_Sequence_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PlantGrowthPoint_Sequence_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003CEB RID: 15595
		// (get) Token: 0x06021C4D RID: 138317 RVA: 0x00952D87 File Offset: 0x00950F87
		// (set) Token: 0x06021C4E RID: 138318 RVA: 0x00952D9B File Offset: 0x00950F9B
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PlantGrowthPoint_Sequence_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PlantGrowthPoint_Sequence_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17003CEC RID: 15596
		// (get) Token: 0x06021C4F RID: 138319 RVA: 0x00952DB0 File Offset: 0x00950FB0
		// (set) Token: 0x06021C50 RID: 138320 RVA: 0x00952DC0 File Offset: 0x00950FC0
		public unsafe bool IsDone
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PlantGrowthPoint_Sequence_C.__PropertyOffset_3) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PlantGrowthPoint_Sequence_C.__PropertyOffset_3) = (value ? 1 : 0);
			}
		}

		// Token: 0x06021C51 RID: 138321 RVA: 0x00952DD1 File Offset: 0x00950FD1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SetPos()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PlantGrowthPoint_Sequence_C.__SetPos_NativeFunctionPtr, null);
		}

		// Token: 0x06021C52 RID: 138322 RVA: 0x00952DE8 File Offset: 0x00950FE8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_PlantGrowthPoint_Sequence_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_PlantGrowthPoint_Sequence_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_PlantGrowthPoint_Sequence_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PlantGrowthPoint_Sequence_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PlantGrowthPoint_Sequence_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021C53 RID: 138323 RVA: 0x00952E30 File Offset: 0x00951030
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_PlantGrowthPoint_Sequence_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_PlantGrowthPoint_Sequence_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_PlantGrowthPoint_Sequence_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PlantGrowthPoint_Sequence_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PlantGrowthPoint_Sequence_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021C54 RID: 138324 RVA: 0x00952E78 File Offset: 0x00951078
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_PlantGrowthPoint_Sequence(int EntryPoint)
		{
			BP_PlantGrowthPoint_Sequence_C.__ExecuteUbergraph_BP_PlantGrowthPoint_Sequence_FunctionParams* ptr = stackalloc BP_PlantGrowthPoint_Sequence_C.__ExecuteUbergraph_BP_PlantGrowthPoint_Sequence_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_PlantGrowthPoint_Sequence_C.__ExecuteUbergraph_BP_PlantGrowthPoint_Sequence_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PlantGrowthPoint_Sequence_C.__ExecuteUbergraph_BP_PlantGrowthPoint_Sequence_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PlantGrowthPoint_Sequence_C.__ExecuteUbergraph_BP_PlantGrowthPoint_Sequence_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021C55 RID: 138325 RVA: 0x00952EBF File Offset: 0x009510BF
		protected BP_PlantGrowthPoint_Sequence_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04011089 RID: 69769
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/SceneInteraction/BP_PlantGrowthPoint_Sequence.BP_PlantGrowthPoint_Sequence_C";

		// Token: 0x0401108A RID: 69770
		private static IntPtr _ClassPtr;

		// Token: 0x0401108B RID: 69771
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401108C RID: 69772
		internal static int __PropertyOffset_0;

		// Token: 0x0401108D RID: 69773
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0401108E RID: 69774
		internal static int __PropertyOffset_1;

		// Token: 0x0401108F RID: 69775
		internal static int __PropertyOffset_2;

		// Token: 0x04011090 RID: 69776
		internal static int __PropertyOffset_3;

		// Token: 0x04011091 RID: 69777
		private static IntPtr __SetPos_NativeFunctionPtr;

		// Token: 0x04011092 RID: 69778
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04011093 RID: 69779
		private static IntPtr __ExecuteUbergraph_BP_PlantGrowthPoint_Sequence_NativeFunctionPtr;

		// Token: 0x02009B42 RID: 39746
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x0403231E RID: 205598
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009B43 RID: 39747
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __ExecuteUbergraph_BP_PlantGrowthPoint_Sequence_FunctionParams
		{
			// Token: 0x0403231F RID: 205599
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
