using System;
using System.Collections.Generic;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.PermanentRogue
{
	// Token: 0x02005696 RID: 22166
	public class RogueResSkillDesc : UiPanelBase
	{
		// Token: 0x06038739 RID: 231225 RVA: 0x00E4D0D0 File Offset: 0x00E4B2D0
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUITexture)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUISprite)),
				new ValueTuple<int, Type>(3, typeof(UUIText))
			};
		}

		// Token: 0x0603873A RID: 231226 RVA: 0x00E4D140 File Offset: 0x00E4B340
		protected override void OnStart()
		{
			this.Refresh();
		}

		// Token: 0x0603873B RID: 231227 RVA: 0x00E4D148 File Offset: 0x00E4B348
		public void Refresh()
		{
			if (this.Data == null)
			{
				return;
			}
			RogueResTalentTreeDesc? config = ConfigRogueResTalentTreeDescById.GetConfig(this.Data.Value.Describe, true);
			int skillLevelById = ModelBase<ActivityPermanentRogueModel>.Instance.GetSkillLevelById(this.Data.Value.Id);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), config.Value.TalentDesc, new <>z__ReadOnlySingleElementList<object>(config.Value.Args(skillLevelById - 1)));
			if (this.Index % 2 == 1)
			{
				base.GetSprite(2).useChangeColor = true;
			}
		}

		// Token: 0x04020396 RID: 131990
		public RogueResTalentTree? Data;

		// Token: 0x04020397 RID: 131991
		public int Index;
	}
}
