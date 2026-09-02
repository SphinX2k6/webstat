using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.MusicalInstrument
{
	// Token: 0x020056CE RID: 22222
	[NullableContext(1)]
	[Nullable(0)]
	public class GuqinView : MusicalInstrumentBaseView
	{
		// Token: 0x06038914 RID: 231700 RVA: 0x00E54D23 File Offset: 0x00E52F23
		public GuqinView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06038915 RID: 231701 RVA: 0x00E54D49 File Offset: 0x00E52F49
		protected override EInstrumentType GetMusicalInstrumentType()
		{
			return EInstrumentType.ChineseZither;
		}

		// Token: 0x06038916 RID: 231702 RVA: 0x00E54D4C File Offset: 0x00E52F4C
		[PreserveBaseOverrides]
		protected new virtual GuqinSubModel GetSubModel()
		{
			return (GuqinSubModel)ModelBase<MusicalInstrumentModel>.Instance.GetSubModel(EInstrumentType.ChineseZither);
		}

		// Token: 0x06038917 RID: 231703 RVA: 0x00E54D60 File Offset: 0x00E52F60
		protected unsafe override void OnRegisterComponent()
		{
			int num = 10;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUILayoutBase));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06038918 RID: 231704 RVA: 0x00E54ED4 File Offset: 0x00E530D4
		protected override UniTask OnBeforeStartAsync()
		{
			GuqinView.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<GuqinView.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06038919 RID: 231705 RVA: 0x00E54F18 File Offset: 0x00E53118
		private UniTask CreateKeyItems()
		{
			GuqinView.<CreateKeyItems>d__12 <CreateKeyItems>d__;
			<CreateKeyItems>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateKeyItems>d__.<>4__this = this;
			<CreateKeyItems>d__.<>1__state = -1;
			<CreateKeyItems>d__.<>t__builder.Start<GuqinView.<CreateKeyItems>d__12>(ref <CreateKeyItems>d__);
			return <CreateKeyItems>d__.<>t__builder.Task;
		}

		// Token: 0x0603891A RID: 231706 RVA: 0x00E54F5C File Offset: 0x00E5315C
		protected override void OnStart()
		{
			this.AddEvents();
			UUIItem item = base.GetItem(9);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			this.CaptionItem = new PopupCaptionItem(base.GetItem(0));
			this.CaptionItem.SetCloseCallBack(new Action(this.OnCloseBtnClick));
			this.CaptionItem.SetHelpCallBack(new Action(this.OnHelpBtnClick));
			GuqinModeToggleItem fundamentalToneToggleItem = this.FundamentalToneToggleItem;
			if (fundamentalToneToggleItem != null)
			{
				fundamentalToneToggleItem.SetToggleState(EToggleState.ETT_Checked, true);
			}
			this.InitQteMode();
			if (Singleton<Info>.Instance.IsInGamepad())
			{
				this.OnGamepadChangePitch(EZitherGamepadPitchType.Middle);
			}
		}

		// Token: 0x0603891B RID: 231707 RVA: 0x00E54FEF File Offset: 0x00E531EF
		private void AddEvents()
		{
			Singleton<EventSystem>.Instance.Add<EInputControllerMainType, EInputControllerMainType>(EEventName.InputControllerMainTypeChange, new Action<EInputControllerMainType, EInputControllerMainType>(this.OnInputControllerMainTypeChange));
		}

		// Token: 0x0603891C RID: 231708 RVA: 0x00E5500D File Offset: 0x00E5320D
		private void RemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.InputControllerMainTypeChange, new Action<EInputControllerMainType, EInputControllerMainType>(this.OnInputControllerMainTypeChange));
		}

		// Token: 0x0603891D RID: 231709 RVA: 0x00E5502C File Offset: 0x00E5322C
		private void OnInputControllerMainTypeChange(EInputControllerMainType last, EInputControllerMainType now)
		{
			if (now == EInputControllerMainType.Gamepad)
			{
				this.OnGamepadChangePitch(EZitherGamepadPitchType.Middle);
				return;
			}
			foreach (ZitherKeyGroupView zitherKeyGroupView in this.KeyGroupViews)
			{
				zitherKeyGroupView.Refresh(true);
			}
		}

		// Token: 0x0603891E RID: 231710 RVA: 0x00E5508C File Offset: 0x00E5328C
		private void InitQteMode()
		{
			MusicalInstrumentQteData qteData = this.GetSubModel().GetQteData();
			if (qteData != null)
			{
				PopupCaptionItem captionItem = this.CaptionItem;
				if (captionItem != null)
				{
					captionItem.SetUiActive(false);
				}
				UUIItem item = base.GetItem(6);
				if (item != null)
				{
					item.SetUIActive(true);
				}
				UUIItem item2 = base.GetItem(1);
				if (item2 != null)
				{
					item2.SetUIActive(false);
				}
				UUIItem item3 = base.GetItem(2);
				if (item3 != null)
				{
					item3.SetUIActive(false);
				}
				this.QteLayout = new GenericLayout<GuqinQteItem, MusicalInstrumentQteItemData>(base.GetLayoutBase(7), new Func<GuqinQteItem>(this.InitGuqinQteItem), (AUIBaseActor)base.GetItem(8).GetOwner(), false, true);
				GenericLayout<GuqinQteItem, MusicalInstrumentQteItemData> qteLayout = this.QteLayout;
				if (qteLayout != null)
				{
					qteLayout.RefreshByData(qteData.ItemDataList, null, false);
				}
				base.FocusCurrentQte();
				return;
			}
			UUIItem item4 = base.GetItem(6);
			if (item4 != null)
			{
				item4.SetUIActive(false);
			}
			UUIItem item5 = base.GetItem(1);
			if (item5 != null)
			{
				item5.SetUIActive(true);
			}
			UUIItem item6 = base.GetItem(2);
			if (item6 == null)
			{
				return;
			}
			item6.SetUIActive(true);
		}

		// Token: 0x0603891F RID: 231711 RVA: 0x00E5517C File Offset: 0x00E5337C
		private GuqinQteItem InitGuqinQteItem()
		{
			return new GuqinQteItem
			{
				GetKeyConfigCallback = new Func<int, int, GuqinKeyConfig>(this.GetKeyConfigCallback)
			};
		}

		// Token: 0x06038920 RID: 231712 RVA: 0x00E55195 File Offset: 0x00E53395
		[NullableContext(2)]
		private GuqinKeyConfig GetKeyConfigCallback(int rowIndex, int columnIndex)
		{
			return this.GetSubModel().GetKeyConfig(rowIndex, columnIndex);
		}

		// Token: 0x06038921 RID: 231713 RVA: 0x00E551A4 File Offset: 0x00E533A4
		private void OnSelectAudioType(EZitherAudioType audioType)
		{
			this.AudioType = audioType;
			if (this.AudioType == EZitherAudioType.FundamentalTone)
			{
				GuqinModeToggleItem overToneToggleItem = this.OverToneToggleItem;
				if (overToneToggleItem != null)
				{
					overToneToggleItem.SetToggleState(EToggleState.ETT_UnChecked, true);
				}
			}
			else
			{
				GuqinModeToggleItem fundamentalToneToggleItem = this.FundamentalToneToggleItem;
				if (fundamentalToneToggleItem != null)
				{
					fundamentalToneToggleItem.SetToggleState(EToggleState.ETT_UnChecked, true);
				}
			}
			foreach (List<MusicalInstrumentKeyItem> list in this.KeyItems)
			{
				foreach (MusicalInstrumentKeyItem musicalInstrumentKeyItem in list)
				{
					((GuqinKeyItem)musicalInstrumentKeyItem).RefreshMode(audioType);
				}
			}
			UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
			if (uiViewSequence == null)
			{
				return;
			}
			uiViewSequence.PlayOrReplaySequenceByName("Switch", false, null);
		}

		// Token: 0x06038922 RID: 231714 RVA: 0x00E55288 File Offset: 0x00E53488
		private void OnCloseBtnClick()
		{
			base.Exit();
		}

		// Token: 0x06038923 RID: 231715 RVA: 0x00E55290 File Offset: 0x00E53490
		private void OnHelpBtnClick()
		{
			ControllerBase<HelpController>.Instance.OpenHelpById(662);
		}

		// Token: 0x06038924 RID: 231716 RVA: 0x00E552A1 File Offset: 0x00E534A1
		protected override void OnQtePerformance(int rowIndex, int columnIndex, bool success)
		{
			if (success)
			{
				GenericLayout<GuqinQteItem, MusicalInstrumentQteItemData> qteLayout = this.QteLayout;
				if (qteLayout == null)
				{
					return;
				}
				qteLayout.RefreshWithoutDataSync();
			}
		}

		// Token: 0x06038925 RID: 231717 RVA: 0x00E552B8 File Offset: 0x00E534B8
		protected override void PostAudioEventByIndex(int rowIndex, int columnIndex)
		{
			GuqinKeyConfig keyConfig = this.GetSubModel().GetKeyConfig(rowIndex, columnIndex);
			if (keyConfig == null)
			{
				return;
			}
			string @event = (this.AudioType == EZitherAudioType.FundamentalTone) ? keyConfig.FundamentalToneAudioEvent : keyConfig.OverToneAudioEvent;
			Singleton<AudioSystem>.Instance.PostEvent(@event, Global.BaseCharacter, null);
			ControllerBase<MusicalInstrumentController>.Instance.SyncServerRequest(@event);
		}

		// Token: 0x06038926 RID: 231718 RVA: 0x00E55314 File Offset: 0x00E53514
		public void OnGamepadChangePitch(EZitherGamepadPitchType pitchType)
		{
			for (int i = 0; i < this.KeyGroupViews.Count; i++)
			{
				this.KeyGroupViews[i].Refresh(i == (int)pitchType);
			}
		}

		// Token: 0x06038927 RID: 231719 RVA: 0x00E5534C File Offset: 0x00E5354C
		public void OnGamepadPressPitch(EZitherGamepadPitchType pitchType)
		{
			int num = this.HeldPitchTypes.IndexOf(pitchType);
			if (num >= 0)
			{
				this.HeldPitchTypes.RemoveAt(num);
			}
			this.HeldPitchTypes.Add(pitchType);
			this.OnGamepadChangePitch(pitchType);
		}

		// Token: 0x06038928 RID: 231720 RVA: 0x00E5538C File Offset: 0x00E5358C
		public void OnGamepadReleasePitch(EZitherGamepadPitchType pitchType)
		{
			int num = this.HeldPitchTypes.IndexOf(pitchType);
			if (num >= 0)
			{
				this.HeldPitchTypes.RemoveAt(num);
			}
			EZitherGamepadPitchType pitchType2 = (this.HeldPitchTypes.Count > 0) ? this.HeldPitchTypes[this.HeldPitchTypes.Count - 1] : EZitherGamepadPitchType.Middle;
			this.OnGamepadChangePitch(pitchType2);
		}

		// Token: 0x06038929 RID: 231721 RVA: 0x00E553E7 File Offset: 0x00E535E7
		protected override void OnBeforeDestroy()
		{
			this.RemoveEvents();
		}

		// Token: 0x0402046A RID: 132202
		[Nullable(2)]
		private PopupCaptionItem CaptionItem;

		// Token: 0x0402046B RID: 132203
		[Nullable(2)]
		private GuqinModeToggleItem FundamentalToneToggleItem;

		// Token: 0x0402046C RID: 132204
		[Nullable(2)]
		private GuqinModeToggleItem OverToneToggleItem;

		// Token: 0x0402046D RID: 132205
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<GuqinQteItem, MusicalInstrumentQteItemData> QteLayout;

		// Token: 0x0402046E RID: 132206
		private EZitherAudioType AudioType = EZitherAudioType.FundamentalTone;

		// Token: 0x0402046F RID: 132207
		private readonly List<ZitherKeyGroupView> KeyGroupViews = new List<ZitherKeyGroupView>();

		// Token: 0x04020470 RID: 132208
		private readonly List<EZitherGamepadPitchType> HeldPitchTypes = new List<EZitherGamepadPitchType>();

		// Token: 0x0200B74F RID: 46927
		[NullableContext(0)]
		private enum EComponent
		{
			// Token: 0x04038B25 RID: 232229
			CaptionItem,
			// Token: 0x04038B26 RID: 232230
			NormalMode,
			// Token: 0x04038B27 RID: 232231
			SpecialMode,
			// Token: 0x04038B28 RID: 232232
			HighGroup,
			// Token: 0x04038B29 RID: 232233
			MiddleGroup,
			// Token: 0x04038B2A RID: 232234
			LowGroup,
			// Token: 0x04038B2B RID: 232235
			PnlTopQte,
			// Token: 0x04038B2C RID: 232236
			PnlQteLayout,
			// Token: 0x04038B2D RID: 232237
			QteKeyItem,
			// Token: 0x04038B2E RID: 232238
			BtnVisible
		}
	}
}
