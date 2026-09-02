using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Character.NPC.Animal.CommonSmallAnimal;
using AkiClient.Game.Aki.Render.RuntimeBP.SnowCoverInteraction.BluePrints;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA069
{
	// Token: 0x02004102 RID: 16642
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA069/BP_NA069.BP_NA069_C")]
	[UnrealStructLayout(2272, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2264)]
	public class BP_NA069_C : BP_CommonSmallAnimal_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C48B RID: 181387 RVA: 0x00A9C38C File Offset: 0x00A9A58C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_NA069_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA069/BP_NA069.BP_NA069_C");
			}
			return BP_NA069_C._ClassPtr;
		}

		// Token: 0x0602C48C RID: 181388 RVA: 0x00A9C3B0 File Offset: 0x00A9A5B0
		public BP_NA069_C() : this(BuiltinUtils.AllocNativeUObject(BP_NA069_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C48D RID: 181389 RVA: 0x00A9C3D8 File Offset: 0x00A9A5D8
		[NullableContext(1)]
		public BP_NA069_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_NA069_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007739 RID: 30521
		// (get) Token: 0x0602C48E RID: 181390 RVA: 0x00A9C40C File Offset: 0x00A9A60C
		// (set) Token: 0x0602C48F RID: 181391 RVA: 0x00A9C445 File Offset: 0x00A9A645
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_NA069_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_NA069_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700773A RID: 30522
		// (get) Token: 0x0602C490 RID: 181392 RVA: 0x00A9C466 File Offset: 0x00A9A666
		// (set) Token: 0x0602C491 RID: 181393 RVA: 0x00A9C47A File Offset: 0x00A9A67A
		public unsafe BP_SnowTrailComponent_NPC_C BP_SnowTrailComponent_NPC
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_SnowTrailComponent_NPC_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_NA069_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_NA069_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x1700773B RID: 30523
		// (get) Token: 0x0602C492 RID: 181394 RVA: 0x00A9C48F File Offset: 0x00A9A68F
		// (set) Token: 0x0602C493 RID: 181395 RVA: 0x00A9C4A3 File Offset: 0x00A9A6A3
		public unsafe UKuroAdjustableCapsuleComponent ROOT
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroAdjustableCapsuleComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_NA069_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_NA069_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x0602C494 RID: 181396 RVA: 0x00A9C4B8 File Offset: 0x00A9A6B8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_NA069_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0602C495 RID: 181397 RVA: 0x00A9C4CC File Offset: 0x00A9A6CC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_NA069_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602C496 RID: 181398 RVA: 0x00A9C4E4 File Offset: 0x00A9A6E4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_NA069(int EntryPoint)
		{
			BP_NA069_C.__ExecuteUbergraph_BP_NA069_FunctionParams* ptr = stackalloc BP_NA069_C.__ExecuteUbergraph_BP_NA069_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_NA069_C.__ExecuteUbergraph_BP_NA069_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_NA069_C.__ExecuteUbergraph_BP_NA069_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_NA069_C.__ExecuteUbergraph_BP_NA069_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602C497 RID: 181399 RVA: 0x00A9C52B File Offset: 0x00A9A72B
		protected BP_NA069_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401890E RID: 100622
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA069/BP_NA069.BP_NA069_C";

		// Token: 0x0401890F RID: 100623
		private static IntPtr _ClassPtr;

		// Token: 0x04018910 RID: 100624
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04018911 RID: 100625
		internal new static int __PropertyOffset_0;

		// Token: 0x04018912 RID: 100626
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04018913 RID: 100627
		internal static int __PropertyOffset_1;

		// Token: 0x04018914 RID: 100628
		internal static int __PropertyOffset_2;

		// Token: 0x04018915 RID: 100629
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04018916 RID: 100630
		private static IntPtr __ExecuteUbergraph_BP_NA069_NativeFunctionPtr;

		// Token: 0x0200A436 RID: 42038
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __ExecuteUbergraph_BP_NA069_FunctionParams
		{
			// Token: 0x04033231 RID: 209457
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
