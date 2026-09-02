using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001627 RID: 5671
[NullableContext(1)]
[Nullable(0)]
public class VersionPreheatQuestDetailView : UiViewBase
{
	// Token: 0x06009FDF RID: 40927 RVA: 0x0029C2E8 File Offset: 0x0029A4E8
	public VersionPreheatQuestDetailView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x06009FE0 RID: 40928 RVA: 0x0029C348 File Offset: 0x0029A548
	protected unsafe override void OnRegisterComponent()
	{
		int num = 41;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUISliderComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(15, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(18, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(19, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(20, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(21, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(22, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(23, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(24, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(25, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(26, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(27, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(28, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(29, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(30, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(31, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(32, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(33, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(34, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(35, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(36, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(37, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(38, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(39, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(40, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 3;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(16, new Action(this.HandleOnClickShare));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(27, new Action(this.HandleOnClickSelfChatContent));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(38, new Action(this.HandleOnClickExit));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06009FE1 RID: 40929 RVA: 0x0029C960 File Offset: 0x0029AB60
	protected override UniTask OnBeforeStartAsync()
	{
		VersionPreheatQuestDetailView.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<VersionPreheatQuestDetailView.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06009FE2 RID: 40930 RVA: 0x0029C9A4 File Offset: 0x0029ABA4
	protected override void OnBeforeShow()
	{
		if (this.IsFirstIn)
		{
			this.IsFirstIn = false;
			return;
		}
		VersionPreheatModel instance = ModelBase<VersionPreheatModel>.Instance;
		if (instance.CurrentUsingVersionPreheatId != null)
		{
			VersionPreheatQuestDetailData data = instance.BuildQuestDetailDataById(instance.CurrentUsingVersionPreheatId.Value);
			this.RefreshExternal(data);
		}
	}

	// Token: 0x06009FE3 RID: 40931 RVA: 0x0029C9ED File Offset: 0x0029ABED
	protected override void OnBeforeDestroy()
	{
		ModelBase<VersionPreheatModel>.Instance.CurrentUsingVersionPreheatId = null;
	}

	// Token: 0x06009FE4 RID: 40932 RVA: 0x0029CA00 File Offset: 0x0029AC00
	private void HandleOnClickShare()
	{
		VersionPreheatQuestDetailPersistentData persistentData = (this.OpenParam as VersionPreheatQuestDetailData).PersistentData;
		ControllerBase<ActivityVersionPreheatController>.Instance.OpenShareView(persistentData.QuestSharePhotoPath, persistentData.QuestTitleTextId, persistentData.QuestContentTextId);
	}

	// Token: 0x06009FE5 RID: 40933 RVA: 0x0029CA3A File Offset: 0x0029AC3A
	private void HandleOnClickSelfChatContent()
	{
	}

	// Token: 0x06009FE6 RID: 40934 RVA: 0x0029CA3C File Offset: 0x0029AC3C
	private void HandleOnClickExit()
	{
		base.CloseMe(null);
	}

	// Token: 0x06009FE7 RID: 40935 RVA: 0x0029CA45 File Offset: 0x0029AC45
	private CommonItemSmallItemGrid GridProxyCreateFunction()
	{
		return new CommonItemSmallItemGrid();
	}

	// Token: 0x06009FE8 RID: 40936 RVA: 0x0029CA4C File Offset: 0x0029AC4C
	private void RefreshPersistentByData(VersionPreheatQuestDetailPersistentData data)
	{
		base.SetTextureByPath(data.QuestPhotoPath, base.GetTexture(15), null, null);
		this.RefreshQuestItem(data.Index);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), data.QuestContentTextId, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), data.QuestTitleTextId, Array.Empty<object>());
		UUITexture texture = base.GetTexture(1);
		if (texture != null)
		{
			texture.SetUIActive(data.QuestCrestIndex == 0);
		}
		UUITexture texture2 = base.GetTexture(2);
		if (texture2 != null)
		{
			texture2.SetUIActive(data.QuestCrestIndex == 1);
		}
		UUIButtonComponent button = base.GetButton(16);
		if (button != null)
		{
			button.RootUIComp.Get().SetUIActive(data.CanShare);
		}
		UUITexture texture3 = base.GetTexture(39);
		if (texture3 == null)
		{
			return;
		}
		texture3.SetUIActive(data.CanShare);
	}

	// Token: 0x06009FE9 RID: 40937 RVA: 0x0029CB30 File Offset: 0x0029AD30
	private void RefreshQuestItem(int index)
	{
		for (int i = 0; i < this.QuestItemList.Count; i++)
		{
			UUIItem item = base.GetItem(this.QuestItemList[i]);
			if (item != null)
			{
				item.SetUIActive(i == index);
			}
		}
	}

	// Token: 0x06009FEA RID: 40938 RVA: 0x0029CB74 File Offset: 0x0029AD74
	private void RefreshVoteByData(VersionPreheatQuestDetailVoteData data)
	{
		if (data == null)
		{
			UUIItem item = base.GetItem(4);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(false);
			return;
		}
		else
		{
			UUIItem item2 = base.GetItem(4);
			if (item2 != null)
			{
				item2.SetUIActive(true);
			}
			UUIText text = base.GetText(9);
			if (text != null)
			{
				text.SetText(data.LeftPercentageText, true);
			}
			UUIText text2 = base.GetText(11);
			if (text2 != null)
			{
				text2.SetText(data.RightPercentageText, true);
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(13), data.LeftThemeTextId, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(14), data.RightThemeTextId, Array.Empty<object>());
			UUISprite sprite = base.GetSprite(10);
			if (sprite != null)
			{
				sprite.SetUIActive(data.IsLeftChosen);
			}
			UUISprite sprite2 = base.GetSprite(12);
			if (sprite2 != null)
			{
				sprite2.SetUIActive(!data.IsLeftChosen);
			}
			UUISprite sprite3 = base.GetSprite(6);
			if (sprite3 != null)
			{
				sprite3.SetFillAmount(data.LeftNormalized);
			}
			UUISprite sprite4 = base.GetSprite(5);
			if (sprite4 != null)
			{
				sprite4.SetFillAmount(data.RightNormalized);
			}
			UUISliderComponent slider = base.GetSlider(7);
			if (slider == null)
			{
				return;
			}
			slider.SetValue(data.LeftNormalized, true);
			return;
		}
	}

	// Token: 0x06009FEB RID: 40939 RVA: 0x0029CC98 File Offset: 0x0029AE98
	private void RefreshChatByData(VersionPreheatQuestDetailChatData data)
	{
		if (data == null)
		{
			UUIItem item = base.GetItem(21);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(false);
			return;
		}
		else
		{
			UUIItem item2 = base.GetItem(21);
			if (item2 != null)
			{
				item2.SetUIActive(true);
			}
			this.NpcRoleItem.RefreshExternal(data.NpcIconPath);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(23), data.NpcContentTextId, Array.Empty<object>());
			VersionPreheatQuestDetailChatData selfChatData = data.SelfChatData;
			if (selfChatData == null)
			{
				UUIItem item3 = base.GetItem(24);
				if (item3 == null)
				{
					return;
				}
				item3.SetUIActive(false);
				return;
			}
			else
			{
				UUIItem item4 = base.GetItem(24);
				if (item4 != null)
				{
					item4.SetUIActive(true);
				}
				this.SelfRoleItem.RefreshExternal(selfChatData.NpcIconPath);
				if (selfChatData.NpcContentTextId == null)
				{
					UUIItem item5 = base.GetItem(26);
					if (item5 != null)
					{
						item5.SetUIActive(false);
					}
				}
				else
				{
					UUIItem item6 = base.GetItem(26);
					if (item6 != null)
					{
						item6.SetUIActive(true);
					}
					Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(28), selfChatData.NpcContentTextId, Array.Empty<object>());
				}
				UUIButtonComponent button = base.GetButton(27);
				if (button == null)
				{
					return;
				}
				button.RootUIComp.Get().SetUIActive(false);
				return;
			}
		}
	}

	// Token: 0x06009FEC RID: 40940 RVA: 0x0029CDB0 File Offset: 0x0029AFB0
	private void RefreshRewardByData(VersionPreheatQuestDetailRewardData data)
	{
		if (data != null)
		{
			UUIItem item = base.GetItem(17);
			if (item != null)
			{
				item.SetUIActive(true);
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(18), data.QuestContentTextId, Array.Empty<object>());
			this.RefreshRewardItemsAsync(data);
			this.RewardConfirmButtonItem.ClickRewardFunc = data.ClickFunc;
			this.RewardConfirmButtonItem.ClickRewardPassData = new int?(data.ClickPassData);
			return;
		}
		UUIItem item2 = base.GetItem(17);
		if (item2 == null)
		{
			return;
		}
		item2.SetUIActive(false);
	}

	// Token: 0x06009FED RID: 40941 RVA: 0x0029CE34 File Offset: 0x0029B034
	private UniTask RefreshRewardItemsAsync(VersionPreheatQuestDetailRewardData data)
	{
		VersionPreheatQuestDetailView.<RefreshRewardItemsAsync>d__21 <RefreshRewardItemsAsync>d__;
		<RefreshRewardItemsAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshRewardItemsAsync>d__.<>4__this = this;
		<RefreshRewardItemsAsync>d__.data = data;
		<RefreshRewardItemsAsync>d__.<>1__state = -1;
		<RefreshRewardItemsAsync>d__.<>t__builder.Start<VersionPreheatQuestDetailView.<RefreshRewardItemsAsync>d__21>(ref <RefreshRewardItemsAsync>d__);
		return <RefreshRewardItemsAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06009FEE RID: 40942 RVA: 0x0029CE80 File Offset: 0x0029B080
	private void RefreshBonus(string data)
	{
		if (data != null)
		{
			UUIText text = base.GetText(30);
			if (text != null)
			{
				text.SetUIActive(true);
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(30), data, Array.Empty<object>());
			return;
		}
		UUIText text2 = base.GetText(30);
		if (text2 == null)
		{
			return;
		}
		text2.SetUIActive(false);
	}

	// Token: 0x06009FEF RID: 40943 RVA: 0x0029CED0 File Offset: 0x0029B0D0
	private void RefreshExternal(VersionPreheatQuestDetailData data)
	{
		this.RefreshPersistentByData(data.PersistentData);
		this.RefreshVoteByData(data.VoteData);
		this.RefreshChatByData(data.ChatData);
		this.RefreshRewardByData(data.RewardData);
		this.RefreshBonus(data.BonusTextId);
	}

	// Token: 0x04004971 RID: 18801
	private readonly List<int> QuestItemList = new List<int>
	{
		31,
		32,
		33,
		34,
		35,
		36,
		37
	};

	// Token: 0x04004972 RID: 18802
	private VersionPreheatQuestDetailRoleItem NpcRoleItem;

	// Token: 0x04004973 RID: 18803
	private VersionPreheatQuestDetailRoleItem SelfRoleItem;

	// Token: 0x04004974 RID: 18804
	private GenericLayout<CommonItemSmallItemGrid, TItem> ItemLayoutInReward;

	// Token: 0x04004975 RID: 18805
	private VersionPreheatButton RewardConfirmButtonItem;

	// Token: 0x04004976 RID: 18806
	private bool IsFirstIn = true;

	// Token: 0x020079E1 RID: 31201
	[NullableContext(0)]
	private class EComponent
	{
		// Token: 0x04029D6B RID: 171371
		public const int QuestContentText = 0;

		// Token: 0x04029D6C RID: 171372
		public const int Crest1Texture = 1;

		// Token: 0x04029D6D RID: 171373
		public const int Crest2Texture = 2;

		// Token: 0x04029D6E RID: 171374
		public const int QuestTitleText = 3;

		// Token: 0x04029D6F RID: 171375
		public const int VoteRootItem = 4;

		// Token: 0x04029D70 RID: 171376
		public const int BlueSprite = 5;

		// Token: 0x04029D71 RID: 171377
		public const int RedSprite = 6;

		// Token: 0x04029D72 RID: 171378
		public const int BlueAndRedSlider = 7;

		// Token: 0x04029D73 RID: 171379
		public const int HandleSprite = 8;

		// Token: 0x04029D74 RID: 171380
		public const int LeftPercentageText = 9;

		// Token: 0x04029D75 RID: 171381
		public const int LeftCheckSprite = 10;

		// Token: 0x04029D76 RID: 171382
		public const int RightPercentageText = 11;

		// Token: 0x04029D77 RID: 171383
		public const int RightCheckSprite = 12;

		// Token: 0x04029D78 RID: 171384
		public const int LeftTipsText = 13;

		// Token: 0x04029D79 RID: 171385
		public const int RightTipsText = 14;

		// Token: 0x04029D7A RID: 171386
		public const int PhotoTexture = 15;

		// Token: 0x04029D7B RID: 171387
		public const int ShareButton = 16;

		// Token: 0x04029D7C RID: 171388
		public const int RewardRootItem = 17;

		// Token: 0x04029D7D RID: 171389
		public const int RewardTitleText = 18;

		// Token: 0x04029D7E RID: 171390
		public const int RewardItemLayout = 19;

		// Token: 0x04029D7F RID: 171391
		public const int RewardItemLayoutItem = 20;

		// Token: 0x04029D80 RID: 171392
		public const int ChatRootItem = 21;

		// Token: 0x04029D81 RID: 171393
		public const int NpcRoleItem = 22;

		// Token: 0x04029D82 RID: 171394
		public const int NpcChatContentText = 23;

		// Token: 0x04029D83 RID: 171395
		public const int SelfChatRootItem = 24;

		// Token: 0x04029D84 RID: 171396
		public const int SelfRoleItem = 25;

		// Token: 0x04029D85 RID: 171397
		public const int SelfChatContentRootItem = 26;

		// Token: 0x04029D86 RID: 171398
		public const int SelfChatContentButton = 27;

		// Token: 0x04029D87 RID: 171399
		public const int SelfChatContentText = 28;

		// Token: 0x04029D88 RID: 171400
		public const int SelfChatRedDotItem = 29;

		// Token: 0x04029D89 RID: 171401
		public const int BonusTipsText = 30;

		// Token: 0x04029D8A RID: 171402
		public const int Quest1RootItem = 31;

		// Token: 0x04029D8B RID: 171403
		public const int Quest2RootItem = 32;

		// Token: 0x04029D8C RID: 171404
		public const int Quest3RootItem = 33;

		// Token: 0x04029D8D RID: 171405
		public const int Quest4RootItem = 34;

		// Token: 0x04029D8E RID: 171406
		public const int Quest5RootItem = 35;

		// Token: 0x04029D8F RID: 171407
		public const int Quest6RootItem = 36;

		// Token: 0x04029D90 RID: 171408
		public const int Quest7RootItem = 37;

		// Token: 0x04029D91 RID: 171409
		public const int ExitButton = 38;

		// Token: 0x04029D92 RID: 171410
		public const int ShareBgTexture = 39;

		// Token: 0x04029D93 RID: 171411
		public const int RewardConfirmButtonItem = 40;
	}
}
