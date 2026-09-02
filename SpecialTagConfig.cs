using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.Role.Common.Data.Structure;
using UnrealEngine;

// Token: 0x0200306A RID: 12394
[NullableContext(2)]
[Nullable(0)]
public class SpecialTagConfig
{
	// Token: 0x0601978B RID: 104331 RVA: 0x0075D798 File Offset: 0x0075B998
	public void Init(BaseTagComponent tagComp = null, BP_SpecialTagConfig_C asset = null, Func<double, bool> check = null)
	{
		if (asset == null || tagComp == null)
		{
			return;
		}
		int tag = asset.SpecialTagListener.SpecialTagListener.TagId();
		List<int> list = new List<int>();
		TArray<FGameplayTag> gameplayTags = asset.SpecialTagListener.ForbidTagList.GameplayTags;
		for (int i = 0; i < gameplayTags.Num(); i++)
		{
			list.Add(gameplayTags.Get(i).TagId());
		}
		List<int> list2 = new List<int>();
		TArray<FGameplayTag> gameplayTags2 = asset.SpecialTagListener.TargetTagList.GameplayTags;
		for (int j = 0; j < gameplayTags2.Num(); j++)
		{
			list2.Add(gameplayTags2.Get(j).TagId());
		}
		this.TagListenerInfo = new SpecialTagListener();
		this.TagListenerInfo.InitTagListener(tagComp, tag, list, list2, check);
	}

	// Token: 0x0601978C RID: 104332 RVA: 0x0075D85E File Offset: 0x0075BA5E
	public void Clear()
	{
		SpecialTagListener tagListenerInfo = this.TagListenerInfo;
		if (tagListenerInfo == null)
		{
			return;
		}
		tagListenerInfo.ClearTagListener();
	}

	// Token: 0x0601978D RID: 104333 RVA: 0x0075D870 File Offset: 0x0075BA70
	public void UpdateCondition(double delta)
	{
		SpecialTagListener tagListenerInfo = this.TagListenerInfo;
		if (tagListenerInfo == null)
		{
			return;
		}
		tagListenerInfo.UpdateCondition(delta);
	}

	// Token: 0x0400C9E4 RID: 51684
	private SpecialTagListener TagListenerInfo;
}
