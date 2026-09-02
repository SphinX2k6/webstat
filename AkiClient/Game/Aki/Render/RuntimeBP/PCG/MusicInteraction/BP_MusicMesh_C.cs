using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.MusicInteraction
{
	// Token: 0x02003BBD RID: 15293
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/MusicInteraction/BP_MusicMesh.BP_MusicMesh_C")]
	[UnrealStructLayout(1384, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1384)]
	public class BP_MusicMesh_C : AKuroBPEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602248F RID: 140431 RVA: 0x00960FA7 File Offset: 0x0095F1A7
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_MusicMesh_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/MusicInteraction/BP_MusicMesh.BP_MusicMesh_C");
			}
			return BP_MusicMesh_C._ClassPtr;
		}

		// Token: 0x06022490 RID: 140432 RVA: 0x00960FCC File Offset: 0x0095F1CC
		public BP_MusicMesh_C() : this(BuiltinUtils.AllocNativeUObject(BP_MusicMesh_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06022491 RID: 140433 RVA: 0x00960FF4 File Offset: 0x0095F1F4
		[NullableContext(1)]
		public BP_MusicMesh_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_MusicMesh_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700400F RID: 16399
		// (get) Token: 0x06022492 RID: 140434 RVA: 0x00961028 File Offset: 0x0095F228
		// (set) Token: 0x06022493 RID: 140435 RVA: 0x00961061 File Offset: 0x0095F261
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_MusicMesh_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_MusicMesh_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004010 RID: 16400
		// (get) Token: 0x06022494 RID: 140436 RVA: 0x00961082 File Offset: 0x0095F282
		// (set) Token: 0x06022495 RID: 140437 RVA: 0x00961096 File Offset: 0x0095F296
		public unsafe UStaticMeshComponent StaticMeshComp
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MusicMesh_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MusicMesh_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17004011 RID: 16401
		// (get) Token: 0x06022496 RID: 140438 RVA: 0x009610AB File Offset: 0x0095F2AB
		// (set) Token: 0x06022497 RID: 140439 RVA: 0x009610BF File Offset: 0x0095F2BF
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MusicMesh_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MusicMesh_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17004012 RID: 16402
		// (get) Token: 0x06022498 RID: 140440 RVA: 0x009610D4 File Offset: 0x0095F2D4
		// (set) Token: 0x06022499 RID: 140441 RVA: 0x009610E4 File Offset: 0x0095F2E4
		public unsafe bool 双拍触发
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MusicMesh_C.__PropertyOffset_3) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MusicMesh_C.__PropertyOffset_3) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004013 RID: 16403
		// (get) Token: 0x0602249A RID: 140442 RVA: 0x009610F5 File Offset: 0x0095F2F5
		// (set) Token: 0x0602249B RID: 140443 RVA: 0x00961105 File Offset: 0x0095F305
		public unsafe float DelayTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MusicMesh_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MusicMesh_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17004014 RID: 16404
		// (get) Token: 0x0602249C RID: 140444 RVA: 0x00961116 File Offset: 0x0095F316
		// (set) Token: 0x0602249D RID: 140445 RVA: 0x00961126 File Offset: 0x0095F326
		public unsafe bool Activate
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MusicMesh_C.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MusicMesh_C.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004015 RID: 16405
		// (get) Token: 0x0602249E RID: 140446 RVA: 0x00961137 File Offset: 0x0095F337
		// (set) Token: 0x0602249F RID: 140447 RVA: 0x0096114B File Offset: 0x0095F34B
		public unsafe UStaticMesh 模型资产
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MusicMesh_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MusicMesh_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x17004016 RID: 16406
		// (get) Token: 0x060224A0 RID: 140448 RVA: 0x00961160 File Offset: 0x0095F360
		// (set) Token: 0x060224A1 RID: 140449 RVA: 0x00961170 File Offset: 0x0095F370
		public unsafe float 特效延迟
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MusicMesh_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MusicMesh_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17004017 RID: 16407
		// (get) Token: 0x060224A2 RID: 140450 RVA: 0x00961181 File Offset: 0x0095F381
		// (set) Token: 0x060224A3 RID: 140451 RVA: 0x00961191 File Offset: 0x0095F391
		public unsafe float LoopTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MusicMesh_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MusicMesh_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17004018 RID: 16408
		// (get) Token: 0x060224A4 RID: 140452 RVA: 0x009611A2 File Offset: 0x0095F3A2
		// (set) Token: 0x060224A5 RID: 140453 RVA: 0x009611B2 File Offset: 0x0095F3B2
		public unsafe float Delta_Seconds
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MusicMesh_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MusicMesh_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17004019 RID: 16409
		// (get) Token: 0x060224A6 RID: 140454 RVA: 0x009611C3 File Offset: 0x0095F3C3
		// (set) Token: 0x060224A7 RID: 140455 RVA: 0x009611D3 File Offset: 0x0095F3D3
		public unsafe float 单拍时间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MusicMesh_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MusicMesh_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x060224A8 RID: 140456 RVA: 0x009611E4 File Offset: 0x0095F3E4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MusicMesh_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x060224A9 RID: 140457 RVA: 0x009611F8 File Offset: 0x0095F3F8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MusicMesh_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060224AA RID: 140458 RVA: 0x00961210 File Offset: 0x0095F410
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_MusicMesh_C.__EditorTick_FunctionParams* ptr = stackalloc BP_MusicMesh_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_MusicMesh_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MusicMesh_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MusicMesh_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060224AB RID: 140459 RVA: 0x00961258 File Offset: 0x0095F458
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_MusicMesh_C.__EditorTick_FunctionParams* ptr = stackalloc BP_MusicMesh_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_MusicMesh_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MusicMesh_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MusicMesh_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060224AC RID: 140460 RVA: 0x009612A0 File Offset: 0x0095F4A0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_MusicMesh_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_MusicMesh_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_MusicMesh_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MusicMesh_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MusicMesh_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060224AD RID: 140461 RVA: 0x009612E8 File Offset: 0x0095F4E8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_MusicMesh_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_MusicMesh_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_MusicMesh_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MusicMesh_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MusicMesh_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060224AE RID: 140462 RVA: 0x00961330 File Offset: 0x0095F530
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_MusicMesh(int EntryPoint)
		{
			BP_MusicMesh_C.__ExecuteUbergraph_BP_MusicMesh_FunctionParams* ptr = stackalloc BP_MusicMesh_C.__ExecuteUbergraph_BP_MusicMesh_FunctionParams[(UIntPtr)335] + 15L / (long)sizeof(BP_MusicMesh_C.__ExecuteUbergraph_BP_MusicMesh_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MusicMesh_C.__ExecuteUbergraph_BP_MusicMesh_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MusicMesh_C.__ExecuteUbergraph_BP_MusicMesh_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060224AF RID: 140463 RVA: 0x0096137A File Offset: 0x0095F57A
		protected BP_MusicMesh_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04011569 RID: 71017
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/MusicInteraction/BP_MusicMesh.BP_MusicMesh_C";

		// Token: 0x0401156A RID: 71018
		private static IntPtr _ClassPtr;

		// Token: 0x0401156B RID: 71019
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401156C RID: 71020
		internal static int __PropertyOffset_0;

		// Token: 0x0401156D RID: 71021
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0401156E RID: 71022
		internal static int __PropertyOffset_1;

		// Token: 0x0401156F RID: 71023
		internal static int __PropertyOffset_2;

		// Token: 0x04011570 RID: 71024
		internal static int __PropertyOffset_3;

		// Token: 0x04011571 RID: 71025
		internal static int __PropertyOffset_4;

		// Token: 0x04011572 RID: 71026
		internal static int __PropertyOffset_5;

		// Token: 0x04011573 RID: 71027
		internal static int __PropertyOffset_6;

		// Token: 0x04011574 RID: 71028
		internal static int __PropertyOffset_7;

		// Token: 0x04011575 RID: 71029
		internal static int __PropertyOffset_8;

		// Token: 0x04011576 RID: 71030
		internal static int __PropertyOffset_9;

		// Token: 0x04011577 RID: 71031
		internal static int __PropertyOffset_10;

		// Token: 0x04011578 RID: 71032
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04011579 RID: 71033
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x0401157A RID: 71034
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0401157B RID: 71035
		private static IntPtr __ExecuteUbergraph_BP_MusicMesh_NativeFunctionPtr;

		// Token: 0x02009BB8 RID: 39864
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x040323EB RID: 205803
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009BB9 RID: 39865
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x040323EC RID: 205804
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009BBA RID: 39866
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 320)]
		protected ref struct __ExecuteUbergraph_BP_MusicMesh_FunctionParams
		{
			// Token: 0x040323ED RID: 205805
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
