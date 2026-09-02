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
	// Token: 0x02003FD7 RID: 16343
	[UnrealObjectPath("/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_Jump_WindField.GA_Motor_Jump_WindField_C")]
	[UnrealStructLayout(1496, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1496)]
	public class GA_Motor_Jump_WindField_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06029182 RID: 168322 RVA: 0x00A20F7F File Offset: 0x00A1F17F
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Motor_Jump_WindField_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_Jump_WindField.GA_Motor_Jump_WindField_C");
			}
			return GA_Motor_Jump_WindField_C._ClassPtr;
		}

		// Token: 0x06029183 RID: 168323 RVA: 0x00A20FA4 File Offset: 0x00A1F1A4
		public GA_Motor_Jump_WindField_C() : this(BuiltinUtils.AllocNativeUObject(GA_Motor_Jump_WindField_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06029184 RID: 168324 RVA: 0x00A20FCC File Offset: 0x00A1F1CC
		[NullableContext(1)]
		public GA_Motor_Jump_WindField_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Motor_Jump_WindField_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700655F RID: 25951
		// (get) Token: 0x06029185 RID: 168325 RVA: 0x00A21000 File Offset: 0x00A1F200
		// (set) Token: 0x06029186 RID: 168326 RVA: 0x00A21039 File Offset: 0x00A1F239
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Motor_Jump_WindField_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Motor_Jump_WindField_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006560 RID: 25952
		// (get) Token: 0x06029187 RID: 168327 RVA: 0x00A2105A File Offset: 0x00A1F25A
		// (set) Token: 0x06029188 RID: 168328 RVA: 0x00A2106E File Offset: 0x00A1F26E
		[Nullable(2)]
		public unsafe AActor 被控物
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_Jump_WindField_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_Jump_WindField_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x06029189 RID: 168329 RVA: 0x00A21084 File Offset: 0x00A1F284
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetMontageTimeScale(ref float TimeScale)
		{
			GA_Motor_Jump_WindField_C.__GetMontageTimeScale_FunctionParams* ptr = stackalloc GA_Motor_Jump_WindField_C.__GetMontageTimeScale_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(GA_Motor_Jump_WindField_C.__GetMontageTimeScale_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Jump_WindField_C.__GetMontageTimeScale_NativeFunctionPtr, (void*)ptr, 1);
			ptr->TimeScale = TimeScale;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Jump_WindField_C.__GetMontageTimeScale_NativeFunctionPtr, (void*)ptr);
			TimeScale = ptr->TimeScale;
		}

		// Token: 0x0602918A RID: 168330 RVA: 0x00A210D3 File Offset: 0x00A1F2D3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_CF946D5D4EFE5E5564EFF09B8A496968()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Jump_WindField_C.__OnTick_CF946D5D4EFE5E5564EFF09B8A496968_NativeFunctionPtr, null);
		}

		// Token: 0x0602918B RID: 168331 RVA: 0x00A210E7 File Offset: 0x00A1F2E7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCancelled_CF946D5D4EFE5E5564EFF09B8A496968()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Jump_WindField_C.__OnCancelled_CF946D5D4EFE5E5564EFF09B8A496968_NativeFunctionPtr, null);
		}

		// Token: 0x0602918C RID: 168332 RVA: 0x00A210FB File Offset: 0x00A1F2FB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInterrupted_CF946D5D4EFE5E5564EFF09B8A496968()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Jump_WindField_C.__OnInterrupted_CF946D5D4EFE5E5564EFF09B8A496968_NativeFunctionPtr, null);
		}

		// Token: 0x0602918D RID: 168333 RVA: 0x00A2110F File Offset: 0x00A1F30F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBlendOut_CF946D5D4EFE5E5564EFF09B8A496968()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Jump_WindField_C.__OnBlendOut_CF946D5D4EFE5E5564EFF09B8A496968_NativeFunctionPtr, null);
		}

		// Token: 0x0602918E RID: 168334 RVA: 0x00A21123 File Offset: 0x00A1F323
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCompleted_CF946D5D4EFE5E5564EFF09B8A496968()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Jump_WindField_C.__OnCompleted_CF946D5D4EFE5E5564EFF09B8A496968_NativeFunctionPtr, null);
		}

		// Token: 0x0602918F RID: 168335 RVA: 0x00A21137 File Offset: 0x00A1F337
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_CF946D5D4EFE5E5564EFF09BAD82FE79()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Jump_WindField_C.__OnTick_CF946D5D4EFE5E5564EFF09BAD82FE79_NativeFunctionPtr, null);
		}

		// Token: 0x06029190 RID: 168336 RVA: 0x00A2114B File Offset: 0x00A1F34B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCancelled_CF946D5D4EFE5E5564EFF09BAD82FE79()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Jump_WindField_C.__OnCancelled_CF946D5D4EFE5E5564EFF09BAD82FE79_NativeFunctionPtr, null);
		}

		// Token: 0x06029191 RID: 168337 RVA: 0x00A2115F File Offset: 0x00A1F35F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInterrupted_CF946D5D4EFE5E5564EFF09BAD82FE79()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Jump_WindField_C.__OnInterrupted_CF946D5D4EFE5E5564EFF09BAD82FE79_NativeFunctionPtr, null);
		}

		// Token: 0x06029192 RID: 168338 RVA: 0x00A21173 File Offset: 0x00A1F373
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBlendOut_CF946D5D4EFE5E5564EFF09BAD82FE79()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Jump_WindField_C.__OnBlendOut_CF946D5D4EFE5E5564EFF09BAD82FE79_NativeFunctionPtr, null);
		}

		// Token: 0x06029193 RID: 168339 RVA: 0x00A21187 File Offset: 0x00A1F387
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCompleted_CF946D5D4EFE5E5564EFF09BAD82FE79()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Jump_WindField_C.__OnCompleted_CF946D5D4EFE5E5564EFF09BAD82FE79_NativeFunctionPtr, null);
		}

		// Token: 0x06029194 RID: 168340 RVA: 0x00A2119B File Offset: 0x00A1F39B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Jump_WindField_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x06029195 RID: 168341 RVA: 0x00A211AF File Offset: 0x00A1F3AF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_Jump_WindField_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06029196 RID: 168342 RVA: 0x00A211C4 File Offset: 0x00A1F3C4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Motor_Jump_WindField_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Motor_Jump_WindField_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Motor_Jump_WindField_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Jump_WindField_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Jump_WindField_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06029197 RID: 168343 RVA: 0x00A2120C File Offset: 0x00A1F40C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Motor_Jump_WindField_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Motor_Jump_WindField_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Motor_Jump_WindField_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Jump_WindField_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_Jump_WindField_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06029198 RID: 168344 RVA: 0x00A21254 File Offset: 0x00A1F454
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Motor_Jump_WindField(int EntryPoint)
		{
			GA_Motor_Jump_WindField_C.__ExecuteUbergraph_GA_Motor_Jump_WindField_FunctionParams* ptr = stackalloc GA_Motor_Jump_WindField_C.__ExecuteUbergraph_GA_Motor_Jump_WindField_FunctionParams[(UIntPtr)719] + 15L / (long)sizeof(GA_Motor_Jump_WindField_C.__ExecuteUbergraph_GA_Motor_Jump_WindField_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Jump_WindField_C.__ExecuteUbergraph_GA_Motor_Jump_WindField_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_Jump_WindField_C.__ExecuteUbergraph_GA_Motor_Jump_WindField_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06029199 RID: 168345 RVA: 0x00A2129E File Offset: 0x00A1F49E
		protected GA_Motor_Jump_WindField_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04015C57 RID: 89175
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_Jump_WindField.GA_Motor_Jump_WindField_C";

		// Token: 0x04015C58 RID: 89176
		private static IntPtr _ClassPtr;

		// Token: 0x04015C59 RID: 89177
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04015C5A RID: 89178
		internal new static int __PropertyOffset_0;

		// Token: 0x04015C5B RID: 89179
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04015C5C RID: 89180
		internal new static int __PropertyOffset_1;

		// Token: 0x04015C5D RID: 89181
		private static IntPtr __GetMontageTimeScale_NativeFunctionPtr;

		// Token: 0x04015C5E RID: 89182
		private static IntPtr __OnTick_CF946D5D4EFE5E5564EFF09B8A496968_NativeFunctionPtr;

		// Token: 0x04015C5F RID: 89183
		private static IntPtr __OnCancelled_CF946D5D4EFE5E5564EFF09B8A496968_NativeFunctionPtr;

		// Token: 0x04015C60 RID: 89184
		private static IntPtr __OnInterrupted_CF946D5D4EFE5E5564EFF09B8A496968_NativeFunctionPtr;

		// Token: 0x04015C61 RID: 89185
		private static IntPtr __OnBlendOut_CF946D5D4EFE5E5564EFF09B8A496968_NativeFunctionPtr;

		// Token: 0x04015C62 RID: 89186
		private static IntPtr __OnCompleted_CF946D5D4EFE5E5564EFF09B8A496968_NativeFunctionPtr;

		// Token: 0x04015C63 RID: 89187
		private static IntPtr __OnTick_CF946D5D4EFE5E5564EFF09BAD82FE79_NativeFunctionPtr;

		// Token: 0x04015C64 RID: 89188
		private static IntPtr __OnCancelled_CF946D5D4EFE5E5564EFF09BAD82FE79_NativeFunctionPtr;

		// Token: 0x04015C65 RID: 89189
		private static IntPtr __OnInterrupted_CF946D5D4EFE5E5564EFF09BAD82FE79_NativeFunctionPtr;

		// Token: 0x04015C66 RID: 89190
		private static IntPtr __OnBlendOut_CF946D5D4EFE5E5564EFF09BAD82FE79_NativeFunctionPtr;

		// Token: 0x04015C67 RID: 89191
		private static IntPtr __OnCompleted_CF946D5D4EFE5E5564EFF09BAD82FE79_NativeFunctionPtr;

		// Token: 0x04015C68 RID: 89192
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04015C69 RID: 89193
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x04015C6A RID: 89194
		private static IntPtr __ExecuteUbergraph_GA_Motor_Jump_WindField_NativeFunctionPtr;

		// Token: 0x0200A1CC RID: 41420
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __GetMontageTimeScale_FunctionParams
		{
			// Token: 0x04032F29 RID: 208681
			[FieldOffset(0)]
			public float TimeScale;
		}

		// Token: 0x0200A1CD RID: 41421
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x04032F2A RID: 208682
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A1CE RID: 41422
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 704)]
		protected ref struct __ExecuteUbergraph_GA_Motor_Jump_WindField_FunctionParams
		{
			// Token: 0x04032F2B RID: 208683
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
