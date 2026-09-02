using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.HotPatch
{
	// Token: 0x02003DBB RID: 15803
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class OnAxisCallback : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x06026B18 RID: 158488 RVA: 0x009DF348 File Offset: 0x009DD548
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return OnAxisCallback.StaticFunctionPtr();
		}

		// Token: 0x06026B19 RID: 158489 RVA: 0x009DF354 File Offset: 0x009DD554
		private static IntPtr StaticFunctionPtr()
		{
			if (TsHotFixActionHandle_C.__OnAxisCallback__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				TsHotFixActionHandle_C.__OnAxisCallback__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/HotPatch/TsHotFixActionHandle.TsHotFixActionHandle_C:OnAxisCallback__DelegateSignature");
			}
			return TsHotFixActionHandle_C.__OnAxisCallback__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x06026B1A RID: 158490 RVA: 0x009DF377 File Offset: 0x009DD577
		public OnAxisCallback()
		{
		}

		// Token: 0x06026B1B RID: 158491 RVA: 0x009DF37F File Offset: 0x009DD57F
		[NullableContext(2)]
		public OnAxisCallback(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06026B1C RID: 158492 RVA: 0x009DF389 File Offset: 0x009DD589
		public OnAxisCallback(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06026B1D RID: 158493 RVA: 0x009DF394 File Offset: 0x009DD594
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action<float, string>) ?? ((Action<float, string>)Delegate.CreateDelegate(typeof(Action<float, string>), Callback.Target, Callback.Method)));
		}

		// Token: 0x06026B1E RID: 158494 RVA: 0x009DF3C6 File Offset: 0x009DD5C6
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add(Action<float, string> Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x06026B1F RID: 158495 RVA: 0x009DF3D5 File Offset: 0x009DD5D5
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove(Action<float, string> Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x06026B20 RID: 158496 RVA: 0x009DF3E0 File Offset: 0x009DD5E0
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void Broadcast(float value, string axisName)
		{
			OnAxisCallback.__OnAxisCallback_DelegateParams* ptr = stackalloc OnAxisCallback.__OnAxisCallback_DelegateParams[(UIntPtr)39] + 15L / (long)sizeof(OnAxisCallback.__OnAxisCallback_DelegateParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(OnAxisCallback.StaticFunctionPtr(), (void*)ptr, 1);
			ptr->value = value;
			FString.CopyFrom((void*)(&ptr->axisName), axisName);
			base.BroadcastInternal((void*)ptr);
			UnrealReflectionUtils.DestroyStruct(TsHotFixActionHandle_C.__OnAxisCallback__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06026B21 RID: 158497 RVA: 0x009DF43C File Offset: 0x009DD63C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveOptimization)]
		protected unsafe static void OnScriptCallback(IntPtr __Handle, byte* __Parameters)
		{
			object target = GCHandle.FromIntPtr(__Handle).Target;
			Action<float, string> action = target as Action<float, string>;
			if (action == null)
			{
				throw new ArgumentException((target != null) ? target.GetType().ToString() : null);
			}
			string arg = FString.ToString((void*)(&((OnAxisCallback.__OnAxisCallback_DelegateParams*)__Parameters)->axisName));
			action(((OnAxisCallback.__OnAxisCallback_DelegateParams*)__Parameters)->value, arg);
		}

		// Token: 0x040142C0 RID: 82624
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/HotPatch/TsHotFixActionHandle.TsHotFixActionHandle_C:OnAxisCallback__DelegateSignature";

		// Token: 0x0200A09D RID: 41117
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __OnAxisCallback_DelegateParams
		{
			// Token: 0x04032D40 RID: 208192
			[FieldOffset(0)]
			public float value;

			// Token: 0x04032D41 RID: 208193
			[FieldOffset(8)]
			public FString axisName;
		}
	}
}
