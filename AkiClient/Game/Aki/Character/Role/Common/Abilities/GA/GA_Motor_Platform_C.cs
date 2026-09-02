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
	// Token: 0x0200409C RID: 16540
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_Motor_Platform.GA_Motor_Platform_C")]
	[UnrealStructLayout(1496, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1496)]
	public class GA_Motor_Platform_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602B0C8 RID: 176328 RVA: 0x00A6EAEB File Offset: 0x00A6CCEB
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Motor_Platform_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Motor_Platform.GA_Motor_Platform_C");
			}
			return GA_Motor_Platform_C._ClassPtr;
		}

		// Token: 0x0602B0C9 RID: 176329 RVA: 0x00A6EB10 File Offset: 0x00A6CD10
		public GA_Motor_Platform_C() : this(BuiltinUtils.AllocNativeUObject(GA_Motor_Platform_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602B0CA RID: 176330 RVA: 0x00A6EB38 File Offset: 0x00A6CD38
		[NullableContext(1)]
		public GA_Motor_Platform_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Motor_Platform_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007087 RID: 28807
		// (get) Token: 0x0602B0CB RID: 176331 RVA: 0x00A6EB6C File Offset: 0x00A6CD6C
		// (set) Token: 0x0602B0CC RID: 176332 RVA: 0x00A6EBA5 File Offset: 0x00A6CDA5
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Motor_Platform_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Motor_Platform_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007088 RID: 28808
		// (get) Token: 0x0602B0CD RID: 176333 RVA: 0x00A6EBC6 File Offset: 0x00A6CDC6
		// (set) Token: 0x0602B0CE RID: 176334 RVA: 0x00A6EBDA File Offset: 0x00A6CDDA
		[Nullable(2)]
		public unsafe BP_Motor_BaseVehicle_C 摩托车对象缓存
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_Motor_BaseVehicle_C>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_Platform_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_Platform_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x0602B0CF RID: 176335 RVA: 0x00A6EBF0 File Offset: 0x00A6CDF0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Motor_Platform_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Motor_Platform_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Motor_Platform_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Platform_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Platform_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B0D0 RID: 176336 RVA: 0x00A6EC38 File Offset: 0x00A6CE38
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Motor_Platform_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Motor_Platform_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Motor_Platform_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Platform_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_Platform_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B0D1 RID: 176337 RVA: 0x00A6EC7F File Offset: 0x00A6CE7F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Platform_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602B0D2 RID: 176338 RVA: 0x00A6EC93 File Offset: 0x00A6CE93
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_Platform_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602B0D3 RID: 176339 RVA: 0x00A6ECA8 File Offset: 0x00A6CEA8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Motor_Platform(int EntryPoint)
		{
			GA_Motor_Platform_C.__ExecuteUbergraph_GA_Motor_Platform_FunctionParams* ptr = stackalloc GA_Motor_Platform_C.__ExecuteUbergraph_GA_Motor_Platform_FunctionParams[(UIntPtr)111] + 15L / (long)sizeof(GA_Motor_Platform_C.__ExecuteUbergraph_GA_Motor_Platform_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Platform_C.__ExecuteUbergraph_GA_Motor_Platform_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_Platform_C.__ExecuteUbergraph_GA_Motor_Platform_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B0D4 RID: 176340 RVA: 0x00A6ECEF File Offset: 0x00A6CEEF
		protected GA_Motor_Platform_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040178B0 RID: 96432
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Motor_Platform.GA_Motor_Platform_C";

		// Token: 0x040178B1 RID: 96433
		private static IntPtr _ClassPtr;

		// Token: 0x040178B2 RID: 96434
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040178B3 RID: 96435
		internal new static int __PropertyOffset_0;

		// Token: 0x040178B4 RID: 96436
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040178B5 RID: 96437
		internal new static int __PropertyOffset_1;

		// Token: 0x040178B6 RID: 96438
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x040178B7 RID: 96439
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x040178B8 RID: 96440
		private static IntPtr __ExecuteUbergraph_GA_Motor_Platform_NativeFunctionPtr;

		// Token: 0x0200A2D8 RID: 41688
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x04033099 RID: 209049
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A2D9 RID: 41689
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 96)]
		protected ref struct __ExecuteUbergraph_GA_Motor_Platform_FunctionParams
		{
			// Token: 0x0403309A RID: 209050
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
