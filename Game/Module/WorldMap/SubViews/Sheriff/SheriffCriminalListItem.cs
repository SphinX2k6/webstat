using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Module.Sheriff;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.WorldMap.SubViews.Sheriff
{
	// Token: 0x02004B87 RID: 19335
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class SheriffCriminalListItem : GridProxyAbstract<SheriffCriminalInfo>
	{
		// Token: 0x060327F6 RID: 206838 RVA: 0x00CA224C File Offset: 0x00CA044C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 10;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickBtnCommon));
			this.BtnBindInfo = list2;
		}

		// Token: 0x060327F7 RID: 206839 RVA: 0x00CA23FC File Offset: 0x00CA05FC
		private void OnClickBtnCommon()
		{
			if (this.Data == null)
			{
				return;
			}
			Action<SheriffCriminalInfo> clickCallBack = this.ClickCallBack;
			if (clickCallBack == null)
			{
				return;
			}
			clickCallBack(this.Data);
		}

		// Token: 0x060327F8 RID: 206840 RVA: 0x00CA2420 File Offset: 0x00CA0620
		public override void Refresh(SheriffCriminalInfo data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			SheriffAnomalyInfo anomalyInfo = ModelBase<SheriffModel>.Instance.GetAnomalyInfo(data.AnomalyId);
			if (anomalyInfo == null)
			{
				return;
			}
			SheriffAnomaly? anomalyConfigById = ConfigBase<SheriffConfig>.Instance.GetAnomalyConfigById(data.AnomalyId);
			SheriffCriminal? criminalConfigById = ConfigBase<SheriffConfig>.Instance.GetCriminalConfigById(data.CriminalId);
			SheriffIdentity? identityConfigById = ConfigBase<SheriffConfig>.Instance.GetIdentityConfigById(data.Identity);
			if (identityConfigById == null || criminalConfigById == null || anomalyConfigById == null)
			{
				return;
			}
			ESheriffAnomalyState state = anomalyInfo.State;
			bool uiactive = state == ESheriffAnomalyState.Completed;
			Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(1), (state >= ESheriffAnomalyState.UnOpened) ? anomalyConfigById.Value.Name : "Sheriff_Unknow_1", Array.Empty<object>());
			this.RefreshProgress(anomalyInfo, state);
			this.RefreshCriminal(state, identityConfigById.Value, criminalConfigById.Value);
			if (state == ESheriffAnomalyState.Lock)
			{
				UUIItem item = base.GetItem(7);
				if (item != null)
				{
					item.SetUIActive(true);
				}
				Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(8), LevelGeneralCommons.GetConditionGroupHintText(anomalyConfigById.Value.UnlockConditionGroupId), Array.Empty<object>());
			}
			else
			{
				UUIItem item2 = base.GetItem(7);
				if (item2 != null)
				{
					item2.SetUIActive(false);
				}
			}
			UUIItem item3 = base.GetItem(9);
			if (item3 == null)
			{
				return;
			}
			item3.SetUIActive(uiactive);
		}

		// Token: 0x060327F9 RID: 206841 RVA: 0x00CA2564 File Offset: 0x00CA0764
		private void RefreshProgress(SheriffAnomalyInfo anomalyInfo, ESheriffAnomalyState state)
		{
			if (state == ESheriffAnomalyState.UnOpened)
			{
				Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(2), "FunctionMap_Content_14", Array.Empty<object>());
				return;
			}
			if (state == ESheriffAnomalyState.Opened)
			{
				UUIText text = base.GetText(2);
				if (text != null)
				{
					text.SetUIActive(true);
				}
				UUIText text2 = base.GetText(2);
				if (text2 == null)
				{
					return;
				}
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
				defaultInterpolatedStringHandler.AppendFormatted<int>(anomalyInfo.Progress);
				defaultInterpolatedStringHandler.AppendLiteral("%");
				text2.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
				return;
			}
			else
			{
				UUIText text3 = base.GetText(2);
				if (text3 == null)
				{
					return;
				}
				text3.SetUIActive(false);
				return;
			}
		}

		// Token: 0x060327FA RID: 206842 RVA: 0x00CA25F8 File Offset: 0x00CA07F8
		private void RefreshCriminal(ESheriffAnomalyState state, SheriffIdentity identityConfig, SheriffCriminal criminalConfig)
		{
			bool flag = this.Data.State >= ESheriffCriminalState.Confirmed;
			if (state == ESheriffAnomalyState.Lock)
			{
				UUISprite sprite = base.GetSprite(3);
				if (sprite != null)
				{
					sprite.SetUIActive(false);
				}
				UUIText text = base.GetText(4);
				if (text != null)
				{
					text.SetUIActive(true);
				}
				UUIText text2 = base.GetText(4);
				if (text2 != null)
				{
					text2.SetText("?", true);
				}
				Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(5), "Sheriff_Unknow_2", Array.Empty<object>());
				Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(6), "Sheriff_Unknow_3", Array.Empty<object>());
				return;
			}
			if (!flag)
			{
				UUISprite sprite2 = base.GetSprite(3);
				if (sprite2 != null)
				{
					sprite2.SetUIActive(false);
				}
				UUIText text3 = base.GetText(4);
				if (text3 != null)
				{
					text3.SetUIActive(true);
				}
				UUIText text4 = base.GetText(4);
				if (text4 != null)
				{
					text4.SetText("?", true);
				}
				Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(5), "Sheriff_Unknow_2", Array.Empty<object>());
				Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(6), "Sheriff_Unknow_3", Array.Empty<object>());
				return;
			}
			base.TrySetSpriteByPath(identityConfig.IconListData, base.GetSprite(3), false, null, null);
			UUIText text5 = base.GetText(4);
			if (text5 != null)
			{
				text5.SetUIActive(false);
			}
			Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(5), identityConfig.Name, Array.Empty<object>());
			List<TItem> dropPackagePreviewItemList = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackagePreviewItemList(criminalConfig.DropId);
			UUIText text6 = base.GetText(6);
			if (text6 == null)
			{
				return;
			}
			text6.SetText(dropPackagePreviewItemList[0].Count.ToString(), true);
		}

		// Token: 0x060327FB RID: 206843 RVA: 0x00CA2794 File Offset: 0x00CA0994
		public override object GetKey(SheriffCriminalInfo data, int displayIndex)
		{
			return data.CriminalId;
		}

		// Token: 0x0401D73E RID: 120638
		[Nullable(2)]
		private SheriffCriminalInfo Data;

		// Token: 0x0401D73F RID: 120639
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<SheriffCriminalInfo> ClickCallBack;

		// Token: 0x0200AC57 RID: 44119
		[NullableContext(0)]
		private static class EComponent
		{
			// Token: 0x04035962 RID: 219490
			public const int BtnCommon = 0;

			// Token: 0x04035963 RID: 219491
			public const int TextTitle = 1;

			// Token: 0x04035964 RID: 219492
			public const int TextProgress = 2;

			// Token: 0x04035965 RID: 219493
			public const int SprCriminal = 3;

			// Token: 0x04035966 RID: 219494
			public const int TextUnknown = 4;

			// Token: 0x04035967 RID: 219495
			public const int TextName = 5;

			// Token: 0x04035968 RID: 219496
			public const int TextMoney = 6;

			// Token: 0x04035969 RID: 219497
			public const int PnlLock = 7;

			// Token: 0x0403596A RID: 219498
			public const int TextLockTips = 8;

			// Token: 0x0403596B RID: 219499
			public const int PnlDone = 9;
		}
	}
}
