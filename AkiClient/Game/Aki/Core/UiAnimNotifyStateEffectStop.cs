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
	// Token: 0x02003F41 RID: 16193
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class UiAnimNotifyStateEffectStop : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x06028700 RID: 165632 RVA: 0x00A0AADA File Offset: 0x00A08CDA
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return UiAnimNotifyStateEffectStop.StaticFunctionPtr();
		}

		// Token: 0x06028701 RID: 165633 RVA: 0x00A0AAE6 File Offset: 0x00A08CE6
		private static IntPtr StaticFunctionPtr()
		{
			if (BP_UiActorCallBack_C.__UiAnimNotifyStateEffectStop__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				BP_UiActorCallBack_C.__UiAnimNotifyStateEffectStop__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/Core/BP_UiActorCallBack.BP_UiActorCallBack_C:UiAnimNotifyStateEffectStop__DelegateSignature");
			}
			return BP_UiActorCallBack_C.__UiAnimNotifyStateEffectStop__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x06028702 RID: 165634 RVA: 0x00A0AB09 File Offset: 0x00A08D09
		public UiAnimNotifyStateEffectStop()
		{
		}

		// Token: 0x06028703 RID: 165635 RVA: 0x00A0AB11 File Offset: 0x00A08D11
		[NullableContext(2)]
		public UiAnimNotifyStateEffectStop(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06028704 RID: 165636 RVA: 0x00A0AB1B File Offset: 0x00A08D1B
		public UiAnimNotifyStateEffectStop(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06028705 RID: 165637 RVA: 0x00A0AB26 File Offset: 0x00A08D26
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action<TEnumAsByte<EPerformanceRoleState>, string, USkeletalMeshComponent>) ?? ((Action<TEnumAsByte<EPerformanceRoleState>, string, USkeletalMeshComponent>)Delegate.CreateDelegate(typeof(Action<TEnumAsByte<EPerformanceRoleState>, string, USkeletalMeshComponent>), Callback.Target, Callback.Method)));
		}

		// Token: 0x06028706 RID: 165638 RVA: 0x00A0AB58 File Offset: 0x00A08D58
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

		// Token: 0x06028707 RID: 165639 RVA: 0x00A0AB67 File Offset: 0x00A08D67
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

		// Token: 0x06028708 RID: 165640 RVA: 0x00A0AB70 File Offset: 0x00A08D70
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void Broadcast(EPerformanceRoleState animState, string socketName, [Nullable(2)] USkeletalMeshComponent mesh)
		{
			UiAnimNotifyStateEffectStop.__UiAnimNotifyStateEffectStop_DelegateParams* ptr = stackalloc UiAnimNotifyStateEffectStop.__UiAnimNotifyStateEffectStop_DelegateParams[(UIntPtr)47] + 15L / (long)sizeof(UiAnimNotifyStateEffectStop.__UiAnimNotifyStateEffectStop_DelegateParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(UiAnimNotifyStateEffectStop.StaticFunctionPtr(), (void*)ptr, 1);
			ptr->animState = animState;
			FString.CopyFrom((void*)(&ptr->socketName), socketName);
			ptr->mesh = ((mesh != null) ? mesh.NativePtr : IntPtr.Zero);
			base.BroadcastInternal((void*)ptr);
			UnrealReflectionUtils.DestroyStruct(BP_UiActorCallBack_C.__UiAnimNotifyStateEffectStop__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06028709 RID: 165641 RVA: 0x00A0ABE8 File Offset: 0x00A08DE8
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
			string arg = FString.ToString((void*)(&((UiAnimNotifyStateEffectStop.__UiAnimNotifyStateEffectStop_DelegateParams*)__Parameters)->socketName));
			USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(((UiAnimNotifyStateEffectStop.__UiAnimNotifyStateEffectStop_DelegateParams*)__Parameters)->mesh);
			action(((UiAnimNotifyStateEffectStop.__UiAnimNotifyStateEffectStop_DelegateParams*)__Parameters)->animState, arg, orCreateUObjectByNativePointer);
		}

		// Token: 0x0401544F RID: 87119
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Core/BP_UiActorCallBack.BP_UiActorCallBack_C:UiAnimNotifyStateEffectStop__DelegateSignature";

		// Token: 0x0200A0F1 RID: 41201
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __UiAnimNotifyStateEffectStop_DelegateParams
		{
			// Token: 0x04032DBB RID: 208315
			[FieldOffset(0)]
			public TEnumAsByte<EPerformanceRoleState> animState;

			// Token: 0x04032DBC RID: 208316
			[FieldOffset(8)]
			public FString socketName;

			// Token: 0x04032DBD RID: 208317
			[FieldOffset(24)]
			public IntPtr mesh;
		}
	}
}
