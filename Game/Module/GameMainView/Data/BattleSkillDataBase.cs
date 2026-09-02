using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Input;
using CSharpScript.Game.Module.Battle;
using CSharpScript.Game.Module.BattleUi.Views;
using CSharpScript.Game.Module.SkillButtonUi;
using UnrealEngine;

namespace CSharpScript.Game.Module.GameMainView.Data
{
	// Token: 0x02005D16 RID: 23830
	[NullableContext(2)]
	[Nullable(0)]
	public abstract class BattleSkillDataBase : ISkillButtonData
	{
		// Token: 0x17009867 RID: 39015
		// (get) Token: 0x0603C102 RID: 246018 RVA: 0x00F3C41A File Offset: 0x00F3A61A
		public bool IsExploreAsFight { get; }

		// Token: 0x17009868 RID: 39016
		// (get) Token: 0x0603C103 RID: 246019 RVA: 0x00F3C422 File Offset: 0x00F3A622
		public ESkillButtonAttributeUsageMode AttributeUsageMode { get; }

		// Token: 0x17009869 RID: 39017
		// (get) Token: 0x0603C104 RID: 246020 RVA: 0x00F3C42A File Offset: 0x00F3A62A
		public int[] AttributeUsageParams { get; }

		// Token: 0x1700986A RID: 39018
		// (get) Token: 0x0603C105 RID: 246021 RVA: 0x00F3C432 File Offset: 0x00F3A632
		public EAttributeType AttributeId { get; }

		// Token: 0x1700986B RID: 39019
		// (get) Token: 0x0603C106 RID: 246022 RVA: 0x00F3C43A File Offset: 0x00F3A63A
		public bool IsEnableSlideControl { get; }

		// Token: 0x1700986C RID: 39020
		// (get) Token: 0x0603C107 RID: 246023 RVA: 0x00F3C442 File Offset: 0x00F3A642
		public bool IsLimitCountCustom { get; }

		// Token: 0x1700986D RID: 39021
		// (get) Token: 0x0603C108 RID: 246024 RVA: 0x00F3C44A File Offset: 0x00F3A64A
		public int RemainingCountCustom { get; }

		// Token: 0x1700986E RID: 39022
		// (get) Token: 0x0603C109 RID: 246025 RVA: 0x00F3C452 File Offset: 0x00F3A652
		public int TotalCoolDownCustom { get; }

		// Token: 0x1700986F RID: 39023
		// (get) Token: 0x0603C10A RID: 246026 RVA: 0x00F3C45A File Offset: 0x00F3A65A
		public bool HideCoolDownTextCustom { get; }

		// Token: 0x17009870 RID: 39024
		// (get) Token: 0x0603C10B RID: 246027 RVA: 0x00F3C462 File Offset: 0x00F3A662
		public bool IsLimitCountVehicleSkill { get; }

		// Token: 0x17009871 RID: 39025
		// (get) Token: 0x0603C10C RID: 246028 RVA: 0x00F3C46A File Offset: 0x00F3A66A
		public int RemainingCountVehicleSkill { get; }

		// Token: 0x17009872 RID: 39026
		// (get) Token: 0x0603C10D RID: 246029 RVA: 0x00F3C472 File Offset: 0x00F3A672
		public EInputAction[] SharedHoldRingFxActions { get; }

		// Token: 0x17009873 RID: 39027
		// (get) Token: 0x0603C10E RID: 246030 RVA: 0x00F3C47A File Offset: 0x00F3A67A
		public bool IsEnableDotIndicator { get; }

		// Token: 0x17009874 RID: 39028
		// (get) Token: 0x0603C10F RID: 246031 RVA: 0x00F3C482 File Offset: 0x00F3A682
		public int DotIndicatorCount { get; }

		// Token: 0x0603C110 RID: 246032 RVA: 0x00F3C48A File Offset: 0x00F3A68A
		[NullableContext(1)]
		public void InitData(string actionName)
		{
			this.ActionName = actionName;
			this.OnInitData();
		}

		// Token: 0x0603C111 RID: 246033 RVA: 0x00F3C499 File Offset: 0x00F3A699
		protected virtual void OnInitData()
		{
		}

