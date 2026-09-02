using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Protocol;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;

// Token: 0x02002401 RID: 9217
[NullableContext(1)]
[Nullable(0)]
public class WeekCardItem : UiPanelBase
{
	// Token: 0x06011D4B RID: 73035 RVA: 0x004E7488 File Offset: 0x004E5688
	protected unsafe override void OnRegisterComponent()
	{
		int num = 10;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUITexture));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickConfirm));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06011D4C RID: 73036 RVA: 0x004E7638 File Offset: 0x004E5838
	protected override void OnStart()
	{
		this.RewardLayout = new GenericLayout<WeekCardRewardGrid, IWeekRewardData>(base.GetHorizontalLayout(1), () => new WeekCardRewardGrid(), null, false, true);
	}

	// Token: 0x06011D4D RID: 73037 RVA: 0x004E7670 File Offset: 0x004E5870
	public void Refresh(WeekCardViewModel vm, WeekCardContentInfo info)
	{
		this.Vm = vm;
		this.ContentId = info.WeekCardContentId;
		this.Status = (EContentStatus)info.Status;
		this.UnlockDay = info.UnlockDay;
		this.UnlockTimeStamp = info.UnlockTimeStamp;
		this.RewardContent = new List<Tuple<int, int>>();
		foreach (KeyValuePair<int, int> keyValuePair in info.RewardContent)
		{
			this.RewardContent.Add(new Tuple<int, int>(keyValuePair.Key, keyValuePair.Value));
		}
		this.IsBuy = vm.IsBuy();
		this.RefreshView();
	}

	// Token: 0x06011D4E RID: 73038 RVA: 0x004E7728 File Offset: 0x004E5928
	public void RefreshView()
	{
		this.RefreshRewardTexture();
		List<IWeekRewardData> list = new List<IWeekRewardData>();
		foreach (Tuple<int, int> tuple in this.RewardContent)
		{
			list.Add(new WeekRewardData
			{
				ItemId = tuple.Item1,
				Count = tuple.Item2
			});
		}
		this.RewardLayout.RefreshByData(list, null, false);
		base.GetItem(3).SetUIActive(this.Status != EContentStatus.Received);
		base.GetItem(5).SetUIActive(this.IsBuy && this.Status == EContentStatus.CanReceive);
		base.GetItem(6).SetUIActive(this.IsBuy && this.Status == EContentStatus.Received);
		base.GetItem(8).SetAlpha((this.Status == EContentStatus.Received) ? 0.5f : 1f);
		this.ConfirmButton.SetUiActive(this.IsBuy && this.Status == EContentStatus.CanReceive);
		base.GetItem(7).SetUIActive(this.Status == EContentStatus.CanReceive);
		this.RefreshTime();
	}

	// Token: 0x06011D4F RID: 73039 RVA: 0x004E7864 File Offset: 0x004E5A64
	private void RefreshRewardTexture()
	{
		WeekCardViewModel vm = this.Vm;
		string text = (vm != null) ? vm.GetContentRewardTexturePath(this.ContentId) : null;
		if (string.IsNullOrEmpty(text))
		{
			return;
		}
		base.SetTextureByPath(text, base.GetTexture(9), null, null);
	}

	// Token: 0x06011D50 RID: 73040 RVA: 0x004E78AC File Offset: 0x004E5AAC
	public void RefreshTime()
	{
		base.GetText(4).SetUIActive(this.Status == EContentStatus.CannotReceive);
		if (this.IsBuy)
		{
			CommonDefine.ICountDown remainTimeDataFormat = Singleton<TimeUtil>.Instance.GetRemainTimeDataFormat3(Singleton<TimeUtil>.Instance.SetTimeSecond((double)this.UnlockTimeStamp - Singleton<TimeUtil>.Instance.GetServerTimeStamp()));
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), "WeekCard_1002", new <>z__ReadOnlySingleElementList<object>(remainTimeDataFormat.CountDownText ?? ""));
			return;
		}
		if (this.UnlockDay == 1)
		{
			base.GetText(4).ShowTextNew("WeekCard_1001");
			return;
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), "WeekCard_1006", new <>z__ReadOnlySingleElementList<object>(this.UnlockDay));
	}

	// Token: 0x06011D51 RID: 73041 RVA: 0x004E7969 File Offset: 0x004E5B69
	private void OnClickConfirm()
	{
		if (this.Status != EContentStatus.CanReceive)
		{
			return;
		}
		WeekCardViewModel vm = this.Vm;
		if (vm == null)
		{
			return;
		}
		vm.OnReceiveReward(this.ContentId).Forget<bool>();
	}

	// Token: 0x04008B79 RID: 35705
	private int ContentId;

	// Token: 0x04008B7A RID: 35706
	private EContentStatus Status;

	// Token: 0x04008B7B RID: 35707
	private int UnlockDay;

	// Token: 0x04008B7C RID: 35708
	private long UnlockTimeStamp;

	// Token: 0x04008B7D RID: 35709
	private List<Tuple<int, int>> RewardContent = new List<Tuple<int, int>>();

	// Token: 0x04008B7E RID: 35710
	private bool IsBuy;

	// Token: 0x04008B7F RID: 35711
	private readonly ButtonItem ConfirmButton = new ButtonItem(null);

	// Token: 0x04008B80 RID: 35712
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<WeekCardRewardGrid, IWeekRewardData> RewardLayout;

	// Token: 0x04008B81 RID: 35713
	[Nullable(2)]
	private WeekCardViewModel Vm;

	// Token: 0x02008734 RID: 34612
	[NullableContext(0)]
	private class EChildType
	{
		// Token: 0x0402DBB4 RID: 187316
		public const int ButtonWeekCardReward = 0;

		// Token: 0x0402DBB5 RID: 187317
		public const int PanelRewardLayout = 1;

		// Token: 0x0402DBB6 RID: 187318
		public const int PanelRewardItem = 2;

		// Token: 0x0402DBB7 RID: 187319
		public const int PanelLock = 3;

		// Token: 0x0402DBB8 RID: 187320
		public const int TextLock = 4;

		// Token: 0x0402DBB9 RID: 187321
		public const int PanelReceive = 5;

		// Token: 0x0402DBBA RID: 187322
		public const int PanelFinish = 6;

		// Token: 0x0402DBBB RID: 187323
		public const int PanelRedDot = 7;

		// Token: 0x0402DBBC RID: 187324
		public const int PanelFinishAlpha = 8;

		// Token: 0x0402DBBD RID: 187325
		public const int RewardTexture = 9;
	}
}
