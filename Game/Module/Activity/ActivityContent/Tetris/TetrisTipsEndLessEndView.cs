using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Tetris
{
	// Token: 0x020062EC RID: 25324
	public class TetrisTipsEndLessEndView : TetrisTipsBaseView
	{
		// Token: 0x0603FAB5 RID: 260789 RVA: 0x01052AA3 File Offset: 0x01050CA3
		[NullableContext(1)]
		public TetrisTipsEndLessEndView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603FAB6 RID: 260790 RVA: 0x01052AAC File Offset: 0x01050CAC
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIItem))
			};
		}

		// Token: 0x0603FAB7 RID: 260791 RVA: 0x01052B08 File Offset: 0x01050D08
		protected override void OnStart()
		{
			base.OnStart();
			object openParam = this.OpenParam;
			if (openParam is int)
			{
				int value = (int)openParam;
				this.Param = new int?(value);
				return;
			}
			this.Param = new int?((this.OpenParam as IEndLessEndOpenParam).Score);
			this.IsQuit = (this.OpenParam as IEndLessEndOpenParam).IsQuit;
		}

		// Token: 0x0603FAB8 RID: 260792 RVA: 0x01052B6F File Offset: 0x01050D6F
		protected override void OnBeforeShow()
		{
			this.Refresh();
		}

		// Token: 0x0603FAB9 RID: 260793 RVA: 0x01052B78 File Offset: 0x01050D78
		protected override void OnClose()
		{
			if (this.IsQuit)
			{
				base.CloseMe(delegate(bool _)
				{
					Singleton<UiManager>.Instance.CloseView(EUiViewName.TetrisPlayView, null);
				});
				return;
			}
			base.OnClose();
			TetrisPlayView tetrisPlayView = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.TetrisPlayView) as TetrisPlayView;
			if (tetrisPlayView != null)
			{
				tetrisPlayView.OpenLoseConfirm();
			}
		}

		// Token: 0x0603FABA RID: 260794 RVA: 0x01052BD8 File Offset: 0x01050DD8
		private void Refresh()
		{
			if (this.IsQuit)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "Text_ChallengeFinish_Text", Array.Empty<object>());
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), "Tetristext_13", new <>z__ReadOnlySingleElementList<object>(this.Param.Value.ToString()));
			base.GetItem(2).SetUIActive((long)this.Param.Value > ControllerBase<TetrisController>.Instance.GetHighestScore());
		}

		// Token: 0x04023C05 RID: 146437
		private int? Param;

		// Token: 0x04023C06 RID: 146438
		private bool IsQuit;
	}
}
