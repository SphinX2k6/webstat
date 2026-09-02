using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.UI.Manager
{
	// Token: 0x020039A6 RID: 14758
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class 当触发相机注视时 : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x0601DCA3 RID: 122019 RVA: 0x008E0CC2 File Offset: 0x008DEEC2
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return 当触发相机注视时.StaticFunctionPtr();
		}

		// Token: 0x0601DCA4 RID: 122020 RVA: 0x008E0CCE File Offset: 0x008DEECE
		private static IntPtr StaticFunctionPtr()
		{
			if (BP_EventManager_C.__当触发相机注视时__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				BP_EventManager_C.__当触发相机注视时__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/UI/Manager/BP_EventManager.BP_EventManager_C:当触发相机注视时__DelegateSignature");
			}
			return BP_EventManager_C.__当触发相机注视时__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x0601DCA5 RID: 122021 RVA: 0x008E0CF1 File Offset: 0x008DEEF1
		public 当触发相机注视时()
		{
		}

		// Token: 0x0601DCA6 RID: 122022 RVA: 0x008E0CF9 File Offset: 0x008DEEF9
		[NullableContext(2)]
		public 当触发相机注视时(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0601DCA7 RID: 122023 RVA: 0x008E0D03 File Offset: 0x008DEF03
		public 当触发相机注视时(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0601DCA8 RID: 122024 RVA: 0x008E0D0E File Offset: 0x008DEF0E
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action) ?? ((Action)Delegate.CreateDelegate(typeof(Action), Callback.Target, Callback.Method)));
		}

		// Token: 0x0601DCA9 RID: 122025 RVA: 0x008E0D40 File Offset: 0x008DEF40
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add(Action Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x0601DCAA RID: 122026 RVA: 0x008E0D4F File Offset: 0x008DEF4F
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove(Action Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x0601DCAB RID: 122027 RVA: 0x008E0D58 File Offset: 0x008DEF58
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Broadcast()
		{
			base.BroadcastInternal(null);
		}

		// Token: 0x0601DCAC RID: 122028 RVA: 0x008E0D64 File Offset: 0x008DEF64
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

		// Token: 0x0400E974 RID: 59764
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/UI/Manager/BP_EventManager.BP_EventManager_C:当触发相机注视时__DelegateSignature";
	}
}
