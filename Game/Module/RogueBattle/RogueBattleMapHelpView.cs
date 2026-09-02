using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.RogueBattle
{
	// Token: 0x02005264 RID: 21092
	public class RogueBattleMapHelpView : UiViewBase
	{
		// Token: 0x06035FB4 RID: 221108 RVA: 0x00D9541C File Offset: 0x00D9361C
		[NullableContext(1)]
		public RogueBattleMapHelpView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06035FB5 RID: 221109 RVA: 0x00D95425 File Offset: 0x00D93625
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIGridLayout)),
				new ValueTuple<int, Type>(1, typeof(UUIText))
			};
		}

		// Token: 0x06035FB6 RID: 221110 RVA: 0x00D95460 File Offset: 0x00D93660
		protected override UniTask OnBeforeStartAsync()
		{
			RogueBattleMapHelpView.<OnBeforeStartAsync>d__3 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RogueBattleMapHelpView.<OnBeforeStartAsync>d__3>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0401F028 RID: 127016
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<RogueBattleEnvironmentBuffItemWithTexture, IRogueBattleEnvironmentInfo> EventLayout;
	}
}
