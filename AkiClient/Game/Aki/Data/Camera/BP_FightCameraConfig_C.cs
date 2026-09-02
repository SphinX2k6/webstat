using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter.Camera;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.Camera
{
	// Token: 0x02003F13 RID: 16147
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/Camera/BP_FightCameraConfig.BP_FightCameraConfig_C")]
	[UnrealStructLayout(2784, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2784)]
	public class BP_FightCameraConfig_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602845D RID: 164957 RVA: 0x00A065F5 File Offset: 0x00A047F5
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_FightCameraConfig_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Data/Camera/BP_FightCameraConfig.BP_FightCameraConfig_C");
			}
			return BP_FightCameraConfig_C._ClassPtr;
		}

		// Token: 0x0602845E RID: 164958 RVA: 0x00A0661C File Offset: 0x00A0481C
		public BP_FightCameraConfig_C() : this(BuiltinUtils.AllocNativeUObject(BP_FightCameraConfig_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602845F RID: 164959 RVA: 0x00A06644 File Offset: 0x00A04844
		public BP_FightCameraConfig_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_FightCameraConfig_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700618B RID: 24971
		// (get) Token: 0x06028460 RID: 164960 RVA: 0x00A06678 File Offset: 0x00A04878
		// (set) Token: 0x06028461 RID: 164961 RVA: 0x00A066B1 File Offset: 0x00A048B1
		[Nullable(new byte[]
		{
			1,
			0
		})]
		public TMap<TEnumAsByte<EFightCameraDefault>, float> 基础
		{
			[return: Nullable(new byte[]
			{
				1,
				0
			})]
			get
			{
				base.FastCheckIsValid();
				TMap<TEnumAsByte<EFightCameraDefault>, float> result;
				if ((result = this._基础) == null)
				{
					result = (this._基础 = new TMap<TEnumAsByte<EFightCameraDefault>, float>(base.NativePtr + (IntPtr)BP_FightCameraConfig_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[param: Nullable(new byte[]
			{
				1,
				0
			})]
			set
			{
				this.基础.CopyAssign(value);
			}
		}

		// Token: 0x1700618C RID: 24972
		// (get) Token: 0x06028462 RID: 164962 RVA: 0x00A066C0 File Offset: 0x00A048C0
		// (set) Token: 0x06028463 RID: 164963 RVA: 0x00A066F9 File Offset: 0x00A048F9
		[Nullable(new byte[]
		{
			1,
			0,
			1
		})]
		public TMap<TEnumAsByte<EFightCameraDefault>, SBaseCurve> 基础曲线配置
		{
			[return: Nullable(new byte[]
			{
				1,
				0,
				1
			})]
			get
			{
				base.FastCheckIsValid();
				TMap<TEnumAsByte<EFightCameraDefault>, SBaseCurve> result;
				if ((result = this._基础曲线配置) == null)
				{
					result = (this._基础曲线配置 = new TMap<TEnumAsByte<EFightCameraDefault>, SBaseCurve>(base.NativePtr + (IntPtr)BP_FightCameraConfig_C.__PropertyOffset_1, this));
				}
				return result;
			}
			[param: Nullable(new byte[]
			{
				1,
				0,
				1
			})]
			set
			{
				this.基础曲线配置.CopyAssign(value);
			}
		}

		// Token: 0x1700618D RID: 24973
		// (get) Token: 0x06028464 RID: 164964 RVA: 0x00A06708 File Offset: 0x00A04908
		// (set) Token: 0x06028465 RID: 164965 RVA: 0x00A06741 File Offset: 0x00A04941
		[Nullable(new byte[]
		{
			1,
			0
		})]
		public TMap<TEnumAsByte<EFightCameraAdjust>, float> 技能修正
		{
			[return: Nullable(new byte[]
			{
				1,
				0
			})]
			get
			{
				base.FastCheckIsValid();
				TMap<TEnumAsByte<EFightCameraAdjust>, float> result;
				if ((result = this._技能修正) == null)
				{
					result = (this._技能修正 = new TMap<TEnumAsByte<EFightCameraAdjust>, float>(base.NativePtr + (IntPtr)BP_FightCameraConfig_C.__PropertyOffset_2, this));
				}
				return result;
			}
			[param: Nullable(new byte[]
			{
				1,
				0
			})]
			set
			{
				this.技能修正.CopyAssign(value);
			}
		}

		// Token: 0x1700618E RID: 24974
		// (get) Token: 0x06028466 RID: 164966 RVA: 0x00A06750 File Offset: 0x00A04950
		// (set) Token: 0x06028467 RID: 164967 RVA: 0x00A06789 File Offset: 0x00A04989
		[Nullable(new byte[]
		{
			1,
			0,
			1
		})]
		public TMap<TEnumAsByte<EFightCameraAdjust>, SBaseCurve> 技能修正曲线配置
		{
			[return: Nullable(new byte[]
			{
				1,
				0,
				1
			})]
			get
			{
				base.FastCheckIsValid();
				TMap<TEnumAsByte<EFightCameraAdjust>, SBaseCurve> result;
				if ((result = this._技能修正曲线配置) == null)
				{
					result = (this._技能修正曲线配置 = new TMap<TEnumAsByte<EFightCameraAdjust>, SBaseCurve>(base.NativePtr + (IntPtr)BP_FightCameraConfig_C.__PropertyOffset_3, this));
				}
				return result;
			}
			[param: Nullable(new byte[]
			{
				1,
				0,
				1
			})]
			set
			{
				this.技能修正曲线配置.CopyAssign(value);
			}
		}

		// Token: 0x1700618F RID: 24975
		// (get) Token: 0x06028468 RID: 164968 RVA: 0x00A06798 File Offset: 0x00A04998
		// (set) Token: 0x06028469 RID: 164969 RVA: 0x00A067D1 File Offset: 0x00A049D1
		[Nullable(new byte[]
		{
			1,
			0
		})]
		public TMap<TEnumAsByte<EFightCameraAuto>, float> 自动镜头
		{
			[return: Nullable(new byte[]
			{
				1,
				0
			})]
			get
			{
				base.FastCheckIsValid();
				TMap<TEnumAsByte<EFightCameraAuto>, float> result;
				if ((result = this._自动镜头) == null)
				{
					result = (this._自动镜头 = new TMap<TEnumAsByte<EFightCameraAuto>, float>(base.NativePtr + (IntPtr)BP_FightCameraConfig_C.__PropertyOffset_4, this));
				}
				return result;
			}
			[param: Nullable(new byte[]
			{
				1,
				0
			})]
			set
			{
				this.自动镜头.CopyAssign(value);
			}
		}

		// Token: 0x17006190 RID: 24976
		// (get) Token: 0x0602846A RID: 164970 RVA: 0x00A067E0 File Offset: 0x00A049E0
		// (set) Token: 0x0602846B RID: 164971 RVA: 0x00A06819 File Offset: 0x00A04A19
		[Nullable(new byte[]
		{
			1,
			0,
			1
		})]
		public TMap<TEnumAsByte<EFightCameraAuto>, SBaseCurve> 自动镜头曲线配置
		{
			[return: Nullable(new byte[]
			{
				1,
				0,
				1
			})]
			get
			{
				base.FastCheckIsValid();
				TMap<TEnumAsByte<EFightCameraAuto>, SBaseCurve> result;
				if ((result = this._自动镜头曲线配置) == null)
				{
					result = (this._自动镜头曲线配置 = new TMap<TEnumAsByte<EFightCameraAuto>, SBaseCurve>(base.NativePtr + (IntPtr)BP_FightCameraConfig_C.__PropertyOffset_5, this));
				}
				return result;
			}
			[param: Nullable(new byte[]
			{
				1,
				0,
				1
			})]
			set
			{
				this.自动镜头曲线配置.CopyAssign(value);
			}
		}

		// Token: 0x17006191 RID: 24977
		// (get) Token: 0x0602846C RID: 164972 RVA: 0x00A06828 File Offset: 0x00A04A28
		// (set) Token: 0x0602846D RID: 164973 RVA: 0x00A06861 File Offset: 0x00A04A61
		[Nullable(new byte[]
		{
			1,
			0
		})]
		public TMap<TEnumAsByte<EFightCameraFocus>, float> 锁定镜头
		{
			[return: Nullable(new byte[]
			{
				1,
				0
			})]
			get
			{
				base.FastCheckIsValid();
				TMap<TEnumAsByte<EFightCameraFocus>, float> result;
				if ((result = this._锁定镜头) == null)
				{
					result = (this._锁定镜头 = new TMap<TEnumAsByte<EFightCameraFocus>, float>(base.NativePtr + (IntPtr)BP_FightCameraConfig_C.__PropertyOffset_6, this));
				}
				return result;
			}
			[param: Nullable(new byte[]
			{
				1,
				0
			})]
			set
			{
				this.锁定镜头.CopyAssign(value);
			}
		}

		// Token: 0x17006192 RID: 24978
		// (get) Token: 0x0602846E RID: 164974 RVA: 0x00A06870 File Offset: 0x00A04A70
		// (set) Token: 0x0602846F RID: 164975 RVA: 0x00A068A9 File Offset: 0x00A04AA9
		[Nullable(new byte[]
		{
			1,
			0,
			1
		})]
		public TMap<TEnumAsByte<EFightCameraFocus>, SBaseCurve> 锁定镜头曲线配置
		{
			[return: Nullable(new byte[]
			{
				1,
				0,
				1
			})]
			get
			{
				base.FastCheckIsValid();
				TMap<TEnumAsByte<EFightCameraFocus>, SBaseCurve> result;
				if ((result = this._锁定镜头曲线配置) == null)
				{
					result = (this._锁定镜头曲线配置 = new TMap<TEnumAsByte<EFightCameraFocus>, SBaseCurve>(base.NativePtr + (IntPtr)BP_FightCameraConfig_C.__PropertyOffset_7, this));
				}
				return result;
			}
			[param: Nullable(new byte[]
			{
				1,
				0,
				1
			})]
			set
			{
				this.锁定镜头曲线配置.CopyAssign(value);
			}
		}

		// Token: 0x17006193 RID: 24979
		// (get) Token: 0x06028470 RID: 164976 RVA: 0x00A068B8 File Offset: 0x00A04AB8
		// (set) Token: 0x06028471 RID: 164977 RVA: 0x00A068F1 File Offset: 0x00A04AF1
		[Nullable(new byte[]
		{
			1,
			0
		})]
		public TMap<TEnumAsByte<EFightCameraInput>, float> 镜头输入
		{
			[return: Nullable(new byte[]
			{
				1,
				0
			})]
			get
			{
				base.FastCheckIsValid();
				TMap<TEnumAsByte<EFightCameraInput>, float> result;
				if ((result = this._镜头输入) == null)
				{
					result = (this._镜头输入 = new TMap<TEnumAsByte<EFightCameraInput>, float>(base.NativePtr + (IntPtr)BP_FightCameraConfig_C.__PropertyOffset_8, this));
				}
				return result;
			}
			[param: Nullable(new byte[]
			{
				1,
				0
			})]
			set
			{
				this.镜头输入.CopyAssign(value);
			}
		}

		// Token: 0x17006194 RID: 24980
		// (get) Token: 0x06028472 RID: 164978 RVA: 0x00A06900 File Offset: 0x00A04B00
		// (set) Token: 0x06028473 RID: 164979 RVA: 0x00A06939 File Offset: 0x00A04B39
		[Nullable(new byte[]
		{
			1,
			0,
			1
		})]
		public TMap<TEnumAsByte<EFightCameraInput>, SBaseCurve> 镜头输入曲线配置
		{
			[return: Nullable(new byte[]
			{
				1,
				0,
				1
			})]
			get
			{
				base.FastCheckIsValid();
				TMap<TEnumAsByte<EFightCameraInput>, SBaseCurve> result;
				if ((result = this._镜头输入曲线配置) == null)
				{
					result = (this._镜头输入曲线配置 = new TMap<TEnumAsByte<EFightCameraInput>, SBaseCurve>(base.NativePtr + (IntPtr)BP_FightCameraConfig_C.__PropertyOffset_9, this));
				}
				return result;
			}
			[param: Nullable(new byte[]
			{
				1,
				0,
				1
			})]
			set
			{
				this.镜头输入曲线配置.CopyAssign(value);
			}
		}

		// Token: 0x17006195 RID: 24981
		// (get) Token: 0x06028474 RID: 164980 RVA: 0x00A06948 File Offset: 0x00A04B48
		// (set) Token: 0x06028475 RID: 164981 RVA: 0x00A06981 File Offset: 0x00A04B81
		[Nullable(new byte[]
		{
			1,
			0
		})]
		public TMap<TEnumAsByte<EFightCameraModify>, float> Modify镜头
		{
			[return: Nullable(new byte[]
			{
				1,
				0
			})]
			get
			{
				base.FastCheckIsValid();
				TMap<TEnumAsByte<EFightCameraModify>, float> result;
				if ((result = this._Modify镜头) == null)
				{
					result = (this._Modify镜头 = new TMap<TEnumAsByte<EFightCameraModify>, float>(base.NativePtr + (IntPtr)BP_FightCameraConfig_C.__PropertyOffset_10, this));
				}
				return result;
			}
			[param: Nullable(new byte[]
			{
				1,
				0
			})]
			set
			{
				this.Modify镜头.CopyAssign(value);
			}
		}

		// Token: 0x17006196 RID: 24982
		// (get) Token: 0x06028476 RID: 164982 RVA: 0x00A06990 File Offset: 0x00A04B90
		// (set) Token: 0x06028477 RID: 164983 RVA: 0x00A069C9 File Offset: 0x00A04BC9
		[Nullable(new byte[]
		{
			1,
			0,
			1
		})]
		public TMap<TEnumAsByte<EFightCameraModify>, SBaseCurve> Modify镜头曲线配置
		{
			[return: Nullable(new byte[]
			{
				1,
				0,
				1
			})]
			get
			{
				base.FastCheckIsValid();
				TMap<TEnumAsByte<EFightCameraModify>, SBaseCurve> result;
				if ((result = this._Modify镜头曲线配置) == null)
				{
					result = (this._Modify镜头曲线配置 = new TMap<TEnumAsByte<EFightCameraModify>, SBaseCurve>(base.NativePtr + (IntPtr)BP_FightCameraConfig_C.__PropertyOffset_11, this));
				}
				return result;
			}
			[param: Nullable(new byte[]
			{
				1,
				0,
				1
			})]
			set
			{
				this.Modify镜头曲线配置.CopyAssign(value);
			}
		}

		// Token: 0x17006197 RID: 24983
		// (get) Token: 0x06028478 RID: 164984 RVA: 0x00A069D8 File Offset: 0x00A04BD8
		// (set) Token: 0x06028479 RID: 164985 RVA: 0x00A06A11 File Offset: 0x00A04C11
		[Nullable(new byte[]
		{
			1,
			0
		})]
		public TMap<TEnumAsByte<EFightCameraGuide>, float> 引导镜头
		{
			[return: Nullable(new byte[]
			{
				1,
				0
			})]
			get
			{
				base.FastCheckIsValid();
				TMap<TEnumAsByte<EFightCameraGuide>, float> result;
				if ((result = this._引导镜头) == null)
				{
					result = (this._引导镜头 = new TMap<TEnumAsByte<EFightCameraGuide>, float>(base.NativePtr + (IntPtr)BP_FightCameraConfig_C.__PropertyOffset_12, this));
				}
				return result;
			}
			[param: Nullable(new byte[]
			{
				1,
				0
			})]
			set
			{
				this.引导镜头.CopyAssign(value);
			}
		}

		// Token: 0x17006198 RID: 24984
		// (get) Token: 0x0602847A RID: 164986 RVA: 0x00A06A20 File Offset: 0x00A04C20
		// (set) Token: 0x0602847B RID: 164987 RVA: 0x00A06A59 File Offset: 0x00A04C59
		[Nullable(new byte[]
		{
			1,
			0,
			1
		})]
		public TMap<TEnumAsByte<EFightCameraGuide>, SBaseCurve> 引导镜头曲线配置
		{
			[return: Nullable(new byte[]
			{
				1,
				0,
				1
			})]
			get
			{
				base.FastCheckIsValid();
				TMap<TEnumAsByte<EFightCameraGuide>, SBaseCurve> result;
				if ((result = this._引导镜头曲线配置) == null)
				{
					result = (this._引导镜头曲线配置 = new TMap<TEnumAsByte<EFightCameraGuide>, SBaseCurve>(base.NativePtr + (IntPtr)BP_FightCameraConfig_C.__PropertyOffset_13, this));
				}
				return result;
			}
			[param: Nullable(new byte[]
			{
				1,
				0,
				1
			})]
			set
			{
				this.引导镜头曲线配置.CopyAssign(value);
			}
		}

		// Token: 0x17006199 RID: 24985
		// (get) Token: 0x0602847C RID: 164988 RVA: 0x00A06A68 File Offset: 0x00A04C68
		// (set) Token: 0x0602847D RID: 164989 RVA: 0x00A06AA1 File Offset: 0x00A04CA1
		[Nullable(new byte[]
		{
			1,
			0
		})]
		public TMap<TEnumAsByte<EFightCameraExplore>, float> 跑图镜头
		{
			[return: Nullable(new byte[]
			{
				1,
				0
			})]
			get
			{
				base.FastCheckIsValid();
				TMap<TEnumAsByte<EFightCameraExplore>, float> result;
				if ((result = this._跑图镜头) == null)
				{
					result = (this._跑图镜头 = new TMap<TEnumAsByte<EFightCameraExplore>, float>(base.NativePtr + (IntPtr)BP_FightCameraConfig_C.__PropertyOffset_14, this));
				}
				return result;
			}
			[param: Nullable(new byte[]
			{
				1,
				0
			})]
			set
			{
				this.跑图镜头.CopyAssign(value);
			}
		}

		// Token: 0x1700619A RID: 24986
		// (get) Token: 0x0602847E RID: 164990 RVA: 0x00A06AB0 File Offset: 0x00A04CB0
		// (set) Token: 0x0602847F RID: 164991 RVA: 0x00A06AE9 File Offset: 0x00A04CE9
		[Nullable(new byte[]
		{
			1,
			0,
			1
		})]
		public TMap<TEnumAsByte<EFightCameraExplore>, SBaseCurve> 跑图镜头曲线配置
		{
			[return: Nullable(new byte[]
			{
				1,
				0,
				1
			})]
			get
			{
				base.FastCheckIsValid();
				TMap<TEnumAsByte<EFightCameraExplore>, SBaseCurve> result;
				if ((result = this._跑图镜头曲线配置) == null)
				{
					result = (this._跑图镜头曲线配置 = new TMap<TEnumAsByte<EFightCameraExplore>, SBaseCurve>(base.NativePtr + (IntPtr)BP_FightCameraConfig_C.__PropertyOffset_15, this));
				}
				return result;
			}
			[param: Nullable(new byte[]
			{
				1,
				0,
				1
			})]
			set
			{
				this.跑图镜头曲线配置.CopyAssign(value);
			}
		}

		// Token: 0x1700619B RID: 24987
		// (get) Token: 0x06028480 RID: 164992 RVA: 0x00A06AF8 File Offset: 0x00A04CF8
		// (set) Token: 0x06028481 RID: 164993 RVA: 0x00A06B31 File Offset: 0x00A04D31
		[Nullable(new byte[]
		{
			1,
			0
		})]
		public TMap<TEnumAsByte<EFightCameraDialogue>, float> 对话镜头
		{
			[return: Nullable(new byte[]
			{
				1,
				0
			})]
			get
			{
				base.FastCheckIsValid();
				TMap<TEnumAsByte<EFightCameraDialogue>, float> result;
				if ((result = this._对话镜头) == null)
				{
					result = (this._对话镜头 = new TMap<TEnumAsByte<EFightCameraDialogue>, float>(base.NativePtr + (IntPtr)BP_FightCameraConfig_C.__PropertyOffset_16, this));
				}
				return result;
			}
			[param: Nullable(new byte[]
			{
				1,
				0
			})]
			set
			{
				this.对话镜头.CopyAssign(value);
			}
		}

		// Token: 0x1700619C RID: 24988
		// (get) Token: 0x06028482 RID: 164994 RVA: 0x00A06B40 File Offset: 0x00A04D40
		// (set) Token: 0x06028483 RID: 164995 RVA: 0x00A06B79 File Offset: 0x00A04D79
		[Nullable(new byte[]
		{
			1,
			0,
			1
		})]
		public TMap<TEnumAsByte<EFightCameraDialogue>, SBaseCurve> 对话镜头曲线配置
		{
			[return: Nullable(new byte[]
			{
				1,
				0,
				1
			})]
			get
			{
				base.FastCheckIsValid();
				TMap<TEnumAsByte<EFightCameraDialogue>, SBaseCurve> result;
				if ((result = this._对话镜头曲线配置) == null)
				{
					result = (this._对话镜头曲线配置 = new TMap<TEnumAsByte<EFightCameraDialogue>, SBaseCurve>(base.NativePtr + (IntPtr)BP_FightCameraConfig_C.__PropertyOffset_17, this));
				}
				return result;
			}
			[param: Nullable(new byte[]
			{
				1,
				0,
				1
			})]
			set
			{
				this.对话镜头曲线配置.CopyAssign(value);
			}
		}

		// Token: 0x1700619D RID: 24989
		// (get) Token: 0x06028484 RID: 164996 RVA: 0x00A06B88 File Offset: 0x00A04D88
		// (set) Token: 0x06028485 RID: 164997 RVA: 0x00A06BC1 File Offset: 0x00A04DC1
		[Nullable(new byte[]
		{
			1,
			0
		})]
		public TMap<TEnumAsByte<EFightCameraClimb>, float> 攀爬镜头
		{
			[return: Nullable(new byte[]
			{
				1,
				0
			})]
			get
			{
				base.FastCheckIsValid();
				TMap<TEnumAsByte<EFightCameraClimb>, float> result;
				if ((result = this._攀爬镜头) == null)
				{
					result = (this._攀爬镜头 = new TMap<TEnumAsByte<EFightCameraClimb>, float>(base.NativePtr + (IntPtr)BP_FightCameraConfig_C.__PropertyOffset_18, this));
				}
				return result;
			}
			[param: Nullable(new byte[]
			{
				1,
				0
			})]
			set
			{
				this.攀爬镜头.CopyAssign(value);
			}
		}

		// Token: 0x1700619E RID: 24990
		// (get) Token: 0x06028486 RID: 164998 RVA: 0x00A06BD0 File Offset: 0x00A04DD0
		// (set) Token: 0x06028487 RID: 164999 RVA: 0x00A06C09 File Offset: 0x00A04E09
		[Nullable(new byte[]
		{
			1,
			0,
			1
		})]
		public TMap<TEnumAsByte<EFightCameraClimb>, SBaseCurve> 攀爬镜头曲线配置
		{
			[return: Nullable(new byte[]
			{
				1,
				0,
				1
			})]
			get
			{
				base.FastCheckIsValid();
				TMap<TEnumAsByte<EFightCameraClimb>, SBaseCurve> result;
				if ((result = this._攀爬镜头曲线配置) == null)
				{
					result = (this._攀爬镜头曲线配置 = new TMap<TEnumAsByte<EFightCameraClimb>, SBaseCurve>(base.NativePtr + (IntPtr)BP_FightCameraConfig_C.__PropertyOffset_19, this));
				}
				return result;
			}
			[param: Nullable(new byte[]
			{
				1,
				0,
				1
			})]
			set
			{
				this.攀爬镜头曲线配置.CopyAssign(value);
			}
		}

		// Token: 0x1700619F RID: 24991
		// (get) Token: 0x06028488 RID: 165000 RVA: 0x00A06C18 File Offset: 0x00A04E18
		// (set) Token: 0x06028489 RID: 165001 RVA: 0x00A06C51 File Offset: 0x00A04E51
		[Nullable(new byte[]
		{
			1,
			0
		})]
		public TMap<TEnumAsByte<EFightCameraSidestep>, float> 移动自动镜头
		{
			[return: Nullable(new byte[]
			{
				1,
				0
			})]
			get
			{
				base.FastCheckIsValid();
				TMap<TEnumAsByte<EFightCameraSidestep>, float> result;
				if ((result = this._移动自动镜头) == null)
				{
					result = (this._移动自动镜头 = new TMap<TEnumAsByte<EFightCameraSidestep>, float>(base.NativePtr + (IntPtr)BP_FightCameraConfig_C.__PropertyOffset_20, this));
				}
				return result;
			}
			[param: Nullable(new byte[]
			{
				1,
				0
			})]
			set
			{
				this.移动自动镜头.CopyAssign(value);
			}
		}

		// Token: 0x170061A0 RID: 24992
		// (get) Token: 0x0602848A RID: 165002 RVA: 0x00A06C60 File Offset: 0x00A04E60
		// (set) Token: 0x0602848B RID: 165003 RVA: 0x00A06C99 File Offset: 0x00A04E99
		[Nullable(new byte[]
		{
			1,
			0,
			1
		})]
		public TMap<TEnumAsByte<EFightCameraSidestep>, SBaseCurve> 移动自动镜头曲线配置
		{
			[return: Nullable(new byte[]
			{
				1,
				0,
				1
			})]
			get
			{
				base.FastCheckIsValid();
				TMap<TEnumAsByte<EFightCameraSidestep>, SBaseCurve> result;
				if ((result = this._移动自动镜头曲线配置) == null)
				{
					result = (this._移动自动镜头曲线配置 = new TMap<TEnumAsByte<EFightCameraSidestep>, SBaseCurve>(base.NativePtr + (IntPtr)BP_FightCameraConfig_C.__PropertyOffset_21, this));
				}
				return result;
			}
			[param: Nullable(new byte[]
			{
				1,
				0,
				1
			})]
			set
			{
				this.移动自动镜头曲线配置.CopyAssign(value);
			}
		}

		// Token: 0x170061A1 RID: 24993
		// (get) Token: 0x0602848C RID: 165004 RVA: 0x00A06CA8 File Offset: 0x00A04EA8
		// (set) Token: 0x0602848D RID: 165005 RVA: 0x00A06CE1 File Offset: 0x00A04EE1
		[Nullable(new byte[]
		{
			1,
			0
		})]
		public TMap<TEnumAsByte<EFightCameraHook>, float> 钩锁镜头
		{
			[return: Nullable(new byte[]
			{
				1,
				0
			})]
			get
			{
				base.FastCheckIsValid();
				TMap<TEnumAsByte<EFightCameraHook>, float> result;
				if ((result = this._钩锁镜头) == null)
				{
					result = (this._钩锁镜头 = new TMap<TEnumAsByte<EFightCameraHook>, float>(base.NativePtr + (IntPtr)BP_FightCameraConfig_C.__PropertyOffset_22, this));
				}
				return result;
			}
			[param: Nullable(new byte[]
			{
				1,
				0
			})]
			set
			{
				this.钩锁镜头.CopyAssign(value);
			}
		}

		// Token: 0x170061A2 RID: 24994
		// (get) Token: 0x0602848E RID: 165006 RVA: 0x00A06CF0 File Offset: 0x00A04EF0
		// (set) Token: 0x0602848F RID: 165007 RVA: 0x00A06D29 File Offset: 0x00A04F29
		[Nullable(new byte[]
		{
			1,
			0,
			1
		})]
		public TMap<TEnumAsByte<EFightCameraHook>, SBaseCurve> 钩锁镜头曲线配置
		{
			[return: Nullable(new byte[]
			{
				1,
				0,
				1
			})]
			get
			{
				base.FastCheckIsValid();
				TMap<TEnumAsByte<EFightCameraHook>, SBaseCurve> result;
				if ((result = this._钩锁镜头曲线配置) == null)
				{
					result = (this._钩锁镜头曲线配置 = new TMap<TEnumAsByte<EFightCameraHook>, SBaseCurve>(base.NativePtr + (IntPtr)BP_FightCameraConfig_C.__PropertyOffset_23, this));
				}
				return result;
			}
			[param: Nullable(new byte[]
			{
				1,
				0,
				1
			})]
			set
			{
				this.钩锁镜头曲线配置.CopyAssign(value);
			}
		}

		// Token: 0x170061A3 RID: 24995
		// (get) Token: 0x06028490 RID: 165008 RVA: 0x00A06D38 File Offset: 0x00A04F38
		// (set) Token: 0x06028491 RID: 165009 RVA: 0x00A06D71 File Offset: 0x00A04F71
		[Nullable(new byte[]
		{
			1,
			0
		})]
		public TMap<TEnumAsByte<EFightCameraVehicle>, float> 载具镜头
		{
			[return: Nullable(new byte[]
			{
				1,
				0
			})]
			get
			{
				base.FastCheckIsValid();
				TMap<TEnumAsByte<EFightCameraVehicle>, float> result;
				if ((result = this._载具镜头) == null)
				{
					result = (this._载具镜头 = new TMap<TEnumAsByte<EFightCameraVehicle>, float>(base.NativePtr + (IntPtr)BP_FightCameraConfig_C.__PropertyOffset_24, this));
				}
				return result;
			}
			[param: Nullable(new byte[]
			{
				1,
				0
			})]
			set
			{
				this.载具镜头.CopyAssign(value);
			}
		}

		// Token: 0x170061A4 RID: 24996
		// (get) Token: 0x06028492 RID: 165010 RVA: 0x00A06D80 File Offset: 0x00A04F80
		// (set) Token: 0x06028493 RID: 165011 RVA: 0x00A06DB9 File Offset: 0x00A04FB9
		[Nullable(new byte[]
		{
			1,
			0,
			1
		})]
		public TMap<TEnumAsByte<EFightCameraVehicle>, SBaseCurve> 载具镜头曲线配置
		{
			[return: Nullable(new byte[]
			{
				1,
				0,
				1
			})]
			get
			{
				base.FastCheckIsValid();
				TMap<TEnumAsByte<EFightCameraVehicle>, SBaseCurve> result;
				if ((result = this._载具镜头曲线配置) == null)
				{
					result = (this._载具镜头曲线配置 = new TMap<TEnumAsByte<EFightCameraVehicle>, SBaseCurve>(base.NativePtr + (IntPtr)BP_FightCameraConfig_C.__PropertyOffset_25, this));
				}
				return result;
			}
			[param: Nullable(new byte[]
			{
				1,
				0,
				1
			})]
			set
			{
				this.载具镜头曲线配置.CopyAssign(value);
			}
		}

		// Token: 0x170061A5 RID: 24997
		// (get) Token: 0x06028494 RID: 165012 RVA: 0x00A06DC8 File Offset: 0x00A04FC8
		// (set) Token: 0x06028495 RID: 165013 RVA: 0x00A06E01 File Offset: 0x00A05001
		public SSettlementCamera 结算镜头
		{
			get
			{
				base.FastCheckIsValid();
				SSettlementCamera result;
				if ((result = this._结算镜头) == null)
				{
					result = (this._结算镜头 = new SSettlementCamera(base.NativePtr + (IntPtr)BP_FightCameraConfig_C.__PropertyOffset_26, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SSettlementCamera.StaticStruct(), base.NativePtr + (IntPtr)BP_FightCameraConfig_C.__PropertyOffset_26, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170061A6 RID: 24998
		// (get) Token: 0x06028496 RID: 165014 RVA: 0x00A06E24 File Offset: 0x00A05024
		// (set) Token: 0x06028497 RID: 165015 RVA: 0x00A06E5D File Offset: 0x00A0505D
		[Nullable(new byte[]
		{
			1,
			0
		})]
		public TMap<TEnumAsByte<EFightCameraGravity>, float> 镜头重力
		{
			[return: Nullable(new byte[]
			{
				1,
				0
			})]
			get
			{
				base.FastCheckIsValid();
				TMap<TEnumAsByte<EFightCameraGravity>, float> result;
				if ((result = this._镜头重力) == null)
				{
					result = (this._镜头重力 = new TMap<TEnumAsByte<EFightCameraGravity>, float>(base.NativePtr + (IntPtr)BP_FightCameraConfig_C.__PropertyOffset_27, this));
				}
				return result;
			}
			[param: Nullable(new byte[]
			{
				1,
				0
			})]
			set
			{
				this.镜头重力.CopyAssign(value);
			}
		}

		// Token: 0x170061A7 RID: 24999
		// (get) Token: 0x06028498 RID: 165016 RVA: 0x00A06E6C File Offset: 0x00A0506C
		// (set) Token: 0x06028499 RID: 165017 RVA: 0x00A06EA5 File Offset: 0x00A050A5
		[Nullable(new byte[]
		{
			1,
			0,
			1
		})]
		public TMap<TEnumAsByte<EFightCameraGravity>, SBaseCurve> 镜头重力曲线配置
		{
			[return: Nullable(new byte[]
			{
				1,
				0,
				1
			})]
			get
			{
				base.FastCheckIsValid();
				TMap<TEnumAsByte<EFightCameraGravity>, SBaseCurve> result;
				if ((result = this._镜头重力曲线配置) == null)
				{
					result = (this._镜头重力曲线配置 = new TMap<TEnumAsByte<EFightCameraGravity>, SBaseCurve>(base.NativePtr + (IntPtr)BP_FightCameraConfig_C.__PropertyOffset_28, this));
				}
				return result;
			}
			[param: Nullable(new byte[]
			{
				1,
				0,
				1
			})]
			set
			{
				this.镜头重力曲线配置.CopyAssign(value);
			}
		}

		// Token: 0x0602849A RID: 165018 RVA: 0x00A06EB3 File Offset: 0x00A050B3
		protected BP_FightCameraConfig_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040152CF RID: 86735
		public new const string __ObjectPath = "/Game/Aki/Data/Camera/BP_FightCameraConfig.BP_FightCameraConfig_C";

		// Token: 0x040152D0 RID: 86736
		private static IntPtr _ClassPtr;

		// Token: 0x040152D1 RID: 86737
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040152D2 RID: 86738
		internal static int __PropertyOffset_0;

		// Token: 0x040152D3 RID: 86739
		[Nullable(new byte[]
		{
			2,
			0
		})]
		private TMap<TEnumAsByte<EFightCameraDefault>, float> _基础;

		// Token: 0x040152D4 RID: 86740
		internal static int __PropertyOffset_1;

		// Token: 0x040152D5 RID: 86741
		[Nullable(new byte[]
		{
			2,
			0,
			1
		})]
		private TMap<TEnumAsByte<EFightCameraDefault>, SBaseCurve> _基础曲线配置;

		// Token: 0x040152D6 RID: 86742
		internal static int __PropertyOffset_2;

		// Token: 0x040152D7 RID: 86743
		[Nullable(new byte[]
		{
			2,
			0
		})]
		private TMap<TEnumAsByte<EFightCameraAdjust>, float> _技能修正;

		// Token: 0x040152D8 RID: 86744
		internal static int __PropertyOffset_3;

		// Token: 0x040152D9 RID: 86745
		[Nullable(new byte[]
		{
			2,
			0,
			1
		})]
		private TMap<TEnumAsByte<EFightCameraAdjust>, SBaseCurve> _技能修正曲线配置;

		// Token: 0x040152DA RID: 86746
		internal static int __PropertyOffset_4;

		// Token: 0x040152DB RID: 86747
		[Nullable(new byte[]
		{
			2,
			0
		})]
		private TMap<TEnumAsByte<EFightCameraAuto>, float> _自动镜头;

		// Token: 0x040152DC RID: 86748
		internal static int __PropertyOffset_5;

		// Token: 0x040152DD RID: 86749
		[Nullable(new byte[]
		{
			2,
			0,
			1
		})]
		private TMap<TEnumAsByte<EFightCameraAuto>, SBaseCurve> _自动镜头曲线配置;

		// Token: 0x040152DE RID: 86750
		internal static int __PropertyOffset_6;

		// Token: 0x040152DF RID: 86751
		[Nullable(new byte[]
		{
			2,
			0
		})]
		private TMap<TEnumAsByte<EFightCameraFocus>, float> _锁定镜头;

		// Token: 0x040152E0 RID: 86752
		internal static int __PropertyOffset_7;

		// Token: 0x040152E1 RID: 86753
		[Nullable(new byte[]
		{
			2,
			0,
			1
		})]
		private TMap<TEnumAsByte<EFightCameraFocus>, SBaseCurve> _锁定镜头曲线配置;

		// Token: 0x040152E2 RID: 86754
		internal static int __PropertyOffset_8;

		// Token: 0x040152E3 RID: 86755
		[Nullable(new byte[]
		{
			2,
			0
		})]
		private TMap<TEnumAsByte<EFightCameraInput>, float> _镜头输入;

		// Token: 0x040152E4 RID: 86756
		internal static int __PropertyOffset_9;

		// Token: 0x040152E5 RID: 86757
		[Nullable(new byte[]
		{
			2,
			0,
			1
		})]
		private TMap<TEnumAsByte<EFightCameraInput>, SBaseCurve> _镜头输入曲线配置;

		// Token: 0x040152E6 RID: 86758
		internal static int __PropertyOffset_10;

		// Token: 0x040152E7 RID: 86759
		[Nullable(new byte[]
		{
			2,
			0
		})]
		private TMap<TEnumAsByte<EFightCameraModify>, float> _Modify镜头;

		// Token: 0x040152E8 RID: 86760
		internal static int __PropertyOffset_11;

		// Token: 0x040152E9 RID: 86761
		[Nullable(new byte[]
		{
			2,
			0,
			1
		})]
		private TMap<TEnumAsByte<EFightCameraModify>, SBaseCurve> _Modify镜头曲线配置;

		// Token: 0x040152EA RID: 86762
		internal static int __PropertyOffset_12;

		// Token: 0x040152EB RID: 86763
		[Nullable(new byte[]
		{
			2,
			0
		})]
		private TMap<TEnumAsByte<EFightCameraGuide>, float> _引导镜头;

		// Token: 0x040152EC RID: 86764
		internal static int __PropertyOffset_13;

		// Token: 0x040152ED RID: 86765
		[Nullable(new byte[]
		{
			2,
			0,
			1
		})]
		private TMap<TEnumAsByte<EFightCameraGuide>, SBaseCurve> _引导镜头曲线配置;

		// Token: 0x040152EE RID: 86766
		internal static int __PropertyOffset_14;

		// Token: 0x040152EF RID: 86767
		[Nullable(new byte[]
		{
			2,
			0
		})]
		private TMap<TEnumAsByte<EFightCameraExplore>, float> _跑图镜头;

		// Token: 0x040152F0 RID: 86768
		internal static int __PropertyOffset_15;

		// Token: 0x040152F1 RID: 86769
		[Nullable(new byte[]
		{
			2,
			0,
			1
		})]
		private TMap<TEnumAsByte<EFightCameraExplore>, SBaseCurve> _跑图镜头曲线配置;

		// Token: 0x040152F2 RID: 86770
		internal static int __PropertyOffset_16;

		// Token: 0x040152F3 RID: 86771
		[Nullable(new byte[]
		{
			2,
			0
		})]
		private TMap<TEnumAsByte<EFightCameraDialogue>, float> _对话镜头;

		// Token: 0x040152F4 RID: 86772
		internal static int __PropertyOffset_17;

		// Token: 0x040152F5 RID: 86773
		[Nullable(new byte[]
		{
			2,
			0,
			1
		})]
		private TMap<TEnumAsByte<EFightCameraDialogue>, SBaseCurve> _对话镜头曲线配置;

		// Token: 0x040152F6 RID: 86774
		internal static int __PropertyOffset_18;

		// Token: 0x040152F7 RID: 86775
		[Nullable(new byte[]
		{
			2,
			0
		})]
		private TMap<TEnumAsByte<EFightCameraClimb>, float> _攀爬镜头;

		// Token: 0x040152F8 RID: 86776
		internal static int __PropertyOffset_19;

		// Token: 0x040152F9 RID: 86777
		[Nullable(new byte[]
		{
			2,
			0,
			1
		})]
		private TMap<TEnumAsByte<EFightCameraClimb>, SBaseCurve> _攀爬镜头曲线配置;

		// Token: 0x040152FA RID: 86778
		internal static int __PropertyOffset_20;

		// Token: 0x040152FB RID: 86779
		[Nullable(new byte[]
		{
			2,
			0
		})]
		private TMap<TEnumAsByte<EFightCameraSidestep>, float> _移动自动镜头;

		// Token: 0x040152FC RID: 86780
		internal static int __PropertyOffset_21;

		// Token: 0x040152FD RID: 86781
		[Nullable(new byte[]
		{
			2,
			0,
			1
		})]
		private TMap<TEnumAsByte<EFightCameraSidestep>, SBaseCurve> _移动自动镜头曲线配置;

		// Token: 0x040152FE RID: 86782
		internal static int __PropertyOffset_22;

		// Token: 0x040152FF RID: 86783
		[Nullable(new byte[]
		{
			2,
			0
		})]
		private TMap<TEnumAsByte<EFightCameraHook>, float> _钩锁镜头;

		// Token: 0x04015300 RID: 86784
		internal static int __PropertyOffset_23;

		// Token: 0x04015301 RID: 86785
		[Nullable(new byte[]
		{
			2,
			0,
			1
		})]
		private TMap<TEnumAsByte<EFightCameraHook>, SBaseCurve> _钩锁镜头曲线配置;

		// Token: 0x04015302 RID: 86786
		internal static int __PropertyOffset_24;

		// Token: 0x04015303 RID: 86787
		[Nullable(new byte[]
		{
			2,
			0
		})]
		private TMap<TEnumAsByte<EFightCameraVehicle>, float> _载具镜头;

		// Token: 0x04015304 RID: 86788
		internal static int __PropertyOffset_25;

		// Token: 0x04015305 RID: 86789
		[Nullable(new byte[]
		{
			2,
			0,
			1
		})]
		private TMap<TEnumAsByte<EFightCameraVehicle>, SBaseCurve> _载具镜头曲线配置;

		// Token: 0x04015306 RID: 86790
		internal static int __PropertyOffset_26;

		// Token: 0x04015307 RID: 86791
		[Nullable(2)]
		private SSettlementCamera _结算镜头;

		// Token: 0x04015308 RID: 86792
		internal static int __PropertyOffset_27;

		// Token: 0x04015309 RID: 86793
		[Nullable(new byte[]
		{
			2,
			0
		})]
		private TMap<TEnumAsByte<EFightCameraGravity>, float> _镜头重力;

		// Token: 0x0401530A RID: 86794
		internal static int __PropertyOffset_28;

		// Token: 0x0401530B RID: 86795
		[Nullable(new byte[]
		{
			2,
			0,
			1
		})]
		private TMap<TEnumAsByte<EFightCameraGravity>, SBaseCurve> _镜头重力曲线配置;
	}
}
