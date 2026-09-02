using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Utils;

// Token: 0x02002FCC RID: 12236
[NullableContext(1)]
[Nullable(0)]
public class TagStackTrigger : Trigger
{
	// Token: 0x06018F2A RID: 102186 RVA: 0x00711AFA File Offset: 0x0070FCFA
	[NullableContext(2)]
	public TagStackTrigger(ITriggerConfig c, int h, CharacterTriggerComponent o, [Nullable(1)] Dictionary<string, Func<TFormulaValue[], TFormulaValue>> f, TTriggerCallback cb, TTriggerChecker ck) : base(c, h, o, f, cb, ck)
	{
	}

	// Token: 0x06018F2B RID: 102187 RVA: 0x00711B0C File Offset: 0x0070FD0C
	public override void OnInitParams(string[] triggerParams)
	{
		string tagName = (triggerParams.Length != 0) ? triggerParams[0].Trim() : string.Empty;
		this.TagId = GameplayTagUtils.GetTagIdByName(tagName);
		this.InitBehavior = (TagTrigger.ETagTriggerInitBehavior)Convert.ToInt32((triggerParams.Length > 1) ? triggerParams[1] : "0");
	}

	// Token: 0x06018F2C RID: 102188 RVA: 0x00711B54 File Offset: 0x0070FD54
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
		int tagCount = baseTagComponent2.GetTagCount(this.TagId);
		switch (this.InitBehavior)
		{
		case TagTrigger.ETagTriggerInitBehavior.CheckWhenHasTag:
			if (tagCount > 0)
			{
				this.OnEvent(tagCount, this.TagId, this.TagId, this.OldCount);
			}
			break;
		case TagTrigger.ETagTriggerInitBehavior.CheckWhenNotHasTag:
			if (tagCount <= 0)
			{
				this.OnEvent(tagCount, this.TagId, this.TagId, this.OldCount);
			}
			break;
		}
		this.OldCount = tagCount;
		baseTagComponent2.AddTagChangedListener(this.TagId, new BaseTagComponent.TTagChangedCallback(this.OnEvent), null);
	}

	// Token: 0x06018F2D RID: 102189 RVA: 0x00711C08 File Offset: 0x0070FE08
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
		baseTagComponent2.RemoveTagChangedListener(this.TagId, new BaseTagComponent.TTagChangedCallback(this.OnEvent));
	}

	// Token: 0x06018F2E RID: 102190 RVA: 0x00711C50 File Offset: 0x0070FE50
	protected void OnEvent(int newCount, int tagId, int exactTagId, int oldCount)
	{
		if (base.Checker != null && !base.Checker())
		{
			return;
		}
		Dictionary<string, TFormulaValue> dictionary = new Dictionary<string, TFormulaValue>();
		dictionary["NewStack"] = newCount;
		dictionary["OldStack"] = this.OldCount;
		base.EvaluateAndExecute(dictionary);
		this.OldCount = newCount;
	}

	// Token: 0x06018F2F RID: 102191 RVA: 0x00711CAC File Offset: 0x0070FEAC
	public override string GetDebugTriggerType()
	{
		return "标签 [" + GameplayTagUtils.GetNameByTagId(this.TagId) + "] 层数变化时触发";
	}

	// Token: 0x0400C2F8 RID: 49912
	protected int TagId;

	// Token: 0x0400C2F9 RID: 49913
	protected int OldCount;

	// Token: 0x0400C2FA RID: 49914
	protected TagTrigger.ETagTriggerInitBehavior InitBehavior;
}
