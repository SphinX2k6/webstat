using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Core.Fight;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.UI.Manager
{
	// Token: 0x02003999 RID: 14745
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class 子弹撞到水面时 : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x0601DC21 RID: 121889 RVA: 0x008DFD6C File Offset: 0x008DDF6C
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return 子弹撞到水面时.StaticFunctionPtr();
		}

		// Token: 0x0601DC22 RID: 121890 RVA: 0x008DFD78 File Offset: 0x008DDF78
		private static IntPtr StaticFunctionPtr()
		{
			if (BP_EventManager_C.__子弹撞到水面时__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				BP_EventManager_C.__子弹撞到水面时__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/UI/Manager/BP_EventManager.BP_EventManager_C:子弹撞到水面时__DelegateSignature");
			}
			return BP_EventManager_C.__子弹撞到水面时__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x0601DC23 RID: 121891 RVA: 0x008DFD9B File Offset: 0x008DDF9B
		public 子弹撞到水面时()
		{
		}

		// Token: 0x0601DC24 RID: 121892 RVA: 0x008DFDA3 File Offset: 0x008DDFA3
		[NullableContext(2)]
		public 子弹撞到水面时(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0601DC25 RID: 121893 RVA: 0x008DFDAD File Offset: 0x008DDFAD
		public 子弹撞到水面时(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0601DC26 RID: 121894 RVA: 0x008DFDB8 File Offset: 0x008DDFB8
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action<FVectorDouble, BP_SceneBattleInteract_C, FVectorDouble, int>) ?? ((Action<FVectorDouble, BP_SceneBattleInteract_C, FVectorDouble, int>)Delegate.CreateDelegate(typeof(Action<FVectorDouble, BP_SceneBattleInteract_C, FVectorDouble, int>), Callback.Target, Callback.Method)));
		}

		// Token: 0x0601DC27 RID: 121895 RVA: 0x008DFDEA File Offset: 0x008DDFEA
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add([Nullable(new byte[]
		{
			1,
			2
		})] Action<FVectorDouble, BP_SceneBattleInteract_C, FVectorDouble, int> Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x0601DC28 RID: 121896 RVA: 0x008DFDF9 File Offset: 0x008DDFF9
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove([Nullable(new byte[]
		{
			1,
			2
		})] Action<FVectorDouble, BP_SceneBattleInteract_C, FVectorDouble, int> Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x0601DC29 RID: 121897 RVA: 0x008DFE04 File Offset: 0x008DE004
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void Broadcast(FVectorDouble ImpactPoint, BP_SceneBattleInteract_C Config, FVectorDouble OriginPoint, int Id)
		{
			子弹撞到水面时.__子弹撞到水面时_DelegateParams* ptr = stackalloc 子弹撞到水面时.__子弹撞到水面时_DelegateParams[(UIntPtr)79] + 15L / (long)sizeof(子弹撞到水面时.__子弹撞到水面时_DelegateParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(子弹撞到水面时.StaticFunctionPtr(), (void*)ptr, 1);
			ptr->ImpactPoint = ImpactPoint;
			ptr->Config = ((Config != null) ? Config.NativePtr : IntPtr.Zero);
			ptr->OriginPoint = OriginPoint;
			ptr->Id = Id;
			base.BroadcastInternal((void*)ptr);
		}

		// Token: 0x0601DC2A RID: 121898 RVA: 0x008DFE68 File Offset: 0x008DE068
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveOptimization)]
		protected unsafe static void OnScriptCallback(IntPtr __Handle, byte* __Parameters)
		{
			object target = GCHandle.FromIntPtr(__Handle).Target;
			Action<FVectorDouble, BP_SceneBattleInteract_C, FVectorDouble, int> action = target as Action<FVectorDouble, BP_SceneBattleInteract_C, FVectorDouble, int>;
			if (action == null)
			{
				throw new ArgumentException((target != null) ? target.GetType().ToString() : null);
			}
			BP_SceneBattleInteract_C orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<BP_SceneBattleInteract_C>(((子弹撞到水面时.__子弹撞到水面时_DelegateParams*)__Parameters)->Config);
			action(((子弹撞到水面时.__子弹撞到水面时_DelegateParams*)__Parameters)->ImpactPoint, orCreateUObjectByNativePointer, ((子弹撞到水面时.__子弹撞到水面时_DelegateParams*)__Parameters)->OriginPoint, ((子弹撞到水面时.__子弹撞到水面时_DelegateParams*)__Parameters)->Id);
		}

		// Token: 0x0400E967 RID: 59751
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/UI/Manager/BP_EventManager.BP_EventManager_C:子弹撞到水面时__DelegateSignature";

		// Token: 0x020096C7 RID: 38599
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 64)]
		protected ref struct __子弹撞到水面时_DelegateParams
		{
			// Token: 0x04031BA5 RID: 203685
			[FieldOffset(0)]
			public FVectorDouble ImpactPoint;

			// Token: 0x04031BA6 RID: 203686
			[FieldOffset(24)]
			public IntPtr Config;

			// Token: 0x04031BA7 RID: 203687
			[FieldOffset(32)]
			public FVectorDouble OriginPoint;

			// Token: 0x04031BA8 RID: 203688
			[FieldOffset(56)]
			public int Id;
		}
	}
}
