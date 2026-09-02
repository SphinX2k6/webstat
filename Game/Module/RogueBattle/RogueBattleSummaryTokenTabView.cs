using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.RogueBattle
{
	// Token: 0x02005281 RID: 21121
	[NullableContext(1)]
	[Nullable(0)]
	public class RogueBattleSummaryTokenTabView : UiTabViewBase
	{
		// Token: 0x06036047 RID: 221255 RVA: 0x00D98540 File Offset: 0x00D96740
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUILoopScrollViewComponent)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIItem))
			};
		}

		// Token: 0x06036048 RID: 221256 RVA: 0x00D9859A File Offset: 0x00D9679A
		private RogueBattleTokenGrid CreateItem()
		{
			return new RogueBattleTokenGrid
			{
				SelectCallback = new Action<int, RogueResGainData>(this.OnSelectCallback)
			};
		}

		// Token: 0x06036049 RID: 221257 RVA: 0x00D985B3 File Offset: 0x00D967B3
		private void OnSelectCallback(int index, RogueResGainData data)
		{
			RogueBattleTokenItem tokenComponent = this.TokenComponent;
			if (tokenComponent != null)
			{
				tokenComponent.Refresh(data, false, 0);
			}
			RogueBattleTokenItem tokenComponent2 = this.TokenComponent;
			if (tokenComponent2 != null)
			{
				tokenComponent2.SetUiActive(true);
			}
			LoopScrollView<RogueBattleTokenGrid, RogueResGainData> tokenScrollView = this.TokenScrollView;
			if (tokenScrollView == null)
			{
				return;
			}
			tokenScrollView.SelectGridProxy(index, false);
		}

		// Token: 0x0603604A RID: 221258 RVA: 0x00D985F0 File Offset: 0x00D967F0
		protected override UniTask OnBeforeStartAsync()
		{
			RogueBattleSummaryTokenTabView.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RogueBattleSummaryTokenTabView.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0401F0C3 RID: 127171
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private LoopScrollView<RogueBattleTokenGrid, RogueResGainData> TokenScrollView;

		// Token: 0x0401F0C4 RID: 127172
		[Nullable(2)]
		private RogueBattleTokenItem TokenComponent;
	}
}
