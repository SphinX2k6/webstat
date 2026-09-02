using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Render.RuntimeBP.UltraDynamicSky.Blueprints
{
	// Token: 0x02003A12 RID: 14866
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class Sunset : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x0601E642 RID: 124482 RVA: 0x008F4A36 File Offset: 0x008F2C36
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return Sunset.StaticFunctionPtr();
		}

		// Token: 0x0601E643 RID: 124483 RVA: 0x008F4A42 File Offset: 0x008F2C42
		private static IntPtr StaticFunctionPtr()
		{
			if (Ultra_Dynamic_Sky_C.__Sunset__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				Ultra_Dynamic_Sky_C.__Sunset__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/Render/RuntimeBP/UltraDynamicSky/Blueprints/Ultra_Dynamic_Sky.Ultra_Dynamic_Sky_C:Sunset__DelegateSignature");
			}
			return Ultra_Dynamic_Sky_C.__Sunset__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x0601E644 RID: 124484 RVA: 0x008F4A65 File Offset: 0x008F2C65
		public Sunset()
		{
		}

		// Token: 0x0601E645 RID: 124485 RVA: 0x008F4A6D File Offset: 0x008F2C6D
		[NullableContext(2)]
		public Sunset(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0601E646 RID: 124486 RVA: 0x008F4A77 File Offset: 0x008F2C77
		public Sunset(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0601E647 RID: 124487 RVA: 0x008F4A82 File Offset: 0x008F2C82
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action) ?? ((Action)Delegate.CreateDelegate(typeof(Action), Callback.Target, Callback.Method)));
		}

		// Token: 0x0601E648 RID: 124488 RVA: 0x008F4AB4 File Offset: 0x008F2CB4
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add(Action Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x0601E649 RID: 124489 RVA: 0x008F4AC3 File Offset: 0x008F2CC3
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove(Action Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x0601E64A RID: 124490 RVA: 0x008F4ACC File Offset: 0x008F2CCC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Broadcast()
		{
			base.BroadcastInternal(null);
		}

		// Token: 0x0601E64B RID: 124491 RVA: 0x008F4AD8 File Offset: 0x008F2CD8
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

		// Token: 0x0400EF4E RID: 61262
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/UltraDynamicSky/Blueprints/Ultra_Dynamic_Sky.Ultra_Dynamic_Sky_C:Sunset__DelegateSignature";
	}
}
