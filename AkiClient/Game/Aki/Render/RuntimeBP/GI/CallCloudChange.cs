using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Render.RuntimeBP.GI.NewCloud.BP;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.GI
{
	// Token: 0x02003C9B RID: 15515
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class CallCloudChange : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x06024822 RID: 149538 RVA: 0x0099FA07 File Offset: 0x0099DC07
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return CallCloudChange.StaticFunctionPtr();
		}

		// Token: 0x06024823 RID: 149539 RVA: 0x0099FA13 File Offset: 0x0099DC13
		private static IntPtr StaticFunctionPtr()
		{
			if (BP_GlobalGI_C.__CallCloudChange__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				BP_GlobalGI_C.__CallCloudChange__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/Render/RuntimeBP/GI/BP_GlobalGI.BP_GlobalGI_C:CallCloudChange__DelegateSignature");
			}
			return BP_GlobalGI_C.__CallCloudChange__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x06024824 RID: 149540 RVA: 0x0099FA36 File Offset: 0x0099DC36
		public CallCloudChange()
		{
		}

		// Token: 0x06024825 RID: 149541 RVA: 0x0099FA3E File Offset: 0x0099DC3E
		[NullableContext(2)]
		public CallCloudChange(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06024826 RID: 149542 RVA: 0x0099FA48 File Offset: 0x0099DC48
		public CallCloudChange(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06024827 RID: 149543 RVA: 0x0099FA53 File Offset: 0x0099DC53
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action<TEnumAsByte<E_Cloud_Presents>, float, bool>) ?? ((Action<TEnumAsByte<E_Cloud_Presents>, float, bool>)Delegate.CreateDelegate(typeof(Action<TEnumAsByte<E_Cloud_Presents>, float, bool>), Callback.Target, Callback.Method)));
		}

		// Token: 0x06024828 RID: 149544 RVA: 0x0099FA85 File Offset: 0x0099DC85
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add([Nullable(new byte[]
		{
			1,
			0
		})] Action<TEnumAsByte<E_Cloud_Presents>, float, bool> Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x06024829 RID: 149545 RVA: 0x0099FA94 File Offset: 0x0099DC94
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove([Nullable(new byte[]
		{
			1,
			0
		})] Action<TEnumAsByte<E_Cloud_Presents>, float, bool> Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x0602482A RID: 149546 RVA: 0x0099FAA0 File Offset: 0x0099DCA0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void Broadcast(E_Cloud_Presents CloudPresents, float ChangeSpeed, bool IsinEditor)
		{
			CallCloudChange.__CallCloudChange_DelegateParams* ptr = stackalloc CallCloudChange.__CallCloudChange_DelegateParams[(UIntPtr)27] + 15L / (long)sizeof(CallCloudChange.__CallCloudChange_DelegateParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(CallCloudChange.StaticFunctionPtr(), (void*)ptr, 1);
			ptr->CloudPresents = CloudPresents;
			ptr->ChangeSpeed = ChangeSpeed;
			ptr->IsinEditor = IsinEditor;
			base.BroadcastInternal((void*)ptr);
		}

		// Token: 0x0602482B RID: 149547 RVA: 0x0099FAF0 File Offset: 0x0099DCF0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveOptimization)]
		protected unsafe static void OnScriptCallback(IntPtr __Handle, byte* __Parameters)
		{
			object target = GCHandle.FromIntPtr(__Handle).Target;
			Action<TEnumAsByte<E_Cloud_Presents>, float, bool> action = target as Action<TEnumAsByte<E_Cloud_Presents>, float, bool>;
			if (action == null)
			{
				throw new ArgumentException((target != null) ? target.GetType().ToString() : null);
			}
			action(((CallCloudChange.__CallCloudChange_DelegateParams*)__Parameters)->CloudPresents, ((CallCloudChange.__CallCloudChange_DelegateParams*)__Parameters)->ChangeSpeed, ((CallCloudChange.__CallCloudChange_DelegateParams*)__Parameters)->IsinEditor);
		}

		// Token: 0x04012B46 RID: 76614
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/GI/BP_GlobalGI.BP_GlobalGI_C:CallCloudChange__DelegateSignature";

		// Token: 0x02009E01 RID: 40449
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __CallCloudChange_DelegateParams
		{
			// Token: 0x04032845 RID: 206917
			[FieldOffset(0)]
			public TEnumAsByte<E_Cloud_Presents> CloudPresents;

			// Token: 0x04032846 RID: 206918
			[FieldOffset(4)]
			public float ChangeSpeed;

			// Token: 0x04032847 RID: 206919
			[FieldOffset(8)]
			public bool IsinEditor;
		}
	}
}
