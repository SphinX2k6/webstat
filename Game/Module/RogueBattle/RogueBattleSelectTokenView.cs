using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.MapRogue;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using Google.Protobuf.Collections;
using UnrealEngine;

namespace CSharpScript.Game.Module.RogueBattle
{
	// Token: 0x02005279 RID: 21113
	[NullableContext(1)]
	[Nullable(0)]
	public class RogueBattleSelectTokenView : UiViewBase
	{
		// Token: 0x0603601F RID: 221215 RVA: 0x00D9780D File Offset: 0x00D95A0D
		public RogueBattleSelectTokenView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06036020 RID: 221216 RVA: 0x00D97818 File Offset: 0x00D95A18
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIHorizontalLayout)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(6, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(7, typeof(UUITexture)),
				new ValueTuple<int, Type>(8, typeof(UUIText))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(5, new Action(this.OnBtnConfirm)),
				new ValueTuple<int, Delegate>(6, new Action(this.OnBtnRefresh))
			};
		}

		// Token: 0x06036021 RID: 221217 RVA: 0x00D97934 File Offset: 0x00D95B34
		protected override UniTask OnBeforeStartAsync()
		{
			RogueBattleSelectTokenView.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RogueBattleSelectTokenView.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06036022 RID: 221218 RVA: 0x00D97978 File Offset: 0x00D95B78
		private void RefreshTokenLayout()
		{
			SelectViewOp selectViewOp = ((MapRogueOpSelectView)ModelBase<MapRogueModel>.Instance.GetOpData((int)this.OpenParam)).Data.SelectViewOp;
			RepeatedField<RogueResGainData> repeatedField;
			if (selectViewOp == null)
			{
				repeatedField = null;
			}
			else
			{
				RogueResOption rogueResOption = selectViewOp.RogueResOption;
				repeatedField = ((rogueResOption != null) ? rogueResOption.RogueResGainDatas : null);
			}
			RepeatedField<RogueResGainData> repeatedField2 = repeatedField;
			if (repeatedField2 != null)
			{
				GenericLayout<RogueBattleTokenItem, RogueResGainData> tokenLayout = this.TokenLayout;
				if (tokenLayout == null)
				{
					return;
				}
				tokenLayout.RefreshByData(repeatedField2.ToList<RogueResGainData>(), null, false);
			}
		}

		// Token: 0x06036023 RID: 221219 RVA: 0x00D979E0 File Offset: 0x00D95BE0
		private void OnBtnConfirm()
		{
			int selectedGridIndex = this.TokenLayout.GetSelectedGridIndex();
			if (selectedGridIndex < 0)
			{
				return;
			}
			((MapRogueOpSelectView)ModelBase<MapRogueModel>.Instance.GetOpData((int)this.OpenParam)).Select(selectedGridIndex);
		}

		// Token: 0x06036024 RID: 221220 RVA: 0x00D97A1E File Offset: 0x00D95C1E
		private void OnBtnRefresh()
		{
		}

		// Token: 0x06036025 RID: 221221 RVA: 0x00D97A20 File Offset: 0x00D95C20
		private void OnClickDetail()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RogueBattleSummary, null, null);
		}

		// Token: 0x06036026 RID: 221222 RVA: 0x00D97A33 File Offset: 0x00D95C33
		private RogueBattleTokenItem CreateTokenItem()
		{
			return new RogueBattleTokenItem
			{
				OnClickHandle = new Action<int?>(this.OnSelectToken)
			};
		}

		// Token: 0x06036027 RID: 221223 RVA: 0x00D97A4C File Offset: 0x00D95C4C
		private void OnSelectToken(int? index)
		{
			if (index == null)
			{
				GenericLayout<RogueBattleTokenItem, RogueResGainData> tokenLayout = this.TokenLayout;
				if (tokenLayout != null)
				{
					tokenLayout.DeselectCurrentGridProxy();
				}
				base.GetButton(5).SetSelfInteractive(false);
			}
			else
			{
				base.GetButton(5).SetSelfInteractive(true);
				GenericLayout<RogueBattleTokenItem, RogueResGainData> tokenLayout2 = this.TokenLayout;
				if (tokenLayout2 != null)
				{
					tokenLayout2.SelectGridProxy(index.Value, false);
				}
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.RogueBattleSelectOptionPreview);
		}

		// Token: 0x0401F095 RID: 127125
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<RogueBattleTokenItem, RogueResGainData> TokenLayout;

		// Token: 0x0401F096 RID: 127126
		[Nullable(2)]
		private RogueBattleTopPanel CaptionComponent;
	}
}
