using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Prepare.Entrance
{
	// Token: 0x020054DA RID: 21722
	public class PhantomArenaMapDropDownItem : DropDownItemBase<int>
	{
		// Token: 0x06037581 RID: 226689 RVA: 0x00E0B23D File Offset: 0x00E0943D
		[NullableContext(1)]
		public PhantomArenaMapDropDownItem(UUIItem uiItem) : base(uiItem)
		{
		}

		// Token: 0x06037582 RID: 226690 RVA: 0x00E0B248 File Offset: 0x00E09448
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIItem))
			};
		}

		// Token: 0x06037583 RID: 226691 RVA: 0x00E0B2A2 File Offset: 0x00E094A2
		[NullableContext(2)]
		protected override UUIExtendToggle GetDropDownToggle()
		{
			return base.GetExtendToggle(0);
		}

		// Token: 0x06037584 RID: 226692 RVA: 0x00E0B2AC File Offset: 0x00E094AC
		protected override void OnShowDropDownItemBase(int mapId)
		{
			PhantomArenaConfig instance = ConfigBase<PhantomArenaConfig>.Instance;
			PhantomBattleMapParam? phantomBattleMapParam = (instance != null) ? instance.GetPhantomBattleMapParamById(mapId) : null;
			if (phantomBattleMapParam == null)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module = ELogModule.PhantomArena;
				ELogAuthor author = ELogAuthor.CB;
				string message = "对应mapId的MapParam为空";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("mapId", mapId);
				instance2.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			string mapName = phantomBattleMapParam.Value.MapName;
			PhantomArenaModel instance3 = ModelBase<PhantomArenaModel>.Instance;
			int? num = (instance3 != null) ? new int?(instance3.GetPermanentFinishedChallengeCount(mapId)) : null;
			PhantomArenaModel instance4 = ModelBase<PhantomArenaModel>.Instance;
			int? num2 = (instance4 != null) ? new int?(instance4.GetPermanentAllChallengeCount(mapId)) : null;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), mapName, new <>z__ReadOnlyArray<object>(new object[]
			{
				num,
				num2
			}));
			UUIItem item = base.GetItem(2);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(false);
		}

		// Token: 0x0200B452 RID: 46162
		private class EPhantomArenaMapDropDownItemComp
		{
			// Token: 0x04037CFB RID: 228603
			public const int Toggle = 0;

			// Token: 0x04037CFC RID: 228604
			public const int Content = 1;

			// Token: 0x04037CFD RID: 228605
			public const int RedDot = 2;
		}
	}
}
