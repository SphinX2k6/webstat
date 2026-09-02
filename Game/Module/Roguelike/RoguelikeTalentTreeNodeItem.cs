using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x020051BD RID: 20925
	[NullableContext(1)]
	[Nullable(0)]
	public class RoguelikeTalentTreeNodeItem : UiPanelBase
	{
		// Token: 0x06035CBE RID: 220350 RVA: 0x00D88114 File Offset: 0x00D86314
		protected unsafe override void OnRegisterComponent()
		{
			int num = 14;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(4, new Action<EToggleState>(this.OnClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06035CBF RID: 220351 RVA: 0x00D8834C File Offset: 0x00D8654C
		protected override void OnStart()
		{
			this.SequencePlayer = new LevelSequencePlayer(this.RootItem);
			base.GetItem(2).SetUIActive(true);
			base.GetItem(0).SetUIActive(false);
			base.GetItem(3).SetUIActive(true);
			base.GetItem(1).SetUIActive(false);
			base.GetItem(10).SetUIActive(true);
			base.GetItem(9).SetUIActive(false);
		}

		// Token: 0x06035CC0 RID: 220352 RVA: 0x00D883BA File Offset: 0x00D865BA
		protected override void OnBeforeShow()
		{
			Singleton<EventSystem>.Instance.Add<int>(EEventName.RoguelikeTalentLevelUp, new Action<int>(this.OnSkillLevelUp));
		}

		// Token: 0x06035CC1 RID: 220353 RVA: 0x00D883D8 File Offset: 0x00D865D8
		protected override void OnBeforeHide()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.RoguelikeTalentLevelUp, new Action<int>(this.OnSkillLevelUp));
		}

		// Token: 0x06035CC2 RID: 220354 RVA: 0x00D883F6 File Offset: 0x00D865F6
		protected override void OnBeforeDestroy()
		{
			if (this.Data != null)
			{
				this.Data.SetNodeToggleState = null;
			}
		}

		// Token: 0x06035CC3 RID: 220355 RVA: 0x00D8840C File Offset: 0x00D8660C
		private void OnSkillLevelUp(int skillId)
		{
			if (this.Data != null)
			{
				this.Refresh(this.Data);
			}
		}

		// Token: 0x06035CC4 RID: 220356 RVA: 0x00D88424 File Offset: 0x00D86624
		public void Refresh(RoguelikeTalentTreeNodeData data)
		{
			this.Data = data;
			this.Data.SetNodeToggleState = new Action<bool, bool>(this.SetToggleState);
			bool isLock = data.State == ETalentTreeNodeState.Lock;
			bool flag = data.State == ETalentTreeNodeState.Unlock;
			bool flag2 = data.State == ETalentTreeNodeState.Active;
			bool flag3 = data.CanAfford();
			this.RefreshIsLock(isLock);
			base.GetItem(11).SetUIActive(flag && flag3);
			base.GetItem(12).SetUIActive(flag && flag3);
			string talentIcon = data.DescConfig.TalentIcon;
			bool flag4 = talentIcon.Contains("Atlas");
			UUITexture texture = base.GetTexture(13);
			texture.SetUIActive(!flag4);
			UUISprite sprite = base.GetSprite(7);
			sprite.SetUIActive(flag4);
			if (flag4)
			{
				UUIItem uuiitem = sprite;
				bool bUseChangeColor = !flag2;
				FColor? fcolor = new FColor?(sprite.changeColor);
				uuiitem.SetChangeColor(bUseChangeColor, fcolor);
				this.SetSpriteByPath(talentIcon, sprite, false, null, null);
			}
			else
			{
				UUIItem uuiitem2 = texture;
				bool bUseChangeColor2 = !flag2;
				FColor? fcolor = new FColor?(texture.changeColor);
				uuiitem2.SetChangeColor(bUseChangeColor2, fcolor);
				base.SetTextureByPath(talentIcon, texture, null, null);
			}
			string sequenceName = flag2 ? "Loop" : "Start1";
			this.SequencePlayer.PlayLevelSequenceByName(sequenceName, false, null, false);
			if (flag2 && !this.NodeUnlockStateCache)
			{
				this.SequencePlayer.PlayLevelSequenceByName("Start2", false, null, false);
			}
			this.NodeUnlockStateCache = flag2;
		}

		// Token: 0x06035CC5 RID: 220357 RVA: 0x00D885A1 File Offset: 0x00D867A1
		private void RefreshIsLock(bool isLock)
		{
			base.GetItem(5).SetUIActive(isLock);
			base.GetItem(6).SetUIActive(!isLock);
		}

		// Token: 0x06035CC6 RID: 220358 RVA: 0x00D885C0 File Offset: 0x00D867C0
		public UUIItem GetUpLine()
		{
			return base.GetItem(2);
		}

		// Token: 0x06035CC7 RID: 220359 RVA: 0x00D885C9 File Offset: 0x00D867C9
		public UUIItem GetDownLine()
		{
			return base.GetItem(3);
		}

		// Token: 0x06035CC8 RID: 220360 RVA: 0x00D885D2 File Offset: 0x00D867D2
		public UUIItem GetMidLine()
		{
			return base.GetItem(10);
		}

		// Token: 0x06035CC9 RID: 220361 RVA: 0x00D885DC File Offset: 0x00D867DC
		public unsafe List<UUIItem> GetAllLines()
		{
			int num = 3;
			List<UUIItem> list = new List<UUIItem>(num);
			CollectionsMarshal.SetCount<UUIItem>(list, num);
			Span<UUIItem> span = CollectionsMarshal.AsSpan<UUIItem>(list);
			int num2 = 0;
			*span[num2] = base.GetItem(2);
			num2++;
			*span[num2] = base.GetItem(3);
			num2++;
			*span[num2] = base.GetItem(10);
			return list;
		}

		// Token: 0x06035CCA RID: 220362 RVA: 0x00D8863A File Offset: 0x00D8683A
		public void SetNodeActive(bool isActive)
		{
			base.GetItem(8).SetUIActive(isActive);
		}

		// Token: 0x06035CCB RID: 220363 RVA: 0x00D88649 File Offset: 0x00D86849
		private void OnClick(EToggleState toggleState)
		{
			if (this.Data != null)
			{
				Action<bool, RoguelikeTalentTreeNodeData> onClickNode = ModelBase<RoguelikeModel>.Instance.GetTalentTreeViewModel().OnClickNode;
				if (onClickNode == null)
				{
					return;
				}
				onClickNode(toggleState == EToggleState.ETT_Checked, this.Data);
			}
		}

		// Token: 0x06035CCC RID: 220364 RVA: 0x00D88676 File Offset: 0x00D86876
		private void SetToggleState(bool isSelected, bool bFireEvent)
		{
			base.GetExtendToggle(4).SetToggleState(isSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, bFireEvent, false, false);
		}

		// Token: 0x0401EDC3 RID: 126403
		[Nullable(2)]
		private RoguelikeTalentTreeNodeData Data;

		// Token: 0x0401EDC4 RID: 126404
		[Nullable(2)]
		private LevelSequencePlayer SequencePlayer;

		// Token: 0x0401EDC5 RID: 126405
		private bool NodeUnlockStateCache = true;

		// Token: 0x0200B1A2 RID: 45474
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x04037170 RID: 225648
			public const int ItemDashedLineUp = 0;

			// Token: 0x04037171 RID: 225649
			public const int ItemDashedLineDown = 1;

			// Token: 0x04037172 RID: 225650
			public const int ItemSolidLineUp = 2;

			// Token: 0x04037173 RID: 225651
			public const int ItemSolidLineDown = 3;

			// Token: 0x04037174 RID: 225652
			public const int Toggle = 4;

			// Token: 0x04037175 RID: 225653
			public const int ItemLock = 5;

			// Token: 0x04037176 RID: 225654
			public const int ItemUnlock = 6;

			// Token: 0x04037177 RID: 225655
			public const int SpriteIcon = 7;

			// Token: 0x04037178 RID: 225656
			public const int ItemNode = 8;

			// Token: 0x04037179 RID: 225657
			public const int ItemMidLineDashed = 9;

			// Token: 0x0403717A RID: 225658
			public const int ItemMidLineSolid = 10;

			// Token: 0x0403717B RID: 225659
			public const int ItemLevelUpIcon = 11;

			// Token: 0x0403717C RID: 225660
			public const int ItemLoopAnim = 12;

			// Token: 0x0403717D RID: 225661
			public const int TexIcon = 13;
		}
	}
}
