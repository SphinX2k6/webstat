using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Common.Piano
{
	// Token: 0x02003AE8 RID: 15080
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class MoveNote : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x06020642 RID: 132674 RVA: 0x0092A7E0 File Offset: 0x009289E0
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return MoveNote.StaticFunctionPtr();
		}

		// Token: 0x06020643 RID: 132675 RVA: 0x0092A7EC File Offset: 0x009289EC
		private static IntPtr StaticFunctionPtr()
		{
			if (BP_Piano_C.__MoveNote__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				BP_Piano_C.__MoveNote__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/Render/RuntimeBP/Scene/Common/Piano/BP_Piano.BP_Piano_C:MoveNote__DelegateSignature");
			}
			return BP_Piano_C.__MoveNote__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x06020644 RID: 132676 RVA: 0x0092A80F File Offset: 0x00928A0F
		public MoveNote()
		{
		}

		// Token: 0x06020645 RID: 132677 RVA: 0x0092A817 File Offset: 0x00928A17
		[NullableContext(2)]
		public MoveNote(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06020646 RID: 132678 RVA: 0x0092A821 File Offset: 0x00928A21
		public MoveNote(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06020647 RID: 132679 RVA: 0x0092A82C File Offset: 0x00928A2C
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action) ?? ((Action)Delegate.CreateDelegate(typeof(Action), Callback.Target, Callback.Method)));
		}

		// Token: 0x06020648 RID: 132680 RVA: 0x0092A85E File Offset: 0x00928A5E
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add(Action Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x06020649 RID: 132681 RVA: 0x0092A86D File Offset: 0x00928A6D
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove(Action Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x0602064A RID: 132682 RVA: 0x0092A876 File Offset: 0x00928A76
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Broadcast()
		{
			base.BroadcastInternal(null);
		}

		// Token: 0x0602064B RID: 132683 RVA: 0x0092A880 File Offset: 0x00928A80
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveOptimization)]
		protected unsafe static void OnScriptCallback(IntPtr __Handle, byte* __Parameters)
		{
			object target = GCHandle.FromIntPtr(__Handle).Target;
			Action action = target as Action;
			if (action == null)
			{
				throw new ArgumentException((target != null) ? target.GetType().ToString() : null);
			}
			action();
		}

		// Token: 0x040102BD RID: 66237
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Common/Piano/BP_Piano.BP_Piano_C:MoveNote__DelegateSignature";
	}
}
