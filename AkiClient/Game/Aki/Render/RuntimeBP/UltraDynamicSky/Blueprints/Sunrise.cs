using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Render.RuntimeBP.UltraDynamicSky.Blueprints
{
	// Token: 0x02003A11 RID: 14865
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class Sunrise : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x0601E638 RID: 124472 RVA: 0x008F4954 File Offset: 0x008F2B54
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return Sunrise.StaticFunctionPtr();
		}

		// Token: 0x0601E639 RID: 124473 RVA: 0x008F4960 File Offset: 0x008F2B60
		private static IntPtr StaticFunctionPtr()
		{
			if (Ultra_Dynamic_Sky_C.__Sunrise__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				Ultra_Dynamic_Sky_C.__Sunrise__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/Render/RuntimeBP/UltraDynamicSky/Blueprints/Ultra_Dynamic_Sky.Ultra_Dynamic_Sky_C:Sunrise__DelegateSignature");
			}
			return Ultra_Dynamic_Sky_C.__Sunrise__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x0601E63A RID: 124474 RVA: 0x008F4983 File Offset: 0x008F2B83
		public Sunrise()
		{
		}

		// Token: 0x0601E63B RID: 124475 RVA: 0x008F498B File Offset: 0x008F2B8B
		[NullableContext(2)]
		public Sunrise(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0601E63C RID: 124476 RVA: 0x008F4995 File Offset: 0x008F2B95
		public Sunrise(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0601E63D RID: 124477 RVA: 0x008F49A0 File Offset: 0x008F2BA0
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action) ?? ((Action)Delegate.CreateDelegate(typeof(Action), Callback.Target, Callback.Method)));
		}

		// Token: 0x0601E63E RID: 124478 RVA: 0x008F49D2 File Offset: 0x008F2BD2
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add(Action Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x0601E63F RID: 124479 RVA: 0x008F49E1 File Offset: 0x008F2BE1
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove(Action Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x0601E640 RID: 124480 RVA: 0x008F49EA File Offset: 0x008F2BEA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Broadcast()
		{
			base.BroadcastInternal(null);
		}

		// Token: 0x0601E641 RID: 124481 RVA: 0x008F49F4 File Offset: 0x008F2BF4
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

		// Token: 0x0400EF4D RID: 61261
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/UltraDynamicSky/Blueprints/Ultra_Dynamic_Sky.Ultra_Dynamic_Sky_C:Sunrise__DelegateSignature";
	}
}
