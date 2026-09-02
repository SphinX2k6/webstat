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
	// Token: 0x02003CB1 RID: 15537
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class OnWeatherPresetChanged : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x06024B3C RID: 150332 RVA: 0x009A4F5C File Offset: 0x009A315C
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return OnWeatherPresetChanged.StaticFunctionPtr();
		}

		// Token: 0x06024B3D RID: 150333 RVA: 0x009A4F68 File Offset: 0x009A3168
		private static IntPtr StaticFunctionPtr()
		{
			if (BP_SkyDome_C.__OnWeatherPresetChanged__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				BP_SkyDome_C.__OnWeatherPresetChanged__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/Render/RuntimeBP/GI/Skybox/BP_SkyDome.BP_SkyDome_C:OnWeatherPresetChanged__DelegateSignature");
			}
			return BP_SkyDome_C.__OnWeatherPresetChanged__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x06024B3E RID: 150334 RVA: 0x009A4F8B File Offset: 0x009A318B
		public OnWeatherPresetChanged()
		{
		}

		// Token: 0x06024B3F RID: 150335 RVA: 0x009A4F93 File Offset: 0x009A3193
		[NullableContext(2)]
		public OnWeatherPresetChanged(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06024B40 RID: 150336 RVA: 0x009A4F9D File Offset: 0x009A319D
		public OnWeatherPresetChanged(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06024B41 RID: 150337 RVA: 0x009A4FA8 File Offset: 0x009A31A8
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as OnWeatherPresetChanged.OnWeatherPresetChanged_ScriptDelegate) ?? ((OnWeatherPresetChanged.OnWeatherPresetChanged_ScriptDelegate)Delegate.CreateDelegate(typeof(OnWeatherPresetChanged.OnWeatherPresetChanged_ScriptDelegate), Callback.Target, Callback.Method)));
		}

		// Token: 0x06024B42 RID: 150338 RVA: 0x009A4FDA File Offset: 0x009A31DA
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add(OnWeatherPresetChanged.OnWeatherPresetChanged_ScriptDelegate Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x06024B43 RID: 150339 RVA: 0x009A4FE9 File Offset: 0x009A31E9
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove(OnWeatherPresetChanged.OnWeatherPresetChanged_ScriptDelegate Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x06024B44 RID: 150340 RVA: 0x009A4FF4 File Offset: 0x009A31F4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void Broadcast([Nullable(new byte[]
		{
			0,
			1
		})] TSubclassOf<WeatherPreset_C> Preset, float TransitionDuration)
		{
			OnWeatherPresetChanged.__OnWeatherPresetChanged_DelegateParams* ptr = stackalloc OnWeatherPresetChanged.__OnWeatherPresetChanged_DelegateParams[(UIntPtr)31] + 15L / (long)sizeof(OnWeatherPresetChanged.__OnWeatherPresetChanged_DelegateParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(OnWeatherPresetChanged.StaticFunctionPtr(), (void*)ptr, 1);
			ptr->Preset = Preset;
			ptr->TransitionDuration = TransitionDuration;
			base.BroadcastInternal((void*)ptr);
		}

		// Token: 0x06024B45 RID: 150341 RVA: 0x009A5038 File Offset: 0x009A3238
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveOptimization)]
		protected unsafe static void OnScriptCallback(IntPtr __Handle, byte* __Parameters)
		{
			object target = GCHandle.FromIntPtr(__Handle).Target;
			OnWeatherPresetChanged.OnWeatherPresetChanged_ScriptDelegate onWeatherPresetChanged_ScriptDelegate = target as OnWeatherPresetChanged.OnWeatherPresetChanged_ScriptDelegate;
			if (onWeatherPresetChanged_ScriptDelegate == null)
			{
				throw new ArgumentException((target != null) ? target.GetType().ToString() : null);
			}
			onWeatherPresetChanged_ScriptDelegate(((OnWeatherPresetChanged.__OnWeatherPresetChanged_DelegateParams*)__Parameters)->Preset, ((OnWeatherPresetChanged.__OnWeatherPresetChanged_DelegateParams*)__Parameters)->TransitionDuration);
		}

		// Token: 0x04012D26 RID: 77094
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/GI/Skybox/BP_SkyDome.BP_SkyDome_C:OnWeatherPresetChanged__DelegateSignature";

		// Token: 0x02009E30 RID: 40496
		// (Invoke) Token: 0x0604A59F RID: 304543
		public delegate void OnWeatherPresetChanged_ScriptDelegate([Nullable(new byte[]
		{
			0,
			1
		})] TSubclassOf<WeatherPreset_C> Preset, float TransitionDuration);

		// Token: 0x02009E31 RID: 40497
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __OnWeatherPresetChanged_DelegateParams
		{
			// Token: 0x04032883 RID: 206979
			[Nullable(new byte[]
			{
				0,
				1
			})]
			[FieldOffset(0)]
			public TSubclassOf<WeatherPreset_C> Preset;

			// Token: 0x04032884 RID: 206980
			[FieldOffset(8)]
			public float TransitionDuration;
		}
	}
}
