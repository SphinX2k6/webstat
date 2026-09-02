using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Core.Fight.Manager
{
	// Token: 0x02003F80 RID: 16256
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class 添加Debug的FightAttribute : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x06028A78 RID: 166520 RVA: 0x00A11C36 File Offset: 0x00A0FE36
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return 添加Debug的FightAttribute.StaticFunctionPtr();
		}

		// Token: 0x06028A79 RID: 166521 RVA: 0x00A11C42 File Offset: 0x00A0FE42
		private static IntPtr StaticFunctionPtr()
		{
			if (BP_FightManager_C.__添加Debug的FightAttribute__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				BP_FightManager_C.__添加Debug的FightAttribute__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/Core/Fight/Manager/BP_FightManager.BP_FightManager_C:添加Debug的FightAttribute__DelegateSignature");
			}
			return BP_FightManager_C.__添加Debug的FightAttribute__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x06028A7A RID: 166522 RVA: 0x00A11C65 File Offset: 0x00A0FE65
		public 添加Debug的FightAttribute()
		{
		}

		// Token: 0x06028A7B RID: 166523 RVA: 0x00A11C6D File Offset: 0x00A0FE6D
		[NullableContext(2)]
		public 添加Debug的FightAttribute(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06028A7C RID: 166524 RVA: 0x00A11C77 File Offset: 0x00A0FE77
		public 添加Debug的FightAttribute(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06028A7D RID: 166525 RVA: 0x00A11C82 File Offset: 0x00A0FE82
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action<string>) ?? ((Action<string>)Delegate.CreateDelegate(typeof(Action<string>), Callback.Target, Callback.Method)));
		}

		// Token: 0x06028A7E RID: 166526 RVA: 0x00A11CB4 File Offset: 0x00A0FEB4
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add(Action<string> Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x06028A7F RID: 166527 RVA: 0x00A11CC3 File Offset: 0x00A0FEC3
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove(Action<string> Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x06028A80 RID: 166528 RVA: 0x00A11CCC File Offset: 0x00A0FECC
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void Broadcast(string Option)
		{
			添加Debug的FightAttribute.__添加Debug的FightAttribute_DelegateParams* ptr = stackalloc 添加Debug的FightAttribute.__添加Debug的FightAttribute_DelegateParams[(UIntPtr)31] + 15L / (long)sizeof(添加Debug的FightAttribute.__添加Debug的FightAttribute_DelegateParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(添加Debug的FightAttribute.StaticFunctionPtr(), (void*)ptr, 1);
			FString.CopyFrom((void*)(&ptr->Option), Option);
			base.BroadcastInternal((void*)ptr);
			UnrealReflectionUtils.DestroyStruct(BP_FightManager_C.__添加Debug的FightAttribute__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06028A81 RID: 166529 RVA: 0x00A11D20 File Offset: 0x00A0FF20
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
			string obj = FString.ToString((void*)(&((添加Debug的FightAttribute.__添加Debug的FightAttribute_DelegateParams*)__Parameters)->Option));
			action(obj);
		}

		// Token: 0x04015717 RID: 87831
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Core/Fight/Manager/BP_FightManager.BP_FightManager_C:添加Debug的FightAttribute__DelegateSignature";

		// Token: 0x0200A12F RID: 41263
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __添加Debug的FightAttribute_DelegateParams
		{
			// Token: 0x04032E63 RID: 208483
			[FieldOffset(0)]
			public FString Option;
		}
	}
}
