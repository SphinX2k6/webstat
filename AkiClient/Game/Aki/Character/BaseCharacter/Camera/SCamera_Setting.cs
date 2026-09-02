using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Camera
{
	// Token: 0x02004318 RID: 17176
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Camera/SCamera_Setting.SCamera_Setting")]
	[UnrealStructLayout(168, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 164)]
	public class SCamera_Setting : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602D8A7 RID: 186535 RVA: 0x00AC3108 File Offset: 0x00AC1308
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SCamera_Setting._ScriptStructPtr != 0) ? SCamera_Setting._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/Camera/SCamera_Setting.SCamera_Setting", ref SCamera_Setting._ScriptStructPtr);
		}

		// Token: 0x17007CA9 RID: 31913
		// (get) Token: 0x0602D8A8 RID: 186536 RVA: 0x00AC312C File Offset: 0x00AC132C
		// (set) Token: 0x0602D8A9 RID: 186537 RVA: 0x00AC3140 File Offset: 0x00AC1340
		public unsafe TEnumAsByte<EFightCameraType> Type
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCamera_Setting.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCamera_Setting.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17007CAA RID: 31914
		// (get) Token: 0x0602D8AA RID: 186538 RVA: 0x00AC3155 File Offset: 0x00AC1355
		// (set) Token: 0x0602D8AB RID: 186539 RVA: 0x00AC3169 File Offset: 0x00AC1369
		public unsafe FGameplayTag Tag
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCamera_Setting.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCamera_Setting.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17007CAB RID: 31915
		// (get) Token: 0x0602D8AC RID: 186540 RVA: 0x00AC317E File Offset: 0x00AC137E
		// (set) Token: 0x0602D8AD RID: 186541 RVA: 0x00AC318E File Offset: 0x00AC138E
		public unsafe float 默认臂长
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCamera_Setting.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCamera_Setting.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17007CAC RID: 31916
		// (get) Token: 0x0602D8AE RID: 186542 RVA: 0x00AC319F File Offset: 0x00AC139F
		// (set) Token: 0x0602D8AF RID: 186543 RVA: 0x00AC31AF File Offset: 0x00AC13AF
		public unsafe float 默认臂长优先级
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCamera_Setting.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCamera_Setting.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17007CAD RID: 31917
		// (get) Token: 0x0602D8B0 RID: 186544 RVA: 0x00AC31C0 File Offset: 0x00AC13C0
		// (set) Token: 0x0602D8B1 RID: 186545 RVA: 0x00AC31D0 File Offset: 0x00AC13D0
		public unsafe float 最大臂长
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCamera_Setting.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCamera_Setting.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17007CAE RID: 31918
		// (get) Token: 0x0602D8B2 RID: 186546 RVA: 0x00AC31E1 File Offset: 0x00AC13E1
		// (set) Token: 0x0602D8B3 RID: 186547 RVA: 0x00AC31F1 File Offset: 0x00AC13F1
		public unsafe float 最大臂长优先级
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCamera_Setting.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCamera_Setting.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17007CAF RID: 31919
		// (get) Token: 0x0602D8B4 RID: 186548 RVA: 0x00AC3202 File Offset: 0x00AC1402
		// (set) Token: 0x0602D8B5 RID: 186549 RVA: 0x00AC3212 File Offset: 0x00AC1412
		public unsafe float 最小臂长
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCamera_Setting.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCamera_Setting.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17007CB0 RID: 31920
		// (get) Token: 0x0602D8B6 RID: 186550 RVA: 0x00AC3223 File Offset: 0x00AC1423
		// (set) Token: 0x0602D8B7 RID: 186551 RVA: 0x00AC3233 File Offset: 0x00AC1433
		public unsafe float 最小臂长优先级
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCamera_Setting.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCamera_Setting.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17007CB1 RID: 31921
		// (get) Token: 0x0602D8B8 RID: 186552 RVA: 0x00AC3244 File Offset: 0x00AC1444
		// (set) Token: 0x0602D8B9 RID: 186553 RVA: 0x00AC3254 File Offset: 0x00AC1454
		public unsafe float 叠加臂长
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCamera_Setting.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCamera_Setting.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17007CB2 RID: 31922
		// (get) Token: 0x0602D8BA RID: 186554 RVA: 0x00AC3265 File Offset: 0x00AC1465
		// (set) Token: 0x0602D8BB RID: 186555 RVA: 0x00AC3279 File Offset: 0x00AC1479
		public unsafe FVector 镜头偏移
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCamera_Setting.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCamera_Setting.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17007CB3 RID: 31923
		// (get) Token: 0x0602D8BC RID: 186556 RVA: 0x00AC328E File Offset: 0x00AC148E
		// (set) Token: 0x0602D8BD RID: 186557 RVA: 0x00AC329E File Offset: 0x00AC149E
		public unsafe float 镜头偏移优先级
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCamera_Setting.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCamera_Setting.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17007CB4 RID: 31924
		// (get) Token: 0x0602D8BE RID: 186558 RVA: 0x00AC32AF File Offset: 0x00AC14AF
		// (set) Token: 0x0602D8BF RID: 186559 RVA: 0x00AC32C3 File Offset: 0x00AC14C3
		public unsafe FVector 相机臂偏移
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCamera_Setting.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCamera_Setting.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17007CB5 RID: 31925
		// (get) Token: 0x0602D8C0 RID: 186560 RVA: 0x00AC32D8 File Offset: 0x00AC14D8
		// (set) Token: 0x0602D8C1 RID: 186561 RVA: 0x00AC32E8 File Offset: 0x00AC14E8
		public unsafe float 相机臂偏移优先级
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCamera_Setting.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCamera_Setting.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17007CB6 RID: 31926
		// (get) Token: 0x0602D8C2 RID: 186562 RVA: 0x00AC32F9 File Offset: 0x00AC14F9
		// (set) Token: 0x0602D8C3 RID: 186563 RVA: 0x00AC3309 File Offset: 0x00AC1509
		public unsafe float 进入状态相机延迟速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCamera_Setting.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCamera_Setting.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17007CB7 RID: 31927
		// (get) Token: 0x0602D8C4 RID: 186564 RVA: 0x00AC331A File Offset: 0x00AC151A
		// (set) Token: 0x0602D8C5 RID: 186565 RVA: 0x00AC332A File Offset: 0x00AC152A
		public unsafe float 退出状态相机延迟速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCamera_Setting.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCamera_Setting.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17007CB8 RID: 31928
		// (get) Token: 0x0602D8C6 RID: 186566 RVA: 0x00AC333B File Offset: 0x00AC153B
		// (set) Token: 0x0602D8C7 RID: 186567 RVA: 0x00AC334B File Offset: 0x00AC154B
		public unsafe float 相机延迟速度优先级
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCamera_Setting.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCamera_Setting.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17007CB9 RID: 31929
		// (get) Token: 0x0602D8C8 RID: 186568 RVA: 0x00AC335C File Offset: 0x00AC155C
		// (set) Token: 0x0602D8C9 RID: 186569 RVA: 0x00AC336C File Offset: 0x00AC156C
		public unsafe float 最大延迟距离
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCamera_Setting.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCamera_Setting.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x17007CBA RID: 31930
		// (get) Token: 0x0602D8CA RID: 186570 RVA: 0x00AC337D File Offset: 0x00AC157D
		// (set) Token: 0x0602D8CB RID: 186571 RVA: 0x00AC338D File Offset: 0x00AC158D
		public unsafe float 最大延迟距离优先级
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCamera_Setting.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCamera_Setting.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x17007CBB RID: 31931
		// (get) Token: 0x0602D8CC RID: 186572 RVA: 0x00AC339E File Offset: 0x00AC159E
		// (set) Token: 0x0602D8CD RID: 186573 RVA: 0x00AC33AE File Offset: 0x00AC15AE
		public unsafe float FOV
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCamera_Setting.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCamera_Setting.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x17007CBC RID: 31932
		// (get) Token: 0x0602D8CE RID: 186574 RVA: 0x00AC33BF File Offset: 0x00AC15BF
		// (set) Token: 0x0602D8CF RID: 186575 RVA: 0x00AC33CF File Offset: 0x00AC15CF
		public unsafe float FOV优先级
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCamera_Setting.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCamera_Setting.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x17007CBD RID: 31933
		// (get) Token: 0x0602D8D0 RID: 186576 RVA: 0x00AC33E0 File Offset: 0x00AC15E0
		// (set) Token: 0x0602D8D1 RID: 186577 RVA: 0x00AC33F0 File Offset: 0x00AC15F0
		public unsafe float FadeInTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCamera_Setting.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCamera_Setting.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x17007CBE RID: 31934
		// (get) Token: 0x0602D8D2 RID: 186578 RVA: 0x00AC3401 File Offset: 0x00AC1601
		// (set) Token: 0x0602D8D3 RID: 186579 RVA: 0x00AC3411 File Offset: 0x00AC1611
		public unsafe float FadeOutTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCamera_Setting.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCamera_Setting.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x17007CBF RID: 31935
		// (get) Token: 0x0602D8D4 RID: 186580 RVA: 0x00AC3422 File Offset: 0x00AC1622
		// (set) Token: 0x0602D8D5 RID: 186581 RVA: 0x00AC3432 File Offset: 0x00AC1632
		public unsafe bool AutoCamera
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCamera_Setting.__PropertyOffset_22) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCamera_Setting.__PropertyOffset_22) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007CC0 RID: 31936
		// (get) Token: 0x0602D8D6 RID: 186582 RVA: 0x00AC3443 File Offset: 0x00AC1643
		// (set) Token: 0x0602D8D7 RID: 186583 RVA: 0x00AC3453 File Offset: 0x00AC1653
		public unsafe bool ModifyCamera
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCamera_Setting.__PropertyOffset_23) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCamera_Setting.__PropertyOffset_23) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007CC1 RID: 31937
		// (get) Token: 0x0602D8D8 RID: 186584 RVA: 0x00AC3464 File Offset: 0x00AC1664
		// (set) Token: 0x0602D8D9 RID: 186585 RVA: 0x00AC3474 File Offset: 0x00AC1674
		public unsafe bool AdjustCamera
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCamera_Setting.__PropertyOffset_24) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCamera_Setting.__PropertyOffset_24) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007CC2 RID: 31938
		// (get) Token: 0x0602D8DA RID: 186586 RVA: 0x00AC3485 File Offset: 0x00AC1685
		// (set) Token: 0x0602D8DB RID: 186587 RVA: 0x00AC3495 File Offset: 0x00AC1695
		public unsafe bool FocusCamera
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCamera_Setting.__PropertyOffset_25) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCamera_Setting.__PropertyOffset_25) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007CC3 RID: 31939
		// (get) Token: 0x0602D8DC RID: 186588 RVA: 0x00AC34A6 File Offset: 0x00AC16A6
		// (set) Token: 0x0602D8DD RID: 186589 RVA: 0x00AC34B6 File Offset: 0x00AC16B6
		public unsafe float 自动偏转最大角速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCamera_Setting.__PropertyOffset_26);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCamera_Setting.__PropertyOffset_26) = value;
			}
		}

		// Token: 0x17007CC4 RID: 31940
		// (get) Token: 0x0602D8DE RID: 186590 RVA: 0x00AC34C7 File Offset: 0x00AC16C7
		// (set) Token: 0x0602D8DF RID: 186591 RVA: 0x00AC34D7 File Offset: 0x00AC16D7
		public unsafe bool 是否启用自动俯仰角修正
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCamera_Setting.__PropertyOffset_27) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCamera_Setting.__PropertyOffset_27) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007CC5 RID: 31941
		// (get) Token: 0x0602D8E0 RID: 186592 RVA: 0x00AC34E8 File Offset: 0x00AC16E8
		// (set) Token: 0x0602D8E1 RID: 186593 RVA: 0x00AC352B File Offset: 0x00AC172B
		[Nullable(1)]
		public TArray<float> 自动俯仰角参数
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<float> result;
				if ((result = this._自动俯仰角参数) == null)
				{
					result = (this._自动俯仰角参数 = new TArray<float>(base.NativePtr + (IntPtr)SCamera_Setting.__PropertyOffset_28, base.MemoryOwner ?? this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.自动俯仰角参数.CopyAssign(value);
			}
		}

		// Token: 0x17007CC6 RID: 31942
		// (get) Token: 0x0602D8E2 RID: 186594 RVA: 0x00AC3539 File Offset: 0x00AC1739
		// (set) Token: 0x0602D8E3 RID: 186595 RVA: 0x00AC3549 File Offset: 0x00AC1749
		public unsafe float 自动俯仰角参数优先级
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCamera_Setting.__PropertyOffset_29);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCamera_Setting.__PropertyOffset_29) = value;
			}
		}

		// Token: 0x17007CC7 RID: 31943
		// (get) Token: 0x0602D8E4 RID: 186596 RVA: 0x00AC355A File Offset: 0x00AC175A
		// (set) Token: 0x0602D8E5 RID: 186597 RVA: 0x00AC356A File Offset: 0x00AC176A
		public unsafe float 锁定镜头偏角
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCamera_Setting.__PropertyOffset_30);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCamera_Setting.__PropertyOffset_30) = value;
			}
		}

		// Token: 0x17007CC8 RID: 31944
		// (get) Token: 0x0602D8E6 RID: 186598 RVA: 0x00AC357B File Offset: 0x00AC177B
		// (set) Token: 0x0602D8E7 RID: 186599 RVA: 0x00AC358B File Offset: 0x00AC178B
		public unsafe float 锁定镜头偏角优先级
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCamera_Setting.__PropertyOffset_31);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCamera_Setting.__PropertyOffset_31) = value;
			}
		}

		// Token: 0x17007CC9 RID: 31945
		// (get) Token: 0x0602D8E8 RID: 186600 RVA: 0x00AC359C File Offset: 0x00AC179C
		// (set) Token: 0x0602D8E9 RID: 186601 RVA: 0x00AC35AC File Offset: 0x00AC17AC
		public unsafe float 自动镜头额外臂水平偏移
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCamera_Setting.__PropertyOffset_32);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCamera_Setting.__PropertyOffset_32) = value;
			}
		}

		// Token: 0x17007CCA RID: 31946
		// (get) Token: 0x0602D8EA RID: 186602 RVA: 0x00AC35BD File Offset: 0x00AC17BD
		// (set) Token: 0x0602D8EB RID: 186603 RVA: 0x00AC35CD File Offset: 0x00AC17CD
		public unsafe float 自动镜头额外臂水平偏移优先级
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCamera_Setting.__PropertyOffset_33);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCamera_Setting.__PropertyOffset_33) = value;
			}
		}

		// Token: 0x0602D8EC RID: 186604 RVA: 0x00AC35DE File Offset: 0x00AC17DE
		public SCamera_Setting()
		{
		}

		// Token: 0x0602D8ED RID: 186605 RVA: 0x00AC35E8 File Offset: 0x00AC17E8
		public SCamera_Setting(TEnumAsByte<EFightCameraType> Type, FGameplayTag Tag, float 默认臂长, float 默认臂长优先级, float 最大臂长, float 最大臂长优先级, float 最小臂长, float 最小臂长优先级, float 叠加臂长, FVector 镜头偏移, float 镜头偏移优先级, FVector 相机臂偏移, float 相机臂偏移优先级, float 进入状态相机延迟速度, float 退出状态相机延迟速度, float 相机延迟速度优先级, float 最大延迟距离, float 最大延迟距离优先级, float FOV, float FOV优先级, float FadeInTime, float FadeOutTime, bool AutoCamera, bool ModifyCamera, bool AdjustCamera, bool FocusCamera, float 自动偏转最大角速度, bool 是否启用自动俯仰角修正, [Nullable(1)] TArray<float> 自动俯仰角参数, float 自动俯仰角参数优先级, float 锁定镜头偏角, float 锁定镜头偏角优先级, float 自动镜头额外臂水平偏移, float 自动镜头额外臂水平偏移优先级)
		{
			this.Type = Type;
			this.Tag = Tag;
			this.默认臂长 = 默认臂长;
			this.默认臂长优先级 = 默认臂长优先级;
			this.最大臂长 = 最大臂长;
			this.最大臂长优先级 = 最大臂长优先级;
			this.最小臂长 = 最小臂长;
			this.最小臂长优先级 = 最小臂长优先级;
			this.叠加臂长 = 叠加臂长;
			this.镜头偏移 = 镜头偏移;
			this.镜头偏移优先级 = 镜头偏移优先级;
			this.相机臂偏移 = 相机臂偏移;
			this.相机臂偏移优先级 = 相机臂偏移优先级;
			this.进入状态相机延迟速度 = 进入状态相机延迟速度;
			this.退出状态相机延迟速度 = 退出状态相机延迟速度;
			this.相机延迟速度优先级 = 相机延迟速度优先级;
			this.最大延迟距离 = 最大延迟距离;
			this.最大延迟距离优先级 = 最大延迟距离优先级;
			this.FOV = FOV;
			this.FOV优先级 = FOV优先级;
			this.FadeInTime = FadeInTime;
			this.FadeOutTime = FadeOutTime;
			this.AutoCamera = AutoCamera;
			this.ModifyCamera = ModifyCamera;
			this.AdjustCamera = AdjustCamera;
			this.FocusCamera = FocusCamera;
			this.自动偏转最大角速度 = 自动偏转最大角速度;
			this.是否启用自动俯仰角修正 = 是否启用自动俯仰角修正;
			this.自动俯仰角参数 = 自动俯仰角参数;
			this.自动俯仰角参数优先级 = 自动俯仰角参数优先级;
			this.锁定镜头偏角 = 锁定镜头偏角;
			this.锁定镜头偏角优先级 = 锁定镜头偏角优先级;
			this.自动镜头额外臂水平偏移 = 自动镜头额外臂水平偏移;
			this.自动镜头额外臂水平偏移优先级 = 自动镜头额外臂水平偏移优先级;
		}

		// Token: 0x0602D8EE RID: 186606 RVA: 0x00AC3708 File Offset: 0x00AC1908
		protected override IntPtr GetUStructPtr()
		{
			return SCamera_Setting.StaticStruct();
		}

		// Token: 0x0602D8EF RID: 186607 RVA: 0x00AC3714 File Offset: 0x00AC1914
		[NullableContext(2)]
		public SCamera_Setting(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602D8F0 RID: 186608 RVA: 0x00AC371E File Offset: 0x00AC191E
		public SCamera_Setting(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602D8F1 RID: 186609 RVA: 0x00AC3729 File Offset: 0x00AC1929
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SCamera_Setting(Pointer, false, true);
		}

		// Token: 0x0602D8F2 RID: 186610 RVA: 0x00AC3733 File Offset: 0x00AC1933
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SCamera_Setting(Pointer, MemoryOwner);
		}

		// Token: 0x04019AD9 RID: 105177
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Camera/SCamera_Setting.SCamera_Setting";

		// Token: 0x04019ADA RID: 105178
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04019ADB RID: 105179
		internal static int __PropertyOffset_0;

		// Token: 0x04019ADC RID: 105180
		internal static int __PropertyOffset_1;

		// Token: 0x04019ADD RID: 105181
		internal static int __PropertyOffset_2;

		// Token: 0x04019ADE RID: 105182
		internal static int __PropertyOffset_3;

		// Token: 0x04019ADF RID: 105183
		internal static int __PropertyOffset_4;

		// Token: 0x04019AE0 RID: 105184
		internal static int __PropertyOffset_5;

		// Token: 0x04019AE1 RID: 105185
		internal static int __PropertyOffset_6;

		// Token: 0x04019AE2 RID: 105186
		internal static int __PropertyOffset_7;

		// Token: 0x04019AE3 RID: 105187
		internal static int __PropertyOffset_8;

		// Token: 0x04019AE4 RID: 105188
		internal static int __PropertyOffset_9;

		// Token: 0x04019AE5 RID: 105189
		internal static int __PropertyOffset_10;

		// Token: 0x04019AE6 RID: 105190
		internal static int __PropertyOffset_11;

		// Token: 0x04019AE7 RID: 105191
		internal static int __PropertyOffset_12;

		// Token: 0x04019AE8 RID: 105192
		internal static int __PropertyOffset_13;

		// Token: 0x04019AE9 RID: 105193
		internal static int __PropertyOffset_14;

		// Token: 0x04019AEA RID: 105194
		internal static int __PropertyOffset_15;

		// Token: 0x04019AEB RID: 105195
		internal static int __PropertyOffset_16;

		// Token: 0x04019AEC RID: 105196
		internal static int __PropertyOffset_17;

		// Token: 0x04019AED RID: 105197
		internal static int __PropertyOffset_18;

		// Token: 0x04019AEE RID: 105198
		internal static int __PropertyOffset_19;

		// Token: 0x04019AEF RID: 105199
		internal static int __PropertyOffset_20;

		// Token: 0x04019AF0 RID: 105200
		internal static int __PropertyOffset_21;

		// Token: 0x04019AF1 RID: 105201
		internal static int __PropertyOffset_22;

		// Token: 0x04019AF2 RID: 105202
		internal static int __PropertyOffset_23;

		// Token: 0x04019AF3 RID: 105203
		internal static int __PropertyOffset_24;

		// Token: 0x04019AF4 RID: 105204
		internal static int __PropertyOffset_25;

		// Token: 0x04019AF5 RID: 105205
		internal static int __PropertyOffset_26;

		// Token: 0x04019AF6 RID: 105206
		internal static int __PropertyOffset_27;

		// Token: 0x04019AF7 RID: 105207
		internal static int __PropertyOffset_28;

		// Token: 0x04019AF8 RID: 105208
		[Nullable(2)]
		private TArray<float> _自动俯仰角参数;

		// Token: 0x04019AF9 RID: 105209
		internal static int __PropertyOffset_29;

		// Token: 0x04019AFA RID: 105210
		internal static int __PropertyOffset_30;

		// Token: 0x04019AFB RID: 105211
		internal static int __PropertyOffset_31;

		// Token: 0x04019AFC RID: 105212
		internal static int __PropertyOffset_32;

		// Token: 0x04019AFD RID: 105213
		internal static int __PropertyOffset_33;
	}
}
