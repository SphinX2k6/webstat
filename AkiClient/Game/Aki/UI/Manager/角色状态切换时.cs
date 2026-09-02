using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.UI.Manager
{
	// Token: 0x020039AF RID: 14767
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class 角色状态切换时 : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x0601DCFD RID: 122109 RVA: 0x008E171B File Offset: 0x008DF91B
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return 角色状态切换时.StaticFunctionPtr();
		}

		// Token: 0x0601DCFE RID: 122110 RVA: 0x008E1727 File Offset: 0x008DF927
		private static IntPtr StaticFunctionPtr()
		{
			if (BP_EventManager_C.__角色状态切换时__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				BP_EventManager_C.__角色状态切换时__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/UI/Manager/BP_EventManager.BP_EventManager_C:角色状态切换时__DelegateSignature");
			}
			return BP_EventManager_C.__角色状态切换时__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x0601DCFF RID: 122111 RVA: 0x008E174A File Offset: 0x008DF94A
		public 角色状态切换时()
		{
		}

		// Token: 0x0601DD00 RID: 122112 RVA: 0x008E1752 File Offset: 0x008DF952
		[NullableContext(2)]
		public 角色状态切换时(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0601DD01 RID: 122113 RVA: 0x008E175C File Offset: 0x008DF95C
		public 角色状态切换时(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0601DD02 RID: 122114 RVA: 0x008E1767 File Offset: 0x008DF967
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action<TsBaseCharacter, TEnumAsByte<ECharacterState>, TEnumAsByte<ECharacterState>, bool>) ?? ((Action<TsBaseCharacter, TEnumAsByte<ECharacterState>, TEnumAsByte<ECharacterState>, bool>)Delegate.CreateDelegate(typeof(Action<TsBaseCharacter, TEnumAsByte<ECharacterState>, TEnumAsByte<ECharacterState>, bool>), Callback.Target, Callback.Method)));
		}

		// Token: 0x0601DD03 RID: 122115 RVA: 0x008E1799 File Offset: 0x008DF999
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add([Nullable(new byte[]
		{
			1,
			2,
			0,
			0
		})] Action<TsBaseCharacter, TEnumAsByte<ECharacterState>, TEnumAsByte<ECharacterState>, bool> Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x0601DD04 RID: 122116 RVA: 0x008E17A8 File Offset: 0x008DF9A8
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove([Nullable(new byte[]
		{
			1,
			2,
			0,
			0
		})] Action<TsBaseCharacter, TEnumAsByte<ECharacterState>, TEnumAsByte<ECharacterState>, bool> Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x0601DD05 RID: 122117 RVA: 0x008E17B4 File Offset: 0x008DF9B4
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void Broadcast(TsBaseCharacter 角色, ECharacterState 老状态, ECharacterState 新状态, bool 主控)
		{
			角色状态切换时.__角色状态切换时_DelegateParams* ptr = stackalloc 角色状态切换时.__角色状态切换时_DelegateParams[(UIntPtr)31] + 15L / (long)sizeof(角色状态切换时.__角色状态切换时_DelegateParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(角色状态切换时.StaticFunctionPtr(), (void*)ptr, 1);
			ptr->角色 = ((角色 != null) ? 角色.NativePtr : IntPtr.Zero);
			ptr->老状态 = 老状态;
			ptr->新状态 = 新状态;
			ptr->主控 = 主控;
			base.BroadcastInternal((void*)ptr);
		}

		// Token: 0x0601DD06 RID: 122118 RVA: 0x008E1820 File Offset: 0x008DFA20
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveOptimization)]
		protected unsafe static void OnScriptCallback(IntPtr __Handle, byte* __Parameters)
		{
			object target = GCHandle.FromIntPtr(__Handle).Target;
			Action<TsBaseCharacter, TEnumAsByte<ECharacterState>, TEnumAsByte<ECharacterState>, bool> action = target as Action<TsBaseCharacter, TEnumAsByte<ECharacterState>, TEnumAsByte<ECharacterState>, bool>;
			if (action == null)
			{
				throw new ArgumentException((target != null) ? target.GetType().ToString() : null);
			}
			TsBaseCharacter orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<TsBaseCharacter>(((角色状态切换时.__角色状态切换时_DelegateParams*)__Parameters)->角色);
			action(orCreateUObjectByNativePointer, ((角色状态切换时.__角色状态切换时_DelegateParams*)__Parameters)->老状态, ((角色状态切换时.__角色状态切换时_DelegateParams*)__Parameters)->新状态, ((角色状态切换时.__角色状态切换时_DelegateParams*)__Parameters)->主控);
		}

		// Token: 0x0400E97D RID: 59773
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/UI/Manager/BP_EventManager.BP_EventManager_C:角色状态切换时__DelegateSignature";

		// Token: 0x020096D8 RID: 38616
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __角色状态切换时_DelegateParams
		{
			// Token: 0x04031BC3 RID: 203715
			[FieldOffset(0)]
			public IntPtr 角色;

			// Token: 0x04031BC4 RID: 203716
			[FieldOffset(8)]
			public TEnumAsByte<ECharacterState> 老状态;

			// Token: 0x04031BC5 RID: 203717
			[FieldOffset(9)]
			public TEnumAsByte<ECharacterState> 新状态;

			// Token: 0x04031BC6 RID: 203718
			[FieldOffset(10)]
			public bool 主控;
		}
	}
}
