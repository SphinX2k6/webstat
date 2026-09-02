using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x0200646B RID: 25707
	[NullableContext(1)]
	[Nullable(0)]
	public class RoverlikeTalentTreeNodeItem : UiPanelBase
	{
		// Token: 0x17009E43 RID: 40515
		// (get) Token: 0x060407BC RID: 264124 RVA: 0x0108666E File Offset: 0x0108486E
		[Nullable(2)]
		private RoverlikeTalentTreeData TreeData
		{
			[NullableContext(2)]
			get
			{
				RoverlikeActivityData currentActivityData = ControllerBase<RoverlikeActivityController>.Instance.GetCurrentActivityData();
				if (currentActivityData == null)
				{
					return null;
				}
				return currentActivityData.TalentTreeData;
			}
		}

		// Token: 0x060407BD RID: 264125 RVA: 0x01086688 File Offset: 0x01084888
		protected unsafe override void OnRegisterComponent()
		{
			int num = 17;
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
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(16, typeof(UUISprite));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(4, new Action<EToggleState>(this.OnClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x060407BE RID: 264126 RVA: 0x01086928 File Offset: 0x01084B28
		protected override void OnStart()
		{
			base.GetItem(2).SetUIActive(true);
			base.GetItem(0).SetUIActive(false);
			base.GetItem(3).SetUIActive(true);
			base.GetItem(1).SetUIActive(false);
			base.GetItem(10).SetUIActive(true);
			base.GetItem(9).SetUIActive(false);
		}

		// Token: 0x060407BF RID: 264127 RVA: 0x01086985 File Offset: 0x01084B85
		protected override void OnBeforeDestroy()
		{
			if (this.Data != null)
			{
				this.Data.SetNodeToggleState = null;
			}
		}

		// Token: 0x060407C0 RID: 264128 RVA: 0x0108699C File Offset: 0x01084B9C
		public void Refresh(RoverlikeTalentNodeData data)
		{
			this.Data = data;
			this.Data.SetNodeToggleState = new Action<bool, bool>(this.SetToggleState);
			bool flag = data.State == ERoverlikeTalentNodeState.Lock;
			RoverlikeTalentTreeData treeData = this.TreeData;
			bool uiactive = treeData != null && treeData.IsTalentCanUnlock(data);
			base.GetItem(5).SetUIActive(flag);
			base.GetItem(6).SetUIActive(!flag);
			UUIItem item = base.GetItem(11);
			if (item != null)
			{
				item.SetUIActive(uiactive);
			}
			UUIItem item2 = base.GetItem(12);
			if (item2 != null)
			{
				item2.SetUIActive(uiactive);
			}
			UUIText text = base.GetText(14);
			if (text != null)
			{
				text.SetUIActive(!flag);
			}
			if (!flag && text != null)
			{
				UUIText uuitext = text;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
				defaultInterpolatedStringHandler.AppendFormatted<int>(data.CurLevel);
				defaultInterpolatedStringHandler.AppendLiteral("/");
				defaultInterpolatedStringHandler.AppendFormatted<int>(data.MaxLevel);
				uuitext.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			}
			RoverRogueTalentTree? roverRogueTalentTree;
			string iconPath = ((data.CurrentLevelConfig != null) ? roverRogueTalentTree.GetValueOrDefault().Icon : null) ?? data.HeadConfig.Icon;
			this.RefreshIcon(iconPath, flag, 13, 7);
			this.RefreshIcon(iconPath, flag, 15, 16);
		}

		// Token: 0x060407C1 RID: 264129 RVA: 0x01086AD4 File Offset: 0x01084CD4
		private void RefreshIcon(string iconPath, bool isLock, int texIndex, int sprIndex)
		{
			bool flag = iconPath.Contains("Atlas");
			UUITexture texture = base.GetTexture(texIndex);
			texture.SetUIActive(!flag);
			UUISprite sprite = base.GetSprite(sprIndex);
			sprite.SetUIActive(flag);
			if (flag)
			{
				this.SetSpriteByPath(iconPath, sprite, false, null, null);
				return;
			}
			base.SetTextureByPath(iconPath, texture, null, null);
		}

		// Token: 0x060407C2 RID: 264130 RVA: 0x01086B38 File Offset: 0x01084D38
		public UUIItem GetUpSolidLine()
		{
			return base.GetItem(2);
		}

		// Token: 0x060407C3 RID: 264131 RVA: 0x01086B41 File Offset: 0x01084D41
		public UUIItem GetUpDashedLine()
		{
			return base.GetItem(0);
		}

		// Token: 0x060407C4 RID: 264132 RVA: 0x01086B4A File Offset: 0x01084D4A
		public UUIItem GetDownSolidLine()
		{
			return base.GetItem(3);
		}

		// Token: 0x060407C5 RID: 264133 RVA: 0x01086B53 File Offset: 0x01084D53
		public UUIItem GetDownDashedLine()
		{
			return base.GetItem(1);
		}

		// Token: 0x060407C6 RID: 264134 RVA: 0x01086B5C File Offset: 0x01084D5C
		public UUIItem GetMidSolidLine()
		{
			return base.GetItem(10);
		}

		// Token: 0x060407C7 RID: 264135 RVA: 0x01086B66 File Offset: 0x01084D66
		public UUIItem GetMidDashedLine()
		{
			return base.GetItem(9);
		}

		// Token: 0x060407C8 RID: 264136 RVA: 0x01086B70 File Offset: 0x01084D70
		public List<UUIItem> GetAllLines()
		{
			return new List<UUIItem>
			{
				base.GetItem(2),
				base.GetItem(0),
				base.GetItem(3),
				base.GetItem(1),
				base.GetItem(10),
				base.GetItem(9)
			};
		}

		// Token: 0x060407C9 RID: 264137 RVA: 0x01086BD2 File Offset: 0x01084DD2
		public void SetNodeActive(bool isActive)
		{
			base.GetItem(8).SetUIActive(isActive);
		}

		// Token: 0x060407CA RID: 264138 RVA: 0x01086BE1 File Offset: 0x01084DE1
		public void SetItemVisible(bool visible)
		{
			UUIItem rootItem = this.RootItem;
			if (rootItem == null)
			{
				return;
			}
			rootItem.SetUIActive(visible);
		}

		// Token: 0x060407CB RID: 264139 RVA: 0x01086BF4 File Offset: 0x01084DF4
		private void OnClick(EToggleState toggleState)
		{
			if (this.Data != null)
			{
				RoverlikeTalentTreeData treeData = this.TreeData;
				if (treeData == null)
				{
					return;
				}
				Action<bool, RoverlikeTalentNodeData> onClickNode = treeData.OnClickNode;
				if (onClickNode == null)
				{
					return;
				}
				onClickNode(toggleState == EToggleState.ETT_Checked, this.Data);
			}
		}

		// Token: 0x060407CC RID: 264140 RVA: 0x01086C22 File Offset: 0x01084E22
		private void SetToggleState(bool isSelected, bool bFireEvent)
		{
			base.GetExtendToggle(4).SetToggleState(isSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, bFireEvent, false, false);
		}

		// Token: 0x04024194 RID: 147860
		[Nullable(2)]
		private RoverlikeTalentNodeData Data;

		// Token: 0x0200C4C4 RID: 50372
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x0403C924 RID: 248100
			public const int SprDashedLineUp = 0;

			// Token: 0x0403C925 RID: 248101
			public const int SprDashedLineDown = 1;

			// Token: 0x0403C926 RID: 248102
			public const int SprSolidLineUp = 2;

			// Token: 0x0403C927 RID: 248103
			public const int SprSolidLineDown = 3;

			// Token: 0x0403C928 RID: 248104
			public const int TogSkill = 4;

			// Token: 0x0403C929 RID: 248105
			public const int PnlLock = 5;

			// Token: 0x0403C92A RID: 248106
			public const int SprUnlock = 6;

			// Token: 0x0403C92B RID: 248107
			public const int SprIcon = 7;

			// Token: 0x0403C92C RID: 248108
			public const int PnlTog = 8;

			// Token: 0x0403C92D RID: 248109
			public const int SprMidLineDashed = 9;

			// Token: 0x0403C92E RID: 248110
			public const int SprMidLineSolid = 10;

			// Token: 0x0403C92F RID: 248111
			public const int SprUpgradeHint = 11;

			// Token: 0x0403C930 RID: 248112
			public const int PnlAni = 12;

			// Token: 0x0403C931 RID: 248113
			public const int TexIcon = 13;

			// Token: 0x0403C932 RID: 248114
			public const int TxtLevel = 14;

			// Token: 0x0403C933 RID: 248115
			public const int TexIcon1 = 15;

			// Token: 0x0403C934 RID: 248116
			public const int SprIcon1 = 16;
		}
	}
}
