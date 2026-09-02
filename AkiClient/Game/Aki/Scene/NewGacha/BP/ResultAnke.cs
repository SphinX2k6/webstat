using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Scene.NewGacha.BP
{
	// Token: 0x020039CD RID: 14797
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class ResultAnke : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x0601DF8C RID: 122764 RVA: 0x008E8A8B File Offset: 0x008E6C8B
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return ResultAnke.StaticFunctionPtr();
		}

		// Token: 0x0601DF8D RID: 122765 RVA: 0x008E8A97 File Offset: 0x008E6C97
		private static IntPtr StaticFunctionPtr()
		{
			if (BP_UpdateInteract_C.__ResultAnke__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				BP_UpdateInteract_C.__ResultAnke__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/Scene/NewGacha/BP/BP_UpdateInteract.BP_UpdateInteract_C:ResultAnke__DelegateSignature");
			}
			return BP_UpdateInteract_C.__ResultAnke__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x0601DF8E RID: 122766 RVA: 0x008E8ABA File Offset: 0x008E6CBA
		public ResultAnke()
		{
		}

		// Token: 0x0601DF8F RID: 122767 RVA: 0x008E8AC2 File Offset: 0x008E6CC2
		[NullableContext(2)]
		public ResultAnke(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0601DF90 RID: 122768 RVA: 0x008E8ACC File Offset: 0x008E6CCC
		public ResultAnke(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0601DF91 RID: 122769 RVA: 0x008E8AD7 File Offset: 0x008E6CD7
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action) ?? ((Action)Delegate.CreateDelegate(typeof(Action), Callback.Target, Callback.Method)));
		}

		// Token: 0x0601DF92 RID: 122770 RVA: 0x008E8B09 File Offset: 0x008E6D09
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add(Action Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x0601DF93 RID: 122771 RVA: 0x008E8B18 File Offset: 0x008E6D18
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove(Action Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x0601DF94 RID: 122772 RVA: 0x008E8B21 File Offset: 0x008E6D21
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Broadcast()
		{
			base.BroadcastInternal(null);
		}

		// Token: 0x0601DF95 RID: 122773 RVA: 0x008E8B2C File Offset: 0x008E6D2C
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

		// Token: 0x0400EB81 RID: 60289
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Scene/NewGacha/BP/BP_UpdateInteract.BP_UpdateInteract_C:ResultAnke__DelegateSignature";
	}
}
