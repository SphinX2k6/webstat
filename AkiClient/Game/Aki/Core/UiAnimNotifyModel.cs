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
	// Token: 0x02003F3F RID: 16191
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class UiAnimNotifyModel : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x060286EC RID: 165612 RVA: 0x00A0A7EA File Offset: 0x00A089EA
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return UiAnimNotifyModel.StaticFunctionPtr();
		}

		// Token: 0x060286ED RID: 165613 RVA: 0x00A0A7F6 File Offset: 0x00A089F6
		private static IntPtr StaticFunctionPtr()
		{
			if (BP_UiActorCallBack_C.__UiAnimNotifyModel__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				BP_UiActorCallBack_C.__UiAnimNotifyModel__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/Core/BP_UiActorCallBack.BP_UiActorCallBack_C:UiAnimNotifyModel__DelegateSignature");
			}
			return BP_UiActorCallBack_C.__UiAnimNotifyModel__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x060286EE RID: 165614 RVA: 0x00A0A819 File Offset: 0x00A08A19
		public UiAnimNotifyModel()
		{
		}

		// Token: 0x060286EF RID: 165615 RVA: 0x00A0A821 File Offset: 0x00A08A21
		[NullableContext(2)]
		public UiAnimNotifyModel(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x060286F0 RID: 165616 RVA: 0x00A0A82B File Offset: 0x00A08A2B
		public UiAnimNotifyModel(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x060286F1 RID: 165617 RVA: 0x00A0A836 File Offset: 0x00A08A36
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action<SUiAnimNotifyModel, USkeletalMeshComponent>) ?? ((Action<SUiAnimNotifyModel, USkeletalMeshComponent>)Delegate.CreateDelegate(typeof(Action<SUiAnimNotifyModel, USkeletalMeshComponent>), Callback.Target, Callback.Method)));
		}

		// Token: 0x060286F2 RID: 165618 RVA: 0x00A0A868 File Offset: 0x00A08A68
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add([Nullable(new byte[]
		{
			1,
			1,
			2
		})] Action<SUiAnimNotifyModel, USkeletalMeshComponent> Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x060286F3 RID: 165619 RVA: 0x00A0A877 File Offset: 0x00A08A77
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove([Nullable(new byte[]
		{
			1,
			1,
			2
		})] Action<SUiAnimNotifyModel, USkeletalMeshComponent> Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x060286F4 RID: 165620 RVA: 0x00A0A880 File Offset: 0x00A08A80
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void Broadcast(SUiAnimNotifyModel uiAnimNotifyModel, USkeletalMeshComponent mesh)
		{
			UiAnimNotifyModel.__UiAnimNotifyModel_DelegateParams* ptr = stackalloc UiAnimNotifyModel.__UiAnimNotifyModel_DelegateParams[(UIntPtr)223] + 15L / (long)sizeof(UiAnimNotifyModel.__UiAnimNotifyModel_DelegateParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(UiAnimNotifyModel.StaticFunctionPtr(), (void*)ptr, 1);
			if (uiAnimNotifyModel != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SUiAnimNotifyModel.StaticStruct(), &ptr->uiAnimNotifyModel, uiAnimNotifyModel.NativePtr, 1, false);
			}
			ptr->mesh = ((mesh != null) ? mesh.NativePtr : IntPtr.Zero);
			base.BroadcastInternal((void*)ptr);
			UnrealReflectionUtils.DestroyStruct(BP_UiActorCallBack_C.__UiAnimNotifyModel__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x060286F5 RID: 165621 RVA: 0x00A0A904 File Offset: 0x00A08B04
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveOptimization)]
		protected unsafe static void OnScriptCallback(IntPtr __Handle, byte* __Parameters)
		{
			object target = GCHandle.FromIntPtr(__Handle).Target;
			Action<SUiAnimNotifyModel, USkeletalMeshComponent> action = target as Action<SUiAnimNotifyModel, USkeletalMeshComponent>;
			if (action == null)
			{
				throw new ArgumentException((target != null) ? target.GetType().ToString() : null);
			}
			SUiAnimNotifyModel arg = new SUiAnimNotifyModel(&((UiAnimNotifyModel.__UiAnimNotifyModel_DelegateParams*)__Parameters)->uiAnimNotifyModel, true, true);
			USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(((UiAnimNotifyModel.__UiAnimNotifyModel_DelegateParams*)__Parameters)->mesh);
			action(arg, orCreateUObjectByNativePointer);
		}

		// Token: 0x0401544D RID: 87117
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Core/BP_UiActorCallBack.BP_UiActorCallBack_C:UiAnimNotifyModel__DelegateSignature";

		// Token: 0x0200A0EF RID: 41199
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 208)]
		protected ref struct __UiAnimNotifyModel_DelegateParams
		{
			// Token: 0x04032DB6 RID: 208310
			[FieldOffset(0)]
			public byte uiAnimNotifyModel;

			// Token: 0x04032DB7 RID: 208311
			[FieldOffset(192)]
			public IntPtr mesh;
		}
	}
}
