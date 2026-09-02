using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.GI.CloudLayer
{
	// Token: 0x02003CE7 RID: 15591
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/GI/CloudLayer/BP_CloudLayerComponent.BP_CloudLayerComponent_C")]
	[UnrealStructLayout(624, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 620)]
	public class BP_CloudLayerComponent_C : USceneComponent, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060252F1 RID: 152305 RVA: 0x009B2EBC File Offset: 0x009B10BC
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_CloudLayerComponent_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/GI/CloudLayer/BP_CloudLayerComponent.BP_CloudLayerComponent_C");
			}
			return BP_CloudLayerComponent_C._ClassPtr;
		}

		// Token: 0x060252F2 RID: 152306 RVA: 0x009B2EE0 File Offset: 0x009B10E0
		public BP_CloudLayerComponent_C() : this(BuiltinUtils.AllocNativeUObject(BP_CloudLayerComponent_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060252F3 RID: 152307 RVA: 0x009B2F08 File Offset: 0x009B1108
		[NullableContext(1)]
		public BP_CloudLayerComponent_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_CloudLayerComponent_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700500F RID: 20495
		// (get) Token: 0x060252F4 RID: 152308 RVA: 0x009B2F3B File Offset: 0x009B113B
		// (set) Token: 0x060252F5 RID: 152309 RVA: 0x009B2F4B File Offset: 0x009B114B
		public unsafe float CloudSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudLayerComponent_C.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudLayerComponent_C.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17005010 RID: 20496
		// (get) Token: 0x060252F6 RID: 152310 RVA: 0x009B2F5C File Offset: 0x009B115C
		// (set) Token: 0x060252F7 RID: 152311 RVA: 0x009B2F70 File Offset: 0x009B1170
		public unsafe FVector CloudPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudLayerComponent_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudLayerComponent_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17005011 RID: 20497
		// (get) Token: 0x060252F8 RID: 152312 RVA: 0x009B2F85 File Offset: 0x009B1185
		// (set) Token: 0x060252F9 RID: 152313 RVA: 0x009B2F95 File Offset: 0x009B1195
		public unsafe float CloudsTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudLayerComponent_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudLayerComponent_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17005012 RID: 20498
		// (get) Token: 0x060252FA RID: 152314 RVA: 0x009B2FA6 File Offset: 0x009B11A6
		// (set) Token: 0x060252FB RID: 152315 RVA: 0x009B2FB6 File Offset: 0x009B11B6
		public unsafe float CloudDir
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudLayerComponent_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudLayerComponent_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17005013 RID: 20499
		// (get) Token: 0x060252FC RID: 152316 RVA: 0x009B2FC7 File Offset: 0x009B11C7
		// (set) Token: 0x060252FD RID: 152317 RVA: 0x009B2FD7 File Offset: 0x009B11D7
		public unsafe float CloudPhase
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudLayerComponent_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudLayerComponent_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17005014 RID: 20500
		// (get) Token: 0x060252FE RID: 152318 RVA: 0x009B2FE8 File Offset: 0x009B11E8
		// (set) Token: 0x060252FF RID: 152319 RVA: 0x009B2FF8 File Offset: 0x009B11F8
		public unsafe float PrevCloudsTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudLayerComponent_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudLayerComponent_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17005015 RID: 20501
		// (get) Token: 0x06025300 RID: 152320 RVA: 0x009B3009 File Offset: 0x009B1209
		// (set) Token: 0x06025301 RID: 152321 RVA: 0x009B301D File Offset: 0x009B121D
		public unsafe FVector CloudsPhasePosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudLayerComponent_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudLayerComponent_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x06025302 RID: 152322 RVA: 0x009B3034 File Offset: 0x009B1234
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetCloudVelocity(ref FVector Ret)
		{
			BP_CloudLayerComponent_C.__GetCloudVelocity_FunctionParams* ptr = stackalloc BP_CloudLayerComponent_C.__GetCloudVelocity_FunctionParams[(UIntPtr)99] + 15L / (long)sizeof(BP_CloudLayerComponent_C.__GetCloudVelocity_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CloudLayerComponent_C.__GetCloudVelocity_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Ret = Ret;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CloudLayerComponent_C.__GetCloudVelocity_NativeFunctionPtr, (void*)ptr);
			Ret = ptr->Ret;
		}

		// Token: 0x06025303 RID: 152323 RVA: 0x009B308C File Offset: 0x009B128C
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Update_Cloud_Layer(UMaterialInstanceDynamic CloudMID, FVector SunLightDir, float TimeOfDay, BP_GlobalGI_C TODObj)
		{
			BP_CloudLayerComponent_C.__Update_Cloud_Layer_FunctionParams* ptr = stackalloc BP_CloudLayerComponent_C.__Update_Cloud_Layer_FunctionParams[(UIntPtr)311] + 15L / (long)sizeof(BP_CloudLayerComponent_C.__Update_Cloud_Layer_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CloudLayerComponent_C.__Update_Cloud_Layer_NativeFunctionPtr, (void*)ptr, 1);
			ptr->CloudMID = ((CloudMID != null) ? CloudMID.NativePtr : IntPtr.Zero);
			ptr->SunLightDir = SunLightDir;
			ptr->TimeOfDay = TimeOfDay;
			ptr->TODObj = ((TODObj != null) ? TODObj.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CloudLayerComponent_C.__Update_Cloud_Layer_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025304 RID: 152324 RVA: 0x009B310A File Offset: 0x009B130A
		protected BP_CloudLayerComponent_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401324C RID: 78412
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/GI/CloudLayer/BP_CloudLayerComponent.BP_CloudLayerComponent_C";

		// Token: 0x0401324D RID: 78413
		private static IntPtr _ClassPtr;

		// Token: 0x0401324E RID: 78414
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401324F RID: 78415
		internal static int __PropertyOffset_0;

		// Token: 0x04013250 RID: 78416
		internal static int __PropertyOffset_1;

		// Token: 0x04013251 RID: 78417
		internal static int __PropertyOffset_2;

		// Token: 0x04013252 RID: 78418
		internal static int __PropertyOffset_3;

		// Token: 0x04013253 RID: 78419
		internal static int __PropertyOffset_4;

		// Token: 0x04013254 RID: 78420
		internal static int __PropertyOffset_5;

		// Token: 0x04013255 RID: 78421
		internal static int __PropertyOffset_6;

		// Token: 0x04013256 RID: 78422
		private static IntPtr __GetCloudVelocity_NativeFunctionPtr;

		// Token: 0x04013257 RID: 78423
		private static IntPtr __Update_Cloud_Layer_NativeFunctionPtr;

		// Token: 0x02009EC1 RID: 40641
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 84)]
		protected ref struct __GetCloudVelocity_FunctionParams
		{
			// Token: 0x04032989 RID: 207241
			[FieldOffset(0)]
			public FVector Ret;
		}

		// Token: 0x02009EC2 RID: 40642
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 296)]
		protected ref struct __Update_Cloud_Layer_FunctionParams
		{
			// Token: 0x0403298A RID: 207242
			[FieldOffset(0)]
			public IntPtr CloudMID;

			// Token: 0x0403298B RID: 207243
			[FieldOffset(8)]
			public FVector SunLightDir;

			// Token: 0x0403298C RID: 207244
			[FieldOffset(20)]
			public float TimeOfDay;

			// Token: 0x0403298D RID: 207245
			[FieldOffset(24)]
			public IntPtr TODObj;
		}
	}
}
