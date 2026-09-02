using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.UI.Module.HotFix
{
	// Token: 0x0200397E RID: 14718
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class OnMiddleMouseScroll : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x0601DA7F RID: 121471 RVA: 0x008DC692 File Offset: 0x008DA892
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return OnMiddleMouseScroll.StaticFunctionPtr();
		}

		// Token: 0x0601DA80 RID: 121472 RVA: 0x008DC69E File Offset: 0x008DA89E
		private static IntPtr StaticFunctionPtr()
		{
			if (HotFixLGUIEventSystemActor_C.__OnMiddleMouseScroll__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				HotFixLGUIEventSystemActor_C.__OnMiddleMouseScroll__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/UI/Module/HotFix/HotFixLGUIEventSystemActor.HotFixLGUIEventSystemActor_C:OnMiddleMouseScroll__DelegateSignature");
			}
			return HotFixLGUIEventSystemActor_C.__OnMiddleMouseScroll__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x0601DA81 RID: 121473 RVA: 0x008DC6C1 File Offset: 0x008DA8C1
		public OnMiddleMouseScroll()
		{
		}

		// Token: 0x0601DA82 RID: 121474 RVA: 0x008DC6C9 File Offset: 0x008DA8C9
		[NullableContext(2)]
		public OnMiddleMouseScroll(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0601DA83 RID: 121475 RVA: 0x008DC6D3 File Offset: 0x008DA8D3
		public OnMiddleMouseScroll(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0601DA84 RID: 121476 RVA: 0x008DC6DE File Offset: 0x008DA8DE
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action<float>) ?? ((Action<float>)Delegate.CreateDelegate(typeof(Action<float>), Callback.Target, Callback.Method)));
		}

		// Token: 0x0601DA85 RID: 121477 RVA: 0x008DC710 File Offset: 0x008DA910
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add(Action<float> Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x0601DA86 RID: 121478 RVA: 0x008DC71F File Offset: 0x008DA91F
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove(Action<float> Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x0601DA87 RID: 121479 RVA: 0x008DC728 File Offset: 0x008DA928
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void Broadcast(float AxisValue)
		{
			OnMiddleMouseScroll.__OnMiddleMouseScroll_DelegateParams* ptr = stackalloc OnMiddleMouseScroll.__OnMiddleMouseScroll_DelegateParams[(UIntPtr)19] + 15L / (long)sizeof(OnMiddleMouseScroll.__OnMiddleMouseScroll_DelegateParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(OnMiddleMouseScroll.StaticFunctionPtr(), (void*)ptr, 1);
			ptr->AxisValue = AxisValue;
			base.BroadcastInternal((void*)ptr);
		}

		// Token: 0x0601DA88 RID: 121480 RVA: 0x008DC764 File Offset: 0x008DA964
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveOptimization)]
		protected unsafe static void OnScriptCallback(IntPtr __Handle, byte* __Parameters)
		{
			object target = GCHandle.FromIntPtr(__Handle).Target;
			Action<float> action = target as Action<float>;
			if (action == null)
			{
				throw new ArgumentException((target != null) ? target.GetType().ToString() : null);
			}
			action(((OnMiddleMouseScroll.__OnMiddleMouseScroll_DelegateParams*)__Parameters)->AxisValue);
		}

		// Token: 0x0400E85C RID: 59484
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/UI/Module/HotFix/HotFixLGUIEventSystemActor.HotFixLGUIEventSystemActor_C:OnMiddleMouseScroll__DelegateSignature";

		// Token: 0x020096AC RID: 38572
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __OnMiddleMouseScroll_DelegateParams
		{
			// Token: 0x04031B7E RID: 203646
			[FieldOffset(0)]
			public float AxisValue;
		}
	}
}
