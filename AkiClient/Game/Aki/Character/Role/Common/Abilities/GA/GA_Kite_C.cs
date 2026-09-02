using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GA;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Abilities.GA
{
	// Token: 0x02004098 RID: 16536
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_Kite.GA_Kite_C")]
	[UnrealStructLayout(1488, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1488)]
	public class GA_Kite_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602B082 RID: 176258 RVA: 0x00A6DF94 File Offset: 0x00A6C194
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Kite_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Kite.GA_Kite_C");
			}
			return GA_Kite_C._ClassPtr;
		}

		// Token: 0x0602B083 RID: 176259 RVA: 0x00A6DFB8 File Offset: 0x00A6C1B8
		public GA_Kite_C() : this(BuiltinUtils.AllocNativeUObject(GA_Kite_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602B084 RID: 176260 RVA: 0x00A6DFE0 File Offset: 0x00A6C1E0
		[NullableContext(1)]
		public GA_Kite_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Kite_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700707D RID: 28797
		// (get) Token: 0x0602B085 RID: 176261 RVA: 0x00A6E014 File Offset: 0x00A6C214
		// (set) Token: 0x0602B086 RID: 176262 RVA: 0x00A6E04D File Offset: 0x00A6C24D
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Kite_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Kite_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x0602B087 RID: 176263 RVA: 0x00A6E06E File Offset: 0x00A6C26E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SummorMotorcycle()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Kite_C.__SummorMotorcycle_NativeFunctionPtr, null);
		}

		// Token: 0x0602B088 RID: 176264 RVA: 0x00A6E082 File Offset: 0x00A6C282
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void KiteStart()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Kite_C.__KiteStart_NativeFunctionPtr, null);
		}

		// Token: 0x0602B089 RID: 176265 RVA: 0x00A6E096 File Offset: 0x00A6C296
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void KiteTick()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Kite_C.__KiteTick_NativeFunctionPtr, null);
		}

		// Token: 0x0602B08A RID: 176266 RVA: 0x00A6E0AC File Offset: 0x00A6C2AC
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void EventReceived_18B59F5945020DB23C42FD88CC3A85AA(FGameplayEventData Payload)
		{
			GA_Kite_C.__EventReceived_18B59F5945020DB23C42FD88CC3A85AA_FunctionParams* ptr = stackalloc GA_Kite_C.__EventReceived_18B59F5945020DB23C42FD88CC3A85AA_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(GA_Kite_C.__EventReceived_18B59F5945020DB23C42FD88CC3A85AA_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Kite_C.__EventReceived_18B59F5945020DB23C42FD88CC3A85AA_NativeFunctionPtr, (void*)ptr, 1);
			if (Payload != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayEventData.StaticStruct(), &ptr->Payload, Payload.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Kite_C.__EventReceived_18B59F5945020DB23C42FD88CC3A85AA_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(GA_Kite_C.__EventReceived_18B59F5945020DB23C42FD88CC3A85AA_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602B08B RID: 176267 RVA: 0x00A6E124 File Offset: 0x00A6C324
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void EventReceived_18B59F5945020DB23C42FD882073BC78(FGameplayEventData Payload)
		{
			GA_Kite_C.__EventReceived_18B59F5945020DB23C42FD882073BC78_FunctionParams* ptr = stackalloc GA_Kite_C.__EventReceived_18B59F5945020DB23C42FD882073BC78_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(GA_Kite_C.__EventReceived_18B59F5945020DB23C42FD882073BC78_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Kite_C.__EventReceived_18B59F5945020DB23C42FD882073BC78_NativeFunctionPtr, (void*)ptr, 1);
			if (Payload != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayEventData.StaticStruct(), &ptr->Payload, Payload.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Kite_C.__EventReceived_18B59F5945020DB23C42FD882073BC78_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(GA_Kite_C.__EventReceived_18B59F5945020DB23C42FD882073BC78_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602B08C RID: 176268 RVA: 0x00A6E199 File Offset: 0x00A6C399
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Kite_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602B08D RID: 176269 RVA: 0x00A6E1AD File Offset: 0x00A6C3AD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Kite_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602B08E RID: 176270 RVA: 0x00A6E1C4 File Offset: 0x00A6C3C4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Kite_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Kite_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Kite_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Kite_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Kite_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B08F RID: 176271 RVA: 0x00A6E20C File Offset: 0x00A6C40C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Kite_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Kite_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Kite_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Kite_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Kite_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B090 RID: 176272 RVA: 0x00A6E254 File Offset: 0x00A6C454
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnMovementModeChanged(ACharacter Character, EMovementMode PrevMovementMode, byte PreviousCustomMode)
		{
			GA_Kite_C.__OnMovementModeChanged_FunctionParams* ptr = stackalloc GA_Kite_C.__OnMovementModeChanged_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(GA_Kite_C.__OnMovementModeChanged_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Kite_C.__OnMovementModeChanged_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Character = ((Character != null) ? Character.NativePtr : IntPtr.Zero);
			ptr->PrevMovementMode = PrevMovementMode;
			ptr->PreviousCustomMode = PreviousCustomMode;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Kite_C.__OnMovementModeChanged_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B091 RID: 176273 RVA: 0x00A6E2BC File Offset: 0x00A6C4BC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Kite(int EntryPoint)
		{
			GA_Kite_C.__ExecuteUbergraph_GA_Kite_FunctionParams* ptr = stackalloc GA_Kite_C.__ExecuteUbergraph_GA_Kite_FunctionParams[(UIntPtr)1111] + 15L / (long)sizeof(GA_Kite_C.__ExecuteUbergraph_GA_Kite_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Kite_C.__ExecuteUbergraph_GA_Kite_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Kite_C.__ExecuteUbergraph_GA_Kite_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B092 RID: 176274 RVA: 0x00A6E306 File Offset: 0x00A6C506
		protected GA_Kite_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401787C RID: 96380
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Kite.GA_Kite_C";

		// Token: 0x0401787D RID: 96381
		private static IntPtr _ClassPtr;

		// Token: 0x0401787E RID: 96382
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401787F RID: 96383
		internal new static int __PropertyOffset_0;

		// Token: 0x04017880 RID: 96384
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04017881 RID: 96385
		private static IntPtr __SummorMotorcycle_NativeFunctionPtr;

		// Token: 0x04017882 RID: 96386
		private static IntPtr __KiteStart_NativeFunctionPtr;

		// Token: 0x04017883 RID: 96387
		private static IntPtr __KiteTick_NativeFunctionPtr;

		// Token: 0x04017884 RID: 96388
		private static IntPtr __EventReceived_18B59F5945020DB23C42FD88CC3A85AA_NativeFunctionPtr;

		// Token: 0x04017885 RID: 96389
		private static IntPtr __EventReceived_18B59F5945020DB23C42FD882073BC78_NativeFunctionPtr;

		// Token: 0x04017886 RID: 96390
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04017887 RID: 96391
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x04017888 RID: 96392
		private static IntPtr __OnMovementModeChanged_NativeFunctionPtr;

		// Token: 0x04017889 RID: 96393
		private static IntPtr __ExecuteUbergraph_GA_Kite_NativeFunctionPtr;

		// Token: 0x0200A2CB RID: 41675
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __EventReceived_18B59F5945020DB23C42FD88CC3A85AA_FunctionParams
		{
			// Token: 0x04033087 RID: 209031
			[FieldOffset(0)]
			public byte Payload;
		}

		// Token: 0x0200A2CC RID: 41676
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __EventReceived_18B59F5945020DB23C42FD882073BC78_FunctionParams
		{
			// Token: 0x04033088 RID: 209032
			[FieldOffset(0)]
			public byte Payload;
		}

		// Token: 0x0200A2CD RID: 41677
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x04033089 RID: 209033
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A2CE RID: 41678
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __OnMovementModeChanged_FunctionParams
		{
			// Token: 0x0403308A RID: 209034
			[FieldOffset(0)]
			public IntPtr Character;

			// Token: 0x0403308B RID: 209035
			[FieldOffset(8)]
			public TEnumAsByte<EMovementMode> PrevMovementMode;

			// Token: 0x0403308C RID: 209036
			[FieldOffset(9)]
			public byte PreviousCustomMode;
		}

		// Token: 0x0200A2CF RID: 41679
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1096)]
		protected ref struct __ExecuteUbergraph_GA_Kite_FunctionParams
		{
			// Token: 0x0403308D RID: 209037
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
