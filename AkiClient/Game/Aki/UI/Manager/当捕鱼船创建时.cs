using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.UI.Manager
{
	// Token: 0x0200399D RID: 14749
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class 当捕鱼船创建时 : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x0601DC49 RID: 121929 RVA: 0x008E023A File Offset: 0x008DE43A
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return 当捕鱼船创建时.StaticFunctionPtr();
		}

		// Token: 0x0601DC4A RID: 121930 RVA: 0x008E0246 File Offset: 0x008DE446
		private static IntPtr StaticFunctionPtr()
		{
			if (BP_EventManager_C.__当捕鱼船创建时__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				BP_EventManager_C.__当捕鱼船创建时__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/UI/Manager/BP_EventManager.BP_EventManager_C:当捕鱼船创建时__DelegateSignature");
			}
			return BP_EventManager_C.__当捕鱼船创建时__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x0601DC4B RID: 121931 RVA: 0x008E0269 File Offset: 0x008DE469
		public 当捕鱼船创建时()
		{
		}

		// Token: 0x0601DC4C RID: 121932 RVA: 0x008E0271 File Offset: 0x008DE471
		[NullableContext(2)]
		public 当捕鱼船创建时(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0601DC4D RID: 121933 RVA: 0x008E027B File Offset: 0x008DE47B
		public 当捕鱼船创建时(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0601DC4E RID: 121934 RVA: 0x008E0286 File Offset: 0x008DE486
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action<AActor>) ?? ((Action<AActor>)Delegate.CreateDelegate(typeof(Action<AActor>), Callback.Target, Callback.Method)));
		}

		// Token: 0x0601DC4F RID: 121935 RVA: 0x008E02B8 File Offset: 0x008DE4B8
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add([Nullable(new byte[]
		{
			1,
			2
		})] Action<AActor> Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x0601DC50 RID: 121936 RVA: 0x008E02C7 File Offset: 0x008DE4C7
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove([Nullable(new byte[]
		{
			1,
			2
		})] Action<AActor> Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x0601DC51 RID: 121937 RVA: 0x008E02D0 File Offset: 0x008DE4D0
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void Broadcast(AActor fishingBoat)
		{
			当捕鱼船创建时.__当捕鱼船创建时_DelegateParams* ptr = stackalloc 当捕鱼船创建时.__当捕鱼船创建时_DelegateParams[(UIntPtr)23] + 15L / (long)sizeof(当捕鱼船创建时.__当捕鱼船创建时_DelegateParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(当捕鱼船创建时.StaticFunctionPtr(), (void*)ptr, 1);
			ptr->fishingBoat = ((fishingBoat != null) ? fishingBoat.NativePtr : IntPtr.Zero);
			base.BroadcastInternal((void*)ptr);
		}

		// Token: 0x0601DC52 RID: 121938 RVA: 0x008E031C File Offset: 0x008DE51C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveOptimization)]
		protected unsafe static void OnScriptCallback(IntPtr __Handle, byte* __Parameters)
		{
			object target = GCHandle.FromIntPtr(__Handle).Target;
			Action<AActor> action = target as Action<AActor>;
			if (action == null)
			{
				throw new ArgumentException((target != null) ? target.GetType().ToString() : null);
			}
			AActor orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AActor>(((当捕鱼船创建时.__当捕鱼船创建时_DelegateParams*)__Parameters)->fishingBoat);
			action(orCreateUObjectByNativePointer);
		}

		// Token: 0x0400E96B RID: 59755
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/UI/Manager/BP_EventManager.BP_EventManager_C:当捕鱼船创建时__DelegateSignature";

		// Token: 0x020096CB RID: 38603
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __当捕鱼船创建时_DelegateParams
		{
			// Token: 0x04031BAC RID: 203692
			[FieldOffset(0)]
			public IntPtr fishingBoat;
		}
	}
}
