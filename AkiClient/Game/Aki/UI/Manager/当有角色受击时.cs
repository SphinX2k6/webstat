using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.UI.Manager
{
	// Token: 0x0200399F RID: 14751
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class 当有角色受击时 : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x0601DC5D RID: 121949 RVA: 0x008E0452 File Offset: 0x008DE652
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return 当有角色受击时.StaticFunctionPtr();
		}

		// Token: 0x0601DC5E RID: 121950 RVA: 0x008E045E File Offset: 0x008DE65E
		private static IntPtr StaticFunctionPtr()
		{
			if (BP_EventManager_C.__当有角色受击时__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				BP_EventManager_C.__当有角色受击时__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/UI/Manager/BP_EventManager.BP_EventManager_C:当有角色受击时__DelegateSignature");
			}
			return BP_EventManager_C.__当有角色受击时__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x0601DC5F RID: 121951 RVA: 0x008E0481 File Offset: 0x008DE681
		public 当有角色受击时()
		{
		}

		// Token: 0x0601DC60 RID: 121952 RVA: 0x008E0489 File Offset: 0x008DE689
		[NullableContext(2)]
		public 当有角色受击时(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0601DC61 RID: 121953 RVA: 0x008E0493 File Offset: 0x008DE693
		public 当有角色受击时(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0601DC62 RID: 121954 RVA: 0x008E049E File Offset: 0x008DE69E
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action<TsBaseCharacter, SHitInformation>) ?? ((Action<TsBaseCharacter, SHitInformation>)Delegate.CreateDelegate(typeof(Action<TsBaseCharacter, SHitInformation>), Callback.Target, Callback.Method)));
		}

		// Token: 0x0601DC63 RID: 121955 RVA: 0x008E04D0 File Offset: 0x008DE6D0
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add([Nullable(new byte[]
		{
			1,
			2,
			1
		})] Action<TsBaseCharacter, SHitInformation> Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x0601DC64 RID: 121956 RVA: 0x008E04DF File Offset: 0x008DE6DF
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove([Nullable(new byte[]
		{
			1,
			2,
			1
		})] Action<TsBaseCharacter, SHitInformation> Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x0601DC65 RID: 121957 RVA: 0x008E04E8 File Offset: 0x008DE6E8
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void Broadcast(TsBaseCharacter 角色, SHitInformation 受击数据)
		{
			当有角色受击时.__当有角色受击时_DelegateParams* ptr = stackalloc 当有角色受击时.__当有角色受击时_DelegateParams[(UIntPtr)2295] + 15L / (long)sizeof(当有角色受击时.__当有角色受击时_DelegateParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(当有角色受击时.StaticFunctionPtr(), (void*)ptr, 1);
			ptr->角色 = ((角色 != null) ? 角色.NativePtr : IntPtr.Zero);
			if (受击数据 != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SHitInformation.StaticStruct(), &ptr->受击数据, 受击数据.NativePtr, 1, false);
			}
			base.BroadcastInternal((void*)ptr);
			UnrealReflectionUtils.DestroyStruct(BP_EventManager_C.__当有角色受击时__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0601DC66 RID: 121958 RVA: 0x008E056C File Offset: 0x008DE76C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveOptimization)]
		protected unsafe static void OnScriptCallback(IntPtr __Handle, byte* __Parameters)
		{
			object target = GCHandle.FromIntPtr(__Handle).Target;
			Action<TsBaseCharacter, SHitInformation> action = target as Action<TsBaseCharacter, SHitInformation>;
			if (action == null)
			{
				throw new ArgumentException((target != null) ? target.GetType().ToString() : null);
			}
			TsBaseCharacter orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<TsBaseCharacter>(((当有角色受击时.__当有角色受击时_DelegateParams*)__Parameters)->角色);
			SHitInformation arg = new SHitInformation(&((当有角色受击时.__当有角色受击时_DelegateParams*)__Parameters)->受击数据, true, true);
			action(orCreateUObjectByNativePointer, arg);
		}

		// Token: 0x0400E96D RID: 59757
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/UI/Manager/BP_EventManager.BP_EventManager_C:当有角色受击时__DelegateSignature";

		// Token: 0x020096CC RID: 38604
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 2280)]
		protected ref struct __当有角色受击时_DelegateParams
		{
			// Token: 0x04031BAD RID: 203693
			[FieldOffset(0)]
			public IntPtr 角色;

			// Token: 0x04031BAE RID: 203694
			[FieldOffset(8)]
			public byte 受击数据;
		}
	}
}
