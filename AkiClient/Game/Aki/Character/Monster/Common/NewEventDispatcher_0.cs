using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Character.Monster.Common
{
	// Token: 0x0200419C RID: 16796
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class NewEventDispatcher_0 : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x0602C942 RID: 182594 RVA: 0x00AA6FE3 File Offset: 0x00AA51E3
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return NewEventDispatcher_0.StaticFunctionPtr();
		}

		// Token: 0x0602C943 RID: 182595 RVA: 0x00AA6FEF File Offset: 0x00AA51EF
		private static IntPtr StaticFunctionPtr()
		{
			if (ABP_MonsterCommon_C.__NewEventDispatcher_0__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				ABP_MonsterCommon_C.__NewEventDispatcher_0__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/Character/Monster/Common/ABP_MonsterCommon.ABP_MonsterCommon_C:NewEventDispatcher_0__DelegateSignature");
			}
			return ABP_MonsterCommon_C.__NewEventDispatcher_0__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x0602C944 RID: 182596 RVA: 0x00AA7012 File Offset: 0x00AA5212
		public NewEventDispatcher_0()
		{
		}

		// Token: 0x0602C945 RID: 182597 RVA: 0x00AA701A File Offset: 0x00AA521A
		[NullableContext(2)]
		public NewEventDispatcher_0(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602C946 RID: 182598 RVA: 0x00AA7024 File Offset: 0x00AA5224
		public NewEventDispatcher_0(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602C947 RID: 182599 RVA: 0x00AA702F File Offset: 0x00AA522F
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action) ?? ((Action)Delegate.CreateDelegate(typeof(Action), Callback.Target, Callback.Method)));
		}

		// Token: 0x0602C948 RID: 182600 RVA: 0x00AA7061 File Offset: 0x00AA5261
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add(Action Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x0602C949 RID: 182601 RVA: 0x00AA7070 File Offset: 0x00AA5270
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove(Action Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x0602C94A RID: 182602 RVA: 0x00AA7079 File Offset: 0x00AA5279
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Broadcast()
		{
			base.BroadcastInternal(null);
		}

		// Token: 0x0602C94B RID: 182603 RVA: 0x00AA7084 File Offset: 0x00AA5284
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

		// Token: 0x04018CDA RID: 101594
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Character/Monster/Common/ABP_MonsterCommon.ABP_MonsterCommon_C:NewEventDispatcher_0__DelegateSignature";
	}
}
