using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.GI.Skybox
{
	// Token: 0x02003CAF RID: 15535
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class OnHourPassedBy : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x06024B28 RID: 150312 RVA: 0x009A4D16 File Offset: 0x009A2F16
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return OnHourPassedBy.StaticFunctionPtr();
		}

		// Token: 0x06024B29 RID: 150313 RVA: 0x009A4D22 File Offset: 0x009A2F22
		private static IntPtr StaticFunctionPtr()
		{
			if (BP_SkyDome_C.__OnHourPassedBy__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				BP_SkyDome_C.__OnHourPassedBy__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/Render/RuntimeBP/GI/Skybox/BP_SkyDome.BP_SkyDome_C:OnHourPassedBy__DelegateSignature");
			}
			return BP_SkyDome_C.__OnHourPassedBy__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x06024B2A RID: 150314 RVA: 0x009A4D45 File Offset: 0x009A2F45
		public OnHourPassedBy()
		{
		}

		// Token: 0x06024B2B RID: 150315 RVA: 0x009A4D4D File Offset: 0x009A2F4D
		[NullableContext(2)]
		public OnHourPassedBy(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06024B2C RID: 150316 RVA: 0x009A4D57 File Offset: 0x009A2F57
		public OnHourPassedBy(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06024B2D RID: 150317 RVA: 0x009A4D62 File Offset: 0x009A2F62
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action<int>) ?? ((Action<int>)Delegate.CreateDelegate(typeof(Action<int>), Callback.Target, Callback.Method)));
		}

		// Token: 0x06024B2E RID: 150318 RVA: 0x009A4D94 File Offset: 0x009A2F94
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add(Action<int> Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x06024B2F RID: 150319 RVA: 0x009A4DA3 File Offset: 0x009A2FA3
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove(Action<int> Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x06024B30 RID: 150320 RVA: 0x009A4DAC File Offset: 0x009A2FAC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void Broadcast(int Hour)
		{
			OnHourPassedBy.__OnHourPassedBy_DelegateParams* ptr = stackalloc OnHourPassedBy.__OnHourPassedBy_DelegateParams[(UIntPtr)19] + 15L / (long)sizeof(OnHourPassedBy.__OnHourPassedBy_DelegateParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(OnHourPassedBy.StaticFunctionPtr(), (void*)ptr, 1);
			ptr->Hour = Hour;
			base.BroadcastInternal((void*)ptr);
		}

		// Token: 0x06024B31 RID: 150321 RVA: 0x009A4DE8 File Offset: 0x009A2FE8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveOptimization)]
		protected unsafe static void OnScriptCallback(IntPtr __Handle, byte* __Parameters)
		{
			object target = GCHandle.FromIntPtr(__Handle).Target;
			Action<int> action = target as Action<int>;
			if (action == null)
			{
				throw new ArgumentException((target != null) ? target.GetType().ToString() : null);
			}
			action(((OnHourPassedBy.__OnHourPassedBy_DelegateParams*)__Parameters)->Hour);
		}

		// Token: 0x04012D24 RID: 77092
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/GI/Skybox/BP_SkyDome.BP_SkyDome_C:OnHourPassedBy__DelegateSignature";

		// Token: 0x02009E2D RID: 40493
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __OnHourPassedBy_DelegateParams
		{
			// Token: 0x04032880 RID: 206976
			[FieldOffset(0)]
			public int Hour;
		}
	}
}
