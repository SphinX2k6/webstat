using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Vehicle.Motor.Abilities.GA
{
	// Token: 0x02003FC6 RID: 16326
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_Drone_DyStart1.GA_Motor_Drone_DyStart1_C")]
	[UnrealStructLayout(1568, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1568)]
	public class GA_Motor_Drone_DyStart1_C : GA_Motor_DroneBase_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06028FC4 RID: 167876 RVA: 0x00A1D3BC File Offset: 0x00A1B5BC
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Motor_Drone_DyStart1_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_Drone_DyStart1.GA_Motor_Drone_DyStart1_C");
			}
			return GA_Motor_Drone_DyStart1_C._ClassPtr;
		}

		// Token: 0x06028FC5 RID: 167877 RVA: 0x00A1D3E0 File Offset: 0x00A1B5E0
		public GA_Motor_Drone_DyStart1_C() : this(BuiltinUtils.AllocNativeUObject(GA_Motor_Drone_DyStart1_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06028FC6 RID: 167878 RVA: 0x00A1D408 File Offset: 0x00A1B608
		public GA_Motor_Drone_DyStart1_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Motor_Drone_DyStart1_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170064FC RID: 25852
		// (get) Token: 0x06028FC7 RID: 167879 RVA: 0x00A1D43C File Offset: 0x00A1B63C
		// (set) Token: 0x06028FC8 RID: 167880 RVA: 0x00A1D475 File Offset: 0x00A1B675
		public new FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Motor_Drone_DyStart1_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Motor_Drone_DyStart1_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170064FD RID: 25853
		// (get) Token: 0x06028FC9 RID: 167881 RVA: 0x00A1D498 File Offset: 0x00A1B698
		// (set) Token: 0x06028FCA RID: 167882 RVA: 0x00A1D4D1 File Offset: 0x00A1B6D1
		public TArray<FGameplayTag> 挂点Tags
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FGameplayTag> result;
				if ((result = this._挂点Tags) == null)
				{
					result = (this._挂点Tags = new TArray<FGameplayTag>(base.NativePtr + (IntPtr)GA_Motor_Drone_DyStart1_C.__PropertyOffset_1, this));
				}
				return result;
			}
			set
			{
				this.挂点Tags.CopyAssign(value);
			}
		}

		// Token: 0x170064FE RID: 25854
		// (get) Token: 0x06028FCB RID: 167883 RVA: 0x00A1D4E0 File Offset: 0x00A1B6E0
		// (set) Token: 0x06028FCC RID: 167884 RVA: 0x00A1D519 File Offset: 0x00A1B719
		public TArray<FGameplayTag> 死眼Tag
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FGameplayTag> result;
				if ((result = this._死眼Tag) == null)
				{
					result = (this._死眼Tag = new TArray<FGameplayTag>(base.NativePtr + (IntPtr)GA_Motor_Drone_DyStart1_C.__PropertyOffset_2, this));
				}
				return result;
			}
			set
			{
				this.死眼Tag.CopyAssign(value);
			}
		}

		// Token: 0x170064FF RID: 25855
		// (get) Token: 0x06028FCD RID: 167885 RVA: 0x00A1D527 File Offset: 0x00A1B727
		// (set) Token: 0x06028FCE RID: 167886 RVA: 0x00A1D53B File Offset: 0x00A1B73B
		[Nullable(2)]
		public unsafe TsBaseVehicle 施法载具
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<TsBaseVehicle>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_Drone_DyStart1_C.__PropertyOffset_3);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_Drone_DyStart1_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x06028FCF RID: 167887 RVA: 0x00A1D550 File Offset: 0x00A1B750
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Motor_Drone_DyStart1_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Motor_Drone_DyStart1_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Motor_Drone_DyStart1_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Drone_DyStart1_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Drone_DyStart1_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06028FD0 RID: 167888 RVA: 0x00A1D598 File Offset: 0x00A1B798
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Motor_Drone_DyStart1_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Motor_Drone_DyStart1_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Motor_Drone_DyStart1_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Drone_DyStart1_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_Drone_DyStart1_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06028FD1 RID: 167889 RVA: 0x00A1D5DF File Offset: 0x00A1B7DF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Drone_DyStart1_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x06028FD2 RID: 167890 RVA: 0x00A1D5F3 File Offset: 0x00A1B7F3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_Drone_DyStart1_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06028FD3 RID: 167891 RVA: 0x00A1D608 File Offset: 0x00A1B808
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Motor_Drone_DyStart1(int EntryPoint)
		{
			GA_Motor_Drone_DyStart1_C.__ExecuteUbergraph_GA_Motor_Drone_DyStart1_FunctionParams* ptr = stackalloc GA_Motor_Drone_DyStart1_C.__ExecuteUbergraph_GA_Motor_Drone_DyStart1_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(GA_Motor_Drone_DyStart1_C.__ExecuteUbergraph_GA_Motor_Drone_DyStart1_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Drone_DyStart1_C.__ExecuteUbergraph_GA_Motor_Drone_DyStart1_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_Drone_DyStart1_C.__ExecuteUbergraph_GA_Motor_Drone_DyStart1_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06028FD4 RID: 167892 RVA: 0x00A1D64F File Offset: 0x00A1B84F
		protected GA_Motor_Drone_DyStart1_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04015B15 RID: 88853
		public new const string __ObjectPath = "/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_Drone_DyStart1.GA_Motor_Drone_DyStart1_C";

		// Token: 0x04015B16 RID: 88854
		private static IntPtr _ClassPtr;

		// Token: 0x04015B17 RID: 88855
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04015B18 RID: 88856
		internal new static int __PropertyOffset_0;

		// Token: 0x04015B19 RID: 88857
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04015B1A RID: 88858
		internal new static int __PropertyOffset_1;

		// Token: 0x04015B1B RID: 88859
		[Nullable(2)]
		private TArray<FGameplayTag> _挂点Tags;

		// Token: 0x04015B1C RID: 88860
		internal new static int __PropertyOffset_2;

		// Token: 0x04015B1D RID: 88861
		[Nullable(2)]
		private TArray<FGameplayTag> _死眼Tag;

		// Token: 0x04015B1E RID: 88862
		internal new static int __PropertyOffset_3;

		// Token: 0x04015B1F RID: 88863
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x04015B20 RID: 88864
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04015B21 RID: 88865
		private static IntPtr __ExecuteUbergraph_GA_Motor_Drone_DyStart1_NativeFunctionPtr;

		// Token: 0x0200A190 RID: 41360
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x04032EE4 RID: 208612
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A191 RID: 41361
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __ExecuteUbergraph_GA_Motor_Drone_DyStart1_FunctionParams
		{
			// Token: 0x04032EE5 RID: 208613
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
