using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.UI.Manager
{
	// Token: 0x020039A9 RID: 14761
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class 材质播放结束时 : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x0601DCC1 RID: 122049 RVA: 0x008E0FE2 File Offset: 0x008DF1E2
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return 材质播放结束时.StaticFunctionPtr();
		}

		// Token: 0x0601DCC2 RID: 122050 RVA: 0x008E0FEE File Offset: 0x008DF1EE
		private static IntPtr StaticFunctionPtr()
		{
			if (BP_EventManager_C.__材质播放结束时__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				BP_EventManager_C.__材质播放结束时__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/UI/Manager/BP_EventManager.BP_EventManager_C:材质播放结束时__DelegateSignature");
			}
			return BP_EventManager_C.__材质播放结束时__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x0601DCC3 RID: 122051 RVA: 0x008E1011 File Offset: 0x008DF211
		public 材质播放结束时()
		{
		}

		// Token: 0x0601DCC4 RID: 122052 RVA: 0x008E1019 File Offset: 0x008DF219
		[NullableContext(2)]
		public 材质播放结束时(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0601DCC5 RID: 122053 RVA: 0x008E1023 File Offset: 0x008DF223
		public 材质播放结束时(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0601DCC6 RID: 122054 RVA: 0x008E102E File Offset: 0x008DF22E
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action<int>) ?? ((Action<int>)Delegate.CreateDelegate(typeof(Action<int>), Callback.Target, Callback.Method)));
		}

		// Token: 0x0601DCC7 RID: 122055 RVA: 0x008E1060 File Offset: 0x008DF260
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add(Action<int> Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x0601DCC8 RID: 122056 RVA: 0x008E106F File Offset: 0x008DF26F
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove(Action<int> Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x0601DCC9 RID: 122057 RVA: 0x008E1078 File Offset: 0x008DF278
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void Broadcast(int 材质ID)
		{
			材质播放结束时.__材质播放结束时_DelegateParams* ptr = stackalloc 材质播放结束时.__材质播放结束时_DelegateParams[(UIntPtr)19] + 15L / (long)sizeof(材质播放结束时.__材质播放结束时_DelegateParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(材质播放结束时.StaticFunctionPtr(), (void*)ptr, 1);
			ptr->材质ID = 材质ID;
			base.BroadcastInternal((void*)ptr);
		}

		// Token: 0x0601DCCA RID: 122058 RVA: 0x008E10B4 File Offset: 0x008DF2B4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveOptimization)]
		protected unsafe static void OnScriptCallback(IntPtr __Handle, byte* __Parameters)
		{
			object target = GCHandle.FromIntPtr(__Handle).Target;
			Action<int> action = target as Action<int>;
			if (action == null)
			{
				throw new ArgumentException((target != null) ? target.GetType().ToString() : null);
			}
			action(((材质播放结束时.__材质播放结束时_DelegateParams*)__Parameters)->材质ID);
		}

		// Token: 0x0400E977 RID: 59767
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/UI/Manager/BP_EventManager.BP_EventManager_C:材质播放结束时__DelegateSignature";

		// Token: 0x020096D3 RID: 38611
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __材质播放结束时_DelegateParams
		{
			// Token: 0x04031BB9 RID: 203705
			[FieldOffset(0)]
			public int 材质ID;
		}
	}
}
