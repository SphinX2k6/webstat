using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Common.DollMachine
{
	// Token: 0x02003B1C RID: 15132
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class OnBeginPlay : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x06020851 RID: 133201 RVA: 0x0092E684 File Offset: 0x0092C884
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return OnBeginPlay.StaticFunctionPtr();
		}

		// Token: 0x06020852 RID: 133202 RVA: 0x0092E690 File Offset: 0x0092C890
		private static IntPtr StaticFunctionPtr()
		{
			if (BP_DollActor_C.__OnBeginPlay__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				BP_DollActor_C.__OnBeginPlay__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollActor.BP_DollActor_C:OnBeginPlay__DelegateSignature");
			}
			return BP_DollActor_C.__OnBeginPlay__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x06020853 RID: 133203 RVA: 0x0092E6B3 File Offset: 0x0092C8B3
		public OnBeginPlay()
		{
		}

		// Token: 0x06020854 RID: 133204 RVA: 0x0092E6BB File Offset: 0x0092C8BB
		[NullableContext(2)]
		public OnBeginPlay(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06020855 RID: 133205 RVA: 0x0092E6C5 File Offset: 0x0092C8C5
		public OnBeginPlay(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06020856 RID: 133206 RVA: 0x0092E6D0 File Offset: 0x0092C8D0
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action<BP_DollActor_C>) ?? ((Action<BP_DollActor_C>)Delegate.CreateDelegate(typeof(Action<BP_DollActor_C>), Callback.Target, Callback.Method)));
		}

		// Token: 0x06020857 RID: 133207 RVA: 0x0092E702 File Offset: 0x0092C902
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add([Nullable(new byte[]
		{
			1,
			2
		})] Action<BP_DollActor_C> Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x06020858 RID: 133208 RVA: 0x0092E711 File Offset: 0x0092C911
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove([Nullable(new byte[]
		{
			1,
			2
		})] Action<BP_DollActor_C> Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x06020859 RID: 133209 RVA: 0x0092E71C File Offset: 0x0092C91C
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void Broadcast(BP_DollActor_C Actor)
		{
			OnBeginPlay.__OnBeginPlay_DelegateParams* ptr = stackalloc OnBeginPlay.__OnBeginPlay_DelegateParams[(UIntPtr)23] + 15L / (long)sizeof(OnBeginPlay.__OnBeginPlay_DelegateParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(OnBeginPlay.StaticFunctionPtr(), (void*)ptr, 1);
			ptr->Actor = ((Actor != null) ? Actor.NativePtr : IntPtr.Zero);
			base.BroadcastInternal((void*)ptr);
		}

		// Token: 0x0602085A RID: 133210 RVA: 0x0092E768 File Offset: 0x0092C968
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveOptimization)]
		protected unsafe static void OnScriptCallback(IntPtr __Handle, byte* __Parameters)
		{
			object target = GCHandle.FromIntPtr(__Handle).Target;
			Action<BP_DollActor_C> action = target as Action<BP_DollActor_C>;
			if (action == null)
			{
				throw new ArgumentException((target != null) ? target.GetType().ToString() : null);
			}
			BP_DollActor_C orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<BP_DollActor_C>(((OnBeginPlay.__OnBeginPlay_DelegateParams*)__Parameters)->Actor);
			action(orCreateUObjectByNativePointer);
		}

		// Token: 0x04010433 RID: 66611
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollActor.BP_DollActor_C:OnBeginPlay__DelegateSignature";

		// Token: 0x020099C4 RID: 39364
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __OnBeginPlay_DelegateParams
		{
			// Token: 0x04032067 RID: 204903
			[FieldOffset(0)]
			public IntPtr Actor;
		}
	}
}
