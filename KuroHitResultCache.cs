using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02002DDE RID: 11742
[NullableContext(1)]
[Nullable(0)]
public class KuroHitResultCache
{
	// Token: 0x06017AA9 RID: 96937 RVA: 0x0069AA30 File Offset: 0x00698C30
	public void Append(UKuroHitResult ueObj)
	{
		int hitCount = ueObj.GetHitCount();
		this.HitCount += hitCount;
		TArray<TWeakObjectPtr<AActor>> actors = ueObj.Actors;
		TArray<string> boneNameArray = ueObj.BoneNameArray;
		TArray<TWeakObjectPtr<UPrimitiveComponent>> components = ueObj.Components;
		TArray<float> impactPointX_Array = ueObj.ImpactPointX_Array;
		TArray<float> impactPointY_Array = ueObj.ImpactPointY_Array;
		TArray<float> impactPointZ_Array = ueObj.ImpactPointZ_Array;
		for (int i = 0; i < hitCount; i++)
		{
			this.Actors.Add(actors.Get(i));
			this.BoneNameArray.Add(FNameUtil.GetDynamicFName(boneNameArray.Get(i)).Value);
			this.Components.Add(components.Get(i));
			this.ImpactPointX.Add(impactPointX_Array.Get(i));
			this.ImpactPointY.Add(impactPointY_Array.Get(i));
			this.ImpactPointZ.Add(impactPointZ_Array.Get(i));
		}
	}

	// Token: 0x0400B68D RID: 46733
	public int HitCount;

	// Token: 0x0400B68E RID: 46734
	public List<AActor> Actors = new List<AActor>();

	// Token: 0x0400B68F RID: 46735
	public List<FName> BoneNameArray = new List<FName>();

	// Token: 0x0400B690 RID: 46736
	[Nullable(new byte[]
	{
		1,
		0,
		1
	})]
	public List<TWeakObjectPtr<UPrimitiveComponent>> Components = new List<TWeakObjectPtr<UPrimitiveComponent>>();

	// Token: 0x0400B691 RID: 46737
	public List<float> ImpactPointX = new List<float>();

	// Token: 0x0400B692 RID: 46738
	public List<float> ImpactPointY = new List<float>();

	// Token: 0x0400B693 RID: 46739
	public List<float> ImpactPointZ = new List<float>();

	// Token: 0x0400B694 RID: 46740
	[StaticVariableRuleIgnore]
	private static readonly Stat stat = Stat.Create("KuroHitResultCache", "", "");
}
