using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.FlagChallenge
{
	// Token: 0x02005D47 RID: 23879
	[NullableContext(1)]
	[Nullable(0)]
	public class FlagChallengeAreaDetailView : UiViewBase
	{
		// Token: 0x1700989C RID: 39068
		// (get) Token: 0x0603C338 RID: 246584 RVA: 0x00F44B81 File Offset: 0x00F42D81
		[Nullable(2)]
		public new FlagChallengeAreaDetailViewParams OpenParam
		{
			[NullableContext(2)]
			get
			{
				return this.OpenParam as FlagChallengeAreaDetailViewParams;
			}
		}

		// Token: 0x0603C339 RID: 246585 RVA: 0x00F44B90 File Offset: 0x00F42D90
		public FlagChallengeAreaDetailView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603C33A RID: 246586 RVA: 0x00F44CD4 File Offset: 0x00F42ED4
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUITexture)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUIItem)),
				new ValueTuple<int, Type>(8, typeof(UUITexture)),
				new ValueTuple<int, Type>(9, typeof(UUITexture)),
				new ValueTuple<int, Type>(10, typeof(UUIItem)),
				new ValueTuple<int, Type>(11, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(12, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(13, typeof(UUIItem)),
				new ValueTuple<int, Type>(14, typeof(UUITexture)),
				new ValueTuple<int, Type>(15, typeof(UUITexture)),
				new ValueTuple<int, Type>(16, typeof(UUIItem)),
				new ValueTuple<int, Type>(17, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(18, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(19, typeof(UUIHorizontalLayout)),
				new ValueTuple<int, Type>(20, typeof(UUIItem)),
				new ValueTuple<int, Type>(21, typeof(UUISprite)),
				new ValueTuple<int, Type>(22, typeof(UUIItem)),
				new ValueTuple<int, Type>(23, typeof(UUIItem)),
				new ValueTuple<int, Type>(24, typeof(UUIItem)),
				new ValueTuple<int, Type>(25, typeof(UUIText)),
				new ValueTuple<int, Type>(26, typeof(UUIItem)),
				new ValueTuple<int, Type>(27, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(11, new Action(this.OnBuffButtonClick)),
				new ValueTuple<int, Delegate>(12, new Action(this.OnTaskButtonClick)),
				new ValueTuple<int, Delegate>(17, new Action(this.OnLeftPageButtonClick)),
				new ValueTuple<int, Delegate>(18, new Action(this.OnRightPageButtonClick))
			};
		}

		// Token: 0x0603C33B RID: 246587 RVA: 0x00F44FD8 File Offset: 0x00F431D8
		protected override UniTask OnBeforeStartAsync()
		{
			FlagChallengeAreaDetailView.<OnBeforeStartAsync>d__22 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<FlagChallengeAreaDetailView.<OnBeforeStartAsync>d__22>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603C33C RID: 246588 RVA: 0x00F4501C File Offset: 0x00F4321C
		protected override void OnStart()
		{
			EFlagChallengeUiStyleType uiStyle = this.Data.GetLevelData(this.LevelId).GetUiStyle();
			base.GetTexture(9).SetColor(FColor.FromHex(this.gridColor[uiStyle]));
			base.GetTexture(8).SetColor(FColor.FromHex(this.centerBgColor[uiStyle]));
			base.GetTexture(14).SetColor(FColor.FromHex(this.bgColor[uiStyle]));
			Dictionary<string, string> dictionary;
			if (!Singleton<FlagChallengeDefine>.Instance.flagChallengeStyleRes.TryGetValue(uiStyle, out dictionary))
			{
				return;
			}
			base.SetTextureByPath(ConfigBase<UiResourceConfig>.Instance.GetResourcePath(dictionary["LevelSetOffLight"]), base.GetTexture(15), null, null);
			base.SetTextureByPath(ConfigBase<UiResourceConfig>.Instance.GetResourcePath(dictionary["MaskBg"]), base.GetTexture(1), null, null);
			this.SetStrongholdSelect(this.SelectStrongholdId);
			this.LevelInfoItem.RefreshView();
			this.RefreshTaskView();
			ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.RedDotFlagChallengeActivityReward, base.GetItem(26), null, this.ActivityId);
			ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.RedDotFlagChallengeActivityBuffNewlyUnlocked, base.GetItem(27), null, this.ActivityId);
		}

		// Token: 0x0603C33D RID: 246589 RVA: 0x00F45160 File Offset: 0x00F43360
		protected override void OnBeforeDestroy()
		{
			ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.RedDotFlagChallengeActivityReward, base.GetItem(26), this.ActivityId);
			ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.RedDotFlagChallengeActivityBuffNewlyUnlocked, base.GetItem(27), this.ActivityId);
		}

		// Token: 0x0603C33E RID: 246590 RVA: 0x00F4519C File Offset: 0x00F4339C
		private void InitViewData()
		{
			FlagChallengeAreaDetailViewParams openParam = this.OpenParam;
			this.ActivityId = openParam.ActivityId;
			this.LevelId = openParam.LevelId;
			this.AreaId = openParam.AreaId;
			this.Data = ModelBase<FlagChallengeModel>.Instance.GetFlagChallengeData(this.ActivityId);
			this.AreaDataList = this.Data.GetLevelAreaDataList(this.LevelId);
			this.SelectStrongholdId = openParam.StrongholdId;
		}

		// Token: 0x0603C33F RID: 246591 RVA: 0x00F45210 File Offset: 0x00F43410
		private UniTask InitStrongholdViewAsync()
		{
			FlagChallengeAreaDetailView.<InitStrongholdViewAsync>d__26 <InitStrongholdViewAsync>d__;
			<InitStrongholdViewAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitStrongholdViewAsync>d__.<>4__this = this;
			<InitStrongholdViewAsync>d__.<>1__state = -1;
			<InitStrongholdViewAsync>d__.<>t__builder.Start<FlagChallengeAreaDetailView.<InitStrongholdViewAsync>d__26>(ref <InitStrongholdViewAsync>d__);
			return <InitStrongholdViewAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603C340 RID: 246592 RVA: 0x00F45254 File Offset: 0x00F43454
		private void InitPageView()
		{
			if (this.AreaDataList.Count <= 1)
			{
				base.GetItem(16).SetUIActive(false);
				return;
			}
			base.GetItem(16).SetUIActive(true);
			this.DotLayout = new GenericLayout<FlagChallengeAreaPageDotItem, IFlagChallengeAreaPageDotItemData>(base.GetHorizontalLayout(19), new Func<FlagChallengeAreaPageDotItem>(this.CreatePageDotItem), null, false, true);
		}

		// Token: 0x0603C341 RID: 246593 RVA: 0x00F452AE File Offset: 0x00F434AE
		private void RefreshTaskView()
		{
			UUIText text = base.GetText(25);
			if (text == null)
			{
				return;
			}
			text.SetText(this.Data.GetTaskProgressText(), true);
		}

		// Token: 0x0603C342 RID: 246594 RVA: 0x00F452D0 File Offset: 0x00F434D0
		private void RefreshStrongholdPanel(int id)
		{
			this.StrongholdPanel.SetUiActive(true);
			this.StrongholdPanel.RefreshView(id);
			FlagChallengeStrongholdData strongholdData = ModelBase<FlagChallengeModel>.Instance.GetStrongholdData(id);
			int totalLevel = ModelBase<FlagChallengeModel>.Instance.GetTotalLevel(this.ActivityId);
			base.GetItem(13).SetUIActive(!strongholdData.IsPass && totalLevel < strongholdData.StrongholdConfig.RecommendLevel);
			this.SequencePlayer.StopCurrentSequenceByName("Switch", false, true);
			this.SequencePlayer.PlayOrReplaySequenceByName("Switch", false, null);
		}

		// Token: 0x0603C343 RID: 246595 RVA: 0x00F45364 File Offset: 0x00F43564
		private void SetStrongholdSelect(int? strongholdId)
		{
			if (strongholdId != null)
			{
				this.StrongholdContainer.SetItemSelect(strongholdId.Value);
			}
			else
			{
				this.StrongholdPanel.SetUiActive(false);
			}
			this.SelectStrongholdId = strongholdId;
		}

		// Token: 0x0603C344 RID: 246596 RVA: 0x00F45398 File Offset: 0x00F43598
		private UniTask RefreshStrongholdViewAsync(int areaId)
		{
			FlagChallengeAreaDetailView.<RefreshStrongholdViewAsync>d__31 <RefreshStrongholdViewAsync>d__;
			<RefreshStrongholdViewAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshStrongholdViewAsync>d__.<>4__this = this;
			<RefreshStrongholdViewAsync>d__.areaId = areaId;
			<RefreshStrongholdViewAsync>d__.<>1__state = -1;
			<RefreshStrongholdViewAsync>d__.<>t__builder.Start<FlagChallengeAreaDetailView.<RefreshStrongholdViewAsync>d__31>(ref <RefreshStrongholdViewAsync>d__);
			return <RefreshStrongholdViewAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603C345 RID: 246597 RVA: 0x00F453E4 File Offset: 0x00F435E4
		private void RefreshPageView(int areaId)
		{
			if (this.DotLayout == null)
			{
				return;
			}
			List<IFlagChallengeAreaPageDotItemData> list = new List<IFlagChallengeAreaPageDotItemData>();
			foreach (FlagChallengeAreaData flagChallengeAreaData in this.AreaDataList)
			{
				list.Add(new FlagChallengeAreaPageDotItemData
				{
					IsHighlight = (flagChallengeAreaData.Id == areaId)
				});
			}
			this.DotLayout.RefreshByData(list, null, false);
		}

		// Token: 0x0603C346 RID: 246598 RVA: 0x00F45468 File Offset: 0x00F43668
		private UniTask SwitchAreaAsync(int areaId)
		{
			FlagChallengeAreaDetailView.<SwitchAreaAsync>d__33 <SwitchAreaAsync>d__;
			<SwitchAreaAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<SwitchAreaAsync>d__.<>4__this = this;
			<SwitchAreaAsync>d__.areaId = areaId;
			<SwitchAreaAsync>d__.<>1__state = -1;
			<SwitchAreaAsync>d__.<>t__builder.Start<FlagChallengeAreaDetailView.<SwitchAreaAsync>d__33>(ref <SwitchAreaAsync>d__);
			return <SwitchAreaAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603C347 RID: 246599 RVA: 0x00F454B3 File Offset: 0x00F436B3
		private FlagChallengeAreaPageDotItem CreatePageDotItem()
		{
			return new FlagChallengeAreaPageDotItem();
		}

		// Token: 0x0603C348 RID: 246600 RVA: 0x00F454BA File Offset: 0x00F436BA
		private void OnCloseClick()
		{
			base.CloseMe(null);
		}

		// Token: 0x0603C349 RID: 246601 RVA: 0x00F454C4 File Offset: 0x00F436C4
		private void OnHelpClick()
		{
			int areaDetailViewHelpId = ConfigBase<FlagChallengeConfig>.Instance.GetAreaDetailViewHelpId();
			ControllerBase<HelpController>.Instance.OpenHelpById(areaDetailViewHelpId);
		}

		// Token: 0x0603C34A RID: 246602 RVA: 0x00F454E8 File Offset: 0x00F436E8
		private void OnBuffButtonClick()
		{
			ControllerBase<FlagChallengeController>.Instance.OpenFlagChallengeBuffView(this.ActivityId, null);
		}

		// Token: 0x0603C34B RID: 246603 RVA: 0x00F4550E File Offset: 0x00F4370E
		private void OnTaskButtonClick()
		{
			ControllerBase<FlagChallengeController>.Instance.OpenFlagChallengeTaskView(this.ActivityId);
		}

		// Token: 0x0603C34C RID: 246604 RVA: 0x00F45520 File Offset: 0x00F43720
		private void OnLeftPageButtonClick()
		{
			List<FlagChallengeAreaData> areaDataList = this.AreaDataList;
			int count = areaDataList.Count;
			int num = -1;
			for (int i = 0; i < areaDataList.Count; i++)
			{
				if (areaDataList[i].Id == this.AreaId)
				{
					num = i;
					break;
				}
			}
			int index = (num - 1 + count) % count;
			int id = areaDataList[index].Id;
			this.SwitchAreaAsync(id);
		}

		// Token: 0x0603C34D RID: 246605 RVA: 0x00F4558C File Offset: 0x00F4378C
		private void OnRightPageButtonClick()
		{
			List<FlagChallengeAreaData> areaDataList = this.AreaDataList;
			int count = areaDataList.Count;
			int num = -1;
			for (int i = 0; i < areaDataList.Count; i++)
			{
				if (areaDataList[i].Id == this.AreaId)
				{
					num = i;
					break;
				}
			}
			int index = (num + 1) % count;
			int id = areaDataList[index].Id;
			this.SwitchAreaAsync(id);
		}

		// Token: 0x0603C34E RID: 246606 RVA: 0x00F455F5 File Offset: 0x00F437F5
		private void OnItemSelectChangeCallback(int id)
		{
			this.RefreshStrongholdPanel(id);
		}

		// Token: 0x0603C34F RID: 246607 RVA: 0x00F45600 File Offset: 0x00F43800
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			if (!(configParams[0] == "Boss"))
			{
				return null;
			}
			FlagChallengeAreaStrongholdContainer strongholdContainer = this.StrongholdContainer;
			UUIItem uuiitem;
			if (strongholdContainer == null)
			{
				uuiitem = null;
			}
			else
			{
				FlagChallengeAreaStrongholdItem bossStrongholdItem = strongholdContainer.GetBossStrongholdItem();
				uuiitem = ((bossStrongholdItem != null) ? bossStrongholdItem.GetRootItem() : null);
			}
			UUIItem uuiitem2 = uuiitem;
			if (uuiitem2 == null)
			{
				return null;
			}
			return new UUIItem[]
			{
				uuiitem2,
				uuiitem2
			};
		}

		// Token: 0x04021CE7 RID: 138471
		private PopupCaptionItem CaptionItem;

		// Token: 0x04021CE8 RID: 138472
		private int ActivityId;

		// Token: 0x04021CE9 RID: 138473
		private int LevelId;

		// Token: 0x04021CEA RID: 138474
		private int AreaId;

		// Token: 0x04021CEB RID: 138475
		private int? SelectStrongholdId;

		// Token: 0x04021CEC RID: 138476
		private FlagChallengeData Data;

		// Token: 0x04021CED RID: 138477
		private List<FlagChallengeAreaData> AreaDataList;

		// Token: 0x04021CEE RID: 138478
		private FlagChallengeLevelInfoItem LevelInfoItem;

		// Token: 0x04021CEF RID: 138479
		private FlagChallengeAreaStrongholdPanel StrongholdPanel;

		// Token: 0x04021CF0 RID: 138480
		private FlagChallengeAreaStrongholdContainer StrongholdContainer;

		// Token: 0x04021CF1 RID: 138481
		private readonly Dictionary<int, FlagChallengeAreaStrongholdContainer> AreaId2StrongholdContainer = new Dictionary<int, FlagChallengeAreaStrongholdContainer>();

		// Token: 0x04021CF2 RID: 138482
		private GenericLayout<FlagChallengeAreaPageDotItem, IFlagChallengeAreaPageDotItemData> DotLayout;

		// Token: 0x04021CF3 RID: 138483
		[Nullable(2)]
		private UiSequencePlayer SequencePlayer;

		// Token: 0x04021CF4 RID: 138484
		private readonly int[] strongholdItemList = new int[]
		{
			3,
			4,
			5,
			6,
			7
		};

		// Token: 0x04021CF5 RID: 138485
		private readonly Dictionary<EFlagChallengeUiStyleType, string> bgColor = new Dictionary<EFlagChallengeUiStyleType, string>
		{
			{
				EFlagChallengeUiStyleType.Green,
				"#040811"
			},
			{
				EFlagChallengeUiStyleType.Yellow,
				"#090709"
			},
			{
				EFlagChallengeUiStyleType.Red,
				"#0A0510"
			},
			{
				EFlagChallengeUiStyleType.Hidden,
				"#0A0510"
			}
		};

		// Token: 0x04021CF6 RID: 138486
		private readonly Dictionary<EFlagChallengeUiStyleType, string> centerBgColor = new Dictionary<EFlagChallengeUiStyleType, string>
		{
			{
				EFlagChallengeUiStyleType.Green,
				"#6AD6ED"
			},
			{
				EFlagChallengeUiStyleType.Yellow,
				"#E2B083"
			},
			{
				EFlagChallengeUiStyleType.Red,
				"#FF83E9"
			},
			{
				EFlagChallengeUiStyleType.Hidden,
				"#FF83E9"
			}
		};

		// Token: 0x04021CF7 RID: 138487
		private readonly Dictionary<EFlagChallengeUiStyleType, string> gridColor = new Dictionary<EFlagChallengeUiStyleType, string>
		{
			{
				EFlagChallengeUiStyleType.Green,
				"#DAE6FE"
			},
			{
				EFlagChallengeUiStyleType.Yellow,
				"#FEF9DA"
			},
			{
				EFlagChallengeUiStyleType.Red,
				"#FEDAF9"
			},
			{
				EFlagChallengeUiStyleType.Hidden,
				"#FEDAF9"
			}
		};

		// Token: 0x04021CF8 RID: 138488
		[TupleElementNames(new string[]
		{
			"Left",
			"Top"
		})]
		[Nullable(new byte[]
		{
			1,
			0
		})]
		private readonly Dictionary<int, ValueTuple<int, int>> frameBgStretch = new Dictionary<int, ValueTuple<int, int>>
		{
			{
				1,
				new ValueTuple<int, int>(-38, -16)
			},
			{
				2,
				new ValueTuple<int, int>(-14, -8)
			},
			{
				3,
				new ValueTuple<int, int>(-14, -26)
			},
			{
				4,
				new ValueTuple<int, int>(-50, -90)
			},
			{
				5,
				new ValueTuple<int, int>(-57, -43)
			}
		};
	}
}
