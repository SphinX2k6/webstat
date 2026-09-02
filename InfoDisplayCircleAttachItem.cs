using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.AutoAttach;
using UnrealEngine;

// Token: 0x02001FF9 RID: 8185
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class InfoDisplayCircleAttachItem : AutoAttachItem<string>
{
	// Token: 0x0600F73D RID: 63293 RVA: 0x0043AC0C File Offset: 0x00438E0C
	public InfoDisplayCircleAttachItem(AActor actor) : base(actor)
	{
	}

	// Token: 0x0600F73E RID: 63294 RVA: 0x0043AC3C File Offset: 0x00438E3C
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

	// Token: 0x0600F73F RID: 63295 RVA: 0x0043ACE4 File Offset: 0x00438EE4
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

	// Token: 0x0600F740 RID: 63296 RVA: 0x0043AD10 File Offset: 0x00438F10
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
				rootItem.SetHierarchyIndex(3);
				return;
			}
		}
		else if (relativeScale3D.X != this.DefaultScale.X)
		{
			this.RootItem.SetUIItemScale(this.DefaultScale);
		}
	}

	// Token: 0x0600F741 RID: 63297 RVA: 0x0043AE1C File Offset: 0x0043901C
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

	// Token: 0x0600F742 RID: 63298 RVA: 0x0043AE5D File Offset: 0x0043905D
	public override void OnSelect()
	{
	}

	// Token: 0x0600F743 RID: 63299 RVA: 0x0043AE5F File Offset: 0x0043905F
	protected override void OnUnSelect()
	{
	}

	// Token: 0x0600F744 RID: 63300 RVA: 0x0043AE64 File Offset: 0x00439064
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

	// Token: 0x0400775B RID: 30555
	private const int FRONT_HIERACHY = 3;

	// Token: 0x0400775C RID: 30556
	private const float ANIMAL_SCALE = 0.8f;

	// Token: 0x0400775D RID: 30557
	private const float LEFT_RANGE = 0.4f;

	// Token: 0x0400775E RID: 30558
	private const float MIDDLE_RANGE = 0.5f;

	// Token: 0x0400775F RID: 30559
	private const float RIGHT_RANGE = 0.6f;

	// Token: 0x04007760 RID: 30560
	private string CurrentItemData = "";

	// Token: 0x04007761 RID: 30561
	private readonly FVector DefaultScale = new FVector(0.8f, 0.8f, 0.8f);

	// Token: 0x0200837B RID: 33659
	[NullableContext(0)]
	private class EInfoDisplayNoCircleItemComponents
	{
		// Token: 0x0402C97C RID: 182652
		public const int Btn = 0;

		// Token: 0x0402C97D RID: 182653
		public const int Texture = 1;
	}
}
