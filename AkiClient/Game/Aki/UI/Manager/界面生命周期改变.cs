using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.UI.Manager
{
	// Token: 0x020039AC RID: 14764
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class 界面生命周期改变 : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x0601DCDF RID: 122079 RVA: 0x008E139C File Offset: 0x008DF59C
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return 界面生命周期改变.StaticFunctionPtr();
		}

		// Token: 0x0601DCE0 RID: 122080 RVA: 0x008E13A8 File Offset: 0x008DF5A8
		private static IntPtr StaticFunctionPtr()
		{
			if (BP_EventManager_C.__界面生命周期改变__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				BP_EventManager_C.__界面生命周期改变__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/UI/Manager/BP_EventManager.BP_EventManager_C:界面生命周期改变__DelegateSignature");
			}
			return BP_EventManager_C.__界面生命周期改变__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x0601DCE1 RID: 122081 RVA: 0x008E13CB File Offset: 0x008DF5CB
		public 界面生命周期改变()
		{
		}

		// Token: 0x0601DCE2 RID: 122082 RVA: 0x008E13D3 File Offset: 0x008DF5D3
		[NullableContext(2)]
		public 界面生命周期改变(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0601DCE3 RID: 122083 RVA: 0x008E13DD File Offset: 0x008DF5DD
		public 界面生命周期改变(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0601DCE4 RID: 122084 RVA: 0x008E13E8 File Offset: 0x008DF5E8
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action<byte, UObject>) ?? ((Action<byte, UObject>)Delegate.CreateDelegate(typeof(Action<byte, UObject>), Callback.Target, Callback.Method)));
		}

		// Token: 0x0601DCE5 RID: 122085 RVA: 0x008E141A File Offset: 0x008DF61A
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add([Nullable(new byte[]
		{
			1,
			2
		})] Action<byte, UObject> Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x0601DCE6 RID: 122086 RVA: 0x008E1429 File Offset: 0x008DF629
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove([Nullable(new byte[]
		{
			1,
			2
		})] Action<byte, UObject> Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x0601DCE7 RID: 122087 RVA: 0x008E1434 File Offset: 0x008DF634
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void Broadcast(byte 生命周期类型, UObject 界面实例)
		{
			界面生命周期改变.__界面生命周期改变_DelegateParams* ptr = stackalloc 界面生命周期改变.__界面生命周期改变_DelegateParams[(UIntPtr)31] + 15L / (long)sizeof(界面生命周期改变.__界面生命周期改变_DelegateParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(界面生命周期改变.StaticFunctionPtr(), (void*)ptr, 1);
			ptr->生命周期类型 = 生命周期类型;
			ptr->界面实例 = ((界面实例 != null) ? 界面实例.NativePtr : IntPtr.Zero);
			base.BroadcastInternal((void*)ptr);
		}

		// Token: 0x0601DCE8 RID: 122088 RVA: 0x008E1488 File Offset: 0x008DF688
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveOptimization)]
		protected unsafe static void OnScriptCallback(IntPtr __Handle, byte* __Parameters)
		{
			object target = GCHandle.FromIntPtr(__Handle).Target;
			Action<byte, UObject> action = target as Action<byte, UObject>;
			if (action == null)
			{
				throw new ArgumentException((target != null) ? target.GetType().ToString() : null);
			}
			UObject orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<UObject>(((界面生命周期改变.__界面生命周期改变_DelegateParams*)__Parameters)->界面实例);
			action(((界面生命周期改变.__界面生命周期改变_DelegateParams*)__Parameters)->生命周期类型, orCreateUObjectByNativePointer);
		}

		// Token: 0x0400E97A RID: 59770
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/UI/Manager/BP_EventManager.BP_EventManager_C:界面生命周期改变__DelegateSignature";

		// Token: 0x020096D6 RID: 38614
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __界面生命周期改变_DelegateParams
		{
			// Token: 0x04031BBF RID: 203711
			[FieldOffset(0)]
			public byte 生命周期类型;

			// Token: 0x04031BC0 RID: 203712
			[FieldOffset(8)]
			public IntPtr 界面实例;
		}
	}
}
