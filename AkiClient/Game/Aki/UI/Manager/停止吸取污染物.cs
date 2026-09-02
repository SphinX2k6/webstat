using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.UI.Manager
{
	// Token: 0x02003995 RID: 14741
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class 停止吸取污染物 : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x0601DBF9 RID: 121849 RVA: 0x008DF8AE File Offset: 0x008DDAAE
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return 停止吸取污染物.StaticFunctionPtr();
		}

		// Token: 0x0601DBFA RID: 121850 RVA: 0x008DF8BA File Offset: 0x008DDABA
		private static IntPtr StaticFunctionPtr()
		{
			if (BP_EventManager_C.__停止吸取污染物__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				BP_EventManager_C.__停止吸取污染物__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/UI/Manager/BP_EventManager.BP_EventManager_C:停止吸取污染物__DelegateSignature");
			}
			return BP_EventManager_C.__停止吸取污染物__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x0601DBFB RID: 121851 RVA: 0x008DF8DD File Offset: 0x008DDADD
		public 停止吸取污染物()
		{
		}

		// Token: 0x0601DBFC RID: 121852 RVA: 0x008DF8E5 File Offset: 0x008DDAE5
		[NullableContext(2)]
		public 停止吸取污染物(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0601DBFD RID: 121853 RVA: 0x008DF8EF File Offset: 0x008DDAEF
		public 停止吸取污染物(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0601DBFE RID: 121854 RVA: 0x008DF8FA File Offset: 0x008DDAFA
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action<int>) ?? ((Action<int>)Delegate.CreateDelegate(typeof(Action<int>), Callback.Target, Callback.Method)));
		}

		// Token: 0x0601DBFF RID: 121855 RVA: 0x008DF92C File Offset: 0x008DDB2C
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add(Action<int> Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x0601DC00 RID: 121856 RVA: 0x008DF93B File Offset: 0x008DDB3B
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove(Action<int> Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x0601DC01 RID: 121857 RVA: 0x008DF944 File Offset: 0x008DDB44
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void Broadcast(int EntityId)
		{
			停止吸取污染物.__停止吸取污染物_DelegateParams* ptr = stackalloc 停止吸取污染物.__停止吸取污染物_DelegateParams[(UIntPtr)19] + 15L / (long)sizeof(停止吸取污染物.__停止吸取污染物_DelegateParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(停止吸取污染物.StaticFunctionPtr(), (void*)ptr, 1);
			ptr->EntityId = EntityId;
			base.BroadcastInternal((void*)ptr);
		}

		// Token: 0x0601DC02 RID: 121858 RVA: 0x008DF980 File Offset: 0x008DDB80
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
			action(((停止吸取污染物.__停止吸取污染物_DelegateParams*)__Parameters)->EntityId);
		}

		// Token: 0x0400E963 RID: 59747
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/UI/Manager/BP_EventManager.BP_EventManager_C:停止吸取污染物__DelegateSignature";

		// Token: 0x020096C3 RID: 38595
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __停止吸取污染物_DelegateParams
		{
			// Token: 0x04031B9F RID: 203679
			[FieldOffset(0)]
			public int EntityId;
		}
	}
}
