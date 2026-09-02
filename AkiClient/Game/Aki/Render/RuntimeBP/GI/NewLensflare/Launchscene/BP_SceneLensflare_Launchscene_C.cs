using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.GI.NewLensflare.Launchscene
{
	// Token: 0x02003CB3 RID: 15539
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/GI/NewLensflare/Launchscene/BP_SceneLensflare_Launchscene.BP_SceneLensflare_Launchscene_C")]
	[UnrealStructLayout(1544, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1544)]
	public class BP_SceneLensflare_Launchscene_C : ALensflareSamplerActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06024BB3 RID: 150451 RVA: 0x009A5CF0 File Offset: 0x009A3EF0
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SceneLensflare_Launchscene_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/GI/NewLensflare/Launchscene/BP_SceneLensflare_Launchscene.BP_SceneLensflare_Launchscene_C");
			}
			return BP_SceneLensflare_Launchscene_C._ClassPtr;
		}

		// Token: 0x06024BB4 RID: 150452 RVA: 0x009A5D14 File Offset: 0x009A3F14
		public BP_SceneLensflare_Launchscene_C() : this(BuiltinUtils.AllocNativeUObject(BP_SceneLensflare_Launchscene_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06024BB5 RID: 150453 RVA: 0x009A5D3C File Offset: 0x009A3F3C
		[NullableContext(1)]
		public BP_SceneLensflare_Launchscene_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SceneLensflare_Launchscene_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004DB8 RID: 19896
		// (get) Token: 0x06024BB6 RID: 150454 RVA: 0x009A5D70 File Offset: 0x009A3F70
		// (set) Token: 0x06024BB7 RID: 150455 RVA: 0x009A5DA9 File Offset: 0x009A3FA9
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_SceneLensflare_Launchscene_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_SceneLensflare_Launchscene_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004DB9 RID: 19897
		// (get) Token: 0x06024BB8 RID: 150456 RVA: 0x009A5DCA File Offset: 0x009A3FCA
		// (set) Token: 0x06024BB9 RID: 150457 RVA: 0x009A5DDA File Offset: 0x009A3FDA
		public unsafe bool 自定义Ghost
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_Launchscene_C.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_Launchscene_C.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004DBA RID: 19898
		// (get) Token: 0x06024BBA RID: 150458 RVA: 0x009A5DEB File Offset: 0x009A3FEB
		// (set) Token: 0x06024BBB RID: 150459 RVA: 0x009A5DFB File Offset: 0x009A3FFB
		public unsafe float Ghost_大小
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_Launchscene_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_Launchscene_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17004DBB RID: 19899
		// (get) Token: 0x06024BBC RID: 150460 RVA: 0x009A5E0C File Offset: 0x009A400C
		// (set) Token: 0x06024BBD RID: 150461 RVA: 0x009A5E1C File Offset: 0x009A401C
		public unsafe float Ghost_分布偏移
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_Launchscene_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_Launchscene_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17004DBC RID: 19900
		// (get) Token: 0x06024BBE RID: 150462 RVA: 0x009A5E2D File Offset: 0x009A402D
		// (set) Token: 0x06024BBF RID: 150463 RVA: 0x009A5E3D File Offset: 0x009A403D
		public unsafe float Ghost_分布范围
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_Launchscene_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_Launchscene_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17004DBD RID: 19901
		// (get) Token: 0x06024BC0 RID: 150464 RVA: 0x009A5E4E File Offset: 0x009A404E
		// (set) Token: 0x06024BC1 RID: 150465 RVA: 0x009A5E62 File Offset: 0x009A4062
		public unsafe FLinearColor Ghost_调色
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_Launchscene_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_Launchscene_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17004DBE RID: 19902
		// (get) Token: 0x06024BC2 RID: 150466 RVA: 0x009A5E77 File Offset: 0x009A4077
		// (set) Token: 0x06024BC3 RID: 150467 RVA: 0x009A5E87 File Offset: 0x009A4087
		public unsafe float Ghost_不透明度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_Launchscene_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_Launchscene_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17004DBF RID: 19903
		// (get) Token: 0x06024BC4 RID: 150468 RVA: 0x009A5E98 File Offset: 0x009A4098
		// (set) Token: 0x06024BC5 RID: 150469 RVA: 0x009A5EA8 File Offset: 0x009A40A8
		public unsafe bool 自定义Halo
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_Launchscene_C.__PropertyOffset_7) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_Launchscene_C.__PropertyOffset_7) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004DC0 RID: 19904
		// (get) Token: 0x06024BC6 RID: 150470 RVA: 0x009A5EB9 File Offset: 0x009A40B9
		// (set) Token: 0x06024BC7 RID: 150471 RVA: 0x009A5EC9 File Offset: 0x009A40C9
		public unsafe float Halo_圆环衰减
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_Launchscene_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_Launchscene_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17004DC1 RID: 19905
		// (get) Token: 0x06024BC8 RID: 150472 RVA: 0x009A5EDA File Offset: 0x009A40DA
		// (set) Token: 0x06024BC9 RID: 150473 RVA: 0x009A5EEA File Offset: 0x009A40EA
		public unsafe float Halo_大小
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_Launchscene_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_Launchscene_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17004DC2 RID: 19906
		// (get) Token: 0x06024BCA RID: 150474 RVA: 0x009A5EFB File Offset: 0x009A40FB
		// (set) Token: 0x06024BCB RID: 150475 RVA: 0x009A5F0B File Offset: 0x009A410B
		public unsafe float Halo_分布偏移
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_Launchscene_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_Launchscene_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17004DC3 RID: 19907
		// (get) Token: 0x06024BCC RID: 150476 RVA: 0x009A5F1C File Offset: 0x009A411C
		// (set) Token: 0x06024BCD RID: 150477 RVA: 0x009A5F2C File Offset: 0x009A412C
		public unsafe float Halo_分布范围
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_Launchscene_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_Launchscene_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17004DC4 RID: 19908
		// (get) Token: 0x06024BCE RID: 150478 RVA: 0x009A5F3D File Offset: 0x009A413D
		// (set) Token: 0x06024BCF RID: 150479 RVA: 0x009A5F51 File Offset: 0x009A4151
		public unsafe FLinearColor Halo_调色
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_Launchscene_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_Launchscene_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17004DC5 RID: 19909
		// (get) Token: 0x06024BD0 RID: 150480 RVA: 0x009A5F66 File Offset: 0x009A4166
		// (set) Token: 0x06024BD1 RID: 150481 RVA: 0x009A5F76 File Offset: 0x009A4176
		public unsafe float Halo_不透明度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_Launchscene_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_Launchscene_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17004DC6 RID: 19910
		// (get) Token: 0x06024BD2 RID: 150482 RVA: 0x009A5F87 File Offset: 0x009A4187
		// (set) Token: 0x06024BD3 RID: 150483 RVA: 0x009A5F97 File Offset: 0x009A4197
		public unsafe bool 自定义Glare
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_Launchscene_C.__PropertyOffset_14) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_Launchscene_C.__PropertyOffset_14) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004DC7 RID: 19911
		// (get) Token: 0x06024BD4 RID: 150484 RVA: 0x009A5FA8 File Offset: 0x009A41A8
		// (set) Token: 0x06024BD5 RID: 150485 RVA: 0x009A5FBC File Offset: 0x009A41BC
		public unsafe FVector2D Glare_大小
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_Launchscene_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_Launchscene_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17004DC8 RID: 19912
		// (get) Token: 0x06024BD6 RID: 150486 RVA: 0x009A5FD1 File Offset: 0x009A41D1
		// (set) Token: 0x06024BD7 RID: 150487 RVA: 0x009A5FE5 File Offset: 0x009A41E5
		public unsafe FLinearColor Glare_调色
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_Launchscene_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_Launchscene_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x17004DC9 RID: 19913
		// (get) Token: 0x06024BD8 RID: 150488 RVA: 0x009A5FFA File Offset: 0x009A41FA
		// (set) Token: 0x06024BD9 RID: 150489 RVA: 0x009A600A File Offset: 0x009A420A
		public unsafe float Glare_不透明度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_Launchscene_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_Launchscene_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x17004DCA RID: 19914
		// (get) Token: 0x06024BDA RID: 150490 RVA: 0x009A601B File Offset: 0x009A421B
		// (set) Token: 0x06024BDB RID: 150491 RVA: 0x009A602B File Offset: 0x009A422B
		public unsafe float Glare_旋转
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_Launchscene_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_Launchscene_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x17004DCB RID: 19915
		// (get) Token: 0x06024BDC RID: 150492 RVA: 0x009A603C File Offset: 0x009A423C
		// (set) Token: 0x06024BDD RID: 150493 RVA: 0x009A604C File Offset: 0x009A424C
		public unsafe float Glare_锁定动态旋转
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_Launchscene_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_Launchscene_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x17004DCC RID: 19916
		// (get) Token: 0x06024BDE RID: 150494 RVA: 0x009A605D File Offset: 0x009A425D
		// (set) Token: 0x06024BDF RID: 150495 RVA: 0x009A606D File Offset: 0x009A426D
		public unsafe float Ghost_受背景色影响
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_Launchscene_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_Launchscene_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x17004DCD RID: 19917
		// (get) Token: 0x06024BE0 RID: 150496 RVA: 0x009A607E File Offset: 0x009A427E
		// (set) Token: 0x06024BE1 RID: 150497 RVA: 0x009A608E File Offset: 0x009A428E
		public unsafe float Halo_受背景色影响
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_Launchscene_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_Launchscene_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x17004DCE RID: 19918
		// (get) Token: 0x06024BE2 RID: 150498 RVA: 0x009A609F File Offset: 0x009A429F
		// (set) Token: 0x06024BE3 RID: 150499 RVA: 0x009A60AF File Offset: 0x009A42AF
		public unsafe float Glare_受背景色影响
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_Launchscene_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_Launchscene_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x17004DCF RID: 19919
		// (get) Token: 0x06024BE4 RID: 150500 RVA: 0x009A60C0 File Offset: 0x009A42C0
		// (set) Token: 0x06024BE5 RID: 150501 RVA: 0x009A60D0 File Offset: 0x009A42D0
		public unsafe float Ghost_视角衰减速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_Launchscene_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_Launchscene_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x17004DD0 RID: 19920
		// (get) Token: 0x06024BE6 RID: 150502 RVA: 0x009A60E1 File Offset: 0x009A42E1
		// (set) Token: 0x06024BE7 RID: 150503 RVA: 0x009A60F1 File Offset: 0x009A42F1
		public unsafe float Halo_视角衰减速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_Launchscene_C.__PropertyOffset_24);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_Launchscene_C.__PropertyOffset_24) = value;
			}
		}

		// Token: 0x17004DD1 RID: 19921
		// (get) Token: 0x06024BE8 RID: 150504 RVA: 0x009A6102 File Offset: 0x009A4302
		// (set) Token: 0x06024BE9 RID: 150505 RVA: 0x009A6112 File Offset: 0x009A4312
		public unsafe float Glare_视角衰减速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_Launchscene_C.__PropertyOffset_25);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_Launchscene_C.__PropertyOffset_25) = value;
			}
		}

		// Token: 0x17004DD2 RID: 19922
		// (get) Token: 0x06024BEA RID: 150506 RVA: 0x009A6123 File Offset: 0x009A4323
		// (set) Token: 0x06024BEB RID: 150507 RVA: 0x009A6133 File Offset: 0x009A4333
		public unsafe bool 自定义Ghost贴图
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_Launchscene_C.__PropertyOffset_26) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_Launchscene_C.__PropertyOffset_26) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004DD3 RID: 19923
		// (get) Token: 0x06024BEC RID: 150508 RVA: 0x009A6144 File Offset: 0x009A4344
		// (set) Token: 0x06024BED RID: 150509 RVA: 0x009A6158 File Offset: 0x009A4358
		public unsafe UTexture2D Ghost贴图
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneLensflare_Launchscene_C.__PropertyOffset_27);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneLensflare_Launchscene_C.__PropertyOffset_27, value);
			}
		}

		// Token: 0x17004DD4 RID: 19924
		// (get) Token: 0x06024BEE RID: 150510 RVA: 0x009A616D File Offset: 0x009A436D
		// (set) Token: 0x06024BEF RID: 150511 RVA: 0x009A617D File Offset: 0x009A437D
		public unsafe bool 自定义Halo贴图
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_Launchscene_C.__PropertyOffset_28) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_Launchscene_C.__PropertyOffset_28) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004DD5 RID: 19925
		// (get) Token: 0x06024BF0 RID: 150512 RVA: 0x009A618E File Offset: 0x009A438E
		// (set) Token: 0x06024BF1 RID: 150513 RVA: 0x009A61A2 File Offset: 0x009A43A2
		public unsafe UTexture2D Halo贴图
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneLensflare_Launchscene_C.__PropertyOffset_29);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneLensflare_Launchscene_C.__PropertyOffset_29, value);
			}
		}

		// Token: 0x17004DD6 RID: 19926
		// (get) Token: 0x06024BF2 RID: 150514 RVA: 0x009A61B7 File Offset: 0x009A43B7
		// (set) Token: 0x06024BF3 RID: 150515 RVA: 0x009A61C7 File Offset: 0x009A43C7
		public unsafe bool 自定义Glare贴图
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_Launchscene_C.__PropertyOffset_30) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_Launchscene_C.__PropertyOffset_30) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004DD7 RID: 19927
		// (get) Token: 0x06024BF4 RID: 150516 RVA: 0x009A61D8 File Offset: 0x009A43D8
		// (set) Token: 0x06024BF5 RID: 150517 RVA: 0x009A61EC File Offset: 0x009A43EC
		public unsafe UTexture2D Glare贴图
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneLensflare_Launchscene_C.__PropertyOffset_31);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneLensflare_Launchscene_C.__PropertyOffset_31, value);
			}
		}

		// Token: 0x17004DD8 RID: 19928
		// (get) Token: 0x06024BF6 RID: 150518 RVA: 0x009A6201 File Offset: 0x009A4401
		// (set) Token: 0x06024BF7 RID: 150519 RVA: 0x009A6215 File Offset: 0x009A4415
		public unsafe FLinearColor Glare_UV缩放_偏移
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_Launchscene_C.__PropertyOffset_32);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_Launchscene_C.__PropertyOffset_32) = value;
			}
		}

		// Token: 0x06024BF8 RID: 150520 RVA: 0x009A622C File Offset: 0x009A442C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ApplyDynamicMaterialGhost(UMaterialInstanceDynamic DynMaterial)
		{
			BP_SceneLensflare_Launchscene_C.__ApplyDynamicMaterialGhost_FunctionParams* ptr = stackalloc BP_SceneLensflare_Launchscene_C.__ApplyDynamicMaterialGhost_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_SceneLensflare_Launchscene_C.__ApplyDynamicMaterialGhost_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SceneLensflare_Launchscene_C.__ApplyDynamicMaterialGhost_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DynMaterial = ((DynMaterial != null) ? DynMaterial.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SceneLensflare_Launchscene_C.__ApplyDynamicMaterialGhost_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024BF9 RID: 150521 RVA: 0x009A6284 File Offset: 0x009A4484
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ApplyDynamicMaterialGhost_Implementation(UMaterialInstanceDynamic DynMaterial)
		{
			BP_SceneLensflare_Launchscene_C.__ApplyDynamicMaterialGhost_FunctionParams* ptr = stackalloc BP_SceneLensflare_Launchscene_C.__ApplyDynamicMaterialGhost_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_SceneLensflare_Launchscene_C.__ApplyDynamicMaterialGhost_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SceneLensflare_Launchscene_C.__ApplyDynamicMaterialGhost_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DynMaterial = ((DynMaterial != null) ? DynMaterial.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SceneLensflare_Launchscene_C.__ApplyDynamicMaterialGhost_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024BFA RID: 150522 RVA: 0x009A62DC File Offset: 0x009A44DC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ApplyDynamicMaterialHalo(UMaterialInstanceDynamic DynMaterial)
		{
			BP_SceneLensflare_Launchscene_C.__ApplyDynamicMaterialHalo_FunctionParams* ptr = stackalloc BP_SceneLensflare_Launchscene_C.__ApplyDynamicMaterialHalo_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_SceneLensflare_Launchscene_C.__ApplyDynamicMaterialHalo_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SceneLensflare_Launchscene_C.__ApplyDynamicMaterialHalo_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DynMaterial = ((DynMaterial != null) ? DynMaterial.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SceneLensflare_Launchscene_C.__ApplyDynamicMaterialHalo_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024BFB RID: 150523 RVA: 0x009A6334 File Offset: 0x009A4534
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ApplyDynamicMaterialHalo_Implementation(UMaterialInstanceDynamic DynMaterial)
		{
			BP_SceneLensflare_Launchscene_C.__ApplyDynamicMaterialHalo_FunctionParams* ptr = stackalloc BP_SceneLensflare_Launchscene_C.__ApplyDynamicMaterialHalo_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_SceneLensflare_Launchscene_C.__ApplyDynamicMaterialHalo_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SceneLensflare_Launchscene_C.__ApplyDynamicMaterialHalo_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DynMaterial = ((DynMaterial != null) ? DynMaterial.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SceneLensflare_Launchscene_C.__ApplyDynamicMaterialHalo_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024BFC RID: 150524 RVA: 0x009A638C File Offset: 0x009A458C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ApplyDynamicMaterialGlare(UMaterialInstanceDynamic DynMaterial)
		{
			BP_SceneLensflare_Launchscene_C.__ApplyDynamicMaterialGlare_FunctionParams* ptr = stackalloc BP_SceneLensflare_Launchscene_C.__ApplyDynamicMaterialGlare_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_SceneLensflare_Launchscene_C.__ApplyDynamicMaterialGlare_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SceneLensflare_Launchscene_C.__ApplyDynamicMaterialGlare_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DynMaterial = ((DynMaterial != null) ? DynMaterial.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SceneLensflare_Launchscene_C.__ApplyDynamicMaterialGlare_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024BFD RID: 150525 RVA: 0x009A63E4 File Offset: 0x009A45E4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ApplyDynamicMaterialGlare_Implementation(UMaterialInstanceDynamic DynMaterial)
		{
			BP_SceneLensflare_Launchscene_C.__ApplyDynamicMaterialGlare_FunctionParams* ptr = stackalloc BP_SceneLensflare_Launchscene_C.__ApplyDynamicMaterialGlare_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_SceneLensflare_Launchscene_C.__ApplyDynamicMaterialGlare_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SceneLensflare_Launchscene_C.__ApplyDynamicMaterialGlare_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DynMaterial = ((DynMaterial != null) ? DynMaterial.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SceneLensflare_Launchscene_C.__ApplyDynamicMaterialGlare_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024BFE RID: 150526 RVA: 0x009A643C File Offset: 0x009A463C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_SceneLensflare_Launchscene(int EntryPoint)
		{
			BP_SceneLensflare_Launchscene_C.__ExecuteUbergraph_BP_SceneLensflare_Launchscene_FunctionParams* ptr = stackalloc BP_SceneLensflare_Launchscene_C.__ExecuteUbergraph_BP_SceneLensflare_Launchscene_FunctionParams[(UIntPtr)71] + 15L / (long)sizeof(BP_SceneLensflare_Launchscene_C.__ExecuteUbergraph_BP_SceneLensflare_Launchscene_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SceneLensflare_Launchscene_C.__ExecuteUbergraph_BP_SceneLensflare_Launchscene_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SceneLensflare_Launchscene_C.__ExecuteUbergraph_BP_SceneLensflare_Launchscene_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024BFF RID: 150527 RVA: 0x009A6483 File Offset: 0x009A4683
		protected BP_SceneLensflare_Launchscene_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04012D61 RID: 77153
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/GI/NewLensflare/Launchscene/BP_SceneLensflare_Launchscene.BP_SceneLensflare_Launchscene_C";

		// Token: 0x04012D62 RID: 77154
		private static IntPtr _ClassPtr;

		// Token: 0x04012D63 RID: 77155
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04012D64 RID: 77156
		internal static int __PropertyOffset_0;

		// Token: 0x04012D65 RID: 77157
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04012D66 RID: 77158
		internal static int __PropertyOffset_1;

		// Token: 0x04012D67 RID: 77159
		internal static int __PropertyOffset_2;

		// Token: 0x04012D68 RID: 77160
		internal static int __PropertyOffset_3;

		// Token: 0x04012D69 RID: 77161
		internal static int __PropertyOffset_4;

		// Token: 0x04012D6A RID: 77162
		internal static int __PropertyOffset_5;

		// Token: 0x04012D6B RID: 77163
		internal static int __PropertyOffset_6;

		// Token: 0x04012D6C RID: 77164
		internal static int __PropertyOffset_7;

		// Token: 0x04012D6D RID: 77165
		internal static int __PropertyOffset_8;

		// Token: 0x04012D6E RID: 77166
		internal static int __PropertyOffset_9;

		// Token: 0x04012D6F RID: 77167
		internal static int __PropertyOffset_10;

		// Token: 0x04012D70 RID: 77168
		internal static int __PropertyOffset_11;

		// Token: 0x04012D71 RID: 77169
		internal static int __PropertyOffset_12;

		// Token: 0x04012D72 RID: 77170
		internal static int __PropertyOffset_13;

		// Token: 0x04012D73 RID: 77171
		internal static int __PropertyOffset_14;

		// Token: 0x04012D74 RID: 77172
		internal static int __PropertyOffset_15;

		// Token: 0x04012D75 RID: 77173
		internal static int __PropertyOffset_16;

		// Token: 0x04012D76 RID: 77174
		internal static int __PropertyOffset_17;

		// Token: 0x04012D77 RID: 77175
		internal static int __PropertyOffset_18;

		// Token: 0x04012D78 RID: 77176
		internal static int __PropertyOffset_19;

		// Token: 0x04012D79 RID: 77177
		internal static int __PropertyOffset_20;

		// Token: 0x04012D7A RID: 77178
		internal static int __PropertyOffset_21;

		// Token: 0x04012D7B RID: 77179
		internal static int __PropertyOffset_22;

		// Token: 0x04012D7C RID: 77180
		internal static int __PropertyOffset_23;

		// Token: 0x04012D7D RID: 77181
		internal static int __PropertyOffset_24;

		// Token: 0x04012D7E RID: 77182
		internal static int __PropertyOffset_25;

		// Token: 0x04012D7F RID: 77183
		internal static int __PropertyOffset_26;

		// Token: 0x04012D80 RID: 77184
		internal static int __PropertyOffset_27;

		// Token: 0x04012D81 RID: 77185
		internal static int __PropertyOffset_28;

		// Token: 0x04012D82 RID: 77186
		internal static int __PropertyOffset_29;

		// Token: 0x04012D83 RID: 77187
		internal static int __PropertyOffset_30;

		// Token: 0x04012D84 RID: 77188
		internal static int __PropertyOffset_31;

		// Token: 0x04012D85 RID: 77189
		internal static int __PropertyOffset_32;

		// Token: 0x04012D86 RID: 77190
		private static IntPtr __ApplyDynamicMaterialGhost_NativeFunctionPtr;

		// Token: 0x04012D87 RID: 77191
		private static IntPtr __ApplyDynamicMaterialHalo_NativeFunctionPtr;

		// Token: 0x04012D88 RID: 77192
		private static IntPtr __ApplyDynamicMaterialGlare_NativeFunctionPtr;

		// Token: 0x04012D89 RID: 77193
		private static IntPtr __ExecuteUbergraph_BP_SceneLensflare_Launchscene_NativeFunctionPtr;

		// Token: 0x02009E3C RID: 40508
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected new ref struct __ApplyDynamicMaterialGhost_FunctionParams
		{
			// Token: 0x0403288F RID: 206991
			[FieldOffset(0)]
			public IntPtr DynMaterial;
		}

		// Token: 0x02009E3D RID: 40509
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected new ref struct __ApplyDynamicMaterialHalo_FunctionParams
		{
			// Token: 0x04032890 RID: 206992
			[FieldOffset(0)]
			public IntPtr DynMaterial;
		}

		// Token: 0x02009E3E RID: 40510
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected new ref struct __ApplyDynamicMaterialGlare_FunctionParams
		{
			// Token: 0x04032891 RID: 206993
			[FieldOffset(0)]
			public IntPtr DynMaterial;
		}

		// Token: 0x02009E3F RID: 40511
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 56)]
		protected ref struct __ExecuteUbergraph_BP_SceneLensflare_Launchscene_FunctionParams
		{
			// Token: 0x04032892 RID: 206994
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
