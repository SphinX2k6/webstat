using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.FluidNinjaLive
{
	// Token: 0x02003CF0 RID: 15600
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class ComponentBroadcastMemConsumption : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x06025473 RID: 152691 RVA: 0x009B60E3 File Offset: 0x009B42E3
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return ComponentBroadcastMemConsumption.StaticFunctionPtr();
		}

		// Token: 0x06025474 RID: 152692 RVA: 0x009B60EF File Offset: 0x009B42EF
		private static IntPtr StaticFunctionPtr()
		{
			if (NinjaLiveComponent_C.__ComponentBroadcastMemConsumption__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				NinjaLiveComponent_C.__ComponentBroadcastMemConsumption__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/Render/RuntimeBP/FluidNinjaLive/NinjaLiveComponent.NinjaLiveComponent_C:ComponentBroadcastMemConsumption__DelegateSignature");
			}
			return NinjaLiveComponent_C.__ComponentBroadcastMemConsumption__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x06025475 RID: 152693 RVA: 0x009B6112 File Offset: 0x009B4312
		public ComponentBroadcastMemConsumption()
		{
		}

		// Token: 0x06025476 RID: 152694 RVA: 0x009B611A File Offset: 0x009B431A
		[NullableContext(2)]
		public ComponentBroadcastMemConsumption(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06025477 RID: 152695 RVA: 0x009B6124 File Offset: 0x009B4324
		public ComponentBroadcastMemConsumption(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06025478 RID: 152696 RVA: 0x009B612F File Offset: 0x009B432F
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action<UObject, float, bool>) ?? ((Action<UObject, float, bool>)Delegate.CreateDelegate(typeof(Action<UObject, float, bool>), Callback.Target, Callback.Method)));
		}

		// Token: 0x06025479 RID: 152697 RVA: 0x009B6161 File Offset: 0x009B4361
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add([Nullable(new byte[]
		{
			1,
			2
		})] Action<UObject, float, bool> Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x0602547A RID: 152698 RVA: 0x009B6170 File Offset: 0x009B4370
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove([Nullable(new byte[]
		{
			1,
			2
		})] Action<UObject, float, bool> Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x0602547B RID: 152699 RVA: 0x009B617C File Offset: 0x009B437C
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void Broadcast(UObject Consumer, float MemConsumption, bool TakenOrReturned)
		{
			ComponentBroadcastMemConsumption.__ComponentBroadcastMemConsumption_DelegateParams* ptr = stackalloc ComponentBroadcastMemConsumption.__ComponentBroadcastMemConsumption_DelegateParams[(UIntPtr)31] + 15L / (long)sizeof(ComponentBroadcastMemConsumption.__ComponentBroadcastMemConsumption_DelegateParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ComponentBroadcastMemConsumption.StaticFunctionPtr(), (void*)ptr, 1);
			ptr->Consumer = ((Consumer != null) ? Consumer.NativePtr : IntPtr.Zero);
			ptr->MemConsumption = MemConsumption;
			ptr->TakenOrReturned = TakenOrReturned;
			base.BroadcastInternal((void*)ptr);
		}

		// Token: 0x0602547C RID: 152700 RVA: 0x009B61D8 File Offset: 0x009B43D8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveOptimization)]
		protected unsafe static void OnScriptCallback(IntPtr __Handle, byte* __Parameters)
		{
			object target = GCHandle.FromIntPtr(__Handle).Target;
			Action<UObject, float, bool> action = target as Action<UObject, float, bool>;
			if (action == null)
			{
				throw new ArgumentException((target != null) ? target.GetType().ToString() : null);
			}
			UObject orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<UObject>(((ComponentBroadcastMemConsumption.__ComponentBroadcastMemConsumption_DelegateParams*)__Parameters)->Consumer);
			action(orCreateUObjectByNativePointer, ((ComponentBroadcastMemConsumption.__ComponentBroadcastMemConsumption_DelegateParams*)__Parameters)->MemConsumption, ((ComponentBroadcastMemConsumption.__ComponentBroadcastMemConsumption_DelegateParams*)__Parameters)->TakenOrReturned);
		}

		// Token: 0x04013347 RID: 78663
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/FluidNinjaLive/NinjaLiveComponent.NinjaLiveComponent_C:ComponentBroadcastMemConsumption__DelegateSignature";

		// Token: 0x02009EF5 RID: 40693
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __ComponentBroadcastMemConsumption_DelegateParams
		{
			// Token: 0x040329EA RID: 207338
			[FieldOffset(0)]
			public IntPtr Consumer;

			// Token: 0x040329EB RID: 207339
			[FieldOffset(8)]
			public float MemConsumption;

			// Token: 0x040329EC RID: 207340
			[FieldOffset(12)]
			public bool TakenOrReturned;
		}
	}
}
