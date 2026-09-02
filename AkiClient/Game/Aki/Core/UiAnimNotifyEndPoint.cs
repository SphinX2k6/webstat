using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Character.Role.Common.Data.Enum;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Core
{
	// Token: 0x02003F3E RID: 16190
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class UiAnimNotifyEndPoint : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x060286E2 RID: 165602 RVA: 0x00A0A6C6 File Offset: 0x00A088C6
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return UiAnimNotifyEndPoint.StaticFunctionPtr();
		}

		// Token: 0x060286E3 RID: 165603 RVA: 0x00A0A6D2 File Offset: 0x00A088D2
		private static IntPtr StaticFunctionPtr()
		{
			if (BP_UiActorCallBack_C.__UiAnimNotifyEndPoint__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				BP_UiActorCallBack_C.__UiAnimNotifyEndPoint__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/Core/BP_UiActorCallBack.BP_UiActorCallBack_C:UiAnimNotifyEndPoint__DelegateSignature");
			}
			return BP_UiActorCallBack_C.__UiAnimNotifyEndPoint__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x060286E4 RID: 165604 RVA: 0x00A0A6F5 File Offset: 0x00A088F5
		public UiAnimNotifyEndPoint()
		{
		}

		// Token: 0x060286E5 RID: 165605 RVA: 0x00A0A6FD File Offset: 0x00A088FD
		[NullableContext(2)]
		public UiAnimNotifyEndPoint(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x060286E6 RID: 165606 RVA: 0x00A0A707 File Offset: 0x00A08907
		public UiAnimNotifyEndPoint(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x060286E7 RID: 165607 RVA: 0x00A0A712 File Offset: 0x00A08912
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action<TEnumAsByte<EPerformanceRoleState>>) ?? ((Action<TEnumAsByte<EPerformanceRoleState>>)Delegate.CreateDelegate(typeof(Action<TEnumAsByte<EPerformanceRoleState>>), Callback.Target, Callback.Method)));
		}

		// Token: 0x060286E8 RID: 165608 RVA: 0x00A0A744 File Offset: 0x00A08944
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add([Nullable(new byte[]
		{
			1,
			0
		})] Action<TEnumAsByte<EPerformanceRoleState>> Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x060286E9 RID: 165609 RVA: 0x00A0A753 File Offset: 0x00A08953
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove([Nullable(new byte[]
		{
			1,
			0
		})] Action<TEnumAsByte<EPerformanceRoleState>> Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x060286EA RID: 165610 RVA: 0x00A0A75C File Offset: 0x00A0895C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void Broadcast(EPerformanceRoleState RoleState)
		{
			UiAnimNotifyEndPoint.__UiAnimNotifyEndPoint_DelegateParams* ptr = stackalloc UiAnimNotifyEndPoint.__UiAnimNotifyEndPoint_DelegateParams[(UIntPtr)16] + 15L / (long)sizeof(UiAnimNotifyEndPoint.__UiAnimNotifyEndPoint_DelegateParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(UiAnimNotifyEndPoint.StaticFunctionPtr(), (void*)ptr, 1);
			ptr->RoleState = RoleState;
			base.BroadcastInternal((void*)ptr);
		}

		// Token: 0x060286EB RID: 165611 RVA: 0x00A0A7A0 File Offset: 0x00A089A0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveOptimization)]
		protected unsafe static void OnScriptCallback(IntPtr __Handle, byte* __Parameters)
		{
			object target = GCHandle.FromIntPtr(__Handle).Target;
			Action<TEnumAsByte<EPerformanceRoleState>> action = target as Action<TEnumAsByte<EPerformanceRoleState>>;
			if (action == null)
			{
				throw new ArgumentException((target != null) ? target.GetType().ToString() : null);
			}
			action(((UiAnimNotifyEndPoint.__UiAnimNotifyEndPoint_DelegateParams*)__Parameters)->RoleState);
		}

		// Token: 0x0401544C RID: 87116
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Core/BP_UiActorCallBack.BP_UiActorCallBack_C:UiAnimNotifyEndPoint__DelegateSignature";

		// Token: 0x0200A0EE RID: 41198
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected ref struct __UiAnimNotifyEndPoint_DelegateParams
		{
			// Token: 0x04032DB5 RID: 208309
			[FieldOffset(0)]
			public TEnumAsByte<EPerformanceRoleState> RoleState;
		}
	}
}
