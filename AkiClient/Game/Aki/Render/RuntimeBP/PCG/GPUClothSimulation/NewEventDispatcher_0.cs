using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.GPUClothSimulation
{
	// Token: 0x02003C1C RID: 15388
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class NewEventDispatcher_0 : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x06023126 RID: 143654 RVA: 0x009779D8 File Offset: 0x00975BD8
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return NewEventDispatcher_0.StaticFunctionPtr();
		}

		// Token: 0x06023127 RID: 143655 RVA: 0x009779E4 File Offset: 0x00975BE4
		private static IntPtr StaticFunctionPtr()
		{
			if (BP_PhysicCloth_v2_C.__NewEventDispatcher_0__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				BP_PhysicCloth_v2_C.__NewEventDispatcher_0__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/Render/RuntimeBP/PCG/GPUClothSimulation/BP_PhysicCloth_v2.BP_PhysicCloth_v2_C:NewEventDispatcher_0__DelegateSignature");
			}
			return BP_PhysicCloth_v2_C.__NewEventDispatcher_0__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x06023128 RID: 143656 RVA: 0x00977A07 File Offset: 0x00975C07
		public NewEventDispatcher_0()
		{
		}

		// Token: 0x06023129 RID: 143657 RVA: 0x00977A0F File Offset: 0x00975C0F
		[NullableContext(2)]
		public NewEventDispatcher_0(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602312A RID: 143658 RVA: 0x00977A19 File Offset: 0x00975C19
		public NewEventDispatcher_0(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602312B RID: 143659 RVA: 0x00977A24 File Offset: 0x00975C24
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action) ?? ((Action)Delegate.CreateDelegate(typeof(Action), Callback.Target, Callback.Method)));
		}

		// Token: 0x0602312C RID: 143660 RVA: 0x00977A56 File Offset: 0x00975C56
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add(Action Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x0602312D RID: 143661 RVA: 0x00977A65 File Offset: 0x00975C65
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove(Action Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x0602312E RID: 143662 RVA: 0x00977A6E File Offset: 0x00975C6E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Broadcast()
		{
			base.BroadcastInternal(null);
		}

		// Token: 0x0602312F RID: 143663 RVA: 0x00977A78 File Offset: 0x00975C78
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

		// Token: 0x04011D42 RID: 73026
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/GPUClothSimulation/BP_PhysicCloth_v2.BP_PhysicCloth_v2_C:NewEventDispatcher_0__DelegateSignature";
	}
}
