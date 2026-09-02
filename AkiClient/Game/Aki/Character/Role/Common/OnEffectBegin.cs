using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Character.Role.Common
{
	// Token: 0x02003FFF RID: 16383
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class OnEffectBegin : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x0602A871 RID: 174193 RVA: 0x00A5C032 File Offset: 0x00A5A232
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return OnEffectBegin.StaticFunctionPtr();
		}

		// Token: 0x0602A872 RID: 174194 RVA: 0x00A5C03E File Offset: 0x00A5A23E
		private static IntPtr StaticFunctionPtr()
		{
			if (ABP_PerformanceRole_C.__OnEffectBegin__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				ABP_PerformanceRole_C.__OnEffectBegin__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/Character/Role/Common/ABP_PerformanceRole.ABP_PerformanceRole_C:OnEffectBegin__DelegateSignature");
			}
			return ABP_PerformanceRole_C.__OnEffectBegin__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x0602A873 RID: 174195 RVA: 0x00A5C061 File Offset: 0x00A5A261
		public OnEffectBegin()
		{
		}

		// Token: 0x0602A874 RID: 174196 RVA: 0x00A5C069 File Offset: 0x00A5A269
		[NullableContext(2)]
		public OnEffectBegin(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602A875 RID: 174197 RVA: 0x00A5C073 File Offset: 0x00A5A273
		public OnEffectBegin(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602A876 RID: 174198 RVA: 0x00A5C07E File Offset: 0x00A5A27E
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action) ?? ((Action)Delegate.CreateDelegate(typeof(Action), Callback.Target, Callback.Method)));
		}

		// Token: 0x0602A877 RID: 174199 RVA: 0x00A5C0B0 File Offset: 0x00A5A2B0
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add(Action Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x0602A878 RID: 174200 RVA: 0x00A5C0BF File Offset: 0x00A5A2BF
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove(Action Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x0602A879 RID: 174201 RVA: 0x00A5C0C8 File Offset: 0x00A5A2C8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Broadcast()
		{
			base.BroadcastInternal(null);
		}

		// Token: 0x0602A87A RID: 174202 RVA: 0x00A5C0D4 File Offset: 0x00A5A2D4
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

		// Token: 0x0401720D RID: 94733
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Character/Role/Common/ABP_PerformanceRole.ABP_PerformanceRole_C:OnEffectBegin__DelegateSignature";
	}
}
