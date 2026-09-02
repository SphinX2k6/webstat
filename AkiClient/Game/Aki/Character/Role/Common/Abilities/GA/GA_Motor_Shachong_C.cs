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
	// Token: 0x0200409D RID: 16541
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_Motor_Shachong.GA_Motor_Shachong_C")]
	[UnrealStructLayout(1528, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1524)]
	public class GA_Motor_Shachong_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602B0D5 RID: 176341 RVA: 0x00A6ECF8 File Offset: 0x00A6CEF8
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Motor_Shachong_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Motor_Shachong.GA_Motor_Shachong_C");
			}
			return GA_Motor_Shachong_C._ClassPtr;
		}

		// Token: 0x0602B0D6 RID: 176342 RVA: 0x00A6ED1C File Offset: 0x00A6CF1C
		public GA_Motor_Shachong_C() : this(BuiltinUtils.AllocNativeUObject(GA_Motor_Shachong_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602B0D7 RID: 176343 RVA: 0x00A6ED44 File Offset: 0x00A6CF44
		[NullableContext(1)]
		public GA_Motor_Shachong_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Motor_Shachong_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007089 RID: 28809
		// (get) Token: 0x0602B0D8 RID: 176344 RVA: 0x00A6ED78 File Offset: 0x00A6CF78
		// (set) Token: 0x0602B0D9 RID: 176345 RVA: 0x00A6EDB1 File Offset: 0x00A6CFB1
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Motor_Shachong_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Motor_Shachong_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700708A RID: 28810
		// (get) Token: 0x0602B0DA RID: 176346 RVA: 0x00A6EDD2 File Offset: 0x00A6CFD2
		// (set) Token: 0x0602B0DB RID: 176347 RVA: 0x00A6EDE6 File Offset: 0x00A6CFE6
		[Nullable(2)]
		public unsafe BP_Motor_BaseVehicle_C 摩托车对象缓存
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_Motor_BaseVehicle_C>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_Shachong_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_Shachong_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x1700708B RID: 28811
		// (get) Token: 0x0602B0DC RID: 176348 RVA: 0x00A6EDFB File Offset: 0x00A6CFFB
		// (set) Token: 0x0602B0DD RID: 176349 RVA: 0x00A6EE0B File Offset: 0x00A6D00B
		public unsafe int 摩托车对象entity_Id
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Motor_Shachong_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Motor_Shachong_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x1700708C RID: 28812
		// (get) Token: 0x0602B0DE RID: 176350 RVA: 0x00A6EE1C File Offset: 0x00A6D01C
		// (set) Token: 0x0602B0DF RID: 176351 RVA: 0x00A6EE30 File Offset: 0x00A6D030
		public unsafe FVector In_Out_Location
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Motor_Shachong_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Motor_Shachong_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x1700708D RID: 28813
		// (get) Token: 0x0602B0E0 RID: 176352 RVA: 0x00A6EE45 File Offset: 0x00A6D045
		// (set) Token: 0x0602B0E1 RID: 176353 RVA: 0x00A6EE59 File Offset: 0x00A6D059
		public unsafe FRotator Out_Rotation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Motor_Shachong_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Motor_Shachong_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x0602B0E2 RID: 176354 RVA: 0x00A6EE6E File Offset: 0x00A6D06E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Shachong_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602B0E3 RID: 176355 RVA: 0x00A6EE82 File Offset: 0x00A6D082
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_Shachong_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602B0E4 RID: 176356 RVA: 0x00A6EE98 File Offset: 0x00A6D098
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Motor_Shachong_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Motor_Shachong_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Motor_Shachong_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Shachong_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Shachong_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B0E5 RID: 176357 RVA: 0x00A6EEE0 File Offset: 0x00A6D0E0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Motor_Shachong_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Motor_Shachong_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Motor_Shachong_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Shachong_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_Shachong_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B0E6 RID: 176358 RVA: 0x00A6EF28 File Offset: 0x00A6D128
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Motor_Shachong(int EntryPoint)
		{
			GA_Motor_Shachong_C.__ExecuteUbergraph_GA_Motor_Shachong_FunctionParams* ptr = stackalloc GA_Motor_Shachong_C.__ExecuteUbergraph_GA_Motor_Shachong_FunctionParams[(UIntPtr)111] + 15L / (long)sizeof(GA_Motor_Shachong_C.__ExecuteUbergraph_GA_Motor_Shachong_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Shachong_C.__ExecuteUbergraph_GA_Motor_Shachong_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_Shachong_C.__ExecuteUbergraph_GA_Motor_Shachong_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B0E7 RID: 176359 RVA: 0x00A6EF6F File Offset: 0x00A6D16F
		protected GA_Motor_Shachong_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040178B9 RID: 96441
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Motor_Shachong.GA_Motor_Shachong_C";

		// Token: 0x040178BA RID: 96442
		private static IntPtr _ClassPtr;

		// Token: 0x040178BB RID: 96443
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040178BC RID: 96444
		internal new static int __PropertyOffset_0;

		// Token: 0x040178BD RID: 96445
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040178BE RID: 96446
		internal new static int __PropertyOffset_1;

		// Token: 0x040178BF RID: 96447
		internal new static int __PropertyOffset_2;

		// Token: 0x040178C0 RID: 96448
		internal new static int __PropertyOffset_3;

		// Token: 0x040178C1 RID: 96449
		internal static int __PropertyOffset_4;

		// Token: 0x040178C2 RID: 96450
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x040178C3 RID: 96451
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x040178C4 RID: 96452
		private static IntPtr __ExecuteUbergraph_GA_Motor_Shachong_NativeFunctionPtr;

		// Token: 0x0200A2DA RID: 41690
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x0403309B RID: 209051
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A2DB RID: 41691
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 96)]
		protected ref struct __ExecuteUbergraph_GA_Motor_Shachong_FunctionParams
		{
			// Token: 0x0403309C RID: 209052
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
