using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002F4A RID: 12106
[NullableContext(1)]
[Nullable(0)]
public class ReplaceBuffOnAddEffect : BuffEffect
{
	// Token: 0x06018C5B RID: 101467 RVA: 0x00700C3C File Offset: 0x006FEE3C
	public ReplaceBuffOnAddEffect(int activeHandleId, int index, RequireAndLimits requireAndLimits, BaseBuffComponent ownerBuffComponent, [Nullable(2)] CharacterBuffComponent instigatorBuffComponent) : base(activeHandleId, index, requireAndLimits, ownerBuffComponent, instigatorBuffComponent)
	{
	}

	// Token: 0x06018C5C RID: 101468 RVA: 0x00700C58 File Offset: 0x006FEE58
	protected override void InitParameters(ExtraEffectParameters parameters)
	{
		this.ReplaceBuffMap.Clear();
		string[] extraEffectParameters_ = parameters.ExtraEffectParameters_;
		if (extraEffectParameters_ == null || extraEffectParameters_.Length < 2)
		{
			return;
		}
		string[] array = extraEffectParameters_[0].Split('#', StringSplitOptions.None);
		string[] array2 = extraEffectParameters_[1].Split('#', StringSplitOptions.None);
		int num = Math.Min(array.Length, array2.Length);
		for (int i = 0; i < num; i++)
		{
			this.ReplaceBuffMap[long.Parse(array[i])] = long.Parse(array2[i]);
		}
	}

	// Token: 0x06018C5D RID: 101469 RVA: 0x00700CD4 File Offset: 0x006FEED4
	public override void OnCreated()
	{
		foreach (KeyValuePair<long, long> keyValuePair in this.ReplaceBuffMap)
		{
			IBuffComponent ownerBuffComponent = this.OwnerBuffComponent;
			if (ownerBuffComponent != null)
			{
				long key = keyValuePair.Key;
				BuffReplace buffReplace = new BuffReplace();
				buffReplace.ReplaceBuffId = keyValuePair.Value;
				IActiveBuff buff = base.Buff;
				buffReplace.PreMessageId = ((buff != null) ? buff.MessageId : null);
				ownerBuffComponent.AddReplaceBuff(key, buffReplace);
			}
		}
	}

	// Token: 0x06018C5E RID: 101470 RVA: 0x00700D6C File Offset: 0x006FEF6C
	public override void OnRemoved(bool bPremature)
	{
		foreach (KeyValuePair<long, long> keyValuePair in this.ReplaceBuffMap)
		{
			IBuffComponent ownerBuffComponent = this.OwnerBuffComponent;
			if (ownerBuffComponent != null)
			{
				ownerBuffComponent.RemoveReplaceBuff(keyValuePair.Key);
			}
		}
	}

	// Token: 0x06018C5F RID: 101471 RVA: 0x00700DD4 File Offset: 0x006FEFD4
	[return: Nullable(2)]
	public override object OnExecute(params object[] parameters)
	{
		return null;
	}

	// Token: 0x06018C60 RID: 101472 RVA: 0x00700DD8 File Offset: 0x006FEFD8
	public override string GetDebugEffectString()
	{
		string text = "";
		foreach (KeyValuePair<long, long> keyValuePair in this.ReplaceBuffMap)
		{
			string str = text;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(19, 2);
			defaultInterpolatedStringHandler.AppendLiteral("当添加buff ");
			defaultInterpolatedStringHandler.AppendFormatted<long>(keyValuePair.Key);
			defaultInterpolatedStringHandler.AppendLiteral(" 时替换为buff ");
			defaultInterpolatedStringHandler.AppendFormatted<long>(keyValuePair.Value);
			defaultInterpolatedStringHandler.AppendLiteral("\n");
			text = str + defaultInterpolatedStringHandler.ToStringAndClear();
		}
		return text;
	}

	// Token: 0x0400C0E9 RID: 49385
	protected Dictionary<long, long> ReplaceBuffMap = new Dictionary<long, long>();
}
