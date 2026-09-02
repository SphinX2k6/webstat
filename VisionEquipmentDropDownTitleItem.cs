using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

// Token: 0x020024FB RID: 9467
public class VisionEquipmentDropDownTitleItem : TitleItemBase<int>
{
	// Token: 0x06012630 RID: 75312 RVA: 0x0050E515 File Offset: 0x0050C715
	[NullableContext(1)]
	public VisionEquipmentDropDownTitleItem(UUIItem uiItem) : base(uiItem)
	{
	}

	// Token: 0x06012631 RID: 75313 RVA: 0x0050E51E File Offset: 0x0050C71E
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIItem))
		};
	}

	// Token: 0x06012632 RID: 75314 RVA: 0x0050E558 File Offset: 0x0050C758
	[NullableContext(1)]
	public override void ShowTemp(int data, DropDownItemBase<int> selectedItemObj)
	{
		if (this.VisionFetterSuitItem == null)
		{
			this.VisionFetterSuitItem = new VisionFetterSuitItem(base.GetItem(1));
			this.VisionFetterSuitItem.Init();
		}
		string newText;
		if (data > 0)
		{
			newText = (ConfigMultiTextLang.GetLocalTextNew(ConfigBase<PhantomBattleConfig>.Instance.GetFetterGroupById(data).FetterGroupName, null) ?? "");
		}
		else
		{
			newText = (ConfigMultiTextLang.GetLocalTextNew("Text_FilterTextAllVisionFetter_Text", null) ?? "");
		}
		base.GetText(0).SetText(newText, true);
		bool flag = true;
		if (flag)
		{
			PhantomFetterGroup? fetterGroupData = (data > 0) ? new PhantomFetterGroup?(ConfigBase<PhantomBattleConfig>.Instance.GetFetterGroupById(data)) : null;
			this.VisionFetterSuitItem.Update(fetterGroupData);
		}
		this.VisionFetterSuitItem.SetActive(flag);
	}

	// Token: 0x06012633 RID: 75315 RVA: 0x0050E619 File Offset: 0x0050C819
	protected override void OnBeforeDestroy()
	{
		VisionFetterSuitItem visionFetterSuitItem = this.VisionFetterSuitItem;
		if (visionFetterSuitItem == null)
		{
			return;
		}
		visionFetterSuitItem.Destroy(null);
	}

	// Token: 0x04008F67 RID: 36711
	[Nullable(2)]
	private VisionFetterSuitItem VisionFetterSuitItem;

	// Token: 0x02008817 RID: 34839
	private enum EComponent
	{
		// Token: 0x0402DF82 RID: 188290
		TxtOption,
		// Token: 0x0402DF83 RID: 188291
		SuitElementItem
	}
}
