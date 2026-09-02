using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001E2A RID: 7722
public class GuideCountDownItem : UiPanelBase
{
	// Token: 0x0600E44D RID: 58445 RVA: 0x003D7993 File Offset: 0x003D5B93
	public GuideCountDownItem(float totalCountDown)
	{
		this.TotalCountDown = totalCountDown;
		this.Rotator = Rotator.Create(0f, 0f, 0f);
	}

	// Token: 0x0600E44E RID: 58446 RVA: 0x003D79BC File Offset: 0x003D5BBC
	[NullableContext(1)]
	public void Init(UUIItem item)
	{
		base.CreateThenShowByActorAsync(item.GetOwner(), null, false);
	}

	// Token: 0x0600E44F RID: 58447 RVA: 0x003D79D0 File Offset: 0x003D5BD0
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600E450 RID: 58448 RVA: 0x003D7A3C File Offset: 0x003D5C3C
	protected override void OnStart()
	{
		this.CircularItem = base.GetSprite(0);
		this.NeedleItem = base.GetSprite(1);
		this.CircularItem.SetFillAmount(1f);
		this.Rotator.Set(0f, 0f, 0f);
		UUIItem needleItem = this.NeedleItem;
		FRotator frotator = this.Rotator.ToUeRotator();
		needleItem.SetUIRelativeRotation(frotator);
		this.RootItem.SetUIActive(true);
	}

	// Token: 0x0600E451 RID: 58449 RVA: 0x003D7AB4 File Offset: 0x003D5CB4
	public void OnDurationChange(float remainDuration)
	{
		if (base.IsShowOrShowing)
		{
			float num = remainDuration / this.TotalCountDown;
			this.CircularItem.SetFillAmount(num);
			this.Rotator.Set(0f, (num - 1f) * 360f, 0f);
			UUIItem needleItem = this.NeedleItem;
			FRotator frotator = this.Rotator.ToUeRotator();
			needleItem.SetUIRelativeRotation(frotator);
		}
	}

	// Token: 0x04006DC1 RID: 28097
	private readonly float TotalCountDown;

	// Token: 0x04006DC2 RID: 28098
	[Nullable(1)]
	private readonly Rotator Rotator;

	// Token: 0x04006DC3 RID: 28099
	[Nullable(2)]
	private UUISprite CircularItem;

	// Token: 0x04006DC4 RID: 28100
	[Nullable(2)]
	private UUIItem NeedleItem;

	// Token: 0x0200818D RID: 33165
	private enum EGuideCountDownItem
	{
		// Token: 0x0402BFCC RID: 180172
		Circular,
		// Token: 0x0402BFCD RID: 180173
		Needle2
	}
}
