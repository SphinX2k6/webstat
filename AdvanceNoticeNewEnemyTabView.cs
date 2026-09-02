using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001190 RID: 4496
public class AdvanceNoticeNewEnemyTabView : AdvanceNoticeTabViewBase
{
	// Token: 0x06007640 RID: 30272 RVA: 0x001EEBF4 File Offset: 0x001ECDF4
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUISprite)),
			new ValueTuple<int, Type>(6, typeof(UUISprite)),
			new ValueTuple<int, Type>(7, typeof(UUITexture)),
			new ValueTuple<int, Type>(8, typeof(UUITexture)),
			new ValueTuple<int, Type>(9, typeof(UUITexture)),
			new ValueTuple<int, Type>(10, typeof(UUINiagara)),
			new ValueTuple<int, Type>(11, typeof(UUIText)),
			new ValueTuple<int, Type>(12, typeof(UUIItem)),
			new ValueTuple<int, Type>(13, typeof(UUIItem)),
			new ValueTuple<int, Type>(14, typeof(UUIText)),
			new ValueTuple<int, Type>(15, typeof(UUILayoutBase)),
			new ValueTuple<int, Type>(16, typeof(UUIItem)),
			new ValueTuple<int, Type>(17, typeof(UUIText)),
			new ValueTuple<int, Type>(18, typeof(UUILayoutBase)),
			new ValueTuple<int, Type>(19, typeof(UUIText)),
			new ValueTuple<int, Type>(20, typeof(UUIScrollViewWithScrollbarComponent))
		};
	}

	// Token: 0x06007641 RID: 30273 RVA: 0x001EEDE8 File Offset: 0x001ECFE8
	protected override UniTask OnBeforeStartAsync()
	{
		AdvanceNoticeNewEnemyTabView.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<AdvanceNoticeNewEnemyTabView.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06007642 RID: 30274 RVA: 0x001EEE2C File Offset: 0x001ED02C
	protected override void RefreshView()
	{
		int currentSubTabId = this.ViewModel.CurrentSubTabId;
		switch (ConfigBase<AdvanceNoticeConfig>.Instance.GetAdvertisingTabEnemyById(currentSubTabId).Type)
		{
		case 1:
			this.RefreshEnemyView();
			break;
		case 2:
			this.RefreshVisionView();
			break;
		case 3:
			this.RefreshFetterView();
			break;
		}
		base.GetScrollViewWithScrollbar(20).SetScrollProgress(0f);
	}

	// Token: 0x06007643 RID: 30275 RVA: 0x001EEE98 File Offset: 0x001ED098
	protected void RefreshEnemyView()
	{
		base.GetItem(4).SetUIActive(false);
		base.GetTexture(0).SetUIActive(true);
		int currentSubTabId = this.ViewModel.CurrentSubTabId;
		AdvertisingTabEnemy advertisingTabEnemyById = ConfigBase<AdvanceNoticeConfig>.Instance.GetAdvertisingTabEnemyById(currentSubTabId);
		base.SetTextureByPath(advertisingTabEnemyById.MainPic, base.GetTexture(0), null, null);
		this.SetLeftText(advertisingTabEnemyById);
		base.GetItem(12).SetUIActive(true);
		base.GetText(11).SetUIActive(true);
		base.GetItem(13).SetUIActive(false);
		base.GetItem(16).SetUIActive(true);
		base.GetLayoutBase(18).RootUIComp.Get().SetUIActive(false);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(11), advertisingTabEnemyById.EnemyDescription, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(17), "AdvertisingEnemy_Description", Array.Empty<object>());
		UUIText text = base.GetText(19);
		if (text == null)
		{
			return;
		}
		text.SetUIActive(true);
	}

	// Token: 0x06007644 RID: 30276 RVA: 0x001EEF9C File Offset: 0x001ED19C
	protected void RefreshVisionView()
	{
		base.GetItem(4).SetUIActive(false);
		base.GetTexture(0).SetUIActive(true);
		int currentSubTabId = this.ViewModel.CurrentSubTabId;
		AdvertisingTabEnemy advertisingTabEnemyById = ConfigBase<AdvanceNoticeConfig>.Instance.GetAdvertisingTabEnemyById(currentSubTabId);
		base.SetTextureByPath(advertisingTabEnemyById.MainPic, base.GetTexture(0), null, null);
		this.SetLeftText(advertisingTabEnemyById);
		List<string> list = new List<string>();
		foreach (string item in advertisingTabEnemyById.VisionFetterIconListIter())
		{
			list.Add(item);
		}
		this.VisionFetterLayout.RefreshByData(list, null, false);
		base.GetItem(12).SetUIActive(true);
		base.GetText(11).SetUIActive(true);
		base.GetItem(13).SetUIActive(true);
		base.GetItem(16).SetUIActive(true);
		base.GetLayoutBase(18).RootUIComp.Get().SetUIActive(false);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(11), advertisingTabEnemyById.VisionDescription, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(14), "AdvertisingEnemy_Fetter", Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(17), "AdvertisingEnemy_Skill", Array.Empty<object>());
		UUIText text = base.GetText(19);
		if (text == null)
		{
			return;
		}
		text.SetUIActive(true);
	}

	// Token: 0x06007645 RID: 30277 RVA: 0x001EF11C File Offset: 0x001ED31C
	protected void RefreshFetterView()
	{
		base.GetItem(4).SetUIActive(true);
		base.GetTexture(0).SetUIActive(false);
		int currentSubTabId = this.ViewModel.CurrentSubTabId;
		AdvertisingTabEnemy advertisingTabEnemyById = ConfigBase<AdvanceNoticeConfig>.Instance.GetAdvertisingTabEnemyById(currentSubTabId);
		this.SetLeftText(advertisingTabEnemyById);
		this.SetSpriteByPath(advertisingTabEnemyById.SuitCoreSprite, base.GetSprite(5), false, null, null);
		this.SetSpriteByPath(advertisingTabEnemyById.SuitCoreBgSprite, base.GetSprite(6), false, null, null);
		base.SetTextureByPath(advertisingTabEnemyById.SuitOuterBgTexture, base.GetTexture(7), null, null);
		FColor fcolor = FColor.FromHex(advertisingTabEnemyById.SuitNiagaraColor);
		FLinearColor value = new FLinearColor(ref fcolor);
		base.GetUiNiagara(10).SetNiagaraVarLinearColor("Color", value);
		Dictionary<int, string> dictionary = advertisingTabEnemyById.VisionEffectMap();
		List<IAdvanceNoticeFetterSuitDetailItemData> list = new List<IAdvanceNoticeFetterSuitDetailItemData>();
		foreach (KeyValuePair<int, string> keyValuePair in dictionary)
		{
			AdvanceNoticeFetterSuitDetailItemData item = new AdvanceNoticeFetterSuitDetailItemData
			{
				TitleTextData = new TableTextArgNew("AdvertisingEnemy_FetterTitle", new <>z__ReadOnlySingleElementList<object>(keyValuePair.Key)),
				DescTextData = new TableTextArgNew(keyValuePair.Value, Array.Empty<object>())
			};
			list.Add(item);
		}
		this.FetterSuitDetailLayout.RefreshByData(list, null, false);
		base.GetItem(12).SetUIActive(false);
		base.GetText(11).SetUIActive(false);
		base.GetLayoutBase(18).RootUIComp.Get().SetUIActive(true);
		UUIText text = base.GetText(19);
		if (text == null)
		{
			return;
		}
		text.SetUIActive(false);
	}

	// Token: 0x06007646 RID: 30278 RVA: 0x001EF2D4 File Offset: 0x001ED4D4
	private void SetLeftText(AdvertisingTabEnemy config)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), config.SubTitle, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), config.Title, Array.Empty<object>());
		if (StringUtils.IsEmpty(config.Description))
		{
			base.GetText(3).SetUIActive(false);
			return;
		}
		base.GetText(3).SetUIActive(true);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), config.Description, Array.Empty<object>());
	}

	// Token: 0x06007647 RID: 30279 RVA: 0x001EF361 File Offset: 0x001ED561
	[NullableContext(1)]
	private AdvanceNoticeSuitItem CreateFetterItem()
	{
		return new AdvanceNoticeSuitItem();
	}

	// Token: 0x06007648 RID: 30280 RVA: 0x001EF368 File Offset: 0x001ED568
	[NullableContext(1)]
	private AdvanceNoticeFetterSuitDetailItem CreateFetterSuitDetailItem()
	{
		return new AdvanceNoticeFetterSuitDetailItem();
	}

	// Token: 0x04003944 RID: 14660
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<AdvanceNoticeSuitItem, string> VisionFetterLayout;

	// Token: 0x04003945 RID: 14661
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<AdvanceNoticeFetterSuitDetailItem, IAdvanceNoticeFetterSuitDetailItemData> FetterSuitDetailLayout;

	// Token: 0x020074E9 RID: 29929
	private class EComponentDefine
	{
		// Token: 0x040285BD RID: 165309
		public const int VisionTexture = 0;

		// Token: 0x040285BE RID: 165310
		public const int SubTitleText = 1;

		// Token: 0x040285BF RID: 165311
		public const int TitleText = 2;

		// Token: 0x040285C0 RID: 165312
		public const int DescText = 3;

		// Token: 0x040285C1 RID: 165313
		public const int ElementRootItem = 4;

		// Token: 0x040285C2 RID: 165314
		public const int SuitCoreSprite = 5;

		// Token: 0x040285C3 RID: 165315
		public const int SuitCoreBgSprite = 6;

		// Token: 0x040285C4 RID: 165316
		public const int SuitOuterBgTexture = 7;

		// Token: 0x040285C5 RID: 165317
		public const int SuitOuterEffectTextureA = 8;

		// Token: 0x040285C6 RID: 165318
		public const int SuitOuterEffectTextureB = 9;

		// Token: 0x040285C7 RID: 165319
		public const int SuitNiagara = 10;

		// Token: 0x040285C8 RID: 165320
		public const int ScrollText = 11;

		// Token: 0x040285C9 RID: 165321
		public const int TopTitleItem = 12;

		// Token: 0x040285CA RID: 165322
		public const int VisionTitleItem = 13;

		// Token: 0x040285CB RID: 165323
		public const int VisionTitleText = 14;

		// Token: 0x040285CC RID: 165324
		public const int VisionFetterLayout = 15;

		// Token: 0x040285CD RID: 165325
		public const int EnemyTitleItem = 16;

		// Token: 0x040285CE RID: 165326
		public const int EnemyTitleText = 17;

		// Token: 0x040285CF RID: 165327
		public const int FetterSuitLayout = 18;

		// Token: 0x040285D0 RID: 165328
		public const int ReminderText = 19;

		// Token: 0x040285D1 RID: 165329
		public const int DescScrollView = 20;
	}
}
