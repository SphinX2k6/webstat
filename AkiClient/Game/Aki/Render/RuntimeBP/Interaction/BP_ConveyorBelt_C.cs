using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Interaction
{
	// Token: 0x02003C78 RID: 15480
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Interaction/BP_ConveyorBelt.BP_ConveyorBelt_C")]
	[UnrealStructLayout(1360, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1360)]
	public class BP_ConveyorBelt_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06023F6C RID: 147308 RVA: 0x00990E0C File Offset: 0x0098F00C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_ConveyorBelt_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Interaction/BP_ConveyorBelt.BP_ConveyorBelt_C");
			}
			return BP_ConveyorBelt_C._ClassPtr;
		}

		// Token: 0x06023F6D RID: 147309 RVA: 0x00990E30 File Offset: 0x0098F030
		public BP_ConveyorBelt_C() : this(BuiltinUtils.AllocNativeUObject(BP_ConveyorBelt_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06023F6E RID: 147310 RVA: 0x00990E58 File Offset: 0x0098F058
		[NullableContext(1)]
		public BP_ConveyorBelt_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_ConveyorBelt_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700494A RID: 18762
		// (get) Token: 0x06023F6F RID: 147311 RVA: 0x00990E8C File Offset: 0x0098F08C
		// (set) Token: 0x06023F70 RID: 147312 RVA: 0x00990EC5 File Offset: 0x0098F0C5
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_ConveyorBelt_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_ConveyorBelt_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700494B RID: 18763
		// (get) Token: 0x06023F71 RID: 147313 RVA: 0x00990EE6 File Offset: 0x0098F0E6
		// (set) Token: 0x06023F72 RID: 147314 RVA: 0x00990EFA File Offset: 0x0098F0FA
		public unsafe UStaticMeshComponent StaticMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ConveyorBelt_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ConveyorBelt_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x1700494C RID: 18764
		// (get) Token: 0x06023F73 RID: 147315 RVA: 0x00990F0F File Offset: 0x0098F10F
		// (set) Token: 0x06023F74 RID: 147316 RVA: 0x00990F23 File Offset: 0x0098F123
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ConveyorBelt_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ConveyorBelt_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x1700494D RID: 18765
		// (get) Token: 0x06023F75 RID: 147317 RVA: 0x00990F38 File Offset: 0x0098F138
		// (set) Token: 0x06023F76 RID: 147318 RVA: 0x00990F4C File Offset: 0x0098F14C
		public unsafe UStaticMesh ConveyorBeltMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ConveyorBelt_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ConveyorBelt_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x1700494E RID: 18766
		// (get) Token: 0x06023F77 RID: 147319 RVA: 0x00990F61 File Offset: 0x0098F161
		// (set) Token: 0x06023F78 RID: 147320 RVA: 0x00990F71 File Offset: 0x0098F171
		public unsafe int ConveyorBeltMaterialElementIndex
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ConveyorBelt_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ConveyorBelt_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x1700494F RID: 18767
		// (get) Token: 0x06023F79 RID: 147321 RVA: 0x00990F82 File Offset: 0x0098F182
		// (set) Token: 0x06023F7A RID: 147322 RVA: 0x00990F92 File Offset: 0x0098F192
		public unsafe float RunningSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ConveyorBelt_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ConveyorBelt_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17004950 RID: 18768
		// (get) Token: 0x06023F7B RID: 147323 RVA: 0x00990FA3 File Offset: 0x0098F1A3
		// (set) Token: 0x06023F7C RID: 147324 RVA: 0x00990FB7 File Offset: 0x0098F1B7
		public unsafe UMaterialInstanceDynamic ConveyorBeltDMI
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ConveyorBelt_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ConveyorBelt_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x06023F7D RID: 147325 RVA: 0x00990FCC File Offset: 0x0098F1CC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CreateDMI()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ConveyorBelt_C.__CreateDMI_NativeFunctionPtr, null);
		}

		// Token: 0x06023F7E RID: 147326 RVA: 0x00990FE0 File Offset: 0x0098F1E0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ConveyorBelt_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06023F7F RID: 147327 RVA: 0x00990FF4 File Offset: 0x0098F1F4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_ConveyorBelt_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06023F80 RID: 147328 RVA: 0x00991009 File Offset: 0x0098F209
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ConveyorBelt_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06023F81 RID: 147329 RVA: 0x0099101D File Offset: 0x0098F21D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_ConveyorBelt_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06023F82 RID: 147330 RVA: 0x00991034 File Offset: 0x0098F234
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_ConveyorBelt_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_ConveyorBelt_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_ConveyorBelt_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ConveyorBelt_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ConveyorBelt_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06023F83 RID: 147331 RVA: 0x0099107C File Offset: 0x0098F27C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_ConveyorBelt_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_ConveyorBelt_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_ConveyorBelt_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ConveyorBelt_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_ConveyorBelt_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023F84 RID: 147332 RVA: 0x009910C4 File Offset: 0x0098F2C4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_ConveyorBelt_C.__EditorTick_FunctionParams* ptr = stackalloc BP_ConveyorBelt_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_ConveyorBelt_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ConveyorBelt_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ConveyorBelt_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06023F85 RID: 147333 RVA: 0x0099110C File Offset: 0x0098F30C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_ConveyorBelt_C.__EditorTick_FunctionParams* ptr = stackalloc BP_ConveyorBelt_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_ConveyorBelt_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ConveyorBelt_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_ConveyorBelt_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023F86 RID: 147334 RVA: 0x00991154 File Offset: 0x0098F354
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_ConveyorBelt(int EntryPoint)
		{
			BP_ConveyorBelt_C.__ExecuteUbergraph_BP_ConveyorBelt_FunctionParams* ptr = stackalloc BP_ConveyorBelt_C.__ExecuteUbergraph_BP_ConveyorBelt_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(BP_ConveyorBelt_C.__ExecuteUbergraph_BP_ConveyorBelt_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ConveyorBelt_C.__ExecuteUbergraph_BP_ConveyorBelt_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_ConveyorBelt_C.__ExecuteUbergraph_BP_ConveyorBelt_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023F87 RID: 147335 RVA: 0x0099119B File Offset: 0x0098F39B
		protected BP_ConveyorBelt_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04012600 RID: 75264
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Interaction/BP_ConveyorBelt.BP_ConveyorBelt_C";

		// Token: 0x04012601 RID: 75265
		private static IntPtr _ClassPtr;

		// Token: 0x04012602 RID: 75266
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04012603 RID: 75267
		internal static int __PropertyOffset_0;

		// Token: 0x04012604 RID: 75268
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04012605 RID: 75269
		internal static int __PropertyOffset_1;

		// Token: 0x04012606 RID: 75270
		internal static int __PropertyOffset_2;

		// Token: 0x04012607 RID: 75271
		internal static int __PropertyOffset_3;

		// Token: 0x04012608 RID: 75272
		internal static int __PropertyOffset_4;

		// Token: 0x04012609 RID: 75273
		internal static int __PropertyOffset_5;

		// Token: 0x0401260A RID: 75274
		internal static int __PropertyOffset_6;

		// Token: 0x0401260B RID: 75275
		private static IntPtr __CreateDMI_NativeFunctionPtr;

		// Token: 0x0401260C RID: 75276
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0401260D RID: 75277
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0401260E RID: 75278
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0401260F RID: 75279
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x04012610 RID: 75280
		private static IntPtr __ExecuteUbergraph_BP_ConveyorBelt_NativeFunctionPtr;

		// Token: 0x02009D6C RID: 40300
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032761 RID: 206689
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009D6D RID: 40301
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04032762 RID: 206690
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009D6E RID: 40302
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __ExecuteUbergraph_BP_ConveyorBelt_FunctionParams
		{
			// Token: 0x04032763 RID: 206691
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
