using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.AnimNotifyState
{
	// Token: 0x0200432D RID: 17197
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/AnimNotifyState/ANS_PositionBranchTarget2.ANS_PositionBranchTarget2_C")]
	[UnrealStructLayout(192, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 189)]
	public class ANS_PositionBranchTarget2_C : UKuroAnimNotifyState, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602D9ED RID: 186861 RVA: 0x00AC4BF4 File Offset: 0x00AC2DF4
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ANS_PositionBranchTarget2_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/AnimNotifyState/ANS_PositionBranchTarget2.ANS_PositionBranchTarget2_C");
			}
			return ANS_PositionBranchTarget2_C._ClassPtr;
		}

		// Token: 0x0602D9EE RID: 186862 RVA: 0x00AC4C18 File Offset: 0x00AC2E18
		public ANS_PositionBranchTarget2_C() : this(BuiltinUtils.AllocNativeUObject(ANS_PositionBranchTarget2_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602D9EF RID: 186863 RVA: 0x00AC4C40 File Offset: 0x00AC2E40
		[NullableContext(1)]
		public ANS_PositionBranchTarget2_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ANS_PositionBranchTarget2_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007D0F RID: 32015
		// (get) Token: 0x0602D9F0 RID: 186864 RVA: 0x00AC4C73 File Offset: 0x00AC2E73
		// (set) Token: 0x0602D9F1 RID: 186865 RVA: 0x00AC4C87 File Offset: 0x00AC2E87
		public unsafe TsBaseCharacter BaseChar
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<TsBaseCharacter>(base.NativePtr / (IntPtr)sizeof(void*) + ANS_PositionBranchTarget2_C.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + ANS_PositionBranchTarget2_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x17007D10 RID: 32016
		// (get) Token: 0x0602D9F2 RID: 186866 RVA: 0x00AC4C9C File Offset: 0x00AC2E9C
		// (set) Token: 0x0602D9F3 RID: 186867 RVA: 0x00AC4CB0 File Offset: 0x00AC2EB0
		public unsafe AActor Target
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + ANS_PositionBranchTarget2_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + ANS_PositionBranchTarget2_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17007D11 RID: 32017
		// (get) Token: 0x0602D9F4 RID: 186868 RVA: 0x00AC4CC5 File Offset: 0x00AC2EC5
		// (set) Token: 0x0602D9F5 RID: 186869 RVA: 0x00AC4CD9 File Offset: 0x00AC2ED9
		public unsafe UCurveFloat MoveCurve
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveFloat>(base.NativePtr / (IntPtr)sizeof(void*) + ANS_PositionBranchTarget2_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + ANS_PositionBranchTarget2_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17007D12 RID: 32018
		// (get) Token: 0x0602D9F6 RID: 186870 RVA: 0x00AC4CEE File Offset: 0x00AC2EEE
		// (set) Token: 0x0602D9F7 RID: 186871 RVA: 0x00AC4CFE File Offset: 0x00AC2EFE
		public unsafe float Distance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ANS_PositionBranchTarget2_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ANS_PositionBranchTarget2_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17007D13 RID: 32019
		// (get) Token: 0x0602D9F8 RID: 186872 RVA: 0x00AC4D0F File Offset: 0x00AC2F0F
		// (set) Token: 0x0602D9F9 RID: 186873 RVA: 0x00AC4D1F File Offset: 0x00AC2F1F
		public unsafe float MaxSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ANS_PositionBranchTarget2_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ANS_PositionBranchTarget2_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17007D14 RID: 32020
		// (get) Token: 0x0602D9FA RID: 186874 RVA: 0x00AC4D30 File Offset: 0x00AC2F30
		// (set) Token: 0x0602D9FB RID: 186875 RVA: 0x00AC4D40 File Offset: 0x00AC2F40
		public unsafe bool 是否永远面向目标
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ANS_PositionBranchTarget2_C.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ANS_PositionBranchTarget2_C.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007D15 RID: 32021
		// (get) Token: 0x0602D9FC RID: 186876 RVA: 0x00AC4D51 File Offset: 0x00AC2F51
		// (set) Token: 0x0602D9FD RID: 186877 RVA: 0x00AC4D61 File Offset: 0x00AC2F61
		public unsafe bool 忽略Z轴方向
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ANS_PositionBranchTarget2_C.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ANS_PositionBranchTarget2_C.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007D16 RID: 32022
		// (get) Token: 0x0602D9FE RID: 186878 RVA: 0x00AC4D72 File Offset: 0x00AC2F72
		// (set) Token: 0x0602D9FF RID: 186879 RVA: 0x00AC4D82 File Offset: 0x00AC2F82
		public unsafe bool 忽略双方半径
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ANS_PositionBranchTarget2_C.__PropertyOffset_7) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ANS_PositionBranchTarget2_C.__PropertyOffset_7) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007D17 RID: 32023
		// (get) Token: 0x0602DA00 RID: 186880 RVA: 0x00AC4D93 File Offset: 0x00AC2F93
		// (set) Token: 0x0602DA01 RID: 186881 RVA: 0x00AC4DA3 File Offset: 0x00AC2FA3
		public unsafe float NowTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ANS_PositionBranchTarget2_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ANS_PositionBranchTarget2_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17007D18 RID: 32024
		// (get) Token: 0x0602DA02 RID: 186882 RVA: 0x00AC4DB4 File Offset: 0x00AC2FB4
		// (set) Token: 0x0602DA03 RID: 186883 RVA: 0x00AC4DC4 File Offset: 0x00AC2FC4
		public unsafe float TotalTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ANS_PositionBranchTarget2_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ANS_PositionBranchTarget2_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17007D19 RID: 32025
		// (get) Token: 0x0602DA04 RID: 186884 RVA: 0x00AC4DD5 File Offset: 0x00AC2FD5
		// (set) Token: 0x0602DA05 RID: 186885 RVA: 0x00AC4DE9 File Offset: 0x00AC2FE9
		[Nullable(1)]
		public unsafe string SocketName
		{
			[NullableContext(1)]
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)ANS_PositionBranchTarget2_C.__PropertyOffset_10)));
			}
			[NullableContext(1)]
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)ANS_PositionBranchTarget2_C.__PropertyOffset_10)), value);
			}
		}

		// Token: 0x17007D1A RID: 32026
		// (get) Token: 0x0602DA06 RID: 186886 RVA: 0x00AC4DFE File Offset: 0x00AC2FFE
		// (set) Token: 0x0602DA07 RID: 186887 RVA: 0x00AC4E0E File Offset: 0x00AC300E
		public unsafe bool IsShareTarget
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ANS_PositionBranchTarget2_C.__PropertyOffset_11) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ANS_PositionBranchTarget2_C.__PropertyOffset_11) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007D1B RID: 32027
		// (get) Token: 0x0602DA08 RID: 186888 RVA: 0x00AC4E1F File Offset: 0x00AC301F
		// (set) Token: 0x0602DA09 RID: 186889 RVA: 0x00AC4E33 File Offset: 0x00AC3033
		public unsafe FVectorDouble TargetOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ANS_PositionBranchTarget2_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ANS_PositionBranchTarget2_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17007D1C RID: 32028
		// (get) Token: 0x0602DA0A RID: 186890 RVA: 0x00AC4E48 File Offset: 0x00AC3048
		// (set) Token: 0x0602DA0B RID: 186891 RVA: 0x00AC4E5C File Offset: 0x00AC305C
		public unsafe FRotator TargetRotation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ANS_PositionBranchTarget2_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ANS_PositionBranchTarget2_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17007D1D RID: 32029
		// (get) Token: 0x0602DA0C RID: 186892 RVA: 0x00AC4E71 File Offset: 0x00AC3071
		// (set) Token: 0x0602DA0D RID: 186893 RVA: 0x00AC4E81 File Offset: 0x00AC3081
		public unsafe bool 允许反向移动
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ANS_PositionBranchTarget2_C.__PropertyOffset_14) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ANS_PositionBranchTarget2_C.__PropertyOffset_14) = (value ? 1 : 0);
			}
		}

		// Token: 0x0602DA0E RID: 186894 RVA: 0x00AC4E94 File Offset: 0x00AC3094
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void MoveToTarget(float Rate, float DeltaTime)
		{
			ANS_PositionBranchTarget2_C.__MoveToTarget_FunctionParams* ptr = stackalloc ANS_PositionBranchTarget2_C.__MoveToTarget_FunctionParams[(UIntPtr)959] + 15L / (long)sizeof(ANS_PositionBranchTarget2_C.__MoveToTarget_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ANS_PositionBranchTarget2_C.__MoveToTarget_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Rate = Rate;
			ptr->DeltaTime = DeltaTime;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ANS_PositionBranchTarget2_C.__MoveToTarget_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602DA0F RID: 186895 RVA: 0x00AC4EE4 File Offset: 0x00AC30E4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override bool K2_NotifyTick(USkeletalMeshComponent MeshComp, UAnimSequenceBase Animation, float FrameDeltaTime)
		{
			ANS_PositionBranchTarget2_C.__K2_NotifyTick_FunctionParams* ptr = stackalloc ANS_PositionBranchTarget2_C.__K2_NotifyTick_FunctionParams[(UIntPtr)103] + 15L / (long)sizeof(ANS_PositionBranchTarget2_C.__K2_NotifyTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ANS_PositionBranchTarget2_C.__K2_NotifyTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->MeshComp = ((MeshComp != null) ? MeshComp.NativePtr : IntPtr.Zero);
			ptr->Animation = ((Animation != null) ? Animation.NativePtr : IntPtr.Zero);
			ptr->FrameDeltaTime = FrameDeltaTime;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ANS_PositionBranchTarget2_C.__K2_NotifyTick_NativeFunctionPtr, (void*)ptr);
			return ptr->__Result;
		}

		// Token: 0x0602DA10 RID: 186896 RVA: 0x00AC4F5C File Offset: 0x00AC315C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual bool K2_NotifyTick_Implementation(USkeletalMeshComponent MeshComp, UAnimSequenceBase Animation, float FrameDeltaTime)
		{
			ANS_PositionBranchTarget2_C.__K2_NotifyTick_FunctionParams* ptr = stackalloc ANS_PositionBranchTarget2_C.__K2_NotifyTick_FunctionParams[(UIntPtr)103] + 15L / (long)sizeof(ANS_PositionBranchTarget2_C.__K2_NotifyTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ANS_PositionBranchTarget2_C.__K2_NotifyTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->MeshComp = ((MeshComp != null) ? MeshComp.NativePtr : IntPtr.Zero);
			ptr->Animation = ((Animation != null) ? Animation.NativePtr : IntPtr.Zero);
			ptr->FrameDeltaTime = FrameDeltaTime;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ANS_PositionBranchTarget2_C.__K2_NotifyTick_NativeFunctionPtr, (void*)ptr, 0);
			return ptr->__Result;
		}

		// Token: 0x0602DA11 RID: 186897 RVA: 0x00AC4FD8 File Offset: 0x00AC31D8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override bool K2_NotifyEnd(USkeletalMeshComponent MeshComp, UAnimSequenceBase Animation)
		{
			ANS_PositionBranchTarget2_C.__K2_NotifyEnd_FunctionParams* ptr = stackalloc ANS_PositionBranchTarget2_C.__K2_NotifyEnd_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(ANS_PositionBranchTarget2_C.__K2_NotifyEnd_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ANS_PositionBranchTarget2_C.__K2_NotifyEnd_NativeFunctionPtr, (void*)ptr, 1);
			ptr->MeshComp = ((MeshComp != null) ? MeshComp.NativePtr : IntPtr.Zero);
			ptr->Animation = ((Animation != null) ? Animation.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ANS_PositionBranchTarget2_C.__K2_NotifyEnd_NativeFunctionPtr, (void*)ptr);
			return ptr->__Result;
		}

		// Token: 0x0602DA12 RID: 186898 RVA: 0x00AC504C File Offset: 0x00AC324C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual bool K2_NotifyEnd_Implementation(USkeletalMeshComponent MeshComp, UAnimSequenceBase Animation)
		{
			ANS_PositionBranchTarget2_C.__K2_NotifyEnd_FunctionParams* ptr = stackalloc ANS_PositionBranchTarget2_C.__K2_NotifyEnd_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(ANS_PositionBranchTarget2_C.__K2_NotifyEnd_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ANS_PositionBranchTarget2_C.__K2_NotifyEnd_NativeFunctionPtr, (void*)ptr, 1);
			ptr->MeshComp = ((MeshComp != null) ? MeshComp.NativePtr : IntPtr.Zero);
			ptr->Animation = ((Animation != null) ? Animation.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ANS_PositionBranchTarget2_C.__K2_NotifyEnd_NativeFunctionPtr, (void*)ptr, 0);
			return ptr->__Result;
		}

		// Token: 0x0602DA13 RID: 186899 RVA: 0x00AC50C0 File Offset: 0x00AC32C0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override bool K2_NotifyBegin(USkeletalMeshComponent MeshComp, UAnimSequenceBase Animation, float TotalDuration)
		{
			ANS_PositionBranchTarget2_C.__K2_NotifyBegin_FunctionParams* ptr = stackalloc ANS_PositionBranchTarget2_C.__K2_NotifyBegin_FunctionParams[(UIntPtr)135] + 15L / (long)sizeof(ANS_PositionBranchTarget2_C.__K2_NotifyBegin_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ANS_PositionBranchTarget2_C.__K2_NotifyBegin_NativeFunctionPtr, (void*)ptr, 1);
			ptr->MeshComp = ((MeshComp != null) ? MeshComp.NativePtr : IntPtr.Zero);
			ptr->Animation = ((Animation != null) ? Animation.NativePtr : IntPtr.Zero);
			ptr->TotalDuration = TotalDuration;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ANS_PositionBranchTarget2_C.__K2_NotifyBegin_NativeFunctionPtr, (void*)ptr);
			return ptr->__Result;
		}

		// Token: 0x0602DA14 RID: 186900 RVA: 0x00AC513C File Offset: 0x00AC333C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent MeshComp, UAnimSequenceBase Animation, float TotalDuration)
		{
			ANS_PositionBranchTarget2_C.__K2_NotifyBegin_FunctionParams* ptr = stackalloc ANS_PositionBranchTarget2_C.__K2_NotifyBegin_FunctionParams[(UIntPtr)135] + 15L / (long)sizeof(ANS_PositionBranchTarget2_C.__K2_NotifyBegin_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ANS_PositionBranchTarget2_C.__K2_NotifyBegin_NativeFunctionPtr, (void*)ptr, 1);
			ptr->MeshComp = ((MeshComp != null) ? MeshComp.NativePtr : IntPtr.Zero);
			ptr->Animation = ((Animation != null) ? Animation.NativePtr : IntPtr.Zero);
			ptr->TotalDuration = TotalDuration;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ANS_PositionBranchTarget2_C.__K2_NotifyBegin_NativeFunctionPtr, (void*)ptr, 0);
			return ptr->__Result;
		}

		// Token: 0x0602DA15 RID: 186901 RVA: 0x00AC51B8 File Offset: 0x00AC33B8
		protected ANS_PositionBranchTarget2_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019B84 RID: 105348
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/AnimNotifyState/ANS_PositionBranchTarget2.ANS_PositionBranchTarget2_C";

		// Token: 0x04019B85 RID: 105349
		private static IntPtr _ClassPtr;

		// Token: 0x04019B86 RID: 105350
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04019B87 RID: 105351
		internal static int __PropertyOffset_0;

		// Token: 0x04019B88 RID: 105352
		internal static int __PropertyOffset_1;

		// Token: 0x04019B89 RID: 105353
		internal static int __PropertyOffset_2;

		// Token: 0x04019B8A RID: 105354
		internal static int __PropertyOffset_3;

		// Token: 0x04019B8B RID: 105355
		internal static int __PropertyOffset_4;

		// Token: 0x04019B8C RID: 105356
		internal static int __PropertyOffset_5;

		// Token: 0x04019B8D RID: 105357
		internal static int __PropertyOffset_6;

		// Token: 0x04019B8E RID: 105358
		internal static int __PropertyOffset_7;

		// Token: 0x04019B8F RID: 105359
		internal static int __PropertyOffset_8;

		// Token: 0x04019B90 RID: 105360
		internal static int __PropertyOffset_9;

		// Token: 0x04019B91 RID: 105361
		internal static int __PropertyOffset_10;

		// Token: 0x04019B92 RID: 105362
		internal static int __PropertyOffset_11;

		// Token: 0x04019B93 RID: 105363
		internal static int __PropertyOffset_12;

		// Token: 0x04019B94 RID: 105364
		internal static int __PropertyOffset_13;

		// Token: 0x04019B95 RID: 105365
		internal static int __PropertyOffset_14;

		// Token: 0x04019B96 RID: 105366
		private static IntPtr __MoveToTarget_NativeFunctionPtr;

		// Token: 0x04019B97 RID: 105367
		private static IntPtr __K2_NotifyTick_NativeFunctionPtr;

		// Token: 0x04019B98 RID: 105368
		private static IntPtr __K2_NotifyEnd_NativeFunctionPtr;

		// Token: 0x04019B99 RID: 105369
		private static IntPtr __K2_NotifyBegin_NativeFunctionPtr;

		// Token: 0x0200A52D RID: 42285
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 944)]
		protected ref struct __MoveToTarget_FunctionParams
		{
			// Token: 0x040333DD RID: 209885
			[FieldOffset(0)]
			public float Rate;

			// Token: 0x040333DE RID: 209886
			[FieldOffset(4)]
			public float DeltaTime;
		}

		// Token: 0x0200A52E RID: 42286
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 88)]
		protected new ref struct __K2_NotifyTick_FunctionParams
		{
			// Token: 0x040333DF RID: 209887
			[FieldOffset(0)]
			public IntPtr MeshComp;

			// Token: 0x040333E0 RID: 209888
			[FieldOffset(8)]
			public IntPtr Animation;

			// Token: 0x040333E1 RID: 209889
			[FieldOffset(16)]
			public float FrameDeltaTime;

			// Token: 0x040333E2 RID: 209890
			[FieldOffset(20)]
			public bool __Result;
		}

		// Token: 0x0200A52F RID: 42287
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected new ref struct __K2_NotifyEnd_FunctionParams
		{
			// Token: 0x040333E3 RID: 209891
			[FieldOffset(0)]
			public IntPtr MeshComp;

			// Token: 0x040333E4 RID: 209892
			[FieldOffset(8)]
			public IntPtr Animation;

			// Token: 0x040333E5 RID: 209893
			[FieldOffset(16)]
			public bool __Result;
		}

		// Token: 0x0200A530 RID: 42288
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 120)]
		protected new ref struct __K2_NotifyBegin_FunctionParams
		{
			// Token: 0x040333E6 RID: 209894
			[FieldOffset(0)]
			public IntPtr MeshComp;

			// Token: 0x040333E7 RID: 209895
			[FieldOffset(8)]
			public IntPtr Animation;

			// Token: 0x040333E8 RID: 209896
			[FieldOffset(16)]
			public float TotalDuration;

			// Token: 0x040333E9 RID: 209897
			[FieldOffset(20)]
			public bool __Result;
		}
	}
}
