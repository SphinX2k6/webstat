using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200252C RID: 9516
public class VisionNewRecommendPreviewEquipItem : UiPanelBase
{
	// Token: 0x0601283D RID: 75837 RVA: 0x00519DC8 File Offset: 0x00517FC8
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem))
		};
	}

	// Token: 0x0601283E RID: 75838 RVA: 0x00519E50 File Offset: 0x00518050
	protected override UniTask OnBeforeStartAsync()
	{
		VisionNewRecommendPreviewEquipItem.<OnBeforeStartAsync>d__3 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<VisionNewRecommendPreviewEquipItem.<OnBeforeStartAsync>d__3>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0601283F RID: 75839 RVA: 0x00519E94 File Offset: 0x00518094
	public void Update([Nullable(new byte[]
	{
		1,
		2
	})] List<VisionNewRecommendPhantomItemData> data)
	{
		for (int i = 0; i < this.AssembleItemList.Count; i++)
		{
			VisionNewRecommendPhantomItemData visionNewRecommendPhantomItemData = (i < data.Count) ? data[i] : null;
			if (visionNewRecommendPhantomItemData != null)
			{
				this.AssembleItemList[i].Update(visionNewRecommendPhantomItemData);
			}
			else
			{
				this.AssembleItemList[i].Reset();
			}
		}
	}

	// Token: 0x04009059 RID: 36953
	[Nullable(1)]
	private readonly List<VisionNewRecommendPhantomItem> AssembleItemList = new List<VisionNewRecommendPhantomItem>();

	// Token: 0x02008852 RID: 34898
	private enum EComp
	{
		// Token: 0x0402E0B7 RID: 188599
		VisionAssembleItem1,
		// Token: 0x0402E0B8 RID: 188600
		VisionAssembleItem2,
		// Token: 0x0402E0B9 RID: 188601
		VisionAssembleItem3,
		// Token: 0x0402E0BA RID: 188602
		VisionAssembleItem4,
		// Token: 0x0402E0BB RID: 188603
		VisionAssembleItem5
	}
}
