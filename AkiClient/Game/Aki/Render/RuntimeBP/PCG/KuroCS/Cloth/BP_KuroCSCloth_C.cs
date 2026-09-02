using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.KuroCS.Cloth
{
	// Token: 0x02003BFF RID: 15359
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/KuroCS/Cloth/BP_KuroCSCloth.BP_KuroCSCloth_C")]
	[UnrealStructLayout(1576, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1574)]
	public class BP_KuroCSCloth_C : AKuroCSCloth, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06022C40 RID: 142400 RVA: 0x0096E73D File Offset: 0x0096C93D
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_KuroCSCloth_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/KuroCS/Cloth/BP_KuroCSCloth.BP_KuroCSCloth_C");
			}
			return BP_KuroCSCloth_C._ClassPtr;
		}

		// Token: 0x06022C41 RID: 142401 RVA: 0x0096E764 File Offset: 0x0096C964
		public BP_KuroCSCloth_C() : this(BuiltinUtils.AllocNativeUObject(BP_KuroCSCloth_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06022C42 RID: 142402 RVA: 0x0096E78C File Offset: 0x0096C98C
		[NullableContext(1)]
		public BP_KuroCSCloth_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_KuroCSCloth_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700429A RID: 17050
		// (get) Token: 0x06022C43 RID: 142403 RVA: 0x0096E7C0 File Offset: 0x0096C9C0
		// (set) Token: 0x06022C44 RID: 142404 RVA: 0x0096E7F9 File Offset: 0x0096C9F9
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_KuroCSCloth_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_KuroCSCloth_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700429B RID: 17051
		// (get) Token: 0x06022C45 RID: 142405 RVA: 0x0096E81A File Offset: 0x0096CA1A
		// (set) Token: 0x06022C46 RID: 142406 RVA: 0x0096E82E File Offset: 0x0096CA2E
		public unsafe UBoxComponent ValidBox
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSCloth_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSCloth_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x1700429C RID: 17052
		// (get) Token: 0x06022C47 RID: 142407 RVA: 0x0096E843 File Offset: 0x0096CA43
		// (set) Token: 0x06022C48 RID: 142408 RVA: 0x0096E857 File Offset: 0x0096CA57
		public unsafe UStaticMeshComponent ClothMeshXZ
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSCloth_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSCloth_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x1700429D RID: 17053
		// (get) Token: 0x06022C49 RID: 142409 RVA: 0x0096E86C File Offset: 0x0096CA6C
		// (set) Token: 0x06022C4A RID: 142410 RVA: 0x0096E880 File Offset: 0x0096CA80
		public unsafe UTextureRenderTarget2D RT
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSCloth_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSCloth_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x1700429E RID: 17054
		// (get) Token: 0x06022C4B RID: 142411 RVA: 0x0096E895 File Offset: 0x0096CA95
		// (set) Token: 0x06022C4C RID: 142412 RVA: 0x0096E8A5 File Offset: 0x0096CAA5
		public unsafe bool bStopSim
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCSCloth_C.__PropertyOffset_4) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCSCloth_C.__PropertyOffset_4) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700429F RID: 17055
		// (get) Token: 0x06022C4D RID: 142413 RVA: 0x0096E8B6 File Offset: 0x0096CAB6
		// (set) Token: 0x06022C4E RID: 142414 RVA: 0x0096E8C6 File Offset: 0x0096CAC6
		public unsafe bool bEditorTick
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCSCloth_C.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCSCloth_C.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x170042A0 RID: 17056
		// (get) Token: 0x06022C4F RID: 142415 RVA: 0x0096E8D7 File Offset: 0x0096CAD7
		// (set) Token: 0x06022C50 RID: 142416 RVA: 0x0096E8EB File Offset: 0x0096CAEB
		public unsafe FVector PosOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCSCloth_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCSCloth_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x170042A1 RID: 17057
		// (get) Token: 0x06022C51 RID: 142417 RVA: 0x0096E900 File Offset: 0x0096CB00
		// (set) Token: 0x06022C52 RID: 142418 RVA: 0x0096E910 File Offset: 0x0096CB10
		public unsafe float FadeOut
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCSCloth_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCSCloth_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x170042A2 RID: 17058
		// (get) Token: 0x06022C53 RID: 142419 RVA: 0x0096E921 File Offset: 0x0096CB21
		// (set) Token: 0x06022C54 RID: 142420 RVA: 0x0096E931 File Offset: 0x0096CB31
		public unsafe bool bFadeOut
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCSCloth_C.__PropertyOffset_8) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCSCloth_C.__PropertyOffset_8) = (value ? 1 : 0);
			}
		}

		// Token: 0x170042A3 RID: 17059
		// (get) Token: 0x06022C55 RID: 142421 RVA: 0x0096E944 File Offset: 0x0096CB44
		// (set) Token: 0x06022C56 RID: 142422 RVA: 0x0096E97D File Offset: 0x0096CB7D
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
					result = (this._Mats = new TArray<UMaterialInstanceDynamic>(base.NativePtr + (IntPtr)BP_KuroCSCloth_C.__PropertyOffset_9, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Mats.CopyAssign(value);
			}
		}

		// Token: 0x170042A4 RID: 17060
		// (get) Token: 0x06022C57 RID: 142423 RVA: 0x0096E98B File Offset: 0x0096CB8B
		// (set) Token: 0x06022C58 RID: 142424 RVA: 0x0096E99B File Offset: 0x0096CB9B
		public unsafe bool bInit
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCSCloth_C.__PropertyOffset_10) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCSCloth_C.__PropertyOffset_10) = (value ? 1 : 0);
			}
		}

		// Token: 0x170042A5 RID: 17061
		// (get) Token: 0x06022C59 RID: 142425 RVA: 0x0096E9AC File Offset: 0x0096CBAC
		// (set) Token: 0x06022C5A RID: 142426 RVA: 0x0096E9BC File Offset: 0x0096CBBC
		public unsafe bool bDrawDebug
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCSCloth_C.__PropertyOffset_11) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCSCloth_C.__PropertyOffset_11) = (value ? 1 : 0);
			}
		}

		// Token: 0x170042A6 RID: 17062
		// (get) Token: 0x06022C5B RID: 142427 RVA: 0x0096E9CD File Offset: 0x0096CBCD
		// (set) Token: 0x06022C5C RID: 142428 RVA: 0x0096E9DD File Offset: 0x0096CBDD
		public unsafe bool InitOverlap
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCSCloth_C.__PropertyOffset_12) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCSCloth_C.__PropertyOffset_12) = (value ? 1 : 0);
			}
		}

		// Token: 0x170042A7 RID: 17063
		// (get) Token: 0x06022C5D RID: 142429 RVA: 0x0096E9EE File Offset: 0x0096CBEE
		// (set) Token: 0x06022C5E RID: 142430 RVA: 0x0096E9FE File Offset: 0x0096CBFE
		public unsafe bool bEnable
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCSCloth_C.__PropertyOffset_13) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCSCloth_C.__PropertyOffset_13) = (value ? 1 : 0);
			}
		}

		// Token: 0x170042A8 RID: 17064
		// (get) Token: 0x06022C5F RID: 142431 RVA: 0x0096EA0F File Offset: 0x0096CC0F
		// (set) Token: 0x06022C60 RID: 142432 RVA: 0x0096EA1F File Offset: 0x0096CC1F
		public unsafe float CollisionWolrd
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCSCloth_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCSCloth_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x170042A9 RID: 17065
		// (get) Token: 0x06022C61 RID: 142433 RVA: 0x0096EA30 File Offset: 0x0096CC30
		// (set) Token: 0x06022C62 RID: 142434 RVA: 0x0096EA44 File Offset: 0x0096CC44
		public unsafe UChildActorComponent editorTicker
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSCloth_C.__PropertyOffset_15);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSCloth_C.__PropertyOffset_15, value);
			}
		}

		// Token: 0x170042AA RID: 17066
		// (get) Token: 0x06022C63 RID: 142435 RVA: 0x0096EA59 File Offset: 0x0096CC59
		// (set) Token: 0x06022C64 RID: 142436 RVA: 0x0096EA69 File Offset: 0x0096CC69
		public unsafe bool bReadFromDA
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCSCloth_C.__PropertyOffset_16) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCSCloth_C.__PropertyOffset_16) = (value ? 1 : 0);
			}
		}

		// Token: 0x170042AB RID: 17067
		// (get) Token: 0x06022C65 RID: 142437 RVA: 0x0096EA7A File Offset: 0x0096CC7A
		// (set) Token: 0x06022C66 RID: 142438 RVA: 0x0096EA8E File Offset: 0x0096CC8E
		public unsafe PD_MeshToClothData_C DA
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<PD_MeshToClothData_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSCloth_C.__PropertyOffset_17);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSCloth_C.__PropertyOffset_17, value);
			}
		}

		// Token: 0x170042AC RID: 17068
		// (get) Token: 0x06022C67 RID: 142439 RVA: 0x0096EAA3 File Offset: 0x0096CCA3
		// (set) Token: 0x06022C68 RID: 142440 RVA: 0x0096EAB7 File Offset: 0x0096CCB7
		public unsafe UTextureRenderTarget2D RT_N
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSCloth_C.__PropertyOffset_18);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSCloth_C.__PropertyOffset_18, value);
			}
		}

		// Token: 0x170042AD RID: 17069
		// (get) Token: 0x06022C69 RID: 142441 RVA: 0x0096EACC File Offset: 0x0096CCCC
		// (set) Token: 0x06022C6A RID: 142442 RVA: 0x0096EADC File Offset: 0x0096CCDC
		public unsafe float Delta_Time
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCSCloth_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCSCloth_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x170042AE RID: 17070
		// (get) Token: 0x06022C6B RID: 142443 RVA: 0x0096EAF0 File Offset: 0x0096CCF0
		// (set) Token: 0x06022C6C RID: 142444 RVA: 0x0096EB29 File Offset: 0x0096CD29
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
					result = (this._Scalar_Parameters = new TMap<FName, float>(base.NativePtr + (IntPtr)BP_KuroCSCloth_C.__PropertyOffset_20, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Scalar_Parameters.CopyAssign(value);
			}
		}

		// Token: 0x170042AF RID: 17071
		// (get) Token: 0x06022C6D RID: 142445 RVA: 0x0096EB38 File Offset: 0x0096CD38
		// (set) Token: 0x06022C6E RID: 142446 RVA: 0x0096EB71 File Offset: 0x0096CD71
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
					result = (this._Vector_Parameters = new TMap<FName, FLinearColor>(base.NativePtr + (IntPtr)BP_KuroCSCloth_C.__PropertyOffset_21, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Vector_Parameters.CopyAssign(value);
			}
		}

		// Token: 0x170042B0 RID: 17072
		// (get) Token: 0x06022C6F RID: 142447 RVA: 0x0096EB80 File Offset: 0x0096CD80
		// (set) Token: 0x06022C70 RID: 142448 RVA: 0x0096EBB9 File Offset: 0x0096CDB9
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
					result = (this._Texture_Parameters = new TMap<FName, UTexture>(base.NativePtr + (IntPtr)BP_KuroCSCloth_C.__PropertyOffset_22, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Texture_Parameters.CopyAssign(value);
			}
		}

		// Token: 0x170042B1 RID: 17073
		// (get) Token: 0x06022C71 RID: 142449 RVA: 0x0096EBC7 File Offset: 0x0096CDC7
		// (set) Token: 0x06022C72 RID: 142450 RVA: 0x0096EBD7 File Offset: 0x0096CDD7
		public unsafe float LastCustomDeltaTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCSCloth_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCSCloth_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x170042B2 RID: 17074
		// (get) Token: 0x06022C73 RID: 142451 RVA: 0x0096EBE8 File Offset: 0x0096CDE8
		// (set) Token: 0x06022C74 RID: 142452 RVA: 0x0096EBF8 File Offset: 0x0096CDF8
		public unsafe bool bFlipNormal
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCSCloth_C.__PropertyOffset_24) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCSCloth_C.__PropertyOffset_24) = (value ? 1 : 0);
			}
		}

		// Token: 0x170042B3 RID: 17075
		// (get) Token: 0x06022C75 RID: 142453 RVA: 0x0096EC09 File Offset: 0x0096CE09
		// (set) Token: 0x06022C76 RID: 142454 RVA: 0x0096EC19 File Offset: 0x0096CE19
		public unsafe bool bDisableBoxCollision
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCSCloth_C.__PropertyOffset_25) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCSCloth_C.__PropertyOffset_25) = (value ? 1 : 0);
			}
		}

		// Token: 0x06022C77 RID: 142455 RVA: 0x0096EC2A File Offset: 0x0096CE2A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateMaterialParams()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCSCloth_C.__UpdateMaterialParams_NativeFunctionPtr, null);
		}

		// Token: 0x06022C78 RID: 142456 RVA: 0x0096EC3E File Offset: 0x0096CE3E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void InitParams()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCSCloth_C.__InitParams_NativeFunctionPtr, null);
		}

		// Token: 0x06022C79 RID: 142457 RVA: 0x0096EC52 File Offset: 0x0096CE52
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void InitRT()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCSCloth_C.__InitRT_NativeFunctionPtr, null);
		}

		// Token: 0x06022C7A RID: 142458 RVA: 0x0096EC66 File Offset: 0x0096CE66
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AutoXCenter()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCSCloth_C.__AutoXCenter_NativeFunctionPtr, null);
		}

		// Token: 0x06022C7B RID: 142459 RVA: 0x0096EC7A File Offset: 0x0096CE7A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void InitMats()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCSCloth_C.__InitMats_NativeFunctionPtr, null);
		}

		// Token: 0x06022C7C RID: 142460 RVA: 0x0096EC8E File Offset: 0x0096CE8E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCSCloth_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06022C7D RID: 142461 RVA: 0x0096ECA2 File Offset: 0x0096CEA2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroCSCloth_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06022C7E RID: 142462 RVA: 0x0096ECB7 File Offset: 0x0096CEB7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EditorTick()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCSCloth_C.__EditorTick_NativeFunctionPtr, null);
		}

		// Token: 0x06022C7F RID: 142463 RVA: 0x0096ECCC File Offset: 0x0096CECC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_KuroCSCloth_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_KuroCSCloth_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_KuroCSCloth_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroCSCloth_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCSCloth_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022C80 RID: 142464 RVA: 0x0096ED14 File Offset: 0x0096CF14
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_KuroCSCloth_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_KuroCSCloth_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_KuroCSCloth_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroCSCloth_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroCSCloth_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06022C81 RID: 142465 RVA: 0x0096ED5B File Offset: 0x0096CF5B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCSCloth_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06022C82 RID: 142466 RVA: 0x0096ED6F File Offset: 0x0096CF6F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroCSCloth_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06022C83 RID: 142467 RVA: 0x0096ED84 File Offset: 0x0096CF84
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveEndPlay(EEndPlayReason EndPlayReason)
		{
			BP_KuroCSCloth_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_KuroCSCloth_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_KuroCSCloth_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroCSCloth_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCSCloth_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022C84 RID: 142468 RVA: 0x0096EDD0 File Offset: 0x0096CFD0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveEndPlay_Implementation(EEndPlayReason EndPlayReason)
		{
			BP_KuroCSCloth_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_KuroCSCloth_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_KuroCSCloth_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroCSCloth_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroCSCloth_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06022C85 RID: 142469 RVA: 0x0096EE1C File Offset: 0x0096D01C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_KuroCSCloth_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex, bool bFromSweep, in FHitResult SweepResult)
		{
			BP_KuroCSCloth_C.__BndEvt__BP_KuroCSCloth_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_KuroCSCloth_C.__BndEvt__BP_KuroCSCloth_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(BP_KuroCSCloth_C.__BndEvt__BP_KuroCSCloth_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroCSCloth_C.__BndEvt__BP_KuroCSCloth_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			ptr->bFromSweep = bFromSweep;
			if (SweepResult != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FHitResult.StaticStruct(), &ptr->SweepResult, SweepResult.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCSCloth_C.__BndEvt__BP_KuroCSCloth_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022C86 RID: 142470 RVA: 0x0096EED8 File Offset: 0x0096D0D8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_KuroCSCloth_ValidBox_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex)
		{
			BP_KuroCSCloth_C.__BndEvt__BP_KuroCSCloth_ValidBox_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_KuroCSCloth_C.__BndEvt__BP_KuroCSCloth_ValidBox_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_KuroCSCloth_C.__BndEvt__BP_KuroCSCloth_ValidBox_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroCSCloth_C.__BndEvt__BP_KuroCSCloth_ValidBox_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCSCloth_C.__BndEvt__BP_KuroCSCloth_ValidBox_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022C87 RID: 142471 RVA: 0x0096EF64 File Offset: 0x0096D164
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_KuroCSCloth(int EntryPoint)
		{
			BP_KuroCSCloth_C.__ExecuteUbergraph_BP_KuroCSCloth_FunctionParams* ptr = stackalloc BP_KuroCSCloth_C.__ExecuteUbergraph_BP_KuroCSCloth_FunctionParams[(UIntPtr)1535] + 15L / (long)sizeof(BP_KuroCSCloth_C.__ExecuteUbergraph_BP_KuroCSCloth_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroCSCloth_C.__ExecuteUbergraph_BP_KuroCSCloth_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroCSCloth_C.__ExecuteUbergraph_BP_KuroCSCloth_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06022C88 RID: 142472 RVA: 0x0096EFAE File Offset: 0x0096D1AE
		protected BP_KuroCSCloth_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04011A22 RID: 72226
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/KuroCS/Cloth/BP_KuroCSCloth.BP_KuroCSCloth_C";

		// Token: 0x04011A23 RID: 72227
		private static IntPtr _ClassPtr;

		// Token: 0x04011A24 RID: 72228
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04011A25 RID: 72229
		internal static int __PropertyOffset_0;

		// Token: 0x04011A26 RID: 72230
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04011A27 RID: 72231
		internal static int __PropertyOffset_1;

		// Token: 0x04011A28 RID: 72232
		internal static int __PropertyOffset_2;

		// Token: 0x04011A29 RID: 72233
		internal static int __PropertyOffset_3;

		// Token: 0x04011A2A RID: 72234
		internal static int __PropertyOffset_4;

		// Token: 0x04011A2B RID: 72235
		internal static int __PropertyOffset_5;

		// Token: 0x04011A2C RID: 72236
		internal static int __PropertyOffset_6;

		// Token: 0x04011A2D RID: 72237
		internal static int __PropertyOffset_7;

		// Token: 0x04011A2E RID: 72238
		internal static int __PropertyOffset_8;

		// Token: 0x04011A2F RID: 72239
		internal static int __PropertyOffset_9;

		// Token: 0x04011A30 RID: 72240
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UMaterialInstanceDynamic> _Mats;

		// Token: 0x04011A31 RID: 72241
		internal static int __PropertyOffset_10;

		// Token: 0x04011A32 RID: 72242
		internal static int __PropertyOffset_11;

		// Token: 0x04011A33 RID: 72243
		internal static int __PropertyOffset_12;

		// Token: 0x04011A34 RID: 72244
		internal static int __PropertyOffset_13;

		// Token: 0x04011A35 RID: 72245
		internal static int __PropertyOffset_14;

		// Token: 0x04011A36 RID: 72246
		internal static int __PropertyOffset_15;

		// Token: 0x04011A37 RID: 72247
		internal static int __PropertyOffset_16;

		// Token: 0x04011A38 RID: 72248
		internal static int __PropertyOffset_17;

		// Token: 0x04011A39 RID: 72249
		internal static int __PropertyOffset_18;

		// Token: 0x04011A3A RID: 72250
		internal static int __PropertyOffset_19;

		// Token: 0x04011A3B RID: 72251
		internal static int __PropertyOffset_20;

		// Token: 0x04011A3C RID: 72252
		private TMap<FName, float> _Scalar_Parameters;

		// Token: 0x04011A3D RID: 72253
		internal static int __PropertyOffset_21;

		// Token: 0x04011A3E RID: 72254
		private TMap<FName, FLinearColor> _Vector_Parameters;

		// Token: 0x04011A3F RID: 72255
		internal static int __PropertyOffset_22;

		// Token: 0x04011A40 RID: 72256
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<FName, UTexture> _Texture_Parameters;

		// Token: 0x04011A41 RID: 72257
		internal static int __PropertyOffset_23;

		// Token: 0x04011A42 RID: 72258
		internal static int __PropertyOffset_24;

		// Token: 0x04011A43 RID: 72259
		internal static int __PropertyOffset_25;

		// Token: 0x04011A44 RID: 72260
		private static IntPtr __UpdateMaterialParams_NativeFunctionPtr;

		// Token: 0x04011A45 RID: 72261
		private static IntPtr __InitParams_NativeFunctionPtr;

		// Token: 0x04011A46 RID: 72262
		private static IntPtr __InitRT_NativeFunctionPtr;

		// Token: 0x04011A47 RID: 72263
		private static IntPtr __AutoXCenter_NativeFunctionPtr;

		// Token: 0x04011A48 RID: 72264
		private static IntPtr __InitMats_NativeFunctionPtr;

		// Token: 0x04011A49 RID: 72265
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04011A4A RID: 72266
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x04011A4B RID: 72267
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04011A4C RID: 72268
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04011A4D RID: 72269
		private static IntPtr __ReceiveEndPlay_NativeFunctionPtr;

		// Token: 0x04011A4E RID: 72270
		private static IntPtr __BndEvt__BP_KuroCSCloth_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04011A4F RID: 72271
		private static IntPtr __BndEvt__BP_KuroCSCloth_ValidBox_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04011A50 RID: 72272
		private static IntPtr __ExecuteUbergraph_BP_KuroCSCloth_NativeFunctionPtr;

		// Token: 0x02009C28 RID: 39976
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x040324A2 RID: 205986
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009C29 RID: 39977
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __ReceiveEndPlay_FunctionParams
		{
			// Token: 0x040324A3 RID: 205987
			[FieldOffset(0)]
			public TEnumAsByte<EEndPlayReason> EndPlayReason;
		}

		// Token: 0x02009C2A RID: 39978
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __BndEvt__BP_KuroCSCloth_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x040324A4 RID: 205988
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x040324A5 RID: 205989
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x040324A6 RID: 205990
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x040324A7 RID: 205991
			[FieldOffset(24)]
			public int OtherBodyIndex;

			// Token: 0x040324A8 RID: 205992
			[FieldOffset(28)]
			public bool bFromSweep;

			// Token: 0x040324A9 RID: 205993
			[FieldOffset(32)]
			public byte SweepResult;
		}

		// Token: 0x02009C2B RID: 39979
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __BndEvt__BP_KuroCSCloth_ValidBox_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x040324AA RID: 205994
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x040324AB RID: 205995
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x040324AC RID: 205996
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x040324AD RID: 205997
			[FieldOffset(24)]
			public int OtherBodyIndex;
		}

		// Token: 0x02009C2C RID: 39980
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1520)]
		protected ref struct __ExecuteUbergraph_BP_KuroCSCloth_FunctionParams
		{
			// Token: 0x040324AE RID: 205998
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
