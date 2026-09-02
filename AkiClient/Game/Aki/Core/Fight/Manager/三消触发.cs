using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Core.Fight.Manager
{
	// Token: 0x02003F7C RID: 16252
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class 三消触发 : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x06028A50 RID: 166480 RVA: 0x00A1175C File Offset: 0x00A0F95C
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return 三消触发.StaticFunctionPtr();
		}

		// Token: 0x06028A51 RID: 166481 RVA: 0x00A11768 File Offset: 0x00A0F968
		private static IntPtr StaticFunctionPtr()
		{
			if (BP_FightManager_C.__三消触发__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				BP_FightManager_C.__三消触发__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/Core/Fight/Manager/BP_FightManager.BP_FightManager_C:三消触发__DelegateSignature");
			}
			return BP_FightManager_C.__三消触发__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x06028A52 RID: 166482 RVA: 0x00A1178B File Offset: 0x00A0F98B
		public 三消触发()
		{
		}

		// Token: 0x06028A53 RID: 166483 RVA: 0x00A11793 File Offset: 0x00A0F993
		[NullableContext(2)]
		public 三消触发(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06028A54 RID: 166484 RVA: 0x00A1179D File Offset: 0x00A0F99D
		public 三消触发(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06028A55 RID: 166485 RVA: 0x00A117A8 File Offset: 0x00A0F9A8
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action<TsBaseCharacter>) ?? ((Action<TsBaseCharacter>)Delegate.CreateDelegate(typeof(Action<TsBaseCharacter>), Callback.Target, Callback.Method)));
		}

		// Token: 0x06028A56 RID: 166486 RVA: 0x00A117DA File Offset: 0x00A0F9DA
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add([Nullable(new byte[]
		{
			1,
			2
		})] Action<TsBaseCharacter> Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x06028A57 RID: 166487 RVA: 0x00A117E9 File Offset: 0x00A0F9E9
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove([Nullable(new byte[]
		{
			1,
			2
		})] Action<TsBaseCharacter> Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x06028A58 RID: 166488 RVA: 0x00A117F4 File Offset: 0x00A0F9F4
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void Broadcast(TsBaseCharacter 触发者)
		{
			三消触发.__三消触发_DelegateParams* ptr = stackalloc 三消触发.__三消触发_DelegateParams[(UIntPtr)23] + 15L / (long)sizeof(三消触发.__三消触发_DelegateParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(三消触发.StaticFunctionPtr(), (void*)ptr, 1);
			ptr->触发者 = ((触发者 != null) ? 触发者.NativePtr : IntPtr.Zero);
			base.BroadcastInternal((void*)ptr);
		}

		// Token: 0x06028A59 RID: 166489 RVA: 0x00A11840 File Offset: 0x00A0FA40
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
			TsBaseCharacter orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<TsBaseCharacter>(((三消触发.__三消触发_DelegateParams*)__Parameters)->触发者);
			action(orCreateUObjectByNativePointer);
		}

		// Token: 0x04015713 RID: 87827
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Core/Fight/Manager/BP_FightManager.BP_FightManager_C:三消触发__DelegateSignature";

		// Token: 0x0200A12B RID: 41259
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __三消触发_DelegateParams
		{
			// Token: 0x04032E5F RID: 208479
			[FieldOffset(0)]
			public IntPtr 触发者;
		}
	}
}
