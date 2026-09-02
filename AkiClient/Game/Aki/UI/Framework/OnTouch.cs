using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.UI.Framework
{
	// Token: 0x020039B7 RID: 14775
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class OnTouch : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x0601DD92 RID: 122258 RVA: 0x008E454A File Offset: 0x008E274A
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return OnTouch.StaticFunctionPtr();
		}

		// Token: 0x0601DD93 RID: 122259 RVA: 0x008E4556 File Offset: 0x008E2756
		private static IntPtr StaticFunctionPtr()
		{
			if (LGUIEventSystemActor_C.__OnTouch__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				LGUIEventSystemActor_C.__OnTouch__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/UI/Framework/LGUIEventSystemActor.LGUIEventSystemActor_C:OnTouch__DelegateSignature");
			}
			return LGUIEventSystemActor_C.__OnTouch__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x0601DD94 RID: 122260 RVA: 0x008E4579 File Offset: 0x008E2779
		public OnTouch()
		{
		}

		// Token: 0x0601DD95 RID: 122261 RVA: 0x008E4581 File Offset: 0x008E2781
		[NullableContext(2)]
		public OnTouch(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0601DD96 RID: 122262 RVA: 0x008E458B File Offset: 0x008E278B
		public OnTouch(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0601DD97 RID: 122263 RVA: 0x008E4596 File Offset: 0x008E2796
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action<bool, int, FVector>) ?? ((Action<bool, int, FVector>)Delegate.CreateDelegate(typeof(Action<bool, int, FVector>), Callback.Target, Callback.Method)));
		}

		// Token: 0x0601DD98 RID: 122264 RVA: 0x008E45C8 File Offset: 0x008E27C8
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add(Action<bool, int, FVector> Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x0601DD99 RID: 122265 RVA: 0x008E45D7 File Offset: 0x008E27D7
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove(Action<bool, int, FVector> Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x0601DD9A RID: 122266 RVA: 0x008E45E0 File Offset: 0x008E27E0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void Broadcast(bool TouchPress, int TouchID, FVector TouchPointPosition)
		{
			OnTouch.__OnTouch_DelegateParams* ptr = stackalloc OnTouch.__OnTouch_DelegateParams[(UIntPtr)35] + 15L / (long)sizeof(OnTouch.__OnTouch_DelegateParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(OnTouch.StaticFunctionPtr(), (void*)ptr, 1);
			ptr->TouchPress = TouchPress;
			ptr->TouchID = TouchID;
			ptr->TouchPointPosition = TouchPointPosition;
			base.BroadcastInternal((void*)ptr);
		}

		// Token: 0x0601DD9B RID: 122267 RVA: 0x008E462C File Offset: 0x008E282C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveOptimization)]
		protected unsafe static void OnScriptCallback(IntPtr __Handle, byte* __Parameters)
		{
			object target = GCHandle.FromIntPtr(__Handle).Target;
			Action<bool, int, FVector> action = target as Action<bool, int, FVector>;
			if (action == null)
			{
				throw new ArgumentException((target != null) ? target.GetType().ToString() : null);
			}
			action(((OnTouch.__OnTouch_DelegateParams*)__Parameters)->TouchPress, ((OnTouch.__OnTouch_DelegateParams*)__Parameters)->TouchID, ((OnTouch.__OnTouch_DelegateParams*)__Parameters)->TouchPointPosition);
		}

		// Token: 0x0400E9D9 RID: 59865
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/UI/Framework/LGUIEventSystemActor.LGUIEventSystemActor_C:OnTouch__DelegateSignature";

		// Token: 0x0200971B RID: 38683
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 20)]
		protected ref struct __OnTouch_DelegateParams
		{
			// Token: 0x04031C5B RID: 203867
			[FieldOffset(0)]
			public bool TouchPress;

			// Token: 0x04031C5C RID: 203868
			[FieldOffset(4)]
			public int TouchID;

			// Token: 0x04031C5D RID: 203869
			[FieldOffset(8)]
			public FVector TouchPointPosition;
		}
	}
}
