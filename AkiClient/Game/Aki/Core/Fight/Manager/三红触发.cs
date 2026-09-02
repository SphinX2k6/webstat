using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Core.Fight.Manager
{
	// Token: 0x02003F7D RID: 16253
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class 三红触发 : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x06028A5A RID: 166490 RVA: 0x00A11891 File Offset: 0x00A0FA91
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return 三红触发.StaticFunctionPtr();
		}

		// Token: 0x06028A5B RID: 166491 RVA: 0x00A1189D File Offset: 0x00A0FA9D
		private static IntPtr StaticFunctionPtr()
		{
			if (BP_FightManager_C.__三红触发__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				BP_FightManager_C.__三红触发__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/Core/Fight/Manager/BP_FightManager.BP_FightManager_C:三红触发__DelegateSignature");
			}
			return BP_FightManager_C.__三红触发__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x06028A5C RID: 166492 RVA: 0x00A118C0 File Offset: 0x00A0FAC0
		public 三红触发()
		{
		}

		// Token: 0x06028A5D RID: 166493 RVA: 0x00A118C8 File Offset: 0x00A0FAC8
		[NullableContext(2)]
		public 三红触发(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06028A5E RID: 166494 RVA: 0x00A118D2 File Offset: 0x00A0FAD2
		public 三红触发(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06028A5F RID: 166495 RVA: 0x00A118DD File Offset: 0x00A0FADD
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action<TsBaseCharacter>) ?? ((Action<TsBaseCharacter>)Delegate.CreateDelegate(typeof(Action<TsBaseCharacter>), Callback.Target, Callback.Method)));
		}

		// Token: 0x06028A60 RID: 166496 RVA: 0x00A1190F File Offset: 0x00A0FB0F
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add([Nullable(new byte[]
		{
			1,
			2
		})] Action<TsBaseCharacter> Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x06028A61 RID: 166497 RVA: 0x00A1191E File Offset: 0x00A0FB1E
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove([Nullable(new byte[]
		{
			1,
			2
		})] Action<TsBaseCharacter> Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x06028A62 RID: 166498 RVA: 0x00A11928 File Offset: 0x00A0FB28
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void Broadcast(TsBaseCharacter 触发者)
		{
			三红触发.__三红触发_DelegateParams* ptr = stackalloc 三红触发.__三红触发_DelegateParams[(UIntPtr)23] + 15L / (long)sizeof(三红触发.__三红触发_DelegateParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(三红触发.StaticFunctionPtr(), (void*)ptr, 1);
			ptr->触发者 = ((触发者 != null) ? 触发者.NativePtr : IntPtr.Zero);
			base.BroadcastInternal((void*)ptr);
		}

		// Token: 0x06028A63 RID: 166499 RVA: 0x00A11974 File Offset: 0x00A0FB74
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveOptimization)]
		protected unsafe static void OnScriptCallback(IntPtr __Handle, byte* __Parameters)
		{
			object target = GCHandle.FromIntPtr(__Handle).Target;
			Action<TsBaseCharacter> action = target as Action<TsBaseCharacter>;
			if (action == null)
			{
				throw new ArgumentException((target != null) ? target.GetType().ToString() : null);
			}
			TsBaseCharacter orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<TsBaseCharacter>(((三红触发.__三红触发_DelegateParams*)__Parameters)->触发者);
			action(orCreateUObjectByNativePointer);
		}

		// Token: 0x04015714 RID: 87828
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Core/Fight/Manager/BP_FightManager.BP_FightManager_C:三红触发__DelegateSignature";

		// Token: 0x0200A12C RID: 41260
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __三红触发_DelegateParams
		{
			// Token: 0x04032E60 RID: 208480
			[FieldOffset(0)]
			public IntPtr 触发者;
		}
	}
}
