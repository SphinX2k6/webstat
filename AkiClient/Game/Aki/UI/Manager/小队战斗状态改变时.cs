using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.UI.Manager
{
	// Token: 0x0200399A RID: 14746
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class 小队战斗状态改变时 : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x0601DC2B RID: 121899 RVA: 0x008DFECB File Offset: 0x008DE0CB
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return 小队战斗状态改变时.StaticFunctionPtr();
		}

		// Token: 0x0601DC2C RID: 121900 RVA: 0x008DFED7 File Offset: 0x008DE0D7
		private static IntPtr StaticFunctionPtr()
		{
			if (BP_EventManager_C.__小队战斗状态改变时__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				BP_EventManager_C.__小队战斗状态改变时__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/UI/Manager/BP_EventManager.BP_EventManager_C:小队战斗状态改变时__DelegateSignature");
			}
			return BP_EventManager_C.__小队战斗状态改变时__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x0601DC2D RID: 121901 RVA: 0x008DFEFA File Offset: 0x008DE0FA
		public 小队战斗状态改变时()
		{
		}

		// Token: 0x0601DC2E RID: 121902 RVA: 0x008DFF02 File Offset: 0x008DE102
		[NullableContext(2)]
		public 小队战斗状态改变时(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0601DC2F RID: 121903 RVA: 0x008DFF0C File Offset: 0x008DE10C
		public 小队战斗状态改变时(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0601DC30 RID: 121904 RVA: 0x008DFF17 File Offset: 0x008DE117
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action<bool>) ?? ((Action<bool>)Delegate.CreateDelegate(typeof(Action<bool>), Callback.Target, Callback.Method)));
		}

		// Token: 0x0601DC31 RID: 121905 RVA: 0x008DFF49 File Offset: 0x008DE149
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add(Action<bool> Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x0601DC32 RID: 121906 RVA: 0x008DFF58 File Offset: 0x008DE158
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove(Action<bool> Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x0601DC33 RID: 121907 RVA: 0x008DFF64 File Offset: 0x008DE164
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void Broadcast(bool 是否进入战斗)
		{
			小队战斗状态改变时.__小队战斗状态改变时_DelegateParams* ptr = stackalloc 小队战斗状态改变时.__小队战斗状态改变时_DelegateParams[(UIntPtr)16] + 15L / (long)sizeof(小队战斗状态改变时.__小队战斗状态改变时_DelegateParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(小队战斗状态改变时.StaticFunctionPtr(), (void*)ptr, 1);
			ptr->是否进入战斗 = 是否进入战斗;
			base.BroadcastInternal((void*)ptr);
		}

		// Token: 0x0601DC34 RID: 121908 RVA: 0x008DFFA0 File Offset: 0x008DE1A0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveOptimization)]
		protected unsafe static void OnScriptCallback(IntPtr __Handle, byte* __Parameters)
		{
			object target = GCHandle.FromIntPtr(__Handle).Target;
			Action<bool> action = target as Action<bool>;
			if (action == null)
			{
				throw new ArgumentException((target != null) ? target.GetType().ToString() : null);
			}
			action(((小队战斗状态改变时.__小队战斗状态改变时_DelegateParams*)__Parameters)->是否进入战斗);
		}

		// Token: 0x0400E968 RID: 59752
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/UI/Manager/BP_EventManager.BP_EventManager_C:小队战斗状态改变时__DelegateSignature";

		// Token: 0x020096C8 RID: 38600
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected ref struct __小队战斗状态改变时_DelegateParams
		{
			// Token: 0x04031BA9 RID: 203689
			[FieldOffset(0)]
			public bool 是否进入战斗;
		}
	}
}
