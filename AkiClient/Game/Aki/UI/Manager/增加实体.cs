using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.UI.Manager
{
	// Token: 0x02003997 RID: 14743
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class 增加实体 : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x0601DC0D RID: 121869 RVA: 0x008DFAFD File Offset: 0x008DDCFD
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return 增加实体.StaticFunctionPtr();
		}

		// Token: 0x0601DC0E RID: 121870 RVA: 0x008DFB09 File Offset: 0x008DDD09
		private static IntPtr StaticFunctionPtr()
		{
			if (BP_EventManager_C.__增加实体__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				BP_EventManager_C.__增加实体__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/UI/Manager/BP_EventManager.BP_EventManager_C:增加实体__DelegateSignature");
			}
			return BP_EventManager_C.__增加实体__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x0601DC0F RID: 121871 RVA: 0x008DFB2C File Offset: 0x008DDD2C
		public 增加实体()
		{
		}

		// Token: 0x0601DC10 RID: 121872 RVA: 0x008DFB34 File Offset: 0x008DDD34
		[NullableContext(2)]
		public 增加实体(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0601DC11 RID: 121873 RVA: 0x008DFB3E File Offset: 0x008DDD3E
		public 增加实体(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0601DC12 RID: 121874 RVA: 0x008DFB49 File Offset: 0x008DDD49
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action<int, AActor>) ?? ((Action<int, AActor>)Delegate.CreateDelegate(typeof(Action<int, AActor>), Callback.Target, Callback.Method)));
		}

		// Token: 0x0601DC13 RID: 121875 RVA: 0x008DFB7B File Offset: 0x008DDD7B
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add([Nullable(new byte[]
		{
			1,
			2
		})] Action<int, AActor> Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x0601DC14 RID: 121876 RVA: 0x008DFB8A File Offset: 0x008DDD8A
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove([Nullable(new byte[]
		{
			1,
			2
		})] Action<int, AActor> Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x0601DC15 RID: 121877 RVA: 0x008DFB94 File Offset: 0x008DDD94
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void Broadcast(int 实体ID, AActor Entity)
		{
			增加实体.__增加实体_DelegateParams* ptr = stackalloc 增加实体.__增加实体_DelegateParams[(UIntPtr)31] + 15L / (long)sizeof(增加实体.__增加实体_DelegateParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(增加实体.StaticFunctionPtr(), (void*)ptr, 1);
			ptr->实体ID = 实体ID;
			ptr->Entity = ((Entity != null) ? Entity.NativePtr : IntPtr.Zero);
			base.BroadcastInternal((void*)ptr);
		}

		// Token: 0x0601DC16 RID: 121878 RVA: 0x008DFBE8 File Offset: 0x008DDDE8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveOptimization)]
		protected unsafe static void OnScriptCallback(IntPtr __Handle, byte* __Parameters)
		{
			object target = GCHandle.FromIntPtr(__Handle).Target;
			Action<int, AActor> action = target as Action<int, AActor>;
			if (action == null)
			{
				throw new ArgumentException((target != null) ? target.GetType().ToString() : null);
			}
			AActor orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AActor>(((增加实体.__增加实体_DelegateParams*)__Parameters)->Entity);
			action(((增加实体.__增加实体_DelegateParams*)__Parameters)->实体ID, orCreateUObjectByNativePointer);
		}

		// Token: 0x0400E965 RID: 59749
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/UI/Manager/BP_EventManager.BP_EventManager_C:增加实体__DelegateSignature";

		// Token: 0x020096C5 RID: 38597
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __增加实体_DelegateParams
		{
			// Token: 0x04031BA1 RID: 203681
			[FieldOffset(0)]
			public int 实体ID;

			// Token: 0x04031BA2 RID: 203682
			[FieldOffset(8)]
			public IntPtr Entity;
		}
	}
}
