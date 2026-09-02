using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Scene.NewGacha.BP
{
	// Token: 0x020039D6 RID: 14806
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class ResultJinxi : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x0601DFE6 RID: 122854 RVA: 0x008E928E File Offset: 0x008E748E
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return ResultJinxi.StaticFunctionPtr();
		}

		// Token: 0x0601DFE7 RID: 122855 RVA: 0x008E929A File Offset: 0x008E749A
		private static IntPtr StaticFunctionPtr()
		{
			if (BP_UpdateInteract_C.__ResultJinxi__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				BP_UpdateInteract_C.__ResultJinxi__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/Scene/NewGacha/BP/BP_UpdateInteract.BP_UpdateInteract_C:ResultJinxi__DelegateSignature");
			}
			return BP_UpdateInteract_C.__ResultJinxi__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x0601DFE8 RID: 122856 RVA: 0x008E92BD File Offset: 0x008E74BD
		public ResultJinxi()
		{
		}

		// Token: 0x0601DFE9 RID: 122857 RVA: 0x008E92C5 File Offset: 0x008E74C5
		[NullableContext(2)]
		public ResultJinxi(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0601DFEA RID: 122858 RVA: 0x008E92CF File Offset: 0x008E74CF
		public ResultJinxi(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0601DFEB RID: 122859 RVA: 0x008E92DA File Offset: 0x008E74DA
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action) ?? ((Action)Delegate.CreateDelegate(typeof(Action), Callback.Target, Callback.Method)));
		}

		// Token: 0x0601DFEC RID: 122860 RVA: 0x008E930C File Offset: 0x008E750C
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add(Action Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x0601DFED RID: 122861 RVA: 0x008E931B File Offset: 0x008E751B
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove(Action Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x0601DFEE RID: 122862 RVA: 0x008E9324 File Offset: 0x008E7524
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Broadcast()
		{
			base.BroadcastInternal(null);
		}

		// Token: 0x0601DFEF RID: 122863 RVA: 0x008E9330 File Offset: 0x008E7530
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

		// Token: 0x0400EB8A RID: 60298
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Scene/NewGacha/BP/BP_UpdateInteract.BP_UpdateInteract_C:ResultJinxi__DelegateSignature";
	}
}
