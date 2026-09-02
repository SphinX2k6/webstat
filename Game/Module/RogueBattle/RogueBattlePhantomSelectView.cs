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
	// Token: 0x0200526E RID: 21102
	[NullableContext(1)]
	[Nullable(0)]
	public class RogueBattlePhantomSelectView : UiViewBase
	{
		// Token: 0x06035FEF RID: 221167 RVA: 0x00D9688A File Offset: 0x00D94A8A
		public RogueBattlePhantomSelectView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06035FF0 RID: 221168 RVA: 0x00D96894 File Offset: 0x00D94A94
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIHorizontalLayout)),
				new ValueTuple<int, Type>(2, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(3, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(2, new Action(this.OnBtnConfirm))
			};
		}

		// Token: 0x06035FF1 RID: 221169 RVA: 0x00D96928 File Offset: 0x00D94B28
		private void OnBtnConfirm()
		{
			GenericLayout<RogueBattlePhantomItem, RogueResGainData> phantomLayout = this.PhantomLayout;
			int? num = (phantomLayout != null) ? new int?(phantomLayout.GetSelectedGridIndex()) : null;
			if (num != null && num.Value > 0)
			{
				return;
			}
			ControllerBase<RogueBattleController>.Instance.SelectTokenRequest(num.Value).ContinueWith(delegate()
			{
				base.CloseMe(null);
			}).Forget();
		}

		// Token: 0x06035FF2 RID: 221170 RVA: 0x00D96990 File Offset: 0x00D94B90
		private RogueBattlePhantomItem CreatePhantomItem()
		{
			return new RogueBattlePhantomItem
			{
				SelectCallBack = new Action<int?>(this.OnSelectPhantom)
			};
		}

		// Token: 0x06035FF3 RID: 221171 RVA: 0x00D969AC File Offset: 0x00D94BAC
		private void OnSelectPhantom(int? index)
		{
			if (index == null)
			{
				GenericLayout<RogueBattlePhantomItem, RogueResGainData> phantomLayout = this.PhantomLayout;
				if (phantomLayout != null)
				{
					phantomLayout.DeselectCurrentGridProxy();
				}
				base.GetButton(2).SetSelfInteractive(false);
				return;
			}
			base.GetButton(2).SetSelfInteractive(true);
			GenericLayout<RogueBattlePhantomItem, RogueResGainData> phantomLayout2 = this.PhantomLayout;
			if (phantomLayout2 == null)
			{
				return;
			}
			phantomLayout2.SelectGridProxy(index.Value, false);
		}

		// Token: 0x06035FF4 RID: 221172 RVA: 0x00D96A08 File Offset: 0x00D94C08
		protected override UniTask OnBeforeStartAsync()
		{
			RogueBattlePhantomSelectView.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RogueBattlePhantomSelectView.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0401F061 RID: 127073
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		public GenericLayout<RogueBattlePhantomItem, RogueResGainData> PhantomLayout;

		// Token: 0x0401F062 RID: 127074
		[Nullable(2)]
		public RogueBattleElementPanel ElementInfoPanel;

		// Token: 0x0401F063 RID: 127075
		[Nullable(2)]
		public RogueBattleTopPanel CaptionItem;
	}
}
