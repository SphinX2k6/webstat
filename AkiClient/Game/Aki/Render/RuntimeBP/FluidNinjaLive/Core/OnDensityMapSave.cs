using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.FluidNinjaLive.Core
{
	// Token: 0x02003D07 RID: 15623
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class OnDensityMapSave : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x06025BB9 RID: 154553 RVA: 0x009C35CC File Offset: 0x009C17CC
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return OnDensityMapSave.StaticFunctionPtr();
		}

		// Token: 0x06025BBA RID: 154554 RVA: 0x009C35D8 File Offset: 0x009C17D8
		private static IntPtr StaticFunctionPtr()
		{
			if (NinjaLiveGUI_C.__OnDensityMapSave__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				NinjaLiveGUI_C.__OnDensityMapSave__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/Render/RuntimeBP/FluidNinjaLive/Core/NinjaLiveGUI.NinjaLiveGUI_C:OnDensityMapSave__DelegateSignature");
			}
			return NinjaLiveGUI_C.__OnDensityMapSave__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x06025BBB RID: 154555 RVA: 0x009C35FB File Offset: 0x009C17FB
		public OnDensityMapSave()
		{
		}

		// Token: 0x06025BBC RID: 154556 RVA: 0x009C3603 File Offset: 0x009C1803
		[NullableContext(2)]
		public OnDensityMapSave(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06025BBD RID: 154557 RVA: 0x009C360D File Offset: 0x009C180D
		public OnDensityMapSave(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06025BBE RID: 154558 RVA: 0x009C3618 File Offset: 0x009C1818
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action<bool>) ?? ((Action<bool>)Delegate.CreateDelegate(typeof(Action<bool>), Callback.Target, Callback.Method)));
		}

		// Token: 0x06025BBF RID: 154559 RVA: 0x009C364A File Offset: 0x009C184A
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add(Action<bool> Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x06025BC0 RID: 154560 RVA: 0x009C3659 File Offset: 0x009C1859
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove(Action<bool> Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x06025BC1 RID: 154561 RVA: 0x009C3664 File Offset: 0x009C1864
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void Broadcast(bool SavePaintBuffer)
		{
			OnDensityMapSave.__OnDensityMapSave_DelegateParams* ptr = stackalloc OnDensityMapSave.__OnDensityMapSave_DelegateParams[(UIntPtr)16] + 15L / (long)sizeof(OnDensityMapSave.__OnDensityMapSave_DelegateParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(OnDensityMapSave.StaticFunctionPtr(), (void*)ptr, 1);
			ptr->SavePaintBuffer = SavePaintBuffer;
			base.BroadcastInternal((void*)ptr);
		}

		// Token: 0x06025BC2 RID: 154562 RVA: 0x009C36A0 File Offset: 0x009C18A0
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
			action(((OnDensityMapSave.__OnDensityMapSave_DelegateParams*)__Parameters)->SavePaintBuffer);
		}

		// Token: 0x040137C1 RID: 79809
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/FluidNinjaLive/Core/NinjaLiveGUI.NinjaLiveGUI_C:OnDensityMapSave__DelegateSignature";

		// Token: 0x02009F96 RID: 40854
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected ref struct __OnDensityMapSave_DelegateParams
		{
			// Token: 0x04032B3F RID: 207679
			[FieldOffset(0)]
			public bool SavePaintBuffer;
		}
	}
}
