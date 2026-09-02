using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Core;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.UI.Manager
{
	// Token: 0x02003990 RID: 14736
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/UI/Manager/BP_EventManager.BP_EventManager_C")]
	[UnrealStructLayout(632, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 632)]
	public class BP_EventManager_C : BP_ManagerBase_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601DB87 RID: 121735 RVA: 0x008DE77B File Offset: 0x008DC97B
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_EventManager_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/UI/Manager/BP_EventManager.BP_EventManager_C");
			}
			return BP_EventManager_C._ClassPtr;
		}

		// Token: 0x0601DB88 RID: 121736 RVA: 0x008DE7A0 File Offset: 0x008DC9A0
		public BP_EventManager_C() : this(BuiltinUtils.AllocNativeUObject(BP_EventManager_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601DB89 RID: 121737 RVA: 0x008DE7C8 File Offset: 0x008DC9C8
		public BP_EventManager_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_EventManager_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002755 RID: 10069
		// (get) Token: 0x0601DB8A RID: 121738 RVA: 0x008DE7FC File Offset: 0x008DC9FC
		// (set) Token: 0x0601DB8B RID: 121739 RVA: 0x008DE835 File Offset: 0x008DCA35
		public 界面生命周期改变 界面生命周期改变
		{
			get
			{
				base.FastCheckIsValid();
				界面生命周期改变 result;
				if ((result = this._界面生命周期改变) == null)
				{
					result = (this._界面生命周期改变 = new 界面生命周期改变(base.NativePtr + (IntPtr)BP_EventManager_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)BP_EventManager_C.__PropertyOffset_0, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x17002756 RID: 10070
		// (get) Token: 0x0601DB8C RID: 121740 RVA: 0x008DE858 File Offset: 0x008DCA58
		// (set) Token: 0x0601DB8D RID: 121741 RVA: 0x008DE891 File Offset: 0x008DCA91
		public 当有角色受击时 当有角色受击时
		{
			get
			{
				base.FastCheckIsValid();
				当有角色受击时 result;
				if ((result = this._当有角色受击时) == null)
				{
					result = (this._当有角色受击时 = new 当有角色受击时(base.NativePtr + (IntPtr)BP_EventManager_C.__PropertyOffset_1, this));
				}
				return result;
			}
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)BP_EventManager_C.__PropertyOffset_1, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x17002757 RID: 10071
		// (get) Token: 0x0601DB8E RID: 121742 RVA: 0x008DE8B4 File Offset: 0x008DCAB4
		// (set) Token: 0x0601DB8F RID: 121743 RVA: 0x008DE8ED File Offset: 0x008DCAED
		public 当解密界面打开时 当解密界面打开时
		{
			get
			{
				base.FastCheckIsValid();
				当解密界面打开时 result;
				if ((result = this._当解密界面打开时) == null)
				{
					result = (this._当解密界面打开时 = new 当解密界面打开时(base.NativePtr + (IntPtr)BP_EventManager_C.__PropertyOffset_2, this));
				}
				return result;
			}
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)BP_EventManager_C.__PropertyOffset_2, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x17002758 RID: 10072
		// (get) Token: 0x0601DB90 RID: 121744 RVA: 0x008DE910 File Offset: 0x008DCB10
		// (set) Token: 0x0601DB91 RID: 121745 RVA: 0x008DE949 File Offset: 0x008DCB49
		public 删除实体 删除实体
		{
			get
			{
				base.FastCheckIsValid();
				删除实体 result;
				if ((result = this._删除实体) == null)
				{
					result = (this._删除实体 = new 删除实体(base.NativePtr + (IntPtr)BP_EventManager_C.__PropertyOffset_3, this));
				}
				return result;
			}
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)BP_EventManager_C.__PropertyOffset_3, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x17002759 RID: 10073
		// (get) Token: 0x0601DB92 RID: 121746 RVA: 0x008DE96C File Offset: 0x008DCB6C
		// (set) Token: 0x0601DB93 RID: 121747 RVA: 0x008DE9A5 File Offset: 0x008DCBA5
		public WorldDoneNotify WorldDoneNotify
		{
			get
			{
				base.FastCheckIsValid();
				WorldDoneNotify result;
				if ((result = this._WorldDoneNotify) == null)
				{
					result = (this._WorldDoneNotify = new WorldDoneNotify(base.NativePtr + (IntPtr)BP_EventManager_C.__PropertyOffset_4, this));
				}
				return result;
			}
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)BP_EventManager_C.__PropertyOffset_4, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x1700275A RID: 10074
		// (get) Token: 0x0601DB94 RID: 121748 RVA: 0x008DE9C8 File Offset: 0x008DCBC8
		// (set) Token: 0x0601DB95 RID: 121749 RVA: 0x008DEA01 File Offset: 0x008DCC01
		public 增加实体 增加实体
		{
			get
			{
				base.FastCheckIsValid();
				增加实体 result;
				if ((result = this._增加实体) == null)
				{
					result = (this._增加实体 = new 增加实体(base.NativePtr + (IntPtr)BP_EventManager_C.__PropertyOffset_5, this));
				}
				return result;
			}
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)BP_EventManager_C.__PropertyOffset_5, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x1700275B RID: 10075
		// (get) Token: 0x0601DB96 RID: 121750 RVA: 0x008DEA24 File Offset: 0x008DCC24
		// (set) Token: 0x0601DB97 RID: 121751 RVA: 0x008DEA5D File Offset: 0x008DCC5D
		public 当换人完成时 当换人完成时
		{
			get
			{
				base.FastCheckIsValid();
				当换人完成时 result;
				if ((result = this._当换人完成时) == null)
				{
					result = (this._当换人完成时 = new 当换人完成时(base.NativePtr + (IntPtr)BP_EventManager_C.__PropertyOffset_6, this));
				}
				return result;
			}
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)BP_EventManager_C.__PropertyOffset_6, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x1700275C RID: 10076
		// (get) Token: 0x0601DB98 RID: 121752 RVA: 0x008DEA80 File Offset: 0x008DCC80
		// (set) Token: 0x0601DB99 RID: 121753 RVA: 0x008DEAB9 File Offset: 0x008DCCB9
		public 子弹命中前 子弹命中前
		{
			get
			{
				base.FastCheckIsValid();
				子弹命中前 result;
				if ((result = this._子弹命中前) == null)
				{
					result = (this._子弹命中前 = new 子弹命中前(base.NativePtr + (IntPtr)BP_EventManager_C.__PropertyOffset_7, this));
				}
				return result;
			}
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)BP_EventManager_C.__PropertyOffset_7, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x1700275D RID: 10077
		// (get) Token: 0x0601DB9A RID: 121754 RVA: 0x008DEADC File Offset: 0x008DCCDC
		// (set) Token: 0x0601DB9B RID: 121755 RVA: 0x008DEB15 File Offset: 0x008DCD15
		public 角色部位血量变化时 角色部位血量变化时
		{
			get
			{
				base.FastCheckIsValid();
				角色部位血量变化时 result;
				if ((result = this._角色部位血量变化时) == null)
				{
					result = (this._角色部位血量变化时 = new 角色部位血量变化时(base.NativePtr + (IntPtr)BP_EventManager_C.__PropertyOffset_8, this));
				}
				return result;
			}
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)BP_EventManager_C.__PropertyOffset_8, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x1700275E RID: 10078
		// (get) Token: 0x0601DB9C RID: 121756 RVA: 0x008DEB38 File Offset: 0x008DCD38
		// (set) Token: 0x0601DB9D RID: 121757 RVA: 0x008DEB71 File Offset: 0x008DCD71
		public 角色部位弱点打击时 角色部位弱点打击时
		{
			get
			{
				base.FastCheckIsValid();
				角色部位弱点打击时 result;
				if ((result = this._角色部位弱点打击时) == null)
				{
					result = (this._角色部位弱点打击时 = new 角色部位弱点打击时(base.NativePtr + (IntPtr)BP_EventManager_C.__PropertyOffset_9, this));
				}
				return result;
			}
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)BP_EventManager_C.__PropertyOffset_9, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x1700275F RID: 10079
		// (get) Token: 0x0601DB9E RID: 121758 RVA: 0x008DEB94 File Offset: 0x008DCD94
		// (set) Token: 0x0601DB9F RID: 121759 RVA: 0x008DEBCD File Offset: 0x008DCDCD
		public AI巡逻达到样条点 AI巡逻达到样条点
		{
			get
			{
				base.FastCheckIsValid();
				AI巡逻达到样条点 result;
				if ((result = this._AI巡逻达到样条点) == null)
				{
					result = (this._AI巡逻达到样条点 = new AI巡逻达到样条点(base.NativePtr + (IntPtr)BP_EventManager_C.__PropertyOffset_10, this));
				}
				return result;
			}
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)BP_EventManager_C.__PropertyOffset_10, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x17002760 RID: 10080
		// (get) Token: 0x0601DBA0 RID: 121760 RVA: 0x008DEBF0 File Offset: 0x008DCDF0
		// (set) Token: 0x0601DBA1 RID: 121761 RVA: 0x008DEC29 File Offset: 0x008DCE29
		public 被控物广播 被控物广播
		{
			get
			{
				base.FastCheckIsValid();
				被控物广播 result;
				if ((result = this._被控物广播) == null)
				{
					result = (this._被控物广播 = new 被控物广播(base.NativePtr + (IntPtr)BP_EventManager_C.__PropertyOffset_11, this));
				}
				return result;
			}
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)BP_EventManager_C.__PropertyOffset_11, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x17002761 RID: 10081
		// (get) Token: 0x0601DBA2 RID: 121762 RVA: 0x008DEC4C File Offset: 0x008DCE4C
		// (set) Token: 0x0601DBA3 RID: 121763 RVA: 0x008DEC85 File Offset: 0x008DCE85
		public CaughtEntity CaughtEntity
		{
			get
			{
				base.FastCheckIsValid();
				CaughtEntity result;
				if ((result = this._CaughtEntity) == null)
				{
					result = (this._CaughtEntity = new CaughtEntity(base.NativePtr + (IntPtr)BP_EventManager_C.__PropertyOffset_12, this));
				}
				return result;
			}
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)BP_EventManager_C.__PropertyOffset_12, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x17002762 RID: 10082
		// (get) Token: 0x0601DBA4 RID: 121764 RVA: 0x008DECA8 File Offset: 0x008DCEA8
		// (set) Token: 0x0601DBA5 RID: 121765 RVA: 0x008DECE1 File Offset: 0x008DCEE1
		public 角色状态切换时 角色状态切换时
		{
			get
			{
				base.FastCheckIsValid();
				角色状态切换时 result;
				if ((result = this._角色状态切换时) == null)
				{
					result = (this._角色状态切换时 = new 角色状态切换时(base.NativePtr + (IntPtr)BP_EventManager_C.__PropertyOffset_13, this));
				}
				return result;
			}
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)BP_EventManager_C.__PropertyOffset_13, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x17002763 RID: 10083
		// (get) Token: 0x0601DBA6 RID: 121766 RVA: 0x008DED04 File Offset: 0x008DCF04
		// (set) Token: 0x0601DBA7 RID: 121767 RVA: 0x008DED3D File Offset: 0x008DCF3D
		public 当触发对策事件时 当触发对策事件时
		{
			get
			{
				base.FastCheckIsValid();
				当触发对策事件时 result;
				if ((result = this._当触发对策事件时) == null)
				{
					result = (this._当触发对策事件时 = new 当触发对策事件时(base.NativePtr + (IntPtr)BP_EventManager_C.__PropertyOffset_14, this));
				}
				return result;
			}
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)BP_EventManager_C.__PropertyOffset_14, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x17002764 RID: 10084
		// (get) Token: 0x0601DBA8 RID: 121768 RVA: 0x008DED60 File Offset: 0x008DCF60
		// (set) Token: 0x0601DBA9 RID: 121769 RVA: 0x008DED99 File Offset: 0x008DCF99
		public 当有角色死亡时 当有角色死亡时
		{
			get
			{
				base.FastCheckIsValid();
				当有角色死亡时 result;
				if ((result = this._当有角色死亡时) == null)
				{
					result = (this._当有角色死亡时 = new 当有角色死亡时(base.NativePtr + (IntPtr)BP_EventManager_C.__PropertyOffset_15, this));
				}
				return result;
			}
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)BP_EventManager_C.__PropertyOffset_15, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x17002765 RID: 10085
		// (get) Token: 0x0601DBAA RID: 121770 RVA: 0x008DEDBC File Offset: 0x008DCFBC
		// (set) Token: 0x0601DBAB RID: 121771 RVA: 0x008DEDF5 File Offset: 0x008DCFF5
		public 小队战斗状态改变时 小队战斗状态改变时
		{
			get
			{
				base.FastCheckIsValid();
				小队战斗状态改变时 result;
				if ((result = this._小队战斗状态改变时) == null)
				{
					result = (this._小队战斗状态改变时 = new 小队战斗状态改变时(base.NativePtr + (IntPtr)BP_EventManager_C.__PropertyOffset_16, this));
				}
				return result;
			}
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)BP_EventManager_C.__PropertyOffset_16, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x17002766 RID: 10086
		// (get) Token: 0x0601DBAC RID: 121772 RVA: 0x008DEE18 File Offset: 0x008DD018
		// (set) Token: 0x0601DBAD RID: 121773 RVA: 0x008DEE51 File Offset: 0x008DD051
		public 小队技能目标改变时 小队技能目标改变时
		{
			get
			{
				base.FastCheckIsValid();
				小队技能目标改变时 result;
				if ((result = this._小队技能目标改变时) == null)
				{
					result = (this._小队技能目标改变时 = new 小队技能目标改变时(base.NativePtr + (IntPtr)BP_EventManager_C.__PropertyOffset_17, this));
				}
				return result;
			}
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)BP_EventManager_C.__PropertyOffset_17, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x17002767 RID: 10087
		// (get) Token: 0x0601DBAE RID: 121774 RVA: 0x008DEE74 File Offset: 0x008DD074
		// (set) Token: 0x0601DBAF RID: 121775 RVA: 0x008DEEAD File Offset: 0x008DD0AD
		public 抓取目标成功时 抓取目标成功时
		{
			get
			{
				base.FastCheckIsValid();
				抓取目标成功时 result;
				if ((result = this._抓取目标成功时) == null)
				{
					result = (this._抓取目标成功时 = new 抓取目标成功时(base.NativePtr + (IntPtr)BP_EventManager_C.__PropertyOffset_18, this));
				}
				return result;
			}
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)BP_EventManager_C.__PropertyOffset_18, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x17002768 RID: 10088
		// (get) Token: 0x0601DBB0 RID: 121776 RVA: 0x008DEED0 File Offset: 0x008DD0D0
		// (set) Token: 0x0601DBB1 RID: 121777 RVA: 0x008DEF09 File Offset: 0x008DD109
		public 材质播放结束时 材质播放结束时
		{
			get
			{
				base.FastCheckIsValid();
				材质播放结束时 result;
				if ((result = this._材质播放结束时) == null)
				{
					result = (this._材质播放结束时 = new 材质播放结束时(base.NativePtr + (IntPtr)BP_EventManager_C.__PropertyOffset_19, this));
				}
				return result;
			}
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)BP_EventManager_C.__PropertyOffset_19, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x17002769 RID: 10089
		// (get) Token: 0x0601DBB2 RID: 121778 RVA: 0x008DEF2C File Offset: 0x008DD12C
		// (set) Token: 0x0601DBB3 RID: 121779 RVA: 0x008DEF65 File Offset: 0x008DD165
		public 当编队更新时 当编队更新时
		{
			get
			{
				base.FastCheckIsValid();
				当编队更新时 result;
				if ((result = this._当编队更新时) == null)
				{
					result = (this._当编队更新时 = new 当编队更新时(base.NativePtr + (IntPtr)BP_EventManager_C.__PropertyOffset_20, this));
				}
				return result;
			}
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)BP_EventManager_C.__PropertyOffset_20, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x1700276A RID: 10090
		// (get) Token: 0x0601DBB4 RID: 121780 RVA: 0x008DEF88 File Offset: 0x008DD188
		// (set) Token: 0x0601DBB5 RID: 121781 RVA: 0x008DEFC1 File Offset: 0x008DD1C1
		public OnEnterPhotograph OnEnterPhotograph
		{
			get
			{
				base.FastCheckIsValid();
				OnEnterPhotograph result;
				if ((result = this._OnEnterPhotograph) == null)
				{
					result = (this._OnEnterPhotograph = new OnEnterPhotograph(base.NativePtr + (IntPtr)BP_EventManager_C.__PropertyOffset_21, this));
				}
				return result;
			}
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)BP_EventManager_C.__PropertyOffset_21, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x1700276B RID: 10091
		// (get) Token: 0x0601DBB6 RID: 121782 RVA: 0x008DEFE4 File Offset: 0x008DD1E4
		// (set) Token: 0x0601DBB7 RID: 121783 RVA: 0x008DF01D File Offset: 0x008DD21D
		public OnExitPhotograph OnExitPhotograph
		{
			get
			{
				base.FastCheckIsValid();
				OnExitPhotograph result;
				if ((result = this._OnExitPhotograph) == null)
				{
					result = (this._OnExitPhotograph = new OnExitPhotograph(base.NativePtr + (IntPtr)BP_EventManager_C.__PropertyOffset_22, this));
				}
				return result;
			}
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)BP_EventManager_C.__PropertyOffset_22, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x1700276C RID: 10092
		// (get) Token: 0x0601DBB8 RID: 121784 RVA: 0x008DF040 File Offset: 0x008DD240
		// (set) Token: 0x0601DBB9 RID: 121785 RVA: 0x008DF079 File Offset: 0x008DD279
		public 被控物撞到水面时 被控物撞到水面时
		{
			get
			{
				base.FastCheckIsValid();
				被控物撞到水面时 result;
				if ((result = this._被控物撞到水面时) == null)
				{
					result = (this._被控物撞到水面时 = new 被控物撞到水面时(base.NativePtr + (IntPtr)BP_EventManager_C.__PropertyOffset_23, this));
				}
				return result;
			}
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)BP_EventManager_C.__PropertyOffset_23, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x1700276D RID: 10093
		// (get) Token: 0x0601DBBA RID: 121786 RVA: 0x008DF09C File Offset: 0x008DD29C
		// (set) Token: 0x0601DBBB RID: 121787 RVA: 0x008DF0D5 File Offset: 0x008DD2D5
		public 开始吸取污染物 开始吸取污染物
		{
			get
			{
				base.FastCheckIsValid();
				开始吸取污染物 result;
				if ((result = this._开始吸取污染物) == null)
				{
					result = (this._开始吸取污染物 = new 开始吸取污染物(base.NativePtr + (IntPtr)BP_EventManager_C.__PropertyOffset_24, this));
				}
				return result;
			}
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)BP_EventManager_C.__PropertyOffset_24, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x1700276E RID: 10094
		// (get) Token: 0x0601DBBC RID: 121788 RVA: 0x008DF0F8 File Offset: 0x008DD2F8
		// (set) Token: 0x0601DBBD RID: 121789 RVA: 0x008DF131 File Offset: 0x008DD331
		public 停止吸取污染物 停止吸取污染物
		{
			get
			{
				base.FastCheckIsValid();
				停止吸取污染物 result;
				if ((result = this._停止吸取污染物) == null)
				{
					result = (this._停止吸取污染物 = new 停止吸取污染物(base.NativePtr + (IntPtr)BP_EventManager_C.__PropertyOffset_25, this));
				}
				return result;
			}
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)BP_EventManager_C.__PropertyOffset_25, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x1700276F RID: 10095
		// (get) Token: 0x0601DBBE RID: 121790 RVA: 0x008DF154 File Offset: 0x008DD354
		// (set) Token: 0x0601DBBF RID: 121791 RVA: 0x008DF18D File Offset: 0x008DD38D
		public 当捕鱼船创建时 当捕鱼船创建时
		{
			get
			{
				base.FastCheckIsValid();
				当捕鱼船创建时 result;
				if ((result = this._当捕鱼船创建时) == null)
				{
					result = (this._当捕鱼船创建时 = new 当捕鱼船创建时(base.NativePtr + (IntPtr)BP_EventManager_C.__PropertyOffset_26, this));
				}
				return result;
			}
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)BP_EventManager_C.__PropertyOffset_26, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x17002770 RID: 10096
		// (get) Token: 0x0601DBC0 RID: 121792 RVA: 0x008DF1B0 File Offset: 0x008DD3B0
		// (set) Token: 0x0601DBC1 RID: 121793 RVA: 0x008DF1E9 File Offset: 0x008DD3E9
		public 子弹撞到水面时 子弹撞到水面时
		{
			get
			{
				base.FastCheckIsValid();
				子弹撞到水面时 result;
				if ((result = this._子弹撞到水面时) == null)
				{
					result = (this._子弹撞到水面时 = new 子弹撞到水面时(base.NativePtr + (IntPtr)BP_EventManager_C.__PropertyOffset_27, this));
				}
				return result;
			}
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)BP_EventManager_C.__PropertyOffset_27, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x17002771 RID: 10097
		// (get) Token: 0x0601DBC2 RID: 121794 RVA: 0x008DF20C File Offset: 0x008DD40C
		// (set) Token: 0x0601DBC3 RID: 121795 RVA: 0x008DF245 File Offset: 0x008DD445
		public 当有角色复活时 当有角色复活时
		{
			get
			{
				base.FastCheckIsValid();
				当有角色复活时 result;
				if ((result = this._当有角色复活时) == null)
				{
					result = (this._当有角色复活时 = new 当有角色复活时(base.NativePtr + (IntPtr)BP_EventManager_C.__PropertyOffset_28, this));
				}
				return result;
			}
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)BP_EventManager_C.__PropertyOffset_28, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x17002772 RID: 10098
		// (get) Token: 0x0601DBC4 RID: 121796 RVA: 0x008DF268 File Offset: 0x008DD468
		// (set) Token: 0x0601DBC5 RID: 121797 RVA: 0x008DF2A1 File Offset: 0x008DD4A1
		public 武器交互场景时 武器交互场景时
		{
			get
			{
				base.FastCheckIsValid();
				武器交互场景时 result;
				if ((result = this._武器交互场景时) == null)
				{
					result = (this._武器交互场景时 = new 武器交互场景时(base.NativePtr + (IntPtr)BP_EventManager_C.__PropertyOffset_29, this));
				}
				return result;
			}
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)BP_EventManager_C.__PropertyOffset_29, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x17002773 RID: 10099
		// (get) Token: 0x0601DBC6 RID: 121798 RVA: 0x008DF2C4 File Offset: 0x008DD4C4
		// (set) Token: 0x0601DBC7 RID: 121799 RVA: 0x008DF2FD File Offset: 0x008DD4FD
		public 当浮游炮瞄准可以自动开炮时 当浮游炮瞄准可以自动开炮时
		{
			get
			{
				base.FastCheckIsValid();
				当浮游炮瞄准可以自动开炮时 result;
				if ((result = this._当浮游炮瞄准可以自动开炮时) == null)
				{
					result = (this._当浮游炮瞄准可以自动开炮时 = new 当浮游炮瞄准可以自动开炮时(base.NativePtr + (IntPtr)BP_EventManager_C.__PropertyOffset_30, this));
				}
				return result;
			}
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)BP_EventManager_C.__PropertyOffset_30, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x17002774 RID: 10100
		// (get) Token: 0x0601DBC8 RID: 121800 RVA: 0x008DF320 File Offset: 0x008DD520
		// (set) Token: 0x0601DBC9 RID: 121801 RVA: 0x008DF359 File Offset: 0x008DD559
		public 音乐节拍事件触发时 音乐节拍事件触发时
		{
			get
			{
				base.FastCheckIsValid();
				音乐节拍事件触发时 result;
				if ((result = this._音乐节拍事件触发时) == null)
				{
					result = (this._音乐节拍事件触发时 = new 音乐节拍事件触发时(base.NativePtr + (IntPtr)BP_EventManager_C.__PropertyOffset_31, this));
				}
				return result;
			}
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)BP_EventManager_C.__PropertyOffset_31, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x17002775 RID: 10101
		// (get) Token: 0x0601DBCA RID: 121802 RVA: 0x008DF37C File Offset: 0x008DD57C
		// (set) Token: 0x0601DBCB RID: 121803 RVA: 0x008DF3B5 File Offset: 0x008DD5B5
		public 当触发结算镜头时 当触发结算镜头时
		{
			get
			{
				base.FastCheckIsValid();
				当触发结算镜头时 result;
				if ((result = this._当触发结算镜头时) == null)
				{
					result = (this._当触发结算镜头时 = new 当触发结算镜头时(base.NativePtr + (IntPtr)BP_EventManager_C.__PropertyOffset_32, this));
				}
				return result;
			}
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)BP_EventManager_C.__PropertyOffset_32, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x17002776 RID: 10102
		// (get) Token: 0x0601DBCC RID: 121804 RVA: 0x008DF3D8 File Offset: 0x008DD5D8
		// (set) Token: 0x0601DBCD RID: 121805 RVA: 0x008DF411 File Offset: 0x008DD611
		public 当触发相机注视时 当触发相机注视时
		{
			get
			{
				base.FastCheckIsValid();
				当触发相机注视时 result;
				if ((result = this._当触发相机注视时) == null)
				{
					result = (this._当触发相机注视时 = new 当触发相机注视时(base.NativePtr + (IntPtr)BP_EventManager_C.__PropertyOffset_33, this));
				}
				return result;
			}
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)BP_EventManager_C.__PropertyOffset_33, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x17002777 RID: 10103
		// (get) Token: 0x0601DBCE RID: 121806 RVA: 0x008DF434 File Offset: 0x008DD634
		// (set) Token: 0x0601DBCF RID: 121807 RVA: 0x008DF46D File Offset: 0x008DD66D
		public 演出状态改变时 演出状态改变时
		{
			get
			{
				base.FastCheckIsValid();
				演出状态改变时 result;
				if ((result = this._演出状态改变时) == null)
				{
					result = (this._演出状态改变时 = new 演出状态改变时(base.NativePtr + (IntPtr)BP_EventManager_C.__PropertyOffset_34, this));
				}
				return result;
			}
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)BP_EventManager_C.__PropertyOffset_34, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x0601DBD0 RID: 121808 RVA: 0x008DF48E File Offset: 0x008DD68E
		protected BP_EventManager_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400E8F3 RID: 59635
		public new const string __ObjectPath = "/Game/Aki/UI/Manager/BP_EventManager.BP_EventManager_C";

		// Token: 0x0400E8F4 RID: 59636
		private static IntPtr _ClassPtr;

		// Token: 0x0400E8F5 RID: 59637
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400E8F6 RID: 59638
		public static IntPtr __演出状态改变时__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0400E8F7 RID: 59639
		public static IntPtr __当触发相机注视时__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0400E8F8 RID: 59640
		public static IntPtr __当触发结算镜头时__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0400E8F9 RID: 59641
		public static IntPtr __音乐节拍事件触发时__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0400E8FA RID: 59642
		public static IntPtr __当浮游炮瞄准可以自动开炮时__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0400E8FB RID: 59643
		public static IntPtr __武器交互场景时__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0400E8FC RID: 59644
		public static IntPtr __当有角色复活时__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0400E8FD RID: 59645
		public static IntPtr __子弹撞到水面时__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0400E8FE RID: 59646
		public static IntPtr __当捕鱼船创建时__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0400E8FF RID: 59647
		public static IntPtr __停止吸取污染物__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0400E900 RID: 59648
		public static IntPtr __开始吸取污染物__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0400E901 RID: 59649
		public static IntPtr __被控物撞到水面时__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0400E902 RID: 59650
		public static IntPtr __OnExitPhotograph__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0400E903 RID: 59651
		public static IntPtr __OnEnterPhotograph__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0400E904 RID: 59652
		public static IntPtr __当编队更新时__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0400E905 RID: 59653
		public static IntPtr __材质播放结束时__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0400E906 RID: 59654
		public static IntPtr __抓取目标成功时__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0400E907 RID: 59655
		public static IntPtr __小队技能目标改变时__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0400E908 RID: 59656
		public static IntPtr __小队战斗状态改变时__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0400E909 RID: 59657
		public static IntPtr __当有角色死亡时__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0400E90A RID: 59658
		public static IntPtr __当触发对策事件时__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0400E90B RID: 59659
		public static IntPtr __角色状态切换时__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0400E90C RID: 59660
		public static IntPtr __CaughtEntity__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0400E90D RID: 59661
		public static IntPtr __被控物广播__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0400E90E RID: 59662
		public static IntPtr __AI巡逻达到样条点__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0400E90F RID: 59663
		public static IntPtr __角色部位弱点打击时__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0400E910 RID: 59664
		public static IntPtr __角色部位血量变化时__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0400E911 RID: 59665
		public static IntPtr __子弹命中前__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0400E912 RID: 59666
		public static IntPtr __当换人完成时__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0400E913 RID: 59667
		public static IntPtr __增加实体__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0400E914 RID: 59668
		public static IntPtr __WorldDoneNotify__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0400E915 RID: 59669
		public static IntPtr __删除实体__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0400E916 RID: 59670
		public static IntPtr __当解密界面打开时__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0400E917 RID: 59671
		public static IntPtr __当有角色受击时__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0400E918 RID: 59672
		public static IntPtr __界面生命周期改变__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0400E919 RID: 59673
		internal new static int __PropertyOffset_0;

		// Token: 0x0400E91A RID: 59674
		[Nullable(2)]
		private 界面生命周期改变 _界面生命周期改变;

		// Token: 0x0400E91B RID: 59675
		internal new static int __PropertyOffset_1;

		// Token: 0x0400E91C RID: 59676
		[Nullable(2)]
		private 当有角色受击时 _当有角色受击时;

		// Token: 0x0400E91D RID: 59677
		internal new static int __PropertyOffset_2;

		// Token: 0x0400E91E RID: 59678
		[Nullable(2)]
		private 当解密界面打开时 _当解密界面打开时;

		// Token: 0x0400E91F RID: 59679
		internal static int __PropertyOffset_3;

		// Token: 0x0400E920 RID: 59680
		[Nullable(2)]
		private 删除实体 _删除实体;

		// Token: 0x0400E921 RID: 59681
		internal static int __PropertyOffset_4;

		// Token: 0x0400E922 RID: 59682
		[Nullable(2)]
		private WorldDoneNotify _WorldDoneNotify;

		// Token: 0x0400E923 RID: 59683
		internal static int __PropertyOffset_5;

		// Token: 0x0400E924 RID: 59684
		[Nullable(2)]
		private 增加实体 _增加实体;

		// Token: 0x0400E925 RID: 59685
		internal static int __PropertyOffset_6;

		// Token: 0x0400E926 RID: 59686
		[Nullable(2)]
		private 当换人完成时 _当换人完成时;

		// Token: 0x0400E927 RID: 59687
		internal static int __PropertyOffset_7;

		// Token: 0x0400E928 RID: 59688
		[Nullable(2)]
		private 子弹命中前 _子弹命中前;

		// Token: 0x0400E929 RID: 59689
		internal static int __PropertyOffset_8;

		// Token: 0x0400E92A RID: 59690
		[Nullable(2)]
		private 角色部位血量变化时 _角色部位血量变化时;

		// Token: 0x0400E92B RID: 59691
		internal static int __PropertyOffset_9;

		// Token: 0x0400E92C RID: 59692
		[Nullable(2)]
		private 角色部位弱点打击时 _角色部位弱点打击时;

		// Token: 0x0400E92D RID: 59693
		internal static int __PropertyOffset_10;

		// Token: 0x0400E92E RID: 59694
		[Nullable(2)]
		private AI巡逻达到样条点 _AI巡逻达到样条点;

		// Token: 0x0400E92F RID: 59695
		internal static int __PropertyOffset_11;

		// Token: 0x0400E930 RID: 59696
		[Nullable(2)]
		private 被控物广播 _被控物广播;

		// Token: 0x0400E931 RID: 59697
		internal static int __PropertyOffset_12;

		// Token: 0x0400E932 RID: 59698
		[Nullable(2)]
		private CaughtEntity _CaughtEntity;

		// Token: 0x0400E933 RID: 59699
		internal static int __PropertyOffset_13;

		// Token: 0x0400E934 RID: 59700
		[Nullable(2)]
		private 角色状态切换时 _角色状态切换时;

		// Token: 0x0400E935 RID: 59701
		internal static int __PropertyOffset_14;

		// Token: 0x0400E936 RID: 59702
		[Nullable(2)]
		private 当触发对策事件时 _当触发对策事件时;

		// Token: 0x0400E937 RID: 59703
		internal static int __PropertyOffset_15;

		// Token: 0x0400E938 RID: 59704
		[Nullable(2)]
		private 当有角色死亡时 _当有角色死亡时;

		// Token: 0x0400E939 RID: 59705
		internal static int __PropertyOffset_16;

		// Token: 0x0400E93A RID: 59706
		[Nullable(2)]
		private 小队战斗状态改变时 _小队战斗状态改变时;

		// Token: 0x0400E93B RID: 59707
		internal static int __PropertyOffset_17;

		// Token: 0x0400E93C RID: 59708
		[Nullable(2)]
		private 小队技能目标改变时 _小队技能目标改变时;

		// Token: 0x0400E93D RID: 59709
		internal static int __PropertyOffset_18;

		// Token: 0x0400E93E RID: 59710
		[Nullable(2)]
		private 抓取目标成功时 _抓取目标成功时;

		// Token: 0x0400E93F RID: 59711
		internal static int __PropertyOffset_19;

		// Token: 0x0400E940 RID: 59712
		[Nullable(2)]
		private 材质播放结束时 _材质播放结束时;

		// Token: 0x0400E941 RID: 59713
		internal static int __PropertyOffset_20;

		// Token: 0x0400E942 RID: 59714
		[Nullable(2)]
		private 当编队更新时 _当编队更新时;

		// Token: 0x0400E943 RID: 59715
		internal static int __PropertyOffset_21;

		// Token: 0x0400E944 RID: 59716
		[Nullable(2)]
		private OnEnterPhotograph _OnEnterPhotograph;

		// Token: 0x0400E945 RID: 59717
		internal static int __PropertyOffset_22;

		// Token: 0x0400E946 RID: 59718
		[Nullable(2)]
		private OnExitPhotograph _OnExitPhotograph;

		// Token: 0x0400E947 RID: 59719
		internal static int __PropertyOffset_23;

		// Token: 0x0400E948 RID: 59720
		[Nullable(2)]
		private 被控物撞到水面时 _被控物撞到水面时;

		// Token: 0x0400E949 RID: 59721
		internal static int __PropertyOffset_24;

		// Token: 0x0400E94A RID: 59722
		[Nullable(2)]
		private 开始吸取污染物 _开始吸取污染物;

		// Token: 0x0400E94B RID: 59723
		internal static int __PropertyOffset_25;

		// Token: 0x0400E94C RID: 59724
		[Nullable(2)]
		private 停止吸取污染物 _停止吸取污染物;

		// Token: 0x0400E94D RID: 59725
		internal static int __PropertyOffset_26;

		// Token: 0x0400E94E RID: 59726
		[Nullable(2)]
		private 当捕鱼船创建时 _当捕鱼船创建时;

		// Token: 0x0400E94F RID: 59727
		internal static int __PropertyOffset_27;

		// Token: 0x0400E950 RID: 59728
		[Nullable(2)]
		private 子弹撞到水面时 _子弹撞到水面时;

		// Token: 0x0400E951 RID: 59729
		internal static int __PropertyOffset_28;

		// Token: 0x0400E952 RID: 59730
		[Nullable(2)]
		private 当有角色复活时 _当有角色复活时;

		// Token: 0x0400E953 RID: 59731
		internal static int __PropertyOffset_29;

		// Token: 0x0400E954 RID: 59732
		[Nullable(2)]
		private 武器交互场景时 _武器交互场景时;

		// Token: 0x0400E955 RID: 59733
		internal static int __PropertyOffset_30;

		// Token: 0x0400E956 RID: 59734
		[Nullable(2)]
		private 当浮游炮瞄准可以自动开炮时 _当浮游炮瞄准可以自动开炮时;

		// Token: 0x0400E957 RID: 59735
		internal static int __PropertyOffset_31;

		// Token: 0x0400E958 RID: 59736
		[Nullable(2)]
		private 音乐节拍事件触发时 _音乐节拍事件触发时;

		// Token: 0x0400E959 RID: 59737
		internal static int __PropertyOffset_32;

		// Token: 0x0400E95A RID: 59738
		[Nullable(2)]
		private 当触发结算镜头时 _当触发结算镜头时;

		// Token: 0x0400E95B RID: 59739
		internal static int __PropertyOffset_33;

		// Token: 0x0400E95C RID: 59740
		[Nullable(2)]
		private 当触发相机注视时 _当触发相机注视时;

		// Token: 0x0400E95D RID: 59741
		internal static int __PropertyOffset_34;

		// Token: 0x0400E95E RID: 59742
		[Nullable(2)]
		private 演出状态改变时 _演出状态改变时;
	}
}
