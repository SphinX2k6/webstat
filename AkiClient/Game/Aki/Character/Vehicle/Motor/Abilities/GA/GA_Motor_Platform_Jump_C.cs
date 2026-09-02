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
	// Token: 0x02003FDF RID: 16351
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_Platform_Jump.GA_Motor_Platform_Jump_C")]
	[UnrealStructLayout(1528, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1528)]
	public class GA_Motor_Platform_Jump_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602925A RID: 168538 RVA: 0x00A22967 File Offset: 0x00A20B67
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Motor_Platform_Jump_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_Platform_Jump.GA_Motor_Platform_Jump_C");
			}
			return GA_Motor_Platform_Jump_C._ClassPtr;
		}

		// Token: 0x0602925B RID: 168539 RVA: 0x00A2298C File Offset: 0x00A20B8C
		public GA_Motor_Platform_Jump_C() : this(BuiltinUtils.AllocNativeUObject(GA_Motor_Platform_Jump_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602925C RID: 168540 RVA: 0x00A229B4 File Offset: 0x00A20BB4
		[NullableContext(1)]
		public GA_Motor_Platform_Jump_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Motor_Platform_Jump_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700657C RID: 25980
		// (get) Token: 0x0602925D RID: 168541 RVA: 0x00A229E8 File Offset: 0x00A20BE8
		// (set) Token: 0x0602925E RID: 168542 RVA: 0x00A22A21 File Offset: 0x00A20C21
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Motor_Platform_Jump_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Motor_Platform_Jump_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700657D RID: 25981
		// (get) Token: 0x0602925F RID: 168543 RVA: 0x00A22A42 File Offset: 0x00A20C42
		// (set) Token: 0x06029260 RID: 168544 RVA: 0x00A22A52 File Offset: 0x00A20C52
		public unsafe bool 是否主动结束
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Motor_Platform_Jump_C.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Motor_Platform_Jump_C.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700657E RID: 25982
		// (get) Token: 0x06029261 RID: 168545 RVA: 0x00A22A63 File Offset: 0x00A20C63
		// (set) Token: 0x06029262 RID: 168546 RVA: 0x00A22A77 File Offset: 0x00A20C77
		public unsafe TsBaseCharacter 驾驶员
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<TsBaseCharacter>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_Platform_Jump_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_Platform_Jump_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x1700657F RID: 25983
		// (get) Token: 0x06029263 RID: 168547 RVA: 0x00A22A8C File Offset: 0x00A20C8C
		// (set) Token: 0x06029264 RID: 168548 RVA: 0x00A22A9C File Offset: 0x00A20C9C
		public unsafe bool 是否进入了Catapult
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Motor_Platform_Jump_C.__PropertyOffset_3) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Motor_Platform_Jump_C.__PropertyOffset_3) = (value ? 1 : 0);
			}
		}

		// Token: 0x17006580 RID: 25984
		// (get) Token: 0x06029265 RID: 168549 RVA: 0x00A22AAD File Offset: 0x00A20CAD
		// (set) Token: 0x06029266 RID: 168550 RVA: 0x00A22ABD File Offset: 0x00A20CBD
		public unsafe bool 接Idle技能
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Motor_Platform_Jump_C.__PropertyOffset_4) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Motor_Platform_Jump_C.__PropertyOffset_4) = (value ? 1 : 0);
			}
		}

		// Token: 0x17006581 RID: 25985
		// (get) Token: 0x06029267 RID: 168551 RVA: 0x00A22ACE File Offset: 0x00A20CCE
		// (set) Token: 0x06029268 RID: 168552 RVA: 0x00A22AE2 File Offset: 0x00A20CE2
		public unsafe FVector Offset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Motor_Platform_Jump_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Motor_Platform_Jump_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17006582 RID: 25986
		// (get) Token: 0x06029269 RID: 168553 RVA: 0x00A22AF7 File Offset: 0x00A20CF7
		// (set) Token: 0x0602926A RID: 168554 RVA: 0x00A22B0B File Offset: 0x00A20D0B
		public unsafe TsBaseVehicle 施法载具
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<TsBaseVehicle>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_Platform_Jump_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_Platform_Jump_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x0602926B RID: 168555 RVA: 0x00A22B20 File Offset: 0x00A20D20
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void NewFunction_0()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Platform_Jump_C.__NewFunction_0_NativeFunctionPtr, null);
		}

		// Token: 0x0602926C RID: 168556 RVA: 0x00A22B34 File Offset: 0x00A20D34
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_CF946D5D4EFE5E5564EFF09B6249659C()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Platform_Jump_C.__OnTick_CF946D5D4EFE5E5564EFF09B6249659C_NativeFunctionPtr, null);
		}

		// Token: 0x0602926D RID: 168557 RVA: 0x00A22B48 File Offset: 0x00A20D48
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCancelled_CF946D5D4EFE5E5564EFF09B6249659C()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Platform_Jump_C.__OnCancelled_CF946D5D4EFE5E5564EFF09B6249659C_NativeFunctionPtr, null);
		}

		// Token: 0x0602926E RID: 168558 RVA: 0x00A22B5C File Offset: 0x00A20D5C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInterrupted_CF946D5D4EFE5E5564EFF09B6249659C()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Platform_Jump_C.__OnInterrupted_CF946D5D4EFE5E5564EFF09B6249659C_NativeFunctionPtr, null);
		}

		// Token: 0x0602926F RID: 168559 RVA: 0x00A22B70 File Offset: 0x00A20D70
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBlendOut_CF946D5D4EFE5E5564EFF09B6249659C()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Platform_Jump_C.__OnBlendOut_CF946D5D4EFE5E5564EFF09B6249659C_NativeFunctionPtr, null);
		}

		// Token: 0x06029270 RID: 168560 RVA: 0x00A22B84 File Offset: 0x00A20D84
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCompleted_CF946D5D4EFE5E5564EFF09B6249659C()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Platform_Jump_C.__OnCompleted_CF946D5D4EFE5E5564EFF09B6249659C_NativeFunctionPtr, null);
		}

		// Token: 0x06029271 RID: 168561 RVA: 0x00A22B98 File Offset: 0x00A20D98
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_CF946D5D4EFE5E5564EFF09B8AB9B05C()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Platform_Jump_C.__OnTick_CF946D5D4EFE5E5564EFF09B8AB9B05C_NativeFunctionPtr, null);
		}

		// Token: 0x06029272 RID: 168562 RVA: 0x00A22BAC File Offset: 0x00A20DAC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCancelled_CF946D5D4EFE5E5564EFF09B8AB9B05C()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Platform_Jump_C.__OnCancelled_CF946D5D4EFE5E5564EFF09B8AB9B05C_NativeFunctionPtr, null);
		}

		// Token: 0x06029273 RID: 168563 RVA: 0x00A22BC0 File Offset: 0x00A20DC0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInterrupted_CF946D5D4EFE5E5564EFF09B8AB9B05C()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Platform_Jump_C.__OnInterrupted_CF946D5D4EFE5E5564EFF09B8AB9B05C_NativeFunctionPtr, null);
		}

		// Token: 0x06029274 RID: 168564 RVA: 0x00A22BD4 File Offset: 0x00A20DD4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBlendOut_CF946D5D4EFE5E5564EFF09B8AB9B05C()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Platform_Jump_C.__OnBlendOut_CF946D5D4EFE5E5564EFF09B8AB9B05C_NativeFunctionPtr, null);
		}

		// Token: 0x06029275 RID: 168565 RVA: 0x00A22BE8 File Offset: 0x00A20DE8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCompleted_CF946D5D4EFE5E5564EFF09B8AB9B05C()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Platform_Jump_C.__OnCompleted_CF946D5D4EFE5E5564EFF09B8AB9B05C_NativeFunctionPtr, null);
		}

		// Token: 0x06029276 RID: 168566 RVA: 0x00A22BFC File Offset: 0x00A20DFC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnFinish_9688557C424F8F0C8B36328604685B6B()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Platform_Jump_C.__OnFinish_9688557C424F8F0C8B36328604685B6B_NativeFunctionPtr, null);
		}

		// Token: 0x06029277 RID: 168567 RVA: 0x00A22C10 File Offset: 0x00A20E10
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_9688557C424F8F0C8B36328604685B6B()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Platform_Jump_C.__OnTick_9688557C424F8F0C8B36328604685B6B_NativeFunctionPtr, null);
		}

		// Token: 0x06029278 RID: 168568 RVA: 0x00A22C24 File Offset: 0x00A20E24
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnFinish_F9B3D327463A6F8C1B7239BE43C2B3D1()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Platform_Jump_C.__OnFinish_F9B3D327463A6F8C1B7239BE43C2B3D1_NativeFunctionPtr, null);
		}

		// Token: 0x06029279 RID: 168569 RVA: 0x00A22C38 File Offset: 0x00A20E38
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_F9B3D327463A6F8C1B7239BE43C2B3D1()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Platform_Jump_C.__OnTick_F9B3D327463A6F8C1B7239BE43C2B3D1_NativeFunctionPtr, null);
		}

		// Token: 0x0602927A RID: 168570 RVA: 0x00A22C4C File Offset: 0x00A20E4C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnFinish_91580C824CDF48A611FAD484BAC206DC()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Platform_Jump_C.__OnFinish_91580C824CDF48A611FAD484BAC206DC_NativeFunctionPtr, null);
		}

		// Token: 0x0602927B RID: 168571 RVA: 0x00A22C60 File Offset: 0x00A20E60
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Platform_Jump_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602927C RID: 168572 RVA: 0x00A22C74 File Offset: 0x00A20E74
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_Platform_Jump_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602927D RID: 168573 RVA: 0x00A22C8C File Offset: 0x00A20E8C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Motor_Platform_Jump_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Motor_Platform_Jump_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Motor_Platform_Jump_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Platform_Jump_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Platform_Jump_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602927E RID: 168574 RVA: 0x00A22CD4 File Offset: 0x00A20ED4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Motor_Platform_Jump_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Motor_Platform_Jump_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Motor_Platform_Jump_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Platform_Jump_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_Platform_Jump_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602927F RID: 168575 RVA: 0x00A22D1C File Offset: 0x00A20F1C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Motor_Platform_Jump(int EntryPoint)
		{
			GA_Motor_Platform_Jump_C.__ExecuteUbergraph_GA_Motor_Platform_Jump_FunctionParams* ptr = stackalloc GA_Motor_Platform_Jump_C.__ExecuteUbergraph_GA_Motor_Platform_Jump_FunctionParams[(UIntPtr)1311] + 15L / (long)sizeof(GA_Motor_Platform_Jump_C.__ExecuteUbergraph_GA_Motor_Platform_Jump_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Platform_Jump_C.__ExecuteUbergraph_GA_Motor_Platform_Jump_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_Platform_Jump_C.__ExecuteUbergraph_GA_Motor_Platform_Jump_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06029280 RID: 168576 RVA: 0x00A22D66 File Offset: 0x00A20F66
		protected GA_Motor_Platform_Jump_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04015D04 RID: 89348
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_Platform_Jump.GA_Motor_Platform_Jump_C";

		// Token: 0x04015D05 RID: 89349
		private static IntPtr _ClassPtr;

		// Token: 0x04015D06 RID: 89350
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04015D07 RID: 89351
		internal new static int __PropertyOffset_0;

		// Token: 0x04015D08 RID: 89352
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04015D09 RID: 89353
		internal new static int __PropertyOffset_1;

		// Token: 0x04015D0A RID: 89354
		internal new static int __PropertyOffset_2;

		// Token: 0x04015D0B RID: 89355
		internal new static int __PropertyOffset_3;

		// Token: 0x04015D0C RID: 89356
		internal static int __PropertyOffset_4;

		// Token: 0x04015D0D RID: 89357
		internal static int __PropertyOffset_5;

		// Token: 0x04015D0E RID: 89358
		internal static int __PropertyOffset_6;

		// Token: 0x04015D0F RID: 89359
		private static IntPtr __NewFunction_0_NativeFunctionPtr;

		// Token: 0x04015D10 RID: 89360
		private static IntPtr __OnTick_CF946D5D4EFE5E5564EFF09B6249659C_NativeFunctionPtr;

		// Token: 0x04015D11 RID: 89361
		private static IntPtr __OnCancelled_CF946D5D4EFE5E5564EFF09B6249659C_NativeFunctionPtr;

		// Token: 0x04015D12 RID: 89362
		private static IntPtr __OnInterrupted_CF946D5D4EFE5E5564EFF09B6249659C_NativeFunctionPtr;

		// Token: 0x04015D13 RID: 89363
		private static IntPtr __OnBlendOut_CF946D5D4EFE5E5564EFF09B6249659C_NativeFunctionPtr;

		// Token: 0x04015D14 RID: 89364
		private static IntPtr __OnCompleted_CF946D5D4EFE5E5564EFF09B6249659C_NativeFunctionPtr;

		// Token: 0x04015D15 RID: 89365
		private static IntPtr __OnTick_CF946D5D4EFE5E5564EFF09B8AB9B05C_NativeFunctionPtr;

		// Token: 0x04015D16 RID: 89366
		private static IntPtr __OnCancelled_CF946D5D4EFE5E5564EFF09B8AB9B05C_NativeFunctionPtr;

		// Token: 0x04015D17 RID: 89367
		private static IntPtr __OnInterrupted_CF946D5D4EFE5E5564EFF09B8AB9B05C_NativeFunctionPtr;

		// Token: 0x04015D18 RID: 89368
		private static IntPtr __OnBlendOut_CF946D5D4EFE5E5564EFF09B8AB9B05C_NativeFunctionPtr;

		// Token: 0x04015D19 RID: 89369
		private static IntPtr __OnCompleted_CF946D5D4EFE5E5564EFF09B8AB9B05C_NativeFunctionPtr;

		// Token: 0x04015D1A RID: 89370
		private static IntPtr __OnFinish_9688557C424F8F0C8B36328604685B6B_NativeFunctionPtr;

		// Token: 0x04015D1B RID: 89371
		private static IntPtr __OnTick_9688557C424F8F0C8B36328604685B6B_NativeFunctionPtr;

		// Token: 0x04015D1C RID: 89372
		private static IntPtr __OnFinish_F9B3D327463A6F8C1B7239BE43C2B3D1_NativeFunctionPtr;

		// Token: 0x04015D1D RID: 89373
		private static IntPtr __OnTick_F9B3D327463A6F8C1B7239BE43C2B3D1_NativeFunctionPtr;

		// Token: 0x04015D1E RID: 89374
		private static IntPtr __OnFinish_91580C824CDF48A611FAD484BAC206DC_NativeFunctionPtr;

		// Token: 0x04015D1F RID: 89375
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04015D20 RID: 89376
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x04015D21 RID: 89377
		private static IntPtr __ExecuteUbergraph_GA_Motor_Platform_Jump_NativeFunctionPtr;

		// Token: 0x0200A1E0 RID: 41440
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x04032F3D RID: 208701
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A1E1 RID: 41441
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1296)]
		protected ref struct __ExecuteUbergraph_GA_Motor_Platform_Jump_FunctionParams
		{
			// Token: 0x04032F3E RID: 208702
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
