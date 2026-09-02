using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.UI.Manager
{
	// Token: 0x020039A3 RID: 14755
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class 当编队更新时 : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x0601DC85 RID: 121989 RVA: 0x008E0960 File Offset: 0x008DEB60
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return 当编队更新时.StaticFunctionPtr();
		}

		// Token: 0x0601DC86 RID: 121990 RVA: 0x008E096C File Offset: 0x008DEB6C
		private static IntPtr StaticFunctionPtr()
		{
			if (BP_EventManager_C.__当编队更新时__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				BP_EventManager_C.__当编队更新时__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/UI/Manager/BP_EventManager.BP_EventManager_C:当编队更新时__DelegateSignature");
			}
			return BP_EventManager_C.__当编队更新时__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x0601DC87 RID: 121991 RVA: 0x008E098F File Offset: 0x008DEB8F
		public 当编队更新时()
		{
		}

		// Token: 0x0601DC88 RID: 121992 RVA: 0x008E0997 File Offset: 0x008DEB97
		[NullableContext(2)]
		public 当编队更新时(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0601DC89 RID: 121993 RVA: 0x008E09A1 File Offset: 0x008DEBA1
		public 当编队更新时(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0601DC8A RID: 121994 RVA: 0x008E09AC File Offset: 0x008DEBAC
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action) ?? ((Action)Delegate.CreateDelegate(typeof(Action), Callback.Target, Callback.Method)));
		}

		// Token: 0x0601DC8B RID: 121995 RVA: 0x008E09DE File Offset: 0x008DEBDE
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add(Action Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x0601DC8C RID: 121996 RVA: 0x008E09ED File Offset: 0x008DEBED
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove(Action Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x0601DC8D RID: 121997 RVA: 0x008E09F6 File Offset: 0x008DEBF6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Broadcast()
		{
			base.BroadcastInternal(null);
		}

		// Token: 0x0601DC8E RID: 121998 RVA: 0x008E0A00 File Offset: 0x008DEC00
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

		// Token: 0x0400E971 RID: 59761
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/UI/Manager/BP_EventManager.BP_EventManager_C:当编队更新时__DelegateSignature";
	}
}
