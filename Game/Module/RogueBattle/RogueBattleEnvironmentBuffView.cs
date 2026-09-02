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
	// Token: 0x0200525E RID: 21086
	public class RogueBattleEnvironmentBuffView : UiViewBase
	{
		// Token: 0x06035FA3 RID: 221091 RVA: 0x00D94E97 File Offset: 0x00D93097
		[NullableContext(1)]
		public RogueBattleEnvironmentBuffView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06035FA4 RID: 221092 RVA: 0x00D94EA0 File Offset: 0x00D930A0
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIVerticalLayout)),
				new ValueTuple<int, Type>(1, typeof(UUIVerticalLayout))
			};
		}

		// Token: 0x06035FA5 RID: 221093 RVA: 0x00D94EDC File Offset: 0x00D930DC
		protected override UniTask OnBeforeStartAsync()
		{
			RogueBattleEnvironmentBuffView.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RogueBattleEnvironmentBuffView.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06035FA6 RID: 221094 RVA: 0x00D94F20 File Offset: 0x00D93120
		protected UniTask RefreshView()
		{
			RogueBattleEnvironmentBuffView.<RefreshView>d__5 <RefreshView>d__;
			<RefreshView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshView>d__.<>4__this = this;
			<RefreshView>d__.<>1__state = -1;
			<RefreshView>d__.<>t__builder.Start<RogueBattleEnvironmentBuffView.<RefreshView>d__5>(ref <RefreshView>d__);
			return <RefreshView>d__.<>t__builder.Task;
		}

		// Token: 0x0401F014 RID: 126996
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<RogueBattleEnvironmentBuffItemWithTexture, IRogueBattleEnvironmentInfo> EnvironmentBuffLayout;

		// Token: 0x0401F015 RID: 126997
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<RogueBattleEnvironmentBuffItemWithSprite, IRogueBattleEnvironmentInfo> MonsterBuffLayout;
	}
}
