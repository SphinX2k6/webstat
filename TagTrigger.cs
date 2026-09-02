using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Utils;

// Token: 0x02002FCB RID: 12235
[NullableContext(1)]
[Nullable(0)]
public class TagTrigger : Trigger
{
	// Token: 0x06018F23 RID: 102179 RVA: 0x007116A7 File Offset: 0x0070F8A7
	[NullableContext(2)]
	public TagTrigger(ITriggerConfig c, int h, CharacterTriggerComponent o, [Nullable(1)] Dictionary<string, Func<TFormulaValue[], TFormulaValue>> f, TTriggerCallback cb, TTriggerChecker ck) : base(c, h, o, f, cb, ck)
	{
	}

	// Token: 0x06018F24 RID: 102180 RVA: 0x007116C4 File Offset: 0x0070F8C4
	public override void OnInitParams(string[] triggerParams)
	{
		this.TagIds.Clear();
		string[] array = ((triggerParams.Length != 0) ? triggerParams[0] : "").Split('#', StringSplitOptions.None);
		for (int i = 0; i < array.Length; i++)
		{
			string text = array[i].Trim();
			if (text.Length != 0)
			{
				int tagIdByName = GameplayTagUtils.GetTagIdByName(text);
				this.TagIds.Add(tagIdByName);
			}
		}
		this.CheckRemove = (Convert.ToInt32((triggerParams.Length > 1) ? triggerParams[1] : "0") != 0);
		this.TargetType = (ETriggerTargetType)Convert.ToInt32((triggerParams.Length > 2) ? triggerParams[2] : "0");
		this.InitBehavior = (TagTrigger.ETagTriggerInitBehavior)Convert.ToInt32((triggerParams.Length > 3) ? triggerParams[3] : "0");
		this.LogicRelation = Convert.ToInt32((triggerParams.Length > 4) ? triggerParams[4] : "0");
	}

	// Token: 0x06018F25 RID: 102181 RVA: 0x00711794 File Offset: 0x0070F994
	protected override void OnActive()
	{
		CharacterTriggerComponent ownerTriggerComp = base.OwnerTriggerComp;
		BaseTagComponent baseTagComponent;
		if (ownerTriggerComp == null)
		{
			baseTagComponent = null;
		}
		else
		{
			Entity entity = ownerTriggerComp.Entity;
			baseTagComponent = ((entity != null) ? entity.GetComponent<BaseTagComponent>() : null);
		}
		BaseTagComponent baseTagComponent2 = baseTagComponent;
		if (baseTagComponent2 == null)
		{
			return;
		}
		bool flag = false;
		switch (this.InitBehavior)
		{
		case TagTrigger.ETagTriggerInitBehavior.CheckWhenHasTag:
			flag = ((this.LogicRelation == 1) ? baseTagComponent2.HasAnyTag(this.TagIds.ToArray()) : baseTagComponent2.HasAllTag(this.TagIds.ToArray()));
			break;
		case TagTrigger.ETagTriggerInitBehavior.CheckWhenNotHasTag:
			flag = ((this.LogicRelation == 1) ? (!baseTagComponent2.HasAllTag(this.TagIds.ToArray())) : (!baseTagComponent2.HasAnyTag(this.TagIds.ToArray())));
			break;
		}
		if (flag)
		{
			if (base.Checker != null && !base.Checker())
			{
				return;
			}
			if (this.CheckTagCondition(baseTagComponent2, true))
			{
				base.EvaluateAndExecute(new Dictionary<string, TFormulaValue>());
			}
		}
		for (int i = 0; i < this.TagIds.Count; i++)
		{
			baseTagComponent2.AddTagAddOrRemoveListener(this.TagIds[i], new BaseTagComponent.TTagSwitchedCallback(this.OnEvent), null);
		}
	}

	// Token: 0x06018F26 RID: 102182 RVA: 0x007118A8 File Offset: 0x0070FAA8
	protected override void OnInactive()
	{
		CharacterTriggerComponent ownerTriggerComp = base.OwnerTriggerComp;
		BaseTagComponent baseTagComponent;
		if (ownerTriggerComp == null)
		{
			baseTagComponent = null;
		}
		else
		{
			Entity entity = ownerTriggerComp.Entity;
			baseTagComponent = ((entity != null) ? entity.GetComponent<BaseTagComponent>() : null);
		}
		BaseTagComponent baseTagComponent2 = baseTagComponent;
		if (baseTagComponent2 == null)
		{
			return;
		}
		for (int i = 0; i < this.TagIds.Count; i++)
		{
			baseTagComponent2.RemoveTagAddOrRemoveListener(this.TagIds[i], new BaseTagComponent.TTagSwitchedCallback(this.OnEvent));
		}
	}

