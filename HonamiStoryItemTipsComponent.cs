using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.HonamiStory;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001F11 RID: 7953
public class HonamiStoryItemTipsComponent : UiPanelBase, IItemTipsUiProxy
{
	// Token: 0x0600EDBE RID: 60862 RVA: 0x0040E0A8 File Offset: 0x0040C2A8
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUISprite)),
			new ValueTuple<int, Type>(2, typeof(UUISprite)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUITexture)),
			new ValueTuple<int, Type>(5, typeof(UUIText)),
			new ValueTuple<int, Type>(6, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIText)),
			new ValueTuple<int, Type>(9, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(10, typeof(UUIItem)),
			new ValueTuple<int, Type>(11, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(12, typeof(UUIItem)),
			new ValueTuple<int, Type>(13, typeof(UUIText)),
			new ValueTuple<int, Type>(14, typeof(UUIItem)),
			new ValueTuple<int, Type>(15, typeof(UUIItem)),
			new ValueTuple<int, Type>(16, typeof(UUIItem)),
			new ValueTuple<int, Type>(17, typeof(UUIItem)),
			new ValueTuple<int, Type>(18, typeof(UUIItem)),
			new ValueTuple<int, Type>(19, typeof(UUIItem)),
			new ValueTuple<int, Type>(20, typeof(UUIItem)),
			new ValueTuple<int, Type>(21, typeof(UUIItem)),
			new ValueTuple<int, Type>(22, typeof(UUITexture)),
			new ValueTuple<int, Type>(23, typeof(UUIItem)),
			new ValueTuple<int, Type>(24, typeof(UUIItem)),
			new ValueTuple<int, Type>(25, typeof(UUIItem))
		};
	}

	// Token: 0x0600EDBF RID: 60863 RVA: 0x0040E310 File Offset: 0x0040C510
	protected override void OnStart()
	{
		this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
		base.GetItem(14).SetUIActive(false);
		base.GetItem(15).SetUIActive(false);
		base.GetItem(17).SetUIActive(false);
		base.GetItem(18).SetUIActive(false);
		base.GetItem(20).SetUIActive(false);
		base.GetItem(21).SetUIActive(false);
		base.GetExtendToggle(6).RootUIComp.Get().SetUIActive(false);
		UUIItem item = base.GetItem(24);
		if (item != null)
		{
			item.SetUIActive(false);
		}
		UUIItem item2 = base.GetItem(23);
		if (item2 != null)
		{
			item2.SetUIActive(false);
		}
		this.PropertyLayout = new GenericLayout<HonamiStoryTipsPropertyItem, IHonamiStoryTipsPropertyData>(base.GetVerticalLayout(9), new Func<HonamiStoryTipsPropertyItem>(this.CreateProp), null, false, true);
		this.SkillLayout = new GenericLayout<HonamiStoryTipsTextItem, IHonamiStoryTipsBuffInfo>(base.GetVerticalLayout(11), new Func<HonamiStoryTipsTextItem>(this.CreateSkill), null, false, true);
		base.GetRootItem().SetPivot(new FVector2D(0.5f, 0.5f));
		base.GetRootItem().SetAnchorOffset(new FVector2D(0f, 0f));
	}

	// Token: 0x0600EDC0 RID: 60864 RVA: 0x0040E43C File Offset: 0x0040C63C
	protected override void OnBeforeShow()
	{
		this.PlayStartSequence();
	}

	// Token: 0x0600EDC1 RID: 60865 RVA: 0x0040E444 File Offset: 0x0040C644
	private void PlayStartSequence()
	{
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer == null)
		{
			return;
		}
		levelSequencePlayer.PlaySequencePurely("Start", false, false, null, null, false);
	}

	// Token: 0x0600EDC2 RID: 60866 RVA: 0x0040E474 File Offset: 0x0040C674
	public UniTask PlayCloseSequence()
	{
		HonamiStoryItemTipsComponent.<PlayCloseSequence>d__8 <PlayCloseSequence>d__;
		<PlayCloseSequence>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayCloseSequence>d__.<>4__this = this;
		<PlayCloseSequence>d__.<>1__state = -1;
		<PlayCloseSequence>d__.<>t__builder.Start<HonamiStoryItemTipsComponent.<PlayCloseSequence>d__8>(ref <PlayCloseSequence>d__);
		return <PlayCloseSequence>d__.<>t__builder.Task;
	}

	// Token: 0x0600EDC3 RID: 60867 RVA: 0x0040E4B8 File Offset: 0x0040C6B8
	[NullableContext(1)]
	public void Refresh(ItemTipsData dataFrom)
	{
		TipsHonamiStoryData tipsHonamiStoryData = dataFrom as TipsHonamiStoryData;
		if (tipsHonamiStoryData == null)
		{
			return;
		}
		HonamiStoryItem? honamiStoryItem = ConfigBase<HonamiStoryConfig>.Instance.GetHonamiStoryItem(tipsHonamiStoryData.ConfigId);
		if (honamiStoryItem == null)
		{
			return;
		}
		string name = honamiStoryItem.Value.Name;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), name, Array.Empty<object>());
		string attributesDescription = honamiStoryItem.Value.AttributesDescription;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(13), attributesDescription, Array.Empty<object>());
		base.GetItem(7).SetUIActive(false);
		string resourceId = (honamiStoryItem.Value.ItemType == 1) ? "SP_TipsTypeIcon1" : "SP_TipsTypeIcon2";
		UiResourceConfig instance = ConfigBase<UiResourceConfig>.Instance;
		string text = (instance != null) ? instance.GetResourcePath(resourceId) : null;
		this.SetSpriteByPath(text ?? string.Empty, base.GetSprite(2), false, null, null);
		string text2;
		string textStringId = Singleton<HonamiStoryDefine>.Instance.honamiItemTypeMap.TryGetValue((EHonamiStoryItemType)honamiStoryItem.Value.ItemType, out text2) ? text2 : string.Empty;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), textStringId, Array.Empty<object>());
		this.SetSpriteByPath(ConfigBase<HonamiStoryConfig>.Instance.GetHonamiStoryQuality(honamiStoryItem.Value.QualityId).Value.Bg, base.GetSprite(1), false, null, null);
		UUIText text3 = base.GetText(5);
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
		defaultInterpolatedStringHandler.AppendFormatted<int>(honamiStoryItem.Value.SellPrice);
		text3.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		base.SetItemIcon(base.GetTexture(22), honamiStoryItem.Value.Id, null, null);
		HonamiStoryItemDataBase itemData = ModelBase<HonamiStoryModel>.Instance.GetItemData(tipsHonamiStoryData.IncId);
		if (itemData == null || itemData.GetItemType() == EHonamiStoryItemType.Normal)
		{
			return;
		}
		HonamiStoryEquipItemData honamiStoryEquipItemData = ModelBase<HonamiStoryModel>.Instance.GetItemData(tipsHonamiStoryData.IncId) as HonamiStoryEquipItemData;
		if (honamiStoryEquipItemData != null)
		{
			int[] mainPropList = honamiStoryEquipItemData.GetMainPropList();
			List<IHonamiStoryTipsPropertyData> list = new List<IHonamiStoryTipsPropertyData>();
			foreach (int propId in mainPropList)
			{
				list.Add(new HonamiStoryTipsPropertyData
				{
					PropId = propId
				});
			}
			this.PropertyLayout.RefreshByData(list, null, true);
			List<IHonamiStoryTipsBuffInfo> buffTempIdList = honamiStoryEquipItemData.GetBuffTempIdList(false);
			this.SkillLayout.RefreshByData(buffTempIdList, null, true);
		}
	}

	// Token: 0x0600EDC4 RID: 60868 RVA: 0x0040E72D File Offset: 0x0040C92D
	[NullableContext(1)]
	private HonamiStoryTipsPropertyItem CreateProp()
	{
		return new HonamiStoryTipsPropertyItem();
	}

	// Token: 0x0600EDC5 RID: 60869 RVA: 0x0040E734 File Offset: 0x0040C934
	[NullableContext(1)]
	private HonamiStoryTipsTextItem CreateSkill()
	{
		return new HonamiStoryTipsTextItem();
	}

	// Token: 0x04007239 RID: 29241
	[Nullable(2)]
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x0400723A RID: 29242
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<HonamiStoryTipsPropertyItem, IHonamiStoryTipsPropertyData> PropertyLayout;

	// Token: 0x0400723B RID: 29243
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<HonamiStoryTipsTextItem, IHonamiStoryTipsBuffInfo> SkillLayout;

	// Token: 0x02008274 RID: 33396
	private enum EDefine
	{
		// Token: 0x0402C3E2 RID: 181218
		TxtName,
		// Token: 0x0402C3E3 RID: 181219
		SpriteTitleBg,
		// Token: 0x0402C3E4 RID: 181220
		SpriteTypeIcon,
		// Token: 0x0402C3E5 RID: 181221
		TxtType,
		// Token: 0x0402C3E6 RID: 181222
		TexCost,
		// Token: 0x0402C3E7 RID: 181223
		TxtLevel,
		// Token: 0x0402C3E8 RID: 181224
		TogLock,
		// Token: 0x0402C3E9 RID: 181225
		PanelTipsTime,
		// Token: 0x0402C3EA RID: 181226
		TxtTime,
		// Token: 0x0402C3EB RID: 181227
		PanelTipsProperty,
		// Token: 0x0402C3EC RID: 181228
		PanelList,
		// Token: 0x0402C3ED RID: 181229
		PanelSkill,
		// Token: 0x0402C3EE RID: 181230
		MainDescItem,
		// Token: 0x0402C3EF RID: 181231
		TxtDesc,
		// Token: 0x0402C3F0 RID: 181232
		BtnConfirmA,
		// Token: 0x0402C3F1 RID: 181233
		BtnConfirmB,
		// Token: 0x0402C3F2 RID: 181234
		PanelBtnR,
		// Token: 0x0402C3F3 RID: 181235
		BtnRA,
		// Token: 0x0402C3F4 RID: 181236
		BtnRB,
		// Token: 0x0402C3F5 RID: 181237
		PanelBtnL,
		// Token: 0x0402C3F6 RID: 181238
		BtnLA,
		// Token: 0x0402C3F7 RID: 181239
		BtnLB,
		// Token: 0x0402C3F8 RID: 181240
		TexItemIcon,
		// Token: 0x0402C3F9 RID: 181241
		PanelBottom,
		// Token: 0x0402C3FA RID: 181242
		PanelDoubleClicked,
		// Token: 0x0402C3FB RID: 181243
		TxtDoubleClicked
	}
}
