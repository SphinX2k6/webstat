using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.HotPatch
{
	// Token: 0x02003DBA RID: 15802
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class OnAnyKeyPressCallback : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x06026B0E RID: 158478 RVA: 0x009DF1F4 File Offset: 0x009DD3F4
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return OnAnyKeyPressCallback.StaticFunctionPtr();
		}

		// Token: 0x06026B0F RID: 158479 RVA: 0x009DF200 File Offset: 0x009DD400
		private static IntPtr StaticFunctionPtr()
		{
			if (TsHotFixActionHandle_C.__OnAnyKeyPressCallback__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				TsHotFixActionHandle_C.__OnAnyKeyPressCallback__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/HotPatch/TsHotFixActionHandle.TsHotFixActionHandle_C:OnAnyKeyPressCallback__DelegateSignature");
			}
			return TsHotFixActionHandle_C.__OnAnyKeyPressCallback__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x06026B10 RID: 158480 RVA: 0x009DF223 File Offset: 0x009DD423
		public OnAnyKeyPressCallback()
		{
		}

		// Token: 0x06026B11 RID: 158481 RVA: 0x009DF22B File Offset: 0x009DD42B
		[NullableContext(2)]
		public OnAnyKeyPressCallback(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06026B12 RID: 158482 RVA: 0x009DF235 File Offset: 0x009DD435
		public OnAnyKeyPressCallback(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06026B13 RID: 158483 RVA: 0x009DF240 File Offset: 0x009DD440
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action<FKey>) ?? ((Action<FKey>)Delegate.CreateDelegate(typeof(Action<FKey>), Callback.Target, Callback.Method)));
		}

		// Token: 0x06026B14 RID: 158484 RVA: 0x009DF272 File Offset: 0x009DD472
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add(Action<FKey> Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x06026B15 RID: 158485 RVA: 0x009DF281 File Offset: 0x009DD481
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove(Action<FKey> Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x06026B16 RID: 158486 RVA: 0x009DF28C File Offset: 0x009DD48C
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void Broadcast(FKey key)
		{
			OnAnyKeyPressCallback.__OnAnyKeyPressCallback_DelegateParams* ptr = stackalloc OnAnyKeyPressCallback.__OnAnyKeyPressCallback_DelegateParams[(UIntPtr)47] + 15L / (long)sizeof(OnAnyKeyPressCallback.__OnAnyKeyPressCallback_DelegateParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(OnAnyKeyPressCallback.StaticFunctionPtr(), (void*)ptr, 1);
			if (key != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FKey.StaticStruct(), &ptr->key, key.NativePtr, 1, false);
			}
			base.BroadcastInternal((void*)ptr);
			UnrealReflectionUtils.DestroyStruct(TsHotFixActionHandle_C.__OnAnyKeyPressCallback__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06026B17 RID: 158487 RVA: 0x009DF2F4 File Offset: 0x009DD4F4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveOptimization)]
		protected unsafe static void OnScriptCallback(IntPtr __Handle, byte* __Parameters)
		{
			object target = GCHandle.FromIntPtr(__Handle).Target;
			Action<FKey> action = target as Action<FKey>;
			if (action == null)
			{
				throw new ArgumentException((target != null) ? target.GetType().ToString() : null);
			}
			FKey obj = new FKey(&((OnAnyKeyPressCallback.__OnAnyKeyPressCallback_DelegateParams*)__Parameters)->key, true, true);
			action(obj);
		}

		// Token: 0x040142BF RID: 82623
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/HotPatch/TsHotFixActionHandle.TsHotFixActionHandle_C:OnAnyKeyPressCallback__DelegateSignature";

		// Token: 0x0200A09C RID: 41116
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __OnAnyKeyPressCallback_DelegateParams
		{
			// Token: 0x04032D3F RID: 208191
			[FieldOffset(0)]
			public byte key;
		}
	}
}
