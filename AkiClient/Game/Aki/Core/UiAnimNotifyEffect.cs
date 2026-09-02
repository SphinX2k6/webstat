using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Core
{
	// Token: 0x02003F3D RID: 16189
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class UiAnimNotifyEffect : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x060286D8 RID: 165592 RVA: 0x00A0A54B File Offset: 0x00A0874B
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return UiAnimNotifyEffect.StaticFunctionPtr();
		}

		// Token: 0x060286D9 RID: 165593 RVA: 0x00A0A557 File Offset: 0x00A08757
		private static IntPtr StaticFunctionPtr()
		{
			if (BP_UiActorCallBack_C.__UiAnimNotifyEffect__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				BP_UiActorCallBack_C.__UiAnimNotifyEffect__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/Core/BP_UiActorCallBack.BP_UiActorCallBack_C:UiAnimNotifyEffect__DelegateSignature");
			}
			return BP_UiActorCallBack_C.__UiAnimNotifyEffect__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x060286DA RID: 165594 RVA: 0x00A0A57A File Offset: 0x00A0877A
		public UiAnimNotifyEffect()
		{
		}

		// Token: 0x060286DB RID: 165595 RVA: 0x00A0A582 File Offset: 0x00A08782
		[NullableContext(2)]
		public UiAnimNotifyEffect(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x060286DC RID: 165596 RVA: 0x00A0A58C File Offset: 0x00A0878C
		public UiAnimNotifyEffect(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x060286DD RID: 165597 RVA: 0x00A0A597 File Offset: 0x00A08797
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action<SUiAnimNotifyEffect, USkeletalMeshComponent>) ?? ((Action<SUiAnimNotifyEffect, USkeletalMeshComponent>)Delegate.CreateDelegate(typeof(Action<SUiAnimNotifyEffect, USkeletalMeshComponent>), Callback.Target, Callback.Method)));
		}

		// Token: 0x060286DE RID: 165598 RVA: 0x00A0A5C9 File Offset: 0x00A087C9
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add([Nullable(new byte[]
		{
			1,
			1,
			2
		})] Action<SUiAnimNotifyEffect, USkeletalMeshComponent> Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x060286DF RID: 165599 RVA: 0x00A0A5D8 File Offset: 0x00A087D8
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove([Nullable(new byte[]
		{
			1,
			1,
			2
		})] Action<SUiAnimNotifyEffect, USkeletalMeshComponent> Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x060286E0 RID: 165600 RVA: 0x00A0A5E4 File Offset: 0x00A087E4
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void Broadcast(SUiAnimNotifyEffect uiAnimNotifyEffect, USkeletalMeshComponent mesh)
		{
			UiAnimNotifyEffect.__UiAnimNotifyEffect_DelegateParams* ptr = stackalloc UiAnimNotifyEffect.__UiAnimNotifyEffect_DelegateParams[(UIntPtr)127] + 15L / (long)sizeof(UiAnimNotifyEffect.__UiAnimNotifyEffect_DelegateParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(UiAnimNotifyEffect.StaticFunctionPtr(), (void*)ptr, 1);
			if (uiAnimNotifyEffect != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SUiAnimNotifyEffect.StaticStruct(), &ptr->uiAnimNotifyEffect, uiAnimNotifyEffect.NativePtr, 1, false);
			}
			ptr->mesh = ((mesh != null) ? mesh.NativePtr : IntPtr.Zero);
			base.BroadcastInternal((void*)ptr);
			UnrealReflectionUtils.DestroyStruct(BP_UiActorCallBack_C.__UiAnimNotifyEffect__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x060286E1 RID: 165601 RVA: 0x00A0A664 File Offset: 0x00A08864
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveOptimization)]
		protected unsafe static void OnScriptCallback(IntPtr __Handle, byte* __Parameters)
		{
			object target = GCHandle.FromIntPtr(__Handle).Target;
			Action<SUiAnimNotifyEffect, USkeletalMeshComponent> action = target as Action<SUiAnimNotifyEffect, USkeletalMeshComponent>;
			if (action == null)
			{
				throw new ArgumentException((target != null) ? target.GetType().ToString() : null);
			}
			SUiAnimNotifyEffect arg = new SUiAnimNotifyEffect(&((UiAnimNotifyEffect.__UiAnimNotifyEffect_DelegateParams*)__Parameters)->uiAnimNotifyEffect, true, true);
			USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(((UiAnimNotifyEffect.__UiAnimNotifyEffect_DelegateParams*)__Parameters)->mesh);
			action(arg, orCreateUObjectByNativePointer);
		}

		// Token: 0x0401544B RID: 87115
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Core/BP_UiActorCallBack.BP_UiActorCallBack_C:UiAnimNotifyEffect__DelegateSignature";

		// Token: 0x0200A0ED RID: 41197
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 112)]
		protected ref struct __UiAnimNotifyEffect_DelegateParams
		{
			// Token: 0x04032DB3 RID: 208307
			[FieldOffset(0)]
			public byte uiAnimNotifyEffect;

			// Token: 0x04032DB4 RID: 208308
			[FieldOffset(96)]
			public IntPtr mesh;
		}
	}
}
