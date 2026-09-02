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
	// Token: 0x02004099 RID: 16537
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_Luokeke_Peiluo.GA_Luokeke_Peiluo_C")]
	[UnrealStructLayout(1488, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1488)]
	public class GA_Luokeke_Peiluo_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602B093 RID: 176275 RVA: 0x00A6E30F File Offset: 0x00A6C50F
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Luokeke_Peiluo_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Luokeke_Peiluo.GA_Luokeke_Peiluo_C");
			}
			return GA_Luokeke_Peiluo_C._ClassPtr;
		}

		// Token: 0x0602B094 RID: 176276 RVA: 0x00A6E334 File Offset: 0x00A6C534
		public GA_Luokeke_Peiluo_C() : this(BuiltinUtils.AllocNativeUObject(GA_Luokeke_Peiluo_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602B095 RID: 176277 RVA: 0x00A6E35C File Offset: 0x00A6C55C
		[NullableContext(1)]
		public GA_Luokeke_Peiluo_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Luokeke_Peiluo_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700707E RID: 28798
		// (get) Token: 0x0602B096 RID: 176278 RVA: 0x00A6E390 File Offset: 0x00A6C590
		// (set) Token: 0x0602B097 RID: 176279 RVA: 0x00A6E3C9 File Offset: 0x00A6C5C9
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Luokeke_Peiluo_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Luokeke_Peiluo_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x0602B098 RID: 176280 RVA: 0x00A6E3EA File Offset: 0x00A6C5EA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnFinish_602D72ED446DF1A10F6F5184005CF56D()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Luokeke_Peiluo_C.__OnFinish_602D72ED446DF1A10F6F5184005CF56D_NativeFunctionPtr, null);
		}

		// Token: 0x0602B099 RID: 176281 RVA: 0x00A6E3FE File Offset: 0x00A6C5FE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Luokeke_Peiluo_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602B09A RID: 176282 RVA: 0x00A6E412 File Offset: 0x00A6C612
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Luokeke_Peiluo_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602B09B RID: 176283 RVA: 0x00A6E428 File Offset: 0x00A6C628
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Luokeke_Peiluo_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Luokeke_Peiluo_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Luokeke_Peiluo_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Luokeke_Peiluo_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Luokeke_Peiluo_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B09C RID: 176284 RVA: 0x00A6E470 File Offset: 0x00A6C670
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Luokeke_Peiluo_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Luokeke_Peiluo_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Luokeke_Peiluo_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Luokeke_Peiluo_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Luokeke_Peiluo_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B09D RID: 176285 RVA: 0x00A6E4B8 File Offset: 0x00A6C6B8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Luokeke_Peiluo(int EntryPoint)
		{
			GA_Luokeke_Peiluo_C.__ExecuteUbergraph_GA_Luokeke_Peiluo_FunctionParams* ptr = stackalloc GA_Luokeke_Peiluo_C.__ExecuteUbergraph_GA_Luokeke_Peiluo_FunctionParams[(UIntPtr)127] + 15L / (long)sizeof(GA_Luokeke_Peiluo_C.__ExecuteUbergraph_GA_Luokeke_Peiluo_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Luokeke_Peiluo_C.__ExecuteUbergraph_GA_Luokeke_Peiluo_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Luokeke_Peiluo_C.__ExecuteUbergraph_GA_Luokeke_Peiluo_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B09E RID: 176286 RVA: 0x00A6E4FF File Offset: 0x00A6C6FF
		protected GA_Luokeke_Peiluo_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401788A RID: 96394
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Luokeke_Peiluo.GA_Luokeke_Peiluo_C";

		// Token: 0x0401788B RID: 96395
		private static IntPtr _ClassPtr;

		// Token: 0x0401788C RID: 96396
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401788D RID: 96397
		internal new static int __PropertyOffset_0;

		// Token: 0x0401788E RID: 96398
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0401788F RID: 96399
		private static IntPtr __OnFinish_602D72ED446DF1A10F6F5184005CF56D_NativeFunctionPtr;

		// Token: 0x04017890 RID: 96400
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04017891 RID: 96401
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x04017892 RID: 96402
		private static IntPtr __ExecuteUbergraph_GA_Luokeke_Peiluo_NativeFunctionPtr;

		// Token: 0x0200A2D0 RID: 41680
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x0403308E RID: 209038
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A2D1 RID: 41681
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 112)]
		protected ref struct __ExecuteUbergraph_GA_Luokeke_Peiluo_FunctionParams
		{
			// Token: 0x0403308F RID: 209039
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
