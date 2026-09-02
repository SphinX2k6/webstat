using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GA;
using AkiClient.Game.Aki.Character.Item;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Abilities.GA
{
	// Token: 0x020040CF RID: 16591
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_Sword_TotalAttack.GA_Sword_TotalAttack_C")]
	[UnrealStructLayout(1568, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1568)]
	public class GA_Sword_TotalAttack_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602B644 RID: 177732 RVA: 0x00A7A84F File Offset: 0x00A78A4F
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Sword_TotalAttack_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Sword_TotalAttack.GA_Sword_TotalAttack_C");
			}
			return GA_Sword_TotalAttack_C._ClassPtr;
		}

		// Token: 0x0602B645 RID: 177733 RVA: 0x00A7A874 File Offset: 0x00A78A74
		public GA_Sword_TotalAttack_C() : this(BuiltinUtils.AllocNativeUObject(GA_Sword_TotalAttack_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602B646 RID: 177734 RVA: 0x00A7A89C File Offset: 0x00A78A9C
		public GA_Sword_TotalAttack_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Sword_TotalAttack_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170071A7 RID: 29095
		// (get) Token: 0x0602B647 RID: 177735 RVA: 0x00A7A8D0 File Offset: 0x00A78AD0
		// (set) Token: 0x0602B648 RID: 177736 RVA: 0x00A7A909 File Offset: 0x00A78B09
		public new FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Sword_TotalAttack_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Sword_TotalAttack_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170071A8 RID: 29096
		// (get) Token: 0x0602B649 RID: 177737 RVA: 0x00A7A92C File Offset: 0x00A78B2C
		// (set) Token: 0x0602B64A RID: 177738 RVA: 0x00A7A965 File Offset: 0x00A78B65
		public TArray<BP_BaseItem_C> 目标列表
		{
			get
			{
				base.FastCheckIsValid();
				TArray<BP_BaseItem_C> result;
				if ((result = this._目标列表) == null)
				{
					result = (this._目标列表 = new TArray<BP_BaseItem_C>(base.NativePtr + (IntPtr)GA_Sword_TotalAttack_C.__PropertyOffset_1, this));
				}
				return result;
			}
			set
			{
				this.目标列表.CopyAssign(value);
			}
		}

		// Token: 0x170071A9 RID: 29097
		// (get) Token: 0x0602B64B RID: 177739 RVA: 0x00A7A973 File Offset: 0x00A78B73
		// (set) Token: 0x0602B64C RID: 177740 RVA: 0x00A7A987 File Offset: 0x00A78B87
		public unsafe FVectorDouble 玩家摄像机朝向
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Sword_TotalAttack_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Sword_TotalAttack_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x170071AA RID: 29098
		// (get) Token: 0x0602B64D RID: 177741 RVA: 0x00A7A99C File Offset: 0x00A78B9C
		// (set) Token: 0x0602B64E RID: 177742 RVA: 0x00A7A9B0 File Offset: 0x00A78BB0
		public unsafe FVectorDouble 目标朝向点
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Sword_TotalAttack_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Sword_TotalAttack_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x170071AB RID: 29099
		// (get) Token: 0x0602B64F RID: 177743 RVA: 0x00A7A9C8 File Offset: 0x00A78BC8
		// (set) Token: 0x0602B650 RID: 177744 RVA: 0x00A7AA01 File Offset: 0x00A78C01
		public TArray<FVectorDouble> 目标位置列表
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FVectorDouble> result;
				if ((result = this._目标位置列表) == null)
				{
					result = (this._目标位置列表 = new TArray<FVectorDouble>(base.NativePtr + (IntPtr)GA_Sword_TotalAttack_C.__PropertyOffset_4, this));
				}
				return result;
			}
			set
			{
				this.目标位置列表.CopyAssign(value);
			}
		}

		// Token: 0x0602B651 RID: 177745 RVA: 0x00A7AA0F File Offset: 0x00A78C0F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 设置朝向黑板值()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Sword_TotalAttack_C.__设置朝向黑板值_NativeFunctionPtr, null);
		}

		// Token: 0x0602B652 RID: 177746 RVA: 0x00A7AA24 File Offset: 0x00A78C24
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void EventReceived_18B59F5945020DB23C42FD88DCBF967C(FGameplayEventData Payload)
		{
			GA_Sword_TotalAttack_C.__EventReceived_18B59F5945020DB23C42FD88DCBF967C_FunctionParams* ptr = stackalloc GA_Sword_TotalAttack_C.__EventReceived_18B59F5945020DB23C42FD88DCBF967C_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(GA_Sword_TotalAttack_C.__EventReceived_18B59F5945020DB23C42FD88DCBF967C_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Sword_TotalAttack_C.__EventReceived_18B59F5945020DB23C42FD88DCBF967C_NativeFunctionPtr, (void*)ptr, 1);
			if (Payload != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayEventData.StaticStruct(), &ptr->Payload, Payload.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Sword_TotalAttack_C.__EventReceived_18B59F5945020DB23C42FD88DCBF967C_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(GA_Sword_TotalAttack_C.__EventReceived_18B59F5945020DB23C42FD88DCBF967C_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602B653 RID: 177747 RVA: 0x00A7AA99 File Offset: 0x00A78C99
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_5D118C384AE61F1C80292E813CBC8B4D()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Sword_TotalAttack_C.__OnTick_5D118C384AE61F1C80292E813CBC8B4D_NativeFunctionPtr, null);
		}

		// Token: 0x0602B654 RID: 177748 RVA: 0x00A7AAAD File Offset: 0x00A78CAD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCancelled_5D118C384AE61F1C80292E813CBC8B4D()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Sword_TotalAttack_C.__OnCancelled_5D118C384AE61F1C80292E813CBC8B4D_NativeFunctionPtr, null);
		}

		// Token: 0x0602B655 RID: 177749 RVA: 0x00A7AAC1 File Offset: 0x00A78CC1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInterrupted_5D118C384AE61F1C80292E813CBC8B4D()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Sword_TotalAttack_C.__OnInterrupted_5D118C384AE61F1C80292E813CBC8B4D_NativeFunctionPtr, null);
		}

		// Token: 0x0602B656 RID: 177750 RVA: 0x00A7AAD5 File Offset: 0x00A78CD5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBlendOut_5D118C384AE61F1C80292E813CBC8B4D()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Sword_TotalAttack_C.__OnBlendOut_5D118C384AE61F1C80292E813CBC8B4D_NativeFunctionPtr, null);
		}

		// Token: 0x0602B657 RID: 177751 RVA: 0x00A7AAE9 File Offset: 0x00A78CE9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCompleted_5D118C384AE61F1C80292E813CBC8B4D()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Sword_TotalAttack_C.__OnCompleted_5D118C384AE61F1C80292E813CBC8B4D_NativeFunctionPtr, null);
		}

		// Token: 0x0602B658 RID: 177752 RVA: 0x00A7AAFD File Offset: 0x00A78CFD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Sword_TotalAttack_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602B659 RID: 177753 RVA: 0x00A7AB11 File Offset: 0x00A78D11
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Sword_TotalAttack_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602B65A RID: 177754 RVA: 0x00A7AB28 File Offset: 0x00A78D28
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Sword_TotalAttack_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Sword_TotalAttack_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Sword_TotalAttack_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Sword_TotalAttack_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Sword_TotalAttack_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B65B RID: 177755 RVA: 0x00A7AB70 File Offset: 0x00A78D70
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Sword_TotalAttack_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Sword_TotalAttack_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Sword_TotalAttack_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Sword_TotalAttack_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Sword_TotalAttack_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B65C RID: 177756 RVA: 0x00A7ABB8 File Offset: 0x00A78DB8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Sword_TotalAttack(int EntryPoint)
		{
			GA_Sword_TotalAttack_C.__ExecuteUbergraph_GA_Sword_TotalAttack_FunctionParams* ptr = stackalloc GA_Sword_TotalAttack_C.__ExecuteUbergraph_GA_Sword_TotalAttack_FunctionParams[(UIntPtr)1655] + 15L / (long)sizeof(GA_Sword_TotalAttack_C.__ExecuteUbergraph_GA_Sword_TotalAttack_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Sword_TotalAttack_C.__ExecuteUbergraph_GA_Sword_TotalAttack_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Sword_TotalAttack_C.__ExecuteUbergraph_GA_Sword_TotalAttack_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B65D RID: 177757 RVA: 0x00A7AC02 File Offset: 0x00A78E02
		protected GA_Sword_TotalAttack_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017CBA RID: 97466
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Sword_TotalAttack.GA_Sword_TotalAttack_C";

		// Token: 0x04017CBB RID: 97467
		private static IntPtr _ClassPtr;

		// Token: 0x04017CBC RID: 97468
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04017CBD RID: 97469
		internal new static int __PropertyOffset_0;

		// Token: 0x04017CBE RID: 97470
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04017CBF RID: 97471
		internal new static int __PropertyOffset_1;

		// Token: 0x04017CC0 RID: 97472
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<BP_BaseItem_C> _目标列表;

		// Token: 0x04017CC1 RID: 97473
		internal new static int __PropertyOffset_2;

		// Token: 0x04017CC2 RID: 97474
		internal new static int __PropertyOffset_3;

		// Token: 0x04017CC3 RID: 97475
		internal static int __PropertyOffset_4;

		// Token: 0x04017CC4 RID: 97476
		[Nullable(2)]
		private TArray<FVectorDouble> _目标位置列表;

		// Token: 0x04017CC5 RID: 97477
		private static IntPtr __设置朝向黑板值_NativeFunctionPtr;

		// Token: 0x04017CC6 RID: 97478
		private static IntPtr __EventReceived_18B59F5945020DB23C42FD88DCBF967C_NativeFunctionPtr;

		// Token: 0x04017CC7 RID: 97479
		private static IntPtr __OnTick_5D118C384AE61F1C80292E813CBC8B4D_NativeFunctionPtr;

		// Token: 0x04017CC8 RID: 97480
		private static IntPtr __OnCancelled_5D118C384AE61F1C80292E813CBC8B4D_NativeFunctionPtr;

		// Token: 0x04017CC9 RID: 97481
		private static IntPtr __OnInterrupted_5D118C384AE61F1C80292E813CBC8B4D_NativeFunctionPtr;

		// Token: 0x04017CCA RID: 97482
		private static IntPtr __OnBlendOut_5D118C384AE61F1C80292E813CBC8B4D_NativeFunctionPtr;

		// Token: 0x04017CCB RID: 97483
		private static IntPtr __OnCompleted_5D118C384AE61F1C80292E813CBC8B4D_NativeFunctionPtr;

		// Token: 0x04017CCC RID: 97484
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04017CCD RID: 97485
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x04017CCE RID: 97486
		private static IntPtr __ExecuteUbergraph_GA_Sword_TotalAttack_NativeFunctionPtr;

		// Token: 0x0200A3A1 RID: 41889
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __EventReceived_18B59F5945020DB23C42FD88DCBF967C_FunctionParams
		{
			// Token: 0x0403317E RID: 209278
			[FieldOffset(0)]
			public byte Payload;
		}

		// Token: 0x0200A3A2 RID: 41890
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x0403317F RID: 209279
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A3A3 RID: 41891
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1640)]
		protected ref struct __ExecuteUbergraph_GA_Sword_TotalAttack_FunctionParams
		{
			// Token: 0x04033180 RID: 209280
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
