using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.KuroCustomCapture
{
	// Token: 0x02003C71 RID: 15473
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/KuroCustomCapture/BP_KuroCustomCapture.BP_KuroCustomCapture_C")]
	[UnrealStructLayout(1064, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1064)]
	public class BP_KuroCustomCapture_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06023E72 RID: 147058 RVA: 0x0098F350 File Offset: 0x0098D550
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_KuroCustomCapture_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/KuroCustomCapture/BP_KuroCustomCapture.BP_KuroCustomCapture_C");
			}
			return BP_KuroCustomCapture_C._ClassPtr;
		}

		// Token: 0x06023E73 RID: 147059 RVA: 0x0098F374 File Offset: 0x0098D574
		public BP_KuroCustomCapture_C() : this(BuiltinUtils.AllocNativeUObject(BP_KuroCustomCapture_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06023E74 RID: 147060 RVA: 0x0098F39C File Offset: 0x0098D59C
		[NullableContext(1)]
		public BP_KuroCustomCapture_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_KuroCustomCapture_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170048F5 RID: 18677
		// (get) Token: 0x06023E75 RID: 147061 RVA: 0x0098F3CF File Offset: 0x0098D5CF
		// (set) Token: 0x06023E76 RID: 147062 RVA: 0x0098F3E3 File Offset: 0x0098D5E3
		public unsafe UBoxComponent Box
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCustomCapture_C.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCustomCapture_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x170048F6 RID: 18678
		// (get) Token: 0x06023E77 RID: 147063 RVA: 0x0098F3F8 File Offset: 0x0098D5F8
		// (set) Token: 0x06023E78 RID: 147064 RVA: 0x0098F40C File Offset: 0x0098D60C
		public unsafe UKuroCustomCaptureVolume KuroCustomCaptureVolume
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroCustomCaptureVolume>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCustomCapture_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCustomCapture_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170048F7 RID: 18679
		// (get) Token: 0x06023E79 RID: 147065 RVA: 0x0098F421 File Offset: 0x0098D621
		// (set) Token: 0x06023E7A RID: 147066 RVA: 0x0098F435 File Offset: 0x0098D635
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCustomCapture_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCustomCapture_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170048F8 RID: 18680
		// (get) Token: 0x06023E7B RID: 147067 RVA: 0x0098F44A File Offset: 0x0098D64A
		// (set) Token: 0x06023E7C RID: 147068 RVA: 0x0098F45A File Offset: 0x0098D65A
		public unsafe bool bCapture
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCustomCapture_C.__PropertyOffset_3) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCustomCapture_C.__PropertyOffset_3) = (value ? 1 : 0);
			}
		}

		// Token: 0x170048F9 RID: 18681
		// (get) Token: 0x06023E7D RID: 147069 RVA: 0x0098F46B File Offset: 0x0098D66B
		// (set) Token: 0x06023E7E RID: 147070 RVA: 0x0098F47F File Offset: 0x0098D67F
		[Nullable(0)]
		public unsafe TEnumAsByte<ECaptureMode> CaptureMode
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCustomCapture_C.__PropertyOffset_4);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCustomCapture_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x170048FA RID: 18682
		// (get) Token: 0x06023E7F RID: 147071 RVA: 0x0098F494 File Offset: 0x0098D694
		// (set) Token: 0x06023E80 RID: 147072 RVA: 0x0098F4A8 File Offset: 0x0098D6A8
		public unsafe UTextureRenderTarget2D RT
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCustomCapture_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCustomCapture_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x06023E81 RID: 147073 RVA: 0x0098F4BD File Offset: 0x0098D6BD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCustomCapture_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06023E82 RID: 147074 RVA: 0x0098F4D1 File Offset: 0x0098D6D1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroCustomCapture_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06023E83 RID: 147075 RVA: 0x0098F4E6 File Offset: 0x0098D6E6
		protected BP_KuroCustomCapture_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04012568 RID: 75112
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/KuroCustomCapture/BP_KuroCustomCapture.BP_KuroCustomCapture_C";

		// Token: 0x04012569 RID: 75113
		private static IntPtr _ClassPtr;

		// Token: 0x0401256A RID: 75114
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401256B RID: 75115
		internal static int __PropertyOffset_0;

		// Token: 0x0401256C RID: 75116
		internal static int __PropertyOffset_1;

		// Token: 0x0401256D RID: 75117
		internal static int __PropertyOffset_2;

		// Token: 0x0401256E RID: 75118
		internal static int __PropertyOffset_3;

		// Token: 0x0401256F RID: 75119
		internal static int __PropertyOffset_4;

		// Token: 0x04012570 RID: 75120
		internal static int __PropertyOffset_5;

		// Token: 0x04012571 RID: 75121
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;
	}
}
