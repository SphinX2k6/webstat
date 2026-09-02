using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Scene.NewGacha.BP
{
	// Token: 0x020039D5 RID: 14805
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class ResultJianxin : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x0601DFDC RID: 122844 RVA: 0x008E91AA File Offset: 0x008E73AA
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return ResultJianxin.StaticFunctionPtr();
		}

		// Token: 0x0601DFDD RID: 122845 RVA: 0x008E91B6 File Offset: 0x008E73B6
		private static IntPtr StaticFunctionPtr()
		{
			if (BP_UpdateInteract_C.__ResultJianxin__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				BP_UpdateInteract_C.__ResultJianxin__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/Scene/NewGacha/BP/BP_UpdateInteract.BP_UpdateInteract_C:ResultJianxin__DelegateSignature");
			}
			return BP_UpdateInteract_C.__ResultJianxin__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x0601DFDE RID: 122846 RVA: 0x008E91D9 File Offset: 0x008E73D9
		public ResultJianxin()
		{
		}

		// Token: 0x0601DFDF RID: 122847 RVA: 0x008E91E1 File Offset: 0x008E73E1
		[NullableContext(2)]
		public ResultJianxin(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0601DFE0 RID: 122848 RVA: 0x008E91EB File Offset: 0x008E73EB
		public ResultJianxin(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0601DFE1 RID: 122849 RVA: 0x008E91F6 File Offset: 0x008E73F6
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action) ?? ((Action)Delegate.CreateDelegate(typeof(Action), Callback.Target, Callback.Method)));
		}

		// Token: 0x0601DFE2 RID: 122850 RVA: 0x008E9228 File Offset: 0x008E7428
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add(Action Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x0601DFE3 RID: 122851 RVA: 0x008E9237 File Offset: 0x008E7437
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove(Action Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x0601DFE4 RID: 122852 RVA: 0x008E9240 File Offset: 0x008E7440
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Broadcast()
		{
			base.BroadcastInternal(null);
		}

		// Token: 0x0601DFE5 RID: 122853 RVA: 0x008E924C File Offset: 0x008E744C
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

		// Token: 0x0400EB89 RID: 60297
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Scene/NewGacha/BP/BP_UpdateInteract.BP_UpdateInteract_C:ResultJianxin__DelegateSignature";
	}
}