		// Token: 0x0603C112 RID: 246034 RVA: 0x00F3C49B File Offset: 0x00F3A69B
		public virtual EInputAction GetActionType()
		{
			return EInputAction.None;
		}

		// Token: 0x0603C113 RID: 246035 RVA: 0x00F3C4A2 File Offset: 0x00F3A6A2
		[NullableContext(1)]
		public string GetInputAction()
		{
			return this.GetActionName();
		}

		// Token: 0x0603C114 RID: 246036 RVA: 0x00F3C4AA File Offset: 0x00F3A6AA
		public virtual bool IsEnableInput()
		{
			return true;
		}

		// Token: 0x0603C115 RID: 246037 RVA: 0x00F3C4AD File Offset: 0x00F3A6AD
		public virtual double GetLongPressTime()
		{
			return 0.0;
		}

		// Token: 0x0603C116 RID: 246038 RVA: 0x00F3C4B8 File Offset: 0x00F3A6B8
		public virtual void RefreshLongPressTime()
		{
		}

		// Token: 0x0603C117 RID: 246039 RVA: 0x00F3C4BA File Offset: 0x00F3A6BA
		public virtual bool? GetIsLongPressControlCamera()
		{
			return new bool?(false);
		}

		// Token: 0x0603C118 RID: 246040 RVA: 0x00F3C4C2 File Offset: 0x00F3A6C2
		public string GetActionName()
		{
			return this.ActionName;
		}

		// Token: 0x0603C119 RID: 246041 RVA: 0x00F3C4CA File Offset: 0x00F3A6CA
		public virtual bool? IsMultiStageSkill()
		{
			return new bool?(false);
		}

		// Token: 0x0603C11A RID: 246042 RVA: 0x00F3C4D2 File Offset: 0x00F3A6D2
		[NullableContext(1)]
		public virtual string GetMultiSkillTexturePath()
		{
			return "";
		}

		// Token: 0x0603C11B RID: 246043 RVA: 0x00F3C4D9 File Offset: 0x00F3A6D9
		public virtual string GetSkillTexturePath()
		{
			return "";
		}

		// Token: 0x0603C11C RID: 246044 RVA: 0x00F3C4E0 File Offset: 0x00F3A6E0
		public virtual int GetSkillId()
		{
			return 0;
		}

		// Token: 0x0603C11D RID: 246045 RVA: 0x00F3C4E3 File Offset: 0x00F3A6E3
		public virtual string GetSkillIconName()
		{
			return "";
		}

		// Token: 0x0603C11E RID: 246046 RVA: 0x00F3C4EA File Offset: 0x00F3A6EA
		public virtual MultiSkillInfo GetMultiSkillInfo()
		{
			return null;
		}

		// Token: 0x0603C11F RID: 246047 RVA: 0x00F3C4ED File Offset: 0x00F3A6ED
		public virtual GroupSkillCdInfo GetGroupSkillCdInfo()
		{
			return null;
		}

		// Token: 0x0603C120 RID: 246048 RVA: 0x00F3C4F0 File Offset: 0x00F3A6F0
		public virtual bool HasCdComponent()
		{
			return false;
		}

		// Token: 0x0603C121 RID: 246049 RVA: 0x00F3C4F3 File Offset: 0x00F3A6F3
		public virtual float GetSkillRemainingCoolDown()
		{
			return 0f;
		}

		// Token: 0x0603C122 RID: 246050 RVA: 0x00F3C4FA File Offset: 0x00F3A6FA
		public virtual bool IsCdVisible()
		{
			return false;
		}

		// Token: 0x0603C123 RID: 246051 RVA: 0x00F3C4FD File Offset: 0x00F3A6FD
		public virtual void RefreshIsEnable()
		{
		}

		// Token: 0x0603C124 RID: 246052 RVA: 0x00F3C4FF File Offset: 0x00F3A6FF
		public virtual bool IsVehicleSkillInCd()
		{
			return false;
		}

		// Token: 0x0603C125 RID: 246053 RVA: 0x00F3C502 File Offset: 0x00F3A702
		public virtual float GetRemainingCoolDownCustom()
		{
			return 0f;
		}

		// Token: 0x0603C126 RID: 246054 RVA: 0x00F3C509 File Offset: 0x00F3A709
		public virtual float GetAttribute()
		{
			return 0f;
		}

