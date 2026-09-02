using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Scene.NewGacha.BP
{
	// Token: 0x020039D4 RID: 14804
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class ResultChun : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x0601DFD2 RID: 122834 RVA: 0x008E90C6 File Offset: 0x008E72C6
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return ResultChun.StaticFunctionPtr();
		}

		// Token: 0x0601DFD3 RID: 122835 RVA: 0x008E90D2 File Offset: 0x008E72D2
		private static IntPtr StaticFunctionPtr()
		{
			if (BP_UpdateInteract_C.__ResultChun__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				BP_UpdateInteract_C.__ResultChun__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/Scene/NewGacha/BP/BP_UpdateInteract.BP_UpdateInteract_C:ResultChun__DelegateSignature");
			}
			return BP_UpdateInteract_C.__ResultChun__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x0601DFD4 RID: 122836 RVA: 0x008E90F5 File Offset: 0x008E72F5
		public ResultChun()
		{
		}

		// Token: 0x0601DFD5 RID: 122837 RVA: 0x008E90FD File Offset: 0x008E72FD
		[NullableContext(2)]
		public ResultChun(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0601DFD6 RID: 122838 RVA: 0x008E9107 File Offset: 0x008E7307
		public ResultChun(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0601DFD7 RID: 122839 RVA: 0x008E9112 File Offset: 0x008E7312
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action) ?? ((Action)Delegate.CreateDelegate(typeof(Action), Callback.Target, Callback.Method)));
		}

		// Token: 0x0601DFD8 RID: 122840 RVA: 0x008E9144 File Offset: 0x008E7344
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add(Action Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x0601DFD9 RID: 122841 RVA: 0x008E9153 File Offset: 0x008E7353
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove(Action Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x0601DFDA RID: 122842 RVA: 0x008E915C File Offset: 0x008E735C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Broadcast()
		{
			base.BroadcastInternal(null);
		}

		// Token: 0x0601DFDB RID: 122843 RVA: 0x008E9168 File Offset: 0x008E7368
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

		// Token: 0x0400EB88 RID: 60296
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Scene/NewGacha/BP/BP_UpdateInteract.BP_UpdateInteract_C:ResultChun__DelegateSignature";
	}
}
