using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.YangYangBirds
{
	// Token: 0x020039F5 RID: 14837
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/YangYangBirds/AN_Yangyang_SpawnBirds.AN_Yangyang_SpawnBirds_C")]
	[UnrealStructLayout(80, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 80)]
	public class AN_Yangyang_SpawnBirds_C : UKuroAnimNotify, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601E26F RID: 123503 RVA: 0x008EDCE2 File Offset: 0x008EBEE2
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (AN_Yangyang_SpawnBirds_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/YangYangBirds/AN_Yangyang_SpawnBirds.AN_Yangyang_SpawnBirds_C");
			}
			return AN_Yangyang_SpawnBirds_C._ClassPtr;
		}

		// Token: 0x0601E270 RID: 123504 RVA: 0x008EDD08 File Offset: 0x008EBF08
		public AN_Yangyang_SpawnBirds_C() : this(BuiltinUtils.AllocNativeUObject(AN_Yangyang_SpawnBirds_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601E271 RID: 123505 RVA: 0x008EDD30 File Offset: 0x008EBF30
		[NullableContext(1)]
		public AN_Yangyang_SpawnBirds_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(AN_Yangyang_SpawnBirds_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0601E272 RID: 123506 RVA: 0x008EDD64 File Offset: 0x008EBF64
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override bool Received_Notify(USkeletalMeshComponent MeshComp, UAnimSequenceBase Animation)
		{
			AN_Yangyang_SpawnBirds_C.__Received_Notify_FunctionParams* ptr = stackalloc AN_Yangyang_SpawnBirds_C.__Received_Notify_FunctionParams[(UIntPtr)63] + 15L / (long)sizeof(AN_Yangyang_SpawnBirds_C.__Received_Notify_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(AN_Yangyang_SpawnBirds_C.__Received_Notify_NativeFunctionPtr, (void*)ptr, 1);
			ptr->MeshComp = ((MeshComp != null) ? MeshComp.NativePtr : IntPtr.Zero);
			ptr->Animation = ((Animation != null) ? Animation.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, AN_Yangyang_SpawnBirds_C.__Received_Notify_NativeFunctionPtr, (void*)ptr);
			return ptr->__Result;
		}

		// Token: 0x0601E273 RID: 123507 RVA: 0x008EDDD8 File Offset: 0x008EBFD8
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual bool Received_Notify_Implementation(USkeletalMeshComponent MeshComp, UAnimSequenceBase Animation)
		{
			AN_Yangyang_SpawnBirds_C.__Received_Notify_FunctionParams* ptr = stackalloc AN_Yangyang_SpawnBirds_C.__Received_Notify_FunctionParams[(UIntPtr)63] + 15L / (long)sizeof(AN_Yangyang_SpawnBirds_C.__Received_Notify_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(AN_Yangyang_SpawnBirds_C.__Received_Notify_NativeFunctionPtr, (void*)ptr, 1);
			ptr->MeshComp = ((MeshComp != null) ? MeshComp.NativePtr : IntPtr.Zero);
			ptr->Animation = ((Animation != null) ? Animation.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, AN_Yangyang_SpawnBirds_C.__Received_Notify_NativeFunctionPtr, (void*)ptr, 0);
			return ptr->__Result;
		}

		// Token: 0x0601E274 RID: 123508 RVA: 0x008EDE4A File Offset: 0x008EC04A
		protected AN_Yangyang_SpawnBirds_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400ECFC RID: 60668
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/YangYangBirds/AN_Yangyang_SpawnBirds.AN_Yangyang_SpawnBirds_C";

		// Token: 0x0400ECFD RID: 60669
		private static IntPtr _ClassPtr;

		// Token: 0x0400ECFE RID: 60670
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400ECFF RID: 60671
		private static IntPtr __Received_Notify_NativeFunctionPtr;

		// Token: 0x02009775 RID: 38773
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 48)]
		protected new ref struct __Received_Notify_FunctionParams
		{
			// Token: 0x04031D28 RID: 204072
			[FieldOffset(0)]
			public IntPtr MeshComp;

			// Token: 0x04031D29 RID: 204073
			[FieldOffset(8)]
			public IntPtr Animation;

			// Token: 0x04031D2A RID: 204074
			[FieldOffset(16)]
			public bool __Result;
		}
	}
}
