using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Vehicle.Motor.Abilities.GA
{
	// Token: 0x02003FC9 RID: 16329
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_Drone_FreezeWater_End.GA_Motor_Drone_FreezeWater_End_C")]
	[UnrealStructLayout(1544, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1544)]
	public class GA_Motor_Drone_FreezeWater_End_C : GA_Motor_DroneBase_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06028FF9 RID: 167929 RVA: 0x00A1DD3F File Offset: 0x00A1BF3F
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Motor_Drone_FreezeWater_End_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_Drone_FreezeWater_End.GA_Motor_Drone_FreezeWater_End_C");
			}
			return GA_Motor_Drone_FreezeWater_End_C._ClassPtr;
		}

		// Token: 0x06028FFA RID: 167930 RVA: 0x00A1DD64 File Offset: 0x00A1BF64
		public GA_Motor_Drone_FreezeWater_End_C() : this(BuiltinUtils.AllocNativeUObject(GA_Motor_Drone_FreezeWater_End_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06028FFB RID: 167931 RVA: 0x00A1DD8C File Offset: 0x00A1BF8C
		public GA_Motor_Drone_FreezeWater_End_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Motor_Drone_FreezeWater_End_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17006506 RID: 25862
		// (get) Token: 0x06028FFC RID: 167932 RVA: 0x00A1DDC0 File Offset: 0x00A1BFC0
		// (set) Token: 0x06028FFD RID: 167933 RVA: 0x00A1DDF9 File Offset: 0x00A1BFF9
		public new FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Motor_Drone_FreezeWater_End_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Motor_Drone_FreezeWater_End_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006507 RID: 25863
		// (get) Token: 0x06028FFE RID: 167934 RVA: 0x00A1DE1C File Offset: 0x00A1C01C
		// (set) Token: 0x06028FFF RID: 167935 RVA: 0x00A1DE55 File Offset: 0x00A1C055
		public TArray<FGameplayTag> 挂点Tags
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FGameplayTag> result;
				if ((result = this._挂点Tags) == null)
				{
					result = (this._挂点Tags = new TArray<FGameplayTag>(base.NativePtr + (IntPtr)GA_Motor_Drone_FreezeWater_End_C.__PropertyOffset_1, this));
				}
				return result;
			}
			set
			{
				this.挂点Tags.CopyAssign(value);
			}
		}

		// Token: 0x06029000 RID: 167936 RVA: 0x00A1DE63 File Offset: 0x00A1C063
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Drone_FreezeWater_End_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x06029001 RID: 167937 RVA: 0x00A1DE77 File Offset: 0x00A1C077
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_Drone_FreezeWater_End_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06029002 RID: 167938 RVA: 0x00A1DE8C File Offset: 0x00A1C08C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Motor_Drone_FreezeWater_End_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Motor_Drone_FreezeWater_End_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Motor_Drone_FreezeWater_End_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Drone_FreezeWater_End_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Drone_FreezeWater_End_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06029003 RID: 167939 RVA: 0x00A1DED4 File Offset: 0x00A1C0D4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Motor_Drone_FreezeWater_End_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Motor_Drone_FreezeWater_End_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Motor_Drone_FreezeWater_End_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Drone_FreezeWater_End_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_Drone_FreezeWater_End_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06029004 RID: 167940 RVA: 0x00A1DF1C File Offset: 0x00A1C11C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Motor_Drone_FreezeWater_End(int EntryPoint)
		{
			GA_Motor_Drone_FreezeWater_End_C.__ExecuteUbergraph_GA_Motor_Drone_FreezeWater_End_FunctionParams* ptr = stackalloc GA_Motor_Drone_FreezeWater_End_C.__ExecuteUbergraph_GA_Motor_Drone_FreezeWater_End_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(GA_Motor_Drone_FreezeWater_End_C.__ExecuteUbergraph_GA_Motor_Drone_FreezeWater_End_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Drone_FreezeWater_End_C.__ExecuteUbergraph_GA_Motor_Drone_FreezeWater_End_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_Drone_FreezeWater_End_C.__ExecuteUbergraph_GA_Motor_Drone_FreezeWater_End_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06029005 RID: 167941 RVA: 0x00A1DF63 File Offset: 0x00A1C163
		protected GA_Motor_Drone_FreezeWater_End_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04015B3F RID: 88895
		public new const string __ObjectPath = "/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_Drone_FreezeWater_End.GA_Motor_Drone_FreezeWater_End_C";

		// Token: 0x04015B40 RID: 88896
		private static IntPtr _ClassPtr;

		// Token: 0x04015B41 RID: 88897
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04015B42 RID: 88898
		internal new static int __PropertyOffset_0;

		// Token: 0x04015B43 RID: 88899
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04015B44 RID: 88900
		internal new static int __PropertyOffset_1;

		// Token: 0x04015B45 RID: 88901
		[Nullable(2)]
		private TArray<FGameplayTag> _挂点Tags;

		// Token: 0x04015B46 RID: 88902
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04015B47 RID: 88903
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x04015B48 RID: 88904
		private static IntPtr __ExecuteUbergraph_GA_Motor_Drone_FreezeWater_End_NativeFunctionPtr;

		// Token: 0x0200A19D RID: 41373
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x04032EF5 RID: 208629
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A19E RID: 41374
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __ExecuteUbergraph_GA_Motor_Drone_FreezeWater_End_FunctionParams
		{
			// Token: 0x04032EF6 RID: 208630
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
