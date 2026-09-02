using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.UI.Manager
{
	// Token: 0x020039B0 RID: 14768
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class 角色部位弱点打击时 : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x0601DD07 RID: 122119 RVA: 0x008E1883 File Offset: 0x008DFA83
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return 角色部位弱点打击时.StaticFunctionPtr();
		}

		// Token: 0x0601DD08 RID: 122120 RVA: 0x008E188F File Offset: 0x008DFA8F
		private static IntPtr StaticFunctionPtr()
		{
			if (BP_EventManager_C.__角色部位弱点打击时__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				BP_EventManager_C.__角色部位弱点打击时__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/UI/Manager/BP_EventManager.BP_EventManager_C:角色部位弱点打击时__DelegateSignature");
			}
			return BP_EventManager_C.__角色部位弱点打击时__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x0601DD09 RID: 122121 RVA: 0x008E18B2 File Offset: 0x008DFAB2
		public 角色部位弱点打击时()
		{
		}

		// Token: 0x0601DD0A RID: 122122 RVA: 0x008E18BA File Offset: 0x008DFABA
		[NullableContext(2)]
		public 角色部位弱点打击时(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0601DD0B RID: 122123 RVA: 0x008E18C4 File Offset: 0x008DFAC4
		public 角色部位弱点打击时(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0601DD0C RID: 122124 RVA: 0x008E18CF File Offset: 0x008DFACF
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action<TsBaseCharacter, FGameplayTag, TsBaseCharacter>) ?? ((Action<TsBaseCharacter, FGameplayTag, TsBaseCharacter>)Delegate.CreateDelegate(typeof(Action<TsBaseCharacter, FGameplayTag, TsBaseCharacter>), Callback.Target, Callback.Method)));
		}

		// Token: 0x0601DD0D RID: 122125 RVA: 0x008E1901 File Offset: 0x008DFB01
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add([Nullable(new byte[]
		{
			1,
			2,
			2
		})] Action<TsBaseCharacter, FGameplayTag, TsBaseCharacter> Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x0601DD0E RID: 122126 RVA: 0x008E1910 File Offset: 0x008DFB10
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove([Nullable(new byte[]
		{
			1,
			2,
			2
		})] Action<TsBaseCharacter, FGameplayTag, TsBaseCharacter> Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x0601DD0F RID: 122127 RVA: 0x008E191C File Offset: 0x008DFB1C
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void Broadcast(TsBaseCharacter 角色, FGameplayTag 部位Tag, TsBaseCharacter 攻击者)
		{
			角色部位弱点打击时.__角色部位弱点打击时_DelegateParams* ptr = stackalloc 角色部位弱点打击时.__角色部位弱点打击时_DelegateParams[(UIntPtr)47] + 15L / (long)sizeof(角色部位弱点打击时.__角色部位弱点打击时_DelegateParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(角色部位弱点打击时.StaticFunctionPtr(), (void*)ptr, 1);
			ptr->角色 = ((角色 != null) ? 角色.NativePtr : IntPtr.Zero);
			ptr->部位Tag = 部位Tag;
			ptr->攻击者 = ((攻击者 != null) ? 攻击者.NativePtr : IntPtr.Zero);
			base.BroadcastInternal((void*)ptr);
		}

		// Token: 0x0601DD10 RID: 122128 RVA: 0x008E1984 File Offset: 0x008DFB84
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveOptimization)]
		protected unsafe static void OnScriptCallback(IntPtr __Handle, byte* __Parameters)
		{
			object target = GCHandle.FromIntPtr(__Handle).Target;
			Action<TsBaseCharacter, FGameplayTag, TsBaseCharacter> action = target as Action<TsBaseCharacter, FGameplayTag, TsBaseCharacter>;
			if (action == null)
			{
				throw new ArgumentException((target != null) ? target.GetType().ToString() : null);
			}
			TsBaseCharacter orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<TsBaseCharacter>(((角色部位弱点打击时.__角色部位弱点打击时_DelegateParams*)__Parameters)->角色);
			TsBaseCharacter orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<TsBaseCharacter>(((角色部位弱点打击时.__角色部位弱点打击时_DelegateParams*)__Parameters)->攻击者);
			action(orCreateUObjectByNativePointer, ((角色部位弱点打击时.__角色部位弱点打击时_DelegateParams*)__Parameters)->部位Tag, orCreateUObjectByNativePointer2);
		}

		// Token: 0x0400E97E RID: 59774
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/UI/Manager/BP_EventManager.BP_EventManager_C:角色部位弱点打击时__DelegateSignature";

		// Token: 0x020096D9 RID: 38617
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __角色部位弱点打击时_DelegateParams
		{
			// Token: 0x04031BC7 RID: 203719
			[FieldOffset(0)]
			public IntPtr 角色;

			// Token: 0x04031BC8 RID: 203720
			[FieldOffset(8)]
			public FGameplayTag 部位Tag;

			// Token: 0x04031BC9 RID: 203721
			[FieldOffset(24)]
			public IntPtr 攻击者;
		}
	}
}
