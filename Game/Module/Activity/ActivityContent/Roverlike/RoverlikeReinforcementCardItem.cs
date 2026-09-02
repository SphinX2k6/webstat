using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x020063E0 RID: 25568
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RoverlikeReinforcementCardItem : RoverlikeMultiUseGridProxyAbstract<IRoverlikeReinforcementItemData>
	{
		// Token: 0x06040349 RID: 262985 RVA: 0x010747DD File Offset: 0x010729DD
		public void BindOnItemSelect(Action<IRoverlikeReinforcementItemData> callback)
		{
			this.OnItemSelect = callback;
		}

		// Token: 0x0604034A RID: 262986 RVA: 0x010747E6 File Offset: 0x010729E6
		[NullableContext(2)]
		public UUIItem GetGuideUiItem()
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle == null)
			{
				return null;
			}
			return extendToggle.GetRootComponent();
		}

		// Token: 0x0604034B RID: 262987 RVA: 0x010747FC File Offset: 0x010729FC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 9;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnTogItemStateChanged));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0604034C RID: 262988 RVA: 0x0107498C File Offset: 0x01072B8C
		protected override void OnStart()
		{
			UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar = base.GetScrollViewWithScrollbar(6);
			if (scrollViewWithScrollbar != null)
			{
				scrollViewWithScrollbar.OnScrollValueChange.Bind(delegate(FVector2D _)
				{
					this.RefreshScrollArrow();
				});
			}
			UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar2 = base.GetScrollViewWithScrollbar(6);
			if (scrollViewWithScrollbar2 != null)
			{
				scrollViewWithScrollbar2.OnLateUpdate.Bind(new Action<float>(this.OnScrollLateUpdate));
			}
			ITermExplanationRegistryParam param = new TermExplanationRegistryParam
			{
				UiText = base.GetText(2),
				ViewType = ETermExplanationViewType.Center,
				ReportType = ETermExplanationReportType.Roverlike
			};
			ControllerBase<TermExplanationController>.Instance.RegisterTextHyperlinkByParam(param);
		}

		// Token: 0x0604034D RID: 262989 RVA: 0x01074A0D File Offset: 0x01072C0D
		protected override void OnBeforeCreate()
		{
			UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar = base.GetScrollViewWithScrollbar(6);
			if (scrollViewWithScrollbar == null)
			{
				return;
			}
			scrollViewWithScrollbar.OnScrollValueChange.Unbind();
		}

		// Token: 0x0604034E RID: 262990 RVA: 0x01074A28 File Offset: 0x01072C28
		public override void Refresh(IRoverlikeReinforcementItemData data, bool isSelected, int gridIndex)
		{
			this.CurrentData = data;
			this.HasScrollFirstLateUpdate = false;
			RoverRogueRoleEnhance? roleEnhanceConfig = ConfigBase<RoverlikeConfig>.Instance.GetRoleEnhanceConfig(data.ConfigId);
			if (roleEnhanceConfig == null)
			{
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), roleEnhanceConfig.Value.Name, Array.Empty<object>());
			this.SetSpriteByPath(roleEnhanceConfig.Value.Icon, base.GetSprite(3), false, null, null);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), roleEnhanceConfig.Value.Desc, roleEnhanceConfig.Value.DescParams());
			bool flag = !StringUtils.IsEmpty(roleEnhanceConfig.Value.AdditionText);
			if (flag)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), roleEnhanceConfig.Value.AdditionText, roleEnhanceConfig.Value.AdditionParams());
			}
			base.GetText(4).SetUIActive(flag);
			base.GetItem(5).SetUIActive(roleEnhanceConfig.Value.IsRecommend);
			base.GetExtendToggle(0).SetToggleState(isSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
			base.GetExtendToggle(0).SetSelfInteractive(data.AllowToggleInteract.GetValueOrDefault(true));
			this.RefreshScrollArrow();
		}

		// Token: 0x0604034F RID: 262991 RVA: 0x01074B84 File Offset: 0x01072D84
		public override void OnSelected(bool fireEvent)
		{
			base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_Checked, false, false, false);
		}

		// Token: 0x06040350 RID: 262992 RVA: 0x01074B97 File Offset: 0x01072D97
		public override void OnDeselected(bool fireEvent)
		{
			base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		}

		// Token: 0x06040351 RID: 262993 RVA: 0x01074BAA File Offset: 0x01072DAA
		private void OnScrollLateUpdate(float _)
		{
			if (!this.HasScrollFirstLateUpdate)
			{
				this.RefreshScrollArrow();
				this.HasScrollFirstLateUpdate = true;
			}
		}

		// Token: 0x06040352 RID: 262994 RVA: 0x01074BC4 File Offset: 0x01072DC4
		private void RefreshScrollArrow()
		{
			UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar = base.GetScrollViewWithScrollbar(6);
			UUIText text = base.GetText(2);
			if (scrollViewWithScrollbar == null || text == null)
			{
				base.GetItem(7).SetUIActive(false);
				base.GetItem(8).SetUIActive(false);
				return;
			}
			EOutOfBoundsType eoutOfBoundsType = EOutOfBoundsType.EOutOfBoundsType_MAX;
			EOutOfBoundsType eoutOfBoundsType2 = EOutOfBoundsType.EOutOfBoundsType_MAX;
			scrollViewWithScrollbar.GetOutOfBottomBoundsType(text, ref eoutOfBoundsType, ref eoutOfBoundsType2, 0f);
			EOutOfBoundsType eoutOfBoundsType3 = eoutOfBoundsType;
			base.GetItem(7).SetUIActive(eoutOfBoundsType3 == EOutOfBoundsType.OutOfBegin);
			base.GetItem(8).SetUIActive(eoutOfBoundsType3 == EOutOfBoundsType.OutOfEnd);
		}

		// Token: 0x06040353 RID: 262995 RVA: 0x01074C3B File Offset: 0x01072E3B
		private void OnTogItemStateChanged(EToggleState state)
		{
			if (state == EToggleState.ETT_Checked && this.CurrentData != null)
			{
				Action<IRoverlikeReinforcementItemData> onItemSelect = this.OnItemSelect;
				if (onItemSelect == null)
				{
					return;
				}
				onItemSelect(this.CurrentData);
			}
		}

		// Token: 0x0402401C RID: 147484
		[Nullable(2)]
		private IRoverlikeReinforcementItemData CurrentData;

		// Token: 0x0402401D RID: 147485
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Action<IRoverlikeReinforcementItemData> OnItemSelect;

		// Token: 0x0402401E RID: 147486
		private bool HasScrollFirstLateUpdate;

		// Token: 0x0200C446 RID: 50246
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403C6BA RID: 247482
			public const int TogItem = 0;

			// Token: 0x0403C6BB RID: 247483
			public const int TxtName = 1;

			// Token: 0x0403C6BC RID: 247484
			public const int TxtInfo = 2;

			// Token: 0x0403C6BD RID: 247485
			public const int SpriteIcon = 3;

			// Token: 0x0403C6BE RID: 247486
			public const int TxtTips = 4;

			// Token: 0x0403C6BF RID: 247487
			public const int PnlRecommend = 5;

			// Token: 0x0403C6C0 RID: 247488
			public const int SvInfo = 6;

			// Token: 0x0403C6C1 RID: 247489
			public const int SprArrowUp = 7;

			// Token: 0x0403C6C2 RID: 247490
			public const int SprArrowDown = 8;
		}
	}
}
