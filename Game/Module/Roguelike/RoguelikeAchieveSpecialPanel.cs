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
	// Token: 0x0200512D RID: 20781
	[NullableContext(1)]
	[Nullable(0)]
	public class RoguelikeAchieveSpecialPanel : UiPanelBase
	{
		// Token: 0x06035805 RID: 219141 RVA: 0x00D6E780 File Offset: 0x00D6C980
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
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
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnBtnDetailClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06035806 RID: 219142 RVA: 0x00D6E88C File Offset: 0x00D6CA8C
		protected override void OnStart()
		{
			this.SpecialItemLayout = new GenericLayout<RoguelikeAchieveSpecialItem, IRoguelikeAchieveTokenItemData>(base.GetHorizontalLayout(3), new Func<RoguelikeAchieveSpecialItem>(this.CreateTokenItem), base.GetItem(4).GetOwner() as AUIBaseActor, false, true);
			base.SetUiActive(false);
			UUIButtonComponent button = base.GetButton(0);
			if (button != null)
			{
				button.SetSelfInteractive(false);
			}
			this.RefreshSpecialItemLayout(new List<IRoguelikeAchieveTokenItemData>());
		}

		// Token: 0x06035807 RID: 219143 RVA: 0x00D6E8EF File Offset: 0x00D6CAEF
		protected override void OnBeforeDestroy()
		{
			this.SpecialItemLayout = null;
			this.CurrentArchiveInfoData = null;
			this.Vm = null;
		}

		// Token: 0x06035808 RID: 219144 RVA: 0x00D6E906 File Offset: 0x00D6CB06
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

		// Token: 0x06035809 RID: 219145 RVA: 0x00D6E92C File Offset: 0x00D6CB2C
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
			List<IRoguelikeAchieveTokenItemData> specialItemDataList = this.GetSpecialItemDataList(roguelikeInfo.SpecialEntryList);
			base.SetUiActive(true);
			UUIButtonComponent button = base.GetButton(0);
			if (button != null)
			{
				button.SetSelfInteractive(this.Vm != null);
			}
			base.GetText(2).SetText(specialItemDataList.Count.ToString(), true);
			this.RefreshSpecialItemLayout(specialItemDataList);
		}

		// Token: 0x0603580A RID: 219146 RVA: 0x00D6E9B1 File Offset: 0x00D6CBB1
		private void OnBtnDetailClick()
		{
			RogueArchiveInfoData currentArchiveInfoData = this.CurrentArchiveInfoData;
			if (((currentArchiveInfoData != null) ? currentArchiveInfoData.RoguelikeInfo : null) == null)
			{
				return;
			}
			ControllerBase<RoguelikeController>.Instance.OpenRogueInfoView(this.CurrentArchiveInfoData.RoguelikeInfo, false, false, ERogueInfoViewPage.Special);
		}

		// Token: 0x0603580B RID: 219147 RVA: 0x00D6E9E0 File Offset: 0x00D6CBE0
		private RoguelikeAchieveSpecialItem CreateTokenItem()
		{
			return new RoguelikeAchieveSpecialItem();
		}

		// Token: 0x0603580C RID: 219148 RVA: 0x00D6E9E7 File Offset: 0x00D6CBE7
		private void RefreshSpecialItemLayout(List<IRoguelikeAchieveTokenItemData> dataList)
		{
			GenericLayout<RoguelikeAchieveSpecialItem, IRoguelikeAchieveTokenItemData> specialItemLayout = this.SpecialItemLayout;
			if (specialItemLayout == null)
			{
				return;
			}
			specialItemLayout.RefreshByData(dataList, null, false);
		}

		// Token: 0x0603580D RID: 219149 RVA: 0x00D6E9FC File Offset: 0x00D6CBFC
		private List<IRoguelikeAchieveTokenItemData> GetSpecialItemDataList(List<RogueGainEntry> specialEntryList)
		{
			List<IRoguelikeAchieveTokenItemData> list = new List<IRoguelikeAchieveTokenItemData>();
			foreach (RogueGainEntry gainEntry in specialEntryList)
			{
				list.Add(new RoguelikeAchieveTokenItemData
				{
					GainEntry = gainEntry
				});
			}
			list.Sort(new Comparison<IRoguelikeAchieveTokenItemData>(this.SortSpecialItem));
			return list;
		}

		// Token: 0x0603580E RID: 219150 RVA: 0x00D6EA70 File Offset: 0x00D6CC70
		private int SortSpecialItem(IRoguelikeAchieveTokenItemData a, IRoguelikeAchieveTokenItemData b)
		{
			RoguelikeConfig instance = ConfigBase<RoguelikeConfig>.Instance;
			RougeMiraclecreation? rougeMiraclecreation = (instance != null) ? instance.GetRoguelikeSpecialConfig(a.GainEntry.ConfigId) : null;
			RoguelikeConfig instance2 = ConfigBase<RoguelikeConfig>.Instance;
			RougeMiraclecreation? rougeMiraclecreation2 = (instance2 != null) ? instance2.GetRoguelikeSpecialConfig(b.GainEntry.ConfigId) : null;
			RougeMiraclecreationColor? rougeMiraclecreationColor = (rougeMiraclecreation != null) ? ConfigBase<RoguelikeConfig>.Instance.GetRoguelikeMiraclecreationColorConfig(rougeMiraclecreation.Value.ColorType) : null;
			RougeMiraclecreationColor? rougeMiraclecreationColor2 = (rougeMiraclecreation2 != null) ? ConfigBase<RoguelikeConfig>.Instance.GetRoguelikeMiraclecreationColorConfig(rougeMiraclecreation2.Value.ColorType) : null;
			int num = (rougeMiraclecreationColor != null) ? rougeMiraclecreationColor.GetValueOrDefault().Sort : 0;
			return ((rougeMiraclecreationColor2 != null) ? rougeMiraclecreationColor2.GetValueOrDefault().Sort : 0) - num;
		}

		// Token: 0x0401EC04 RID: 125956
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<RoguelikeAchieveSpecialItem, IRoguelikeAchieveTokenItemData> SpecialItemLayout;

		// Token: 0x0401EC05 RID: 125957
		[Nullable(2)]
		private RogueArchiveInfoData CurrentArchiveInfoData;

		// Token: 0x0401EC06 RID: 125958
		[Nullable(2)]
		private RoguelikeAchieveViewModel Vm;

		// Token: 0x0200B0CC RID: 45260
		[NullableContext(0)]
		private class ERoguelikeAchieveSpecialPanelComponents
		{
			// Token: 0x04036D89 RID: 224649
			public const int SpecialPanel = 0;

			// Token: 0x04036D8A RID: 224650
			public const int BtnDetail = 1;

			// Token: 0x04036D8B RID: 224651
			public const int TxtValue = 2;

			// Token: 0x04036D8C RID: 224652
			public const int TokenLayout = 3;

			// Token: 0x04036D8D RID: 224653
			public const int TokenItem = 4;
		}
	}
}
