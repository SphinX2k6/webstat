using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Plot.Flow;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Sheriff.View.Item
{
	// Token: 0x02004FE9 RID: 20457
	[NullableContext(1)]
	[Nullable(0)]
	public class SheriffMainDialogPanel : UiPanelBase
	{
		// Token: 0x06034BD9 RID: 216025 RVA: 0x00D3B3A5 File Offset: 0x00D395A5
		public SheriffMainDialogPanel(TsUiBlur uiBlur)
		{
			this.UiBlur = uiBlur;
		}

		// Token: 0x06034BDA RID: 216026 RVA: 0x00D3B3C0 File Offset: 0x00D395C0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 9;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUISprite));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnClickBtnNextPage));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06034BDB RID: 216027 RVA: 0x00D3B550 File Offset: 0x00D39750
		protected override void OnStart()
		{
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
			this.LevelSequencePlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.OnCloseSeqEnd), false);
			UUIItem item = base.GetItem(2);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			UUIButtonComponent button = base.GetButton(6);
			if (button != null)
			{
				button.RootUIComp.Get().SetUIActive(false);
			}
			UUIButtonComponent button2 = base.GetButton(7);
			if (button2 != null)
			{
				button2.RootUIComp.Get().SetUIActive(false);
			}
			EPlayerGender playerGender = ModelBase<PlayerInfoModel>.Instance.GetPlayerGender();
			if (playerGender == EPlayerGender.None)
			{
				return;
			}
			string resourceId = (playerGender == EPlayerGender.Male) ? "T_SkyEyeRoleMale" : "T_SkyEyeRoleFemale";
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
			base.SetTextureByPath(resourcePath, base.GetTexture(0), null, null);
		}

		// Token: 0x06034BDC RID: 216028 RVA: 0x00D3B620 File Offset: 0x00D39820
		public void Refresh(List<string> stateIds)
		{
			if (stateIds.Count == 0)
			{
				return;
			}
			this.LevelSequencePlayer.PlayLevelSequenceByName("Start", false, null, false);
			this.UiBlur.SetEnableUiBlur(true);
			UUIButtonComponent button = base.GetButton(1);
			if (button != null)
			{
				button.SetSelfInteractive(true);
			}
			this.TalkList.Clear();
			this.CurTalkIndex = 0;
			foreach (ActionInfo actionInfo in ConfigBase<FlowConfig>.Instance.GetFlowStateActions(stateIds[0], int.Parse(stateIds[1]), int.Parse(stateIds[2])))
			{
				if (actionInfo.Name == EAction.ShowTalk)
				{
					foreach (ITalkItem talkItem in (actionInfo.Params as ShowTalk).TalkItems)
					{
						this.TalkList.Add(talkItem.TidTalk ?? "");
					}
				}
			}
			this.ShowTalk();
		}

		// Token: 0x06034BDD RID: 216029 RVA: 0x00D3B758 File Offset: 0x00D39958
		private void ShowTalk()
		{
			if (this.CurTalkIndex >= this.TalkList.Count)
			{
				if (this.LevelSequencePlayer.IsPlayingSequence("Start"))
				{
					this.LevelSequencePlayer.StopSequenceByKey("Start", false, false);
				}
				this.LevelSequencePlayer.PlayLevelSequenceByName("Close", false, null, false);
				UUIButtonComponent button = base.GetButton(1);
				if (button != null)
				{
					button.SetSelfInteractive(false);
				}
				this.UiBlur.SetEnableUiBlur(false);
				return;
			}
			string key = this.TalkList[this.CurTalkIndex];
			UUIText text = base.GetText(4);
			if (text == null)
			{
				return;
			}
			text.ShowTextNew(key);
		}

		// Token: 0x06034BDE RID: 216030 RVA: 0x00D3B7FB File Offset: 0x00D399FB
		private void OnClickBtnNextPage()
		{
			this.CurTalkIndex++;
			this.ShowTalk();
		}

		// Token: 0x06034BDF RID: 216031 RVA: 0x00D3B811 File Offset: 0x00D39A11
		private void OnCloseSeqEnd(string seqName)
		{
			if (seqName == "Close")
			{
				base.SetUiActive(false);
				Singleton<EventSystem>.Instance.Emit<string>(EEventName.OnGuideTriggerEvent, "SheriffMainViewDialogClose");
			}
		}

		// Token: 0x0401E63B RID: 124475
		protected List<string> TalkList = new List<string>();

		// Token: 0x0401E63C RID: 124476
		protected int CurTalkIndex;

		// Token: 0x0401E63D RID: 124477
		protected LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x0401E63E RID: 124478
		protected TsUiBlur UiBlur;

		// Token: 0x0200AFC4 RID: 44996
		[NullableContext(0)]
		private static class EDefine
		{
			// Token: 0x0403689E RID: 223390
			public const int TexRole = 0;

			// Token: 0x0403689F RID: 223391
			public const int BtnNextPage = 1;

			// Token: 0x040368A0 RID: 223392
			public const int PanelTitle = 2;

			// Token: 0x040368A1 RID: 223393
			public const int TxtTitle = 3;

			// Token: 0x040368A2 RID: 223394
			public const int TxtList = 4;

			// Token: 0x040368A3 RID: 223395
			public const int PanelButton = 5;

			// Token: 0x040368A4 RID: 223396
			public const int BtnLeft = 6;

			// Token: 0x040368A5 RID: 223397
			public const int BtnRight = 7;

			// Token: 0x040368A6 RID: 223398
			public const int SpriteArrow = 8;
		}
	}
}
