using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Light
{
	// Token: 0x02003A93 RID: 14995
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Light/BP_SeqToonFallOffLight.BP_SeqToonFallOffLight_C")]
	[UnrealStructLayout(1664, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1657)]
	public class BP_SeqToonFallOffLight_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601F8F8 RID: 129272 RVA: 0x00914CF7 File Offset: 0x00912EF7
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SeqToonFallOffLight_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_SeqToonFallOffLight.BP_SeqToonFallOffLight_C");
			}
			return BP_SeqToonFallOffLight_C._ClassPtr;
		}

		// Token: 0x0601F8F9 RID: 129273 RVA: 0x00914D1C File Offset: 0x00912F1C
		public BP_SeqToonFallOffLight_C() : this(BuiltinUtils.AllocNativeUObject(BP_SeqToonFallOffLight_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601F8FA RID: 129274 RVA: 0x00914D44 File Offset: 0x00912F44
		[NullableContext(1)]
		public BP_SeqToonFallOffLight_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SeqToonFallOffLight_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170030A0 RID: 12448
		// (get) Token: 0x0601F8FB RID: 129275 RVA: 0x00914D78 File Offset: 0x00912F78
		// (set) Token: 0x0601F8FC RID: 129276 RVA: 0x00914DB1 File Offset: 0x00912FB1
		[Nullable(1)]
		public FPointerToUberGraphFrame UberGraphFrame
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_SeqToonFallOffLight_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_SeqToonFallOffLight_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170030A1 RID: 12449
		// (get) Token: 0x0601F8FD RID: 129277 RVA: 0x00914DD2 File Offset: 0x00912FD2
		// (set) Token: 0x0601F8FE RID: 129278 RVA: 0x00914DE6 File Offset: 0x00912FE6
		public unsafe UArrowComponent Arrow
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UArrowComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SeqToonFallOffLight_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SeqToonFallOffLight_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170030A2 RID: 12450
		// (get) Token: 0x0601F8FF RID: 129279 RVA: 0x00914DFB File Offset: 0x00912FFB
		// (set) Token: 0x0601F900 RID: 129280 RVA: 0x00914E0F File Offset: 0x0091300F
		public unsafe UBillboardComponent Billboard
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBillboardComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SeqToonFallOffLight_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SeqToonFallOffLight_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170030A3 RID: 12451
		// (get) Token: 0x0601F901 RID: 129281 RVA: 0x00914E24 File Offset: 0x00913024
		// (set) Token: 0x0601F902 RID: 129282 RVA: 0x00914E38 File Offset: 0x00913038
		public unsafe USphereComponent Sphere
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USphereComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SeqToonFallOffLight_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SeqToonFallOffLight_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x170030A4 RID: 12452
		// (get) Token: 0x0601F903 RID: 129283 RVA: 0x00914E4D File Offset: 0x0091304D
		// (set) Token: 0x0601F904 RID: 129284 RVA: 0x00914E61 File Offset: 0x00913061
		public unsafe UKuroPostProcessComponent KuroPostProcess
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroPostProcessComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SeqToonFallOffLight_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SeqToonFallOffLight_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x170030A5 RID: 12453
		// (get) Token: 0x0601F905 RID: 129285 RVA: 0x00914E76 File Offset: 0x00913076
		// (set) Token: 0x0601F906 RID: 129286 RVA: 0x00914E8A File Offset: 0x0091308A
		public unsafe UMaterialInterface MainMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInterface>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SeqToonFallOffLight_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SeqToonFallOffLight_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x170030A6 RID: 12454
		// (get) Token: 0x0601F907 RID: 129287 RVA: 0x00914E9F File Offset: 0x0091309F
		// (set) Token: 0x0601F908 RID: 129288 RVA: 0x00914EB3 File Offset: 0x009130B3
		public unsafe FLinearColor LightColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SeqToonFallOffLight_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SeqToonFallOffLight_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x170030A7 RID: 12455
		// (get) Token: 0x0601F909 RID: 129289 RVA: 0x00914EC8 File Offset: 0x009130C8
		// (set) Token: 0x0601F90A RID: 129290 RVA: 0x00914EDC File Offset: 0x009130DC
		public unsafe FLinearColor LightFallOffColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SeqToonFallOffLight_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SeqToonFallOffLight_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x170030A8 RID: 12456
		// (get) Token: 0x0601F90B RID: 129291 RVA: 0x00914EF1 File Offset: 0x009130F1
		// (set) Token: 0x0601F90C RID: 129292 RVA: 0x00914F01 File Offset: 0x00913101
		public unsafe float LightIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SeqToonFallOffLight_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SeqToonFallOffLight_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x170030A9 RID: 12457
		// (get) Token: 0x0601F90D RID: 129293 RVA: 0x00914F12 File Offset: 0x00913112
		// (set) Token: 0x0601F90E RID: 129294 RVA: 0x00914F22 File Offset: 0x00913122
		public unsafe float InnerRadius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SeqToonFallOffLight_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SeqToonFallOffLight_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x170030AA RID: 12458
		// (get) Token: 0x0601F90F RID: 129295 RVA: 0x00914F33 File Offset: 0x00913133
		// (set) Token: 0x0601F910 RID: 129296 RVA: 0x00914F47 File Offset: 0x00913147
		public unsafe UMaterialInstanceDynamic DynamicMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SeqToonFallOffLight_C.__PropertyOffset_10);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SeqToonFallOffLight_C.__PropertyOffset_10, value);
			}
		}

		// Token: 0x170030AB RID: 12459
		// (get) Token: 0x0601F911 RID: 129297 RVA: 0x00914F5C File Offset: 0x0091315C
		// (set) Token: 0x0601F912 RID: 129298 RVA: 0x00914F95 File Offset: 0x00913195
		[Nullable(1)]
		public TMap<FName, float> Scalar_Parameters
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TMap<FName, float> result;
				if ((result = this._Scalar_Parameters) == null)
				{
					result = (this._Scalar_Parameters = new TMap<FName, float>(base.NativePtr + (IntPtr)BP_SeqToonFallOffLight_C.__PropertyOffset_11, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Scalar_Parameters.CopyAssign(value);
			}
		}

		// Token: 0x170030AC RID: 12460
		// (get) Token: 0x0601F913 RID: 129299 RVA: 0x00914FA4 File Offset: 0x009131A4
		// (set) Token: 0x0601F914 RID: 129300 RVA: 0x00914FDD File Offset: 0x009131DD
		[Nullable(1)]
		public TMap<FName, FLinearColor> Vector_Parameters
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TMap<FName, FLinearColor> result;
				if ((result = this._Vector_Parameters) == null)
				{
					result = (this._Vector_Parameters = new TMap<FName, FLinearColor>(base.NativePtr + (IntPtr)BP_SeqToonFallOffLight_C.__PropertyOffset_12, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Vector_Parameters.CopyAssign(value);
			}
		}

		// Token: 0x170030AD RID: 12461
		// (get) Token: 0x0601F915 RID: 129301 RVA: 0x00914FEC File Offset: 0x009131EC
		// (set) Token: 0x0601F916 RID: 129302 RVA: 0x00915025 File Offset: 0x00913225
		[Nullable(1)]
		public TMap<FName, UTexture> Texture_Parameters
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TMap<FName, UTexture> result;
				if ((result = this._Texture_Parameters) == null)
				{
					result = (this._Texture_Parameters = new TMap<FName, UTexture>(base.NativePtr + (IntPtr)BP_SeqToonFallOffLight_C.__PropertyOffset_13, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Texture_Parameters.CopyAssign(value);
			}
		}

		// Token: 0x170030AE RID: 12462
		// (get) Token: 0x0601F917 RID: 129303 RVA: 0x00915033 File Offset: 0x00913233
		// (set) Token: 0x0601F918 RID: 129304 RVA: 0x00915043 File Offset: 0x00913243
		public unsafe float InnerWidth
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SeqToonFallOffLight_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SeqToonFallOffLight_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x170030AF RID: 12463
		// (get) Token: 0x0601F919 RID: 129305 RVA: 0x00915054 File Offset: 0x00913254
		// (set) Token: 0x0601F91A RID: 129306 RVA: 0x00915064 File Offset: 0x00913264
		public unsafe float OutterRadius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SeqToonFallOffLight_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SeqToonFallOffLight_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x170030B0 RID: 12464
		// (get) Token: 0x0601F91B RID: 129307 RVA: 0x00915075 File Offset: 0x00913275
		// (set) Token: 0x0601F91C RID: 129308 RVA: 0x00915085 File Offset: 0x00913285
		public unsafe bool UseCubeMask
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SeqToonFallOffLight_C.__PropertyOffset_16) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SeqToonFallOffLight_C.__PropertyOffset_16) = (value ? 1 : 0);
			}
		}

		// Token: 0x0601F91D RID: 129309 RVA: 0x00915096 File Offset: 0x00913296
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Update()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SeqToonFallOffLight_C.__Update_NativeFunctionPtr, null);
		}

		// Token: 0x0601F91E RID: 129310 RVA: 0x009150AA File Offset: 0x009132AA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateEditor()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SeqToonFallOffLight_C.__UpdateEditor_NativeFunctionPtr, null);
		}

		// Token: 0x0601F91F RID: 129311 RVA: 0x009150BE File Offset: 0x009132BE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SeqToonFallOffLight_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0601F920 RID: 129312 RVA: 0x009150D2 File Offset: 0x009132D2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SeqToonFallOffLight_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601F921 RID: 129313 RVA: 0x009150E7 File Offset: 0x009132E7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SeqToonFallOffLight_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0601F922 RID: 129314 RVA: 0x009150FB File Offset: 0x009132FB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SeqToonFallOffLight_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601F923 RID: 129315 RVA: 0x00915110 File Offset: 0x00913310
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_SeqToonFallOffLight_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_SeqToonFallOffLight_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SeqToonFallOffLight_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SeqToonFallOffLight_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SeqToonFallOffLight_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F924 RID: 129316 RVA: 0x00915158 File Offset: 0x00913358
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_SeqToonFallOffLight_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_SeqToonFallOffLight_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SeqToonFallOffLight_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SeqToonFallOffLight_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SeqToonFallOffLight_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F925 RID: 129317 RVA: 0x0091519F File Offset: 0x0091339F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveDestroyed()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SeqToonFallOffLight_C.__ReceiveDestroyed_NativeFunctionPtr, null);
		}

		// Token: 0x0601F926 RID: 129318 RVA: 0x009151B3 File Offset: 0x009133B3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveDestroyed_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SeqToonFallOffLight_C.__ReceiveDestroyed_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601F927 RID: 129319 RVA: 0x009151C8 File Offset: 0x009133C8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_SeqToonFallOffLight_C.__EditorTick_FunctionParams* ptr = stackalloc BP_SeqToonFallOffLight_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SeqToonFallOffLight_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SeqToonFallOffLight_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SeqToonFallOffLight_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F928 RID: 129320 RVA: 0x00915210 File Offset: 0x00913410
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_SeqToonFallOffLight_C.__EditorTick_FunctionParams* ptr = stackalloc BP_SeqToonFallOffLight_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SeqToonFallOffLight_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SeqToonFallOffLight_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SeqToonFallOffLight_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F929 RID: 129321 RVA: 0x00915257 File Offset: 0x00913457
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void EditorInit()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SeqToonFallOffLight_C.__EditorInit_NativeFunctionPtr, null);
		}

		// Token: 0x0601F92A RID: 129322 RVA: 0x0091526B File Offset: 0x0091346B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void EditorInit_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SeqToonFallOffLight_C.__EditorInit_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601F92B RID: 129323 RVA: 0x00915280 File Offset: 0x00913480
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_SeqToonFallOffLight(int EntryPoint)
		{
			BP_SeqToonFallOffLight_C.__ExecuteUbergraph_BP_SeqToonFallOffLight_FunctionParams* ptr = stackalloc BP_SeqToonFallOffLight_C.__ExecuteUbergraph_BP_SeqToonFallOffLight_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_SeqToonFallOffLight_C.__ExecuteUbergraph_BP_SeqToonFallOffLight_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SeqToonFallOffLight_C.__ExecuteUbergraph_BP_SeqToonFallOffLight_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SeqToonFallOffLight_C.__ExecuteUbergraph_BP_SeqToonFallOffLight_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F92C RID: 129324 RVA: 0x009152C7 File Offset: 0x009134C7
		protected BP_SeqToonFallOffLight_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400FAF9 RID: 64249
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_SeqToonFallOffLight.BP_SeqToonFallOffLight_C";

		// Token: 0x0400FAFA RID: 64250
		private static IntPtr _ClassPtr;

		// Token: 0x0400FAFB RID: 64251
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400FAFC RID: 64252
		internal static int __PropertyOffset_0;

		// Token: 0x0400FAFD RID: 64253
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400FAFE RID: 64254
		internal static int __PropertyOffset_1;

		// Token: 0x0400FAFF RID: 64255
		internal static int __PropertyOffset_2;

		// Token: 0x0400FB00 RID: 64256
		internal static int __PropertyOffset_3;

		// Token: 0x0400FB01 RID: 64257
		internal static int __PropertyOffset_4;

		// Token: 0x0400FB02 RID: 64258
		internal static int __PropertyOffset_5;

		// Token: 0x0400FB03 RID: 64259
		internal static int __PropertyOffset_6;

		// Token: 0x0400FB04 RID: 64260
		internal static int __PropertyOffset_7;

		// Token: 0x0400FB05 RID: 64261
		internal static int __PropertyOffset_8;

		// Token: 0x0400FB06 RID: 64262
		internal static int __PropertyOffset_9;

		// Token: 0x0400FB07 RID: 64263
		internal static int __PropertyOffset_10;

		// Token: 0x0400FB08 RID: 64264
		internal static int __PropertyOffset_11;

		// Token: 0x0400FB09 RID: 64265
		private TMap<FName, float> _Scalar_Parameters;

		// Token: 0x0400FB0A RID: 64266
		internal static int __PropertyOffset_12;

		// Token: 0x0400FB0B RID: 64267
		private TMap<FName, FLinearColor> _Vector_Parameters;

		// Token: 0x0400FB0C RID: 64268
		internal static int __PropertyOffset_13;

		// Token: 0x0400FB0D RID: 64269
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<FName, UTexture> _Texture_Parameters;

		// Token: 0x0400FB0E RID: 64270
		internal static int __PropertyOffset_14;

		// Token: 0x0400FB0F RID: 64271
		internal static int __PropertyOffset_15;

		// Token: 0x0400FB10 RID: 64272
		internal static int __PropertyOffset_16;

		// Token: 0x0400FB11 RID: 64273
		private static IntPtr __Update_NativeFunctionPtr;

		// Token: 0x0400FB12 RID: 64274
		private static IntPtr __UpdateEditor_NativeFunctionPtr;

		// Token: 0x0400FB13 RID: 64275
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0400FB14 RID: 64276
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400FB15 RID: 64277
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400FB16 RID: 64278
		private static IntPtr __ReceiveDestroyed_NativeFunctionPtr;

		// Token: 0x0400FB17 RID: 64279
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x0400FB18 RID: 64280
		private static IntPtr __EditorInit_NativeFunctionPtr;

		// Token: 0x0400FB19 RID: 64281
		private static IntPtr __ExecuteUbergraph_BP_SeqToonFallOffLight_NativeFunctionPtr;

		// Token: 0x020098FC RID: 39164
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031F5B RID: 204635
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x020098FD RID: 39165
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04031F5C RID: 204636
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x020098FE RID: 39166
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __ExecuteUbergraph_BP_SeqToonFallOffLight_FunctionParams
		{
			// Token: 0x04031F5D RID: 204637
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
