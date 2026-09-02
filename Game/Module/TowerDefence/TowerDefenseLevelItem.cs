using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.TowerDefence
{
	// Token: 0x02004ED1 RID: 20177
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class TowerDefenseLevelItem : GridProxyAbstract<TowerDefenseGroupData>
	{
		// Token: 0x060341E2 RID: 213474 RVA: 0x00D071E4 File Offset: 0x00D053E4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 18;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUITexture));
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
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIVerticalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIExtendToggleTextureTransition));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIExtendToggleTextTransition));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIExtendToggleTextTransition));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(16, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIExtendToggleTextureTransition));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickToggle));
			this.BtnBindInfo = list2;
		}

		// Token: 0x060341E3 RID: 213475 RVA: 0x00D074A4 File Offset: 0x00D056A4
		protected override void OnStart()
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle != null)
			{
				extendToggle.CanExecuteChange.Bind(new Func<bool>(this.OnCanExecuteChange));
			}
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.OnUndeterminedClicked.Add(new Action(this.OnUndeterminedClicked));
		}

		// Token: 0x060341E4 RID: 213476 RVA: 0x00D074F0 File Offset: 0x00D056F0
		public override void Refresh(TowerDefenseGroupData data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			this.RefreshGroupInfo(data);
			if (this.IsBossRush)
			{
				this.SetSubLayoutActive(false);
				this.RefreshSelectionVisual();
				return;
			}
			if (this.SubLayout == null)
			{
				this.SubLayout = new GenericLayout<TowerDefenseSubLevelItem, TowerDefenseSubLevelData>(base.GetVerticalLayout(11), () => new TowerDefenseSubLevelItem(), base.GetItem(12).GetOwner() as AUIBaseActor, false, true);
			}
			this.SubLayout.RefreshByData(this.BuildSubDataList(data), null, false);
			this.Expanded = this.IsGroupSelected();
			this.RefreshSelectionVisual();
		}

		// Token: 0x060341E5 RID: 213477 RVA: 0x00D07598 File Offset: 0x00D05798
		public void RefreshSelectionVisual()
		{
			bool flag = this.IsGroupLocked();
			bool flag2 = this.IsGroupSelected();
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (this.IsBossRush)
			{
				if (flag)
				{
					if (extendToggle != null)
					{
						extendToggle.SetToggleStateForce(EToggleState.ETT_UnDetermined, false, false, false);
						return;
					}
				}
				else if (extendToggle != null)
				{
					extendToggle.SetToggleStateForce(flag2 ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
				}
				return;
			}
			if (!flag2)
			{
				this.Expanded = false;
			}
			if (flag)
			{
				if (extendToggle != null)
				{
					extendToggle.SetToggleStateForce(EToggleState.ETT_UnDetermined, false, false, false);
				}
			}
			else if (extendToggle != null)
			{
				extendToggle.SetToggleStateForce((flag2 && this.Expanded) ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
			}
			this.SetSubLayoutActive(flag2 && this.Expanded);
			if (this.SubLayout != null)
			{
				foreach (TowerDefenseSubLevelItem towerDefenseSubLevelItem in this.SubLayout.GetLayoutItemList())
				{
					towerDefenseSubLevelItem.RefreshSelectionVisual();
				}
			}
		}

		// Token: 0x060341E6 RID: 213478 RVA: 0x00D07684 File Offset: 0x00D05884
		public void RefreshRedDot()
		{
			if (this.Data == null)
			{
				return;
			}
			bool uiactive = this.Data.SubStageIds.Any(delegate(int id)
			{
				TowerDefenceInstance? towerDefenseConfigById = ConfigBase<InstanceDungeonConfig>.Instance.GetTowerDefenseConfigById(id);
				int instanceId = (towerDefenseConfigById != null) ? towerDefenseConfigById.Value.InstanceId : 0;
				return ModelBase<TowerDefenseModel>.Instance.CheckTowerDefenseInstanceHasRedDot(instanceId);
			});
			UUIItem item = base.GetItem(10);
			if (item != null)
			{
				item.SetUIActive(uiactive);
			}
			if (this.SubLayout != null)
			{
				foreach (TowerDefenseSubLevelItem towerDefenseSubLevelItem in this.SubLayout.GetLayoutItemList())
				{
					towerDefenseSubLevelItem.RefreshRedDot();
				}
			}
		}

		// Token: 0x060341E7 RID: 213479 RVA: 0x00D07730 File Offset: 0x00D05930
		private bool IsGroupLocked()
		{
			if (this.Data == null)
			{
				return true;
			}
			return !this.Data.SubStageIds.Any((int id) => ControllerBase<TowerDefenseController>.Instance.CheckStageUnlockById(id));
		}

		// Token: 0x060341E8 RID: 213480 RVA: 0x00D0776E File Offset: 0x00D0596E
		private bool IsGroupSelected()
		{
			return this.Data != null && this.Data.SubStageIds.Any((int id) => this.Data.IsSelectedGetter(id));
		}

		// Token: 0x060341E9 RID: 213481 RVA: 0x00D07798 File Offset: 0x00D05998
		public void RefreshOnTick()
		{
			if (this.Data == null || this.IsBossRush)
			{
				return;
			}
			List<int> subStageIds = this.Data.SubStageIds;
			bool flag = subStageIds.Any((int id) => ControllerBase<TowerDefenseController>.Instance.CheckStageUnlockById(id));
			if (flag != this.CanExpand)
			{
				this.Refresh(this.Data, false, 0);
				return;
			}
			if (!flag)
			{
				this.RefreshDescText(subStageIds, false);
			}
		}

		// Token: 0x060341EA RID: 213482 RVA: 0x00D0780C File Offset: 0x00D05A0C
		private void RefreshGroupInfo(TowerDefenseGroupData data)
		{
			List<int> subStageIds = data.SubStageIds;
			this.IsBossRush = (subStageIds.Count > 0 && ConfigBase<InstanceDungeonConfig>.Instance.GetTowerDefenseConfigById(subStageIds[0]).Value.BossRush);
			UUIItem item = base.GetItem(1);
			if (item != null)
			{
				item.SetUIActive(!this.IsBossRush);
			}
			UUIItem item2 = base.GetItem(2);
			if (item2 != null)
			{
				item2.SetUIActive(this.IsBossRush);
			}
			InstanceDungeonTitle? titleConfig = ConfigBase<InstanceDungeonConfig>.Instance.GetTitleConfig(data.GroupId);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), (titleConfig != null) ? titleConfig.Value.CommonText : "", Array.Empty<object>());
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(TowerDefenseLevelItem.BuildRomeTextureName(base.DisplayIndex + 1));
			UUITexture texture = base.GetTexture(4);
			UUITexture texture2 = base.GetTexture(16);
			if (texture != null)
			{
				texture.SetUIActive(!this.IsBossRush);
			}
			if (texture2 != null)
			{
				texture2.SetUIActive(this.IsBossRush);
			}
			base.TrySetTextureByPath(resourcePath, this.IsBossRush ? texture2 : texture, null, null);
			this.RefreshTransitionColors();
			if (this.IsBossRush)
			{
				this.RefreshBossRushGroupInfo(subStageIds[0]);
				return;
			}
			this.RefreshNormalGroupInfo(subStageIds);
		}

		// Token: 0x060341EB RID: 213483 RVA: 0x00D07960 File Offset: 0x00D05B60
		private void RefreshTransitionColors()
		{
			bool isBossRush = this.IsBossRush;
			UUIExtendToggleTextureTransition uiExtendToggleTextureTransition = base.GetUiExtendToggleTextureTransition(isBossRush ? 17 : 13);
			if (uiExtendToggleTextureTransition != null)
			{
				this.SetTextureTransitionColor(uiExtendToggleTextureTransition, isBossRush ? "e9d7da" : "a6bdca", isBossRush ? "e9d7da" : "182b34");
			}
			UUIExtendToggleTextTransition uiExtendToggleTextTransition = base.GetUiExtendToggleTextTransition(14);
			if (uiExtendToggleTextTransition != null)
			{
				this.SetTextTransitionColor(uiExtendToggleTextTransition, isBossRush ? "ddc7cb" : "adc2cd", isBossRush ? "ffffff" : "182b34");
			}
			UUIExtendToggleTextTransition uiExtendToggleTextTransition2 = base.GetUiExtendToggleTextTransition(15);
			if (uiExtendToggleTextTransition2 != null)
			{
				this.SetTextTransitionColor(uiExtendToggleTextTransition2, isBossRush ? "dfe8ec66" : "5d6e77", isBossRush ? "ffffff7f" : "6a7b84");
			}
		}

		// Token: 0x060341EC RID: 213484 RVA: 0x00D07A10 File Offset: 0x00D05C10
		private void SetTextureTransitionColor(UUIExtendToggleTextureTransition transition, string uncheckedHex, string checkedHex)
		{
			FExtendToggleColorTransition transitionColors = transition.TransitionColors;
			FColor fcolor = FColor.FromHex(uncheckedHex);
			FColor fcolor2 = FColor.FromHex(checkedHex);
			transitionColors.UnCheckedUnHoverColor = fcolor;
			transitionColors.UnCheckedHoverColor = fcolor;
			transitionColors.UnCheckedPressedColor = fcolor;
			transitionColors.CheckedUnHoverColor = fcolor2;
			transitionColors.CheckedHoverColor = fcolor2;
			transitionColors.CheckedPressedColor = fcolor2;
			transition.TransitionColors = transitionColors;
		}

		// Token: 0x060341ED RID: 213485 RVA: 0x00D07A64 File Offset: 0x00D05C64
		private void SetTextTransitionColor(UUIExtendToggleTextTransition transition, string uncheckedHex, string checkedHex)
		{
			FExtendToggleTextTransitionState transitionState = transition.TransitionState;
			transitionState.UnCheckUnHoverState = this.BuildTextStateColor(transitionState.UnCheckUnHoverState, uncheckedHex);
			transitionState.UnCheckHoverState = this.BuildTextStateColor(transitionState.UnCheckHoverState, uncheckedHex);
			transitionState.UnCheckPressedState = this.BuildTextStateColor(transitionState.UnCheckPressedState, uncheckedHex);
			transitionState.CheckUnHoverState = this.BuildTextStateColor(transitionState.CheckUnHoverState, checkedHex);
			transitionState.CheckHoverState = this.BuildTextStateColor(transitionState.CheckHoverState, checkedHex);
			transitionState.CheckPressedState = this.BuildTextStateColor(transitionState.CheckPressedState, checkedHex);
			transition.TransitionState = transitionState;
		}

		// Token: 0x060341EE RID: 213486 RVA: 0x00D07AF1 File Offset: 0x00D05CF1
		private FTextTransitionInfoOfState BuildTextStateColor(FTextTransitionInfoOfState state, string hex)
		{
			state.bSetFontColor = true;
			state.FontColor = FColor.FromHex(hex);
			return state;
		}

		// Token: 0x060341EF RID: 213487 RVA: 0x00D07B08 File Offset: 0x00D05D08
		private void RefreshNormalGroupInfo(List<int> ids)
		{
			bool flag = ids.Any((int id) => ControllerBase<TowerDefenseController>.Instance.CheckStageUnlockById(id));
			bool uiactive = ids.Any(delegate(int id)
			{
				TowerDefenceInstance? towerDefenseConfigById = ConfigBase<InstanceDungeonConfig>.Instance.GetTowerDefenseConfigById(id);
				int instanceId = (towerDefenseConfigById != null) ? towerDefenseConfigById.Value.InstanceId : 0;
				return ModelBase<TowerDefenseModel>.Instance.CheckTowerDefenseInstanceHasRedDot(instanceId);
			});
			this.CanExpand = flag;
			bool flag2 = !flag;
			UUIItem item = base.GetItem(8);
			if (item != null)
			{
				item.SetUIActive(flag2);
			}
			UUIItem item2 = base.GetItem(9);
			if (item2 != null)
			{
				item2.SetUIActive(false);
			}
			UUIItem item3 = base.GetItem(7);
			if (item3 != null)
			{
				item3.SetUIActive(!flag2);
			}
			UUIItem item4 = base.GetItem(10);
			if (item4 != null)
			{
				item4.SetUIActive(uiactive);
			}
			this.RefreshDescText(ids, flag);
		}

		// Token: 0x060341F0 RID: 213488 RVA: 0x00D07BC8 File Offset: 0x00D05DC8
		private void RefreshBossRushGroupInfo(int stageId)
		{
			this.CanExpand = false;
			TowerDefenceInstance? towerDefenseConfigById = ConfigBase<InstanceDungeonConfig>.Instance.GetTowerDefenseConfigById(stageId);
			int instanceId = (towerDefenseConfigById != null) ? towerDefenseConfigById.Value.InstanceId : 0;
			bool flag = ControllerBase<TowerDefenseController>.Instance.CheckStageUnlockById(stageId);
			bool uiactive = ModelBase<TowerDefenseModel>.Instance.CheckTowerDefenseInstanceHasRedDot(instanceId);
			UUIItem item = base.GetItem(8);
			if (item != null)
			{
				item.SetUIActive(!flag);
			}
			UUIItem item2 = base.GetItem(9);
			if (item2 != null)
			{
				item2.SetUIActive(false);
			}
			UUIItem item3 = base.GetItem(7);
			if (item3 != null)
			{
				item3.SetUIActive(false);
			}
			UUIItem item4 = base.GetItem(10);
			if (item4 != null)
			{
				item4.SetUIActive(uiactive);
			}
			UUIText text = base.GetText(6);
			if (text == null)
			{
				return;
			}
			if (flag)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "TowerDefence_GPint", new <>z__ReadOnlySingleElementList<object>(ControllerBase<TowerDefenseController>.Instance.GetRecordByStageId(stageId)));
				return;
			}
			ITowerDefenseLockedHint towerDefenseLockedHint = ControllerBase<TowerDefenseController>.Instance.BuildStageLockedHintById(stageId);
			if (towerDefenseLockedHint == null)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "TowerDefence_Lcok_TipsText", Array.Empty<object>());
				return;
			}
			if (towerDefenseLockedHint.Args != null)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text, towerDefenseLockedHint.TextId, towerDefenseLockedHint.Args);
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, towerDefenseLockedHint.TextId, Array.Empty<object>());
		}

		// Token: 0x060341F1 RID: 213489 RVA: 0x00D07D0C File Offset: 0x00D05F0C
		private void RefreshDescText(List<int> ids, bool anyUnlock)
		{
			UUIText text = base.GetText(6);
			if (text == null)
			{
				return;
			}
			if (anyUnlock)
			{
				int value = ids.Count((int id) => ControllerBase<TowerDefenseController>.Instance.CheckStagePassedById(id));
				UUIText uuitext = text;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
				defaultInterpolatedStringHandler.AppendFormatted<int>(value);
				defaultInterpolatedStringHandler.AppendLiteral("/");
				defaultInterpolatedStringHandler.AppendFormatted<int>(ids.Count);
				uuitext.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
				return;
			}
			int num = 0;
			if (ids.Count > 0)
			{
				TowerDefenceInstance? towerDefenseConfigById = ConfigBase<InstanceDungeonConfig>.Instance.GetTowerDefenseConfigById(ids[0]);
				num = ((towerDefenseConfigById != null) ? towerDefenseConfigById.Value.InstanceId : 0);
			}
			string text2 = (num > 0) ? ControllerBase<TowerDefenseController>.Instance.BuildInstanceCountDownText(num) : null;
			text.SetText(text2 ?? "", true);
		}

		// Token: 0x060341F2 RID: 213490 RVA: 0x00D07DE8 File Offset: 0x00D05FE8
		private static string BuildRomeTextureName(int index)
		{
			int num = Math.Max(1, index);
			string text;
			if (num >= 10)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
				defaultInterpolatedStringHandler.AppendFormatted<int>(num);
				text = defaultInterpolatedStringHandler.ToStringAndClear();
			}
			else
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
				defaultInterpolatedStringHandler.AppendLiteral("0");
				defaultInterpolatedStringHandler.AppendFormatted<int>(num);
				text = defaultInterpolatedStringHandler.ToStringAndClear();
			}
			string str = text;
			return "T_ComRomeText_" + str;
		}

		// Token: 0x060341F3 RID: 213491 RVA: 0x00D07E4C File Offset: 0x00D0604C
		private List<TowerDefenseSubLevelData> BuildSubDataList(TowerDefenseGroupData group)
		{
			return (from id in @group.SubStageIds
			select new TowerDefenseSubLevelData
			{
				StageId = id,
				OnClickCb = @group.OnClickSubLevel,
				IsSelectedGetter = @group.IsSelectedGetter
			}).ToList<TowerDefenseSubLevelData>();
		}

		// Token: 0x060341F4 RID: 213492 RVA: 0x00D07E88 File Offset: 0x00D06088
		private void OnClickToggle(EToggleState state)
		{
			if (this.IsGroupLocked())
			{
				this.RefreshSelectionVisual();
				return;
			}
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (this.IsBossRush)
			{
				if (this.IsGroupSelected())
				{
					if (extendToggle != null)
					{
						extendToggle.SetToggleStateForce(EToggleState.ETT_Checked, false, false, false);
						return;
					}
				}
				else
				{
					int num = (this.Data != null && this.Data.SubStageIds.Count > 0) ? this.Data.SubStageIds[0] : 0;
					if (num > 0)
					{
						this.Data.OnClickSubLevel(num);
					}
				}
				return;
			}
			if (this.IsGroupSelected())
			{
				this.Expanded = !this.Expanded;
				if (extendToggle != null)
				{
					extendToggle.SetToggleStateForce(this.Expanded ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
				}
				this.SetSubLayoutActive(this.Expanded);
				return;
			}
			this.Expanded = true;
			int num2 = this.PickDefaultSubInstance();
			if (num2 > 0)
			{
				this.Data.OnClickSubLevel(num2);
			}
		}

		// Token: 0x060341F5 RID: 213493 RVA: 0x00D07F70 File Offset: 0x00D06170
		private int PickDefaultSubInstance()
		{
			if (this.Data == null)
			{
				return 0;
			}
			List<int> subStageIds = this.Data.SubStageIds;
			foreach (int num in subStageIds)
			{
				if (ConfigBase<InstanceDungeonConfig>.Instance.GetTowerDefenseConfigById(num).Value.Difficulty == 1)
				{
					return num;
				}
			}
			if (subStageIds.Count <= 0)
			{
				return 0;
			}
			return subStageIds[0];
		}

		// Token: 0x060341F6 RID: 213494 RVA: 0x00D08008 File Offset: 0x00D06208
		private bool OnCanExecuteChange()
		{
			return !this.IsGroupLocked();
		}

		// Token: 0x060341F7 RID: 213495 RVA: 0x00D08014 File Offset: 0x00D06214
		private void OnUndeterminedClicked()
		{
			if (this.IsGroupLocked())
			{
				string textId = this.IsBossRush ? "TowerDefence_Lcok_TipsText" : "TowerDefence_LevelLocked";
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId(textId, Array.Empty<object>());
			}
		}

		// Token: 0x060341F8 RID: 213496 RVA: 0x00D08050 File Offset: 0x00D06250
		private void SetSubLayoutActive(bool active)
		{
			UUIVerticalLayout verticalLayout = base.GetVerticalLayout(11);
			if (verticalLayout == null)
			{
				return;
			}
			UUIItem uuiitem = verticalLayout.RootUIComp.Get();
			if (uuiitem == null)
			{
				return;
			}
			uuiitem.SetUIActive(active);
		}

		// Token: 0x0401E195 RID: 123285
		private const string NormalIndexUncheckedColor = "a6bdca";

		// Token: 0x0401E196 RID: 123286
		private const string NormalIndexCheckedColor = "182b34";

		// Token: 0x0401E197 RID: 123287
		private const string NormalTitleUncheckedColor = "adc2cd";

		// Token: 0x0401E198 RID: 123288
		private const string NormalTitleCheckedColor = "182b34";

		// Token: 0x0401E199 RID: 123289
		private const string NormalDescUncheckedColor = "5d6e77";

		// Token: 0x0401E19A RID: 123290
		private const string NormalDescCheckedColor = "6a7b84";

		// Token: 0x0401E19B RID: 123291
		private const string HardIndexUncheckedColor = "e9d7da";

		// Token: 0x0401E19C RID: 123292
		private const string HardIndexCheckedColor = "e9d7da";

		// Token: 0x0401E19D RID: 123293
		private const string HardTitleUncheckedColor = "ddc7cb";

		// Token: 0x0401E19E RID: 123294
		private const string HardTitleCheckedColor = "ffffff";

		// Token: 0x0401E19F RID: 123295
		private const string HardDescUncheckedColor = "dfe8ec66";

		// Token: 0x0401E1A0 RID: 123296
		private const string HardDescCheckedColor = "ffffff7f";

		// Token: 0x0401E1A1 RID: 123297
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<TowerDefenseSubLevelItem, TowerDefenseSubLevelData> SubLayout;

		// Token: 0x0401E1A2 RID: 123298
		private bool CanExpand;

		// Token: 0x0401E1A3 RID: 123299
		private bool IsBossRush;

		// Token: 0x0401E1A4 RID: 123300
		private bool Expanded;

		// Token: 0x0401E1A5 RID: 123301
		[Nullable(2)]
		private TowerDefenseGroupData Data;

		// Token: 0x0200AE76 RID: 44662
		[NullableContext(0)]
		private class ELevelItemComponent
		{
			// Token: 0x0403629E RID: 221854
			public const int Toggle = 0;

			// Token: 0x0403629F RID: 221855
			public const int NormalPnl = 1;

			// Token: 0x040362A0 RID: 221856
			public const int DifficultPnl = 2;

			// Token: 0x040362A1 RID: 221857
			public const int IndexIconPnl = 3;

			// Token: 0x040362A2 RID: 221858
			public const int IndexIconTex = 4;

			// Token: 0x040362A3 RID: 221859
			public const int TitleTxt = 5;

			// Token: 0x040362A4 RID: 221860
			public const int DescTxt = 6;

			// Token: 0x040362A5 RID: 221861
			public const int DropdownPnl = 7;

			// Token: 0x040362A6 RID: 221862
			public const int LockPnl = 8;

			// Token: 0x040362A7 RID: 221863
			public const int FinishPnl = 9;

			// Token: 0x040362A8 RID: 221864
			public const int RedDotItem = 10;

			// Token: 0x040362A9 RID: 221865
			public const int SubLevelLayout = 11;

			// Token: 0x040362AA RID: 221866
			public const int SubLevelItem = 12;

			// Token: 0x040362AB RID: 221867
			public const int IndexIconTransition = 13;

			// Token: 0x040362AC RID: 221868
			public const int TitleTransition = 14;

			// Token: 0x040362AD RID: 221869
			public const int DescTransition = 15;

			// Token: 0x040362AE RID: 221870
			public const int BossIndexTex = 16;

			// Token: 0x040362AF RID: 221871
			public const int BossIndexIconTransition = 17;
		}
	}
}
