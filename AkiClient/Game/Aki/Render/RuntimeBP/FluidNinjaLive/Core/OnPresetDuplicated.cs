using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.FluidNinjaLive.Core
{
	// Token: 0x02003D08 RID: 15624
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class OnPresetDuplicated : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x06025BC3 RID: 154563 RVA: 0x009C36EA File Offset: 0x009C18EA
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return OnPresetDuplicated.StaticFunctionPtr();
		}

		// Token: 0x06025BC4 RID: 154564 RVA: 0x009C36F6 File Offset: 0x009C18F6
		private static IntPtr StaticFunctionPtr()
		{
			if (NinjaLiveGUI_C.__OnPresetDuplicated__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				NinjaLiveGUI_C.__OnPresetDuplicated__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/Render/RuntimeBP/FluidNinjaLive/Core/NinjaLiveGUI.NinjaLiveGUI_C:OnPresetDuplicated__DelegateSignature");
			}
			return NinjaLiveGUI_C.__OnPresetDuplicated__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x06025BC5 RID: 154565 RVA: 0x009C3719 File Offset: 0x009C1919
		public OnPresetDuplicated()
		{
		}

		// Token: 0x06025BC6 RID: 154566 RVA: 0x009C3721 File Offset: 0x009C1921
		[NullableContext(2)]
		public OnPresetDuplicated(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06025BC7 RID: 154567 RVA: 0x009C372B File Offset: 0x009C192B
		public OnPresetDuplicated(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06025BC8 RID: 154568 RVA: 0x009C3736 File Offset: 0x009C1936
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action<UDataTable>) ?? ((Action<UDataTable>)Delegate.CreateDelegate(typeof(Action<UDataTable>), Callback.Target, Callback.Method)));
		}

		// Token: 0x06025BC9 RID: 154569 RVA: 0x009C3768 File Offset: 0x009C1968
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add([Nullable(new byte[]
		{
			1,
			2
		})] Action<UDataTable> Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x06025BCA RID: 154570 RVA: 0x009C3777 File Offset: 0x009C1977
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove([Nullable(new byte[]
		{
			1,
			2
		})] Action<UDataTable> Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x06025BCB RID: 154571 RVA: 0x009C3780 File Offset: 0x009C1980
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void Broadcast(UDataTable DuplicatedPreset)
		{
			OnPresetDuplicated.__OnPresetDuplicated_DelegateParams* ptr = stackalloc OnPresetDuplicated.__OnPresetDuplicated_DelegateParams[(UIntPtr)23] + 15L / (long)sizeof(OnPresetDuplicated.__OnPresetDuplicated_DelegateParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(OnPresetDuplicated.StaticFunctionPtr(), (void*)ptr, 1);
			ptr->DuplicatedPreset = ((DuplicatedPreset != null) ? DuplicatedPreset.NativePtr : IntPtr.Zero);
			base.BroadcastInternal((void*)ptr);
		}

		// Token: 0x06025BCC RID: 154572 RVA: 0x009C37CC File Offset: 0x009C19CC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveOptimization)]
		protected unsafe static void OnScriptCallback(IntPtr __Handle, byte* __Parameters)
		{
			object target = GCHandle.FromIntPtr(__Handle).Target;
			Action<UDataTable> action = target as Action<UDataTable>;
			if (action == null)
			{
				throw new ArgumentException((target != null) ? target.GetType().ToString() : null);
			}
			UDataTable orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<UDataTable>(((OnPresetDuplicated.__OnPresetDuplicated_DelegateParams*)__Parameters)->DuplicatedPreset);
			action(orCreateUObjectByNativePointer);
		}

		// Token: 0x040137C2 RID: 79810
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/FluidNinjaLive/Core/NinjaLiveGUI.NinjaLiveGUI_C:OnPresetDuplicated__DelegateSignature";

		// Token: 0x02009F97 RID: 40855
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __OnPresetDuplicated_DelegateParams
		{
			// Token: 0x04032B40 RID: 207680
			[FieldOffset(0)]
			public IntPtr DuplicatedPreset;
		}
	}
}
