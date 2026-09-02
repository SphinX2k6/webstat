using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.PBD_PhysicBridge.BP
{
	// Token: 0x02003BB4 RID: 15284
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class custom : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x0602237F RID: 140159 RVA: 0x0095F0A7 File Offset: 0x0095D2A7
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return custom.StaticFunctionPtr();
		}

		// Token: 0x06022380 RID: 140160 RVA: 0x0095F0B3 File Offset: 0x0095D2B3
		private static IntPtr StaticFunctionPtr()
		{
			if (BP_BridgeModels_BrokenMobile_C.__custom__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				BP_BridgeModels_BrokenMobile_C.__custom__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/Render/RuntimeBP/PCG/PBD_PhysicBridge/BP/BP_BridgeModels_BrokenMobile.BP_BridgeModels_BrokenMobile_C:custom__DelegateSignature");
			}
			return BP_BridgeModels_BrokenMobile_C.__custom__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x06022381 RID: 140161 RVA: 0x0095F0D6 File Offset: 0x0095D2D6
		public custom()
		{
		}

		// Token: 0x06022382 RID: 140162 RVA: 0x0095F0DE File Offset: 0x0095D2DE
		[NullableContext(2)]
		public custom(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06022383 RID: 140163 RVA: 0x0095F0E8 File Offset: 0x0095D2E8
		public custom(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06022384 RID: 140164 RVA: 0x0095F0F3 File Offset: 0x0095D2F3
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action) ?? ((Action)Delegate.CreateDelegate(typeof(Action), Callback.Target, Callback.Method)));
		}

		// Token: 0x06022385 RID: 140165 RVA: 0x0095F125 File Offset: 0x0095D325
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add(Action Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x06022386 RID: 140166 RVA: 0x0095F134 File Offset: 0x0095D334
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove(Action Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x06022387 RID: 140167 RVA: 0x0095F13D File Offset: 0x0095D33D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Broadcast()
		{
			base.BroadcastInternal(null);
		}

		// Token: 0x06022388 RID: 140168 RVA: 0x0095F148 File Offset: 0x0095D348
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveOptimization)]
		protected unsafe static void OnScriptCallback(IntPtr __Handle, byte* __Parameters)
		{
			object target = GCHandle.FromIntPtr(__Handle).Target;
			Action action = target as Action;
			if (action == null)
			{
				throw new ArgumentException((target != null) ? target.GetType().ToString() : null);
			}
			action();
		}

		// Token: 0x040114C8 RID: 70856
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/PBD_PhysicBridge/BP/BP_BridgeModels_BrokenMobile.BP_BridgeModels_BrokenMobile_C:custom__DelegateSignature";
	}
}
