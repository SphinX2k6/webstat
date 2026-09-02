using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.Hourglass
{
	// Token: 0x02006E5D RID: 28253
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class QteHourglassModel : ModelBase<QteHourglassModel>
	{
		// Token: 0x06044919 RID: 280857 RVA: 0x011D33E8 File Offset: 0x011D15E8
		public void OpenGameplay(IQteHourglass config)
		{
			this.CloseGameplay();
			this.IsActive = true;
			this.OpenToken++;
			int openToken = this.OpenToken;
			this.RefreshGameplayQteIds(config);
			this.StartListen();
			HourglassOpenParam param = new HourglassOpenParam
			{
				Config = config,
				AutoStartQte = new bool?(false)
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.QteHourglassView, param, delegate(bool success, int viewId)
			{
				if (this.OpenToken != openToken || !this.IsActive)
				{
					if (success && Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.QteHourglassView))
					{
						Singleton<UiManager>.Instance.CloseView(EUiViewName.QteHourglassView, null);
					}
					return;
				}
				if (!success)
				{
					Singleton<global::Log>.Instance.Error(ELogModule.LevelPlay, ELogAuthor.FZX, "[QteHourglassModel] 打开界面失败", default(ReadOnlySpan<ValueTuple<string, object>>));
					this.StopListen();
					this.ResetRuntimeState();
					return;
				}
				this.BoundView = (Singleton<UiManager>.Instance.GetView(viewId) as QteHourglassView);
				this.FlushCompletedQteInfos();
			});
		}

		// Token: 0x0604491A RID: 280858 RVA: 0x011D346B File Offset: 0x011D166B
		public void CloseGameplay()
		{
			bool flag = Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.QteHourglassView);
			this.OpenToken++;
			this.StopListen();
			this.ResetRuntimeState();
			if (flag)
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.QteHourglassView, null);
			}
		}

		// Token: 0x0604491B RID: 280859 RVA: 0x011D34A8 File Offset: 0x011D16A8
		protected override bool OnClear()
		{
			this.CloseGameplay();
			return true;
		}

		// Token: 0x0604491C RID: 280860 RVA: 0x011D34B1 File Offset: 0x011D16B1
		protected override bool OnLeaveLevel()
		{
			this.CloseGameplay();
			return true;
		}

		// Token: 0x0604491D RID: 280861 RVA: 0x011D34BA File Offset: 0x011D16BA
		protected override bool OnChangeMode()
		{
			this.CloseGameplay();
			return true;
		}

		// Token: 0x0604491E RID: 280862 RVA: 0x011D34C4 File Offset: 0x011D16C4
		private void StartListen()
		{
			if (!Singleton<EventSystem>.Instance.Has<int?>(EEventName.CommonQteEnd, new Action<int?>(this.OnCommonQteEnd)))
			{
				Singleton<EventSystem>.Instance.Add<int?>(EEventName.CommonQteEnd, new Action<int?>(this.OnCommonQteEnd));
			}
			if (!Singleton<EventSystem>.Instance.Has<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseView)))
			{
				Singleton<EventSystem>.Instance.Add<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseView));
			}
		}

		// Token: 0x0604491F RID: 280863 RVA: 0x011D3540 File Offset: 0x011D1740
		private void StopListen()
		{
			if (Singleton<EventSystem>.Instance.Has<int?>(EEventName.CommonQteEnd, new Action<int?>(this.OnCommonQteEnd)))
			{
				Singleton<EventSystem>.Instance.Remove<int?>(EEventName.CommonQteEnd, new Action<int?>(this.OnCommonQteEnd));
			}
			if (Singleton<EventSystem>.Instance.Has<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseView)))
			{
				Singleton<EventSystem>.Instance.Remove<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseView));
			}
		}

		// Token: 0x06044920 RID: 280864 RVA: 0x011D35BC File Offset: 0x011D17BC
		private void RefreshGameplayQteIds(IQteHourglass config)
		{
			this.GameplayQteIds.Clear();
			if (config.QteConfigs == null)
			{
				return;
			}
			foreach (IQteHourglassConfig qteHourglassConfig in config.QteConfigs)
			{
				this.GameplayQteIds.Add(qteHourglassConfig.QteId);
			}
		}

		// Token: 0x06044921 RID: 280865 RVA: 0x011D3630 File Offset: 0x011D1830
		private void OnCommonQteEnd(int? handleId)
		{
			if (!this.IsActive || handleId == null || this.CompletedQteHandleIds.Contains(handleId.Value))
			{
				return;
			}
			CommonQteModel instance = ModelBase<CommonQteModel>.Instance;
			CommonQteContextBase commonQteContextBase = (instance != null) ? instance.GetQteContext(handleId.Value) : null;
			if (commonQteContextBase == null)
			{
				return;
			}
			if (!this.GameplayQteIds.Contains(commonQteContextBase.QteId))
			{
				return;
			}
			IQteHourglassCompletedQteInfo qteHourglassCompletedQteInfo = this.CreateCompletedQteInfo(commonQteContextBase);
			this.CompletedQteHandleIds.Add(handleId.Value);
			this.CompletedQteInfos.Add(qteHourglassCompletedQteInfo);
			QteHourglassView boundView = this.BoundView;
			if (boundView == null)
			{
				return;
			}
			boundView.NotifyCommonQteCompleted(qteHourglassCompletedQteInfo);
		}

		// Token: 0x06044922 RID: 280866 RVA: 0x011D36CC File Offset: 0x011D18CC
		private void OnCloseView(EUiViewName viewName, int viewId)
		{
			if (viewName != EUiViewName.QteHourglassView || !this.IsActive)
			{
				return;
			}
			this.OpenToken++;
			this.StopListen();
			this.ResetRuntimeState();
		}

		// Token: 0x06044923 RID: 280867 RVA: 0x011D3700 File Offset: 0x011D1900
		private void FlushCompletedQteInfos()
		{
			foreach (IQteHourglassCompletedQteInfo completedInfo in this.CompletedQteInfos)
			{
				QteHourglassView boundView = this.BoundView;
				if (boundView != null)
				{
					boundView.NotifyCommonQteCompleted(completedInfo);
				}
			}
		}

		// Token: 0x06044924 RID: 280868 RVA: 0x011D3760 File Offset: 0x011D1960
		private void ResetRuntimeState()
		{
			this.BoundView = null;
			this.IsActive = false;
			this.GameplayQteIds.Clear();
			this.CompletedQteInfos.Clear();
			this.CompletedQteHandleIds.Clear();
		}

		// Token: 0x06044925 RID: 280869 RVA: 0x011D3794 File Offset: 0x011D1994
		private IQteHourglassCompletedQteInfo CreateCompletedQteInfo(CommonQteContextBase context)
		{
			return new QteHourglassCompletedQteInfo
			{
				HandleId = context.HandleId,
				QteId = context.QteId,
				IsSuccess = context.IsSuccess(),
				IsFail = context.IsFail(),
				StartPos = this.GetQteStartPos(context)
			};
		}

		// Token: 0x06044926 RID: 280870 RVA: 0x011D37E4 File Offset: 0x011D19E4
		[return: Nullable(2)]
		private Vector GetQteStartPos(CommonQteContextBase context)
		{
			AActor uiActor = context.UiActor;
			if (uiActor == null)
			{
				return null;
			}
			AUIBaseActor auibaseActor = uiActor as AUIBaseActor;
			UUIItem uuiitem = (auibaseActor != null) ? auibaseActor.GetUIItem() : null;
			if (uuiitem == null)
			{
				return null;
			}
			return Vector.Create(uuiitem.GetUIWorldPosition());
		}

		// Token: 0x040262B6 RID: 156342
		[Nullable(2)]
		private QteHourglassView BoundView;

		// Token: 0x040262B7 RID: 156343
		private bool IsActive;

		// Token: 0x040262B8 RID: 156344
		private int OpenToken;

		// Token: 0x040262B9 RID: 156345
		private readonly HashSet<int> GameplayQteIds = new HashSet<int>();

		// Token: 0x040262BA RID: 156346
		private readonly List<IQteHourglassCompletedQteInfo> CompletedQteInfos = new List<IQteHourglassCompletedQteInfo>();

		// Token: 0x040262BB RID: 156347
		private readonly HashSet<int> CompletedQteHandleIds = new HashSet<int>();
	}
}
