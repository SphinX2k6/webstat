using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Camera
{
	// Token: 0x0200430E RID: 17166
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Camera/SCameraConfig.SCameraConfig")]
	[UnrealStructLayout(2128, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 2128)]
	public class SCameraConfig : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602D71C RID: 186140 RVA: 0x00AC0570 File Offset: 0x00ABE770
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SCameraConfig._ScriptStructPtr != 0) ? SCameraConfig._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/Camera/SCameraConfig.SCameraConfig", ref SCameraConfig._ScriptStructPtr);
		}

		// Token: 0x17007C0B RID: 31755
		// (get) Token: 0x0602D71D RID: 186141 RVA: 0x00AC0594 File Offset: 0x00ABE794
		// (set) Token: 0x0602D71E RID: 186142 RVA: 0x00AC05A8 File Offset: 0x00ABE7A8
		[Nullable(0)]
		public unsafe TEnumAsByte<EFightCameraType> Type
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraConfig.__PropertyOffset_0);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)SCameraConfig.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17007C0C RID: 31756
		// (get) Token: 0x0602D71F RID: 186143 RVA: 0x00AC05BD File Offset: 0x00ABE7BD
		// (set) Token: 0x0602D720 RID: 186144 RVA: 0x00AC05CD File Offset: 0x00ABE7CD
		public unsafe bool 是否重置默认配置
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraConfig.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraConfig.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007C0D RID: 31757
		// (get) Token: 0x0602D721 RID: 186145 RVA: 0x00AC05DE File Offset: 0x00ABE7DE
		// (set) Token: 0x0602D722 RID: 186146 RVA: 0x00AC05EE File Offset: 0x00ABE7EE
		public unsafe bool 是否重置镜头锁定
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraConfig.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraConfig.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007C0E RID: 31758
		// (get) Token: 0x0602D723 RID: 186147 RVA: 0x00AC05FF File Offset: 0x00ABE7FF
		// (set) Token: 0x0602D724 RID: 186148 RVA: 0x00AC0613 File Offset: 0x00ABE813
		public unsafe FGameplayTag Tag
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraConfig.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraConfig.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17007C0F RID: 31759
		// (get) Token: 0x0602D725 RID: 186149 RVA: 0x00AC0628 File Offset: 0x00ABE828
		// (set) Token: 0x0602D726 RID: 186150 RVA: 0x00AC0638 File Offset: 0x00ABE838
		public unsafe bool PC生效
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraConfig.__PropertyOffset_4) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraConfig.__PropertyOffset_4) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007C10 RID: 31760
		// (get) Token: 0x0602D727 RID: 186151 RVA: 0x00AC0649 File Offset: 0x00ABE849
		// (set) Token: 0x0602D728 RID: 186152 RVA: 0x00AC0659 File Offset: 0x00ABE859
		public unsafe bool 手机生效
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraConfig.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraConfig.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007C11 RID: 31761
		// (get) Token: 0x0602D729 RID: 186153 RVA: 0x00AC066A File Offset: 0x00ABE86A
		// (set) Token: 0x0602D72A RID: 186154 RVA: 0x00AC067A File Offset: 0x00ABE87A
		public unsafe int 优先级
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraConfig.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraConfig.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17007C12 RID: 31762
		// (get) Token: 0x0602D72B RID: 186155 RVA: 0x00AC068B File Offset: 0x00ABE88B
		// (set) Token: 0x0602D72C RID: 186156 RVA: 0x00AC069B File Offset: 0x00ABE89B
		public unsafe float 淡入时间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraConfig.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraConfig.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17007C13 RID: 31763
		// (get) Token: 0x0602D72D RID: 186157 RVA: 0x00AC06AC File Offset: 0x00ABE8AC
		// (set) Token: 0x0602D72E RID: 186158 RVA: 0x00AC06EF File Offset: 0x00ABE8EF
		public SBaseCurve 淡入曲线
		{
			get
			{
				base.FastCheckIsValid();
				SBaseCurve result;
				if ((result = this._淡入曲线) == null)
				{
					result = (this._淡入曲线 = new SBaseCurve(base.NativePtr + (IntPtr)SCameraConfig.__PropertyOffset_8, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SBaseCurve.StaticStruct(), base.NativePtr + (IntPtr)SCameraConfig.__PropertyOffset_8, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007C14 RID: 31764
		// (get) Token: 0x0602D72F RID: 186159 RVA: 0x00AC0710 File Offset: 0x00ABE910
		// (set) Token: 0x0602D730 RID: 186160 RVA: 0x00AC0720 File Offset: 0x00ABE920
		public unsafe float 淡出时间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraConfig.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraConfig.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17007C15 RID: 31765
		// (get) Token: 0x0602D731 RID: 186161 RVA: 0x00AC0734 File Offset: 0x00ABE934
		// (set) Token: 0x0602D732 RID: 186162 RVA: 0x00AC0777 File Offset: 0x00ABE977
		public SBaseCurve 淡出曲线
		{
			get
			{
				base.FastCheckIsValid();
				SBaseCurve result;
				if ((result = this._淡出曲线) == null)
				{
					result = (this._淡出曲线 = new SBaseCurve(base.NativePtr + (IntPtr)SCameraConfig.__PropertyOffset_10, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SBaseCurve.StaticStruct(), base.NativePtr + (IntPtr)SCameraConfig.__PropertyOffset_10, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007C16 RID: 31766
		// (get) Token: 0x0602D733 RID: 186163 RVA: 0x00AC0798 File Offset: 0x00ABE998
		// (set) Token: 0x0602D734 RID: 186164 RVA: 0x00AC07A8 File Offset: 0x00ABE9A8
		public unsafe bool 启用自动镜头
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraConfig.__PropertyOffset_11) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraConfig.__PropertyOffset_11) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007C17 RID: 31767
		// (get) Token: 0x0602D735 RID: 186165 RVA: 0x00AC07B9 File Offset: 0x00ABE9B9
		// (set) Token: 0x0602D736 RID: 186166 RVA: 0x00AC07C9 File Offset: 0x00ABE9C9
		public unsafe bool 启用Modify镜头
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraConfig.__PropertyOffset_12) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraConfig.__PropertyOffset_12) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007C18 RID: 31768
		// (get) Token: 0x0602D737 RID: 186167 RVA: 0x00AC07DA File Offset: 0x00ABE9DA
		// (set) Token: 0x0602D738 RID: 186168 RVA: 0x00AC07EA File Offset: 0x00ABE9EA
		public unsafe bool 启用技能修正镜头
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraConfig.__PropertyOffset_13) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraConfig.__PropertyOffset_13) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007C19 RID: 31769
		// (get) Token: 0x0602D739 RID: 186169 RVA: 0x00AC07FB File Offset: 0x00ABE9FB
		// (set) Token: 0x0602D73A RID: 186170 RVA: 0x00AC080B File Offset: 0x00ABEA0B
		public unsafe bool 启用锁定镜头
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraConfig.__PropertyOffset_14) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraConfig.__PropertyOffset_14) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007C1A RID: 31770
		// (get) Token: 0x0602D73B RID: 186171 RVA: 0x00AC081C File Offset: 0x00ABEA1C
		// (set) Token: 0x0602D73C RID: 186172 RVA: 0x00AC082C File Offset: 0x00ABEA2C
		public unsafe bool 启用移动自动镜头
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraConfig.__PropertyOffset_15) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraConfig.__PropertyOffset_15) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007C1B RID: 31771
		// (get) Token: 0x0602D73D RID: 186173 RVA: 0x00AC083D File Offset: 0x00ABEA3D
		// (set) Token: 0x0602D73E RID: 186174 RVA: 0x00AC084D File Offset: 0x00ABEA4D
		public unsafe bool 启用攀爬镜头
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraConfig.__PropertyOffset_16) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraConfig.__PropertyOffset_16) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007C1C RID: 31772
		// (get) Token: 0x0602D73F RID: 186175 RVA: 0x00AC0860 File Offset: 0x00ABEA60
		// (set) Token: 0x0602D740 RID: 186176 RVA: 0x00AC08A3 File Offset: 0x00ABEAA3
		public TArray<string> 锁定点名称
		{
			get
			{
				base.FastCheckIsValid();
				TArray<string> result;
				if ((result = this._锁定点名称) == null)
				{
					result = (this._锁定点名称 = new TArray<string>(base.NativePtr + (IntPtr)SCameraConfig.__PropertyOffset_17, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.锁定点名称.CopyAssign(value);
			}
		}

		// Token: 0x17007C1D RID: 31773
		// (get) Token: 0x0602D741 RID: 186177 RVA: 0x00AC08B4 File Offset: 0x00ABEAB4
		// (set) Token: 0x0602D742 RID: 186178 RVA: 0x00AC08F7 File Offset: 0x00ABEAF7
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
					result = (this._基础 = new TMap<TEnumAsByte<EFightCameraDefault>, float>(base.NativePtr + (IntPtr)SCameraConfig.__PropertyOffset_18, base.MemoryOwner ?? this));
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

		// Token: 0x17007C1E RID: 31774
		// (get) Token: 0x0602D743 RID: 186179 RVA: 0x00AC0908 File Offset: 0x00ABEB08
		// (set) Token: 0x0602D744 RID: 186180 RVA: 0x00AC094B File Offset: 0x00ABEB4B
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
					result = (this._技能修正 = new TMap<TEnumAsByte<EFightCameraAdjust>, float>(base.NativePtr + (IntPtr)SCameraConfig.__PropertyOffset_19, base.MemoryOwner ?? this));
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

		// Token: 0x17007C1F RID: 31775
		// (get) Token: 0x0602D745 RID: 186181 RVA: 0x00AC095C File Offset: 0x00ABEB5C
		// (set) Token: 0x0602D746 RID: 186182 RVA: 0x00AC099F File Offset: 0x00ABEB9F
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
					result = (this._自动镜头 = new TMap<TEnumAsByte<EFightCameraAuto>, float>(base.NativePtr + (IntPtr)SCameraConfig.__PropertyOffset_20, base.MemoryOwner ?? this));
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

		// Token: 0x17007C20 RID: 31776
		// (get) Token: 0x0602D747 RID: 186183 RVA: 0x00AC09B0 File Offset: 0x00ABEBB0
		// (set) Token: 0x0602D748 RID: 186184 RVA: 0x00AC09F3 File Offset: 0x00ABEBF3
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
					result = (this._锁定镜头 = new TMap<TEnumAsByte<EFightCameraFocus>, float>(base.NativePtr + (IntPtr)SCameraConfig.__PropertyOffset_21, base.MemoryOwner ?? this));
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

		// Token: 0x17007C21 RID: 31777
		// (get) Token: 0x0602D749 RID: 186185 RVA: 0x00AC0A04 File Offset: 0x00ABEC04
		// (set) Token: 0x0602D74A RID: 186186 RVA: 0x00AC0A47 File Offset: 0x00ABEC47
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
					result = (this._镜头输入 = new TMap<TEnumAsByte<EFightCameraInput>, float>(base.NativePtr + (IntPtr)SCameraConfig.__PropertyOffset_22, base.MemoryOwner ?? this));
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

		// Token: 0x17007C22 RID: 31778
		// (get) Token: 0x0602D74B RID: 186187 RVA: 0x00AC0A58 File Offset: 0x00ABEC58
		// (set) Token: 0x0602D74C RID: 186188 RVA: 0x00AC0A9B File Offset: 0x00ABEC9B
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
					result = (this._Modify镜头 = new TMap<TEnumAsByte<EFightCameraModify>, float>(base.NativePtr + (IntPtr)SCameraConfig.__PropertyOffset_23, base.MemoryOwner ?? this));
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

		// Token: 0x17007C23 RID: 31779
		// (get) Token: 0x0602D74D RID: 186189 RVA: 0x00AC0AAC File Offset: 0x00ABECAC
		// (set) Token: 0x0602D74E RID: 186190 RVA: 0x00AC0AEF File Offset: 0x00ABECEF
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
					result = (this._引导镜头 = new TMap<TEnumAsByte<EFightCameraGuide>, float>(base.NativePtr + (IntPtr)SCameraConfig.__PropertyOffset_24, base.MemoryOwner ?? this));
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

		// Token: 0x17007C24 RID: 31780
		// (get) Token: 0x0602D74F RID: 186191 RVA: 0x00AC0B00 File Offset: 0x00ABED00
		// (set) Token: 0x0602D750 RID: 186192 RVA: 0x00AC0B43 File Offset: 0x00ABED43
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
					result = (this._跑图镜头 = new TMap<TEnumAsByte<EFightCameraExplore>, float>(base.NativePtr + (IntPtr)SCameraConfig.__PropertyOffset_25, base.MemoryOwner ?? this));
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

		// Token: 0x17007C25 RID: 31781
		// (get) Token: 0x0602D751 RID: 186193 RVA: 0x00AC0B54 File Offset: 0x00ABED54
		// (set) Token: 0x0602D752 RID: 186194 RVA: 0x00AC0B97 File Offset: 0x00ABED97
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
					result = (this._对话镜头 = new TMap<TEnumAsByte<EFightCameraDialogue>, float>(base.NativePtr + (IntPtr)SCameraConfig.__PropertyOffset_26, base.MemoryOwner ?? this));
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

		// Token: 0x17007C26 RID: 31782
		// (get) Token: 0x0602D753 RID: 186195 RVA: 0x00AC0BA8 File Offset: 0x00ABEDA8
		// (set) Token: 0x0602D754 RID: 186196 RVA: 0x00AC0BEB File Offset: 0x00ABEDEB
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
					result = (this._攀爬镜头 = new TMap<TEnumAsByte<EFightCameraClimb>, float>(base.NativePtr + (IntPtr)SCameraConfig.__PropertyOffset_27, base.MemoryOwner ?? this));
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

		// Token: 0x17007C27 RID: 31783
		// (get) Token: 0x0602D755 RID: 186197 RVA: 0x00AC0BFC File Offset: 0x00ABEDFC
		// (set) Token: 0x0602D756 RID: 186198 RVA: 0x00AC0C3F File Offset: 0x00ABEE3F
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
					result = (this._移动自动镜头 = new TMap<TEnumAsByte<EFightCameraSidestep>, float>(base.NativePtr + (IntPtr)SCameraConfig.__PropertyOffset_28, base.MemoryOwner ?? this));
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

		// Token: 0x17007C28 RID: 31784
		// (get) Token: 0x0602D757 RID: 186199 RVA: 0x00AC0C50 File Offset: 0x00ABEE50
		// (set) Token: 0x0602D758 RID: 186200 RVA: 0x00AC0C93 File Offset: 0x00ABEE93
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
					result = (this._载具镜头 = new TMap<TEnumAsByte<EFightCameraVehicle>, float>(base.NativePtr + (IntPtr)SCameraConfig.__PropertyOffset_29, base.MemoryOwner ?? this));
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

		// Token: 0x17007C29 RID: 31785
		// (get) Token: 0x0602D759 RID: 186201 RVA: 0x00AC0CA1 File Offset: 0x00ABEEA1
		// (set) Token: 0x0602D75A RID: 186202 RVA: 0x00AC0CB1 File Offset: 0x00ABEEB1
		public unsafe bool 是否开启主镜头缓入缓出
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraConfig.__PropertyOffset_30) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraConfig.__PropertyOffset_30) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007C2A RID: 31786
		// (get) Token: 0x0602D75B RID: 186203 RVA: 0x00AC0CC4 File Offset: 0x00ABEEC4
		// (set) Token: 0x0602D75C RID: 186204 RVA: 0x00AC0D07 File Offset: 0x00ABEF07
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
					result = (this._基础曲线配置 = new TMap<TEnumAsByte<EFightCameraDefault>, SBaseCurve>(base.NativePtr + (IntPtr)SCameraConfig.__PropertyOffset_31, base.MemoryOwner ?? this));
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

		// Token: 0x17007C2B RID: 31787
		// (get) Token: 0x0602D75D RID: 186205 RVA: 0x00AC0D18 File Offset: 0x00ABEF18
		// (set) Token: 0x0602D75E RID: 186206 RVA: 0x00AC0D5B File Offset: 0x00ABEF5B
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
					result = (this._技能修正曲线配置 = new TMap<TEnumAsByte<EFightCameraAdjust>, SBaseCurve>(base.NativePtr + (IntPtr)SCameraConfig.__PropertyOffset_32, base.MemoryOwner ?? this));
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

		// Token: 0x17007C2C RID: 31788
		// (get) Token: 0x0602D75F RID: 186207 RVA: 0x00AC0D6C File Offset: 0x00ABEF6C
		// (set) Token: 0x0602D760 RID: 186208 RVA: 0x00AC0DAF File Offset: 0x00ABEFAF
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
					result = (this._自动镜头曲线配置 = new TMap<TEnumAsByte<EFightCameraAuto>, SBaseCurve>(base.NativePtr + (IntPtr)SCameraConfig.__PropertyOffset_33, base.MemoryOwner ?? this));
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

		// Token: 0x17007C2D RID: 31789
		// (get) Token: 0x0602D761 RID: 186209 RVA: 0x00AC0DC0 File Offset: 0x00ABEFC0
		// (set) Token: 0x0602D762 RID: 186210 RVA: 0x00AC0E03 File Offset: 0x00ABF003
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
					result = (this._锁定镜头曲线配置 = new TMap<TEnumAsByte<EFightCameraFocus>, SBaseCurve>(base.NativePtr + (IntPtr)SCameraConfig.__PropertyOffset_34, base.MemoryOwner ?? this));
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

		// Token: 0x17007C2E RID: 31790
		// (get) Token: 0x0602D763 RID: 186211 RVA: 0x00AC0E14 File Offset: 0x00ABF014
		// (set) Token: 0x0602D764 RID: 186212 RVA: 0x00AC0E57 File Offset: 0x00ABF057
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
					result = (this._镜头输入曲线配置 = new TMap<TEnumAsByte<EFightCameraInput>, SBaseCurve>(base.NativePtr + (IntPtr)SCameraConfig.__PropertyOffset_35, base.MemoryOwner ?? this));
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

		// Token: 0x17007C2F RID: 31791
		// (get) Token: 0x0602D765 RID: 186213 RVA: 0x00AC0E68 File Offset: 0x00ABF068
		// (set) Token: 0x0602D766 RID: 186214 RVA: 0x00AC0EAB File Offset: 0x00ABF0AB
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
					result = (this._Modify镜头曲线配置 = new TMap<TEnumAsByte<EFightCameraModify>, SBaseCurve>(base.NativePtr + (IntPtr)SCameraConfig.__PropertyOffset_36, base.MemoryOwner ?? this));
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

		// Token: 0x17007C30 RID: 31792
		// (get) Token: 0x0602D767 RID: 186215 RVA: 0x00AC0EBC File Offset: 0x00ABF0BC
		// (set) Token: 0x0602D768 RID: 186216 RVA: 0x00AC0EFF File Offset: 0x00ABF0FF
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
					result = (this._引导镜头曲线配置 = new TMap<TEnumAsByte<EFightCameraGuide>, SBaseCurve>(base.NativePtr + (IntPtr)SCameraConfig.__PropertyOffset_37, base.MemoryOwner ?? this));
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

		// Token: 0x17007C31 RID: 31793
		// (get) Token: 0x0602D769 RID: 186217 RVA: 0x00AC0F10 File Offset: 0x00ABF110
		// (set) Token: 0x0602D76A RID: 186218 RVA: 0x00AC0F53 File Offset: 0x00ABF153
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
					result = (this._跑图镜头曲线配置 = new TMap<TEnumAsByte<EFightCameraExplore>, SBaseCurve>(base.NativePtr + (IntPtr)SCameraConfig.__PropertyOffset_38, base.MemoryOwner ?? this));
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

		// Token: 0x17007C32 RID: 31794
		// (get) Token: 0x0602D76B RID: 186219 RVA: 0x00AC0F64 File Offset: 0x00ABF164
		// (set) Token: 0x0602D76C RID: 186220 RVA: 0x00AC0FA7 File Offset: 0x00ABF1A7
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
					result = (this._对话镜头曲线配置 = new TMap<TEnumAsByte<EFightCameraDialogue>, SBaseCurve>(base.NativePtr + (IntPtr)SCameraConfig.__PropertyOffset_39, base.MemoryOwner ?? this));
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

		// Token: 0x17007C33 RID: 31795
		// (get) Token: 0x0602D76D RID: 186221 RVA: 0x00AC0FB8 File Offset: 0x00ABF1B8
		// (set) Token: 0x0602D76E RID: 186222 RVA: 0x00AC0FFB File Offset: 0x00ABF1FB
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
					result = (this._攀爬镜头曲线配置 = new TMap<TEnumAsByte<EFightCameraClimb>, SBaseCurve>(base.NativePtr + (IntPtr)SCameraConfig.__PropertyOffset_40, base.MemoryOwner ?? this));
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

		// Token: 0x17007C34 RID: 31796
		// (get) Token: 0x0602D76F RID: 186223 RVA: 0x00AC100C File Offset: 0x00ABF20C
		// (set) Token: 0x0602D770 RID: 186224 RVA: 0x00AC104F File Offset: 0x00ABF24F
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
					result = (this._移动自动镜头曲线配置 = new TMap<TEnumAsByte<EFightCameraSidestep>, SBaseCurve>(base.NativePtr + (IntPtr)SCameraConfig.__PropertyOffset_41, base.MemoryOwner ?? this));
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

		// Token: 0x17007C35 RID: 31797
		// (get) Token: 0x0602D771 RID: 186225 RVA: 0x00AC1060 File Offset: 0x00ABF260
		// (set) Token: 0x0602D772 RID: 186226 RVA: 0x00AC10A3 File Offset: 0x00ABF2A3
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
					result = (this._载具镜头曲线配置 = new TMap<TEnumAsByte<EFightCameraVehicle>, SBaseCurve>(base.NativePtr + (IntPtr)SCameraConfig.__PropertyOffset_42, base.MemoryOwner ?? this));
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

		// Token: 0x17007C36 RID: 31798
		// (get) Token: 0x0602D773 RID: 186227 RVA: 0x00AC10B1 File Offset: 0x00ABF2B1
		// (set) Token: 0x0602D774 RID: 186228 RVA: 0x00AC10C1 File Offset: 0x00ABF2C1
		public unsafe bool 是否独立过渡时间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraConfig.__PropertyOffset_43) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraConfig.__PropertyOffset_43) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007C37 RID: 31799
		// (get) Token: 0x0602D775 RID: 186229 RVA: 0x00AC10D2 File Offset: 0x00ABF2D2
		// (set) Token: 0x0602D776 RID: 186230 RVA: 0x00AC10E6 File Offset: 0x00ABF2E6
		public unsafe FName 主控角色骨骼
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraConfig.__PropertyOffset_44);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraConfig.__PropertyOffset_44) = value;
			}
		}

		// Token: 0x17007C38 RID: 31800
		// (get) Token: 0x0602D777 RID: 186231 RVA: 0x00AC10FB File Offset: 0x00ABF2FB
		// (set) Token: 0x0602D778 RID: 186232 RVA: 0x00AC110F File Offset: 0x00ABF30F
		[Nullable(0)]
		public unsafe TEnumAsByte<EFightCameraSocketOverrideType> 主控角色骨骼覆盖方式
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraConfig.__PropertyOffset_45);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)SCameraConfig.__PropertyOffset_45) = value;
			}
		}

		// Token: 0x17007C39 RID: 31801
		// (get) Token: 0x0602D779 RID: 186233 RVA: 0x00AC1124 File Offset: 0x00ABF324
		// (set) Token: 0x0602D77A RID: 186234 RVA: 0x00AC1167 File Offset: 0x00ABF367
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
					result = (this._镜头重力 = new TMap<TEnumAsByte<EFightCameraGravity>, float>(base.NativePtr + (IntPtr)SCameraConfig.__PropertyOffset_46, base.MemoryOwner ?? this));
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

		// Token: 0x0602D77B RID: 186235 RVA: 0x00AC1175 File Offset: 0x00ABF375
		public SCameraConfig()
		{
		}

		// Token: 0x0602D77C RID: 186236 RVA: 0x00AC1180 File Offset: 0x00ABF380
		public SCameraConfig([Nullable(0)] TEnumAsByte<EFightCameraType> Type, bool 是否重置默认配置, bool 是否重置镜头锁定, FGameplayTag Tag, bool PC生效, bool 手机生效, int 优先级, float 淡入时间, SBaseCurve 淡入曲线, float 淡出时间, SBaseCurve 淡出曲线, bool 启用自动镜头, bool 启用Modify镜头, bool 启用技能修正镜头, bool 启用锁定镜头, bool 启用移动自动镜头, bool 启用攀爬镜头, TArray<string> 锁定点名称, [Nullable(new byte[]
		{
			1,
			0
		})] TMap<TEnumAsByte<EFightCameraDefault>, float> 基础, [Nullable(new byte[]
		{
			1,
			0
		})] TMap<TEnumAsByte<EFightCameraAdjust>, float> 技能修正, [Nullable(new byte[]
		{
			1,
			0
		})] TMap<TEnumAsByte<EFightCameraAuto>, float> 自动镜头, [Nullable(new byte[]
		{
			1,
			0
		})] TMap<TEnumAsByte<EFightCameraFocus>, float> 锁定镜头, [Nullable(new byte[]
		{
			1,
			0
		})] TMap<TEnumAsByte<EFightCameraInput>, float> 镜头输入, [Nullable(new byte[]
		{
			1,
			0
		})] TMap<TEnumAsByte<EFightCameraModify>, float> Modify镜头, [Nullable(new byte[]
		{
			1,
			0
		})] TMap<TEnumAsByte<EFightCameraGuide>, float> 引导镜头, [Nullable(new byte[]
		{
			1,
			0
		})] TMap<TEnumAsByte<EFightCameraExplore>, float> 跑图镜头, [Nullable(new byte[]
		{
			1,
			0
		})] TMap<TEnumAsByte<EFightCameraDialogue>, float> 对话镜头, [Nullable(new byte[]
		{
			1,
			0
		})] TMap<TEnumAsByte<EFightCameraClimb>, float> 攀爬镜头, [Nullable(new byte[]
		{
			1,
			0
		})] TMap<TEnumAsByte<EFightCameraSidestep>, float> 移动自动镜头, [Nullable(new byte[]
		{
			1,
			0
		})] TMap<TEnumAsByte<EFightCameraVehicle>, float> 载具镜头, bool 是否开启主镜头缓入缓出, [Nullable(new byte[]
		{
			1,
			0,
			1
		})] TMap<TEnumAsByte<EFightCameraDefault>, SBaseCurve> 基础曲线配置, [Nullable(new byte[]
		{
			1,
			0,
			1
		})] TMap<TEnumAsByte<EFightCameraAdjust>, SBaseCurve> 技能修正曲线配置, [Nullable(new byte[]
		{
			1,
			0,
			1
		})] TMap<TEnumAsByte<EFightCameraAuto>, SBaseCurve> 自动镜头曲线配置, [Nullable(new byte[]
		{
			1,
			0,
			1
		})] TMap<TEnumAsByte<EFightCameraFocus>, SBaseCurve> 锁定镜头曲线配置, [Nullable(new byte[]
		{
			1,
			0,
			1
		})] TMap<TEnumAsByte<EFightCameraInput>, SBaseCurve> 镜头输入曲线配置, [Nullable(new byte[]
		{
			1,
			0,
			1
		})] TMap<TEnumAsByte<EFightCameraModify>, SBaseCurve> Modify镜头曲线配置, [Nullable(new byte[]
		{
			1,
			0,
			1
		})] TMap<TEnumAsByte<EFightCameraGuide>, SBaseCurve> 引导镜头曲线配置, [Nullable(new byte[]
		{
			1,
			0,
			1
		})] TMap<TEnumAsByte<EFightCameraExplore>, SBaseCurve> 跑图镜头曲线配置, [Nullable(new byte[]
		{
			1,
			0,
			1
		})] TMap<TEnumAsByte<EFightCameraDialogue>, SBaseCurve> 对话镜头曲线配置, [Nullable(new byte[]
		{
			1,
			0,
			1
		})] TMap<TEnumAsByte<EFightCameraClimb>, SBaseCurve> 攀爬镜头曲线配置, [Nullable(new byte[]
		{
			1,
			0,
			1
		})] TMap<TEnumAsByte<EFightCameraSidestep>, SBaseCurve> 移动自动镜头曲线配置, [Nullable(new byte[]
		{
			1,
			0,
			1
		})] TMap<TEnumAsByte<EFightCameraVehicle>, SBaseCurve> 载具镜头曲线配置, bool 是否独立过渡时间, FName 主控角色骨骼, [Nullable(0)] TEnumAsByte<EFightCameraSocketOverrideType> 主控角色骨骼覆盖方式, [Nullable(new byte[]
		{
			1,
			0
		})] TMap<TEnumAsByte<EFightCameraGravity>, float> 镜头重力)
		{
			this.Type = Type;
			this.是否重置默认配置 = 是否重置默认配置;
			this.是否重置镜头锁定 = 是否重置镜头锁定;
			this.Tag = Tag;
			this.PC生效 = PC生效;
			this.手机生效 = 手机生效;
			this.优先级 = 优先级;
			this.淡入时间 = 淡入时间;
			this.淡入曲线 = 淡入曲线;
			this.淡出时间 = 淡出时间;
			this.淡出曲线 = 淡出曲线;
			this.启用自动镜头 = 启用自动镜头;
			this.启用Modify镜头 = 启用Modify镜头;
			this.启用技能修正镜头 = 启用技能修正镜头;
			this.启用锁定镜头 = 启用锁定镜头;
			this.启用移动自动镜头 = 启用移动自动镜头;
			this.启用攀爬镜头 = 启用攀爬镜头;
			this.锁定点名称 = 锁定点名称;
			this.基础 = 基础;
			this.技能修正 = 技能修正;
			this.自动镜头 = 自动镜头;
			this.锁定镜头 = 锁定镜头;
			this.镜头输入 = 镜头输入;
			this.Modify镜头 = Modify镜头;
			this.引导镜头 = 引导镜头;
			this.跑图镜头 = 跑图镜头;
			this.对话镜头 = 对话镜头;
			this.攀爬镜头 = 攀爬镜头;
			this.移动自动镜头 = 移动自动镜头;
			this.载具镜头 = 载具镜头;
			this.是否开启主镜头缓入缓出 = 是否开启主镜头缓入缓出;
			this.基础曲线配置 = 基础曲线配置;
			this.技能修正曲线配置 = 技能修正曲线配置;
			this.自动镜头曲线配置 = 自动镜头曲线配置;
			this.锁定镜头曲线配置 = 锁定镜头曲线配置;
			this.镜头输入曲线配置 = 镜头输入曲线配置;
			this.Modify镜头曲线配置 = Modify镜头曲线配置;
			this.引导镜头曲线配置 = 引导镜头曲线配置;
			this.跑图镜头曲线配置 = 跑图镜头曲线配置;
			this.对话镜头曲线配置 = 对话镜头曲线配置;
			this.攀爬镜头曲线配置 = 攀爬镜头曲线配置;
			this.移动自动镜头曲线配置 = 移动自动镜头曲线配置;
			this.载具镜头曲线配置 = 载具镜头曲线配置;
			this.是否独立过渡时间 = 是否独立过渡时间;
			this.主控角色骨骼 = 主控角色骨骼;
			this.主控角色骨骼覆盖方式 = 主控角色骨骼覆盖方式;
			this.镜头重力 = 镜头重力;
		}

		// Token: 0x0602D77D RID: 186237 RVA: 0x00AC1308 File Offset: 0x00ABF508
		protected override IntPtr GetUStructPtr()
		{
			return SCameraConfig.StaticStruct();
		}

		// Token: 0x0602D77E RID: 186238 RVA: 0x00AC1314 File Offset: 0x00ABF514
		[NullableContext(2)]
		public SCameraConfig(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602D77F RID: 186239 RVA: 0x00AC131E File Offset: 0x00ABF51E
		public SCameraConfig(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602D780 RID: 186240 RVA: 0x00AC1329 File Offset: 0x00ABF529
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SCameraConfig(Pointer, false, true);
		}

		// Token: 0x0602D781 RID: 186241 RVA: 0x00AC1333 File Offset: 0x00ABF533
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SCameraConfig(Pointer, MemoryOwner);
		}

		// Token: 0x040199EB RID: 104939
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Camera/SCameraConfig.SCameraConfig";

		// Token: 0x040199EC RID: 104940
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040199ED RID: 104941
		internal static int __PropertyOffset_0;

		// Token: 0x040199EE RID: 104942
		internal static int __PropertyOffset_1;

		// Token: 0x040199EF RID: 104943
		internal static int __PropertyOffset_2;

		// Token: 0x040199F0 RID: 104944
		internal static int __PropertyOffset_3;

		// Token: 0x040199F1 RID: 104945
		internal static int __PropertyOffset_4;

		// Token: 0x040199F2 RID: 104946
		internal static int __PropertyOffset_5;

		// Token: 0x040199F3 RID: 104947
		internal static int __PropertyOffset_6;

		// Token: 0x040199F4 RID: 104948
		internal static int __PropertyOffset_7;

		// Token: 0x040199F5 RID: 104949
		internal static int __PropertyOffset_8;

		// Token: 0x040199F6 RID: 104950
		[Nullable(2)]
		private SBaseCurve _淡入曲线;

		// Token: 0x040199F7 RID: 104951
		internal static int __PropertyOffset_9;

		// Token: 0x040199F8 RID: 104952
		internal static int __PropertyOffset_10;

		// Token: 0x040199F9 RID: 104953
		[Nullable(2)]
		private SBaseCurve _淡出曲线;

		// Token: 0x040199FA RID: 104954
		internal static int __PropertyOffset_11;

		// Token: 0x040199FB RID: 104955
		internal static int __PropertyOffset_12;

		// Token: 0x040199FC RID: 104956
		internal static int __PropertyOffset_13;

		// Token: 0x040199FD RID: 104957
		internal static int __PropertyOffset_14;

		// Token: 0x040199FE RID: 104958
		internal static int __PropertyOffset_15;

		// Token: 0x040199FF RID: 104959
		internal static int __PropertyOffset_16;

		// Token: 0x04019A00 RID: 104960
		internal static int __PropertyOffset_17;

		// Token: 0x04019A01 RID: 104961
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<string> _锁定点名称;

		// Token: 0x04019A02 RID: 104962
		internal static int __PropertyOffset_18;

		// Token: 0x04019A03 RID: 104963
		[Nullable(new byte[]
		{
			2,
			0
		})]
		private TMap<TEnumAsByte<EFightCameraDefault>, float> _基础;

		// Token: 0x04019A04 RID: 104964
		internal static int __PropertyOffset_19;

		// Token: 0x04019A05 RID: 104965
		[Nullable(new byte[]
		{
			2,
			0
		})]
		private TMap<TEnumAsByte<EFightCameraAdjust>, float> _技能修正;

		// Token: 0x04019A06 RID: 104966
		internal static int __PropertyOffset_20;

		// Token: 0x04019A07 RID: 104967
		[Nullable(new byte[]
		{
			2,
			0
		})]
		private TMap<TEnumAsByte<EFightCameraAuto>, float> _自动镜头;

		// Token: 0x04019A08 RID: 104968
		internal static int __PropertyOffset_21;

		// Token: 0x04019A09 RID: 104969
		[Nullable(new byte[]
		{
			2,
			0
		})]
		private TMap<TEnumAsByte<EFightCameraFocus>, float> _锁定镜头;

		// Token: 0x04019A0A RID: 104970
		internal static int __PropertyOffset_22;

		// Token: 0x04019A0B RID: 104971
		[Nullable(new byte[]
		{
			2,
			0
		})]
		private TMap<TEnumAsByte<EFightCameraInput>, float> _镜头输入;

		// Token: 0x04019A0C RID: 104972
		internal static int __PropertyOffset_23;

		// Token: 0x04019A0D RID: 104973
		[Nullable(new byte[]
		{
			2,
			0
		})]
		private TMap<TEnumAsByte<EFightCameraModify>, float> _Modify镜头;

		// Token: 0x04019A0E RID: 104974
		internal static int __PropertyOffset_24;

		// Token: 0x04019A0F RID: 104975
		[Nullable(new byte[]
		{
			2,
			0
		})]
		private TMap<TEnumAsByte<EFightCameraGuide>, float> _引导镜头;

		// Token: 0x04019A10 RID: 104976
		internal static int __PropertyOffset_25;

		// Token: 0x04019A11 RID: 104977
		[Nullable(new byte[]
		{
			2,
			0
		})]
		private TMap<TEnumAsByte<EFightCameraExplore>, float> _跑图镜头;

		// Token: 0x04019A12 RID: 104978
		internal static int __PropertyOffset_26;

		// Token: 0x04019A13 RID: 104979
		[Nullable(new byte[]
		{
			2,
			0
		})]
		private TMap<TEnumAsByte<EFightCameraDialogue>, float> _对话镜头;

		// Token: 0x04019A14 RID: 104980
		internal static int __PropertyOffset_27;

		// Token: 0x04019A15 RID: 104981
		[Nullable(new byte[]
		{
			2,
			0
		})]
		private TMap<TEnumAsByte<EFightCameraClimb>, float> _攀爬镜头;

		// Token: 0x04019A16 RID: 104982
		internal static int __PropertyOffset_28;

		// Token: 0x04019A17 RID: 104983
		[Nullable(new byte[]
		{
			2,
			0
		})]
		private TMap<TEnumAsByte<EFightCameraSidestep>, float> _移动自动镜头;

		// Token: 0x04019A18 RID: 104984
		internal static int __PropertyOffset_29;

		// Token: 0x04019A19 RID: 104985
		[Nullable(new byte[]
		{
			2,
			0
		})]
		private TMap<TEnumAsByte<EFightCameraVehicle>, float> _载具镜头;

		// Token: 0x04019A1A RID: 104986
		internal static int __PropertyOffset_30;

		// Token: 0x04019A1B RID: 104987
		internal static int __PropertyOffset_31;

		// Token: 0x04019A1C RID: 104988
		[Nullable(new byte[]
		{
			2,
			0,
			1
		})]
		private TMap<TEnumAsByte<EFightCameraDefault>, SBaseCurve> _基础曲线配置;

		// Token: 0x04019A1D RID: 104989
		internal static int __PropertyOffset_32;

		// Token: 0x04019A1E RID: 104990
		[Nullable(new byte[]
		{
			2,
			0,
			1
		})]
		private TMap<TEnumAsByte<EFightCameraAdjust>, SBaseCurve> _技能修正曲线配置;

		// Token: 0x04019A1F RID: 104991
		internal static int __PropertyOffset_33;

		// Token: 0x04019A20 RID: 104992
		[Nullable(new byte[]
		{
			2,
			0,
			1
		})]
		private TMap<TEnumAsByte<EFightCameraAuto>, SBaseCurve> _自动镜头曲线配置;

		// Token: 0x04019A21 RID: 104993
		internal static int __PropertyOffset_34;

		// Token: 0x04019A22 RID: 104994
		[Nullable(new byte[]
		{
			2,
			0,
			1
		})]
		private TMap<TEnumAsByte<EFightCameraFocus>, SBaseCurve> _锁定镜头曲线配置;

		// Token: 0x04019A23 RID: 104995
		internal static int __PropertyOffset_35;

		// Token: 0x04019A24 RID: 104996
		[Nullable(new byte[]
		{
			2,
			0,
			1
		})]
		private TMap<TEnumAsByte<EFightCameraInput>, SBaseCurve> _镜头输入曲线配置;

		// Token: 0x04019A25 RID: 104997
		internal static int __PropertyOffset_36;

		// Token: 0x04019A26 RID: 104998
		[Nullable(new byte[]
		{
			2,
			0,
			1
		})]
		private TMap<TEnumAsByte<EFightCameraModify>, SBaseCurve> _Modify镜头曲线配置;

		// Token: 0x04019A27 RID: 104999
		internal static int __PropertyOffset_37;

		// Token: 0x04019A28 RID: 105000
		[Nullable(new byte[]
		{
			2,
			0,
			1
		})]
		private TMap<TEnumAsByte<EFightCameraGuide>, SBaseCurve> _引导镜头曲线配置;

		// Token: 0x04019A29 RID: 105001
		internal static int __PropertyOffset_38;

		// Token: 0x04019A2A RID: 105002
		[Nullable(new byte[]
		{
			2,
			0,
			1
		})]
		private TMap<TEnumAsByte<EFightCameraExplore>, SBaseCurve> _跑图镜头曲线配置;

		// Token: 0x04019A2B RID: 105003
		internal static int __PropertyOffset_39;

		// Token: 0x04019A2C RID: 105004
		[Nullable(new byte[]
		{
			2,
			0,
			1
		})]
		private TMap<TEnumAsByte<EFightCameraDialogue>, SBaseCurve> _对话镜头曲线配置;

		// Token: 0x04019A2D RID: 105005
		internal static int __PropertyOffset_40;

		// Token: 0x04019A2E RID: 105006
		[Nullable(new byte[]
		{
			2,
			0,
			1
		})]
		private TMap<TEnumAsByte<EFightCameraClimb>, SBaseCurve> _攀爬镜头曲线配置;

		// Token: 0x04019A2F RID: 105007
		internal static int __PropertyOffset_41;

		// Token: 0x04019A30 RID: 105008
		[Nullable(new byte[]
		{
			2,
			0,
			1
		})]
		private TMap<TEnumAsByte<EFightCameraSidestep>, SBaseCurve> _移动自动镜头曲线配置;

		// Token: 0x04019A31 RID: 105009
		internal static int __PropertyOffset_42;

		// Token: 0x04019A32 RID: 105010
		[Nullable(new byte[]
		{
			2,
			0,
			1
		})]
		private TMap<TEnumAsByte<EFightCameraVehicle>, SBaseCurve> _载具镜头曲线配置;

		// Token: 0x04019A33 RID: 105011
		internal static int __PropertyOffset_43;

		// Token: 0x04019A34 RID: 105012
		internal static int __PropertyOffset_44;

		// Token: 0x04019A35 RID: 105013
		internal static int __PropertyOffset_45;

		// Token: 0x04019A36 RID: 105014
		internal static int __PropertyOffset_46;

		// Token: 0x04019A37 RID: 105015
		[Nullable(new byte[]
		{
			2,
			0
		})]
		private TMap<TEnumAsByte<EFightCameraGravity>, float> _镜头重力;
	}
}
