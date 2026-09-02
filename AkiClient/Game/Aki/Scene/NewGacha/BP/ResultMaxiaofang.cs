using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Scene.NewGacha.BP
{
	// Token: 0x020039DB RID: 14811
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class ResultMaxiaofang : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x0601E018 RID: 122904 RVA: 0x008E973A File Offset: 0x008E793A
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return ResultMaxiaofang.StaticFunctionPtr();
		}

		// Token: 0x0601E019 RID: 122905 RVA: 0x008E9746 File Offset: 0x008E7946
		private static IntPtr StaticFunctionPtr()
		{
			if (BP_UpdateInteract_C.__ResultMaxiaofang__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				BP_UpdateInteract_C.__ResultMaxiaofang__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/Scene/NewGacha/BP/BP_UpdateInteract.BP_UpdateInteract_C:ResultMaxiaofang__DelegateSignature");
			}
			return BP_UpdateInteract_C.__ResultMaxiaofang__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x0601E01A RID: 122906 RVA: 0x008E9769 File Offset: 0x008E7969
		public ResultMaxiaofang()
		{
		}

		// Token: 0x0601E01B RID: 122907 RVA: 0x008E9771 File Offset: 0x008E7971
		[NullableContext(2)]
		public ResultMaxiaofang(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0601E01C RID: 122908 RVA: 0x008E977B File Offset: 0x008E797B
		public ResultMaxiaofang(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0601E01D RID: 122909 RVA: 0x008E9786 File Offset: 0x008E7986
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action) ?? ((Action)Delegate.CreateDelegate(typeof(Action), Callback.Target, Callback.Method)));
		}

		// Token: 0x0601E01E RID: 122910 RVA: 0x008E97B8 File Offset: 0x008E79B8
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add(Action Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x0601E01F RID: 122911 RVA: 0x008E97C7 File Offset: 0x008E79C7
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove(Action Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x0601E020 RID: 122912 RVA: 0x008E97D0 File Offset: 0x008E79D0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Broadcast()
		{
			base.BroadcastInternal(null);
		}

		// Token: 0x0601E021 RID: 122913 RVA: 0x008E97DC File Offset: 0x008E79DC
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

		// Token: 0x0400EB8F RID: 60303
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Scene/NewGacha/BP/BP_UpdateInteract.BP_UpdateInteract_C:ResultMaxiaofang__DelegateSignature";
	}
}
