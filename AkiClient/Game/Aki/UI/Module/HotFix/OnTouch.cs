using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.UI.Module.HotFix
{
	// Token: 0x0200397F RID: 14719
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class OnTouch : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x0601DA89 RID: 121481 RVA: 0x008DC7AE File Offset: 0x008DA9AE
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return OnTouch.StaticFunctionPtr();
		}

		// Token: 0x0601DA8A RID: 121482 RVA: 0x008DC7BA File Offset: 0x008DA9BA
		private static IntPtr StaticFunctionPtr()
		{
			if (HotFixLGUIEventSystemActor_C.__OnTouch__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				HotFixLGUIEventSystemActor_C.__OnTouch__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/UI/Module/HotFix/HotFixLGUIEventSystemActor.HotFixLGUIEventSystemActor_C:OnTouch__DelegateSignature");
			}
			return HotFixLGUIEventSystemActor_C.__OnTouch__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x0601DA8B RID: 121483 RVA: 0x008DC7DD File Offset: 0x008DA9DD
		public OnTouch()
		{
		}

		// Token: 0x0601DA8C RID: 121484 RVA: 0x008DC7E5 File Offset: 0x008DA9E5
		[NullableContext(2)]
		public OnTouch(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0601DA8D RID: 121485 RVA: 0x008DC7EF File Offset: 0x008DA9EF
		public OnTouch(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0601DA8E RID: 121486 RVA: 0x008DC7FA File Offset: 0x008DA9FA
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action<bool, int, FVector>) ?? ((Action<bool, int, FVector>)Delegate.CreateDelegate(typeof(Action<bool, int, FVector>), Callback.Target, Callback.Method)));
		}

		// Token: 0x0601DA8F RID: 121487 RVA: 0x008DC82C File Offset: 0x008DAA2C
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add(Action<bool, int, FVector> Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x0601DA90 RID: 121488 RVA: 0x008DC83B File Offset: 0x008DAA3B
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove(Action<bool, int, FVector> Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x0601DA91 RID: 121489 RVA: 0x008DC844 File Offset: 0x008DAA44
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

		// Token: 0x0601DA92 RID: 121490 RVA: 0x008DC890 File Offset: 0x008DAA90
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

		// Token: 0x0400E85D RID: 59485
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/UI/Module/HotFix/HotFixLGUIEventSystemActor.HotFixLGUIEventSystemActor_C:OnTouch__DelegateSignature";

		// Token: 0x020096AD RID: 38573
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 20)]
		protected ref struct __OnTouch_DelegateParams
		{
			// Token: 0x04031B7F RID: 203647
			[FieldOffset(0)]
			public bool TouchPress;

			// Token: 0x04031B80 RID: 203648
			[FieldOffset(4)]
			public int TouchID;

			// Token: 0x04031B81 RID: 203649
			[FieldOffset(8)]
			public FVector TouchPointPosition;
		}
	}
}
