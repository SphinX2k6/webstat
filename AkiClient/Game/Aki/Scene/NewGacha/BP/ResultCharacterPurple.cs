using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Scene.NewGacha.BP
{
	// Token: 0x020039D3 RID: 14803
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class ResultCharacterPurple : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x0601DFC8 RID: 122824 RVA: 0x008E8FE2 File Offset: 0x008E71E2
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return ResultCharacterPurple.StaticFunctionPtr();
		}

		// Token: 0x0601DFC9 RID: 122825 RVA: 0x008E8FEE File Offset: 0x008E71EE
		private static IntPtr StaticFunctionPtr()
		{
			if (BP_UpdateInteract_C.__ResultCharacterPurple__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				BP_UpdateInteract_C.__ResultCharacterPurple__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/Scene/NewGacha/BP/BP_UpdateInteract.BP_UpdateInteract_C:ResultCharacterPurple__DelegateSignature");
			}
			return BP_UpdateInteract_C.__ResultCharacterPurple__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x0601DFCA RID: 122826 RVA: 0x008E9011 File Offset: 0x008E7211
		public ResultCharacterPurple()
		{
		}

		// Token: 0x0601DFCB RID: 122827 RVA: 0x008E9019 File Offset: 0x008E7219
		[NullableContext(2)]
		public ResultCharacterPurple(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0601DFCC RID: 122828 RVA: 0x008E9023 File Offset: 0x008E7223
		public ResultCharacterPurple(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0601DFCD RID: 122829 RVA: 0x008E902E File Offset: 0x008E722E
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action) ?? ((Action)Delegate.CreateDelegate(typeof(Action), Callback.Target, Callback.Method)));
		}

		// Token: 0x0601DFCE RID: 122830 RVA: 0x008E9060 File Offset: 0x008E7260
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add(Action Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x0601DFCF RID: 122831 RVA: 0x008E906F File Offset: 0x008E726F
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove(Action Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x0601DFD0 RID: 122832 RVA: 0x008E9078 File Offset: 0x008E7278
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Broadcast()
		{
			base.BroadcastInternal(null);
		}

		// Token: 0x0601DFD1 RID: 122833 RVA: 0x008E9084 File Offset: 0x008E7284
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

		// Token: 0x0400EB87 RID: 60295
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Scene/NewGacha/BP/BP_UpdateInteract.BP_UpdateInteract_C:ResultCharacterPurple__DelegateSignature";
	}
}
