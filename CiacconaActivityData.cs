using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Module.CiacconaGal;

// Token: 0x02001296 RID: 4758
public class CiacconaActivityData : ActivityBaseData
{
	// Token: 0x06007F66 RID: 32614 RVA: 0x0021A97A File Offset: 0x00218B7A
	protected override bool GetExDataFinishShowState()
	{
		return ModelBase<CiacconaGalModel>.Instance.HasAllRewardReceived();
	}

	// Token: 0x06007F67 RID: 32615 RVA: 0x0021A986 File Offset: 0x00218B86
	[NullableContext(1)]
	protected override void PhraseEx(ActivityData data)
	{
		ModelBase<CiacconaGalModel>.Instance.UpdateByServerActivityData(data, base.Id);
	}

	// Token: 0x06007F68 RID: 32616 RVA: 0x0021A99C File Offset: 0x00218B9C
	public override bool GetExDataRedPointShowState()
	{
		bool flag = ModelBase<CiacconaGalModel>.Instance.HasAnyEndingReward();
		bool flag2 = ModelBase<CiacconaGalModel>.Instance.HasAnyProgressReward();
		bool flag3 = ModelBase<CiacconaGalModel>.Instance.HasAnySubEndingReward();
		return flag || flag2 || flag3;
	}
}
