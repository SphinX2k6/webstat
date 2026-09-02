using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.UI.Manager
{
	// Token: 0x020039A2 RID: 14754
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class 当浮游炮瞄准可以自动开炮时 : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x0601DC7B RID: 121979 RVA: 0x008E0835 File Offset: 0x008DEA35
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return 当浮游炮瞄准可以自动开炮时.StaticFunctionPtr();
		}

		// Token: 0x0601DC7C RID: 121980 RVA: 0x008E0841 File Offset: 0x008DEA41
		private static IntPtr StaticFunctionPtr()
		{
			if (BP_EventManager_C.__当浮游炮瞄准可以自动开炮时__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				BP_EventManager_C.__当浮游炮瞄准可以自动开炮时__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/UI/Manager/BP_EventManager.BP_EventManager_C:当浮游炮瞄准可以自动开炮时__DelegateSignature");
			}
			return BP_EventManager_C.__当浮游炮瞄准可以自动开炮时__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x0601DC7D RID: 121981 RVA: 0x008E0864 File Offset: 0x008DEA64
		public 当浮游炮瞄准可以自动开炮时()
		{
		}

		// Token: 0x0601DC7E RID: 121982 RVA: 0x008E086C File Offset: 0x008DEA6C
		[NullableContext(2)]
		public 当浮游炮瞄准可以自动开炮时(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0601DC7F RID: 121983 RVA: 0x008E0876 File Offset: 0x008DEA76
		public 当浮游炮瞄准可以自动开炮时(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0601DC80 RID: 121984 RVA: 0x008E0881 File Offset: 0x008DEA81
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action<int, FGameplayTag>) ?? ((Action<int, FGameplayTag>)Delegate.CreateDelegate(typeof(Action<int, FGameplayTag>), Callback.Target, Callback.Method)));
		}

		// Token: 0x0601DC81 RID: 121985 RVA: 0x008E08B3 File Offset: 0x008DEAB3
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add(Action<int, FGameplayTag> Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x0601DC82 RID: 121986 RVA: 0x008E08C2 File Offset: 0x008DEAC2
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove(Action<int, FGameplayTag> Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x0601DC83 RID: 121987 RVA: 0x008E08CC File Offset: 0x008DEACC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void Broadcast(int EntityId, FGameplayTag TargetTag)
		{
			当浮游炮瞄准可以自动开炮时.__当浮游炮瞄准可以自动开炮时_DelegateParams* ptr = stackalloc 当浮游炮瞄准可以自动开炮时.__当浮游炮瞄准可以自动开炮时_DelegateParams[(UIntPtr)31] + 15L / (long)sizeof(当浮游炮瞄准可以自动开炮时.__当浮游炮瞄准可以自动开炮时_DelegateParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(当浮游炮瞄准可以自动开炮时.StaticFunctionPtr(), (void*)ptr, 1);
			ptr->EntityId = EntityId;
			ptr->TargetTag = TargetTag;
			base.BroadcastInternal((void*)ptr);
		}

		// Token: 0x0601DC84 RID: 121988 RVA: 0x008E0910 File Offset: 0x008DEB10
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveOptimization)]
		protected unsafe static void OnScriptCallback(IntPtr __Handle, byte* __Parameters)
		{
			object target = GCHandle.FromIntPtr(__Handle).Target;
			Action<int, FGameplayTag> action = target as Action<int, FGameplayTag>;
			if (action == null)
			{
				throw new ArgumentException((target != null) ? target.GetType().ToString() : null);
			}
			action(((当浮游炮瞄准可以自动开炮时.__当浮游炮瞄准可以自动开炮时_DelegateParams*)__Parameters)->EntityId, ((当浮游炮瞄准可以自动开炮时.__当浮游炮瞄准可以自动开炮时_DelegateParams*)__Parameters)->TargetTag);
		}

		// Token: 0x0400E970 RID: 59760
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/UI/Manager/BP_EventManager.BP_EventManager_C:当浮游炮瞄准可以自动开炮时__DelegateSignature";

		// Token: 0x020096CF RID: 38607
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __当浮游炮瞄准可以自动开炮时_DelegateParams
		{
			// Token: 0x04031BB1 RID: 203697
			[FieldOffset(0)]
			public int EntityId;

			// Token: 0x04031BB2 RID: 203698
			[FieldOffset(4)]
			public FGameplayTag TargetTag;
		}
	}
}
