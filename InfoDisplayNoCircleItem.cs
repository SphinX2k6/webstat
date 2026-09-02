using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;

// Token: 0x02001FFF RID: 8191
public class InfoDisplayNoCircleItem : AutoAttachExhibitionItemAbstract
{
	// Token: 0x0600F75C RID: 63324 RVA: 0x0043B630 File Offset: 0x00439830
	[NullableContext(1)]
	public InfoDisplayNoCircleItem(AActor uiActor) : base(uiActor)
	{
	}

	// Token: 0x0600F75D RID: 63325 RVA: 0x0043B660 File Offset: 0x00439860
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

	// Token: 0x0600F75E RID: 63326 RVA: 0x0043B708 File Offset: 0x00439908
	public void RefreshItem()
	{
		if (this.Data == null)
		{
			return;
		}
		int showItemIndex = base.GetShowItemIndex();
		if (showItemIndex < 0 || showItemIndex >= this.Data.Length)
		{
			return;
		}
		this.CurrentItemData = this.Data[showItemIndex];
		if (string.IsNullOrEmpty(this.CurrentItemData))
		{
			return;
		}
		this.RefreshTexture();
		UUIItem rootItem = base.GetRootItem();
		if (rootItem != null)
		{
			rootItem.SetHierarchyIndex(0);
		}
	}

	// Token: 0x0600F75F RID: 63327 RVA: 0x0043B768 File Offset: 0x00439968
	[NullableContext(2)]
	public override void SetData(object param)
	{
		this.Data = (param as string[]);
	}

	// Token: 0x0600F760 RID: 63328 RVA: 0x0043B778 File Offset: 0x00439978
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

	// Token: 0x0600F761 RID: 63329 RVA: 0x0043B7BC File Offset: 0x004399BC
	public override void OnMoveItem(float vectorX)
	{
		UUIItem rootItem = base.GetRootItem();
		if (rootItem == null)
		{
			return;
		}
		AutoAttachExhibitionItem attachItem = base.GetAttachItem();
		if (((attachItem != null) ? attachItem.ExhibitionView : null) == null)
		{
			return;
		}
		Number width = attachItem.ExhibitionView.GetWidth();
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
				rootItem2.SetHierarchyIndex(1);
				return;
			}
		}
		else if (relativeScale3D.X != this.DefaultScale.X)
		{
			rootItem.SetUIItemScale(this.DefaultScale);
		}
	}

	// Token: 0x0600F762 RID: 63330 RVA: 0x0043B944 File Offset: 0x00439B44
	private void OnClickItem()
	{
		AutoAttachExhibitionItem attachItem = base.GetAttachItem();
		bool flag;
		if (attachItem == null)
		{
			flag = (null != null);
		}
		else
		{
			AutoAttachExhibitionView exhibitionView = attachItem.ExhibitionView;
			flag = (((exhibitionView != null) ? exhibitionView.ItemActor : null) != null);
		}
		if (!flag)
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

	// Token: 0x04007774 RID: 30580
	private const int FRONT_HIERACHY = 1;

	// Token: 0x04007775 RID: 30581
	private const float ANIMAL_SCALE = 0.8f;

	// Token: 0x04007776 RID: 30582
	private const float LEFT_RANGE = 0.4f;

	// Token: 0x04007777 RID: 30583
	private const float MIDDLE_RANGE = 0.5f;

	// Token: 0x04007778 RID: 30584
	private const float RIGHT_RANGE = 0.6f;

	// Token: 0x04007779 RID: 30585
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private string[] Data;

	// Token: 0x0400777A RID: 30586
	[Nullable(1)]
	private string CurrentItemData = "";

	// Token: 0x0400777B RID: 30587
	private readonly FVector DefaultScale = new FVector(0.8f, 0.8f, 0.8f);

	// Token: 0x02008380 RID: 33664
	private class EInfoDisplayNoCircleItemComponents
	{
		// Token: 0x0402C986 RID: 182662
		public const int Btn = 0;

		// Token: 0x0402C987 RID: 182663
		public const int Texture = 1;
	}
}
