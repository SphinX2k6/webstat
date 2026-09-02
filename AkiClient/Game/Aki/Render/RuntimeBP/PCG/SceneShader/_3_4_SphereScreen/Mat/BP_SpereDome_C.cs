using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.SceneShader._3_4_SphereScreen.Mat
{
	// Token: 0x02003B85 RID: 15237
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/SceneShader/3_4_SphereScreen/Mat/BP_SpereDome.BP_SpereDome_C")]
	[UnrealStructLayout(1360, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1356)]
	public class BP_SpereDome_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06021B23 RID: 138019 RVA: 0x0095043B File Offset: 0x0094E63B
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SpereDome_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/SceneShader/3_4_SphereScreen/Mat/BP_SpereDome.BP_SpereDome_C");
			}
			return BP_SpereDome_C._ClassPtr;
		}

		// Token: 0x06021B24 RID: 138020 RVA: 0x00950460 File Offset: 0x0094E660
		public BP_SpereDome_C() : this(BuiltinUtils.AllocNativeUObject(BP_SpereDome_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06021B25 RID: 138021 RVA: 0x00950488 File Offset: 0x0094E688
		[NullableContext(1)]
		public BP_SpereDome_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SpereDome_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003C92 RID: 15506
		// (get) Token: 0x06021B26 RID: 138022 RVA: 0x009504BC File Offset: 0x0094E6BC
		// (set) Token: 0x06021B27 RID: 138023 RVA: 0x009504F5 File Offset: 0x0094E6F5
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_SpereDome_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_SpereDome_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003C93 RID: 15507
		// (get) Token: 0x06021B28 RID: 138024 RVA: 0x00950516 File Offset: 0x0094E716
		// (set) Token: 0x06021B29 RID: 138025 RVA: 0x0095052A File Offset: 0x0094E72A
		public unsafe UStaticMeshComponent StaticMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SpereDome_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SpereDome_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003C94 RID: 15508
		// (get) Token: 0x06021B2A RID: 138026 RVA: 0x0095053F File Offset: 0x0094E73F
		// (set) Token: 0x06021B2B RID: 138027 RVA: 0x00950553 File Offset: 0x0094E753
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SpereDome_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SpereDome_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17003C95 RID: 15509
		// (get) Token: 0x06021B2C RID: 138028 RVA: 0x00950568 File Offset: 0x0094E768
		// (set) Token: 0x06021B2D RID: 138029 RVA: 0x0095057C File Offset: 0x0094E77C
		public unsafe UMaterialInstanceDynamic DMI
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SpereDome_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SpereDome_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17003C96 RID: 15510
		// (get) Token: 0x06021B2E RID: 138030 RVA: 0x00950591 File Offset: 0x0094E791
		// (set) Token: 0x06021B2F RID: 138031 RVA: 0x009505A5 File Offset: 0x0094E7A5
		public unsafe UMaterialInstanceDynamic DMI_1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SpereDome_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SpereDome_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17003C97 RID: 15511
		// (get) Token: 0x06021B30 RID: 138032 RVA: 0x009505BA File Offset: 0x0094E7BA
		// (set) Token: 0x06021B31 RID: 138033 RVA: 0x009505CA File Offset: 0x0094E7CA
		public unsafe float DissolveProgress
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SpereDome_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SpereDome_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x06021B32 RID: 138034 RVA: 0x009505DB File Offset: 0x0094E7DB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SpereDome_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06021B33 RID: 138035 RVA: 0x009505EF File Offset: 0x0094E7EF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SpereDome_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06021B34 RID: 138036 RVA: 0x00950604 File Offset: 0x0094E804
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SpereDome_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06021B35 RID: 138037 RVA: 0x00950618 File Offset: 0x0094E818
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SpereDome_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06021B36 RID: 138038 RVA: 0x00950630 File Offset: 0x0094E830
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_SpereDome_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_SpereDome_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SpereDome_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SpereDome_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SpereDome_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021B37 RID: 138039 RVA: 0x00950678 File Offset: 0x0094E878
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_SpereDome_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_SpereDome_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SpereDome_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SpereDome_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SpereDome_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021B38 RID: 138040 RVA: 0x009506C0 File Offset: 0x0094E8C0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_SpereDome_C.__EditorTick_FunctionParams* ptr = stackalloc BP_SpereDome_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SpereDome_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SpereDome_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SpereDome_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021B39 RID: 138041 RVA: 0x00950708 File Offset: 0x0094E908
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_SpereDome_C.__EditorTick_FunctionParams* ptr = stackalloc BP_SpereDome_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SpereDome_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SpereDome_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SpereDome_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021B3A RID: 138042 RVA: 0x00950750 File Offset: 0x0094E950
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_SpereDome(int EntryPoint)
		{
			BP_SpereDome_C.__ExecuteUbergraph_BP_SpereDome_FunctionParams* ptr = stackalloc BP_SpereDome_C.__ExecuteUbergraph_BP_SpereDome_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(BP_SpereDome_C.__ExecuteUbergraph_BP_SpereDome_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SpereDome_C.__ExecuteUbergraph_BP_SpereDome_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SpereDome_C.__ExecuteUbergraph_BP_SpereDome_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021B3B RID: 138043 RVA: 0x00950797 File Offset: 0x0094E997
		protected BP_SpereDome_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04010FD0 RID: 69584
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/SceneShader/3_4_SphereScreen/Mat/BP_SpereDome.BP_SpereDome_C";

		// Token: 0x04010FD1 RID: 69585
		private static IntPtr _ClassPtr;

		// Token: 0x04010FD2 RID: 69586
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04010FD3 RID: 69587
		internal static int __PropertyOffset_0;

		// Token: 0x04010FD4 RID: 69588
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04010FD5 RID: 69589
		internal static int __PropertyOffset_1;

		// Token: 0x04010FD6 RID: 69590
		internal static int __PropertyOffset_2;

		// Token: 0x04010FD7 RID: 69591
		internal static int __PropertyOffset_3;

		// Token: 0x04010FD8 RID: 69592
		internal static int __PropertyOffset_4;

		// Token: 0x04010FD9 RID: 69593
		internal static int __PropertyOffset_5;

		// Token: 0x04010FDA RID: 69594
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04010FDB RID: 69595
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04010FDC RID: 69596
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04010FDD RID: 69597
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x04010FDE RID: 69598
		private static IntPtr __ExecuteUbergraph_BP_SpereDome_NativeFunctionPtr;

		// Token: 0x02009B1A RID: 39706
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x040322D2 RID: 205522
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009B1B RID: 39707
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x040322D3 RID: 205523
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009B1C RID: 39708
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __ExecuteUbergraph_BP_SpereDome_FunctionParams
		{
			// Token: 0x040322D4 RID: 205524
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
