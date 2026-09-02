using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.UI.Manager
{
	// Token: 0x020039B1 RID: 14769
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class 角色部位血量变化时 : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x0601DD11 RID: 122129 RVA: 0x008E19E9 File Offset: 0x008DFBE9
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return 角色部位血量变化时.StaticFunctionPtr();
		}

		// Token: 0x0601DD12 RID: 122130 RVA: 0x008E19F5 File Offset: 0x008DFBF5
		private static IntPtr StaticFunctionPtr()
		{
			if (BP_EventManager_C.__角色部位血量变化时__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				BP_EventManager_C.__角色部位血量变化时__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/UI/Manager/BP_EventManager.BP_EventManager_C:角色部位血量变化时__DelegateSignature");
			}
			return BP_EventManager_C.__角色部位血量变化时__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x0601DD13 RID: 122131 RVA: 0x008E1A18 File Offset: 0x008DFC18
		public 角色部位血量变化时()
		{
		}

		// Token: 0x0601DD14 RID: 122132 RVA: 0x008E1A20 File Offset: 0x008DFC20
		[NullableContext(2)]
		public 角色部位血量变化时(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0601DD15 RID: 122133 RVA: 0x008E1A2A File Offset: 0x008DFC2A
		public 角色部位血量变化时(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0601DD16 RID: 122134 RVA: 0x008E1A35 File Offset: 0x008DFC35
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action<TsBaseCharacter, FGameplayTag, float, float>) ?? ((Action<TsBaseCharacter, FGameplayTag, float, float>)Delegate.CreateDelegate(typeof(Action<TsBaseCharacter, FGameplayTag, float, float>), Callback.Target, Callback.Method)));
		}

		// Token: 0x0601DD17 RID: 122135 RVA: 0x008E1A67 File Offset: 0x008DFC67
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add([Nullable(new byte[]
		{
			1,
			2
		})] Action<TsBaseCharacter, FGameplayTag, float, float> Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x0601DD18 RID: 122136 RVA: 0x008E1A76 File Offset: 0x008DFC76
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove([Nullable(new byte[]
		{
			1,
			2
		})] Action<TsBaseCharacter, FGameplayTag, float, float> Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x0601DD19 RID: 122137 RVA: 0x008E1A80 File Offset: 0x008DFC80
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void Broadcast(TsBaseCharacter 角色, FGameplayTag 部位Tag, float 变化前血量比例, float 变化后血量比例)
		{
			角色部位血量变化时.__角色部位血量变化时_DelegateParams* ptr = stackalloc 角色部位血量变化时.__角色部位血量变化时_DelegateParams[(UIntPtr)47] + 15L / (long)sizeof(角色部位血量变化时.__角色部位血量变化时_DelegateParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(角色部位血量变化时.StaticFunctionPtr(), (void*)ptr, 1);
			ptr->角色 = ((角色 != null) ? 角色.NativePtr : IntPtr.Zero);
			ptr->部位Tag = 部位Tag;
			ptr->变化前血量比例 = 变化前血量比例;
			ptr->变化后血量比例 = 变化后血量比例;
			base.BroadcastInternal((void*)ptr);
		}

		// Token: 0x0601DD1A RID: 122138 RVA: 0x008E1AE4 File Offset: 0x008DFCE4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveOptimization)]
		protected unsafe static void OnScriptCallback(IntPtr __Handle, byte* __Parameters)
		{
			object target = GCHandle.FromIntPtr(__Handle).Target;
			Action<TsBaseCharacter, FGameplayTag, float, float> action = target as Action<TsBaseCharacter, FGameplayTag, float, float>;
			if (action == null)
			{
				throw new ArgumentException((target != null) ? target.GetType().ToString() : null);
			}
			TsBaseCharacter orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<TsBaseCharacter>(((角色部位血量变化时.__角色部位血量变化时_DelegateParams*)__Parameters)->角色);
			action(orCreateUObjectByNativePointer, ((角色部位血量变化时.__角色部位血量变化时_DelegateParams*)__Parameters)->部位Tag, ((角色部位血量变化时.__角色部位血量变化时_DelegateParams*)__Parameters)->变化前血量比例, ((角色部位血量变化时.__角色部位血量变化时_DelegateParams*)__Parameters)->变化后血量比例);
		}

		// Token: 0x0400E97F RID: 59775
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/UI/Manager/BP_EventManager.BP_EventManager_C:角色部位血量变化时__DelegateSignature";

		// Token: 0x020096DA RID: 38618
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __角色部位血量变化时_DelegateParams
		{
			// Token: 0x04031BCA RID: 203722
			[FieldOffset(0)]
			public IntPtr 角色;

			// Token: 0x04031BCB RID: 203723
			[FieldOffset(8)]
			public FGameplayTag 部位Tag;

			// Token: 0x04031BCC RID: 203724
			[FieldOffset(20)]
			public float 变化前血量比例;

			// Token: 0x04031BCD RID: 203725
			[FieldOffset(24)]
			public float 变化后血量比例;
		}
	}
}
