using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.HotPatch
{
	// Token: 0x02003DBC RID: 15804
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class OnPressActionCallback : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x06026B22 RID: 158498 RVA: 0x009DF494 File Offset: 0x009DD694
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return OnPressActionCallback.StaticFunctionPtr();
		}

		// Token: 0x06026B23 RID: 158499 RVA: 0x009DF4A0 File Offset: 0x009DD6A0
		private static IntPtr StaticFunctionPtr()
		{
			if (TsHotFixActionHandle_C.__OnPressActionCallback__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				TsHotFixActionHandle_C.__OnPressActionCallback__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/HotPatch/TsHotFixActionHandle.TsHotFixActionHandle_C:OnPressActionCallback__DelegateSignature");
			}
			return TsHotFixActionHandle_C.__OnPressActionCallback__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x06026B24 RID: 158500 RVA: 0x009DF4C3 File Offset: 0x009DD6C3
		public OnPressActionCallback()
		{
		}

		// Token: 0x06026B25 RID: 158501 RVA: 0x009DF4CB File Offset: 0x009DD6CB
		[NullableContext(2)]
		public OnPressActionCallback(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06026B26 RID: 158502 RVA: 0x009DF4D5 File Offset: 0x009DD6D5
		public OnPressActionCallback(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06026B27 RID: 158503 RVA: 0x009DF4E0 File Offset: 0x009DD6E0
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action<bool, string, FKey>) ?? ((Action<bool, string, FKey>)Delegate.CreateDelegate(typeof(Action<bool, string, FKey>), Callback.Target, Callback.Method)));
		}

		// Token: 0x06026B28 RID: 158504 RVA: 0x009DF512 File Offset: 0x009DD712
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add(Action<bool, string, FKey> Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x06026B29 RID: 158505 RVA: 0x009DF521 File Offset: 0x009DD721
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove(Action<bool, string, FKey> Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x06026B2A RID: 158506 RVA: 0x009DF52C File Offset: 0x009DD72C
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void Broadcast(bool isPress, string actionName, [Nullable(2)] FKey key)
		{
			OnPressActionCallback.__OnPressActionCallback_DelegateParams* ptr = stackalloc OnPressActionCallback.__OnPressActionCallback_DelegateParams[(UIntPtr)71] + 15L / (long)sizeof(OnPressActionCallback.__OnPressActionCallback_DelegateParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(OnPressActionCallback.StaticFunctionPtr(), (void*)ptr, 1);
			ptr->isPress = isPress;
			FString.CopyFrom((void*)(&ptr->actionName), actionName);
			if (key != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FKey.StaticStruct(), &ptr->key, key.NativePtr, 1, false);
			}
			base.BroadcastInternal((void*)ptr);
			UnrealReflectionUtils.DestroyStruct(TsHotFixActionHandle_C.__OnPressActionCallback__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06026B2B RID: 158507 RVA: 0x009DF5A8 File Offset: 0x009DD7A8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveOptimization)]
		protected unsafe static void OnScriptCallback(IntPtr __Handle, byte* __Parameters)
		{
			object target = GCHandle.FromIntPtr(__Handle).Target;
			Action<bool, string, FKey> action = target as Action<bool, string, FKey>;
			if (action == null)
			{
				throw new ArgumentException((target != null) ? target.GetType().ToString() : null);
			}
			string arg = FString.ToString((void*)(&((OnPressActionCallback.__OnPressActionCallback_DelegateParams*)__Parameters)->actionName));
			FKey arg2 = new FKey(&((OnPressActionCallback.__OnPressActionCallback_DelegateParams*)__Parameters)->key, true, true);
			action(((OnPressActionCallback.__OnPressActionCallback_DelegateParams*)__Parameters)->isPress, arg, arg2);
		}

		// Token: 0x040142C1 RID: 82625
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/HotPatch/TsHotFixActionHandle.TsHotFixActionHandle_C:OnPressActionCallback__DelegateSignature";

		// Token: 0x0200A09E RID: 41118
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 56)]
		protected ref struct __OnPressActionCallback_DelegateParams
		{
			// Token: 0x04032D42 RID: 208194
			[FieldOffset(0)]
			public bool isPress;

			// Token: 0x04032D43 RID: 208195
			[FieldOffset(8)]
			public FString actionName;

			// Token: 0x04032D44 RID: 208196
			[FieldOffset(24)]
			public byte key;
		}
	}
}
