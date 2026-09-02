using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.UI.Manager
{
	// Token: 0x020039B2 RID: 14770
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class 音乐节拍事件触发时 : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x0601DD1B RID: 122139 RVA: 0x008E1B47 File Offset: 0x008DFD47
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return 音乐节拍事件触发时.StaticFunctionPtr();
		}

		// Token: 0x0601DD1C RID: 122140 RVA: 0x008E1B53 File Offset: 0x008DFD53
		private static IntPtr StaticFunctionPtr()
		{
			if (BP_EventManager_C.__音乐节拍事件触发时__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				BP_EventManager_C.__音乐节拍事件触发时__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/UI/Manager/BP_EventManager.BP_EventManager_C:音乐节拍事件触发时__DelegateSignature");
			}
			return BP_EventManager_C.__音乐节拍事件触发时__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x0601DD1D RID: 122141 RVA: 0x008E1B76 File Offset: 0x008DFD76
		public 音乐节拍事件触发时()
		{
		}

		// Token: 0x0601DD1E RID: 122142 RVA: 0x008E1B7E File Offset: 0x008DFD7E
		[NullableContext(2)]
		public 音乐节拍事件触发时(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0601DD1F RID: 122143 RVA: 0x008E1B88 File Offset: 0x008DFD88
		public 音乐节拍事件触发时(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0601DD20 RID: 122144 RVA: 0x008E1B93 File Offset: 0x008DFD93
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action<string>) ?? ((Action<string>)Delegate.CreateDelegate(typeof(Action<string>), Callback.Target, Callback.Method)));
		}

		// Token: 0x0601DD21 RID: 122145 RVA: 0x008E1BC5 File Offset: 0x008DFDC5
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add(Action<string> Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x0601DD22 RID: 122146 RVA: 0x008E1BD4 File Offset: 0x008DFDD4
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove(Action<string> Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x0601DD23 RID: 122147 RVA: 0x008E1BE0 File Offset: 0x008DFDE0
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void Broadcast(string MusicEventType)
		{
			音乐节拍事件触发时.__音乐节拍事件触发时_DelegateParams* ptr = stackalloc 音乐节拍事件触发时.__音乐节拍事件触发时_DelegateParams[(UIntPtr)31] + 15L / (long)sizeof(音乐节拍事件触发时.__音乐节拍事件触发时_DelegateParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(音乐节拍事件触发时.StaticFunctionPtr(), (void*)ptr, 1);
			FString.CopyFrom((void*)(&ptr->MusicEventType), MusicEventType);
			base.BroadcastInternal((void*)ptr);
			UnrealReflectionUtils.DestroyStruct(BP_EventManager_C.__音乐节拍事件触发时__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0601DD24 RID: 122148 RVA: 0x008E1C34 File Offset: 0x008DFE34
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveOptimization)]
		protected unsafe static void OnScriptCallback(IntPtr __Handle, byte* __Parameters)
		{
			object target = GCHandle.FromIntPtr(__Handle).Target;
			Action<string> action = target as Action<string>;
			if (action == null)
			{
				throw new ArgumentException((target != null) ? target.GetType().ToString() : null);
			}
			string obj = FString.ToString((void*)(&((音乐节拍事件触发时.__音乐节拍事件触发时_DelegateParams*)__Parameters)->MusicEventType));
			action(obj);
		}

		// Token: 0x0400E980 RID: 59776
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/UI/Manager/BP_EventManager.BP_EventManager_C:音乐节拍事件触发时__DelegateSignature";

		// Token: 0x020096DB RID: 38619
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __音乐节拍事件触发时_DelegateParams
		{
			// Token: 0x04031BCE RID: 203726
			[FieldOffset(0)]
			public FString MusicEventType;
		}
	}
}
