using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

// Token: 0x02002BC0 RID: 11200
[NullableContext(1)]
[Nullable(0)]
public class TimeOfDaySecondCircleItem : AutoAttachExhibitionItemAbstract
{
	// Token: 0x06016508 RID: 91400 RVA: 0x0062E8EC File Offset: 0x0062CAEC
	public TimeOfDaySecondCircleItem(AActor uiItem) : base(uiItem)
	{
	}

	// Token: 0x06016509 RID: 91401 RVA: 0x0062E94C File Offset: 0x0062CB4C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 6;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		Action item = delegate()
		{
			this.OnClickStoneBtn();
		};
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(3, item);
		this.BtnBindInfo = list2;
	}

	// Token: 0x0601650A RID: 91402 RVA: 0x0062EA79 File Offset: 0x0062CC79
	public override void RefreshItem(int showItemIndex)
	{
		this.CurrentShowItemIndex = showItemIndex;
		this.CurrentItemData = this.Data[showItemIndex];
		this.RefreshShowText();
		this.RefreshArrow();
	}

	// Token: 0x0601650B RID: 91403 RVA: 0x0062EA9C File Offset: 0x0062CC9C
	private void RefreshShowText()
	{
		if (this.CurrentItemData != null)
		{
			base.GetText(2).SetText(this.CurrentItemData.ShowName, true);
			string newText = TodDayTime.ConvertToHourMinuteString((double)this.CurrentItemData.SetTime);
			base.GetText(1).SetText(newText, true);
		}
	}

	// Token: 0x0601650C RID: 91404 RVA: 0x0062EAEC File Offset: 0x0062CCEC
	private void RefreshArrow()
	{
		if (this.CurrentItemData != null)
		{
			int num = this.CurrentItemData.SetTime / 3600;
			if (num > 12)
			{
				num -= 12;
			}
			int num2 = 360 - 30 * num;
			UUIItem item = base.GetItem(0);
			this.ArrowRotator.Yaw = (float)num2;
			FRotator frotator = this.ArrowRotator.ToUeRotator();
			item.SetUIRelativeRotation(frotator);
		}
	}

	// Token: 0x0601650D RID: 91405 RVA: 0x0062EB4F File Offset: 0x0062CD4F
	public override void SetData(object param)
	{
		this.Data = (TimeOfDaySecondItemSt[])param;
	}

	// Token: 0x0601650E RID: 91406 RVA: 0x0062EB60 File Offset: 0x0062CD60
	public override void OnMoveItem(float offset)
	{
		float width = base.GetAttachItem().ExhibitionView.ItemActor.GetWidth();
		UUIItem rootItem = base.GetRootItem();
		float num = (rootItem.GetAnchorOffsetX() + width / 2f) / width;
		FVector relativeScale3D = rootItem.RelativeScale3D;
		float alpha = 0f;
		float num2;
		if (num > 0.1f && num < 0.5f)
		{
			num2 = (num - 0.1f) / 0.4f;
			alpha = Singleton<MathUtils>.Instance.Lerp(0.65f, 1f, num2);
		}
		else if (num > 0.04f && num < 0.1f)
		{
			num2 = (num - 0.04f) / 0.060000002f;
			alpha = Singleton<MathUtils>.Instance.Lerp(0f, 0.65f, num2);
		}
		else if (num <= 0.04f)
		{
			alpha = 0f;
		}
		if (num >= 0.5f && num < 0.9f)
		{
			num2 = (num - 0.5f) / 0.39999998f;
			alpha = Singleton<MathUtils>.Instance.Lerp(1f, 0.65f, num2);
		}
		else if (num >= 0.9f && num < 0.96f)
		{
			num2 = (num - 0.9f) / 0.060000002f;
			alpha = Singleton<MathUtils>.Instance.Lerp(0.65f, 0f, num2);
		}
		else if (num >= 0.96f)
		{
			alpha = 0f;
		}
		base.GetItem(5).SetAlpha(alpha);
		if (num > 0.3f && num < 0.5f)
		{
			num2 = (num - 0.3f) / 0.19999999f;
			alpha = Singleton<MathUtils>.Instance.Lerp(0f, 1f, num2);
		}
		else if (num >= 0.5f && num < 0.7f)
		{
			num2 = (num - 0.5f) / 0.19999999f;
			alpha = Singleton<MathUtils>.Instance.Lerp(1f, 0f, num2);
		}
		else
		{
			alpha = 0f;
		}
		base.GetTexture(4).SetAlpha(alpha);
		if (num < 0.4f || num > 0.6f)
		{
			if (relativeScale3D.X != this.DefaultScale.X)
			{
				rootItem.SetUIItemScale(this.DefaultScale);
			}
			return;
		}
		if (num >= 0.4f && num <= 0.5f)
		{
			num2 = num - 0.4f;
			float num3 = Singleton<MathUtils>.Instance.Lerp(0.9f, 1f, num2 * 10f);
			FVector uiitemScale = new FVector(num3, num3, num3);
			rootItem.SetUIItemScale(uiitemScale);
			return;
		}
		num2 = num - 0.5f;
		float num4 = Singleton<MathUtils>.Instance.Lerp(1f, 0.9f, num2 * 10f);
		FVector uiitemScale2 = new FVector(num4, num4, num4);
		rootItem.SetUIItemScale(uiitemScale2);
	}

	// Token: 0x0601650F RID: 91407 RVA: 0x0062EE06 File Offset: 0x0062D006
	public override void OnUnSelect()
	{
	}

	// Token: 0x06016510 RID: 91408 RVA: 0x0062EE08 File Offset: 0x0062D008
	public override void OnSelect()
	{
		ModelBase<TimeOfDayModel>.Instance.CurrentSelectTimeItemSt = this.CurrentItemData;
		Singleton<EventSystem>.Instance.Emit(EEventName.OnSelectTimeItem);
	}

	// Token: 0x0400ACCF RID: 44239
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TimeOfDaySecondItemSt[] Data;

	// Token: 0x0400ACD0 RID: 44240
	[Nullable(2)]
	private TimeOfDaySecondItemSt CurrentItemData;

	// Token: 0x0400ACD1 RID: 44241
	private readonly Rotator ArrowRotator = Rotator.Create();

	// Token: 0x0400ACD2 RID: 44242
	private readonly FVector DefaultScale = new FVector(0.9f, 0.9f, 0.9f);

	// Token: 0x0400ACD3 RID: 44243
	private const float ANIMAL_SCALE = 0.9f;

	// Token: 0x0400ACD4 RID: 44244
	private const int MIDDLE_TIME = 12;

	// Token: 0x0400ACD5 RID: 44245
	private const int FULL_ANGLE = 360;

	// Token: 0x0400ACD6 RID: 44246
	private const int ONE_HOUR_ANGLE = 30;

	// Token: 0x0400ACD7 RID: 44247
	private const float LEFT_RANGE = 0.4f;

	// Token: 0x0400ACD8 RID: 44248
	private const float MIDDLE_RANGE = 0.5f;

	// Token: 0x0400ACD9 RID: 44249
	private const float RIGHT_RANGE = 0.6f;

	// Token: 0x0400ACDA RID: 44250
	private const float BORDER_ALPHA = 0.65f;

	// Token: 0x0400ACDB RID: 44251
	private const float BORDER_RIGHT = 0.9f;

	// Token: 0x0400ACDC RID: 44252
	private const float BORDER_LEFT = 0.1f;

	// Token: 0x0400ACDD RID: 44253
	private const float BORDER_LEFT_HIDE = 0.04f;

	// Token: 0x0400ACDE RID: 44254
	private const float BORDER_RIGHT_HIDE = 0.96f;

	// Token: 0x0400ACDF RID: 44255
	private const float BORDER_MIDDLE = 0.5f;

	// Token: 0x0400ACE0 RID: 44256
	private const float STONE2_BORDER_LEFT = 0.3f;

	// Token: 0x0400ACE1 RID: 44257
	private const float STONE2_BORDER_RIGHT = 0.7f;

	// Token: 0x0400ACE2 RID: 44258
	private readonly Action OnClickStoneBtn = delegate()
	{
	};

	// Token: 0x02008EB6 RID: 36534
	[NullableContext(0)]
	private enum ETimeOfDaySecondItemComponents
	{
		// Token: 0x0402FF5B RID: 196443
		Arrow,
		// Token: 0x0402FF5C RID: 196444
		TimeText,
		// Token: 0x0402FF5D RID: 196445
		CurrentTimeShowText,
		// Token: 0x0402FF5E RID: 196446
		StoneBtn,
		// Token: 0x0402FF5F RID: 196447
		StoneMixTexture,
		// Token: 0x0402FF60 RID: 196448
		SelfItem
	}
}
