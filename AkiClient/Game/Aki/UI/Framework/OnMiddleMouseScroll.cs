using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.UI.Framework
{
	// Token: 0x020039B6 RID: 14774
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class OnMiddleMouseScroll : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x0601DD88 RID: 122248 RVA: 0x008E442E File Offset: 0x008E262E
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return OnMiddleMouseScroll.StaticFunctionPtr();
		}

		// Token: 0x0601DD89 RID: 122249 RVA: 0x008E443A File Offset: 0x008E263A
		private static IntPtr StaticFunctionPtr()
		{
			if (LGUIEventSystemActor_C.__OnMiddleMouseScroll__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				LGUIEventSystemActor_C.__OnMiddleMouseScroll__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/UI/Framework/LGUIEventSystemActor.LGUIEventSystemActor_C:OnMiddleMouseScroll__DelegateSignature");
			}
			return LGUIEventSystemActor_C.__OnMiddleMouseScroll__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x0601DD8A RID: 122250 RVA: 0x008E445D File Offset: 0x008E265D
		public OnMiddleMouseScroll()
		{
		}

		// Token: 0x0601DD8B RID: 122251 RVA: 0x008E4465 File Offset: 0x008E2665
		[NullableContext(2)]
		public OnMiddleMouseScroll(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0601DD8C RID: 122252 RVA: 0x008E446F File Offset: 0x008E266F
		public OnMiddleMouseScroll(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0601DD8D RID: 122253 RVA: 0x008E447A File Offset: 0x008E267A
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action<float>) ?? ((Action<float>)Delegate.CreateDelegate(typeof(Action<float>), Callback.Target, Callback.Method)));
		}

		// Token: 0x0601DD8E RID: 122254 RVA: 0x008E44AC File Offset: 0x008E26AC
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add(Action<float> Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x0601DD8F RID: 122255 RVA: 0x008E44BB File Offset: 0x008E26BB
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove(Action<float> Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x0601DD90 RID: 122256 RVA: 0x008E44C4 File Offset: 0x008E26C4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void Broadcast(float AxisValue)
		{
			OnMiddleMouseScroll.__OnMiddleMouseScroll_DelegateParams* ptr = stackalloc OnMiddleMouseScroll.__OnMiddleMouseScroll_DelegateParams[(UIntPtr)19] + 15L / (long)sizeof(OnMiddleMouseScroll.__OnMiddleMouseScroll_DelegateParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(OnMiddleMouseScroll.StaticFunctionPtr(), (void*)ptr, 1);
			ptr->AxisValue = AxisValue;
			base.BroadcastInternal((void*)ptr);
		}

		// Token: 0x0601DD91 RID: 122257 RVA: 0x008E4500 File Offset: 0x008E2700
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

		// Token: 0x0400E9D8 RID: 59864
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/UI/Framework/LGUIEventSystemActor.LGUIEventSystemActor_C:OnMiddleMouseScroll__DelegateSignature";

		// Token: 0x0200971A RID: 38682
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __OnMiddleMouseScroll_DelegateParams
		{
			// Token: 0x04031C5A RID: 203866
			[FieldOffset(0)]
			public float AxisValue;
		}
	}
}
