using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.UI.Manager
{
	// Token: 0x020039A8 RID: 14760
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class 抓取目标成功时 : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x0601DCB7 RID: 122039 RVA: 0x008E0E8A File Offset: 0x008DF08A
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return 抓取目标成功时.StaticFunctionPtr();
		}

		// Token: 0x0601DCB8 RID: 122040 RVA: 0x008E0E96 File Offset: 0x008DF096
		private static IntPtr StaticFunctionPtr()
		{
			if (BP_EventManager_C.__抓取目标成功时__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				BP_EventManager_C.__抓取目标成功时__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/UI/Manager/BP_EventManager.BP_EventManager_C:抓取目标成功时__DelegateSignature");
			}
			return BP_EventManager_C.__抓取目标成功时__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x0601DCB9 RID: 122041 RVA: 0x008E0EB9 File Offset: 0x008DF0B9
		public 抓取目标成功时()
		{
		}

		// Token: 0x0601DCBA RID: 122042 RVA: 0x008E0EC1 File Offset: 0x008DF0C1
		[NullableContext(2)]
		public 抓取目标成功时(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0601DCBB RID: 122043 RVA: 0x008E0ECB File Offset: 0x008DF0CB
		public 抓取目标成功时(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0601DCBC RID: 122044 RVA: 0x008E0ED6 File Offset: 0x008DF0D6
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action<int, int, string>) ?? ((Action<int, int, string>)Delegate.CreateDelegate(typeof(Action<int, int, string>), Callback.Target, Callback.Method)));
		}

		// Token: 0x0601DCBD RID: 122045 RVA: 0x008E0F08 File Offset: 0x008DF108
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add(Action<int, int, string> Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x0601DCBE RID: 122046 RVA: 0x008E0F17 File Offset: 0x008DF117
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove(Action<int, int, string> Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x0601DCBF RID: 122047 RVA: 0x008E0F20 File Offset: 0x008DF120
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void Broadcast(int RoleEntityId, int CaughtEntityId, string CaughtId)
		{
			抓取目标成功时.__抓取目标成功时_DelegateParams* ptr = stackalloc 抓取目标成功时.__抓取目标成功时_DelegateParams[(UIntPtr)39] + 15L / (long)sizeof(抓取目标成功时.__抓取目标成功时_DelegateParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(抓取目标成功时.StaticFunctionPtr(), (void*)ptr, 1);
			ptr->RoleEntityId = RoleEntityId;
			ptr->CaughtEntityId = CaughtEntityId;
			FString.CopyFrom((void*)(&ptr->CaughtId), CaughtId);
			base.BroadcastInternal((void*)ptr);
			UnrealReflectionUtils.DestroyStruct(BP_EventManager_C.__抓取目标成功时__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0601DCC0 RID: 122048 RVA: 0x008E0F84 File Offset: 0x008DF184
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveOptimization)]
		protected unsafe static void OnScriptCallback(IntPtr __Handle, byte* __Parameters)
		{
			object target = GCHandle.FromIntPtr(__Handle).Target;
			Action<int, int, string> action = target as Action<int, int, string>;
			if (action == null)
			{
				throw new ArgumentException((target != null) ? target.GetType().ToString() : null);
			}
			string arg = FString.ToString((void*)(&((抓取目标成功时.__抓取目标成功时_DelegateParams*)__Parameters)->CaughtId));
			action(((抓取目标成功时.__抓取目标成功时_DelegateParams*)__Parameters)->RoleEntityId, ((抓取目标成功时.__抓取目标成功时_DelegateParams*)__Parameters)->CaughtEntityId, arg);
		}

		// Token: 0x0400E976 RID: 59766
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/UI/Manager/BP_EventManager.BP_EventManager_C:抓取目标成功时__DelegateSignature";

		// Token: 0x020096D2 RID: 38610
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __抓取目标成功时_DelegateParams
		{
			// Token: 0x04031BB6 RID: 203702
			[FieldOffset(0)]
			public int RoleEntityId;

			// Token: 0x04031BB7 RID: 203703
			[FieldOffset(4)]
			public int CaughtEntityId;

			// Token: 0x04031BB8 RID: 203704
			[FieldOffset(8)]
			public FString CaughtId;
		}
	}
}
