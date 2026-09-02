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
	// Token: 0x02004088 RID: 16520
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_Hook_SwingingEnd.GA_Hook_SwingingEnd_C")]
	[UnrealStructLayout(1504, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1500)]
	public class GA_Hook_SwingingEnd_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AF7F RID: 175999 RVA: 0x00A6B958 File Offset: 0x00A69B58
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Hook_SwingingEnd_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Hook_SwingingEnd.GA_Hook_SwingingEnd_C");
			}
			return GA_Hook_SwingingEnd_C._ClassPtr;
		}

		// Token: 0x0602AF80 RID: 176000 RVA: 0x00A6B97C File Offset: 0x00A69B7C
		public GA_Hook_SwingingEnd_C() : this(BuiltinUtils.AllocNativeUObject(GA_Hook_SwingingEnd_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AF81 RID: 176001 RVA: 0x00A6B9A4 File Offset: 0x00A69BA4
		[NullableContext(1)]
		public GA_Hook_SwingingEnd_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Hook_SwingingEnd_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700705E RID: 28766
		// (get) Token: 0x0602AF82 RID: 176002 RVA: 0x00A6B9D8 File Offset: 0x00A69BD8
		// (set) Token: 0x0602AF83 RID: 176003 RVA: 0x00A6BA11 File Offset: 0x00A69C11
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Hook_SwingingEnd_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Hook_SwingingEnd_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700705F RID: 28767
		// (get) Token: 0x0602AF84 RID: 176004 RVA: 0x00A6BA32 File Offset: 0x00A69C32
		// (set) Token: 0x0602AF85 RID: 176005 RVA: 0x00A6BA46 File Offset: 0x00A69C46
		public unsafe FVector 摆荡基础速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Hook_SwingingEnd_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Hook_SwingingEnd_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x0602AF86 RID: 176006 RVA: 0x00A6BA5B File Offset: 0x00A69C5B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_5D118C384AE61F1C80292E8136286539()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Hook_SwingingEnd_C.__OnTick_5D118C384AE61F1C80292E8136286539_NativeFunctionPtr, null);
		}

		// Token: 0x0602AF87 RID: 176007 RVA: 0x00A6BA6F File Offset: 0x00A69C6F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCancelled_5D118C384AE61F1C80292E8136286539()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Hook_SwingingEnd_C.__OnCancelled_5D118C384AE61F1C80292E8136286539_NativeFunctionPtr, null);
		}

		// Token: 0x0602AF88 RID: 176008 RVA: 0x00A6BA83 File Offset: 0x00A69C83
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInterrupted_5D118C384AE61F1C80292E8136286539()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Hook_SwingingEnd_C.__OnInterrupted_5D118C384AE61F1C80292E8136286539_NativeFunctionPtr, null);
		}

		// Token: 0x0602AF89 RID: 176009 RVA: 0x00A6BA97 File Offset: 0x00A69C97
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBlendOut_5D118C384AE61F1C80292E8136286539()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Hook_SwingingEnd_C.__OnBlendOut_5D118C384AE61F1C80292E8136286539_NativeFunctionPtr, null);
		}

		// Token: 0x0602AF8A RID: 176010 RVA: 0x00A6BAAB File Offset: 0x00A69CAB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCompleted_5D118C384AE61F1C80292E8136286539()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Hook_SwingingEnd_C.__OnCompleted_5D118C384AE61F1C80292E8136286539_NativeFunctionPtr, null);
		}

		// Token: 0x0602AF8B RID: 176011 RVA: 0x00A6BAC0 File Offset: 0x00A69CC0
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void EventReceived_395B7D3941A9DA8F2A9D14B334F75D10(FGameplayEventData Payload)
		{
			GA_Hook_SwingingEnd_C.__EventReceived_395B7D3941A9DA8F2A9D14B334F75D10_FunctionParams* ptr = stackalloc GA_Hook_SwingingEnd_C.__EventReceived_395B7D3941A9DA8F2A9D14B334F75D10_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(GA_Hook_SwingingEnd_C.__EventReceived_395B7D3941A9DA8F2A9D14B334F75D10_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Hook_SwingingEnd_C.__EventReceived_395B7D3941A9DA8F2A9D14B334F75D10_NativeFunctionPtr, (void*)ptr, 1);
			if (Payload != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayEventData.StaticStruct(), &ptr->Payload, Payload.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Hook_SwingingEnd_C.__EventReceived_395B7D3941A9DA8F2A9D14B334F75D10_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(GA_Hook_SwingingEnd_C.__EventReceived_395B7D3941A9DA8F2A9D14B334F75D10_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602AF8C RID: 176012 RVA: 0x00A6BB38 File Offset: 0x00A69D38
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Added_54E5FB1C47764D94BD245DAB78EF78CB(in FGameplayTag Tag)
		{
			GA_Hook_SwingingEnd_C.__Added_54E5FB1C47764D94BD245DAB78EF78CB_FunctionParams* ptr = stackalloc GA_Hook_SwingingEnd_C.__Added_54E5FB1C47764D94BD245DAB78EF78CB_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_Hook_SwingingEnd_C.__Added_54E5FB1C47764D94BD245DAB78EF78CB_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Hook_SwingingEnd_C.__Added_54E5FB1C47764D94BD245DAB78EF78CB_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Hook_SwingingEnd_C.__Added_54E5FB1C47764D94BD245DAB78EF78CB_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602AF8D RID: 176013 RVA: 0x00A6BB84 File Offset: 0x00A69D84
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Hook_SwingingEnd_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Hook_SwingingEnd_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Hook_SwingingEnd_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Hook_SwingingEnd_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Hook_SwingingEnd_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602AF8E RID: 176014 RVA: 0x00A6BBCC File Offset: 0x00A69DCC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Hook_SwingingEnd_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Hook_SwingingEnd_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Hook_SwingingEnd_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Hook_SwingingEnd_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Hook_SwingingEnd_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602AF8F RID: 176015 RVA: 0x00A6BC13 File Offset: 0x00A69E13
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Hook_SwingingEnd_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602AF90 RID: 176016 RVA: 0x00A6BC27 File Offset: 0x00A69E27
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Hook_SwingingEnd_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602AF91 RID: 176017 RVA: 0x00A6BC3C File Offset: 0x00A69E3C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Hook_SwingingEnd(int EntryPoint)
		{
			GA_Hook_SwingingEnd_C.__ExecuteUbergraph_GA_Hook_SwingingEnd_FunctionParams* ptr = stackalloc GA_Hook_SwingingEnd_C.__ExecuteUbergraph_GA_Hook_SwingingEnd_FunctionParams[(UIntPtr)1519] + 15L / (long)sizeof(GA_Hook_SwingingEnd_C.__ExecuteUbergraph_GA_Hook_SwingingEnd_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Hook_SwingingEnd_C.__ExecuteUbergraph_GA_Hook_SwingingEnd_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Hook_SwingingEnd_C.__ExecuteUbergraph_GA_Hook_SwingingEnd_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602AF92 RID: 176018 RVA: 0x00A6BC86 File Offset: 0x00A69E86
		protected GA_Hook_SwingingEnd_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040177B2 RID: 96178
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Hook_SwingingEnd.GA_Hook_SwingingEnd_C";

		// Token: 0x040177B3 RID: 96179
		private static IntPtr _ClassPtr;

		// Token: 0x040177B4 RID: 96180
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040177B5 RID: 96181
		internal new static int __PropertyOffset_0;

		// Token: 0x040177B6 RID: 96182
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040177B7 RID: 96183
		internal new static int __PropertyOffset_1;

		// Token: 0x040177B8 RID: 96184
		private static IntPtr __OnTick_5D118C384AE61F1C80292E8136286539_NativeFunctionPtr;

		// Token: 0x040177B9 RID: 96185
		private static IntPtr __OnCancelled_5D118C384AE61F1C80292E8136286539_NativeFunctionPtr;

		// Token: 0x040177BA RID: 96186
		private static IntPtr __OnInterrupted_5D118C384AE61F1C80292E8136286539_NativeFunctionPtr;

		// Token: 0x040177BB RID: 96187
		private static IntPtr __OnBlendOut_5D118C384AE61F1C80292E8136286539_NativeFunctionPtr;

		// Token: 0x040177BC RID: 96188
		private static IntPtr __OnCompleted_5D118C384AE61F1C80292E8136286539_NativeFunctionPtr;

		// Token: 0x040177BD RID: 96189
		private static IntPtr __EventReceived_395B7D3941A9DA8F2A9D14B334F75D10_NativeFunctionPtr;

		// Token: 0x040177BE RID: 96190
		private static IntPtr __Added_54E5FB1C47764D94BD245DAB78EF78CB_NativeFunctionPtr;

		// Token: 0x040177BF RID: 96191
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x040177C0 RID: 96192
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x040177C1 RID: 96193
		private static IntPtr __ExecuteUbergraph_GA_Hook_SwingingEnd_NativeFunctionPtr;

		// Token: 0x0200A2A7 RID: 41639
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __EventReceived_395B7D3941A9DA8F2A9D14B334F75D10_FunctionParams
		{
			// Token: 0x0403305A RID: 208986
			[FieldOffset(0)]
			public byte Payload;
		}

		// Token: 0x0200A2A8 RID: 41640
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Added_54E5FB1C47764D94BD245DAB78EF78CB_FunctionParams
		{
			// Token: 0x0403305B RID: 208987
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A2A9 RID: 41641
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x0403305C RID: 208988
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A2AA RID: 41642
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1504)]
		protected ref struct __ExecuteUbergraph_GA_Hook_SwingingEnd_FunctionParams
		{
			// Token: 0x0403305D RID: 208989
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
