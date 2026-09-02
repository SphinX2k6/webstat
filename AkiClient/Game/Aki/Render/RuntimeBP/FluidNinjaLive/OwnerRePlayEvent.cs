using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Render.RuntimeBP.FluidNinjaLive
{
	// Token: 0x02003CFA RID: 15610
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class OwnerRePlayEvent : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x06025953 RID: 153939 RVA: 0x009BE1D3 File Offset: 0x009BC3D3
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return OwnerRePlayEvent.StaticFunctionPtr();
		}

		// Token: 0x06025954 RID: 153940 RVA: 0x009BE1DF File Offset: 0x009BC3DF
		private static IntPtr StaticFunctionPtr()
		{
			if (NinjaLive_C.__OwnerRePlayEvent__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				NinjaLive_C.__OwnerRePlayEvent__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/Render/RuntimeBP/FluidNinjaLive/NinjaLive.NinjaLive_C:OwnerRePlayEvent__DelegateSignature");
			}
			return NinjaLive_C.__OwnerRePlayEvent__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x06025955 RID: 153941 RVA: 0x009BE202 File Offset: 0x009BC402
		public OwnerRePlayEvent()
		{
		}

		// Token: 0x06025956 RID: 153942 RVA: 0x009BE20A File Offset: 0x009BC40A
		[NullableContext(2)]
		public OwnerRePlayEvent(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06025957 RID: 153943 RVA: 0x009BE214 File Offset: 0x009BC414
		public OwnerRePlayEvent(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06025958 RID: 153944 RVA: 0x009BE21F File Offset: 0x009BC41F
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action) ?? ((Action)Delegate.CreateDelegate(typeof(Action), Callback.Target, Callback.Method)));
		}

		// Token: 0x06025959 RID: 153945 RVA: 0x009BE251 File Offset: 0x009BC451
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add(Action Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x0602595A RID: 153946 RVA: 0x009BE260 File Offset: 0x009BC460
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove(Action Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x0602595B RID: 153947 RVA: 0x009BE269 File Offset: 0x009BC469
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Broadcast()
		{
			base.BroadcastInternal(null);
		}

		// Token: 0x0602595C RID: 153948 RVA: 0x009BE274 File Offset: 0x009BC474
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

		// Token: 0x0401363D RID: 79421
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/FluidNinjaLive/NinjaLive.NinjaLive_C:OwnerRePlayEvent__DelegateSignature";
	}
}
