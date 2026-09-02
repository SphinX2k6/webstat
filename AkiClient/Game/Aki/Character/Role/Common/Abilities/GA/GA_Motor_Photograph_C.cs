using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GA;
using AkiClient.Game.Aki.Character.Vehicle.Motor;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Abilities.GA
{
	// Token: 0x0200409B RID: 16539
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_Motor_Photograph.GA_Motor_Photograph_C")]
	[UnrealStructLayout(1528, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1524)]
	public class GA_Motor_Photograph_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602B0B3 RID: 176307 RVA: 0x00A6E79F File Offset: 0x00A6C99F
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Motor_Photograph_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Motor_Photograph.GA_Motor_Photograph_C");
			}
			return GA_Motor_Photograph_C._ClassPtr;
		}

		// Token: 0x0602B0B4 RID: 176308 RVA: 0x00A6E7C4 File Offset: 0x00A6C9C4
		public GA_Motor_Photograph_C() : this(BuiltinUtils.AllocNativeUObject(GA_Motor_Photograph_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602B0B5 RID: 176309 RVA: 0x00A6E7EC File Offset: 0x00A6C9EC
		[NullableContext(1)]
		public GA_Motor_Photograph_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Motor_Photograph_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007082 RID: 28802
		// (get) Token: 0x0602B0B6 RID: 176310 RVA: 0x00A6E820 File Offset: 0x00A6CA20
		// (set) Token: 0x0602B0B7 RID: 176311 RVA: 0x00A6E859 File Offset: 0x00A6CA59
		[Nullable(1)]
		public new FPointerToUberGraphFrame UberGraphFrame
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Motor_Photograph_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Motor_Photograph_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007083 RID: 28803
		// (get) Token: 0x0602B0B8 RID: 176312 RVA: 0x00A6E87A File Offset: 0x00A6CA7A
		// (set) Token: 0x0602B0B9 RID: 176313 RVA: 0x00A6E88E File Offset: 0x00A6CA8E
		[Nullable(2)]
		public unsafe BP_Motor_BaseVehicle_C 摩托车对象缓存
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_Motor_BaseVehicle_C>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_Photograph_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_Photograph_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17007084 RID: 28804
		// (get) Token: 0x0602B0BA RID: 176314 RVA: 0x00A6E8A3 File Offset: 0x00A6CAA3
		// (set) Token: 0x0602B0BB RID: 176315 RVA: 0x00A6E8B3 File Offset: 0x00A6CAB3
		public unsafe int 摩托车对象entity_Id
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Motor_Photograph_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Motor_Photograph_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17007085 RID: 28805
		// (get) Token: 0x0602B0BC RID: 176316 RVA: 0x00A6E8C4 File Offset: 0x00A6CAC4
		// (set) Token: 0x0602B0BD RID: 176317 RVA: 0x00A6E8D8 File Offset: 0x00A6CAD8
		public unsafe FVector In_Out_Location
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Motor_Photograph_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Motor_Photograph_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17007086 RID: 28806
		// (get) Token: 0x0602B0BE RID: 176318 RVA: 0x00A6E8ED File Offset: 0x00A6CAED
		// (set) Token: 0x0602B0BF RID: 176319 RVA: 0x00A6E901 File Offset: 0x00A6CB01
		public unsafe FRotator Out_Rotation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Motor_Photograph_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Motor_Photograph_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x0602B0C0 RID: 176320 RVA: 0x00A6E918 File Offset: 0x00A6CB18
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void TraceTest(FVectorDouble Start, FVectorDouble End, ref bool Block)
		{
			GA_Motor_Photograph_C.__TraceTest_FunctionParams* ptr = stackalloc GA_Motor_Photograph_C.__TraceTest_FunctionParams[(UIntPtr)407] + 15L / (long)sizeof(GA_Motor_Photograph_C.__TraceTest_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Photograph_C.__TraceTest_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Start = Start;
			ptr->End = End;
			ptr->Block = Block;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Photograph_C.__TraceTest_NativeFunctionPtr, (void*)ptr);
			Block = ptr->Block;
		}

		// Token: 0x0602B0C1 RID: 176321 RVA: 0x00A6E978 File Offset: 0x00A6CB78
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void FinishSummon(string Reason, bool ShowFloat)
		{
			GA_Motor_Photograph_C.__FinishSummon_FunctionParams* ptr = stackalloc GA_Motor_Photograph_C.__FinishSummon_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(GA_Motor_Photograph_C.__FinishSummon_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Photograph_C.__FinishSummon_NativeFunctionPtr, (void*)ptr, 1);
			FString.CopyFrom((void*)(&ptr->Reason), Reason);
			ptr->ShowFloat = ShowFloat;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Photograph_C.__FinishSummon_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(GA_Motor_Photograph_C.__FinishSummon_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602B0C2 RID: 176322 RVA: 0x00A6E9DC File Offset: 0x00A6CBDC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Photograph_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602B0C3 RID: 176323 RVA: 0x00A6E9F0 File Offset: 0x00A6CBF0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_Photograph_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602B0C4 RID: 176324 RVA: 0x00A6EA08 File Offset: 0x00A6CC08
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Motor_Photograph_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Motor_Photograph_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Motor_Photograph_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Photograph_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Photograph_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B0C5 RID: 176325 RVA: 0x00A6EA50 File Offset: 0x00A6CC50
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Motor_Photograph_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Motor_Photograph_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Motor_Photograph_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Photograph_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_Photograph_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B0C6 RID: 176326 RVA: 0x00A6EA98 File Offset: 0x00A6CC98
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Motor_Photograph(int EntryPoint)
		{
			GA_Motor_Photograph_C.__ExecuteUbergraph_GA_Motor_Photograph_FunctionParams* ptr = stackalloc GA_Motor_Photograph_C.__ExecuteUbergraph_GA_Motor_Photograph_FunctionParams[(UIntPtr)263] + 15L / (long)sizeof(GA_Motor_Photograph_C.__ExecuteUbergraph_GA_Motor_Photograph_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Photograph_C.__ExecuteUbergraph_GA_Motor_Photograph_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_Photograph_C.__ExecuteUbergraph_GA_Motor_Photograph_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B0C7 RID: 176327 RVA: 0x00A6EAE2 File Offset: 0x00A6CCE2
		protected GA_Motor_Photograph_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040178A2 RID: 96418
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Motor_Photograph.GA_Motor_Photograph_C";

		// Token: 0x040178A3 RID: 96419
		private static IntPtr _ClassPtr;

		// Token: 0x040178A4 RID: 96420
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040178A5 RID: 96421
		internal new static int __PropertyOffset_0;

		// Token: 0x040178A6 RID: 96422
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040178A7 RID: 96423
		internal new static int __PropertyOffset_1;

		// Token: 0x040178A8 RID: 96424
		internal new static int __PropertyOffset_2;

		// Token: 0x040178A9 RID: 96425
		internal new static int __PropertyOffset_3;

		// Token: 0x040178AA RID: 96426
		internal static int __PropertyOffset_4;

		// Token: 0x040178AB RID: 96427
		private static IntPtr __TraceTest_NativeFunctionPtr;

		// Token: 0x040178AC RID: 96428
		private static IntPtr __FinishSummon_NativeFunctionPtr;

		// Token: 0x040178AD RID: 96429
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x040178AE RID: 96430
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x040178AF RID: 96431
		private static IntPtr __ExecuteUbergraph_GA_Motor_Photograph_NativeFunctionPtr;

		// Token: 0x0200A2D4 RID: 41684
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 392)]
		protected ref struct __TraceTest_FunctionParams
		{
			// Token: 0x04033092 RID: 209042
			[FieldOffset(0)]
			public FVectorDouble Start;

			// Token: 0x04033093 RID: 209043
			[FieldOffset(24)]
			public FVectorDouble End;

			// Token: 0x04033094 RID: 209044
			[FieldOffset(48)]
			public bool Block;
		}

		// Token: 0x0200A2D5 RID: 41685
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __FinishSummon_FunctionParams
		{
			// Token: 0x04033095 RID: 209045
			[FieldOffset(0)]
			public FString Reason;

			// Token: 0x04033096 RID: 209046
			[FieldOffset(16)]
			public bool ShowFloat;
		}

		// Token: 0x0200A2D6 RID: 41686
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x04033097 RID: 209047
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A2D7 RID: 41687
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 248)]
		protected ref struct __ExecuteUbergraph_GA_Motor_Photograph_FunctionParams
		{
			// Token: 0x04033098 RID: 209048
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
