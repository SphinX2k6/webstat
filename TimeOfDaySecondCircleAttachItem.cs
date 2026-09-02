using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.AutoAttach;
using UnrealEngine;

// Token: 0x02002BBF RID: 11199
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
public class TimeOfDaySecondCircleAttachItem : AutoAttachItem<TimeOfDaySecondItemSt>, IStaticVariableResetter
{
	// Token: 0x060164FC RID: 91388 RVA: 0x0062E2A6 File Offset: 0x0062C4A6
	static TimeOfDaySecondCircleAttachItem()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(TimeOfDaySecondCircleAttachItem.CreateStaticDefaultValue), new Action(TimeOfDaySecondCircleAttachItem.ResetStaticDefaultValue));
	}

	// Token: 0x060164FD RID: 91389 RVA: 0x0062E2C5 File Offset: 0x0062C4C5
	public TimeOfDaySecondCircleAttachItem(AActor uiItem = null) : base(uiItem)
	{
	}

	// Token: 0x060164FE RID: 91390 RVA: 0x0062E2F3 File Offset: 0x0062C4F3
	public static void CreateStaticDefaultValue()
	{
		TimeOfDaySecondCircleAttachItem.MiddleOffsetCurve = null;
	}

	// Token: 0x060164FF RID: 91391 RVA: 0x0062E2FB File Offset: 0x0062C4FB
	public static void ResetStaticDefaultValue()
	{
		TimeOfDaySecondCircleAttachItem.MiddleOffsetCurve = null;
	}

	// Token: 0x06016500 RID: 91392 RVA: 0x0062E304 File Offset: 0x0062C504
	protected unsafe override void OnRegisterComponent()
	{
		int num = 9;
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
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClickStoneBtn));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06016501 RID: 91393 RVA: 0x0062E492 File Offset: 0x0062C692
	[NullableContext(1)]
	protected override void OnRefreshItem(TimeOfDaySecondItemSt data)
	{
		this.CurrentItemData = data;
		base.GetItem(6).SetUIActive(data == null);
		base.GetItem(7).SetUIActive(data != null);
		this.RefreshShowText();
		this.RefreshArrow();
		this.OnMoveItem();
	}

	// Token: 0x06016502 RID: 91394 RVA: 0x0062E4D0 File Offset: 0x0062C6D0
	private void RefreshShowText()
	{
		if (this.CurrentItemData != null)
		{
			base.GetText(2).SetText(this.CurrentItemData.ShowName, true);
			string newText = TodDayTime.ConvertToHourMinuteString((double)this.CurrentItemData.SetTime);
			base.GetText(1).SetText(newText, true);
		}
	}

	// Token: 0x06016503 RID: 91395 RVA: 0x0062E520 File Offset: 0x0062C720
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

	// Token: 0x06016504 RID: 91396 RVA: 0x0062E584 File Offset: 0x0062C784
	protected override void OnMoveItem()
	{
		float currentMovePercentage = base.GetCurrentMovePercentage();
		FVector relativeScale3D = this.RootItem.RelativeScale3D;
		float num = 0f;
		float num2;
		if (currentMovePercentage >= 0.34375f && currentMovePercentage < 0.5f)
		{
			num2 = (currentMovePercentage - 0.34375f) / 0.15625f;
			num = Singleton<MathUtils>.Instance.Lerp(0.8f, 1f, num2);
		}
		else if (currentMovePercentage > 0.03125f && currentMovePercentage < 0.34375f)
		{
			num2 = (currentMovePercentage - 0.03125f) / 0.3125f;
			num = Singleton<MathUtils>.Instance.Lerp(0.4f, 0.8f, num2);
		}
		else if (currentMovePercentage <= 0.03125f)
		{
			num = 0.4f;
		}
		if (currentMovePercentage >= 0.5f && currentMovePercentage < 0.65625f)
		{
			num2 = (currentMovePercentage - 0.5f) / 0.15625f;
			num = Singleton<MathUtils>.Instance.Lerp(1f, 0.8f, num2);
		}
		else if (currentMovePercentage >= 0.65625f && currentMovePercentage < 0.96875f)
		{
			num2 = (currentMovePercentage - 0.65625f) / 0.3125f;
			num = Singleton<MathUtils>.Instance.Lerp(0.8f, 0.4f, num2);
		}
		else if (currentMovePercentage >= 0.96875f)
		{
			num = 0.4f;
		}
		base.GetItem(5).SetAlpha(num);
		float anchorOffsetX;
		if (currentMovePercentage > 0.375f && currentMovePercentage < 0.5f)
		{
			num2 = (currentMovePercentage - 0.375f) / 0.125f;
			num = Singleton<MathUtils>.Instance.Lerp(0f, 1f, num2);
			UCurveFloat middleOffsetCurve = TimeOfDaySecondCircleAttachItem.MiddleOffsetCurve;
			anchorOffsetX = -((middleOffsetCurve != null) ? middleOffsetCurve.GetFloatValue(1f - num2) : 0f);
		}
		else if (currentMovePercentage >= 0.5f && currentMovePercentage < 0.625f)
		{
			num2 = (currentMovePercentage - 0.5f) / 0.125f;
			num = Singleton<MathUtils>.Instance.Lerp(1f, 0f, num2);
			UCurveFloat middleOffsetCurve2 = TimeOfDaySecondCircleAttachItem.MiddleOffsetCurve;
			anchorOffsetX = ((middleOffsetCurve2 != null) ? middleOffsetCurve2.GetFloatValue(num2) : 0f);
		}
		else
		{
			num = 0f;
			UCurveFloat middleOffsetCurve3 = TimeOfDaySecondCircleAttachItem.MiddleOffsetCurve;
			float num3 = (middleOffsetCurve3 != null) ? middleOffsetCurve3.GetFloatValue(1f) : 0f;
			if (currentMovePercentage < 0.375f)
			{
				anchorOffsetX = -num3;
			}
			else
			{
				anchorOffsetX = num3;
			}
		}
		base.GetItem(7).SetAnchorOffsetX(anchorOffsetX);
		base.GetItem(6).SetAnchorOffsetX(anchorOffsetX);
		base.GetItem(8).SetAlpha(Math.Max(0.2f, num));
		base.GetTexture(4).SetAlpha(num);
		if (currentMovePercentage < 0.4f || currentMovePercentage > 0.6f)
		{
			if (relativeScale3D.X != this.DefaultScale.X)
			{
				this.RootItem.SetUIItemScale(this.DefaultScale);
			}
			return;
		}
		if (currentMovePercentage >= 0.4f && currentMovePercentage <= 0.5f)
		{
			num2 = currentMovePercentage - 0.4f;
			float num4 = Singleton<MathUtils>.Instance.Lerp(0.8f, 1f, num2 * 10f);
			FVector uiitemScale = new FVector(num4, num4, num4);
			uiitemScale.Set(num4, num4, num4);
			this.RootItem.SetUIItemScale(uiitemScale);
			return;
		}
		num2 = currentMovePercentage - 0.5f;
		float num5 = Singleton<MathUtils>.Instance.Lerp(1f, 0.8f, num2 * 10f);
		FVector uiitemScale2 = new FVector(num5, num5, num5);
		this.RootItem.SetUIItemScale(uiitemScale2);
	}

	// Token: 0x06016505 RID: 91397 RVA: 0x0062E8AA File Offset: 0x0062CAAA
	private void OnClickStoneBtn()
	{
		if (this.CurrentItemData == null)
		{
			return;
		}
		Singleton<EventSystem>.Instance.Emit<TimeOfDaySecondCircleAttachItem>(EEventName.ClickTimeItem, this);
	}

	// Token: 0x06016506 RID: 91398 RVA: 0x0062E8C6 File Offset: 0x0062CAC6
	protected override void OnUnSelect()
	{
	}

	// Token: 0x06016507 RID: 91399 RVA: 0x0062E8C8 File Offset: 0x0062CAC8
	public override void OnSelect()
	{
		ModelBase<TimeOfDayModel>.Instance.CurrentSelectTimeItemSt = this.CurrentItemData;
		Singleton<EventSystem>.Instance.Emit(EEventName.OnSelectTimeItem);
	}

	// Token: 0x0400ACBB RID: 44219
	private TimeOfDaySecondItemSt CurrentItemData;

	// Token: 0x0400ACBC RID: 44220
	[Nullable(1)]
	private readonly Rotator ArrowRotator = Rotator.Create();

	// Token: 0x0400ACBD RID: 44221
	private readonly FVector DefaultScale = new FVector(0.8f, 0.8f, 0.8f);

	// Token: 0x0400ACBE RID: 44222
	public static UCurveFloat MiddleOffsetCurve;

	// Token: 0x0400ACBF RID: 44223
	private const float ANIMAL_SCALE = 0.8f;

	// Token: 0x0400ACC0 RID: 44224
	private const int MIDDLE_TIME = 12;

	// Token: 0x0400ACC1 RID: 44225
	private const int FULL_ANGLE = 360;

	// Token: 0x0400ACC2 RID: 44226
	private const int ONE_HOUR_ANGLE = 30;

	// Token: 0x0400ACC3 RID: 44227
	private const float LEFT_RANGE = 0.4f;

	// Token: 0x0400ACC4 RID: 44228
	private const float MIDDLE_RANGE = 0.5f;

	// Token: 0x0400ACC5 RID: 44229
	private const float RIGHT_RANGE = 0.6f;

	// Token: 0x0400ACC6 RID: 44230
	private const float BORDER_ALPHA = 0.8f;

	// Token: 0x0400ACC7 RID: 44231
	private const float BORDER_RIGHT = 0.65625f;

	// Token: 0x0400ACC8 RID: 44232
	private const float BORDER_LEFT = 0.34375f;

	// Token: 0x0400ACC9 RID: 44233
	private const float BORDER_LEFT_HIDE = 0.03125f;

	// Token: 0x0400ACCA RID: 44234
	private const float BORDER_RIGHT_HIDE = 0.96875f;

	// Token: 0x0400ACCB RID: 44235
	private const float BORDER_MIDDLE = 0.5f;

	// Token: 0x0400ACCC RID: 44236
	private const float STONE2_BORDER_LEFT = 0.375f;

	// Token: 0x0400ACCD RID: 44237
	private const float STONE2_BORDER_RIGHT = 0.625f;

	// Token: 0x0400ACCE RID: 44238
	private const float NIAGARA_MIN_VALUE = 0.2f;

	// Token: 0x02008EB5 RID: 36533
	[NullableContext(0)]
	private enum ETimeOfDaySecondItemComponents
	{
		// Token: 0x0402FF51 RID: 196433
		Arrow,
		// Token: 0x0402FF52 RID: 196434
		TimeText,
		// Token: 0x0402FF53 RID: 196435
		CurrentTimeShowText,
		// Token: 0x0402FF54 RID: 196436
		StoneBtn,
		// Token: 0x0402FF55 RID: 196437
		StoneMixTexture,
		// Token: 0x0402FF56 RID: 196438
		SelfItem,
		// Token: 0x0402FF57 RID: 196439
		EmptyItem,
		// Token: 0x0402FF58 RID: 196440
		NotEmptyItem,
		// Token: 0x0402FF59 RID: 196441
		NiagaraItem
	}
}
