using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.GI.NewLensflare
{
	// Token: 0x02003CB2 RID: 15538
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/GI/NewLensflare/BP_SceneLensflare.BP_SceneLensflare_C")]
	[UnrealStructLayout(1592, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1588)]
	public class BP_SceneLensflare_C : ALensflareSamplerActor, IUnrealUObject, IUnrealObject, IInterface_KuroLightBP, IUnrealNativeInterface, IUnrealInterface
	{
		// Token: 0x06024B46 RID: 150342 RVA: 0x009A5088 File Offset: 0x009A3288
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SceneLensflare_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/GI/NewLensflare/BP_SceneLensflare.BP_SceneLensflare_C");
			}
			return BP_SceneLensflare_C._ClassPtr;
		}

		// Token: 0x06024B47 RID: 150343 RVA: 0x009A50AC File Offset: 0x009A32AC
		int IInterface_KuroLightBP.InterfaceOffset()
		{
			return BP_SceneLensflare_C.__InterfaceOffset_IInterface_KuroLightBP;
		}

		// Token: 0x06024B48 RID: 150344 RVA: 0x009A50B4 File Offset: 0x009A32B4
		public BP_SceneLensflare_C() : this(BuiltinUtils.AllocNativeUObject(BP_SceneLensflare_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06024B49 RID: 150345 RVA: 0x009A50DC File Offset: 0x009A32DC
		[NullableContext(1)]
		public BP_SceneLensflare_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SceneLensflare_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004D8D RID: 19853
		// (get) Token: 0x06024B4A RID: 150346 RVA: 0x009A5110 File Offset: 0x009A3310
		// (set) Token: 0x06024B4B RID: 150347 RVA: 0x009A5149 File Offset: 0x009A3349
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_SceneLensflare_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_SceneLensflare_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004D8E RID: 19854
		// (get) Token: 0x06024B4C RID: 150348 RVA: 0x009A516A File Offset: 0x009A336A
		// (set) Token: 0x06024B4D RID: 150349 RVA: 0x009A517E File Offset: 0x009A337E
		public unsafe UBillboardComponent Billboard
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBillboardComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneLensflare_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneLensflare_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17004D8F RID: 19855
		// (get) Token: 0x06024B4E RID: 150350 RVA: 0x009A5193 File Offset: 0x009A3393
		// (set) Token: 0x06024B4F RID: 150351 RVA: 0x009A51A3 File Offset: 0x009A33A3
		public unsafe bool 自定义Ghost
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_C.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_C.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004D90 RID: 19856
		// (get) Token: 0x06024B50 RID: 150352 RVA: 0x009A51B4 File Offset: 0x009A33B4
		// (set) Token: 0x06024B51 RID: 150353 RVA: 0x009A51C4 File Offset: 0x009A33C4
		public unsafe float Ghost_大小
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17004D91 RID: 19857
		// (get) Token: 0x06024B52 RID: 150354 RVA: 0x009A51D5 File Offset: 0x009A33D5
		// (set) Token: 0x06024B53 RID: 150355 RVA: 0x009A51E5 File Offset: 0x009A33E5
		public unsafe float Ghost_分布偏移
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17004D92 RID: 19858
		// (get) Token: 0x06024B54 RID: 150356 RVA: 0x009A51F6 File Offset: 0x009A33F6
		// (set) Token: 0x06024B55 RID: 150357 RVA: 0x009A5206 File Offset: 0x009A3406
		public unsafe float Ghost_分布范围
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17004D93 RID: 19859
		// (get) Token: 0x06024B56 RID: 150358 RVA: 0x009A5217 File Offset: 0x009A3417
		// (set) Token: 0x06024B57 RID: 150359 RVA: 0x009A522B File Offset: 0x009A342B
		public unsafe FLinearColor Ghost_调色
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17004D94 RID: 19860
		// (get) Token: 0x06024B58 RID: 150360 RVA: 0x009A5240 File Offset: 0x009A3440
		// (set) Token: 0x06024B59 RID: 150361 RVA: 0x009A5250 File Offset: 0x009A3450
		public unsafe float Ghost_不透明度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17004D95 RID: 19861
		// (get) Token: 0x06024B5A RID: 150362 RVA: 0x009A5261 File Offset: 0x009A3461
		// (set) Token: 0x06024B5B RID: 150363 RVA: 0x009A5271 File Offset: 0x009A3471
		public unsafe bool 自定义Halo
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_C.__PropertyOffset_8) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_C.__PropertyOffset_8) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004D96 RID: 19862
		// (get) Token: 0x06024B5C RID: 150364 RVA: 0x009A5282 File Offset: 0x009A3482
		// (set) Token: 0x06024B5D RID: 150365 RVA: 0x009A5292 File Offset: 0x009A3492
		public unsafe float Halo_圆环衰减
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17004D97 RID: 19863
		// (get) Token: 0x06024B5E RID: 150366 RVA: 0x009A52A3 File Offset: 0x009A34A3
		// (set) Token: 0x06024B5F RID: 150367 RVA: 0x009A52B3 File Offset: 0x009A34B3
		public unsafe float Halo_大小
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17004D98 RID: 19864
		// (get) Token: 0x06024B60 RID: 150368 RVA: 0x009A52C4 File Offset: 0x009A34C4
		// (set) Token: 0x06024B61 RID: 150369 RVA: 0x009A52D4 File Offset: 0x009A34D4
		public unsafe float Halo_分布偏移
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17004D99 RID: 19865
		// (get) Token: 0x06024B62 RID: 150370 RVA: 0x009A52E5 File Offset: 0x009A34E5
		// (set) Token: 0x06024B63 RID: 150371 RVA: 0x009A52F5 File Offset: 0x009A34F5
		public unsafe float Halo_分布范围
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17004D9A RID: 19866
		// (get) Token: 0x06024B64 RID: 150372 RVA: 0x009A5306 File Offset: 0x009A3506
		// (set) Token: 0x06024B65 RID: 150373 RVA: 0x009A531A File Offset: 0x009A351A
		public unsafe FLinearColor Halo_调色
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17004D9B RID: 19867
		// (get) Token: 0x06024B66 RID: 150374 RVA: 0x009A532F File Offset: 0x009A352F
		// (set) Token: 0x06024B67 RID: 150375 RVA: 0x009A533F File Offset: 0x009A353F
		public unsafe float Halo_不透明度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17004D9C RID: 19868
		// (get) Token: 0x06024B68 RID: 150376 RVA: 0x009A5350 File Offset: 0x009A3550
		// (set) Token: 0x06024B69 RID: 150377 RVA: 0x009A5360 File Offset: 0x009A3560
		public unsafe bool 自定义Glare
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_C.__PropertyOffset_15) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_C.__PropertyOffset_15) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004D9D RID: 19869
		// (get) Token: 0x06024B6A RID: 150378 RVA: 0x009A5371 File Offset: 0x009A3571
		// (set) Token: 0x06024B6B RID: 150379 RVA: 0x009A5385 File Offset: 0x009A3585
		public unsafe FVector2D Glare_大小
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x17004D9E RID: 19870
		// (get) Token: 0x06024B6C RID: 150380 RVA: 0x009A539A File Offset: 0x009A359A
		// (set) Token: 0x06024B6D RID: 150381 RVA: 0x009A53AE File Offset: 0x009A35AE
		public unsafe FLinearColor Glare_调色
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x17004D9F RID: 19871
		// (get) Token: 0x06024B6E RID: 150382 RVA: 0x009A53C3 File Offset: 0x009A35C3
		// (set) Token: 0x06024B6F RID: 150383 RVA: 0x009A53D3 File Offset: 0x009A35D3
		public unsafe float Glare_不透明度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x17004DA0 RID: 19872
		// (get) Token: 0x06024B70 RID: 150384 RVA: 0x009A53E4 File Offset: 0x009A35E4
		// (set) Token: 0x06024B71 RID: 150385 RVA: 0x009A53F4 File Offset: 0x009A35F4
		public unsafe float Glare_旋转
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x17004DA1 RID: 19873
		// (get) Token: 0x06024B72 RID: 150386 RVA: 0x009A5405 File Offset: 0x009A3605
		// (set) Token: 0x06024B73 RID: 150387 RVA: 0x009A5415 File Offset: 0x009A3615
		public unsafe float Glare_锁定动态旋转
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x17004DA2 RID: 19874
		// (get) Token: 0x06024B74 RID: 150388 RVA: 0x009A5426 File Offset: 0x009A3626
		// (set) Token: 0x06024B75 RID: 150389 RVA: 0x009A5436 File Offset: 0x009A3636
		public unsafe float Ghost_受背景色影响
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x17004DA3 RID: 19875
		// (get) Token: 0x06024B76 RID: 150390 RVA: 0x009A5447 File Offset: 0x009A3647
		// (set) Token: 0x06024B77 RID: 150391 RVA: 0x009A5457 File Offset: 0x009A3657
		public unsafe float Halo_受背景色影响
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x17004DA4 RID: 19876
		// (get) Token: 0x06024B78 RID: 150392 RVA: 0x009A5468 File Offset: 0x009A3668
		// (set) Token: 0x06024B79 RID: 150393 RVA: 0x009A5478 File Offset: 0x009A3678
		public unsafe float Glare_受背景色影响
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x17004DA5 RID: 19877
		// (get) Token: 0x06024B7A RID: 150394 RVA: 0x009A5489 File Offset: 0x009A3689
		// (set) Token: 0x06024B7B RID: 150395 RVA: 0x009A5499 File Offset: 0x009A3699
		public unsafe float Ghost_视角衰减速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_C.__PropertyOffset_24);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_C.__PropertyOffset_24) = value;
			}
		}

		// Token: 0x17004DA6 RID: 19878
		// (get) Token: 0x06024B7C RID: 150396 RVA: 0x009A54AA File Offset: 0x009A36AA
		// (set) Token: 0x06024B7D RID: 150397 RVA: 0x009A54BA File Offset: 0x009A36BA
		public unsafe float Halo_视角衰减速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_C.__PropertyOffset_25);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_C.__PropertyOffset_25) = value;
			}
		}

		// Token: 0x17004DA7 RID: 19879
		// (get) Token: 0x06024B7E RID: 150398 RVA: 0x009A54CB File Offset: 0x009A36CB
		// (set) Token: 0x06024B7F RID: 150399 RVA: 0x009A54DB File Offset: 0x009A36DB
		public unsafe float Glare_视角衰减速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_C.__PropertyOffset_26);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_C.__PropertyOffset_26) = value;
			}
		}

		// Token: 0x17004DA8 RID: 19880
		// (get) Token: 0x06024B80 RID: 150400 RVA: 0x009A54EC File Offset: 0x009A36EC
		// (set) Token: 0x06024B81 RID: 150401 RVA: 0x009A54FC File Offset: 0x009A36FC
		public unsafe bool Ghost_使用固定旋转
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_C.__PropertyOffset_27) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_C.__PropertyOffset_27) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004DA9 RID: 19881
		// (get) Token: 0x06024B82 RID: 150402 RVA: 0x009A550D File Offset: 0x009A370D
		// (set) Token: 0x06024B83 RID: 150403 RVA: 0x009A551D File Offset: 0x009A371D
		public unsafe float Ghost_固定旋转值
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_C.__PropertyOffset_28);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_C.__PropertyOffset_28) = value;
			}
		}

		// Token: 0x17004DAA RID: 19882
		// (get) Token: 0x06024B84 RID: 150404 RVA: 0x009A552E File Offset: 0x009A372E
		// (set) Token: 0x06024B85 RID: 150405 RVA: 0x009A553E File Offset: 0x009A373E
		public unsafe bool 自定义Ghost贴图
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_C.__PropertyOffset_29) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_C.__PropertyOffset_29) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004DAB RID: 19883
		// (get) Token: 0x06024B86 RID: 150406 RVA: 0x009A554F File Offset: 0x009A374F
		// (set) Token: 0x06024B87 RID: 150407 RVA: 0x009A5563 File Offset: 0x009A3763
		public unsafe UTexture2D Ghost贴图
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneLensflare_C.__PropertyOffset_30);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneLensflare_C.__PropertyOffset_30, value);
			}
		}

		// Token: 0x17004DAC RID: 19884
		// (get) Token: 0x06024B88 RID: 150408 RVA: 0x009A5578 File Offset: 0x009A3778
		// (set) Token: 0x06024B89 RID: 150409 RVA: 0x009A5588 File Offset: 0x009A3788
		public unsafe bool Halo_使用固定旋转
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_C.__PropertyOffset_31) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_C.__PropertyOffset_31) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004DAD RID: 19885
		// (get) Token: 0x06024B8A RID: 150410 RVA: 0x009A5599 File Offset: 0x009A3799
		// (set) Token: 0x06024B8B RID: 150411 RVA: 0x009A55A9 File Offset: 0x009A37A9
		public unsafe float Halo_固定旋转值
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_C.__PropertyOffset_32);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_C.__PropertyOffset_32) = value;
			}
		}

		// Token: 0x17004DAE RID: 19886
		// (get) Token: 0x06024B8C RID: 150412 RVA: 0x009A55BA File Offset: 0x009A37BA
		// (set) Token: 0x06024B8D RID: 150413 RVA: 0x009A55CA File Offset: 0x009A37CA
		public unsafe bool 自定义Halo贴图
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_C.__PropertyOffset_33) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_C.__PropertyOffset_33) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004DAF RID: 19887
		// (get) Token: 0x06024B8E RID: 150414 RVA: 0x009A55DB File Offset: 0x009A37DB
		// (set) Token: 0x06024B8F RID: 150415 RVA: 0x009A55EF File Offset: 0x009A37EF
		public unsafe UTexture2D Halo贴图
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneLensflare_C.__PropertyOffset_34);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneLensflare_C.__PropertyOffset_34, value);
			}
		}

		// Token: 0x17004DB0 RID: 19888
		// (get) Token: 0x06024B90 RID: 150416 RVA: 0x009A5604 File Offset: 0x009A3804
		// (set) Token: 0x06024B91 RID: 150417 RVA: 0x009A5614 File Offset: 0x009A3814
		public unsafe bool 自定义Glare贴图
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_C.__PropertyOffset_35) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_C.__PropertyOffset_35) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004DB1 RID: 19889
		// (get) Token: 0x06024B92 RID: 150418 RVA: 0x009A5625 File Offset: 0x009A3825
		// (set) Token: 0x06024B93 RID: 150419 RVA: 0x009A5639 File Offset: 0x009A3839
		public unsafe UTexture2D Glare贴图
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneLensflare_C.__PropertyOffset_36);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneLensflare_C.__PropertyOffset_36, value);
			}
		}

		// Token: 0x17004DB2 RID: 19890
		// (get) Token: 0x06024B94 RID: 150420 RVA: 0x009A564E File Offset: 0x009A384E
		// (set) Token: 0x06024B95 RID: 150421 RVA: 0x009A5662 File Offset: 0x009A3862
		public unsafe FLinearColor Glare_UV缩放_偏移
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_C.__PropertyOffset_37);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_C.__PropertyOffset_37) = value;
			}
		}

		// Token: 0x17004DB3 RID: 19891
		// (get) Token: 0x06024B96 RID: 150422 RVA: 0x009A5677 File Offset: 0x009A3877
		// (set) Token: 0x06024B97 RID: 150423 RVA: 0x009A5687 File Offset: 0x009A3887
		public unsafe float 衰减系数
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_C.__PropertyOffset_38);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_C.__PropertyOffset_38) = value;
			}
		}

		// Token: 0x17004DB4 RID: 19892
		// (get) Token: 0x06024B98 RID: 150424 RVA: 0x009A5698 File Offset: 0x009A3898
		// (set) Token: 0x06024B99 RID: 150425 RVA: 0x009A56A8 File Offset: 0x009A38A8
		public unsafe float 屏占比剔除阈值
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_C.__PropertyOffset_39);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_C.__PropertyOffset_39) = value;
			}
		}

		// Token: 0x17004DB5 RID: 19893
		// (get) Token: 0x06024B9A RID: 150426 RVA: 0x009A56B9 File Offset: 0x009A38B9
		// (set) Token: 0x06024B9B RID: 150427 RVA: 0x009A56C9 File Offset: 0x009A38C9
		public unsafe float 反向衰减偏移
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_C.__PropertyOffset_40);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_C.__PropertyOffset_40) = value;
			}
		}

		// Token: 0x17004DB6 RID: 19894
		// (get) Token: 0x06024B9C RID: 150428 RVA: 0x009A56DA File Offset: 0x009A38DA
		// (set) Token: 0x06024B9D RID: 150429 RVA: 0x009A56EA File Offset: 0x009A38EA
		public unsafe float 反向衰减长度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_C.__PropertyOffset_41);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_C.__PropertyOffset_41) = value;
			}
		}

		// Token: 0x17004DB7 RID: 19895
		// (get) Token: 0x06024B9E RID: 150430 RVA: 0x009A56FB File Offset: 0x009A38FB
		// (set) Token: 0x06024B9F RID: 150431 RVA: 0x009A570B File Offset: 0x009A390B
		public unsafe float 反向衰减系数
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_C.__PropertyOffset_42);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_C.__PropertyOffset_42) = value;
			}
		}

		// Token: 0x06024BA0 RID: 150432 RVA: 0x009A571C File Offset: 0x009A391C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual int GetPlacementSortOrder()
		{
			BP_SceneLensflare_C.__GetPlacementSortOrder_FunctionParams* ptr = stackalloc BP_SceneLensflare_C.__GetPlacementSortOrder_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SceneLensflare_C.__GetPlacementSortOrder_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SceneLensflare_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SceneLensflare_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr);
			return ptr->__Result;
		}

		// Token: 0x06024BA1 RID: 150433 RVA: 0x009A5764 File Offset: 0x009A3964
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual int GetPlacementSortOrder_Implementation()
		{
			BP_SceneLensflare_C.__GetPlacementSortOrder_FunctionParams* ptr = stackalloc BP_SceneLensflare_C.__GetPlacementSortOrder_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SceneLensflare_C.__GetPlacementSortOrder_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SceneLensflare_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SceneLensflare_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr, 0);
			return ptr->__Result;
		}

		// Token: 0x06024BA2 RID: 150434 RVA: 0x009A57AC File Offset: 0x009A39AC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetParameterCommon(UMaterialInstanceDynamic DynamicMaterial)
		{
			BP_SceneLensflare_C.__SetParameterCommon_FunctionParams* ptr = stackalloc BP_SceneLensflare_C.__SetParameterCommon_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_SceneLensflare_C.__SetParameterCommon_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SceneLensflare_C.__SetParameterCommon_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DynamicMaterial = ((DynamicMaterial != null) ? DynamicMaterial.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SceneLensflare_C.__SetParameterCommon_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024BA3 RID: 150435 RVA: 0x009A5804 File Offset: 0x009A3A04
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override FLensflareSamplerActorParameter GetLensflareParameter()
		{
			BP_SceneLensflare_C.__GetLensflareParameter_FunctionParams* ptr = stackalloc BP_SceneLensflare_C.__GetLensflareParameter_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(BP_SceneLensflare_C.__GetLensflareParameter_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SceneLensflare_C.__GetLensflareParameter_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SceneLensflare_C.__GetLensflareParameter_NativeFunctionPtr, (void*)ptr);
			return new FLensflareSamplerActorParameter(&ptr->__Result, true, true);
		}

		// Token: 0x06024BA4 RID: 150436 RVA: 0x009A5854 File Offset: 0x009A3A54
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual FLensflareSamplerActorParameter GetLensflareParameter_Implementation()
		{
			BP_SceneLensflare_C.__GetLensflareParameter_FunctionParams* ptr = stackalloc BP_SceneLensflare_C.__GetLensflareParameter_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(BP_SceneLensflare_C.__GetLensflareParameter_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SceneLensflare_C.__GetLensflareParameter_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SceneLensflare_C.__GetLensflareParameter_NativeFunctionPtr, (void*)ptr, 0);
			return new FLensflareSamplerActorParameter(&ptr->__Result, true, true);
		}

		// Token: 0x06024BA5 RID: 150437 RVA: 0x009A58A4 File Offset: 0x009A3AA4
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override FLensflareSamplerActorGlareParameter GetCustomGlareParameter()
		{
			BP_SceneLensflare_C.__GetCustomGlareParameter_FunctionParams* ptr = stackalloc BP_SceneLensflare_C.__GetCustomGlareParameter_FunctionParams[(UIntPtr)175] + 15L / (long)sizeof(BP_SceneLensflare_C.__GetCustomGlareParameter_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SceneLensflare_C.__GetCustomGlareParameter_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SceneLensflare_C.__GetCustomGlareParameter_NativeFunctionPtr, (void*)ptr);
			return new FLensflareSamplerActorGlareParameter(&ptr->__Result, true, true);
		}

		// Token: 0x06024BA6 RID: 150438 RVA: 0x009A58F4 File Offset: 0x009A3AF4
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual FLensflareSamplerActorGlareParameter GetCustomGlareParameter_Implementation()
		{
			BP_SceneLensflare_C.__GetCustomGlareParameter_FunctionParams* ptr = stackalloc BP_SceneLensflare_C.__GetCustomGlareParameter_FunctionParams[(UIntPtr)175] + 15L / (long)sizeof(BP_SceneLensflare_C.__GetCustomGlareParameter_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SceneLensflare_C.__GetCustomGlareParameter_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SceneLensflare_C.__GetCustomGlareParameter_NativeFunctionPtr, (void*)ptr, 0);
			return new FLensflareSamplerActorGlareParameter(&ptr->__Result, true, true);
		}

		// Token: 0x06024BA7 RID: 150439 RVA: 0x009A5948 File Offset: 0x009A3B48
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override FLensflareSamplerActorHaloParameter GetCustomHaloParameter()
		{
			BP_SceneLensflare_C.__GetCustomHaloParameter_FunctionParams* ptr = stackalloc BP_SceneLensflare_C.__GetCustomHaloParameter_FunctionParams[(UIntPtr)159] + 15L / (long)sizeof(BP_SceneLensflare_C.__GetCustomHaloParameter_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SceneLensflare_C.__GetCustomHaloParameter_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SceneLensflare_C.__GetCustomHaloParameter_NativeFunctionPtr, (void*)ptr);
			return new FLensflareSamplerActorHaloParameter(&ptr->__Result, true, true);
		}

		// Token: 0x06024BA8 RID: 150440 RVA: 0x009A5998 File Offset: 0x009A3B98
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual FLensflareSamplerActorHaloParameter GetCustomHaloParameter_Implementation()
		{
			BP_SceneLensflare_C.__GetCustomHaloParameter_FunctionParams* ptr = stackalloc BP_SceneLensflare_C.__GetCustomHaloParameter_FunctionParams[(UIntPtr)159] + 15L / (long)sizeof(BP_SceneLensflare_C.__GetCustomHaloParameter_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SceneLensflare_C.__GetCustomHaloParameter_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SceneLensflare_C.__GetCustomHaloParameter_NativeFunctionPtr, (void*)ptr, 0);
			return new FLensflareSamplerActorHaloParameter(&ptr->__Result, true, true);
		}

		// Token: 0x06024BA9 RID: 150441 RVA: 0x009A59EC File Offset: 0x009A3BEC
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override FLensflareSamplerActorGhostParameter GetCustomGhostParameter()
		{
			BP_SceneLensflare_C.__GetCustomGhostParameter_FunctionParams* ptr = stackalloc BP_SceneLensflare_C.__GetCustomGhostParameter_FunctionParams[(UIntPtr)143] + 15L / (long)sizeof(BP_SceneLensflare_C.__GetCustomGhostParameter_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SceneLensflare_C.__GetCustomGhostParameter_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SceneLensflare_C.__GetCustomGhostParameter_NativeFunctionPtr, (void*)ptr);
			return new FLensflareSamplerActorGhostParameter(&ptr->__Result, true, true);
		}

		// Token: 0x06024BAA RID: 150442 RVA: 0x009A5A3C File Offset: 0x009A3C3C
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual FLensflareSamplerActorGhostParameter GetCustomGhostParameter_Implementation()
		{
			BP_SceneLensflare_C.__GetCustomGhostParameter_FunctionParams* ptr = stackalloc BP_SceneLensflare_C.__GetCustomGhostParameter_FunctionParams[(UIntPtr)143] + 15L / (long)sizeof(BP_SceneLensflare_C.__GetCustomGhostParameter_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SceneLensflare_C.__GetCustomGhostParameter_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SceneLensflare_C.__GetCustomGhostParameter_NativeFunctionPtr, (void*)ptr, 0);
			return new FLensflareSamplerActorGhostParameter(&ptr->__Result, true, true);
		}

		// Token: 0x06024BAB RID: 150443 RVA: 0x009A5A90 File Offset: 0x009A3C90
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ApplyDynamicMaterialGhost(UMaterialInstanceDynamic DynMaterial)
		{
			BP_SceneLensflare_C.__ApplyDynamicMaterialGhost_FunctionParams* ptr = stackalloc BP_SceneLensflare_C.__ApplyDynamicMaterialGhost_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_SceneLensflare_C.__ApplyDynamicMaterialGhost_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SceneLensflare_C.__ApplyDynamicMaterialGhost_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DynMaterial = ((DynMaterial != null) ? DynMaterial.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SceneLensflare_C.__ApplyDynamicMaterialGhost_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024BAC RID: 150444 RVA: 0x009A5AE8 File Offset: 0x009A3CE8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ApplyDynamicMaterialGhost_Implementation(UMaterialInstanceDynamic DynMaterial)
		{
			BP_SceneLensflare_C.__ApplyDynamicMaterialGhost_FunctionParams* ptr = stackalloc BP_SceneLensflare_C.__ApplyDynamicMaterialGhost_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_SceneLensflare_C.__ApplyDynamicMaterialGhost_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SceneLensflare_C.__ApplyDynamicMaterialGhost_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DynMaterial = ((DynMaterial != null) ? DynMaterial.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SceneLensflare_C.__ApplyDynamicMaterialGhost_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024BAD RID: 150445 RVA: 0x009A5B40 File Offset: 0x009A3D40
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ApplyDynamicMaterialHalo(UMaterialInstanceDynamic DynMaterial)
		{
			BP_SceneLensflare_C.__ApplyDynamicMaterialHalo_FunctionParams* ptr = stackalloc BP_SceneLensflare_C.__ApplyDynamicMaterialHalo_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_SceneLensflare_C.__ApplyDynamicMaterialHalo_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SceneLensflare_C.__ApplyDynamicMaterialHalo_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DynMaterial = ((DynMaterial != null) ? DynMaterial.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SceneLensflare_C.__ApplyDynamicMaterialHalo_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024BAE RID: 150446 RVA: 0x009A5B98 File Offset: 0x009A3D98
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ApplyDynamicMaterialHalo_Implementation(UMaterialInstanceDynamic DynMaterial)
		{
			BP_SceneLensflare_C.__ApplyDynamicMaterialHalo_FunctionParams* ptr = stackalloc BP_SceneLensflare_C.__ApplyDynamicMaterialHalo_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_SceneLensflare_C.__ApplyDynamicMaterialHalo_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SceneLensflare_C.__ApplyDynamicMaterialHalo_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DynMaterial = ((DynMaterial != null) ? DynMaterial.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SceneLensflare_C.__ApplyDynamicMaterialHalo_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024BAF RID: 150447 RVA: 0x009A5BF0 File Offset: 0x009A3DF0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ApplyDynamicMaterialGlare(UMaterialInstanceDynamic DynMaterial)
		{
			BP_SceneLensflare_C.__ApplyDynamicMaterialGlare_FunctionParams* ptr = stackalloc BP_SceneLensflare_C.__ApplyDynamicMaterialGlare_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_SceneLensflare_C.__ApplyDynamicMaterialGlare_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SceneLensflare_C.__ApplyDynamicMaterialGlare_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DynMaterial = ((DynMaterial != null) ? DynMaterial.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SceneLensflare_C.__ApplyDynamicMaterialGlare_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024BB0 RID: 150448 RVA: 0x009A5C48 File Offset: 0x009A3E48
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ApplyDynamicMaterialGlare_Implementation(UMaterialInstanceDynamic DynMaterial)
		{
			BP_SceneLensflare_C.__ApplyDynamicMaterialGlare_FunctionParams* ptr = stackalloc BP_SceneLensflare_C.__ApplyDynamicMaterialGlare_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_SceneLensflare_C.__ApplyDynamicMaterialGlare_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SceneLensflare_C.__ApplyDynamicMaterialGlare_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DynMaterial = ((DynMaterial != null) ? DynMaterial.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SceneLensflare_C.__ApplyDynamicMaterialGlare_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024BB1 RID: 150449 RVA: 0x009A5CA0 File Offset: 0x009A3EA0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_SceneLensflare(int EntryPoint)
		{
			BP_SceneLensflare_C.__ExecuteUbergraph_BP_SceneLensflare_FunctionParams* ptr = stackalloc BP_SceneLensflare_C.__ExecuteUbergraph_BP_SceneLensflare_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_SceneLensflare_C.__ExecuteUbergraph_BP_SceneLensflare_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SceneLensflare_C.__ExecuteUbergraph_BP_SceneLensflare_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SceneLensflare_C.__ExecuteUbergraph_BP_SceneLensflare_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024BB2 RID: 150450 RVA: 0x009A5CE7 File Offset: 0x009A3EE7
		protected BP_SceneLensflare_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04012D27 RID: 77095
		internal static int __InterfaceOffset_IInterface_KuroLightBP;

		// Token: 0x04012D28 RID: 77096
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/GI/NewLensflare/BP_SceneLensflare.BP_SceneLensflare_C";

		// Token: 0x04012D29 RID: 77097
		private static IntPtr _ClassPtr;

		// Token: 0x04012D2A RID: 77098
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04012D2B RID: 77099
		internal static int __PropertyOffset_0;

		// Token: 0x04012D2C RID: 77100
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04012D2D RID: 77101
		internal static int __PropertyOffset_1;

		// Token: 0x04012D2E RID: 77102
		internal static int __PropertyOffset_2;

		// Token: 0x04012D2F RID: 77103
		internal static int __PropertyOffset_3;

		// Token: 0x04012D30 RID: 77104
		internal static int __PropertyOffset_4;

		// Token: 0x04012D31 RID: 77105
		internal static int __PropertyOffset_5;

		// Token: 0x04012D32 RID: 77106
		internal static int __PropertyOffset_6;

		// Token: 0x04012D33 RID: 77107
		internal static int __PropertyOffset_7;

		// Token: 0x04012D34 RID: 77108
		internal static int __PropertyOffset_8;

		// Token: 0x04012D35 RID: 77109
		internal static int __PropertyOffset_9;

		// Token: 0x04012D36 RID: 77110
		internal static int __PropertyOffset_10;

		// Token: 0x04012D37 RID: 77111
		internal static int __PropertyOffset_11;

		// Token: 0x04012D38 RID: 77112
		internal static int __PropertyOffset_12;

		// Token: 0x04012D39 RID: 77113
		internal static int __PropertyOffset_13;

		// Token: 0x04012D3A RID: 77114
		internal static int __PropertyOffset_14;

		// Token: 0x04012D3B RID: 77115
		internal static int __PropertyOffset_15;

		// Token: 0x04012D3C RID: 77116
		internal static int __PropertyOffset_16;

		// Token: 0x04012D3D RID: 77117
		internal static int __PropertyOffset_17;

		// Token: 0x04012D3E RID: 77118
		internal static int __PropertyOffset_18;

		// Token: 0x04012D3F RID: 77119
		internal static int __PropertyOffset_19;

		// Token: 0x04012D40 RID: 77120
		internal static int __PropertyOffset_20;

		// Token: 0x04012D41 RID: 77121
		internal static int __PropertyOffset_21;

		// Token: 0x04012D42 RID: 77122
		internal static int __PropertyOffset_22;

		// Token: 0x04012D43 RID: 77123
		internal static int __PropertyOffset_23;

		// Token: 0x04012D44 RID: 77124
		internal static int __PropertyOffset_24;

		// Token: 0x04012D45 RID: 77125
		internal static int __PropertyOffset_25;

		// Token: 0x04012D46 RID: 77126
		internal static int __PropertyOffset_26;

		// Token: 0x04012D47 RID: 77127
		internal static int __PropertyOffset_27;

		// Token: 0x04012D48 RID: 77128
		internal static int __PropertyOffset_28;

		// Token: 0x04012D49 RID: 77129
		internal static int __PropertyOffset_29;

		// Token: 0x04012D4A RID: 77130
		internal static int __PropertyOffset_30;

		// Token: 0x04012D4B RID: 77131
		internal static int __PropertyOffset_31;

		// Token: 0x04012D4C RID: 77132
		internal static int __PropertyOffset_32;

		// Token: 0x04012D4D RID: 77133
		internal static int __PropertyOffset_33;

		// Token: 0x04012D4E RID: 77134
		internal static int __PropertyOffset_34;

		// Token: 0x04012D4F RID: 77135
		internal static int __PropertyOffset_35;

		// Token: 0x04012D50 RID: 77136
		internal static int __PropertyOffset_36;

		// Token: 0x04012D51 RID: 77137
		internal static int __PropertyOffset_37;

		// Token: 0x04012D52 RID: 77138
		internal static int __PropertyOffset_38;

		// Token: 0x04012D53 RID: 77139
		internal static int __PropertyOffset_39;

		// Token: 0x04012D54 RID: 77140
		internal static int __PropertyOffset_40;

		// Token: 0x04012D55 RID: 77141
		internal static int __PropertyOffset_41;

		// Token: 0x04012D56 RID: 77142
		internal static int __PropertyOffset_42;

		// Token: 0x04012D57 RID: 77143
		private static IntPtr __GetPlacementSortOrder_NativeFunctionPtr;

		// Token: 0x04012D58 RID: 77144
		private static IntPtr __SetParameterCommon_NativeFunctionPtr;

		// Token: 0x04012D59 RID: 77145
		private static IntPtr __GetLensflareParameter_NativeFunctionPtr;

		// Token: 0x04012D5A RID: 77146
		private static IntPtr __GetCustomGlareParameter_NativeFunctionPtr;

		// Token: 0x04012D5B RID: 77147
		private static IntPtr __GetCustomHaloParameter_NativeFunctionPtr;

		// Token: 0x04012D5C RID: 77148
		private static IntPtr __GetCustomGhostParameter_NativeFunctionPtr;

		// Token: 0x04012D5D RID: 77149
		private static IntPtr __ApplyDynamicMaterialGhost_NativeFunctionPtr;

		// Token: 0x04012D5E RID: 77150
		private static IntPtr __ApplyDynamicMaterialHalo_NativeFunctionPtr;

		// Token: 0x04012D5F RID: 77151
		private static IntPtr __ApplyDynamicMaterialGlare_NativeFunctionPtr;

		// Token: 0x04012D60 RID: 77152
		private static IntPtr __ExecuteUbergraph_BP_SceneLensflare_NativeFunctionPtr;

		// Token: 0x02009E32 RID: 40498
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __GetPlacementSortOrder_FunctionParams
		{
			// Token: 0x04032885 RID: 206981
			[FieldOffset(0)]
			public int __Result;
		}

		// Token: 0x02009E33 RID: 40499
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __SetParameterCommon_FunctionParams
		{
			// Token: 0x04032886 RID: 206982
			[FieldOffset(0)]
			public IntPtr DynamicMaterial;
		}

		// Token: 0x02009E34 RID: 40500
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected new ref struct __GetLensflareParameter_FunctionParams
		{
			// Token: 0x04032887 RID: 206983
			[FieldOffset(0)]
			public byte __Result;
		}

		// Token: 0x02009E35 RID: 40501
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 160)]
		protected new ref struct __GetCustomGlareParameter_FunctionParams
		{
			// Token: 0x04032888 RID: 206984
			[FieldOffset(0)]
			public byte __Result;
		}

		// Token: 0x02009E36 RID: 40502
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 144)]
		protected new ref struct __GetCustomHaloParameter_FunctionParams
		{
			// Token: 0x04032889 RID: 206985
			[FieldOffset(0)]
			public byte __Result;
		}

		// Token: 0x02009E37 RID: 40503
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 128)]
		protected new ref struct __GetCustomGhostParameter_FunctionParams
		{
			// Token: 0x0403288A RID: 206986
			[FieldOffset(0)]
			public byte __Result;
		}

		// Token: 0x02009E38 RID: 40504
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected new ref struct __ApplyDynamicMaterialGhost_FunctionParams
		{
			// Token: 0x0403288B RID: 206987
			[FieldOffset(0)]
			public IntPtr DynMaterial;
		}

		// Token: 0x02009E39 RID: 40505
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected new ref struct __ApplyDynamicMaterialHalo_FunctionParams
		{
			// Token: 0x0403288C RID: 206988
			[FieldOffset(0)]
			public IntPtr DynMaterial;
		}

		// Token: 0x02009E3A RID: 40506
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected new ref struct __ApplyDynamicMaterialGlare_FunctionParams
		{
			// Token: 0x0403288D RID: 206989
			[FieldOffset(0)]
			public IntPtr DynMaterial;
		}

		// Token: 0x02009E3B RID: 40507
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __ExecuteUbergraph_BP_SceneLensflare_FunctionParams
		{
			// Token: 0x0403288E RID: 206990
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
