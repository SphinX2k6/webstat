using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Activity.ActivityContent.RougeActivity;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x02005184 RID: 20868
	public class RoguelikeBlackFlowerInstanceItem : UiPanelBase
	{
		// Token: 0x06035B12 RID: 219922 RVA: 0x00D7D37C File Offset: 0x00D7B57C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnClickHelp));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06035B13 RID: 219923 RVA: 0x00D7D443 File Offset: 0x00D7B643
		protected override void OnBeforeShow()
		{
			this.RefreshHandle();
		}

		// Token: 0x06035B14 RID: 219924 RVA: 0x00D7D44C File Offset: 0x00D7B64C
		private void OnClickHelp()
		{
			RogueParam? paramConfigBySeasonId = ModelBase<RoguelikeModel>.Instance.GetParamConfigBySeasonId(null);
			if (paramConfigBySeasonId == null)
			{
				return;
			}
			RoguelikeBlackFlowerOpenParam roguelikeBlackFlowerOpenParam = new RoguelikeBlackFlowerOpenParam();
			roguelikeBlackFlowerOpenParam.DropId = paramConfigBySeasonId.Value.BlackFlowerDropId;
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RoguelikeBlackFlowerPreviewView, roguelikeBlackFlowerOpenParam, null);
		}

		// Token: 0x06035B15 RID: 219925 RVA: 0x00D7D4A4 File Offset: 0x00D7B6A4
		private void RefreshHandle()
		{
			ActivityRogueData currentActivityData = ControllerBase<ActivityRogueController>.Instance.GetCurrentActivityData();
			if (currentActivityData == null)
			{
				return;
			}
			int num = currentActivityData.SeasonData.BlackFlowerMaxCount - currentActivityData.SeasonData.BlackFlowerUseCount;
			RogueSeasonData seasonData = currentActivityData.SeasonData;
			int num2 = (seasonData != null) ? seasonData.BlackFlowerMaxCount : 0;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), "InstanceDungeon_BlackFlowerTitle", Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "Rogue_MemoryPlace_Progress", new <>z__ReadOnlyArray<object>(new object[]
			{
				num.ToString(),
				num2.ToString()
			}));
		}

		// Token: 0x0200B13F RID: 45375
		private class EItemComponentDefine
		{
			// Token: 0x04036F8F RID: 225167
			public const int TxtTitle = 0;

			// Token: 0x04036F90 RID: 225168
			public const int TxtContent = 1;

			// Token: 0x04036F91 RID: 225169
			public const int BtnHelp = 2;
		}
	}
}
