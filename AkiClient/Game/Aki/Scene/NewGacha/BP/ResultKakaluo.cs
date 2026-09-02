using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Scene.NewGacha.BP
{
	// Token: 0x020039D9 RID: 14809
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class ResultKakaluo : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x0601E004 RID: 122884 RVA: 0x008E953A File Offset: 0x008E773A
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return ResultKakaluo.StaticFunctionPtr();
		}

		// Token: 0x0601E005 RID: 122885 RVA: 0x008E9546 File Offset: 0x008E7746
		private static IntPtr StaticFunctionPtr()
		{
			if (BP_UpdateInteract_C.__ResultKakaluo__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				BP_UpdateInteract_C.__ResultKakaluo__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/Scene/NewGacha/BP/BP_UpdateInteract.BP_UpdateInteract_C:ResultKakaluo__DelegateSignature");
			}
			return BP_UpdateInteract_C.__ResultKakaluo__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x0601E006 RID: 122886 RVA: 0x008E9569 File Offset: 0x008E7769
		public ResultKakaluo()
		{
		}

		// Token: 0x0601E007 RID: 122887 RVA: 0x008E9571 File Offset: 0x008E7771
		[NullableContext(2)]
		public ResultKakaluo(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0601E008 RID: 122888 RVA: 0x008E957B File Offset: 0x008E777B
		public ResultKakaluo(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0601E009 RID: 122889 RVA: 0x008E9586 File Offset: 0x008E7786
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action) ?? ((Action)Delegate.CreateDelegate(typeof(Action), Callback.Target, Callback.Method)));
		}

		// Token: 0x0601E00A RID: 122890 RVA: 0x008E95B8 File Offset: 0x008E77B8
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add(Action Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x0601E00B RID: 122891 RVA: 0x008E95C7 File Offset: 0x008E77C7
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove(Action Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x0601E00C RID: 122892 RVA: 0x008E95D0 File Offset: 0x008E77D0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Broadcast()
		{
			base.BroadcastInternal(null);
		}

		// Token: 0x0601E00D RID: 122893 RVA: 0x008E95DC File Offset: 0x008E77DC
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

		// Token: 0x0400EB8D RID: 60301
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Scene/NewGacha/BP/BP_UpdateInteract.BP_UpdateInteract_C:ResultKakaluo__DelegateSignature";
	}
}
