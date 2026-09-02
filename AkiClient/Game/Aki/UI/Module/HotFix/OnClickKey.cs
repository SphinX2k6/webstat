using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.UI.Module.HotFix
{
	// Token: 0x0200397D RID: 14717
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class OnClickKey : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x0601DA75 RID: 121461 RVA: 0x008DC52F File Offset: 0x008DA72F
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return OnClickKey.StaticFunctionPtr();
		}

		// Token: 0x0601DA76 RID: 121462 RVA: 0x008DC53B File Offset: 0x008DA73B
		private static IntPtr StaticFunctionPtr()
		{
			if (HotFixLGUIEventSystemActor_C.__OnClickKey__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				HotFixLGUIEventSystemActor_C.__OnClickKey__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/UI/Module/HotFix/HotFixLGUIEventSystemActor.HotFixLGUIEventSystemActor_C:OnClickKey__DelegateSignature");
			}
			return HotFixLGUIEventSystemActor_C.__OnClickKey__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x0601DA77 RID: 121463 RVA: 0x008DC55E File Offset: 0x008DA75E
		public OnClickKey()
		{
		}

		// Token: 0x0601DA78 RID: 121464 RVA: 0x008DC566 File Offset: 0x008DA766
		[NullableContext(2)]
		public OnClickKey(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0601DA79 RID: 121465 RVA: 0x008DC570 File Offset: 0x008DA770
		public OnClickKey(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0601DA7A RID: 121466 RVA: 0x008DC57B File Offset: 0x008DA77B
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action<FKey, bool>) ?? ((Action<FKey, bool>)Delegate.CreateDelegate(typeof(Action<FKey, bool>), Callback.Target, Callback.Method)));
		}

		// Token: 0x0601DA7B RID: 121467 RVA: 0x008DC5AD File Offset: 0x008DA7AD
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add(Action<FKey, bool> Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x0601DA7C RID: 121468 RVA: 0x008DC5BC File Offset: 0x008DA7BC
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove(Action<FKey, bool> Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x0601DA7D RID: 121469 RVA: 0x008DC5C8 File Offset: 0x008DA7C8
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void Broadcast(FKey KeyCode, bool IsPress)
		{
			OnClickKey.__OnClickKey_DelegateParams* ptr = stackalloc OnClickKey.__OnClickKey_DelegateParams[(UIntPtr)55] + 15L / (long)sizeof(OnClickKey.__OnClickKey_DelegateParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(OnClickKey.StaticFunctionPtr(), (void*)ptr, 1);
			if (KeyCode != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FKey.StaticStruct(), &ptr->KeyCode, KeyCode.NativePtr, 1, false);
			}
			ptr->IsPress = IsPress;
			base.BroadcastInternal((void*)ptr);
			UnrealReflectionUtils.DestroyStruct(HotFixLGUIEventSystemActor_C.__OnClickKey__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0601DA7E RID: 121470 RVA: 0x008DC638 File Offset: 0x008DA838
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveOptimization)]
		protected unsafe static void OnScriptCallback(IntPtr __Handle, byte* __Parameters)
		{
			object target = GCHandle.FromIntPtr(__Handle).Target;
			Action<FKey, bool> action = target as Action<FKey, bool>;
			if (action == null)
			{
				throw new ArgumentException((target != null) ? target.GetType().ToString() : null);
			}
			FKey arg = new FKey(&((OnClickKey.__OnClickKey_DelegateParams*)__Parameters)->KeyCode, true, true);
			action(arg, ((OnClickKey.__OnClickKey_DelegateParams*)__Parameters)->IsPress);
		}

		// Token: 0x0400E85B RID: 59483
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/UI/Module/HotFix/HotFixLGUIEventSystemActor.HotFixLGUIEventSystemActor_C:OnClickKey__DelegateSignature";

		// Token: 0x020096AB RID: 38571
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __OnClickKey_DelegateParams
		{
			// Token: 0x04031B7C RID: 203644
			[FieldOffset(0)]
			public byte KeyCode;

			// Token: 0x04031B7D RID: 203645
			[FieldOffset(32)]
			public bool IsPress;
		}
	}
}
