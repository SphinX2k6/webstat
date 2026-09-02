using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter.Camera;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.Structure
{
	// Token: 0x02004007 RID: 16391
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/Structure/BP_QTE_Camera.BP_QTE_Camera_C")]
	[UnrealStructLayout(576, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 576)]
	public class BP_QTE_Camera_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602A931 RID: 174385 RVA: 0x00A5D0A3 File Offset: 0x00A5B2A3
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_QTE_Camera_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Data/Structure/BP_QTE_Camera.BP_QTE_Camera_C");
			}
			return BP_QTE_Camera_C._ClassPtr;
		}

		// Token: 0x0602A932 RID: 174386 RVA: 0x00A5D0C8 File Offset: 0x00A5B2C8
		public BP_QTE_Camera_C() : this(BuiltinUtils.AllocNativeUObject(BP_QTE_Camera_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602A933 RID: 174387 RVA: 0x00A5D0F0 File Offset: 0x00A5B2F0
		public BP_QTE_Camera_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_QTE_Camera_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17006ED1 RID: 28369
		// (get) Token: 0x0602A934 RID: 174388 RVA: 0x00A5D124 File Offset: 0x00A5B324
		// (set) Token: 0x0602A935 RID: 174389 RVA: 0x00A5D15D File Offset: 0x00A5B35D
		public SCameraModifier_Settings 相机配置
		{
			get
			{
				base.FastCheckIsValid();
				SCameraModifier_Settings result;
				if ((result = this._相机配置) == null)
				{
					result = (this._相机配置 = new SCameraModifier_Settings(base.NativePtr + (IntPtr)BP_QTE_Camera_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SCameraModifier_Settings.StaticStruct(), base.NativePtr + (IntPtr)BP_QTE_Camera_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006ED2 RID: 28370
		// (get) Token: 0x0602A936 RID: 174390 RVA: 0x00A5D17E File Offset: 0x00A5B37E
		// (set) Token: 0x0602A937 RID: 174391 RVA: 0x00A5D18E File Offset: 0x00A5B38E
		public unsafe float Duration
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QTE_Camera_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QTE_Camera_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17006ED3 RID: 28371
		// (get) Token: 0x0602A938 RID: 174392 RVA: 0x00A5D19F File Offset: 0x00A5B39F
		// (set) Token: 0x0602A939 RID: 174393 RVA: 0x00A5D1AF File Offset: 0x00A5B3AF
		public unsafe float BlendInTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QTE_Camera_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QTE_Camera_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17006ED4 RID: 28372
		// (get) Token: 0x0602A93A RID: 174394 RVA: 0x00A5D1C0 File Offset: 0x00A5B3C0
		// (set) Token: 0x0602A93B RID: 174395 RVA: 0x00A5D1D0 File Offset: 0x00A5B3D0
		public unsafe float BlendOutTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QTE_Camera_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QTE_Camera_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17006ED5 RID: 28373
		// (get) Token: 0x0602A93C RID: 174396 RVA: 0x00A5D1E1 File Offset: 0x00A5B3E1
		// (set) Token: 0x0602A93D RID: 174397 RVA: 0x00A5D1F1 File Offset: 0x00A5B3F1
		public unsafe float BreakBlendOutTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QTE_Camera_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QTE_Camera_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17006ED6 RID: 28374
		// (get) Token: 0x0602A93E RID: 174398 RVA: 0x00A5D204 File Offset: 0x00A5B404
		// (set) Token: 0x0602A93F RID: 174399 RVA: 0x00A5D23D File Offset: 0x00A5B43D
		public SBaseCurve BlendInCurve
		{
			get
			{
				base.FastCheckIsValid();
				SBaseCurve result;
				if ((result = this._BlendInCurve) == null)
				{
					result = (this._BlendInCurve = new SBaseCurve(base.NativePtr + (IntPtr)BP_QTE_Camera_C.__PropertyOffset_5, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SBaseCurve.StaticStruct(), base.NativePtr + (IntPtr)BP_QTE_Camera_C.__PropertyOffset_5, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006ED7 RID: 28375
		// (get) Token: 0x0602A940 RID: 174400 RVA: 0x00A5D260 File Offset: 0x00A5B460
		// (set) Token: 0x0602A941 RID: 174401 RVA: 0x00A5D299 File Offset: 0x00A5B499
		public SBaseCurve BlendOutCurve
		{
			get
			{
				base.FastCheckIsValid();
				SBaseCurve result;
				if ((result = this._BlendOutCurve) == null)
				{
					result = (this._BlendOutCurve = new SBaseCurve(base.NativePtr + (IntPtr)BP_QTE_Camera_C.__PropertyOffset_6, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SBaseCurve.StaticStruct(), base.NativePtr + (IntPtr)BP_QTE_Camera_C.__PropertyOffset_6, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006ED8 RID: 28376
		// (get) Token: 0x0602A942 RID: 174402 RVA: 0x00A5D2BA File Offset: 0x00A5B4BA
		// (set) Token: 0x0602A943 RID: 174403 RVA: 0x00A5D2CA File Offset: 0x00A5B4CA
		public unsafe float 设置QTE位置_角度_有目标_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QTE_Camera_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QTE_Camera_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17006ED9 RID: 28377
		// (get) Token: 0x0602A944 RID: 174404 RVA: 0x00A5D2DB File Offset: 0x00A5B4DB
		// (set) Token: 0x0602A945 RID: 174405 RVA: 0x00A5D2EB File Offset: 0x00A5B4EB
		public unsafe float 设置QTE位置_距离_有目标_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QTE_Camera_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QTE_Camera_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17006EDA RID: 28378
		// (get) Token: 0x0602A946 RID: 174406 RVA: 0x00A5D2FC File Offset: 0x00A5B4FC
		// (set) Token: 0x0602A947 RID: 174407 RVA: 0x00A5D30C File Offset: 0x00A5B50C
		public unsafe float 设置QTE位置_高度_有目标_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QTE_Camera_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QTE_Camera_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17006EDB RID: 28379
		// (get) Token: 0x0602A948 RID: 174408 RVA: 0x00A5D31D File Offset: 0x00A5B51D
		// (set) Token: 0x0602A949 RID: 174409 RVA: 0x00A5D32D File Offset: 0x00A5B52D
		public unsafe float 设置QTE位置_角度_无目标_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QTE_Camera_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QTE_Camera_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17006EDC RID: 28380
		// (get) Token: 0x0602A94A RID: 174410 RVA: 0x00A5D33E File Offset: 0x00A5B53E
		// (set) Token: 0x0602A94B RID: 174411 RVA: 0x00A5D34E File Offset: 0x00A5B54E
		public unsafe float 设置QTE位置_距离_无目标_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QTE_Camera_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QTE_Camera_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17006EDD RID: 28381
		// (get) Token: 0x0602A94C RID: 174412 RVA: 0x00A5D35F File Offset: 0x00A5B55F
		// (set) Token: 0x0602A94D RID: 174413 RVA: 0x00A5D36F File Offset: 0x00A5B56F
		public unsafe float 设置QTE位置_高度_无目标_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QTE_Camera_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QTE_Camera_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17006EDE RID: 28382
		// (get) Token: 0x0602A94E RID: 174414 RVA: 0x00A5D380 File Offset: 0x00A5B580
		// (set) Token: 0x0602A94F RID: 174415 RVA: 0x00A5D390 File Offset: 0x00A5B590
		public unsafe float 使用QTE次级镜头_与目标高度差_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QTE_Camera_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QTE_Camera_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17006EDF RID: 28383
		// (get) Token: 0x0602A950 RID: 174416 RVA: 0x00A5D3A1 File Offset: 0x00A5B5A1
		// (set) Token: 0x0602A951 RID: 174417 RVA: 0x00A5D3B1 File Offset: 0x00A5B5B1
		public unsafe float 使用QTE次级镜头_当前臂长_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QTE_Camera_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QTE_Camera_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17006EE0 RID: 28384
		// (get) Token: 0x0602A952 RID: 174418 RVA: 0x00A5D3C2 File Offset: 0x00A5B5C2
		// (set) Token: 0x0602A953 RID: 174419 RVA: 0x00A5D3D2 File Offset: 0x00A5B5D2
		public unsafe float QTE次级镜头臂长add
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QTE_Camera_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QTE_Camera_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17006EE1 RID: 28385
		// (get) Token: 0x0602A954 RID: 174420 RVA: 0x00A5D3E3 File Offset: 0x00A5B5E3
		// (set) Token: 0x0602A955 RID: 174421 RVA: 0x00A5D3F7 File Offset: 0x00A5B5F7
		public unsafe FGameplayTag Tag
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QTE_Camera_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QTE_Camera_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x17006EE2 RID: 28386
		// (get) Token: 0x0602A956 RID: 174422 RVA: 0x00A5D40C File Offset: 0x00A5B60C
		// (set) Token: 0x0602A957 RID: 174423 RVA: 0x00A5D420 File Offset: 0x00A5B620
		[Nullable(0)]
		public unsafe TEnumAsByte<ECameraAnsEffectiveClientType> 生效客户端类型
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QTE_Camera_C.__PropertyOffset_17);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)BP_QTE_Camera_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x17006EE3 RID: 28387
		// (get) Token: 0x0602A958 RID: 174424 RVA: 0x00A5D435 File Offset: 0x00A5B635
		// (set) Token: 0x0602A959 RID: 174425 RVA: 0x00A5D449 File Offset: 0x00A5B649
		public unsafe string CameraAttachSocket
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)BP_QTE_Camera_C.__PropertyOffset_18)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)BP_QTE_Camera_C.__PropertyOffset_18)), value);
			}
		}

		// Token: 0x17006EE4 RID: 28388
		// (get) Token: 0x0602A95A RID: 174426 RVA: 0x00A5D460 File Offset: 0x00A5B660
		// (set) Token: 0x0602A95B RID: 174427 RVA: 0x00A5D499 File Offset: 0x00A5B699
		public TArray<SCameraModifier_Condition> 条件
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SCameraModifier_Condition> result;
				if ((result = this._条件) == null)
				{
					result = (this._条件 = new TArray<SCameraModifier_Condition>(base.NativePtr + (IntPtr)BP_QTE_Camera_C.__PropertyOffset_19, this));
				}
				return result;
			}
			set
			{
				this.条件.CopyAssign(value);
			}
		}

		// Token: 0x0602A95C RID: 174428 RVA: 0x00A5D4A7 File Offset: 0x00A5B6A7
		protected BP_QTE_Camera_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017273 RID: 94835
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/Structure/BP_QTE_Camera.BP_QTE_Camera_C";

		// Token: 0x04017274 RID: 94836
		private static IntPtr _ClassPtr;

		// Token: 0x04017275 RID: 94837
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04017276 RID: 94838
		internal static int __PropertyOffset_0;

		// Token: 0x04017277 RID: 94839
		[Nullable(2)]
		private SCameraModifier_Settings _相机配置;

		// Token: 0x04017278 RID: 94840
		internal static int __PropertyOffset_1;

		// Token: 0x04017279 RID: 94841
		internal static int __PropertyOffset_2;

		// Token: 0x0401727A RID: 94842
		internal static int __PropertyOffset_3;

		// Token: 0x0401727B RID: 94843
		internal static int __PropertyOffset_4;

		// Token: 0x0401727C RID: 94844
		internal static int __PropertyOffset_5;

		// Token: 0x0401727D RID: 94845
		[Nullable(2)]
		private SBaseCurve _BlendInCurve;

		// Token: 0x0401727E RID: 94846
		internal static int __PropertyOffset_6;

		// Token: 0x0401727F RID: 94847
		[Nullable(2)]
		private SBaseCurve _BlendOutCurve;

		// Token: 0x04017280 RID: 94848
		internal static int __PropertyOffset_7;

		// Token: 0x04017281 RID: 94849
		internal static int __PropertyOffset_8;

		// Token: 0x04017282 RID: 94850
		internal static int __PropertyOffset_9;

		// Token: 0x04017283 RID: 94851
		internal static int __PropertyOffset_10;

		// Token: 0x04017284 RID: 94852
		internal static int __PropertyOffset_11;

		// Token: 0x04017285 RID: 94853
		internal static int __PropertyOffset_12;

		// Token: 0x04017286 RID: 94854
		internal static int __PropertyOffset_13;

		// Token: 0x04017287 RID: 94855
		internal static int __PropertyOffset_14;

		// Token: 0x04017288 RID: 94856
		internal static int __PropertyOffset_15;

		// Token: 0x04017289 RID: 94857
		internal static int __PropertyOffset_16;

		// Token: 0x0401728A RID: 94858
		internal static int __PropertyOffset_17;

		// Token: 0x0401728B RID: 94859
		internal static int __PropertyOffset_18;

		// Token: 0x0401728C RID: 94860
		internal static int __PropertyOffset_19;

		// Token: 0x0401728D RID: 94861
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SCameraModifier_Condition> _条件;
	}
}
