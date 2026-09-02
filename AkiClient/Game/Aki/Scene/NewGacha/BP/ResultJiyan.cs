using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Scene.NewGacha.BP
{
	// Token: 0x020039D7 RID: 14807
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class ResultJiyan : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x0601DFF0 RID: 122864 RVA: 0x008E9372 File Offset: 0x008E7572
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return ResultJiyan.StaticFunctionPtr();
		}

		// Token: 0x0601DFF1 RID: 122865 RVA: 0x008E937E File Offset: 0x008E757E
		private static IntPtr StaticFunctionPtr()
		{
			if (BP_UpdateInteract_C.__ResultJiyan__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				BP_UpdateInteract_C.__ResultJiyan__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/Scene/NewGacha/BP/BP_UpdateInteract.BP_UpdateInteract_C:ResultJiyan__DelegateSignature");
			}
			return BP_UpdateInteract_C.__ResultJiyan__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x0601DFF2 RID: 122866 RVA: 0x008E93A1 File Offset: 0x008E75A1
		public ResultJiyan()
		{
		}

		// Token: 0x0601DFF3 RID: 122867 RVA: 0x008E93A9 File Offset: 0x008E75A9
		[NullableContext(2)]
		public ResultJiyan(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0601DFF4 RID: 122868 RVA: 0x008E93B3 File Offset: 0x008E75B3
		public ResultJiyan(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0601DFF5 RID: 122869 RVA: 0x008E93BE File Offset: 0x008E75BE
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action) ?? ((Action)Delegate.CreateDelegate(typeof(Action), Callback.Target, Callback.Method)));
		}

		// Token: 0x0601DFF6 RID: 122870 RVA: 0x008E93F0 File Offset: 0x008E75F0
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add(Action Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x0601DFF7 RID: 122871 RVA: 0x008E93FF File Offset: 0x008E75FF
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove(Action Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x0601DFF8 RID: 122872 RVA: 0x008E9408 File Offset: 0x008E7608
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Broadcast()
		{
			base.BroadcastInternal(null);
		}

		// Token: 0x0601DFF9 RID: 122873 RVA: 0x008E9414 File Offset: 0x008E7614
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

		// Token: 0x0400EB8B RID: 60299
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Scene/NewGacha/BP/BP_UpdateInteract.BP_UpdateInteract_C:ResultJiyan__DelegateSignature";
	}
}
