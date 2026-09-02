using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Skin;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Kurotato.View.Pause
{
	// Token: 0x02005A91 RID: 23185
	[NullableContext(1)]
	[Nullable(0)]
	public class KurotatoPauseView : UiViewBase
	{
		// Token: 0x0603AA96 RID: 240278 RVA: 0x00EDD264 File Offset: 0x00EDB464
		public KurotatoPauseView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x0603AA97 RID: 240279 RVA: 0x00EDD2BC File Offset: 0x00EDB4BC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 13;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(12, new Action(this.OnClickBtnInfo));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603AA98 RID: 240280 RVA: 0x00EDD4D3 File Offset: 0x00EDB6D3
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.KurotatoOnRoleSaveStateUpdate, new Action(this.OnRoleSaveStateUpdate));
		}

		// Token: 0x0603AA99 RID: 240281 RVA: 0x00EDD4F1 File Offset: 0x00EDB6F1
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.KurotatoOnRoleSaveStateUpdate, new Action(this.OnRoleSaveStateUpdate));
		}

		// Token: 0x0603AA9A RID: 240282 RVA: 0x00EDD510 File Offset: 0x00EDB710
		protected override UniTask OnBeforeStartAsync()
		{
			KurotatoPauseView.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<KurotatoPauseView.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603AA9B RID: 240283 RVA: 0x00EDD554 File Offset: 0x00EDB754
		private UniTask CreateCaption()
		{
			KurotatoPauseView.<CreateCaption>d__12 <CreateCaption>d__;
			<CreateCaption>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateCaption>d__.<>4__this = this;
			<CreateCaption>d__.<>1__state = -1;
			<CreateCaption>d__.<>t__builder.Start<KurotatoPauseView.<CreateCaption>d__12>(ref <CreateCaption>d__);
			return <CreateCaption>d__.<>t__builder.Task;
		}

		// Token: 0x0603AA9C RID: 240284 RVA: 0x00EDD597 File Offset: 0x00EDB797
		protected override void OnBeforeShow()
		{
			this.RefreshRoleInfo();
			this.RefreshCurrencyNum();
			this.RefreshWaveInfo();
			this.RefreshSaveStateButtons();
			this.SetupButtonCallbacks();
		}

		// Token: 0x0603AA9D RID: 240285 RVA: 0x00EDD5B8 File Offset: 0x00EDB7B8
		private void RefreshRoleInfo()
		{
			int roleId = ModelBase<KurotatoModel>.Instance.GetRoleId();
			RoleDataBase roleDataByKurotatoRoleId = ModelBase<KurotatoModel>.Instance.GetRoleDataByKurotatoRoleId(roleId);
			base.SetTextureByPath(ConfigBase<SkinConfig>.Instance.GetRoleSkinConfig(roleDataByKurotatoRoleId.GetRoleSkinId()).Value.RoleHeadIconCircle, base.GetTexture(1), null, null);
			base.GetText(2).SetText(ModelBase<KurotatoModel>.Instance.BattleData.GetRoleLevel().ToString(), true);
		}

		// Token: 0x0603AA9E RID: 240286 RVA: 0x00EDD63C File Offset: 0x00EDB83C
		private void RefreshCurrencyNum()
		{
			base.GetText(4).SetText(ModelBase<KurotatoModel>.Instance.BattleData.GetCurrencyCount().ToString(), true);
		}

		// Token: 0x0603AA9F RID: 240287 RVA: 0x00EDD670 File Offset: 0x00EDB870
		private void RefreshWaveInfo()
		{
			KurotatoModel instance = ModelBase<KurotatoModel>.Instance;
			KurotatoConfig instance2 = ConfigBase<KurotatoConfig>.Instance;
			int curLevelId = instance.GetCurLevelId();
			int batch = instance.BattleData.GetBatch();
			List<KurotatoWave> waveByLevelId = instance2.GetWaveByLevelId(curLevelId);
			bool flag = false;
			foreach (KurotatoWave kurotatoWave in waveByLevelId)
			{
				if (kurotatoWave.Wave == batch)
				{
					flag = (kurotatoWave.WaveType == 1);
					break;
				}
			}
			if (flag)
			{
				base.GetText(5).ShowTextNew("Kurotato_Special_Boss");
			}
			else
			{
				UUIText text = base.GetText(5);
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
				defaultInterpolatedStringHandler.AppendFormatted<int>(instance.BattleData.GetBatch());
				defaultInterpolatedStringHandler.AppendLiteral("/");
				defaultInterpolatedStringHandler.AppendFormatted<int>(instance.BattleData.GetMaxBatch());
				text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			}
			int num = 0;
			foreach (KurotatoWave kurotatoWave2 in waveByLevelId)
			{
				if (kurotatoWave2.Wave > batch && kurotatoWave2.IsPowerWave)
				{
					num = kurotatoWave2.Wave;
					break;
				}
			}
			base.GetText(6).SetText((num > 0) ? num.ToString() : "-", true);
		}

		// Token: 0x0603AAA0 RID: 240288 RVA: 0x00EDD7D8 File Offset: 0x00EDB9D8
		private void SetupButtonCallbacks()
		{
			this.BtnSaveFixedWave.SetClickCb(delegate
			{
				if (ModelBase<KurotatoModel>.Instance.GetRoleSaveInstInfos().Count > 1 && ModelBase<KurotatoModel>.Instance.GetRoleSaveInstInfos()[1] != null)
				{
					ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.KurotatoSaveNotifyConfirm);
					ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
					return;
				}
				ControllerBase<KurotatoController>.Instance.RequestKurotatoRoleRecord().Forget<bool>();
			});
			this.BtnRestart.SetClickCb(delegate
			{
				ControllerBase<KurotatoController>.Instance.RequestKurotatoReChallenge(true).Forget<bool>();
			});
			this.BtnSaveAndExit.SetClickCb(delegate
			{
				if (ModelBase<KurotatoModel>.Instance.BattleData.GetBatch() <= 1)
				{
					ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("KurotatoSaveLockedTip", Array.Empty<object>());
					return;
				}
				ControllerBase<KurotatoController>.Instance.LeaveInstanceDungeon();
			});
			this.BtnSettle.SetClickCb(delegate
			{
				ControllerBase<KurotatoController>.Instance.RequestKurotatoSettlement().Forget<bool>();
			});
		}

		// Token: 0x0603AAA1 RID: 240289 RVA: 0x00EDD890 File Offset: 0x00EDBA90
		private void RefreshSaveStateButtons()
		{
			int curLevelId = ModelBase<KurotatoModel>.Instance.GetCurLevelId();
			KurotatoLevel? kurotatoLevel;
			bool flag = ((ConfigBase<KurotatoConfig>.Instance.GetLevelConfig(curLevelId) != null) ? new int?(kurotatoLevel.GetValueOrDefault().Difficulty) : null).GetValueOrDefault() == 3;
			KurotatoRoleSaveState roleSaveState = ModelBase<KurotatoModel>.Instance.GetRoleSaveState();
			bool flag2 = roleSaveState == KurotatoRoleSaveState.NotSaved;
			bool flag3 = roleSaveState == KurotatoRoleSaveState.ClientSaved || roleSaveState == KurotatoRoleSaveState.ServerSaved;
			UUIItem rootItem = this.BtnSaveFixedWave.GetRootItem();
			if (rootItem != null)
			{
				rootItem.SetUIActive(flag2 && flag);
			}
			UUIItem rootItem2 = this.BtnFixedWaveSaved.GetRootItem();
			if (rootItem2 == null)
			{
				return;
			}
			rootItem2.SetUIActive(flag3 && flag);
		}

		// Token: 0x0603AAA2 RID: 240290 RVA: 0x00EDD93C File Offset: 0x00EDBB3C
		private void OnRoleSaveStateUpdate()
		{
			this.RefreshSaveStateButtons();
		}

		// Token: 0x0603AAA3 RID: 240291 RVA: 0x00EDD944 File Offset: 0x00EDBB44
		private void OnClickBtnInfo()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.KurotatoTabMainView, null, null);
		}

		// Token: 0x040212CE RID: 135886
		private readonly PopupCaptionItem Caption = new PopupCaptionItem(null);

		// Token: 0x040212CF RID: 135887
		private readonly PauseButtonItem BtnSaveFixedWave = new PauseButtonItem();

		// Token: 0x040212D0 RID: 135888
		private readonly PauseButtonItem BtnFixedWaveSaved = new PauseButtonItem();

		// Token: 0x040212D1 RID: 135889
		private readonly PauseButtonItem BtnRestart = new PauseButtonItem();

		// Token: 0x040212D2 RID: 135890
		private readonly PauseButtonItem BtnSaveAndExit = new PauseButtonItem();

		// Token: 0x040212D3 RID: 135891
		private readonly PauseButtonItem BtnSettle = new PauseButtonItem();

		// Token: 0x0200BA7D RID: 47741
		[NullableContext(0)]
		private enum EComps
		{
			// Token: 0x0403993D RID: 235837
			Caption,
			// Token: 0x0403993E RID: 235838
			TextureRole,
			// Token: 0x0403993F RID: 235839
			TextLevel,
			// Token: 0x04039940 RID: 235840
			TextureCurrency,
			// Token: 0x04039941 RID: 235841
			TextCurrency,
			// Token: 0x04039942 RID: 235842
			TextWave,
			// Token: 0x04039943 RID: 235843
			TextNextEliteWave,
			// Token: 0x04039944 RID: 235844
			BtnSaveFixedWave,
			// Token: 0x04039945 RID: 235845
			BtnFixedWaveSaved,
			// Token: 0x04039946 RID: 235846
			BtnRestart,
			// Token: 0x04039947 RID: 235847
			BtnSaveAndExit,
			// Token: 0x04039948 RID: 235848
			BtnSettle,
			// Token: 0x04039949 RID: 235849
			BtnInfo
		}
	}
}
