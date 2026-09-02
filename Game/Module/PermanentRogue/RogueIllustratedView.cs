using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PermanentRogue
{
	// Token: 0x02005680 RID: 22144
	[NullableContext(2)]
	[Nullable(0)]
	public class RogueIllustratedView : UiViewBase
	{
		// Token: 0x060386B3 RID: 231091 RVA: 0x00E49F99 File Offset: 0x00E48199
		[NullableContext(1)]
		public RogueIllustratedView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x060386B4 RID: 231092 RVA: 0x00E49FA4 File Offset: 0x00E481A4
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(5, typeof(UUIButtonComponent))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(4, new Action(this.OnClickPrev)),
				new ValueTuple<int, Delegate>(5, new Action(this.OnClickNext))
			};
		}

		// Token: 0x060386B5 RID: 231093 RVA: 0x00E4A07C File Offset: 0x00E4827C
		protected override UniTask OnBeforeStartAsync()
		{
			RogueIllustratedView.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RogueIllustratedView.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060386B6 RID: 231094 RVA: 0x00E4A0C0 File Offset: 0x00E482C0
		protected override void OnStart()
		{
			base.GetButton(4).RootUIComp.Get().SetUIActive(false);
			base.GetButton(5).RootUIComp.Get().SetUIActive(false);
		}

		// Token: 0x060386B7 RID: 231095 RVA: 0x00E4A101 File Offset: 0x00E48301
		protected override void OnBeforeShow()
		{
			this.RefreshBtn();
			this.BindRedDot();
		}

		// Token: 0x060386B8 RID: 231096 RVA: 0x00E4A10F File Offset: 0x00E4830F
		protected override void OnBeforeHide()
		{
			this.UnbindRedDot();
		}

		// Token: 0x060386B9 RID: 231097 RVA: 0x00E4A117 File Offset: 0x00E48317
		protected override void OnBeforeDestroy()
		{
			this.CaptionItem = null;
			this.BtnToken = null;
			this.BtnNormal = null;
			this.BtnMap = null;
		}

		// Token: 0x060386BA RID: 231098 RVA: 0x00E4A135 File Offset: 0x00E48335
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.PermanentRogueRewardUpdate, new Action(this.OnRefreshAward));
		}

		// Token: 0x060386BB RID: 231099 RVA: 0x00E4A153 File Offset: 0x00E48353
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.PermanentRogueRewardUpdate, new Action(this.OnRefreshAward));
		}

		// Token: 0x060386BC RID: 231100 RVA: 0x00E4A171 File Offset: 0x00E48371
		private void OnClickBack()
		{
			base.CloseMe(null);
		}

		// Token: 0x060386BD RID: 231101 RVA: 0x00E4A17A File Offset: 0x00E4837A
		private void OnClickToken()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RogueTokenIllustratedView, null, null);
		}

		// Token: 0x060386BE RID: 231102 RVA: 0x00E4A18D File Offset: 0x00E4838D
		private void OnClickNormal()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RogueEventIllustratedView, true, null);
		}

		// Token: 0x060386BF RID: 231103 RVA: 0x00E4A1A5 File Offset: 0x00E483A5
		private void OnClickMap()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RogueEventIllustratedView, false, null);
		}

		// Token: 0x060386C0 RID: 231104 RVA: 0x00E4A1BD File Offset: 0x00E483BD
		private void OnClickPrev()
		{
		}

		// Token: 0x060386C1 RID: 231105 RVA: 0x00E4A1BF File Offset: 0x00E483BF
		private void OnClickNext()
		{
		}

		// Token: 0x060386C2 RID: 231106 RVA: 0x00E4A1C1 File Offset: 0x00E483C1
		private void OnRefreshAward()
		{
			this.UnbindRedDot();
			this.BindRedDot();
			this.RefreshBtn();
		}

		// Token: 0x060386C3 RID: 231107 RVA: 0x00E4A1D8 File Offset: 0x00E483D8
		public void RefreshBtn()
		{
			Dictionary<int, int[]> typeIllustratedCountInfo = ModelBase<ActivityPermanentRogueModel>.Instance.GetTypeIllustratedCountInfo();
			string multiTextByKey = ConfigBase<TextConfig>.Instance.GetMultiTextByKey("Rogue_Collection_Progress", "Rogue_Collection_Progress");
			int[] array;
			typeIllustratedCountInfo.TryGetValue(0, out array);
			string num = StringUtils.Format(multiTextByKey ?? "", new string[]
			{
				(array != null) ? array[0].ToString() : "0",
				(array != null) ? array[1].ToString() : "0"
			});
			RogueButtonItemCollection btnToken = this.BtnToken;
			if (btnToken != null)
			{
				btnToken.SetNum(num);
			}
			RogueButtonItemCollection btnToken2 = this.BtnToken;
			if (btnToken2 != null)
			{
				btnToken2.SetButtonDone(array == null || array[0] == array[1]);
			}
			int[] array2;
			typeIllustratedCountInfo.TryGetValue(1, out array2);
			string num2 = StringUtils.Format(multiTextByKey ?? "", new string[]
			{
				(array2 != null) ? array2[0].ToString() : "0",
				(array2 != null) ? array2[1].ToString() : "0"
			});
			RogueButtonItemCollection btnNormal = this.BtnNormal;
			if (btnNormal != null)
			{
				btnNormal.SetNum(num2);
			}
			RogueButtonItemCollection btnNormal2 = this.BtnNormal;
			if (btnNormal2 != null)
			{
				btnNormal2.SetButtonDone(array2 == null || array2[0] == array2[1]);
			}
			int[] array3;
			typeIllustratedCountInfo.TryGetValue(2, out array3);
			string num3 = StringUtils.Format(multiTextByKey ?? "", new string[]
			{
				(array3 != null) ? array3[0].ToString() : "0",
				(array3 != null) ? array3[1].ToString() : "0"
			});
			RogueButtonItemCollection btnMap = this.BtnMap;
			if (btnMap != null)
			{
				btnMap.SetNum(num3);
			}
			RogueButtonItemCollection btnMap2 = this.BtnMap;
			if (btnMap2 == null)
			{
				return;
			}
			btnMap2.SetButtonDone(array3 == null || array3[0] == array3[1]);
		}

		// Token: 0x060386C4 RID: 231108 RVA: 0x00E4A3A0 File Offset: 0x00E485A0
		public void BindRedDot()
		{
			RogueButtonItemCollection btnToken = this.BtnToken;
			if (btnToken != null)
			{
				btnToken.BindRedDot(ERedDotName.RogueResIllustratedTokenTab, new int?(0));
			}
			RogueButtonItemCollection btnNormal = this.BtnNormal;
			if (btnNormal != null)
			{
				btnNormal.BindRedDot(ERedDotName.RogueResIllustratedNormalTab, new int?(0));
			}
			RogueButtonItemCollection btnMap = this.BtnMap;
			if (btnMap == null)
			{
				return;
			}
			btnMap.BindRedDot(ERedDotName.RogueResIllustratedMapTab, new int?(0));
		}

		// Token: 0x060386C5 RID: 231109 RVA: 0x00E4A3FD File Offset: 0x00E485FD
		public void UnbindRedDot()
		{
			this.BtnToken.UnBindRedDot();
			this.BtnNormal.UnBindRedDot();
			this.BtnMap.UnBindRedDot();
		}

		// Token: 0x04020315 RID: 131861
		private PopupCaptionItem CaptionItem;

		// Token: 0x04020316 RID: 131862
		private RogueButtonItemCollection BtnToken;

		// Token: 0x04020317 RID: 131863
		private RogueButtonItemCollection BtnNormal;

		// Token: 0x04020318 RID: 131864
		private RogueButtonItemCollection BtnMap;
	}
}
