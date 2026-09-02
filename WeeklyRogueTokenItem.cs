using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Roguelike;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02002D42 RID: 11586
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class WeeklyRogueTokenItem : GridProxyAbstract<RogueWeeklyEntry>
{
	// Token: 0x060175F9 RID: 95737 RVA: 0x0067B3D4 File Offset: 0x006795D4
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUISprite)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(10, typeof(UUIItem)),
			new ValueTuple<int, Type>(11, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(4, new Action<EToggleState>(this.OnClick))
		};
	}

	// Token: 0x060175FA RID: 95738 RVA: 0x0067B51A File Offset: 0x0067971A
	protected override void OnStart()
	{
		this.TagLayout = new GenericLayout<WeeklyRogueTagItem, int>(base.GetHorizontalLayout(9), new Func<WeeklyRogueTagItem>(this.OnCreateTagItem), null, false, true);
		base.GetItem(11).SetUIActive(false);
	}

	// Token: 0x060175FB RID: 95739 RVA: 0x0067B54C File Offset: 0x0067974C
	protected override void OnBeforeShow()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.WeeklyRogueDescModeChange, new Action(this.OnDescModeChange));
	}

	// Token: 0x060175FC RID: 95740 RVA: 0x0067B56A File Offset: 0x0067976A
	protected override void OnBeforeHide()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.WeeklyRogueDescModeChange, new Action(this.OnDescModeChange));
	}

	// Token: 0x060175FD RID: 95741 RVA: 0x0067B588 File Offset: 0x00679788
	public override void Refresh(RogueWeeklyEntry data, bool isSelected, int gridIndex)
	{
		this.Data = data;
		this.UpdateByConfigId(data.ConfigId);
		base.GetItem(11).SetUIActive(data.IsRecommend);
	}

	// Token: 0x060175FE RID: 95742 RVA: 0x0067B5B0 File Offset: 0x006797B0
	private void OnClick(EToggleState toggleState)
	{
		int? obj = (base.GetExtendToggle(4).GetToggleState() == EToggleState.ETT_Checked) ? new int?(base.GridIndex) : null;
		Action<int?> onSelectedChange = this.OnSelectedChange;
		if (onSelectedChange == null)
		{
			return;
		}
		onSelectedChange(obj);
	}

	// Token: 0x060175FF RID: 95743 RVA: 0x0067B5F4 File Offset: 0x006797F4
	public override void OnSelected(bool fireEvent)
	{
		base.GetExtendToggle(4).SetToggleState(EToggleState.ETT_Checked, false, false, false);
		ModelBase<WeeklyRogueModel>.Instance.SelectEntry = this.Data;
	}

	// Token: 0x06017600 RID: 95744 RVA: 0x0067B617 File Offset: 0x00679817
	public override void OnDeselected(bool fireEvent)
	{
		base.GetExtendToggle(4).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		ModelBase<WeeklyRogueModel>.Instance.SelectEntry = null;
	}

	// Token: 0x06017601 RID: 95745 RVA: 0x0067B638 File Offset: 0x00679838
	private void OnDescModeChange()
	{
		if (this.ConfigId == 0)
		{
			return;
		}
		RogueWeeklyBuffPool? rogueWeeklyBuffPool = ConfigBase<WeeklyRogueConfig>.Instance.GetRogueWeeklyBuffPool(this.ConfigId);
		if (rogueWeeklyBuffPool == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.WeeklyRogue;
			ELogAuthor author = ELogAuthor.LPH;
			string message = "刷新周常肉鸽信物格子失败，找不到对应的配置";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ConfigId", this.ConfigId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		if (ModelBase<WeeklyRogueModel>.Instance.DescMode == EDescModel.SIMPLE)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), rogueWeeklyBuffPool.Value.BuffDescSimple, Array.Empty<object>());
			return;
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), rogueWeeklyBuffPool.Value.BuffDesc, rogueWeeklyBuffPool.Value.BuffDescParam());
	}

	// Token: 0x06017602 RID: 95746 RVA: 0x0067B700 File Offset: 0x00679900
	public void UpdateByConfigId(int configId)
	{
		this.ConfigId = configId;
		RogueWeeklyBuffPool? rogueWeeklyBuffPool = ConfigBase<WeeklyRogueConfig>.Instance.GetRogueWeeklyBuffPool(configId);
		if (rogueWeeklyBuffPool == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.WeeklyRogue;
			ELogAuthor author = ELogAuthor.LPH;
			string message = "刷新周常肉鸽信物格子失败，找不到对应的配置";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ConfigId", configId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		base.GetItem(5).SetUIActive(false);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), rogueWeeklyBuffPool.Value.BuffName, Array.Empty<object>());
		if (ModelBase<WeeklyRogueModel>.Instance.DescMode == EDescModel.SIMPLE)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), rogueWeeklyBuffPool.Value.BuffDescSimple, Array.Empty<object>());
		}
		else
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), rogueWeeklyBuffPool.Value.BuffDesc, rogueWeeklyBuffPool.Value.BuffDescParam());
		}
		base.SetTextureByPath(rogueWeeklyBuffPool.Value.BuffIcon, base.GetTexture(1), null, null);
		RogueWeekQualityConfig? rogueWeeklyQualityConfig = ConfigBase<WeeklyRogueConfig>.Instance.GetRogueWeeklyQualityConfig(rogueWeeklyBuffPool.Value.Quality);
		if (rogueWeeklyQualityConfig != null)
		{
			base.SetTextureByPath(rogueWeeklyQualityConfig.Value.TokenBgNew, base.GetTexture(0), null, null);
		}
		base.GetSprite(6).SetColor(FColor.FromHex(rogueWeeklyQualityConfig.Value.TokenColor));
		base.GetItem(7).SetUIActive(rogueWeeklyBuffPool.Value.Quality == 6);
		base.GetItem(8).SetUIActive(rogueWeeklyBuffPool.Value.Quality == 5);
		this.TagLayout.RefreshByData(ModelBase<WeeklyRogueModel>.Instance.GetRogueWeeklyBuffTagIdList(configId), null, false);
	}

	// Token: 0x06017603 RID: 95747 RVA: 0x0067B8D4 File Offset: 0x00679AD4
	public void SetInteractive(bool bActive)
	{
		base.GetExtendToggle(4).SetSelfInteractive(bActive);
	}

	// Token: 0x06017604 RID: 95748 RVA: 0x0067B8E3 File Offset: 0x00679AE3
	private WeeklyRogueTagItem OnCreateTagItem()
	{
		return new WeeklyRogueTagItem();
	}

	// Token: 0x0400B373 RID: 45939
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<WeeklyRogueTagItem, int> TagLayout;

	// Token: 0x0400B374 RID: 45940
	[Nullable(2)]
	private RogueWeeklyEntry Data;

	// Token: 0x0400B375 RID: 45941
	private int ConfigId;

	// Token: 0x0400B376 RID: 45942
	[Nullable(2)]
	public Action<int?> OnSelectedChange;

	// Token: 0x02009008 RID: 36872
	[NullableContext(0)]
	private enum EWeeklyRogueTokenItem
	{
		// Token: 0x04030531 RID: 197937
		QualityBgTexture,
		// Token: 0x04030532 RID: 197938
		IconTexture,
		// Token: 0x04030533 RID: 197939
		NameText,
		// Token: 0x04030534 RID: 197940
		DescText,
		// Token: 0x04030535 RID: 197941
		SelfToggle,
		// Token: 0x04030536 RID: 197942
		NewItem,
		// Token: 0x04030537 RID: 197943
		QualityLineSprite,
		// Token: 0x04030538 RID: 197944
		GoldItem,
		// Token: 0x04030539 RID: 197945
		YellowItem,
		// Token: 0x0403053A RID: 197946
		TagLayout,
		// Token: 0x0403053B RID: 197947
		TagItem,
		// Token: 0x0403053C RID: 197948
		ItemRecommend
	}
}
