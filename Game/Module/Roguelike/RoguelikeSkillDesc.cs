using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x020051A8 RID: 20904
	public class RoguelikeSkillDesc : UiPanelBase
	{
		// Token: 0x06035C14 RID: 220180 RVA: 0x00D84B00 File Offset: 0x00D82D00
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06035C15 RID: 220181 RVA: 0x00D84BAB File Offset: 0x00D82DAB
		protected override void OnStart()
		{
			this.Refresh();
		}

		// Token: 0x06035C16 RID: 220182 RVA: 0x00D84BB4 File Offset: 0x00D82DB4
		public void Refresh()
		{
			if (this.Data == null)
			{
				return;
			}
			RogueTalentTreeDesc? rogueTalentTreeDescConfig = ConfigBase<RoguelikeConfig>.Instance.GetRogueTalentTreeDescConfig(this.Data.Value.Describe);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), rogueTalentTreeDescConfig.Value.BaseDesc, rogueTalentTreeDescConfig.Value.Params().ToArray<string>());
			if (this.Index % 2 == 1)
			{
				base.GetSprite(2).useChangeColor = true;
			}
		}

		// Token: 0x0401ED8B RID: 126347
		public RogueTalentTree? Data;

		// Token: 0x0401ED8C RID: 126348
		public int Index;

		// Token: 0x0200B182 RID: 45442
		private class ERoguelikeSkillDescDefine
		{
			// Token: 0x040370CB RID: 225483
			public const int TexIcon = 0;

			// Token: 0x040370CC RID: 225484
			public const int TxtTitle = 1;

			// Token: 0x040370CD RID: 225485
			public const int SpriteBg = 2;

			// Token: 0x040370CE RID: 225486
			public const int TxtNum = 3;
		}
	}
}
