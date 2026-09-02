using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Common.Piano
{
	// Token: 0x02003AE7 RID: 15079
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class EventDispatcher : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x06020638 RID: 132664 RVA: 0x0092A6AF File Offset: 0x009288AF
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return EventDispatcher.StaticFunctionPtr();
		}

		// Token: 0x06020639 RID: 132665 RVA: 0x0092A6BB File Offset: 0x009288BB
		private static IntPtr StaticFunctionPtr()
		{
			if (BP_PianoKey_C.__EventDispatcher__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				BP_PianoKey_C.__EventDispatcher__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/Render/RuntimeBP/Scene/Common/Piano/BP_PianoKey.BP_PianoKey_C:EventDispatcher__DelegateSignature");
			}
			return BP_PianoKey_C.__EventDispatcher__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x0602063A RID: 132666 RVA: 0x0092A6DE File Offset: 0x009288DE
		public EventDispatcher()
		{
		}

		// Token: 0x0602063B RID: 132667 RVA: 0x0092A6E6 File Offset: 0x009288E6
		[NullableContext(2)]
		public EventDispatcher(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602063C RID: 132668 RVA: 0x0092A6F0 File Offset: 0x009288F0
		public EventDispatcher(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602063D RID: 132669 RVA: 0x0092A6FB File Offset: 0x009288FB
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action<bool, TEnumAsByte<PianoKeyEnum>>) ?? ((Action<bool, TEnumAsByte<PianoKeyEnum>>)Delegate.CreateDelegate(typeof(Action<bool, TEnumAsByte<PianoKeyEnum>>), Callback.Target, Callback.Method)));
		}

		// Token: 0x0602063E RID: 132670 RVA: 0x0092A72D File Offset: 0x0092892D
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add([Nullable(new byte[]
		{
			1,
			0
		})] Action<bool, TEnumAsByte<PianoKeyEnum>> Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x0602063F RID: 132671 RVA: 0x0092A73C File Offset: 0x0092893C
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove([Nullable(new byte[]
		{
			1,
			0
		})] Action<bool, TEnumAsByte<PianoKeyEnum>> Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x06020640 RID: 132672 RVA: 0x0092A748 File Offset: 0x00928948
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void Broadcast(bool Overlap, PianoKeyEnum KeyType)
		{
			EventDispatcher.__EventDispatcher_DelegateParams* ptr = stackalloc EventDispatcher.__EventDispatcher_DelegateParams[(UIntPtr)17] + 15L / (long)sizeof(EventDispatcher.__EventDispatcher_DelegateParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(EventDispatcher.StaticFunctionPtr(), (void*)ptr, 1);
			ptr->Overlap = Overlap;
			ptr->KeyType = KeyType;
			base.BroadcastInternal((void*)ptr);
		}

		// Token: 0x06020641 RID: 132673 RVA: 0x0092A790 File Offset: 0x00928990
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveOptimization)]
		protected unsafe static void OnScriptCallback(IntPtr __Handle, byte* __Parameters)
		{
			object target = GCHandle.FromIntPtr(__Handle).Target;
			Action<bool, TEnumAsByte<PianoKeyEnum>> action = target as Action<bool, TEnumAsByte<PianoKeyEnum>>;
			if (action == null)
			{
				throw new ArgumentException((target != null) ? target.GetType().ToString() : null);
			}
			action(((EventDispatcher.__EventDispatcher_DelegateParams*)__Parameters)->Overlap, ((EventDispatcher.__EventDispatcher_DelegateParams*)__Parameters)->KeyType);
		}

		// Token: 0x040102BC RID: 66236
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Common/Piano/BP_PianoKey.BP_PianoKey_C:EventDispatcher__DelegateSignature";

		// Token: 0x020099A2 RID: 39330
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 2)]
		protected ref struct __EventDispatcher_DelegateParams
		{
			// Token: 0x04032034 RID: 204852
			[FieldOffset(0)]
			public bool Overlap;

			// Token: 0x04032035 RID: 204853
			[FieldOffset(1)]
			public TEnumAsByte<PianoKeyEnum> KeyType;
		}
	}
}
