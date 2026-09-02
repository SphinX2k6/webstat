using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.UI.Framework
{
	// Token: 0x020039B5 RID: 14773
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class OnClickKey : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x0601DD7E RID: 122238 RVA: 0x008E42CB File Offset: 0x008E24CB
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return OnClickKey.StaticFunctionPtr();
		}

		// Token: 0x0601DD7F RID: 122239 RVA: 0x008E42D7 File Offset: 0x008E24D7
		private static IntPtr StaticFunctionPtr()
		{
			if (LGUIEventSystemActor_C.__OnClickKey__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				LGUIEventSystemActor_C.__OnClickKey__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/UI/Framework/LGUIEventSystemActor.LGUIEventSystemActor_C:OnClickKey__DelegateSignature");
			}
			return LGUIEventSystemActor_C.__OnClickKey__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x0601DD80 RID: 122240 RVA: 0x008E42FA File Offset: 0x008E24FA
		public OnClickKey()
		{
		}

		// Token: 0x0601DD81 RID: 122241 RVA: 0x008E4302 File Offset: 0x008E2502
		[NullableContext(2)]
		public OnClickKey(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0601DD82 RID: 122242 RVA: 0x008E430C File Offset: 0x008E250C
		public OnClickKey(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0601DD83 RID: 122243 RVA: 0x008E4317 File Offset: 0x008E2517
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action<FKey, bool>) ?? ((Action<FKey, bool>)Delegate.CreateDelegate(typeof(Action<FKey, bool>), Callback.Target, Callback.Method)));
		}

		// Token: 0x0601DD84 RID: 122244 RVA: 0x008E4349 File Offset: 0x008E2549
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add(Action<FKey, bool> Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x0601DD85 RID: 122245 RVA: 0x008E4358 File Offset: 0x008E2558
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove(Action<FKey, bool> Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x0601DD86 RID: 122246 RVA: 0x008E4364 File Offset: 0x008E2564
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void Broadcast(FKey KeyCode, bool IsPress)
		{
			OnClickKey.__OnClickKey_DelegateParams* ptr = stackalloc OnClickKey.__OnClickKey_DelegateParams[(UIntPtr)55] + 15L / (long)sizeof(OnClickKey.__OnClickKey_DelegateParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(OnClickKey.StaticFunctionPtr(), (void*)ptr, 1);
			if (KeyCode != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FKey.StaticStruct(), &ptr->KeyCode, KeyCode.NativePtr, 1, false);
			}
			ptr->IsPress = IsPress;
			base.BroadcastInternal((void*)ptr);
			UnrealReflectionUtils.DestroyStruct(LGUIEventSystemActor_C.__OnClickKey__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0601DD87 RID: 122247 RVA: 0x008E43D4 File Offset: 0x008E25D4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveOptimization)]
		protected unsafe static void OnScriptCallback(IntPtr __Handle, byte* __Parameters)
		{
			object target = GCHandle.FromIntPtr(__Handle).Target;
			Action<FKey, bool> action = target as Action<FKey, bool>;
			if (action == null)
			{
				throw new ArgumentException((target != null) ? target.GetType().ToString() : null);
			}
			FKey arg = new FKey(&((OnClickKey.__OnClickKey_DelegateParams*)__Parameters)->KeyCode, true, true);
			action(arg, ((OnClickKey.__OnClickKey_DelegateParams*)__Parameters)->IsPress);
		}

		// Token: 0x0400E9D7 RID: 59863
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/UI/Framework/LGUIEventSystemActor.LGUIEventSystemActor_C:OnClickKey__DelegateSignature";

		// Token: 0x02009719 RID: 38681
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __OnClickKey_DelegateParams
		{
			// Token: 0x04031C58 RID: 203864
			[FieldOffset(0)]
			public byte KeyCode;

			// Token: 0x04031C59 RID: 203865
			[FieldOffset(32)]
			public bool IsPress;
		}
	}
}
