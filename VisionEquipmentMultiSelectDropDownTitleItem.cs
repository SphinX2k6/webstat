using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Core.Extension;
using Cysharp.Threading.Tasks;
using UnrealEngine;

// Token: 0x020024FC RID: 9468
public class VisionEquipmentMultiSelectDropDownTitleItem : MultiSelectTitleItemBase<int>
{
	// Token: 0x06012634 RID: 75316 RVA: 0x0050E62C File Offset: 0x0050C82C
	[NullableContext(1)]
	public VisionEquipmentMultiSelectDropDownTitleItem(UUIItem uiItem) : base(uiItem)
	{
	}

	// Token: 0x06012635 RID: 75317 RVA: 0x0050E635 File Offset: 0x0050C835
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIItem))
		};
	}

	// Token: 0x06012636 RID: 75318 RVA: 0x0050E670 File Offset: 0x0050C870
	[NullableContext(1)]
	public override void ShowMultiSelectTitle(IReadOnlyList<int> dataList)
	{
		if (this.VisionFetterSuitItem == null)
		{
			this.VisionFetterSuitItem = new VisionFetterSuitItem(base.GetItem(1));
			this.VisionFetterSuitItem.Init().Finally(delegate()
			{
			}).Forget();
		}
		if (dataList.Count == 0 || dataList.Contains(0))
		{
			string newText = ConfigMultiTextLang.GetLocalTextNew("Text_FilterTextAllVisionFetter_Text", null) ?? "";
			base.GetText(0).SetText(newText, true);
			this.VisionFetterSuitItem.SetActive(false);
			return;
		}
		if (dataList.Count == 1)
		{
			int groupId = dataList[0];
			PhantomFetterGroup fetterGroupById = ConfigBase<PhantomBattleConfig>.Instance.GetFetterGroupById(groupId);
			string newText2 = ConfigMultiTextLang.GetLocalTextNew(fetterGroupById.FetterGroupName, null) ?? "";
			base.GetText(0).SetText(newText2, true);
			this.VisionFetterSuitItem.Update(new PhantomFetterGroup?(fetterGroupById));
			this.VisionFetterSuitItem.SetActive(true);
			return;
		}
		List<string> list = new List<string>();
		foreach (int num in dataList)
		{
			if (num > 0)
			{
				list.Add(ConfigMultiTextLang.GetLocalTextNew(ConfigBase<PhantomBattleConfig>.Instance.GetFetterGroupById(num).FetterGroupName, null) ?? "");
			}
		}
		base.GetText(0).SetText(string.Join(",", list), true);
		this.VisionFetterSuitItem.SetActive(false);
	}

	// Token: 0x06012637 RID: 75319 RVA: 0x0050E804 File Offset: 0x0050CA04
	protected override void OnBeforeDestroy()
	{
		VisionFetterSuitItem visionFetterSuitItem = this.VisionFetterSuitItem;
		if (visionFetterSuitItem == null)
		{
			return;
		}
		visionFetterSuitItem.Destroy(null);
	}

	// Token: 0x04008F68 RID: 36712
	[Nullable(2)]
	private VisionFetterSuitItem VisionFetterSuitItem;

	// Token: 0x02008818 RID: 34840
	private enum EComponent
	{
		// Token: 0x0402DF85 RID: 188293
		TxtOption,
		// Token: 0x0402DF86 RID: 188294
		SuitElementItem
	}
}
