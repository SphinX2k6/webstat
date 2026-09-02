using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Scene.NewGacha.BP
{
	// Token: 0x020039E0 RID: 14816
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class ResultWeaponGolden : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x0601E04A RID: 122954 RVA: 0x008E9BAE File Offset: 0x008E7DAE
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return ResultWeaponGolden.StaticFunctionPtr();
		}

		// Token: 0x0601E04B RID: 122955 RVA: 0x008E9BBA File Offset: 0x008E7DBA
		private static IntPtr StaticFunctionPtr()
		{
			if (BP_UpdateInteract_C.__ResultWeaponGolden__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				BP_UpdateInteract_C.__ResultWeaponGolden__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/Scene/NewGacha/BP/BP_UpdateInteract.BP_UpdateInteract_C:ResultWeaponGolden__DelegateSignature");
			}
			return BP_UpdateInteract_C.__ResultWeaponGolden__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x0601E04C RID: 122956 RVA: 0x008E9BDD File Offset: 0x008E7DDD
		public ResultWeaponGolden()
		{
		}

		// Token: 0x0601E04D RID: 122957 RVA: 0x008E9BE5 File Offset: 0x008E7DE5
		[NullableContext(2)]
		public ResultWeaponGolden(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0601E04E RID: 122958 RVA: 0x008E9BEF File Offset: 0x008E7DEF
		public ResultWeaponGolden(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0601E04F RID: 122959 RVA: 0x008E9BFA File Offset: 0x008E7DFA
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action) ?? ((Action)Delegate.CreateDelegate(typeof(Action), Callback.Target, Callback.Method)));
		}

		// Token: 0x0601E050 RID: 122960 RVA: 0x008E9C2C File Offset: 0x008E7E2C
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add(Action Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x0601E051 RID: 122961 RVA: 0x008E9C3B File Offset: 0x008E7E3B
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove(Action Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x0601E052 RID: 122962 RVA: 0x008E9C44 File Offset: 0x008E7E44
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Broadcast()
		{
			base.BroadcastInternal(null);
		}

		// Token: 0x0601E053 RID: 122963 RVA: 0x008E9C50 File Offset: 0x008E7E50
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveOptimization)]
		protected unsafe static void OnScriptCallback(IntPtr __Handle, byte* __Parameters)
		{
			object target = GCHandle.FromIntPtr(__Handle).Target;
			Action action = target as Action;
			if (action == null)
			{
				throw new ArgumentException((target != null) ? target.GetType().ToString() : null);
			}
			action();
		}

		// Token: 0x0400EB94 RID: 60308
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Scene/NewGacha/BP/BP_UpdateInteract.BP_UpdateInteract_C:ResultWeaponGolden__DelegateSignature";
	}
}
