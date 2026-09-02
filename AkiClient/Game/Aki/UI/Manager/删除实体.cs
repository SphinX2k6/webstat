using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.UI.Manager
{
	// Token: 0x02003996 RID: 14742
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class 删除实体 : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x0601DC03 RID: 121859 RVA: 0x008DF9CA File Offset: 0x008DDBCA
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return 删除实体.StaticFunctionPtr();
		}

		// Token: 0x0601DC04 RID: 121860 RVA: 0x008DF9D6 File Offset: 0x008DDBD6
		private static IntPtr StaticFunctionPtr()
		{
			if (BP_EventManager_C.__删除实体__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				BP_EventManager_C.__删除实体__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/UI/Manager/BP_EventManager.BP_EventManager_C:删除实体__DelegateSignature");
			}
			return BP_EventManager_C.__删除实体__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x0601DC05 RID: 121861 RVA: 0x008DF9F9 File Offset: 0x008DDBF9
		public 删除实体()
		{
		}

		// Token: 0x0601DC06 RID: 121862 RVA: 0x008DFA01 File Offset: 0x008DDC01
		[NullableContext(2)]
		public 删除实体(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0601DC07 RID: 121863 RVA: 0x008DFA0B File Offset: 0x008DDC0B
		public 删除实体(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0601DC08 RID: 121864 RVA: 0x008DFA16 File Offset: 0x008DDC16
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action<AActor>) ?? ((Action<AActor>)Delegate.CreateDelegate(typeof(Action<AActor>), Callback.Target, Callback.Method)));
		}

		// Token: 0x0601DC09 RID: 121865 RVA: 0x008DFA48 File Offset: 0x008DDC48
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add([Nullable(new byte[]
		{
			1,
			2
		})] Action<AActor> Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x0601DC0A RID: 121866 RVA: 0x008DFA57 File Offset: 0x008DDC57
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove([Nullable(new byte[]
		{
			1,
			2
		})] Action<AActor> Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x0601DC0B RID: 121867 RVA: 0x008DFA60 File Offset: 0x008DDC60
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void Broadcast(AActor 删除的实体)
		{
			删除实体.__删除实体_DelegateParams* ptr = stackalloc 删除实体.__删除实体_DelegateParams[(UIntPtr)23] + 15L / (long)sizeof(删除实体.__删除实体_DelegateParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(删除实体.StaticFunctionPtr(), (void*)ptr, 1);
			ptr->删除的实体 = ((删除的实体 != null) ? 删除的实体.NativePtr : IntPtr.Zero);
			base.BroadcastInternal((void*)ptr);
		}

		// Token: 0x0601DC0C RID: 121868 RVA: 0x008DFAAC File Offset: 0x008DDCAC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveOptimization)]
		protected unsafe static void OnScriptCallback(IntPtr __Handle, byte* __Parameters)
		{
			object target = GCHandle.FromIntPtr(__Handle).Target;
			Action<AActor> action = target as Action<AActor>;
			if (action == null)
			{
				throw new ArgumentException((target != null) ? target.GetType().ToString() : null);
			}
			AActor orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AActor>(((删除实体.__删除实体_DelegateParams*)__Parameters)->删除的实体);
			action(orCreateUObjectByNativePointer);
		}

		// Token: 0x0400E964 RID: 59748
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/UI/Manager/BP_EventManager.BP_EventManager_C:删除实体__DelegateSignature";

		// Token: 0x020096C4 RID: 38596
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __删除实体_DelegateParams
		{
			// Token: 0x04031BA0 RID: 203680
			[FieldOffset(0)]
			public IntPtr 删除的实体;
		}
	}
}
