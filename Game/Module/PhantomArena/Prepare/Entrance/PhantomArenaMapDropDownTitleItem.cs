using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Prepare.Entrance
{
	// Token: 0x020054DB RID: 21723
	public class PhantomArenaMapDropDownTitleItem : TitleItemBase<int>
	{
		// Token: 0x06037585 RID: 226693 RVA: 0x00E0B3A2 File Offset: 0x00E095A2
		[NullableContext(1)]
		public PhantomArenaMapDropDownTitleItem(UUIItem uiItem) : base(uiItem)
		{
		}

		// Token: 0x06037586 RID: 226694 RVA: 0x00E0B3AB File Offset: 0x00E095AB
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText))
			};
		}

		// Token: 0x06037587 RID: 226695 RVA: 0x00E0B3D0 File Offset: 0x00E095D0
		[NullableContext(1)]
		public override void ShowTemp(int mapId, DropDownItemBase<int> selectedItemObj)
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
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), mapName, new <>z__ReadOnlyArray<object>(new object[]
			{
				num,
				num2
			}));
		}

		// Token: 0x0200B453 RID: 46163
		private class EPhantomArenaMapDropDownTitleItemComp
		{
			// Token: 0x04037CFE RID: 228606
			public const int Title = 0;
		}
	}
}
