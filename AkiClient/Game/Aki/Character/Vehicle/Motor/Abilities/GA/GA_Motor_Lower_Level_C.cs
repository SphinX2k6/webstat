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
	// Token: 0x02003FDC RID: 16348
	[UnrealObjectPath("/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_Lower_Level.GA_Motor_Lower_Level_C")]
	[UnrealStructLayout(1504, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1504)]
	public class GA_Motor_Lower_Level_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06029210 RID: 168464 RVA: 0x00A22027 File Offset: 0x00A20227
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Motor_Lower_Level_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_Lower_Level.GA_Motor_Lower_Level_C");
			}
			return GA_Motor_Lower_Level_C._ClassPtr;
		}

		// Token: 0x06029211 RID: 168465 RVA: 0x00A2204C File Offset: 0x00A2024C
		public GA_Motor_Lower_Level_C() : this(BuiltinUtils.AllocNativeUObject(GA_Motor_Lower_Level_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06029212 RID: 168466 RVA: 0x00A22074 File Offset: 0x00A20274
		[NullableContext(1)]
		public GA_Motor_Lower_Level_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Motor_Lower_Level_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17006570 RID: 25968
		// (get) Token: 0x06029213 RID: 168467 RVA: 0x00A220A8 File Offset: 0x00A202A8
		// (set) Token: 0x06029214 RID: 168468 RVA: 0x00A220E1 File Offset: 0x00A202E1
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Motor_Lower_Level_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Motor_Lower_Level_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006571 RID: 25969
		// (get) Token: 0x06029215 RID: 168469 RVA: 0x00A22102 File Offset: 0x00A20302
		// (set) Token: 0x06029216 RID: 168470 RVA: 0x00A22112 File Offset: 0x00A20312
		public unsafe bool 是否主动结束
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Motor_Lower_Level_C.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Motor_Lower_Level_C.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x17006572 RID: 25970
		// (get) Token: 0x06029217 RID: 168471 RVA: 0x00A22123 File Offset: 0x00A20323
		// (set) Token: 0x06029218 RID: 168472 RVA: 0x00A22137 File Offset: 0x00A20337
		[Nullable(2)]
		public unsafe TsBaseCharacter 驾驶员
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<TsBaseCharacter>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_Lower_Level_C.__PropertyOffset_2);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_Lower_Level_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x06029219 RID: 168473 RVA: 0x00A2214C File Offset: 0x00A2034C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_CF946D5D4EFE5E5564EFF09BA87D4529()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Lower_Level_C.__OnTick_CF946D5D4EFE5E5564EFF09BA87D4529_NativeFunctionPtr, null);
		}

		// Token: 0x0602921A RID: 168474 RVA: 0x00A22160 File Offset: 0x00A20360
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCancelled_CF946D5D4EFE5E5564EFF09BA87D4529()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Lower_Level_C.__OnCancelled_CF946D5D4EFE5E5564EFF09BA87D4529_NativeFunctionPtr, null);
		}

		// Token: 0x0602921B RID: 168475 RVA: 0x00A22174 File Offset: 0x00A20374
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInterrupted_CF946D5D4EFE5E5564EFF09BA87D4529()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Lower_Level_C.__OnInterrupted_CF946D5D4EFE5E5564EFF09BA87D4529_NativeFunctionPtr, null);
		}

		// Token: 0x0602921C RID: 168476 RVA: 0x00A22188 File Offset: 0x00A20388
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBlendOut_CF946D5D4EFE5E5564EFF09BA87D4529()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Lower_Level_C.__OnBlendOut_CF946D5D4EFE5E5564EFF09BA87D4529_NativeFunctionPtr, null);
		}

		// Token: 0x0602921D RID: 168477 RVA: 0x00A2219C File Offset: 0x00A2039C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCompleted_CF946D5D4EFE5E5564EFF09BA87D4529()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Lower_Level_C.__OnCompleted_CF946D5D4EFE5E5564EFF09BA87D4529_NativeFunctionPtr, null);
		}

		// Token: 0x0602921E RID: 168478 RVA: 0x00A221B0 File Offset: 0x00A203B0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_CF946D5D4EFE5E5564EFF09BC2C5D807()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Lower_Level_C.__OnTick_CF946D5D4EFE5E5564EFF09BC2C5D807_NativeFunctionPtr, null);
		}

		// Token: 0x0602921F RID: 168479 RVA: 0x00A221C4 File Offset: 0x00A203C4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCancelled_CF946D5D4EFE5E5564EFF09BC2C5D807()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Lower_Level_C.__OnCancelled_CF946D5D4EFE5E5564EFF09BC2C5D807_NativeFunctionPtr, null);
		}

		// Token: 0x06029220 RID: 168480 RVA: 0x00A221D8 File Offset: 0x00A203D8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInterrupted_CF946D5D4EFE5E5564EFF09BC2C5D807()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Lower_Level_C.__OnInterrupted_CF946D5D4EFE5E5564EFF09BC2C5D807_NativeFunctionPtr, null);
		}

		// Token: 0x06029221 RID: 168481 RVA: 0x00A221EC File Offset: 0x00A203EC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBlendOut_CF946D5D4EFE5E5564EFF09BC2C5D807()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Lower_Level_C.__OnBlendOut_CF946D5D4EFE5E5564EFF09BC2C5D807_NativeFunctionPtr, null);
		}

		// Token: 0x06029222 RID: 168482 RVA: 0x00A22200 File Offset: 0x00A20400
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCompleted_CF946D5D4EFE5E5564EFF09BC2C5D807()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Lower_Level_C.__OnCompleted_CF946D5D4EFE5E5564EFF09BC2C5D807_NativeFunctionPtr, null);
		}

		// Token: 0x06029223 RID: 168483 RVA: 0x00A22214 File Offset: 0x00A20414
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Removed_DB9F64004F8908FEAD99D38123D3BC99(in FGameplayTag Tag)
		{
			GA_Motor_Lower_Level_C.__Removed_DB9F64004F8908FEAD99D38123D3BC99_FunctionParams* ptr = stackalloc GA_Motor_Lower_Level_C.__Removed_DB9F64004F8908FEAD99D38123D3BC99_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_Motor_Lower_Level_C.__Removed_DB9F64004F8908FEAD99D38123D3BC99_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Lower_Level_C.__Removed_DB9F64004F8908FEAD99D38123D3BC99_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Lower_Level_C.__Removed_DB9F64004F8908FEAD99D38123D3BC99_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06029224 RID: 168484 RVA: 0x00A2225F File Offset: 0x00A2045F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Lower_Level_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x06029225 RID: 168485 RVA: 0x00A22273 File Offset: 0x00A20473
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_Lower_Level_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06029226 RID: 168486 RVA: 0x00A22288 File Offset: 0x00A20488
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Motor_Lower_Level_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Motor_Lower_Level_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Motor_Lower_Level_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Lower_Level_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Lower_Level_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06029227 RID: 168487 RVA: 0x00A222D0 File Offset: 0x00A204D0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Motor_Lower_Level_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Motor_Lower_Level_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Motor_Lower_Level_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Lower_Level_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_Lower_Level_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06029228 RID: 168488 RVA: 0x00A22318 File Offset: 0x00A20518
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Motor_Lower_Level(int EntryPoint)
		{
			GA_Motor_Lower_Level_C.__ExecuteUbergraph_GA_Motor_Lower_Level_FunctionParams* ptr = stackalloc GA_Motor_Lower_Level_C.__ExecuteUbergraph_GA_Motor_Lower_Level_FunctionParams[(UIntPtr)767] + 15L / (long)sizeof(GA_Motor_Lower_Level_C.__ExecuteUbergraph_GA_Motor_Lower_Level_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Lower_Level_C.__ExecuteUbergraph_GA_Motor_Lower_Level_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_Lower_Level_C.__ExecuteUbergraph_GA_Motor_Lower_Level_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06029229 RID: 168489 RVA: 0x00A22362 File Offset: 0x00A20562
		protected GA_Motor_Lower_Level_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04015CCB RID: 89291
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_Lower_Level.GA_Motor_Lower_Level_C";

		// Token: 0x04015CCC RID: 89292
		private static IntPtr _ClassPtr;

		// Token: 0x04015CCD RID: 89293
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04015CCE RID: 89294
		internal new static int __PropertyOffset_0;

		// Token: 0x04015CCF RID: 89295
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04015CD0 RID: 89296
		internal new static int __PropertyOffset_1;

		// Token: 0x04015CD1 RID: 89297
		internal new static int __PropertyOffset_2;

		// Token: 0x04015CD2 RID: 89298
		private static IntPtr __OnTick_CF946D5D4EFE5E5564EFF09BA87D4529_NativeFunctionPtr;

		// Token: 0x04015CD3 RID: 89299
		private static IntPtr __OnCancelled_CF946D5D4EFE5E5564EFF09BA87D4529_NativeFunctionPtr;

		// Token: 0x04015CD4 RID: 89300
		private static IntPtr __OnInterrupted_CF946D5D4EFE5E5564EFF09BA87D4529_NativeFunctionPtr;

		// Token: 0x04015CD5 RID: 89301
		private static IntPtr __OnBlendOut_CF946D5D4EFE5E5564EFF09BA87D4529_NativeFunctionPtr;

		// Token: 0x04015CD6 RID: 89302
		private static IntPtr __OnCompleted_CF946D5D4EFE5E5564EFF09BA87D4529_NativeFunctionPtr;

		// Token: 0x04015CD7 RID: 89303
		private static IntPtr __OnTick_CF946D5D4EFE5E5564EFF09BC2C5D807_NativeFunctionPtr;

		// Token: 0x04015CD8 RID: 89304
		private static IntPtr __OnCancelled_CF946D5D4EFE5E5564EFF09BC2C5D807_NativeFunctionPtr;

		// Token: 0x04015CD9 RID: 89305
		private static IntPtr __OnInterrupted_CF946D5D4EFE5E5564EFF09BC2C5D807_NativeFunctionPtr;

		// Token: 0x04015CDA RID: 89306
		private static IntPtr __OnBlendOut_CF946D5D4EFE5E5564EFF09BC2C5D807_NativeFunctionPtr;

		// Token: 0x04015CDB RID: 89307
		private static IntPtr __OnCompleted_CF946D5D4EFE5E5564EFF09BC2C5D807_NativeFunctionPtr;

		// Token: 0x04015CDC RID: 89308
		private static IntPtr __Removed_DB9F64004F8908FEAD99D38123D3BC99_NativeFunctionPtr;

		// Token: 0x04015CDD RID: 89309
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04015CDE RID: 89310
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x04015CDF RID: 89311
		private static IntPtr __ExecuteUbergraph_GA_Motor_Lower_Level_NativeFunctionPtr;

		// Token: 0x0200A1D9 RID: 41433
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Removed_DB9F64004F8908FEAD99D38123D3BC99_FunctionParams
		{
			// Token: 0x04032F36 RID: 208694
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A1DA RID: 41434
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x04032F37 RID: 208695
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A1DB RID: 41435
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 752)]
		protected ref struct __ExecuteUbergraph_GA_Motor_Lower_Level_FunctionParams
		{
			// Token: 0x04032F38 RID: 208696
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
