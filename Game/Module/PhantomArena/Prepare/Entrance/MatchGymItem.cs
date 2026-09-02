using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Prepare.Entrance
{
	// Token: 0x020054DF RID: 21727
	public class MatchGymItem : GridProxyAbstract<int>
	{
		// Token: 0x060375AD RID: 226733 RVA: 0x00E0C134 File Offset: 0x00E0A334
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(1, typeof(UUISprite)),
				new ValueTuple<int, Type>(2, typeof(UUISprite)),
				new ValueTuple<int, Type>(3, typeof(UUISprite)),
				new ValueTuple<int, Type>(4, typeof(UUISprite)),
				new ValueTuple<int, Type>(5, typeof(UUIHorizontalLayout)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUISprite)),
				new ValueTuple<int, Type>(8, typeof(UUISprite)),
				new ValueTuple<int, Type>(10, typeof(UUISprite)),
				new ValueTuple<int, Type>(9, typeof(UUISprite)),
				new ValueTuple<int, Type>(11, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickToggle))
			};
		}

		// Token: 0x060375AE RID: 226734 RVA: 0x00E0C27C File Offset: 0x00E0A47C
		protected override void OnStart()
		{
			base.GetItem(11).SetUIActive(false);
			this.LayoutStar = new GenericLayout<GymStarItem, GymChallengeData>(base.GetHorizontalLayout(5), new Func<GymStarItem>(this.CreateStarItem), null, false, true);
			base.GetExtendToggle(0).OnUndeterminedClicked.Add(new Action(this.OnUndeterminedClicked));
		}

		// Token: 0x060375AF RID: 226735 RVA: 0x00E0C2D5 File Offset: 0x00E0A4D5
		[NullableContext(1)]
		private GymStarItem CreateStarItem()
		{
			return new GymStarItem();
		}

		// Token: 0x060375B0 RID: 226736 RVA: 0x00E0C2DC File Offset: 0x00E0A4DC
		public override void Refresh(int gymLevel, bool isSelected, int gridIndex)
		{
			this.Level = gymLevel;
			PhantomBattleGym? phantomBattleGymConfigByLevel = ModelBase<PhantomArenaModel>.Instance.GetPhantomBattleGymConfigByLevel(gymLevel, this.ActivityId);
			if (phantomBattleGymConfigByLevel == null)
			{
				return;
			}
			bool flag = ModelBase<PhantomArenaModel>.Instance.IsGymLock(this.Level, this.ActivityId);
			string path = flag ? phantomBattleGymConfigByLevel.Value.IconLock : phantomBattleGymConfigByLevel.Value.Icon;
			UUISprite sprite = base.GetSprite(4);
			this.SetSpriteByPath(path, sprite, false, null, null);
			UUIItem uuiitem = sprite;
			bool bUseChangeColor = flag;
			FColor? fcolor = new FColor?(sprite.changeColor);
			uuiitem.SetChangeColor(bUseChangeColor, fcolor);
			this.SetSpriteByPath(phantomBattleGymConfigByLevel.Value.IconRoman, base.GetSprite(1), false, null, null);
			this.SetSpriteByPath(phantomBattleGymConfigByLevel.Value.IconRoman, base.GetSprite(2), false, null, null);
			this.SetSpriteByPath(phantomBattleGymConfigByLevel.Value.IconBg, base.GetSprite(3), false, null, null);
			this.SetSelected(isSelected);
			List<GymChallengeData> challengeStateListByGymLevel = ModelBase<PhantomArenaModel>.Instance.GetChallengeStateListByGymLevel(this.Level, this.ActivityId);
			this.LayoutStar.RefreshByData(challengeStateListByGymLevel, null, false);
			this.LayoutStar.SetActive(!flag);
			this.RefreshRedDot();
		}

		// Token: 0x060375B1 RID: 226737 RVA: 0x00E0C43C File Offset: 0x00E0A63C
		public void RefreshRedDot()
		{
			bool uiactive = this.Level > 0 && ModelBase<PhantomArenaModel>.Instance.GetGymRedDotById(this.Level, this.ActivityId);
			base.GetItem(11).SetUIActive(uiactive);
		}

		// Token: 0x060375B2 RID: 226738 RVA: 0x00E0C47C File Offset: 0x00E0A67C
		private void SetSelected(bool isSelected)
		{
			bool flag = ModelBase<PhantomArenaModel>.Instance.IsGymLock(this.Level, this.ActivityId);
			EToggleState etoggleState = (!flag && isSelected) ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
			EToggleState state = flag ? EToggleState.ETT_UnDetermined : etoggleState;
			base.GetExtendToggle(0).SetToggleState(state, false, false, false);
			base.GetSprite(1).SetUIActive(!isSelected);
			base.GetSprite(2).SetUIActive(isSelected);
			base.GetSprite(3).SetUIActive(!flag && !isSelected);
			base.GetSprite(7).SetUIActive(flag);
			base.GetSprite(8).SetUIActive(flag);
			base.GetSprite(1).SetIsGray(true);
		}

		// Token: 0x060375B3 RID: 226739 RVA: 0x00E0C520 File Offset: 0x00E0A720
		public override void OnSelected(bool fireEvent)
		{
			this.SetSelected(true);
		}

		// Token: 0x060375B4 RID: 226740 RVA: 0x00E0C529 File Offset: 0x00E0A729
		public override void OnDeselected(bool fireEvent)
		{
			this.SetSelected(false);
		}

		// Token: 0x060375B5 RID: 226741 RVA: 0x00E0C534 File Offset: 0x00E0A734
		private void OnUndeterminedClicked()
		{
			if (this.CallbackOnClick != null && this.Level > 0)
			{
				EToggleState toggleState = base.GetExtendToggle(0).GetToggleState();
				this.CallbackOnClick(this.Level, base.GridIndex, toggleState);
			}
		}

		// Token: 0x060375B6 RID: 226742 RVA: 0x00E0C578 File Offset: 0x00E0A778
		private void OnClickToggle(EToggleState toggleState)
		{
			if (this.CallbackOnClick != null && this.Level > 0)
			{
				EToggleState toggleState2 = base.GetExtendToggle(0).GetToggleState();
				this.CallbackOnClick(this.Level, base.GridIndex, toggleState2);
			}
		}

		// Token: 0x0401FCA8 RID: 130216
		public int Level = -1;

		// Token: 0x0401FCA9 RID: 130217
		public int ActivityId;

		// Token: 0x0401FCAA RID: 130218
		[Nullable(2)]
		public Action<int, int, EToggleState> CallbackOnClick;

		// Token: 0x0401FCAB RID: 130219
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<GymStarItem, GymChallengeData> LayoutStar;

		// Token: 0x0200B459 RID: 46169
		private class EComponent
		{
			// Token: 0x04037D27 RID: 228647
			public const int ToggleLevel = 0;

			// Token: 0x04037D28 RID: 228648
			public const int SpriteRoman = 1;

			// Token: 0x04037D29 RID: 228649
			public const int SpriteRomanSel = 2;

			// Token: 0x04037D2A RID: 228650
			public const int SpriteGate = 3;

			// Token: 0x04037D2B RID: 228651
			public const int SpriteIcon = 4;

			// Token: 0x04037D2C RID: 228652
			public const int LayoutStar = 5;

			// Token: 0x04037D2D RID: 228653
			public const int ItemStar = 6;

			// Token: 0x04037D2E RID: 228654
			public const int SpriteGateLock = 7;

			// Token: 0x04037D2F RID: 228655
			public const int SpriteLock = 8;

			// Token: 0x04037D30 RID: 228656
			public const int SpriteGray = 9;

			// Token: 0x04037D31 RID: 228657
			public const int SpriteLight = 10;

			// Token: 0x04037D32 RID: 228658
			public const int ItemRedDot = 11;
		}
	}
}
