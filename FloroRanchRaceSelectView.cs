using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001C3D RID: 7229
[NullableContext(1)]
[Nullable(0)]
public class FloroRanchRaceSelectView : UiViewBase
{
	// Token: 0x0600D2B7 RID: 53943 RVA: 0x00380AAB File Offset: 0x0037ECAB
	public FloroRanchRaceSelectView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x0600D2B8 RID: 53944 RVA: 0x00380ACC File Offset: 0x0037ECCC
	protected unsafe override void OnRegisterComponent()
	{
		int num = 5;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnConfirmBtnClick));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(5, new Action(this.OnCloseBtnClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600D2B9 RID: 53945 RVA: 0x00380BF8 File Offset: 0x0037EDF8
	protected override UniTask OnBeforeStartAsync()
	{
		FloroRanchRaceSelectView.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<FloroRanchRaceSelectView.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600D2BA RID: 53946 RVA: 0x00380C3C File Offset: 0x0037EE3C
	public void RefreshSelectedNum()
	{
		int num = this.FixedRaceIds.Count + this.SelectedRaceIds.Count;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), "FloroRanchRaceSelectedNum", new <>z__ReadOnlyArray<object>(new object[]
		{
			num,
			this.TotalNum
		}));
		base.GetButton(3).SetSelfInteractive(num == this.TotalNum);
	}

	// Token: 0x0600D2BB RID: 53947 RVA: 0x00380CB0 File Offset: 0x0037EEB0
	private bool IsRaceFixed(int raceId)
	{
		using (List<int>.Enumerator enumerator = this.FixedRaceIds.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current == raceId)
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x0600D2BC RID: 53948 RVA: 0x00380D08 File Offset: 0x0037EF08
	private void OnToggleCallback(int raceId)
	{
		if (this.FixedRaceIds.Count != this.TotalNum)
		{
			int num = this.SelectedRaceIds.IndexOf(raceId);
			if (num != -1)
			{
				this.SelectedRaceIds.RemoveAt(num);
			}
			else
			{
				if (this.FixedRaceIds.Count + this.SelectedRaceIds.Count == this.TotalNum)
				{
					int num2 = this.SelectedRaceIds[0];
					this.SelectedRaceIds.RemoveAt(0);
					FloroRanchRaceCardItem layoutItemByKey = this.RaceLayout.GetLayoutItemByKey(num2);
					if (layoutItemByKey != null)
					{
						layoutItemByKey.SetToggleState(false);
					}
				}
				this.SelectedRaceIds.Add(raceId);
			}
			this.RefreshSelectedNum();
			return;
		}
		ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Farm_RaceLock", Array.Empty<object>());
		FloroRanchRaceCardItem layoutItemByKey2 = this.RaceLayout.GetLayoutItemByKey(raceId);
		if (layoutItemByKey2 == null)
		{
			return;
		}
		layoutItemByKey2.SetToggleState(false);
	}

	// Token: 0x0600D2BD RID: 53949 RVA: 0x00380DE1 File Offset: 0x0037EFE1
	private FloroRanchRaceCardItem CreateRaceCard()
	{
		return new FloroRanchRaceCardItem
		{
			ActivityDataType = this.ActivityDataType,
			IsFixedRace = new Func<int, bool>(this.IsRaceFixed),
			OnToggleCallBack = new Action<int>(this.OnToggleCallback)
		};
	}

	// Token: 0x0600D2BE RID: 53950 RVA: 0x00380E18 File Offset: 0x0037F018
	private void OnConfirmBtnClick()
	{
		List<int> list = new List<int>();
		list.AddRange(this.FixedRaceIds);
		list.AddRange(this.SelectedRaceIds);
		if (this.ActivityDataType == EFloroRanchActivityDataType.Normal)
		{
			Singleton<EventSystem>.Instance.Emit<IReadOnlyList<int>>(EEventName.FloroRanchRaceRedDot, list);
		}
		Dictionary<int, List<int>> dictionary = LocalStorage.GetPlayer<Dictionary<int, List<int>>>(ELocalStoragePlayerKey.FloroRanchSelectedRaceIds, null) ?? new Dictionary<int, List<int>>();
		dictionary[this.SubDungeonId] = list;
		LocalStorage.SetPlayer<Dictionary<int, List<int>>>(ELocalStoragePlayerKey.FloroRanchSelectedRaceIds, dictionary);
		base.CloseMe(null);
	}

	// Token: 0x0600D2BF RID: 53951 RVA: 0x00380E94 File Offset: 0x0037F094
	private void OnCloseBtnClick()
	{
		if (this.ActivityDataType == EFloroRanchActivityDataType.Normal)
		{
			FloroRanchRaceSelectViewParam floroRanchRaceSelectViewParam = (FloroRanchRaceSelectViewParam)this.OpenParam;
			Singleton<EventSystem>.Instance.Emit<IReadOnlyList<int>>(EEventName.FloroRanchRaceRedDot, floroRanchRaceSelectViewParam.SubDungeonData.SelectedRaceIds);
		}
		base.CloseMe(null);
	}

	// Token: 0x04006460 RID: 25696
	private List<int> FixedRaceIds = new List<int>();

	// Token: 0x04006461 RID: 25697
	private List<int> SelectedRaceIds = new List<int>();

	// Token: 0x04006462 RID: 25698
	private int SubDungeonId;

	// Token: 0x04006463 RID: 25699
	private int TotalNum;

	// Token: 0x04006464 RID: 25700
	private EFloroRanchActivityDataType ActivityDataType;

	// Token: 0x04006465 RID: 25701
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<FloroRanchRaceCardItem, FloroRanchRaceData> RaceLayout;

	// Token: 0x02007F3D RID: 32573
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x0402B4E9 RID: 177385
		public const int LayoutRaceCard = 0;

		// Token: 0x0402B4EA RID: 177386
		public const int ItemRaceCard = 1;

		// Token: 0x0402B4EB RID: 177387
		public const int TextSelectedNum = 2;

		// Token: 0x0402B4EC RID: 177388
		public const int ButtonConfirm = 3;

		// Token: 0x0402B4ED RID: 177389
		public const int ButtonHelp = 4;

		// Token: 0x0402B4EE RID: 177390
		public const int ButtonClose = 5;
	}
}
