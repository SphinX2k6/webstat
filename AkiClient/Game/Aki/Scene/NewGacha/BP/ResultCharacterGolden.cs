using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Scene.NewGacha.BP
{
	// Token: 0x020039D2 RID: 14802
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class ResultCharacterGolden : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x0601DFBE RID: 122814 RVA: 0x008E8EFE File Offset: 0x008E70FE
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return ResultCharacterGolden.StaticFunctionPtr();
		}

		// Token: 0x0601DFBF RID: 122815 RVA: 0x008E8F0A File Offset: 0x008E710A
		private static IntPtr StaticFunctionPtr()
		{
			if (BP_UpdateInteract_C.__ResultCharacterGolden__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				BP_UpdateInteract_C.__ResultCharacterGolden__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/Scene/NewGacha/BP/BP_UpdateInteract.BP_UpdateInteract_C:ResultCharacterGolden__DelegateSignature");
			}
			return BP_UpdateInteract_C.__ResultCharacterGolden__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x0601DFC0 RID: 122816 RVA: 0x008E8F2D File Offset: 0x008E712D
		public ResultCharacterGolden()
		{
		}

		// Token: 0x0601DFC1 RID: 122817 RVA: 0x008E8F35 File Offset: 0x008E7135
		[NullableContext(2)]
		public ResultCharacterGolden(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0601DFC2 RID: 122818 RVA: 0x008E8F3F File Offset: 0x008E713F
		public ResultCharacterGolden(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0601DFC3 RID: 122819 RVA: 0x008E8F4A File Offset: 0x008E714A
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action) ?? ((Action)Delegate.CreateDelegate(typeof(Action), Callback.Target, Callback.Method)));
		}

		// Token: 0x0601DFC4 RID: 122820 RVA: 0x008E8F7C File Offset: 0x008E717C
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add(Action Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x0601DFC5 RID: 122821 RVA: 0x008E8F8B File Offset: 0x008E718B
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove(Action Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x0601DFC6 RID: 122822 RVA: 0x008E8F94 File Offset: 0x008E7194
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Broadcast()
		{
			base.BroadcastInternal(null);
		}

		// Token: 0x0601DFC7 RID: 122823 RVA: 0x008E8FA0 File Offset: 0x008E71A0
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

		// Token: 0x0400EB86 RID: 60294
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Scene/NewGacha/BP/BP_UpdateInteract.BP_UpdateInteract_C:ResultCharacterGolden__DelegateSignature";
	}
}
