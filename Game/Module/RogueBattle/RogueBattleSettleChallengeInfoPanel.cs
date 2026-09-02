using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.RogueBattle
{
	// Token: 0x0200520D RID: 21005
	public class RogueBattleSettleChallengeInfoPanel : UiPanelBase
	{
		// Token: 0x06035DE3 RID: 220643 RVA: 0x00D8E8CC File Offset: 0x00D8CACC
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIText)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem))
			};
		}

		// Token: 0x06035DE4 RID: 220644 RVA: 0x00D8E954 File Offset: 0x00D8CB54
		protected override UniTask OnBeforeStartAsync()
		{
			RogueBattleSettleChallengeInfoPanel.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RogueBattleSettleChallengeInfoPanel.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0401EEFE RID: 126718
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private RogueBattleSettleInfoPanelWithList<RogueBattleSettleInfoRoleGrid, RogueResGainData> RoleLayoutComponent;

		// Token: 0x0401EEFF RID: 126719
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private RogueBattleSettleInfoPanelWithList<RogueBattleSettleFetterInfoGrid, RoleBondInfo> FetterLayoutComponent;

		// Token: 0x0401EF00 RID: 126720
		public int IncId;

		// Token: 0x0401EF01 RID: 126721
		[Nullable(2)]
		public InstResultView ResultView;
	}
}
