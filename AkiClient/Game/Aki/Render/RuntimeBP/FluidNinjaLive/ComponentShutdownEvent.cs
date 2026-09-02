using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Render.RuntimeBP.FluidNinjaLive
{
	// Token: 0x02003CF2 RID: 15602
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class ComponentShutdownEvent : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x06025487 RID: 152711 RVA: 0x009B631A File Offset: 0x009B451A
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return ComponentShutdownEvent.StaticFunctionPtr();
		}

		// Token: 0x06025488 RID: 152712 RVA: 0x009B6326 File Offset: 0x009B4526
		private static IntPtr StaticFunctionPtr()
		{
			if (NinjaLiveComponent_C.__ComponentShutdownEvent__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				NinjaLiveComponent_C.__ComponentShutdownEvent__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/Render/RuntimeBP/FluidNinjaLive/NinjaLiveComponent.NinjaLiveComponent_C:ComponentShutdownEvent__DelegateSignature");
			}
			return NinjaLiveComponent_C.__ComponentShutdownEvent__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x06025489 RID: 152713 RVA: 0x009B6349 File Offset: 0x009B4549
		public ComponentShutdownEvent()
		{
		}

		// Token: 0x0602548A RID: 152714 RVA: 0x009B6351 File Offset: 0x009B4551
		[NullableContext(2)]
		public ComponentShutdownEvent(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602548B RID: 152715 RVA: 0x009B635B File Offset: 0x009B455B
		public ComponentShutdownEvent(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602548C RID: 152716 RVA: 0x009B6366 File Offset: 0x009B4566
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action) ?? ((Action)Delegate.CreateDelegate(typeof(Action), Callback.Target, Callback.Method)));
		}

		// Token: 0x0602548D RID: 152717 RVA: 0x009B6398 File Offset: 0x009B4598
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add(Action Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x0602548E RID: 152718 RVA: 0x009B63A7 File Offset: 0x009B45A7
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove(Action Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x0602548F RID: 152719 RVA: 0x009B63B0 File Offset: 0x009B45B0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Broadcast()
		{
			base.BroadcastInternal(null);
		}

		// Token: 0x06025490 RID: 152720 RVA: 0x009B63BC File Offset: 0x009B45BC
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

		// Token: 0x04013349 RID: 78665
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/FluidNinjaLive/NinjaLiveComponent.NinjaLiveComponent_C:ComponentShutdownEvent__DelegateSignature";
	}
}