		// Token: 0x0603C127 RID: 246055 RVA: 0x00F3C510 File Offset: 0x00F3A710
		public virtual float GetMaxAttribute()
		{
			return 0f;
		}

		// Token: 0x0603C128 RID: 246056 RVA: 0x00F3C517 File Offset: 0x00F3A717
		public virtual ESkillButtonType GetButtonType()
		{
			return ESkillButtonType.None;
		}

		// Token: 0x0603C129 RID: 246057 RVA: 0x00F3C51A File Offset: 0x00F3A71A
		public virtual bool IsSkillInItemUseCd()
		{
			return false;
		}

		// Token: 0x0603C12A RID: 246058 RVA: 0x00F3C51D File Offset: 0x00F3A71D
		public virtual bool IsEquippedItemBanReqUse()
		{
			return false;
		}

		// Token: 0x0603C12B RID: 246059 RVA: 0x00F3C520 File Offset: 0x00F3A720
		public virtual bool IsSkillInItemUseBuffCd()
		{
			return false;
		}

		// Token: 0x0603C12C RID: 246060 RVA: 0x00F3C523 File Offset: 0x00F3A723
		[NullableContext(0)]
		public virtual ValueTuple<double, double> GetEquippedItemUsingBuffCd()
		{
			return new ValueTuple<double, double>(0.0, 0.0);
		}

		// Token: 0x0603C12D RID: 246061 RVA: 0x00F3C53C File Offset: 0x00F3A73C
		public virtual bool IsSkillInItemUseSkillCd()
		{
			return false;
		}

		// Token: 0x0603C12E RID: 246062 RVA: 0x00F3C53F File Offset: 0x00F3A73F
		[NullableContext(0)]
		public virtual ValueTuple<double, double> GetEquippedItemUsingSkillCd()
		{
			return new ValueTuple<double, double>(0.0, 0.0);
		}

		// Token: 0x0603C12F RID: 246063 RVA: 0x00F3C558 File Offset: 0x00F3A758
		[NullableContext(0)]
		public virtual ValueTuple<double, double> GetVehicleSkillCd()
		{
			return new ValueTuple<double, double>(0.0, 0.0);
		}

		// Token: 0x0603C130 RID: 246064 RVA: 0x00F3C571 File Offset: 0x00F3A771
		public bool GetExploreSkillChange()
		{
			return this.IsExploreSkillChange;
		}

		// Token: 0x0603C131 RID: 246065 RVA: 0x00F3C579 File Offset: 0x00F3A779
		public void SetExploreSkillChange(bool isExploreSkillChange)
		{
			this.IsExploreSkillChange = isExploreSkillChange;
		}

		// Token: 0x0603C132 RID: 246066 RVA: 0x00F3C582 File Offset: 0x00F3A782
		[NullableContext(1)]
		public virtual string GetMaxAttributeEffectPath()
		{
			return "";
		}

		// Token: 0x0603C133 RID: 246067 RVA: 0x00F3C58C File Offset: 0x00F3A78C
		public virtual FLinearColor? GetMaxAttributeColor()
		{
			return null;
		}

		// Token: 0x0603C134 RID: 246068 RVA: 0x00F3C5A4 File Offset: 0x00F3A7A4
		public virtual SkillButtonEffect? GetDynamicEffectConfig()
		{
			return null;
		}

		// Token: 0x0603C135 RID: 246069 RVA: 0x00F3C5BA File Offset: 0x00F3A7BA
		public virtual int GetCdCompletedEffectId()
		{
			return 0;
		}

		// Token: 0x0603C136 RID: 246070 RVA: 0x00F3C5C0 File Offset: 0x00F3A7C0
		public virtual SkillButtonEffect? GetCdCompletedEffectConfig()
		{
			return null;
		}

		// Token: 0x0603C137 RID: 246071 RVA: 0x00F3C5D6 File Offset: 0x00F3A7D6
		public virtual bool HasConfigFollower()
		{
			return false;
		}

		// Token: 0x0603C138 RID: 246072 RVA: 0x00F3C5DC File Offset: 0x00F3A7DC
		public virtual FColor? GetFrameSpriteColor()
		{
			return null;
		}

