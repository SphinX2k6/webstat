using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.GI.Skybox
{
	// Token: 0x02003CAE RID: 15534
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class OnDayPassedBy : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x06024B1E RID: 150302 RVA: 0x009A4BF8 File Offset: 0x009A2DF8
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return OnDayPassedBy.StaticFunctionPtr();
		}

		// Token: 0x06024B1F RID: 150303 RVA: 0x009A4C04 File Offset: 0x009A2E04
		private static IntPtr StaticFunctionPtr()
		{
			if (BP_SkyDome_C.__OnDayPassedBy__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				BP_SkyDome_C.__OnDayPassedBy__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/Render/RuntimeBP/GI/Skybox/BP_SkyDome.BP_SkyDome_C:OnDayPassedBy__DelegateSignature");
			}
			return BP_SkyDome_C.__OnDayPassedBy__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x06024B20 RID: 150304 RVA: 0x009A4C27 File Offset: 0x009A2E27
		public OnDayPassedBy()
		{
		}

		// Token: 0x06024B21 RID: 150305 RVA: 0x009A4C2F File Offset: 0x009A2E2F
		[NullableContext(2)]
		public OnDayPassedBy(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06024B22 RID: 150306 RVA: 0x009A4C39 File Offset: 0x009A2E39
		public OnDayPassedBy(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06024B23 RID: 150307 RVA: 0x009A4C44 File Offset: 0x009A2E44
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action<int>) ?? ((Action<int>)Delegate.CreateDelegate(typeof(Action<int>), Callback.Target, Callback.Method)));
		}

		// Token: 0x06024B24 RID: 150308 RVA: 0x009A4C76 File Offset: 0x009A2E76
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add(Action<int> Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x06024B25 RID: 150309 RVA: 0x009A4C85 File Offset: 0x009A2E85
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove(Action<int> Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x06024B26 RID: 150310 RVA: 0x009A4C90 File Offset: 0x009A2E90
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void Broadcast(int Day)
		{
			OnDayPassedBy.__OnDayPassedBy_DelegateParams* ptr = stackalloc OnDayPassedBy.__OnDayPassedBy_DelegateParams[(UIntPtr)19] + 15L / (long)sizeof(OnDayPassedBy.__OnDayPassedBy_DelegateParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(OnDayPassedBy.StaticFunctionPtr(), (void*)ptr, 1);
			ptr->Day = Day;
			base.BroadcastInternal((void*)ptr);
		}

		// Token: 0x06024B27 RID: 150311 RVA: 0x009A4CCC File Offset: 0x009A2ECC
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
			action(((OnDayPassedBy.__OnDayPassedBy_DelegateParams*)__Parameters)->Day);
		}

		// Token: 0x04012D23 RID: 77091
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/GI/Skybox/BP_SkyDome.BP_SkyDome_C:OnDayPassedBy__DelegateSignature";

		// Token: 0x02009E2C RID: 40492
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __OnDayPassedBy_DelegateParams
		{
			// Token: 0x0403287F RID: 206975
			[FieldOffset(0)]
			public int Day;
		}
	}
}
