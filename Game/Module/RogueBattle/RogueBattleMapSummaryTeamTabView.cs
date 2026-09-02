using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.RogueBattle
{
	// Token: 0x0200526A RID: 21098
	[NullableContext(2)]
	[Nullable(0)]
	public class RogueBattleMapSummaryTeamTabView : UiTabViewBase
	{
		// Token: 0x06035FD3 RID: 221139 RVA: 0x00D9612E File Offset: 0x00D9432E
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem))
			};
		}

		// Token: 0x06035FD4 RID: 221140 RVA: 0x00D96167 File Offset: 0x00D94367
		protected override void AddEventListener()
		{
			this.Attribute.BindEvent();
			this.RoleList.BindEvent();
		}

		// Token: 0x06035FD5 RID: 221141 RVA: 0x00D9617F File Offset: 0x00D9437F
		protected override void RemoveEventListener()
		{
			this.Attribute.UnbindEvent();
			this.RoleList.UnbindEvent();
		}

		// Token: 0x06035FD6 RID: 221142 RVA: 0x00D96198 File Offset: 0x00D94398
		protected override void OnAfterShow()
		{
			this.UiViewSequence.PlaySequence("Start", false, null);
		}

		// Token: 0x06035FD7 RID: 221143 RVA: 0x00D961C0 File Offset: 0x00D943C0
		protected override UniTask OnBeforeStartAsync()
		{
			RogueBattleMapSummaryTeamTabView.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RogueBattleMapSummaryTeamTabView.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06035FD8 RID: 221144 RVA: 0x00D96203 File Offset: 0x00D94403
		protected override void OnBeforeDestroy()
		{
			this.Attribute = null;
			this.RoleList = null;
		}

		// Token: 0x0401F04D RID: 127053
		private RogueBattleMapRoleAttributeItem Attribute;

		// Token: 0x0401F04E RID: 127054
		private RogueBattleMapRoleListPanel RoleList;
	}
}
