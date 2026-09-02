using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Data.Effect.Struct;
using AkiClient.Game.Aki.Render.RuntimeBP.Effect.Data;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Effect
{
	// Token: 0x02003D1D RID: 15645
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Effect/BP_EffectActor.BP_EffectActor_C")]
	[UnrealStructLayout(1344, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1339)]
	public class BP_EffectActor_C : AKuroSceneEffectActor, IUnrealUObject, IUnrealObject, IBPI_EffectInterface_C, IUnrealBlueprintInterface, IUnrealInterface
	{
		// Token: 0x06025CF3 RID: 154867 RVA: 0x009C5AEF File Offset: 0x009C3CEF
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_EffectActor_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Effect/BP_EffectActor.BP_EffectActor_C");
			}
			return BP_EffectActor_C._ClassPtr;
		}

		// Token: 0x06025CF4 RID: 154868 RVA: 0x009C5B14 File Offset: 0x009C3D14
		public BP_EffectActor_C() : this(BuiltinUtils.AllocNativeUObject(BP_EffectActor_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06025CF5 RID: 154869 RVA: 0x009C5B3C File Offset: 0x009C3D3C
		public BP_EffectActor_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_EffectActor_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170053DA RID: 21466
		// (get) Token: 0x06025CF6 RID: 154870 RVA: 0x009C5B70 File Offset: 0x009C3D70
		// (set) Token: 0x06025CF7 RID: 154871 RVA: 0x009C5BA9 File Offset: 0x009C3DA9
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_EffectActor_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_EffectActor_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170053DB RID: 21467
		// (get) Token: 0x06025CF8 RID: 154872 RVA: 0x009C5BCA File Offset: 0x009C3DCA
		// (set) Token: 0x06025CF9 RID: 154873 RVA: 0x009C5BDE File Offset: 0x009C3DDE
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_EffectActor_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_EffectActor_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170053DC RID: 21468
		// (get) Token: 0x06025CFA RID: 154874 RVA: 0x009C5BF4 File Offset: 0x009C3DF4
		// (set) Token: 0x06025CFB RID: 154875 RVA: 0x009C5C2D File Offset: 0x009C3E2D
		public FSoftObjectPath EffectData
		{
			get
			{
				base.FastCheckIsValid();
				FSoftObjectPath result;
				if ((result = this._EffectData) == null)
				{
					result = (this._EffectData = new FSoftObjectPath(base.NativePtr + (IntPtr)BP_EffectActor_C.__PropertyOffset_2, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FSoftObjectPath.StaticStruct(), base.NativePtr + (IntPtr)BP_EffectActor_C.__PropertyOffset_2, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170053DD RID: 21469
		// (get) Token: 0x06025CFC RID: 154876 RVA: 0x009C5C4E File Offset: 0x009C3E4E
		// (set) Token: 0x06025CFD RID: 154877 RVA: 0x009C5C5E File Offset: 0x009C3E5E
		public unsafe bool DebugPrintOnConstruction
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectActor_C.__PropertyOffset_3) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectActor_C.__PropertyOffset_3) = (value ? 1 : 0);
			}
		}

		// Token: 0x170053DE RID: 21470
		// (get) Token: 0x06025CFE RID: 154878 RVA: 0x009C5C6F File Offset: 0x009C3E6F
		// (set) Token: 0x06025CFF RID: 154879 RVA: 0x009C5C7F File Offset: 0x009C3E7F
		public unsafe bool EditorTickWithoutSelected
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectActor_C.__PropertyOffset_4) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectActor_C.__PropertyOffset_4) = (value ? 1 : 0);
			}
		}

		// Token: 0x170053DF RID: 21471
		// (get) Token: 0x06025D00 RID: 154880 RVA: 0x009C5C90 File Offset: 0x009C3E90
		// (set) Token: 0x06025D01 RID: 154881 RVA: 0x009C5CA0 File Offset: 0x009C3EA0
		public unsafe int EffectComponent
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectActor_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectActor_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x170053E0 RID: 21472
		// (get) Token: 0x06025D02 RID: 154882 RVA: 0x009C5CB1 File Offset: 0x009C3EB1
		// (set) Token: 0x06025D03 RID: 154883 RVA: 0x009C5CC5 File Offset: 0x009C3EC5
		[Nullable(0)]
		public unsafe TEnumAsByte<EEffectPlay> PlayType
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectActor_C.__PropertyOffset_6);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectActor_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x170053E1 RID: 21473
		// (get) Token: 0x06025D04 RID: 154884 RVA: 0x009C5CDA File Offset: 0x009C3EDA
		// (set) Token: 0x06025D05 RID: 154885 RVA: 0x009C5CEE File Offset: 0x009C3EEE
		[Nullable(0)]
		public unsafe TEnumAsByte<AkiClient.Game.Aki.Data.Effect.Struct.EEffectType> EffectType
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectActor_C.__PropertyOffset_7);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectActor_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x170053E2 RID: 21474
		// (get) Token: 0x06025D06 RID: 154886 RVA: 0x009C5D03 File Offset: 0x009C3F03
		// (set) Token: 0x06025D07 RID: 154887 RVA: 0x009C5D13 File Offset: 0x009C3F13
		public unsafe bool FirstTick
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectActor_C.__PropertyOffset_8) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectActor_C.__PropertyOffset_8) = (value ? 1 : 0);
			}
		}

		// Token: 0x170053E3 RID: 21475
		// (get) Token: 0x06025D08 RID: 154888 RVA: 0x009C5D24 File Offset: 0x009C3F24
		// (set) Token: 0x06025D09 RID: 154889 RVA: 0x009C5D34 File Offset: 0x009C3F34
		public unsafe bool 使用特效参数
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectActor_C.__PropertyOffset_9) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectActor_C.__PropertyOffset_9) = (value ? 1 : 0);
			}
		}

		// Token: 0x170053E4 RID: 21476
		// (get) Token: 0x06025D0A RID: 154890 RVA: 0x009C5D45 File Offset: 0x009C3F45
		// (set) Token: 0x06025D0B RID: 154891 RVA: 0x009C5D55 File Offset: 0x009C3F55
		public unsafe float 环境光影响强度覆盖
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectActor_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectActor_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x170053E5 RID: 21477
		// (get) Token: 0x06025D0C RID: 154892 RVA: 0x009C5D68 File Offset: 0x009C3F68
		// (set) Token: 0x06025D0D RID: 154893 RVA: 0x009C5DA1 File Offset: 0x009C3FA1
		public TArray<SEffectFloatParameter> 用户参数Float
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SEffectFloatParameter> result;
				if ((result = this._用户参数Float) == null)
				{
					result = (this._用户参数Float = new TArray<SEffectFloatParameter>(base.NativePtr + (IntPtr)BP_EffectActor_C.__PropertyOffset_11, this));
				}
				return result;
			}
			set
			{
				this.用户参数Float.CopyAssign(value);
			}
		}

		// Token: 0x170053E6 RID: 21478
		// (get) Token: 0x06025D0E RID: 154894 RVA: 0x009C5DB0 File Offset: 0x009C3FB0
		// (set) Token: 0x06025D0F RID: 154895 RVA: 0x009C5DE9 File Offset: 0x009C3FE9
		public TArray<SEffectColorParameter> 用户参数Color
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SEffectColorParameter> result;
				if ((result = this._用户参数Color) == null)
				{
					result = (this._用户参数Color = new TArray<SEffectColorParameter>(base.NativePtr + (IntPtr)BP_EffectActor_C.__PropertyOffset_12, this));
				}
				return result;
			}
			set
			{
				this.用户参数Color.CopyAssign(value);
			}
		}

		// Token: 0x170053E7 RID: 21479
		// (get) Token: 0x06025D10 RID: 154896 RVA: 0x009C5DF8 File Offset: 0x009C3FF8
		// (set) Token: 0x06025D11 RID: 154897 RVA: 0x009C5E31 File Offset: 0x009C4031
		public TArray<SEffectVectorParameter> 用户参数Vector
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SEffectVectorParameter> result;
				if ((result = this._用户参数Vector) == null)
				{
					result = (this._用户参数Vector = new TArray<SEffectVectorParameter>(base.NativePtr + (IntPtr)BP_EffectActor_C.__PropertyOffset_13, this));
				}
				return result;
			}
			set
			{
				this.用户参数Vector.CopyAssign(value);
			}
		}

		// Token: 0x170053E8 RID: 21480
		// (get) Token: 0x06025D12 RID: 154898 RVA: 0x009C5E40 File Offset: 0x009C4040
		// (set) Token: 0x06025D13 RID: 154899 RVA: 0x009C5E79 File Offset: 0x009C4079
		public TArray<SEffectFloatParameter> 材质参数Float
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SEffectFloatParameter> result;
				if ((result = this._材质参数Float) == null)
				{
					result = (this._材质参数Float = new TArray<SEffectFloatParameter>(base.NativePtr + (IntPtr)BP_EffectActor_C.__PropertyOffset_14, this));
				}
				return result;
			}
			set
			{
				this.材质参数Float.CopyAssign(value);
			}
		}

		// Token: 0x170053E9 RID: 21481
		// (get) Token: 0x06025D14 RID: 154900 RVA: 0x009C5E88 File Offset: 0x009C4088
		// (set) Token: 0x06025D15 RID: 154901 RVA: 0x009C5EC1 File Offset: 0x009C40C1
		public TArray<SEffectColorParameter> 材质参数Color
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SEffectColorParameter> result;
				if ((result = this._材质参数Color) == null)
				{
					result = (this._材质参数Color = new TArray<SEffectColorParameter>(base.NativePtr + (IntPtr)BP_EffectActor_C.__PropertyOffset_15, this));
				}
				return result;
			}
			set
			{
				this.材质参数Color.CopyAssign(value);
			}
		}

		// Token: 0x170053EA RID: 21482
		// (get) Token: 0x06025D16 RID: 154902 RVA: 0x009C5ED0 File Offset: 0x009C40D0
		// (set) Token: 0x06025D17 RID: 154903 RVA: 0x009C5F09 File Offset: 0x009C4109
		public TArray<SEffectFloatParameter> 材质参数Float_Temp
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SEffectFloatParameter> result;
				if ((result = this._材质参数Float_Temp) == null)
				{
					result = (this._材质参数Float_Temp = new TArray<SEffectFloatParameter>(base.NativePtr + (IntPtr)BP_EffectActor_C.__PropertyOffset_16, this));
				}
				return result;
			}
			set
			{
				this.材质参数Float_Temp.CopyAssign(value);
			}
		}

		// Token: 0x170053EB RID: 21483
		// (get) Token: 0x06025D18 RID: 154904 RVA: 0x009C5F17 File Offset: 0x009C4117
		// (set) Token: 0x06025D19 RID: 154905 RVA: 0x009C5F27 File Offset: 0x009C4127
		public unsafe bool UsedInBossFight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectActor_C.__PropertyOffset_17) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectActor_C.__PropertyOffset_17) = (value ? 1 : 0);
			}
		}

		// Token: 0x170053EC RID: 21484
		// (get) Token: 0x06025D1A RID: 154906 RVA: 0x009C5F38 File Offset: 0x009C4138
		// (set) Token: 0x06025D1B RID: 154907 RVA: 0x009C5F48 File Offset: 0x009C4148
		public unsafe bool ShouldBePlaying
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectActor_C.__PropertyOffset_18) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectActor_C.__PropertyOffset_18) = (value ? 1 : 0);
			}
		}

		// Token: 0x170053ED RID: 21485
		// (get) Token: 0x06025D1C RID: 154908 RVA: 0x009C5F59 File Offset: 0x009C4159
		// (set) Token: 0x06025D1D RID: 154909 RVA: 0x009C5F69 File Offset: 0x009C4169
		public unsafe bool OpenVisibilityOptimize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectActor_C.__PropertyOffset_19) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectActor_C.__PropertyOffset_19) = (value ? 1 : 0);
			}
		}

		// Token: 0x170053EE RID: 21486
		// (get) Token: 0x06025D1E RID: 154910 RVA: 0x009C5F7A File Offset: 0x009C417A
		// (set) Token: 0x06025D1F RID: 154911 RVA: 0x009C5F8A File Offset: 0x009C418A
		public unsafe bool ForceStoppingTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectActor_C.__PropertyOffset_20) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectActor_C.__PropertyOffset_20) = (value ? 1 : 0);
			}
		}

		// Token: 0x170053EF RID: 21487
		// (get) Token: 0x06025D20 RID: 154912 RVA: 0x009C5F9B File Offset: 0x009C419B
		// (set) Token: 0x06025D21 RID: 154913 RVA: 0x009C5FAB File Offset: 0x009C41AB
		public unsafe bool IgnoreStoppingTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectActor_C.__PropertyOffset_21) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectActor_C.__PropertyOffset_21) = (value ? 1 : 0);
			}
		}

		// Token: 0x170053F0 RID: 21488
		// (get) Token: 0x06025D22 RID: 154914 RVA: 0x009C5FBC File Offset: 0x009C41BC
		// (set) Token: 0x06025D23 RID: 154915 RVA: 0x009C5FCC File Offset: 0x009C41CC
		public unsafe bool MobileOnly
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectActor_C.__PropertyOffset_22) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectActor_C.__PropertyOffset_22) = (value ? 1 : 0);
			}
		}

		// Token: 0x170053F1 RID: 21489
		// (get) Token: 0x06025D24 RID: 154916 RVA: 0x009C5FDD File Offset: 0x009C41DD
		// (set) Token: 0x06025D25 RID: 154917 RVA: 0x009C5FED File Offset: 0x009C41ED
		public unsafe float CustomProcess
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectActor_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectActor_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x170053F2 RID: 21490
		// (get) Token: 0x06025D26 RID: 154918 RVA: 0x009C5FFE File Offset: 0x009C41FE
		// (set) Token: 0x06025D27 RID: 154919 RVA: 0x009C600E File Offset: 0x009C420E
		public unsafe bool IsSimulateFromSequence
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectActor_C.__PropertyOffset_24) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectActor_C.__PropertyOffset_24) = (value ? 1 : 0);
			}
		}

		// Token: 0x170053F3 RID: 21491
		// (get) Token: 0x06025D28 RID: 154920 RVA: 0x009C601F File Offset: 0x009C421F
		// (set) Token: 0x06025D29 RID: 154921 RVA: 0x009C602F File Offset: 0x009C422F
		public unsafe bool IsPublicToSequence
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectActor_C.__PropertyOffset_25) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectActor_C.__PropertyOffset_25) = (value ? 1 : 0);
			}
		}

		// Token: 0x170053F4 RID: 21492
		// (get) Token: 0x06025D2A RID: 154922 RVA: 0x009C6040 File Offset: 0x009C4240
		// (set) Token: 0x06025D2B RID: 154923 RVA: 0x009C6050 File Offset: 0x009C4250
		public unsafe float FloatParameter0
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectActor_C.__PropertyOffset_26);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectActor_C.__PropertyOffset_26) = value;
			}
		}

		// Token: 0x170053F5 RID: 21493
		// (get) Token: 0x06025D2C RID: 154924 RVA: 0x009C6061 File Offset: 0x009C4261
		// (set) Token: 0x06025D2D RID: 154925 RVA: 0x009C6071 File Offset: 0x009C4271
		public unsafe float FloatParameter1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectActor_C.__PropertyOffset_27);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectActor_C.__PropertyOffset_27) = value;
			}
		}

		// Token: 0x170053F6 RID: 21494
		// (get) Token: 0x06025D2E RID: 154926 RVA: 0x009C6082 File Offset: 0x009C4282
		// (set) Token: 0x06025D2F RID: 154927 RVA: 0x009C6092 File Offset: 0x009C4292
		public unsafe float FloatParameter2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectActor_C.__PropertyOffset_28);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectActor_C.__PropertyOffset_28) = value;
			}
		}

		// Token: 0x170053F7 RID: 21495
		// (get) Token: 0x06025D30 RID: 154928 RVA: 0x009C60A3 File Offset: 0x009C42A3
		// (set) Token: 0x06025D31 RID: 154929 RVA: 0x009C60B7 File Offset: 0x009C42B7
		public unsafe string FloatParameterName0
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)BP_EffectActor_C.__PropertyOffset_29)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)BP_EffectActor_C.__PropertyOffset_29)), value);
			}
		}

		// Token: 0x170053F8 RID: 21496
		// (get) Token: 0x06025D32 RID: 154930 RVA: 0x009C60CC File Offset: 0x009C42CC
		// (set) Token: 0x06025D33 RID: 154931 RVA: 0x009C60E0 File Offset: 0x009C42E0
		public unsafe string FloatParameterName1
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)BP_EffectActor_C.__PropertyOffset_30)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)BP_EffectActor_C.__PropertyOffset_30)), value);
			}
		}

		// Token: 0x170053F9 RID: 21497
		// (get) Token: 0x06025D34 RID: 154932 RVA: 0x009C60F5 File Offset: 0x009C42F5
		// (set) Token: 0x06025D35 RID: 154933 RVA: 0x009C6109 File Offset: 0x009C4309
		public unsafe string FloatParameterName2
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)BP_EffectActor_C.__PropertyOffset_31)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)BP_EffectActor_C.__PropertyOffset_31)), value);
			}
		}

		// Token: 0x170053FA RID: 21498
		// (get) Token: 0x06025D36 RID: 154934 RVA: 0x009C611E File Offset: 0x009C431E
		// (set) Token: 0x06025D37 RID: 154935 RVA: 0x009C6132 File Offset: 0x009C4332
		[Nullable(0)]
		public unsafe TEnumAsByte<EEffectPlay> EditorPlayType
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectActor_C.__PropertyOffset_32);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectActor_C.__PropertyOffset_32) = value;
			}
		}

		// Token: 0x170053FB RID: 21499
		// (get) Token: 0x06025D38 RID: 154936 RVA: 0x009C6147 File Offset: 0x009C4347
		// (set) Token: 0x06025D39 RID: 154937 RVA: 0x009C6157 File Offset: 0x009C4357
		public unsafe bool VisibleInRaytracing
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectActor_C.__PropertyOffset_33) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectActor_C.__PropertyOffset_33) = (value ? 1 : 0);
			}
		}

		// Token: 0x170053FC RID: 21500
		// (get) Token: 0x06025D3A RID: 154938 RVA: 0x009C6168 File Offset: 0x009C4368
		// (set) Token: 0x06025D3B RID: 154939 RVA: 0x009C6178 File Offset: 0x009C4378
		public unsafe bool InUIScene
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectActor_C.__PropertyOffset_34) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectActor_C.__PropertyOffset_34) = (value ? 1 : 0);
			}
		}

		// Token: 0x06025D3C RID: 154940 RVA: 0x009C618C File Offset: 0x009C438C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetHandle(ref int Handle)
		{
			BP_EffectActor_C.__GetHandle_FunctionParams* ptr = stackalloc BP_EffectActor_C.__GetHandle_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_EffectActor_C.__GetHandle_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_EffectActor_C.__GetHandle_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Handle = Handle;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_EffectActor_C.__GetHandle_NativeFunctionPtr, (void*)ptr);
			Handle = ptr->Handle;
		}

		// Token: 0x06025D3D RID: 154941 RVA: 0x009C61DC File Offset: 0x009C43DC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void AfterSpawnEffect(int EffectHandle)
		{
			BP_EffectActor_C.__AfterSpawnEffect_FunctionParams* ptr = stackalloc BP_EffectActor_C.__AfterSpawnEffect_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_EffectActor_C.__AfterSpawnEffect_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_EffectActor_C.__AfterSpawnEffect_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EffectHandle = EffectHandle;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_EffectActor_C.__AfterSpawnEffect_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025D3E RID: 154942 RVA: 0x009C6224 File Offset: 0x009C4424
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override FBox GetStreamingBoundsEx()
		{
			BP_EffectActor_C.__GetStreamingBoundsEx_FunctionParams* ptr = stackalloc BP_EffectActor_C.__GetStreamingBoundsEx_FunctionParams[(UIntPtr)207] + 15L / (long)sizeof(BP_EffectActor_C.__GetStreamingBoundsEx_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_EffectActor_C.__GetStreamingBoundsEx_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_EffectActor_C.__GetStreamingBoundsEx_NativeFunctionPtr, (void*)ptr);
			return ptr->__Result;
		}

		// Token: 0x06025D3F RID: 154943 RVA: 0x009C626C File Offset: 0x009C446C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override FBox GetStreamingBoundsEx_Implementation()
		{
			BP_EffectActor_C.__GetStreamingBoundsEx_FunctionParams* ptr = stackalloc BP_EffectActor_C.__GetStreamingBoundsEx_FunctionParams[(UIntPtr)207] + 15L / (long)sizeof(BP_EffectActor_C.__GetStreamingBoundsEx_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_EffectActor_C.__GetStreamingBoundsEx_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_EffectActor_C.__GetStreamingBoundsEx_NativeFunctionPtr, (void*)ptr, 0);
			return ptr->__Result;
		}

		// Token: 0x06025D40 RID: 154944 RVA: 0x009C62B5 File Offset: 0x009C44B5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void StopEffect()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_EffectActor_C.__StopEffect_NativeFunctionPtr, null);
		}

		// Token: 0x06025D41 RID: 154945 RVA: 0x009C62C9 File Offset: 0x009C44C9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void PlayEffect()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_EffectActor_C.__PlayEffect_NativeFunctionPtr, null);
		}

		// Token: 0x06025D42 RID: 154946 RVA: 0x009C62E0 File Offset: 0x009C44E0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Play(string Reason)
		{
			BP_EffectActor_C.__Play_FunctionParams* ptr = stackalloc BP_EffectActor_C.__Play_FunctionParams[(UIntPtr)191] + 15L / (long)sizeof(BP_EffectActor_C.__Play_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_EffectActor_C.__Play_NativeFunctionPtr, (void*)ptr, 1);
			FString.CopyFrom((void*)(&ptr->Reason), Reason);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_EffectActor_C.__Play_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(BP_EffectActor_C.__Play_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06025D43 RID: 154947 RVA: 0x009C6340 File Offset: 0x009C4540
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual bool Stop(string Reason, bool Immediately)
		{
			BP_EffectActor_C.__Stop_FunctionParams* ptr = stackalloc BP_EffectActor_C.__Stop_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_EffectActor_C.__Stop_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_EffectActor_C.__Stop_NativeFunctionPtr, (void*)ptr, 1);
			FString.CopyFrom((void*)(&ptr->Reason), Reason);
			ptr->Immediately = Immediately;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_EffectActor_C.__Stop_NativeFunctionPtr, (void*)ptr);
			bool _Result = ptr->__Result;
			UnrealReflectionUtils.DestroyStruct(BP_EffectActor_C.__Stop_NativeFunctionPtr, (void*)ptr, 1);
			return _Result;
		}

		// Token: 0x06025D44 RID: 154948 RVA: 0x009C63AC File Offset: 0x009C45AC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void IsEditor(ref bool IsEditor)
		{
			BP_EffectActor_C.__IsEditor_FunctionParams* ptr = stackalloc BP_EffectActor_C.__IsEditor_FunctionParams[(UIntPtr)17] + 15L / (long)sizeof(BP_EffectActor_C.__IsEditor_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_EffectActor_C.__IsEditor_NativeFunctionPtr, (void*)ptr, 1);
			ptr->IsEditor = IsEditor;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_EffectActor_C.__IsEditor_NativeFunctionPtr, (void*)ptr);
			IsEditor = ptr->IsEditor;
		}

		// Token: 0x06025D45 RID: 154949 RVA: 0x009C63FB File Offset: 0x009C45FB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CalculateLifeTime()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_EffectActor_C.__CalculateLifeTime_NativeFunctionPtr, null);
		}

		// Token: 0x06025D46 RID: 154950 RVA: 0x009C640F File Offset: 0x009C460F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Refresh()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_EffectActor_C.__Refresh_NativeFunctionPtr, null);
		}

		// Token: 0x06025D47 RID: 154951 RVA: 0x009C6423 File Offset: 0x009C4623
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_EffectActor_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06025D48 RID: 154952 RVA: 0x009C6437 File Offset: 0x009C4637
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_EffectActor_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06025D49 RID: 154953 RVA: 0x009C644C File Offset: 0x009C464C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetHandle(int Handle)
		{
			BP_EffectActor_C.__SetHandle_FunctionParams* ptr = stackalloc BP_EffectActor_C.__SetHandle_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_EffectActor_C.__SetHandle_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_EffectActor_C.__SetHandle_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Handle = Handle;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_EffectActor_C.__SetHandle_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025D4A RID: 154954 RVA: 0x009C6492 File Offset: 0x009C4692
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void RemoveHandle()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_EffectActor_C.__RemoveHandle_NativeFunctionPtr, null);
		}

		// Token: 0x06025D4B RID: 154955 RVA: 0x009C64A6 File Offset: 0x009C46A6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_EffectActor_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06025D4C RID: 154956 RVA: 0x009C64BA File Offset: 0x009C46BA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_EffectActor_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06025D4D RID: 154957 RVA: 0x009C64D0 File Offset: 0x009C46D0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveEndPlay(EEndPlayReason EndPlayReason)
		{
			BP_EffectActor_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_EffectActor_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_EffectActor_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_EffectActor_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_EffectActor_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025D4E RID: 154958 RVA: 0x009C651C File Offset: 0x009C471C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveEndPlay_Implementation(EEndPlayReason EndPlayReason)
		{
			BP_EffectActor_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_EffectActor_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_EffectActor_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_EffectActor_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_EffectActor_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06025D4F RID: 154959 RVA: 0x009C6568 File Offset: 0x009C4768
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_EffectActor_C.__EditorTick_FunctionParams* ptr = stackalloc BP_EffectActor_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_EffectActor_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_EffectActor_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_EffectActor_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025D50 RID: 154960 RVA: 0x009C65B0 File Offset: 0x009C47B0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_EffectActor_C.__EditorTick_FunctionParams* ptr = stackalloc BP_EffectActor_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_EffectActor_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_EffectActor_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_EffectActor_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06025D51 RID: 154961 RVA: 0x009C65F8 File Offset: 0x009C47F8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void DoHiddenInGame(bool bValue)
		{
			BP_EffectActor_C.__DoHiddenInGame_FunctionParams* ptr = stackalloc BP_EffectActor_C.__DoHiddenInGame_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_EffectActor_C.__DoHiddenInGame_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_EffectActor_C.__DoHiddenInGame_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bValue = bValue;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_EffectActor_C.__DoHiddenInGame_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025D52 RID: 154962 RVA: 0x009C6640 File Offset: 0x009C4840
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void DoHiddenInGame_Implementation(bool bValue)
		{
			BP_EffectActor_C.__DoHiddenInGame_FunctionParams* ptr = stackalloc BP_EffectActor_C.__DoHiddenInGame_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_EffectActor_C.__DoHiddenInGame_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_EffectActor_C.__DoHiddenInGame_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bValue = bValue;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_EffectActor_C.__DoHiddenInGame_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06025D53 RID: 154963 RVA: 0x009C6687 File Offset: 0x009C4887
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void OnReceiveHideSceneEffectActor()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_EffectActor_C.__OnReceiveHideSceneEffectActor_NativeFunctionPtr, null);
		}

		// Token: 0x06025D54 RID: 154964 RVA: 0x009C669B File Offset: 0x009C489B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void OnReceiveHideSceneEffectActor_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_EffectActor_C.__OnReceiveHideSceneEffectActor_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06025D55 RID: 154965 RVA: 0x009C66B0 File Offset: 0x009C48B0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void OnReceiveShowSceneEffectActor()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_EffectActor_C.__OnReceiveShowSceneEffectActor_NativeFunctionPtr, null);
		}

		// Token: 0x06025D56 RID: 154966 RVA: 0x009C66C4 File Offset: 0x009C48C4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void OnReceiveShowSceneEffectActor_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_EffectActor_C.__OnReceiveShowSceneEffectActor_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06025D57 RID: 154967 RVA: 0x009C66D9 File Offset: 0x009C48D9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void EditorDestroy()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_EffectActor_C.__EditorDestroy_NativeFunctionPtr, null);
		}

		// Token: 0x06025D58 RID: 154968 RVA: 0x009C66ED File Offset: 0x009C48ED
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void EditorDestroy_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_EffectActor_C.__EditorDestroy_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06025D59 RID: 154969 RVA: 0x009C6704 File Offset: 0x009C4904
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_EffectActor(int EntryPoint)
		{
			BP_EffectActor_C.__ExecuteUbergraph_BP_EffectActor_FunctionParams* ptr = stackalloc BP_EffectActor_C.__ExecuteUbergraph_BP_EffectActor_FunctionParams[(UIntPtr)79] + 15L / (long)sizeof(BP_EffectActor_C.__ExecuteUbergraph_BP_EffectActor_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_EffectActor_C.__ExecuteUbergraph_BP_EffectActor_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_EffectActor_C.__ExecuteUbergraph_BP_EffectActor_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06025D5A RID: 154970 RVA: 0x009C674B File Offset: 0x009C494B
		protected BP_EffectActor_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04013897 RID: 80023
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Effect/BP_EffectActor.BP_EffectActor_C";

		// Token: 0x04013898 RID: 80024
		private static IntPtr _ClassPtr;

		// Token: 0x04013899 RID: 80025
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401389A RID: 80026
		internal static int __PropertyOffset_0;

		// Token: 0x0401389B RID: 80027
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0401389C RID: 80028
		internal static int __PropertyOffset_1;

		// Token: 0x0401389D RID: 80029
		internal static int __PropertyOffset_2;

		// Token: 0x0401389E RID: 80030
		[Nullable(2)]
		private FSoftObjectPath _EffectData;

		// Token: 0x0401389F RID: 80031
		internal static int __PropertyOffset_3;

		// Token: 0x040138A0 RID: 80032
		internal static int __PropertyOffset_4;

		// Token: 0x040138A1 RID: 80033
		internal static int __PropertyOffset_5;

		// Token: 0x040138A2 RID: 80034
		internal static int __PropertyOffset_6;

		// Token: 0x040138A3 RID: 80035
		internal static int __PropertyOffset_7;

		// Token: 0x040138A4 RID: 80036
		internal static int __PropertyOffset_8;

		// Token: 0x040138A5 RID: 80037
		internal static int __PropertyOffset_9;

		// Token: 0x040138A6 RID: 80038
		internal static int __PropertyOffset_10;

		// Token: 0x040138A7 RID: 80039
		internal static int __PropertyOffset_11;

		// Token: 0x040138A8 RID: 80040
		[Nullable(2)]
		private TArray<SEffectFloatParameter> _用户参数Float;

		// Token: 0x040138A9 RID: 80041
		internal static int __PropertyOffset_12;

		// Token: 0x040138AA RID: 80042
		[Nullable(2)]
		private TArray<SEffectColorParameter> _用户参数Color;

		// Token: 0x040138AB RID: 80043
		internal static int __PropertyOffset_13;

		// Token: 0x040138AC RID: 80044
		[Nullable(2)]
		private TArray<SEffectVectorParameter> _用户参数Vector;

		// Token: 0x040138AD RID: 80045
		internal static int __PropertyOffset_14;

		// Token: 0x040138AE RID: 80046
		[Nullable(2)]
		private TArray<SEffectFloatParameter> _材质参数Float;

		// Token: 0x040138AF RID: 80047
		internal static int __PropertyOffset_15;

		// Token: 0x040138B0 RID: 80048
		[Nullable(2)]
		private TArray<SEffectColorParameter> _材质参数Color;

		// Token: 0x040138B1 RID: 80049
		internal static int __PropertyOffset_16;

		// Token: 0x040138B2 RID: 80050
		[Nullable(2)]
		private TArray<SEffectFloatParameter> _材质参数Float_Temp;

		// Token: 0x040138B3 RID: 80051
		internal static int __PropertyOffset_17;

		// Token: 0x040138B4 RID: 80052
		internal static int __PropertyOffset_18;

		// Token: 0x040138B5 RID: 80053
		internal static int __PropertyOffset_19;

		// Token: 0x040138B6 RID: 80054
		internal static int __PropertyOffset_20;

		// Token: 0x040138B7 RID: 80055
		internal static int __PropertyOffset_21;

		// Token: 0x040138B8 RID: 80056
		internal static int __PropertyOffset_22;

		// Token: 0x040138B9 RID: 80057
		internal static int __PropertyOffset_23;

		// Token: 0x040138BA RID: 80058
		internal static int __PropertyOffset_24;

		// Token: 0x040138BB RID: 80059
		internal static int __PropertyOffset_25;

		// Token: 0x040138BC RID: 80060
		internal static int __PropertyOffset_26;

		// Token: 0x040138BD RID: 80061
		internal static int __PropertyOffset_27;

		// Token: 0x040138BE RID: 80062
		internal static int __PropertyOffset_28;

		// Token: 0x040138BF RID: 80063
		internal static int __PropertyOffset_29;

		// Token: 0x040138C0 RID: 80064
		internal static int __PropertyOffset_30;

		// Token: 0x040138C1 RID: 80065
		internal static int __PropertyOffset_31;

		// Token: 0x040138C2 RID: 80066
		internal static int __PropertyOffset_32;

		// Token: 0x040138C3 RID: 80067
		internal static int __PropertyOffset_33;

		// Token: 0x040138C4 RID: 80068
		internal static int __PropertyOffset_34;

		// Token: 0x040138C5 RID: 80069
		private static IntPtr __GetHandle_NativeFunctionPtr;

		// Token: 0x040138C6 RID: 80070
		private static IntPtr __AfterSpawnEffect_NativeFunctionPtr;

		// Token: 0x040138C7 RID: 80071
		private static IntPtr __GetStreamingBoundsEx_NativeFunctionPtr;

		// Token: 0x040138C8 RID: 80072
		private static IntPtr __StopEffect_NativeFunctionPtr;

		// Token: 0x040138C9 RID: 80073
		private static IntPtr __PlayEffect_NativeFunctionPtr;

		// Token: 0x040138CA RID: 80074
		private static IntPtr __Play_NativeFunctionPtr;

		// Token: 0x040138CB RID: 80075
		private static IntPtr __Stop_NativeFunctionPtr;

		// Token: 0x040138CC RID: 80076
		private static IntPtr __IsEditor_NativeFunctionPtr;

		// Token: 0x040138CD RID: 80077
		private static IntPtr __CalculateLifeTime_NativeFunctionPtr;

		// Token: 0x040138CE RID: 80078
		private static IntPtr __Refresh_NativeFunctionPtr;

		// Token: 0x040138CF RID: 80079
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x040138D0 RID: 80080
		private static IntPtr __SetHandle_NativeFunctionPtr;

		// Token: 0x040138D1 RID: 80081
		private static IntPtr __RemoveHandle_NativeFunctionPtr;

		// Token: 0x040138D2 RID: 80082
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x040138D3 RID: 80083
		private static IntPtr __ReceiveEndPlay_NativeFunctionPtr;

		// Token: 0x040138D4 RID: 80084
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x040138D5 RID: 80085
		private static IntPtr __DoHiddenInGame_NativeFunctionPtr;

		// Token: 0x040138D6 RID: 80086
		private static IntPtr __OnReceiveHideSceneEffectActor_NativeFunctionPtr;

		// Token: 0x040138D7 RID: 80087
		private static IntPtr __OnReceiveShowSceneEffectActor_NativeFunctionPtr;

		// Token: 0x040138D8 RID: 80088
		private static IntPtr __EditorDestroy_NativeFunctionPtr;

		// Token: 0x040138D9 RID: 80089
		private static IntPtr __ExecuteUbergraph_BP_EffectActor_NativeFunctionPtr;

		// Token: 0x02009FB8 RID: 40888
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __GetHandle_FunctionParams
		{
			// Token: 0x04032B6E RID: 207726
			[FieldOffset(0)]
			public int Handle;
		}

		// Token: 0x02009FB9 RID: 40889
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __AfterSpawnEffect_FunctionParams
		{
			// Token: 0x04032B6F RID: 207727
			[FieldOffset(0)]
			public int EffectHandle;
		}

		// Token: 0x02009FBA RID: 40890
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 192)]
		protected new ref struct __GetStreamingBoundsEx_FunctionParams
		{
			// Token: 0x04032B70 RID: 207728
			[FieldOffset(0)]
			public FBox __Result;
		}

		// Token: 0x02009FBB RID: 40891
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 176)]
		protected ref struct __Play_FunctionParams
		{
			// Token: 0x04032B71 RID: 207729
			[FieldOffset(0)]
			public FString Reason;
		}

		// Token: 0x02009FBC RID: 40892
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __Stop_FunctionParams
		{
			// Token: 0x04032B72 RID: 207730
			[FieldOffset(0)]
			public FString Reason;

			// Token: 0x04032B73 RID: 207731
			[FieldOffset(16)]
			public bool Immediately;

			// Token: 0x04032B74 RID: 207732
			[FieldOffset(17)]
			public bool __Result;
		}

		// Token: 0x02009FBD RID: 40893
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 2)]
		protected ref struct __IsEditor_FunctionParams
		{
			// Token: 0x04032B75 RID: 207733
			[FieldOffset(0)]
			public bool IsEditor;
		}

		// Token: 0x02009FBE RID: 40894
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __SetHandle_FunctionParams
		{
			// Token: 0x04032B76 RID: 207734
			[FieldOffset(0)]
			public int Handle;
		}

		// Token: 0x02009FBF RID: 40895
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __ReceiveEndPlay_FunctionParams
		{
			// Token: 0x04032B77 RID: 207735
			[FieldOffset(0)]
			public TEnumAsByte<EEndPlayReason> EndPlayReason;
		}

		// Token: 0x02009FC0 RID: 40896
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04032B78 RID: 207736
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009FC1 RID: 40897
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __DoHiddenInGame_FunctionParams
		{
			// Token: 0x04032B79 RID: 207737
			[FieldOffset(0)]
			public bool bValue;
		}

		// Token: 0x02009FC2 RID: 40898
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 64)]
		protected ref struct __ExecuteUbergraph_BP_EffectActor_FunctionParams
		{
			// Token: 0x04032B7A RID: 207738
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
