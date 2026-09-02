using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.UI.Module.HotFix
{
	// Token: 0x02003980 RID: 14720
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class OnTouchMove : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x0601DA93 RID: 121491 RVA: 0x008DC8E6 File Offset: 0x008DAAE6
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return OnTouchMove.StaticFunctionPtr();
		}

		// Token: 0x0601DA94 RID: 121492 RVA: 0x008DC8F2 File Offset: 0x008DAAF2
		private static IntPtr StaticFunctionPtr()
		{
			if (HotFixLGUIEventSystemActor_C.__OnTouchMove__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				HotFixLGUIEventSystemActor_C.__OnTouchMove__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/UI/Module/HotFix/HotFixLGUIEventSystemActor.HotFixLGUIEventSystemActor_C:OnTouchMove__DelegateSignature");
			}
			return HotFixLGUIEventSystemActor_C.__OnTouchMove__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x0601DA95 RID: 121493 RVA: 0x008DC915 File Offset: 0x008DAB15
		public OnTouchMove()
		{
		}

		// Token: 0x0601DA96 RID: 121494 RVA: 0x008DC91D File Offset: 0x008DAB1D
		[NullableContext(2)]
		public OnTouchMove(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0601DA97 RID: 121495 RVA: 0x008DC927 File Offset: 0x008DAB27
		public OnTouchMove(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0601DA98 RID: 121496 RVA: 0x008DC932 File Offset: 0x008DAB32
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action<int, FVector>) ?? ((Action<int, FVector>)Delegate.CreateDelegate(typeof(Action<int, FVector>), Callback.Target, Callback.Method)));
		}

		// Token: 0x0601DA99 RID: 121497 RVA: 0x008DC964 File Offset: 0x008DAB64
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add(Action<int, FVector> Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x0601DA9A RID: 121498 RVA: 0x008DC973 File Offset: 0x008DAB73
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove(Action<int, FVector> Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x0601DA9B RID: 121499 RVA: 0x008DC97C File Offset: 0x008DAB7C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void Broadcast(int TouchID, FVector TouchPointPosition)
		{
			OnTouchMove.__OnTouchMove_DelegateParams* ptr = stackalloc OnTouchMove.__OnTouchMove_DelegateParams[(UIntPtr)31] + 15L / (long)sizeof(OnTouchMove.__OnTouchMove_DelegateParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(OnTouchMove.StaticFunctionPtr(), (void*)ptr, 1);
			ptr->TouchID = TouchID;
			ptr->TouchPointPosition = TouchPointPosition;
			base.BroadcastInternal((void*)ptr);
		}

		// Token: 0x0601DA9C RID: 121500 RVA: 0x008DC9C0 File Offset: 0x008DABC0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveOptimization)]
		protected unsafe static void OnScriptCallback(IntPtr __Handle, byte* __Parameters)
		{
			object target = GCHandle.FromIntPtr(__Handle).Target;
			Action<int, FVector> action = target as Action<int, FVector>;
			if (action == null)
			{
				throw new ArgumentException((target != null) ? target.GetType().ToString() : null);
			}
			action(((OnTouchMove.__OnTouchMove_DelegateParams*)__Parameters)->TouchID, ((OnTouchMove.__OnTouchMove_DelegateParams*)__Parameters)->TouchPointPosition);
		}

		// Token: 0x0400E85E RID: 59486
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/UI/Module/HotFix/HotFixLGUIEventSystemActor.HotFixLGUIEventSystemActor_C:OnTouchMove__DelegateSignature";

		// Token: 0x020096AE RID: 38574
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __OnTouchMove_DelegateParams
		{
			// Token: 0x04031B82 RID: 203650
			[FieldOffset(0)]
			public int TouchID;

			// Token: 0x04031B83 RID: 203651
			[FieldOffset(4)]
			public FVector TouchPointPosition;
		}
	}
}
