using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Level.KeepFollowing;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.Structure
{
	// Token: 0x02004005 RID: 16389
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/Structure/BP_HoldingHandsConfig.BP_HoldingHandsConfig_C")]
	[UnrealStructLayout(456, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 456)]
	public class BP_HoldingHandsConfig_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602A8CB RID: 174283 RVA: 0x00A5C814 File Offset: 0x00A5AA14
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_HoldingHandsConfig_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Data/Structure/BP_HoldingHandsConfig.BP_HoldingHandsConfig_C");
			}
			return BP_HoldingHandsConfig_C._ClassPtr;
		}

		// Token: 0x0602A8CC RID: 174284 RVA: 0x00A5C838 File Offset: 0x00A5AA38
		public BP_HoldingHandsConfig_C() : this(BuiltinUtils.AllocNativeUObject(BP_HoldingHandsConfig_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602A8CD RID: 174285 RVA: 0x00A5C860 File Offset: 0x00A5AA60
		public BP_HoldingHandsConfig_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_HoldingHandsConfig_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17006EA2 RID: 28322
		// (get) Token: 0x0602A8CE RID: 174286 RVA: 0x00A5C894 File Offset: 0x00A5AA94
		// (set) Token: 0x0602A8CF RID: 174287 RVA: 0x00A5C8CD File Offset: 0x00A5AACD
		public FGameplayTagContainer 邀请中
		{
			get
			{
				base.FastCheckIsValid();
				FGameplayTagContainer result;
				if ((result = this._邀请中) == null)
				{
					result = (this._邀请中 = new FGameplayTagContainer(base.NativePtr + (IntPtr)BP_HoldingHandsConfig_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayTagContainer.StaticStruct(), base.NativePtr + (IntPtr)BP_HoldingHandsConfig_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006EA3 RID: 28323
		// (get) Token: 0x0602A8D0 RID: 174288 RVA: 0x00A5C8F0 File Offset: 0x00A5AAF0
		// (set) Token: 0x0602A8D1 RID: 174289 RVA: 0x00A5C929 File Offset: 0x00A5AB29
		public FGameplayTagContainer 牵手中
		{
			get
			{
				base.FastCheckIsValid();
				FGameplayTagContainer result;
				if ((result = this._牵手中) == null)
				{
					result = (this._牵手中 = new FGameplayTagContainer(base.NativePtr + (IntPtr)BP_HoldingHandsConfig_C.__PropertyOffset_1, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayTagContainer.StaticStruct(), base.NativePtr + (IntPtr)BP_HoldingHandsConfig_C.__PropertyOffset_1, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006EA4 RID: 28324
		// (get) Token: 0x0602A8D2 RID: 174290 RVA: 0x00A5C94C File Offset: 0x00A5AB4C
		// (set) Token: 0x0602A8D3 RID: 174291 RVA: 0x00A5C985 File Offset: 0x00A5AB85
		public FGameplayTagContainer 被牵手中
		{
			get
			{
				base.FastCheckIsValid();
				FGameplayTagContainer result;
				if ((result = this._被牵手中) == null)
				{
					result = (this._被牵手中 = new FGameplayTagContainer(base.NativePtr + (IntPtr)BP_HoldingHandsConfig_C.__PropertyOffset_2, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayTagContainer.StaticStruct(), base.NativePtr + (IntPtr)BP_HoldingHandsConfig_C.__PropertyOffset_2, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006EA5 RID: 28325
		// (get) Token: 0x0602A8D4 RID: 174292 RVA: 0x00A5C9A6 File Offset: 0x00A5ABA6
		// (set) Token: 0x0602A8D5 RID: 174293 RVA: 0x00A5C9BA File Offset: 0x00A5ABBA
		public unsafe FGameplayTag 牵手范围内
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_HoldingHandsConfig_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_HoldingHandsConfig_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17006EA6 RID: 28326
		// (get) Token: 0x0602A8D6 RID: 174294 RVA: 0x00A5C9D0 File Offset: 0x00A5ABD0
		// (set) Token: 0x0602A8D7 RID: 174295 RVA: 0x00A5CA09 File Offset: 0x00A5AC09
		public FGameplayTagContainer 牵手禁止
		{
			get
			{
				base.FastCheckIsValid();
				FGameplayTagContainer result;
				if ((result = this._牵手禁止) == null)
				{
					result = (this._牵手禁止 = new FGameplayTagContainer(base.NativePtr + (IntPtr)BP_HoldingHandsConfig_C.__PropertyOffset_4, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayTagContainer.StaticStruct(), base.NativePtr + (IntPtr)BP_HoldingHandsConfig_C.__PropertyOffset_4, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006EA7 RID: 28327
		// (get) Token: 0x0602A8D8 RID: 174296 RVA: 0x00A5CA2A File Offset: 0x00A5AC2A
		// (set) Token: 0x0602A8D9 RID: 174297 RVA: 0x00A5CA3A File Offset: 0x00A5AC3A
		public unsafe float 超时终止时长
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_HoldingHandsConfig_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_HoldingHandsConfig_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17006EA8 RID: 28328
		// (get) Token: 0x0602A8DA RID: 174298 RVA: 0x00A5CA4B File Offset: 0x00A5AC4B
		// (set) Token: 0x0602A8DB RID: 174299 RVA: 0x00A5CA5B File Offset: 0x00A5AC5B
		public unsafe float 进出牵手阻尼
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_HoldingHandsConfig_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_HoldingHandsConfig_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17006EA9 RID: 28329
		// (get) Token: 0x0602A8DC RID: 174300 RVA: 0x00A5CA6C File Offset: 0x00A5AC6C
		// (set) Token: 0x0602A8DD RID: 174301 RVA: 0x00A5CA7C File Offset: 0x00A5AC7C
		public unsafe float 跑步速度缩放
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_HoldingHandsConfig_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_HoldingHandsConfig_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17006EAA RID: 28330
		// (get) Token: 0x0602A8DE RID: 174302 RVA: 0x00A5CA8D File Offset: 0x00A5AC8D
		// (set) Token: 0x0602A8DF RID: 174303 RVA: 0x00A5CA9D File Offset: 0x00A5AC9D
		public unsafe float 牵手点阻尼
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_HoldingHandsConfig_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_HoldingHandsConfig_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17006EAB RID: 28331
		// (get) Token: 0x0602A8E0 RID: 174304 RVA: 0x00A5CAAE File Offset: 0x00A5ACAE
		// (set) Token: 0x0602A8E1 RID: 174305 RVA: 0x00A5CABE File Offset: 0x00A5ACBE
		public unsafe float 长按退出时长
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_HoldingHandsConfig_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_HoldingHandsConfig_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17006EAC RID: 28332
		// (get) Token: 0x0602A8E2 RID: 174306 RVA: 0x00A5CACF File Offset: 0x00A5ACCF
		// (set) Token: 0x0602A8E3 RID: 174307 RVA: 0x00A5CAE3 File Offset: 0x00A5ACE3
		public unsafe FFloatRange 牵手点偏转角范围
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_HoldingHandsConfig_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_HoldingHandsConfig_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17006EAD RID: 28333
		// (get) Token: 0x0602A8E4 RID: 174308 RVA: 0x00A5CAF8 File Offset: 0x00A5ACF8
		// (set) Token: 0x0602A8E5 RID: 174309 RVA: 0x00A5CB0C File Offset: 0x00A5AD0C
		public unsafe FFloatRange 牵手点俯仰角范围
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_HoldingHandsConfig_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_HoldingHandsConfig_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17006EAE RID: 28334
		// (get) Token: 0x0602A8E6 RID: 174310 RVA: 0x00A5CB21 File Offset: 0x00A5AD21
		// (set) Token: 0x0602A8E7 RID: 174311 RVA: 0x00A5CB35 File Offset: 0x00A5AD35
		public unsafe FFloatRange 肩部偏转角范围
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_HoldingHandsConfig_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_HoldingHandsConfig_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17006EAF RID: 28335
		// (get) Token: 0x0602A8E8 RID: 174312 RVA: 0x00A5CB4A File Offset: 0x00A5AD4A
		// (set) Token: 0x0602A8E9 RID: 174313 RVA: 0x00A5CB5E File Offset: 0x00A5AD5E
		public unsafe FFloatRange 肩部俯仰角范围
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_HoldingHandsConfig_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_HoldingHandsConfig_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17006EB0 RID: 28336
		// (get) Token: 0x0602A8EA RID: 174314 RVA: 0x00A5CB73 File Offset: 0x00A5AD73
		// (set) Token: 0x0602A8EB RID: 174315 RVA: 0x00A5CB83 File Offset: 0x00A5AD83
		public unsafe float 范围内额外角度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_HoldingHandsConfig_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_HoldingHandsConfig_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17006EB1 RID: 28337
		// (get) Token: 0x0602A8EC RID: 174316 RVA: 0x00A5CB94 File Offset: 0x00A5AD94
		// (set) Token: 0x0602A8ED RID: 174317 RVA: 0x00A5CBA4 File Offset: 0x00A5ADA4
		public unsafe float 范围外可达距离缩放
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_HoldingHandsConfig_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_HoldingHandsConfig_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17006EB2 RID: 28338
		// (get) Token: 0x0602A8EE RID: 174318 RVA: 0x00A5CBB5 File Offset: 0x00A5ADB5
		// (set) Token: 0x0602A8EF RID: 174319 RVA: 0x00A5CBC5 File Offset: 0x00A5ADC5
		public unsafe float 范围内可达距离缩放
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_HoldingHandsConfig_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_HoldingHandsConfig_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x17006EB3 RID: 28339
		// (get) Token: 0x0602A8F0 RID: 174320 RVA: 0x00A5CBD6 File Offset: 0x00A5ADD6
		// (set) Token: 0x0602A8F1 RID: 174321 RVA: 0x00A5CBE6 File Offset: 0x00A5ADE6
		public unsafe float 范围外牵手点最大距离
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_HoldingHandsConfig_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_HoldingHandsConfig_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x17006EB4 RID: 28340
		// (get) Token: 0x0602A8F2 RID: 174322 RVA: 0x00A5CBF7 File Offset: 0x00A5ADF7
		// (set) Token: 0x0602A8F3 RID: 174323 RVA: 0x00A5CC07 File Offset: 0x00A5AE07
		public unsafe float 范围内牵手点最大距离
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_HoldingHandsConfig_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_HoldingHandsConfig_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x17006EB5 RID: 28341
		// (get) Token: 0x0602A8F4 RID: 174324 RVA: 0x00A5CC18 File Offset: 0x00A5AE18
		// (set) Token: 0x0602A8F5 RID: 174325 RVA: 0x00A5CC2D File Offset: 0x00A5AE2D
		public TSoftObjectPtr<BP_KeepFollowingConfig_C> 跟随配置
		{
			get
			{
				return new TSoftObjectPtr<BP_KeepFollowingConfig_C>(base.NativePtr + (IntPtr)BP_HoldingHandsConfig_C.__PropertyOffset_19, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_HoldingHandsConfig_C.__PropertyOffset_19, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17006EB6 RID: 28342
		// (get) Token: 0x0602A8F6 RID: 174326 RVA: 0x00A5CC52 File Offset: 0x00A5AE52
		// (set) Token: 0x0602A8F7 RID: 174327 RVA: 0x00A5CC62 File Offset: 0x00A5AE62
		public unsafe bool Debug
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_HoldingHandsConfig_C.__PropertyOffset_20) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_HoldingHandsConfig_C.__PropertyOffset_20) = (value ? 1 : 0);
			}
		}

		// Token: 0x17006EB7 RID: 28343
		// (get) Token: 0x0602A8F8 RID: 174328 RVA: 0x00A5CC73 File Offset: 0x00A5AE73
		// (set) Token: 0x0602A8F9 RID: 174329 RVA: 0x00A5CC83 File Offset: 0x00A5AE83
		public unsafe float 跑步最大旋转速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_HoldingHandsConfig_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_HoldingHandsConfig_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x17006EB8 RID: 28344
		// (get) Token: 0x0602A8FA RID: 174330 RVA: 0x00A5CC94 File Offset: 0x00A5AE94
		// (set) Token: 0x0602A8FB RID: 174331 RVA: 0x00A5CCA4 File Offset: 0x00A5AEA4
		public unsafe float 走路最大旋转速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_HoldingHandsConfig_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_HoldingHandsConfig_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x17006EB9 RID: 28345
		// (get) Token: 0x0602A8FC RID: 174332 RVA: 0x00A5CCB5 File Offset: 0x00A5AEB5
		// (set) Token: 0x0602A8FD RID: 174333 RVA: 0x00A5CCC5 File Offset: 0x00A5AEC5
		public unsafe int 牵手者碰撞优先级
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_HoldingHandsConfig_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_HoldingHandsConfig_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x17006EBA RID: 28346
		// (get) Token: 0x0602A8FE RID: 174334 RVA: 0x00A5CCD6 File Offset: 0x00A5AED6
		// (set) Token: 0x0602A8FF RID: 174335 RVA: 0x00A5CCE6 File Offset: 0x00A5AEE6
		public unsafe int 被牵手者碰撞优先级
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_HoldingHandsConfig_C.__PropertyOffset_24);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_HoldingHandsConfig_C.__PropertyOffset_24) = value;
			}
		}

		// Token: 0x17006EBB RID: 28347
		// (get) Token: 0x0602A900 RID: 174336 RVA: 0x00A5CCF7 File Offset: 0x00A5AEF7
		// (set) Token: 0x0602A901 RID: 174337 RVA: 0x00A5CD07 File Offset: 0x00A5AF07
		public unsafe float 牵手者质量
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_HoldingHandsConfig_C.__PropertyOffset_25);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_HoldingHandsConfig_C.__PropertyOffset_25) = value;
			}
		}

		// Token: 0x17006EBC RID: 28348
		// (get) Token: 0x0602A902 RID: 174338 RVA: 0x00A5CD18 File Offset: 0x00A5AF18
		// (set) Token: 0x0602A903 RID: 174339 RVA: 0x00A5CD28 File Offset: 0x00A5AF28
		public unsafe float 被牵手者质量
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_HoldingHandsConfig_C.__PropertyOffset_26);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_HoldingHandsConfig_C.__PropertyOffset_26) = value;
			}
		}

		// Token: 0x17006EBD RID: 28349
		// (get) Token: 0x0602A904 RID: 174340 RVA: 0x00A5CD39 File Offset: 0x00A5AF39
		// (set) Token: 0x0602A905 RID: 174341 RVA: 0x00A5CD49 File Offset: 0x00A5AF49
		public unsafe float 邀请距离
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_HoldingHandsConfig_C.__PropertyOffset_27);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_HoldingHandsConfig_C.__PropertyOffset_27) = value;
			}
		}

		// Token: 0x17006EBE RID: 28350
		// (get) Token: 0x0602A906 RID: 174342 RVA: 0x00A5CD5A File Offset: 0x00A5AF5A
		// (set) Token: 0x0602A907 RID: 174343 RVA: 0x00A5CD6A File Offset: 0x00A5AF6A
		public unsafe float 邀请距离容差
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_HoldingHandsConfig_C.__PropertyOffset_28);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_HoldingHandsConfig_C.__PropertyOffset_28) = value;
			}
		}

		// Token: 0x17006EBF RID: 28351
		// (get) Token: 0x0602A908 RID: 174344 RVA: 0x00A5CD7B File Offset: 0x00A5AF7B
		// (set) Token: 0x0602A909 RID: 174345 RVA: 0x00A5CD8B File Offset: 0x00A5AF8B
		public unsafe float 邀请结束距离
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_HoldingHandsConfig_C.__PropertyOffset_29);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_HoldingHandsConfig_C.__PropertyOffset_29) = value;
			}
		}

		// Token: 0x17006EC0 RID: 28352
		// (get) Token: 0x0602A90A RID: 174346 RVA: 0x00A5CD9C File Offset: 0x00A5AF9C
		// (set) Token: 0x0602A90B RID: 174347 RVA: 0x00A5CDAC File Offset: 0x00A5AFAC
		public unsafe float 邀请结束距离容差
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_HoldingHandsConfig_C.__PropertyOffset_30);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_HoldingHandsConfig_C.__PropertyOffset_30) = value;
			}
		}

		// Token: 0x17006EC1 RID: 28353
		// (get) Token: 0x0602A90C RID: 174348 RVA: 0x00A5CDBD File Offset: 0x00A5AFBD
		// (set) Token: 0x0602A90D RID: 174349 RVA: 0x00A5CDCD File Offset: 0x00A5AFCD
		public unsafe float 邀请结束移动速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_HoldingHandsConfig_C.__PropertyOffset_31);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_HoldingHandsConfig_C.__PropertyOffset_31) = value;
			}
		}

		// Token: 0x17006EC2 RID: 28354
		// (get) Token: 0x0602A90E RID: 174350 RVA: 0x00A5CDDE File Offset: 0x00A5AFDE
		// (set) Token: 0x0602A90F RID: 174351 RVA: 0x00A5CDEE File Offset: 0x00A5AFEE
		public unsafe float 邀请旋转速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_HoldingHandsConfig_C.__PropertyOffset_32);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_HoldingHandsConfig_C.__PropertyOffset_32) = value;
			}
		}

		// Token: 0x17006EC3 RID: 28355
		// (get) Token: 0x0602A910 RID: 174352 RVA: 0x00A5CDFF File Offset: 0x00A5AFFF
		// (set) Token: 0x0602A911 RID: 174353 RVA: 0x00A5CE0F File Offset: 0x00A5B00F
		public unsafe float 邀请时牵手点阻尼
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_HoldingHandsConfig_C.__PropertyOffset_33);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_HoldingHandsConfig_C.__PropertyOffset_33) = value;
			}
		}

		// Token: 0x17006EC4 RID: 28356
		// (get) Token: 0x0602A912 RID: 174354 RVA: 0x00A5CE20 File Offset: 0x00A5B020
		// (set) Token: 0x0602A913 RID: 174355 RVA: 0x00A5CE30 File Offset: 0x00A5B030
		public unsafe float 手掌最小夹角
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_HoldingHandsConfig_C.__PropertyOffset_34);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_HoldingHandsConfig_C.__PropertyOffset_34) = value;
			}
		}

		// Token: 0x17006EC5 RID: 28357
		// (get) Token: 0x0602A914 RID: 174356 RVA: 0x00A5CE41 File Offset: 0x00A5B041
		// (set) Token: 0x0602A915 RID: 174357 RVA: 0x00A5CE51 File Offset: 0x00A5B051
		public unsafe float 牵手者牵手点位置缩放
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_HoldingHandsConfig_C.__PropertyOffset_35);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_HoldingHandsConfig_C.__PropertyOffset_35) = value;
			}
		}

		// Token: 0x17006EC6 RID: 28358
		// (get) Token: 0x0602A916 RID: 174358 RVA: 0x00A5CE62 File Offset: 0x00A5B062
		// (set) Token: 0x0602A917 RID: 174359 RVA: 0x00A5CE72 File Offset: 0x00A5B072
		public unsafe float 被牵手者牵手点位置缩放
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_HoldingHandsConfig_C.__PropertyOffset_36);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_HoldingHandsConfig_C.__PropertyOffset_36) = value;
			}
		}

		// Token: 0x17006EC7 RID: 28359
		// (get) Token: 0x0602A918 RID: 174360 RVA: 0x00A5CE83 File Offset: 0x00A5B083
		// (set) Token: 0x0602A919 RID: 174361 RVA: 0x00A5CE93 File Offset: 0x00A5B093
		public unsafe float 贴合距离
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_HoldingHandsConfig_C.__PropertyOffset_37);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_HoldingHandsConfig_C.__PropertyOffset_37) = value;
			}
		}

		// Token: 0x17006EC8 RID: 28360
		// (get) Token: 0x0602A91A RID: 174362 RVA: 0x00A5CEA4 File Offset: 0x00A5B0A4
		// (set) Token: 0x0602A91B RID: 174363 RVA: 0x00A5CEB4 File Offset: 0x00A5B0B4
		public unsafe float 范围外肩部最大高度差
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_HoldingHandsConfig_C.__PropertyOffset_38);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_HoldingHandsConfig_C.__PropertyOffset_38) = value;
			}
		}

		// Token: 0x17006EC9 RID: 28361
		// (get) Token: 0x0602A91C RID: 174364 RVA: 0x00A5CEC5 File Offset: 0x00A5B0C5
		// (set) Token: 0x0602A91D RID: 174365 RVA: 0x00A5CED5 File Offset: 0x00A5B0D5
		public unsafe float 范围内肩部最大高度差
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_HoldingHandsConfig_C.__PropertyOffset_39);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_HoldingHandsConfig_C.__PropertyOffset_39) = value;
			}
		}

		// Token: 0x0602A91E RID: 174366 RVA: 0x00A5CEE6 File Offset: 0x00A5B0E6
		protected BP_HoldingHandsConfig_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017239 RID: 94777
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/Structure/BP_HoldingHandsConfig.BP_HoldingHandsConfig_C";

		// Token: 0x0401723A RID: 94778
		private static IntPtr _ClassPtr;

		// Token: 0x0401723B RID: 94779
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401723C RID: 94780
		internal static int __PropertyOffset_0;

		// Token: 0x0401723D RID: 94781
		[Nullable(2)]
		private FGameplayTagContainer _邀请中;

		// Token: 0x0401723E RID: 94782
		internal static int __PropertyOffset_1;

		// Token: 0x0401723F RID: 94783
		[Nullable(2)]
		private FGameplayTagContainer _牵手中;

		// Token: 0x04017240 RID: 94784
		internal static int __PropertyOffset_2;

		// Token: 0x04017241 RID: 94785
		[Nullable(2)]
		private FGameplayTagContainer _被牵手中;

		// Token: 0x04017242 RID: 94786
		internal static int __PropertyOffset_3;

		// Token: 0x04017243 RID: 94787
		internal static int __PropertyOffset_4;

		// Token: 0x04017244 RID: 94788
		[Nullable(2)]
		private FGameplayTagContainer _牵手禁止;

		// Token: 0x04017245 RID: 94789
		internal static int __PropertyOffset_5;

		// Token: 0x04017246 RID: 94790
		internal static int __PropertyOffset_6;

		// Token: 0x04017247 RID: 94791
		internal static int __PropertyOffset_7;

		// Token: 0x04017248 RID: 94792
		internal static int __PropertyOffset_8;

		// Token: 0x04017249 RID: 94793
		internal static int __PropertyOffset_9;

		// Token: 0x0401724A RID: 94794
		internal static int __PropertyOffset_10;

		// Token: 0x0401724B RID: 94795
		internal static int __PropertyOffset_11;

		// Token: 0x0401724C RID: 94796
		internal static int __PropertyOffset_12;

		// Token: 0x0401724D RID: 94797
		internal static int __PropertyOffset_13;

		// Token: 0x0401724E RID: 94798
		internal static int __PropertyOffset_14;

		// Token: 0x0401724F RID: 94799
		internal static int __PropertyOffset_15;

		// Token: 0x04017250 RID: 94800
		internal static int __PropertyOffset_16;

		// Token: 0x04017251 RID: 94801
		internal static int __PropertyOffset_17;

		// Token: 0x04017252 RID: 94802
		internal static int __PropertyOffset_18;

		// Token: 0x04017253 RID: 94803
		internal static int __PropertyOffset_19;

		// Token: 0x04017254 RID: 94804
		internal static int __PropertyOffset_20;

		// Token: 0x04017255 RID: 94805
		internal static int __PropertyOffset_21;

		// Token: 0x04017256 RID: 94806
		internal static int __PropertyOffset_22;

		// Token: 0x04017257 RID: 94807
		internal static int __PropertyOffset_23;

		// Token: 0x04017258 RID: 94808
		internal static int __PropertyOffset_24;

		// Token: 0x04017259 RID: 94809
		internal static int __PropertyOffset_25;

		// Token: 0x0401725A RID: 94810
		internal static int __PropertyOffset_26;

		// Token: 0x0401725B RID: 94811
		internal static int __PropertyOffset_27;

		// Token: 0x0401725C RID: 94812
		internal static int __PropertyOffset_28;

		// Token: 0x0401725D RID: 94813
		internal static int __PropertyOffset_29;

		// Token: 0x0401725E RID: 94814
		internal static int __PropertyOffset_30;

		// Token: 0x0401725F RID: 94815
		internal static int __PropertyOffset_31;

		// Token: 0x04017260 RID: 94816
		internal static int __PropertyOffset_32;

		// Token: 0x04017261 RID: 94817
		internal static int __PropertyOffset_33;

		// Token: 0x04017262 RID: 94818
		internal static int __PropertyOffset_34;

		// Token: 0x04017263 RID: 94819
		internal static int __PropertyOffset_35;

		// Token: 0x04017264 RID: 94820
		internal static int __PropertyOffset_36;

		// Token: 0x04017265 RID: 94821
		internal static int __PropertyOffset_37;

		// Token: 0x04017266 RID: 94822
		internal static int __PropertyOffset_38;

		// Token: 0x04017267 RID: 94823
		internal static int __PropertyOffset_39;
	}
}
