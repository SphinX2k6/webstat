using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.UI.Module.Common.View.Widget;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.GI.UI
{
	// Token: 0x02003C9D RID: 15517
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/GI/UI/BP_DebugGlobalGI.BP_DebugGlobalGI_C")]
	[UnrealStructLayout(1560, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1560)]
	public class BP_DebugGlobalGI_C : UUserWidget, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602485E RID: 149598 RVA: 0x009A0078 File Offset: 0x0099E278
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_DebugGlobalGI_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/GI/UI/BP_DebugGlobalGI.BP_DebugGlobalGI_C");
			}
			return BP_DebugGlobalGI_C._ClassPtr;
		}

		// Token: 0x0602485F RID: 149599 RVA: 0x009A009C File Offset: 0x0099E29C
		public BP_DebugGlobalGI_C() : this(BuiltinUtils.AllocNativeUObject(BP_DebugGlobalGI_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06024860 RID: 149600 RVA: 0x009A00C4 File Offset: 0x0099E2C4
		[NullableContext(1)]
		public BP_DebugGlobalGI_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_DebugGlobalGI_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004C8A RID: 19594
		// (get) Token: 0x06024861 RID: 149601 RVA: 0x009A00F8 File Offset: 0x0099E2F8
		// (set) Token: 0x06024862 RID: 149602 RVA: 0x009A0131 File Offset: 0x0099E331
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_DebugGlobalGI_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_DebugGlobalGI_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004C8B RID: 19595
		// (get) Token: 0x06024863 RID: 149603 RVA: 0x009A0152 File Offset: 0x0099E352
		// (set) Token: 0x06024864 RID: 149604 RVA: 0x009A0166 File Offset: 0x0099E366
		public unsafe UButton Btn_0
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UButton>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugGlobalGI_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugGlobalGI_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17004C8C RID: 19596
		// (get) Token: 0x06024865 RID: 149605 RVA: 0x009A017B File Offset: 0x0099E37B
		// (set) Token: 0x06024866 RID: 149606 RVA: 0x009A018F File Offset: 0x0099E38F
		public unsafe UButton Btn_3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UButton>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugGlobalGI_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugGlobalGI_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17004C8D RID: 19597
		// (get) Token: 0x06024867 RID: 149607 RVA: 0x009A01A4 File Offset: 0x0099E3A4
		// (set) Token: 0x06024868 RID: 149608 RVA: 0x009A01B8 File Offset: 0x0099E3B8
		public unsafe UButton Btn_6
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UButton>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugGlobalGI_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugGlobalGI_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17004C8E RID: 19598
		// (get) Token: 0x06024869 RID: 149609 RVA: 0x009A01CD File Offset: 0x0099E3CD
		// (set) Token: 0x0602486A RID: 149610 RVA: 0x009A01E1 File Offset: 0x0099E3E1
		public unsafe UButton Btn_9
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UButton>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugGlobalGI_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugGlobalGI_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17004C8F RID: 19599
		// (get) Token: 0x0602486B RID: 149611 RVA: 0x009A01F6 File Offset: 0x0099E3F6
		// (set) Token: 0x0602486C RID: 149612 RVA: 0x009A020A File Offset: 0x0099E40A
		public unsafe UButton Btn_12
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UButton>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugGlobalGI_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugGlobalGI_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17004C90 RID: 19600
		// (get) Token: 0x0602486D RID: 149613 RVA: 0x009A021F File Offset: 0x0099E41F
		// (set) Token: 0x0602486E RID: 149614 RVA: 0x009A0233 File Offset: 0x0099E433
		public unsafe UButton Btn_15
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UButton>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugGlobalGI_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugGlobalGI_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x17004C91 RID: 19601
		// (get) Token: 0x0602486F RID: 149615 RVA: 0x009A0248 File Offset: 0x0099E448
		// (set) Token: 0x06024870 RID: 149616 RVA: 0x009A025C File Offset: 0x0099E45C
		public unsafe UButton Btn_18
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UButton>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugGlobalGI_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugGlobalGI_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x17004C92 RID: 19602
		// (get) Token: 0x06024871 RID: 149617 RVA: 0x009A0271 File Offset: 0x0099E471
		// (set) Token: 0x06024872 RID: 149618 RVA: 0x009A0285 File Offset: 0x0099E485
		public unsafe UButton Btn_21
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UButton>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugGlobalGI_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugGlobalGI_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x17004C93 RID: 19603
		// (get) Token: 0x06024873 RID: 149619 RVA: 0x009A029A File Offset: 0x0099E49A
		// (set) Token: 0x06024874 RID: 149620 RVA: 0x009A02AE File Offset: 0x0099E4AE
		public unsafe UButton BtnClose
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UButton>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugGlobalGI_C.__PropertyOffset_9);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugGlobalGI_C.__PropertyOffset_9, value);
			}
		}

		// Token: 0x17004C94 RID: 19604
		// (get) Token: 0x06024875 RID: 149621 RVA: 0x009A02C3 File Offset: 0x0099E4C3
		// (set) Token: 0x06024876 RID: 149622 RVA: 0x009A02D7 File Offset: 0x0099E4D7
		public unsafe UButton BtnCloseCloudMove
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UButton>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugGlobalGI_C.__PropertyOffset_10);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugGlobalGI_C.__PropertyOffset_10, value);
			}
		}

		// Token: 0x17004C95 RID: 19605
		// (get) Token: 0x06024877 RID: 149623 RVA: 0x009A02EC File Offset: 0x0099E4EC
		// (set) Token: 0x06024878 RID: 149624 RVA: 0x009A0300 File Offset: 0x0099E500
		public unsafe UButton BtnCloseLightFunction
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UButton>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugGlobalGI_C.__PropertyOffset_11);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugGlobalGI_C.__PropertyOffset_11, value);
			}
		}

		// Token: 0x17004C96 RID: 19606
		// (get) Token: 0x06024879 RID: 149625 RVA: 0x009A0315 File Offset: 0x0099E515
		// (set) Token: 0x0602487A RID: 149626 RVA: 0x009A0329 File Offset: 0x0099E529
		public unsafe UButton BtnCloseLightFunction_1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UButton>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugGlobalGI_C.__PropertyOffset_12);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugGlobalGI_C.__PropertyOffset_12, value);
			}
		}

		// Token: 0x17004C97 RID: 19607
		// (get) Token: 0x0602487B RID: 149627 RVA: 0x009A033E File Offset: 0x0099E53E
		// (set) Token: 0x0602487C RID: 149628 RVA: 0x009A0352 File Offset: 0x0099E552
		public unsafe UButton BtnCloseNewUiScene
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UButton>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugGlobalGI_C.__PropertyOffset_13);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugGlobalGI_C.__PropertyOffset_13, value);
			}
		}

		// Token: 0x17004C98 RID: 19608
		// (get) Token: 0x0602487D RID: 149629 RVA: 0x009A0367 File Offset: 0x0099E567
		// (set) Token: 0x0602487E RID: 149630 RVA: 0x009A037B File Offset: 0x0099E57B
		public unsafe UButton BtnCloseStoneAo
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UButton>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugGlobalGI_C.__PropertyOffset_14);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugGlobalGI_C.__PropertyOffset_14, value);
			}
		}

		// Token: 0x17004C99 RID: 19609
		// (get) Token: 0x0602487F RID: 149631 RVA: 0x009A0390 File Offset: 0x0099E590
		// (set) Token: 0x06024880 RID: 149632 RVA: 0x009A03A4 File Offset: 0x0099E5A4
		public unsafe UButton BtnCloseStoneAo_1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UButton>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugGlobalGI_C.__PropertyOffset_15);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugGlobalGI_C.__PropertyOffset_15, value);
			}
		}

		// Token: 0x17004C9A RID: 19610
		// (get) Token: 0x06024881 RID: 149633 RVA: 0x009A03B9 File Offset: 0x0099E5B9
		// (set) Token: 0x06024882 RID: 149634 RVA: 0x009A03CD File Offset: 0x0099E5CD
		public unsafe UButton BtnOpenCloudMove
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UButton>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugGlobalGI_C.__PropertyOffset_16);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugGlobalGI_C.__PropertyOffset_16, value);
			}
		}

		// Token: 0x17004C9B RID: 19611
		// (get) Token: 0x06024883 RID: 149635 RVA: 0x009A03E2 File Offset: 0x0099E5E2
		// (set) Token: 0x06024884 RID: 149636 RVA: 0x009A03F6 File Offset: 0x0099E5F6
		public unsafe UButton BtnOpenNewUiScene
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UButton>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugGlobalGI_C.__PropertyOffset_17);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugGlobalGI_C.__PropertyOffset_17, value);
			}
		}

		// Token: 0x17004C9C RID: 19612
		// (get) Token: 0x06024885 RID: 149637 RVA: 0x009A040B File Offset: 0x0099E60B
		// (set) Token: 0x06024886 RID: 149638 RVA: 0x009A041F File Offset: 0x0099E61F
		public unsafe UButton BtnSetInterval
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UButton>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugGlobalGI_C.__PropertyOffset_18);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugGlobalGI_C.__PropertyOffset_18, value);
			}
		}

		// Token: 0x17004C9D RID: 19613
		// (get) Token: 0x06024887 RID: 149639 RVA: 0x009A0434 File Offset: 0x0099E634
		// (set) Token: 0x06024888 RID: 149640 RVA: 0x009A0448 File Offset: 0x0099E648
		public unsafe UButton BtnSetInterval_1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UButton>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugGlobalGI_C.__PropertyOffset_19);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugGlobalGI_C.__PropertyOffset_19, value);
			}
		}

		// Token: 0x17004C9E RID: 19614
		// (get) Token: 0x06024889 RID: 149641 RVA: 0x009A045D File Offset: 0x0099E65D
		// (set) Token: 0x0602488A RID: 149642 RVA: 0x009A0471 File Offset: 0x0099E671
		public unsafe UButton BtnSetInterval_2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UButton>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugGlobalGI_C.__PropertyOffset_20);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugGlobalGI_C.__PropertyOffset_20, value);
			}
		}

		// Token: 0x17004C9F RID: 19615
		// (get) Token: 0x0602488B RID: 149643 RVA: 0x009A0486 File Offset: 0x0099E686
		// (set) Token: 0x0602488C RID: 149644 RVA: 0x009A049A File Offset: 0x0099E69A
		public unsafe UButton BtnSetInterval_3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UButton>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugGlobalGI_C.__PropertyOffset_21);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugGlobalGI_C.__PropertyOffset_21, value);
			}
		}

		// Token: 0x17004CA0 RID: 19616
		// (get) Token: 0x0602488D RID: 149645 RVA: 0x009A04AF File Offset: 0x0099E6AF
		// (set) Token: 0x0602488E RID: 149646 RVA: 0x009A04C3 File Offset: 0x0099E6C3
		public unsafe UButton BtnSetTime
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UButton>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugGlobalGI_C.__PropertyOffset_22);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugGlobalGI_C.__PropertyOffset_22, value);
			}
		}

		// Token: 0x17004CA1 RID: 19617
		// (get) Token: 0x0602488F RID: 149647 RVA: 0x009A04D8 File Offset: 0x0099E6D8
		// (set) Token: 0x06024890 RID: 149648 RVA: 0x009A04EC File Offset: 0x0099E6EC
		public unsafe UButton BtnStart
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UButton>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugGlobalGI_C.__PropertyOffset_23);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugGlobalGI_C.__PropertyOffset_23, value);
			}
		}

		// Token: 0x17004CA2 RID: 19618
		// (get) Token: 0x06024891 RID: 149649 RVA: 0x009A0501 File Offset: 0x0099E701
		// (set) Token: 0x06024892 RID: 149650 RVA: 0x009A0515 File Offset: 0x0099E715
		public unsafe UButton BtnStop
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UButton>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugGlobalGI_C.__PropertyOffset_24);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugGlobalGI_C.__PropertyOffset_24, value);
			}
		}

		// Token: 0x17004CA3 RID: 19619
		// (get) Token: 0x06024893 RID: 149651 RVA: 0x009A052A File Offset: 0x0099E72A
		// (set) Token: 0x06024894 RID: 149652 RVA: 0x009A053E File Offset: 0x0099E73E
		public unsafe UButton BtnTestUiScene
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UButton>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugGlobalGI_C.__PropertyOffset_25);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugGlobalGI_C.__PropertyOffset_25, value);
			}
		}

		// Token: 0x17004CA4 RID: 19620
		// (get) Token: 0x06024895 RID: 149653 RVA: 0x009A0553 File Offset: 0x0099E753
		// (set) Token: 0x06024896 RID: 149654 RVA: 0x009A0567 File Offset: 0x0099E767
		public unsafe UButton BtnTime
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UButton>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugGlobalGI_C.__PropertyOffset_26);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugGlobalGI_C.__PropertyOffset_26, value);
			}
		}

		// Token: 0x17004CA5 RID: 19621
		// (get) Token: 0x06024897 RID: 149655 RVA: 0x009A057C File Offset: 0x0099E77C
		// (set) Token: 0x06024898 RID: 149656 RVA: 0x009A0590 File Offset: 0x0099E790
		public unsafe UButton BtnTime_0
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UButton>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugGlobalGI_C.__PropertyOffset_27);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugGlobalGI_C.__PropertyOffset_27, value);
			}
		}

		// Token: 0x17004CA6 RID: 19622
		// (get) Token: 0x06024899 RID: 149657 RVA: 0x009A05A5 File Offset: 0x0099E7A5
		// (set) Token: 0x0602489A RID: 149658 RVA: 0x009A05B9 File Offset: 0x0099E7B9
		public unsafe UButton BtnTime_1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UButton>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugGlobalGI_C.__PropertyOffset_28);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugGlobalGI_C.__PropertyOffset_28, value);
			}
		}

		// Token: 0x17004CA7 RID: 19623
		// (get) Token: 0x0602489B RID: 149659 RVA: 0x009A05CE File Offset: 0x0099E7CE
		// (set) Token: 0x0602489C RID: 149660 RVA: 0x009A05E2 File Offset: 0x0099E7E2
		public unsafe UButton BtnTime_2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UButton>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugGlobalGI_C.__PropertyOffset_29);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugGlobalGI_C.__PropertyOffset_29, value);
			}
		}

		// Token: 0x17004CA8 RID: 19624
		// (get) Token: 0x0602489D RID: 149661 RVA: 0x009A05F7 File Offset: 0x0099E7F7
		// (set) Token: 0x0602489E RID: 149662 RVA: 0x009A060B File Offset: 0x0099E80B
		public unsafe UButton BtnTime_3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UButton>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugGlobalGI_C.__PropertyOffset_30);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugGlobalGI_C.__PropertyOffset_30, value);
			}
		}

		// Token: 0x17004CA9 RID: 19625
		// (get) Token: 0x0602489F RID: 149663 RVA: 0x009A0620 File Offset: 0x0099E820
		// (set) Token: 0x060248A0 RID: 149664 RVA: 0x009A0634 File Offset: 0x0099E834
		public unsafe UButton BtnTime_4
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UButton>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugGlobalGI_C.__PropertyOffset_31);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugGlobalGI_C.__PropertyOffset_31, value);
			}
		}

		// Token: 0x17004CAA RID: 19626
		// (get) Token: 0x060248A1 RID: 149665 RVA: 0x009A0649 File Offset: 0x0099E849
		// (set) Token: 0x060248A2 RID: 149666 RVA: 0x009A065D File Offset: 0x0099E85D
		public unsafe UButton BtnTime_5
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UButton>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugGlobalGI_C.__PropertyOffset_32);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugGlobalGI_C.__PropertyOffset_32, value);
			}
		}

		// Token: 0x17004CAB RID: 19627
		// (get) Token: 0x060248A3 RID: 149667 RVA: 0x009A0672 File Offset: 0x0099E872
		// (set) Token: 0x060248A4 RID: 149668 RVA: 0x009A0686 File Offset: 0x0099E886
		public unsafe UButton BtnTime_6
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UButton>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugGlobalGI_C.__PropertyOffset_33);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugGlobalGI_C.__PropertyOffset_33, value);
			}
		}

		// Token: 0x17004CAC RID: 19628
		// (get) Token: 0x060248A5 RID: 149669 RVA: 0x009A069B File Offset: 0x0099E89B
		// (set) Token: 0x060248A6 RID: 149670 RVA: 0x009A06AF File Offset: 0x0099E8AF
		public unsafe UButton BtnTime_7
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UButton>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugGlobalGI_C.__PropertyOffset_34);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugGlobalGI_C.__PropertyOffset_34, value);
			}
		}

		// Token: 0x17004CAD RID: 19629
		// (get) Token: 0x060248A7 RID: 149671 RVA: 0x009A06C4 File Offset: 0x0099E8C4
		// (set) Token: 0x060248A8 RID: 149672 RVA: 0x009A06D8 File Offset: 0x0099E8D8
		public unsafe UButton BtnTime_8
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UButton>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugGlobalGI_C.__PropertyOffset_35);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugGlobalGI_C.__PropertyOffset_35, value);
			}
		}

		// Token: 0x17004CAE RID: 19630
		// (get) Token: 0x060248A9 RID: 149673 RVA: 0x009A06ED File Offset: 0x0099E8ED
		// (set) Token: 0x060248AA RID: 149674 RVA: 0x009A0701 File Offset: 0x0099E901
		public unsafe UButton BtnUpdate
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UButton>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugGlobalGI_C.__PropertyOffset_36);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugGlobalGI_C.__PropertyOffset_36, value);
			}
		}

		// Token: 0x17004CAF RID: 19631
		// (get) Token: 0x060248AB RID: 149675 RVA: 0x009A0716 File Offset: 0x0099E916
		// (set) Token: 0x060248AC RID: 149676 RVA: 0x009A072A File Offset: 0x0099E92A
		public unsafe KuroImage_C KuroImage_C_76
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<KuroImage_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugGlobalGI_C.__PropertyOffset_37);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugGlobalGI_C.__PropertyOffset_37, value);
			}
		}

		// Token: 0x17004CB0 RID: 19632
		// (get) Token: 0x060248AD RID: 149677 RVA: 0x009A073F File Offset: 0x0099E93F
		// (set) Token: 0x060248AE RID: 149678 RVA: 0x009A0753 File Offset: 0x0099E953
		public unsafe USlider Slider_CurTime
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USlider>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugGlobalGI_C.__PropertyOffset_38);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugGlobalGI_C.__PropertyOffset_38, value);
			}
		}

		// Token: 0x17004CB1 RID: 19633
		// (get) Token: 0x060248AF RID: 149679 RVA: 0x009A0768 File Offset: 0x0099E968
		// (set) Token: 0x060248B0 RID: 149680 RVA: 0x009A077C File Offset: 0x0099E97C
		public unsafe UTextBlock Text_CurTime
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextBlock>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugGlobalGI_C.__PropertyOffset_39);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugGlobalGI_C.__PropertyOffset_39, value);
			}
		}

		// Token: 0x17004CB2 RID: 19634
		// (get) Token: 0x060248B1 RID: 149681 RVA: 0x009A0791 File Offset: 0x0099E991
		// (set) Token: 0x060248B2 RID: 149682 RVA: 0x009A07A5 File Offset: 0x0099E9A5
		public unsafe UEditableText TextInput_Time
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UEditableText>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugGlobalGI_C.__PropertyOffset_40);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugGlobalGI_C.__PropertyOffset_40, value);
			}
		}

		// Token: 0x17004CB3 RID: 19635
		// (get) Token: 0x060248B3 RID: 149683 RVA: 0x009A07BA File Offset: 0x0099E9BA
		// (set) Token: 0x060248B4 RID: 149684 RVA: 0x009A07CE File Offset: 0x0099E9CE
		public unsafe UEditableText TextInput_Time_1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UEditableText>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugGlobalGI_C.__PropertyOffset_41);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugGlobalGI_C.__PropertyOffset_41, value);
			}
		}

		// Token: 0x17004CB4 RID: 19636
		// (get) Token: 0x060248B5 RID: 149685 RVA: 0x009A07E3 File Offset: 0x0099E9E3
		// (set) Token: 0x060248B6 RID: 149686 RVA: 0x009A07F7 File Offset: 0x0099E9F7
		public unsafe UEditableText TextInput_TimeInterval
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UEditableText>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugGlobalGI_C.__PropertyOffset_42);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugGlobalGI_C.__PropertyOffset_42, value);
			}
		}

		// Token: 0x17004CB5 RID: 19637
		// (get) Token: 0x060248B7 RID: 149687 RVA: 0x009A080C File Offset: 0x0099EA0C
		// (set) Token: 0x060248B8 RID: 149688 RVA: 0x009A0821 File Offset: 0x0099EA21
		[Nullable(1)]
		public TSoftObjectPtr<BP_GlobalGI_C> BP_GlobalGI
		{
			[NullableContext(1)]
			get
			{
				return new TSoftObjectPtr<BP_GlobalGI_C>(base.NativePtr + (IntPtr)BP_DebugGlobalGI_C.__PropertyOffset_43, this);
			}
			[NullableContext(1)]
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_DebugGlobalGI_C.__PropertyOffset_43, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x060248B9 RID: 149689 RVA: 0x009A0848 File Offset: 0x0099EA48
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetAutoPlay(bool AutoPlay)
		{
			BP_DebugGlobalGI_C.__SetAutoPlay_FunctionParams* ptr = stackalloc BP_DebugGlobalGI_C.__SetAutoPlay_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_DebugGlobalGI_C.__SetAutoPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_DebugGlobalGI_C.__SetAutoPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->AutoPlay = AutoPlay;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DebugGlobalGI_C.__SetAutoPlay_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060248BA RID: 149690 RVA: 0x009A0890 File Offset: 0x0099EA90
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetInterval(float Interval)
		{
			BP_DebugGlobalGI_C.__SetInterval_FunctionParams* ptr = stackalloc BP_DebugGlobalGI_C.__SetInterval_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_DebugGlobalGI_C.__SetInterval_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_DebugGlobalGI_C.__SetInterval_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Interval = Interval;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DebugGlobalGI_C.__SetInterval_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060248BB RID: 149691 RVA: 0x009A08D8 File Offset: 0x0099EAD8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetTime(float Time)
		{
			BP_DebugGlobalGI_C.__SetTime_FunctionParams* ptr = stackalloc BP_DebugGlobalGI_C.__SetTime_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(BP_DebugGlobalGI_C.__SetTime_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_DebugGlobalGI_C.__SetTime_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Time = Time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DebugGlobalGI_C.__SetTime_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060248BC RID: 149692 RVA: 0x009A0920 File Offset: 0x0099EB20
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void IsGIValid(ref bool IsValid)
		{
			BP_DebugGlobalGI_C.__IsGIValid_FunctionParams* ptr = stackalloc BP_DebugGlobalGI_C.__IsGIValid_FunctionParams[(UIntPtr)17] + 15L / (long)sizeof(BP_DebugGlobalGI_C.__IsGIValid_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_DebugGlobalGI_C.__IsGIValid_NativeFunctionPtr, (void*)ptr, 1);
			ptr->IsValid = IsValid;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DebugGlobalGI_C.__IsGIValid_NativeFunctionPtr, (void*)ptr);
			IsValid = ptr->IsValid;
		}

		// Token: 0x060248BD RID: 149693 RVA: 0x009A096F File Offset: 0x0099EB6F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateGIInfo()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DebugGlobalGI_C.__UpdateGIInfo_NativeFunctionPtr, null);
		}

		// Token: 0x060248BE RID: 149694 RVA: 0x009A0983 File Offset: 0x0099EB83
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void FindGI()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DebugGlobalGI_C.__FindGI_NativeFunctionPtr, null);
		}

		// Token: 0x060248BF RID: 149695 RVA: 0x009A0997 File Offset: 0x0099EB97
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void BndEvt__BP_DebugGlobalGI_BtnUpdate_K2Node_ComponentBoundEvent_0_OnButtonClickedEvent__DelegateSignature()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DebugGlobalGI_C.__BndEvt__BP_DebugGlobalGI_BtnUpdate_K2Node_ComponentBoundEvent_0_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr, null);
		}

		// Token: 0x060248C0 RID: 149696 RVA: 0x009A09AB File Offset: 0x0099EBAB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void BndEvt__BP_DebugGlobalGI_Btn_0_K2Node_ComponentBoundEvent_1_OnButtonClickedEvent__DelegateSignature()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DebugGlobalGI_C.__BndEvt__BP_DebugGlobalGI_Btn_0_K2Node_ComponentBoundEvent_1_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr, null);
		}

		// Token: 0x060248C1 RID: 149697 RVA: 0x009A09BF File Offset: 0x0099EBBF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void BndEvt__BP_DebugGlobalGI_Btn_3_K2Node_ComponentBoundEvent_2_OnButtonClickedEvent__DelegateSignature()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DebugGlobalGI_C.__BndEvt__BP_DebugGlobalGI_Btn_3_K2Node_ComponentBoundEvent_2_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr, null);
		}

		// Token: 0x060248C2 RID: 149698 RVA: 0x009A09D3 File Offset: 0x0099EBD3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void BndEvt__BP_DebugGlobalGI_Btn_6_K2Node_ComponentBoundEvent_3_OnButtonClickedEvent__DelegateSignature()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DebugGlobalGI_C.__BndEvt__BP_DebugGlobalGI_Btn_6_K2Node_ComponentBoundEvent_3_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr, null);
		}

		// Token: 0x060248C3 RID: 149699 RVA: 0x009A09E7 File Offset: 0x0099EBE7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void BndEvt__BP_DebugGlobalGI_Btn_9_K2Node_ComponentBoundEvent_4_OnButtonClickedEvent__DelegateSignature()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DebugGlobalGI_C.__BndEvt__BP_DebugGlobalGI_Btn_9_K2Node_ComponentBoundEvent_4_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr, null);
		}

		// Token: 0x060248C4 RID: 149700 RVA: 0x009A09FB File Offset: 0x0099EBFB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void BndEvt__BP_DebugGlobalGI_Btn_12_K2Node_ComponentBoundEvent_5_OnButtonClickedEvent__DelegateSignature()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DebugGlobalGI_C.__BndEvt__BP_DebugGlobalGI_Btn_12_K2Node_ComponentBoundEvent_5_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr, null);
		}

		// Token: 0x060248C5 RID: 149701 RVA: 0x009A0A0F File Offset: 0x0099EC0F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void BndEvt__BP_DebugGlobalGI_Btn_15_K2Node_ComponentBoundEvent_6_OnButtonClickedEvent__DelegateSignature()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DebugGlobalGI_C.__BndEvt__BP_DebugGlobalGI_Btn_15_K2Node_ComponentBoundEvent_6_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr, null);
		}

		// Token: 0x060248C6 RID: 149702 RVA: 0x009A0A23 File Offset: 0x0099EC23
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void BndEvt__BP_DebugGlobalGI_Btn_18_K2Node_ComponentBoundEvent_7_OnButtonClickedEvent__DelegateSignature()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DebugGlobalGI_C.__BndEvt__BP_DebugGlobalGI_Btn_18_K2Node_ComponentBoundEvent_7_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr, null);
		}

		// Token: 0x060248C7 RID: 149703 RVA: 0x009A0A37 File Offset: 0x0099EC37
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void BndEvt__BP_DebugGlobalGI_Btn_21_K2Node_ComponentBoundEvent_8_OnButtonClickedEvent__DelegateSignature()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DebugGlobalGI_C.__BndEvt__BP_DebugGlobalGI_Btn_21_K2Node_ComponentBoundEvent_8_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr, null);
		}

		// Token: 0x060248C8 RID: 149704 RVA: 0x009A0A4B File Offset: 0x0099EC4B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void BndEvt__BP_DebugGlobalGI_BtnSetInterval_K2Node_ComponentBoundEvent_9_OnButtonClickedEvent__DelegateSignature()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DebugGlobalGI_C.__BndEvt__BP_DebugGlobalGI_BtnSetInterval_K2Node_ComponentBoundEvent_9_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr, null);
		}

		// Token: 0x060248C9 RID: 149705 RVA: 0x009A0A5F File Offset: 0x0099EC5F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void BndEvt__BP_DebugGlobalGI_BtnSetTime_K2Node_ComponentBoundEvent_10_OnButtonClickedEvent__DelegateSignature()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DebugGlobalGI_C.__BndEvt__BP_DebugGlobalGI_BtnSetTime_K2Node_ComponentBoundEvent_10_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr, null);
		}

		// Token: 0x060248CA RID: 149706 RVA: 0x009A0A73 File Offset: 0x0099EC73
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void BndEvt__BP_DebugGlobalGI_BtnStart_K2Node_ComponentBoundEvent_11_OnButtonClickedEvent__DelegateSignature()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DebugGlobalGI_C.__BndEvt__BP_DebugGlobalGI_BtnStart_K2Node_ComponentBoundEvent_11_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr, null);
		}

		// Token: 0x060248CB RID: 149707 RVA: 0x009A0A87 File Offset: 0x0099EC87
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void BndEvt__BP_DebugGlobalGI_BtnStop_K2Node_ComponentBoundEvent_12_OnButtonClickedEvent__DelegateSignature()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DebugGlobalGI_C.__BndEvt__BP_DebugGlobalGI_BtnStop_K2Node_ComponentBoundEvent_12_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr, null);
		}

		// Token: 0x060248CC RID: 149708 RVA: 0x009A0A9C File Offset: 0x0099EC9C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void Tick(FGeometry MyGeometry, float InDeltaTime)
		{
			BP_DebugGlobalGI_C.__Tick_FunctionParams* ptr = stackalloc BP_DebugGlobalGI_C.__Tick_FunctionParams[(UIntPtr)75] + 15L / (long)sizeof(BP_DebugGlobalGI_C.__Tick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_DebugGlobalGI_C.__Tick_NativeFunctionPtr, (void*)ptr, 1);
			if (MyGeometry != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FGeometry.StaticStruct(), &ptr->MyGeometry, MyGeometry.NativePtr, 1, false);
			}
			ptr->InDeltaTime = InDeltaTime;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DebugGlobalGI_C.__Tick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060248CD RID: 149709 RVA: 0x009A0B04 File Offset: 0x0099ED04
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void Tick_Implementation(FGeometry MyGeometry, float InDeltaTime)
		{
			BP_DebugGlobalGI_C.__Tick_FunctionParams* ptr = stackalloc BP_DebugGlobalGI_C.__Tick_FunctionParams[(UIntPtr)75] + 15L / (long)sizeof(BP_DebugGlobalGI_C.__Tick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_DebugGlobalGI_C.__Tick_NativeFunctionPtr, (void*)ptr, 1);
			if (MyGeometry != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FGeometry.StaticStruct(), &ptr->MyGeometry, MyGeometry.NativePtr, 1, false);
			}
			ptr->InDeltaTime = InDeltaTime;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_DebugGlobalGI_C.__Tick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060248CE RID: 149710 RVA: 0x009A0B6D File Offset: 0x0099ED6D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void BndEvt__BP_DebugGlobalGI_BtnTime_0_K2Node_ComponentBoundEvent_13_OnButtonClickedEvent__DelegateSignature()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DebugGlobalGI_C.__BndEvt__BP_DebugGlobalGI_BtnTime_0_K2Node_ComponentBoundEvent_13_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr, null);
		}

		// Token: 0x060248CF RID: 149711 RVA: 0x009A0B81 File Offset: 0x0099ED81
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void BndEvt__BP_DebugGlobalGI_BtnTime_1_K2Node_ComponentBoundEvent_14_OnButtonClickedEvent__DelegateSignature()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DebugGlobalGI_C.__BndEvt__BP_DebugGlobalGI_BtnTime_1_K2Node_ComponentBoundEvent_14_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr, null);
		}

		// Token: 0x060248D0 RID: 149712 RVA: 0x009A0B95 File Offset: 0x0099ED95
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void BndEvt__BP_DebugGlobalGI_BtnTime_2_K2Node_ComponentBoundEvent_15_OnButtonClickedEvent__DelegateSignature()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DebugGlobalGI_C.__BndEvt__BP_DebugGlobalGI_BtnTime_2_K2Node_ComponentBoundEvent_15_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr, null);
		}

		// Token: 0x060248D1 RID: 149713 RVA: 0x009A0BA9 File Offset: 0x0099EDA9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void BndEvt__BP_DebugGlobalGI_BtnTime_K2Node_ComponentBoundEvent_16_OnButtonClickedEvent__DelegateSignature()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DebugGlobalGI_C.__BndEvt__BP_DebugGlobalGI_BtnTime_K2Node_ComponentBoundEvent_16_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr, null);
		}

		// Token: 0x060248D2 RID: 149714 RVA: 0x009A0BBD File Offset: 0x0099EDBD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void BndEvt__BP_DebugGlobalGI_BtnTime_3_K2Node_ComponentBoundEvent_17_OnButtonClickedEvent__DelegateSignature()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DebugGlobalGI_C.__BndEvt__BP_DebugGlobalGI_BtnTime_3_K2Node_ComponentBoundEvent_17_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr, null);
		}

		// Token: 0x060248D3 RID: 149715 RVA: 0x009A0BD1 File Offset: 0x0099EDD1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void BndEvt__BP_DebugGlobalGI_BtnTime_4_K2Node_ComponentBoundEvent_18_OnButtonClickedEvent__DelegateSignature()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DebugGlobalGI_C.__BndEvt__BP_DebugGlobalGI_BtnTime_4_K2Node_ComponentBoundEvent_18_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr, null);
		}

		// Token: 0x060248D4 RID: 149716 RVA: 0x009A0BE5 File Offset: 0x0099EDE5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void BndEvt__BP_DebugGlobalGI_BtnClose_K2Node_ComponentBoundEvent_19_OnButtonClickedEvent__DelegateSignature()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DebugGlobalGI_C.__BndEvt__BP_DebugGlobalGI_BtnClose_K2Node_ComponentBoundEvent_19_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr, null);
		}

		// Token: 0x060248D5 RID: 149717 RVA: 0x009A0BF9 File Offset: 0x0099EDF9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void BndEvt__BP_DebugGlobalGI_BtnTime_5_K2Node_ComponentBoundEvent_20_OnButtonClickedEvent__DelegateSignature()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DebugGlobalGI_C.__BndEvt__BP_DebugGlobalGI_BtnTime_5_K2Node_ComponentBoundEvent_20_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr, null);
		}

		// Token: 0x060248D6 RID: 149718 RVA: 0x009A0C0D File Offset: 0x0099EE0D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void BndEvt__BP_DebugGlobalGI_BtnTime_6_K2Node_ComponentBoundEvent_21_OnButtonClickedEvent__DelegateSignature()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DebugGlobalGI_C.__BndEvt__BP_DebugGlobalGI_BtnTime_6_K2Node_ComponentBoundEvent_21_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr, null);
		}

		// Token: 0x060248D7 RID: 149719 RVA: 0x009A0C21 File Offset: 0x0099EE21
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void BndEvt__BP_DebugGlobalGI_BtnTime_7_K2Node_ComponentBoundEvent_22_OnButtonClickedEvent__DelegateSignature()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DebugGlobalGI_C.__BndEvt__BP_DebugGlobalGI_BtnTime_7_K2Node_ComponentBoundEvent_22_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr, null);
		}

		// Token: 0x060248D8 RID: 149720 RVA: 0x009A0C35 File Offset: 0x0099EE35
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void BndEvt__BP_DebugGlobalGI_BtnTime_8_K2Node_ComponentBoundEvent_23_OnButtonClickedEvent__DelegateSignature()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DebugGlobalGI_C.__BndEvt__BP_DebugGlobalGI_BtnTime_8_K2Node_ComponentBoundEvent_23_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr, null);
		}

		// Token: 0x060248D9 RID: 149721 RVA: 0x009A0C49 File Offset: 0x0099EE49
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void BndEvt__BP_DebugGlobalGI_BtnSetInterval_1_K2Node_ComponentBoundEvent_24_OnButtonClickedEvent__DelegateSignature()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DebugGlobalGI_C.__BndEvt__BP_DebugGlobalGI_BtnSetInterval_1_K2Node_ComponentBoundEvent_24_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr, null);
		}

		// Token: 0x060248DA RID: 149722 RVA: 0x009A0C5D File Offset: 0x0099EE5D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void BndEvt__BP_DebugGlobalGI_BtnSetInterval_2_K2Node_ComponentBoundEvent_25_OnButtonClickedEvent__DelegateSignature()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DebugGlobalGI_C.__BndEvt__BP_DebugGlobalGI_BtnSetInterval_2_K2Node_ComponentBoundEvent_25_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr, null);
		}

		// Token: 0x060248DB RID: 149723 RVA: 0x009A0C71 File Offset: 0x0099EE71
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void BndEvt__BP_DebugGlobalGI_BtnSetInterval_3_K2Node_ComponentBoundEvent_26_OnButtonClickedEvent__DelegateSignature()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DebugGlobalGI_C.__BndEvt__BP_DebugGlobalGI_BtnSetInterval_3_K2Node_ComponentBoundEvent_26_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr, null);
		}

		// Token: 0x060248DC RID: 149724 RVA: 0x009A0C85 File Offset: 0x0099EE85
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBegin()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DebugGlobalGI_C.__OnBegin_NativeFunctionPtr, null);
		}

		// Token: 0x060248DD RID: 149725 RVA: 0x009A0C99 File Offset: 0x0099EE99
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void BndEvt__BP_DebugGlobalGI_BtnCloseLightFunction_K2Node_ComponentBoundEvent_27_OnButtonClickedEvent__DelegateSignature()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DebugGlobalGI_C.__BndEvt__BP_DebugGlobalGI_BtnCloseLightFunction_K2Node_ComponentBoundEvent_27_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr, null);
		}

		// Token: 0x060248DE RID: 149726 RVA: 0x009A0CAD File Offset: 0x0099EEAD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void BndEvt__BP_DebugGlobalGI_BtnCloseLightFunction_1_K2Node_ComponentBoundEvent_28_OnButtonClickedEvent__DelegateSignature()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DebugGlobalGI_C.__BndEvt__BP_DebugGlobalGI_BtnCloseLightFunction_1_K2Node_ComponentBoundEvent_28_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr, null);
		}

		// Token: 0x060248DF RID: 149727 RVA: 0x009A0CC1 File Offset: 0x0099EEC1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void BndEvt__BP_DebugGlobalGI_BtnTestUiScene_K2Node_ComponentBoundEvent_29_OnButtonClickedEvent__DelegateSignature()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DebugGlobalGI_C.__BndEvt__BP_DebugGlobalGI_BtnTestUiScene_K2Node_ComponentBoundEvent_29_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr, null);
		}

		// Token: 0x060248E0 RID: 149728 RVA: 0x009A0CD5 File Offset: 0x0099EED5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void BndEvt__BP_DebugGlobalGI_BtnCloseStoneAo_K2Node_ComponentBoundEvent_30_OnButtonClickedEvent__DelegateSignature()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DebugGlobalGI_C.__BndEvt__BP_DebugGlobalGI_BtnCloseStoneAo_K2Node_ComponentBoundEvent_30_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr, null);
		}

		// Token: 0x060248E1 RID: 149729 RVA: 0x009A0CE9 File Offset: 0x0099EEE9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void BndEvt__BP_DebugGlobalGI_BtnCloseStoneAo_1_K2Node_ComponentBoundEvent_31_OnButtonClickedEvent__DelegateSignature()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DebugGlobalGI_C.__BndEvt__BP_DebugGlobalGI_BtnCloseStoneAo_1_K2Node_ComponentBoundEvent_31_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr, null);
		}

		// Token: 0x060248E2 RID: 149730 RVA: 0x009A0CFD File Offset: 0x0099EEFD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void BndEvt__BP_DebugGlobalGI_BtnOpenNewUiScene_K2Node_ComponentBoundEvent_32_OnButtonClickedEvent__DelegateSignature()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DebugGlobalGI_C.__BndEvt__BP_DebugGlobalGI_BtnOpenNewUiScene_K2Node_ComponentBoundEvent_32_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr, null);
		}

		// Token: 0x060248E3 RID: 149731 RVA: 0x009A0D11 File Offset: 0x0099EF11
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void BndEvt__BP_DebugGlobalGI_BtnCloseNewUiScene_K2Node_ComponentBoundEvent_33_OnButtonClickedEvent__DelegateSignature()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DebugGlobalGI_C.__BndEvt__BP_DebugGlobalGI_BtnCloseNewUiScene_K2Node_ComponentBoundEvent_33_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr, null);
		}

		// Token: 0x060248E4 RID: 149732 RVA: 0x009A0D25 File Offset: 0x0099EF25
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void BndEvt__BP_DebugGlobalGI_BtnChangeCloudMove_K2Node_ComponentBoundEvent_34_OnButtonClickedEvent__DelegateSignature()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DebugGlobalGI_C.__BndEvt__BP_DebugGlobalGI_BtnChangeCloudMove_K2Node_ComponentBoundEvent_34_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr, null);
		}

		// Token: 0x060248E5 RID: 149733 RVA: 0x009A0D39 File Offset: 0x0099EF39
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void BndEvt__BP_DebugGlobalGI_BtnCloseCloudMove_K2Node_ComponentBoundEvent_35_OnButtonClickedEvent__DelegateSignature()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DebugGlobalGI_C.__BndEvt__BP_DebugGlobalGI_BtnCloseCloudMove_K2Node_ComponentBoundEvent_35_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr, null);
		}

		// Token: 0x060248E6 RID: 149734 RVA: 0x009A0D50 File Offset: 0x0099EF50
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_DebugGlobalGI_TextInput_Time_1_K2Node_ComponentBoundEvent_36_OnEditableTextChangedEvent__DelegateSignature(in FText Text)
		{
			BP_DebugGlobalGI_C.__BndEvt__BP_DebugGlobalGI_TextInput_Time_1_K2Node_ComponentBoundEvent_36_OnEditableTextChangedEvent__DelegateSignature_FunctionParams* ptr = stackalloc BP_DebugGlobalGI_C.__BndEvt__BP_DebugGlobalGI_TextInput_Time_1_K2Node_ComponentBoundEvent_36_OnEditableTextChangedEvent__DelegateSignature_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_DebugGlobalGI_C.__BndEvt__BP_DebugGlobalGI_TextInput_Time_1_K2Node_ComponentBoundEvent_36_OnEditableTextChangedEvent__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_DebugGlobalGI_C.__BndEvt__BP_DebugGlobalGI_TextInput_Time_1_K2Node_ComponentBoundEvent_36_OnEditableTextChangedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			FText.NativeMove((void*)(&ptr->Text), Text.NativePtr);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DebugGlobalGI_C.__BndEvt__BP_DebugGlobalGI_TextInput_Time_1_K2Node_ComponentBoundEvent_36_OnEditableTextChangedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(BP_DebugGlobalGI_C.__BndEvt__BP_DebugGlobalGI_TextInput_Time_1_K2Node_ComponentBoundEvent_36_OnEditableTextChangedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x060248E7 RID: 149735 RVA: 0x009A0DB4 File Offset: 0x0099EFB4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_DebugGlobalGI(int EntryPoint)
		{
			BP_DebugGlobalGI_C.__ExecuteUbergraph_BP_DebugGlobalGI_FunctionParams* ptr = stackalloc BP_DebugGlobalGI_C.__ExecuteUbergraph_BP_DebugGlobalGI_FunctionParams[(UIntPtr)527] + 15L / (long)sizeof(BP_DebugGlobalGI_C.__ExecuteUbergraph_BP_DebugGlobalGI_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_DebugGlobalGI_C.__ExecuteUbergraph_BP_DebugGlobalGI_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_DebugGlobalGI_C.__ExecuteUbergraph_BP_DebugGlobalGI_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060248E8 RID: 149736 RVA: 0x009A0DFE File Offset: 0x0099EFFE
		protected BP_DebugGlobalGI_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04012B64 RID: 76644
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/GI/UI/BP_DebugGlobalGI.BP_DebugGlobalGI_C";

		// Token: 0x04012B65 RID: 76645
		private static IntPtr _ClassPtr;

		// Token: 0x04012B66 RID: 76646
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04012B67 RID: 76647
		internal static int __PropertyOffset_0;

		// Token: 0x04012B68 RID: 76648
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04012B69 RID: 76649
		internal static int __PropertyOffset_1;

		// Token: 0x04012B6A RID: 76650
		internal static int __PropertyOffset_2;

		// Token: 0x04012B6B RID: 76651
		internal static int __PropertyOffset_3;

		// Token: 0x04012B6C RID: 76652
		internal static int __PropertyOffset_4;

		// Token: 0x04012B6D RID: 76653
		internal static int __PropertyOffset_5;

		// Token: 0x04012B6E RID: 76654
		internal static int __PropertyOffset_6;

		// Token: 0x04012B6F RID: 76655
		internal static int __PropertyOffset_7;

		// Token: 0x04012B70 RID: 76656
		internal static int __PropertyOffset_8;

		// Token: 0x04012B71 RID: 76657
		internal static int __PropertyOffset_9;

		// Token: 0x04012B72 RID: 76658
		internal static int __PropertyOffset_10;

		// Token: 0x04012B73 RID: 76659
		internal static int __PropertyOffset_11;

		// Token: 0x04012B74 RID: 76660
		internal static int __PropertyOffset_12;

		// Token: 0x04012B75 RID: 76661
		internal static int __PropertyOffset_13;

		// Token: 0x04012B76 RID: 76662
		internal static int __PropertyOffset_14;

		// Token: 0x04012B77 RID: 76663
		internal static int __PropertyOffset_15;

		// Token: 0x04012B78 RID: 76664
		internal static int __PropertyOffset_16;

		// Token: 0x04012B79 RID: 76665
		internal static int __PropertyOffset_17;

		// Token: 0x04012B7A RID: 76666
		internal static int __PropertyOffset_18;

		// Token: 0x04012B7B RID: 76667
		internal static int __PropertyOffset_19;

		// Token: 0x04012B7C RID: 76668
		internal static int __PropertyOffset_20;

		// Token: 0x04012B7D RID: 76669
		internal static int __PropertyOffset_21;

		// Token: 0x04012B7E RID: 76670
		internal static int __PropertyOffset_22;

		// Token: 0x04012B7F RID: 76671
		internal static int __PropertyOffset_23;

		// Token: 0x04012B80 RID: 76672
		internal static int __PropertyOffset_24;

		// Token: 0x04012B81 RID: 76673
		internal static int __PropertyOffset_25;

		// Token: 0x04012B82 RID: 76674
		internal static int __PropertyOffset_26;

		// Token: 0x04012B83 RID: 76675
		internal static int __PropertyOffset_27;

		// Token: 0x04012B84 RID: 76676
		internal static int __PropertyOffset_28;

		// Token: 0x04012B85 RID: 76677
		internal static int __PropertyOffset_29;

		// Token: 0x04012B86 RID: 76678
		internal static int __PropertyOffset_30;

		// Token: 0x04012B87 RID: 76679
		internal static int __PropertyOffset_31;

		// Token: 0x04012B88 RID: 76680
		internal static int __PropertyOffset_32;

		// Token: 0x04012B89 RID: 76681
		internal static int __PropertyOffset_33;

		// Token: 0x04012B8A RID: 76682
		internal static int __PropertyOffset_34;

		// Token: 0x04012B8B RID: 76683
		internal static int __PropertyOffset_35;

		// Token: 0x04012B8C RID: 76684
		internal static int __PropertyOffset_36;

		// Token: 0x04012B8D RID: 76685
		internal static int __PropertyOffset_37;

		// Token: 0x04012B8E RID: 76686
		internal static int __PropertyOffset_38;

		// Token: 0x04012B8F RID: 76687
		internal static int __PropertyOffset_39;

		// Token: 0x04012B90 RID: 76688
		internal static int __PropertyOffset_40;

		// Token: 0x04012B91 RID: 76689
		internal static int __PropertyOffset_41;

		// Token: 0x04012B92 RID: 76690
		internal static int __PropertyOffset_42;

		// Token: 0x04012B93 RID: 76691
		internal static int __PropertyOffset_43;

		// Token: 0x04012B94 RID: 76692
		private static IntPtr __SetAutoPlay_NativeFunctionPtr;

		// Token: 0x04012B95 RID: 76693
		private static IntPtr __SetInterval_NativeFunctionPtr;

		// Token: 0x04012B96 RID: 76694
		private static IntPtr __SetTime_NativeFunctionPtr;

		// Token: 0x04012B97 RID: 76695
		private static IntPtr __IsGIValid_NativeFunctionPtr;

		// Token: 0x04012B98 RID: 76696
		private static IntPtr __UpdateGIInfo_NativeFunctionPtr;

		// Token: 0x04012B99 RID: 76697
		private static IntPtr __FindGI_NativeFunctionPtr;

		// Token: 0x04012B9A RID: 76698
		private static IntPtr __BndEvt__BP_DebugGlobalGI_BtnUpdate_K2Node_ComponentBoundEvent_0_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04012B9B RID: 76699
		private static IntPtr __BndEvt__BP_DebugGlobalGI_Btn_0_K2Node_ComponentBoundEvent_1_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04012B9C RID: 76700
		private static IntPtr __BndEvt__BP_DebugGlobalGI_Btn_3_K2Node_ComponentBoundEvent_2_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04012B9D RID: 76701
		private static IntPtr __BndEvt__BP_DebugGlobalGI_Btn_6_K2Node_ComponentBoundEvent_3_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04012B9E RID: 76702
		private static IntPtr __BndEvt__BP_DebugGlobalGI_Btn_9_K2Node_ComponentBoundEvent_4_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04012B9F RID: 76703
		private static IntPtr __BndEvt__BP_DebugGlobalGI_Btn_12_K2Node_ComponentBoundEvent_5_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04012BA0 RID: 76704
		private static IntPtr __BndEvt__BP_DebugGlobalGI_Btn_15_K2Node_ComponentBoundEvent_6_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04012BA1 RID: 76705
		private static IntPtr __BndEvt__BP_DebugGlobalGI_Btn_18_K2Node_ComponentBoundEvent_7_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04012BA2 RID: 76706
		private static IntPtr __BndEvt__BP_DebugGlobalGI_Btn_21_K2Node_ComponentBoundEvent_8_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04012BA3 RID: 76707
		private static IntPtr __BndEvt__BP_DebugGlobalGI_BtnSetInterval_K2Node_ComponentBoundEvent_9_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04012BA4 RID: 76708
		private static IntPtr __BndEvt__BP_DebugGlobalGI_BtnSetTime_K2Node_ComponentBoundEvent_10_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04012BA5 RID: 76709
		private static IntPtr __BndEvt__BP_DebugGlobalGI_BtnStart_K2Node_ComponentBoundEvent_11_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04012BA6 RID: 76710
		private static IntPtr __BndEvt__BP_DebugGlobalGI_BtnStop_K2Node_ComponentBoundEvent_12_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04012BA7 RID: 76711
		private static IntPtr __Tick_NativeFunctionPtr;

		// Token: 0x04012BA8 RID: 76712
		private static IntPtr __BndEvt__BP_DebugGlobalGI_BtnTime_0_K2Node_ComponentBoundEvent_13_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04012BA9 RID: 76713
		private static IntPtr __BndEvt__BP_DebugGlobalGI_BtnTime_1_K2Node_ComponentBoundEvent_14_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04012BAA RID: 76714
		private static IntPtr __BndEvt__BP_DebugGlobalGI_BtnTime_2_K2Node_ComponentBoundEvent_15_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04012BAB RID: 76715
		private static IntPtr __BndEvt__BP_DebugGlobalGI_BtnTime_K2Node_ComponentBoundEvent_16_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04012BAC RID: 76716
		private static IntPtr __BndEvt__BP_DebugGlobalGI_BtnTime_3_K2Node_ComponentBoundEvent_17_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04012BAD RID: 76717
		private static IntPtr __BndEvt__BP_DebugGlobalGI_BtnTime_4_K2Node_ComponentBoundEvent_18_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04012BAE RID: 76718
		private static IntPtr __BndEvt__BP_DebugGlobalGI_BtnClose_K2Node_ComponentBoundEvent_19_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04012BAF RID: 76719
		private static IntPtr __BndEvt__BP_DebugGlobalGI_BtnTime_5_K2Node_ComponentBoundEvent_20_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04012BB0 RID: 76720
		private static IntPtr __BndEvt__BP_DebugGlobalGI_BtnTime_6_K2Node_ComponentBoundEvent_21_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04012BB1 RID: 76721
		private static IntPtr __BndEvt__BP_DebugGlobalGI_BtnTime_7_K2Node_ComponentBoundEvent_22_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04012BB2 RID: 76722
		private static IntPtr __BndEvt__BP_DebugGlobalGI_BtnTime_8_K2Node_ComponentBoundEvent_23_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04012BB3 RID: 76723
		private static IntPtr __BndEvt__BP_DebugGlobalGI_BtnSetInterval_1_K2Node_ComponentBoundEvent_24_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04012BB4 RID: 76724
		private static IntPtr __BndEvt__BP_DebugGlobalGI_BtnSetInterval_2_K2Node_ComponentBoundEvent_25_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04012BB5 RID: 76725
		private static IntPtr __BndEvt__BP_DebugGlobalGI_BtnSetInterval_3_K2Node_ComponentBoundEvent_26_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04012BB6 RID: 76726
		private static IntPtr __OnBegin_NativeFunctionPtr;

		// Token: 0x04012BB7 RID: 76727
		private static IntPtr __BndEvt__BP_DebugGlobalGI_BtnCloseLightFunction_K2Node_ComponentBoundEvent_27_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04012BB8 RID: 76728
		private static IntPtr __BndEvt__BP_DebugGlobalGI_BtnCloseLightFunction_1_K2Node_ComponentBoundEvent_28_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04012BB9 RID: 76729
		private static IntPtr __BndEvt__BP_DebugGlobalGI_BtnTestUiScene_K2Node_ComponentBoundEvent_29_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04012BBA RID: 76730
		private static IntPtr __BndEvt__BP_DebugGlobalGI_BtnCloseStoneAo_K2Node_ComponentBoundEvent_30_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04012BBB RID: 76731
		private static IntPtr __BndEvt__BP_DebugGlobalGI_BtnCloseStoneAo_1_K2Node_ComponentBoundEvent_31_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04012BBC RID: 76732
		private static IntPtr __BndEvt__BP_DebugGlobalGI_BtnOpenNewUiScene_K2Node_ComponentBoundEvent_32_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04012BBD RID: 76733
		private static IntPtr __BndEvt__BP_DebugGlobalGI_BtnCloseNewUiScene_K2Node_ComponentBoundEvent_33_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04012BBE RID: 76734
		private static IntPtr __BndEvt__BP_DebugGlobalGI_BtnChangeCloudMove_K2Node_ComponentBoundEvent_34_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04012BBF RID: 76735
		private static IntPtr __BndEvt__BP_DebugGlobalGI_BtnCloseCloudMove_K2Node_ComponentBoundEvent_35_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04012BC0 RID: 76736
		private static IntPtr __BndEvt__BP_DebugGlobalGI_TextInput_Time_1_K2Node_ComponentBoundEvent_36_OnEditableTextChangedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04012BC1 RID: 76737
		private static IntPtr __ExecuteUbergraph_BP_DebugGlobalGI_NativeFunctionPtr;

		// Token: 0x02009E05 RID: 40453
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __SetAutoPlay_FunctionParams
		{
			// Token: 0x0403284B RID: 206923
			[FieldOffset(0)]
			public bool AutoPlay;
		}

		// Token: 0x02009E06 RID: 40454
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __SetInterval_FunctionParams
		{
			// Token: 0x0403284C RID: 206924
			[FieldOffset(0)]
			public float Interval;
		}

		// Token: 0x02009E07 RID: 40455
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __SetTime_FunctionParams
		{
			// Token: 0x0403284D RID: 206925
			[FieldOffset(0)]
			public float Time;
		}

		// Token: 0x02009E08 RID: 40456
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 2)]
		protected ref struct __IsGIValid_FunctionParams
		{
			// Token: 0x0403284E RID: 206926
			[FieldOffset(0)]
			public bool IsValid;
		}

		// Token: 0x02009E09 RID: 40457
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 60)]
		protected new ref struct __Tick_FunctionParams
		{
			// Token: 0x0403284F RID: 206927
			[FieldOffset(0)]
			public byte MyGeometry;

			// Token: 0x04032850 RID: 206928
			[FieldOffset(56)]
			public float InDeltaTime;
		}

		// Token: 0x02009E0A RID: 40458
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __BndEvt__BP_DebugGlobalGI_TextInput_Time_1_K2Node_ComponentBoundEvent_36_OnEditableTextChangedEvent__DelegateSignature_FunctionParams
		{
			// Token: 0x04032851 RID: 206929
			[FieldOffset(0)]
			public byte Text;
		}

		// Token: 0x02009E0B RID: 40459
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 512)]
		protected ref struct __ExecuteUbergraph_BP_DebugGlobalGI_FunctionParams
		{
			// Token: 0x04032852 RID: 206930
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
