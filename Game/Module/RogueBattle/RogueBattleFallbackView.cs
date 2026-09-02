using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.MapRogue;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.RogueBattle
{
	// Token: 0x02005260 RID: 21088
	public class RogueBattleFallbackView : UiViewBase
	{
		// Token: 0x06035FA7 RID: 221095 RVA: 0x00D94F63 File Offset: 0x00D93163
		[NullableContext(1)]
		public RogueBattleFallbackView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06035FA8 RID: 221096 RVA: 0x00D94F6C File Offset: 0x00D9316C
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(3, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(4, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action(this.OnBtnHelp)),
				new ValueTuple<int, Delegate>(2, new Action(this.OnBtnExit)),
				new ValueTuple<int, Delegate>(3, new Action(this.OnBtnBackToMap))
			};
		}

		// Token: 0x06035FA9 RID: 221097 RVA: 0x00D95045 File Offset: 0x00D93245
		private void OnBtnHelp()
		{
		}

		// Token: 0x06035FAA RID: 221098 RVA: 0x00D95047 File Offset: 0x00D93247
		private void OnBtnExit()
		{
			((MapRogueOpFallback)ModelBase<MapRogueModel>.Instance.GetOpData((int)this.OpenParam)).OpExecuteClientId = 0;
			ModelBase<MapRogueModel>.Instance.ExecuteOpData((int)this.OpenParam, null);
			base.CloseMe(null);
		}

		// Token: 0x06035FAB RID: 221099 RVA: 0x00D95086 File Offset: 0x00D93286
		private void OnBtnBackToMap()
		{
			((MapRogueOpFallback)ModelBase<MapRogueModel>.Instance.GetOpData((int)this.OpenParam)).OpExecuteClientId = 1;
			ModelBase<MapRogueModel>.Instance.ExecuteOpData((int)this.OpenParam, null);
		}

		// Token: 0x06035FAC RID: 221100 RVA: 0x00D950C0 File Offset: 0x00D932C0
		protected override UniTask OnBeforeStartAsync()
		{
			RogueBattleFallbackView.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RogueBattleFallbackView.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}
	}
}
