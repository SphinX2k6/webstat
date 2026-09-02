using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Scene.NewGacha.BP
{
	// Token: 0x020039E3 RID: 14819
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class ResultYangyang : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x0601E068 RID: 122984 RVA: 0x008E9E5A File Offset: 0x008E805A
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return ResultYangyang.StaticFunctionPtr();
		}

		// Token: 0x0601E069 RID: 122985 RVA: 0x008E9E66 File Offset: 0x008E8066
		private static IntPtr StaticFunctionPtr()
		{
			if (BP_UpdateInteract_C.__ResultYangyang__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				BP_UpdateInteract_C.__ResultYangyang__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/Scene/NewGacha/BP/BP_UpdateInteract.BP_UpdateInteract_C:ResultYangyang__DelegateSignature");
			}
			return BP_UpdateInteract_C.__ResultYangyang__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x0601E06A RID: 122986 RVA: 0x008E9E89 File Offset: 0x008E8089
		public ResultYangyang()
		{
		}

		// Token: 0x0601E06B RID: 122987 RVA: 0x008E9E91 File Offset: 0x008E8091
		[NullableContext(2)]
		public ResultYangyang(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0601E06C RID: 122988 RVA: 0x008E9E9B File Offset: 0x008E809B
		public ResultYangyang(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0601E06D RID: 122989 RVA: 0x008E9EA6 File Offset: 0x008E80A6
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action) ?? ((Action)Delegate.CreateDelegate(typeof(Action), Callback.Target, Callback.Method)));
		}

		// Token: 0x0601E06E RID: 122990 RVA: 0x008E9ED8 File Offset: 0x008E80D8
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add(Action Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x0601E06F RID: 122991 RVA: 0x008E9EE7 File Offset: 0x008E80E7
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove(Action Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x0601E070 RID: 122992 RVA: 0x008E9EF0 File Offset: 0x008E80F0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Broadcast()
		{
			base.BroadcastInternal(null);
		}

		// Token: 0x0601E071 RID: 122993 RVA: 0x008E9EFC File Offset: 0x008E80FC
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

		// Token: 0x0400EB97 RID: 60311
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Scene/NewGacha/BP/BP_UpdateInteract.BP_UpdateInteract_C:ResultYangyang__DelegateSignature";
	}
}
