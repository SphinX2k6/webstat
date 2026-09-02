using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.UI.Manager
{
	// Token: 0x02003992 RID: 14738
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class OnEnterPhotograph : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x0601DBDB RID: 121819 RVA: 0x008DF604 File Offset: 0x008DD804
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return OnEnterPhotograph.StaticFunctionPtr();
		}

		// Token: 0x0601DBDC RID: 121820 RVA: 0x008DF610 File Offset: 0x008DD810
		private static IntPtr StaticFunctionPtr()
		{
			if (BP_EventManager_C.__OnEnterPhotograph__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				BP_EventManager_C.__OnEnterPhotograph__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/UI/Manager/BP_EventManager.BP_EventManager_C:OnEnterPhotograph__DelegateSignature");
			}
			return BP_EventManager_C.__OnEnterPhotograph__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x0601DBDD RID: 121821 RVA: 0x008DF633 File Offset: 0x008DD833
		public OnEnterPhotograph()
		{
		}

		// Token: 0x0601DBDE RID: 121822 RVA: 0x008DF63B File Offset: 0x008DD83B
		[NullableContext(2)]
		public OnEnterPhotograph(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0601DBDF RID: 121823 RVA: 0x008DF645 File Offset: 0x008DD845
		public OnEnterPhotograph(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0601DBE0 RID: 121824 RVA: 0x008DF650 File Offset: 0x008DD850
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action) ?? ((Action)Delegate.CreateDelegate(typeof(Action), Callback.Target, Callback.Method)));
		}

		// Token: 0x0601DBE1 RID: 121825 RVA: 0x008DF682 File Offset: 0x008DD882
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add(Action Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x0601DBE2 RID: 121826 RVA: 0x008DF691 File Offset: 0x008DD891
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove(Action Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x0601DBE3 RID: 121827 RVA: 0x008DF69A File Offset: 0x008DD89A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Broadcast()
		{
			base.BroadcastInternal(null);
		}

		// Token: 0x0601DBE4 RID: 121828 RVA: 0x008DF6A4 File Offset: 0x008DD8A4
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

		// Token: 0x0400E960 RID: 59744
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/UI/Manager/BP_EventManager.BP_EventManager_C:OnEnterPhotograph__DelegateSignature";
	}
}
