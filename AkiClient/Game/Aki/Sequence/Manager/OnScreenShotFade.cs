using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Sequence.Manager
{
	// Token: 0x020043AB RID: 17323
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class OnScreenShotFade : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x0602E12E RID: 188718 RVA: 0x00AD6180 File Offset: 0x00AD4380
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return OnScreenShotFade.StaticFunctionPtr();
		}

		// Token: 0x0602E12F RID: 188719 RVA: 0x00AD618C File Offset: 0x00AD438C
		private static IntPtr StaticFunctionPtr()
		{
			if (BP_KuroMasterSeqEvent_C.__OnScreenShotFade__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				BP_KuroMasterSeqEvent_C.__OnScreenShotFade__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/Sequence/Manager/BP_KuroMasterSeqEvent.BP_KuroMasterSeqEvent_C:OnScreenShotFade__DelegateSignature");
			}
			return BP_KuroMasterSeqEvent_C.__OnScreenShotFade__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x0602E130 RID: 188720 RVA: 0x00AD61AF File Offset: 0x00AD43AF
		public OnScreenShotFade()
		{
		}

		// Token: 0x0602E131 RID: 188721 RVA: 0x00AD61B7 File Offset: 0x00AD43B7
		[NullableContext(2)]
		public OnScreenShotFade(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602E132 RID: 188722 RVA: 0x00AD61C1 File Offset: 0x00AD43C1
		public OnScreenShotFade(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602E133 RID: 188723 RVA: 0x00AD61CC File Offset: 0x00AD43CC
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action) ?? ((Action)Delegate.CreateDelegate(typeof(Action), Callback.Target, Callback.Method)));
		}

		// Token: 0x0602E134 RID: 188724 RVA: 0x00AD61FE File Offset: 0x00AD43FE
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add(Action Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x0602E135 RID: 188725 RVA: 0x00AD620D File Offset: 0x00AD440D
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove(Action Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x0602E136 RID: 188726 RVA: 0x00AD6216 File Offset: 0x00AD4416
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Broadcast()
		{
			base.BroadcastInternal(null);
		}

		// Token: 0x0602E137 RID: 188727 RVA: 0x00AD6220 File Offset: 0x00AD4420
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

		// Token: 0x0401A0BC RID: 106684
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Sequence/Manager/BP_KuroMasterSeqEvent.BP_KuroMasterSeqEvent_C:OnScreenShotFade__DelegateSignature";
	}
}
