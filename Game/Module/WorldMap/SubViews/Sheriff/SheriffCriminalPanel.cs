using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Map.Mark;
using CSharpScript.Game.Module.Sheriff;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.WorldMap.ViewComponent;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.WorldMap.SubViews.Sheriff
{
	// Token: 0x02004B88 RID: 19336
	[NullableContext(1)]
	[Nullable(0)]
	public class SheriffCriminalPanel : WorldMapSecondaryUi
	{
		// Token: 0x060327FD RID: 206845 RVA: 0x00CA27A9 File Offset: 0x00CA09A9
		public override string GetResourceId()
		{
			return "UiItem_SkyEyeMapNpcPopup";
		}

		// Token: 0x060327FE RID: 206846 RVA: 0x00CA27B0 File Offset: 0x00CA09B0
		[PreserveBaseOverrides]
		protected new virtual SheriffPopupRightItem GetPopupRightItem()
		{
			return new SheriffPopupRightItem();
		}

		// Token: 0x060327FF RID: 206847 RVA: 0x00CA27B8 File Offset: 0x00CA09B8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUILoopScrollViewComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06032800 RID: 206848 RVA: 0x00CA2824 File Offset: 0x00CA0A24
		protected override UniTask OnBeforeStartAsync()
		{
			SheriffCriminalPanel.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<SheriffCriminalPanel.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06032801 RID: 206849 RVA: 0x00CA2867 File Offset: 0x00CA0A67
		private void InitScroll()
		{
			this.LoopScroll = new LoopScrollView<SheriffCriminalListItem, SheriffCriminalInfo>(base.GetLoopScrollViewComponent(0), (AUIBaseActor)base.GetItem(1).GetOwner(), new Func<SheriffCriminalListItem>(this.CreateGrid), false);
		}

		// Token: 0x06032802 RID: 206850 RVA: 0x00CA2899 File Offset: 0x00CA0A99
		private SheriffCriminalListItem CreateGrid()
		{
			return new SheriffCriminalListItem
			{
				ClickCallBack = new Action<SheriffCriminalInfo>(this.OnClickCriminal)
			};
		}

		// Token: 0x06032803 RID: 206851 RVA: 0x00CA28B4 File Offset: 0x00CA0AB4
		private void OnClickCriminal(SheriffCriminalInfo data)
		{
			SheriffAnomalyInfo anomalyInfo = ModelBase<SheriffModel>.Instance.GetAnomalyInfo(data.AnomalyId);
			if (anomalyInfo == null)
			{
				return;
			}
			if (anomalyInfo.State == ESheriffAnomalyState.Lock)
			{
				ControllerBase<SheriffController>.Instance.OpenAnomalyConditionView(data.AnomalyId);
				return;
			}
			base.CloseWithCallBack(delegate
			{
				Singleton<EventSystem>.Instance.Emit<NavigateMark>(EEventName.WorldMapNavigate, new NavigateMark
				{
					MarkId = anomalyInfo.MarkId,
					MarkType = EMarkType.SheriffAnomaly,
					Focal = new bool?(true)
				});
			}, true);
		}

		// Token: 0x06032804 RID: 206852 RVA: 0x00CA2918 File Offset: 0x00CA0B18
		protected override void OnShowWorldMapSecondaryUi(params object[] param)
		{
			if (param.Length == 0)
			{
				return;
			}
			int zoneId = (int)param[0];
			List<SheriffCriminalInfo> criminalList = ModelBase<SheriffModel>.Instance.GetCriminalList(zoneId);
			criminalList.Sort(new Comparison<SheriffCriminalInfo>(this.CompareCriminal));
			LoopScrollView<SheriffCriminalListItem, SheriffCriminalInfo> loopScroll = this.LoopScroll;
			if (loopScroll == null)
			{
				return;
			}
			loopScroll.RefreshByData(criminalList, false, null, false);
		}

		// Token: 0x06032805 RID: 206853 RVA: 0x00CA2968 File Offset: 0x00CA0B68
		private int CompareCriminal(SheriffCriminalInfo a, SheriffCriminalInfo b)
		{
			SheriffAnomalyInfo anomalyInfo = ModelBase<SheriffModel>.Instance.GetAnomalyInfo(a.AnomalyId);
			SheriffAnomalyInfo anomalyInfo2 = ModelBase<SheriffModel>.Instance.GetAnomalyInfo(b.AnomalyId);
			int sortGroup = this.GetSortGroup((anomalyInfo != null) ? new ESheriffAnomalyState?(anomalyInfo.State) : null);
			int sortGroup2 = this.GetSortGroup((anomalyInfo2 != null) ? new ESheriffAnomalyState?(anomalyInfo2.State) : null);
			if (sortGroup != sortGroup2)
			{
				return sortGroup - sortGroup2;
			}
			if (sortGroup == 0 && anomalyInfo != null && anomalyInfo2 != null && anomalyInfo.Progress != anomalyInfo2.Progress)
			{
				return anomalyInfo2.Progress - anomalyInfo.Progress;
			}
			SheriffCriminal? criminalConfigById = ConfigBase<SheriffConfig>.Instance.GetCriminalConfigById(a.CriminalId);
			int num = (criminalConfigById != null) ? criminalConfigById.GetValueOrDefault().Priority : 0;
			criminalConfigById = ConfigBase<SheriffConfig>.Instance.GetCriminalConfigById(b.CriminalId);
			return ((criminalConfigById != null) ? criminalConfigById.GetValueOrDefault().Priority : 0) - num;
		}

		// Token: 0x06032806 RID: 206854 RVA: 0x00CA2A68 File Offset: 0x00CA0C68
		private int GetSortGroup(ESheriffAnomalyState? state)
		{
			if (state != null)
			{
				switch (state.GetValueOrDefault())
				{
				case ESheriffAnomalyState.Lock:
					return 2;
				case ESheriffAnomalyState.UnActivated:
					return 1;
				case ESheriffAnomalyState.UnOpened:
					return 0;
				case ESheriffAnomalyState.Opened:
					return 0;
				case ESheriffAnomalyState.Completed:
					return 3;
				}
			}
			return 4;
		}

		// Token: 0x0401D740 RID: 120640
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private LoopScrollView<SheriffCriminalListItem, SheriffCriminalInfo> LoopScroll;

		// Token: 0x0200AC58 RID: 44120
		[NullableContext(0)]
		private static class EComponent
		{
			// Token: 0x0403596C RID: 219500
			public const int Loop = 0;

			// Token: 0x0403596D RID: 219501
			public const int LoopItem = 1;
		}
	}
}
