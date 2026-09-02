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
	// Token: 0x020039A5 RID: 14757
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class 当触发对策事件时 : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x0601DC99 RID: 122009 RVA: 0x008E0B5E File Offset: 0x008DED5E
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return 当触发对策事件时.StaticFunctionPtr();
		}

		// Token: 0x0601DC9A RID: 122010 RVA: 0x008E0B6A File Offset: 0x008DED6A
		private static IntPtr StaticFunctionPtr()
		{
			if (BP_EventManager_C.__当触发对策事件时__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				BP_EventManager_C.__当触发对策事件时__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/UI/Manager/BP_EventManager.BP_EventManager_C:当触发对策事件时__DelegateSignature");
			}
			return BP_EventManager_C.__当触发对策事件时__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x0601DC9B RID: 122011 RVA: 0x008E0B8D File Offset: 0x008DED8D
		public 当触发对策事件时()
		{
		}

		// Token: 0x0601DC9C RID: 122012 RVA: 0x008E0B95 File Offset: 0x008DED95
		[NullableContext(2)]
		public 当触发对策事件时(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0601DC9D RID: 122013 RVA: 0x008E0B9F File Offset: 0x008DED9F
		public 当触发对策事件时(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0601DC9E RID: 122014 RVA: 0x008E0BAA File Offset: 0x008DEDAA
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action<int, SHitInformation>) ?? ((Action<int, SHitInformation>)Delegate.CreateDelegate(typeof(Action<int, SHitInformation>), Callback.Target, Callback.Method)));
		}

		// Token: 0x0601DC9F RID: 122015 RVA: 0x008E0BDC File Offset: 0x008DEDDC
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add(Action<int, SHitInformation> Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x0601DCA0 RID: 122016 RVA: 0x008E0BEB File Offset: 0x008DEDEB
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove(Action<int, SHitInformation> Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x0601DCA1 RID: 122017 RVA: 0x008E0BF4 File Offset: 0x008DEDF4
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void Broadcast(int 对策事件ID, SHitInformation 受击数据)
		{
			当触发对策事件时.__当触发对策事件时_DelegateParams* ptr = stackalloc 当触发对策事件时.__当触发对策事件时_DelegateParams[(UIntPtr)2295] + 15L / (long)sizeof(当触发对策事件时.__当触发对策事件时_DelegateParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(当触发对策事件时.StaticFunctionPtr(), (void*)ptr, 1);
			ptr->对策事件ID = 对策事件ID;
			if (受击数据 != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SHitInformation.StaticStruct(), &ptr->受击数据, 受击数据.NativePtr, 1, false);
			}
			base.BroadcastInternal((void*)ptr);
			UnrealReflectionUtils.DestroyStruct(BP_EventManager_C.__当触发对策事件时__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0601DCA2 RID: 122018 RVA: 0x008E0C68 File Offset: 0x008DEE68
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveOptimization)]
		protected unsafe static void OnScriptCallback(IntPtr __Handle, byte* __Parameters)
		{
			object target = GCHandle.FromIntPtr(__Handle).Target;
			Action<int, SHitInformation> action = target as Action<int, SHitInformation>;
			if (action == null)
			{
				throw new ArgumentException((target != null) ? target.GetType().ToString() : null);
			}
			SHitInformation arg = new SHitInformation(&((当触发对策事件时.__当触发对策事件时_DelegateParams*)__Parameters)->受击数据, true, true);
			action(((当触发对策事件时.__当触发对策事件时_DelegateParams*)__Parameters)->对策事件ID, arg);
		}

		// Token: 0x0400E973 RID: 59763
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/UI/Manager/BP_EventManager.BP_EventManager_C:当触发对策事件时__DelegateSignature";

		// Token: 0x020096D1 RID: 38609
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 2280)]
		protected ref struct __当触发对策事件时_DelegateParams
		{
			// Token: 0x04031BB4 RID: 203700
			[FieldOffset(0)]
			public int 对策事件ID;

			// Token: 0x04031BB5 RID: 203701
			[FieldOffset(8)]
			public byte 受击数据;
		}
	}
}
