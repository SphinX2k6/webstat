using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Battle
{
	// Token: 0x02006636 RID: 26166
	[NullableContext(1)]
	[Nullable(0)]
	public class PinballBattleLevelInfoView : UiPanelBase
	{
		// Token: 0x17009F70 RID: 40816
		// (get) Token: 0x060415BC RID: 267708 RVA: 0x010C3875 File Offset: 0x010C1A75
		// (set) Token: 0x060415BD RID: 267709 RVA: 0x010C387D File Offset: 0x010C1A7D
		public new IPinballBattleLevelInfoViewParam OpenParam { get; set; }

		// Token: 0x060415BE RID: 267710 RVA: 0x010C3888 File Offset: 0x010C1A88
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIVerticalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x060415BF RID: 267711 RVA: 0x010C3975 File Offset: 0x010C1B75
		protected override void OnStart()
		{
			this.StarLayout = new GenericLayout<PinballBattleLevelInfoTargetItem, PinballBattleLevelInfoTargetData>(base.GetVerticalLayout(4), new Func<PinballBattleLevelInfoTargetItem>(this.InitStarItem), base.GetItem(5).GetOwner() as AUIBaseActor, false, true);
		}

		// Token: 0x060415C0 RID: 267712 RVA: 0x010C39A8 File Offset: 0x010C1BA8
		private PinballBattleLevelInfoTargetItem InitStarItem()
		{
			return new PinballBattleLevelInfoTargetItem();
		}

		// Token: 0x060415C1 RID: 267713 RVA: 0x010C39B0 File Offset: 0x010C1BB0
		protected override void OnBeforeShow()
		{
			PinballLevelConfig? pinballLevelConfigById = ConfigBase<PinballConfig>.Instance.GetPinballLevelConfigById(this.OpenParam.LevelId);
			if (pinballLevelConfigById == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Pinball;
				ELogAuthor author = ELogAuthor.CB;
				string message = "找不到关卡配置";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("LevelId", this.OpenParam.LevelId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(1), pinballLevelConfigById.Value.Desc, Array.Empty<object>());
			switch (this.OpenParam.LevelType)
			{
			case EPinballLevelShowType.Normal:
			case EPinballLevelShowType.Tower:
			{
				base.GetItem(2).SetUIActive(true);
				List<PinballBattleLevelInfoTargetData> list = new List<PinballBattleLevelInfoTargetData>();
				for (int i = 0; i < pinballLevelConfigById.Value.StarCondLength; i++)
				{
					int targetId = pinballLevelConfigById.Value.StarCond(i);
					PinballLevelTarget? pinballLevelTargetConfigById = ConfigBase<PinballConfig>.Instance.GetPinballLevelTargetConfigById(targetId);
					PinballBattleLevelInfoTargetData item = new PinballBattleLevelInfoTargetData
					{
						IsSpecial = false,
						IsFinish = ((pinballLevelTargetConfigById.Value.CondType == 2) ? (this.OpenParam.Score >= pinballLevelTargetConfigById.Value.NeedNum) : (this.OpenParam.StarInfo[i] > 0)),
						Desc = pinballLevelTargetConfigById.Value.CondDesc,
						Value = pinballLevelTargetConfigById.Value.NeedNum
					};
					list.Add(item);
				}
				GenericLayout<PinballBattleLevelInfoTargetItem, PinballBattleLevelInfoTargetData> starLayout = this.StarLayout;
				if (starLayout == null)
				{
					return;
				}
				starLayout.RefreshByData(list, null, false);
				return;
			}
			case EPinballLevelShowType.Cow:
			{
				base.GetItem(2).SetUIActive(true);
				List<PinballBattleLevelInfoTargetData> list2 = new List<PinballBattleLevelInfoTargetData>();
				for (int j = 0; j < pinballLevelConfigById.Value.ScoreLevelRewardLength; j++)
				{
					DicIntInt? dicIntInt = pinballLevelConfigById.Value.ScoreLevelReward(j);
					if (dicIntInt != null)
					{
						int key = dicIntInt.Value.Key;
						PinballBattleLevelInfoTargetData item2 = new PinballBattleLevelInfoTargetData
						{
							IsSpecial = true,
							IsFinish = (this.OpenParam.Score >= key),
							Desc = "Pinball_Level_Conditon04",
							Value = key
						};
						list2.Add(item2);
					}
				}
				GenericLayout<PinballBattleLevelInfoTargetItem, PinballBattleLevelInfoTargetData> starLayout2 = this.StarLayout;
				if (starLayout2 == null)
				{
					return;
				}
				starLayout2.RefreshByData(list2, null, false);
				return;
			}
			case EPinballLevelShowType.Daily:
				base.GetItem(2).SetUIActive(false);
				return;
			default:
				return;
			}
		}

		// Token: 0x040248DF RID: 149727
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<PinballBattleLevelInfoTargetItem, PinballBattleLevelInfoTargetData> StarLayout;

		// Token: 0x0200C65C RID: 50780
		[NullableContext(0)]
		private enum EComponent
		{
			// Token: 0x0403D103 RID: 250115
			Scroll,
			// Token: 0x0403D104 RID: 250116
			LevelDesc,
			// Token: 0x0403D105 RID: 250117
			PnlLevelTarget,
			// Token: 0x0403D106 RID: 250118
			TextTargetTitle,
			// Token: 0x0403D107 RID: 250119
			LevelTargetLayout,
			// Token: 0x0403D108 RID: 250120
			LevelTargetLayoutItem
		}
	}
}
