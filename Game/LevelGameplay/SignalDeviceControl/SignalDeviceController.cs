using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.LevelGamePlay.SignalDeviceControl
{
	// Token: 0x02006AF2 RID: 27378
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class SignalDeviceController : UiControllerBase<SignalDeviceController>
	{
		// Token: 0x06043AED RID: 277229 RVA: 0x0117480A File Offset: 0x01172A0A
		public void OpenGameplay(List<IColorPiece> config, Action finishCallback)
		{
			ModelBase<SignalDeviceModel>.Instance.InitData(config);
			ModelBase<SignalDeviceModel>.Instance.ViewType = EViewType.Normal;
			Singleton<UiManager>.Instance.OpenView(EUiViewName.SignalDeviceView, config, null);
			this.FinishCallback = finishCallback;
		}

		// Token: 0x06043AEE RID: 277230 RVA: 0x0117483A File Offset: 0x01172A3A
		public void OpenGameplayChasingMoon(List<IColorPiece> config, Action finishCallback)
		{
			ModelBase<SignalDeviceModel>.Instance.InitData(config);
			ModelBase<SignalDeviceModel>.Instance.ViewType = EViewType.ChasingMoon;
			Singleton<UiManager>.Instance.OpenView(EUiViewName.SignalDeviceChasingMoonView, config, null);
			this.FinishCallback = finishCallback;
		}

		// Token: 0x06043AEF RID: 277231 RVA: 0x0117486A File Offset: 0x01172A6A
		public void OnDotPressed(int index, EPieceColorType color)
		{
			if (ModelBase<SignalDeviceModel>.Instance.IsGridFinished(index))
			{
				return;
			}
			ModelBase<SignalDeviceModel>.Instance.LinkingStart(index, color);
		}

		// Token: 0x06043AF0 RID: 277232 RVA: 0x01174886 File Offset: 0x01172A86
		public void OnHovering(int index)
		{
			if (ModelBase<SignalDeviceModel>.Instance.CurrentColor == EPieceColorType.White)
			{
				return;
			}
			ModelBase<SignalDeviceModel>.Instance.Linking(index);
		}

		// Token: 0x06043AF1 RID: 277233 RVA: 0x011748A0 File Offset: 0x01172AA0
		public void CheckLinking(int index)
		{
			ModelBase<SignalDeviceModel>.Instance.CheckLinking(index);
		}

		// Token: 0x06043AF2 RID: 277234 RVA: 0x011748AD File Offset: 0x01172AAD
		public void ResetAll()
		{
			ModelBase<SignalDeviceModel>.Instance.ResetData();
		}

		// Token: 0x06043AF3 RID: 277235 RVA: 0x011748BC File Offset: 0x01172ABC
		public void CallFinishCallback()
		{
			if (this.FinishCallback != null)
			{
				this.FinishCallback();
			}
			if (ModelBase<SignalDeviceModel>.Instance.ViewType == EViewType.ChasingMoon)
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.SignalDeviceChasingMoonView, null);
				return;
			}
			Singleton<UiManager>.Instance.CloseView(EUiViewName.SignalDeviceView, null);
		}

		// Token: 0x04025CFA RID: 154874
		[Nullable(2)]
		private Action FinishCallback;
	}
}
