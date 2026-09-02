using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.FloroRanch;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001C4C RID: 7244
[NullableContext(1)]
[Nullable(0)]
public class FloroRanchCardItem : GridProxyAbstract<int>
{
	// Token: 0x0600D34A RID: 54090 RVA: 0x00384C04 File Offset: 0x00382E04
	protected unsafe override void OnRegisterComponent()
	{
		int num = 25;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(16, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(18, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(19, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(20, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(21, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(22, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(23, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(24, typeof(UUISprite));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickToggle));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600D34B RID: 54091 RVA: 0x00384FB2 File Offset: 0x003831B2
	protected override void OnStart()
	{
		base.GetExtendToggle(0).CanExecuteChange.Bind(new Func<bool>(this.OnCanExecuteChange));
		this.RegisterTermView();
		this.LevelSequencePlayer = new LevelSequencePlayer(base.GetRootItem());
	}

	// Token: 0x0600D34C RID: 54092 RVA: 0x00384FE8 File Offset: 0x003831E8
	protected override void OnBeforeDestroy()
	{
		this.UnRegisterTermView();
	}

	// Token: 0x0600D34D RID: 54093 RVA: 0x00384FF0 File Offset: 0x003831F0
	public void SetActivityDataType(EFloroRanchActivityDataType activityDataType)
	{
		this.ActivityDataType = new EFloroRanchActivityDataType?(activityDataType);
	}

	// Token: 0x0600D34E RID: 54094 RVA: 0x00384FFE File Offset: 0x003831FE
	private FloroRanchActivityData GetActivityDataForUnlock()
	{
		return ModelBase<FloroRanchModel>.Instance.GetActivityData(this.ActivityDataType.GetValueOrDefault(), true);
	}

	// Token: 0x0600D34F RID: 54095 RVA: 0x00385018 File Offset: 0x00383218
	public override void Refresh(int data, bool isSelected, int gridIndex)
	{
		base.GetItem(19).SetAlpha(0f);
		this.CardId = data;
		if (this.CardType == EFloroRanchCardType.Phantom)
		{
			this.RefreshPhantomCardData();
		}
		else
		{
			this.RefreshToyCardData();
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), this.CardData.GetName(), Array.Empty<object>());
		base.GetText(13).SetText(this.CardData.Desc, true);
		base.GetText(13).bBestFit = false;
		FloroRanchRarityData floroRanchRarity = ModelBase<FloroRanchModel>.Instance.GetFloroRanchRarity(this.CardData.GetRarity());
		UUITexture texture = base.GetTexture(5);
		if (texture != null)
		{
			texture.SetUIActive(true);
		}
		base.SetTextureShowUntilLoaded(this.CardData.GetIcon(), base.GetTexture(5), null);
		base.SetTextureShowUntilLoaded(this.CardData.GetIcon(), base.GetTexture(18), null);
		base.SetTextureShowUntilLoaded(floroRanchRarity.GetRarityDetailCardBigBg(), base.GetTexture(1), null);
		base.SetTextureShowUntilLoaded(floroRanchRarity.GetRarityDetailCardSmallBg(), base.GetTexture(2), null);
		base.SetTextureShowUntilLoaded(floroRanchRarity.GetSelectTexture(), base.GetTexture(16), null);
		bool flag = floroRanchRarity.IsGoldRarity();
		UUITexture texture2 = base.GetTexture(20);
		if (texture2 != null)
		{
			texture2.SetUIActive(false);
		}
		UUITexture texture3 = base.GetTexture(21);
		if (texture3 != null)
		{
			texture3.SetUIActive(flag || floroRanchRarity.IsSpecialRarity());
		}
		UUITexture texture4 = base.GetTexture(1);
		if (texture4 != null)
		{
			texture4.SetIsGray(false);
		}
		UUITexture texture5 = base.GetTexture(2);
		if (texture5 != null)
		{
			texture5.SetIsGray(false);
		}
		FloroRanchCurrencyConfigData floroRanchCurrencyConfig = ModelBase<FloroRanchModel>.Instance.GetFloroRanchCurrencyConfig(ECurrencyType.Salary);
		base.SetTextureShowUntilLoaded(floroRanchCurrencyConfig.GetIcon(), base.GetTexture(11), null);
		UUIItem item = base.GetItem(17);
		if (item != null)
		{
			item.SetUIActive(false);
		}
		FloroRanchActivityData activityDataForUnlock = this.GetActivityDataForUnlock();
		this.UnlockConditionText = ((this.CardType == EFloroRanchCardType.Phantom) ? activityDataForUnlock.GetCardConditionText(this.CardId) : activityDataForUnlock.GetToyConditionText(this.CardId));
		this.RefreshRecommendSprite();
	}

	// Token: 0x0600D350 RID: 54096 RVA: 0x00385200 File Offset: 0x00383400
	public void RefreshPhantomCardData()
	{
		FloroRanchActivityData activityDataForUnlock = this.GetActivityDataForUnlock();
		UUIItem item = base.GetItem(7);
		if (item != null)
		{
			item.SetUIActive(true);
		}
		UUIItem item2 = base.GetItem(10);
		if (item2 != null)
		{
			item2.SetUIActive(true);
		}
		FloroRanchCardData floroRanchCardData = ModelBase<FloroRanchModel>.Instance.GetFloroRanchCardData(this.CardId);
		this.CardData = floroRanchCardData;
		UUIText text = base.GetText(12);
		if (text != null)
		{
			text.SetText(floroRanchCardData.GetBasicSalary().ToString(), true);
		}
		FloroRanchRaceData floroRanchRaceData = ModelBase<FloroRanchModel>.Instance.GetFloroRanchRaceData(floroRanchCardData.GetRace());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(9), floroRanchRaceData.GetRaceName(), Array.Empty<object>());
		base.SetTextureShowUntilLoaded(floroRanchRaceData.SmallIcon, base.GetTexture(8), null);
		UUIItem item3 = base.GetItem(14);
		if (item3 != null)
		{
			item3.SetUIActive(floroRanchCardData.IsSpecialPhantom);
		}
		UUIItem item4 = base.GetItem(15);
		if (item4 != null)
		{
			item4.SetUIActive(activityDataForUnlock.IsCardHasNewLabel(this.CardId));
		}
		UUIText text2 = base.GetText(6);
		if (text2 != null)
		{
			text2.ShowTextNew("Farm_CardType1");
		}
		UUIItem item5 = base.GetItem(22);
		if (item5 == null)
		{
			return;
		}
		item5.SetUIActive(false);
	}

	// Token: 0x0600D351 RID: 54097 RVA: 0x0038531C File Offset: 0x0038351C
	public void RefreshToyCardData()
	{
		FloroRanchToyData floroRanchToyData = ModelBase<FloroRanchModel>.Instance.GetFloroRanchToyData(this.CardId);
		this.CardData = floroRanchToyData;
		UUIItem item = base.GetItem(7);
		if (item != null)
		{
			item.SetUIActive(false);
		}
		UUIItem item2 = base.GetItem(10);
		if (item2 != null)
		{
			item2.SetUIActive(false);
		}
		UUIItem item3 = base.GetItem(14);
		if (item3 != null)
		{
			item3.SetUIActive(false);
		}
		UUIItem item4 = base.GetItem(15);
		if (item4 != null)
		{
			item4.SetUIActive(false);
		}
		UUIText text = base.GetText(6);
		if (text != null)
		{
			text.ShowTextNew("Farm_CardType2");
		}
		UUIItem item5 = base.GetItem(22);
		if (item5 != null)
		{
			item5.SetUIActive(true);
		}
		FloroRanchRaceData toyRaceData = floroRanchToyData.GetToyRaceData();
		if (toyRaceData != null)
		{
			UUIItem item6 = base.GetItem(22);
			if (item6 != null)
			{
				item6.SetUIActive(true);
			}
			base.SetTextureShowUntilLoaded(toyRaceData.SmallIcon, base.GetTexture(23), null);
			return;
		}
		UUIItem item7 = base.GetItem(22);
		if (item7 == null)
		{
			return;
		}
		item7.SetUIActive(false);
	}

	// Token: 0x0600D352 RID: 54098 RVA: 0x00385402 File Offset: 0x00383602
	public void HideNewLabel()
	{
		UUIItem item = base.GetItem(15);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(false);
	}

	// Token: 0x0600D353 RID: 54099 RVA: 0x00385418 File Offset: 0x00383618
	public void SetLock()
	{
		UUIText text = base.GetText(3);
		if (text != null)
		{
			text.SetText("??", true);
		}
		UUIText text2 = base.GetText(12);
		if (text2 != null)
		{
			text2.SetText("+?", true);
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(13), this.UnlockConditionText, Array.Empty<object>());
		base.GetText(13).bBestFit = false;
		UUIItem item = base.GetItem(17);
		if (item != null)
		{
			item.SetUIActive(true);
		}
		UUITexture texture = base.GetTexture(5);
		if (texture != null)
		{
			texture.SetUIActive(false);
		}
		this.RefreshRecommendSprite();
	}

	// Token: 0x0600D354 RID: 54100 RVA: 0x003854B0 File Offset: 0x003836B0
	private void RefreshRecommendSprite()
	{
		FloroRanchActivityData activityDataForUnlock = this.GetActivityDataForUnlock();
		int subInstanceId = ModelBase<FloroRanchGamePlayModel>.Instance.SubInstanceId;
		bool flag = activityDataForUnlock.IsSubDungeonRecommendItem(subInstanceId, this.CardId, this.CardType);
		UUISprite sprite = base.GetSprite(24);
		if (!flag)
		{
			if (sprite != null)
			{
				sprite.SetUIActive(false);
			}
			return;
		}
		if (sprite != null)
		{
			sprite.SetUIActive(true);
		}
	}

	// Token: 0x0600D355 RID: 54101 RVA: 0x00385500 File Offset: 0x00383700
	public void SetInteractive(bool interactiveEnable)
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.SetSelfInteractive(interactiveEnable);
	}

	// Token: 0x0600D356 RID: 54102 RVA: 0x00385514 File Offset: 0x00383714
	private void OnClickToggle(EToggleState toggleState)
	{
		if (this.OnToggleCallBack != null)
		{
			this.OnToggleCallBack(base.GridIndex, this.CardId);
		}
	}

	// Token: 0x0600D357 RID: 54103 RVA: 0x00385535 File Offset: 0x00383735
	public void SetToggleCallBack(Action<int, int> callBack)
	{
		this.OnToggleCallBack = callBack;
	}

	// Token: 0x0600D358 RID: 54104 RVA: 0x0038553E File Offset: 0x0038373E
	public void SetCanToggleExecuteFunction(Func<int, bool> canExecuteFunction)
	{
		this.OnCanExecuteChangeCallBack = canExecuteFunction;
	}

	// Token: 0x0600D359 RID: 54105 RVA: 0x00385547 File Offset: 0x00383747
	public override void OnSelected(bool fireEvent)
	{
		this.SetToggleState(true);
	}

	// Token: 0x0600D35A RID: 54106 RVA: 0x00385550 File Offset: 0x00383750
	public override void OnDeselected(bool fireEvent)
	{
		this.SetToggleState(false);
	}

	// Token: 0x0600D35B RID: 54107 RVA: 0x00385559 File Offset: 0x00383759
	public void SetToggleState(bool isSelect)
	{
		base.GetExtendToggle(0).SetToggleStateForce(isSelect ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x0600D35C RID: 54108 RVA: 0x00385574 File Offset: 0x00383774
	private void RegisterTermView()
	{
		ETermExplanationViewType etermExplanationViewType = (this.OverrideTermViewType != ETermExplanationViewType.Center) ? this.OverrideTermViewType : ETermExplanationViewType.Center;
		TermExplanationRegistryParam param = new TermExplanationRegistryParam
		{
			UiText = base.GetText(13),
			ViewType = etermExplanationViewType,
			ReportType = ETermExplanationReportType.FloroRanch,
			AttachDirection = ((etermExplanationViewType == ETermExplanationViewType.Side) ? new ETermExplanationViewAttachDirection?(ETermExplanationViewAttachDirection.Left) : null),
			AttachItem = base.GetRootItem(),
			Group = new ETermExplanationGroup?(ETermExplanationGroup.FloroRanchCard),
			Style = new ETermExplanationViewStyle?(ETermExplanationViewStyle.FloroRanch)
		};
		ControllerBase<TermExplanationController>.Instance.RegisterTextHyperlinkByParam(param);
	}

	// Token: 0x0600D35D RID: 54109 RVA: 0x00385600 File Offset: 0x00383800
	private void UnRegisterTermView()
	{
		ControllerBase<TermExplanationController>.Instance.UnRegisterTextHyperlink(base.GetText(13));
	}

	// Token: 0x0600D35E RID: 54110 RVA: 0x00385614 File Offset: 0x00383814
	private bool OnCanExecuteChange()
	{
		return this.OnCanExecuteChangeCallBack == null || this.OnCanExecuteChangeCallBack(base.GridIndex);
	}

	// Token: 0x0600D35F RID: 54111 RVA: 0x00385634 File Offset: 0x00383834
	public void PlayAppearAnim()
	{
		FloroRanchRarityData floroRanchRarity = ModelBase<FloroRanchModel>.Instance.GetFloroRanchRarity(this.CardData.GetRarity());
		if (floroRanchRarity.IsGoldRarity() || floroRanchRarity.IsSpecialRarity())
		{
			this.LevelSequencePlayer.PlayLevelSequenceByName("GoldCard", false, null, false);
			return;
		}
		this.LevelSequencePlayer.PlayLevelSequenceByName("Start", false, null, false);
	}

	// Token: 0x0600D360 RID: 54112 RVA: 0x0038569E File Offset: 0x0038389E
	public void StopAppearAnim()
	{
		this.LevelSequencePlayer.StopCurrentSequence(false, false);
		base.GetItem(19).SetAlpha(0f);
	}

	// Token: 0x0600D361 RID: 54113 RVA: 0x003856BF File Offset: 0x003838BF
	public void SetItemAlpha(float alpha)
	{
		base.GetItem(19).SetAlpha(alpha);
	}

	// Token: 0x040064A1 RID: 25761
	private int CardId;

	// Token: 0x040064A2 RID: 25762
	private EFloroRanchActivityDataType? ActivityDataType;

	// Token: 0x040064A3 RID: 25763
	public EFloroRanchCardType CardType;

	// Token: 0x040064A4 RID: 25764
	public IFloroRanchCardOrToyData CardData;

	// Token: 0x040064A5 RID: 25765
	public string UnlockConditionText = "";

	// Token: 0x040064A6 RID: 25766
	public ETermExplanationViewType OverrideTermViewType;

	// Token: 0x040064A7 RID: 25767
	[Nullable(2)]
	protected Action<int, int> OnToggleCallBack;

	// Token: 0x040064A8 RID: 25768
	[Nullable(2)]
	private Func<int, bool> OnCanExecuteChangeCallBack;

	// Token: 0x040064A9 RID: 25769
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x02007F5D RID: 32605
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x0402B5B4 RID: 177588
		public const int ToggleRoot = 0;

		// Token: 0x0402B5B5 RID: 177589
		public const int TextureQualityA = 1;

		// Token: 0x0402B5B6 RID: 177590
		public const int TextureQualityB = 2;

		// Token: 0x0402B5B7 RID: 177591
		public const int TextName = 3;

		// Token: 0x0402B5B8 RID: 177592
		public const int TextureIconBg = 4;

		// Token: 0x0402B5B9 RID: 177593
		public const int TextureIcon = 5;

		// Token: 0x0402B5BA RID: 177594
		public const int TextTypeName = 6;

		// Token: 0x0402B5BB RID: 177595
		public const int ItemRacePanel = 7;

		// Token: 0x0402B5BC RID: 177596
		public const int TextureRaceIcon = 8;

		// Token: 0x0402B5BD RID: 177597
		public const int TextRaceName = 9;

		// Token: 0x0402B5BE RID: 177598
		public const int ItemIncomePanel = 10;

		// Token: 0x0402B5BF RID: 177599
		public const int TextureIncomeIcon = 11;

		// Token: 0x0402B5C0 RID: 177600
		public const int TextIncomeNum = 12;

		// Token: 0x0402B5C1 RID: 177601
		public const int TextDescription = 13;

		// Token: 0x0402B5C2 RID: 177602
		public const int ItemPhantomIcon = 14;

		// Token: 0x0402B5C3 RID: 177603
		public const int ItemNew = 15;

		// Token: 0x0402B5C4 RID: 177604
		public const int TextureSelect = 16;

		// Token: 0x0402B5C5 RID: 177605
		public const int ItemUnknownPanel = 17;

		// Token: 0x0402B5C6 RID: 177606
		public const int TextureIconMask = 18;

		// Token: 0x0402B5C7 RID: 177607
		public const int CardItemRoot = 19;

		// Token: 0x0402B5C8 RID: 177608
		public const int GoldCardQualityTexture = 20;

		// Token: 0x0402B5C9 RID: 177609
		public const int GoldCardQualityTextureB = 21;

		// Token: 0x0402B5CA RID: 177610
		public const int ItemToyRaceType = 22;

		// Token: 0x0402B5CB RID: 177611
		public const int TextureToyRaceIcon = 23;

		// Token: 0x0402B5CC RID: 177612
		public const int RecommendSprite = 24;
	}
}
