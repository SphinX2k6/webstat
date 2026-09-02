using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.FluidNinjaLive.Core
{
	// Token: 0x02003D09 RID: 15625
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class OnPresetSave : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x06025BCD RID: 154573 RVA: 0x009C381D File Offset: 0x009C1A1D
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return OnPresetSave.StaticFunctionPtr();
		}

		// Token: 0x06025BCE RID: 154574 RVA: 0x009C3829 File Offset: 0x009C1A29
		private static IntPtr StaticFunctionPtr()
		{
			if (NinjaLiveGUI_C.__OnPresetSave__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				NinjaLiveGUI_C.__OnPresetSave__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/Render/RuntimeBP/FluidNinjaLive/Core/NinjaLiveGUI.NinjaLiveGUI_C:OnPresetSave__DelegateSignature");
			}
			return NinjaLiveGUI_C.__OnPresetSave__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x06025BCF RID: 154575 RVA: 0x009C384C File Offset: 0x009C1A4C
		public OnPresetSave()
		{
		}

		// Token: 0x06025BD0 RID: 154576 RVA: 0x009C3854 File Offset: 0x009C1A54
		[NullableContext(2)]
		public OnPresetSave(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06025BD1 RID: 154577 RVA: 0x009C385E File Offset: 0x009C1A5E
		public OnPresetSave(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06025BD2 RID: 154578 RVA: 0x009C3869 File Offset: 0x009C1A69
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action<string, string, bool>) ?? ((Action<string, string, bool>)Delegate.CreateDelegate(typeof(Action<string, string, bool>), Callback.Target, Callback.Method)));
		}

		// Token: 0x06025BD3 RID: 154579 RVA: 0x009C389B File Offset: 0x009C1A9B
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add(Action<string, string, bool> Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x06025BD4 RID: 154580 RVA: 0x009C38AA File Offset: 0x009C1AAA
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove(Action<string, string, bool> Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x06025BD5 RID: 154581 RVA: 0x009C38B4 File Offset: 0x009C1AB4
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void Broadcast(string SelectedProject, string SelectedPreset, bool OverWriteOrNot)
		{
			OnPresetSave.__OnPresetSave_DelegateParams* ptr = stackalloc OnPresetSave.__OnPresetSave_DelegateParams[(UIntPtr)55] + 15L / (long)sizeof(OnPresetSave.__OnPresetSave_DelegateParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(OnPresetSave.StaticFunctionPtr(), (void*)ptr, 1);
			FString.CopyFrom((void*)(&ptr->SelectedProject), SelectedProject);
			FString.CopyFrom((void*)(&ptr->SelectedPreset), SelectedPreset);
			ptr->OverWriteOrNot = OverWriteOrNot;
			base.BroadcastInternal((void*)ptr);
			UnrealReflectionUtils.DestroyStruct(NinjaLiveGUI_C.__OnPresetSave__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06025BD6 RID: 154582 RVA: 0x009C391C File Offset: 0x009C1B1C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveOptimization)]
		protected unsafe static void OnScriptCallback(IntPtr __Handle, byte* __Parameters)
		{
			object target = GCHandle.FromIntPtr(__Handle).Target;
			Action<string, string, bool> action = target as Action<string, string, bool>;
			if (action == null)
			{
				throw new ArgumentException((target != null) ? target.GetType().ToString() : null);
			}
			string arg = FString.ToString((void*)(&((OnPresetSave.__OnPresetSave_DelegateParams*)__Parameters)->SelectedProject));
			string arg2 = FString.ToString((void*)(&((OnPresetSave.__OnPresetSave_DelegateParams*)__Parameters)->SelectedPreset));
			action(arg, arg2, ((OnPresetSave.__OnPresetSave_DelegateParams*)__Parameters)->OverWriteOrNot);
		}

		// Token: 0x040137C3 RID: 79811
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/FluidNinjaLive/Core/NinjaLiveGUI.NinjaLiveGUI_C:OnPresetSave__DelegateSignature";

		// Token: 0x02009F98 RID: 40856
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __OnPresetSave_DelegateParams
		{
			// Token: 0x04032B41 RID: 207681
			[FieldOffset(0)]
			public FString SelectedProject;

			// Token: 0x04032B42 RID: 207682
			[FieldOffset(16)]
			public FString SelectedPreset;

			// Token: 0x04032B43 RID: 207683
			[FieldOffset(32)]
			public bool OverWriteOrNot;
		}
	}
}
