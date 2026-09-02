using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Input;
using CSharpScript.Game.Module.GameMainView.Data;
using CSharpScript.Game.Module.SkillButtonUi;
using UnrealEngine;

// Token: 0x02001D39 RID: 7481
[NullableContext(2)]
[Nullable(0)]
public class MotorcycleArrowBattleSkillData : BattleSkillDataBase
{
	// Token: 0x0600DC5F RID: 56415 RVA: 0x003B3CB0 File Offset: 0x003B1EB0
	public MotorcycleArrowBattleSkillData(int skillId)
	{
		this.SkillId = skillId;
		this.IsVisibleInternal = false;
		string stringConfig = ConfigCommonParamById.GetStringConfig("MotorArrowSkillColor");
		if (!string.IsNullOrEmpty(stringConfig))
		{
			this.FrameSpriteColor = new FColor?(FColor.FromHex(stringConfig));
		}
		string stringConfig2 = ConfigCommonParamById.GetStringConfig("MotorArrowSkillEffectColor");
		if (!string.IsNullOrEmpty(stringConfig2))
		{
			FColor fcolor = FColor.FromHex(stringConfig2);
			this.MaxAttributeColor = new FLinearColor?(new FLinearColor(ref fcolor));
		}
		string stringConfig3 = ConfigCommonParamById.GetStringConfig("MotorArrowSkillEffectPath");
		if (!string.IsNullOrEmpty(stringConfig3))
		{
			this.MaxAttributeEffect = stringConfig3;
		}
		string stringConfig4 = ConfigCommonParamById.GetStringConfig("MotorArrowSkillEffectPathPC");
		if (!string.IsNullOrEmpty(stringConfig4))
		{
			this.MaxAttributeEffectPc = stringConfig4;
		}
	}

	// Token: 0x0600DC60 RID: 56416 RVA: 0x003B3D82 File Offset: 0x003B1F82
	protected override void OnInitData()
	{
		if (this.SkillId == 0)
		{
			return;
		}
		this.SkillButtonConfig = this.GetActiveSkillButtonConfig();
	}

	// Token: 0x0600DC61 RID: 56417 RVA: 0x003B3D9C File Offset: 0x003B1F9C
	private SkillGameplayButton? GetActiveSkillButtonConfig()
	{
		IReadOnlyList<SkillGameplayButton> configList = ConfigSkillGameplayButtonByGameplayType.GetConfigList(5, true);
		if (configList == null)
		{
			return null;
		}
		string actionName = base.GetActionName();
		for (int i = 0; i < configList.Count; i++)
		{
			SkillGameplayButton value = configList[i];
			if (value.ActionName == actionName)
			{
				return new SkillGameplayButton?(value);
			}
		}
		return null;
	}

	// Token: 0x0600DC62 RID: 56418 RVA: 0x003B3DFF File Offset: 0x003B1FFF
	public override int GetSkillId()
	{
		return this.SkillId;
	}

	// Token: 0x0600DC63 RID: 56419 RVA: 0x003B3E08 File Offset: 0x003B2008
	public override string GetSkillTexturePath()
	{
		if (this.SkillButtonConfig == null)
		{
			return null;
		}
		return this.SkillButtonConfig.GetValueOrDefault().SkillIcon;
	}

	// Token: 0x0600DC64 RID: 56420 RVA: 0x003B3E34 File Offset: 0x003B2034
	public override EInputAction GetActionType()
	{
		if (this.SkillButtonConfig != null)
		{
			return (EInputAction)((byte)this.SkillButtonConfig.Value.ButtonType);
		}
		return EInputAction.None;
	}

	// Token: 0x0600DC65 RID: 56421 RVA: 0x003B3E70 File Offset: 0x003B2070
	public override ESkillButtonType GetButtonType()
	{
		if (this.SkillButtonConfig != null)
		{
			return (ESkillButtonType)this.SkillButtonConfig.Value.ButtonType;
		}
		return ESkillButtonType.None;
	}

	// Token: 0x0600DC66 RID: 56422 RVA: 0x003B3E9F File Offset: 0x003B209F
	public override FColor? GetFrameSpriteColor()
	{
		return this.FrameSpriteColor;
	}

	// Token: 0x0600DC67 RID: 56423 RVA: 0x003B3EA7 File Offset: 0x003B20A7
	public override FLinearColor? GetMaxAttributeColor()
	{
		return this.MaxAttributeColor;
	}

	// Token: 0x0600DC68 RID: 56424 RVA: 0x003B3EAF File Offset: 0x003B20AF
	[NullableContext(1)]
	public override string GetMaxAttributeEffectPath()
	{
		if (!Singleton<Info>.Instance.IsInTouch())
		{
			return this.MaxAttributeEffectPc;
		}
		return this.MaxAttributeEffect;
	}

	// Token: 0x0600DC69 RID: 56425 RVA: 0x003B3ECC File Offset: 0x003B20CC
	public override void RefreshIsEnable()
	{
		float attribute = this.GetAttribute();
		float maxAttribute = this.GetMaxAttribute();
		if (attribute >= maxAttribute && attribute > 0f)
		{
			this.IsEnableInternal = true;
			return;
		}
		this.IsEnableInternal = false;
	}

	// Token: 0x0600DC6A RID: 56426 RVA: 0x003B3F02 File Offset: 0x003B2102
	public override bool IsEnable()
	{
		return this.IsEnableInternal;
	}

	// Token: 0x0600DC6B RID: 56427 RVA: 0x003B3F0C File Offset: 0x003B210C
	public override float GetAttribute()
	{
		if (this.AttrMap == null)
		{
			return 0f;
		}
		int num;
		return (float)(this.AttrMap.TryGetValue(this.KscAttrId, out num) ? num : 0);
	}

