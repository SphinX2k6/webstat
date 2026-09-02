using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Render.RuntimeBP.GI.Data.TOD;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.GI.Skybox
{
	// Token: 0x02003CB0 RID: 15536
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class OnTimeOfDayPresetChanged : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x06024B32 RID: 150322 RVA: 0x009A4E32 File Offset: 0x009A3032
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return OnTimeOfDayPresetChanged.StaticFunctionPtr();
		}

		// Token: 0x06024B33 RID: 150323 RVA: 0x009A4E3E File Offset: 0x009A303E
		private static IntPtr StaticFunctionPtr()
		{
			if (BP_SkyDome_C.__OnTimeOfDayPresetChanged__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				BP_SkyDome_C.__OnTimeOfDayPresetChanged__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/Render/RuntimeBP/GI/Skybox/BP_SkyDome.BP_SkyDome_C:OnTimeOfDayPresetChanged__DelegateSignature");
			}
			return BP_SkyDome_C.__OnTimeOfDayPresetChanged__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x06024B34 RID: 150324 RVA: 0x009A4E61 File Offset: 0x009A3061
		public OnTimeOfDayPresetChanged()
		{
		}

		// Token: 0x06024B35 RID: 150325 RVA: 0x009A4E69 File Offset: 0x009A3069
		[NullableContext(2)]
		public OnTimeOfDayPresetChanged(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06024B36 RID: 150326 RVA: 0x009A4E73 File Offset: 0x009A3073
		public OnTimeOfDayPresetChanged(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06024B37 RID: 150327 RVA: 0x009A4E7E File Offset: 0x009A307E
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as OnTimeOfDayPresetChanged.OnTimeOfDayPresetChanged_ScriptDelegate) ?? ((OnTimeOfDayPresetChanged.OnTimeOfDayPresetChanged_ScriptDelegate)Delegate.CreateDelegate(typeof(OnTimeOfDayPresetChanged.OnTimeOfDayPresetChanged_ScriptDelegate), Callback.Target, Callback.Method)));
		}

		// Token: 0x06024B38 RID: 150328 RVA: 0x009A4EB0 File Offset: 0x009A30B0
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add(OnTimeOfDayPresetChanged.OnTimeOfDayPresetChanged_ScriptDelegate Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x06024B39 RID: 150329 RVA: 0x009A4EBF File Offset: 0x009A30BF
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove(OnTimeOfDayPresetChanged.OnTimeOfDayPresetChanged_ScriptDelegate Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x06024B3A RID: 150330 RVA: 0x009A4EC8 File Offset: 0x009A30C8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void Broadcast([Nullable(new byte[]
		{
			0,
			1
		})] TSubclassOf<TimeOfDayPreset_C> Preset, float TransitionDuraion)
		{
			OnTimeOfDayPresetChanged.__OnTimeOfDayPresetChanged_DelegateParams* ptr = stackalloc OnTimeOfDayPresetChanged.__OnTimeOfDayPresetChanged_DelegateParams[(UIntPtr)31] + 15L / (long)sizeof(OnTimeOfDayPresetChanged.__OnTimeOfDayPresetChanged_DelegateParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(OnTimeOfDayPresetChanged.StaticFunctionPtr(), (void*)ptr, 1);
			ptr->Preset = Preset;
			ptr->TransitionDuraion = TransitionDuraion;
			base.BroadcastInternal((void*)ptr);
		}

		// Token: 0x06024B3B RID: 150331 RVA: 0x009A4F0C File Offset: 0x009A310C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveOptimization)]
		protected unsafe static void OnScriptCallback(IntPtr __Handle, byte* __Parameters)
		{
			object target = GCHandle.FromIntPtr(__Handle).Target;
			OnTimeOfDayPresetChanged.OnTimeOfDayPresetChanged_ScriptDelegate onTimeOfDayPresetChanged_ScriptDelegate = target as OnTimeOfDayPresetChanged.OnTimeOfDayPresetChanged_ScriptDelegate;
			if (onTimeOfDayPresetChanged_ScriptDelegate == null)
			{
				throw new ArgumentException((target != null) ? target.GetType().ToString() : null);
			}
			onTimeOfDayPresetChanged_ScriptDelegate(((OnTimeOfDayPresetChanged.__OnTimeOfDayPresetChanged_DelegateParams*)__Parameters)->Preset, ((OnTimeOfDayPresetChanged.__OnTimeOfDayPresetChanged_DelegateParams*)__Parameters)->TransitionDuraion);
		}

		// Token: 0x04012D25 RID: 77093
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/GI/Skybox/BP_SkyDome.BP_SkyDome_C:OnTimeOfDayPresetChanged__DelegateSignature";

		// Token: 0x02009E2E RID: 40494
		// (Invoke) Token: 0x0604A59B RID: 304539
		public delegate void OnTimeOfDayPresetChanged_ScriptDelegate([Nullable(new byte[]
		{
			0,
			1
		})] TSubclassOf<TimeOfDayPreset_C> Preset, float TransitionDuraion);

		// Token: 0x02009E2F RID: 40495
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __OnTimeOfDayPresetChanged_DelegateParams
		{
			// Token: 0x04032881 RID: 206977
			[Nullable(new byte[]
			{
				0,
				1
			})]
			[FieldOffset(0)]
			public TSubclassOf<TimeOfDayPreset_C> Preset;

			// Token: 0x04032882 RID: 206978
			[FieldOffset(8)]
			public float TransitionDuraion;
		}
	}
}
