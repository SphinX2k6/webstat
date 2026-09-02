using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;

// Token: 0x02001FFA RID: 8186
public class InfoDisplayCircleItem : AutoAttachExhibitionItemAbstract
{
	// Token: 0x0600F745 RID: 63301 RVA: 0x0043AEB4 File Offset: 0x004390B4
	[NullableContext(1)]
	public InfoDisplayCircleItem(AActor uiActor) : base(uiActor)
	{
	}

	// Token: 0x0600F746 RID: 63302 RVA: 0x0043AEE4 File Offset: 0x004390E4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickItem));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600F747 RID: 63303 RVA: 0x0043AF8C File Offset: 0x0043918C
	public override void RefreshItem(int showItemIndex)
	{
		if (this.Data == null)
		{
			return;
		}
		if (showItemIndex >= 0 && showItemIndex < this.Data.Length)
		{
			this.CurrentItemData = this.Data[showItemIndex];
		}
		this.RefreshTexture();
		UUIItem rootItem = base.GetRootItem();
		if (rootItem != null)
		{
			rootItem.SetHierarchyIndex(0);
		}
	}

	// Token: 0x0600F748 RID: 63304 RVA: 0x0043AFD8 File Offset: 0x004391D8
	public override void OnMoveItem(float vectorX)
	{
		AutoAttachExhibitionItem attachItem = base.GetAttachItem();
		if (attachItem == null || attachItem.ExhibitionView == null)
		{
			return;
		}
		Number width = attachItem.ExhibitionView.GetWidth();
		UUIItem rootItem = base.GetRootItem();
		if (rootItem == null)
		{
			return;
		}
		Number a = (rootItem.GetAnchorOffsetX() + width / 2) / width;
		FVector relativeScale3D = rootItem.RelativeScale3D;
		if (a >= 0.4f && a <= 0.6f)
		{
			if (a >= 0.4f && a <= 0.5f)
			{
				float num = a - 0.4f;
				float num2 = Singleton<MathUtils>.Instance.Lerp(0.8f, 1f, num * 10f);
				FVector uiitemScale = new FVector(num2, num2, num2);
				rootItem.SetUIItemScale(uiitemScale);
			}
			else
			{
				float num = a - 0.5f;
				float num3 = Singleton<MathUtils>.Instance.Lerp(1f, 0.8f, num * 10f);
				FVector uiitemScale2 = new FVector(num3, num3, num3);
				rootItem.SetUIItemScale(uiitemScale2);
			}
			UUIItem rootItem2 = base.GetRootItem();
			if (rootItem2 != null)
			{
				rootItem2.SetHierarchyIndex(3);
				return;
			}
		}
		else if (relativeScale3D.X != this.DefaultScale.X)
		{
			rootItem.SetUIItemScale(this.DefaultScale);
		}
	}

	// Token: 0x0600F749 RID: 63305 RVA: 0x0043B15A File Offset: 0x0043935A
	[NullableContext(2)]
	public override void SetData(object param)
	{
		this.Data = (param as string[]);
	}

	// Token: 0x0600F74A RID: 63306 RVA: 0x0043B168 File Offset: 0x00439368
	private void RefreshTexture()
	{
		if (this.CurrentItemData != "")
		{
			UUITexture texture = base.GetTexture(1);
			if (texture != null)
			{
				base.SetTextureByPath(this.CurrentItemData, texture, null, null);
			}
		}
	}

	// Token: 0x0600F74B RID: 63307 RVA: 0x0043B1AC File Offset: 0x004393AC
	private void OnClickItem()
	{
		AutoAttachExhibitionItem attachItem = base.GetAttachItem();
		if (attachItem == null || attachItem.ExhibitionView == null || attachItem.ExhibitionView.ItemActor == null)
		{
			return;
		}
		float width = attachItem.ExhibitionView.ItemActor.GetWidth();
		UUIItem rootItem = base.GetRootItem();
		if (rootItem == null)
		{
			return;
		}
		float num = (rootItem.GetAnchorOffsetX() + width / 2f) / width;
		if (num >= 0.4f && num <= 0.6f)
		{
			ModelBase<InfoDisplayModel>.Instance.SetCurrentOpenInformationTexture(this.CurrentItemData);
			ControllerBase<InfoDisplayController>.Instance.OpenInfoDisplayImgView();
		}
	}

	// Token: 0x04007762 RID: 30562
	private const int FRONT_HIERACHY = 3;

	// Token: 0x04007763 RID: 30563
	private const float ANIMAL_SCALE = 0.8f;

	// Token: 0x04007764 RID: 30564
	private const float LEFT_RANGE = 0.4f;

	// Token: 0x04007765 RID: 30565
	private const float MIDDLE_RANGE = 0.5f;

	// Token: 0x04007766 RID: 30566
	private const float RIGHT_RANGE = 0.6f;

	// Token: 0x04007767 RID: 30567
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private string[] Data;

	// Token: 0x04007768 RID: 30568
	[Nullable(1)]
	private string CurrentItemData = "";

	// Token: 0x04007769 RID: 30569
	private readonly FVector DefaultScale = new FVector(0.8f, 0.8f, 0.8f);

	// Token: 0x0200837C RID: 33660
	private class EInfoDisplayNoCircleItemComponents
	{
		// Token: 0x0402C97E RID: 182654
		public const int Btn = 0;

		// Token: 0x0402C97F RID: 182655
		public const int Texture = 1;
	}
}
