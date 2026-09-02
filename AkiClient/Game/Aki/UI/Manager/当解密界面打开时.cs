using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.UI.Manager
{
	// Token: 0x020039A4 RID: 14756
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class 当解密界面打开时 : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x0601DC8F RID: 121999 RVA: 0x008E0A42 File Offset: 0x008DEC42
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return 当解密界面打开时.StaticFunctionPtr();
		}

		// Token: 0x0601DC90 RID: 122000 RVA: 0x008E0A4E File Offset: 0x008DEC4E
		private static IntPtr StaticFunctionPtr()
		{
			if (BP_EventManager_C.__当解密界面打开时__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				BP_EventManager_C.__当解密界面打开时__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/UI/Manager/BP_EventManager.BP_EventManager_C:当解密界面打开时__DelegateSignature");
			}
			return BP_EventManager_C.__当解密界面打开时__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x0601DC91 RID: 122001 RVA: 0x008E0A71 File Offset: 0x008DEC71
		public 当解密界面打开时()
		{
		}

		// Token: 0x0601DC92 RID: 122002 RVA: 0x008E0A79 File Offset: 0x008DEC79
		[NullableContext(2)]
		public 当解密界面打开时(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0601DC93 RID: 122003 RVA: 0x008E0A83 File Offset: 0x008DEC83
		public 当解密界面打开时(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0601DC94 RID: 122004 RVA: 0x008E0A8E File Offset: 0x008DEC8E
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action<FName>) ?? ((Action<FName>)Delegate.CreateDelegate(typeof(Action<FName>), Callback.Target, Callback.Method)));
		}

		// Token: 0x0601DC95 RID: 122005 RVA: 0x008E0AC0 File Offset: 0x008DECC0
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add(Action<FName> Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x0601DC96 RID: 122006 RVA: 0x008E0ACF File Offset: 0x008DECCF
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove(Action<FName> Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x0601DC97 RID: 122007 RVA: 0x008E0AD8 File Offset: 0x008DECD8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void Broadcast(FName inID)
		{
			当解密界面打开时.__当解密界面打开时_DelegateParams* ptr = stackalloc 当解密界面打开时.__当解密界面打开时_DelegateParams[(UIntPtr)27] + 15L / (long)sizeof(当解密界面打开时.__当解密界面打开时_DelegateParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(当解密界面打开时.StaticFunctionPtr(), (void*)ptr, 1);
			ptr->inID = inID;
			base.BroadcastInternal((void*)ptr);
		}

		// Token: 0x0601DC98 RID: 122008 RVA: 0x008E0B14 File Offset: 0x008DED14
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveOptimization)]
		protected unsafe static void OnScriptCallback(IntPtr __Handle, byte* __Parameters)
		{
			object target = GCHandle.FromIntPtr(__Handle).Target;
			Action<FName> action = target as Action<FName>;
			if (action == null)
			{
				throw new ArgumentException((target != null) ? target.GetType().ToString() : null);
			}
			action(((当解密界面打开时.__当解密界面打开时_DelegateParams*)__Parameters)->inID);
		}

		// Token: 0x0400E972 RID: 59762
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/UI/Manager/BP_EventManager.BP_EventManager_C:当解密界面打开时__DelegateSignature";

		// Token: 0x020096D0 RID: 38608
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __当解密界面打开时_DelegateParams
		{
			// Token: 0x04031BB3 RID: 203699
			[FieldOffset(0)]
			public FName inID;
		}
	}
}
