using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001C5D RID: 7261
[NullableContext(1)]
[Nullable(0)]
public class FloroRanchEvolveItem : UiPanelBase
{
	// Token: 0x0600D3E9 RID: 54249 RVA: 0x00387BBC File Offset: 0x00385DBC
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600D3EA RID: 54250 RVA: 0x00387C67 File Offset: 0x00385E67
	protected override void OnStart()
	{
		this.TemplateItem = base.GetItem(2);
		this.TemplateItem.SetUIActive(false);
	}

	// Token: 0x0600D3EB RID: 54251 RVA: 0x00387C84 File Offset: 0x00385E84
	[NullableContext(2)]
	public void Refresh(FloroRanchEvolveData evolveData)
	{
		if (evolveData == null)
		{
			base.GetRootItem().SetUIActive(false);
			return;
		}
		base.GetRootItem().SetUIActive(true);
		base.GetText(1).SetText(evolveData.CurLevel.ToString(), true);
		base.GetSprite(0).SetFillAmount((float)evolveData.CurExp * 1f / (float)evolveData.ExpPerLevel);
		this.RefreshLineItem(evolveData);
	}

	// Token: 0x0600D3EC RID: 54252 RVA: 0x00387CF0 File Offset: 0x00385EF0
	private void RefreshLineItem(FloroRanchEvolveData evolveData)
	{
		if (this.LineItemList.Count < evolveData.ExpPerLevel)
		{
			for (int i = this.LineItemList.Count; i < evolveData.ExpPerLevel; i++)
			{
				UUIItem item = this.CreateItem();
				this.LineItemList.Add(item);
			}
		}
		float num = 360f / (float)evolveData.ExpPerLevel;
		for (int j = 0; j < this.LineItemList.Count; j++)
		{
			UUIItem uuiitem = this.LineItemList[j];
			if (j >= evolveData.ExpPerLevel)
			{
				uuiitem.SetUIActive(false);
			}
			else
			{
				uuiitem.SetUIActive(true);
				FRotator frotator = new FRotator(0f, 180f - num * (float)j, 0f);
				uuiitem.SetUIRelativeRotation(frotator);
			}
		}
	}

	// Token: 0x0600D3ED RID: 54253 RVA: 0x00387DAF File Offset: 0x00385FAF
	private UUIItem CreateItem()
	{
		return Singleton<LguiUtil>.Instance.CopyItem(this.TemplateItem, base.GetItem(3));
	}

	// Token: 0x040064CD RID: 25805
	private const int LINE_ROTATOR_YAW_OFFSET = 180;

	// Token: 0x040064CE RID: 25806
	private UUIItem TemplateItem;

	// Token: 0x040064CF RID: 25807
	private readonly List<UUIItem> LineItemList = new List<UUIItem>();

	// Token: 0x02007F71 RID: 32625
	[NullableContext(0)]
	private class EComponent
	{
		// Token: 0x0402B634 RID: 177716
		public const int ProgressSprite = 0;

		// Token: 0x0402B635 RID: 177717
		public const int LevelText = 1;

		// Token: 0x0402B636 RID: 177718
		public const int LineItem = 2;

		// Token: 0x0402B637 RID: 177719
		public const int LineRoot = 3;
	}
}
