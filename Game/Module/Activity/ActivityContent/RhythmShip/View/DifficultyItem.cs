using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RhythmShip.View
{
	// Token: 0x020064EB RID: 25835
	internal class DifficultyItem : UiPanelBase
	{
		// Token: 0x06040B3D RID: 265021 RVA: 0x0109760C File Offset: 0x0109580C
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickToggle))
			};
		}

		// Token: 0x06040B3E RID: 265022 RVA: 0x0109769F File Offset: 0x0109589F
		protected override void OnStart()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnRhythmShipRedDotRefresh, new Action<List<int>, List<int>, List<int>>(this.OnRhythmShipRedDotRefresh));
			base.GetExtendToggle(0).OnUndeterminedClicked.Add(new Action(this.OnUndeterminedClickToggle));
		}

		// Token: 0x06040B3F RID: 265023 RVA: 0x010976DA File Offset: 0x010958DA
		protected override void OnBeforeDestroy()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnRhythmShipRedDotRefresh, new Action<List<int>, List<int>, List<int>>(this.OnRhythmShipRedDotRefresh));
		}

		// Token: 0x06040B40 RID: 265024 RVA: 0x010976F8 File Offset: 0x010958F8
		public void RefreshPanel(int subLevelId)
		{
			if (subLevelId <= 0)
			{
				base.SetUiActive(false);
				return;
			}
			base.SetUiActive(true);
			this.SubLevelId = subLevelId;
			Dictionary<int, RhythmSubLevelPb> subLevelInfoMapBySubLevelId = ModelBase<RhythmShipModel>.Instance.GetSubLevelInfoMapBySubLevelId(subLevelId);
			RhythmSubLevelPb rhythmSubLevelPb = null;
			if (subLevelInfoMapBySubLevelId != null)
			{
				subLevelInfoMapBySubLevelId.TryGetValue(subLevelId, out rhythmSubLevelPb);
			}
			bool uiactive = rhythmSubLevelPb != null && rhythmSubLevelPb.Cleared;
			base.GetItem(3).SetUIActive(uiactive);
			this.IsUnLock = ModelBase<RhythmShipModel>.Instance.GetSubLevelIsUnlock(subLevelId);
			base.GetItem(2).SetUIActive(!this.IsUnLock);
			this.HaveRedDotItem = ModelBase<RhythmShipModel>.Instance.GetSubLevelRedDotActive(subLevelId);
			base.GetItem(1).SetUIActive(this.HaveRedDotItem);
			base.GetExtendToggle(0).SetToggleStateForce(this.IsUnLock ? EToggleState.ETT_UnChecked : EToggleState.ETT_UnDetermined, false, false, false);
		}

		// Token: 0x06040B41 RID: 265025 RVA: 0x010977BC File Offset: 0x010959BC
		private void OnClickToggle(EToggleState state)
		{
			if (!this.IsUnLock)
			{
				RhythmSubLevel? rhythmShipSubLevelById = ConfigBase<RhythmShipConfig>.Instance.GetRhythmShipSubLevelById(this.SubLevelId);
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId(((rhythmShipSubLevelById != null) ? rhythmShipSubLevelById.GetValueOrDefault().LockTips : null) ?? "RhythmShipLevelLockTips", Array.Empty<object>());
			}
			Action<int, UUIExtendToggle> onClickToggleCallBack = this.OnClickToggleCallBack;
			if (onClickToggleCallBack == null)
			{
				return;
			}
			onClickToggleCallBack(this.SubLevelId, base.GetExtendToggle(0));
		}

		// Token: 0x06040B42 RID: 265026 RVA: 0x01097834 File Offset: 0x01095A34
		private void OnUndeterminedClickToggle()
		{
			RhythmSubLevel? rhythmShipSubLevelById = ConfigBase<RhythmShipConfig>.Instance.GetRhythmShipSubLevelById(this.SubLevelId);
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId(((rhythmShipSubLevelById != null) ? rhythmShipSubLevelById.GetValueOrDefault().LockTips : null) ?? "RhythmShipLevelLockTips", Array.Empty<object>());
		}

		// Token: 0x06040B43 RID: 265027 RVA: 0x01097885 File Offset: 0x01095A85
		public void SelectToggle()
		{
			if (!this.IsUnLock)
			{
				return;
			}
			base.GetExtendToggle(0).SetToggleStateForce(EToggleState.ETT_Checked, true, false, false);
		}

		// Token: 0x06040B44 RID: 265028 RVA: 0x010978A0 File Offset: 0x01095AA0
		[NullableContext(2)]
		private void OnRhythmShipRedDotRefresh(List<int> planet, List<int> subLevel, List<int> role)
		{
			if (subLevel == null || !subLevel.Contains(this.SubLevelId))
			{
				return;
			}
			this.HaveRedDotItem = false;
			base.GetItem(1).SetUIActive(false);
		}

		// Token: 0x04024429 RID: 148521
		public int SubLevelId;

		// Token: 0x0402442A RID: 148522
		public bool IsUnLock;

		// Token: 0x0402442B RID: 148523
		public bool HaveRedDotItem;

		// Token: 0x0402442C RID: 148524
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<int, UUIExtendToggle> OnClickToggleCallBack;
	}
}
