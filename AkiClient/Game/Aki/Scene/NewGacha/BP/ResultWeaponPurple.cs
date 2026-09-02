using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Scene.NewGacha.BP
{
	// Token: 0x020039E2 RID: 14818
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class ResultWeaponPurple : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x0601E05E RID: 122974 RVA: 0x008E9D76 File Offset: 0x008E7F76
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return ResultWeaponPurple.StaticFunctionPtr();
		}

		// Token: 0x0601E05F RID: 122975 RVA: 0x008E9D82 File Offset: 0x008E7F82
		private static IntPtr StaticFunctionPtr()
		{
			if (BP_UpdateInteract_C.__ResultWeaponPurple__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				BP_UpdateInteract_C.__ResultWeaponPurple__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/Scene/NewGacha/BP/BP_UpdateInteract.BP_UpdateInteract_C:ResultWeaponPurple__DelegateSignature");
			}
			return BP_UpdateInteract_C.__ResultWeaponPurple__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x0601E060 RID: 122976 RVA: 0x008E9DA5 File Offset: 0x008E7FA5
		public ResultWeaponPurple()
		{
		}

		// Token: 0x0601E061 RID: 122977 RVA: 0x008E9DAD File Offset: 0x008E7FAD
		[NullableContext(2)]
		public ResultWeaponPurple(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0601E062 RID: 122978 RVA: 0x008E9DB7 File Offset: 0x008E7FB7
		public ResultWeaponPurple(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0601E063 RID: 122979 RVA: 0x008E9DC2 File Offset: 0x008E7FC2
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action) ?? ((Action)Delegate.CreateDelegate(typeof(Action), Callback.Target, Callback.Method)));
		}

		// Token: 0x0601E064 RID: 122980 RVA: 0x008E9DF4 File Offset: 0x008E7FF4
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add(Action Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x0601E065 RID: 122981 RVA: 0x008E9E03 File Offset: 0x008E8003
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove(Action Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x0601E066 RID: 122982 RVA: 0x008E9E0C File Offset: 0x008E800C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Broadcast()
		{
			base.BroadcastInternal(null);
		}

		// Token: 0x0601E067 RID: 122983 RVA: 0x008E9E18 File Offset: 0x008E8018
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

		// Token: 0x0400EB96 RID: 60310
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Scene/NewGacha/BP/BP_UpdateInteract.BP_UpdateInteract_C:ResultWeaponPurple__DelegateSignature";
	}
}
