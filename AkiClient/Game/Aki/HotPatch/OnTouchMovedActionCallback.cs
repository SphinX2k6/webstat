using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.HotPatch
{
	// Token: 0x02003DBE RID: 15806
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class OnTouchMovedActionCallback : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x06026B36 RID: 158518 RVA: 0x009DF74E File Offset: 0x009DD94E
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return OnTouchMovedActionCallback.StaticFunctionPtr();
		}

		// Token: 0x06026B37 RID: 158519 RVA: 0x009DF75A File Offset: 0x009DD95A
		private static IntPtr StaticFunctionPtr()
		{
			if (TsHotFixActionHandle_C.__OnTouchMovedActionCallback__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				TsHotFixActionHandle_C.__OnTouchMovedActionCallback__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/HotPatch/TsHotFixActionHandle.TsHotFixActionHandle_C:OnTouchMovedActionCallback__DelegateSignature");
			}
			return TsHotFixActionHandle_C.__OnTouchMovedActionCallback__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x06026B38 RID: 158520 RVA: 0x009DF77D File Offset: 0x009DD97D
		public OnTouchMovedActionCallback()
		{
		}

		// Token: 0x06026B39 RID: 158521 RVA: 0x009DF785 File Offset: 0x009DD985
		[NullableContext(2)]
		public OnTouchMovedActionCallback(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06026B3A RID: 158522 RVA: 0x009DF78F File Offset: 0x009DD98F
		public OnTouchMovedActionCallback(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06026B3B RID: 158523 RVA: 0x009DF79A File Offset: 0x009DD99A
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action<TEnumAsByte<ETouchIndex>, FVector>) ?? ((Action<TEnumAsByte<ETouchIndex>, FVector>)Delegate.CreateDelegate(typeof(Action<TEnumAsByte<ETouchIndex>, FVector>), Callback.Target, Callback.Method)));
		}

		// Token: 0x06026B3C RID: 158524 RVA: 0x009DF7CC File Offset: 0x009DD9CC
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add([Nullable(new byte[]
		{
			1,
			0
		})] Action<TEnumAsByte<ETouchIndex>, FVector> Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x06026B3D RID: 158525 RVA: 0x009DF7DB File Offset: 0x009DD9DB
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove([Nullable(new byte[]
		{
			1,
			0
		})] Action<TEnumAsByte<ETouchIndex>, FVector> Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x06026B3E RID: 158526 RVA: 0x009DF7E4 File Offset: 0x009DD9E4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void Broadcast(ETouchIndex touchIndex, FVector TouchPosition)
		{
			OnTouchMovedActionCallback.__OnTouchMovedActionCallback_DelegateParams* ptr = stackalloc OnTouchMovedActionCallback.__OnTouchMovedActionCallback_DelegateParams[(UIntPtr)31] + 15L / (long)sizeof(OnTouchMovedActionCallback.__OnTouchMovedActionCallback_DelegateParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(OnTouchMovedActionCallback.StaticFunctionPtr(), (void*)ptr, 1);
			ptr->touchIndex = touchIndex;
			ptr->TouchPosition = TouchPosition;
			base.BroadcastInternal((void*)ptr);
		}

		// Token: 0x06026B3F RID: 158527 RVA: 0x009DF82C File Offset: 0x009DDA2C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveOptimization)]
		protected unsafe static void OnScriptCallback(IntPtr __Handle, byte* __Parameters)
		{
			object target = GCHandle.FromIntPtr(__Handle).Target;
			Action<TEnumAsByte<ETouchIndex>, FVector> action = target as Action<TEnumAsByte<ETouchIndex>, FVector>;
			if (action == null)
			{
				throw new ArgumentException((target != null) ? target.GetType().ToString() : null);
			}
			action(((OnTouchMovedActionCallback.__OnTouchMovedActionCallback_DelegateParams*)__Parameters)->touchIndex, ((OnTouchMovedActionCallback.__OnTouchMovedActionCallback_DelegateParams*)__Parameters)->TouchPosition);
		}

		// Token: 0x040142C3 RID: 82627
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/HotPatch/TsHotFixActionHandle.TsHotFixActionHandle_C:OnTouchMovedActionCallback__DelegateSignature";

		// Token: 0x0200A0A0 RID: 41120
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __OnTouchMovedActionCallback_DelegateParams
		{
			// Token: 0x04032D48 RID: 208200
			[FieldOffset(0)]
			public TEnumAsByte<ETouchIndex> touchIndex;

			// Token: 0x04032D49 RID: 208201
			[FieldOffset(4)]
			public FVector TouchPosition;
		}
	}
}
