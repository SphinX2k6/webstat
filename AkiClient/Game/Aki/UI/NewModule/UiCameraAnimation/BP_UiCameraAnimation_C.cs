using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.UI.NewModule.UiCameraAnimation
{
	// Token: 0x0200397A RID: 14714
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/UI/NewModule/UiCameraAnimation/BP_UiCameraAnimation.BP_UiCameraAnimation_C")]
	[UnrealStructLayout(1048, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1048)]
	public class BP_UiCameraAnimation_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601DA17 RID: 121367 RVA: 0x008DBAC6 File Offset: 0x008D9CC6
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_UiCameraAnimation_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/UI/NewModule/UiCameraAnimation/BP_UiCameraAnimation.BP_UiCameraAnimation_C");
			}
			return BP_UiCameraAnimation_C._ClassPtr;
		}

		// Token: 0x0601DA18 RID: 121368 RVA: 0x008DBAEC File Offset: 0x008D9CEC
		public BP_UiCameraAnimation_C() : this(BuiltinUtils.AllocNativeUObject(BP_UiCameraAnimation_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601DA19 RID: 121369 RVA: 0x008DBB14 File Offset: 0x008D9D14
		[NullableContext(1)]
		public BP_UiCameraAnimation_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_UiCameraAnimation_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170026F6 RID: 9974
		// (get) Token: 0x0601DA1A RID: 121370 RVA: 0x008DBB47 File Offset: 0x008D9D47
		// (set) Token: 0x0601DA1B RID: 121371 RVA: 0x008DBB5B File Offset: 0x008D9D5B
		public unsafe UCameraComponent Camera
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCameraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_UiCameraAnimation_C.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_UiCameraAnimation_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x170026F7 RID: 9975
		// (get) Token: 0x0601DA1C RID: 121372 RVA: 0x008DBB70 File Offset: 0x008D9D70
		// (set) Token: 0x0601DA1D RID: 121373 RVA: 0x008DBB84 File Offset: 0x008D9D84
		public unsafe USpringArmComponent SpringArm
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USpringArmComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_UiCameraAnimation_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_UiCameraAnimation_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170026F8 RID: 9976
		// (get) Token: 0x0601DA1E RID: 121374 RVA: 0x008DBB99 File Offset: 0x008D9D99
		// (set) Token: 0x0601DA1F RID: 121375 RVA: 0x008DBBAD File Offset: 0x008D9DAD
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_UiCameraAnimation_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_UiCameraAnimation_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x0601DA20 RID: 121376 RVA: 0x008DBBC2 File Offset: 0x008D9DC2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_UiCameraAnimation_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0601DA21 RID: 121377 RVA: 0x008DBBD6 File Offset: 0x008D9DD6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_UiCameraAnimation_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601DA22 RID: 121378 RVA: 0x008DBBEB File Offset: 0x008D9DEB
		protected BP_UiCameraAnimation_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400E81C RID: 59420
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/UI/NewModule/UiCameraAnimation/BP_UiCameraAnimation.BP_UiCameraAnimation_C";

		// Token: 0x0400E81D RID: 59421
		private static IntPtr _ClassPtr;

		// Token: 0x0400E81E RID: 59422
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400E81F RID: 59423
		internal static int __PropertyOffset_0;

		// Token: 0x0400E820 RID: 59424
		internal static int __PropertyOffset_1;

		// Token: 0x0400E821 RID: 59425
		internal static int __PropertyOffset_2;

		// Token: 0x0400E822 RID: 59426
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;
	}
}
