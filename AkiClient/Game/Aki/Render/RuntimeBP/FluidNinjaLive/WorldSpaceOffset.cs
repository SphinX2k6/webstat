using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.FluidNinjaLive
{
	// Token: 0x02003CFB RID: 15611
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class WorldSpaceOffset : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x0602595D RID: 153949 RVA: 0x009BE2B6 File Offset: 0x009BC4B6
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return WorldSpaceOffset.StaticFunctionPtr();
		}

		// Token: 0x0602595E RID: 153950 RVA: 0x009BE2C2 File Offset: 0x009BC4C2
		private static IntPtr StaticFunctionPtr()
		{
			if (NinjaLiveComponent_C.__WorldSpaceOffset__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				NinjaLiveComponent_C.__WorldSpaceOffset__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/Render/RuntimeBP/FluidNinjaLive/NinjaLiveComponent.NinjaLiveComponent_C:WorldSpaceOffset__DelegateSignature");
			}
			return NinjaLiveComponent_C.__WorldSpaceOffset__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x0602595F RID: 153951 RVA: 0x009BE2E5 File Offset: 0x009BC4E5
		public WorldSpaceOffset()
		{
		}

		// Token: 0x06025960 RID: 153952 RVA: 0x009BE2ED File Offset: 0x009BC4ED
		[NullableContext(2)]
		public WorldSpaceOffset(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06025961 RID: 153953 RVA: 0x009BE2F7 File Offset: 0x009BC4F7
		public WorldSpaceOffset(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06025962 RID: 153954 RVA: 0x009BE302 File Offset: 0x009BC502
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action<FVector>) ?? ((Action<FVector>)Delegate.CreateDelegate(typeof(Action<FVector>), Callback.Target, Callback.Method)));
		}

		// Token: 0x06025963 RID: 153955 RVA: 0x009BE334 File Offset: 0x009BC534
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add(Action<FVector> Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x06025964 RID: 153956 RVA: 0x009BE343 File Offset: 0x009BC543
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove(Action<FVector> Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x06025965 RID: 153957 RVA: 0x009BE34C File Offset: 0x009BC54C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void Broadcast(FVector TraceMeshPos)
		{
			WorldSpaceOffset.__WorldSpaceOffset_DelegateParams* ptr = stackalloc WorldSpaceOffset.__WorldSpaceOffset_DelegateParams[(UIntPtr)27] + 15L / (long)sizeof(WorldSpaceOffset.__WorldSpaceOffset_DelegateParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(WorldSpaceOffset.StaticFunctionPtr(), (void*)ptr, 1);
			ptr->TraceMeshPos = TraceMeshPos;
			base.BroadcastInternal((void*)ptr);
		}

		// Token: 0x06025966 RID: 153958 RVA: 0x009BE388 File Offset: 0x009BC588
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveOptimization)]
		protected unsafe static void OnScriptCallback(IntPtr __Handle, byte* __Parameters)
		{
			object target = GCHandle.FromIntPtr(__Handle).Target;
			Action<FVector> action = target as Action<FVector>;
			if (action == null)
			{
				throw new ArgumentException((target != null) ? target.GetType().ToString() : null);
			}
			action(((WorldSpaceOffset.__WorldSpaceOffset_DelegateParams*)__Parameters)->TraceMeshPos);
		}

		// Token: 0x0401363E RID: 79422
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/FluidNinjaLive/NinjaLiveComponent.NinjaLiveComponent_C:WorldSpaceOffset__DelegateSignature";

		// Token: 0x02009F33 RID: 40755
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __WorldSpaceOffset_DelegateParams
		{
			// Token: 0x04032A64 RID: 207460
			[FieldOffset(0)]
			public FVector TraceMeshPos;
		}
	}
}
