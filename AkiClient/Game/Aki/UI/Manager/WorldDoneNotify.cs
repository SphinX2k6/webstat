using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.UI.Manager
{
	// Token: 0x02003994 RID: 14740
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class WorldDoneNotify : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x0601DBEF RID: 121839 RVA: 0x008DF7CA File Offset: 0x008DD9CA
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return WorldDoneNotify.StaticFunctionPtr();
		}

		// Token: 0x0601DBF0 RID: 121840 RVA: 0x008DF7D6 File Offset: 0x008DD9D6
		private static IntPtr StaticFunctionPtr()
		{
			if (BP_EventManager_C.__WorldDoneNotify__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				BP_EventManager_C.__WorldDoneNotify__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/UI/Manager/BP_EventManager.BP_EventManager_C:WorldDoneNotify__DelegateSignature");
			}
			return BP_EventManager_C.__WorldDoneNotify__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x0601DBF1 RID: 121841 RVA: 0x008DF7F9 File Offset: 0x008DD9F9
		public WorldDoneNotify()
		{
		}

		// Token: 0x0601DBF2 RID: 121842 RVA: 0x008DF801 File Offset: 0x008DDA01
		[NullableContext(2)]
		public WorldDoneNotify(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0601DBF3 RID: 121843 RVA: 0x008DF80B File Offset: 0x008DDA0B
		public WorldDoneNotify(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0601DBF4 RID: 121844 RVA: 0x008DF816 File Offset: 0x008DDA16
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action) ?? ((Action)Delegate.CreateDelegate(typeof(Action), Callback.Target, Callback.Method)));
		}

		// Token: 0x0601DBF5 RID: 121845 RVA: 0x008DF848 File Offset: 0x008DDA48
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add(Action Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x0601DBF6 RID: 121846 RVA: 0x008DF857 File Offset: 0x008DDA57
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove(Action Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x0601DBF7 RID: 121847 RVA: 0x008DF860 File Offset: 0x008DDA60
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Broadcast()
		{
			base.BroadcastInternal(null);
		}

		// Token: 0x0601DBF8 RID: 121848 RVA: 0x008DF86C File Offset: 0x008DDA6C
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

		// Token: 0x0400E962 RID: 59746
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/UI/Manager/BP_EventManager.BP_EventManager_C:WorldDoneNotify__DelegateSignature";
	}
}