	// Token: 0x0600DC6C RID: 56428 RVA: 0x003B3F44 File Offset: 0x003B2144
	public override float GetMaxAttribute()
	{
		if (this.AttrMap == null)
		{
			return 0f;
		}
		int num;
		return (float)(this.AttrMap.TryGetValue(this.MaxKscAttributeId, out num) ? num : 0);
	}

	// Token: 0x0600DC6D RID: 56429 RVA: 0x003B3F79 File Offset: 0x003B2179
	public override bool HasAttribute()
	{
		return true;
	}

	// Token: 0x0600DC6E RID: 56430 RVA: 0x003B3F7C File Offset: 0x003B217C
	[NullableContext(1)]
	public void InitAttrData(AKSC_Entity kscEntity)
	{
		UKSC_AttrSet uksc_AttrSet;
		if (kscEntity == null)
		{
			uksc_AttrSet = null;
		}
		else
		{
			UKSC_SkillComp skillComp = kscEntity.GetSkillComp();
			uksc_AttrSet = ((skillComp != null) ? skillComp.AttrSet_ : null);
		}
		UKSC_AttrSet uksc_AttrSet2 = uksc_AttrSet;
		TMap<EKSC_AttrType, int> tmap = (uksc_AttrSet2 != null) ? uksc_AttrSet2.Attrs_ : null;
		if (tmap == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.UiComponent, ELogAuthor.TZQ, "[摩托战斗]技能按钮获取属性失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		Singleton<Log>.Instance.Info(ELogModule.UiComponent, ELogAuthor.TZQ, "[摩托战斗]技能按钮获取属性成功", default(ReadOnlySpan<ValueTuple<string, object>>));
		this.AttrMap = tmap;
		this.AttrSet = uksc_AttrSet2;
		this.DelegateAttrChange = global::DelegateUtils.ToManualReleaseDelegate<FOnKSCAttrChange>(new Action<EKSC_AttrType, int>(this.OnAttrChange));
		uksc_AttrSet2.AssignAttrListen(this.KscAttrId, this.DelegateAttrChange);
		this.DelegateMaxAttrChange = global::DelegateUtils.ToManualReleaseDelegate<FOnKSCAttrChange>(new Action<EKSC_AttrType, int>(this.OnMaxAttrChange));
		uksc_AttrSet2.AssignAttrListen(this.MaxKscAttributeId, this.DelegateMaxAttrChange);
		this.RefreshIsEnable();
	}

	// Token: 0x0600DC6F RID: 56431 RVA: 0x003B4051 File Offset: 0x003B2251
	private void OnAttrChange(EKSC_AttrType attrType, int value)
	{
		this.UpdateAttrChange();
	}

	// Token: 0x0600DC70 RID: 56432 RVA: 0x003B4059 File Offset: 0x003B2259
	private void OnMaxAttrChange(EKSC_AttrType attrType, int value)
	{
		this.UpdateAttrChange();
	}

	// Token: 0x0600DC71 RID: 56433 RVA: 0x003B4061 File Offset: 0x003B2261
	protected void UpdateAttrChange()
	{
		this.RefreshIsEnable();
		Singleton<EventSystem>.Instance.Emit<ESkillButtonType>(EEventName.OnSkillButtonAttributeRefresh, this.GetButtonType());
	}

	// Token: 0x0600DC72 RID: 56434 RVA: 0x003B407F File Offset: 0x003B227F
	public void SetVisible(bool visible)
	{
		this.IsVisibleInternal = visible;
	}

	// Token: 0x0600DC73 RID: 56435 RVA: 0x003B4088 File Offset: 0x003B2288
	public void Clear()
	{
		if (this.AttrSet != null)
		{
			if (this.DelegateAttrChange != null)
			{
				this.AttrSet.RemoveAttrListen(this.KscAttrId, this.DelegateAttrChange);
				this.DelegateAttrChange = null;
			}
			if (this.DelegateMaxAttrChange != null)
			{
				this.AttrSet.RemoveAttrListen(this.MaxKscAttributeId, this.DelegateMaxAttrChange);
				this.DelegateMaxAttrChange = null;
			}
			this.AttrSet = null;
		}
		global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<EKSC_AttrType, int>(this.OnAttrChange));
		global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<EKSC_AttrType, int>(this.OnMaxAttrChange));
	}

	// Token: 0x04006970 RID: 26992
	private bool IsEnableInternal;

	// Token: 0x04006971 RID: 26993
	private readonly int SkillId;

	// Token: 0x04006972 RID: 26994
	private SkillGameplayButton? SkillButtonConfig;

	// Token: 0x04006973 RID: 26995
	private TMap<EKSC_AttrType, int> AttrMap;

	// Token: 0x04006974 RID: 26996
	private UKSC_AttrSet AttrSet;

	// Token: 0x04006975 RID: 26997
	private readonly EKSC_AttrType KscAttrId = EKSC_AttrType.SpecialChange1;

	// Token: 0x04006976 RID: 26998
	private readonly EKSC_AttrType MaxKscAttributeId = EKSC_AttrType.SpecialChange0;

	// Token: 0x04006977 RID: 26999
	private readonly FColor? FrameSpriteColor;

	// Token: 0x04006978 RID: 27000
	private readonly FLinearColor? MaxAttributeColor;

	// Token: 0x04006979 RID: 27001
	[Nullable(1)]
	private readonly string MaxAttributeEffect = "";

	// Token: 0x0400697A RID: 27002
	[Nullable(1)]
	private readonly string MaxAttributeEffectPc = "";

	// Token: 0x0400697B RID: 27003
	public FOnKSCAttrChange DelegateAttrChange;

	// Token: 0x0400697C RID: 27004
	public FOnKSCAttrChange DelegateMaxAttrChange;
}
