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
	// Token: 0x02003D9D RID: 15773
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/BrokenGlass/BP_BrokenWindow_Car_2.BP_BrokenWindow_Car_2_C")]
	[UnrealStructLayout(1696, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1696)]
	public class BP_BrokenWindow_Car_2_C : AKuroBPActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06026925 RID: 157989 RVA: 0x009DC367 File Offset: 0x009DA567
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_BrokenWindow_Car_2_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/BrokenGlass/BP_BrokenWindow_Car_2.BP_BrokenWindow_Car_2_C");
			}
			return BP_BrokenWindow_Car_2_C._ClassPtr;
		}

		// Token: 0x06026926 RID: 157990 RVA: 0x009DC38C File Offset: 0x009DA58C
		public BP_BrokenWindow_Car_2_C() : this(BuiltinUtils.AllocNativeUObject(BP_BrokenWindow_Car_2_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06026927 RID: 157991 RVA: 0x009DC3B4 File Offset: 0x009DA5B4
		[NullableContext(1)]
		public BP_BrokenWindow_Car_2_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_BrokenWindow_Car_2_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700580C RID: 22540
		// (get) Token: 0x06026928 RID: 157992 RVA: 0x009DC3E8 File Offset: 0x009DA5E8
		// (set) Token: 0x06026929 RID: 157993 RVA: 0x009DC421 File Offset: 0x009DA621
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_BrokenWindow_Car_2_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_BrokenWindow_Car_2_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700580D RID: 22541
		// (get) Token: 0x0602692A RID: 157994 RVA: 0x009DC442 File Offset: 0x009DA642
		// (set) Token: 0x0602692B RID: 157995 RVA: 0x009DC456 File Offset: 0x009DA656
		public unsafe UStaticMeshComponent WindowFront2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BrokenWindow_Car_2_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BrokenWindow_Car_2_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x1700580E RID: 22542
		// (get) Token: 0x0602692C RID: 157996 RVA: 0x009DC46B File Offset: 0x009DA66B
		// (set) Token: 0x0602692D RID: 157997 RVA: 0x009DC47F File Offset: 0x009DA67F
		public unsafe UStaticMeshComponent WindowFront1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BrokenWindow_Car_2_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BrokenWindow_Car_2_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x1700580F RID: 22543
		// (get) Token: 0x0602692E RID: 157998 RVA: 0x009DC494 File Offset: 0x009DA694
		// (set) Token: 0x0602692F RID: 157999 RVA: 0x009DC4A8 File Offset: 0x009DA6A8
		public unsafe UStaticMeshComponent WindowBack1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BrokenWindow_Car_2_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BrokenWindow_Car_2_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17005810 RID: 22544
		// (get) Token: 0x06026930 RID: 158000 RVA: 0x009DC4BD File Offset: 0x009DA6BD
		// (set) Token: 0x06026931 RID: 158001 RVA: 0x009DC4D1 File Offset: 0x009DA6D1
		public unsafe UStaticMeshComponent WindowBack2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BrokenWindow_Car_2_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BrokenWindow_Car_2_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17005811 RID: 22545
		// (get) Token: 0x06026932 RID: 158002 RVA: 0x009DC4E6 File Offset: 0x009DA6E6
		// (set) Token: 0x06026933 RID: 158003 RVA: 0x009DC4FA File Offset: 0x009DA6FA
		public unsafe UStaticMeshComponent WindowRight
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BrokenWindow_Car_2_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BrokenWindow_Car_2_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17005812 RID: 22546
		// (get) Token: 0x06026934 RID: 158004 RVA: 0x009DC50F File Offset: 0x009DA70F
		// (set) Token: 0x06026935 RID: 158005 RVA: 0x009DC523 File Offset: 0x009DA723
		public unsafe UStaticMeshComponent WindowLeft
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BrokenWindow_Car_2_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BrokenWindow_Car_2_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x17005813 RID: 22547
		// (get) Token: 0x06026936 RID: 158006 RVA: 0x009DC538 File Offset: 0x009DA738
		// (set) Token: 0x06026937 RID: 158007 RVA: 0x009DC54C File Offset: 0x009DA74C
		public unsafe UBoxComponent BackWindowColli2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BrokenWindow_Car_2_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BrokenWindow_Car_2_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x17005814 RID: 22548
		// (get) Token: 0x06026938 RID: 158008 RVA: 0x009DC561 File Offset: 0x009DA761
		// (set) Token: 0x06026939 RID: 158009 RVA: 0x009DC575 File Offset: 0x009DA775
		public unsafe UBoxComponent BackWindowColli1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BrokenWindow_Car_2_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BrokenWindow_Car_2_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x17005815 RID: 22549
		// (get) Token: 0x0602693A RID: 158010 RVA: 0x009DC58A File Offset: 0x009DA78A
		// (set) Token: 0x0602693B RID: 158011 RVA: 0x009DC59E File Offset: 0x009DA79E
		public unsafe UBoxComponent FrontWindowColli2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BrokenWindow_Car_2_C.__PropertyOffset_9);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BrokenWindow_Car_2_C.__PropertyOffset_9, value);
			}
		}

		// Token: 0x17005816 RID: 22550
		// (get) Token: 0x0602693C RID: 158012 RVA: 0x009DC5B3 File Offset: 0x009DA7B3
		// (set) Token: 0x0602693D RID: 158013 RVA: 0x009DC5C7 File Offset: 0x009DA7C7
		public unsafe UBoxComponent FrontWindowColli1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BrokenWindow_Car_2_C.__PropertyOffset_10);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BrokenWindow_Car_2_C.__PropertyOffset_10, value);
			}
		}

		// Token: 0x17005817 RID: 22551
		// (get) Token: 0x0602693E RID: 158014 RVA: 0x009DC5DC File Offset: 0x009DA7DC
		// (set) Token: 0x0602693F RID: 158015 RVA: 0x009DC5F0 File Offset: 0x009DA7F0
		public unsafe UBoxComponent RightWindowColli
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BrokenWindow_Car_2_C.__PropertyOffset_11);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BrokenWindow_Car_2_C.__PropertyOffset_11, value);
			}
		}

		// Token: 0x17005818 RID: 22552
		// (get) Token: 0x06026940 RID: 158016 RVA: 0x009DC605 File Offset: 0x009DA805
		// (set) Token: 0x06026941 RID: 158017 RVA: 0x009DC619 File Offset: 0x009DA819
		public unsafe UBoxComponent LeftWindowColli
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BrokenWindow_Car_2_C.__PropertyOffset_12);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BrokenWindow_Car_2_C.__PropertyOffset_12, value);
			}
		}

		// Token: 0x17005819 RID: 22553
		// (get) Token: 0x06026942 RID: 158018 RVA: 0x009DC62E File Offset: 0x009DA82E
		// (set) Token: 0x06026943 RID: 158019 RVA: 0x009DC642 File Offset: 0x009DA842
		public unsafe UStaticMeshComponent SM_Com3_Car_05AL
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BrokenWindow_Car_2_C.__PropertyOffset_13);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BrokenWindow_Car_2_C.__PropertyOffset_13, value);
			}
		}

		// Token: 0x1700581A RID: 22554
		// (get) Token: 0x06026944 RID: 158020 RVA: 0x009DC657 File Offset: 0x009DA857
		// (set) Token: 0x06026945 RID: 158021 RVA: 0x009DC66B File Offset: 0x009DA86B
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BrokenWindow_Car_2_C.__PropertyOffset_14);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BrokenWindow_Car_2_C.__PropertyOffset_14, value);
			}
		}

		// Token: 0x1700581B RID: 22555
		// (get) Token: 0x06026946 RID: 158022 RVA: 0x009DC680 File Offset: 0x009DA880
		// (set) Token: 0x06026947 RID: 158023 RVA: 0x009DC694 File Offset: 0x009DA894
		public unsafe FVector Size
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BrokenWindow_Car_2_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BrokenWindow_Car_2_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x1700581C RID: 22556
		// (get) Token: 0x06026948 RID: 158024 RVA: 0x009DC6AC File Offset: 0x009DA8AC
		// (set) Token: 0x06026949 RID: 158025 RVA: 0x009DC6E5 File Offset: 0x009DA8E5
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
					result = (this._UVList = new TArray<FVector>(base.NativePtr + (IntPtr)BP_BrokenWindow_Car_2_C.__PropertyOffset_16, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.UVList.CopyAssign(value);
			}
		}

		// Token: 0x1700581D RID: 22557
		// (get) Token: 0x0602694A RID: 158026 RVA: 0x009DC6F3 File Offset: 0x009DA8F3
		// (set) Token: 0x0602694B RID: 158027 RVA: 0x009DC703 File Offset: 0x009DA903
		public unsafe int UVIndex
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BrokenWindow_Car_2_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BrokenWindow_Car_2_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x1700581E RID: 22558
		// (get) Token: 0x0602694C RID: 158028 RVA: 0x009DC714 File Offset: 0x009DA914
		// (set) Token: 0x0602694D RID: 158029 RVA: 0x009DC724 File Offset: 0x009DA924
		public unsafe float HitTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BrokenWindow_Car_2_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BrokenWindow_Car_2_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x1700581F RID: 22559
		// (get) Token: 0x0602694E RID: 158030 RVA: 0x009DC735 File Offset: 0x009DA935
		// (set) Token: 0x0602694F RID: 158031 RVA: 0x009DC745 File Offset: 0x009DA945
		public unsafe float TraceTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BrokenWindow_Car_2_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BrokenWindow_Car_2_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x17005820 RID: 22560
		// (get) Token: 0x06026950 RID: 158032 RVA: 0x009DC756 File Offset: 0x009DA956
		// (set) Token: 0x06026951 RID: 158033 RVA: 0x009DC76A File Offset: 0x009DA96A
		public unsafe FVector LastWeaponPoint
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BrokenWindow_Car_2_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BrokenWindow_Car_2_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x17005821 RID: 22561
		// (get) Token: 0x06026952 RID: 158034 RVA: 0x009DC77F File Offset: 0x009DA97F
		// (set) Token: 0x06026953 RID: 158035 RVA: 0x009DC78F File Offset: 0x009DA98F
		public unsafe float CrackPointState
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BrokenWindow_Car_2_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BrokenWindow_Car_2_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x17005822 RID: 22562
		// (get) Token: 0x06026954 RID: 158036 RVA: 0x009DC7A0 File Offset: 0x009DA9A0
		// (set) Token: 0x06026955 RID: 158037 RVA: 0x009DC7D9 File Offset: 0x009DA9D9
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
					result = (this._BitMask = new TArray<int>(base.NativePtr + (IntPtr)BP_BrokenWindow_Car_2_C.__PropertyOffset_22, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.BitMask.CopyAssign(value);
			}
		}

		// Token: 0x17005823 RID: 22563
		// (get) Token: 0x06026956 RID: 158038 RVA: 0x009DC7E7 File Offset: 0x009DA9E7
		// (set) Token: 0x06026957 RID: 158039 RVA: 0x009DC7F7 File Offset: 0x009DA9F7
		public unsafe int FinalStateMask
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BrokenWindow_Car_2_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BrokenWindow_Car_2_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x17005824 RID: 22564
		// (get) Token: 0x06026958 RID: 158040 RVA: 0x009DC808 File Offset: 0x009DAA08
		// (set) Token: 0x06026959 RID: 158041 RVA: 0x009DC818 File Offset: 0x009DAA18
		public unsafe float InteractRange
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BrokenWindow_Car_2_C.__PropertyOffset_24);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BrokenWindow_Car_2_C.__PropertyOffset_24) = value;
			}
		}

		// Token: 0x17005825 RID: 22565
		// (get) Token: 0x0602695A RID: 158042 RVA: 0x009DC829 File Offset: 0x009DAA29
		// (set) Token: 0x0602695B RID: 158043 RVA: 0x009DC839 File Offset: 0x009DAA39
		public unsafe bool Debug
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BrokenWindow_Car_2_C.__PropertyOffset_25) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BrokenWindow_Car_2_C.__PropertyOffset_25) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005826 RID: 22566
		// (get) Token: 0x0602695C RID: 158044 RVA: 0x009DC84A File Offset: 0x009DAA4A
		// (set) Token: 0x0602695D RID: 158045 RVA: 0x009DC85A File Offset: 0x009DAA5A
		public unsafe bool LastPointUseAble
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BrokenWindow_Car_2_C.__PropertyOffset_26) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BrokenWindow_Car_2_C.__PropertyOffset_26) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005827 RID: 22567
		// (get) Token: 0x0602695E RID: 158046 RVA: 0x009DC86B File Offset: 0x009DAA6B
		// (set) Token: 0x0602695F RID: 158047 RVA: 0x009DC87B File Offset: 0x009DAA7B
		public unsafe bool Option_2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BrokenWindow_Car_2_C.__PropertyOffset_27) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BrokenWindow_Car_2_C.__PropertyOffset_27) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005828 RID: 22568
		// (get) Token: 0x06026960 RID: 158048 RVA: 0x009DC88C File Offset: 0x009DAA8C
		// (set) Token: 0x06026961 RID: 158049 RVA: 0x009DC89C File Offset: 0x009DAA9C
		public unsafe bool LeftBroken
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BrokenWindow_Car_2_C.__PropertyOffset_28) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BrokenWindow_Car_2_C.__PropertyOffset_28) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005829 RID: 22569
		// (get) Token: 0x06026962 RID: 158050 RVA: 0x009DC8AD File Offset: 0x009DAAAD
		// (set) Token: 0x06026963 RID: 158051 RVA: 0x009DC8BD File Offset: 0x009DAABD
		public unsafe bool RightBroken
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BrokenWindow_Car_2_C.__PropertyOffset_29) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BrokenWindow_Car_2_C.__PropertyOffset_29) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700582A RID: 22570
		// (get) Token: 0x06026964 RID: 158052 RVA: 0x009DC8D0 File Offset: 0x009DAAD0
		// (set) Token: 0x06026965 RID: 158053 RVA: 0x009DC909 File Offset: 0x009DAB09
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
					result = (this._TagDict = new TMap<FName, int>(base.NativePtr + (IntPtr)BP_BrokenWindow_Car_2_C.__PropertyOffset_30, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.TagDict.CopyAssign(value);
			}
		}

		// Token: 0x1700582B RID: 22571
		// (get) Token: 0x06026966 RID: 158054 RVA: 0x009DC918 File Offset: 0x009DAB18
		// (set) Token: 0x06026967 RID: 158055 RVA: 0x009DC951 File Offset: 0x009DAB51
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
					result = (this._TagIndex = new TMap<FName, int>(base.NativePtr + (IntPtr)BP_BrokenWindow_Car_2_C.__PropertyOffset_31, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.TagIndex.CopyAssign(value);
			}
		}

		// Token: 0x1700582C RID: 22572
		// (get) Token: 0x06026968 RID: 158056 RVA: 0x009DC960 File Offset: 0x009DAB60
		// (set) Token: 0x06026969 RID: 158057 RVA: 0x009DC999 File Offset: 0x009DAB99
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
					result = (this._CustomTime = new TArray<float>(base.NativePtr + (IntPtr)BP_BrokenWindow_Car_2_C.__PropertyOffset_32, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.CustomTime.CopyAssign(value);
			}
		}

		// Token: 0x0602696A RID: 158058 RVA: 0x009DC9A7 File Offset: 0x009DABA7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Reset()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BrokenWindow_Car_2_C.__Reset_NativeFunctionPtr, null);
		}

		// Token: 0x0602696B RID: 158059 RVA: 0x009DC9BB File Offset: 0x009DABBB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BrokenWindow_Car_2_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0602696C RID: 158060 RVA: 0x009DC9CF File Offset: 0x009DABCF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BrokenWindow_Car_2_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602696D RID: 158061 RVA: 0x009DC9E4 File Offset: 0x009DABE4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_BrokenWindow_Car_2_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_BrokenWindow_Car_2_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_BrokenWindow_Car_2_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BrokenWindow_Car_2_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BrokenWindow_Car_2_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602696E RID: 158062 RVA: 0x009DCA2C File Offset: 0x009DAC2C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_BrokenWindow_Car_2_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_BrokenWindow_Car_2_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_BrokenWindow_Car_2_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BrokenWindow_Car_2_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BrokenWindow_Car_2_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602696F RID: 158063 RVA: 0x009DCA74 File Offset: 0x009DAC74
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnWeaponInteraction(FVectorDouble OriginPoint, BP_SceneBattleInteract_C Config, int Id)
		{
			BP_BrokenWindow_Car_2_C.__OnWeaponInteraction_FunctionParams* ptr = stackalloc BP_BrokenWindow_Car_2_C.__OnWeaponInteraction_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(BP_BrokenWindow_Car_2_C.__OnWeaponInteraction_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BrokenWindow_Car_2_C.__OnWeaponInteraction_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OriginPoint = OriginPoint;
			ptr->Config = ((Config != null) ? Config.NativePtr : IntPtr.Zero);
			ptr->Id = Id;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BrokenWindow_Car_2_C.__OnWeaponInteraction_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06026970 RID: 158064 RVA: 0x009DCAD8 File Offset: 0x009DACD8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_BrokenWindow_Car_2(int EntryPoint)
		{
			BP_BrokenWindow_Car_2_C.__ExecuteUbergraph_BP_BrokenWindow_Car_2_FunctionParams* ptr = stackalloc BP_BrokenWindow_Car_2_C.__ExecuteUbergraph_BP_BrokenWindow_Car_2_FunctionParams[(UIntPtr)631] + 15L / (long)sizeof(BP_BrokenWindow_Car_2_C.__ExecuteUbergraph_BP_BrokenWindow_Car_2_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BrokenWindow_Car_2_C.__ExecuteUbergraph_BP_BrokenWindow_Car_2_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BrokenWindow_Car_2_C.__ExecuteUbergraph_BP_BrokenWindow_Car_2_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06026971 RID: 158065 RVA: 0x009DCB22 File Offset: 0x009DAD22
		protected BP_BrokenWindow_Car_2_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040140F6 RID: 82166
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/BrokenGlass/BP_BrokenWindow_Car_2.BP_BrokenWindow_Car_2_C";

		// Token: 0x040140F7 RID: 82167
		private static IntPtr _ClassPtr;

		// Token: 0x040140F8 RID: 82168
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040140F9 RID: 82169
		internal static int __PropertyOffset_0;

		// Token: 0x040140FA RID: 82170
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040140FB RID: 82171
		internal static int __PropertyOffset_1;

		// Token: 0x040140FC RID: 82172
		internal static int __PropertyOffset_2;

		// Token: 0x040140FD RID: 82173
		internal static int __PropertyOffset_3;

		// Token: 0x040140FE RID: 82174
		internal static int __PropertyOffset_4;

		// Token: 0x040140FF RID: 82175
		internal static int __PropertyOffset_5;

		// Token: 0x04014100 RID: 82176
		internal static int __PropertyOffset_6;

		// Token: 0x04014101 RID: 82177
		internal static int __PropertyOffset_7;

		// Token: 0x04014102 RID: 82178
		internal static int __PropertyOffset_8;

		// Token: 0x04014103 RID: 82179
		internal static int __PropertyOffset_9;

		// Token: 0x04014104 RID: 82180
		internal static int __PropertyOffset_10;

		// Token: 0x04014105 RID: 82181
		internal static int __PropertyOffset_11;

		// Token: 0x04014106 RID: 82182
		internal static int __PropertyOffset_12;

		// Token: 0x04014107 RID: 82183
		internal static int __PropertyOffset_13;

		// Token: 0x04014108 RID: 82184
		internal static int __PropertyOffset_14;

		// Token: 0x04014109 RID: 82185
		internal static int __PropertyOffset_15;

		// Token: 0x0401410A RID: 82186
		internal static int __PropertyOffset_16;

		// Token: 0x0401410B RID: 82187
		private TArray<FVector> _UVList;

		// Token: 0x0401410C RID: 82188
		internal static int __PropertyOffset_17;

		// Token: 0x0401410D RID: 82189
		internal static int __PropertyOffset_18;

		// Token: 0x0401410E RID: 82190
		internal static int __PropertyOffset_19;

		// Token: 0x0401410F RID: 82191
		internal static int __PropertyOffset_20;

		// Token: 0x04014110 RID: 82192
		internal static int __PropertyOffset_21;

		// Token: 0x04014111 RID: 82193
		internal static int __PropertyOffset_22;

		// Token: 0x04014112 RID: 82194
		private TArray<int> _BitMask;

		// Token: 0x04014113 RID: 82195
		internal static int __PropertyOffset_23;

		// Token: 0x04014114 RID: 82196
		internal static int __PropertyOffset_24;

		// Token: 0x04014115 RID: 82197
		internal static int __PropertyOffset_25;

		// Token: 0x04014116 RID: 82198
		internal static int __PropertyOffset_26;

		// Token: 0x04014117 RID: 82199
		internal static int __PropertyOffset_27;

		// Token: 0x04014118 RID: 82200
		internal static int __PropertyOffset_28;

		// Token: 0x04014119 RID: 82201
		internal static int __PropertyOffset_29;

		// Token: 0x0401411A RID: 82202
		internal static int __PropertyOffset_30;

		// Token: 0x0401411B RID: 82203
		private TMap<FName, int> _TagDict;

		// Token: 0x0401411C RID: 82204
		internal static int __PropertyOffset_31;

		// Token: 0x0401411D RID: 82205
		private TMap<FName, int> _TagIndex;

		// Token: 0x0401411E RID: 82206
		internal static int __PropertyOffset_32;

		// Token: 0x0401411F RID: 82207
		private TArray<float> _CustomTime;

		// Token: 0x04014120 RID: 82208
		private static IntPtr __Reset_NativeFunctionPtr;

		// Token: 0x04014121 RID: 82209
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04014122 RID: 82210
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04014123 RID: 82211
		private static IntPtr __OnWeaponInteraction_NativeFunctionPtr;

		// Token: 0x04014124 RID: 82212
		private static IntPtr __ExecuteUbergraph_BP_BrokenWindow_Car_2_NativeFunctionPtr;

		// Token: 0x0200A091 RID: 41105
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032D2E RID: 208174
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200A092 RID: 41106
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __OnWeaponInteraction_FunctionParams
		{
			// Token: 0x04032D2F RID: 208175
			[FieldOffset(0)]
			public FVectorDouble OriginPoint;

			// Token: 0x04032D30 RID: 208176
			[FieldOffset(24)]
			public IntPtr Config;

			// Token: 0x04032D31 RID: 208177
			[FieldOffset(32)]
			public int Id;
		}

		// Token: 0x0200A093 RID: 41107
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 616)]
		protected ref struct __ExecuteUbergraph_BP_BrokenWindow_Car_2_FunctionParams
		{
			// Token: 0x04032D32 RID: 208178
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
