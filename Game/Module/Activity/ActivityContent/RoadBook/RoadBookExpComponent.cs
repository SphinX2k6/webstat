using System;
using System.Collections.Generic;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RoadBook
{
	// Token: 0x02006492 RID: 25746
	public class RoadBookExpComponent : UiPanelBase
	{
		// Token: 0x0604092D RID: 264493 RVA: 0x0108D204 File Offset: 0x0108B404
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIArtText)),
				new ValueTuple<int, Type>(1, typeof(UUISprite)),
				new ValueTuple<int, Type>(2, typeof(UUIText)),
				new ValueTuple<int, Type>(3, typeof(UUIText))
			};
		}

		// Token: 0x0604092E RID: 264494 RVA: 0x0108D274 File Offset: 0x0108B474
		protected override void OnStart()
		{
			UUIText text = base.GetText(3);
			if (text == null)
			{
				return;
			}
			text.ShowTextNew("RoadBookCurrentLevelExp_Text");
		}

		// Token: 0x0604092F RID: 264495 RVA: 0x0108D28C File Offset: 0x0108B48C
		public void SetProgress(int current, int target, bool isMax)
		{
			if (isMax)
			{
				base.GetSprite(1).SetFillAmount(1f);
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), "RoadBookLevelMax_Text", Array.Empty<object>());
				return;
			}
			base.GetSprite(1).SetFillAmount(Singleton<MathUtils>.Instance.Clamp((float)current / (float)target, 0f, 1f));
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), "RoadBookExp_Text", new <>z__ReadOnlyArray<object>(new object[]
			{
				current,
				target
			}));
		}

		// Token: 0x06040930 RID: 264496 RVA: 0x0108D321 File Offset: 0x0108B521
		public void SetLevel(int level)
		{
			base.GetArtText(0).SetText(level.ToString());
		}
	}
}
