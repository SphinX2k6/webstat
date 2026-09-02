using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Scene.NewGacha.BP
{
	// Token: 0x020039D8 RID: 14808
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class ResultJueyuan : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x0601DFFA RID: 122874 RVA: 0x008E9456 File Offset: 0x008E7656
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return ResultJueyuan.StaticFunctionPtr();
		}

		// Token: 0x0601DFFB RID: 122875 RVA: 0x008E9462 File Offset: 0x008E7662
		private static IntPtr StaticFunctionPtr()
		{
			if (BP_UpdateInteract_C.__ResultJueyuan__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				BP_UpdateInteract_C.__ResultJueyuan__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/Scene/NewGacha/BP/BP_UpdateInteract.BP_UpdateInteract_C:ResultJueyuan__DelegateSignature");
			}
			return BP_UpdateInteract_C.__ResultJueyuan__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x0601DFFC RID: 122876 RVA: 0x008E9485 File Offset: 0x008E7685
		public ResultJueyuan()
		{
		}

		// Token: 0x0601DFFD RID: 122877 RVA: 0x008E948D File Offset: 0x008E768D
		[NullableContext(2)]
		public ResultJueyuan(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0601DFFE RID: 122878 RVA: 0x008E9497 File Offset: 0x008E7697
		public ResultJueyuan(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0601DFFF RID: 122879 RVA: 0x008E94A2 File Offset: 0x008E76A2
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action) ?? ((Action)Delegate.CreateDelegate(typeof(Action), Callback.Target, Callback.Method)));
		}

		// Token: 0x0601E000 RID: 122880 RVA: 0x008E94D4 File Offset: 0x008E76D4
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add(Action Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x0601E001 RID: 122881 RVA: 0x008E94E3 File Offset: 0x008E76E3
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove(Action Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x0601E002 RID: 122882 RVA: 0x008E94EC File Offset: 0x008E76EC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Broadcast()
		{
			base.BroadcastInternal(null);
		}

		// Token: 0x0601E003 RID: 122883 RVA: 0x008E94F8 File Offset: 0x008E76F8
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

		// Token: 0x0400EB8C RID: 60300
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Scene/NewGacha/BP/BP_UpdateInteract.BP_UpdateInteract_C:ResultJueyuan__DelegateSignature";
	}
}
