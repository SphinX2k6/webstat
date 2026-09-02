using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.AutoAttach;
using UnrealEngine;

// Token: 0x02001FFE RID: 8190
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class InfoDisplayNoCircleAttachItem : AutoAttachItem<string>
{
	// Token: 0x0600F754 RID: 63316 RVA: 0x0043B387 File Offset: 0x00439587
	public InfoDisplayNoCircleAttachItem(AActor actor) : base(actor)
	{
	}

	// Token: 0x0600F755 RID: 63317 RVA: 0x0043B3B8 File Offset: 0x004395B8
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

	// Token: 0x0600F756 RID: 63318 RVA: 0x0043B460 File Offset: 0x00439660
	protected override void OnRefreshItem(string data)
	{
		this.CurrentItemData = data;
		this.RefreshTexture();
		UUIItem rootItem = base.GetRootItem();
		if (rootItem != null)
		{
			rootItem.SetHierarchyIndex(0);
		}
	}

	// Token: 0x0600F757 RID: 63319 RVA: 0x0043B48C File Offset: 0x0043968C
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

	// Token: 0x0600F758 RID: 63320 RVA: 0x0043B4D0 File Offset: 0x004396D0
	protected override void OnMoveItem()
	{
		float currentMovePercentage = base.GetCurrentMovePercentage();
		if (this.RootItem == null)
		{
			return;
		}
		FVector relativeScale3D = this.RootItem.RelativeScale3D;
		if (currentMovePercentage >= 0.4f && currentMovePercentage <= 0.6f)
		{
			if (currentMovePercentage >= 0.4f && currentMovePercentage <= 0.5f)
			{
				float num = currentMovePercentage - 0.4f;
				float num2 = Singleton<MathUtils>.Instance.Lerp(0.8f, 1f, num * 10f);
				FVector uiitemScale = new FVector(num2, num2, num2);
				this.RootItem.SetUIItemScale(uiitemScale);
			}
			else
			{
				float num = currentMovePercentage - 0.5f;
				float num3 = Singleton<MathUtils>.Instance.Lerp(1f, 0.8f, num * 10f);
				FVector uiitemScale2 = new FVector(num3, num3, num3);
				this.RootItem.SetUIItemScale(uiitemScale2);
			}
			UUIItem rootItem = base.GetRootItem();
			if (rootItem != null)
			{
				rootItem.SetHierarchyIndex(1);
				return;
			}
		}
		else if (relativeScale3D.X != this.DefaultScale.X)
		{
			this.RootItem.SetUIItemScale(this.DefaultScale);
		}
	}

	// Token: 0x0600F759 RID: 63321 RVA: 0x0043B5DB File Offset: 0x004397DB
	public override void OnSelect()
	{
	}

	// Token: 0x0600F75A RID: 63322 RVA: 0x0043B5DD File Offset: 0x004397DD
	protected override void OnUnSelect()
	{
	}

	// Token: 0x0600F75B RID: 63323 RVA: 0x0043B5E0 File Offset: 0x004397E0
	private void OnClickItem()
	{
		float currentMovePercentage = base.GetCurrentMovePercentage();
		if (currentMovePercentage >= 0.4f && currentMovePercentage <= 0.6f)
		{
			ModelBase<InfoDisplayModel>.Instance.SetCurrentOpenInformationTexture(this.CurrentItemData);
			ControllerBase<InfoDisplayController>.Instance.OpenInfoDisplayImgView();
			return;
		}
		Singleton<EventSystem>.Instance.Emit<AutoAttachItem<string>>(EEventName.ClickDisplayItem, this);
	}

	// Token: 0x0400776D RID: 30573
	private const int FRONT_HIERACHY = 1;

	// Token: 0x0400776E RID: 30574
	private const float ANIMAL_SCALE = 0.8f;

	// Token: 0x0400776F RID: 30575
	private const float LEFT_RANGE = 0.4f;

	// Token: 0x04007770 RID: 30576
	private const float MIDDLE_RANGE = 0.5f;

	// Token: 0x04007771 RID: 30577
	private const float RIGHT_RANGE = 0.6f;

	// Token: 0x04007772 RID: 30578
	private string CurrentItemData = "";

	// Token: 0x04007773 RID: 30579
	private readonly FVector DefaultScale = new FVector(0.8f, 0.8f, 0.8f);

	// Token: 0x0200837F RID: 33663
	[NullableContext(0)]
	private class EInfoDisplayNoCircleItemComponents
	{
		// Token: 0x0402C984 RID: 182660
		public const int Btn = 0;

		// Token: 0x0402C985 RID: 182661
		public const int Texture = 1;
	}
}
