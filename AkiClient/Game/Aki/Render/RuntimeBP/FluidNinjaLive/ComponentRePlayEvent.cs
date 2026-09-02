using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Render.RuntimeBP.FluidNinjaLive
{
	// Token: 0x02003CF1 RID: 15601
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class ComponentRePlayEvent : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x0602547D RID: 152701 RVA: 0x009B6235 File Offset: 0x009B4435
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return ComponentRePlayEvent.StaticFunctionPtr();
		}

		// Token: 0x0602547E RID: 152702 RVA: 0x009B6241 File Offset: 0x009B4441
		private static IntPtr StaticFunctionPtr()
		{
			if (NinjaLiveComponent_C.__ComponentRePlayEvent__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				NinjaLiveComponent_C.__ComponentRePlayEvent__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/Render/RuntimeBP/FluidNinjaLive/NinjaLiveComponent.NinjaLiveComponent_C:ComponentRePlayEvent__DelegateSignature");
			}
			return NinjaLiveComponent_C.__ComponentRePlayEvent__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x0602547F RID: 152703 RVA: 0x009B6264 File Offset: 0x009B4464
		public ComponentRePlayEvent()
		{
		}

		// Token: 0x06025480 RID: 152704 RVA: 0x009B626C File Offset: 0x009B446C
		[NullableContext(2)]
		public ComponentRePlayEvent(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06025481 RID: 152705 RVA: 0x009B6276 File Offset: 0x009B4476
		public ComponentRePlayEvent(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06025482 RID: 152706 RVA: 0x009B6281 File Offset: 0x009B4481
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action) ?? ((Action)Delegate.CreateDelegate(typeof(Action), Callback.Target, Callback.Method)));
		}

		// Token: 0x06025483 RID: 152707 RVA: 0x009B62B3 File Offset: 0x009B44B3
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add(Action Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x06025484 RID: 152708 RVA: 0x009B62C2 File Offset: 0x009B44C2
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove(Action Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x06025485 RID: 152709 RVA: 0x009B62CB File Offset: 0x009B44CB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Broadcast()
		{
			base.BroadcastInternal(null);
		}

		// Token: 0x06025486 RID: 152710 RVA: 0x009B62D8 File Offset: 0x009B44D8
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

		// Token: 0x04013348 RID: 78664
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/FluidNinjaLive/NinjaLiveComponent.NinjaLiveComponent_C:ComponentRePlayEvent__DelegateSignature";
	}
}
