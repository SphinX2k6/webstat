using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x0200428A RID: 17034
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class 当刷新检测结果时 : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x0602D412 RID: 185362 RVA: 0x00ABB265 File Offset: 0x00AB9465
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return 当刷新检测结果时.StaticFunctionPtr();
		}

		// Token: 0x0602D413 RID: 185363 RVA: 0x00ABB271 File Offset: 0x00AB9471
		private static IntPtr StaticFunctionPtr()
		{
			if (BP_HeadStateComponent_C.__当刷新检测结果时__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				BP_HeadStateComponent_C.__当刷新检测结果时__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/Character/BaseCharacter/BP_HeadStateComponent.BP_HeadStateComponent_C:当刷新检测结果时__DelegateSignature");
			}
			return BP_HeadStateComponent_C.__当刷新检测结果时__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x0602D414 RID: 185364 RVA: 0x00ABB294 File Offset: 0x00AB9494
		public 当刷新检测结果时()
		{
		}

		// Token: 0x0602D415 RID: 185365 RVA: 0x00ABB29C File Offset: 0x00AB949C
		[NullableContext(2)]
		public 当刷新检测结果时(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602D416 RID: 185366 RVA: 0x00ABB2A6 File Offset: 0x00AB94A6
		public 当刷新检测结果时(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602D417 RID: 185367 RVA: 0x00ABB2B1 File Offset: 0x00AB94B1
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as 当刷新检测结果时.当刷新检测结果时_ScriptDelegate) ?? ((当刷新检测结果时.当刷新检测结果时_ScriptDelegate)Delegate.CreateDelegate(typeof(当刷新检测结果时.当刷新检测结果时_ScriptDelegate), Callback.Target, Callback.Method)));
		}

		// Token: 0x0602D418 RID: 185368 RVA: 0x00ABB2E3 File Offset: 0x00AB94E3
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add(当刷新检测结果时.当刷新检测结果时_ScriptDelegate Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x0602D419 RID: 185369 RVA: 0x00ABB2F2 File Offset: 0x00AB94F2
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove(当刷新检测结果时.当刷新检测结果时_ScriptDelegate Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x0602D41A RID: 185370 RVA: 0x00ABB2FC File Offset: 0x00AB94FC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void Broadcast([Nullable(new byte[]
		{
			2,
			1
		})] ref TArray<TsBaseCharacter> Results)
		{
			当刷新检测结果时.__当刷新检测结果时_DelegateParams* ptr = stackalloc 当刷新检测结果时.__当刷新检测结果时_DelegateParams[(UIntPtr)31] + 15L / (long)sizeof(当刷新检测结果时.__当刷新检测结果时_DelegateParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(当刷新检测结果时.StaticFunctionPtr(), (void*)ptr, 1);
			TArray<TsBaseCharacter> tarray = Results;
			if (tarray != null)
			{
				tarray.MoveTo(&ptr->Results);
			}
			base.BroadcastInternal((void*)ptr);
			TArray<TsBaseCharacter> tarray2 = Results;
			if (tarray2 != null)
			{
				tarray2.MoveAssign(&ptr->Results);
			}
			UnrealReflectionUtils.DestroyStruct(BP_HeadStateComponent_C.__当刷新检测结果时__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602D41B RID: 185371 RVA: 0x00ABB36C File Offset: 0x00AB956C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveOptimization)]
		protected unsafe static void OnScriptCallback(IntPtr __Handle, byte* __Parameters)
		{
			object target = GCHandle.FromIntPtr(__Handle).Target;
			当刷新检测结果时.当刷新检测结果时_ScriptDelegate 当刷新检测结果时_ScriptDelegate = target as 当刷新检测结果时.当刷新检测结果时_ScriptDelegate;
			if (当刷新检测结果时_ScriptDelegate == null)
			{
				throw new ArgumentException((target != null) ? target.GetType().ToString() : null);
			}
			TArray<TsBaseCharacter> tarray = new TArray<TsBaseCharacter>(&((当刷新检测结果时.__当刷新检测结果时_DelegateParams*)__Parameters)->Results, true, true);
			当刷新检测结果时_ScriptDelegate(ref tarray);
			if (tarray != null)
			{
				tarray.CopyTo(&((当刷新检测结果时.__当刷新检测结果时_DelegateParams*)__Parameters)->Results, default(UScriptStructStackOnlyPtr));
			}
		}

		// Token: 0x040195DF RID: 103903
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/BP_HeadStateComponent.BP_HeadStateComponent_C:当刷新检测结果时__DelegateSignature";

		// Token: 0x0200A524 RID: 42276
		// (Invoke) Token: 0x0604A5A3 RID: 304547
		public delegate void 当刷新检测结果时_ScriptDelegate([Nullable(new byte[]
		{
			2,
			1
		})] ref TArray<TsBaseCharacter> Results);

		// Token: 0x0200A525 RID: 42277
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __当刷新检测结果时_DelegateParams
		{
			// Token: 0x040333CC RID: 209868
			[FieldOffset(0)]
			public byte Results;
		}
	}
}
