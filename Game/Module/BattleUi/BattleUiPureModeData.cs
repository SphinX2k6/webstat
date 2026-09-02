using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.BattleUi
{
	// Token: 0x02005F84 RID: 24452
	[NullableContext(1)]
	[Nullable(0)]
	public class BattleUiPureModeData
	{
		// Token: 0x0603D655 RID: 251477 RVA: 0x00F9E478 File Offset: 0x00F9C678
		public void Init()
		{
			this.CurOperationType = Singleton<Info>.Instance.OperationType;
			this.GuideId = ConfigCommonParamById.GetIntConfig("PureModeGuideId").Value;
		}

		// Token: 0x0603D656 RID: 251478 RVA: 0x00F9E4AD File Offset: 0x00F9C6AD
		public void Clear()
		{
			this.IsOpen = false;
		}

		// Token: 0x17009A5D RID: 39517
		// (get) Token: 0x0603D657 RID: 251479 RVA: 0x00F9E4B6 File Offset: 0x00F9C6B6
		// (set) Token: 0x0603D658 RID: 251480 RVA: 0x00F9E4C0 File Offset: 0x00F9C6C0
		public bool IsOpen
		{
			get
			{
				return this.IsOpenInternal;
			}
			set
			{
				if (this.IsOpenInternal == value)
				{
					return;
				}
				this.IsOpenInternal = value;
				this.Refresh(!value);
				Singleton<UiManager>.Instance.RefreshByPureModeChanged();
				Singleton<EventSystem>.Instance.Emit<bool>(EEventName.BattleUiPureModeChanged, value);
				Singleton<EventSystem>.Instance.Emit<EFunction>(EEventName.RefreshMenuSetting, EFunction.UIPureMode);
			}
		}

		// Token: 0x0603D659 RID: 251481 RVA: 0x00F9E518 File Offset: 0x00F9C718
		public void ShowTypeChange(EOperationType last, EOperationType now)
		{
			if (now == EOperationType.None)
			{
				return;
			}
			if (this.CurOperationType == now)
			{
				return;
			}
			if (this.IsOpen)
			{
				this.Refresh(false);
				this.CurOperationType = now;
				this.Refresh(false);
				return;
			}
			this.CurOperationType = now;
		}

		// Token: 0x0603D65A RID: 251482 RVA: 0x00F9E550 File Offset: 0x00F9C750
		private void Refresh(bool bVisible)
		{
			if (this.CurOperationType == EOperationType.None)
			{
				return;
			}
			if (this.CurOperationType == EOperationType.Desktop)
			{
				BattleUiChildViewData childViewData = ModelBase<BattleUiModel>.Instance.ChildViewData;
				if (childViewData == null)
				{
					return;
				}
				childViewData.SetChildrenVisible(EBattleUiVisibleReason.PureMode, BattleUiPureModeData.DesktopHideChildren, bVisible, true, 0);
				return;
			}
			else
			{
				BattleUiChildViewData childViewData2 = ModelBase<BattleUiModel>.Instance.ChildViewData;
				if (childViewData2 == null)
				{
					return;
				}
				childViewData2.SetChildrenVisible(EBattleUiVisibleReason.PureMode, BattleUiPureModeData.PadHideChildren, bVisible, true, 0);
				return;
			}
		}

		// Token: 0x040227D1 RID: 141265
		private static readonly IReadOnlyList<EBattleUiChild> DesktopHideChildren = new <>z__ReadOnlyArray<EBattleUiChild>(new EBattleUiChild[]
		{
			EBattleUiChild.MiniMap,
			EBattleUiChild.BossState,
			EBattleUiChild.HeadState,
			EBattleUiChild.PartState,
			EBattleUiChild.DamageView,
			EBattleUiChild.BattleHud
		});

		// Token: 0x040227D2 RID: 141266
		private static readonly IReadOnlyList<EBattleUiChild> PadHideChildren = new <>z__ReadOnlyArray<EBattleUiChild>(new EBattleUiChild[]
		{
			EBattleUiChild.MiniMap,
			EBattleUiChild.BossState,
			EBattleUiChild.HeadState,
			EBattleUiChild.PartState,
			EBattleUiChild.DamageView,
			EBattleUiChild.BattleHud
		});

		// Token: 0x040227D3 RID: 141267
		private bool IsOpenInternal;

		// Token: 0x040227D4 RID: 141268
		private EOperationType CurOperationType;

		// Token: 0x040227D5 RID: 141269
		public bool IsSkipConfirmBox;

		// Token: 0x040227D6 RID: 141270
		public bool IsSkipConfirmBoxTmp;

		// Token: 0x040227D7 RID: 141271
		public int GuideId;
	}
}
