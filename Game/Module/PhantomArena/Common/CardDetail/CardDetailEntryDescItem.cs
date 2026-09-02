using System;
using System.Collections.Generic;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Common.CardDetail
{
	// Token: 0x0200556F RID: 21871
	public class CardDetailEntryDescItem : GridProxyAbstract<int>
	{
		// Token: 0x06037BD2 RID: 228306 RVA: 0x00E219A7 File Offset: 0x00E1FBA7
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUIText))
			};
		}

		// Token: 0x06037BD3 RID: 228307 RVA: 0x00E219E0 File Offset: 0x00E1FBE0
		public override void Refresh(int entryId, bool isSelected, int gridIndex)
		{
			PhantomBattleEntry phantomBattleEntryConfig = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleEntryConfig(entryId);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), phantomBattleEntryConfig.Name, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), phantomBattleEntryConfig.Description, Array.Empty<object>());
		}

		// Token: 0x0200B51A RID: 46362
		private static class EComponents
		{
			// Token: 0x040380F3 RID: 229619
			public const int NameText = 0;

			// Token: 0x040380F4 RID: 229620
			public const int DescText = 1;
		}
	}
}