		// Token: 0x0603C139 RID: 246073 RVA: 0x00F3C5F2 File Offset: 0x00F3A7F2
		public virtual bool HasAttribute()
		{
			return this.AttributeId != EAttributeType.None && this.MaxAttributeId != 0;
		}

		// Token: 0x0603C13A RID: 246074 RVA: 0x00F3C607 File Offset: 0x00F3A807
		public virtual bool IsEnable()
		{
			return true;
		}

		// Token: 0x0603C13B RID: 246075 RVA: 0x00F3C60A File Offset: 0x00F3A80A
		public virtual void InitVehicleHandle()
		{
		}

		// Token: 0x0603C13C RID: 246076 RVA: 0x00F3C60C File Offset: 0x00F3A80C
		public bool IsShowLongPress()
		{
			return this.IsShowLongPressInternal;
		}

		// Token: 0x0603C13D RID: 246077 RVA: 0x00F3C614 File Offset: 0x00F3A814
		public virtual void RefreshIsShowLongPress()
		{
		}

		// Token: 0x0603C13E RID: 246078 RVA: 0x00F3C616 File Offset: 0x00F3A816
		public virtual void RefreshLongPressDuration()
		{
		}

		// Token: 0x0603C13F RID: 246079 RVA: 0x00F3C618 File Offset: 0x00F3A818
		public double GetLongPressDuration()
		{
			return (double)this.LongPressDuration;
		}

		// Token: 0x0603C140 RID: 246080 RVA: 0x00F3C621 File Offset: 0x00F3A821
		public virtual bool GetIsLongPressing()
		{
			return false;
		}

		// Token: 0x0603C141 RID: 246081 RVA: 0x00F3C624 File Offset: 0x00F3A824
		public bool GetIsConfigShowLongPress()
		{
			return this.IsConfigShowLongPress;
		}

		// Token: 0x0603C142 RID: 246082 RVA: 0x00F3C62C File Offset: 0x00F3A82C
		public void SetIsConfigShowLongPress(bool value)
		{
			this.IsConfigShowLongPress = value;
		}

		// Token: 0x0603C143 RID: 246083 RVA: 0x00F3C635 File Offset: 0x00F3A835
		public bool IsVisible()
		{
			return this.IsVisibleInternal;
		}

		// Token: 0x0603C144 RID: 246084 RVA: 0x00F3C63D File Offset: 0x00F3A83D
		public virtual int GetMaxAttributeBurstEffectId()
		{
			return 0;
		}

		// Token: 0x0603C145 RID: 246085 RVA: 0x00F3C640 File Offset: 0x00F3A840
		public virtual SkillButtonEffect? GetMaxAttributeBurstEffectConfig()
		{
			return null;
		}

		// Token: 0x0603C146 RID: 246086 RVA: 0x00F3C656 File Offset: 0x00F3A856
		public virtual bool IsEnableLongPress()
		{
			return false;
		}

		// Token: 0x0603C147 RID: 246087 RVA: 0x00F3C659 File Offset: 0x00F3A859
		public virtual SkillButtonTypeFormationData GetFormationData()
		{
			return null;
		}

		// Token: 0x0603C148 RID: 246088 RVA: 0x00F3C65C File Offset: 0x00F3A85C
		public virtual bool IsSkillIdChangeByTag()
		{
			return false;
		}

		// Token: 0x0603C149 RID: 246089 RVA: 0x00F3C65F File Offset: 0x00F3A85F
		public List<EInputAction> GetValidSharedHoldRingFxActions()
		{
			return null;
		}

		// Token: 0x04021BC9 RID: 138185
		[Nullable(1)]
		private string ActionName = "";

		// Token: 0x04021BCA RID: 138186
		private bool IsExploreSkillChange;

		// Token: 0x04021BCF RID: 138191
		public int MaxAttributeId;

		// Token: 0x04021BD0 RID: 138192
		protected bool IsShowLongPressInternal;

		// Token: 0x04021BD1 RID: 138193
		protected float LongPressDuration;

		// Token: 0x04021BD2 RID: 138194
		protected bool IsConfigShowLongPress;

		// Token: 0x04021BD3 RID: 138195
		protected bool IsVisibleInternal = true;
	}
}
