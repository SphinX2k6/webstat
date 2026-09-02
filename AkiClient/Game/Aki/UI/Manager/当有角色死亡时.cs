using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.UI.Manager
{
	// Token: 0x020039A1 RID: 14753
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class 当有角色死亡时 : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x0601DC71 RID: 121969 RVA: 0x008E0701 File Offset: 0x008DE901
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return 当有角色死亡时.StaticFunctionPtr();
		}

		// Token: 0x0601DC72 RID: 121970 RVA: 0x008E070D File Offset: 0x008DE90D
		private static IntPtr StaticFunctionPtr()
		{
			if (BP_EventManager_C.__当有角色死亡时__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				BP_EventManager_C.__当有角色死亡时__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/UI/Manager/BP_EventManager.BP_EventManager_C:当有角色死亡时__DelegateSignature");
			}
			return BP_EventManager_C.__当有角色死亡时__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x0601DC73 RID: 121971 RVA: 0x008E0730 File Offset: 0x008DE930
		public 当有角色死亡时()
		{
		}

		// Token: 0x0601DC74 RID: 121972 RVA: 0x008E0738 File Offset: 0x008DE938
		[NullableContext(2)]
		public 当有角色死亡时(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0601DC75 RID: 121973 RVA: 0x008E0742 File Offset: 0x008DE942
		public 当有角色死亡时(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0601DC76 RID: 121974 RVA: 0x008E074D File Offset: 0x008DE94D
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action<TsBaseCharacter>) ?? ((Action<TsBaseCharacter>)Delegate.CreateDelegate(typeof(Action<TsBaseCharacter>), Callback.Target, Callback.Method)));
		}

		// Token: 0x0601DC77 RID: 121975 RVA: 0x008E077F File Offset: 0x008DE97F
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add([Nullable(new byte[]
		{
			1,
			2
		})] Action<TsBaseCharacter> Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x0601DC78 RID: 121976 RVA: 0x008E078E File Offset: 0x008DE98E
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove([Nullable(new byte[]
		{
			1,
			2
		})] Action<TsBaseCharacter> Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x0601DC79 RID: 121977 RVA: 0x008E0798 File Offset: 0x008DE998
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void Broadcast(TsBaseCharacter 角色)
		{
			当有角色死亡时.__当有角色死亡时_DelegateParams* ptr = stackalloc 当有角色死亡时.__当有角色死亡时_DelegateParams[(UIntPtr)23] + 15L / (long)sizeof(当有角色死亡时.__当有角色死亡时_DelegateParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(当有角色死亡时.StaticFunctionPtr(), (void*)ptr, 1);
			ptr->角色 = ((角色 != null) ? 角色.NativePtr : IntPtr.Zero);
			base.BroadcastInternal((void*)ptr);
		}

		// Token: 0x0601DC7A RID: 121978 RVA: 0x008E07E4 File Offset: 0x008DE9E4
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
			TsBaseCharacter orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<TsBaseCharacter>(((当有角色死亡时.__当有角色死亡时_DelegateParams*)__Parameters)->角色);
			action(orCreateUObjectByNativePointer);
		}

		// Token: 0x0400E96F RID: 59759
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/UI/Manager/BP_EventManager.BP_EventManager_C:当有角色死亡时__DelegateSignature";

		// Token: 0x020096CE RID: 38606
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __当有角色死亡时_DelegateParams
		{
			// Token: 0x04031BB0 RID: 203696
			[FieldOffset(0)]
			public IntPtr 角色;
		}
	}
}
