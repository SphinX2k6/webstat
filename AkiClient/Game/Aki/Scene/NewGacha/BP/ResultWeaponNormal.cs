using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Scene.NewGacha.BP
{
	// Token: 0x020039E1 RID: 14817
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class ResultWeaponNormal : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x0601E054 RID: 122964 RVA: 0x008E9C92 File Offset: 0x008E7E92
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return ResultWeaponNormal.StaticFunctionPtr();
		}

		// Token: 0x0601E055 RID: 122965 RVA: 0x008E9C9E File Offset: 0x008E7E9E
		private static IntPtr StaticFunctionPtr()
		{
			if (BP_UpdateInteract_C.__ResultWeaponNormal__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				BP_UpdateInteract_C.__ResultWeaponNormal__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/Scene/NewGacha/BP/BP_UpdateInteract.BP_UpdateInteract_C:ResultWeaponNormal__DelegateSignature");
			}
			return BP_UpdateInteract_C.__ResultWeaponNormal__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x0601E056 RID: 122966 RVA: 0x008E9CC1 File Offset: 0x008E7EC1
		public ResultWeaponNormal()
		{
		}

		// Token: 0x0601E057 RID: 122967 RVA: 0x008E9CC9 File Offset: 0x008E7EC9
		[NullableContext(2)]
		public ResultWeaponNormal(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0601E058 RID: 122968 RVA: 0x008E9CD3 File Offset: 0x008E7ED3
		public ResultWeaponNormal(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0601E059 RID: 122969 RVA: 0x008E9CDE File Offset: 0x008E7EDE
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action) ?? ((Action)Delegate.CreateDelegate(typeof(Action), Callback.Target, Callback.Method)));
		}

		// Token: 0x0601E05A RID: 122970 RVA: 0x008E9D10 File Offset: 0x008E7F10
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add(Action Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x0601E05B RID: 122971 RVA: 0x008E9D1F File Offset: 0x008E7F1F
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove(Action Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x0601E05C RID: 122972 RVA: 0x008E9D28 File Offset: 0x008E7F28
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Broadcast()
		{
			base.BroadcastInternal(null);
		}

		// Token: 0x0601E05D RID: 122973 RVA: 0x008E9D34 File Offset: 0x008E7F34
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

		// Token: 0x0400EB95 RID: 60309
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Scene/NewGacha/BP/BP_UpdateInteract.BP_UpdateInteract_C:ResultWeaponNormal__DelegateSignature";
	}
}
