using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.UI.Manager
{
	// Token: 0x020039AE RID: 14766
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class 被控物撞到水面时 : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x0601DCF3 RID: 122099 RVA: 0x008E15C2 File Offset: 0x008DF7C2
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return 被控物撞到水面时.StaticFunctionPtr();
		}

		// Token: 0x0601DCF4 RID: 122100 RVA: 0x008E15CE File Offset: 0x008DF7CE
		private static IntPtr StaticFunctionPtr()
		{
			if (BP_EventManager_C.__被控物撞到水面时__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				BP_EventManager_C.__被控物撞到水面时__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/UI/Manager/BP_EventManager.BP_EventManager_C:被控物撞到水面时__DelegateSignature");
			}
			return BP_EventManager_C.__被控物撞到水面时__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x0601DCF5 RID: 122101 RVA: 0x008E15F1 File Offset: 0x008DF7F1
		public 被控物撞到水面时()
		{
		}

		// Token: 0x0601DCF6 RID: 122102 RVA: 0x008E15F9 File Offset: 0x008DF7F9
		[NullableContext(2)]
		public 被控物撞到水面时(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0601DCF7 RID: 122103 RVA: 0x008E1603 File Offset: 0x008DF803
		public 被控物撞到水面时(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0601DCF8 RID: 122104 RVA: 0x008E160E File Offset: 0x008DF80E
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action<AActor, AActor>) ?? ((Action<AActor, AActor>)Delegate.CreateDelegate(typeof(Action<AActor, AActor>), Callback.Target, Callback.Method)));
		}

		// Token: 0x0601DCF9 RID: 122105 RVA: 0x008E1640 File Offset: 0x008DF840
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add([Nullable(new byte[]
		{
			1,
			2,
			2
		})] Action<AActor, AActor> Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x0601DCFA RID: 122106 RVA: 0x008E164F File Offset: 0x008DF84F
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove([Nullable(new byte[]
		{
			1,
			2,
			2
		})] Action<AActor, AActor> Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x0601DCFB RID: 122107 RVA: 0x008E1658 File Offset: 0x008DF858
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void Broadcast(AActor 被控物, AActor 水面)
		{
			被控物撞到水面时.__被控物撞到水面时_DelegateParams* ptr = stackalloc 被控物撞到水面时.__被控物撞到水面时_DelegateParams[(UIntPtr)31] + 15L / (long)sizeof(被控物撞到水面时.__被控物撞到水面时_DelegateParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(被控物撞到水面时.StaticFunctionPtr(), (void*)ptr, 1);
			ptr->被控物 = ((被控物 != null) ? 被控物.NativePtr : IntPtr.Zero);
			ptr->水面 = ((水面 != null) ? 水面.NativePtr : IntPtr.Zero);
			base.BroadcastInternal((void*)ptr);
		}

		// Token: 0x0601DCFC RID: 122108 RVA: 0x008E16BC File Offset: 0x008DF8BC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveOptimization)]
		protected unsafe static void OnScriptCallback(IntPtr __Handle, byte* __Parameters)
		{
			object target = GCHandle.FromIntPtr(__Handle).Target;
			Action<AActor, AActor> action = target as Action<AActor, AActor>;
			if (action == null)
			{
				throw new ArgumentException((target != null) ? target.GetType().ToString() : null);
			}
			AActor orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AActor>(((被控物撞到水面时.__被控物撞到水面时_DelegateParams*)__Parameters)->被控物);
			AActor orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<AActor>(((被控物撞到水面时.__被控物撞到水面时_DelegateParams*)__Parameters)->水面);
			action(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
		}

		// Token: 0x0400E97C RID: 59772
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/UI/Manager/BP_EventManager.BP_EventManager_C:被控物撞到水面时__DelegateSignature";

		// Token: 0x020096D7 RID: 38615
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __被控物撞到水面时_DelegateParams
		{
			// Token: 0x04031BC1 RID: 203713
			[FieldOffset(0)]
			public IntPtr 被控物;

			// Token: 0x04031BC2 RID: 203714
			[FieldOffset(8)]
			public IntPtr 水面;
		}
	}
}
