using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Render.RuntimeBP.PCG.PBD_PhysicBridge.BP;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.KuroCS.ClothDynamicPin
{
	// Token: 0x02003C07 RID: 15367
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/KuroCS/ClothDynamicPin/BP_KuroCSCloth_DynamicPin.BP_KuroCSCloth_DynamicPin_C")]
	[UnrealStructLayout(2000, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1988)]
	public class BP_KuroCSCloth_DynamicPin_C : AKuroCS_Cloth_DynamicPin, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06022DC8 RID: 142792 RVA: 0x0097151F File Offset: 0x0096F71F
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_KuroCSCloth_DynamicPin_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/KuroCS/ClothDynamicPin/BP_KuroCSCloth_DynamicPin.BP_KuroCSCloth_DynamicPin_C");
			}
			return BP_KuroCSCloth_DynamicPin_C._ClassPtr;
		}

		// Token: 0x06022DC9 RID: 142793 RVA: 0x00971544 File Offset: 0x0096F744
		public BP_KuroCSCloth_DynamicPin_C() : this(BuiltinUtils.AllocNativeUObject(BP_KuroCSCloth_DynamicPin_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06022DCA RID: 142794 RVA: 0x0097156C File Offset: 0x0096F76C
		[NullableContext(1)]
		public BP_KuroCSCloth_DynamicPin_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_KuroCSCloth_DynamicPin_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004320 RID: 17184
		// (get) Token: 0x06022DCB RID: 142795 RVA: 0x009715A0 File Offset: 0x0096F7A0
		// (set) Token: 0x06022DCC RID: 142796 RVA: 0x009715D9 File Offset: 0x0096F7D9
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004321 RID: 17185
		// (get) Token: 0x06022DCD RID: 142797 RVA: 0x009715FA File Offset: 0x0096F7FA
		// (set) Token: 0x06022DCE RID: 142798 RVA: 0x0097160E File Offset: 0x0096F80E
		public unsafe UBoxComponent Box
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSCloth_DynamicPin_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSCloth_DynamicPin_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17004322 RID: 17186
		// (get) Token: 0x06022DCF RID: 142799 RVA: 0x00971623 File Offset: 0x0096F823
		// (set) Token: 0x06022DD0 RID: 142800 RVA: 0x00971637 File Offset: 0x0096F837
		public unsafe UStaticMeshComponent MobileProxy
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSCloth_DynamicPin_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSCloth_DynamicPin_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17004323 RID: 17187
		// (get) Token: 0x06022DD1 RID: 142801 RVA: 0x0097164C File Offset: 0x0096F84C
		// (set) Token: 0x06022DD2 RID: 142802 RVA: 0x00971660 File Offset: 0x0096F860
		public unsafe UStaticMeshComponent MeshXZ
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSCloth_DynamicPin_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSCloth_DynamicPin_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17004324 RID: 17188
		// (get) Token: 0x06022DD3 RID: 142803 RVA: 0x00971675 File Offset: 0x0096F875
		// (set) Token: 0x06022DD4 RID: 142804 RVA: 0x00971689 File Offset: 0x0096F889
		public unsafe USceneComponent PinnedLB
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSCloth_DynamicPin_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSCloth_DynamicPin_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17004325 RID: 17189
		// (get) Token: 0x06022DD5 RID: 142805 RVA: 0x0097169E File Offset: 0x0096F89E
		// (set) Token: 0x06022DD6 RID: 142806 RVA: 0x009716B2 File Offset: 0x0096F8B2
		public unsafe USceneComponent PinnedLT
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSCloth_DynamicPin_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSCloth_DynamicPin_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17004326 RID: 17190
		// (get) Token: 0x06022DD7 RID: 142807 RVA: 0x009716C7 File Offset: 0x0096F8C7
		// (set) Token: 0x06022DD8 RID: 142808 RVA: 0x009716DB File Offset: 0x0096F8DB
		public unsafe USceneComponent PinnedRB
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSCloth_DynamicPin_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSCloth_DynamicPin_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x17004327 RID: 17191
		// (get) Token: 0x06022DD9 RID: 142809 RVA: 0x009716F0 File Offset: 0x0096F8F0
		// (set) Token: 0x06022DDA RID: 142810 RVA: 0x00971704 File Offset: 0x0096F904
		public unsafe USceneComponent PinnedRT
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSCloth_DynamicPin_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSCloth_DynamicPin_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x17004328 RID: 17192
		// (get) Token: 0x06022DDB RID: 142811 RVA: 0x00971719 File Offset: 0x0096F919
		// (set) Token: 0x06022DDC RID: 142812 RVA: 0x0097172D File Offset: 0x0096F92D
		public unsafe UTextureRenderTarget2D RTPos
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSCloth_DynamicPin_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSCloth_DynamicPin_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x17004329 RID: 17193
		// (get) Token: 0x06022DDD RID: 142813 RVA: 0x00971742 File Offset: 0x0096F942
		// (set) Token: 0x06022DDE RID: 142814 RVA: 0x00971752 File Offset: 0x0096F952
		public unsafe bool bSyncToBindPoint
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_C.__PropertyOffset_9) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_C.__PropertyOffset_9) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700432A RID: 17194
		// (get) Token: 0x06022DDF RID: 142815 RVA: 0x00971763 File Offset: 0x0096F963
		// (set) Token: 0x06022DE0 RID: 142816 RVA: 0x00971777 File Offset: 0x0096F977
		public unsafe BP_BridgeModels_C bindBrige
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_BridgeModels_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSCloth_DynamicPin_C.__PropertyOffset_10);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSCloth_DynamicPin_C.__PropertyOffset_10, value);
			}
		}

		// Token: 0x1700432B RID: 17195
		// (get) Token: 0x06022DE1 RID: 142817 RVA: 0x0097178C File Offset: 0x0096F98C
		// (set) Token: 0x06022DE2 RID: 142818 RVA: 0x0097179C File Offset: 0x0096F99C
		public unsafe int linkIndex
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x1700432C RID: 17196
		// (get) Token: 0x06022DE3 RID: 142819 RVA: 0x009717AD File Offset: 0x0096F9AD
		// (set) Token: 0x06022DE4 RID: 142820 RVA: 0x009717BD File Offset: 0x0096F9BD
		public unsafe bool bEditorTick
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_C.__PropertyOffset_12) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_C.__PropertyOffset_12) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700432D RID: 17197
		// (get) Token: 0x06022DE5 RID: 142821 RVA: 0x009717CE File Offset: 0x0096F9CE
		// (set) Token: 0x06022DE6 RID: 142822 RVA: 0x009717E2 File Offset: 0x0096F9E2
		public unsafe FVector PosOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x1700432E RID: 17198
		// (get) Token: 0x06022DE7 RID: 142823 RVA: 0x009717F8 File Offset: 0x0096F9F8
		// (set) Token: 0x06022DE8 RID: 142824 RVA: 0x00971831 File Offset: 0x0096FA31
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
					result = (this._Mats = new TArray<UMaterialInstanceDynamic>(base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_C.__PropertyOffset_14, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Mats.CopyAssign(value);
			}
		}

		// Token: 0x1700432F RID: 17199
		// (get) Token: 0x06022DE9 RID: 142825 RVA: 0x0097183F File Offset: 0x0096FA3F
		// (set) Token: 0x06022DEA RID: 142826 RVA: 0x0097184F File Offset: 0x0096FA4F
		public unsafe bool bDrawDebug
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_C.__PropertyOffset_15) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_C.__PropertyOffset_15) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004330 RID: 17200
		// (get) Token: 0x06022DEB RID: 142827 RVA: 0x00971860 File Offset: 0x0096FA60
		// (set) Token: 0x06022DEC RID: 142828 RVA: 0x00971874 File Offset: 0x0096FA74
		public unsafe UChildActorComponent editorTicker
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSCloth_DynamicPin_C.__PropertyOffset_16);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSCloth_DynamicPin_C.__PropertyOffset_16, value);
			}
		}

		// Token: 0x17004331 RID: 17201
		// (get) Token: 0x06022DED RID: 142829 RVA: 0x00971889 File Offset: 0x0096FA89
		// (set) Token: 0x06022DEE RID: 142830 RVA: 0x00971899 File Offset: 0x0096FA99
		public unsafe bool bEnable
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_C.__PropertyOffset_17) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_C.__PropertyOffset_17) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004332 RID: 17202
		// (get) Token: 0x06022DEF RID: 142831 RVA: 0x009718AA File Offset: 0x0096FAAA
		// (set) Token: 0x06022DF0 RID: 142832 RVA: 0x009718BA File Offset: 0x0096FABA
		public unsafe int Substep_Count
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x17004333 RID: 17203
		// (get) Token: 0x06022DF1 RID: 142833 RVA: 0x009718CB File Offset: 0x0096FACB
		// (set) Token: 0x06022DF2 RID: 142834 RVA: 0x009718DB File Offset: 0x0096FADB
		public unsafe bool InitOverlap
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_C.__PropertyOffset_19) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_C.__PropertyOffset_19) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004334 RID: 17204
		// (get) Token: 0x06022DF3 RID: 142835 RVA: 0x009718EC File Offset: 0x0096FAEC
		// (set) Token: 0x06022DF4 RID: 142836 RVA: 0x009718FC File Offset: 0x0096FAFC
		public unsafe bool bFadeOut
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_C.__PropertyOffset_20) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_C.__PropertyOffset_20) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004335 RID: 17205
		// (get) Token: 0x06022DF5 RID: 142837 RVA: 0x0097190D File Offset: 0x0096FB0D
		// (set) Token: 0x06022DF6 RID: 142838 RVA: 0x0097191D File Offset: 0x0096FB1D
		public unsafe float FadeOut
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x17004336 RID: 17206
		// (get) Token: 0x06022DF7 RID: 142839 RVA: 0x0097192E File Offset: 0x0096FB2E
		// (set) Token: 0x06022DF8 RID: 142840 RVA: 0x0097193E File Offset: 0x0096FB3E
		public unsafe bool bStopSim
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_C.__PropertyOffset_22) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_C.__PropertyOffset_22) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004337 RID: 17207
		// (get) Token: 0x06022DF9 RID: 142841 RVA: 0x0097194F File Offset: 0x0096FB4F
		// (set) Token: 0x06022DFA RID: 142842 RVA: 0x0097195F File Offset: 0x0096FB5F
		public unsafe bool bInit
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_C.__PropertyOffset_23) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_C.__PropertyOffset_23) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004338 RID: 17208
		// (get) Token: 0x06022DFB RID: 142843 RVA: 0x00971970 File Offset: 0x0096FB70
		// (set) Token: 0x06022DFC RID: 142844 RVA: 0x009719A9 File Offset: 0x0096FBA9
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
					result = (this._Scalar_Parameters = new TMap<FName, float>(base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_C.__PropertyOffset_24, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Scalar_Parameters.CopyAssign(value);
			}
		}

		// Token: 0x17004339 RID: 17209
		// (get) Token: 0x06022DFD RID: 142845 RVA: 0x009719B8 File Offset: 0x0096FBB8
		// (set) Token: 0x06022DFE RID: 142846 RVA: 0x009719F1 File Offset: 0x0096FBF1
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
					result = (this._Vector_Parameters = new TMap<FName, FLinearColor>(base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_C.__PropertyOffset_25, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Vector_Parameters.CopyAssign(value);
			}
		}

		// Token: 0x1700433A RID: 17210
		// (get) Token: 0x06022DFF RID: 142847 RVA: 0x00971A00 File Offset: 0x0096FC00
		// (set) Token: 0x06022E00 RID: 142848 RVA: 0x00971A39 File Offset: 0x0096FC39
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
					result = (this._Texture_Parameters = new TMap<FName, UTexture>(base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_C.__PropertyOffset_26, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Texture_Parameters.CopyAssign(value);
			}
		}

		// Token: 0x1700433B RID: 17211
		// (get) Token: 0x06022E01 RID: 142849 RVA: 0x00971A47 File Offset: 0x0096FC47
		// (set) Token: 0x06022E02 RID: 142850 RVA: 0x00971A5B File Offset: 0x0096FC5B
		public unsafe FTransformDouble Transform
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_C.__PropertyOffset_27);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_C.__PropertyOffset_27) = value;
			}
		}

		// Token: 0x1700433C RID: 17212
		// (get) Token: 0x06022E03 RID: 142851 RVA: 0x00971A70 File Offset: 0x0096FC70
		// (set) Token: 0x06022E04 RID: 142852 RVA: 0x00971A80 File Offset: 0x0096FC80
		public unsafe int Substep_CountRaw
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_C.__PropertyOffset_28);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_C.__PropertyOffset_28) = value;
			}
		}

		// Token: 0x06022E05 RID: 142853 RVA: 0x00971A91 File Offset: 0x0096FC91
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateMaterialParams()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCSCloth_DynamicPin_C.__UpdateMaterialParams_NativeFunctionPtr, null);
		}

		// Token: 0x06022E06 RID: 142854 RVA: 0x00971AA5 File Offset: 0x0096FCA5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void StopSim()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCSCloth_DynamicPin_C.__StopSim_NativeFunctionPtr, null);
		}

		// Token: 0x06022E07 RID: 142855 RVA: 0x00971AB9 File Offset: 0x0096FCB9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void StartSim()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCSCloth_DynamicPin_C.__StartSim_NativeFunctionPtr, null);
		}

		// Token: 0x06022E08 RID: 142856 RVA: 0x00971ACD File Offset: 0x0096FCCD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void InitRT()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCSCloth_DynamicPin_C.__InitRT_NativeFunctionPtr, null);
		}

		// Token: 0x06022E09 RID: 142857 RVA: 0x00971AE1 File Offset: 0x0096FCE1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void InitMats()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCSCloth_DynamicPin_C.__InitMats_NativeFunctionPtr, null);
		}

		// Token: 0x06022E0A RID: 142858 RVA: 0x00971AF5 File Offset: 0x0096FCF5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void FitToBridge()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCSCloth_DynamicPin_C.__FitToBridge_NativeFunctionPtr, null);
		}

		// Token: 0x06022E0B RID: 142859 RVA: 0x00971B09 File Offset: 0x0096FD09
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void DrawDeformPoints()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCSCloth_DynamicPin_C.__DrawDeformPoints_NativeFunctionPtr, null);
		}

		// Token: 0x06022E0C RID: 142860 RVA: 0x00971B20 File Offset: 0x0096FD20
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SyncPos(USceneComponent From, USceneComponent To)
		{
			BP_KuroCSCloth_DynamicPin_C.__SyncPos_FunctionParams* ptr = stackalloc BP_KuroCSCloth_DynamicPin_C.__SyncPos_FunctionParams[(UIntPtr)215] + 15L / (long)sizeof(BP_KuroCSCloth_DynamicPin_C.__SyncPos_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroCSCloth_DynamicPin_C.__SyncPos_NativeFunctionPtr, (void*)ptr, 1);
			ptr->From = ((From != null) ? From.NativePtr : IntPtr.Zero);
			ptr->To = ((To != null) ? To.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCSCloth_DynamicPin_C.__SyncPos_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022E0D RID: 142861 RVA: 0x00971B8E File Offset: 0x0096FD8E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SyncToBindPin()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCSCloth_DynamicPin_C.__SyncToBindPin_NativeFunctionPtr, null);
		}

		// Token: 0x06022E0E RID: 142862 RVA: 0x00971BA2 File Offset: 0x0096FDA2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void DrawAndSetPin()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCSCloth_DynamicPin_C.__DrawAndSetPin_NativeFunctionPtr, null);
		}

		// Token: 0x06022E0F RID: 142863 RVA: 0x00971BB6 File Offset: 0x0096FDB6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCSCloth_DynamicPin_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06022E10 RID: 142864 RVA: 0x00971BCA File Offset: 0x0096FDCA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroCSCloth_DynamicPin_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06022E11 RID: 142865 RVA: 0x00971BDF File Offset: 0x0096FDDF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCSCloth_DynamicPin_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06022E12 RID: 142866 RVA: 0x00971BF3 File Offset: 0x0096FDF3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroCSCloth_DynamicPin_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06022E13 RID: 142867 RVA: 0x00971C08 File Offset: 0x0096FE08
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_KuroCSCloth_DynamicPin_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_KuroCSCloth_DynamicPin_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_KuroCSCloth_DynamicPin_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroCSCloth_DynamicPin_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCSCloth_DynamicPin_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022E14 RID: 142868 RVA: 0x00971C50 File Offset: 0x0096FE50
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_KuroCSCloth_DynamicPin_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_KuroCSCloth_DynamicPin_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_KuroCSCloth_DynamicPin_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroCSCloth_DynamicPin_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroCSCloth_DynamicPin_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06022E15 RID: 142869 RVA: 0x00971C97 File Offset: 0x0096FE97
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EditorTick()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCSCloth_DynamicPin_C.__EditorTick_NativeFunctionPtr, null);
		}

		// Token: 0x06022E16 RID: 142870 RVA: 0x00971CAC File Offset: 0x0096FEAC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveEndPlay(EEndPlayReason EndPlayReason)
		{
			BP_KuroCSCloth_DynamicPin_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_KuroCSCloth_DynamicPin_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_KuroCSCloth_DynamicPin_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroCSCloth_DynamicPin_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCSCloth_DynamicPin_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022E17 RID: 142871 RVA: 0x00971CF8 File Offset: 0x0096FEF8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveEndPlay_Implementation(EEndPlayReason EndPlayReason)
		{
			BP_KuroCSCloth_DynamicPin_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_KuroCSCloth_DynamicPin_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_KuroCSCloth_DynamicPin_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroCSCloth_DynamicPin_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroCSCloth_DynamicPin_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06022E18 RID: 142872 RVA: 0x00971D44 File Offset: 0x0096FF44
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_KuroCSCloth_DynamicPin_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex, bool bFromSweep, in FHitResult SweepResult)
		{
			BP_KuroCSCloth_DynamicPin_C.__BndEvt__BP_KuroCSCloth_DynamicPin_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_KuroCSCloth_DynamicPin_C.__BndEvt__BP_KuroCSCloth_DynamicPin_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(BP_KuroCSCloth_DynamicPin_C.__BndEvt__BP_KuroCSCloth_DynamicPin_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroCSCloth_DynamicPin_C.__BndEvt__BP_KuroCSCloth_DynamicPin_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			ptr->bFromSweep = bFromSweep;
			if (SweepResult != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FHitResult.StaticStruct(), &ptr->SweepResult, SweepResult.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCSCloth_DynamicPin_C.__BndEvt__BP_KuroCSCloth_DynamicPin_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022E19 RID: 142873 RVA: 0x00971E00 File Offset: 0x00970000
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_KuroCSCloth_DynamicPin_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex)
		{
			BP_KuroCSCloth_DynamicPin_C.__BndEvt__BP_KuroCSCloth_DynamicPin_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_KuroCSCloth_DynamicPin_C.__BndEvt__BP_KuroCSCloth_DynamicPin_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_KuroCSCloth_DynamicPin_C.__BndEvt__BP_KuroCSCloth_DynamicPin_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroCSCloth_DynamicPin_C.__BndEvt__BP_KuroCSCloth_DynamicPin_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCSCloth_DynamicPin_C.__BndEvt__BP_KuroCSCloth_DynamicPin_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022E1A RID: 142874 RVA: 0x00971E8C File Offset: 0x0097008C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_KuroCSCloth_DynamicPin(int EntryPoint)
		{
			BP_KuroCSCloth_DynamicPin_C.__ExecuteUbergraph_BP_KuroCSCloth_DynamicPin_FunctionParams* ptr = stackalloc BP_KuroCSCloth_DynamicPin_C.__ExecuteUbergraph_BP_KuroCSCloth_DynamicPin_FunctionParams[(UIntPtr)1535] + 15L / (long)sizeof(BP_KuroCSCloth_DynamicPin_C.__ExecuteUbergraph_BP_KuroCSCloth_DynamicPin_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroCSCloth_DynamicPin_C.__ExecuteUbergraph_BP_KuroCSCloth_DynamicPin_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroCSCloth_DynamicPin_C.__ExecuteUbergraph_BP_KuroCSCloth_DynamicPin_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06022E1B RID: 142875 RVA: 0x00971ED6 File Offset: 0x009700D6
		protected BP_KuroCSCloth_DynamicPin_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04011B28 RID: 72488
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/KuroCS/ClothDynamicPin/BP_KuroCSCloth_DynamicPin.BP_KuroCSCloth_DynamicPin_C";

		// Token: 0x04011B29 RID: 72489
		private static IntPtr _ClassPtr;

		// Token: 0x04011B2A RID: 72490
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04011B2B RID: 72491
		internal static int __PropertyOffset_0;

		// Token: 0x04011B2C RID: 72492
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04011B2D RID: 72493
		internal static int __PropertyOffset_1;

		// Token: 0x04011B2E RID: 72494
		internal static int __PropertyOffset_2;

		// Token: 0x04011B2F RID: 72495
		internal static int __PropertyOffset_3;

		// Token: 0x04011B30 RID: 72496
		internal static int __PropertyOffset_4;

		// Token: 0x04011B31 RID: 72497
		internal static int __PropertyOffset_5;

		// Token: 0x04011B32 RID: 72498
		internal static int __PropertyOffset_6;

		// Token: 0x04011B33 RID: 72499
		internal static int __PropertyOffset_7;

		// Token: 0x04011B34 RID: 72500
		internal static int __PropertyOffset_8;

		// Token: 0x04011B35 RID: 72501
		internal static int __PropertyOffset_9;

		// Token: 0x04011B36 RID: 72502
		internal static int __PropertyOffset_10;

		// Token: 0x04011B37 RID: 72503
		internal static int __PropertyOffset_11;

		// Token: 0x04011B38 RID: 72504
		internal static int __PropertyOffset_12;

		// Token: 0x04011B39 RID: 72505
		internal static int __PropertyOffset_13;

		// Token: 0x04011B3A RID: 72506
		internal static int __PropertyOffset_14;

		// Token: 0x04011B3B RID: 72507
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UMaterialInstanceDynamic> _Mats;

		// Token: 0x04011B3C RID: 72508
		internal static int __PropertyOffset_15;

		// Token: 0x04011B3D RID: 72509
		internal static int __PropertyOffset_16;

		// Token: 0x04011B3E RID: 72510
		internal static int __PropertyOffset_17;

		// Token: 0x04011B3F RID: 72511
		internal static int __PropertyOffset_18;

		// Token: 0x04011B40 RID: 72512
		internal static int __PropertyOffset_19;

		// Token: 0x04011B41 RID: 72513
		internal static int __PropertyOffset_20;

		// Token: 0x04011B42 RID: 72514
		internal static int __PropertyOffset_21;

		// Token: 0x04011B43 RID: 72515
		internal static int __PropertyOffset_22;

		// Token: 0x04011B44 RID: 72516
		internal static int __PropertyOffset_23;

		// Token: 0x04011B45 RID: 72517
		internal static int __PropertyOffset_24;

		// Token: 0x04011B46 RID: 72518
		private TMap<FName, float> _Scalar_Parameters;

		// Token: 0x04011B47 RID: 72519
		internal static int __PropertyOffset_25;

		// Token: 0x04011B48 RID: 72520
		private TMap<FName, FLinearColor> _Vector_Parameters;

		// Token: 0x04011B49 RID: 72521
		internal static int __PropertyOffset_26;

		// Token: 0x04011B4A RID: 72522
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<FName, UTexture> _Texture_Parameters;

		// Token: 0x04011B4B RID: 72523
		internal static int __PropertyOffset_27;

		// Token: 0x04011B4C RID: 72524
		internal static int __PropertyOffset_28;

		// Token: 0x04011B4D RID: 72525
		private static IntPtr __UpdateMaterialParams_NativeFunctionPtr;

		// Token: 0x04011B4E RID: 72526
		private static IntPtr __StopSim_NativeFunctionPtr;

		// Token: 0x04011B4F RID: 72527
		private static IntPtr __StartSim_NativeFunctionPtr;

		// Token: 0x04011B50 RID: 72528
		private static IntPtr __InitRT_NativeFunctionPtr;

		// Token: 0x04011B51 RID: 72529
		private static IntPtr __InitMats_NativeFunctionPtr;

		// Token: 0x04011B52 RID: 72530
		private static IntPtr __FitToBridge_NativeFunctionPtr;

		// Token: 0x04011B53 RID: 72531
		private static IntPtr __DrawDeformPoints_NativeFunctionPtr;

		// Token: 0x04011B54 RID: 72532
		private static IntPtr __SyncPos_NativeFunctionPtr;

		// Token: 0x04011B55 RID: 72533
		private static IntPtr __SyncToBindPin_NativeFunctionPtr;

		// Token: 0x04011B56 RID: 72534
		private static IntPtr __DrawAndSetPin_NativeFunctionPtr;

		// Token: 0x04011B57 RID: 72535
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04011B58 RID: 72536
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04011B59 RID: 72537
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04011B5A RID: 72538
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x04011B5B RID: 72539
		private static IntPtr __ReceiveEndPlay_NativeFunctionPtr;

		// Token: 0x04011B5C RID: 72540
		private static IntPtr __BndEvt__BP_KuroCSCloth_DynamicPin_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04011B5D RID: 72541
		private static IntPtr __BndEvt__BP_KuroCSCloth_DynamicPin_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04011B5E RID: 72542
		private static IntPtr __ExecuteUbergraph_BP_KuroCSCloth_DynamicPin_NativeFunctionPtr;

		// Token: 0x02009C3E RID: 39998
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 200)]
		protected ref struct __SyncPos_FunctionParams
		{
			// Token: 0x040324DA RID: 206042
			[FieldOffset(0)]
			public IntPtr From;

			// Token: 0x040324DB RID: 206043
			[FieldOffset(8)]
			public IntPtr To;
		}

		// Token: 0x02009C3F RID: 39999
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x040324DC RID: 206044
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009C40 RID: 40000
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __ReceiveEndPlay_FunctionParams
		{
			// Token: 0x040324DD RID: 206045
			[FieldOffset(0)]
			public TEnumAsByte<EEndPlayReason> EndPlayReason;
		}

		// Token: 0x02009C41 RID: 40001
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __BndEvt__BP_KuroCSCloth_DynamicPin_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x040324DE RID: 206046
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x040324DF RID: 206047
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x040324E0 RID: 206048
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x040324E1 RID: 206049
			[FieldOffset(24)]
			public int OtherBodyIndex;

			// Token: 0x040324E2 RID: 206050
			[FieldOffset(28)]
			public bool bFromSweep;

			// Token: 0x040324E3 RID: 206051
			[FieldOffset(32)]
			public byte SweepResult;
		}

		// Token: 0x02009C42 RID: 40002
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __BndEvt__BP_KuroCSCloth_DynamicPin_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x040324E4 RID: 206052
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x040324E5 RID: 206053
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x040324E6 RID: 206054
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x040324E7 RID: 206055
			[FieldOffset(24)]
			public int OtherBodyIndex;
		}

		// Token: 0x02009C43 RID: 40003
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1520)]
		protected ref struct __ExecuteUbergraph_BP_KuroCSCloth_DynamicPin_FunctionParams
		{
			// Token: 0x040324E8 RID: 206056
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
