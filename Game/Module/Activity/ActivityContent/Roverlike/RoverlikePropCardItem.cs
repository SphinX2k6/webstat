using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x020063DF RID: 25567
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RoverlikePropCardItem : RoverlikeMultiUseGridProxyAbstract<IRoverlikePropItemData>
	{
		// Token: 0x0604033F RID: 262975 RVA: 0x0107439A File Offset: 0x0107259A
		public void BindOnItemSelect(Action<IRoverlikePropItemData> callback)
		{
			this.OnItemSelect = callback;
		}

		// Token: 0x06040340 RID: 262976 RVA: 0x010743A4 File Offset: 0x010725A4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 10;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnTogItemStateChanged));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06040341 RID: 262977 RVA: 0x01074554 File Offset: 0x01072754
		protected override void OnStart()
		{
			ITermExplanationRegistryParam param = new TermExplanationRegistryParam
			{
				UiText = base.GetText(3),
				ViewType = ETermExplanationViewType.Center,
				ReportType = ETermExplanationReportType.Roverlike
			};
			ControllerBase<TermExplanationController>.Instance.RegisterTextHyperlinkByParam(param);
			base.GetExtendToggle(0).SetSelfInteractive(false);
		}

		// Token: 0x06040342 RID: 262978 RVA: 0x0107459C File Offset: 0x0107279C
		public override void Refresh(IRoverlikePropItemData data, bool isSelected, int gridIndex)
		{
			this.CurrentData = data;
			RoverRogueItem? itemConfig = ConfigBase<RoverlikeConfig>.Instance.GetItemConfig(data.ConfigId);
			if (itemConfig == null)
			{
				return;
			}
			RoverRogueQuality? qualityConfig = ConfigBase<RoverlikeConfig>.Instance.GetQualityConfig(itemConfig.Value.Quality);
			if (qualityConfig == null)
			{
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), itemConfig.Value.Name, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), itemConfig.Value.Desc, itemConfig.Value.DescParams());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), "RoverRogue_ItemDurationOutGame", new <>z__ReadOnlySingleElementList<object>(itemConfig.Value.RoomPassedRequired));
			base.SetTextureShowUntilLoaded(itemConfig.Value.Icon, base.GetTexture(2), null);
			base.SetTextureByPath(qualityConfig.Value.ItemCard, base.GetTexture(1), null, null);
			if (data.IsInGame)
			{
				this.RefreshInGameMode(data);
				return;
			}
			this.RefreshOutGameMode();
		}

		// Token: 0x06040343 RID: 262979 RVA: 0x010746CC File Offset: 0x010728CC
		public override void OnSelected(bool fireEvent)
		{
			base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_Checked, false, false, false);
		}

		// Token: 0x06040344 RID: 262980 RVA: 0x010746DF File Offset: 0x010728DF
		public override void OnDeselected(bool fireEvent)
		{
			base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		}

		// Token: 0x06040345 RID: 262981 RVA: 0x010746F2 File Offset: 0x010728F2
		private void RefreshOutGameMode()
		{
			base.GetItem(7).SetUIActive(true);
			base.GetItem(8).SetUIActive(false);
			base.GetItem(9).SetUIActive(false);
		}

		// Token: 0x06040346 RID: 262982 RVA: 0x0107471C File Offset: 0x0107291C
		private void RefreshInGameMode(IRoverlikePropItemData data)
		{
			base.GetItem(7).SetUIActive(false);
			RoverlikeInstanceData instanceData = ModelBase<RoverlikeModel>.Instance.InstanceData;
			RoverlikeGainEntry roverlikeGainEntry = (instanceData != null) ? instanceData.GetGainByIncId(data.IncId.GetValueOrDefault()) : null;
			int num = (roverlikeGainEntry != null) ? roverlikeGainEntry.ItemRemainingRooms : 0;
			bool flag = num <= 0;
			base.GetItem(8).SetUIActive(!flag);
			base.GetItem(9).SetUIActive(flag);
			if (!flag)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), "RoverRogue_ItemDurationInGame", new <>z__ReadOnlySingleElementList<object>(num));
			}
		}

		// Token: 0x06040347 RID: 262983 RVA: 0x010747B1 File Offset: 0x010729B1
		private void OnTogItemStateChanged(EToggleState state)
		{
			if (state == EToggleState.ETT_Checked && this.CurrentData != null)
			{
				Action<IRoverlikePropItemData> onItemSelect = this.OnItemSelect;
				if (onItemSelect == null)
				{
					return;
				}
				onItemSelect(this.CurrentData);
			}
		}

		// Token: 0x0402401A RID: 147482
		[Nullable(2)]
		private IRoverlikePropItemData CurrentData;

		// Token: 0x0402401B RID: 147483
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Action<IRoverlikePropItemData> OnItemSelect;

		// Token: 0x0200C445 RID: 50245
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403C6B0 RID: 247472
			public const int TogItem = 0;

			// Token: 0x0403C6B1 RID: 247473
			public const int TexQualityBg = 1;

			// Token: 0x0403C6B2 RID: 247474
			public const int TexItemIcon = 2;

			// Token: 0x0403C6B3 RID: 247475
			public const int TxtInfo = 3;

			// Token: 0x0403C6B4 RID: 247476
			public const int TxtName = 4;

			// Token: 0x0403C6B5 RID: 247477
			public const int TxtTipsOutGame = 5;

			// Token: 0x0403C6B6 RID: 247478
			public const int TxtTipsRemainRound = 6;

			// Token: 0x0403C6B7 RID: 247479
			public const int PanelOutGame = 7;

			// Token: 0x0403C6B8 RID: 247480
			public const int PanelTipsActive = 8;

			// Token: 0x0403C6B9 RID: 247481
			public const int PanelTipsExpired = 9;
		}
	}
}
