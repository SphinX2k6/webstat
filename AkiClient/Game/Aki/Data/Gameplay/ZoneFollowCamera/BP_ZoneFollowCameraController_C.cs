using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.Gameplay.ZoneFollowCamera
{
	// Token: 0x02003E91 RID: 16017
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/Gameplay/ZoneFollowCamera/BP_ZoneFollowCameraController.BP_ZoneFollowCameraController_C")]
	[UnrealStructLayout(1128, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1124)]
	public class BP_ZoneFollowCameraController_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06027ABB RID: 162491 RVA: 0x009F796A File Offset: 0x009F5B6A
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_ZoneFollowCameraController_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Data/Gameplay/ZoneFollowCamera/BP_ZoneFollowCameraController.BP_ZoneFollowCameraController_C");
			}
			return BP_ZoneFollowCameraController_C._ClassPtr;
		}

		// Token: 0x06027ABC RID: 162492 RVA: 0x009F7990 File Offset: 0x009F5B90
		public BP_ZoneFollowCameraController_C() : this(BuiltinUtils.AllocNativeUObject(BP_ZoneFollowCameraController_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06027ABD RID: 162493 RVA: 0x009F79B8 File Offset: 0x009F5BB8
		[NullableContext(1)]
		public BP_ZoneFollowCameraController_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_ZoneFollowCameraController_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17005E30 RID: 24112
		// (get) Token: 0x06027ABE RID: 162494 RVA: 0x009F79EB File Offset: 0x009F5BEB
		// (set) Token: 0x06027ABF RID: 162495 RVA: 0x009F79FF File Offset: 0x009F5BFF
		public unsafe UStaticMeshComponent Sphere
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ZoneFollowCameraController_C.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ZoneFollowCameraController_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x17005E31 RID: 24113
		// (get) Token: 0x06027AC0 RID: 162496 RVA: 0x009F7A14 File Offset: 0x009F5C14
		// (set) Token: 0x06027AC1 RID: 162497 RVA: 0x009F7A28 File Offset: 0x009F5C28
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ZoneFollowCameraController_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ZoneFollowCameraController_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17005E32 RID: 24114
		// (get) Token: 0x06027AC2 RID: 162498 RVA: 0x009F7A3D File Offset: 0x009F5C3D
		// (set) Token: 0x06027AC3 RID: 162499 RVA: 0x009F7A51 File Offset: 0x009F5C51
		public unsafe ACameraActor 预览相机
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<ACameraActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ZoneFollowCameraController_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ZoneFollowCameraController_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17005E33 RID: 24115
		// (get) Token: 0x06027AC4 RID: 162500 RVA: 0x009F7A68 File Offset: 0x009F5C68
		// (set) Token: 0x06027AC5 RID: 162501 RVA: 0x009F7AA1 File Offset: 0x009F5CA1
		[Nullable(1)]
		public TArray<BP_ZoneFollowCameraZone_C> 区域配置
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<BP_ZoneFollowCameraZone_C> result;
				if ((result = this._区域配置) == null)
				{
					result = (this._区域配置 = new TArray<BP_ZoneFollowCameraZone_C>(base.NativePtr + (IntPtr)BP_ZoneFollowCameraController_C.__PropertyOffset_3, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.区域配置.CopyAssign(value);
			}
		}

		// Token: 0x17005E34 RID: 24116
		// (get) Token: 0x06027AC6 RID: 162502 RVA: 0x009F7AAF File Offset: 0x009F5CAF
		// (set) Token: 0x06027AC7 RID: 162503 RVA: 0x009F7ABF File Offset: 0x009F5CBF
		public unsafe float 过渡速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ZoneFollowCameraController_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ZoneFollowCameraController_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17005E35 RID: 24117
		// (get) Token: 0x06027AC8 RID: 162504 RVA: 0x009F7AD0 File Offset: 0x009F5CD0
		// (set) Token: 0x06027AC9 RID: 162505 RVA: 0x009F7AE4 File Offset: 0x009F5CE4
		public unsafe FVector TargetCameraPos
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ZoneFollowCameraController_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ZoneFollowCameraController_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17005E36 RID: 24118
		// (get) Token: 0x06027ACA RID: 162506 RVA: 0x009F7AF9 File Offset: 0x009F5CF9
		// (set) Token: 0x06027ACB RID: 162507 RVA: 0x009F7B0D File Offset: 0x009F5D0D
		public unsafe FRotator TargetCameraRot
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ZoneFollowCameraController_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ZoneFollowCameraController_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17005E37 RID: 24119
		// (get) Token: 0x06027ACC RID: 162508 RVA: 0x009F7B22 File Offset: 0x009F5D22
		// (set) Token: 0x06027ACD RID: 162509 RVA: 0x009F7B32 File Offset: 0x009F5D32
		public unsafe bool IsActive
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ZoneFollowCameraController_C.__PropertyOffset_7) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ZoneFollowCameraController_C.__PropertyOffset_7) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005E38 RID: 24120
		// (get) Token: 0x06027ACE RID: 162510 RVA: 0x009F7B43 File Offset: 0x009F5D43
		// (set) Token: 0x06027ACF RID: 162511 RVA: 0x009F7B53 File Offset: 0x009F5D53
		public unsafe float 默认相机FOV
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ZoneFollowCameraController_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ZoneFollowCameraController_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17005E39 RID: 24121
		// (get) Token: 0x06027AD0 RID: 162512 RVA: 0x009F7B64 File Offset: 0x009F5D64
		// (set) Token: 0x06027AD1 RID: 162513 RVA: 0x009F7B78 File Offset: 0x009F5D78
		public unsafe FVector 默认相机偏移
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ZoneFollowCameraController_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ZoneFollowCameraController_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17005E3A RID: 24122
		// (get) Token: 0x06027AD2 RID: 162514 RVA: 0x009F7B8D File Offset: 0x009F5D8D
		// (set) Token: 0x06027AD3 RID: 162515 RVA: 0x009F7BA1 File Offset: 0x009F5DA1
		public unsafe FRotator 默认相机旋转
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ZoneFollowCameraController_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ZoneFollowCameraController_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x06027AD4 RID: 162516 RVA: 0x009F7BB8 File Offset: 0x009F5DB8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void PackageCameraConfig(ref SZoneFollowCameraSettings Configs)
		{
			BP_ZoneFollowCameraController_C.__PackageCameraConfig_FunctionParams* ptr = stackalloc BP_ZoneFollowCameraController_C.__PackageCameraConfig_FunctionParams[(UIntPtr)639] + 15L / (long)sizeof(BP_ZoneFollowCameraController_C.__PackageCameraConfig_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ZoneFollowCameraController_C.__PackageCameraConfig_NativeFunctionPtr, (void*)ptr, 1);
			if (Configs != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SZoneFollowCameraSettings.StaticStruct(), &ptr->Configs, Configs.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ZoneFollowCameraController_C.__PackageCameraConfig_NativeFunctionPtr, (void*)ptr);
			if (Configs != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SZoneFollowCameraSettings.StaticStruct(), Configs.NativePtr, &ptr->Configs, 1, false);
			}
			UnrealReflectionUtils.DestroyStruct(BP_ZoneFollowCameraController_C.__PackageCameraConfig_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06027AD5 RID: 162517 RVA: 0x009F7C54 File Offset: 0x009F5E54
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void ComputeTargetPosition(ref TArray<int> ZoneIndexs, FVector RoleWorldPos, ref FVector OutPosition, ref FRotator OutRotation)
		{
			BP_ZoneFollowCameraController_C.__ComputeTargetPosition_FunctionParams* ptr = stackalloc BP_ZoneFollowCameraController_C.__ComputeTargetPosition_FunctionParams[(UIntPtr)511] + 15L / (long)sizeof(BP_ZoneFollowCameraController_C.__ComputeTargetPosition_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ZoneFollowCameraController_C.__ComputeTargetPosition_NativeFunctionPtr, (void*)ptr, 1);
			TArray<int> tarray = ZoneIndexs;
			if (tarray != null)
			{
				tarray.MoveTo(&ptr->ZoneIndexs);
			}
			ptr->RoleWorldPos = RoleWorldPos;
			ptr->OutPosition = OutPosition;
			ptr->OutRotation = OutRotation;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ZoneFollowCameraController_C.__ComputeTargetPosition_NativeFunctionPtr, (void*)ptr);
			TArray<int> tarray2 = ZoneIndexs;
			if (tarray2 != null)
			{
				tarray2.MoveAssign(&ptr->ZoneIndexs);
			}
			OutPosition = ptr->OutPosition;
			OutRotation = ptr->OutRotation;
			UnrealReflectionUtils.DestroyStruct(BP_ZoneFollowCameraController_C.__ComputeTargetPosition_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06027AD6 RID: 162518 RVA: 0x009F7D08 File Offset: 0x009F5F08
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void FindActiveZone(FVector WorldPos, ref TArray<int> ZoneIndexs, ref bool bFound)
		{
			BP_ZoneFollowCameraController_C.__FindActiveZone_FunctionParams* ptr = stackalloc BP_ZoneFollowCameraController_C.__FindActiveZone_FunctionParams[(UIntPtr)239] + 15L / (long)sizeof(BP_ZoneFollowCameraController_C.__FindActiveZone_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ZoneFollowCameraController_C.__FindActiveZone_NativeFunctionPtr, (void*)ptr, 1);
			ptr->WorldPos = WorldPos;
			TArray<int> tarray = ZoneIndexs;
			if (tarray != null)
			{
				tarray.MoveTo(&ptr->ZoneIndexs);
			}
			ptr->bFound = bFound;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ZoneFollowCameraController_C.__FindActiveZone_NativeFunctionPtr, (void*)ptr);
			TArray<int> tarray2 = ZoneIndexs;
			if (tarray2 != null)
			{
				tarray2.MoveAssign(&ptr->ZoneIndexs);
			}
			bFound = ptr->bFound;
			UnrealReflectionUtils.DestroyStruct(BP_ZoneFollowCameraController_C.__FindActiveZone_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06027AD7 RID: 162519 RVA: 0x009F7D9A File Offset: 0x009F5F9A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ZoneFollowCameraController_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06027AD8 RID: 162520 RVA: 0x009F7DAE File Offset: 0x009F5FAE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_ZoneFollowCameraController_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06027AD9 RID: 162521 RVA: 0x009F7DC3 File Offset: 0x009F5FC3
		protected BP_ZoneFollowCameraController_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04014CE9 RID: 85225
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Data/Gameplay/ZoneFollowCamera/BP_ZoneFollowCameraController.BP_ZoneFollowCameraController_C";

		// Token: 0x04014CEA RID: 85226
		private static IntPtr _ClassPtr;

		// Token: 0x04014CEB RID: 85227
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04014CEC RID: 85228
		internal static int __PropertyOffset_0;

		// Token: 0x04014CED RID: 85229
		internal static int __PropertyOffset_1;

		// Token: 0x04014CEE RID: 85230
		internal static int __PropertyOffset_2;

		// Token: 0x04014CEF RID: 85231
		internal static int __PropertyOffset_3;

		// Token: 0x04014CF0 RID: 85232
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<BP_ZoneFollowCameraZone_C> _区域配置;

		// Token: 0x04014CF1 RID: 85233
		internal static int __PropertyOffset_4;

		// Token: 0x04014CF2 RID: 85234
		internal static int __PropertyOffset_5;

		// Token: 0x04014CF3 RID: 85235
		internal static int __PropertyOffset_6;

		// Token: 0x04014CF4 RID: 85236
		internal static int __PropertyOffset_7;

		// Token: 0x04014CF5 RID: 85237
		internal static int __PropertyOffset_8;

		// Token: 0x04014CF6 RID: 85238
		internal static int __PropertyOffset_9;

		// Token: 0x04014CF7 RID: 85239
		internal static int __PropertyOffset_10;

		// Token: 0x04014CF8 RID: 85240
		private static IntPtr __PackageCameraConfig_NativeFunctionPtr;

		// Token: 0x04014CF9 RID: 85241
		private static IntPtr __ComputeTargetPosition_NativeFunctionPtr;

		// Token: 0x04014CFA RID: 85242
		private static IntPtr __FindActiveZone_NativeFunctionPtr;

		// Token: 0x04014CFB RID: 85243
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0200A0D9 RID: 41177
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 624)]
		protected ref struct __PackageCameraConfig_FunctionParams
		{
			// Token: 0x04032D8E RID: 208270
			[FieldOffset(0)]
			public byte Configs;
		}

		// Token: 0x0200A0DA RID: 41178
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 496)]
		protected ref struct __ComputeTargetPosition_FunctionParams
		{
			// Token: 0x04032D8F RID: 208271
			[FieldOffset(0)]
			public byte ZoneIndexs;

			// Token: 0x04032D90 RID: 208272
			[FieldOffset(16)]
			public FVector RoleWorldPos;

			// Token: 0x04032D91 RID: 208273
			[FieldOffset(28)]
			public FVector OutPosition;

			// Token: 0x04032D92 RID: 208274
			[FieldOffset(40)]
			public FRotator OutRotation;
		}

		// Token: 0x0200A0DB RID: 41179
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 224)]
		protected ref struct __FindActiveZone_FunctionParams
		{
			// Token: 0x04032D93 RID: 208275
			[FieldOffset(0)]
			public FVector WorldPos;

			// Token: 0x04032D94 RID: 208276
			[FieldOffset(16)]
			public byte ZoneIndexs;

			// Token: 0x04032D95 RID: 208277
			[FieldOffset(32)]
			public bool bFound;
		}
	}
}
