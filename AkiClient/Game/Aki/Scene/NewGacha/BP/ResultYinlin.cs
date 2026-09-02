using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Scene.NewGacha.BP
{
	// Token: 0x020039E4 RID: 14820
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class ResultYinlin : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x0601E072 RID: 122994 RVA: 0x008E9F3E File Offset: 0x008E813E
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return ResultYinlin.StaticFunctionPtr();
		}

		// Token: 0x0601E073 RID: 122995 RVA: 0x008E9F4A File Offset: 0x008E814A
		private static IntPtr StaticFunctionPtr()
		{
			if (BP_UpdateInteract_C.__ResultYinlin__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				BP_UpdateInteract_C.__ResultYinlin__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/Scene/NewGacha/BP/BP_UpdateInteract.BP_UpdateInteract_C:ResultYinlin__DelegateSignature");
			}
			return BP_UpdateInteract_C.__ResultYinlin__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x0601E074 RID: 122996 RVA: 0x008E9F6D File Offset: 0x008E816D
		public ResultYinlin()
		{
		}

		// Token: 0x0601E075 RID: 122997 RVA: 0x008E9F75 File Offset: 0x008E8175
		[NullableContext(2)]
		public ResultYinlin(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0601E076 RID: 122998 RVA: 0x008E9F7F File Offset: 0x008E817F
		public ResultYinlin(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0601E077 RID: 122999 RVA: 0x008E9F8A File Offset: 0x008E818A
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action) ?? ((Action)Delegate.CreateDelegate(typeof(Action), Callback.Target, Callback.Method)));
		}

		// Token: 0x0601E078 RID: 123000 RVA: 0x008E9FBC File Offset: 0x008E81BC
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add(Action Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x0601E079 RID: 123001 RVA: 0x008E9FCB File Offset: 0x008E81CB
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove(Action Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x0601E07A RID: 123002 RVA: 0x008E9FD4 File Offset: 0x008E81D4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Broadcast()
		{
			base.BroadcastInternal(null);
		}

		// Token: 0x0601E07B RID: 123003 RVA: 0x008E9FE0 File Offset: 0x008E81E0
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

		// Token: 0x0400EB98 RID: 60312
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Scene/NewGacha/BP/BP_UpdateInteract.BP_UpdateInteract_C:ResultYinlin__DelegateSignature";
	}
}
