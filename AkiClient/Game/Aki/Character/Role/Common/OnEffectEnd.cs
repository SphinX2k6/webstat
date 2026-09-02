using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Character.Role.Common
{
	// Token: 0x02004000 RID: 16384
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class OnEffectEnd : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x0602A87B RID: 174203 RVA: 0x00A5C116 File Offset: 0x00A5A316
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return OnEffectEnd.StaticFunctionPtr();
		}

		// Token: 0x0602A87C RID: 174204 RVA: 0x00A5C122 File Offset: 0x00A5A322
		private static IntPtr StaticFunctionPtr()
		{
			if (ABP_PerformanceRole_C.__OnEffectEnd__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				ABP_PerformanceRole_C.__OnEffectEnd__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/Character/Role/Common/ABP_PerformanceRole.ABP_PerformanceRole_C:OnEffectEnd__DelegateSignature");
			}
			return ABP_PerformanceRole_C.__OnEffectEnd__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x0602A87D RID: 174205 RVA: 0x00A5C145 File Offset: 0x00A5A345
		public OnEffectEnd()
		{
		}

		// Token: 0x0602A87E RID: 174206 RVA: 0x00A5C14D File Offset: 0x00A5A34D
		[NullableContext(2)]
		public OnEffectEnd(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602A87F RID: 174207 RVA: 0x00A5C157 File Offset: 0x00A5A357
		public OnEffectEnd(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602A880 RID: 174208 RVA: 0x00A5C162 File Offset: 0x00A5A362
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action) ?? ((Action)Delegate.CreateDelegate(typeof(Action), Callback.Target, Callback.Method)));
		}

		// Token: 0x0602A881 RID: 174209 RVA: 0x00A5C194 File Offset: 0x00A5A394
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add(Action Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x0602A882 RID: 174210 RVA: 0x00A5C1A3 File Offset: 0x00A5A3A3
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove(Action Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x0602A883 RID: 174211 RVA: 0x00A5C1AC File Offset: 0x00A5A3AC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Broadcast()
		{
			base.BroadcastInternal(null);
		}

		// Token: 0x0602A884 RID: 174212 RVA: 0x00A5C1B8 File Offset: 0x00A5A3B8
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

		// Token: 0x0401720E RID: 94734
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Character/Role/Common/ABP_PerformanceRole.ABP_PerformanceRole_C:OnEffectEnd__DelegateSignature";
	}
}
