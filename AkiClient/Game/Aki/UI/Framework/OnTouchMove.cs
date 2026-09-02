using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.UI.Framework
{
	// Token: 0x020039B8 RID: 14776
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class OnTouchMove : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x0601DD9C RID: 122268 RVA: 0x008E4682 File Offset: 0x008E2882
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return OnTouchMove.StaticFunctionPtr();
		}

		// Token: 0x0601DD9D RID: 122269 RVA: 0x008E468E File Offset: 0x008E288E
		private static IntPtr StaticFunctionPtr()
		{
			if (LGUIEventSystemActor_C.__OnTouchMove__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				LGUIEventSystemActor_C.__OnTouchMove__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/UI/Framework/LGUIEventSystemActor.LGUIEventSystemActor_C:OnTouchMove__DelegateSignature");
			}
			return LGUIEventSystemActor_C.__OnTouchMove__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x0601DD9E RID: 122270 RVA: 0x008E46B1 File Offset: 0x008E28B1
		public OnTouchMove()
		{
		}

		// Token: 0x0601DD9F RID: 122271 RVA: 0x008E46B9 File Offset: 0x008E28B9
		[NullableContext(2)]
		public OnTouchMove(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0601DDA0 RID: 122272 RVA: 0x008E46C3 File Offset: 0x008E28C3
		public OnTouchMove(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0601DDA1 RID: 122273 RVA: 0x008E46CE File Offset: 0x008E28CE
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action<int, FVector>) ?? ((Action<int, FVector>)Delegate.CreateDelegate(typeof(Action<int, FVector>), Callback.Target, Callback.Method)));
		}

		// Token: 0x0601DDA2 RID: 122274 RVA: 0x008E4700 File Offset: 0x008E2900
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add(Action<int, FVector> Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x0601DDA3 RID: 122275 RVA: 0x008E470F File Offset: 0x008E290F
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove(Action<int, FVector> Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x0601DDA4 RID: 122276 RVA: 0x008E4718 File Offset: 0x008E2918
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

		// Token: 0x0601DDA5 RID: 122277 RVA: 0x008E475C File Offset: 0x008E295C
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

		// Token: 0x0400E9DA RID: 59866
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/UI/Framework/LGUIEventSystemActor.LGUIEventSystemActor_C:OnTouchMove__DelegateSignature";

		// Token: 0x0200971C RID: 38684
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __OnTouchMove_DelegateParams
		{
			// Token: 0x04031C5E RID: 203870
			[FieldOffset(0)]
			public int TouchID;

			// Token: 0x04031C5F RID: 203871
			[FieldOffset(4)]
			public FVector TouchPointPosition;
		}
	}
}
