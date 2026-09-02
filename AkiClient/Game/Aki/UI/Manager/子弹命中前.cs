using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.UI.Manager
{
	// Token: 0x02003998 RID: 14744
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class 子弹命中前 : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x0601DC17 RID: 121879 RVA: 0x008DFC3F File Offset: 0x008DDE3F
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return 子弹命中前.StaticFunctionPtr();
		}

		// Token: 0x0601DC18 RID: 121880 RVA: 0x008DFC4B File Offset: 0x008DDE4B
		private static IntPtr StaticFunctionPtr()
		{
			if (BP_EventManager_C.__子弹命中前__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				BP_EventManager_C.__子弹命中前__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/UI/Manager/BP_EventManager.BP_EventManager_C:子弹命中前__DelegateSignature");
			}
			return BP_EventManager_C.__子弹命中前__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x0601DC19 RID: 121881 RVA: 0x008DFC6E File Offset: 0x008DDE6E
		public 子弹命中前()
		{
		}

		// Token: 0x0601DC1A RID: 121882 RVA: 0x008DFC76 File Offset: 0x008DDE76
		[NullableContext(2)]
		public 子弹命中前(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0601DC1B RID: 121883 RVA: 0x008DFC80 File Offset: 0x008DDE80
		public 子弹命中前(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0601DC1C RID: 121884 RVA: 0x008DFC8B File Offset: 0x008DDE8B
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action<int, int>) ?? ((Action<int, int>)Delegate.CreateDelegate(typeof(Action<int, int>), Callback.Target, Callback.Method)));
		}

		// Token: 0x0601DC1D RID: 121885 RVA: 0x008DFCBD File Offset: 0x008DDEBD
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add(Action<int, int> Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x0601DC1E RID: 121886 RVA: 0x008DFCCC File Offset: 0x008DDECC
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove(Action<int, int> Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x0601DC1F RID: 121887 RVA: 0x008DFCD8 File Offset: 0x008DDED8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void Broadcast(int BulletId, int EntityId)
		{
			子弹命中前.__子弹命中前_DelegateParams* ptr = stackalloc 子弹命中前.__子弹命中前_DelegateParams[(UIntPtr)23] + 15L / (long)sizeof(子弹命中前.__子弹命中前_DelegateParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(子弹命中前.StaticFunctionPtr(), (void*)ptr, 1);
			ptr->BulletId = BulletId;
			ptr->EntityId = EntityId;
			base.BroadcastInternal((void*)ptr);
		}

		// Token: 0x0601DC20 RID: 121888 RVA: 0x008DFD1C File Offset: 0x008DDF1C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveOptimization)]
		protected unsafe static void OnScriptCallback(IntPtr __Handle, byte* __Parameters)
		{
			object target = GCHandle.FromIntPtr(__Handle).Target;
			Action<int, int> action = target as Action<int, int>;
			if (action == null)
			{
				throw new ArgumentException((target != null) ? target.GetType().ToString() : null);
			}
			action(((子弹命中前.__子弹命中前_DelegateParams*)__Parameters)->BulletId, ((子弹命中前.__子弹命中前_DelegateParams*)__Parameters)->EntityId);
		}

		// Token: 0x0400E966 RID: 59750
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/UI/Manager/BP_EventManager.BP_EventManager_C:子弹命中前__DelegateSignature";

		// Token: 0x020096C6 RID: 38598
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __子弹命中前_DelegateParams
		{
			// Token: 0x04031BA3 RID: 203683
			[FieldOffset(0)]
			public int BulletId;

			// Token: 0x04031BA4 RID: 203684
			[FieldOffset(4)]
			public int EntityId;
		}
	}
}
