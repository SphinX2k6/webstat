using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x02006445 RID: 25669
	[NullableContext(2)]
	[Nullable(0)]
	public class RoverlikeRoleSelectView : UiViewBase
	{
		// Token: 0x17009DF9 RID: 40441
		// (get) Token: 0x060406DE RID: 263902 RVA: 0x0108469D File Offset: 0x0108289D
		private RoverlikeActivityData ActivityData
		{
			get
			{
				return ControllerBase<RoverlikeActivityController>.Instance.GetCurrentActivityData();
			}
		}

		// Token: 0x060406DF RID: 263903 RVA: 0x010846A9 File Offset: 0x010828A9
		[NullableContext(1)]
		public RoverlikeRoleSelectView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x060406E0 RID: 263904 RVA: 0x010846C8 File Offset: 0x010828C8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 16;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIGridLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIGridLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action<EToggleState>(this.OnLightToggleStateChange));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(2, new Action<EToggleState>(this.OnDarkToggleStateChange));
			this.BtnBindInfo = list2;
		}

		// Token: 0x060406E1 RID: 263905 RVA: 0x01084968 File Offset: 0x01082B68
		protected override UniTask OnBeforeStartAsync()
		{
			RoverlikeRoleSelectView.<OnBeforeStartAsync>d__20 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RoverlikeRoleSelectView.<OnBeforeStartAsync>d__20>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060406E2 RID: 263906 RVA: 0x010849AC File Offset: 0x01082BAC
		protected override void OnStart()
		{
			this.RoleTypeIdList.Clear();
			foreach (RoverRogueRoleType roverRogueRoleType in ConfigBase<RoverlikeConfig>.Instance.GetRoleTypeConfigList())
			{
				this.RoleTypeIdList.Add(roverRogueRoleType.Id);
			}
			RoverlikeRoleSelectViewOpenParam roverlikeRoleSelectViewOpenParam = this.OpenParam as RoverlikeRoleSelectViewOpenParam;
			this.CurInstId = ((roverlikeRoleSelectViewOpenParam != null) ? roverlikeRoleSelectViewOpenParam.InstId : 0);
			this.BuildSelectableRoleTypeSet();
			this.CaptionItem = new PopupCaptionItem(base.GetItem(0));
			this.CaptionItem.SetCloseCallBack(new Action(this.OnClickClose));
			this.ConfirmButton = new ButtonItem(base.GetButton(15).RootUIComp.Get());
			this.ConfirmButton.SetFunction(new Action<int>(this.OnClickConfirm));
			UUIExtendToggle extendToggle = base.GetExtendToggle(1);
			if (extendToggle != null)
			{
				extendToggle.CanExecuteChange.Bind(() => this.CurRoleTypeId != this.GetRoleTypeIdByIndex(0));
			}
			UUIExtendToggle extendToggle2 = base.GetExtendToggle(2);
			if (extendToggle2 != null)
			{
				extendToggle2.CanExecuteChange.Bind(() => this.CurRoleTypeId != this.GetRoleTypeIdByIndex(1));
			}
			this.BuildInfoLayout();
			this.BuildAssistRoleLayouts();
			this.RefreshRoleStand();
			this.SelectElement(this.GetDefaultRoleTypeId());
		}

		// Token: 0x060406E3 RID: 263907 RVA: 0x01084AFC File Offset: 0x01082CFC
		protected override void OnBeforeDestroy()
		{
			this.CaptionItem = null;
			this.ConfirmButton = null;
			this.TitlePanel = null;
			this.UnlockPanel = null;
			this.LightTogglePanel = null;
			this.DarkTogglePanel = null;
			this.InfoLayout = null;
			this.AssistLayoutL = null;
			this.AssistLayoutR = null;
		}

		// Token: 0x060406E4 RID: 263908 RVA: 0x01084B48 File Offset: 0x01082D48
		private void BuildInfoLayout()
		{
			UUILayoutBase layout = base.GetScrollViewWithScrollbar(8).GetContent().GetComponentByClass(UUILayoutBase.StaticClass()) as UUILayoutBase;
			this.InfoLayout = new GenericLayout<RoverlikeRoleSelectInfoItem, RoverlikeRoleSelectInfoItemData>(layout, () => new RoverlikeRoleSelectInfoItem(), base.GetItem(9).GetOwner() as AUIBaseActor, false, true);
		}

		// Token: 0x060406E5 RID: 263909 RVA: 0x01084BB8 File Offset: 0x01082DB8
		private void BuildAssistRoleLayouts()
		{
			this.AssistLayoutL = new GenericLayout<RoverlikeRoleSelectAssistRoleItem, RoverlikeRoleSelectAssistRoleItemData>(base.GetGridLayout(10), () => new RoverlikeRoleSelectAssistRoleItem(), base.GetItem(11).GetOwner() as AUIBaseActor, false, true);
			this.AssistLayoutR = new GenericLayout<RoverlikeRoleSelectAssistRoleItem, RoverlikeRoleSelectAssistRoleItemData>(base.GetGridLayout(12), () => new RoverlikeRoleSelectAssistRoleItem(), base.GetItem(13).GetOwner() as AUIBaseActor, false, true);
		}

		// Token: 0x060406E6 RID: 263910 RVA: 0x01084C54 File Offset: 0x01082E54
		private int GetDefaultRoleTypeId()
		{
			RoverlikeRoleSelectViewOpenParam roverlikeRoleSelectViewOpenParam = this.OpenParam as RoverlikeRoleSelectViewOpenParam;
			int num = (roverlikeRoleSelectViewOpenParam != null) ? roverlikeRoleSelectViewOpenParam.DefaultRoleTypeId : 0;
			if (num > 0 && this.RoleTypeIdList.Contains(num))
			{
				return num;
			}
			int lastPassRoleTypeId = ModelBase<RoverlikeModel>.Instance.GetLastPassRoleTypeId();
			if (lastPassRoleTypeId > 0 && this.RoleTypeIdList.Contains(lastPassRoleTypeId))
			{
				return lastPassRoleTypeId;
			}
			return this.GetRoleTypeIdByIndex(0);
		}

		// Token: 0x060406E7 RID: 263911 RVA: 0x01084CB3 File Offset: 0x01082EB3
		private int GetRoleTypeIdByIndex(int index)
		{
			if (index >= 0 && index < this.RoleTypeIdList.Count)
			{
				return this.RoleTypeIdList[index];
			}
			if (index != 0)
			{
				return 2;
			}
			return 1;
		}

		// Token: 0x060406E8 RID: 263912 RVA: 0x01084CDC File Offset: 0x01082EDC
		private void SelectElement(int roleTypeId)
		{
			this.CurRoleTypeId = roleTypeId;
			bool flag = roleTypeId == this.GetRoleTypeIdByIndex(0);
			UUIExtendToggle extendToggle = base.GetExtendToggle(1);
			if (extendToggle != null)
			{
				extendToggle.SetToggleStateForce(flag ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
			}
			UUIExtendToggle extendToggle2 = base.GetExtendToggle(2);
			if (extendToggle2 != null)
			{
				extendToggle2.SetToggleStateForce(flag ? EToggleState.ETT_UnChecked : EToggleState.ETT_Checked, false, false, false);
			}
			RoverRogueRoleType? roleTypeConfig = this.GetRoleTypeConfig(roleTypeId);
			this.RefreshEffect();
			RoverlikeRoleSelectTitlePanel titlePanel = this.TitlePanel;
			if (titlePanel != null)
			{
				titlePanel.RefreshElement(flag, roleTypeConfig);
			}
			this.RefreshInfoList(roleTypeConfig);
			this.RefreshAssistRoles(roleTypeId);
			this.RefreshUnlockState(roleTypeId, roleTypeConfig);
		}

		// Token: 0x060406E9 RID: 263913 RVA: 0x01084D6C File Offset: 0x01082F6C
		private void RefreshEffect()
		{
			int roleTypeIdByIndex = this.GetRoleTypeIdByIndex(0);
			int roleTypeIdByIndex2 = this.GetRoleTypeIdByIndex(1);
			bool flag = this.CurRoleTypeId == roleTypeIdByIndex;
			UUIItem item = base.GetItem(5);
			if (item != null)
			{
				item.SetUIActive(flag && this.IsRoleTypeSelectable(roleTypeIdByIndex));
			}
			UUIItem item2 = base.GetItem(6);
			if (item2 == null)
			{
				return;
			}
			item2.SetUIActive(!flag && this.IsRoleTypeSelectable(roleTypeIdByIndex2));
		}

		// Token: 0x060406EA RID: 263914 RVA: 0x01084DD0 File Offset: 0x01082FD0
		private void RefreshRoleStand()
		{
			bool flag = ModelBase<RoverlikeModel>.Instance.GetMainRoleId() == 5053002;
			UUIItem item = base.GetItem(3);
			if (item != null)
			{
				item.SetUIActive(flag);
			}
			UUIItem item2 = base.GetItem(4);
			if (item2 == null)
			{
				return;
			}
			item2.SetUIActive(!flag);
		}

		// Token: 0x060406EB RID: 263915 RVA: 0x01084E17 File Offset: 0x01083017
		private void RefreshInfoList(RoverRogueRoleType? cfg)
		{
			GenericLayout<RoverlikeRoleSelectInfoItem, RoverlikeRoleSelectInfoItemData> infoLayout = this.InfoLayout;
			if (infoLayout == null)
			{
				return;
			}
			infoLayout.RefreshByData(this.BuildInfoDataList(cfg), null, false);
		}

		// Token: 0x060406EC RID: 263916 RVA: 0x01084E34 File Offset: 0x01083034
		[NullableContext(1)]
		private List<RoverlikeRoleSelectInfoItemData> BuildInfoDataList(RoverRogueRoleType? cfg)
		{
			List<RoverlikeRoleSelectInfoItemData> list = new List<RoverlikeRoleSelectInfoItemData>();
			if (cfg == null)
			{
				return list;
			}
			int num = Math.Min(cfg.Value.SkillTitleListLength, cfg.Value.SkillDescListLength);
			for (int i = 0; i < num; i++)
			{
				list.Add(new RoverlikeRoleSelectInfoItemData
				{
					TitleTextId = (cfg.Value.SkillTitleList(i) ?? ""),
					DescTextId = (cfg.Value.SkillDescList(i) ?? "")
				});
			}
			return list;
		}

		// Token: 0x060406ED RID: 263917 RVA: 0x01084ECC File Offset: 0x010830CC
		private void RefreshAssistRoles(int roleTypeId)
		{
			RoverlikeActivityData activityData = this.ActivityData;
			int num = (activityData != null) ? activityData.Id : 0;
			IEnumerable<RoverRogueBlessRole> blessRoleConfigList = ConfigBase<RoverlikeConfig>.Instance.GetBlessRoleConfigList();
			List<RoverlikeRoleSelectAssistRoleItemData> list = new List<RoverlikeRoleSelectAssistRoleItemData>();
			List<RoverlikeRoleSelectAssistRoleItemData> list2 = new List<RoverlikeRoleSelectAssistRoleItemData>();
			foreach (RoverRogueBlessRole roverRogueBlessRole in blessRoleConfigList)
			{
				if (roverRogueBlessRole.Id != 13 && (num <= 0 || roverRogueBlessRole.ActivityId == num))
				{
					int enableRoleTypeLength = roverRogueBlessRole.EnableRoleTypeLength;
					bool flag = false;
					for (int i = 0; i < enableRoleTypeLength; i++)
					{
						if (roverRogueBlessRole.EnableRoleType(i) == roleTypeId)
						{
							flag = true;
							break;
						}
					}
					if (flag)
					{
						if (enableRoleTypeLength > 1)
						{
							list.Add(new RoverlikeRoleSelectAssistRoleItemData
							{
								BlessRoleId = roverRogueBlessRole.Id
							});
						}
						else
						{
							list2.Add(new RoverlikeRoleSelectAssistRoleItemData
							{
								BlessRoleId = roverRogueBlessRole.Id
							});
						}
					}
				}
			}
			GenericLayout<RoverlikeRoleSelectAssistRoleItem, RoverlikeRoleSelectAssistRoleItemData> assistLayoutL = this.AssistLayoutL;
			if (assistLayoutL != null)
			{
				assistLayoutL.RefreshByData(list, null, false);
			}
			GenericLayout<RoverlikeRoleSelectAssistRoleItem, RoverlikeRoleSelectAssistRoleItemData> assistLayoutR = this.AssistLayoutR;
			if (assistLayoutR == null)
			{
				return;
			}
			assistLayoutR.RefreshByData(list2, null, false);
		}

		// Token: 0x060406EE RID: 263918 RVA: 0x01084FE8 File Offset: 0x010831E8
		private void RefreshUnlockState(int roleTypeId, RoverRogueRoleType? cfg)
		{
			bool flag = this.IsRoleTypeSelectable(roleTypeId);
			RoverlikeRoleSelectUnlockPanel unlockPanel = this.UnlockPanel;
			if (unlockPanel != null)
			{
				unlockPanel.SetActive(!flag);
			}
			if (!flag)
			{
				RoverlikeActivityData activityData = this.ActivityData;
				bool flag2 = activityData != null && activityData.IsRoleTypeUnlocked(roleTypeId);
				RoverlikeRoleSelectUnlockPanel unlockPanel2 = this.UnlockPanel;
				if (unlockPanel2 != null)
				{
					unlockPanel2.RefreshUnlockDesc(flag2 ? "RoverRogue_ElementLocked" : (((cfg != null) ? cfg.GetValueOrDefault().UnlockDesc : null) ?? ""));
				}
			}
			RoverlikeRoleSelectElementTogglePanel lightTogglePanel = this.LightTogglePanel;
			if (lightTogglePanel != null)
			{
				lightTogglePanel.SetLocked(!this.IsRoleTypeSelectable(this.GetRoleTypeIdByIndex(0)));
			}
			RoverlikeRoleSelectElementTogglePanel darkTogglePanel = this.DarkTogglePanel;
			if (darkTogglePanel != null)
			{
				darkTogglePanel.SetLocked(!this.IsRoleTypeSelectable(this.GetRoleTypeIdByIndex(1)));
			}
			ButtonItem confirmButton = this.ConfirmButton;
			if (confirmButton == null)
			{
				return;
			}
			confirmButton.SetActive(flag);
		}

		// Token: 0x060406EF RID: 263919 RVA: 0x010850BB File Offset: 0x010832BB
		private RoverRogueRoleType? GetRoleTypeConfig(int roleTypeId)
		{
			return ConfigBase<RoverlikeConfig>.Instance.GetRoleTypeConfig(roleTypeId);
		}

		// Token: 0x060406F0 RID: 263920 RVA: 0x010850C8 File Offset: 0x010832C8
		private void BuildSelectableRoleTypeSet()
		{
			this.SelectableRoleTypeIdSet.Clear();
			RoverRogueIns? insConfig = ConfigBase<RoverlikeConfig>.Instance.GetInsConfig(this.CurInstId);
			if (insConfig == null)
			{
				return;
			}
			int roverListLength = insConfig.Value.RoverListLength;
			if (roverListLength <= 0)
			{
				return;
			}
			for (int i = 0; i < roverListLength; i++)
			{
				this.SelectableRoleTypeIdSet.Add(insConfig.Value.RoverList(i));
			}
		}

		// Token: 0x060406F1 RID: 263921 RVA: 0x01085138 File Offset: 0x01083338
		private bool IsRoleTypeSelectable(int roleTypeId)
		{
			return this.SelectableRoleTypeIdSet.Contains(roleTypeId);
		}

		// Token: 0x060406F2 RID: 263922 RVA: 0x01085148 File Offset: 0x01083348
		private void OnLightToggleStateChange(EToggleState state)
		{
			if (state != EToggleState.ETT_Checked)
			{
				return;
			}
			this.SelectElement(this.GetRoleTypeIdByIndex(0));
			base.PlayOrReplaySequence("Switch", false, null);
		}

		// Token: 0x060406F3 RID: 263923 RVA: 0x0108517C File Offset: 0x0108337C
		private void OnDarkToggleStateChange(EToggleState state)
		{
			if (state != EToggleState.ETT_Checked)
			{
				return;
			}
			this.SelectElement(this.GetRoleTypeIdByIndex(1));
			base.PlayOrReplaySequence("Switch", false, null);
		}

		// Token: 0x060406F4 RID: 263924 RVA: 0x010851B0 File Offset: 0x010833B0
		private void OnClickConfirm(int data)
		{
			if (!this.IsRoleTypeSelectable(this.CurRoleTypeId))
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("RoverRogue_RoleSelect_LockedTip", Array.Empty<object>());
				return;
			}
			RoverlikeRoleSelectViewOpenParam roverlikeRoleSelectViewOpenParam = this.OpenParam as RoverlikeRoleSelectViewOpenParam;
			if (roverlikeRoleSelectViewOpenParam != null)
			{
				Action<int> onConfirm = roverlikeRoleSelectViewOpenParam.OnConfirm;
				if (onConfirm != null)
				{
					onConfirm(this.CurRoleTypeId);
				}
			}
			base.CloseMe(null);
		}

		// Token: 0x060406F5 RID: 263925 RVA: 0x0108520E File Offset: 0x0108340E
		private void OnClickClose()
		{
			base.CloseMe(null);
		}

		// Token: 0x04024141 RID: 147777
		private const int ROLE_TYPE_INDEX_LIGHT = 0;

		// Token: 0x04024142 RID: 147778
		private const int ROLE_TYPE_INDEX_DARK = 1;

		// Token: 0x04024143 RID: 147779
		private PopupCaptionItem CaptionItem;

		// Token: 0x04024144 RID: 147780
		private ButtonItem ConfirmButton;

		// Token: 0x04024145 RID: 147781
		private RoverlikeRoleSelectTitlePanel TitlePanel;

		// Token: 0x04024146 RID: 147782
		private RoverlikeRoleSelectUnlockPanel UnlockPanel;

		// Token: 0x04024147 RID: 147783
		private RoverlikeRoleSelectElementTogglePanel LightTogglePanel;

		// Token: 0x04024148 RID: 147784
		private RoverlikeRoleSelectElementTogglePanel DarkTogglePanel;

		// Token: 0x04024149 RID: 147785
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<RoverlikeRoleSelectInfoItem, RoverlikeRoleSelectInfoItemData> InfoLayout;

		// Token: 0x0402414A RID: 147786
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<RoverlikeRoleSelectAssistRoleItem, RoverlikeRoleSelectAssistRoleItemData> AssistLayoutL;

		// Token: 0x0402414B RID: 147787
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<RoverlikeRoleSelectAssistRoleItem, RoverlikeRoleSelectAssistRoleItemData> AssistLayoutR;

		// Token: 0x0402414C RID: 147788
		private int CurRoleTypeId;

		// Token: 0x0402414D RID: 147789
		[Nullable(1)]
		private List<int> RoleTypeIdList = new List<int>();

		// Token: 0x0402414E RID: 147790
		private int CurInstId;

		// Token: 0x0402414F RID: 147791
		[Nullable(1)]
		private readonly HashSet<int> SelectableRoleTypeIdSet = new HashSet<int>();

		// Token: 0x0200C4B9 RID: 50361
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403C8C8 RID: 248008
			public const int UiItemCaption = 0;

			// Token: 0x0403C8C9 RID: 248009
			public const int TogSelectElementLight = 1;

			// Token: 0x0403C8CA RID: 248010
			public const int TogSelectElementDark = 2;

			// Token: 0x0403C8CB RID: 248011
			public const int PnlRoleMale = 3;

			// Token: 0x0403C8CC RID: 248012
			public const int PnlRoleFemale = 4;

			// Token: 0x0403C8CD RID: 248013
			public const int PnlEffectLight = 5;

			// Token: 0x0403C8CE RID: 248014
			public const int PnlEffectDark = 6;

			// Token: 0x0403C8CF RID: 248015
			public const int PnlTitle = 7;

			// Token: 0x0403C8D0 RID: 248016
			public const int SvInfo = 8;

			// Token: 0x0403C8D1 RID: 248017
			public const int PnlInfoItem = 9;

			// Token: 0x0403C8D2 RID: 248018
			public const int PnlRoleLayoutL = 10;

			// Token: 0x0403C8D3 RID: 248019
			public const int UiItemRoleL = 11;

			// Token: 0x0403C8D4 RID: 248020
			public const int PnlRoleLayoutR = 12;

			// Token: 0x0403C8D5 RID: 248021
			public const int UiItemRoleR = 13;

			// Token: 0x0403C8D6 RID: 248022
			public const int PnlAactivedB = 14;

			// Token: 0x0403C8D7 RID: 248023
			public const int BtnConfirm = 15;
		}
	}
}
