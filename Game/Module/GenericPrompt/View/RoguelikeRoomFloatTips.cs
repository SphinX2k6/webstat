using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.GenericPrompt.View
{
	// Token: 0x02005CBE RID: 23742
	public class RoguelikeRoomFloatTips : GenericPromptFloatTipsBase
	{
		// Token: 0x0603BE4B RID: 245323 RVA: 0x00F2DF21 File Offset: 0x00F2C121
		[NullableContext(1)]
		public RoguelikeRoomFloatTips(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603BE4C RID: 245324 RVA: 0x00F2DF2A File Offset: 0x00F2C12A
		protected override void OnRegisterComponent()
		{
			base.OnRegisterComponent();
			this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(2, typeof(UUISprite)));
		}

		// Token: 0x0603BE4D RID: 245325 RVA: 0x00F2DF50 File Offset: 0x00F2C150
		protected override void SetMainText([ParamCollection] [Nullable(new byte[]
		{
			1,
			2
		})] IReadOnlyList<object> param)
		{
			if (ModelBase<WeeklyRogueModel>.Instance.CheckIsInWeeklyRogue())
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.MainText, "RoguelikeRoomFloatTips_Normal", new <>z__ReadOnlyArray<object>(new object[]
				{
					ModelBase<WeeklyRogueModel>.Instance.CurrentLayer,
					ModelBase<WeeklyRogueModel>.Instance.MaxLayer
				}));
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.ExtraText, "RoguelikeRoomFloatTips_NormalDesc", Array.Empty<object>());
				return;
			}
			RoguelikeRoomType? curRoomType = ModelBase<RoguelikeModel>.Instance.CurRoomType;
			RoguelikeRoomType roguelikeRoomType = RoguelikeRoomType.Normal;
			bool flag = curRoomType.GetValueOrDefault() == roguelikeRoomType & curRoomType != null;
			base.MainText.SetUIActive(flag);
			if (flag)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.MainText, "RoguelikeRoomFloatTips_Normal", new <>z__ReadOnlyArray<object>(new object[]
				{
					ModelBase<RoguelikeModel>.Instance.CurRoomCount,
					ModelBase<RoguelikeModel>.Instance.TotalRoomCount
				}));
			}
		}

		// Token: 0x0603BE4E RID: 245326 RVA: 0x00F2E03C File Offset: 0x00F2C23C
		protected override void SetExtraText([ParamCollection] [Nullable(new byte[]
		{
			1,
			2
		})] IReadOnlyList<object> param)
		{
			base.GetSprite(2).SetUIActive(false);
			RoguelikeRoomType? curRoomType = ModelBase<RoguelikeModel>.Instance.CurRoomType;
			if (curRoomType != null)
			{
				switch (curRoomType.GetValueOrDefault())
				{
				case RoguelikeRoomType.Normal:
					Singleton<LguiUtil>.Instance.SetLocalTextNew(base.ExtraText, "RoguelikeRoomFloatTips_NormalDesc", Array.Empty<object>());
					return;
				case RoguelikeRoomType.Special:
					Singleton<LguiUtil>.Instance.SetLocalTextNew(base.ExtraText, "RoguelikeRoomFloatTips_SpecialDesc", Array.Empty<object>());
					break;
				case RoguelikeRoomType.Boss:
					Singleton<LguiUtil>.Instance.SetLocalTextNew(base.ExtraText, "RoguelikeRoomFloatTips_NoHeadDesc", Array.Empty<object>());
					return;
				default:
					return;
				}
			}
		}

		// Token: 0x0200BD45 RID: 48453
		private class ERoguelikeRoomFloatTipsDefine
		{
			// Token: 0x0403A522 RID: 238882
			public const int Icon = 2;
		}
	}
}
