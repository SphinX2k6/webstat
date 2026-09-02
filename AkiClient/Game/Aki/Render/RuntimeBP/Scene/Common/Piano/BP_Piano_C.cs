using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Common.Piano
{
	// Token: 0x02003AE6 RID: 15078
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Common/Piano/BP_Piano.BP_Piano_C")]
	[UnrealStructLayout(1840, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1840)]
	public class BP_Piano_C : AKuroGameBudgetBlueprintActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060205B6 RID: 132534 RVA: 0x00929928 File Offset: 0x00927B28
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_Piano_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Common/Piano/BP_Piano.BP_Piano_C");
			}
			return BP_Piano_C._ClassPtr;
		}

		// Token: 0x060205B7 RID: 132535 RVA: 0x0092994C File Offset: 0x00927B4C
		public BP_Piano_C() : this(BuiltinUtils.AllocNativeUObject(BP_Piano_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060205B8 RID: 132536 RVA: 0x00929974 File Offset: 0x00927B74
		[NullableContext(1)]
		public BP_Piano_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_Piano_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700353C RID: 13628
		// (get) Token: 0x060205B9 RID: 132537 RVA: 0x009299A8 File Offset: 0x00927BA8
		// (set) Token: 0x060205BA RID: 132538 RVA: 0x009299E1 File Offset: 0x00927BE1
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_Piano_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_Piano_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700353D RID: 13629
		// (get) Token: 0x060205BB RID: 132539 RVA: 0x00929A02 File Offset: 0x00927C02
		// (set) Token: 0x060205BC RID: 132540 RVA: 0x00929A16 File Offset: 0x00927C16
		public unsafe UBoxComponent Box
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x1700353E RID: 13630
		// (get) Token: 0x060205BD RID: 132541 RVA: 0x00929A2B File Offset: 0x00927C2B
		// (set) Token: 0x060205BE RID: 132542 RVA: 0x00929A3F File Offset: 0x00927C3F
		public unsafe UStaticMeshComponent StaticMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x1700353F RID: 13631
		// (get) Token: 0x060205BF RID: 132543 RVA: 0x00929A54 File Offset: 0x00927C54
		// (set) Token: 0x060205C0 RID: 132544 RVA: 0x00929A68 File Offset: 0x00927C68
		public unsafe UChildActorComponent Note_3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17003540 RID: 13632
		// (get) Token: 0x060205C1 RID: 132545 RVA: 0x00929A7D File Offset: 0x00927C7D
		// (set) Token: 0x060205C2 RID: 132546 RVA: 0x00929A91 File Offset: 0x00927C91
		public unsafe UChildActorComponent Note_2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17003541 RID: 13633
		// (get) Token: 0x060205C3 RID: 132547 RVA: 0x00929AA6 File Offset: 0x00927CA6
		// (set) Token: 0x060205C4 RID: 132548 RVA: 0x00929ABA File Offset: 0x00927CBA
		public unsafe UChildActorComponent Note_1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17003542 RID: 13634
		// (get) Token: 0x060205C5 RID: 132549 RVA: 0x00929ACF File Offset: 0x00927CCF
		// (set) Token: 0x060205C6 RID: 132550 RVA: 0x00929AE3 File Offset: 0x00927CE3
		public unsafe UChildActorComponent Key_C4
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x17003543 RID: 13635
		// (get) Token: 0x060205C7 RID: 132551 RVA: 0x00929AF8 File Offset: 0x00927CF8
		// (set) Token: 0x060205C8 RID: 132552 RVA: 0x00929B0C File Offset: 0x00927D0C
		public unsafe USceneComponent Group3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x17003544 RID: 13636
		// (get) Token: 0x060205C9 RID: 132553 RVA: 0x00929B21 File Offset: 0x00927D21
		// (set) Token: 0x060205CA RID: 132554 RVA: 0x00929B35 File Offset: 0x00927D35
		public unsafe USceneComponent Group2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x17003545 RID: 13637
		// (get) Token: 0x060205CB RID: 132555 RVA: 0x00929B4A File Offset: 0x00927D4A
		// (set) Token: 0x060205CC RID: 132556 RVA: 0x00929B5E File Offset: 0x00927D5E
		public unsafe USceneComponent Group1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_9);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_9, value);
			}
		}

		// Token: 0x17003546 RID: 13638
		// (get) Token: 0x060205CD RID: 132557 RVA: 0x00929B73 File Offset: 0x00927D73
		// (set) Token: 0x060205CE RID: 132558 RVA: 0x00929B87 File Offset: 0x00927D87
		public unsafe UChildActorComponent Key_ASharp2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_10);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_10, value);
			}
		}

		// Token: 0x17003547 RID: 13639
		// (get) Token: 0x060205CF RID: 132559 RVA: 0x00929B9C File Offset: 0x00927D9C
		// (set) Token: 0x060205D0 RID: 132560 RVA: 0x00929BB0 File Offset: 0x00927DB0
		public unsafe UChildActorComponent Key_A3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_11);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_11, value);
			}
		}

		// Token: 0x17003548 RID: 13640
		// (get) Token: 0x060205D1 RID: 132561 RVA: 0x00929BC5 File Offset: 0x00927DC5
		// (set) Token: 0x060205D2 RID: 132562 RVA: 0x00929BD9 File Offset: 0x00927DD9
		public unsafe UChildActorComponent Key_GSharp2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_12);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_12, value);
			}
		}

		// Token: 0x17003549 RID: 13641
		// (get) Token: 0x060205D3 RID: 132563 RVA: 0x00929BEE File Offset: 0x00927DEE
		// (set) Token: 0x060205D4 RID: 132564 RVA: 0x00929C02 File Offset: 0x00927E02
		public unsafe UChildActorComponent Key_G3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_13);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_13, value);
			}
		}

		// Token: 0x1700354A RID: 13642
		// (get) Token: 0x060205D5 RID: 132565 RVA: 0x00929C17 File Offset: 0x00927E17
		// (set) Token: 0x060205D6 RID: 132566 RVA: 0x00929C2B File Offset: 0x00927E2B
		public unsafe UChildActorComponent Key_FSharp2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_14);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_14, value);
			}
		}

		// Token: 0x1700354B RID: 13643
		// (get) Token: 0x060205D7 RID: 132567 RVA: 0x00929C40 File Offset: 0x00927E40
		// (set) Token: 0x060205D8 RID: 132568 RVA: 0x00929C54 File Offset: 0x00927E54
		public unsafe UChildActorComponent Key_F3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_15);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_15, value);
			}
		}

		// Token: 0x1700354C RID: 13644
		// (get) Token: 0x060205D9 RID: 132569 RVA: 0x00929C69 File Offset: 0x00927E69
		// (set) Token: 0x060205DA RID: 132570 RVA: 0x00929C7D File Offset: 0x00927E7D
		public unsafe UChildActorComponent Key_E3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_16);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_16, value);
			}
		}

		// Token: 0x1700354D RID: 13645
		// (get) Token: 0x060205DB RID: 132571 RVA: 0x00929C92 File Offset: 0x00927E92
		// (set) Token: 0x060205DC RID: 132572 RVA: 0x00929CA6 File Offset: 0x00927EA6
		public unsafe UChildActorComponent Key_DSharp2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_17);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_17, value);
			}
		}

		// Token: 0x1700354E RID: 13646
		// (get) Token: 0x060205DD RID: 132573 RVA: 0x00929CBB File Offset: 0x00927EBB
		// (set) Token: 0x060205DE RID: 132574 RVA: 0x00929CCF File Offset: 0x00927ECF
		public unsafe UChildActorComponent Key_D3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_18);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_18, value);
			}
		}

		// Token: 0x1700354F RID: 13647
		// (get) Token: 0x060205DF RID: 132575 RVA: 0x00929CE4 File Offset: 0x00927EE4
		// (set) Token: 0x060205E0 RID: 132576 RVA: 0x00929CF8 File Offset: 0x00927EF8
		public unsafe UChildActorComponent Key_CSharp2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_19);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_19, value);
			}
		}

		// Token: 0x17003550 RID: 13648
		// (get) Token: 0x060205E1 RID: 132577 RVA: 0x00929D0D File Offset: 0x00927F0D
		// (set) Token: 0x060205E2 RID: 132578 RVA: 0x00929D21 File Offset: 0x00927F21
		public unsafe UChildActorComponent Key_B3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_20);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_20, value);
			}
		}

		// Token: 0x17003551 RID: 13649
		// (get) Token: 0x060205E3 RID: 132579 RVA: 0x00929D36 File Offset: 0x00927F36
		// (set) Token: 0x060205E4 RID: 132580 RVA: 0x00929D4A File Offset: 0x00927F4A
		public unsafe UChildActorComponent Key_C3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_21);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_21, value);
			}
		}

		// Token: 0x17003552 RID: 13650
		// (get) Token: 0x060205E5 RID: 132581 RVA: 0x00929D5F File Offset: 0x00927F5F
		// (set) Token: 0x060205E6 RID: 132582 RVA: 0x00929D73 File Offset: 0x00927F73
		public unsafe UChildActorComponent Key_ASharp1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_22);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_22, value);
			}
		}

		// Token: 0x17003553 RID: 13651
		// (get) Token: 0x060205E7 RID: 132583 RVA: 0x00929D88 File Offset: 0x00927F88
		// (set) Token: 0x060205E8 RID: 132584 RVA: 0x00929D9C File Offset: 0x00927F9C
		public unsafe UChildActorComponent Key_A2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_23);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_23, value);
			}
		}

		// Token: 0x17003554 RID: 13652
		// (get) Token: 0x060205E9 RID: 132585 RVA: 0x00929DB1 File Offset: 0x00927FB1
		// (set) Token: 0x060205EA RID: 132586 RVA: 0x00929DC5 File Offset: 0x00927FC5
		public unsafe UChildActorComponent Key_GSharp1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_24);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_24, value);
			}
		}

		// Token: 0x17003555 RID: 13653
		// (get) Token: 0x060205EB RID: 132587 RVA: 0x00929DDA File Offset: 0x00927FDA
		// (set) Token: 0x060205EC RID: 132588 RVA: 0x00929DEE File Offset: 0x00927FEE
		public unsafe UChildActorComponent Key_CSharp1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_25);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_25, value);
			}
		}

		// Token: 0x17003556 RID: 13654
		// (get) Token: 0x060205ED RID: 132589 RVA: 0x00929E03 File Offset: 0x00928003
		// (set) Token: 0x060205EE RID: 132590 RVA: 0x00929E17 File Offset: 0x00928017
		public unsafe UChildActorComponent Key_FSharp1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_26);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_26, value);
			}
		}

		// Token: 0x17003557 RID: 13655
		// (get) Token: 0x060205EF RID: 132591 RVA: 0x00929E2C File Offset: 0x0092802C
		// (set) Token: 0x060205F0 RID: 132592 RVA: 0x00929E40 File Offset: 0x00928040
		public unsafe UChildActorComponent Key_B2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_27);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_27, value);
			}
		}

		// Token: 0x17003558 RID: 13656
		// (get) Token: 0x060205F1 RID: 132593 RVA: 0x00929E55 File Offset: 0x00928055
		// (set) Token: 0x060205F2 RID: 132594 RVA: 0x00929E69 File Offset: 0x00928069
		public unsafe UChildActorComponent Key_E2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_28);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_28, value);
			}
		}

		// Token: 0x17003559 RID: 13657
		// (get) Token: 0x060205F3 RID: 132595 RVA: 0x00929E7E File Offset: 0x0092807E
		// (set) Token: 0x060205F4 RID: 132596 RVA: 0x00929E92 File Offset: 0x00928092
		public unsafe UChildActorComponent Key_DSharp1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_29);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_29, value);
			}
		}

		// Token: 0x1700355A RID: 13658
		// (get) Token: 0x060205F5 RID: 132597 RVA: 0x00929EA7 File Offset: 0x009280A7
		// (set) Token: 0x060205F6 RID: 132598 RVA: 0x00929EBB File Offset: 0x009280BB
		public unsafe UChildActorComponent Key_D2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_30);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_30, value);
			}
		}

		// Token: 0x1700355B RID: 13659
		// (get) Token: 0x060205F7 RID: 132599 RVA: 0x00929ED0 File Offset: 0x009280D0
		// (set) Token: 0x060205F8 RID: 132600 RVA: 0x00929EE4 File Offset: 0x009280E4
		public unsafe UChildActorComponent Key_G2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_31);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_31, value);
			}
		}

		// Token: 0x1700355C RID: 13660
		// (get) Token: 0x060205F9 RID: 132601 RVA: 0x00929EF9 File Offset: 0x009280F9
		// (set) Token: 0x060205FA RID: 132602 RVA: 0x00929F0D File Offset: 0x0092810D
		public unsafe UChildActorComponent Key_C2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_32);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_32, value);
			}
		}

		// Token: 0x1700355D RID: 13661
		// (get) Token: 0x060205FB RID: 132603 RVA: 0x00929F22 File Offset: 0x00928122
		// (set) Token: 0x060205FC RID: 132604 RVA: 0x00929F36 File Offset: 0x00928136
		public unsafe UChildActorComponent Key_F2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_33);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_33, value);
			}
		}

		// Token: 0x1700355E RID: 13662
		// (get) Token: 0x060205FD RID: 132605 RVA: 0x00929F4B File Offset: 0x0092814B
		// (set) Token: 0x060205FE RID: 132606 RVA: 0x00929F5F File Offset: 0x0092815F
		public unsafe UChildActorComponent Key_B1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_34);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_34, value);
			}
		}

		// Token: 0x1700355F RID: 13663
		// (get) Token: 0x060205FF RID: 132607 RVA: 0x00929F74 File Offset: 0x00928174
		// (set) Token: 0x06020600 RID: 132608 RVA: 0x00929F88 File Offset: 0x00928188
		public unsafe UChildActorComponent Key_ASharp
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_35);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_35, value);
			}
		}

		// Token: 0x17003560 RID: 13664
		// (get) Token: 0x06020601 RID: 132609 RVA: 0x00929F9D File Offset: 0x0092819D
		// (set) Token: 0x06020602 RID: 132610 RVA: 0x00929FB1 File Offset: 0x009281B1
		public unsafe UChildActorComponent Key_A1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_36);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_36, value);
			}
		}

		// Token: 0x17003561 RID: 13665
		// (get) Token: 0x06020603 RID: 132611 RVA: 0x00929FC6 File Offset: 0x009281C6
		// (set) Token: 0x06020604 RID: 132612 RVA: 0x00929FDA File Offset: 0x009281DA
		public unsafe UChildActorComponent Key_GSharp
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_37);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_37, value);
			}
		}

		// Token: 0x17003562 RID: 13666
		// (get) Token: 0x06020605 RID: 132613 RVA: 0x00929FEF File Offset: 0x009281EF
		// (set) Token: 0x06020606 RID: 132614 RVA: 0x0092A003 File Offset: 0x00928203
		public unsafe UChildActorComponent Key_G1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_38);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_38, value);
			}
		}

		// Token: 0x17003563 RID: 13667
		// (get) Token: 0x06020607 RID: 132615 RVA: 0x0092A018 File Offset: 0x00928218
		// (set) Token: 0x06020608 RID: 132616 RVA: 0x0092A02C File Offset: 0x0092822C
		public unsafe UChildActorComponent Key_C1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_39);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_39, value);
			}
		}

		// Token: 0x17003564 RID: 13668
		// (get) Token: 0x06020609 RID: 132617 RVA: 0x0092A041 File Offset: 0x00928241
		// (set) Token: 0x0602060A RID: 132618 RVA: 0x0092A055 File Offset: 0x00928255
		public unsafe UChildActorComponent Key_F1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_40);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_40, value);
			}
		}

		// Token: 0x17003565 RID: 13669
		// (get) Token: 0x0602060B RID: 132619 RVA: 0x0092A06A File Offset: 0x0092826A
		// (set) Token: 0x0602060C RID: 132620 RVA: 0x0092A07E File Offset: 0x0092827E
		public unsafe UChildActorComponent Key_E1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_41);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_41, value);
			}
		}

		// Token: 0x17003566 RID: 13670
		// (get) Token: 0x0602060D RID: 132621 RVA: 0x0092A093 File Offset: 0x00928293
		// (set) Token: 0x0602060E RID: 132622 RVA: 0x0092A0A7 File Offset: 0x009282A7
		public unsafe UChildActorComponent Key_DSharp
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_42);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_42, value);
			}
		}

		// Token: 0x17003567 RID: 13671
		// (get) Token: 0x0602060F RID: 132623 RVA: 0x0092A0BC File Offset: 0x009282BC
		// (set) Token: 0x06020610 RID: 132624 RVA: 0x0092A0D0 File Offset: 0x009282D0
		public unsafe UChildActorComponent Key_D1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_43);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_43, value);
			}
		}

		// Token: 0x17003568 RID: 13672
		// (get) Token: 0x06020611 RID: 132625 RVA: 0x0092A0E5 File Offset: 0x009282E5
		// (set) Token: 0x06020612 RID: 132626 RVA: 0x0092A0F9 File Offset: 0x009282F9
		public unsafe UChildActorComponent Key_CSharp
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_44);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_44, value);
			}
		}

		// Token: 0x17003569 RID: 13673
		// (get) Token: 0x06020613 RID: 132627 RVA: 0x0092A10E File Offset: 0x0092830E
		// (set) Token: 0x06020614 RID: 132628 RVA: 0x0092A122 File Offset: 0x00928322
		public unsafe UChildActorComponent Key_FSharp
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_45);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_45, value);
			}
		}

		// Token: 0x1700356A RID: 13674
		// (get) Token: 0x06020615 RID: 132629 RVA: 0x0092A137 File Offset: 0x00928337
		// (set) Token: 0x06020616 RID: 132630 RVA: 0x0092A14B File Offset: 0x0092834B
		public unsafe USceneComponent Note
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_46);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_46, value);
			}
		}

		// Token: 0x1700356B RID: 13675
		// (get) Token: 0x06020617 RID: 132631 RVA: 0x0092A160 File Offset: 0x00928360
		// (set) Token: 0x06020618 RID: 132632 RVA: 0x0092A174 File Offset: 0x00928374
		public unsafe USceneComponent Key
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_47);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_47, value);
			}
		}

		// Token: 0x1700356C RID: 13676
		// (get) Token: 0x06020619 RID: 132633 RVA: 0x0092A18C File Offset: 0x0092838C
		// (set) Token: 0x0602061A RID: 132634 RVA: 0x0092A1C5 File Offset: 0x009283C5
		[Nullable(1)]
		public TArray<BP_PianoKey_C> BPKeyArray
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<BP_PianoKey_C> result;
				if ((result = this._BPKeyArray) == null)
				{
					result = (this._BPKeyArray = new TArray<BP_PianoKey_C>(base.NativePtr + (IntPtr)BP_Piano_C.__PropertyOffset_48, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.BPKeyArray.CopyAssign(value);
			}
		}

		// Token: 0x1700356D RID: 13677
		// (get) Token: 0x0602061B RID: 132635 RVA: 0x0092A1D4 File Offset: 0x009283D4
		// (set) Token: 0x0602061C RID: 132636 RVA: 0x0092A20D File Offset: 0x0092840D
		[Nullable(1)]
		public MoveNote MoveNote
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				MoveNote result;
				if ((result = this._MoveNote) == null)
				{
					result = (this._MoveNote = new MoveNote(base.NativePtr + (IntPtr)BP_Piano_C.__PropertyOffset_49, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)BP_Piano_C.__PropertyOffset_49, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x1700356E RID: 13678
		// (get) Token: 0x0602061D RID: 132637 RVA: 0x0092A230 File Offset: 0x00928430
		// (set) Token: 0x0602061E RID: 132638 RVA: 0x0092A269 File Offset: 0x00928469
		[Nullable(1)]
		public TArray<BP_PianoNote_C> BPNoteArray
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<BP_PianoNote_C> result;
				if ((result = this._BPNoteArray) == null)
				{
					result = (this._BPNoteArray = new TArray<BP_PianoNote_C>(base.NativePtr + (IntPtr)BP_Piano_C.__PropertyOffset_50, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.BPNoteArray.CopyAssign(value);
			}
		}

		// Token: 0x1700356F RID: 13679
		// (get) Token: 0x0602061F RID: 132639 RVA: 0x0092A278 File Offset: 0x00928478
		// (set) Token: 0x06020620 RID: 132640 RVA: 0x0092A2B1 File Offset: 0x009284B1
		[Nullable(1)]
		public TSet<BP_PianoNote_C> TriggeredNoteSet
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TSet<BP_PianoNote_C> result;
				if ((result = this._TriggeredNoteSet) == null)
				{
					result = (this._TriggeredNoteSet = new TSet<BP_PianoNote_C>(base.NativePtr + (IntPtr)BP_Piano_C.__PropertyOffset_51, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.TriggeredNoteSet.CopyAssign(value);
			}
		}

		// Token: 0x17003570 RID: 13680
		// (get) Token: 0x06020621 RID: 132641 RVA: 0x0092A2BF File Offset: 0x009284BF
		// (set) Token: 0x06020622 RID: 132642 RVA: 0x0092A2D3 File Offset: 0x009284D3
		public unsafe UAkAudioEvent WwiseEvent
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UAkAudioEvent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_52);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_52, value);
			}
		}

		// Token: 0x17003571 RID: 13681
		// (get) Token: 0x06020623 RID: 132643 RVA: 0x0092A2E8 File Offset: 0x009284E8
		// (set) Token: 0x06020624 RID: 132644 RVA: 0x0092A2F8 File Offset: 0x009284F8
		public unsafe byte MIDIStartIndex
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Piano_C.__PropertyOffset_53);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Piano_C.__PropertyOffset_53) = value;
			}
		}

		// Token: 0x17003572 RID: 13682
		// (get) Token: 0x06020625 RID: 132645 RVA: 0x0092A309 File Offset: 0x00928509
		// (set) Token: 0x06020626 RID: 132646 RVA: 0x0092A31D File Offset: 0x0092851D
		public unsafe ULevelSequence Sequence
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<ULevelSequence>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_54);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_54, value);
			}
		}

		// Token: 0x17003573 RID: 13683
		// (get) Token: 0x06020627 RID: 132647 RVA: 0x0092A332 File Offset: 0x00928532
		// (set) Token: 0x06020628 RID: 132648 RVA: 0x0092A346 File Offset: 0x00928546
		public unsafe ULevelSequencePlayer SequencePlayer
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<ULevelSequencePlayer>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_55);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Piano_C.__PropertyOffset_55, value);
			}
		}

		// Token: 0x06020629 RID: 132649 RVA: 0x0092A35C File Offset: 0x0092855C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void InitSequence(ref ALevelSequenceActor LevelSequenceActor)
		{
			BP_Piano_C.__InitSequence_FunctionParams* ptr = stackalloc BP_Piano_C.__InitSequence_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_Piano_C.__InitSequence_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Piano_C.__InitSequence_NativeFunctionPtr, (void*)ptr, 1);
			ref BP_Piano_C.__InitSequence_FunctionParams ptr2 = ref *ptr;
			ALevelSequenceActor alevelSequenceActor = LevelSequenceActor;
			ptr2.LevelSequenceActor = ((alevelSequenceActor != null) ? alevelSequenceActor.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Piano_C.__InitSequence_NativeFunctionPtr, (void*)ptr);
			LevelSequenceActor = BuiltinUtils.GetOrCreateUObjectByNativePointer<ALevelSequenceActor>(ptr->LevelSequenceActor);
		}

		// Token: 0x0602062A RID: 132650 RVA: 0x0092A3C0 File Offset: 0x009285C0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void InitNoteRefArray()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Piano_C.__InitNoteRefArray_NativeFunctionPtr, null);
		}

		// Token: 0x0602062B RID: 132651 RVA: 0x0092A3D4 File Offset: 0x009285D4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void InitKeyRefArray()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Piano_C.__InitKeyRefArray_NativeFunctionPtr, null);
		}

		// Token: 0x0602062C RID: 132652 RVA: 0x0092A3E8 File Offset: 0x009285E8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetNote(PianoKeyEnum KeyType, ref BP_PianoNote_C Note)
		{
			BP_Piano_C.__GetNote_FunctionParams* ptr = stackalloc BP_Piano_C.__GetNote_FunctionParams[(UIntPtr)87] + 15L / (long)sizeof(BP_Piano_C.__GetNote_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Piano_C.__GetNote_NativeFunctionPtr, (void*)ptr, 1);
			ptr->KeyType = KeyType;
			ref BP_Piano_C.__GetNote_FunctionParams ptr2 = ref *ptr;
			BP_PianoNote_C bp_PianoNote_C = Note;
			ptr2.Note = ((bp_PianoNote_C != null) ? bp_PianoNote_C.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Piano_C.__GetNote_NativeFunctionPtr, (void*)ptr);
			Note = BuiltinUtils.GetOrCreateUObjectByNativePointer<BP_PianoNote_C>(ptr->Note);
		}

		// Token: 0x0602062D RID: 132653 RVA: 0x0092A458 File Offset: 0x00928658
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void PlayAudio(PianoKeyEnum KeyType)
		{
			BP_Piano_C.__PlayAudio_FunctionParams* ptr = stackalloc BP_Piano_C.__PlayAudio_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(BP_Piano_C.__PlayAudio_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Piano_C.__PlayAudio_NativeFunctionPtr, (void*)ptr, 1);
			ptr->KeyType = KeyType;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Piano_C.__PlayAudio_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602062E RID: 132654 RVA: 0x0092A4A3 File Offset: 0x009286A3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Piano_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0602062F RID: 132655 RVA: 0x0092A4B7 File Offset: 0x009286B7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Piano_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06020630 RID: 132656 RVA: 0x0092A4CC File Offset: 0x009286CC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_Piano_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Piano_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Piano_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Piano_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Piano_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06020631 RID: 132657 RVA: 0x0092A514 File Offset: 0x00928714
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_Piano_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Piano_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Piano_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Piano_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Piano_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020632 RID: 132658 RVA: 0x0092A55C File Offset: 0x0092875C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void CustomEvent_0(bool Overlap, PianoKeyEnum KeyType)
		{
			BP_Piano_C.__CustomEvent_0_FunctionParams* ptr = stackalloc BP_Piano_C.__CustomEvent_0_FunctionParams[(UIntPtr)17] + 15L / (long)sizeof(BP_Piano_C.__CustomEvent_0_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Piano_C.__CustomEvent_0_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Overlap = Overlap;
			ptr->KeyType = KeyType;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Piano_C.__CustomEvent_0_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06020633 RID: 132659 RVA: 0x0092A5B0 File Offset: 0x009287B0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveEndPlay(EEndPlayReason EndPlayReason)
		{
			BP_Piano_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_Piano_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_Piano_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Piano_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Piano_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06020634 RID: 132660 RVA: 0x0092A5FC File Offset: 0x009287FC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveEndPlay_Implementation(EEndPlayReason EndPlayReason)
		{
			BP_Piano_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_Piano_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_Piano_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Piano_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Piano_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020635 RID: 132661 RVA: 0x0092A648 File Offset: 0x00928848
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CustomEvent_1()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Piano_C.__CustomEvent_1_NativeFunctionPtr, null);
		}

		// Token: 0x06020636 RID: 132662 RVA: 0x0092A65C File Offset: 0x0092885C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_Piano(int EntryPoint)
		{
			BP_Piano_C.__ExecuteUbergraph_BP_Piano_FunctionParams* ptr = stackalloc BP_Piano_C.__ExecuteUbergraph_BP_Piano_FunctionParams[(UIntPtr)295] + 15L / (long)sizeof(BP_Piano_C.__ExecuteUbergraph_BP_Piano_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Piano_C.__ExecuteUbergraph_BP_Piano_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Piano_C.__ExecuteUbergraph_BP_Piano_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020637 RID: 132663 RVA: 0x0092A6A6 File Offset: 0x009288A6
		protected BP_Piano_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04010270 RID: 66160
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Common/Piano/BP_Piano.BP_Piano_C";

		// Token: 0x04010271 RID: 66161
		private static IntPtr _ClassPtr;

		// Token: 0x04010272 RID: 66162
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04010273 RID: 66163
		public static IntPtr __MoveNote__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04010274 RID: 66164
		internal static int __PropertyOffset_0;

		// Token: 0x04010275 RID: 66165
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04010276 RID: 66166
		internal static int __PropertyOffset_1;

		// Token: 0x04010277 RID: 66167
		internal static int __PropertyOffset_2;

		// Token: 0x04010278 RID: 66168
		internal static int __PropertyOffset_3;

		// Token: 0x04010279 RID: 66169
		internal static int __PropertyOffset_4;

		// Token: 0x0401027A RID: 66170
		internal static int __PropertyOffset_5;

		// Token: 0x0401027B RID: 66171
		internal static int __PropertyOffset_6;

		// Token: 0x0401027C RID: 66172
		internal static int __PropertyOffset_7;

		// Token: 0x0401027D RID: 66173
		internal static int __PropertyOffset_8;

		// Token: 0x0401027E RID: 66174
		internal static int __PropertyOffset_9;

		// Token: 0x0401027F RID: 66175
		internal static int __PropertyOffset_10;

		// Token: 0x04010280 RID: 66176
		internal static int __PropertyOffset_11;

		// Token: 0x04010281 RID: 66177
		internal static int __PropertyOffset_12;

		// Token: 0x04010282 RID: 66178
		internal static int __PropertyOffset_13;

		// Token: 0x04010283 RID: 66179
		internal static int __PropertyOffset_14;

		// Token: 0x04010284 RID: 66180
		internal static int __PropertyOffset_15;

		// Token: 0x04010285 RID: 66181
		internal static int __PropertyOffset_16;

		// Token: 0x04010286 RID: 66182
		internal static int __PropertyOffset_17;

		// Token: 0x04010287 RID: 66183
		internal static int __PropertyOffset_18;

		// Token: 0x04010288 RID: 66184
		internal static int __PropertyOffset_19;

		// Token: 0x04010289 RID: 66185
		internal static int __PropertyOffset_20;

		// Token: 0x0401028A RID: 66186
		internal static int __PropertyOffset_21;

		// Token: 0x0401028B RID: 66187
		internal static int __PropertyOffset_22;

		// Token: 0x0401028C RID: 66188
		internal static int __PropertyOffset_23;

		// Token: 0x0401028D RID: 66189
		internal static int __PropertyOffset_24;

		// Token: 0x0401028E RID: 66190
		internal static int __PropertyOffset_25;

		// Token: 0x0401028F RID: 66191
		internal static int __PropertyOffset_26;

		// Token: 0x04010290 RID: 66192
		internal static int __PropertyOffset_27;

		// Token: 0x04010291 RID: 66193
		internal static int __PropertyOffset_28;

		// Token: 0x04010292 RID: 66194
		internal static int __PropertyOffset_29;

		// Token: 0x04010293 RID: 66195
		internal static int __PropertyOffset_30;

		// Token: 0x04010294 RID: 66196
		internal static int __PropertyOffset_31;

		// Token: 0x04010295 RID: 66197
		internal static int __PropertyOffset_32;

		// Token: 0x04010296 RID: 66198
		internal static int __PropertyOffset_33;

		// Token: 0x04010297 RID: 66199
		internal static int __PropertyOffset_34;

		// Token: 0x04010298 RID: 66200
		internal static int __PropertyOffset_35;

		// Token: 0x04010299 RID: 66201
		internal static int __PropertyOffset_36;

		// Token: 0x0401029A RID: 66202
		internal static int __PropertyOffset_37;

		// Token: 0x0401029B RID: 66203
		internal static int __PropertyOffset_38;

		// Token: 0x0401029C RID: 66204
		internal static int __PropertyOffset_39;

		// Token: 0x0401029D RID: 66205
		internal static int __PropertyOffset_40;

		// Token: 0x0401029E RID: 66206
		internal static int __PropertyOffset_41;

		// Token: 0x0401029F RID: 66207
		internal static int __PropertyOffset_42;

		// Token: 0x040102A0 RID: 66208
		internal static int __PropertyOffset_43;

		// Token: 0x040102A1 RID: 66209
		internal static int __PropertyOffset_44;

		// Token: 0x040102A2 RID: 66210
		internal static int __PropertyOffset_45;

		// Token: 0x040102A3 RID: 66211
		internal static int __PropertyOffset_46;

		// Token: 0x040102A4 RID: 66212
		internal static int __PropertyOffset_47;

		// Token: 0x040102A5 RID: 66213
		internal static int __PropertyOffset_48;

		// Token: 0x040102A6 RID: 66214
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<BP_PianoKey_C> _BPKeyArray;

		// Token: 0x040102A7 RID: 66215
		internal static int __PropertyOffset_49;

		// Token: 0x040102A8 RID: 66216
		private MoveNote _MoveNote;

		// Token: 0x040102A9 RID: 66217
		internal static int __PropertyOffset_50;

		// Token: 0x040102AA RID: 66218
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<BP_PianoNote_C> _BPNoteArray;

		// Token: 0x040102AB RID: 66219
		internal static int __PropertyOffset_51;

		// Token: 0x040102AC RID: 66220
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TSet<BP_PianoNote_C> _TriggeredNoteSet;

		// Token: 0x040102AD RID: 66221
		internal static int __PropertyOffset_52;

		// Token: 0x040102AE RID: 66222
		internal static int __PropertyOffset_53;

		// Token: 0x040102AF RID: 66223
		internal static int __PropertyOffset_54;

		// Token: 0x040102B0 RID: 66224
		internal static int __PropertyOffset_55;

		// Token: 0x040102B1 RID: 66225
		private static IntPtr __InitSequence_NativeFunctionPtr;

		// Token: 0x040102B2 RID: 66226
		private static IntPtr __InitNoteRefArray_NativeFunctionPtr;

		// Token: 0x040102B3 RID: 66227
		private static IntPtr __InitKeyRefArray_NativeFunctionPtr;

		// Token: 0x040102B4 RID: 66228
		private static IntPtr __GetNote_NativeFunctionPtr;

		// Token: 0x040102B5 RID: 66229
		private static IntPtr __PlayAudio_NativeFunctionPtr;

		// Token: 0x040102B6 RID: 66230
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x040102B7 RID: 66231
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x040102B8 RID: 66232
		private static IntPtr __CustomEvent_0_NativeFunctionPtr;

		// Token: 0x040102B9 RID: 66233
		private static IntPtr __ReceiveEndPlay_NativeFunctionPtr;

		// Token: 0x040102BA RID: 66234
		private static IntPtr __CustomEvent_1_NativeFunctionPtr;

		// Token: 0x040102BB RID: 66235
		private static IntPtr __ExecuteUbergraph_BP_Piano_NativeFunctionPtr;

		// Token: 0x0200999B RID: 39323
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __InitSequence_FunctionParams
		{
			// Token: 0x0403202B RID: 204843
			[FieldOffset(0)]
			public IntPtr LevelSequenceActor;
		}

		// Token: 0x0200999C RID: 39324
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 72)]
		protected ref struct __GetNote_FunctionParams
		{
			// Token: 0x0403202C RID: 204844
			[FieldOffset(0)]
			public TEnumAsByte<PianoKeyEnum> KeyType;

			// Token: 0x0403202D RID: 204845
			[FieldOffset(8)]
			public IntPtr Note;
		}

		// Token: 0x0200999D RID: 39325
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __PlayAudio_FunctionParams
		{
			// Token: 0x0403202E RID: 204846
			[FieldOffset(0)]
			public TEnumAsByte<PianoKeyEnum> KeyType;
		}

		// Token: 0x0200999E RID: 39326
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x0403202F RID: 204847
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200999F RID: 39327
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 2)]
		protected ref struct __CustomEvent_0_FunctionParams
		{
			// Token: 0x04032030 RID: 204848
			[FieldOffset(0)]
			public bool Overlap;

			// Token: 0x04032031 RID: 204849
			[FieldOffset(1)]
			public TEnumAsByte<PianoKeyEnum> KeyType;
		}

		// Token: 0x020099A0 RID: 39328
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __ReceiveEndPlay_FunctionParams
		{
			// Token: 0x04032032 RID: 204850
			[FieldOffset(0)]
			public TEnumAsByte<EEndPlayReason> EndPlayReason;
		}

		// Token: 0x020099A1 RID: 39329
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 280)]
		protected ref struct __ExecuteUbergraph_BP_Piano_FunctionParams
		{
			// Token: 0x04032033 RID: 204851
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
