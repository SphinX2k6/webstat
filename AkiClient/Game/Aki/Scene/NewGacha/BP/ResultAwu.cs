using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Scene.NewGacha.BP
{
	// Token: 0x020039CE RID: 14798
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class ResultAwu : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x0601DF96 RID: 122774 RVA: 0x008E8B6E File Offset: 0x008E6D6E
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return ResultAwu.StaticFunctionPtr();
		}

		// Token: 0x0601DF97 RID: 122775 RVA: 0x008E8B7A File Offset: 0x008E6D7A
		private static IntPtr StaticFunctionPtr()
		{
			if (BP_UpdateInteract_C.__ResultAwu__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				BP_UpdateInteract_C.__ResultAwu__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/Scene/NewGacha/BP/BP_UpdateInteract.BP_UpdateInteract_C:ResultAwu__DelegateSignature");
			}
			return BP_UpdateInteract_C.__ResultAwu__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x0601DF98 RID: 122776 RVA: 0x008E8B9D File Offset: 0x008E6D9D
		public ResultAwu()
		{
		}

		// Token: 0x0601DF99 RID: 122777 RVA: 0x008E8BA5 File Offset: 0x008E6DA5
		[NullableContext(2)]
		public ResultAwu(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0601DF9A RID: 122778 RVA: 0x008E8BAF File Offset: 0x008E6DAF
		public ResultAwu(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0601DF9B RID: 122779 RVA: 0x008E8BBA File Offset: 0x008E6DBA
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action) ?? ((Action)Delegate.CreateDelegate(typeof(Action), Callback.Target, Callback.Method)));
		}

		// Token: 0x0601DF9C RID: 122780 RVA: 0x008E8BEC File Offset: 0x008E6DEC
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add(Action Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x0601DF9D RID: 122781 RVA: 0x008E8BFB File Offset: 0x008E6DFB
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove(Action Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x0601DF9E RID: 122782 RVA: 0x008E8C04 File Offset: 0x008E6E04
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Broadcast()
		{
			base.BroadcastInternal(null);
		}

		// Token: 0x0601DF9F RID: 122783 RVA: 0x008E8C10 File Offset: 0x008E6E10
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

		// Token: 0x0400EB82 RID: 60290
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Scene/NewGacha/BP/BP_UpdateInteract.BP_UpdateInteract_C:ResultAwu__DelegateSignature";
	}
}
