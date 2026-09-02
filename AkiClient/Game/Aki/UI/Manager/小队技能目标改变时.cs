using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.UI.Manager
{
	// Token: 0x0200399B RID: 14747
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class 小队技能目标改变时 : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x0601DC35 RID: 121909 RVA: 0x008DFFEA File Offset: 0x008DE1EA
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return 小队技能目标改变时.StaticFunctionPtr();
		}

		// Token: 0x0601DC36 RID: 121910 RVA: 0x008DFFF6 File Offset: 0x008DE1F6
		private static IntPtr StaticFunctionPtr()
		{
			if (BP_EventManager_C.__小队技能目标改变时__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				BP_EventManager_C.__小队技能目标改变时__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/UI/Manager/BP_EventManager.BP_EventManager_C:小队技能目标改变时__DelegateSignature");
			}
			return BP_EventManager_C.__小队技能目标改变时__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x0601DC37 RID: 121911 RVA: 0x008E0019 File Offset: 0x008DE219
		public 小队技能目标改变时()
		{
		}

		// Token: 0x0601DC38 RID: 121912 RVA: 0x008E0021 File Offset: 0x008DE221
		[NullableContext(2)]
		public 小队技能目标改变时(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0601DC39 RID: 121913 RVA: 0x008E002B File Offset: 0x008DE22B
		public 小队技能目标改变时(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0601DC3A RID: 121914 RVA: 0x008E0036 File Offset: 0x008DE236
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action<TsBaseCharacter>) ?? ((Action<TsBaseCharacter>)Delegate.CreateDelegate(typeof(Action<TsBaseCharacter>), Callback.Target, Callback.Method)));
		}

		// Token: 0x0601DC3B RID: 121915 RVA: 0x008E0068 File Offset: 0x008DE268
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add([Nullable(new byte[]
		{
			1,
			2
		})] Action<TsBaseCharacter> Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x0601DC3C RID: 121916 RVA: 0x008E0077 File Offset: 0x008DE277
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove([Nullable(new byte[]
		{
			1,
			2
		})] Action<TsBaseCharacter> Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x0601DC3D RID: 121917 RVA: 0x008E0080 File Offset: 0x008DE280
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void Broadcast(TsBaseCharacter 目标)
		{
			小队技能目标改变时.__小队技能目标改变时_DelegateParams* ptr = stackalloc 小队技能目标改变时.__小队技能目标改变时_DelegateParams[(UIntPtr)23] + 15L / (long)sizeof(小队技能目标改变时.__小队技能目标改变时_DelegateParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(小队技能目标改变时.StaticFunctionPtr(), (void*)ptr, 1);
			ptr->目标 = ((目标 != null) ? 目标.NativePtr : IntPtr.Zero);
			base.BroadcastInternal((void*)ptr);
		}

		// Token: 0x0601DC3E RID: 121918 RVA: 0x008E00CC File Offset: 0x008DE2CC
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
			TsBaseCharacter orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<TsBaseCharacter>(((小队技能目标改变时.__小队技能目标改变时_DelegateParams*)__Parameters)->目标);
			action(orCreateUObjectByNativePointer);
		}

		// Token: 0x0400E969 RID: 59753
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/UI/Manager/BP_EventManager.BP_EventManager_C:小队技能目标改变时__DelegateSignature";

		// Token: 0x020096C9 RID: 38601
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __小队技能目标改变时_DelegateParams
		{
			// Token: 0x04031BAA RID: 203690
			[FieldOffset(0)]
			public IntPtr 目标;
		}
	}
}
