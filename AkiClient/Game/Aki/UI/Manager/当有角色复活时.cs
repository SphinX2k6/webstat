using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.UI.Manager
{
	// Token: 0x020039A0 RID: 14752
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class 当有角色复活时 : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x0601DC67 RID: 121959 RVA: 0x008E05CE File Offset: 0x008DE7CE
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return 当有角色复活时.StaticFunctionPtr();
		}

		// Token: 0x0601DC68 RID: 121960 RVA: 0x008E05DA File Offset: 0x008DE7DA
		private static IntPtr StaticFunctionPtr()
		{
			if (BP_EventManager_C.__当有角色复活时__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				BP_EventManager_C.__当有角色复活时__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/UI/Manager/BP_EventManager.BP_EventManager_C:当有角色复活时__DelegateSignature");
			}
			return BP_EventManager_C.__当有角色复活时__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x0601DC69 RID: 121961 RVA: 0x008E05FD File Offset: 0x008DE7FD
		public 当有角色复活时()
		{
		}

		// Token: 0x0601DC6A RID: 121962 RVA: 0x008E0605 File Offset: 0x008DE805
		[NullableContext(2)]
		public 当有角色复活时(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0601DC6B RID: 121963 RVA: 0x008E060F File Offset: 0x008DE80F
		public 当有角色复活时(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0601DC6C RID: 121964 RVA: 0x008E061A File Offset: 0x008DE81A
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action<TsBaseCharacter>) ?? ((Action<TsBaseCharacter>)Delegate.CreateDelegate(typeof(Action<TsBaseCharacter>), Callback.Target, Callback.Method)));
		}

		// Token: 0x0601DC6D RID: 121965 RVA: 0x008E064C File Offset: 0x008DE84C
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add([Nullable(new byte[]
		{
			1,
			2
		})] Action<TsBaseCharacter> Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x0601DC6E RID: 121966 RVA: 0x008E065B File Offset: 0x008DE85B
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove([Nullable(new byte[]
		{
			1,
			2
		})] Action<TsBaseCharacter> Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x0601DC6F RID: 121967 RVA: 0x008E0664 File Offset: 0x008DE864
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void Broadcast(TsBaseCharacter 角色)
		{
			当有角色复活时.__当有角色复活时_DelegateParams* ptr = stackalloc 当有角色复活时.__当有角色复活时_DelegateParams[(UIntPtr)23] + 15L / (long)sizeof(当有角色复活时.__当有角色复活时_DelegateParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(当有角色复活时.StaticFunctionPtr(), (void*)ptr, 1);
			ptr->角色 = ((角色 != null) ? 角色.NativePtr : IntPtr.Zero);
			base.BroadcastInternal((void*)ptr);
		}

		// Token: 0x0601DC70 RID: 121968 RVA: 0x008E06B0 File Offset: 0x008DE8B0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveOptimization)]
		protected unsafe static void OnScriptCallback(IntPtr __Handle, byte* __Parameters)
		{
			object target = GCHandle.FromIntPtr(__Handle).Target;
			Action<TsBaseCharacter> action = target as Action<TsBaseCharacter>;
			if (action == null)
			{
				throw new ArgumentException((target != null) ? target.GetType().ToString() : null);
			}
			TsBaseCharacter orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<TsBaseCharacter>(((当有角色复活时.__当有角色复活时_DelegateParams*)__Parameters)->角色);
			action(orCreateUObjectByNativePointer);
		}

		// Token: 0x0400E96E RID: 59758
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/UI/Manager/BP_EventManager.BP_EventManager_C:当有角色复活时__DelegateSignature";

		// Token: 0x020096CD RID: 38605
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __当有角色复活时_DelegateParams
		{
			// Token: 0x04031BAF RID: 203695
			[FieldOffset(0)]
			public IntPtr 角色;
		}
	}
}
