using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.TowerDefence
{
	// Token: 0x02004ED2 RID: 20178
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class TowerDefenseSubLevelItem : GridProxyAbstract<TowerDefenseSubLevelData>
	{
		// Token: 0x060341FB RID: 213499 RVA: 0x00D080A0 File Offset: 0x00D062A0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 10;
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
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIExtendToggleTextTransition));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIExtendToggleTextTransition));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickToggle));
			this.BtnBindInfo = list2;
		}

		// Token: 0x060341FC RID: 213500 RVA: 0x00D08250 File Offset: 0x00D06450
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

		// Token: 0x060341FD RID: 213501 RVA: 0x00D0829C File Offset: 0x00D0649C
		public override void Refresh(TowerDefenseSubLevelData data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			TowerDefenceInstance? towerDefenseConfigById = ConfigBase<InstanceDungeonConfig>.Instance.GetTowerDefenseConfigById(data.StageId);
			bool flag = towerDefenseConfigById.Value.Difficulty == 1;
			UUIItem item = base.GetItem(1);
			if (item != null)
			{
				item.SetUIActive(flag);
			}
			UUIItem item2 = base.GetItem(2);
			if (item2 != null)
			{
				item2.SetUIActive(!flag);
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), flag ? "TowerDefence_DifficultyNormal" : "TowerDefence_DifficultyHard", Array.Empty<object>());
			bool flag2 = ControllerBase<TowerDefenseController>.Instance.CheckStageUnlockById(data.StageId);
			bool flag3 = ControllerBase<TowerDefenseController>.Instance.CheckStagePassedById(data.StageId);
			UUIItem item3 = base.GetItem(5);
			if (item3 != null)
			{
				item3.SetUIActive(!flag2);
			}
			UUIItem item4 = base.GetItem(6);
			if (item4 != null)
			{
				item4.SetUIActive(flag2 && flag3);
			}
			int instanceId = (towerDefenseConfigById != null) ? towerDefenseConfigById.Value.InstanceId : 0;
			UUIItem item5 = base.GetItem(7);
			if (item5 != null)
			{
				item5.SetUIActive(ModelBase<TowerDefenseModel>.Instance.CheckTowerDefenseInstanceHasRedDot(instanceId));
			}
			UUIText text = base.GetText(4);
			if (text != null)
			{
				if (!flag)
				{
					this.RefreshHardSubDescText(text, flag2, flag3);
				}
				else if (flag2)
				{
					Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "TowerDefence_GPint", new <>z__ReadOnlySingleElementList<object>(ControllerBase<TowerDefenseController>.Instance.GetRecordByStageId(data.StageId)));
				}
				else
				{
					ITowerDefenseLockedHint towerDefenseLockedHint = ControllerBase<TowerDefenseController>.Instance.BuildStageLockedHintById(data.StageId);
					if (towerDefenseLockedHint != null)
					{
						if (towerDefenseLockedHint.Args != null)
						{
							Singleton<LguiUtil>.Instance.SetLocalTextNew(text, towerDefenseLockedHint.TextId, towerDefenseLockedHint.Args);
						}
						else
						{
							Singleton<LguiUtil>.Instance.SetLocalTextNew(text, towerDefenseLockedHint.TextId, Array.Empty<object>());
						}
					}
					else
					{
						Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "TowerDefence_SubLevelLocked", Array.Empty<object>());
					}
				}
			}
			this.RefreshTransitionColors(flag);
			this.RefreshSelectionVisual();
		}

		// Token: 0x060341FE RID: 213502 RVA: 0x00D08478 File Offset: 0x00D06678
		private void RefreshHardSubDescText(UUIText descTxt, bool unlocked, bool passed)
		{
			if (!unlocked)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(descTxt, "TowerDefence_SubLevelLocked", Array.Empty<object>());
				return;
			}
			if (passed)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(descTxt, "TowerDefence_SubLevelPassed", Array.Empty<object>());
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(descTxt, "TowerDefence_SubLevelUnpassed", Array.Empty<object>());
		}

		// Token: 0x060341FF RID: 213503 RVA: 0x00D084CC File Offset: 0x00D066CC
		private void RefreshTransitionColors(bool isNormal)
		{
			UUIExtendToggleTextTransition uiExtendToggleTextTransition = base.GetUiExtendToggleTextTransition(8);
			if (uiExtendToggleTextTransition != null)
			{
				this.SetTextTransitionColor(uiExtendToggleTextTransition, isNormal ? "adc2cd" : "dad1cc", isNormal ? "182b34" : "dad1cc");
			}
			UUIExtendToggleTextTransition uiExtendToggleTextTransition2 = base.GetUiExtendToggleTextTransition(9);
			if (uiExtendToggleTextTransition2 != null)
			{
				this.SetTextTransitionColor(uiExtendToggleTextTransition2, isNormal ? "5d6e77" : "dad1cc7f", isNormal ? "182b34" : "dad1cc7f");
			}
		}

		// Token: 0x06034200 RID: 213504 RVA: 0x00D0853C File Offset: 0x00D0673C
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

		// Token: 0x06034201 RID: 213505 RVA: 0x00D085C9 File Offset: 0x00D067C9
		private FTextTransitionInfoOfState BuildTextStateColor(FTextTransitionInfoOfState state, string hex)
		{
			state.bSetFontColor = true;
			state.FontColor = FColor.FromHex(hex);
			return state;
		}

		// Token: 0x06034202 RID: 213506 RVA: 0x00D085E0 File Offset: 0x00D067E0
		public void RefreshSelectionVisual()
		{
			if (this.Data == null)
			{
				return;
			}
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (!ControllerBase<TowerDefenseController>.Instance.CheckStageSelectableById(this.Data.StageId))
			{
				if (extendToggle != null)
				{
					extendToggle.SetToggleStateForce(EToggleState.ETT_UnDetermined, false, false, false);
				}
				return;
			}
			bool flag = this.Data.IsSelectedGetter(this.Data.StageId);
			if (extendToggle != null)
			{
				extendToggle.SetToggleStateForce(flag ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
			}
		}

		// Token: 0x06034203 RID: 213507 RVA: 0x00D08654 File Offset: 0x00D06854
		public void RefreshRedDot()
		{
			if (this.Data == null)
			{
				return;
			}
			TowerDefenceInstance? towerDefenseConfigById = ConfigBase<InstanceDungeonConfig>.Instance.GetTowerDefenseConfigById(this.Data.StageId);
			int instanceId = (towerDefenseConfigById != null) ? towerDefenseConfigById.Value.InstanceId : 0;
			UUIItem item = base.GetItem(7);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(ModelBase<TowerDefenseModel>.Instance.CheckTowerDefenseInstanceHasRedDot(instanceId));
		}

		// Token: 0x06034204 RID: 213508 RVA: 0x00D086B8 File Offset: 0x00D068B8
		private void OnClickToggle(EToggleState state)
		{
			if (this.Data == null)
			{
				return;
			}
			if (!ControllerBase<TowerDefenseController>.Instance.CheckStageSelectableById(this.Data.StageId))
			{
				this.RefreshSelectionVisual();
				return;
			}
			if (!this.Data.IsSelectedGetter(this.Data.StageId))
			{
				this.Data.OnClickCb(this.Data.StageId);
				return;
			}
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.SetToggleStateForce(EToggleState.ETT_Checked, false, false, false);
		}

		// Token: 0x06034205 RID: 213509 RVA: 0x00D0873A File Offset: 0x00D0693A
		private bool OnCanExecuteChange()
		{
			return this.Data != null && ControllerBase<TowerDefenseController>.Instance.CheckStageSelectableById(this.Data.StageId);
		}

		// Token: 0x06034206 RID: 213510 RVA: 0x00D0875B File Offset: 0x00D0695B
		private void OnUndeterminedClicked()
		{
			if (this.Data != null && !ControllerBase<TowerDefenseController>.Instance.CheckStageSelectableById(this.Data.StageId))
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("TowerDefence_LevelLocked", Array.Empty<object>());
			}
		}

		// Token: 0x0401E1A6 RID: 123302
		private const string SubNormalTitleUncheckedColor = "adc2cd";

		// Token: 0x0401E1A7 RID: 123303
		private const string SubNormalTitleCheckedColor = "182b34";

		// Token: 0x0401E1A8 RID: 123304
		private const string SubNormalDescUncheckedColor = "5d6e77";

		// Token: 0x0401E1A9 RID: 123305
		private const string SubNormalDescCheckedColor = "182b34";

		// Token: 0x0401E1AA RID: 123306
		private const string SubHardTitleUncheckedColor = "dad1cc";

		// Token: 0x0401E1AB RID: 123307
		private const string SubHardTitleCheckedColor = "dad1cc";

		// Token: 0x0401E1AC RID: 123308
		private const string SubHardDescUncheckedColor = "dad1cc7f";

		// Token: 0x0401E1AD RID: 123309
		private const string SubHardDescCheckedColor = "dad1cc7f";

		// Token: 0x0401E1AE RID: 123310
		[Nullable(2)]
		private TowerDefenseSubLevelData Data;

		// Token: 0x0200AE79 RID: 44665
		[NullableContext(0)]
		private class ESubLevelItemComponent
		{
			// Token: 0x040362B9 RID: 221881
			public const int Toggle = 0;

			// Token: 0x040362BA RID: 221882
			public const int NormalPnl = 1;

			// Token: 0x040362BB RID: 221883
			public const int DifficultPnl = 2;

			// Token: 0x040362BC RID: 221884
			public const int TitleTxt = 3;

			// Token: 0x040362BD RID: 221885
			public const int DescTxt = 4;

			// Token: 0x040362BE RID: 221886
			public const int LockPnl = 5;

			// Token: 0x040362BF RID: 221887
			public const int FinishPnl = 6;

			// Token: 0x040362C0 RID: 221888
			public const int RedDotItem = 7;

			// Token: 0x040362C1 RID: 221889
			public const int TitleTransition = 8;

			// Token: 0x040362C2 RID: 221890
			public const int DescTransition = 9;
		}
	}
}
