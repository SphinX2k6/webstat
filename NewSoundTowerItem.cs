using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.AdventureGuide;
using CSharpScript.Game.Module.AdventureGuide.Views;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200175A RID: 5978
[NullableContext(1)]
[Nullable(0)]
public class NewSoundTowerItem : UiPanelBase, INewSoundItem
{
	// Token: 0x0600A807 RID: 43015 RVA: 0x002CBFDC File Offset: 0x002CA1DC
	protected unsafe override void OnRegisterComponent()
	{
		int num = 6;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600A808 RID: 43016 RVA: 0x002CC0C9 File Offset: 0x002CA2C9
	public void Update(NewSoundDetectItemData sourceData)
	{
		this.UpdateCommon(sourceData);
		if (sourceData.DetectRecordData.Secondary == 28)
		{
			this.UpdateShipTower(sourceData);
			return;
		}
		this.UpdateTower(sourceData);
	}

	// Token: 0x0600A809 RID: 43017 RVA: 0x002CC0F0 File Offset: 0x002CA2F0
	private void UpdateCommon(NewSoundDetectItemData sourceData)
	{
		SoundAreaDetectionRecord detectRecordData = sourceData.DetectRecordData;
		UUIText text = base.GetText(0);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text, detectRecordData.Name, Array.Empty<object>());
		UUITexture texture = base.GetTexture(1);
		string path = detectRecordData.IsLock.GetValueOrDefault() ? detectRecordData.LockBigIcon : detectRecordData.BigIcon;
		base.SetTextureShowUntilLoaded(path, texture, null);
		UUIItem text2 = base.GetText(2);
		UUIText text3 = base.GetText(3);
		bool? isLock = detectRecordData.IsLock;
		bool flag = false;
		text2.SetUIActive(isLock.GetValueOrDefault() == flag & isLock != null);
		UUIItem uuiitem = text3;
		isLock = detectRecordData.IsLock;
		flag = false;
		uuiitem.SetUIActive(isLock.GetValueOrDefault() == flag & isLock != null);
	}

	// Token: 0x0600A80A RID: 43018 RVA: 0x002CC1AC File Offset: 0x002CA3AC
	private void UpdateTower(NewSoundDetectItemData sourceData)
	{
		if (sourceData.DetectRecordData.IsLock.GetValueOrDefault())
		{
			return;
		}
		int maxDifficulty = ModelBase<TowerModel>.Instance.GetMaxDifficulty();
		string newTowerDifficultTitle = ConfigBase<TowerClimbConfig>.Instance.GetNewTowerDifficultTitle(maxDifficulty);
		this.UpdateSubTitle(newTowerDifficultTitle);
		int difficultyMaxStars = ModelBase<TowerModel>.Instance.GetDifficultyMaxStars(maxDifficulty, false);
		int difficultyAllStars = ModelBase<TowerModel>.Instance.GetDifficultyAllStars(maxDifficulty, false);
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
		defaultInterpolatedStringHandler.AppendFormatted<int>(difficultyMaxStars);
		defaultInterpolatedStringHandler.AppendLiteral("/");
		defaultInterpolatedStringHandler.AppendFormatted<int>(difficultyAllStars);
		string progressStr = defaultInterpolatedStringHandler.ToStringAndClear();
		this.UpdateProgressNumber(progressStr);
		UUIItem item = base.GetItem(5);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(true);
	}

	// Token: 0x0600A80B RID: 43019 RVA: 0x002CC250 File Offset: 0x002CA450
	private void UpdateShipTower(NewSoundDetectItemData sourceData)
	{
		if (sourceData.DetectRecordData.IsLock.GetValueOrDefault())
		{
			return;
		}
		this.UpdateSubTitle(ModelBase<ShipTowerModel>.Instance.GetCurrentStageSeasonName());
		this.UpdateProgressNumber(ModelBase<ShipTowerModel>.Instance.GetRewardProgressText(false));
		UUIItem item = base.GetItem(5);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(false);
	}

	// Token: 0x0600A80C RID: 43020 RVA: 0x002CC2A6 File Offset: 0x002CA4A6
	private void UpdateSubTitle(string subTitle)
	{
		base.GetText(2).SetText(subTitle, true);
	}

	// Token: 0x0600A80D RID: 43021 RVA: 0x002CC2B6 File Offset: 0x002CA4B6
	private void UpdateProgressNumber(string progressStr)
	{
		base.GetText(3).SetText(progressStr, true);
	}

	// Token: 0x02007AC0 RID: 31424
	[NullableContext(0)]
	private enum EChildType
	{
		// Token: 0x0402A0BD RID: 172221
		NameText,
		// Token: 0x0402A0BE RID: 172222
		IconTexture,
		// Token: 0x0402A0BF RID: 172223
		ProgressText,
		// Token: 0x0402A0C0 RID: 172224
		ProgressNumberText,
		// Token: 0x0402A0C1 RID: 172225
		SpriteIcon,
		// Token: 0x0402A0C2 RID: 172226
		ItemTowerStar
	}
}
