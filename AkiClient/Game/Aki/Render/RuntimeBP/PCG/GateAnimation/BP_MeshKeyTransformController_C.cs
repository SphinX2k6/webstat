using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.GateAnimation
{
	// Token: 0x02003C30 RID: 15408
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/GateAnimation/BP_MeshKeyTransformController.BP_MeshKeyTransformController_C")]
	[UnrealStructLayout(1368, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1368)]
	public class BP_MeshKeyTransformController_C : AKuroBPEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060234CD RID: 144589 RVA: 0x0097E1EC File Offset: 0x0097C3EC
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_MeshKeyTransformController_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/GateAnimation/BP_MeshKeyTransformController.BP_MeshKeyTransformController_C");
			}
			return BP_MeshKeyTransformController_C._ClassPtr;
		}

		// Token: 0x060234CE RID: 144590 RVA: 0x0097E210 File Offset: 0x0097C410
		public BP_MeshKeyTransformController_C() : this(BuiltinUtils.AllocNativeUObject(BP_MeshKeyTransformController_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060234CF RID: 144591 RVA: 0x0097E238 File Offset: 0x0097C438
		public BP_MeshKeyTransformController_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_MeshKeyTransformController_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170045A5 RID: 17829
		// (get) Token: 0x060234D0 RID: 144592 RVA: 0x0097E26C File Offset: 0x0097C46C
		// (set) Token: 0x060234D1 RID: 144593 RVA: 0x0097E2A5 File Offset: 0x0097C4A5
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_MeshKeyTransformController_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_MeshKeyTransformController_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170045A6 RID: 17830
		// (get) Token: 0x060234D2 RID: 144594 RVA: 0x0097E2C6 File Offset: 0x0097C4C6
		// (set) Token: 0x060234D3 RID: 144595 RVA: 0x0097E2DA File Offset: 0x0097C4DA
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MeshKeyTransformController_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MeshKeyTransformController_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170045A7 RID: 17831
		// (get) Token: 0x060234D4 RID: 144596 RVA: 0x0097E2EF File Offset: 0x0097C4EF
		// (set) Token: 0x060234D5 RID: 144597 RVA: 0x0097E2FF File Offset: 0x0097C4FF
		public unsafe float CustomTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MeshKeyTransformController_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MeshKeyTransformController_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x170045A8 RID: 17832
		// (get) Token: 0x060234D6 RID: 144598 RVA: 0x0097E310 File Offset: 0x0097C510
		// (set) Token: 0x060234D7 RID: 144599 RVA: 0x0097E320 File Offset: 0x0097C520
		public unsafe int Random
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MeshKeyTransformController_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MeshKeyTransformController_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x170045A9 RID: 17833
		// (get) Token: 0x060234D8 RID: 144600 RVA: 0x0097E334 File Offset: 0x0097C534
		// (set) Token: 0x060234D9 RID: 144601 RVA: 0x0097E36D File Offset: 0x0097C56D
		public TArray<BP_MeshKeyTransform_C> MeshActors
		{
			get
			{
				base.FastCheckIsValid();
				TArray<BP_MeshKeyTransform_C> result;
				if ((result = this._MeshActors) == null)
				{
					result = (this._MeshActors = new TArray<BP_MeshKeyTransform_C>(base.NativePtr + (IntPtr)BP_MeshKeyTransformController_C.__PropertyOffset_4, this));
				}
				return result;
			}
			set
			{
				this.MeshActors.CopyAssign(value);
			}
		}

		// Token: 0x170045AA RID: 17834
		// (get) Token: 0x060234DA RID: 144602 RVA: 0x0097E37B File Offset: 0x0097C57B
		// (set) Token: 0x060234DB RID: 144603 RVA: 0x0097E38B File Offset: 0x0097C58B
		public unsafe float LastTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MeshKeyTransformController_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MeshKeyTransformController_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x170045AB RID: 17835
		// (get) Token: 0x060234DC RID: 144604 RVA: 0x0097E39C File Offset: 0x0097C59C
		// (set) Token: 0x060234DD RID: 144605 RVA: 0x0097E3AC File Offset: 0x0097C5AC
		public unsafe int LastRandom
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MeshKeyTransformController_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MeshKeyTransformController_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x060234DE RID: 144606 RVA: 0x0097E3BD File Offset: 0x0097C5BD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateTransform()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MeshKeyTransformController_C.__UpdateTransform_NativeFunctionPtr, null);
		}

		// Token: 0x060234DF RID: 144607 RVA: 0x0097E3D1 File Offset: 0x0097C5D1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SyncMeshActors()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MeshKeyTransformController_C.__SyncMeshActors_NativeFunctionPtr, null);
		}

		// Token: 0x060234E0 RID: 144608 RVA: 0x0097E3E5 File Offset: 0x0097C5E5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MeshKeyTransformController_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x060234E1 RID: 144609 RVA: 0x0097E3F9 File Offset: 0x0097C5F9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MeshKeyTransformController_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060234E2 RID: 144610 RVA: 0x0097E410 File Offset: 0x0097C610
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_MeshKeyTransformController_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_MeshKeyTransformController_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_MeshKeyTransformController_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MeshKeyTransformController_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MeshKeyTransformController_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060234E3 RID: 144611 RVA: 0x0097E458 File Offset: 0x0097C658
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_MeshKeyTransformController_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_MeshKeyTransformController_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_MeshKeyTransformController_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MeshKeyTransformController_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MeshKeyTransformController_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060234E4 RID: 144612 RVA: 0x0097E4A0 File Offset: 0x0097C6A0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_MeshKeyTransformController_C.__EditorTick_FunctionParams* ptr = stackalloc BP_MeshKeyTransformController_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_MeshKeyTransformController_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MeshKeyTransformController_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MeshKeyTransformController_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060234E5 RID: 144613 RVA: 0x0097E4E8 File Offset: 0x0097C6E8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_MeshKeyTransformController_C.__EditorTick_FunctionParams* ptr = stackalloc BP_MeshKeyTransformController_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_MeshKeyTransformController_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MeshKeyTransformController_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MeshKeyTransformController_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060234E6 RID: 144614 RVA: 0x0097E530 File Offset: 0x0097C730
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_MeshKeyTransformController(int EntryPoint)
		{
			BP_MeshKeyTransformController_C.__ExecuteUbergraph_BP_MeshKeyTransformController_FunctionParams* ptr = stackalloc BP_MeshKeyTransformController_C.__ExecuteUbergraph_BP_MeshKeyTransformController_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(BP_MeshKeyTransformController_C.__ExecuteUbergraph_BP_MeshKeyTransformController_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MeshKeyTransformController_C.__ExecuteUbergraph_BP_MeshKeyTransformController_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MeshKeyTransformController_C.__ExecuteUbergraph_BP_MeshKeyTransformController_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060234E7 RID: 144615 RVA: 0x0097E577 File Offset: 0x0097C777
		protected BP_MeshKeyTransformController_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04011F4C RID: 73548
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/GateAnimation/BP_MeshKeyTransformController.BP_MeshKeyTransformController_C";

		// Token: 0x04011F4D RID: 73549
		private static IntPtr _ClassPtr;

		// Token: 0x04011F4E RID: 73550
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04011F4F RID: 73551
		internal static int __PropertyOffset_0;

		// Token: 0x04011F50 RID: 73552
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04011F51 RID: 73553
		internal static int __PropertyOffset_1;

		// Token: 0x04011F52 RID: 73554
		internal static int __PropertyOffset_2;

		// Token: 0x04011F53 RID: 73555
		internal static int __PropertyOffset_3;

		// Token: 0x04011F54 RID: 73556
		internal static int __PropertyOffset_4;

		// Token: 0x04011F55 RID: 73557
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<BP_MeshKeyTransform_C> _MeshActors;

		// Token: 0x04011F56 RID: 73558
		internal static int __PropertyOffset_5;

		// Token: 0x04011F57 RID: 73559
		internal static int __PropertyOffset_6;

		// Token: 0x04011F58 RID: 73560
		private static IntPtr __UpdateTransform_NativeFunctionPtr;

		// Token: 0x04011F59 RID: 73561
		private static IntPtr __SyncMeshActors_NativeFunctionPtr;

		// Token: 0x04011F5A RID: 73562
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04011F5B RID: 73563
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04011F5C RID: 73564
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x04011F5D RID: 73565
		private static IntPtr __ExecuteUbergraph_BP_MeshKeyTransformController_NativeFunctionPtr;

		// Token: 0x02009CBA RID: 40122
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x0403261C RID: 206364
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009CBB RID: 40123
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x0403261D RID: 206365
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009CBC RID: 40124
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __ExecuteUbergraph_BP_MeshKeyTransformController_FunctionParams
		{
			// Token: 0x0403261E RID: 206366
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
