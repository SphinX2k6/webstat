using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Core.Fight;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.SimpleShatter
{
	// Token: 0x02003B74 RID: 15220
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/SimpleShatter/BP_shatter.BP_shatter_C")]
	[UnrealStructLayout(1712, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1705)]
	public class BP_shatter_C : ASimpleShatterActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06021856 RID: 137302 RVA: 0x0094B94F File Offset: 0x00949B4F
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_shatter_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/SimpleShatter/BP_shatter.BP_shatter_C");
			}
			return BP_shatter_C._ClassPtr;
		}

		// Token: 0x06021857 RID: 137303 RVA: 0x0094B974 File Offset: 0x00949B74
		public BP_shatter_C() : this(BuiltinUtils.AllocNativeUObject(BP_shatter_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06021858 RID: 137304 RVA: 0x0094B99C File Offset: 0x00949B9C
		public BP_shatter_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_shatter_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003B97 RID: 15255
		// (get) Token: 0x06021859 RID: 137305 RVA: 0x0094B9D0 File Offset: 0x00949BD0
		// (set) Token: 0x0602185A RID: 137306 RVA: 0x0094BA09 File Offset: 0x00949C09
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_shatter_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_shatter_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003B98 RID: 15256
		// (get) Token: 0x0602185B RID: 137307 RVA: 0x0094BA2A File Offset: 0x00949C2A
		// (set) Token: 0x0602185C RID: 137308 RVA: 0x0094BA3E File Offset: 0x00949C3E
		[Nullable(2)]
		public unsafe UStaticMeshComponent Cube
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_shatter_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_shatter_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003B99 RID: 15257
		// (get) Token: 0x0602185D RID: 137309 RVA: 0x0094BA53 File Offset: 0x00949C53
		// (set) Token: 0x0602185E RID: 137310 RVA: 0x0094BA67 File Offset: 0x00949C67
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_shatter_C.__PropertyOffset_2);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_shatter_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17003B9A RID: 15258
		// (get) Token: 0x0602185F RID: 137311 RVA: 0x0094BA7C File Offset: 0x00949C7C
		// (set) Token: 0x06021860 RID: 137312 RVA: 0x0094BA8C File Offset: 0x00949C8C
		public unsafe bool bEditorTick
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_shatter_C.__PropertyOffset_3) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_shatter_C.__PropertyOffset_3) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003B9B RID: 15259
		// (get) Token: 0x06021861 RID: 137313 RVA: 0x0094BA9D File Offset: 0x00949C9D
		// (set) Token: 0x06021862 RID: 137314 RVA: 0x0094BAB1 File Offset: 0x00949CB1
		[Nullable(2)]
		public unsafe UChildActorComponent editorTicker
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_shatter_C.__PropertyOffset_4);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_shatter_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17003B9C RID: 15260
		// (get) Token: 0x06021863 RID: 137315 RVA: 0x0094BAC6 File Offset: 0x00949CC6
		// (set) Token: 0x06021864 RID: 137316 RVA: 0x0094BADA File Offset: 0x00949CDA
		public unsafe FVector WeaponPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_shatter_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_shatter_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17003B9D RID: 15261
		// (get) Token: 0x06021865 RID: 137317 RVA: 0x0094BAEF File Offset: 0x00949CEF
		// (set) Token: 0x06021866 RID: 137318 RVA: 0x0094BB03 File Offset: 0x00949D03
		public unsafe FVector LastWeaponPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_shatter_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_shatter_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17003B9E RID: 15262
		// (get) Token: 0x06021867 RID: 137319 RVA: 0x0094BB18 File Offset: 0x00949D18
		// (set) Token: 0x06021868 RID: 137320 RVA: 0x0094BB28 File Offset: 0x00949D28
		public unsafe int SelectInt
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_shatter_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_shatter_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17003B9F RID: 15263
		// (get) Token: 0x06021869 RID: 137321 RVA: 0x0094BB39 File Offset: 0x00949D39
		// (set) Token: 0x0602186A RID: 137322 RVA: 0x0094BB4D File Offset: 0x00949D4D
		[Nullable(2)]
		public unsafe PD_BakedShatterToDA_C inputDA
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<PD_BakedShatterToDA_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_shatter_C.__PropertyOffset_8);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_shatter_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x17003BA0 RID: 15264
		// (get) Token: 0x0602186B RID: 137323 RVA: 0x0094BB64 File Offset: 0x00949D64
		// (set) Token: 0x0602186C RID: 137324 RVA: 0x0094BB9D File Offset: 0x00949D9D
		public TArray<FTransform> SMCompoentLocalTransformArr
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FTransform> result;
				if ((result = this._SMCompoentLocalTransformArr) == null)
				{
					result = (this._SMCompoentLocalTransformArr = new TArray<FTransform>(base.NativePtr + (IntPtr)BP_shatter_C.__PropertyOffset_9, this));
				}
				return result;
			}
			set
			{
				this.SMCompoentLocalTransformArr.CopyAssign(value);
			}
		}

		// Token: 0x17003BA1 RID: 15265
		// (get) Token: 0x0602186D RID: 137325 RVA: 0x0094BBAC File Offset: 0x00949DAC
		// (set) Token: 0x0602186E RID: 137326 RVA: 0x0094BBE5 File Offset: 0x00949DE5
		public TArray<AStaticMeshActor> SMActorArr
		{
			get
			{
				base.FastCheckIsValid();
				TArray<AStaticMeshActor> result;
				if ((result = this._SMActorArr) == null)
				{
					result = (this._SMActorArr = new TArray<AStaticMeshActor>(base.NativePtr + (IntPtr)BP_shatter_C.__PropertyOffset_10, this));
				}
				return result;
			}
			set
			{
				this.SMActorArr.CopyAssign(value);
			}
		}

		// Token: 0x17003BA2 RID: 15266
		// (get) Token: 0x0602186F RID: 137327 RVA: 0x0094BBF4 File Offset: 0x00949DF4
		// (set) Token: 0x06021870 RID: 137328 RVA: 0x0094BC2D File Offset: 0x00949E2D
		public TArray<UStaticMeshComponent> SMComponentArr
		{
			get
			{
				base.FastCheckIsValid();
				TArray<UStaticMeshComponent> result;
				if ((result = this._SMComponentArr) == null)
				{
					result = (this._SMComponentArr = new TArray<UStaticMeshComponent>(base.NativePtr + (IntPtr)BP_shatter_C.__PropertyOffset_11, this));
				}
				return result;
			}
			set
			{
				this.SMComponentArr.CopyAssign(value);
			}
		}

		// Token: 0x17003BA3 RID: 15267
		// (get) Token: 0x06021871 RID: 137329 RVA: 0x0094BC3C File Offset: 0x00949E3C
		// (set) Token: 0x06021872 RID: 137330 RVA: 0x0094BC75 File Offset: 0x00949E75
		public TArray<UStaticMesh> SMArr
		{
			get
			{
				base.FastCheckIsValid();
				TArray<UStaticMesh> result;
				if ((result = this._SMArr) == null)
				{
					result = (this._SMArr = new TArray<UStaticMesh>(base.NativePtr + (IntPtr)BP_shatter_C.__PropertyOffset_12, this));
				}
				return result;
			}
			set
			{
				this.SMArr.CopyAssign(value);
			}
		}

		// Token: 0x17003BA4 RID: 15268
		// (get) Token: 0x06021873 RID: 137331 RVA: 0x0094BC83 File Offset: 0x00949E83
		// (set) Token: 0x06021874 RID: 137332 RVA: 0x0094BC93 File Offset: 0x00949E93
		public unsafe bool finishBuild_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_shatter_C.__PropertyOffset_13) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_shatter_C.__PropertyOffset_13) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003BA5 RID: 15269
		// (get) Token: 0x06021875 RID: 137333 RVA: 0x0094BCA4 File Offset: 0x00949EA4
		// (set) Token: 0x06021876 RID: 137334 RVA: 0x0094BCB4 File Offset: 0x00949EB4
		public unsafe bool shatter_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_shatter_C.__PropertyOffset_14) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_shatter_C.__PropertyOffset_14) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003BA6 RID: 15270
		// (get) Token: 0x06021877 RID: 137335 RVA: 0x0094BCC5 File Offset: 0x00949EC5
		// (set) Token: 0x06021878 RID: 137336 RVA: 0x0094BCD5 File Offset: 0x00949ED5
		public unsafe bool debug_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_shatter_C.__PropertyOffset_15) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_shatter_C.__PropertyOffset_15) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003BA7 RID: 15271
		// (get) Token: 0x06021879 RID: 137337 RVA: 0x0094BCE8 File Offset: 0x00949EE8
		// (set) Token: 0x0602187A RID: 137338 RVA: 0x0094BD21 File Offset: 0x00949F21
		public TArray<int> NodeArrInt
		{
			get
			{
				base.FastCheckIsValid();
				TArray<int> result;
				if ((result = this._NodeArrInt) == null)
				{
					result = (this._NodeArrInt = new TArray<int>(base.NativePtr + (IntPtr)BP_shatter_C.__PropertyOffset_16, this));
				}
				return result;
			}
			set
			{
				this.NodeArrInt.CopyAssign(value);
			}
		}

		// Token: 0x17003BA8 RID: 15272
		// (get) Token: 0x0602187B RID: 137339 RVA: 0x0094BD2F File Offset: 0x00949F2F
		// (set) Token: 0x0602187C RID: 137340 RVA: 0x0094BD3F File Offset: 0x00949F3F
		public unsafe bool readDA_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_shatter_C.__PropertyOffset_17) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_shatter_C.__PropertyOffset_17) = (value ? 1 : 0);
			}
		}

		// Token: 0x0602187D RID: 137341 RVA: 0x0094BD50 File Offset: 0x00949F50
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void LoadFromDA_pure()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_shatter_C.__LoadFromDA_pure_NativeFunctionPtr, null);
		}

		// Token: 0x0602187E RID: 137342 RVA: 0x0094BD64 File Offset: 0x00949F64
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void setMaterialsToChild(UStaticMeshComponent FatherComponent, AStaticMeshActor ChildActor)
		{
			BP_shatter_C.__setMaterialsToChild_FunctionParams* ptr = stackalloc BP_shatter_C.__setMaterialsToChild_FunctionParams[(UIntPtr)151] + 15L / (long)sizeof(BP_shatter_C.__setMaterialsToChild_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_shatter_C.__setMaterialsToChild_NativeFunctionPtr, (void*)ptr, 1);
			ptr->FatherComponent = ((FatherComponent != null) ? FatherComponent.NativePtr : IntPtr.Zero);
			ptr->ChildActor = ((ChildActor != null) ? ChildActor.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_shatter_C.__setMaterialsToChild_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602187F RID: 137343 RVA: 0x0094BDD4 File Offset: 0x00949FD4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void LoadFromDA(int ID, ref bool __)
		{
			BP_shatter_C.__LoadFromDA_FunctionParams* ptr = stackalloc BP_shatter_C.__LoadFromDA_FunctionParams[(UIntPtr)127] + 15L / (long)sizeof(BP_shatter_C.__LoadFromDA_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_shatter_C.__LoadFromDA_NativeFunctionPtr, (void*)ptr, 1);
			ptr->ID = ID;
			ptr->__ = __;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_shatter_C.__LoadFromDA_NativeFunctionPtr, (void*)ptr);
			__ = ptr->__;
		}

		// Token: 0x06021880 RID: 137344 RVA: 0x0094BE2A File Offset: 0x0094A02A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SaveAsDA()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_shatter_C.__SaveAsDA_NativeFunctionPtr, null);
		}

		// Token: 0x06021881 RID: 137345 RVA: 0x0094BE3E File Offset: 0x0094A03E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Insert_Components()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_shatter_C.__Insert_Components_NativeFunctionPtr, null);
		}

		// Token: 0x06021882 RID: 137346 RVA: 0x0094BE52 File Offset: 0x0094A052
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_shatter_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06021883 RID: 137347 RVA: 0x0094BE66 File Offset: 0x0094A066
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_shatter_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06021884 RID: 137348 RVA: 0x0094BE7B File Offset: 0x0094A07B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_shatter_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06021885 RID: 137349 RVA: 0x0094BE8F File Offset: 0x0094A08F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_shatter_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06021886 RID: 137350 RVA: 0x0094BEA4 File Offset: 0x0094A0A4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_shatter_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_shatter_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_shatter_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_shatter_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_shatter_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021887 RID: 137351 RVA: 0x0094BEEC File Offset: 0x0094A0EC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_shatter_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_shatter_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_shatter_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_shatter_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_shatter_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021888 RID: 137352 RVA: 0x0094BF34 File Offset: 0x0094A134
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnWeaponInteraction(FVectorDouble OriginPoint, BP_SceneBattleInteract_C Config, int Id)
		{
			BP_shatter_C.__OnWeaponInteraction_FunctionParams* ptr = stackalloc BP_shatter_C.__OnWeaponInteraction_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(BP_shatter_C.__OnWeaponInteraction_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_shatter_C.__OnWeaponInteraction_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OriginPoint = OriginPoint;
			ptr->Config = ((Config != null) ? Config.NativePtr : IntPtr.Zero);
			ptr->Id = Id;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_shatter_C.__OnWeaponInteraction_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021889 RID: 137353 RVA: 0x0094BF97 File Offset: 0x0094A197
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SelectIntEvent()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_shatter_C.__SelectIntEvent_NativeFunctionPtr, null);
		}

		// Token: 0x0602188A RID: 137354 RVA: 0x0094BFAB File Offset: 0x0094A1AB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void MyCustom()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_shatter_C.__MyCustom_NativeFunctionPtr, null);
		}

		// Token: 0x0602188B RID: 137355 RVA: 0x0094BFBF File Offset: 0x0094A1BF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EditorTick()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_shatter_C.__EditorTick_NativeFunctionPtr, null);
		}

		// Token: 0x0602188C RID: 137356 RVA: 0x0094BFD3 File Offset: 0x0094A1D3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SelectEvent1()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_shatter_C.__SelectEvent1_NativeFunctionPtr, null);
		}

		// Token: 0x0602188D RID: 137357 RVA: 0x0094BFE7 File Offset: 0x0094A1E7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SelectEvent2()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_shatter_C.__SelectEvent2_NativeFunctionPtr, null);
		}

		// Token: 0x0602188E RID: 137358 RVA: 0x0094BFFB File Offset: 0x0094A1FB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SelectEvent3()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_shatter_C.__SelectEvent3_NativeFunctionPtr, null);
		}

		// Token: 0x0602188F RID: 137359 RVA: 0x0094C00F File Offset: 0x0094A20F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CustomStartShatter()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_shatter_C.__CustomStartShatter_NativeFunctionPtr, null);
		}

		// Token: 0x06021890 RID: 137360 RVA: 0x0094C023 File Offset: 0x0094A223
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void OnLogicEnable()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_shatter_C.__OnLogicEnable_NativeFunctionPtr, null);
		}

		// Token: 0x06021891 RID: 137361 RVA: 0x0094C037 File Offset: 0x0094A237
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void OnLogicEnable_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_shatter_C.__OnLogicEnable_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06021892 RID: 137362 RVA: 0x0094C04C File Offset: 0x0094A24C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void OnLogicDisable()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_shatter_C.__OnLogicDisable_NativeFunctionPtr, null);
		}

		// Token: 0x06021893 RID: 137363 RVA: 0x0094C060 File Offset: 0x0094A260
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void OnLogicDisable_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_shatter_C.__OnLogicDisable_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06021894 RID: 137364 RVA: 0x0094C078 File Offset: 0x0094A278
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_shatter(int EntryPoint)
		{
			BP_shatter_C.__ExecuteUbergraph_BP_shatter_FunctionParams* ptr = stackalloc BP_shatter_C.__ExecuteUbergraph_BP_shatter_FunctionParams[(UIntPtr)3247] + 15L / (long)sizeof(BP_shatter_C.__ExecuteUbergraph_BP_shatter_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_shatter_C.__ExecuteUbergraph_BP_shatter_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_shatter_C.__ExecuteUbergraph_BP_shatter_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021895 RID: 137365 RVA: 0x0094C0C2 File Offset: 0x0094A2C2
		protected BP_shatter_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04010E20 RID: 69152
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/SimpleShatter/BP_shatter.BP_shatter_C";

		// Token: 0x04010E21 RID: 69153
		private static IntPtr _ClassPtr;

		// Token: 0x04010E22 RID: 69154
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04010E23 RID: 69155
		internal static int __PropertyOffset_0;

		// Token: 0x04010E24 RID: 69156
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04010E25 RID: 69157
		internal static int __PropertyOffset_1;

		// Token: 0x04010E26 RID: 69158
		internal static int __PropertyOffset_2;

		// Token: 0x04010E27 RID: 69159
		internal static int __PropertyOffset_3;

		// Token: 0x04010E28 RID: 69160
		internal static int __PropertyOffset_4;

		// Token: 0x04010E29 RID: 69161
		internal static int __PropertyOffset_5;

		// Token: 0x04010E2A RID: 69162
		internal static int __PropertyOffset_6;

		// Token: 0x04010E2B RID: 69163
		internal static int __PropertyOffset_7;

		// Token: 0x04010E2C RID: 69164
		internal static int __PropertyOffset_8;

		// Token: 0x04010E2D RID: 69165
		internal static int __PropertyOffset_9;

		// Token: 0x04010E2E RID: 69166
		[Nullable(2)]
		private TArray<FTransform> _SMCompoentLocalTransformArr;

		// Token: 0x04010E2F RID: 69167
		internal static int __PropertyOffset_10;

		// Token: 0x04010E30 RID: 69168
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<AStaticMeshActor> _SMActorArr;

		// Token: 0x04010E31 RID: 69169
		internal static int __PropertyOffset_11;

		// Token: 0x04010E32 RID: 69170
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UStaticMeshComponent> _SMComponentArr;

		// Token: 0x04010E33 RID: 69171
		internal static int __PropertyOffset_12;

		// Token: 0x04010E34 RID: 69172
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UStaticMesh> _SMArr;

		// Token: 0x04010E35 RID: 69173
		internal static int __PropertyOffset_13;

		// Token: 0x04010E36 RID: 69174
		internal static int __PropertyOffset_14;

		// Token: 0x04010E37 RID: 69175
		internal static int __PropertyOffset_15;

		// Token: 0x04010E38 RID: 69176
		internal static int __PropertyOffset_16;

		// Token: 0x04010E39 RID: 69177
		[Nullable(2)]
		private TArray<int> _NodeArrInt;

		// Token: 0x04010E3A RID: 69178
		internal static int __PropertyOffset_17;

		// Token: 0x04010E3B RID: 69179
		private static IntPtr __LoadFromDA_pure_NativeFunctionPtr;

		// Token: 0x04010E3C RID: 69180
		private static IntPtr __setMaterialsToChild_NativeFunctionPtr;

		// Token: 0x04010E3D RID: 69181
		private static IntPtr __LoadFromDA_NativeFunctionPtr;

		// Token: 0x04010E3E RID: 69182
		private static IntPtr __SaveAsDA_NativeFunctionPtr;

		// Token: 0x04010E3F RID: 69183
		private static IntPtr __Insert_Components_NativeFunctionPtr;

		// Token: 0x04010E40 RID: 69184
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04010E41 RID: 69185
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04010E42 RID: 69186
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04010E43 RID: 69187
		private static IntPtr __OnWeaponInteraction_NativeFunctionPtr;

		// Token: 0x04010E44 RID: 69188
		private static IntPtr __SelectIntEvent_NativeFunctionPtr;

		// Token: 0x04010E45 RID: 69189
		private static IntPtr __MyCustom_NativeFunctionPtr;

		// Token: 0x04010E46 RID: 69190
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x04010E47 RID: 69191
		private static IntPtr __SelectEvent1_NativeFunctionPtr;

		// Token: 0x04010E48 RID: 69192
		private static IntPtr __SelectEvent2_NativeFunctionPtr;

		// Token: 0x04010E49 RID: 69193
		private static IntPtr __SelectEvent3_NativeFunctionPtr;

		// Token: 0x04010E4A RID: 69194
		private static IntPtr __CustomStartShatter_NativeFunctionPtr;

		// Token: 0x04010E4B RID: 69195
		private static IntPtr __OnLogicEnable_NativeFunctionPtr;

		// Token: 0x04010E4C RID: 69196
		private static IntPtr __OnLogicDisable_NativeFunctionPtr;

		// Token: 0x04010E4D RID: 69197
		private static IntPtr __ExecuteUbergraph_BP_shatter_NativeFunctionPtr;

		// Token: 0x02009AF2 RID: 39666
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 136)]
		protected ref struct __setMaterialsToChild_FunctionParams
		{
			// Token: 0x0403228E RID: 205454
			[FieldOffset(0)]
			public IntPtr FatherComponent;

			// Token: 0x0403228F RID: 205455
			[FieldOffset(8)]
			public IntPtr ChildActor;
		}

		// Token: 0x02009AF3 RID: 39667
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 112)]
		protected ref struct __LoadFromDA_FunctionParams
		{
			// Token: 0x04032290 RID: 205456
			[FieldOffset(0)]
			public int ID;

			// Token: 0x04032291 RID: 205457
			[FieldOffset(4)]
			public bool __;
		}

		// Token: 0x02009AF4 RID: 39668
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032292 RID: 205458
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009AF5 RID: 39669
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __OnWeaponInteraction_FunctionParams
		{
			// Token: 0x04032293 RID: 205459
			[FieldOffset(0)]
			public FVectorDouble OriginPoint;

			// Token: 0x04032294 RID: 205460
			[FieldOffset(24)]
			public IntPtr Config;

			// Token: 0x04032295 RID: 205461
			[FieldOffset(32)]
			public int Id;
		}

		// Token: 0x02009AF6 RID: 39670
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 3232)]
		protected ref struct __ExecuteUbergraph_BP_shatter_FunctionParams
		{
			// Token: 0x04032296 RID: 205462
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
