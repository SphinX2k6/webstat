using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Module.RogueBattle;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.MapRogue
{
	// Token: 0x0200593F RID: 22847
	[NullableContext(1)]
	[Nullable(0)]
	public class MapRoguePanelFetter : UiPanelBase
	{
		// Token: 0x06039F3E RID: 237374 RVA: 0x00EAAC2C File Offset: 0x00EA8E2C
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIVerticalLayout)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(3, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(4, typeof(UUIText))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(2, new Action(this.OnBtnFetterClick)),
				new ValueTuple<int, Delegate>(3, new Action<EToggleState>(this.OnTogFoldClick))
			};
		}

		// Token: 0x06039F3F RID: 237375 RVA: 0x00EAACF0 File Offset: 0x00EA8EF0
		protected override void OnStart()
		{
			this.LevelSequencePlayerInstance = new LevelSequencePlayer(this.RootItem);
			this.LevelSequencePlayerInstance.BindSequenceCloseEvent(new TSequenceEndEvent(this.OnCloseEvent), false);
			this.FetterLayout = new GenericLayout<FetterItem, IRogueBattleRoleBondUpdateInfo>(base.GetVerticalLayout(0), new Func<FetterItem>(this.OnCreateItem), null, false, true);
			this.RefreshTxt();
		}

		// Token: 0x06039F40 RID: 237376 RVA: 0x00EAAD4D File Offset: 0x00EA8F4D
		protected override void OnBeforeShow()
		{
			this.RefreshFetter();
		}

		// Token: 0x06039F41 RID: 237377 RVA: 0x00EAAD58 File Offset: 0x00EA8F58
		public void RefreshFetter()
		{
			List<RoleBondInfo> allOwnedRoleBondData = ModelBase<RogueBattleModel>.Instance.GetAllOwnedRoleBondData();
			List<IRogueBattleRoleBondUpdateInfo> list = new List<IRogueBattleRoleBondUpdateInfo>();
			foreach (RoleBondInfo roleBondInfo in allOwnedRoleBondData)
			{
				RogueBattleRoleBondUpdateInfo item = new RogueBattleRoleBondUpdateInfo
				{
					NewRoleBondInfo = roleBondInfo,
					OldRoleBondInfo = roleBondInfo,
					AddStar = 0
				};
				list.Add(item);
			}
			List<IRogueBattleRoleBondUpdateInfo> list2 = list;
			Comparison<IRogueBattleRoleBondUpdateInfo> comparison;
			if ((comparison = MapRoguePanelFetter.<>O.<0>__SortRogueBattleRoleBondUpdateInfo) == null)
			{
				comparison = (MapRoguePanelFetter.<>O.<0>__SortRogueBattleRoleBondUpdateInfo = new Comparison<IRogueBattleRoleBondUpdateInfo>(RogueBattleDefine.SortRogueBattleRoleBondUpdateInfo));
			}
			list2.Sort(comparison);
			List<IRogueBattleRoleBondUpdateInfo> data = (list.Count > 5) ? list.GetRange(0, 5) : list;
			this.FetterLayout.RefreshByData(data, null, false);
		}

		// Token: 0x06039F42 RID: 237378 RVA: 0x00EAAE18 File Offset: 0x00EA9018
		private FetterItem OnCreateItem()
		{
			return new FetterItem
			{
				OpenMenuFunc = new Action<IRogueBattleRoleBondUpdateInfo>(this.OnFetterItemClick)
			};
		}

		// Token: 0x06039F43 RID: 237379 RVA: 0x00EAAE34 File Offset: 0x00EA9034
		private void OnBtnFetterClick()
		{
			if (this.CheckCanOpenMenu != null && !this.CheckCanOpenMenu())
			{
				return;
			}
			ControllerBase<MapRogueController>.Instance.OpenRogueFetterView(null);
		}

		// Token: 0x06039F44 RID: 237380 RVA: 0x00EAAE6C File Offset: 0x00EA906C
		private void OnCloseEvent(string sequenceName)
		{
			if (sequenceName == "Close")
			{
				base.GetVerticalLayout(0).RootUIComp.Get().SetUIActive(this.VisibleState);
				base.GetButton(2).RootUIComp.Get().SetUIActive(this.VisibleState);
			}
		}

		// Token: 0x06039F45 RID: 237381 RVA: 0x00EAAEC4 File Offset: 0x00EA90C4
		private void OnTogFoldClick(EToggleState state)
		{
			this.VisibleState = !this.VisibleState;
			this.RefreshTxt();
			base.GetVerticalLayout(0).RootUIComp.Get().SetUIActive(true);
			base.GetButton(2).RootUIComp.Get().SetUIActive(true);
			if (this.VisibleState)
			{
				this.LevelSequencePlayerInstance.PlayOrReplaySequenceByName("Start", false, null);
				return;
			}
			this.LevelSequencePlayerInstance.PlayOrReplaySequenceByName("Close", false, null);
		}

		// Token: 0x06039F46 RID: 237382 RVA: 0x00EAAF57 File Offset: 0x00EA9157
		private void OnFetterItemClick(IRogueBattleRoleBondUpdateInfo fetterData)
		{
			if (fetterData.NewRoleBondInfo.ConfigId == 0)
			{
				return;
			}
			if (this.CheckCanOpenMenu != null && !this.CheckCanOpenMenu())
			{
				return;
			}
			ControllerBase<MapRogueController>.Instance.OpenRogueFetterView(new int?(fetterData.NewRoleBondInfo.ConfigId));
		}

		// Token: 0x06039F47 RID: 237383 RVA: 0x00EAAF98 File Offset: 0x00EA9198
		private void RefreshTxt()
		{
			string textStringId = this.VisibleState ? "RogueRes_BondMain_Open" : "RogueRes_BondMain_Close";
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), textStringId, Array.Empty<object>());
		}

		// Token: 0x06039F48 RID: 237384 RVA: 0x00EAAFD4 File Offset: 0x00EA91D4
		public void SetToggleVisible(bool bVisible)
		{
			base.GetExtendToggle(3).RootUIComp.Get().SetUIActive(bVisible);
		}

		// Token: 0x06039F49 RID: 237385 RVA: 0x00EAAFFC File Offset: 0x00EA91FC
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			if (configParams.Length == 0)
			{
				return null;
			}
			GenericLayout<FetterItem, IRogueBattleRoleBondUpdateInfo> fetterLayout = this.FetterLayout;
			UUIItem uuiitem = (fetterLayout != null) ? fetterLayout.GetGridByDisplayIndex(0) : null;
			if (uuiitem == null)
			{
				return null;
			}
			return new UUIItem[]
			{
				uuiitem,
				uuiitem
			};
		}

		// Token: 0x04020D62 RID: 134498
		[Nullable(2)]
		protected LevelSequencePlayer LevelSequencePlayerInstance;

		// Token: 0x04020D63 RID: 134499
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		protected GenericLayout<FetterItem, IRogueBattleRoleBondUpdateInfo> FetterLayout;

		// Token: 0x04020D64 RID: 134500
		[Nullable(2)]
		public Func<bool> CheckCanOpenMenu;

		// Token: 0x04020D65 RID: 134501
		private bool VisibleState = true;

		// Token: 0x04020D66 RID: 134502
		private const int FETTER_DISPLAY_NUM = 5;

		// Token: 0x0200B90F RID: 47375
		[CompilerGenerated]
		private static class <>O
		{
			// Token: 0x040392D0 RID: 234192
			[Nullable(new byte[]
			{
				0,
				1
			})]
			public static Comparison<IRogueBattleRoleBondUpdateInfo> <0>__SortRogueBattleRoleBondUpdateInfo;
		}
	}
}
