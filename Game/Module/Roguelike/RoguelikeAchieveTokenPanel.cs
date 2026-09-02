using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x02005132 RID: 20786
	[NullableContext(1)]
	[Nullable(0)]
	public class RoguelikeAchieveTokenPanel : UiPanelBase
	{
		// Token: 0x06035831 RID: 219185 RVA: 0x00D6F30C File Offset: 0x00D6D50C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnBtnDetailClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06035832 RID: 219186 RVA: 0x00D6F438 File Offset: 0x00D6D638
		protected override void OnStart()
		{
			this.TokenDetailLayout = new GenericLayout<RoguelikeAchieveSmallTokenGrid, RogueGainEntry>(base.GetHorizontalLayout(3), new Func<RoguelikeAchieveSmallTokenGrid>(this.CreateTokenDetailGrid), base.GetItem(4).GetOwner() as AUIBaseActor, false, true);
			base.SetUiActive(false);
			UUIButtonComponent button = base.GetButton(0);
			if (button != null)
			{
				button.SetSelfInteractive(false);
			}
			this.RefreshTokenDetailLayout(new List<RogueGainEntry>());
		}

		// Token: 0x06035833 RID: 219187 RVA: 0x00D6F49B File Offset: 0x00D6D69B
		protected override void OnBeforeDestroy()
		{
			this.TokenDetailLayout = null;
			this.CurrentArchiveInfoData = null;
			this.Vm = null;
		}

		// Token: 0x06035834 RID: 219188 RVA: 0x00D6F4B2 File Offset: 0x00D6D6B2
		public void SetViewModel(RoguelikeAchieveViewModel vm)
		{
			this.Vm = vm;
			UUIButtonComponent button = base.GetButton(0);
			if (button == null)
			{
				return;
			}
			button.SetSelfInteractive(this.CurrentArchiveInfoData != null);
		}

		// Token: 0x06035835 RID: 219189 RVA: 0x00D6F4D8 File Offset: 0x00D6D6D8
		[NullableContext(2)]
		public void Refresh(RogueArchiveInfoData archiveInfoData)
		{
			this.CurrentArchiveInfoData = archiveInfoData;
			if (archiveInfoData == null || !archiveInfoData.HasData)
			{
				base.SetUiActive(false);
				return;
			}
			RoguelikeInfo roguelikeInfo = archiveInfoData.RoguelikeInfo;
			List<RogueGainEntry> sortedBuffEntryList = this.GetSortedBuffEntryList(roguelikeInfo.BuffEntryList);
			UUIButtonComponent button = base.GetButton(0);
			if (button != null)
			{
				button.SetSelfInteractive(this.Vm != null);
			}
			base.GetText(2).SetText(sortedBuffEntryList.Count.ToString(), true);
			base.GetItem(5).SetUIActive(sortedBuffEntryList.Count > 8);
			this.RefreshTokenDetailLayout(sortedBuffEntryList);
			base.SetUiActive(true);
		}

		// Token: 0x06035836 RID: 219190 RVA: 0x00D6F572 File Offset: 0x00D6D772
		private void OnBtnDetailClick()
		{
			RogueArchiveInfoData currentArchiveInfoData = this.CurrentArchiveInfoData;
			if (((currentArchiveInfoData != null) ? currentArchiveInfoData.RoguelikeInfo : null) == null)
			{
				return;
			}
			ControllerBase<RoguelikeController>.Instance.OpenRogueInfoView(this.CurrentArchiveInfoData.RoguelikeInfo, false, false, ERogueInfoViewPage.Token);
		}

		// Token: 0x06035837 RID: 219191 RVA: 0x00D6F5A1 File Offset: 0x00D6D7A1
		private RoguelikeAchieveSmallTokenGrid CreateTokenDetailGrid()
		{
			return new RoguelikeAchieveSmallTokenGrid();
		}

		// Token: 0x06035838 RID: 219192 RVA: 0x00D6F5A8 File Offset: 0x00D6D7A8
		private void RefreshTokenDetailLayout(List<RogueGainEntry> dataList)
		{
			GenericLayout<RoguelikeAchieveSmallTokenGrid, RogueGainEntry> tokenDetailLayout = this.TokenDetailLayout;
			if (tokenDetailLayout == null)
			{
				return;
			}
			tokenDetailLayout.RefreshByData(dataList, null, false);
		}

		// Token: 0x06035839 RID: 219193 RVA: 0x00D6F5BD File Offset: 0x00D6D7BD
		private List<RogueGainEntry> GetSortedBuffEntryList(List<RogueGainEntry> dataList)
		{
			List<RogueGainEntry> list = new List<RogueGainEntry>(dataList);
			list.Sort(new Comparison<RogueGainEntry>(this.SortBuffEntry));
			return list;
		}

		// Token: 0x0603583A RID: 219194 RVA: 0x00D6F5D8 File Offset: 0x00D6D7D8
		private int SortBuffEntry(RogueGainEntry a, RogueGainEntry b)
		{
			RoguelikeConfig instance = ConfigBase<RoguelikeConfig>.Instance;
			int? num;
			if (instance == null)
			{
				num = null;
			}
			else
			{
				RogueBuffPool? rogueBuffConfig = instance.GetRogueBuffConfig(a.ConfigId);
				num = ((rogueBuffConfig != null) ? new int?(rogueBuffConfig.GetValueOrDefault().Quality) : null);
			}
			int? num2 = num;
			RoguelikeConfig instance2 = ConfigBase<RoguelikeConfig>.Instance;
			int? num3;
			if (instance2 == null)
			{
				num3 = null;
			}
			else
			{
				RogueBuffPool? rogueBuffConfig = instance2.GetRogueBuffConfig(b.ConfigId);
				num3 = ((rogueBuffConfig != null) ? new int?(rogueBuffConfig.GetValueOrDefault().Quality) : null);
			}
			int? num4 = num3;
			if (num2 == null || num4 == null)
			{
				return 0;
			}
			return num4.Value - num2.Value;
		}

		// Token: 0x0401EC0A RID: 125962
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<RoguelikeAchieveSmallTokenGrid, RogueGainEntry> TokenDetailLayout;

		// Token: 0x0401EC0B RID: 125963
		[Nullable(2)]
		private RogueArchiveInfoData CurrentArchiveInfoData;

		// Token: 0x0401EC0C RID: 125964
		[Nullable(2)]
		private RoguelikeAchieveViewModel Vm;

		// Token: 0x0200B0D0 RID: 45264
		[NullableContext(0)]
		private class ERoguelikeAchieveTokenPanelComponents
		{
			// Token: 0x04036D9A RID: 224666
			public const int TokenPanel = 0;

			// Token: 0x04036D9B RID: 224667
			public const int BtnDetail = 1;

			// Token: 0x04036D9C RID: 224668
			public const int TxtValue = 2;

			// Token: 0x04036D9D RID: 224669
			public const int BuffLayout = 3;

			// Token: 0x04036D9E RID: 224670
			public const int TokenDetailGridItem = 4;

			// Token: 0x04036D9F RID: 224671
			public const int PnlMore = 5;
		}
	}
}
