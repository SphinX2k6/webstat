using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.YangYangBirds
{
	// Token: 0x020039F4 RID: 14836
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/YangYangBirds/ANS_YangyangBirds_Skill.ANS_YangyangBirds_Skill_C")]
	[UnrealStructLayout(80, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 80)]
	public class ANS_YangyangBirds_Skill_C : UKuroAnimNotifyState, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601E265 RID: 123493 RVA: 0x008ED98C File Offset: 0x008EBB8C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ANS_YangyangBirds_Skill_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/YangYangBirds/ANS_YangyangBirds_Skill.ANS_YangyangBirds_Skill_C");
			}
			return ANS_YangyangBirds_Skill_C._ClassPtr;
		}

		// Token: 0x0601E266 RID: 123494 RVA: 0x008ED9B0 File Offset: 0x008EBBB0
		public ANS_YangyangBirds_Skill_C() : this(BuiltinUtils.AllocNativeUObject(ANS_YangyangBirds_Skill_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601E267 RID: 123495 RVA: 0x008ED9D8 File Offset: 0x008EBBD8
		[NullableContext(1)]
		public ANS_YangyangBirds_Skill_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ANS_YangyangBirds_Skill_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0601E268 RID: 123496 RVA: 0x008EDA0C File Offset: 0x008EBC0C
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override bool K2_NotifyEnd(USkeletalMeshComponent MeshComp, UAnimSequenceBase Animation)
		{
			ANS_YangyangBirds_Skill_C.__K2_NotifyEnd_FunctionParams* ptr = stackalloc ANS_YangyangBirds_Skill_C.__K2_NotifyEnd_FunctionParams[(UIntPtr)63] + 15L / (long)sizeof(ANS_YangyangBirds_Skill_C.__K2_NotifyEnd_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ANS_YangyangBirds_Skill_C.__K2_NotifyEnd_NativeFunctionPtr, (void*)ptr, 1);
			ptr->MeshComp = ((MeshComp != null) ? MeshComp.NativePtr : IntPtr.Zero);
			ptr->Animation = ((Animation != null) ? Animation.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ANS_YangyangBirds_Skill_C.__K2_NotifyEnd_NativeFunctionPtr, (void*)ptr);
			return ptr->__Result;
		}

		// Token: 0x0601E269 RID: 123497 RVA: 0x008EDA80 File Offset: 0x008EBC80
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual bool K2_NotifyEnd_Implementation(USkeletalMeshComponent MeshComp, UAnimSequenceBase Animation)
		{
			ANS_YangyangBirds_Skill_C.__K2_NotifyEnd_FunctionParams* ptr = stackalloc ANS_YangyangBirds_Skill_C.__K2_NotifyEnd_FunctionParams[(UIntPtr)63] + 15L / (long)sizeof(ANS_YangyangBirds_Skill_C.__K2_NotifyEnd_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ANS_YangyangBirds_Skill_C.__K2_NotifyEnd_NativeFunctionPtr, (void*)ptr, 1);
			ptr->MeshComp = ((MeshComp != null) ? MeshComp.NativePtr : IntPtr.Zero);
			ptr->Animation = ((Animation != null) ? Animation.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ANS_YangyangBirds_Skill_C.__K2_NotifyEnd_NativeFunctionPtr, (void*)ptr, 0);
			return ptr->__Result;
		}

		// Token: 0x0601E26A RID: 123498 RVA: 0x008EDAF4 File Offset: 0x008EBCF4
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override bool K2_NotifyBegin(USkeletalMeshComponent MeshComp, UAnimSequenceBase Animation, float TotalDuration)
		{
			ANS_YangyangBirds_Skill_C.__K2_NotifyBegin_FunctionParams* ptr = stackalloc ANS_YangyangBirds_Skill_C.__K2_NotifyBegin_FunctionParams[(UIntPtr)63] + 15L / (long)sizeof(ANS_YangyangBirds_Skill_C.__K2_NotifyBegin_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ANS_YangyangBirds_Skill_C.__K2_NotifyBegin_NativeFunctionPtr, (void*)ptr, 1);
			ptr->MeshComp = ((MeshComp != null) ? MeshComp.NativePtr : IntPtr.Zero);
			ptr->Animation = ((Animation != null) ? Animation.NativePtr : IntPtr.Zero);
			ptr->TotalDuration = TotalDuration;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ANS_YangyangBirds_Skill_C.__K2_NotifyBegin_NativeFunctionPtr, (void*)ptr);
			return ptr->__Result;
		}

		// Token: 0x0601E26B RID: 123499 RVA: 0x008EDB6C File Offset: 0x008EBD6C
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent MeshComp, UAnimSequenceBase Animation, float TotalDuration)
		{
			ANS_YangyangBirds_Skill_C.__K2_NotifyBegin_FunctionParams* ptr = stackalloc ANS_YangyangBirds_Skill_C.__K2_NotifyBegin_FunctionParams[(UIntPtr)63] + 15L / (long)sizeof(ANS_YangyangBirds_Skill_C.__K2_NotifyBegin_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ANS_YangyangBirds_Skill_C.__K2_NotifyBegin_NativeFunctionPtr, (void*)ptr, 1);
			ptr->MeshComp = ((MeshComp != null) ? MeshComp.NativePtr : IntPtr.Zero);
			ptr->Animation = ((Animation != null) ? Animation.NativePtr : IntPtr.Zero);
			ptr->TotalDuration = TotalDuration;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ANS_YangyangBirds_Skill_C.__K2_NotifyBegin_NativeFunctionPtr, (void*)ptr, 0);
			return ptr->__Result;
		}

		// Token: 0x0601E26C RID: 123500 RVA: 0x008EDBE8 File Offset: 0x008EBDE8
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override bool Received_NotifyTick(USkeletalMeshComponent MeshComp, UAnimSequenceBase Animation, float FrameDeltaTime)
		{
			ANS_YangyangBirds_Skill_C.__Received_NotifyTick_FunctionParams* ptr = stackalloc ANS_YangyangBirds_Skill_C.__Received_NotifyTick_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(ANS_YangyangBirds_Skill_C.__Received_NotifyTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ANS_YangyangBirds_Skill_C.__Received_NotifyTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->MeshComp = ((MeshComp != null) ? MeshComp.NativePtr : IntPtr.Zero);
			ptr->Animation = ((Animation != null) ? Animation.NativePtr : IntPtr.Zero);
			ptr->FrameDeltaTime = FrameDeltaTime;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ANS_YangyangBirds_Skill_C.__Received_NotifyTick_NativeFunctionPtr, (void*)ptr);
			return ptr->__Result;
		}

		// Token: 0x0601E26D RID: 123501 RVA: 0x008EDC60 File Offset: 0x008EBE60
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual bool Received_NotifyTick_Implementation(USkeletalMeshComponent MeshComp, UAnimSequenceBase Animation, float FrameDeltaTime)
		{
			ANS_YangyangBirds_Skill_C.__Received_NotifyTick_FunctionParams* ptr = stackalloc ANS_YangyangBirds_Skill_C.__Received_NotifyTick_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(ANS_YangyangBirds_Skill_C.__Received_NotifyTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ANS_YangyangBirds_Skill_C.__Received_NotifyTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->MeshComp = ((MeshComp != null) ? MeshComp.NativePtr : IntPtr.Zero);
			ptr->Animation = ((Animation != null) ? Animation.NativePtr : IntPtr.Zero);
			ptr->FrameDeltaTime = FrameDeltaTime;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ANS_YangyangBirds_Skill_C.__Received_NotifyTick_NativeFunctionPtr, (void*)ptr, 0);
			return ptr->__Result;
		}

		// Token: 0x0601E26E RID: 123502 RVA: 0x008EDCD9 File Offset: 0x008EBED9
		protected ANS_YangyangBirds_Skill_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400ECF6 RID: 60662
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/YangYangBirds/ANS_YangyangBirds_Skill.ANS_YangyangBirds_Skill_C";

		// Token: 0x0400ECF7 RID: 60663
		private static IntPtr _ClassPtr;

		// Token: 0x0400ECF8 RID: 60664
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400ECF9 RID: 60665
		private static IntPtr __K2_NotifyEnd_NativeFunctionPtr;

		// Token: 0x0400ECFA RID: 60666
		private static IntPtr __K2_NotifyBegin_NativeFunctionPtr;

		// Token: 0x0400ECFB RID: 60667
		private static IntPtr __Received_NotifyTick_NativeFunctionPtr;

		// Token: 0x02009772 RID: 38770
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 48)]
		protected new ref struct __K2_NotifyEnd_FunctionParams
		{
			// Token: 0x04031D1D RID: 204061
			[FieldOffset(0)]
			public IntPtr MeshComp;

			// Token: 0x04031D1E RID: 204062
			[FieldOffset(8)]
			public IntPtr Animation;

			// Token: 0x04031D1F RID: 204063
			[FieldOffset(16)]
			public bool __Result;
		}

		// Token: 0x02009773 RID: 38771
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 48)]
		protected new ref struct __K2_NotifyBegin_FunctionParams
		{
			// Token: 0x04031D20 RID: 204064
			[FieldOffset(0)]
			public IntPtr MeshComp;

			// Token: 0x04031D21 RID: 204065
			[FieldOffset(8)]
			public IntPtr Animation;

			// Token: 0x04031D22 RID: 204066
			[FieldOffset(16)]
			public float TotalDuration;

			// Token: 0x04031D23 RID: 204067
			[FieldOffset(20)]
			public bool __Result;
		}

		// Token: 0x02009774 RID: 38772
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected new ref struct __Received_NotifyTick_FunctionParams
		{
			// Token: 0x04031D24 RID: 204068
			[FieldOffset(0)]
			public IntPtr MeshComp;

			// Token: 0x04031D25 RID: 204069
			[FieldOffset(8)]
			public IntPtr Animation;

			// Token: 0x04031D26 RID: 204070
			[FieldOffset(16)]
			public float FrameDeltaTime;

			// Token: 0x04031D27 RID: 204071
			[FieldOffset(20)]
			public bool __Result;
		}
	}
}
