using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.UI.Module.Common.View.Widget
{
	// Token: 0x02003984 RID: 14724
	[UnrealObjectPath("/Game/Aki/UI/Module/Common/View/Widget/KuroButton.KuroButton_C")]
	[UnrealStructLayout(1600, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1600)]
	public class KuroButton_C : UButton, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601DAAF RID: 121519 RVA: 0x008DCC29 File Offset: 0x008DAE29
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (KuroButton_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/UI/Module/Common/View/Widget/KuroButton.KuroButton_C");
			}
			return KuroButton_C._ClassPtr;
		}

		// Token: 0x0601DAB0 RID: 121520 RVA: 0x008DCC50 File Offset: 0x008DAE50
		public KuroButton_C() : this(BuiltinUtils.AllocNativeUObject(KuroButton_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601DAB1 RID: 121521 RVA: 0x008DCC78 File Offset: 0x008DAE78
		[NullableContext(1)]
		public KuroButton_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(KuroButton_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700271B RID: 10011
		// (get) Token: 0x0601DAB2 RID: 121522 RVA: 0x008DCCAB File Offset: 0x008DAEAB
		// (set) Token: 0x0601DAB3 RID: 121523 RVA: 0x008DCCBF File Offset: 0x008DAEBF
		[Nullable(2)]
		public unsafe UAkAudioEvent 音频文件
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UAkAudioEvent>(base.NativePtr / (IntPtr)sizeof(void*) + KuroButton_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + KuroButton_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x0601DAB4 RID: 121524 RVA: 0x008DCCD4 File Offset: 0x008DAED4
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 通过文件播放音效(UAkAudioEvent 音效)
		{
			KuroButton_C.__通过文件播放音效_FunctionParams* ptr = stackalloc KuroButton_C.__通过文件播放音效_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(KuroButton_C.__通过文件播放音效_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(KuroButton_C.__通过文件播放音效_NativeFunctionPtr, (void*)ptr, 1);
			ptr->音效 = ((音效 != null) ? 音效.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, KuroButton_C.__通过文件播放音效_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601DAB5 RID: 121525 RVA: 0x008DCD29 File Offset: 0x008DAF29
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 播放音效()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, KuroButton_C.__播放音效_NativeFunctionPtr, null);
		}

		// Token: 0x0601DAB6 RID: 121526 RVA: 0x008DCD40 File Offset: 0x008DAF40
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 设置音频路径(UAkAudioEvent paht)
		{
			KuroButton_C.__设置音频路径_FunctionParams* ptr = stackalloc KuroButton_C.__设置音频路径_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(KuroButton_C.__设置音频路径_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(KuroButton_C.__设置音频路径_NativeFunctionPtr, (void*)ptr, 1);
			ptr->paht = ((paht != null) ? paht.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, KuroButton_C.__设置音频路径_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601DAB7 RID: 121527 RVA: 0x008DCD95 File Offset: 0x008DAF95
		protected KuroButton_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400E86B RID: 59499
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/UI/Module/Common/View/Widget/KuroButton.KuroButton_C";

		// Token: 0x0400E86C RID: 59500
		private static IntPtr _ClassPtr;

		// Token: 0x0400E86D RID: 59501
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400E86E RID: 59502
		internal static int __PropertyOffset_0;

		// Token: 0x0400E86F RID: 59503
		private static IntPtr __通过文件播放音效_NativeFunctionPtr;

		// Token: 0x0400E870 RID: 59504
		private static IntPtr __播放音效_NativeFunctionPtr;

		// Token: 0x0400E871 RID: 59505
		private static IntPtr __设置音频路径_NativeFunctionPtr;

		// Token: 0x020096AF RID: 38575
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __通过文件播放音效_FunctionParams
		{
			// Token: 0x04031B84 RID: 203652
			[FieldOffset(0)]
			public IntPtr 音效;
		}

		// Token: 0x020096B0 RID: 38576
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __设置音频路径_FunctionParams
		{
			// Token: 0x04031B85 RID: 203653
			[FieldOffset(0)]
			public IntPtr paht;
		}
	}
}
