using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.GPUWindbellSimulation
{
	// Token: 0x02003C13 RID: 15379
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/GPUWindbellSimulation/BP_WindbellCol.BP_WindbellCol_C")]
	[UnrealStructLayout(1648, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1648)]
	public class BP_WindbellCol_C : AKuroCSWindbell_set, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06022FA6 RID: 143270 RVA: 0x00974F14 File Offset: 0x00973114
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_WindbellCol_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/GPUWindbellSimulation/BP_WindbellCol.BP_WindbellCol_C");
			}
			return BP_WindbellCol_C._ClassPtr;
		}

		// Token: 0x06022FA7 RID: 143271 RVA: 0x00974F38 File Offset: 0x00973138
		public BP_WindbellCol_C() : this(BuiltinUtils.AllocNativeUObject(BP_WindbellCol_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06022FA8 RID: 143272 RVA: 0x00974F60 File Offset: 0x00973160
		[NullableContext(1)]
		public BP_WindbellCol_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_WindbellCol_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170043C2 RID: 17346
		// (get) Token: 0x06022FA9 RID: 143273 RVA: 0x00974F94 File Offset: 0x00973194
		// (set) Token: 0x06022FAA RID: 143274 RVA: 0x00974FCD File Offset: 0x009731CD
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_WindbellCol_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_WindbellCol_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170043C3 RID: 17347
		// (get) Token: 0x06022FAB RID: 143275 RVA: 0x00974FEE File Offset: 0x009731EE
		// (set) Token: 0x06022FAC RID: 143276 RVA: 0x00975002 File Offset: 0x00973202
		public unsafe UChildActorComponent ChainEnd
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WindbellCol_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WindbellCol_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170043C4 RID: 17348
		// (get) Token: 0x06022FAD RID: 143277 RVA: 0x00975017 File Offset: 0x00973217
		// (set) Token: 0x06022FAE RID: 143278 RVA: 0x0097502B File Offset: 0x0097322B
		public unsafe UChildActorComponent ChainStart
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WindbellCol_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WindbellCol_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170043C5 RID: 17349
		// (get) Token: 0x06022FAF RID: 143279 RVA: 0x00975040 File Offset: 0x00973240
		// (set) Token: 0x06022FB0 RID: 143280 RVA: 0x00975054 File Offset: 0x00973254
		public unsafe UBoxComponent ValidBox
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WindbellCol_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WindbellCol_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x170043C6 RID: 17350
		// (get) Token: 0x06022FB1 RID: 143281 RVA: 0x00975069 File Offset: 0x00973269
		// (set) Token: 0x06022FB2 RID: 143282 RVA: 0x0097507D File Offset: 0x0097327D
		public unsafe UTextureRenderTarget2D RT
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WindbellCol_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WindbellCol_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x170043C7 RID: 17351
		// (get) Token: 0x06022FB3 RID: 143283 RVA: 0x00975092 File Offset: 0x00973292
		// (set) Token: 0x06022FB4 RID: 143284 RVA: 0x009750A2 File Offset: 0x009732A2
		public unsafe bool bEditorTick
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WindbellCol_C.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WindbellCol_C.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x170043C8 RID: 17352
		// (get) Token: 0x06022FB5 RID: 143285 RVA: 0x009750B3 File Offset: 0x009732B3
		// (set) Token: 0x06022FB6 RID: 143286 RVA: 0x009750C7 File Offset: 0x009732C7
		public unsafe FVector PosOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WindbellCol_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WindbellCol_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x170043C9 RID: 17353
		// (get) Token: 0x06022FB7 RID: 143287 RVA: 0x009750DC File Offset: 0x009732DC
		// (set) Token: 0x06022FB8 RID: 143288 RVA: 0x009750EC File Offset: 0x009732EC
		public unsafe float FadeOut
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WindbellCol_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WindbellCol_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x170043CA RID: 17354
		// (get) Token: 0x06022FB9 RID: 143289 RVA: 0x009750FD File Offset: 0x009732FD
		// (set) Token: 0x06022FBA RID: 143290 RVA: 0x0097510D File Offset: 0x0097330D
		public unsafe bool bFadeOut
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WindbellCol_C.__PropertyOffset_8) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WindbellCol_C.__PropertyOffset_8) = (value ? 1 : 0);
			}
		}

		// Token: 0x170043CB RID: 17355
		// (get) Token: 0x06022FBB RID: 143291 RVA: 0x00975120 File Offset: 0x00973320
		// (set) Token: 0x06022FBC RID: 143292 RVA: 0x00975159 File Offset: 0x00973359
		[Nullable(1)]
		public TArray<UMaterialInstanceDynamic> Mats
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<UMaterialInstanceDynamic> result;
				if ((result = this._Mats) == null)
				{
					result = (this._Mats = new TArray<UMaterialInstanceDynamic>(base.NativePtr + (IntPtr)BP_WindbellCol_C.__PropertyOffset_9, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Mats.CopyAssign(value);
			}
		}

		// Token: 0x170043CC RID: 17356
		// (get) Token: 0x06022FBD RID: 143293 RVA: 0x00975167 File Offset: 0x00973367
		// (set) Token: 0x06022FBE RID: 143294 RVA: 0x00975177 File Offset: 0x00973377
		public unsafe bool bInit
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WindbellCol_C.__PropertyOffset_10) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WindbellCol_C.__PropertyOffset_10) = (value ? 1 : 0);
			}
		}

		// Token: 0x170043CD RID: 17357
		// (get) Token: 0x06022FBF RID: 143295 RVA: 0x00975188 File Offset: 0x00973388
		// (set) Token: 0x06022FC0 RID: 143296 RVA: 0x00975198 File Offset: 0x00973398
		public unsafe bool bDrawDebug
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WindbellCol_C.__PropertyOffset_11) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WindbellCol_C.__PropertyOffset_11) = (value ? 1 : 0);
			}
		}

		// Token: 0x170043CE RID: 17358
		// (get) Token: 0x06022FC1 RID: 143297 RVA: 0x009751A9 File Offset: 0x009733A9
		// (set) Token: 0x06022FC2 RID: 143298 RVA: 0x009751BD File Offset: 0x009733BD
		public unsafe UChildActorComponent editorTicker
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WindbellCol_C.__PropertyOffset_12);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WindbellCol_C.__PropertyOffset_12, value);
			}
		}

		// Token: 0x170043CF RID: 17359
		// (get) Token: 0x06022FC3 RID: 143299 RVA: 0x009751D2 File Offset: 0x009733D2
		// (set) Token: 0x06022FC4 RID: 143300 RVA: 0x009751E6 File Offset: 0x009733E6
		public unsafe FVector gravity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WindbellCol_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WindbellCol_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x170043D0 RID: 17360
		// (get) Token: 0x06022FC5 RID: 143301 RVA: 0x009751FB File Offset: 0x009733FB
		// (set) Token: 0x06022FC6 RID: 143302 RVA: 0x0097520F File Offset: 0x0097340F
		public unsafe UTextureRenderTarget2D RT_N
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WindbellCol_C.__PropertyOffset_14);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WindbellCol_C.__PropertyOffset_14, value);
			}
		}

		// Token: 0x170043D1 RID: 17361
		// (get) Token: 0x06022FC7 RID: 143303 RVA: 0x00975224 File Offset: 0x00973424
		// (set) Token: 0x06022FC8 RID: 143304 RVA: 0x00975234 File Offset: 0x00973434
		public unsafe bool bSaveAllData
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WindbellCol_C.__PropertyOffset_15) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WindbellCol_C.__PropertyOffset_15) = (value ? 1 : 0);
			}
		}

		// Token: 0x170043D2 RID: 17362
		// (get) Token: 0x06022FC9 RID: 143305 RVA: 0x00975245 File Offset: 0x00973445
		// (set) Token: 0x06022FCA RID: 143306 RVA: 0x00975255 File Offset: 0x00973455
		public unsafe bool Start
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WindbellCol_C.__PropertyOffset_16) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WindbellCol_C.__PropertyOffset_16) = (value ? 1 : 0);
			}
		}

		// Token: 0x170043D3 RID: 17363
		// (get) Token: 0x06022FCB RID: 143307 RVA: 0x00975266 File Offset: 0x00973466
		// (set) Token: 0x06022FCC RID: 143308 RVA: 0x00975276 File Offset: 0x00973476
		public unsafe float FadeIn
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WindbellCol_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WindbellCol_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x170043D4 RID: 17364
		// (get) Token: 0x06022FCD RID: 143309 RVA: 0x00975288 File Offset: 0x00973488
		// (set) Token: 0x06022FCE RID: 143310 RVA: 0x009752C1 File Offset: 0x009734C1
		[Nullable(1)]
		public TArray<AStaticMeshActor> SMarray
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<AStaticMeshActor> result;
				if ((result = this._SMarray) == null)
				{
					result = (this._SMarray = new TArray<AStaticMeshActor>(base.NativePtr + (IntPtr)BP_WindbellCol_C.__PropertyOffset_18, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.SMarray.CopyAssign(value);
			}
		}

		// Token: 0x170043D5 RID: 17365
		// (get) Token: 0x06022FCF RID: 143311 RVA: 0x009752CF File Offset: 0x009734CF
		// (set) Token: 0x06022FD0 RID: 143312 RVA: 0x009752DF File Offset: 0x009734DF
		public unsafe int GroupSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WindbellCol_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WindbellCol_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x170043D6 RID: 17366
		// (get) Token: 0x06022FD1 RID: 143313 RVA: 0x009752F0 File Offset: 0x009734F0
		// (set) Token: 0x06022FD2 RID: 143314 RVA: 0x00975304 File Offset: 0x00973504
		public unsafe UMaterialInstance InputMat1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WindbellCol_C.__PropertyOffset_20);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WindbellCol_C.__PropertyOffset_20, value);
			}
		}

		// Token: 0x170043D7 RID: 17367
		// (get) Token: 0x06022FD3 RID: 143315 RVA: 0x00975319 File Offset: 0x00973519
		// (set) Token: 0x06022FD4 RID: 143316 RVA: 0x0097532D File Offset: 0x0097352D
		public unsafe UMaterialInstance InputMat2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WindbellCol_C.__PropertyOffset_21);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WindbellCol_C.__PropertyOffset_21, value);
			}
		}

		// Token: 0x06022FD5 RID: 143317 RVA: 0x00975344 File Offset: 0x00973544
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Re_Cal_Pos(int I_Index_, int G_Group_, int N_Particle_Count_, ref FVector NewPos)
		{
			BP_WindbellCol_C.__Re_Cal_Pos_FunctionParams* ptr = stackalloc BP_WindbellCol_C.__Re_Cal_Pos_FunctionParams[(UIntPtr)167] + 15L / (long)sizeof(BP_WindbellCol_C.__Re_Cal_Pos_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WindbellCol_C.__Re_Cal_Pos_NativeFunctionPtr, (void*)ptr, 1);
			ptr->I_Index_ = I_Index_;
			ptr->G_Group_ = G_Group_;
			ptr->N_Particle_Count_ = N_Particle_Count_;
			ptr->NewPos = NewPos;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WindbellCol_C.__Re_Cal_Pos_NativeFunctionPtr, (void*)ptr);
			NewPos = ptr->NewPos;
		}

		// Token: 0x06022FD6 RID: 143318 RVA: 0x009753B8 File Offset: 0x009735B8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Is_Last(int i_index_, int G_group_, int N_particleCount_, ref int RightID)
		{
			BP_WindbellCol_C.__Is_Last_FunctionParams* ptr = stackalloc BP_WindbellCol_C.__Is_Last_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(BP_WindbellCol_C.__Is_Last_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WindbellCol_C.__Is_Last_NativeFunctionPtr, (void*)ptr, 1);
			ptr->i_index_ = i_index_;
			ptr->G_group_ = G_group_;
			ptr->N_particleCount_ = N_particleCount_;
			ptr->RightID = RightID;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WindbellCol_C.__Is_Last_NativeFunctionPtr, (void*)ptr);
			RightID = ptr->RightID;
		}

		// Token: 0x06022FD7 RID: 143319 RVA: 0x00975420 File Offset: 0x00973620
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Is_First(int i_index_, int G_group_, int N_particleCount_, ref int LeftID, ref int Pinned)
		{
			BP_WindbellCol_C.__Is_First_FunctionParams* ptr = stackalloc BP_WindbellCol_C.__Is_First_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_WindbellCol_C.__Is_First_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WindbellCol_C.__Is_First_NativeFunctionPtr, (void*)ptr, 1);
			ptr->i_index_ = i_index_;
			ptr->G_group_ = G_group_;
			ptr->N_particleCount_ = N_particleCount_;
			ptr->LeftID = LeftID;
			ptr->Pinned = Pinned;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WindbellCol_C.__Is_First_NativeFunctionPtr, (void*)ptr);
			LeftID = ptr->LeftID;
			Pinned = ptr->Pinned;
		}

		// Token: 0x06022FD8 RID: 143320 RVA: 0x00975498 File Offset: 0x00973698
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void InitRT()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WindbellCol_C.__InitRT_NativeFunctionPtr, null);
		}

		// Token: 0x06022FD9 RID: 143321 RVA: 0x009754AC File Offset: 0x009736AC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void StopSim()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WindbellCol_C.__StopSim_NativeFunctionPtr, null);
		}

		// Token: 0x06022FDA RID: 143322 RVA: 0x009754C0 File Offset: 0x009736C0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void StartSim()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WindbellCol_C.__StartSim_NativeFunctionPtr, null);
		}

		// Token: 0x06022FDB RID: 143323 RVA: 0x009754D4 File Offset: 0x009736D4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void InitMats()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WindbellCol_C.__InitMats_NativeFunctionPtr, null);
		}

		// Token: 0x06022FDC RID: 143324 RVA: 0x009754E8 File Offset: 0x009736E8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WindbellCol_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06022FDD RID: 143325 RVA: 0x009754FC File Offset: 0x009736FC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WindbellCol_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06022FDE RID: 143326 RVA: 0x00975511 File Offset: 0x00973711
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WindbellCol_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06022FDF RID: 143327 RVA: 0x00975525 File Offset: 0x00973725
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WindbellCol_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06022FE0 RID: 143328 RVA: 0x0097553C File Offset: 0x0097373C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_WindbellCol_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_WindbellCol_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_WindbellCol_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WindbellCol_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WindbellCol_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022FE1 RID: 143329 RVA: 0x00975584 File Offset: 0x00973784
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_WindbellCol_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_WindbellCol_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_WindbellCol_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WindbellCol_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WindbellCol_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06022FE2 RID: 143330 RVA: 0x009755CB File Offset: 0x009737CB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EditorTick()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WindbellCol_C.__EditorTick_NativeFunctionPtr, null);
		}

		// Token: 0x06022FE3 RID: 143331 RVA: 0x009755E0 File Offset: 0x009737E0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex, bool bFromSweep, in FHitResult SweepResult)
		{
			BP_WindbellCol_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_WindbellCol_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(BP_WindbellCol_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WindbellCol_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			ptr->bFromSweep = bFromSweep;
			if (SweepResult != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FHitResult.StaticStruct(), &ptr->SweepResult, SweepResult.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WindbellCol_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022FE4 RID: 143332 RVA: 0x0097569C File Offset: 0x0097389C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex)
		{
			BP_WindbellCol_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_WindbellCol_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_WindbellCol_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WindbellCol_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WindbellCol_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022FE5 RID: 143333 RVA: 0x00975728 File Offset: 0x00973928
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveEndPlay(EEndPlayReason EndPlayReason)
		{
			BP_WindbellCol_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_WindbellCol_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_WindbellCol_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WindbellCol_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WindbellCol_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022FE6 RID: 143334 RVA: 0x00975774 File Offset: 0x00973974
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveEndPlay_Implementation(EEndPlayReason EndPlayReason)
		{
			BP_WindbellCol_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_WindbellCol_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_WindbellCol_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WindbellCol_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WindbellCol_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06022FE7 RID: 143335 RVA: 0x009757C0 File Offset: 0x009739C0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_WindbellCol(int EntryPoint)
		{
			BP_WindbellCol_C.__ExecuteUbergraph_BP_WindbellCol_FunctionParams* ptr = stackalloc BP_WindbellCol_C.__ExecuteUbergraph_BP_WindbellCol_FunctionParams[(UIntPtr)623] + 15L / (long)sizeof(BP_WindbellCol_C.__ExecuteUbergraph_BP_WindbellCol_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WindbellCol_C.__ExecuteUbergraph_BP_WindbellCol_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WindbellCol_C.__ExecuteUbergraph_BP_WindbellCol_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06022FE8 RID: 143336 RVA: 0x0097580A File Offset: 0x00973A0A
		protected BP_WindbellCol_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04011C54 RID: 72788
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/GPUWindbellSimulation/BP_WindbellCol.BP_WindbellCol_C";

		// Token: 0x04011C55 RID: 72789
		private static IntPtr _ClassPtr;

		// Token: 0x04011C56 RID: 72790
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04011C57 RID: 72791
		internal static int __PropertyOffset_0;

		// Token: 0x04011C58 RID: 72792
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04011C59 RID: 72793
		internal static int __PropertyOffset_1;

		// Token: 0x04011C5A RID: 72794
		internal static int __PropertyOffset_2;

		// Token: 0x04011C5B RID: 72795
		internal static int __PropertyOffset_3;

		// Token: 0x04011C5C RID: 72796
		internal static int __PropertyOffset_4;

		// Token: 0x04011C5D RID: 72797
		internal static int __PropertyOffset_5;

		// Token: 0x04011C5E RID: 72798
		internal static int __PropertyOffset_6;

		// Token: 0x04011C5F RID: 72799
		internal static int __PropertyOffset_7;

		// Token: 0x04011C60 RID: 72800
		internal static int __PropertyOffset_8;

		// Token: 0x04011C61 RID: 72801
		internal static int __PropertyOffset_9;

		// Token: 0x04011C62 RID: 72802
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UMaterialInstanceDynamic> _Mats;

		// Token: 0x04011C63 RID: 72803
		internal static int __PropertyOffset_10;

		// Token: 0x04011C64 RID: 72804
		internal static int __PropertyOffset_11;

		// Token: 0x04011C65 RID: 72805
		internal static int __PropertyOffset_12;

		// Token: 0x04011C66 RID: 72806
		internal static int __PropertyOffset_13;

		// Token: 0x04011C67 RID: 72807
		internal static int __PropertyOffset_14;

		// Token: 0x04011C68 RID: 72808
		internal static int __PropertyOffset_15;

		// Token: 0x04011C69 RID: 72809
		internal static int __PropertyOffset_16;

		// Token: 0x04011C6A RID: 72810
		internal static int __PropertyOffset_17;

		// Token: 0x04011C6B RID: 72811
		internal static int __PropertyOffset_18;

		// Token: 0x04011C6C RID: 72812
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<AStaticMeshActor> _SMarray;

		// Token: 0x04011C6D RID: 72813
		internal static int __PropertyOffset_19;

		// Token: 0x04011C6E RID: 72814
		internal static int __PropertyOffset_20;

		// Token: 0x04011C6F RID: 72815
		internal static int __PropertyOffset_21;

		// Token: 0x04011C70 RID: 72816
		private static IntPtr __Re_Cal_Pos_NativeFunctionPtr;

		// Token: 0x04011C71 RID: 72817
		private static IntPtr __Is_Last_NativeFunctionPtr;

		// Token: 0x04011C72 RID: 72818
		private static IntPtr __Is_First_NativeFunctionPtr;

		// Token: 0x04011C73 RID: 72819
		private static IntPtr __InitRT_NativeFunctionPtr;

		// Token: 0x04011C74 RID: 72820
		private static IntPtr __StopSim_NativeFunctionPtr;

		// Token: 0x04011C75 RID: 72821
		private static IntPtr __StartSim_NativeFunctionPtr;

		// Token: 0x04011C76 RID: 72822
		private static IntPtr __InitMats_NativeFunctionPtr;

		// Token: 0x04011C77 RID: 72823
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04011C78 RID: 72824
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04011C79 RID: 72825
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04011C7A RID: 72826
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x04011C7B RID: 72827
		private static IntPtr __BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04011C7C RID: 72828
		private static IntPtr __BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04011C7D RID: 72829
		private static IntPtr __ReceiveEndPlay_NativeFunctionPtr;

		// Token: 0x04011C7E RID: 72830
		private static IntPtr __ExecuteUbergraph_BP_WindbellCol_NativeFunctionPtr;

		// Token: 0x02009C67 RID: 40039
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 152)]
		protected ref struct __Re_Cal_Pos_FunctionParams
		{
			// Token: 0x0403253B RID: 206139
			[FieldOffset(0)]
			public int I_Index_;

			// Token: 0x0403253C RID: 206140
			[FieldOffset(4)]
			public int G_Group_;

			// Token: 0x0403253D RID: 206141
			[FieldOffset(8)]
			public int N_Particle_Count_;

			// Token: 0x0403253E RID: 206142
			[FieldOffset(12)]
			public FVector NewPos;
		}

		// Token: 0x02009C68 RID: 40040
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __Is_Last_FunctionParams
		{
			// Token: 0x0403253F RID: 206143
			[FieldOffset(0)]
			public int i_index_;

			// Token: 0x04032540 RID: 206144
			[FieldOffset(4)]
			public int G_group_;

			// Token: 0x04032541 RID: 206145
			[FieldOffset(8)]
			public int N_particleCount_;

			// Token: 0x04032542 RID: 206146
			[FieldOffset(12)]
			public int RightID;
		}

		// Token: 0x02009C69 RID: 40041
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __Is_First_FunctionParams
		{
			// Token: 0x04032543 RID: 206147
			[FieldOffset(0)]
			public int i_index_;

			// Token: 0x04032544 RID: 206148
			[FieldOffset(4)]
			public int G_group_;

			// Token: 0x04032545 RID: 206149
			[FieldOffset(8)]
			public int N_particleCount_;

			// Token: 0x04032546 RID: 206150
			[FieldOffset(12)]
			public int LeftID;

			// Token: 0x04032547 RID: 206151
			[FieldOffset(16)]
			public int Pinned;
		}

		// Token: 0x02009C6A RID: 40042
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032548 RID: 206152
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009C6B RID: 40043
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x04032549 RID: 206153
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x0403254A RID: 206154
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x0403254B RID: 206155
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x0403254C RID: 206156
			[FieldOffset(24)]
			public int OtherBodyIndex;

			// Token: 0x0403254D RID: 206157
			[FieldOffset(28)]
			public bool bFromSweep;

			// Token: 0x0403254E RID: 206158
			[FieldOffset(32)]
			public byte SweepResult;
		}

		// Token: 0x02009C6C RID: 40044
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x0403254F RID: 206159
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x04032550 RID: 206160
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x04032551 RID: 206161
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x04032552 RID: 206162
			[FieldOffset(24)]
			public int OtherBodyIndex;
		}

		// Token: 0x02009C6D RID: 40045
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __ReceiveEndPlay_FunctionParams
		{
			// Token: 0x04032553 RID: 206163
			[FieldOffset(0)]
			public TEnumAsByte<EEndPlayReason> EndPlayReason;
		}

		// Token: 0x02009C6E RID: 40046
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 608)]
		protected ref struct __ExecuteUbergraph_BP_WindbellCol_FunctionParams
		{
			// Token: 0x04032554 RID: 206164
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
