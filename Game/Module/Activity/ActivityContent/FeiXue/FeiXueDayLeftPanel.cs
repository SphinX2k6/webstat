using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.FeiXue
{
	// Token: 0x02006845 RID: 26693
	[NullableContext(1)]
	[Nullable(0)]
	public class FeiXueDayLeftPanel : UiPanelBase
	{
		// Token: 0x0604288F RID: 272527 RVA: 0x01113CB7 File Offset: 0x01111EB7
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUISprite)),
				new ValueTuple<int, Type>(1, typeof(UUISprite))
			};
		}

		// Token: 0x06042890 RID: 272528 RVA: 0x01113CF0 File Offset: 0x01111EF0
		public void SetPanelItemActive(bool isFinish)
		{
			base.GetSprite(1).SetUIActive(true);
			if (isFinish)
			{
				UUISprite sprite = base.GetSprite(0);
				if (sprite != null)
				{
					sprite.SetUIActive(true);
				}
				base.GetSprite(1).SetColor(FColor.FromHex(this.FrameFinishColor));
				return;
			}
			UUISprite sprite2 = base.GetSprite(0);
			if (sprite2 != null)
			{
				sprite2.SetUIActive(false);
			}
			base.GetSprite(1).SetColor(FColor.FromHex(this.FrameLockColor));
		}

		// Token: 0x06042891 RID: 272529 RVA: 0x01113D62 File Offset: 0x01111F62
		public void SetAllFinishState()
		{
			UUISprite sprite = base.GetSprite(0);
			if (sprite != null)
			{
				sprite.SetUIActive(false);
			}
			UUISprite sprite2 = base.GetSprite(1);
			if (sprite2 == null)
			{
				return;
			}
			sprite2.SetUIActive(false);
		}

		// Token: 0x04025084 RID: 151684
		private string FrameLockColor = "#FFFFFFFF";

		// Token: 0x04025085 RID: 151685
		private string FrameFinishColor = "#F8EB57FF";
	}
}
