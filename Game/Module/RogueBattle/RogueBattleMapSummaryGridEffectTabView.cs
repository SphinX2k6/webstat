using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.MapRogue;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.RogueBattle
{
	// Token: 0x02005268 RID: 21096
	public class RogueBattleMapSummaryGridEffectTabView : UiTabViewBase
	{
		// Token: 0x06035FCA RID: 221130 RVA: 0x00D95F3C File Offset: 0x00D9413C
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIArtText)),
				new ValueTuple<int, Type>(2, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIArtText)),
				new ValueTuple<int, Type>(5, typeof(UUIVerticalLayout)),
				new ValueTuple<int, Type>(6, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(2, new Action(this.OnClickedMore))
			};
		}

		// Token: 0x06035FCB RID: 221131 RVA: 0x00D96011 File Offset: 0x00D94211
		protected override void OnStart()
		{
			this.Layout = new GenericLayout<RogueBattleMapGridEffectTabItem, IRogueBattleMapGridEffectInfo>(base.GetVerticalLayout(5), new Func<RogueBattleMapGridEffectTabItem>(this.InitItem), null, false, true);
		}

		// Token: 0x06035FCC RID: 221132 RVA: 0x00D96034 File Offset: 0x00D94234
		protected override void OnBeforeShow()
		{
			this.OnClickedTeam();
		}

		// Token: 0x06035FCD RID: 221133 RVA: 0x00D9603C File Offset: 0x00D9423C
		protected override void OnAfterShow()
		{
			this.UiViewSequence.PlaySequence("Start", false, null);
		}

		// Token: 0x06035FCE RID: 221134 RVA: 0x00D96063 File Offset: 0x00D94263
		protected override void OnBeforeDestroy()
		{
			this.Layout = null;
		}

		// Token: 0x06035FCF RID: 221135 RVA: 0x00D9606C File Offset: 0x00D9426C
		private void OnClickedTeam()
		{
			UUIItem item = base.GetItem(0);
			if (item != null)
			{
				item.SetUIActive(true);
			}
			UUIItem item2 = base.GetItem(3);
			if (item2 != null)
			{
				item2.SetUIActive(false);
			}
			List<IRogueBattleMapGridEffectInfo> effectList = ModelBase<RogueBattleModel>.Instance.GetEffectList();
			GenericLayout<RogueBattleMapGridEffectTabItem, IRogueBattleMapGridEffectInfo> layout = this.Layout;
			if (layout != null)
			{
				layout.RefreshByData(effectList, null, true);
			}
			int teamLv = ModelBase<MapRogueModel>.Instance.GameInfo.TeamLv;
			string text;
			if (teamLv <= 10)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
				defaultInterpolatedStringHandler.AppendLiteral("0");
				defaultInterpolatedStringHandler.AppendFormatted<int>(teamLv);
				text = defaultInterpolatedStringHandler.ToStringAndClear();
			}
			else
			{
				text = teamLv.ToString();
			}
			string text2 = text;
			base.GetArtText(1).SetText(text2);
		}

		// Token: 0x06035FD0 RID: 221136 RVA: 0x00D9610E File Offset: 0x00D9430E
		[NullableContext(1)]
		private RogueBattleMapGridEffectTabItem InitItem()
		{
			return new RogueBattleMapGridEffectTabItem();
		}

		// Token: 0x06035FD1 RID: 221137 RVA: 0x00D96115 File Offset: 0x00D94315
		private void OnClickedMore()
		{
			ControllerBase<HelpController>.Instance.OpenHelpById(260);
		}

		// Token: 0x0401F048 RID: 127048
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<RogueBattleMapGridEffectTabItem, IRogueBattleMapGridEffectInfo> Layout;

		// Token: 0x0401F049 RID: 127049
		private const int MORE_HELPID = 260;
	}
}
