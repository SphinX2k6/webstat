using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Scene.NewGacha.BP
{
	// Token: 0x020039DE RID: 14814
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class ResultSanhua : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x0601E036 RID: 122934 RVA: 0x008E99E6 File Offset: 0x008E7BE6
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return ResultSanhua.StaticFunctionPtr();
		}

		// Token: 0x0601E037 RID: 122935 RVA: 0x008E99F2 File Offset: 0x008E7BF2
		private static IntPtr StaticFunctionPtr()
		{
			if (BP_UpdateInteract_C.__ResultSanhua__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				BP_UpdateInteract_C.__ResultSanhua__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/Scene/NewGacha/BP/BP_UpdateInteract.BP_UpdateInteract_C:ResultSanhua__DelegateSignature");
			}
			return BP_UpdateInteract_C.__ResultSanhua__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x0601E038 RID: 122936 RVA: 0x008E9A15 File Offset: 0x008E7C15
		public ResultSanhua()
		{
		}

		// Token: 0x0601E039 RID: 122937 RVA: 0x008E9A1D File Offset: 0x008E7C1D
		[NullableContext(2)]
		public ResultSanhua(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0601E03A RID: 122938 RVA: 0x008E9A27 File Offset: 0x008E7C27
		public ResultSanhua(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0601E03B RID: 122939 RVA: 0x008E9A32 File Offset: 0x008E7C32
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action) ?? ((Action)Delegate.CreateDelegate(typeof(Action), Callback.Target, Callback.Method)));
		}

		// Token: 0x0601E03C RID: 122940 RVA: 0x008E9A64 File Offset: 0x008E7C64
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add(Action Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x0601E03D RID: 122941 RVA: 0x008E9A73 File Offset: 0x008E7C73
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove(Action Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x0601E03E RID: 122942 RVA: 0x008E9A7C File Offset: 0x008E7C7C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Broadcast()
		{
			base.BroadcastInternal(null);
		}

		// Token: 0x0601E03F RID: 122943 RVA: 0x008E9A88 File Offset: 0x008E7C88
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

		// Token: 0x0400EB92 RID: 60306
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Scene/NewGacha/BP/BP_UpdateInteract.BP_UpdateInteract_C:ResultSanhua__DelegateSignature";
	}
}
