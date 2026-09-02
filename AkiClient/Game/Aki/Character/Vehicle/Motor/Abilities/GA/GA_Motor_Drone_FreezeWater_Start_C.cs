using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Vehicle.Motor.Abilities.GA
{
	// Token: 0x02003FCA RID: 16330
	[UnrealObjectPath("/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_Drone_FreezeWater_Start.GA_Motor_Drone_FreezeWater_Start_C")]
	[UnrealStructLayout(1528, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1528)]
	public class GA_Motor_Drone_FreezeWater_Start_C : GA_Motor_DroneBase_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06029006 RID: 167942 RVA: 0x00A1DF6C File Offset: 0x00A1C16C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Motor_Drone_FreezeWater_Start_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_Drone_FreezeWater_Start.GA_Motor_Drone_FreezeWater_Start_C");
			}
			return GA_Motor_Drone_FreezeWater_Start_C._ClassPtr;
		}

		// Token: 0x06029007 RID: 167943 RVA: 0x00A1DF90 File Offset: 0x00A1C190
		public GA_Motor_Drone_FreezeWater_Start_C() : this(BuiltinUtils.AllocNativeUObject(GA_Motor_Drone_FreezeWater_Start_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06029008 RID: 167944 RVA: 0x00A1DFB8 File Offset: 0x00A1C1B8
		[NullableContext(1)]
		public GA_Motor_Drone_FreezeWater_Start_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Motor_Drone_FreezeWater_Start_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17006508 RID: 25864
		// (get) Token: 0x06029009 RID: 167945 RVA: 0x00A1DFEC File Offset: 0x00A1C1EC
		// (set) Token: 0x0602900A RID: 167946 RVA: 0x00A1E025 File Offset: 0x00A1C225
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Motor_Drone_FreezeWater_Start_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Motor_Drone_FreezeWater_Start_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x0602900B RID: 167947 RVA: 0x00A1E046 File Offset: 0x00A1C246
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Drone_FreezeWater_Start_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602900C RID: 167948 RVA: 0x00A1E05A File Offset: 0x00A1C25A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_Drone_FreezeWater_Start_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602900D RID: 167949 RVA: 0x00A1E070 File Offset: 0x00A1C270
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Motor_Drone_FreezeWater_Start_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Motor_Drone_FreezeWater_Start_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Motor_Drone_FreezeWater_Start_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Drone_FreezeWater_Start_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Drone_FreezeWater_Start_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602900E RID: 167950 RVA: 0x00A1E0B8 File Offset: 0x00A1C2B8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Motor_Drone_FreezeWater_Start_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Motor_Drone_FreezeWater_Start_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Motor_Drone_FreezeWater_Start_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Drone_FreezeWater_Start_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_Drone_FreezeWater_Start_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602900F RID: 167951 RVA: 0x00A1E100 File Offset: 0x00A1C300
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Motor_Drone_FreezeWater_Start(int EntryPoint)
		{
			GA_Motor_Drone_FreezeWater_Start_C.__ExecuteUbergraph_GA_Motor_Drone_FreezeWater_Start_FunctionParams* ptr = stackalloc GA_Motor_Drone_FreezeWater_Start_C.__ExecuteUbergraph_GA_Motor_Drone_FreezeWater_Start_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(GA_Motor_Drone_FreezeWater_Start_C.__ExecuteUbergraph_GA_Motor_Drone_FreezeWater_Start_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Drone_FreezeWater_Start_C.__ExecuteUbergraph_GA_Motor_Drone_FreezeWater_Start_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_Drone_FreezeWater_Start_C.__ExecuteUbergraph_GA_Motor_Drone_FreezeWater_Start_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06029010 RID: 167952 RVA: 0x00A1E147 File Offset: 0x00A1C347
		protected GA_Motor_Drone_FreezeWater_Start_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04015B49 RID: 88905
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_Drone_FreezeWater_Start.GA_Motor_Drone_FreezeWater_Start_C";

		// Token: 0x04015B4A RID: 88906
		private static IntPtr _ClassPtr;

		// Token: 0x04015B4B RID: 88907
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04015B4C RID: 88908
		internal new static int __PropertyOffset_0;

		// Token: 0x04015B4D RID: 88909
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04015B4E RID: 88910
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04015B4F RID: 88911
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x04015B50 RID: 88912
		private static IntPtr __ExecuteUbergraph_GA_Motor_Drone_FreezeWater_Start_NativeFunctionPtr;

		// Token: 0x0200A19F RID: 41375
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x04032EF7 RID: 208631
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A1A0 RID: 41376
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __ExecuteUbergraph_GA_Motor_Drone_FreezeWater_Start_FunctionParams
		{
			// Token: 0x04032EF8 RID: 208632
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
