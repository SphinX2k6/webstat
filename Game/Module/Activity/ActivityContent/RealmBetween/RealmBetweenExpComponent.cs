using System;
using System.Collections.Generic;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RealmBetween
{
	// Token: 0x02006535 RID: 25909
	public class RealmBetweenExpComponent : UiPanelBase
	{
		// Token: 0x06040C84 RID: 265348 RVA: 0x0109C684 File Offset: 0x0109A884
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

		// Token: 0x06040C85 RID: 265349 RVA: 0x0109C6F4 File Offset: 0x0109A8F4
		protected override void OnStart()
		{
			UUIText text = base.GetText(3);
			if (text == null)
			{
				return;
			}
			text.ShowTextNew("RealmBetweenCurrentLevelExp_Text");
		}

		// Token: 0x06040C86 RID: 265350 RVA: 0x0109C70C File Offset: 0x0109A90C
		public void SetProgress(int current, int target, bool isMax)
		{
			if (isMax)
			{
				base.GetSprite(1).SetFillAmount(1f);
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), "RealmBetweenLevelMax_Text", Array.Empty<object>());
				return;
			}
			base.GetSprite(1).SetFillAmount(Singleton<MathUtils>.Instance.Clamp((float)current / (float)target, 0f, 1f));
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), "RealmBetweenExp_Text", new <>z__ReadOnlyArray<object>(new object[]
			{
				current,
				target
			}));
		}

		// Token: 0x06040C87 RID: 265351 RVA: 0x0109C7A1 File Offset: 0x0109A9A1
		public void SetLevel(int level)
		{
			base.GetArtText(0).SetText(level.ToString());
		}
	}
}
