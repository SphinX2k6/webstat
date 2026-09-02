using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Common.CardItem.Component.Bvb
{
	// Token: 0x02005561 RID: 21857
	public class BattleCardEffectItem : UiPanelBase
	{
		// Token: 0x06037B5F RID: 228191 RVA: 0x00E2068D File Offset: 0x00E1E88D
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUINiagara)),
				new ValueTuple<int, Type>(1, typeof(UUINiagara))
			};
		}

		// Token: 0x06037B60 RID: 228192 RVA: 0x00E206C8 File Offset: 0x00E1E8C8
		[NullableContext(1)]
		protected UniTask RefreshNiagara(string path, UUINiagara niagara)
		{
			BattleCardEffectItem.<RefreshNiagara>d__3 <RefreshNiagara>d__;
			<RefreshNiagara>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshNiagara>d__.<>4__this = this;
			<RefreshNiagara>d__.path = path;
			<RefreshNiagara>d__.niagara = niagara;
			<RefreshNiagara>d__.<>1__state = -1;
			<RefreshNiagara>d__.<>t__builder.Start<BattleCardEffectItem.<RefreshNiagara>d__3>(ref <RefreshNiagara>d__);
			return <RefreshNiagara>d__.<>t__builder.Task;
		}

		// Token: 0x06037B61 RID: 228193 RVA: 0x00E2071C File Offset: 0x00E1E91C
		protected override UniTask OnBeforeStartAsync()
		{
			BattleCardEffectItem.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<BattleCardEffectItem.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06037B62 RID: 228194 RVA: 0x00E20760 File Offset: 0x00E1E960
		private UniTask RefreshEffect(int configId)
		{
			BattleCardEffectItem.<RefreshEffect>d__5 <RefreshEffect>d__;
			<RefreshEffect>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshEffect>d__.<>4__this = this;
			<RefreshEffect>d__.configId = configId;
			<RefreshEffect>d__.<>1__state = -1;
			<RefreshEffect>d__.<>t__builder.Start<BattleCardEffectItem.<RefreshEffect>d__5>(ref <RefreshEffect>d__);
			return <RefreshEffect>d__.<>t__builder.Task;
		}

		// Token: 0x06037B63 RID: 228195 RVA: 0x00E207AC File Offset: 0x00E1E9AC
		public UniTask RefreshEffectById(int configId)
		{
			BattleCardEffectItem.<RefreshEffectById>d__6 <RefreshEffectById>d__;
			<RefreshEffectById>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshEffectById>d__.<>4__this = this;
			<RefreshEffectById>d__.configId = configId;
			<RefreshEffectById>d__.<>1__state = -1;
			<RefreshEffectById>d__.<>t__builder.Start<BattleCardEffectItem.<RefreshEffectById>d__6>(ref <RefreshEffectById>d__);
			return <RefreshEffectById>d__.<>t__builder.Task;
		}

		// Token: 0x06037B64 RID: 228196 RVA: 0x00E207F8 File Offset: 0x00E1E9F8
		public void PlayStartEffect()
		{
			UUINiagara uiNiagara = base.GetUiNiagara(0);
			UUINiagara uiNiagara2 = base.GetUiNiagara(1);
			this.SetActive(true);
			if (uiNiagara != null && uiNiagara.IsUIActiveSelf())
			{
				uiNiagara.ActivateSystem(true);
			}
			if (uiNiagara2 != null && uiNiagara2.IsUIActiveSelf())
			{
				uiNiagara2.ActivateSystem(true);
			}
		}

		// Token: 0x06037B65 RID: 228197 RVA: 0x00E20840 File Offset: 0x00E1EA40
		public void SetCardConfigId(int cardConfigId)
		{
			this.CardConfigId = cardConfigId;
		}

		// Token: 0x0401FE8B RID: 130699
		protected int CardConfigId;

		// Token: 0x0200B4FC RID: 46332
		private static class EBattleCardEffectItem
		{
			// Token: 0x0403806C RID: 229484
			public const int StartOneNiagara = 0;

			// Token: 0x0403806D RID: 229485
			public const int StartTwoNiagara = 1;
		}
	}
}
