using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.HotPatch
{
	// Token: 0x02003DBD RID: 15805
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class OnTouchActionCallback : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x06026B2C RID: 158508 RVA: 0x009DF611 File Offset: 0x009DD811
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return OnTouchActionCallback.StaticFunctionPtr();
		}

		// Token: 0x06026B2D RID: 158509 RVA: 0x009DF61D File Offset: 0x009DD81D
		private static IntPtr StaticFunctionPtr()
		{
			if (TsHotFixActionHandle_C.__OnTouchActionCallback__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				TsHotFixActionHandle_C.__OnTouchActionCallback__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/HotPatch/TsHotFixActionHandle.TsHotFixActionHandle_C:OnTouchActionCallback__DelegateSignature");
			}
			return TsHotFixActionHandle_C.__OnTouchActionCallback__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x06026B2E RID: 158510 RVA: 0x009DF640 File Offset: 0x009DD840
		public OnTouchActionCallback()
		{
		}

		// Token: 0x06026B2F RID: 158511 RVA: 0x009DF648 File Offset: 0x009DD848
		[NullableContext(2)]
		public OnTouchActionCallback(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06026B30 RID: 158512 RVA: 0x009DF652 File Offset: 0x009DD852
		public OnTouchActionCallback(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06026B31 RID: 158513 RVA: 0x009DF65D File Offset: 0x009DD85D
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action<bool, TEnumAsByte<ETouchIndex>, FVector>) ?? ((Action<bool, TEnumAsByte<ETouchIndex>, FVector>)Delegate.CreateDelegate(typeof(Action<bool, TEnumAsByte<ETouchIndex>, FVector>), Callback.Target, Callback.Method)));
		}

		// Token: 0x06026B32 RID: 158514 RVA: 0x009DF68F File Offset: 0x009DD88F
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add([Nullable(new byte[]
		{
			1,
			0
		})] Action<bool, TEnumAsByte<ETouchIndex>, FVector> Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x06026B33 RID: 158515 RVA: 0x009DF69E File Offset: 0x009DD89E
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove([Nullable(new byte[]
		{
			1,
			0
		})] Action<bool, TEnumAsByte<ETouchIndex>, FVector> Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x06026B34 RID: 158516 RVA: 0x009DF6A8 File Offset: 0x009DD8A8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void Broadcast(bool isPress, ETouchIndex TouchIndex, FVector TouchPosition)
		{
			OnTouchActionCallback.__OnTouchActionCallback_DelegateParams* ptr = stackalloc OnTouchActionCallback.__OnTouchActionCallback_DelegateParams[(UIntPtr)31] + 15L / (long)sizeof(OnTouchActionCallback.__OnTouchActionCallback_DelegateParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(OnTouchActionCallback.StaticFunctionPtr(), (void*)ptr, 1);
			ptr->isPress = isPress;
			ptr->TouchIndex = TouchIndex;
			ptr->TouchPosition = TouchPosition;
			base.BroadcastInternal((void*)ptr);
		}

		// Token: 0x06026B35 RID: 158517 RVA: 0x009DF6F8 File Offset: 0x009DD8F8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveOptimization)]
		protected unsafe static void OnScriptCallback(IntPtr __Handle, byte* __Parameters)
		{
			object target = GCHandle.FromIntPtr(__Handle).Target;
			Action<bool, TEnumAsByte<ETouchIndex>, FVector> action = target as Action<bool, TEnumAsByte<ETouchIndex>, FVector>;
			if (action == null)
			{
				throw new ArgumentException((target != null) ? target.GetType().ToString() : null);
			}
			action(((OnTouchActionCallback.__OnTouchActionCallback_DelegateParams*)__Parameters)->isPress, ((OnTouchActionCallback.__OnTouchActionCallback_DelegateParams*)__Parameters)->TouchIndex, ((OnTouchActionCallback.__OnTouchActionCallback_DelegateParams*)__Parameters)->TouchPosition);
		}

		// Token: 0x040142C2 RID: 82626
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/HotPatch/TsHotFixActionHandle.TsHotFixActionHandle_C:OnTouchActionCallback__DelegateSignature";

		// Token: 0x0200A09F RID: 41119
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __OnTouchActionCallback_DelegateParams
		{
			// Token: 0x04032D45 RID: 208197
			[FieldOffset(0)]
			public bool isPress;

			// Token: 0x04032D46 RID: 208198
			[FieldOffset(1)]
			public TEnumAsByte<ETouchIndex> TouchIndex;

			// Token: 0x04032D47 RID: 208199
			[FieldOffset(4)]
			public FVector TouchPosition;
		}
	}
}
