using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.ExploreLevel;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.SkipInterface;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001B61 RID: 7009
[NullableContext(1)]
[Nullable(0)]
public class ExploreLevelItem : UiPanelBase, IGridProxy<CountryExploreScoreData>
{
	// Token: 0x17001042 RID: 4162
	// (get) Token: 0x0600CAF6 RID: 51958 RVA: 0x00361E15 File Offset: 0x00360015
	// (set) Token: 0x0600CAF7 RID: 51959 RVA: 0x00361E1D File Offset: 0x0036001D
	[Nullable(new byte[]
	{
		2,
		1,
		1,
		1
	})]
	public IScrollViewDelegate<IGridProxy<CountryExploreScoreData>, CountryExploreScoreData> ScrollViewDelegate { [return: Nullable(new byte[]
	{
		2,
		1,
		1,
		1
	})] get; [param: Nullable(new byte[]
	{
		2,
		1,
		1,
		1
	})] set; }

	// Token: 0x17001043 RID: 4163
	// (get) Token: 0x0600CAF8 RID: 51960 RVA: 0x00361E26 File Offset: 0x00360026
	// (set) Token: 0x0600CAF9 RID: 51961 RVA: 0x00361E2E File Offset: 0x0036002E
	public int GridIndex { get; set; }

	// Token: 0x17001044 RID: 4164
	// (get) Token: 0x0600CAFA RID: 51962 RVA: 0x00361E37 File Offset: 0x00360037
	// (set) Token: 0x0600CAFB RID: 51963 RVA: 0x00361E3F File Offset: 0x0036003F
	public int DisplayIndex { get; set; }

	// Token: 0x0600CAFC RID: 51964 RVA: 0x00361E48 File Offset: 0x00360048
	protected unsafe override void OnRegisterComponent()
	{
		int num = 7;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUISprite));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.OnClickedSkipToButton));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(5, new Action(this.OnClickedReceiveButton));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600CAFD RID: 51965 RVA: 0x00361FB6 File Offset: 0x003601B6
	public void Clear()
	{
	}

	// Token: 0x0600CAFE RID: 51966 RVA: 0x00361FB8 File Offset: 0x003601B8
	public void OnSelected(bool fireEvent)
	{
	}

	// Token: 0x0600CAFF RID: 51967 RVA: 0x00361FBA File Offset: 0x003601BA
	public void OnDeselected(bool fireEvent)
	{
	}

	// Token: 0x0600CB00 RID: 51968 RVA: 0x00361FBC File Offset: 0x003601BC
	protected override void OnBeforeDestroy()
	{
		this.CountryExploreScoreData = null;
		this.OnClickedReceiveButtonCallback = null;
	}

	// Token: 0x0600CB01 RID: 51969 RVA: 0x00361FCC File Offset: 0x003601CC
	public void Refresh(CountryExploreScoreData data, bool isSelected, int gridIndex)
	{
		this.CountryExploreScoreData = data;
		this.GridIndex = gridIndex;
		base.SetTextureByPath(ModelBase<ExploreLevelModel>.Instance.ExploreScoreItemTexturePath, base.GetTexture(0), null, null);
		string localTextNew = ConfigMultiTextLang.GetLocalTextNew(data.GetAreaNameTextId(), null);
		int progress = data.Progress;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "AreaExploreProgress", new <>z__ReadOnlyArray<object>(new object[]
		{
			localTextNew,
			progress
		}));
		ExploreAreaData exploreAreaData = ModelBase<ExploreProgressModel>.Instance.GetExploreAreaData(data.AreaId);
		if (exploreAreaData == null)
		{
			return;
		}
		int progress2 = exploreAreaData.GetProgress();
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), "CurrentAreaExploreProgress", new <>z__ReadOnlySingleElementList<object>(progress2));
		base.GetText(3).SetText(data.Score.ToString(), true);
		bool isReceived = data.GetIsReceived();
		bool flag = data.CanReceive();
		if (isReceived)
		{
			base.GetSprite(6).SetUIActive(true);
			base.SetButtonUiActive(4, false);
			base.SetButtonUiActive(5, false);
			return;
		}
		if (flag)
		{
			base.GetSprite(6).SetUIActive(false);
			base.SetButtonUiActive(4, false);
			base.SetButtonUiActive(5, true);
			return;
		}
		base.GetSprite(6).SetUIActive(false);
		base.SetButtonUiActive(4, true);
		base.SetButtonUiActive(5, false);
	}

	// Token: 0x0600CB02 RID: 51970 RVA: 0x0036210D File Offset: 0x0036030D
	public void BindOnClickedReceiveButton(Action<CountryExploreScoreData> onClickedReceiveButton)
	{
		this.OnClickedReceiveButtonCallback = onClickedReceiveButton;
	}

	// Token: 0x0600CB03 RID: 51971 RVA: 0x00362118 File Offset: 0x00360318
	private void OnClickedSkipToButton()
	{
		CountryExploreScoreData countryExploreScoreData = this.CountryExploreScoreData;
		Area? area = (countryExploreScoreData != null) ? countryExploreScoreData.GetAreaConfig() : null;
		if (area == null)
		{
			return;
		}
		EMarkType deliveryMarkType = (EMarkType)area.Value.DeliveryMarkType;
		int deliveryMarkId = area.Value.DeliveryMarkId;
		if (deliveryMarkType != EMarkType.AreaMark)
		{
			return;
		}
		if (deliveryMarkId <= 0)
		{
			return;
		}
		SkipTaskManager.Run(ESkipName.SkipToWorldMapView, new object[]
		{
			deliveryMarkType.ToString(),
			deliveryMarkId.ToString()
		});
	}

	// Token: 0x0600CB04 RID: 51972 RVA: 0x0036219C File Offset: 0x0036039C
	private void OnClickedReceiveButton()
	{
		Action<CountryExploreScoreData> onClickedReceiveButtonCallback = this.OnClickedReceiveButtonCallback;
		if (onClickedReceiveButtonCallback == null)
		{
			return;
		}
		onClickedReceiveButtonCallback(this.CountryExploreScoreData);
	}

	// Token: 0x0600CB05 RID: 51973 RVA: 0x003621B4 File Offset: 0x003603B4
	public object GetKey(CountryExploreScoreData data, int gridIndex)
	{
		return this.GridIndex;
	}

	// Token: 0x04006115 RID: 24853
	[Nullable(2)]
	private CountryExploreScoreData CountryExploreScoreData;

	// Token: 0x04006116 RID: 24854
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Action<CountryExploreScoreData> OnClickedReceiveButtonCallback;

	// Token: 0x02007E4B RID: 32331
	[NullableContext(0)]
	private enum EChildType
	{
		// Token: 0x0402B05F RID: 176223
		ScoreItemTexture,
		// Token: 0x0402B060 RID: 176224
		TitleNameText,
		// Token: 0x0402B061 RID: 176225
		CurrentProgressText,
		// Token: 0x0402B062 RID: 176226
		ScoreRewardText,
		// Token: 0x0402B063 RID: 176227
		SkipToButton,
		// Token: 0x0402B064 RID: 176228
		ReceiveButton,
		// Token: 0x0402B065 RID: 176229
		DoneSprite
	}
}
