using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.BattleUi;

// Token: 0x0200304D RID: 12365
[NullableContext(2)]
[Nullable(0)]
public class InputContinuously
{
	// Token: 0x06019582 RID: 103810 RVA: 0x0074D185 File Offset: 0x0074B385
	[NullableContext(1)]
	public InputContinuously(BaseTagComponent tagComp, BaseBuffComponent buffComp)
	{
		this.TagComp = tagComp;
		this.BuffComp = buffComp;
	}

	// Token: 0x06019583 RID: 103811 RVA: 0x0074D19C File Offset: 0x0074B39C
	public void InitConfig()
	{
		this.Duration = (float)ConfigCommonParamById.GetIntConfig("ConstantSprintEnterTime").Value;
		this.AutoGlideTime = (float)ConfigCommonParamById.GetIntConfig("ConstantSprintAutoGlideTime").Value;
		this.DelayExitTime = (float)ConfigCommonParamById.GetIntConfig("ConstantSprintSpecialStateOffset").Value;
		IReadOnlyList<int> intArrayConfig = ConfigCommonParamById.GetIntArrayConfig("ConstantSprintListeningBuffStopList");
		IReadOnlyList<string> stringArrayConfig = ConfigCommonParamById.GetStringArrayConfig("ConstantSprintListeningTagStopList");
		if (intArrayConfig != null && intArrayConfig.Count > 0)
		{
			this.BuffList = new int[intArrayConfig.Count];
			for (int i = 0; i < intArrayConfig.Count; i++)
			{
				this.BuffList[i] = intArrayConfig[i];
			}
		}
		if (stringArrayConfig != null && stringArrayConfig.Count > 0)
		{
			this.TagList = new int[stringArrayConfig.Count];
			for (int j = 0; j < stringArrayConfig.Count; j++)
			{
				int tagIdByName = GameplayTagUtils.GetTagIdByName(stringArrayConfig[j]);
				this.TagList[j] = tagIdByName;
			}
		}
	}

	// Token: 0x06019584 RID: 103812 RVA: 0x0074D294 File Offset: 0x0074B494
	public bool GetAutoMovingState()
	{
		BattleUiFormationData formationData = ModelBase<BattleUiModel>.Instance.FormationData;
		bool flag = formationData != null && formationData.AutoMovingSettingEnable && this.CheckTagAndBuff();
		if (this.LastState && !flag)
		{
			this.ResetAutoMovingState("不满足默认奔跑条件");
		}
		return flag;
	}

	// Token: 0x06019585 RID: 103813 RVA: 0x0074D2DA File Offset: 0x0074B4DA
	public bool CheckTagAndBuff()
	{
		BaseTagComponent tagComp = this.TagComp;
		return tagComp != null && tagComp.HasTag(GameplayTagDefine.EGameplayTagId["功能.功能制作.保持持续奔跑"]) && this.CheckForbiddenTagAndBuff();
	}

	// Token: 0x06019586 RID: 103814 RVA: 0x0074D30A File Offset: 0x0074B50A
	public void SetAutoMovingState(bool value, bool start = false)
	{
		this.StartEnter = start;
		this.LastState = value;
		this.UpdateAutoMovingTag(value);
	}

	// Token: 0x06019587 RID: 103815 RVA: 0x0074D321 File Offset: 0x0074B521
	public void AddTimeAccumulation(float delta)
	{
		if (!this.CheckForbiddenTagAndBuff())
		{
			this.ClearTimeAccumulation();
			return;
		}
		this.CurrentTime += delta;
		this.AccumulationTime += delta;
	}

	// Token: 0x06019588 RID: 103816 RVA: 0x0074D34E File Offset: 0x0074B54E
	public void ClearTimeAccumulation()
	{
		this.CurrentTime = 0f;
		this.AccumulationTime = 0f;
	}

	// Token: 0x06019589 RID: 103817 RVA: 0x0074D366 File Offset: 0x0074B566
	public void ResetAutoMovingState(string context = null)
	{
		this.ClearTimeAccumulation();
		this.SetAutoMovingState(false, false);
		string.IsNullOrEmpty(context);
	}

