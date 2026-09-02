using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02006106 RID: 24838
	[NullableContext(2)]
	[Nullable(0)]
	public class XiaKongQteBar : UiPanelBase
	{
		// Token: 0x0603EC10 RID: 257040 RVA: 0x010118D4 File Offset: 0x0100FAD4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603EC11 RID: 257041 RVA: 0x0101193D File Offset: 0x0100FB3D
		[NullableContext(1)]
		public void Init(XiaKongQteSkillItem skillItem)
		{
			this.SkillItem = skillItem;
			this.SkillItem.SetEnable(this.ClickTipVisible);
		}

		// Token: 0x0603EC12 RID: 257042 RVA: 0x01011957 File Offset: 0x0100FB57
		public void Refresh(SpecialSkillXiaKong specialSkill)
		{
			this.SpecialSkill = specialSkill;
		}

		// Token: 0x0603EC13 RID: 257043 RVA: 0x01011960 File Offset: 0x0100FB60
		protected override void OnStart()
		{
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
			base.GetTexture(1).SetFillAmount(1f);
			base.GetTexture(1).SetUIActive(false);
			this.ClickTipVisible = false;
		}

		// Token: 0x0603EC14 RID: 257044 RVA: 0x01011998 File Offset: 0x0100FB98
		protected override void OnBeforeDestroy()
		{
			if (this.LevelSequencePlayer != null)
			{
				LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
				if (levelSequencePlayer != null)
				{
					levelSequencePlayer.Clear();
				}
				this.LevelSequencePlayer = null;
			}
		}

		// Token: 0x0603EC15 RID: 257045 RVA: 0x010119BC File Offset: 0x0100FBBC
		public void Tick(float delta)
		{
			if (this.SpecialSkill == null)
			{
				return;
			}
			if (this.SpecialSkill.GetNextEndCircleIndex() >= this.SpecialSkill.GetNextGenCircleIndex())
			{
				this.SetVisible(false);
				return;
			}
			this.SetVisible(true);
			float num = this.SpecialSkill.GetNextEndCircleAttrValue(0) / this.SpecialSkill.GetMinAttrValue();
			if (num >= 1f)
			{
				this.SetClickTipVisible(true);
				return;
			}
			UUITexture texture = base.GetTexture(0);
			if (texture != null)
			{
				texture.SetFillAmount((num - 0.5f) / 0.5f);
			}
			this.SetClickTipVisible(false);
		}

		// Token: 0x0603EC16 RID: 257046 RVA: 0x01011A48 File Offset: 0x0100FC48
		private void SetVisible(bool visible)
		{
			if (this.IsVisible == visible)
			{
				return;
			}
			this.IsVisible = visible;
			this.SetActive(visible);
			XiaKongQteSkillItem skillItem = this.SkillItem;
			if (skillItem == null)
			{
				return;
			}
			skillItem.SetActive(visible);
		}

		// Token: 0x0603EC17 RID: 257047 RVA: 0x01011A74 File Offset: 0x0100FC74
		private void SetClickTipVisible(bool visible)
		{
			if (this.ClickTipVisible == visible)
			{
				return;
			}
			this.ClickTipVisible = visible;
			base.GetTexture(1).SetUIActive(visible);
			XiaKongQteSkillItem skillItem = this.SkillItem;
			if (skillItem != null)
			{
				skillItem.SetEnable(visible);
			}
			if (visible)
			{
				LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
				if (levelSequencePlayer == null)
				{
					return;
				}
				levelSequencePlayer.PlayLevelSequenceByName("Full", false, null, false);
				return;
			}
			else
			{
				LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
				if (levelSequencePlayer2 == null)
				{
					return;
				}
				levelSequencePlayer2.PlayLevelSequenceByName("Use", false, null, false);
				return;
			}
		}

		// Token: 0x04023320 RID: 144160
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x04023321 RID: 144161
		private XiaKongQteSkillItem SkillItem;

		// Token: 0x04023322 RID: 144162
		private SpecialSkillXiaKong SpecialSkill;

		// Token: 0x04023323 RID: 144163
		private bool IsVisible = true;

		// Token: 0x04023324 RID: 144164
		private bool ClickTipVisible;

		// Token: 0x0200C290 RID: 49808
		[NullableContext(0)]
		private enum EChildType
		{
			// Token: 0x0403BFBB RID: 245691
			BarTexture,
			// Token: 0x0403BFBC RID: 245692
			BarLightTexture
		}
	}
}
