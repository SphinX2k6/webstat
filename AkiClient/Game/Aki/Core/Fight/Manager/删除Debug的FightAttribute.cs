using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Core.Fight.Manager
{
	// Token: 0x02003F7F RID: 16255
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class 删除Debug的FightAttribute : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x06028A6E RID: 166510 RVA: 0x00A11AF9 File Offset: 0x00A0FCF9
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return 删除Debug的FightAttribute.StaticFunctionPtr();
		}

		// Token: 0x06028A6F RID: 166511 RVA: 0x00A11B05 File Offset: 0x00A0FD05
		private static IntPtr StaticFunctionPtr()
		{
			if (BP_FightManager_C.__删除Debug的FightAttribute__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				BP_FightManager_C.__删除Debug的FightAttribute__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/Core/Fight/Manager/BP_FightManager.BP_FightManager_C:删除Debug的FightAttribute__DelegateSignature");
			}
			return BP_FightManager_C.__删除Debug的FightAttribute__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x06028A70 RID: 166512 RVA: 0x00A11B28 File Offset: 0x00A0FD28
		public 删除Debug的FightAttribute()
		{
		}

		// Token: 0x06028A71 RID: 166513 RVA: 0x00A11B30 File Offset: 0x00A0FD30
		[NullableContext(2)]
		public 删除Debug的FightAttribute(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06028A72 RID: 166514 RVA: 0x00A11B3A File Offset: 0x00A0FD3A
		public 删除Debug的FightAttribute(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06028A73 RID: 166515 RVA: 0x00A11B45 File Offset: 0x00A0FD45
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action<string>) ?? ((Action<string>)Delegate.CreateDelegate(typeof(Action<string>), Callback.Target, Callback.Method)));
		}

		// Token: 0x06028A74 RID: 166516 RVA: 0x00A11B77 File Offset: 0x00A0FD77
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add(Action<string> Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x06028A75 RID: 166517 RVA: 0x00A11B86 File Offset: 0x00A0FD86
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove(Action<string> Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x06028A76 RID: 166518 RVA: 0x00A11B90 File Offset: 0x00A0FD90
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void Broadcast(string Option)
		{
			删除Debug的FightAttribute.__删除Debug的FightAttribute_DelegateParams* ptr = stackalloc 删除Debug的FightAttribute.__删除Debug的FightAttribute_DelegateParams[(UIntPtr)31] + 15L / (long)sizeof(删除Debug的FightAttribute.__删除Debug的FightAttribute_DelegateParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(删除Debug的FightAttribute.StaticFunctionPtr(), (void*)ptr, 1);
			FString.CopyFrom((void*)(&ptr->Option), Option);
			base.BroadcastInternal((void*)ptr);
			UnrealReflectionUtils.DestroyStruct(BP_FightManager_C.__删除Debug的FightAttribute__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06028A77 RID: 166519 RVA: 0x00A11BE4 File Offset: 0x00A0FDE4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveOptimization)]
		protected unsafe static void OnScriptCallback(IntPtr __Handle, byte* __Parameters)
		{
			object target = GCHandle.FromIntPtr(__Handle).Target;
			Action<string> action = target as Action<string>;
			if (action == null)
			{
				throw new ArgumentException((target != null) ? target.GetType().ToString() : null);
			}
			string obj = FString.ToString((void*)(&((删除Debug的FightAttribute.__删除Debug的FightAttribute_DelegateParams*)__Parameters)->Option));
			action(obj);
		}

		// Token: 0x04015716 RID: 87830
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Core/Fight/Manager/BP_FightManager.BP_FightManager_C:删除Debug的FightAttribute__DelegateSignature";

		// Token: 0x0200A12E RID: 41262
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __删除Debug的FightAttribute_DelegateParams
		{
			// Token: 0x04032E62 RID: 208482
			[FieldOffset(0)]
			public FString Option;
		}
	}
}
