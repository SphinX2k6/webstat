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
	// Token: 0x02005270 RID: 21104
	[NullableContext(1)]
	[Nullable(0)]
	public class RogueBattleRandomEventView : UiViewBase
	{
		// Token: 0x06035FF7 RID: 221175 RVA: 0x00D96A5D File Offset: 0x00D94C5D
		public RogueBattleRandomEventView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06035FF8 RID: 221176 RVA: 0x00D96A68 File Offset: 0x00D94C68
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIVerticalLayout)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(3, typeof(UUIItem))
			};
		}

		// Token: 0x06035FF9 RID: 221177 RVA: 0x00D96AD8 File Offset: 0x00D94CD8
		protected override UniTask OnBeforeStartAsync()
		{
			RogueBattleRandomEventView.<OnBeforeStartAsync>d__3 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RogueBattleRandomEventView.<OnBeforeStartAsync>d__3>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06035FFA RID: 221178 RVA: 0x00D96B1B File Offset: 0x00D94D1B
		private RogueBattleRandomEventItem CreateItem()
		{
			return new RogueBattleRandomEventItem();
		}

		// Token: 0x0401F069 RID: 127081
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		public GenericLayout<RogueBattleRandomEventItem, RogueResGainData> OptionLayout;
	}
}
