using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.AutoAttach;
using Cysharp.Threading.Tasks;
using UnrealEngine;

// Token: 0x020025C8 RID: 9672
public class FightPhotoScrollItem : FightPhotoSetupBase
{
	// Token: 0x06012E8A RID: 77450 RVA: 0x0053B340 File Offset: 0x00539540
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIText))
		};
	}

	// Token: 0x06012E8B RID: 77451 RVA: 0x0053B3C8 File Offset: 0x005395C8
	protected override void OnStart()
	{
		UUIItem item = base.GetItem(0);
		UUIItem item2 = base.GetItem(1);
		UUIItem item3 = base.GetItem(2);
		this.AngleAttachView = new NoCircleAttachView<int?, FightPhotoAngleItem>(item.GetOwner() as AUIBaseActor, false);
		this.AngleAttachView.SetIfNeedFakeItem(false);
		this.AngleAttachView.SetMoveMultiFactor(0f);
		this.AngleAttachView.CreateItems(item3.GetOwner() as AUIBaseActor, 0f, new Func<AActor, int, int, FightPhotoAngleItem>(this.CreateMarkItem), EAttachDirection.Horizontal);
		this.AngleAttachView.SetControllerItem(item2);
		this.AngleAttachView.SetItemSelectMode(EAttachMode.OnMovingNearest);
		item3.SetUIActive(false);
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnSyncFightPhotoTiltAngle, new Action<int>(this.OnSyncFightPhotoTiltAngle));
	}

	// Token: 0x06012E8C RID: 77452 RVA: 0x0053B484 File Offset: 0x00539684
	public override void Refresh()
	{
		if (this.SetupConfig == null)
		{
			return;
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), this.SetupConfig.Value.Name, Array.Empty<object>());
		int num = (int)Math.Round((double)this.SetupConfig.Value.ValueRange(0));
		int num2 = (int)Math.Round((double)this.SetupConfig.Value.ValueRange(1));
		this.AngleMin = num;
		this.AngleMax = num2;
		int num3 = num2 - num + 1;
		int?[] array = new int?[num3];
		for (int i = 0; i < num3; i++)
		{
			array[i] = new int?(num + i);
		}
		int? fightPhotoSetupOption = ModelBase<FightPhotoModel>.Instance.GetFightPhotoSetupOption((EFightPhotoSetupOptionType)this.SetupConfig.Value.Id);
		float num4 = (fightPhotoSetupOption != null) ? ((float)fightPhotoSetupOption.GetValueOrDefault()) : this.SetupConfig.Value.ValueRange(2);
		int num5 = Math.Min(num2, Math.Max(num, (int)Math.Round((double)num4)));
		int attachTo = num5 - num;
		this.RefreshAngleText(num5);
		NoCircleAttachView<int?, FightPhotoAngleItem> angleAttachView = this.AngleAttachView;
		if (angleAttachView == null)
		{
			return;
		}
		angleAttachView.ReloadView(array.Length, array, attachTo);
	}

	// Token: 0x06012E8D RID: 77453 RVA: 0x0053B5C4 File Offset: 0x005397C4
	protected override void OnBeforeDestroy()
	{
		if (Singleton<EventSystem>.Instance.Has<int>(EEventName.OnSyncFightPhotoTiltAngle, new Action<int>(this.OnSyncFightPhotoTiltAngle)))
		{
			Singleton<EventSystem>.Instance.Remove<int>(EEventName.OnSyncFightPhotoTiltAngle, new Action<int>(this.OnSyncFightPhotoTiltAngle));
		}
		this.AngleAttachView = null;
	}

	// Token: 0x06012E8E RID: 77454 RVA: 0x0053B611 File Offset: 0x00539811
	[NullableContext(1)]
	private FightPhotoAngleItem CreateMarkItem(AActor actor, int index, int showNum)
	{
		FightPhotoAngleItem fightPhotoAngleItem = new FightPhotoAngleItem();
		fightPhotoAngleItem.CreateByActorAsync(actor, null, false).Forget();
		fightPhotoAngleItem.OnSelectCallback = new Action<int>(this.OnAngleSelect);
		return fightPhotoAngleItem;
	}

	// Token: 0x06012E8F RID: 77455 RVA: 0x0053B638 File Offset: 0x00539838
	private void OnAngleSelect(int angle)
	{
		this.RefreshAngleText(angle);
		base.OnSetupValueChange(angle);
	}

	// Token: 0x06012E90 RID: 77456 RVA: 0x0053B648 File Offset: 0x00539848
	private void RefreshAngleText(int angle)
	{
		string newText = Singleton<MathUtils>.Instance.GetFloatPointFloorString((double)angle, this.SetupConfig.Value.Digits) + this.SetupConfig.Value.Unit;
		UUIText text = base.GetText(3);
		if (text == null)
		{
			return;
		}
		text.SetText(newText, true);
	}

	// Token: 0x06012E91 RID: 77457 RVA: 0x0053B6A0 File Offset: 0x005398A0
	private void OnSyncFightPhotoTiltAngle(int angle)
	{
		if (this.SetupConfig == null || this.SetupConfig.GetValueOrDefault().Id != 3 || this.AngleAttachView == null)
		{
			return;
		}
		int num = Math.Min(this.AngleMax, Math.Max(this.AngleMin, (int)Math.Round((double)angle)));
		this.RefreshAngleText(num);
		this.AngleAttachView.AttachToIndex(num - this.AngleMin, true);
	}

	// Token: 0x040093B8 RID: 37816
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private NoCircleAttachView<int?, FightPhotoAngleItem> AngleAttachView;

	// Token: 0x040093B9 RID: 37817
	private int AngleMin;

	// Token: 0x040093BA RID: 37818
	private int AngleMax;

	// Token: 0x02008930 RID: 35120
	private enum EChildType
	{
		// Token: 0x0402E4A5 RID: 189605
		Draggable,
		// Token: 0x0402E4A6 RID: 189606
		ItemContent,
		// Token: 0x0402E4A7 RID: 189607
		ItemScaleMark,
		// Token: 0x0402E4A8 RID: 189608
		TxtAngleNum,
		// Token: 0x0402E4A9 RID: 189609
		TxtTitle
	}
}
