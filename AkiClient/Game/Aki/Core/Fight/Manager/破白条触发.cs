using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Core.Fight.Manager
{
	// Token: 0x02003F81 RID: 16257
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class 破白条触发 : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x06028A82 RID: 166530 RVA: 0x00A11D72 File Offset: 0x00A0FF72
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return 破白条触发.StaticFunctionPtr();
		}

		// Token: 0x06028A83 RID: 166531 RVA: 0x00A11D7E File Offset: 0x00A0FF7E
		private static IntPtr StaticFunctionPtr()
		{
			if (BP_FightManager_C.__破白条触发__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				BP_FightManager_C.__破白条触发__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/Core/Fight/Manager/BP_FightManager.BP_FightManager_C:破白条触发__DelegateSignature");
			}
			return BP_FightManager_C.__破白条触发__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x06028A84 RID: 166532 RVA: 0x00A11DA1 File Offset: 0x00A0FFA1
		public 破白条触发()
		{
		}

		// Token: 0x06028A85 RID: 166533 RVA: 0x00A11DA9 File Offset: 0x00A0FFA9
		[NullableContext(2)]
		public 破白条触发(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06028A86 RID: 166534 RVA: 0x00A11DB3 File Offset: 0x00A0FFB3
		public 破白条触发(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06028A87 RID: 166535 RVA: 0x00A11DBE File Offset: 0x00A0FFBE
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action<TsBaseCharacter>) ?? ((Action<TsBaseCharacter>)Delegate.CreateDelegate(typeof(Action<TsBaseCharacter>), Callback.Target, Callback.Method)));
		}

		// Token: 0x06028A88 RID: 166536 RVA: 0x00A11DF0 File Offset: 0x00A0FFF0
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add([Nullable(new byte[]
		{
			1,
			2
		})] Action<TsBaseCharacter> Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x06028A89 RID: 166537 RVA: 0x00A11DFF File Offset: 0x00A0FFFF
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove([Nullable(new byte[]
		{
			1,
			2
		})] Action<TsBaseCharacter> Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x06028A8A RID: 166538 RVA: 0x00A11E08 File Offset: 0x00A10008
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void Broadcast(TsBaseCharacter 触发者)
		{
			破白条触发.__破白条触发_DelegateParams* ptr = stackalloc 破白条触发.__破白条触发_DelegateParams[(UIntPtr)23] + 15L / (long)sizeof(破白条触发.__破白条触发_DelegateParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(破白条触发.StaticFunctionPtr(), (void*)ptr, 1);
			ptr->触发者 = ((触发者 != null) ? 触发者.NativePtr : IntPtr.Zero);
			base.BroadcastInternal((void*)ptr);
		}

		// Token: 0x06028A8B RID: 166539 RVA: 0x00A11E54 File Offset: 0x00A10054
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveOptimization)]
		protected unsafe static void OnScriptCallback(IntPtr __Handle, byte* __Parameters)
		{
			object target = GCHandle.FromIntPtr(__Handle).Target;
			Action<TsBaseCharacter> action = target as Action<TsBaseCharacter>;
			if (action == null)
			{
				throw new ArgumentException((target != null) ? target.GetType().ToString() : null);
			}
			TsBaseCharacter orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<TsBaseCharacter>(((破白条触发.__破白条触发_DelegateParams*)__Parameters)->触发者);
			action(orCreateUObjectByNativePointer);
		}

		// Token: 0x04015718 RID: 87832
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Core/Fight/Manager/BP_FightManager.BP_FightManager_C:破白条触发__DelegateSignature";

		// Token: 0x0200A130 RID: 41264
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __破白条触发_DelegateParams
		{
			// Token: 0x04032E64 RID: 208484
			[FieldOffset(0)]
			public IntPtr 触发者;
		}
	}
}
