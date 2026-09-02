using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Scene.NewGacha.BP
{
	// Token: 0x020039DC RID: 14812
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class ResultMicai : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x0601E022 RID: 122914 RVA: 0x008E981E File Offset: 0x008E7A1E
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return ResultMicai.StaticFunctionPtr();
		}

		// Token: 0x0601E023 RID: 122915 RVA: 0x008E982A File Offset: 0x008E7A2A
		private static IntPtr StaticFunctionPtr()
		{
			if (BP_UpdateInteract_C.__ResultMicai__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				BP_UpdateInteract_C.__ResultMicai__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/Scene/NewGacha/BP/BP_UpdateInteract.BP_UpdateInteract_C:ResultMicai__DelegateSignature");
			}
			return BP_UpdateInteract_C.__ResultMicai__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x0601E024 RID: 122916 RVA: 0x008E984D File Offset: 0x008E7A4D
		public ResultMicai()
		{
		}

		// Token: 0x0601E025 RID: 122917 RVA: 0x008E9855 File Offset: 0x008E7A55
		[NullableContext(2)]
		public ResultMicai(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0601E026 RID: 122918 RVA: 0x008E985F File Offset: 0x008E7A5F
		public ResultMicai(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0601E027 RID: 122919 RVA: 0x008E986A File Offset: 0x008E7A6A
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action) ?? ((Action)Delegate.CreateDelegate(typeof(Action), Callback.Target, Callback.Method)));
		}

		// Token: 0x0601E028 RID: 122920 RVA: 0x008E989C File Offset: 0x008E7A9C
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add(Action Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x0601E029 RID: 122921 RVA: 0x008E98AB File Offset: 0x008E7AAB
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove(Action Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x0601E02A RID: 122922 RVA: 0x008E98B4 File Offset: 0x008E7AB4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Broadcast()
		{
			base.BroadcastInternal(null);
		}

		// Token: 0x0601E02B RID: 122923 RVA: 0x008E98C0 File Offset: 0x008E7AC0
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

		// Token: 0x0400EB90 RID: 60304
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Scene/NewGacha/BP/BP_UpdateInteract.BP_UpdateInteract_C:ResultMicai__DelegateSignature";
	}
}
