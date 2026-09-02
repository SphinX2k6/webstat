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
	// Token: 0x020039AA RID: 14762
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class 武器交互场景时 : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x0601DCCB RID: 122059 RVA: 0x008E10FE File Offset: 0x008DF2FE
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return 武器交互场景时.StaticFunctionPtr();
		}

		// Token: 0x0601DCCC RID: 122060 RVA: 0x008E110A File Offset: 0x008DF30A
		private static IntPtr StaticFunctionPtr()
		{
			if (BP_EventManager_C.__武器交互场景时__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				BP_EventManager_C.__武器交互场景时__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/UI/Manager/BP_EventManager.BP_EventManager_C:武器交互场景时__DelegateSignature");
			}
			return BP_EventManager_C.__武器交互场景时__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x0601DCCD RID: 122061 RVA: 0x008E112D File Offset: 0x008DF32D
		public 武器交互场景时()
		{
		}

		// Token: 0x0601DCCE RID: 122062 RVA: 0x008E1135 File Offset: 0x008DF335
		[NullableContext(2)]
		public 武器交互场景时(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0601DCCF RID: 122063 RVA: 0x008E113F File Offset: 0x008DF33F
		public 武器交互场景时(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0601DCD0 RID: 122064 RVA: 0x008E114A File Offset: 0x008DF34A
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action<FVectorDouble, BP_SceneBattleInteract_C, int>) ?? ((Action<FVectorDouble, BP_SceneBattleInteract_C, int>)Delegate.CreateDelegate(typeof(Action<FVectorDouble, BP_SceneBattleInteract_C, int>), Callback.Target, Callback.Method)));
		}

		// Token: 0x0601DCD1 RID: 122065 RVA: 0x008E117C File Offset: 0x008DF37C
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add([Nullable(new byte[]
		{
			1,
			2
		})] Action<FVectorDouble, BP_SceneBattleInteract_C, int> Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x0601DCD2 RID: 122066 RVA: 0x008E118B File Offset: 0x008DF38B
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove([Nullable(new byte[]
		{
			1,
			2
		})] Action<FVectorDouble, BP_SceneBattleInteract_C, int> Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x0601DCD3 RID: 122067 RVA: 0x008E1194 File Offset: 0x008DF394
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void Broadcast(FVectorDouble OriginPoint, BP_SceneBattleInteract_C Config, int Id)
		{
			武器交互场景时.__武器交互场景时_DelegateParams* ptr = stackalloc 武器交互场景时.__武器交互场景时_DelegateParams[(UIntPtr)55] + 15L / (long)sizeof(武器交互场景时.__武器交互场景时_DelegateParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(武器交互场景时.StaticFunctionPtr(), (void*)ptr, 1);
			ptr->OriginPoint = OriginPoint;
			ptr->Config = ((Config != null) ? Config.NativePtr : IntPtr.Zero);
			ptr->Id = Id;
			base.BroadcastInternal((void*)ptr);
		}

		// Token: 0x0601DCD4 RID: 122068 RVA: 0x008E11F0 File Offset: 0x008DF3F0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveOptimization)]
		protected unsafe static void OnScriptCallback(IntPtr __Handle, byte* __Parameters)
		{
			object target = GCHandle.FromIntPtr(__Handle).Target;
			Action<FVectorDouble, BP_SceneBattleInteract_C, int> action = target as Action<FVectorDouble, BP_SceneBattleInteract_C, int>;
			if (action == null)
			{
				throw new ArgumentException((target != null) ? target.GetType().ToString() : null);
			}
			BP_SceneBattleInteract_C orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<BP_SceneBattleInteract_C>(((武器交互场景时.__武器交互场景时_DelegateParams*)__Parameters)->Config);
			action(((武器交互场景时.__武器交互场景时_DelegateParams*)__Parameters)->OriginPoint, orCreateUObjectByNativePointer, ((武器交互场景时.__武器交互场景时_DelegateParams*)__Parameters)->Id);
		}

		// Token: 0x0400E978 RID: 59768
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/UI/Manager/BP_EventManager.BP_EventManager_C:武器交互场景时__DelegateSignature";

		// Token: 0x020096D4 RID: 38612
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __武器交互场景时_DelegateParams
		{
			// Token: 0x04031BBA RID: 203706
			[FieldOffset(0)]
			public FVectorDouble OriginPoint;

			// Token: 0x04031BBB RID: 203707
			[FieldOffset(24)]
			public IntPtr Config;

			// Token: 0x04031BBC RID: 203708
			[FieldOffset(32)]
			public int Id;
		}
	}
}
