using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.UI.Manager
{
	// Token: 0x020039AD RID: 14765
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class 被控物广播 : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x0601DCE9 RID: 122089 RVA: 0x008E14DF File Offset: 0x008DF6DF
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return 被控物广播.StaticFunctionPtr();
		}

		// Token: 0x0601DCEA RID: 122090 RVA: 0x008E14EB File Offset: 0x008DF6EB
		private static IntPtr StaticFunctionPtr()
		{
			if (BP_EventManager_C.__被控物广播__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				BP_EventManager_C.__被控物广播__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/UI/Manager/BP_EventManager.BP_EventManager_C:被控物广播__DelegateSignature");
			}
			return BP_EventManager_C.__被控物广播__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x0601DCEB RID: 122091 RVA: 0x008E150E File Offset: 0x008DF70E
		public 被控物广播()
		{
		}

		// Token: 0x0601DCEC RID: 122092 RVA: 0x008E1516 File Offset: 0x008DF716
		[NullableContext(2)]
		public 被控物广播(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0601DCED RID: 122093 RVA: 0x008E1520 File Offset: 0x008DF720
		public 被控物广播(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0601DCEE RID: 122094 RVA: 0x008E152B File Offset: 0x008DF72B
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action) ?? ((Action)Delegate.CreateDelegate(typeof(Action), Callback.Target, Callback.Method)));
		}

		// Token: 0x0601DCEF RID: 122095 RVA: 0x008E155D File Offset: 0x008DF75D
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add(Action Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x0601DCF0 RID: 122096 RVA: 0x008E156C File Offset: 0x008DF76C
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove(Action Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x0601DCF1 RID: 122097 RVA: 0x008E1575 File Offset: 0x008DF775
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Broadcast()
		{
			base.BroadcastInternal(null);
		}

		// Token: 0x0601DCF2 RID: 122098 RVA: 0x008E1580 File Offset: 0x008DF780
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

		// Token: 0x0400E97B RID: 59771
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/UI/Manager/BP_EventManager.BP_EventManager_C:被控物广播__DelegateSignature";
	}
}
