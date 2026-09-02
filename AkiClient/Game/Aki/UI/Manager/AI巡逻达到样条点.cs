using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.UI.Manager
{
	// Token: 0x0200398F RID: 14735
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class AI巡逻达到样条点 : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x0601DB7D RID: 121725 RVA: 0x008DE638 File Offset: 0x008DC838
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return AI巡逻达到样条点.StaticFunctionPtr();
		}

		// Token: 0x0601DB7E RID: 121726 RVA: 0x008DE644 File Offset: 0x008DC844
		private static IntPtr StaticFunctionPtr()
		{
			if (BP_EventManager_C.__AI巡逻达到样条点__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				BP_EventManager_C.__AI巡逻达到样条点__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/UI/Manager/BP_EventManager.BP_EventManager_C:AI巡逻达到样条点__DelegateSignature");
			}
			return BP_EventManager_C.__AI巡逻达到样条点__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x0601DB7F RID: 121727 RVA: 0x008DE667 File Offset: 0x008DC867
		public AI巡逻达到样条点()
		{
		}

		// Token: 0x0601DB80 RID: 121728 RVA: 0x008DE66F File Offset: 0x008DC86F
		[NullableContext(2)]
		public AI巡逻达到样条点(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0601DB81 RID: 121729 RVA: 0x008DE679 File Offset: 0x008DC879
		public AI巡逻达到样条点(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0601DB82 RID: 121730 RVA: 0x008DE684 File Offset: 0x008DC884
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action<TsBaseCharacter, int>) ?? ((Action<TsBaseCharacter, int>)Delegate.CreateDelegate(typeof(Action<TsBaseCharacter, int>), Callback.Target, Callback.Method)));
		}

		// Token: 0x0601DB83 RID: 121731 RVA: 0x008DE6B6 File Offset: 0x008DC8B6
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add([Nullable(new byte[]
		{
			1,
			2
		})] Action<TsBaseCharacter, int> Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x0601DB84 RID: 121732 RVA: 0x008DE6C5 File Offset: 0x008DC8C5
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove([Nullable(new byte[]
		{
			1,
			2
		})] Action<TsBaseCharacter, int> Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x0601DB85 RID: 121733 RVA: 0x008DE6D0 File Offset: 0x008DC8D0
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void Broadcast(TsBaseCharacter 角色, int index)
		{
			AI巡逻达到样条点.__AI巡逻达到样条点_DelegateParams* ptr = stackalloc AI巡逻达到样条点.__AI巡逻达到样条点_DelegateParams[(UIntPtr)31] + 15L / (long)sizeof(AI巡逻达到样条点.__AI巡逻达到样条点_DelegateParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(AI巡逻达到样条点.StaticFunctionPtr(), (void*)ptr, 1);
			ptr->角色 = ((角色 != null) ? 角色.NativePtr : IntPtr.Zero);
			ptr->index = index;
			base.BroadcastInternal((void*)ptr);
		}

		// Token: 0x0601DB86 RID: 121734 RVA: 0x008DE724 File Offset: 0x008DC924
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveOptimization)]
		protected unsafe static void OnScriptCallback(IntPtr __Handle, byte* __Parameters)
		{
			object target = GCHandle.FromIntPtr(__Handle).Target;
			Action<TsBaseCharacter, int> action = target as Action<TsBaseCharacter, int>;
			if (action == null)
			{
				throw new ArgumentException((target != null) ? target.GetType().ToString() : null);
			}
			TsBaseCharacter orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<TsBaseCharacter>(((AI巡逻达到样条点.__AI巡逻达到样条点_DelegateParams*)__Parameters)->角色);
			action(orCreateUObjectByNativePointer, ((AI巡逻达到样条点.__AI巡逻达到样条点_DelegateParams*)__Parameters)->index);
		}

		// Token: 0x0400E8F2 RID: 59634
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/UI/Manager/BP_EventManager.BP_EventManager_C:AI巡逻达到样条点__DelegateSignature";

		// Token: 0x020096C1 RID: 38593
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __AI巡逻达到样条点_DelegateParams
		{
			// Token: 0x04031B99 RID: 203673
			[FieldOffset(0)]
			public IntPtr 角色;

			// Token: 0x04031B9A RID: 203674
			[FieldOffset(8)]
			public int index;
		}
	}
}
