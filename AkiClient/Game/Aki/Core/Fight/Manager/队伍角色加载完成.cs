using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Core.Fight.Manager
{
	// Token: 0x02003F82 RID: 16258
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class 队伍角色加载完成 : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x06028A8C RID: 166540 RVA: 0x00A11EA5 File Offset: 0x00A100A5
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return 队伍角色加载完成.StaticFunctionPtr();
		}

		// Token: 0x06028A8D RID: 166541 RVA: 0x00A11EB1 File Offset: 0x00A100B1
		private static IntPtr StaticFunctionPtr()
		{
			if (BP_FightManager_C.__队伍角色加载完成__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				BP_FightManager_C.__队伍角色加载完成__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/Core/Fight/Manager/BP_FightManager.BP_FightManager_C:队伍角色加载完成__DelegateSignature");
			}
			return BP_FightManager_C.__队伍角色加载完成__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x06028A8E RID: 166542 RVA: 0x00A11ED4 File Offset: 0x00A100D4
		public 队伍角色加载完成()
		{
		}

		// Token: 0x06028A8F RID: 166543 RVA: 0x00A11EDC File Offset: 0x00A100DC
		[NullableContext(2)]
		public 队伍角色加载完成(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06028A90 RID: 166544 RVA: 0x00A11EE6 File Offset: 0x00A100E6
		public 队伍角色加载完成(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06028A91 RID: 166545 RVA: 0x00A11EF1 File Offset: 0x00A100F1
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action) ?? ((Action)Delegate.CreateDelegate(typeof(Action), Callback.Target, Callback.Method)));
		}

		// Token: 0x06028A92 RID: 166546 RVA: 0x00A11F23 File Offset: 0x00A10123
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add(Action Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x06028A93 RID: 166547 RVA: 0x00A11F32 File Offset: 0x00A10132
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove(Action Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x06028A94 RID: 166548 RVA: 0x00A11F3B File Offset: 0x00A1013B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Broadcast()
		{
			base.BroadcastInternal(null);
		}

		// Token: 0x06028A95 RID: 166549 RVA: 0x00A11F48 File Offset: 0x00A10148
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

		// Token: 0x04015719 RID: 87833
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Core/Fight/Manager/BP_FightManager.BP_FightManager_C:队伍角色加载完成__DelegateSignature";
	}
}
