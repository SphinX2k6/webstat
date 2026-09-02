using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.TrapDefense;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002C19 RID: 11289
[NullableContext(1)]
[Nullable(0)]
public class TrapDefenseBdQualityView : UiViewBase
{
	// Token: 0x0601694C RID: 92492 RVA: 0x0064455B File Offset: 0x0064275B
	public TrapDefenseBdQualityView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x0601694D RID: 92493 RVA: 0x00644574 File Offset: 0x00642774
	protected unsafe override void OnRegisterComponent()
	{
		int num = 11;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUILayoutBase));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIButtonComponent));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(10, new Action(this.OnClickBtnSure));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0601694E RID: 92494 RVA: 0x00644748 File Offset: 0x00642948
	protected override UniTask OnBeforeStartAsync()
	{
		TrapDefenseBdQualityView.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<TrapDefenseBdQualityView.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0601694F RID: 92495 RVA: 0x0064478C File Offset: 0x0064298C
	protected override void OnStart()
	{
		TermExplanationRegistryParam param = new TermExplanationRegistryParam
		{
			UiText = base.GetText(9),
			ViewType = ETermExplanationViewType.Center,
			ReportType = ETermExplanationReportType.TrapDefenseBuff
		};
		ControllerBase<TermExplanationController>.Instance.RegisterTextHyperlinkByParam(param);
	}

	// Token: 0x06016950 RID: 92496 RVA: 0x006447C8 File Offset: 0x006429C8
	protected override void OnAddEventListener()
	{
	}

	// Token: 0x06016951 RID: 92497 RVA: 0x006447CA File Offset: 0x006429CA
	protected override void OnRemoveEventListener()
	{
	}

	// Token: 0x06016952 RID: 92498 RVA: 0x006447CC File Offset: 0x006429CC
	protected override void OnBeforeShow()
	{
		if (this.ViewModel.CurSelectBdData != null)
		{
			this.UpdateData(this.ViewModel.CurSelectBdData);
		}
	}

	// Token: 0x06016953 RID: 92499 RVA: 0x006447EC File Offset: 0x006429EC
	protected override void OnBeforeDestroy()
	{
		this.ViewModel.OnViewClose();
		ControllerBase<TermExplanationController>.Instance.UnRegisterTextHyperlink(base.GetText(9));
	}

	// Token: 0x06016954 RID: 92500 RVA: 0x0064480B File Offset: 0x00642A0B
	private void OnClickBtnSure()
	{
		base.CloseMe(null);
	}

	// Token: 0x06016955 RID: 92501 RVA: 0x00644814 File Offset: 0x00642A14
	public void UpdateData(TrapDefenseBdData data)
	{
		this.BdData = data;
		UUITexture texture = base.GetTexture(3);
		base.SetTextureByPath(data.Config.Icon, texture, null, null);
		base.GetText(4).ShowTextNew(data.Config.Name);
		this.SetNewQualityMode(this.ViewModel.IsNewQualityMode);
		this.UpdateBdBuffQuality();
	}

	// Token: 0x06016956 RID: 92502 RVA: 0x0064487A File Offset: 0x00642A7A
	public void SetNewQualityMode(bool isNew)
	{
		UUIItem item = base.GetItem(5);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(isNew);
	}

	// Token: 0x06016957 RID: 92503 RVA: 0x00644890 File Offset: 0x00642A90
	public void UpdateBdBuffQuality()
	{
		ETrapDefenseBdBuffQuality showQuality = this.ViewModel.ShowQuality;
		List<TrapDefenseBdBuffData> qualityBuffDataList = this.BdData.GetQualityBuffDataList(showQuality);
		bool flag = qualityBuffDataList.Count > 0;
		UUIItem item = base.GetItem(7);
		if (item != null)
		{
			item.SetUIActive(flag);
		}
		if (flag)
		{
			int lastIndex = this.GetSelectGridIndex(qualityBuffDataList);
			this.LayoutBdBuff.RefreshByData(qualityBuffDataList, delegate
			{
				this.LayoutBdBuff.SelectGridProxy(Math.Max(lastIndex, 0), false);
			}, false);
		}
	}

	// Token: 0x06016958 RID: 92504 RVA: 0x00644909 File Offset: 0x00642B09
	public int GetSelectGridIndex(List<TrapDefenseBdBuffData> list)
	{
		if (this.ViewModel.CurSelectBdBuffData != null)
		{
			return list.FindIndex((TrapDefenseBdBuffData item) => item.Id == this.ViewModel.CurSelectBdBuffData.Id);
		}
		return this.LayoutBdBuff.GetSelectedGridIndex();
	}

	// Token: 0x06016959 RID: 92505 RVA: 0x00644936 File Offset: 0x00642B36
	private TrapDefenseBdBuffItem CreateItemBdBuff()
	{
		return new TrapDefenseBdBuffItem
		{
			OnSelectBuffItemCallback = new Action<TrapDefenseBdBuffData, TrapDefenseBdBuffItem>(this.OnSelectBdBuffItem)
		};
	}

	// Token: 0x0601695A RID: 92506 RVA: 0x00644950 File Offset: 0x00642B50
	private void OnSelectBdBuffItem(TrapDefenseBdBuffData data, TrapDefenseBdBuffItem _)
	{
		this.ViewModel.SetCurSelectBdBuffData(data);
		TrapDefenseBdBuff strengthenBeforeConfig = data.GetStrengthenBeforeConfig();
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(9), strengthenBeforeConfig.Desc, strengthenBeforeConfig.DescArgs());
	}

	// Token: 0x0601695B RID: 92507 RVA: 0x00644990 File Offset: 0x00642B90
	private void OnBtnHelp()
	{
		int helpIdBdSum = ConfigBase<TrapDefenseConfig>.Instance.GetHelpIdBdSum();
		ControllerBase<HelpController>.Instance.OpenHelpById(helpIdBdSum);
	}

	// Token: 0x0601695C RID: 92508 RVA: 0x006449B3 File Offset: 0x00642BB3
	private void OnBtnClose()
	{
		base.CloseMe(null);
	}

	// Token: 0x0400AE63 RID: 44643
	public PopupCaptionItem PopupCaption;

	// Token: 0x0400AE64 RID: 44644
	public TrapDefenseBdData BdData;

	// Token: 0x0400AE65 RID: 44645
	public GenericLayout<TrapDefenseBdBuffItem, TrapDefenseBdBuffData> LayoutBdBuff;

	// Token: 0x0400AE66 RID: 44646
	public TrapDefenseBdQualityViewModel ViewModel = ModelBase<TrapDefenseModel>.Instance.ViewModelBdQuality;

	// Token: 0x02008F34 RID: 36660
	[NullableContext(0)]
	private class EChildType
	{
		// Token: 0x0403017C RID: 196988
		public const int ItemBgYellowLight = 0;

		// Token: 0x0403017D RID: 196989
		public const int ItemBgRedLight = 1;

		// Token: 0x0403017E RID: 196990
		public const int ItemCaption = 2;

		// Token: 0x0403017F RID: 196991
		public const int TextureIcon = 3;

		// Token: 0x04030180 RID: 196992
		public const int TextTitle = 4;

		// Token: 0x04030181 RID: 196993
		public const int ItemNewAddRoot = 5;

		// Token: 0x04030182 RID: 196994
		public const int TextNewAdd = 6;

		// Token: 0x04030183 RID: 196995
		public const int LayoutBdBuff = 7;

		// Token: 0x04030184 RID: 196996
		public const int ItemBdBuff = 8;

		// Token: 0x04030185 RID: 196997
		public const int TextDesc = 9;

		// Token: 0x04030186 RID: 196998
		public const int BtnSure = 10;
	}
}
