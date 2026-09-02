using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.SwingInteraction
{
	// Token: 0x02003A45 RID: 14917
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/SwingInteraction/BP_SwingNPC.BP_SwingNPC_C")]
	[UnrealStructLayout(1344, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1344)]
	public class BP_SwingNPC_C : AKuroBPActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601EE1E RID: 126494 RVA: 0x00900FBF File Offset: 0x008FF1BF
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SwingNPC_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/SwingInteraction/BP_SwingNPC.BP_SwingNPC_C");
			}
			return BP_SwingNPC_C._ClassPtr;
		}

		// Token: 0x0601EE1F RID: 126495 RVA: 0x00900FE4 File Offset: 0x008FF1E4
		public BP_SwingNPC_C() : this(BuiltinUtils.AllocNativeUObject(BP_SwingNPC_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601EE20 RID: 126496 RVA: 0x0090100C File Offset: 0x008FF20C
		[NullableContext(1)]
		public BP_SwingNPC_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SwingNPC_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002CFC RID: 11516
		// (get) Token: 0x0601EE21 RID: 126497 RVA: 0x00901040 File Offset: 0x008FF240
		// (set) Token: 0x0601EE22 RID: 126498 RVA: 0x00901079 File Offset: 0x008FF279
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_SwingNPC_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_SwingNPC_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17002CFD RID: 11517
		// (get) Token: 0x0601EE23 RID: 126499 RVA: 0x0090109A File Offset: 0x008FF29A
		// (set) Token: 0x0601EE24 RID: 126500 RVA: 0x009010AE File Offset: 0x008FF2AE
		public unsafe USphereComponent Sphere
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USphereComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SwingNPC_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SwingNPC_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17002CFE RID: 11518
		// (get) Token: 0x0601EE25 RID: 126501 RVA: 0x009010C3 File Offset: 0x008FF2C3
		// (set) Token: 0x0601EE26 RID: 126502 RVA: 0x009010D7 File Offset: 0x008FF2D7
		public unsafe UPhysicsConstraintComponent PhysicsConstraint
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPhysicsConstraintComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SwingNPC_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SwingNPC_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17002CFF RID: 11519
		// (get) Token: 0x0601EE27 RID: 126503 RVA: 0x009010EC File Offset: 0x008FF2EC
		// (set) Token: 0x0601EE28 RID: 126504 RVA: 0x00901100 File Offset: 0x008FF300
		public unsafe UStaticMeshComponent SwingNPC
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SwingNPC_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SwingNPC_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17002D00 RID: 11520
		// (get) Token: 0x0601EE29 RID: 126505 RVA: 0x00901115 File Offset: 0x008FF315
		// (set) Token: 0x0601EE2A RID: 126506 RVA: 0x00901129 File Offset: 0x008FF329
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SwingNPC_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SwingNPC_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x0601EE2B RID: 126507 RVA: 0x0090113E File Offset: 0x008FF33E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SwingNPC_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0601EE2C RID: 126508 RVA: 0x00901152 File Offset: 0x008FF352
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SwingNPC_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601EE2D RID: 126509 RVA: 0x00901167 File Offset: 0x008FF367
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void OnLogicEnable()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SwingNPC_C.__OnLogicEnable_NativeFunctionPtr, null);
		}

		// Token: 0x0601EE2E RID: 126510 RVA: 0x0090117B File Offset: 0x008FF37B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void OnLogicEnable_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SwingNPC_C.__OnLogicEnable_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601EE2F RID: 126511 RVA: 0x00901190 File Offset: 0x008FF390
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void OnLogicDisable()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SwingNPC_C.__OnLogicDisable_NativeFunctionPtr, null);
		}

		// Token: 0x0601EE30 RID: 126512 RVA: 0x009011A4 File Offset: 0x008FF3A4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void OnLogicDisable_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SwingNPC_C.__OnLogicDisable_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601EE31 RID: 126513 RVA: 0x009011BC File Offset: 0x008FF3BC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_SwingNPC(int EntryPoint)
		{
			BP_SwingNPC_C.__ExecuteUbergraph_BP_SwingNPC_FunctionParams* ptr = stackalloc BP_SwingNPC_C.__ExecuteUbergraph_BP_SwingNPC_FunctionParams[(UIntPtr)111] + 15L / (long)sizeof(BP_SwingNPC_C.__ExecuteUbergraph_BP_SwingNPC_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SwingNPC_C.__ExecuteUbergraph_BP_SwingNPC_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SwingNPC_C.__ExecuteUbergraph_BP_SwingNPC_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601EE32 RID: 126514 RVA: 0x00901203 File Offset: 0x008FF403
		protected BP_SwingNPC_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400F41F RID: 62495
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/SwingInteraction/BP_SwingNPC.BP_SwingNPC_C";

		// Token: 0x0400F420 RID: 62496
		private static IntPtr _ClassPtr;

		// Token: 0x0400F421 RID: 62497
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400F422 RID: 62498
		internal static int __PropertyOffset_0;

		// Token: 0x0400F423 RID: 62499
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400F424 RID: 62500
		internal static int __PropertyOffset_1;

		// Token: 0x0400F425 RID: 62501
		internal static int __PropertyOffset_2;

		// Token: 0x0400F426 RID: 62502
		internal static int __PropertyOffset_3;

		// Token: 0x0400F427 RID: 62503
		internal static int __PropertyOffset_4;

		// Token: 0x0400F428 RID: 62504
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400F429 RID: 62505
		private static IntPtr __OnLogicEnable_NativeFunctionPtr;

		// Token: 0x0400F42A RID: 62506
		private static IntPtr __OnLogicDisable_NativeFunctionPtr;

		// Token: 0x0400F42B RID: 62507
		private static IntPtr __ExecuteUbergraph_BP_SwingNPC_NativeFunctionPtr;

		// Token: 0x02009816 RID: 38934
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 96)]
		protected ref struct __ExecuteUbergraph_BP_SwingNPC_FunctionParams
		{
			// Token: 0x04031E2E RID: 204334
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
