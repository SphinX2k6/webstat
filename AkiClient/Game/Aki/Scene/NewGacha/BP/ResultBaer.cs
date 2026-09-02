using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Scene.NewGacha.BP
{
	// Token: 0x020039CF RID: 14799
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class ResultBaer : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x0601DFA0 RID: 122784 RVA: 0x008E8C52 File Offset: 0x008E6E52
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return ResultBaer.StaticFunctionPtr();
		}

		// Token: 0x0601DFA1 RID: 122785 RVA: 0x008E8C5E File Offset: 0x008E6E5E
		private static IntPtr StaticFunctionPtr()
		{
			if (BP_UpdateInteract_C.__ResultBaer__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				BP_UpdateInteract_C.__ResultBaer__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/Scene/NewGacha/BP/BP_UpdateInteract.BP_UpdateInteract_C:ResultBaer__DelegateSignature");
			}
			return BP_UpdateInteract_C.__ResultBaer__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x0601DFA2 RID: 122786 RVA: 0x008E8C81 File Offset: 0x008E6E81
		public ResultBaer()
		{
		}

		// Token: 0x0601DFA3 RID: 122787 RVA: 0x008E8C89 File Offset: 0x008E6E89
		[NullableContext(2)]
		public ResultBaer(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0601DFA4 RID: 122788 RVA: 0x008E8C93 File Offset: 0x008E6E93
		public ResultBaer(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0601DFA5 RID: 122789 RVA: 0x008E8C9E File Offset: 0x008E6E9E
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action) ?? ((Action)Delegate.CreateDelegate(typeof(Action), Callback.Target, Callback.Method)));
		}

		// Token: 0x0601DFA6 RID: 122790 RVA: 0x008E8CD0 File Offset: 0x008E6ED0
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add(Action Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x0601DFA7 RID: 122791 RVA: 0x008E8CDF File Offset: 0x008E6EDF
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove(Action Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x0601DFA8 RID: 122792 RVA: 0x008E8CE8 File Offset: 0x008E6EE8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Broadcast()
		{
			base.BroadcastInternal(null);
		}

		// Token: 0x0601DFA9 RID: 122793 RVA: 0x008E8CF4 File Offset: 0x008E6EF4
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

		// Token: 0x0400EB83 RID: 60291
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Scene/NewGacha/BP/BP_UpdateInteract.BP_UpdateInteract_C:ResultBaer__DelegateSignature";
	}
}
