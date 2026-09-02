using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Scene.NewGacha.BP
{
	// Token: 0x020039D1 RID: 14801
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class ResultChangli : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x0601DFB4 RID: 122804 RVA: 0x008E8E1A File Offset: 0x008E701A
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return ResultChangli.StaticFunctionPtr();
		}

		// Token: 0x0601DFB5 RID: 122805 RVA: 0x008E8E26 File Offset: 0x008E7026
		private static IntPtr StaticFunctionPtr()
		{
			if (BP_UpdateInteract_C.__ResultChangli__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				BP_UpdateInteract_C.__ResultChangli__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/Scene/NewGacha/BP/BP_UpdateInteract.BP_UpdateInteract_C:ResultChangli__DelegateSignature");
			}
			return BP_UpdateInteract_C.__ResultChangli__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x0601DFB6 RID: 122806 RVA: 0x008E8E49 File Offset: 0x008E7049
		public ResultChangli()
		{
		}

		// Token: 0x0601DFB7 RID: 122807 RVA: 0x008E8E51 File Offset: 0x008E7051
		[NullableContext(2)]
		public ResultChangli(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0601DFB8 RID: 122808 RVA: 0x008E8E5B File Offset: 0x008E705B
		public ResultChangli(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0601DFB9 RID: 122809 RVA: 0x008E8E66 File Offset: 0x008E7066
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action) ?? ((Action)Delegate.CreateDelegate(typeof(Action), Callback.Target, Callback.Method)));
		}

		// Token: 0x0601DFBA RID: 122810 RVA: 0x008E8E98 File Offset: 0x008E7098
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add(Action Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x0601DFBB RID: 122811 RVA: 0x008E8EA7 File Offset: 0x008E70A7
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove(Action Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x0601DFBC RID: 122812 RVA: 0x008E8EB0 File Offset: 0x008E70B0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Broadcast()
		{
			base.BroadcastInternal(null);
		}

		// Token: 0x0601DFBD RID: 122813 RVA: 0x008E8EBC File Offset: 0x008E70BC
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

		// Token: 0x0400EB85 RID: 60293
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Scene/NewGacha/BP/BP_UpdateInteract.BP_UpdateInteract_C:ResultChangli__DelegateSignature";
	}
}
