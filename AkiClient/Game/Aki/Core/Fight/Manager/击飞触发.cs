using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Core.Fight.Manager
{
	// Token: 0x02003F7E RID: 16254
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class 击飞触发 : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x06028A64 RID: 166500 RVA: 0x00A119C5 File Offset: 0x00A0FBC5
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return 击飞触发.StaticFunctionPtr();
		}

		// Token: 0x06028A65 RID: 166501 RVA: 0x00A119D1 File Offset: 0x00A0FBD1
		private static IntPtr StaticFunctionPtr()
		{
			if (BP_FightManager_C.__击飞触发__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				BP_FightManager_C.__击飞触发__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/Core/Fight/Manager/BP_FightManager.BP_FightManager_C:击飞触发__DelegateSignature");
			}
			return BP_FightManager_C.__击飞触发__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x06028A66 RID: 166502 RVA: 0x00A119F4 File Offset: 0x00A0FBF4
		public 击飞触发()
		{
		}

		// Token: 0x06028A67 RID: 166503 RVA: 0x00A119FC File Offset: 0x00A0FBFC
		[NullableContext(2)]
		public 击飞触发(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06028A68 RID: 166504 RVA: 0x00A11A06 File Offset: 0x00A0FC06
		public 击飞触发(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06028A69 RID: 166505 RVA: 0x00A11A11 File Offset: 0x00A0FC11
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action<TsBaseCharacter>) ?? ((Action<TsBaseCharacter>)Delegate.CreateDelegate(typeof(Action<TsBaseCharacter>), Callback.Target, Callback.Method)));
		}

		// Token: 0x06028A6A RID: 166506 RVA: 0x00A11A43 File Offset: 0x00A0FC43
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add([Nullable(new byte[]
		{
			1,
			2
		})] Action<TsBaseCharacter> Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x06028A6B RID: 166507 RVA: 0x00A11A52 File Offset: 0x00A0FC52
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove([Nullable(new byte[]
		{
			1,
			2
		})] Action<TsBaseCharacter> Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x06028A6C RID: 166508 RVA: 0x00A11A5C File Offset: 0x00A0FC5C
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void Broadcast(TsBaseCharacter 触发者)
		{
			击飞触发.__击飞触发_DelegateParams* ptr = stackalloc 击飞触发.__击飞触发_DelegateParams[(UIntPtr)23] + 15L / (long)sizeof(击飞触发.__击飞触发_DelegateParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(击飞触发.StaticFunctionPtr(), (void*)ptr, 1);
			ptr->触发者 = ((触发者 != null) ? 触发者.NativePtr : IntPtr.Zero);
			base.BroadcastInternal((void*)ptr);
		}

		// Token: 0x06028A6D RID: 166509 RVA: 0x00A11AA8 File Offset: 0x00A0FCA8
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
			TsBaseCharacter orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<TsBaseCharacter>(((击飞触发.__击飞触发_DelegateParams*)__Parameters)->触发者);
			action(orCreateUObjectByNativePointer);
		}

		// Token: 0x04015715 RID: 87829
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Core/Fight/Manager/BP_FightManager.BP_FightManager_C:击飞触发__DelegateSignature";

		// Token: 0x0200A12D RID: 41261
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __击飞触发_DelegateParams
		{
			// Token: 0x04032E61 RID: 208481
			[FieldOffset(0)]
			public IntPtr 触发者;
		}
	}
}
