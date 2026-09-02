using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.GamePlay.Portal
{
	// Token: 0x02003DCC RID: 15820
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class RoleTeleport : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x06026BFB RID: 158715 RVA: 0x009E11D0 File Offset: 0x009DF3D0
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return RoleTeleport.StaticFunctionPtr();
		}

		// Token: 0x06026BFC RID: 158716 RVA: 0x009E11DC File Offset: 0x009DF3DC
		private static IntPtr StaticFunctionPtr()
		{
			if (BP_KuroPortalCapture_C.__RoleTeleport__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				BP_KuroPortalCapture_C.__RoleTeleport__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/GamePlay/Portal/BP_KuroPortalCapture.BP_KuroPortalCapture_C:RoleTeleport__DelegateSignature");
			}
			return BP_KuroPortalCapture_C.__RoleTeleport__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x06026BFD RID: 158717 RVA: 0x009E11FF File Offset: 0x009DF3FF
		public RoleTeleport()
		{
		}

		// Token: 0x06026BFE RID: 158718 RVA: 0x009E1207 File Offset: 0x009DF407
		[NullableContext(2)]
		public RoleTeleport(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06026BFF RID: 158719 RVA: 0x009E1211 File Offset: 0x009DF411
		public RoleTeleport(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06026C00 RID: 158720 RVA: 0x009E121C File Offset: 0x009DF41C
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action<FVector>) ?? ((Action<FVector>)Delegate.CreateDelegate(typeof(Action<FVector>), Callback.Target, Callback.Method)));
		}

		// Token: 0x06026C01 RID: 158721 RVA: 0x009E124E File Offset: 0x009DF44E
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add(Action<FVector> Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x06026C02 RID: 158722 RVA: 0x009E125D File Offset: 0x009DF45D
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove(Action<FVector> Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x06026C03 RID: 158723 RVA: 0x009E1268 File Offset: 0x009DF468
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void Broadcast(FVector Velocity)
		{
			RoleTeleport.__RoleTeleport_DelegateParams* ptr = stackalloc RoleTeleport.__RoleTeleport_DelegateParams[(UIntPtr)27] + 15L / (long)sizeof(RoleTeleport.__RoleTeleport_DelegateParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(RoleTeleport.StaticFunctionPtr(), (void*)ptr, 1);
			ptr->Velocity = Velocity;
			base.BroadcastInternal((void*)ptr);
		}

		// Token: 0x06026C04 RID: 158724 RVA: 0x009E12A4 File Offset: 0x009DF4A4
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
			action(((RoleTeleport.__RoleTeleport_DelegateParams*)__Parameters)->Velocity);
		}

		// Token: 0x0401435A RID: 82778
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/GamePlay/Portal/BP_KuroPortalCapture.BP_KuroPortalCapture_C:RoleTeleport__DelegateSignature";

		// Token: 0x0200A0BB RID: 41147
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __RoleTeleport_DelegateParams
		{
			// Token: 0x04032D6D RID: 208237
			[FieldOffset(0)]
			public FVector Velocity;
		}
	}
}
