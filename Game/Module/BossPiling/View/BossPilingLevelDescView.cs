using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.BossPiling.View
{
	// Token: 0x02005EF5 RID: 24309
	[NullableContext(1)]
	[Nullable(0)]
	public class BossPilingLevelDescView : UiViewBase
	{
		// Token: 0x0603D11D RID: 250141 RVA: 0x00F81C94 File Offset: 0x00F7FE94
		public BossPilingLevelDescView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x0603D11E RID: 250142 RVA: 0x00F81CB0 File Offset: 0x00F7FEB0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIGridLayout));
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action<EToggleState>(this.OnClickedFirst));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(2, new Action<EToggleState>(this.OnClickedSecond));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603D11F RID: 250143 RVA: 0x00F81E00 File Offset: 0x00F80000
		protected override void OnStart()
		{
			this.LevelSequence = new LevelSequencePlayer(base.GetRootItem());
			BossPilingLevelDetailInfo bossPilingLevelDetailInfo = this.OpenParam as BossPilingLevelDetailInfo;
			this.IsFirst = bossPilingLevelDetailInfo.IsFirst;
			this.LevelInfo = bossPilingLevelDetailInfo.LevelList;
			this.CaptionItem = new PopupCaptionItem(base.GetItem(0));
			this.CaptionItem.SetCloseCallBack(delegate
			{
				base.CloseMe(null);
			});
			this.CaptionItem.SetHelpBtnActive(false);
			this.Layout = new GenericLayout<ShipTowerMonsterInfoItem, ShipTowerMonsterInfoItemData>(base.GetGridLayout(5), new Func<ShipTowerMonsterInfoItem>(this.CreateItem), null, false, true);
			if (this.IsFirst)
			{
				UUIExtendToggle extendToggle = base.GetExtendToggle(1);
				if (extendToggle != null)
				{
					extendToggle.SetToggleState(EToggleState.ETT_Checked, false, false, false);
				}
			}
			else
			{
				UUIExtendToggle extendToggle2 = base.GetExtendToggle(2);
				if (extendToggle2 != null)
				{
					extendToggle2.SetToggleState(EToggleState.ETT_Checked, false, false, false);
				}
			}
			this.RefreshPanel();
		}

		// Token: 0x0603D120 RID: 250144 RVA: 0x00F81ED8 File Offset: 0x00F800D8
		protected void RefreshPanel()
		{
			this.LevelSequence.PlayOrReplaySequenceByName("Switch", false, null);
			BossPilingLevelDescInfo bossPilingLevelDescInfo = this.IsFirst ? this.LevelInfo[0] : this.LevelInfo[1];
			string key = StringUtils.IsBlank(bossPilingLevelDescInfo.MonsterDesc) ? "BossPilingActivity_DungeonDetail17" : bossPilingLevelDescInfo.MonsterDesc;
			UUIText text = base.GetText(3);
			if (text != null)
			{
				text.ShowTextNew(key);
			}
			string key2 = StringUtils.IsBlank(bossPilingLevelDescInfo.LevelDesc) ? "BossPilingActivity_DungeonDetail17" : bossPilingLevelDescInfo.LevelDesc;
			UUIText text2 = base.GetText(4);
			if (text2 != null)
			{
				text2.ShowTextNew(key2);
			}
			this.RefreshLayout();
		}

		// Token: 0x0603D121 RID: 250145 RVA: 0x00F81F84 File Offset: 0x00F80184
		protected void RefreshLayout()
		{
			BossPilingLevelDescInfo bossPilingLevelDescInfo = this.IsFirst ? this.LevelInfo[0] : this.LevelInfo[1];
			InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(bossPilingLevelDescInfo.LevelId);
			List<ShipTowerMonsterInfoItemData> list = new List<ShipTowerMonsterInfoItemData>();
			foreach (int monsterId in config.Value.MonsterPreviewIter())
			{
				MonsterInfo? monsterInfoConfig = ConfigBase<MonsterInfoConfig>.Instance.GetMonsterInfoConfig(monsterId);
				ShipTowerMonsterInfoItemData item = new ShipTowerMonsterInfoItemData
				{
					Title = (monsterInfoConfig.Value.Name ?? ""),
					Level = config.Value.EntityLevel,
					MonsterIcon = monsterInfoConfig.Value.Icon,
					ElementList = (((monsterInfoConfig != null) ? monsterInfoConfig.GetValueOrDefault().ElementIdArray().ToList<int>() : null) ?? new List<int>())
				};
				list.Add(item);
			}
			this.Layout.RefreshByData(list, null, true);
		}

		// Token: 0x0603D122 RID: 250146 RVA: 0x00F820BC File Offset: 0x00F802BC
		private void OnClickedFirst(EToggleState state)
		{
			this.IsFirst = true;
			this.RefreshPanel();
		}

		// Token: 0x0603D123 RID: 250147 RVA: 0x00F820CB File Offset: 0x00F802CB
		private void OnClickedSecond(EToggleState state)
		{
			this.IsFirst = false;
			this.RefreshPanel();
		}

		// Token: 0x0603D124 RID: 250148 RVA: 0x00F820DA File Offset: 0x00F802DA
		private ShipTowerMonsterInfoItem CreateItem()
		{
			return new ShipTowerMonsterInfoItem();
		}

		// Token: 0x04022414 RID: 140308
		protected List<BossPilingLevelDescInfo> LevelInfo = new List<BossPilingLevelDescInfo>();

		// Token: 0x04022415 RID: 140309
		protected bool IsFirst = true;

		// Token: 0x04022416 RID: 140310
		protected PopupCaptionItem CaptionItem;

		// Token: 0x04022417 RID: 140311
		protected GenericLayout<ShipTowerMonsterInfoItem, ShipTowerMonsterInfoItemData> Layout;

		// Token: 0x04022418 RID: 140312
		protected LevelSequencePlayer LevelSequence;

		// Token: 0x0200BEEA RID: 48874
		[NullableContext(0)]
		private enum EDefine
		{
			// Token: 0x0403AC13 RID: 240659
			CaptionItem,
			// Token: 0x0403AC14 RID: 240660
			Toggle1,
			// Token: 0x0403AC15 RID: 240661
			Toggle2,
			// Token: 0x0403AC16 RID: 240662
			MonsterDesc,
			// Token: 0x0403AC17 RID: 240663
			LevelDesc,
			// Token: 0x0403AC18 RID: 240664
			Layout
		}
	}
}