	// Token: 0x0601958A RID: 103818 RVA: 0x0074D37D File Offset: 0x0074B57D
	[NullableContext(1)]
	public void DeepCopy(InputContinuously other)
	{
		this.CurrentTime = other.CurrentTime;
		this.AccumulationTime = other.AccumulationTime;
		this.InAirTime = other.InAirTime;
		this.SetAutoMovingState(other.GetAutoMovingState(), false);
	}

	// Token: 0x0601958B RID: 103819 RVA: 0x0074D3B0 File Offset: 0x0074B5B0
	public bool IsStartEnter()
	{
		return this.StartEnter;
	}

	// Token: 0x0601958C RID: 103820 RVA: 0x0074D3B8 File Offset: 0x0074B5B8
	public void ClearStartEnter()
	{
		this.StartEnter = false;
	}

	// Token: 0x0601958D RID: 103821 RVA: 0x0074D3C1 File Offset: 0x0074B5C1
	public bool CheckTimeDuration()
	{
		return this.AccumulationTime > this.Duration;
	}

	// Token: 0x0601958E RID: 103822 RVA: 0x0074D3D1 File Offset: 0x0074B5D1
	public float GetCurrentTime()
	{
		return this.CurrentTime;
	}

	// Token: 0x0601958F RID: 103823 RVA: 0x0074D3D9 File Offset: 0x0074B5D9
	public float GetDuration()
	{
		return this.Duration;
	}

	// Token: 0x06019590 RID: 103824 RVA: 0x0074D3E4 File Offset: 0x0074B5E4
	private bool CheckForbiddenTagAndBuff()
	{
		if (this.BuffList != null && this.BuffList.Length != 0)
		{
			for (int i = 0; i < this.BuffList.Length; i++)
			{
				int num = this.BuffList[i];
				BaseBuffComponent buffComp = this.BuffComp;
				if (buffComp != null && buffComp.HasBuff((long)num, false))
				{
					return false;
				}
			}
		}
		if (this.TagList != null && this.TagList.Length != 0)
		{
			for (int j = 0; j < this.TagList.Length; j++)
			{
				int tagId = this.TagList[j];
				BaseTagComponent tagComp = this.TagComp;
				if (tagComp != null && tagComp.HasTag(tagId))
				{
					return false;
				}
			}
		}
		return true;
	}

	// Token: 0x06019591 RID: 103825 RVA: 0x0074D47C File Offset: 0x0074B67C
	private void UpdateAutoMovingTag(bool value)
	{
		if (value)
		{
			BaseTagComponent tagComp = this.TagComp;
			if (tagComp == null || !tagComp.HasTag(GameplayTagDefine.EGameplayTagId["功能.功能制作.保持持续奔跑"]))
			{
				BaseTagComponent tagComp2 = this.TagComp;
				if (tagComp2 != null)
				{
					tagComp2.AddTag(new int?(GameplayTagDefine.EGameplayTagId["功能.功能制作.保持持续奔跑"]));
				}
			}
		}
		if (!value)
		{
			BaseTagComponent tagComp3 = this.TagComp;
			if (tagComp3 != null && tagComp3.HasTag(GameplayTagDefine.EGameplayTagId["功能.功能制作.保持持续奔跑"]))
			{
				BaseTagComponent tagComp4 = this.TagComp;
				if (tagComp4 == null)
				{
					return;
				}
				tagComp4.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["功能.功能制作.保持持续奔跑"]));
			}
		}
	}

	// Token: 0x0400C856 RID: 51286
	private bool LastState;

	// Token: 0x0400C857 RID: 51287
	private bool StartEnter;

	// Token: 0x0400C858 RID: 51288
	private float CurrentTime;

	// Token: 0x0400C859 RID: 51289
	private float AccumulationTime;

	// Token: 0x0400C85A RID: 51290
	public float InAirTime;

	// Token: 0x0400C85B RID: 51291
	public float InDelayExitTime;

	// Token: 0x0400C85C RID: 51292
	private float Duration;

	// Token: 0x0400C85D RID: 51293
	public float AutoGlideTime;

	// Token: 0x0400C85E RID: 51294
	public float DelayExitTime;

	// Token: 0x0400C85F RID: 51295
	private int[] BuffList;

	// Token: 0x0400C860 RID: 51296
	private int[] TagList;

	// Token: 0x0400C861 RID: 51297
	private readonly BaseTagComponent TagComp;

	// Token: 0x0400C862 RID: 51298
	private readonly BaseBuffComponent BuffComp;
}
