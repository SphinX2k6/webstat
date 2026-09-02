using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.UI.Manager
{
	// Token: 0x020039A7 RID: 14759
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class 当触发结算镜头时 : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x0601DCAD RID: 122029 RVA: 0x008E0DA6 File Offset: 0x008DEFA6
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return 当触发结算镜头时.StaticFunctionPtr();
		}

		// Token: 0x0601DCAE RID: 122030 RVA: 0x008E0DB2 File Offset: 0x008DEFB2
		private static IntPtr StaticFunctionPtr()
		{
			if (BP_EventManager_C.__当触发结算镜头时__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				BP_EventManager_C.__当触发结算镜头时__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/UI/Manager/BP_EventManager.BP_EventManager_C:当触发结算镜头时__DelegateSignature");
			}
			return BP_EventManager_C.__当触发结算镜头时__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x0601DCAF RID: 122031 RVA: 0x008E0DD5 File Offset: 0x008DEFD5
		public 当触发结算镜头时()
		{
		}

		// Token: 0x0601DCB0 RID: 122032 RVA: 0x008E0DDD File Offset: 0x008DEFDD
		[NullableContext(2)]
		public 当触发结算镜头时(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0601DCB1 RID: 122033 RVA: 0x008E0DE7 File Offset: 0x008DEFE7
		public 当触发结算镜头时(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0601DCB2 RID: 122034 RVA: 0x008E0DF2 File Offset: 0x008DEFF2
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action) ?? ((Action)Delegate.CreateDelegate(typeof(Action), Callback.Target, Callback.Method)));
		}

		// Token: 0x0601DCB3 RID: 122035 RVA: 0x008E0E24 File Offset: 0x008DF024
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add(Action Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x0601DCB4 RID: 122036 RVA: 0x008E0E33 File Offset: 0x008DF033
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove(Action Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x0601DCB5 RID: 122037 RVA: 0x008E0E3C File Offset: 0x008DF03C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Broadcast()
		{
			base.BroadcastInternal(null);
		}

		// Token: 0x0601DCB6 RID: 122038 RVA: 0x008E0E48 File Offset: 0x008DF048
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

		// Token: 0x0400E975 RID: 59765
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/UI/Manager/BP_EventManager.BP_EventManager_C:当触发结算镜头时__DelegateSignature";
	}
}
