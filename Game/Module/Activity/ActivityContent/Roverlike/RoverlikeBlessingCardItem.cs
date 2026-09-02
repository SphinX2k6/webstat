using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x020063DC RID: 25564
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RoverlikeBlessingCardItem : RoverlikeMultiUseGridProxyAbstract<IRoverlikeBlessingItemData>
	{
		// Token: 0x0604031C RID: 262940 RVA: 0x010739D5 File Offset: 0x01071BD5
		[NullableContext(1)]
		public void BindOnItemSelect(Action<IRoverlikeBlessingItemData> callback)
		{
			this.OnItemSelect = callback;
		}

		// Token: 0x0604031D RID: 262941 RVA: 0x010739DE File Offset: 0x01071BDE
		public UUIItem GetGuideUiItem()
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(6);
			if (extendToggle == null)
			{
				return null;
			}
			return extendToggle.GetRootComponent();
		}

		// Token: 0x0604031E RID: 262942 RVA: 0x010739F4 File Offset: 0x01071BF4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 21;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(18, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(19, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(20, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(6, new Action<EToggleState>(this.OnTogItemStateChanged));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0604031F RID: 262943 RVA: 0x01073D1C File Offset: 0x01071F1C
		protected override void OnStart()
		{
			this.RepresentativeItem = new RoverlikeBlessingRepresentativeItem();
			this.RepresentativeItem.CreateThenShowByActor(base.GetItem(7).GetOwner(), null);
			this.RepresentativeChangeItem = new RoverlikeBlessingRepresentativeItem();
			this.RepresentativeChangeItem.CreateThenShowByActor(base.GetItem(9).GetOwner(), null);
			UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar = base.GetScrollViewWithScrollbar(18);
			if (scrollViewWithScrollbar != null)
			{
				scrollViewWithScrollbar.OnScrollValueChange.Bind(delegate(FVector2D _)
				{
					this.RefreshScrollArrow();
				});
			}
			UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar2 = base.GetScrollViewWithScrollbar(18);
			if (scrollViewWithScrollbar2 != null)
			{
				scrollViewWithScrollbar2.OnLateUpdate.Bind(new Action<float>(this.OnScrollLateUpdate));
			}
			ITermExplanationRegistryParam param = new TermExplanationRegistryParam
			{
				UiText = base.GetText(1),
				ViewType = ETermExplanationViewType.Center,
				ReportType = ETermExplanationReportType.Roverlike
			};
			ControllerBase<TermExplanationController>.Instance.RegisterTextHyperlinkByParam(param);
		}

		// Token: 0x06040320 RID: 262944 RVA: 0x01073DE6 File Offset: 0x01071FE6
		protected override void OnBeforeDestroy()
		{
			UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar = base.GetScrollViewWithScrollbar(18);
			if (scrollViewWithScrollbar == null)
			{
				return;
			}
			scrollViewWithScrollbar.OnScrollValueChange.Unbind();
		}

		// Token: 0x06040321 RID: 262945 RVA: 0x01073E00 File Offset: 0x01072000
		[NullableContext(1)]
		public override void Refresh(IRoverlikeBlessingItemData data, bool isSelected, int gridIndex)
		{
			this.CurrentData = data;
			this.HasScrollFirstLateUpdate = false;
			RoverRogueBless? blessConfig = ConfigBase<RoverlikeConfig>.Instance.GetBlessConfig(data.BlessId);
			if (blessConfig == null)
			{
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), blessConfig.Value.Name, Array.Empty<object>());
			this.SetSpriteByPath(blessConfig.Value.Icon, base.GetSprite(3), false, null, null);
			this.RefreshDescMode();
			bool flag = !StringUtils.IsEmpty(blessConfig.Value.AdditionText);
			if (flag)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), blessConfig.Value.AdditionText, blessConfig.Value.AdditionParams());
			}
			base.GetItem(16).SetUIActive(flag);
			this.RefreshQuality(blessConfig.Value.Quality);
			bool uiactive = data.ShowRecommend.GetValueOrDefault(true) && blessConfig.Value.IsRecommend;
			base.GetItem(17).SetUIActive(uiactive);
			base.GetItem(10).SetUIActive(data.IsUp.GetValueOrDefault());
			RoverlikeBlessingRepresentativeItem representativeItem = this.RepresentativeItem;
			if (representativeItem != null)
			{
				representativeItem.Refresh(blessConfig.Value.BlessRoleId);
			}
			this.RefreshChangeSlot(data);
			base.GetExtendToggle(6).SetToggleState(isSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
			bool valueOrDefault = data.AllowToggleInteract.GetValueOrDefault(true);
			base.GetExtendToggle(6).SetSelfInteractive(valueOrDefault);
			UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar = base.GetScrollViewWithScrollbar(18);
			if (scrollViewWithScrollbar != null)
			{
				scrollViewWithScrollbar.RootUIComp.Get().SetBubbleUpToParent(valueOrDefault);
			}
			this.RefreshScrollArrow();
		}

		// Token: 0x06040322 RID: 262946 RVA: 0x01073FD4 File Offset: 0x010721D4
		public void RefreshDescMode()
		{
			if (this.CurrentData == null)
			{
				return;
			}
			RoverRogueBless? blessConfig = ConfigBase<RoverlikeConfig>.Instance.GetBlessConfig(this.CurrentData.BlessId);
			if (blessConfig == null)
			{
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), blessConfig.Value.Desc, blessConfig.Value.Params());
		}

		// Token: 0x06040323 RID: 262947 RVA: 0x01074039 File Offset: 0x01072239
		public override void OnSelected(bool fireEvent)
		{
			base.GetExtendToggle(6).SetToggleState(EToggleState.ETT_Checked, fireEvent, false, false);
		}

		// Token: 0x06040324 RID: 262948 RVA: 0x0107404C File Offset: 0x0107224C
		public override void OnDeselected(bool fireEvent)
		{
			base.GetExtendToggle(6).SetToggleState(EToggleState.ETT_UnChecked, fireEvent, false, false);
		}

		// Token: 0x06040325 RID: 262949 RVA: 0x01074060 File Offset: 0x01072260
		private void RefreshQuality(int quality)
		{
			RoverRogueQuality? qualityConfig = ConfigBase<RoverlikeConfig>.Instance.GetQualityConfig(quality);
			if (qualityConfig != null)
			{
				base.GetTexture(0).SetColor(FColor.FromHex(qualityConfig.Value.BlessCardTop));
				base.GetTexture(2).SetColor(FColor.FromHex(qualityConfig.Value.BlessCardTheme));
			}
			base.GetItem(11).SetUIActive(quality <= 3);
			base.GetItem(12).SetUIActive(quality == 4);
			base.GetItem(13).SetUIActive(quality == 5);
			base.GetItem(14).SetUIActive(quality == 6);
			base.GetItem(15).SetUIActive(quality == 6);
		}

		// Token: 0x06040326 RID: 262950 RVA: 0x0107411C File Offset: 0x0107231C
		[NullableContext(1)]
		private void RefreshChangeSlot(IRoverlikeBlessingItemData data)
		{
			bool uiactive = false;
			if (data.CheckSameSlot.GetValueOrDefault())
			{
				RoverlikeInstanceData instanceData = ModelBase<RoverlikeModel>.Instance.InstanceData;
				RoverlikeGainEntry roverlikeGainEntry = (instanceData != null) ? instanceData.GetSameSlotIdBless(data.BlessId) : null;
				if (roverlikeGainEntry != null)
				{
					RoverRogueBless? blessConfig = ConfigBase<RoverlikeConfig>.Instance.GetBlessConfig(roverlikeGainEntry.ConfigId);
					if (blessConfig != null)
					{
						RoverlikeBlessingRepresentativeItem representativeChangeItem = this.RepresentativeChangeItem;
						if (representativeChangeItem != null)
						{
							representativeChangeItem.Refresh(blessConfig.Value.BlessRoleId);
						}
						uiactive = true;
					}
				}
			}
			base.GetItem(8).SetUIActive(uiactive);
		}

		// Token: 0x06040327 RID: 262951 RVA: 0x010741A5 File Offset: 0x010723A5
		private void OnScrollLateUpdate(float _)
		{
			if (!this.HasScrollFirstLateUpdate)
			{
				this.RefreshScrollArrow();
				this.HasScrollFirstLateUpdate = true;
			}
		}

		// Token: 0x06040328 RID: 262952 RVA: 0x010741BC File Offset: 0x010723BC
		private void RefreshScrollArrow()
		{
			UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar = base.GetScrollViewWithScrollbar(18);
			UUIText text = base.GetText(1);
			if (scrollViewWithScrollbar == null || text == null)
			{
				base.GetItem(19).SetUIActive(false);
				base.GetItem(20).SetUIActive(false);
				return;
			}
			EOutOfBoundsType eoutOfBoundsType = EOutOfBoundsType.EOutOfBoundsType_MAX;
			EOutOfBoundsType eoutOfBoundsType2 = EOutOfBoundsType.EOutOfBoundsType_MAX;
			scrollViewWithScrollbar.GetOutOfBottomBoundsType(text, ref eoutOfBoundsType, ref eoutOfBoundsType2, 0f);
			EOutOfBoundsType eoutOfBoundsType3 = eoutOfBoundsType;
			base.GetItem(19).SetUIActive(eoutOfBoundsType3 == EOutOfBoundsType.OutOfBegin);
			base.GetItem(20).SetUIActive(eoutOfBoundsType3 == EOutOfBoundsType.OutOfEnd);
		}

		// Token: 0x06040329 RID: 262953 RVA: 0x01074238 File Offset: 0x01072438
		private void OnTogItemStateChanged(EToggleState state)
		{
			if (state == EToggleState.ETT_Checked && this.CurrentData != null)
			{
				Action<IRoverlikeBlessingItemData> onItemSelect = this.OnItemSelect;
				if (onItemSelect == null)
				{
					return;
				}
				onItemSelect(this.CurrentData);
			}
		}

		// Token: 0x04024012 RID: 147474
		private IRoverlikeBlessingItemData CurrentData;

		// Token: 0x04024013 RID: 147475
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Action<IRoverlikeBlessingItemData> OnItemSelect;

		// Token: 0x04024014 RID: 147476
		private RoverlikeBlessingRepresentativeItem RepresentativeItem;

		// Token: 0x04024015 RID: 147477
		private RoverlikeBlessingRepresentativeItem RepresentativeChangeItem;

		// Token: 0x04024016 RID: 147478
		private bool HasScrollFirstLateUpdate;

		// Token: 0x0200C443 RID: 50243
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403C69A RID: 247450
			public const int TexCardBg = 0;

			// Token: 0x0403C69B RID: 247451
			public const int TxtInfo = 1;

			// Token: 0x0403C69C RID: 247452
			public const int TexQualityBg = 2;

			// Token: 0x0403C69D RID: 247453
			public const int SpriteIcon = 3;

			// Token: 0x0403C69E RID: 247454
			public const int TxtName = 4;

			// Token: 0x0403C69F RID: 247455
			public const int TxtTips = 5;

			// Token: 0x0403C6A0 RID: 247456
			public const int TogItem = 6;

			// Token: 0x0403C6A1 RID: 247457
			public const int ItemRepresentative = 7;

			// Token: 0x0403C6A2 RID: 247458
			public const int PanelExchange = 8;

			// Token: 0x0403C6A3 RID: 247459
			public const int ItemRepresentativeChange = 9;

			// Token: 0x0403C6A4 RID: 247460
			public const int ItemUp = 10;

			// Token: 0x0403C6A5 RID: 247461
			public const int PanelQualityBlue = 11;

			// Token: 0x0403C6A6 RID: 247462
			public const int PanelQualityPurple = 12;

			// Token: 0x0403C6A7 RID: 247463
			public const int PanelQualityGold = 13;

			// Token: 0x0403C6A8 RID: 247464
			public const int PanelQualityRed = 14;

			// Token: 0x0403C6A9 RID: 247465
			public const int ItemHighQualityEffect = 15;

			// Token: 0x0403C6AA RID: 247466
			public const int PanelAttribute = 16;

			// Token: 0x0403C6AB RID: 247467
			public const int PanelRecommend = 17;

			// Token: 0x0403C6AC RID: 247468
			public const int SvInfo = 18;

			// Token: 0x0403C6AD RID: 247469
			public const int ItemArrowUp = 19;

			// Token: 0x0403C6AE RID: 247470
			public const int ItemArrowDown = 20;
		}
	}
}
