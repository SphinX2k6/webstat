using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.FluidNinjaLive.Core
{
	// Token: 0x02003D0B RID: 15627
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class OnSelectionChanged : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x06025BE1 RID: 154593 RVA: 0x009C3AD0 File Offset: 0x009C1CD0
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return OnSelectionChanged.StaticFunctionPtr();
		}

		// Token: 0x06025BE2 RID: 154594 RVA: 0x009C3ADC File Offset: 0x009C1CDC
		private static IntPtr StaticFunctionPtr()
		{
			if (NinjaLiveGUI_C.__OnSelectionChanged__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				NinjaLiveGUI_C.__OnSelectionChanged__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/Render/RuntimeBP/FluidNinjaLive/Core/NinjaLiveGUI.NinjaLiveGUI_C:OnSelectionChanged__DelegateSignature");
			}
			return NinjaLiveGUI_C.__OnSelectionChanged__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x06025BE3 RID: 154595 RVA: 0x009C3AFF File Offset: 0x009C1CFF
		public OnSelectionChanged()
		{
		}

		// Token: 0x06025BE4 RID: 154596 RVA: 0x009C3B07 File Offset: 0x009C1D07
		[NullableContext(2)]
		public OnSelectionChanged(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06025BE5 RID: 154597 RVA: 0x009C3B11 File Offset: 0x009C1D11
		public OnSelectionChanged(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06025BE6 RID: 154598 RVA: 0x009C3B1C File Offset: 0x009C1D1C
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action<string, string>) ?? ((Action<string, string>)Delegate.CreateDelegate(typeof(Action<string, string>), Callback.Target, Callback.Method)));
		}

		// Token: 0x06025BE7 RID: 154599 RVA: 0x009C3B4E File Offset: 0x009C1D4E
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add(Action<string, string> Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x06025BE8 RID: 154600 RVA: 0x009C3B5D File Offset: 0x009C1D5D
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove(Action<string, string> Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x06025BE9 RID: 154601 RVA: 0x009C3B68 File Offset: 0x009C1D68
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void Broadcast(string SelectedMenuItem, string SelectedActorName)
		{
			OnSelectionChanged.__OnSelectionChanged_DelegateParams* ptr = stackalloc OnSelectionChanged.__OnSelectionChanged_DelegateParams[(UIntPtr)47] + 15L / (long)sizeof(OnSelectionChanged.__OnSelectionChanged_DelegateParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(OnSelectionChanged.StaticFunctionPtr(), (void*)ptr, 1);
			FString.CopyFrom((void*)(&ptr->SelectedMenuItem), SelectedMenuItem);
			FString.CopyFrom((void*)(&ptr->SelectedActorName), SelectedActorName);
			base.BroadcastInternal((void*)ptr);
			UnrealReflectionUtils.DestroyStruct(NinjaLiveGUI_C.__OnSelectionChanged__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06025BEA RID: 154602 RVA: 0x009C3BC8 File Offset: 0x009C1DC8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveOptimization)]
		protected unsafe static void OnScriptCallback(IntPtr __Handle, byte* __Parameters)
		{
			object target = GCHandle.FromIntPtr(__Handle).Target;
			Action<string, string> action = target as Action<string, string>;
			if (action == null)
			{
				throw new ArgumentException((target != null) ? target.GetType().ToString() : null);
			}
			string arg = FString.ToString((void*)(&((OnSelectionChanged.__OnSelectionChanged_DelegateParams*)__Parameters)->SelectedMenuItem));
			string arg2 = FString.ToString((void*)(&((OnSelectionChanged.__OnSelectionChanged_DelegateParams*)__Parameters)->SelectedActorName));
			action(arg, arg2);
		}

		// Token: 0x040137C5 RID: 79813
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/FluidNinjaLive/Core/NinjaLiveGUI.NinjaLiveGUI_C:OnSelectionChanged__DelegateSignature";

		// Token: 0x02009F9A RID: 40858
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __OnSelectionChanged_DelegateParams
		{
			// Token: 0x04032B46 RID: 207686
			[FieldOffset(0)]
			public FString SelectedMenuItem;

			// Token: 0x04032B47 RID: 207687
			[FieldOffset(16)]
			public FString SelectedActorName;
		}
	}
}
