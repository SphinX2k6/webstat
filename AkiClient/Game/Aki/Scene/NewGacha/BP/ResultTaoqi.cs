using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Scene.NewGacha.BP
{
	// Token: 0x020039DF RID: 14815
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class ResultTaoqi : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x0601E040 RID: 122944 RVA: 0x008E9ACA File Offset: 0x008E7CCA
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return ResultTaoqi.StaticFunctionPtr();
		}

		// Token: 0x0601E041 RID: 122945 RVA: 0x008E9AD6 File Offset: 0x008E7CD6
		private static IntPtr StaticFunctionPtr()
		{
			if (BP_UpdateInteract_C.__ResultTaoqi__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				BP_UpdateInteract_C.__ResultTaoqi__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/Scene/NewGacha/BP/BP_UpdateInteract.BP_UpdateInteract_C:ResultTaoqi__DelegateSignature");
			}
			return BP_UpdateInteract_C.__ResultTaoqi__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x0601E042 RID: 122946 RVA: 0x008E9AF9 File Offset: 0x008E7CF9
		public ResultTaoqi()
		{
		}

		// Token: 0x0601E043 RID: 122947 RVA: 0x008E9B01 File Offset: 0x008E7D01
		[NullableContext(2)]
		public ResultTaoqi(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0601E044 RID: 122948 RVA: 0x008E9B0B File Offset: 0x008E7D0B
		public ResultTaoqi(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0601E045 RID: 122949 RVA: 0x008E9B16 File Offset: 0x008E7D16
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action) ?? ((Action)Delegate.CreateDelegate(typeof(Action), Callback.Target, Callback.Method)));
		}

		// Token: 0x0601E046 RID: 122950 RVA: 0x008E9B48 File Offset: 0x008E7D48
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add(Action Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x0601E047 RID: 122951 RVA: 0x008E9B57 File Offset: 0x008E7D57
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove(Action Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x0601E048 RID: 122952 RVA: 0x008E9B60 File Offset: 0x008E7D60
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Broadcast()
		{
			base.BroadcastInternal(null);
		}

		// Token: 0x0601E049 RID: 122953 RVA: 0x008E9B6C File Offset: 0x008E7D6C
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

		// Token: 0x0400EB93 RID: 60307
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Scene/NewGacha/BP/BP_UpdateInteract.BP_UpdateInteract_C:ResultTaoqi__DelegateSignature";
	}
}
