using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.UI.Manager
{
	// Token: 0x0200399C RID: 14748
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class 开始吸取污染物 : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x0601DC3F RID: 121919 RVA: 0x008E011D File Offset: 0x008DE31D
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return 开始吸取污染物.StaticFunctionPtr();
		}

		// Token: 0x0601DC40 RID: 121920 RVA: 0x008E0129 File Offset: 0x008DE329
		private static IntPtr StaticFunctionPtr()
		{
			if (BP_EventManager_C.__开始吸取污染物__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				BP_EventManager_C.__开始吸取污染物__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/UI/Manager/BP_EventManager.BP_EventManager_C:开始吸取污染物__DelegateSignature");
			}
			return BP_EventManager_C.__开始吸取污染物__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x0601DC41 RID: 121921 RVA: 0x008E014C File Offset: 0x008DE34C
		public 开始吸取污染物()
		{
		}

		// Token: 0x0601DC42 RID: 121922 RVA: 0x008E0154 File Offset: 0x008DE354
		[NullableContext(2)]
		public 开始吸取污染物(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0601DC43 RID: 121923 RVA: 0x008E015E File Offset: 0x008DE35E
		public 开始吸取污染物(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0601DC44 RID: 121924 RVA: 0x008E0169 File Offset: 0x008DE369
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action<int>) ?? ((Action<int>)Delegate.CreateDelegate(typeof(Action<int>), Callback.Target, Callback.Method)));
		}

		// Token: 0x0601DC45 RID: 121925 RVA: 0x008E019B File Offset: 0x008DE39B
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add(Action<int> Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x0601DC46 RID: 121926 RVA: 0x008E01AA File Offset: 0x008DE3AA
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove(Action<int> Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x0601DC47 RID: 121927 RVA: 0x008E01B4 File Offset: 0x008DE3B4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void Broadcast(int EntityId)
		{
			开始吸取污染物.__开始吸取污染物_DelegateParams* ptr = stackalloc 开始吸取污染物.__开始吸取污染物_DelegateParams[(UIntPtr)19] + 15L / (long)sizeof(开始吸取污染物.__开始吸取污染物_DelegateParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(开始吸取污染物.StaticFunctionPtr(), (void*)ptr, 1);
			ptr->EntityId = EntityId;
			base.BroadcastInternal((void*)ptr);
		}

		// Token: 0x0601DC48 RID: 121928 RVA: 0x008E01F0 File Offset: 0x008DE3F0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveOptimization)]
		protected unsafe static void OnScriptCallback(IntPtr __Handle, byte* __Parameters)
		{
			object target = GCHandle.FromIntPtr(__Handle).Target;
			Action<int> action = target as Action<int>;
			if (action == null)
			{
				throw new ArgumentException((target != null) ? target.GetType().ToString() : null);
			}
			action(((开始吸取污染物.__开始吸取污染物_DelegateParams*)__Parameters)->EntityId);
		}

		// Token: 0x0400E96A RID: 59754
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/UI/Manager/BP_EventManager.BP_EventManager_C:开始吸取污染物__DelegateSignature";

		// Token: 0x020096CA RID: 38602
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __开始吸取污染物_DelegateParams
		{
			// Token: 0x04031BAB RID: 203691
			[FieldOffset(0)]
			public int EntityId;
		}
	}
}
