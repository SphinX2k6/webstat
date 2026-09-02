using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.FlagChallenge
{
	// Token: 0x02005D5C RID: 23900
	[NullableContext(1)]
	[Nullable(0)]
	public class FlagChallengeBuffItem : UiPanelBase
	{
		// Token: 0x0603C3A3 RID: 246691 RVA: 0x00F46EA0 File Offset: 0x00F450A0
		public FlagChallengeBuffItem(FlagChallengeBuffData data)
		{
			this.BuffData = data;
		}

		// Token: 0x0603C3A4 RID: 246692 RVA: 0x00F46EB0 File Offset: 0x00F450B0
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUISprite)),
				new ValueTuple<int, Type>(1, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUITexture)),
				new ValueTuple<int, Type>(6, typeof(UUIText)),
				new ValueTuple<int, Type>(7, typeof(UUIItem)),
				new ValueTuple<int, Type>(8, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(1, new Action<EToggleState>(this.OnBuffToggle))
			};
		}

		// Token: 0x0603C3A5 RID: 246693 RVA: 0x00F46FB4 File Offset: 0x00F451B4
		protected override void OnStart()
		{
			UUIItem item = base.GetItem(8);
			int id = this.BuffData.Id;
			ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.RedDotFlagChallengeActivityBuffItemNewlyUnlocked, item, null, id);
			int buffActivityId = FlagChallengeUtils.GetBuffActivityId(id);
			FlagChallengeData flagChallengeData = ModelBase<FlagChallengeModel>.Instance.GetFlagChallengeData(buffActivityId);
			item.SetUIActive(flagChallengeData.IsBuffNewlyUnlocked(id));
		}

		// Token: 0x0603C3A6 RID: 246694 RVA: 0x00F47007 File Offset: 0x00F45207
		protected override void OnBeforeDestroy()
		{
			ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.RedDotFlagChallengeActivityBuffItemNewlyUnlocked, base.GetItem(8), this.BuffData.Id);
		}

		// Token: 0x0603C3A7 RID: 246695 RVA: 0x00F4702C File Offset: 0x00F4522C
		public void RefreshView()
		{
			base.GetText(6).SetText(this.BuffData.Config.Level.ToString(), true);
			this.UpdateToggleState();
			this.UpdateState();
		}

		// Token: 0x0603C3A8 RID: 246696 RVA: 0x00F47070 File Offset: 0x00F45270
		public void UpdateToggleState()
		{
			EToggleState state = this.BuffData.IsSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
			base.GetExtendToggle(1).SetToggleStateForce(state, false, false, false);
		}

		// Token: 0x0603C3A9 RID: 246697 RVA: 0x00F4709F File Offset: 0x00F4529F
		public void SetClickCallback(Action<FlagChallengeBuffData> callback)
		{
			this.ClickCallback = callback;
		}

		// Token: 0x0603C3AA RID: 246698 RVA: 0x00F470A8 File Offset: 0x00F452A8
		private void OnBuffToggle(EToggleState state)
		{
			Action<FlagChallengeBuffData> clickCallback = this.ClickCallback;
			if (clickCallback == null)
			{
				return;
			}
			clickCallback(this.BuffData);
		}

		// Token: 0x0603C3AB RID: 246699 RVA: 0x00F470C0 File Offset: 0x00F452C0
		public void UpdateState()
		{
			switch (this.BuffData.GetBuffStatus())
			{
			case EFlagChallengeBuffStatus.NotActive:
				this.SetStateNotActive();
				return;
			case EFlagChallengeBuffStatus.Active:
				this.SetStateActive();
				return;
			case EFlagChallengeBuffStatus.TempActive:
				this.SetStateTempActive();
				return;
			default:
				return;
			}
		}

		// Token: 0x0603C3AC RID: 246700 RVA: 0x00F47100 File Offset: 0x00F45300
		public void SetStateActive()
		{
			this.SetStarState(true);
			this.SetLockState(false);
			this.SetStateItemShow(3);
			this.SetIcon(this.BuffData.Config.IconPathActive);
			this.SetUseIconChangeColor(true);
		}

		// Token: 0x0603C3AD RID: 246701 RVA: 0x00F47144 File Offset: 0x00F45344
		public void SetStateTempActive()
		{
			this.SetStarState(true);
			this.SetLockState(false);
			this.SetStateItemShow(2);
			this.SetIcon(this.BuffData.Config.IconPathActive);
			this.SetUseIconChangeColor(true);
		}

		// Token: 0x0603C3AE RID: 246702 RVA: 0x00F47188 File Offset: 0x00F45388
		public void SetStateNotActive()
		{
			this.SetStarState(false);
			this.SetLockState(true);
			this.SetStateItemShow(4);
			this.SetIcon(this.BuffData.Config.IconPathNormal);
			this.SetUseIconChangeColor(false);
		}

		// Token: 0x0603C3AF RID: 246703 RVA: 0x00F471CA File Offset: 0x00F453CA
		private void SetStarState(bool show)
		{
			base.GetSprite(0).SetUIActive(show);
		}

		// Token: 0x0603C3B0 RID: 246704 RVA: 0x00F471D9 File Offset: 0x00F453D9
		private void SetLockState(bool show)
		{
			base.GetItem(7).SetUIActive(show);
		}

		// Token: 0x0603C3B1 RID: 246705 RVA: 0x00F471E8 File Offset: 0x00F453E8
		private void SetIcon(string path)
		{
			UUITexture texture = base.GetTexture(5);
			base.SetTextureByPath(path, texture, null, null);
		}

		// Token: 0x0603C3B2 RID: 246706 RVA: 0x00F47210 File Offset: 0x00F45410
		private void SetUseIconChangeColor(bool isUse)
		{
			UUITexture texture = base.GetTexture(5);
			UUIItem uuiitem = texture;
			FColor? fcolor = new FColor?(texture.changeColor);
			uuiitem.SetChangeColor(isUse, fcolor);
		}

		// Token: 0x0603C3B3 RID: 246707 RVA: 0x00F4723C File Offset: 0x00F4543C
		private void SetStateItemShow(int index)
		{
			foreach (int num in new List<int>
			{
				3,
				2,
				4
			})
			{
				base.GetItem(num).SetUIActive(index == num);
			}
		}

		// Token: 0x04021D61 RID: 138593
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Action<FlagChallengeBuffData> ClickCallback;

		// Token: 0x04021D62 RID: 138594
		private readonly FlagChallengeBuffData BuffData;
	}
}
