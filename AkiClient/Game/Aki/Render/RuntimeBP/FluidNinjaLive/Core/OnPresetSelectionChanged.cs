using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.FluidNinjaLive.Core
{
	// Token: 0x02003D0A RID: 15626
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class OnPresetSelectionChanged : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x06025BD7 RID: 154583 RVA: 0x009C3983 File Offset: 0x009C1B83
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return OnPresetSelectionChanged.StaticFunctionPtr();
		}

		// Token: 0x06025BD8 RID: 154584 RVA: 0x009C398F File Offset: 0x009C1B8F
		private static IntPtr StaticFunctionPtr()
		{
			if (NinjaLiveGUI_C.__OnPresetSelectionChanged__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				NinjaLiveGUI_C.__OnPresetSelectionChanged__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/Render/RuntimeBP/FluidNinjaLive/Core/NinjaLiveGUI.NinjaLiveGUI_C:OnPresetSelectionChanged__DelegateSignature");
			}
			return NinjaLiveGUI_C.__OnPresetSelectionChanged__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x06025BD9 RID: 154585 RVA: 0x009C39B2 File Offset: 0x009C1BB2
		public OnPresetSelectionChanged()
		{
		}

		// Token: 0x06025BDA RID: 154586 RVA: 0x009C39BA File Offset: 0x009C1BBA
		[NullableContext(2)]
		public OnPresetSelectionChanged(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06025BDB RID: 154587 RVA: 0x009C39C4 File Offset: 0x009C1BC4
		public OnPresetSelectionChanged(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06025BDC RID: 154588 RVA: 0x009C39CF File Offset: 0x009C1BCF
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action<string, bool>) ?? ((Action<string, bool>)Delegate.CreateDelegate(typeof(Action<string, bool>), Callback.Target, Callback.Method)));
		}

		// Token: 0x06025BDD RID: 154589 RVA: 0x009C3A01 File Offset: 0x009C1C01
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add(Action<string, bool> Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x06025BDE RID: 154590 RVA: 0x009C3A10 File Offset: 0x009C1C10
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove(Action<string, bool> Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x06025BDF RID: 154591 RVA: 0x009C3A1C File Offset: 0x009C1C1C
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void Broadcast(string SelectedPreset, bool ForceAutoLoadPreset)
		{
			OnPresetSelectionChanged.__OnPresetSelectionChanged_DelegateParams* ptr = stackalloc OnPresetSelectionChanged.__OnPresetSelectionChanged_DelegateParams[(UIntPtr)39] + 15L / (long)sizeof(OnPresetSelectionChanged.__OnPresetSelectionChanged_DelegateParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(OnPresetSelectionChanged.StaticFunctionPtr(), (void*)ptr, 1);
			FString.CopyFrom((void*)(&ptr->SelectedPreset), SelectedPreset);
			ptr->ForceAutoLoadPreset = ForceAutoLoadPreset;
			base.BroadcastInternal((void*)ptr);
			UnrealReflectionUtils.DestroyStruct(NinjaLiveGUI_C.__OnPresetSelectionChanged__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06025BE0 RID: 154592 RVA: 0x009C3A78 File Offset: 0x009C1C78
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveOptimization)]
		protected unsafe static void OnScriptCallback(IntPtr __Handle, byte* __Parameters)
		{
			object target = GCHandle.FromIntPtr(__Handle).Target;
			Action<string, bool> action = target as Action<string, bool>;
			if (action == null)
			{
				throw new ArgumentException((target != null) ? target.GetType().ToString() : null);
			}
			string arg = FString.ToString((void*)(&((OnPresetSelectionChanged.__OnPresetSelectionChanged_DelegateParams*)__Parameters)->SelectedPreset));
			action(arg, ((OnPresetSelectionChanged.__OnPresetSelectionChanged_DelegateParams*)__Parameters)->ForceAutoLoadPreset);
		}

		// Token: 0x040137C4 RID: 79812
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/FluidNinjaLive/Core/NinjaLiveGUI.NinjaLiveGUI_C:OnPresetSelectionChanged__DelegateSignature";

		// Token: 0x02009F99 RID: 40857
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __OnPresetSelectionChanged_DelegateParams
		{
			// Token: 0x04032B44 RID: 207684
			[FieldOffset(0)]
			public FString SelectedPreset;

			// Token: 0x04032B45 RID: 207685
			[FieldOffset(16)]
			public bool ForceAutoLoadPreset;
		}
	}
}
