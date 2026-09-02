using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RhythmShip.View
{
	// Token: 0x020064FC RID: 25852
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1,
		1
	})]
	public class RhythmShipQuickSelectLevelGirdItemTitleData : MultiTemplateGridDataBase<RhythmShipQuickSelectLevelData, RhythmShipQuickSelectLevelGirdItemTitle>
	{
		// Token: 0x06040B6A RID: 265066 RVA: 0x0109838A File Offset: 0x0109658A
		public RhythmShipQuickSelectLevelGirdItemTitleData(RhythmShipQuickSelectLevelData data)
		{
			base.Data = data;
		}

		// Token: 0x06040B6B RID: 265067 RVA: 0x01098399 File Offset: 0x01096599
		public override int GetTemplateIndex()
		{
			return 0;
		}

		// Token: 0x06040B6C RID: 265068 RVA: 0x0109839C File Offset: 0x0109659C
		public override RhythmShipQuickSelectLevelGirdItemTitle CreateProxy()
		{
			return new RhythmShipQuickSelectLevelGirdItemTitle();
		}

		// Token: 0x0200C512 RID: 50450
		[NullableContext(2)]
		[Nullable(new byte[]
		{
			0,
			1
		})]
		public class RhythmShipQuickSelectLevelGirdItemLevel : SyncGridProxyAbstract<RhythmShipQuickSelectLevelData>
		{
			// Token: 0x0604EB26 RID: 322342 RVA: 0x015DACD1 File Offset: 0x015D8ED1
			protected override void OnRegisterComponent()
			{
				this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
				{
					new ValueTuple<int, Type>(0, typeof(UUIItem))
				};
			}

			// Token: 0x0604EB27 RID: 322343 RVA: 0x015DACF4 File Offset: 0x015D8EF4
			protected override void OnStart()
			{
				this.RhythmShipQuickSelectLevelGirdItemLevelPanel = new RhythmShipQuickSelectLevelGirdItemTitleData.RhythmShipQuickSelectLevelGirdItemLevelPanel();
				this.RhythmShipQuickSelectLevelGirdItemLevelPanel.CreateThenShowByActor(base.GetItem(0).GetOwner(), null);
				this.RhythmShipQuickSelectLevelGirdItemLevelPanel.OnClickButtonCallBack = this.OnClickButtonCallBack;
			}

			// Token: 0x0604EB28 RID: 322344 RVA: 0x015DAD2A File Offset: 0x015D8F2A
			[NullableContext(1)]
			public override void Refresh(RhythmShipQuickSelectLevelData data)
			{
				RhythmShipQuickSelectLevelGirdItemTitleData.RhythmShipQuickSelectLevelGirdItemLevelPanel rhythmShipQuickSelectLevelGirdItemLevelPanel = this.RhythmShipQuickSelectLevelGirdItemLevelPanel;
				if (rhythmShipQuickSelectLevelGirdItemLevelPanel == null)
				{
					return;
				}
				rhythmShipQuickSelectLevelGirdItemLevelPanel.RefreshPanelByLevelId(data.LevelConfig);
			}

			// Token: 0x0403CA89 RID: 248457
			public Action<int> OnClickButtonCallBack;

			// Token: 0x0403CA8A RID: 248458
			private RhythmShipQuickSelectLevelGirdItemTitleData.RhythmShipQuickSelectLevelGirdItemLevelPanel RhythmShipQuickSelectLevelGirdItemLevelPanel;
		}

		// Token: 0x0200C513 RID: 50451
		[Nullable(new byte[]
		{
			0,
			1,
			1
		})]
		public class RhythmShipQuickSelectLevelGirdItemLevelData : MultiTemplateGridDataBase<RhythmShipQuickSelectLevelData, RhythmShipQuickSelectLevelGirdItemTitleData.RhythmShipQuickSelectLevelGirdItemLevel>
		{
			// Token: 0x0604EB2A RID: 322346 RVA: 0x015DAD4A File Offset: 0x015D8F4A
			public RhythmShipQuickSelectLevelGirdItemLevelData(RhythmShipQuickSelectLevelData data)
			{
				base.Data = data;
			}

			// Token: 0x0604EB2B RID: 322347 RVA: 0x015DAD59 File Offset: 0x015D8F59
			public override int GetTemplateIndex()
			{
				return 1;
			}

			// Token: 0x0604EB2C RID: 322348 RVA: 0x015DAD5C File Offset: 0x015D8F5C
			public override RhythmShipQuickSelectLevelGirdItemTitleData.RhythmShipQuickSelectLevelGirdItemLevel CreateProxy()
			{
				return new RhythmShipQuickSelectLevelGirdItemTitleData.RhythmShipQuickSelectLevelGirdItemLevel
				{
					OnClickButtonCallBack = this.OnClickButtonCallBack
				};
			}

			// Token: 0x0403CA8B RID: 248459
			[Nullable(2)]
			public Action<int> OnClickButtonCallBack;
		}

		// Token: 0x0200C514 RID: 50452
		[NullableContext(0)]
		public class RhythmShipQuickSelectLevelGirdItemLevelPanel : UiPanelBase
		{
			// Token: 0x0604EB2D RID: 322349 RVA: 0x015DAD70 File Offset: 0x015D8F70
			protected override void OnRegisterComponent()
			{
				this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
				{
					new ValueTuple<int, Type>(0, typeof(UUITexture)),
					new ValueTuple<int, Type>(1, typeof(UUIArtText)),
					new ValueTuple<int, Type>(2, typeof(UUIItem)),
					new ValueTuple<int, Type>(3, typeof(UUIItem)),
					new ValueTuple<int, Type>(4, typeof(UUIItem)),
					new ValueTuple<int, Type>(5, typeof(UUIText)),
					new ValueTuple<int, Type>(6, typeof(UUIText)),
					new ValueTuple<int, Type>(7, typeof(UUIText)),
					new ValueTuple<int, Type>(8, typeof(UUIButtonComponent)),
					new ValueTuple<int, Type>(9, typeof(UUIItem))
				};
				this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
				{
					new ValueTuple<int, Delegate>(8, new Action(this.OnClickButton))
				};
			}

			// Token: 0x0604EB2E RID: 322350 RVA: 0x015DAE88 File Offset: 0x015D9088
			protected override void OnStart()
			{
				RhythmShipQuickSelectLevelGirdItemTitleData.RhythmShipQuickSelectStarItem rhythmShipQuickSelectStarItem = new RhythmShipQuickSelectLevelGirdItemTitleData.RhythmShipQuickSelectStarItem();
				rhythmShipQuickSelectStarItem.CreateThenShowByActor(base.GetItem(2).GetOwner(), null);
				RhythmShipQuickSelectLevelGirdItemTitleData.RhythmShipQuickSelectStarItem rhythmShipQuickSelectStarItem2 = new RhythmShipQuickSelectLevelGirdItemTitleData.RhythmShipQuickSelectStarItem();
				rhythmShipQuickSelectStarItem2.CreateThenShowByActor(base.GetItem(3).GetOwner(), null);
				RhythmShipQuickSelectLevelGirdItemTitleData.RhythmShipQuickSelectStarItem rhythmShipQuickSelectStarItem3 = new RhythmShipQuickSelectLevelGirdItemTitleData.RhythmShipQuickSelectStarItem();
				rhythmShipQuickSelectStarItem3.CreateThenShowByActor(base.GetItem(4).GetOwner(), null);
				this.StarItemList.AddRange(new RhythmShipQuickSelectLevelGirdItemTitleData.RhythmShipQuickSelectStarItem[]
				{
					rhythmShipQuickSelectStarItem,
					rhythmShipQuickSelectStarItem2,
					rhythmShipQuickSelectStarItem3
				});
			}

			// Token: 0x0604EB2F RID: 322351 RVA: 0x015DAF00 File Offset: 0x015D9100
			public void RefreshPanelByLevelId(int levelId)
			{
				this.LevelId = levelId;
				RhythmShipLevel? rhythmShipLevelById = ConfigBase<RhythmShipConfig>.Instance.GetRhythmShipLevelById(levelId);
				if (rhythmShipLevelById == null)
				{
					return;
				}
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), rhythmShipLevelById.Value.Name, Array.Empty<object>());
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), rhythmShipLevelById.Value.DesName, Array.Empty<object>());
				base.SetTextureByPath(rhythmShipLevelById.Value.IconTexture, base.GetTexture(0), null, null);
				base.GetText(7).SetText(rhythmShipLevelById.Value.TimeText, true);
				base.GetArtText(1).SetText("0" + rhythmShipLevelById.Value.SortNumber.ToString());
				if (ModelBase<RhythmShipModel>.Instance.ActivityData == null)
				{
					return;
				}
				List<int> list;
				ModelBase<RhythmShipModel>.Instance.LevelSubLevelInfoMap.TryGetValue(this.LevelId, out list);
				list = (list ?? new List<int>());
				Dictionary<int, RhythmSubLevelPb> subLevelInfoMapByLevelId = ModelBase<RhythmShipModel>.Instance.GetSubLevelInfoMapByLevelId(levelId);
				for (int i = 0; i < this.StarItemList.Count; i++)
				{
					RhythmShipQuickSelectLevelGirdItemTitleData.RhythmShipQuickSelectStarItem rhythmShipQuickSelectStarItem = this.StarItemList[i];
					bool flag = i < list.Count;
					rhythmShipQuickSelectStarItem.SetUiActive(flag);
					if (flag)
					{
						RhythmSubLevelPb rhythmSubLevelPb = null;
						if (subLevelInfoMapByLevelId != null)
						{
							subLevelInfoMapByLevelId.TryGetValue(list[i], out rhythmSubLevelPb);
						}
						bool light = rhythmSubLevelPb != null && rhythmSubLevelPb.Cleared;
						rhythmShipQuickSelectStarItem.SetLight(light);
					}
				}
				bool levelIsUnlock = ModelBase<RhythmShipModel>.Instance.GetLevelIsUnlock(this.LevelId);
				base.GetItem(9).SetUIActive(!levelIsUnlock);
			}

			// Token: 0x0604EB30 RID: 322352 RVA: 0x015DB0BA File Offset: 0x015D92BA
			private void OnClickButton()
			{
				Action<int> onClickButtonCallBack = this.OnClickButtonCallBack;
				if (onClickButtonCallBack == null)
				{
					return;
				}
				onClickButtonCallBack(this.LevelId);
			}

			// Token: 0x0403CA8C RID: 248460
			[Nullable(2)]
			public Action<int> OnClickButtonCallBack;

			// Token: 0x0403CA8D RID: 248461
			private int LevelId;

			// Token: 0x0403CA8E RID: 248462
			[Nullable(1)]
			private readonly List<RhythmShipQuickSelectLevelGirdItemTitleData.RhythmShipQuickSelectStarItem> StarItemList = new List<RhythmShipQuickSelectLevelGirdItemTitleData.RhythmShipQuickSelectStarItem>();
		}

		// Token: 0x0200C515 RID: 50453
		[NullableContext(0)]
		private class RhythmShipQuickSelectStarItem : UiPanelBase
		{
			// Token: 0x0604EB32 RID: 322354 RVA: 0x015DB0E5 File Offset: 0x015D92E5
			protected override void OnRegisterComponent()
			{
				this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
				{
					new ValueTuple<int, Type>(1, typeof(UUIItem))
				};
			}

			// Token: 0x0604EB33 RID: 322355 RVA: 0x015DB108 File Offset: 0x015D9308
			public void SetLight(bool value)
			{
				base.GetItem(1).SetUIActive(value);
			}
		}
	}
}
