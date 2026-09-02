using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Common.CardItem.Component.Bvb
{
	// Token: 0x02005562 RID: 21858
	public class BattleCardLoopEffectItem : UiPanelBase
	{
		// Token: 0x06037B67 RID: 228199 RVA: 0x00E20851 File Offset: 0x00E1EA51
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUINiagara))
			};
		}

		// Token: 0x06037B68 RID: 228200 RVA: 0x00E20874 File Offset: 0x00E1EA74
		[NullableContext(1)]
		protected UniTask RefreshNiagara(string path, UUINiagara niagara)
		{
			BattleCardLoopEffectItem.<RefreshNiagara>d__3 <RefreshNiagara>d__;
			<RefreshNiagara>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshNiagara>d__.<>4__this = this;
			<RefreshNiagara>d__.path = path;
			<RefreshNiagara>d__.niagara = niagara;
			<RefreshNiagara>d__.<>1__state = -1;
			<RefreshNiagara>d__.<>t__builder.Start<BattleCardLoopEffectItem.<RefreshNiagara>d__3>(ref <RefreshNiagara>d__);
			return <RefreshNiagara>d__.<>t__builder.Task;
		}

		// Token: 0x06037B69 RID: 228201 RVA: 0x00E208C8 File Offset: 0x00E1EAC8
		protected override UniTask OnBeforeStartAsync()
		{
			BattleCardLoopEffectItem.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<BattleCardLoopEffectItem.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06037B6A RID: 228202 RVA: 0x00E2090C File Offset: 0x00E1EB0C
		private UniTask RefreshEffect(int configId)
		{
			BattleCardLoopEffectItem.<RefreshEffect>d__5 <RefreshEffect>d__;
			<RefreshEffect>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshEffect>d__.<>4__this = this;
			<RefreshEffect>d__.<>1__state = -1;
			<RefreshEffect>d__.<>t__builder.Start<BattleCardLoopEffectItem.<RefreshEffect>d__5>(ref <RefreshEffect>d__);
			return <RefreshEffect>d__.<>t__builder.Task;
		}

		// Token: 0x06037B6B RID: 228203 RVA: 0x00E20950 File Offset: 0x00E1EB50
		public UniTask RefreshEffectById(int configId)
		{
			BattleCardLoopEffectItem.<RefreshEffectById>d__6 <RefreshEffectById>d__;
			<RefreshEffectById>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshEffectById>d__.<>4__this = this;
			<RefreshEffectById>d__.configId = configId;
			<RefreshEffectById>d__.<>1__state = -1;
			<RefreshEffectById>d__.<>t__builder.Start<BattleCardLoopEffectItem.<RefreshEffectById>d__6>(ref <RefreshEffectById>d__);
			return <RefreshEffectById>d__.<>t__builder.Task;
		}

		// Token: 0x06037B6C RID: 228204 RVA: 0x00E2099B File Offset: 0x00E1EB9B
		public void SetCardConfigId(int cardConfigId)
		{
			this.CardConfigId = cardConfigId;
		}

		// Token: 0x0401FE8C RID: 130700
		protected int CardConfigId;

		// Token: 0x0200B501 RID: 46337
		private static class EBattleCardLoopEffectItem
		{
			// Token: 0x04038082 RID: 229506
			public const int LoopNiagara = 0;
		}
	}
}
