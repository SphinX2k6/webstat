using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Scene.NewGacha.BP
{
	// Token: 0x020039D0 RID: 14800
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class ResultBailian : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x0601DFAA RID: 122794 RVA: 0x008E8D36 File Offset: 0x008E6F36
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return ResultBailian.StaticFunctionPtr();
		}

		// Token: 0x0601DFAB RID: 122795 RVA: 0x008E8D42 File Offset: 0x008E6F42
		private static IntPtr StaticFunctionPtr()
		{
			if (BP_UpdateInteract_C.__ResultBailian__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				BP_UpdateInteract_C.__ResultBailian__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/Scene/NewGacha/BP/BP_UpdateInteract.BP_UpdateInteract_C:ResultBailian__DelegateSignature");
			}
			return BP_UpdateInteract_C.__ResultBailian__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x0601DFAC RID: 122796 RVA: 0x008E8D65 File Offset: 0x008E6F65
		public ResultBailian()
		{
		}

		// Token: 0x0601DFAD RID: 122797 RVA: 0x008E8D6D File Offset: 0x008E6F6D
		[NullableContext(2)]
		public ResultBailian(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0601DFAE RID: 122798 RVA: 0x008E8D77 File Offset: 0x008E6F77
		public ResultBailian(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0601DFAF RID: 122799 RVA: 0x008E8D82 File Offset: 0x008E6F82
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action) ?? ((Action)Delegate.CreateDelegate(typeof(Action), Callback.Target, Callback.Method)));
		}

		// Token: 0x0601DFB0 RID: 122800 RVA: 0x008E8DB4 File Offset: 0x008E6FB4
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add(Action Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x0601DFB1 RID: 122801 RVA: 0x008E8DC3 File Offset: 0x008E6FC3
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove(Action Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x0601DFB2 RID: 122802 RVA: 0x008E8DCC File Offset: 0x008E6FCC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Broadcast()
		{
			base.BroadcastInternal(null);
		}

		// Token: 0x0601DFB3 RID: 122803 RVA: 0x008E8DD8 File Offset: 0x008E6FD8
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

		// Token: 0x0400EB84 RID: 60292
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Scene/NewGacha/BP/BP_UpdateInteract.BP_UpdateInteract_C:ResultBailian__DelegateSignature";
	}
}
