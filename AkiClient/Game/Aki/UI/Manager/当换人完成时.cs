using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.UI.Manager
{
	// Token: 0x0200399E RID: 14750
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class 当换人完成时 : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x0601DC53 RID: 121939 RVA: 0x008E036D File Offset: 0x008DE56D
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return 当换人完成时.StaticFunctionPtr();
		}

		// Token: 0x0601DC54 RID: 121940 RVA: 0x008E0379 File Offset: 0x008DE579
		private static IntPtr StaticFunctionPtr()
		{
			if (BP_EventManager_C.__当换人完成时__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				BP_EventManager_C.__当换人完成时__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/UI/Manager/BP_EventManager.BP_EventManager_C:当换人完成时__DelegateSignature");
			}
			return BP_EventManager_C.__当换人完成时__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x0601DC55 RID: 121941 RVA: 0x008E039C File Offset: 0x008DE59C
		public 当换人完成时()
		{
		}

		// Token: 0x0601DC56 RID: 121942 RVA: 0x008E03A4 File Offset: 0x008DE5A4
		[NullableContext(2)]
		public 当换人完成时(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0601DC57 RID: 121943 RVA: 0x008E03AE File Offset: 0x008DE5AE
		public 当换人完成时(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0601DC58 RID: 121944 RVA: 0x008E03B9 File Offset: 0x008DE5B9
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action) ?? ((Action)Delegate.CreateDelegate(typeof(Action), Callback.Target, Callback.Method)));
		}

		// Token: 0x0601DC59 RID: 121945 RVA: 0x008E03EB File Offset: 0x008DE5EB
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add(Action Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x0601DC5A RID: 121946 RVA: 0x008E03FA File Offset: 0x008DE5FA
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove(Action Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x0601DC5B RID: 121947 RVA: 0x008E0403 File Offset: 0x008DE603
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Broadcast()
		{
			base.BroadcastInternal(null);
		}

		// Token: 0x0601DC5C RID: 121948 RVA: 0x008E0410 File Offset: 0x008DE610
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

		// Token: 0x0400E96C RID: 59756
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/UI/Manager/BP_EventManager.BP_EventManager_C:当换人完成时__DelegateSignature";
	}
}
