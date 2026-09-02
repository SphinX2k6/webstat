using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.CiacconaGal
{
	// Token: 0x02005EBF RID: 24255
	public class CiacconaGalFinishBtnItem : UiPanelBase
	{
		// Token: 0x0603CF6D RID: 249709 RVA: 0x00F7BBB0 File Offset: 0x00F79DB0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIExtendToggleTextureTransition));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickInternal));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603CF6E RID: 249710 RVA: 0x00F7BC78 File Offset: 0x00F79E78
		protected override UniTask OnBeforeStartAsync()
		{
			CiacconaGalFinishBtnItem.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<CiacconaGalFinishBtnItem.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603CF6F RID: 249711 RVA: 0x00F7BCBB File Offset: 0x00F79EBB
		protected override void OnStart()
		{
			this.SeqPlayer = new LevelSequencePlayer(this.RootItem);
		}

		// Token: 0x0603CF70 RID: 249712 RVA: 0x00F7BCD0 File Offset: 0x00F79ED0
		protected override void OnAfterShow()
		{
			this.CanClick = false;
			float interval = CiacconaGalUtils.GetAvgChoiceProtectingTime() * (float)Singleton<TimeUtil>.Instance.InverseMillisecond;
			this.ProtectionTimerHandle = TimerSystem.Instance.Delay(delegate(float _)
			{
				this.CanClick = true;
			}, interval, null, null, true, 1f);
			LevelSequencePlayer seqPlayer = this.SeqPlayer;
			if (seqPlayer == null)
			{
				return;
			}
			seqPlayer.PlayLevelSequenceByName("Start", false, null, false);
		}

		// Token: 0x0603CF71 RID: 249713 RVA: 0x00F7BD3B File Offset: 0x00F79F3B
		protected override void OnBeforeDestroy()
		{
			if (this.ProtectionTimerHandle != null && TimerSystem.Instance.Has(this.ProtectionTimerHandle))
			{
				TimerSystem.Instance.Remove(this.ProtectionTimerHandle);
				this.ProtectionTimerHandle = null;
			}
		}

		// Token: 0x0603CF72 RID: 249714 RVA: 0x00F7BD6F File Offset: 0x00F79F6F
		[NullableContext(1)]
		public void SetLocalText(string textId)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), textId, Array.Empty<object>());
		}

		// Token: 0x0603CF73 RID: 249715 RVA: 0x00F7BD88 File Offset: 0x00F79F88
		private void OnClickInternal(EToggleState toggleState)
		{
			if (!this.CanClick)
			{
				return;
			}
			int curHandlingStepId = ControllerBase<CiacconaGalController>.Instance.GalPlayer.CurHandlingStepId;
			int subEndingId = ModelBase<CiacconaGalModel>.Instance.GetStepDataById(curHandlingStepId).SubEndingId;
			ModelBase<CiacconaGalModel>.Instance.GetSubEndingDataById(subEndingId).ClientSetFinished(true);
			ControllerBase<CiacconaGalController>.Instance.ExitAvg().Forget();
		}

		// Token: 0x04022382 RID: 140162
		private bool CanClick;

		// Token: 0x04022383 RID: 140163
		[Nullable(2)]
		private TimerHandle ProtectionTimerHandle;

		// Token: 0x04022384 RID: 140164
		[Nullable(2)]
		private LevelSequencePlayer SeqPlayer;

		// Token: 0x0200BEB4 RID: 48820
		private class EBtnItemComponentDefine
		{
			// Token: 0x0403AB3F RID: 240447
			public const int TogSelf = 0;

			// Token: 0x0403AB40 RID: 240448
			public const int Text = 1;

			// Token: 0x0403AB41 RID: 240449
			public const int TextureIconLock = 2;
		}
	}
}
