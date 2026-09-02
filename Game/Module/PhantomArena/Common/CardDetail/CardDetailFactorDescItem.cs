using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Common.CardDetail
{
	// Token: 0x02005572 RID: 21874
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class CardDetailFactorDescItem : GridProxyAbstract<CardDetailFactorDescItemData>
	{
		// Token: 0x06037BDA RID: 228314 RVA: 0x00E21B13 File Offset: 0x00E1FD13
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUISprite))
			};
		}

		// Token: 0x06037BDB RID: 228315 RVA: 0x00E21B4C File Offset: 0x00E1FD4C
		public override void Refresh(CardDetailFactorDescItemData data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			string text = "";
			PhantomBattleFactor phantomBattleFactorConfig = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleFactorConfig(data.FactorConfigId);
			int entryId = phantomBattleFactorConfig.EntryId;
			if (entryId > 0)
			{
				text = ConfigMultiTextLang.GetLocalTextNew(ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleEntryConfig(entryId).Name, null) + text;
			}
			string id = data.IsActive ? phantomBattleFactorConfig.Description : phantomBattleFactorConfig.DeActiveDescription;
			string[] source = data.IsActive ? phantomBattleFactorConfig.DescriptionParams() : phantomBattleFactorConfig.DeActiveDescriptionParams();
			string str = StringUtils.Format(ConfigMultiTextLang.GetLocalTextNew(id, null), source.ToArray<string>());
			text += str;
			UUIText text2 = base.GetText(0);
			text2.SetText(text, true);
			text2.SetAlpha(data.IsActive ? 1f : 0.5f);
			base.GetSprite(1).SetUIActive(!data.IsActive);
		}

		// Token: 0x0401FEA8 RID: 130728
		protected CardDetailFactorDescItemData Data;

		// Token: 0x0200B51B RID: 46363
		[NullableContext(0)]
		private static class EDescItemComponents
		{
			// Token: 0x040380F5 RID: 229621
			public const int DescText = 0;

			// Token: 0x040380F6 RID: 229622
			public const int BgSprite = 1;
		}
	}
}