	// Token: 0x06018F27 RID: 102183 RVA: 0x0071190C File Offset: 0x0070FB0C
	private bool CheckTagCondition(BaseTagComponent tagComp, bool needCheckOrLogic = false)
	{
		if (this.TagIds.Count == 0)
		{
			return false;
		}
		if (this.LogicRelation != 1 && this.LogicRelation != 0)
		{
			return false;
		}
		if (this.LogicRelation == 1)
		{
			if (!needCheckOrLogic)
			{
				return true;
			}
			if (this.CheckRemove)
			{
				return !tagComp.HasAllTag(this.TagIds.ToArray());
			}
			return tagComp.HasAnyTag(this.TagIds.ToArray());
		}
		else
		{
			if (this.CheckRemove)
			{
				return !tagComp.HasAnyTag(this.TagIds.ToArray());
			}
			return tagComp.HasAllTag(this.TagIds.ToArray());
		}
	}

	// Token: 0x06018F28 RID: 102184 RVA: 0x007119A8 File Offset: 0x0070FBA8
	protected void OnEvent(int _, bool tagExist)
	{
		if (this.CheckRemove == tagExist)
		{
			return;
		}
		if (base.Checker != null && !base.Checker())
		{
			return;
		}
		CharacterTriggerComponent ownerTriggerComp = base.OwnerTriggerComp;
		BaseTagComponent baseTagComponent;
		if (ownerTriggerComp == null)
		{
			baseTagComponent = null;
		}
		else
		{
			Entity entity = ownerTriggerComp.Entity;
			baseTagComponent = ((entity != null) ? entity.GetComponent<BaseTagComponent>() : null);
		}
		BaseTagComponent baseTagComponent2 = baseTagComponent;
		if (baseTagComponent2 == null)
		{
			return;
		}
		if (this.CheckTagCondition(baseTagComponent2, false))
		{
			base.EvaluateAndExecute(new Dictionary<string, TFormulaValue>());
		}
	}

	// Token: 0x06018F29 RID: 102185 RVA: 0x00711A10 File Offset: 0x0070FC10
	public override string GetDebugTriggerType()
	{
		if (this.TagIds.Count == 0)
		{
			return "标签 未配置";
		}
		List<string> list = new List<string>();
		for (int i = 0; i < this.TagIds.Count; i++)
		{
			list.Add(GameplayTagUtils.GetNameByTagId(this.TagIds[i]));
		}
		string separator = (this.LogicRelation == 0) ? " 且 " : " 或 ";
		string value = this.CheckRemove ? "移除" : "添加";
		string value2 = this.CheckRemove ? "不存在" : "存在";
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(13, 3);
		defaultInterpolatedStringHandler.AppendFormatted(value);
		defaultInterpolatedStringHandler.AppendLiteral("下列标签，且标签[");
		defaultInterpolatedStringHandler.AppendFormatted(string.Join(separator, list));
		defaultInterpolatedStringHandler.AppendLiteral("]");
		defaultInterpolatedStringHandler.AppendFormatted(value2);
		defaultInterpolatedStringHandler.AppendLiteral("时触发");
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x0400C2F3 RID: 49907
	protected bool CheckRemove;

	// Token: 0x0400C2F4 RID: 49908
	protected ETriggerTargetType TargetType;

	// Token: 0x0400C2F5 RID: 49909
	protected TagTrigger.ETagTriggerInitBehavior InitBehavior;

	// Token: 0x0400C2F6 RID: 49910
	protected readonly List<int> TagIds = new List<int>();

	// Token: 0x0400C2F7 RID: 49911
	protected int LogicRelation;

	// Token: 0x02009348 RID: 37704
	[NullableContext(0)]
	public enum ETagTriggerInitBehavior
	{
		// Token: 0x0403106B RID: 200811
		None,
		// Token: 0x0403106C RID: 200812
		CheckWhenHasTag,
		// Token: 0x0403106D RID: 200813
		CheckWhenNotHasTag
	}
}
