using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Character.Role.Common.Data.Enum;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Core
{
	// Token: 0x02003F40 RID: 16192
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class UiAnimNotifyStateEffectPlay : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x060286F6 RID: 165622 RVA: 0x00A0A966 File Offset: 0x00A08B66
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return UiAnimNotifyStateEffectPlay.StaticFunctionPtr();
		}

		// Token: 0x060286F7 RID: 165623 RVA: 0x00A0A972 File Offset: 0x00A08B72
		private static IntPtr StaticFunctionPtr()
		{
			if (BP_UiActorCallBack_C.__UiAnimNotifyStateEffectPlay__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				BP_UiActorCallBack_C.__UiAnimNotifyStateEffectPlay__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/Core/BP_UiActorCallBack.BP_UiActorCallBack_C:UiAnimNotifyStateEffectPlay__DelegateSignature");
			}
			return BP_UiActorCallBack_C.__UiAnimNotifyStateEffectPlay__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x060286F8 RID: 165624 RVA: 0x00A0A995 File Offset: 0x00A08B95
		public UiAnimNotifyStateEffectPlay()
		{
		}

		// Token: 0x060286F9 RID: 165625 RVA: 0x00A0A99D File Offset: 0x00A08B9D
		[NullableContext(2)]
		public UiAnimNotifyStateEffectPlay(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x060286FA RID: 165626 RVA: 0x00A0A9A7 File Offset: 0x00A08BA7
		public UiAnimNotifyStateEffectPlay(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x060286FB RID: 165627 RVA: 0x00A0A9B2 File Offset: 0x00A08BB2
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action<TEnumAsByte<EPerformanceRoleState>, string, USkeletalMeshComponent>) ?? ((Action<TEnumAsByte<EPerformanceRoleState>, string, USkeletalMeshComponent>)Delegate.CreateDelegate(typeof(Action<TEnumAsByte<EPerformanceRoleState>, string, USkeletalMeshComponent>), Callback.Target, Callback.Method)));
		}

		// Token: 0x060286FC RID: 165628 RVA: 0x00A0A9E4 File Offset: 0x00A08BE4
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add([Nullable(new byte[]
		{
			1,
			0,
			1,
			2
		})] Action<TEnumAsByte<EPerformanceRoleState>, string, USkeletalMeshComponent> Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x060286FD RID: 165629 RVA: 0x00A0A9F3 File Offset: 0x00A08BF3
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove([Nullable(new byte[]
		{
			1,
			0,
			1,
			2
		})] Action<TEnumAsByte<EPerformanceRoleState>, string, USkeletalMeshComponent> Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x060286FE RID: 165630 RVA: 0x00A0A9FC File Offset: 0x00A08BFC
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void Broadcast(EPerformanceRoleState animState, string socketName, [Nullable(2)] USkeletalMeshComponent mesh)
		{
			UiAnimNotifyStateEffectPlay.__UiAnimNotifyStateEffectPlay_DelegateParams* ptr = stackalloc UiAnimNotifyStateEffectPlay.__UiAnimNotifyStateEffectPlay_DelegateParams[(UIntPtr)47] + 15L / (long)sizeof(UiAnimNotifyStateEffectPlay.__UiAnimNotifyStateEffectPlay_DelegateParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(UiAnimNotifyStateEffectPlay.StaticFunctionPtr(), (void*)ptr, 1);
			ptr->animState = animState;
			FString.CopyFrom((void*)(&ptr->socketName), socketName);
			ptr->mesh = ((mesh != null) ? mesh.NativePtr : IntPtr.Zero);
			base.BroadcastInternal((void*)ptr);
			UnrealReflectionUtils.DestroyStruct(BP_UiActorCallBack_C.__UiAnimNotifyStateEffectPlay__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x060286FF RID: 165631 RVA: 0x00A0AA74 File Offset: 0x00A08C74
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveOptimization)]
		protected unsafe static void OnScriptCallback(IntPtr __Handle, byte* __Parameters)
		{
			object target = GCHandle.FromIntPtr(__Handle).Target;
			Action<TEnumAsByte<EPerformanceRoleState>, string, USkeletalMeshComponent> action = target as Action<TEnumAsByte<EPerformanceRoleState>, string, USkeletalMeshComponent>;
			if (action == null)
			{
				throw new ArgumentException((target != null) ? target.GetType().ToString() : null);
			}
			string arg = FString.ToString((void*)(&((UiAnimNotifyStateEffectPlay.__UiAnimNotifyStateEffectPlay_DelegateParams*)__Parameters)->socketName));
			USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(((UiAnimNotifyStateEffectPlay.__UiAnimNotifyStateEffectPlay_DelegateParams*)__Parameters)->mesh);
			action(((UiAnimNotifyStateEffectPlay.__UiAnimNotifyStateEffectPlay_DelegateParams*)__Parameters)->animState, arg, orCreateUObjectByNativePointer);
		}

		// Token: 0x0401544E RID: 87118
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Core/BP_UiActorCallBack.BP_UiActorCallBack_C:UiAnimNotifyStateEffectPlay__DelegateSignature";

		// Token: 0x0200A0F0 RID: 41200
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __UiAnimNotifyStateEffectPlay_DelegateParams
		{
			// Token: 0x04032DB8 RID: 208312
			[FieldOffset(0)]
			public TEnumAsByte<EPerformanceRoleState> animState;

			// Token: 0x04032DB9 RID: 208313
			[FieldOffset(8)]
			public FString socketName;

			// Token: 0x04032DBA RID: 208314
			[FieldOffset(24)]
			public IntPtr mesh;
		}
	}
}
