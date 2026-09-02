using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GA;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Vehicle.Motor.Abilities.GA
{
	// Token: 0x02003FE1 RID: 16353
	[UnrealObjectPath("/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_Saomiao.GA_Motor_Saomiao_C")]
	[UnrealStructLayout(1496, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1496)]
	public class GA_Motor_Saomiao_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602928D RID: 168589 RVA: 0x00A22FA3 File Offset: 0x00A211A3
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Motor_Saomiao_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_Saomiao.GA_Motor_Saomiao_C");
			}
			return GA_Motor_Saomiao_C._ClassPtr;
		}

		// Token: 0x0602928E RID: 168590 RVA: 0x00A22FC8 File Offset: 0x00A211C8
		public GA_Motor_Saomiao_C() : this(BuiltinUtils.AllocNativeUObject(GA_Motor_Saomiao_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602928F RID: 168591 RVA: 0x00A22FF0 File Offset: 0x00A211F0
		[NullableContext(1)]
		public GA_Motor_Saomiao_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Motor_Saomiao_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17006584 RID: 25988
		// (get) Token: 0x06029290 RID: 168592 RVA: 0x00A23024 File Offset: 0x00A21224
		// (set) Token: 0x06029291 RID: 168593 RVA: 0x00A2305D File Offset: 0x00A2125D
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Motor_Saomiao_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Motor_Saomiao_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006585 RID: 25989
		// (get) Token: 0x06029292 RID: 168594 RVA: 0x00A2307E File Offset: 0x00A2127E
		// (set) Token: 0x06029293 RID: 168595 RVA: 0x00A23092 File Offset: 0x00A21292
		[Nullable(2)]
		public unsafe AActor 被控物
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_Saomiao_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_Saomiao_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x06029294 RID: 168596 RVA: 0x00A230A7 File Offset: 0x00A212A7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Saomiao_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x06029295 RID: 168597 RVA: 0x00A230BB File Offset: 0x00A212BB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_Saomiao_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06029296 RID: 168598 RVA: 0x00A230D0 File Offset: 0x00A212D0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Motor_Saomiao_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Motor_Saomiao_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Motor_Saomiao_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Saomiao_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Saomiao_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06029297 RID: 168599 RVA: 0x00A23118 File Offset: 0x00A21318
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Motor_Saomiao_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Motor_Saomiao_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Motor_Saomiao_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Saomiao_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_Saomiao_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06029298 RID: 168600 RVA: 0x00A23160 File Offset: 0x00A21360
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Motor_Saomiao(int EntryPoint)
		{
			GA_Motor_Saomiao_C.__ExecuteUbergraph_GA_Motor_Saomiao_FunctionParams* ptr = stackalloc GA_Motor_Saomiao_C.__ExecuteUbergraph_GA_Motor_Saomiao_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(GA_Motor_Saomiao_C.__ExecuteUbergraph_GA_Motor_Saomiao_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Saomiao_C.__ExecuteUbergraph_GA_Motor_Saomiao_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_Saomiao_C.__ExecuteUbergraph_GA_Motor_Saomiao_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06029299 RID: 168601 RVA: 0x00A231A7 File Offset: 0x00A213A7
		protected GA_Motor_Saomiao_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04015D2B RID: 89387
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_Saomiao.GA_Motor_Saomiao_C";

		// Token: 0x04015D2C RID: 89388
		private static IntPtr _ClassPtr;

		// Token: 0x04015D2D RID: 89389
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04015D2E RID: 89390
		internal new static int __PropertyOffset_0;

		// Token: 0x04015D2F RID: 89391
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04015D30 RID: 89392
		internal new static int __PropertyOffset_1;

		// Token: 0x04015D31 RID: 89393
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04015D32 RID: 89394
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x04015D33 RID: 89395
		private static IntPtr __ExecuteUbergraph_GA_Motor_Saomiao_NativeFunctionPtr;

		// Token: 0x0200A1E5 RID: 41445
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x04032F42 RID: 208706
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A1E6 RID: 41446
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __ExecuteUbergraph_GA_Motor_Saomiao_FunctionParams
		{
			// Token: 0x04032F43 RID: 208707
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
