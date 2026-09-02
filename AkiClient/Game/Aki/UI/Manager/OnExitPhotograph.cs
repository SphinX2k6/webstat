using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.UI.Manager
{
	// Token: 0x02003993 RID: 14739
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class OnExitPhotograph : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x0601DBE5 RID: 121829 RVA: 0x008DF6E6 File Offset: 0x008DD8E6
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return OnExitPhotograph.StaticFunctionPtr();
		}

		// Token: 0x0601DBE6 RID: 121830 RVA: 0x008DF6F2 File Offset: 0x008DD8F2
		private static IntPtr StaticFunctionPtr()
		{
			if (BP_EventManager_C.__OnExitPhotograph__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				BP_EventManager_C.__OnExitPhotograph__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/UI/Manager/BP_EventManager.BP_EventManager_C:OnExitPhotograph__DelegateSignature");
			}
			return BP_EventManager_C.__OnExitPhotograph__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x0601DBE7 RID: 121831 RVA: 0x008DF715 File Offset: 0x008DD915
		public OnExitPhotograph()
		{
		}

		// Token: 0x0601DBE8 RID: 121832 RVA: 0x008DF71D File Offset: 0x008DD91D
		[NullableContext(2)]
		public OnExitPhotograph(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0601DBE9 RID: 121833 RVA: 0x008DF727 File Offset: 0x008DD927
		public OnExitPhotograph(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0601DBEA RID: 121834 RVA: 0x008DF732 File Offset: 0x008DD932
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action) ?? ((Action)Delegate.CreateDelegate(typeof(Action), Callback.Target, Callback.Method)));
		}

		// Token: 0x0601DBEB RID: 121835 RVA: 0x008DF764 File Offset: 0x008DD964
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add(Action Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x0601DBEC RID: 121836 RVA: 0x008DF773 File Offset: 0x008DD973
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove(Action Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x0601DBED RID: 121837 RVA: 0x008DF77C File Offset: 0x008DD97C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Broadcast()
		{
			base.BroadcastInternal(null);
		}

		// Token: 0x0601DBEE RID: 121838 RVA: 0x008DF788 File Offset: 0x008DD988
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

		// Token: 0x0400E961 RID: 59745
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/UI/Manager/BP_EventManager.BP_EventManager_C:OnExitPhotograph__DelegateSignature";
	}
}
