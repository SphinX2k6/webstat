using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Scene.NewGacha.BP
{
	// Token: 0x020039DA RID: 14810
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class ResultMain : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x0601E00E RID: 122894 RVA: 0x008E961E File Offset: 0x008E781E
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return ResultMain.StaticFunctionPtr();
		}

		// Token: 0x0601E00F RID: 122895 RVA: 0x008E962A File Offset: 0x008E782A
		private static IntPtr StaticFunctionPtr()
		{
			if (BP_UpdateInteract_C.__ResultMain__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				BP_UpdateInteract_C.__ResultMain__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/Scene/NewGacha/BP/BP_UpdateInteract.BP_UpdateInteract_C:ResultMain__DelegateSignature");
			}
			return BP_UpdateInteract_C.__ResultMain__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x0601E010 RID: 122896 RVA: 0x008E964D File Offset: 0x008E784D
		public ResultMain()
		{
		}

		// Token: 0x0601E011 RID: 122897 RVA: 0x008E9655 File Offset: 0x008E7855
		[NullableContext(2)]
		public ResultMain(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0601E012 RID: 122898 RVA: 0x008E965F File Offset: 0x008E785F
		public ResultMain(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0601E013 RID: 122899 RVA: 0x008E966A File Offset: 0x008E786A
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action<int>) ?? ((Action<int>)Delegate.CreateDelegate(typeof(Action<int>), Callback.Target, Callback.Method)));
		}

		// Token: 0x0601E014 RID: 122900 RVA: 0x008E969C File Offset: 0x008E789C
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add(Action<int> Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x0601E015 RID: 122901 RVA: 0x008E96AB File Offset: 0x008E78AB
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove(Action<int> Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x0601E016 RID: 122902 RVA: 0x008E96B4 File Offset: 0x008E78B4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void Broadcast(int ID)
		{
			ResultMain.__ResultMain_DelegateParams* ptr = stackalloc ResultMain.__ResultMain_DelegateParams[(UIntPtr)19] + 15L / (long)sizeof(ResultMain.__ResultMain_DelegateParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ResultMain.StaticFunctionPtr(), (void*)ptr, 1);
			ptr->ID = ID;
			base.BroadcastInternal((void*)ptr);
		}

		// Token: 0x0601E017 RID: 122903 RVA: 0x008E96F0 File Offset: 0x008E78F0
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
			action(((ResultMain.__ResultMain_DelegateParams*)__Parameters)->ID);
		}

		// Token: 0x0400EB8E RID: 60302
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Scene/NewGacha/BP/BP_UpdateInteract.BP_UpdateInteract_C:ResultMain__DelegateSignature";

		// Token: 0x02009749 RID: 38729
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __ResultMain_DelegateParams
		{
			// Token: 0x04031CBE RID: 203966
			[FieldOffset(0)]
			public int ID;
		}
	}
}
