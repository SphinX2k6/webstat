using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Render.RuntimeBP.FluidNinjaLive;
using AkiClient.Game.Aki.Render.RuntimeBP.FluidNinjaLive.Volumetrics;
using AkiClient.Game.Aki.Render.RuntimeBP.GI;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.RadialSnow
{
	// Token: 0x02003BA0 RID: 15264
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/RadialSnow/BP_NinjaRadialSnow.BP_NinjaRadialSnow_C")]
	[UnrealStructLayout(2128, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2124)]
	public class BP_NinjaRadialSnow_C : NinjaLive_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06021E79 RID: 138873 RVA: 0x00956DC0 File Offset: 0x00954FC0
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_NinjaRadialSnow_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/RadialSnow/BP_NinjaRadialSnow.BP_NinjaRadialSnow_C");
			}
			return BP_NinjaRadialSnow_C._ClassPtr;
		}

		// Token: 0x06021E7A RID: 138874 RVA: 0x00956DE4 File Offset: 0x00954FE4
		public BP_NinjaRadialSnow_C() : this(BuiltinUtils.AllocNativeUObject(BP_NinjaRadialSnow_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06021E7B RID: 138875 RVA: 0x00956E0C File Offset: 0x0095500C
		[NullableContext(1)]
		public BP_NinjaRadialSnow_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_NinjaRadialSnow_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003DA5 RID: 15781
		// (get) Token: 0x06021E7C RID: 138876 RVA: 0x00956E40 File Offset: 0x00955040
		// (set) Token: 0x06021E7D RID: 138877 RVA: 0x00956E79 File Offset: 0x00955079
		[Nullable(1)]
		public new FPointerToUberGraphFrame UberGraphFrame
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_NinjaRadialSnow_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_NinjaRadialSnow_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003DA6 RID: 15782
		// (get) Token: 0x06021E7E RID: 138878 RVA: 0x00956E9A File Offset: 0x0095509A
		// (set) Token: 0x06021E7F RID: 138879 RVA: 0x00956EAE File Offset: 0x009550AE
		public unsafe UStaticMeshComponent DepthSlicer
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_NinjaRadialSnow_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_NinjaRadialSnow_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003DA7 RID: 15783
		// (get) Token: 0x06021E80 RID: 138880 RVA: 0x00956EC3 File Offset: 0x009550C3
		// (set) Token: 0x06021E81 RID: 138881 RVA: 0x00956ED7 File Offset: 0x009550D7
		public unsafe VolumeSmokeComponent_C VolumeSmokeComponent
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<VolumeSmokeComponent_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_NinjaRadialSnow_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_NinjaRadialSnow_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17003DA8 RID: 15784
		// (get) Token: 0x06021E82 RID: 138882 RVA: 0x00956EEC File Offset: 0x009550EC
		// (set) Token: 0x06021E83 RID: 138883 RVA: 0x00956EFC File Offset: 0x009550FC
		public unsafe bool OnMeltPlay
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_NinjaRadialSnow_C.__PropertyOffset_3) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_NinjaRadialSnow_C.__PropertyOffset_3) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003DA9 RID: 15785
		// (get) Token: 0x06021E84 RID: 138884 RVA: 0x00956F0D File Offset: 0x0095510D
		// (set) Token: 0x06021E85 RID: 138885 RVA: 0x00956F1D File Offset: 0x0095511D
		public unsafe bool bMoto
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_NinjaRadialSnow_C.__PropertyOffset_4) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_NinjaRadialSnow_C.__PropertyOffset_4) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003DAA RID: 15786
		// (get) Token: 0x06021E86 RID: 138886 RVA: 0x00956F2E File Offset: 0x0095512E
		// (set) Token: 0x06021E87 RID: 138887 RVA: 0x00956F3E File Offset: 0x0095513E
		public unsafe float OriginKuroTrailEnable
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_NinjaRadialSnow_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_NinjaRadialSnow_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17003DAB RID: 15787
		// (get) Token: 0x06021E88 RID: 138888 RVA: 0x00956F4F File Offset: 0x0095514F
		// (set) Token: 0x06021E89 RID: 138889 RVA: 0x00956F5F File Offset: 0x0095515F
		public unsafe float CharacterVeloMotion
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_NinjaRadialSnow_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_NinjaRadialSnow_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17003DAC RID: 15788
		// (get) Token: 0x06021E8A RID: 138890 RVA: 0x00956F70 File Offset: 0x00955170
		// (set) Token: 0x06021E8B RID: 138891 RVA: 0x00956F80 File Offset: 0x00955180
		public unsafe float CharacterGlobalBrush
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_NinjaRadialSnow_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_NinjaRadialSnow_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17003DAD RID: 15789
		// (get) Token: 0x06021E8C RID: 138892 RVA: 0x00956F91 File Offset: 0x00955191
		// (set) Token: 0x06021E8D RID: 138893 RVA: 0x00956FA5 File Offset: 0x009551A5
		public unsafe BP_GlobalGI_C GlobalGI
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_GlobalGI_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_NinjaRadialSnow_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_NinjaRadialSnow_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x17003DAE RID: 15790
		// (get) Token: 0x06021E8E RID: 138894 RVA: 0x00956FBA File Offset: 0x009551BA
		// (set) Token: 0x06021E8F RID: 138895 RVA: 0x00956FCA File Offset: 0x009551CA
		public unsafe bool bIsVisible
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_NinjaRadialSnow_C.__PropertyOffset_9) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_NinjaRadialSnow_C.__PropertyOffset_9) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003DAF RID: 15791
		// (get) Token: 0x06021E90 RID: 138896 RVA: 0x00956FDC File Offset: 0x009551DC
		// (set) Token: 0x06021E91 RID: 138897 RVA: 0x00957015 File Offset: 0x00955215
		[Nullable(1)]
		public TSet<string> physicMaterialSet
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TSet<string> result;
				if ((result = this._physicMaterialSet) == null)
				{
					result = (this._physicMaterialSet = new TSet<string>(base.NativePtr + (IntPtr)BP_NinjaRadialSnow_C.__PropertyOffset_10, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.physicMaterialSet.CopyAssign(value);
			}
		}

		// Token: 0x17003DB0 RID: 15792
		// (get) Token: 0x06021E92 RID: 138898 RVA: 0x00957023 File Offset: 0x00955223
		// (set) Token: 0x06021E93 RID: 138899 RVA: 0x00957037 File Offset: 0x00955237
		public unsafe UMaterialInterface VolumeSmokeMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInterface>(base.NativePtr / (IntPtr)sizeof(void*) + BP_NinjaRadialSnow_C.__PropertyOffset_11);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_NinjaRadialSnow_C.__PropertyOffset_11, value);
			}
		}

		// Token: 0x17003DB1 RID: 15793
		// (get) Token: 0x06021E94 RID: 138900 RVA: 0x0095704C File Offset: 0x0095524C
		// (set) Token: 0x06021E95 RID: 138901 RVA: 0x0095705C File Offset: 0x0095525C
		public unsafe float BrushStrength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_NinjaRadialSnow_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_NinjaRadialSnow_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17003DB2 RID: 15794
		// (get) Token: 0x06021E96 RID: 138902 RVA: 0x0095706D File Offset: 0x0095526D
		// (set) Token: 0x06021E97 RID: 138903 RVA: 0x0095707D File Offset: 0x0095527D
		public unsafe float BrushScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_NinjaRadialSnow_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_NinjaRadialSnow_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17003DB3 RID: 15795
		// (get) Token: 0x06021E98 RID: 138904 RVA: 0x0095708E File Offset: 0x0095528E
		// (set) Token: 0x06021E99 RID: 138905 RVA: 0x009570A2 File Offset: 0x009552A2
		public unsafe FVectorDouble ValidBoxLocation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_NinjaRadialSnow_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_NinjaRadialSnow_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17003DB4 RID: 15796
		// (get) Token: 0x06021E9A RID: 138906 RVA: 0x009570B7 File Offset: 0x009552B7
		// (set) Token: 0x06021E9B RID: 138907 RVA: 0x009570CB File Offset: 0x009552CB
		public unsafe UTextureRenderTarget2D VolumeSmokeInputRT
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_NinjaRadialSnow_C.__PropertyOffset_15);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_NinjaRadialSnow_C.__PropertyOffset_15, value);
			}
		}

		// Token: 0x17003DB5 RID: 15797
		// (get) Token: 0x06021E9C RID: 138908 RVA: 0x009570E0 File Offset: 0x009552E0
		// (set) Token: 0x06021E9D RID: 138909 RVA: 0x009570F0 File Offset: 0x009552F0
		public unsafe int CachedQuality
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_NinjaRadialSnow_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_NinjaRadialSnow_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x06021E9E RID: 138910 RVA: 0x00957104 File Offset: 0x00955304
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void CheckQuality(ref bool IsValid)
		{
			BP_NinjaRadialSnow_C.__CheckQuality_FunctionParams* ptr = stackalloc BP_NinjaRadialSnow_C.__CheckQuality_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(BP_NinjaRadialSnow_C.__CheckQuality_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_NinjaRadialSnow_C.__CheckQuality_NativeFunctionPtr, (void*)ptr, 1);
			ptr->IsValid = IsValid;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_NinjaRadialSnow_C.__CheckQuality_NativeFunctionPtr, (void*)ptr);
			IsValid = ptr->IsValid;
		}

		// Token: 0x06021E9F RID: 138911 RVA: 0x00957153 File Offset: 0x00955353
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_NinjaRadialSnow_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06021EA0 RID: 138912 RVA: 0x00957167 File Offset: 0x00955367
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_NinjaRadialSnow_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06021EA1 RID: 138913 RVA: 0x0095717C File Offset: 0x0095537C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveEndPlay(EEndPlayReason EndPlayReason)
		{
			BP_NinjaRadialSnow_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_NinjaRadialSnow_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_NinjaRadialSnow_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_NinjaRadialSnow_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_NinjaRadialSnow_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021EA2 RID: 138914 RVA: 0x009571C8 File Offset: 0x009553C8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveEndPlay_Implementation(EEndPlayReason EndPlayReason)
		{
			BP_NinjaRadialSnow_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_NinjaRadialSnow_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_NinjaRadialSnow_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_NinjaRadialSnow_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_NinjaRadialSnow_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021EA3 RID: 138915 RVA: 0x00957214 File Offset: 0x00955414
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_NinjaRadialSnow_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_NinjaRadialSnow_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_NinjaRadialSnow_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_NinjaRadialSnow_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_NinjaRadialSnow_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021EA4 RID: 138916 RVA: 0x0095725C File Offset: 0x0095545C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_NinjaRadialSnow_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_NinjaRadialSnow_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_NinjaRadialSnow_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_NinjaRadialSnow_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_NinjaRadialSnow_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021EA5 RID: 138917 RVA: 0x009572A3 File Offset: 0x009554A3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_NinjaRadialSnow_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06021EA6 RID: 138918 RVA: 0x009572B7 File Offset: 0x009554B7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_NinjaRadialSnow_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06021EA7 RID: 138919 RVA: 0x009572CC File Offset: 0x009554CC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_NinjaRadialSnow(int EntryPoint)
		{
			BP_NinjaRadialSnow_C.__ExecuteUbergraph_BP_NinjaRadialSnow_FunctionParams* ptr = stackalloc BP_NinjaRadialSnow_C.__ExecuteUbergraph_BP_NinjaRadialSnow_FunctionParams[(UIntPtr)103] + 15L / (long)sizeof(BP_NinjaRadialSnow_C.__ExecuteUbergraph_BP_NinjaRadialSnow_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_NinjaRadialSnow_C.__ExecuteUbergraph_BP_NinjaRadialSnow_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_NinjaRadialSnow_C.__ExecuteUbergraph_BP_NinjaRadialSnow_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021EA8 RID: 138920 RVA: 0x00957313 File Offset: 0x00955513
		protected BP_NinjaRadialSnow_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040111E1 RID: 70113
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/RadialSnow/BP_NinjaRadialSnow.BP_NinjaRadialSnow_C";

		// Token: 0x040111E2 RID: 70114
		private static IntPtr _ClassPtr;

		// Token: 0x040111E3 RID: 70115
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040111E4 RID: 70116
		internal new static int __PropertyOffset_0;

		// Token: 0x040111E5 RID: 70117
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040111E6 RID: 70118
		internal new static int __PropertyOffset_1;

		// Token: 0x040111E7 RID: 70119
		internal new static int __PropertyOffset_2;

		// Token: 0x040111E8 RID: 70120
		internal new static int __PropertyOffset_3;

		// Token: 0x040111E9 RID: 70121
		internal new static int __PropertyOffset_4;

		// Token: 0x040111EA RID: 70122
		internal new static int __PropertyOffset_5;

		// Token: 0x040111EB RID: 70123
		internal new static int __PropertyOffset_6;

		// Token: 0x040111EC RID: 70124
		internal new static int __PropertyOffset_7;

		// Token: 0x040111ED RID: 70125
		internal new static int __PropertyOffset_8;

		// Token: 0x040111EE RID: 70126
		internal new static int __PropertyOffset_9;

		// Token: 0x040111EF RID: 70127
		internal new static int __PropertyOffset_10;

		// Token: 0x040111F0 RID: 70128
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TSet<string> _physicMaterialSet;

		// Token: 0x040111F1 RID: 70129
		internal new static int __PropertyOffset_11;

		// Token: 0x040111F2 RID: 70130
		internal new static int __PropertyOffset_12;

		// Token: 0x040111F3 RID: 70131
		internal new static int __PropertyOffset_13;

		// Token: 0x040111F4 RID: 70132
		internal new static int __PropertyOffset_14;

		// Token: 0x040111F5 RID: 70133
		internal new static int __PropertyOffset_15;

		// Token: 0x040111F6 RID: 70134
		internal new static int __PropertyOffset_16;

		// Token: 0x040111F7 RID: 70135
		private static IntPtr __CheckQuality_NativeFunctionPtr;

		// Token: 0x040111F8 RID: 70136
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x040111F9 RID: 70137
		private static IntPtr __ReceiveEndPlay_NativeFunctionPtr;

		// Token: 0x040111FA RID: 70138
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x040111FB RID: 70139
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x040111FC RID: 70140
		private static IntPtr __ExecuteUbergraph_BP_NinjaRadialSnow_NativeFunctionPtr;

		// Token: 0x02009B6E RID: 39790
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __CheckQuality_FunctionParams
		{
			// Token: 0x04032361 RID: 205665
			[FieldOffset(0)]
			public bool IsValid;
		}

		// Token: 0x02009B6F RID: 39791
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __ReceiveEndPlay_FunctionParams
		{
			// Token: 0x04032362 RID: 205666
			[FieldOffset(0)]
			public TEnumAsByte<EEndPlayReason> EndPlayReason;
		}

		// Token: 0x02009B70 RID: 39792
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032363 RID: 205667
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009B71 RID: 39793
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 88)]
		protected ref struct __ExecuteUbergraph_BP_NinjaRadialSnow_FunctionParams
		{
			// Token: 0x04032364 RID: 205668
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
