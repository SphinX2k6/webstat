using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004E53 RID: 20051
	[NullableContext(1)]
	[Nullable(0)]
	public class TrapDefenseTalentTreeNodeItem : UiPanelBase
	{
		// Token: 0x06033D07 RID: 212231 RVA: 0x00CF4738 File Offset: 0x00CF2938
		protected unsafe override void OnRegisterComponent()
		{
			int num = 13;
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
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(4, new Action<EToggleState>(this.OnClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06033D08 RID: 212232 RVA: 0x00CF494E File Offset: 0x00CF2B4E
		protected override void OnStart()
		{
			ModelBase<TrapDefenseModel>.Instance.ViewModelTalentTree.AddDelegateOnNodeSelect(new Action<TrapDefenseTalentTreeNodeData, bool>(this.OnSelectedNodeChange));
			this.SeqPlayer = new LevelSequencePlayer(this.RootItem);
		}

		// Token: 0x06033D09 RID: 212233 RVA: 0x00CF497C File Offset: 0x00CF2B7C
		protected override void OnBeforeDestroy()
		{
			ModelBase<TrapDefenseModel>.Instance.ViewModelTalentTree.RemoveDelegateOnNodeSelect(new Action<TrapDefenseTalentTreeNodeData, bool>(this.OnSelectedNodeChange));
		}

		// Token: 0x06033D0A RID: 212234 RVA: 0x00CF499C File Offset: 0x00CF2B9C
		public void Refresh(TrapDefenseTalentTreeNodeData data)
		{
			this.Data = data;
			base.GetItem(5).SetUIActive(!data.IsUnlock);
			base.GetItem(6).SetUIActive(this.Data.IsUnlock);
			bool flag = ModelBase<TrapDefenseModel>.Instance.TalentTreeData.CanNodeUnlock(this.Data);
			bool flag2 = ModelBase<TrapDefenseModel>.Instance.TalentTreeData.CanNodeAfford(this.Data);
			base.GetItem(11).SetUIActive(flag && flag2 && !data.IsUnlock);
			base.GetItem(12).SetUIActive(flag && flag2 && !data.IsUnlock);
			UUISprite sprite = base.GetSprite(7);
			UUIItem uuiitem = sprite;
			bool bUseChangeColor = !data.IsUnlock;
			FColor? fcolor = new FColor?(sprite.changeColor);
			uuiitem.SetChangeColor(bUseChangeColor, fcolor);
			this.SetSpriteByPath(data.Icon, sprite, false, null, null);
			string sequenceName = data.IsUnlock ? "Loop" : "Start1";
			this.SeqPlayer.PlayLevelSequenceByName(sequenceName, false, null, false);
			if (data.IsUnlock && !this.NodeUnlockStateCache)
			{
				this.SeqPlayer.PlayLevelSequenceByName("Start2", false, null, false);
			}
			this.NodeUnlockStateCache = data.IsUnlock;
		}

		// Token: 0x06033D0B RID: 212235 RVA: 0x00CF4AE8 File Offset: 0x00CF2CE8
		[return: Nullable(new byte[]
		{
			0,
			1,
			1
		})]
		public ValueTuple<UUIItem, UUIItem> GetUpLines()
		{
			return new ValueTuple<UUIItem, UUIItem>(base.GetItem(2), base.GetItem(0));
		}

		// Token: 0x06033D0C RID: 212236 RVA: 0x00CF4AFD File Offset: 0x00CF2CFD
		[return: Nullable(new byte[]
		{
			0,
			1,
			1
		})]
		public ValueTuple<UUIItem, UUIItem> GetDownLines()
		{
			return new ValueTuple<UUIItem, UUIItem>(base.GetItem(3), base.GetItem(1));
		}

		// Token: 0x06033D0D RID: 212237 RVA: 0x00CF4B12 File Offset: 0x00CF2D12
		[return: Nullable(new byte[]
		{
			0,
			1,
			1
		})]
		public ValueTuple<UUIItem, UUIItem> GetMidLines()
		{
			return new ValueTuple<UUIItem, UUIItem>(base.GetItem(10), base.GetItem(9));
		}

		// Token: 0x06033D0E RID: 212238 RVA: 0x00CF4B2C File Offset: 0x00CF2D2C
		public UUIItem[] GetAllLines()
		{
			return new UUIItem[]
			{
				base.GetItem(2),
				base.GetItem(0),
				base.GetItem(3),
				base.GetItem(1),
				base.GetItem(9),
				base.GetItem(10)
			};
		}

		// Token: 0x06033D0F RID: 212239 RVA: 0x00CF4B7D File Offset: 0x00CF2D7D
		public void SetNodeActive(bool isActive)
		{
			base.GetItem(8).SetUIActive(isActive);
		}

		// Token: 0x06033D10 RID: 212240 RVA: 0x00CF4B8C File Offset: 0x00CF2D8C
		private void OnClick(EToggleState state)
		{
			ModelBase<TrapDefenseModel>.Instance.ViewModelTalentTree.SelectNode(this.Data, false);
		}

		// Token: 0x06033D11 RID: 212241 RVA: 0x00CF4BA4 File Offset: 0x00CF2DA4
		private void OnSelectedNodeChange(TrapDefenseTalentTreeNodeData node, bool _)
		{
			if (node == this.Data)
			{
				base.GetExtendToggle(4).SetToggleState(EToggleState.ETT_Checked, false, false, false);
				return;
			}
			base.GetExtendToggle(4).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		}

		// Token: 0x0401DFAA RID: 122794
		private TrapDefenseTalentTreeNodeData Data;

		// Token: 0x0401DFAB RID: 122795
		private LevelSequencePlayer SeqPlayer;

		// Token: 0x0401DFAC RID: 122796
		private bool NodeUnlockStateCache = true;

		// Token: 0x0200ADF0 RID: 44528
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x04036034 RID: 221236
			public const int ItemDashedLineUp = 0;

			// Token: 0x04036035 RID: 221237
			public const int ItemDashedLineDown = 1;

			// Token: 0x04036036 RID: 221238
			public const int ItemSolidLineUp = 2;

			// Token: 0x04036037 RID: 221239
			public const int ItemSolidLineDown = 3;

			// Token: 0x04036038 RID: 221240
			public const int Toggle = 4;

			// Token: 0x04036039 RID: 221241
			public const int ItemLock = 5;

			// Token: 0x0403603A RID: 221242
			public const int ItemUnlock = 6;

			// Token: 0x0403603B RID: 221243
			public const int SpriteIcon = 7;

			// Token: 0x0403603C RID: 221244
			public const int ItemNode = 8;

			// Token: 0x0403603D RID: 221245
			public const int ItemMidLineDashed = 9;

			// Token: 0x0403603E RID: 221246
			public const int ItemMidLineSolid = 10;

			// Token: 0x0403603F RID: 221247
			public const int ItemLevelUpIcon = 11;

			// Token: 0x04036040 RID: 221248
			public const int ItemLoopAnim = 12;
		}
	}
}
