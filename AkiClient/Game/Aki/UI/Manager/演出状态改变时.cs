using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Sequence.Manager;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.UI.Manager
{
	// Token: 0x020039AB RID: 14763
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class 演出状态改变时 : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x0601DCD5 RID: 122069 RVA: 0x008E124D File Offset: 0x008DF44D
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return 演出状态改变时.StaticFunctionPtr();
		}

		// Token: 0x0601DCD6 RID: 122070 RVA: 0x008E1259 File Offset: 0x008DF459
		private static IntPtr StaticFunctionPtr()
		{
			if (BP_EventManager_C.__演出状态改变时__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				BP_EventManager_C.__演出状态改变时__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/UI/Manager/BP_EventManager.BP_EventManager_C:演出状态改变时__DelegateSignature");
			}
			return BP_EventManager_C.__演出状态改变时__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x0601DCD7 RID: 122071 RVA: 0x008E127C File Offset: 0x008DF47C
		public 演出状态改变时()
		{
		}

		// Token: 0x0601DCD8 RID: 122072 RVA: 0x008E1284 File Offset: 0x008DF484
		[NullableContext(2)]
		public 演出状态改变时(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0601DCD9 RID: 122073 RVA: 0x008E128E File Offset: 0x008DF48E
		public 演出状态改变时(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0601DCDA RID: 122074 RVA: 0x008E1299 File Offset: 0x008DF499
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action<string, TEnumAsByte<EPlotState>>) ?? ((Action<string, TEnumAsByte<EPlotState>>)Delegate.CreateDelegate(typeof(Action<string, TEnumAsByte<EPlotState>>), Callback.Target, Callback.Method)));
		}

		// Token: 0x0601DCDB RID: 122075 RVA: 0x008E12CB File Offset: 0x008DF4CB
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add([Nullable(new byte[]
		{
			1,
			1,
			0
		})] Action<string, TEnumAsByte<EPlotState>> Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x0601DCDC RID: 122076 RVA: 0x008E12DA File Offset: 0x008DF4DA
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove([Nullable(new byte[]
		{
			1,
			1,
			0
		})] Action<string, TEnumAsByte<EPlotState>> Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x0601DCDD RID: 122077 RVA: 0x008E12E4 File Offset: 0x008DF4E4
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void Broadcast(string PlotId, EPlotState State)
		{
			演出状态改变时.__演出状态改变时_DelegateParams* ptr = stackalloc 演出状态改变时.__演出状态改变时_DelegateParams[(UIntPtr)39] + 15L / (long)sizeof(演出状态改变时.__演出状态改变时_DelegateParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(演出状态改变时.StaticFunctionPtr(), (void*)ptr, 1);
			FString.CopyFrom((void*)(&ptr->PlotId), PlotId);
			ptr->State = State;
			base.BroadcastInternal((void*)ptr);
			UnrealReflectionUtils.DestroyStruct(BP_EventManager_C.__演出状态改变时__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0601DCDE RID: 122078 RVA: 0x008E1344 File Offset: 0x008DF544
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveOptimization)]
		protected unsafe static void OnScriptCallback(IntPtr __Handle, byte* __Parameters)
		{
			object target = GCHandle.FromIntPtr(__Handle).Target;
			Action<string, TEnumAsByte<EPlotState>> action = target as Action<string, TEnumAsByte<EPlotState>>;
			if (action == null)
			{
				throw new ArgumentException((target != null) ? target.GetType().ToString() : null);
			}
			string arg = FString.ToString((void*)(&((演出状态改变时.__演出状态改变时_DelegateParams*)__Parameters)->PlotId));
			action(arg, ((演出状态改变时.__演出状态改变时_DelegateParams*)__Parameters)->State);
		}

		// Token: 0x0400E979 RID: 59769
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/UI/Manager/BP_EventManager.BP_EventManager_C:演出状态改变时__DelegateSignature";

		// Token: 0x020096D5 RID: 38613
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __演出状态改变时_DelegateParams
		{
			// Token: 0x04031BBD RID: 203709
			[FieldOffset(0)]
			public FString PlotId;

			// Token: 0x04031BBE RID: 203710
			[FieldOffset(16)]
			public TEnumAsByte<EPlotState> State;
		}
	}
}
