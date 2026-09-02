using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Scene.NewGacha.BP
{
	// Token: 0x020039DD RID: 14813
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class ResultQiushui : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x0601E02C RID: 122924 RVA: 0x008E9902 File Offset: 0x008E7B02
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return ResultQiushui.StaticFunctionPtr();
		}

		// Token: 0x0601E02D RID: 122925 RVA: 0x008E990E File Offset: 0x008E7B0E
		private static IntPtr StaticFunctionPtr()
		{
			if (BP_UpdateInteract_C.__ResultQiushui__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				BP_UpdateInteract_C.__ResultQiushui__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/Scene/NewGacha/BP/BP_UpdateInteract.BP_UpdateInteract_C:ResultQiushui__DelegateSignature");
			}
			return BP_UpdateInteract_C.__ResultQiushui__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x0601E02E RID: 122926 RVA: 0x008E9931 File Offset: 0x008E7B31
		public ResultQiushui()
		{
		}

		// Token: 0x0601E02F RID: 122927 RVA: 0x008E9939 File Offset: 0x008E7B39
		[NullableContext(2)]
		public ResultQiushui(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0601E030 RID: 122928 RVA: 0x008E9943 File Offset: 0x008E7B43
		public ResultQiushui(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0601E031 RID: 122929 RVA: 0x008E994E File Offset: 0x008E7B4E
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action) ?? ((Action)Delegate.CreateDelegate(typeof(Action), Callback.Target, Callback.Method)));
		}

		// Token: 0x0601E032 RID: 122930 RVA: 0x008E9980 File Offset: 0x008E7B80
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add(Action Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x0601E033 RID: 122931 RVA: 0x008E998F File Offset: 0x008E7B8F
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove(Action Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x0601E034 RID: 122932 RVA: 0x008E9998 File Offset: 0x008E7B98
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Broadcast()
		{
			base.BroadcastInternal(null);
		}

		// Token: 0x0601E035 RID: 122933 RVA: 0x008E99A4 File Offset: 0x008E7BA4
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

		// Token: 0x0400EB91 RID: 60305
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Scene/NewGacha/BP/BP_UpdateInteract.BP_UpdateInteract_C:ResultQiushui__DelegateSignature";
	}
}
