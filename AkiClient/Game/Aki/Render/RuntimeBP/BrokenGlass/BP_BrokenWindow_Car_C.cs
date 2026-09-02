using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Core.Fight;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.BrokenGlass
{
	// Token: 0x02003D9E RID: 15774
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/BrokenGlass/BP_BrokenWindow_Car.BP_BrokenWindow_Car_C")]
	[UnrealStructLayout(1680, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1680)]
	public class BP_BrokenWindow_Car_C : AKuroBPActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06026972 RID: 158066 RVA: 0x009DCB2B File Offset: 0x009DAD2B
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_BrokenWindow_Car_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/BrokenGlass/BP_BrokenWindow_Car.BP_BrokenWindow_Car_C");
			}
			return BP_BrokenWindow_Car_C._ClassPtr;
		}

		// Token: 0x06026973 RID: 158067 RVA: 0x009DCB50 File Offset: 0x009DAD50
		public BP_BrokenWindow_Car_C() : this(BuiltinUtils.AllocNativeUObject(BP_BrokenWindow_Car_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06026974 RID: 158068 RVA: 0x009DCB78 File Offset: 0x009DAD78
		[NullableContext(1)]
		public BP_BrokenWindow_Car_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_BrokenWindow_Car_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700582D RID: 22573
		// (get) Token: 0x06026975 RID: 158069 RVA: 0x009DCBAC File Offset: 0x009DADAC
		// (set) Token: 0x06026976 RID: 158070 RVA: 0x009DCBE5 File Offset: 0x009DADE5
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_BrokenWindow_Car_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_BrokenWindow_Car_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700582E RID: 22574
		// (get) Token: 0x06026977 RID: 158071 RVA: 0x009DCC06 File Offset: 0x009DAE06
		// (set) Token: 0x06026978 RID: 158072 RVA: 0x009DCC1A File Offset: 0x009DAE1A
		public unsafe UStaticMeshComponent WindowBack1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BrokenWindow_Car_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BrokenWindow_Car_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x1700582F RID: 22575
		// (get) Token: 0x06026979 RID: 158073 RVA: 0x009DCC2F File Offset: 0x009DAE2F
		// (set) Token: 0x0602697A RID: 158074 RVA: 0x009DCC43 File Offset: 0x009DAE43
		public unsafe UStaticMeshComponent WindowBack2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BrokenWindow_Car_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BrokenWindow_Car_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17005830 RID: 22576
		// (get) Token: 0x0602697B RID: 158075 RVA: 0x009DCC58 File Offset: 0x009DAE58
		// (set) Token: 0x0602697C RID: 158076 RVA: 0x009DCC6C File Offset: 0x009DAE6C
		public unsafe UStaticMeshComponent WindowRight
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BrokenWindow_Car_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BrokenWindow_Car_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17005831 RID: 22577
		// (get) Token: 0x0602697D RID: 158077 RVA: 0x009DCC81 File Offset: 0x009DAE81
		// (set) Token: 0x0602697E RID: 158078 RVA: 0x009DCC95 File Offset: 0x009DAE95
		public unsafe UStaticMeshComponent WindowLeft
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BrokenWindow_Car_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BrokenWindow_Car_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17005832 RID: 22578
		// (get) Token: 0x0602697F RID: 158079 RVA: 0x009DCCAA File Offset: 0x009DAEAA
		// (set) Token: 0x06026980 RID: 158080 RVA: 0x009DCCBE File Offset: 0x009DAEBE
		public unsafe UBoxComponent BackWindowColli2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BrokenWindow_Car_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BrokenWindow_Car_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17005833 RID: 22579
		// (get) Token: 0x06026981 RID: 158081 RVA: 0x009DCCD3 File Offset: 0x009DAED3
		// (set) Token: 0x06026982 RID: 158082 RVA: 0x009DCCE7 File Offset: 0x009DAEE7
		public unsafe UBoxComponent BackWindowColli1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BrokenWindow_Car_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BrokenWindow_Car_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x17005834 RID: 22580
		// (get) Token: 0x06026983 RID: 158083 RVA: 0x009DCCFC File Offset: 0x009DAEFC
		// (set) Token: 0x06026984 RID: 158084 RVA: 0x009DCD10 File Offset: 0x009DAF10
		public unsafe UBoxComponent FrontWindowColli2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BrokenWindow_Car_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BrokenWindow_Car_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x17005835 RID: 22581
		// (get) Token: 0x06026985 RID: 158085 RVA: 0x009DCD25 File Offset: 0x009DAF25
		// (set) Token: 0x06026986 RID: 158086 RVA: 0x009DCD39 File Offset: 0x009DAF39
		public unsafe UBoxComponent FrontWindowColli1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BrokenWindow_Car_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BrokenWindow_Car_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x17005836 RID: 22582
		// (get) Token: 0x06026987 RID: 158087 RVA: 0x009DCD4E File Offset: 0x009DAF4E
		// (set) Token: 0x06026988 RID: 158088 RVA: 0x009DCD62 File Offset: 0x009DAF62
		public unsafe UBoxComponent RightWindowColli
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BrokenWindow_Car_C.__PropertyOffset_9);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BrokenWindow_Car_C.__PropertyOffset_9, value);
			}
		}

		// Token: 0x17005837 RID: 22583
		// (get) Token: 0x06026989 RID: 158089 RVA: 0x009DCD77 File Offset: 0x009DAF77
		// (set) Token: 0x0602698A RID: 158090 RVA: 0x009DCD8B File Offset: 0x009DAF8B
		public unsafe UBoxComponent LeftWindowColli
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BrokenWindow_Car_C.__PropertyOffset_10);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BrokenWindow_Car_C.__PropertyOffset_10, value);
			}
		}

		// Token: 0x17005838 RID: 22584
		// (get) Token: 0x0602698B RID: 158091 RVA: 0x009DCDA0 File Offset: 0x009DAFA0
		// (set) Token: 0x0602698C RID: 158092 RVA: 0x009DCDB4 File Offset: 0x009DAFB4
		public unsafe UStaticMeshComponent SM_Com3_Car_05AL
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BrokenWindow_Car_C.__PropertyOffset_11);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BrokenWindow_Car_C.__PropertyOffset_11, value);
			}
		}

		// Token: 0x17005839 RID: 22585
		// (get) Token: 0x0602698D RID: 158093 RVA: 0x009DCDC9 File Offset: 0x009DAFC9
		// (set) Token: 0x0602698E RID: 158094 RVA: 0x009DCDDD File Offset: 0x009DAFDD
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BrokenWindow_Car_C.__PropertyOffset_12);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BrokenWindow_Car_C.__PropertyOffset_12, value);
			}
		}

		// Token: 0x1700583A RID: 22586
		// (get) Token: 0x0602698F RID: 158095 RVA: 0x009DCDF2 File Offset: 0x009DAFF2
		// (set) Token: 0x06026990 RID: 158096 RVA: 0x009DCE06 File Offset: 0x009DB006
		public unsafe FVector Size
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BrokenWindow_Car_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BrokenWindow_Car_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x1700583B RID: 22587
		// (get) Token: 0x06026991 RID: 158097 RVA: 0x009DCE1C File Offset: 0x009DB01C
		// (set) Token: 0x06026992 RID: 158098 RVA: 0x009DCE55 File Offset: 0x009DB055
		[Nullable(1)]
		public TArray<FVector> UVList
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<FVector> result;
				if ((result = this._UVList) == null)
				{
					result = (this._UVList = new TArray<FVector>(base.NativePtr + (IntPtr)BP_BrokenWindow_Car_C.__PropertyOffset_14, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.UVList.CopyAssign(value);
			}
		}

		// Token: 0x1700583C RID: 22588
		// (get) Token: 0x06026993 RID: 158099 RVA: 0x009DCE63 File Offset: 0x009DB063
		// (set) Token: 0x06026994 RID: 158100 RVA: 0x009DCE73 File Offset: 0x009DB073
		public unsafe int UVIndex
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BrokenWindow_Car_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BrokenWindow_Car_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x1700583D RID: 22589
		// (get) Token: 0x06026995 RID: 158101 RVA: 0x009DCE84 File Offset: 0x009DB084
		// (set) Token: 0x06026996 RID: 158102 RVA: 0x009DCE94 File Offset: 0x009DB094
		public unsafe float HitTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BrokenWindow_Car_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BrokenWindow_Car_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x1700583E RID: 22590
		// (get) Token: 0x06026997 RID: 158103 RVA: 0x009DCEA5 File Offset: 0x009DB0A5
		// (set) Token: 0x06026998 RID: 158104 RVA: 0x009DCEB5 File Offset: 0x009DB0B5
		public unsafe float TraceTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BrokenWindow_Car_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BrokenWindow_Car_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x1700583F RID: 22591
		// (get) Token: 0x06026999 RID: 158105 RVA: 0x009DCEC6 File Offset: 0x009DB0C6
		// (set) Token: 0x0602699A RID: 158106 RVA: 0x009DCEDA File Offset: 0x009DB0DA
		public unsafe FVector LastWeaponPoint
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BrokenWindow_Car_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BrokenWindow_Car_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x17005840 RID: 22592
		// (get) Token: 0x0602699B RID: 158107 RVA: 0x009DCEEF File Offset: 0x009DB0EF
		// (set) Token: 0x0602699C RID: 158108 RVA: 0x009DCEFF File Offset: 0x009DB0FF
		public unsafe float CrackPointState
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BrokenWindow_Car_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BrokenWindow_Car_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x17005841 RID: 22593
		// (get) Token: 0x0602699D RID: 158109 RVA: 0x009DCF10 File Offset: 0x009DB110
		// (set) Token: 0x0602699E RID: 158110 RVA: 0x009DCF49 File Offset: 0x009DB149
		[Nullable(1)]
		public TArray<int> BitMask
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<int> result;
				if ((result = this._BitMask) == null)
				{
					result = (this._BitMask = new TArray<int>(base.NativePtr + (IntPtr)BP_BrokenWindow_Car_C.__PropertyOffset_20, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.BitMask.CopyAssign(value);
			}
		}

		// Token: 0x17005842 RID: 22594
		// (get) Token: 0x0602699F RID: 158111 RVA: 0x009DCF57 File Offset: 0x009DB157
		// (set) Token: 0x060269A0 RID: 158112 RVA: 0x009DCF67 File Offset: 0x009DB167
		public unsafe int FinalStateMask
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BrokenWindow_Car_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BrokenWindow_Car_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x17005843 RID: 22595
		// (get) Token: 0x060269A1 RID: 158113 RVA: 0x009DCF78 File Offset: 0x009DB178
		// (set) Token: 0x060269A2 RID: 158114 RVA: 0x009DCF88 File Offset: 0x009DB188
		public unsafe float InteractRange
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BrokenWindow_Car_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BrokenWindow_Car_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x17005844 RID: 22596
		// (get) Token: 0x060269A3 RID: 158115 RVA: 0x009DCF99 File Offset: 0x009DB199
		// (set) Token: 0x060269A4 RID: 158116 RVA: 0x009DCFA9 File Offset: 0x009DB1A9
		public unsafe bool Debug
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BrokenWindow_Car_C.__PropertyOffset_23) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BrokenWindow_Car_C.__PropertyOffset_23) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005845 RID: 22597
		// (get) Token: 0x060269A5 RID: 158117 RVA: 0x009DCFBA File Offset: 0x009DB1BA
		// (set) Token: 0x060269A6 RID: 158118 RVA: 0x009DCFCA File Offset: 0x009DB1CA
		public unsafe bool LastPointUseAble
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BrokenWindow_Car_C.__PropertyOffset_24) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BrokenWindow_Car_C.__PropertyOffset_24) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005846 RID: 22598
		// (get) Token: 0x060269A7 RID: 158119 RVA: 0x009DCFDB File Offset: 0x009DB1DB
		// (set) Token: 0x060269A8 RID: 158120 RVA: 0x009DCFEB File Offset: 0x009DB1EB
		public unsafe bool Option_2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BrokenWindow_Car_C.__PropertyOffset_25) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BrokenWindow_Car_C.__PropertyOffset_25) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005847 RID: 22599
		// (get) Token: 0x060269A9 RID: 158121 RVA: 0x009DCFFC File Offset: 0x009DB1FC
		// (set) Token: 0x060269AA RID: 158122 RVA: 0x009DD00C File Offset: 0x009DB20C
		public unsafe bool LeftBroken
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BrokenWindow_Car_C.__PropertyOffset_26) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BrokenWindow_Car_C.__PropertyOffset_26) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005848 RID: 22600
		// (get) Token: 0x060269AB RID: 158123 RVA: 0x009DD01D File Offset: 0x009DB21D
		// (set) Token: 0x060269AC RID: 158124 RVA: 0x009DD02D File Offset: 0x009DB22D
		public unsafe bool RightBroken
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BrokenWindow_Car_C.__PropertyOffset_27) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BrokenWindow_Car_C.__PropertyOffset_27) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005849 RID: 22601
		// (get) Token: 0x060269AD RID: 158125 RVA: 0x009DD040 File Offset: 0x009DB240
		// (set) Token: 0x060269AE RID: 158126 RVA: 0x009DD079 File Offset: 0x009DB279
		[Nullable(1)]
		public TMap<FName, int> TagDict
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TMap<FName, int> result;
				if ((result = this._TagDict) == null)
				{
					result = (this._TagDict = new TMap<FName, int>(base.NativePtr + (IntPtr)BP_BrokenWindow_Car_C.__PropertyOffset_28, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.TagDict.CopyAssign(value);
			}
		}

		// Token: 0x1700584A RID: 22602
		// (get) Token: 0x060269AF RID: 158127 RVA: 0x009DD088 File Offset: 0x009DB288
		// (set) Token: 0x060269B0 RID: 158128 RVA: 0x009DD0C1 File Offset: 0x009DB2C1
		[Nullable(1)]
		public TMap<FName, int> TagIndex
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TMap<FName, int> result;
				if ((result = this._TagIndex) == null)
				{
					result = (this._TagIndex = new TMap<FName, int>(base.NativePtr + (IntPtr)BP_BrokenWindow_Car_C.__PropertyOffset_29, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.TagIndex.CopyAssign(value);
			}
		}

		// Token: 0x1700584B RID: 22603
		// (get) Token: 0x060269B1 RID: 158129 RVA: 0x009DD0D0 File Offset: 0x009DB2D0
		// (set) Token: 0x060269B2 RID: 158130 RVA: 0x009DD109 File Offset: 0x009DB309
		[Nullable(1)]
		public TArray<float> CustomTime
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<float> result;
				if ((result = this._CustomTime) == null)
				{
					result = (this._CustomTime = new TArray<float>(base.NativePtr + (IntPtr)BP_BrokenWindow_Car_C.__PropertyOffset_30, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.CustomTime.CopyAssign(value);
			}
		}

		// Token: 0x060269B3 RID: 158131 RVA: 0x009DD117 File Offset: 0x009DB317
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Reset()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BrokenWindow_Car_C.__Reset_NativeFunctionPtr, null);
		}

		// Token: 0x060269B4 RID: 158132 RVA: 0x009DD12B File Offset: 0x009DB32B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BrokenWindow_Car_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x060269B5 RID: 158133 RVA: 0x009DD13F File Offset: 0x009DB33F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BrokenWindow_Car_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060269B6 RID: 158134 RVA: 0x009DD154 File Offset: 0x009DB354
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_BrokenWindow_Car_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_BrokenWindow_Car_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_BrokenWindow_Car_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BrokenWindow_Car_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BrokenWindow_Car_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060269B7 RID: 158135 RVA: 0x009DD19C File Offset: 0x009DB39C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_BrokenWindow_Car_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_BrokenWindow_Car_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_BrokenWindow_Car_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BrokenWindow_Car_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BrokenWindow_Car_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060269B8 RID: 158136 RVA: 0x009DD1E4 File Offset: 0x009DB3E4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnWeaponInteraction(FVectorDouble OriginPoint, BP_SceneBattleInteract_C Config, int Id)
		{
			BP_BrokenWindow_Car_C.__OnWeaponInteraction_FunctionParams* ptr = stackalloc BP_BrokenWindow_Car_C.__OnWeaponInteraction_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(BP_BrokenWindow_Car_C.__OnWeaponInteraction_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BrokenWindow_Car_C.__OnWeaponInteraction_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OriginPoint = OriginPoint;
			ptr->Config = ((Config != null) ? Config.NativePtr : IntPtr.Zero);
			ptr->Id = Id;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BrokenWindow_Car_C.__OnWeaponInteraction_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060269B9 RID: 158137 RVA: 0x009DD248 File Offset: 0x009DB448
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_BrokenWindow_Car(int EntryPoint)
		{
			BP_BrokenWindow_Car_C.__ExecuteUbergraph_BP_BrokenWindow_Car_FunctionParams* ptr = stackalloc BP_BrokenWindow_Car_C.__ExecuteUbergraph_BP_BrokenWindow_Car_FunctionParams[(UIntPtr)623] + 15L / (long)sizeof(BP_BrokenWindow_Car_C.__ExecuteUbergraph_BP_BrokenWindow_Car_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BrokenWindow_Car_C.__ExecuteUbergraph_BP_BrokenWindow_Car_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BrokenWindow_Car_C.__ExecuteUbergraph_BP_BrokenWindow_Car_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060269BA RID: 158138 RVA: 0x009DD292 File Offset: 0x009DB492
		protected BP_BrokenWindow_Car_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04014125 RID: 82213
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/BrokenGlass/BP_BrokenWindow_Car.BP_BrokenWindow_Car_C";

		// Token: 0x04014126 RID: 82214
		private static IntPtr _ClassPtr;

		// Token: 0x04014127 RID: 82215
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04014128 RID: 82216
		internal static int __PropertyOffset_0;

		// Token: 0x04014129 RID: 82217
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0401412A RID: 82218
		internal static int __PropertyOffset_1;

		// Token: 0x0401412B RID: 82219
		internal static int __PropertyOffset_2;

		// Token: 0x0401412C RID: 82220
		internal static int __PropertyOffset_3;

		// Token: 0x0401412D RID: 82221
		internal static int __PropertyOffset_4;

		// Token: 0x0401412E RID: 82222
		internal static int __PropertyOffset_5;

		// Token: 0x0401412F RID: 82223
		internal static int __PropertyOffset_6;

		// Token: 0x04014130 RID: 82224
		internal static int __PropertyOffset_7;

		// Token: 0x04014131 RID: 82225
		internal static int __PropertyOffset_8;

		// Token: 0x04014132 RID: 82226
		internal static int __PropertyOffset_9;

		// Token: 0x04014133 RID: 82227
		internal static int __PropertyOffset_10;

		// Token: 0x04014134 RID: 82228
		internal static int __PropertyOffset_11;

		// Token: 0x04014135 RID: 82229
		internal static int __PropertyOffset_12;

		// Token: 0x04014136 RID: 82230
		internal static int __PropertyOffset_13;

		// Token: 0x04014137 RID: 82231
		internal static int __PropertyOffset_14;

		// Token: 0x04014138 RID: 82232
		private TArray<FVector> _UVList;

		// Token: 0x04014139 RID: 82233
		internal static int __PropertyOffset_15;

		// Token: 0x0401413A RID: 82234
		internal static int __PropertyOffset_16;

		// Token: 0x0401413B RID: 82235
		internal static int __PropertyOffset_17;

		// Token: 0x0401413C RID: 82236
		internal static int __PropertyOffset_18;

		// Token: 0x0401413D RID: 82237
		internal static int __PropertyOffset_19;

		// Token: 0x0401413E RID: 82238
		internal static int __PropertyOffset_20;

		// Token: 0x0401413F RID: 82239
		private TArray<int> _BitMask;

		// Token: 0x04014140 RID: 82240
		internal static int __PropertyOffset_21;

		// Token: 0x04014141 RID: 82241
		internal static int __PropertyOffset_22;

		// Token: 0x04014142 RID: 82242
		internal static int __PropertyOffset_23;

		// Token: 0x04014143 RID: 82243
		internal static int __PropertyOffset_24;

		// Token: 0x04014144 RID: 82244
		internal static int __PropertyOffset_25;

		// Token: 0x04014145 RID: 82245
		internal static int __PropertyOffset_26;

		// Token: 0x04014146 RID: 82246
		internal static int __PropertyOffset_27;

		// Token: 0x04014147 RID: 82247
		internal static int __PropertyOffset_28;

		// Token: 0x04014148 RID: 82248
		private TMap<FName, int> _TagDict;

		// Token: 0x04014149 RID: 82249
		internal static int __PropertyOffset_29;

		// Token: 0x0401414A RID: 82250
		private TMap<FName, int> _TagIndex;

		// Token: 0x0401414B RID: 82251
		internal static int __PropertyOffset_30;

		// Token: 0x0401414C RID: 82252
		private TArray<float> _CustomTime;

		// Token: 0x0401414D RID: 82253
		private static IntPtr __Reset_NativeFunctionPtr;

		// Token: 0x0401414E RID: 82254
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0401414F RID: 82255
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04014150 RID: 82256
		private static IntPtr __OnWeaponInteraction_NativeFunctionPtr;

		// Token: 0x04014151 RID: 82257
		private static IntPtr __ExecuteUbergraph_BP_BrokenWindow_Car_NativeFunctionPtr;

		// Token: 0x0200A094 RID: 41108
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032D33 RID: 208179
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200A095 RID: 41109
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __OnWeaponInteraction_FunctionParams
		{
			// Token: 0x04032D34 RID: 208180
			[FieldOffset(0)]
			public FVectorDouble OriginPoint;

			// Token: 0x04032D35 RID: 208181
			[FieldOffset(24)]
			public IntPtr Config;

			// Token: 0x04032D36 RID: 208182
			[FieldOffset(32)]
			public int Id;
		}

		// Token: 0x0200A096 RID: 41110
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 608)]
		protected ref struct __ExecuteUbergraph_BP_BrokenWindow_Car_FunctionParams
		{
			// Token: 0x04032D37 RID: 208183
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
