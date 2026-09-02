using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Scene.NewGacha.BP
{
	// Token: 0x020039E5 RID: 14821
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class ResultYuanwu : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x0601E07C RID: 123004 RVA: 0x008EA022 File Offset: 0x008E8222
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return ResultYuanwu.StaticFunctionPtr();
		}

		// Token: 0x0601E07D RID: 123005 RVA: 0x008EA02E File Offset: 0x008E822E
		private static IntPtr StaticFunctionPtr()
		{
			if (BP_UpdateInteract_C.__ResultYuanwu__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				BP_UpdateInteract_C.__ResultYuanwu__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/Scene/NewGacha/BP/BP_UpdateInteract.BP_UpdateInteract_C:ResultYuanwu__DelegateSignature");
			}
			return BP_UpdateInteract_C.__ResultYuanwu__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x0601E07E RID: 123006 RVA: 0x008EA051 File Offset: 0x008E8251
		public ResultYuanwu()
		{
		}

		// Token: 0x0601E07F RID: 123007 RVA: 0x008EA059 File Offset: 0x008E8259
		[NullableContext(2)]
		public ResultYuanwu(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0601E080 RID: 123008 RVA: 0x008EA063 File Offset: 0x008E8263
		public ResultYuanwu(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0601E081 RID: 123009 RVA: 0x008EA06E File Offset: 0x008E826E
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action) ?? ((Action)Delegate.CreateDelegate(typeof(Action), Callback.Target, Callback.Method)));
		}

		// Token: 0x0601E082 RID: 123010 RVA: 0x008EA0A0 File Offset: 0x008E82A0
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add(Action Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x0601E083 RID: 123011 RVA: 0x008EA0AF File Offset: 0x008E82AF
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove(Action Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x0601E084 RID: 123012 RVA: 0x008EA0B8 File Offset: 0x008E82B8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Broadcast()
		{
			base.BroadcastInternal(null);
		}

		// Token: 0x0601E085 RID: 123013 RVA: 0x008EA0C4 File Offset: 0x008E82C4
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

		// Token: 0x0400EB99 RID: 60313
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Scene/NewGacha/BP/BP_UpdateInteract.BP_UpdateInteract_C:ResultYuanwu__DelegateSignature";
	}
}
