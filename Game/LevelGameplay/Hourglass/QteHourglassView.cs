using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.Hourglass
{
	// Token: 0x02006E60 RID: 28256
	[NullableContext(1)]
	[Nullable(0)]
	public class QteHourglassView : UiTickViewBase
	{
		// Token: 0x06044931 RID: 280881 RVA: 0x011D3878 File Offset: 0x011D1A78
		public QteHourglassView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06044932 RID: 280882 RVA: 0x011D38F0 File Offset: 0x011D1AF0
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem))
			};
		}

		// Token: 0x06044933 RID: 280883 RVA: 0x011D392C File Offset: 0x011D1B2C
		protected override void OnStart()
		{
			this.FillItem = base.GetItem(0);
			this.TrailItem = base.GetItem(1);
			this.ResetTrailMove();
			Singleton<EventSystem>.Instance.Add<int?>(EEventName.CommonQteEnd, new Action<int?>(this.OnCommonQteEnd));
			UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
			if (uiViewSequence != null)
			{
				uiViewSequence.AddSequenceFinishEvent("Start", new Action<string>(this.OnStartSequenceFinished), false);
			}
			UiBehaviorLevelSequence uiViewSequence2 = this.UiViewSequence;
			if (uiViewSequence2 != null)
			{
				uiViewSequence2.AddSequenceFinishEvent("PhaseA", new Action<string>(this.OnPhaseAFinished), false);
			}
			UiBehaviorLevelSequence uiViewSequence3 = this.UiViewSequence;
			if (uiViewSequence3 != null)
			{
				uiViewSequence3.AddSequenceFinishEvent("PhaseB", new Action<string>(this.OnPhaseBFinished), false);
			}
			UiBehaviorLevelSequence uiViewSequence4 = this.UiViewSequence;
			if (uiViewSequence4 == null)
			{
				return;
			}
			uiViewSequence4.AddSequenceFinishEvent("PhaseC", new Action<string>(this.OnPhaseCFinished), false);
		}

		// Token: 0x06044934 RID: 280884 RVA: 0x011D3A00 File Offset: 0x011D1C00
		protected override UniTask OnCreateAsync()
		{
			QteHourglassView.<OnCreateAsync>d__29 <OnCreateAsync>d__;
			<OnCreateAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnCreateAsync>d__.<>4__this = this;
			<OnCreateAsync>d__.<>1__state = -1;
			<OnCreateAsync>d__.<>t__builder.Start<QteHourglassView.<OnCreateAsync>d__29>(ref <OnCreateAsync>d__);
			return <OnCreateAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06044935 RID: 280885 RVA: 0x011D3A43 File Offset: 0x011D1C43
		protected override void OnBeforeHide()
		{
			this.CleanupRuntimeState();
			if (!this.LastHide)
			{
				this.LastHide = true;
				base.CloseMe(null);
			}
		}

		// Token: 0x06044936 RID: 280886 RVA: 0x011D3A64 File Offset: 0x011D1C64
		protected override void OnBeforeDestroy()
		{
			this.CleanupRuntimeState();
			Singleton<EventSystem>.Instance.Remove<int?>(EEventName.CommonQteEnd, new Action<int?>(this.OnCommonQteEnd));
			this.QteConfigs.Clear();
			this.State = QteHourglassView.EHourglassState.Ended;
			this.AutoStartQte = false;
			this.TrailCurveX = null;
			this.TrailCurveY = null;
			this.TrailDuration = 1000f;
			this.DefaultTrailCurveXPath = "";
			this.DefaultTrailCurveYPath = "";
			this.TrailCurveCache.Clear();
			this.FillItem = null;
			this.TrailItem = null;
		}

		// Token: 0x06044937 RID: 280887 RVA: 0x011D3AF4 File Offset: 0x011D1CF4
		protected override void OnTick(float delta)
		{
			if (!this.IsTrailMoving || this.IsFinishing)
			{
				return;
			}
			this.TrailElapsedMs += delta;
			float num = Singleton<MathUtils>.Instance.Clamp(this.TrailElapsedMs / this.TrailDuration, 0f, 1f);
			FloatCurve trailCurveX = this.TrailCurveX;
			float num2 = (trailCurveX != null) ? trailCurveX.GetCurrentValueByTime(num) : num;
			FloatCurve trailCurveY = this.TrailCurveY;
			float num3 = (trailCurveY != null) ? trailCurveY.GetCurrentValueByTime(num) : num;
			this.TrailPos.X = this.TrailStartPos.X + (this.TrailEndPos.X - this.TrailStartPos.X) * (double)num2;
			this.TrailPos.Y = this.TrailStartPos.Y + (this.TrailEndPos.Y - this.TrailStartPos.Y) * (double)num;
			this.TrailPos.Z = this.TrailStartPos.Z + (this.TrailEndPos.Z - this.TrailStartPos.Z) * (double)num3;
			UUIItem trailItem = this.TrailItem;
			FVector fvector = this.TrailPos.ToUeVectorOld();
			trailItem.SetUIWorldLocation(fvector);
			if (num >= 1f)
			{
				this.ResetTrailMove();
				this.PlayPendingPhaseSequence();
			}
		}

		// Token: 0x06044938 RID: 280888 RVA: 0x011D3C2A File Offset: 0x011D1E2A
		private void OnStartSequenceFinished(string sequenceName)
		{
			if (this.State != QteHourglassView.EHourglassState.WaitStart)
			{
				return;
			}
			this.State = QteHourglassView.EHourglassState.WaitQte1;
			if (!this.TryConsumeCompletedCurrentQte())
			{
				this.TryAutoStartCurrentQte();
			}
		}

		// Token: 0x06044939 RID: 280889 RVA: 0x011D3C4A File Offset: 0x011D1E4A
		private void OnPhaseAFinished(string sequenceName)
		{
			if (this.State != QteHourglassView.EHourglassState.WaitPhaseA)
			{
				return;
			}
			this.State = QteHourglassView.EHourglassState.WaitQte2;
			if (!this.TryConsumeCompletedCurrentQte())
			{
				this.TryAutoStartCurrentQte();
			}
		}

		// Token: 0x0604493A RID: 280890 RVA: 0x011D3C6B File Offset: 0x011D1E6B
		private void OnPhaseBFinished(string sequenceName)
		{
			if (this.State != QteHourglassView.EHourglassState.WaitPhaseB)
			{
				return;
			}
			this.State = QteHourglassView.EHourglassState.WaitQte3;
			if (!this.TryConsumeCompletedCurrentQte())
			{
				this.TryAutoStartCurrentQte();
			}
		}

		// Token: 0x0604493B RID: 280891 RVA: 0x011D3C8C File Offset: 0x011D1E8C
		private void TryAutoStartCurrentQte()
		{
			if (!this.AutoStartQte)
			{
				return;
			}
			this.TryStartCurrentQte();
		}

		// Token: 0x0604493C RID: 280892 RVA: 0x011D3CA0 File Offset: 0x011D1EA0
		private void OnCommonQteEnd(int? handleId)
		{
			if (this.AutoStartQte || this.IsFinishing || handleId == null)
			{
				return;
			}
			CommonQteModel instance = ModelBase<CommonQteModel>.Instance;
			CommonQteContextBase commonQteContextBase = (instance != null) ? instance.GetQteContext(handleId.Value) : null;
			if (commonQteContextBase == null)
			{
				return;
			}
			this.NotifyCommonQteCompleted(this.CreateCompletedQteInfo(commonQteContextBase));
		}

		// Token: 0x0604493D RID: 280893 RVA: 0x011D3CF4 File Offset: 0x011D1EF4
		public void NotifyCommonQteCompleted(IQteHourglassCompletedQteInfo completedInfo)
		{
			if (this.AutoStartQte || this.IsFinishing || this.CompletedQteHandleIds.Contains(completedInfo.HandleId))
			{
				return;
			}
			int receivableQteIndex = this.GetReceivableQteIndex(completedInfo.QteId);
			if (receivableQteIndex < 0)
			{
				return;
			}
			this.CompletedQteHandleIds.Add(completedInfo.HandleId);
			this.CompletedQteInfos[receivableQteIndex] = completedInfo;
			this.TryConsumeCompletedCurrentQte();
		}

		// Token: 0x0604493E RID: 280894 RVA: 0x011D3D59 File Offset: 0x011D1F59
		private void OnPhaseCFinished(string sequenceName)
		{
			if (this.State != QteHourglassView.EHourglassState.WaitPhaseC || this.IsFinishing)
			{
				return;
			}
			this.State = QteHourglassView.EHourglassState.WaitClose;
			this.IsFinishing = true;
			this.LastHide = true;
			base.CloseMe(null);
		}

		// Token: 0x0604493F RID: 280895 RVA: 0x011D3D8C File Offset: 0x011D1F8C
		private void TryStartCurrentQte()
		{
			if (this.IsFinishing)
			{
				return;
			}
			int currentQteIndex = this.GetCurrentQteIndex();
			if (currentQteIndex < 0 || currentQteIndex >= this.QteConfigs.Count)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.LevelPlay;
				ELogAuthor author = ELogAuthor.FZX;
				string message = "[QteHourglassView] QTE索引越界";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("QteIndex", currentQteIndex);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				this.HandleQteSuccess(null);
				return;
			}
			int qteId = this.QteConfigs[currentQteIndex].QteId;
			CommonQteContextBase commonQteContextBase = ControllerBase<CommonQteController>.Instance.StartQte(qteId, null, null, EQteSource.Battle, null);
			if (commonQteContextBase == null)
			{
				global::Log instance2 = Singleton<global::Log>.Instance;
				ELogModule module2 = ELogModule.LevelPlay;
				ELogAuthor author2 = ELogAuthor.FZX;
				string message2 = "[QteHourglassView] 启动QTE失败";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("QteId", qteId);
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				this.HandleQteSuccess(null);
				return;
			}
			this.ActiveQteHandleId = commonQteContextBase.HandleId;
		}

		// Token: 0x06044940 RID: 280896 RVA: 0x011D3E54 File Offset: 0x011D2054
		private int GetCurrentQteIndex()
		{
			switch (this.State)
			{
			case QteHourglassView.EHourglassState.WaitQte1:
				return 0;
			case QteHourglassView.EHourglassState.WaitQte2:
				return 1;
			case QteHourglassView.EHourglassState.WaitQte3:
				return 2;
			}
			return -1;
		}

		// Token: 0x06044941 RID: 280897 RVA: 0x011D3E90 File Offset: 0x011D2090
		private int GetEarliestReceivableQteIndex()
		{
			switch (this.State)
			{
			case QteHourglassView.EHourglassState.WaitStart:
			case QteHourglassView.EHourglassState.WaitQte1:
				return 0;
			case QteHourglassView.EHourglassState.WaitPhaseA:
			case QteHourglassView.EHourglassState.WaitQte2:
				return 1;
			case QteHourglassView.EHourglassState.WaitPhaseB:
			case QteHourglassView.EHourglassState.WaitQte3:
				return 2;
			default:
				return 3;
			}
		}

		// Token: 0x06044942 RID: 280898 RVA: 0x011D3ECC File Offset: 0x011D20CC
		private int GetReceivableQteIndex(int qteId)
		{
			int currentQteIndex = this.GetCurrentQteIndex();
			if (currentQteIndex >= 0 && currentQteIndex < this.QteConfigs.Count)
			{
				IQteHourglassConfig qteHourglassConfig = this.QteConfigs[currentQteIndex];
				if (qteHourglassConfig != null && qteHourglassConfig.QteId == qteId)
				{
					return currentQteIndex;
				}
			}
			for (int i = this.GetEarliestReceivableQteIndex(); i < this.QteConfigs.Count; i++)
			{
				if (this.CompletedQteInfos[i] == null)
				{
					IQteHourglassConfig qteHourglassConfig2 = this.QteConfigs[i];
					if (qteHourglassConfig2 != null && qteHourglassConfig2.QteId == qteId)
					{
						return i;
					}
				}
			}
			return -1;
		}

		// Token: 0x06044943 RID: 280899 RVA: 0x011D3F58 File Offset: 0x011D2158
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

		// Token: 0x06044944 RID: 280900 RVA: 0x011D3FA8 File Offset: 0x011D21A8
		private bool TryConsumeCompletedCurrentQte()
		{
			if (this.IsFinishing)
			{
				return false;
			}
			int currentQteIndex = this.GetCurrentQteIndex();
			if (currentQteIndex < 0)
			{
				return false;
			}
			IQteHourglassCompletedQteInfo qteHourglassCompletedQteInfo = this.CompletedQteInfos[currentQteIndex];
			if (qteHourglassCompletedQteInfo == null)
			{
				return false;
			}
			this.CompletedQteInfos[currentQteIndex] = null;
			this.HandleQteSuccess(qteHourglassCompletedQteInfo);
			return true;
		}

		// Token: 0x06044945 RID: 280901 RVA: 0x011D3FEC File Offset: 0x011D21EC
		[NullableContext(2)]
		private void HandleQteSuccess(IQteHourglassCompletedQteInfo completedInfo)
		{
			if (this.IsFinishing || completedInfo == null)
			{
				return;
			}
			int currentQteIndex = this.GetCurrentQteIndex();
			IQteHourglassConfig qteHourglassConfig = (currentQteIndex >= 0 && currentQteIndex < this.QteConfigs.Count) ? this.QteConfigs[currentQteIndex] : null;
			if (qteHourglassConfig == null)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.LevelPlay;
				ELogAuthor author = ELogAuthor.FZX;
				string message = "[QteHourglassView] QTE配置不存在";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("QteIndex", currentQteIndex);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			if (this.AutoStartQte && completedInfo.HandleId != this.ActiveQteHandleId)
			{
				return;
			}
			this.ActiveQteHandleId = 0;
			switch (this.State)
			{
			case QteHourglassView.EHourglassState.WaitQte1:
				this.State = QteHourglassView.EHourglassState.WaitPhaseA;
				this.StartTrailMove(completedInfo.StartPos, "PhaseA", qteHourglassConfig);
				return;
			case QteHourglassView.EHourglassState.WaitPhaseA:
			case QteHourglassView.EHourglassState.WaitPhaseB:
				break;
			case QteHourglassView.EHourglassState.WaitQte2:
				this.State = QteHourglassView.EHourglassState.WaitPhaseB;
				this.StartTrailMove(completedInfo.StartPos, "PhaseB", qteHourglassConfig);
				return;
			case QteHourglassView.EHourglassState.WaitQte3:
				this.State = QteHourglassView.EHourglassState.WaitPhaseC;
				this.StartTrailMove(completedInfo.StartPos, "PhaseC", qteHourglassConfig);
				break;
			default:
				return;
			}
		}

		// Token: 0x06044946 RID: 280902 RVA: 0x011D40F0 File Offset: 0x011D22F0
		private void CleanupRuntimeState()
		{
			this.ResetTrailMove();
			if (this.ActiveQteHandleId > 0)
			{
				ControllerBase<CommonQteController>.Instance.StopQte(this.ActiveQteHandleId);
				this.ActiveQteHandleId = 0;
			}
			this.PendingPhaseSequence = null;
			Array.Clear(this.CompletedQteInfos, 0, this.CompletedQteInfos.Length);
			this.CompletedQteHandleIds.Clear();
		}

		// Token: 0x06044947 RID: 280903 RVA: 0x011D414C File Offset: 0x011D234C
		private void StartTrailMove([Nullable(2)] Vector startPos, string phaseSequence, IQteHourglassConfig qteConfig)
		{
			this.PendingPhaseSequence = phaseSequence;
			if (startPos == null || this.FillItem == null || this.TrailItem == null)
			{
				this.PlayPendingPhaseSequence();
				return;
			}
			this.ResetTrailMove();
			this.TrailStartPos = startPos;
			FVector uiworldPosition = this.FillItem.GetUIWorldPosition();
			this.TrailEndPos.FromUeVector(uiworldPosition);
			this.TrailElapsedMs = 0f;
			this.TrailDuration = ((qteConfig.TrailTime > 0f) ? (qteConfig.TrailTime * 1000f) : 1000f);
			this.TrailCurveX = this.GetLoadedTrailCurve(this.GetTrailCurvePath(qteConfig.TrailCurveX, this.DefaultTrailCurveXPath));
			this.TrailCurveY = this.GetLoadedTrailCurve(this.GetTrailCurvePath(qteConfig.TrailCurveY, this.DefaultTrailCurveYPath));
			this.IsTrailMoving = true;
			UUIItem trailItem = this.TrailItem;
			FVector fvector = this.TrailStartPos.ToUeVectorOld();
			trailItem.SetUIWorldLocation(fvector);
			this.TrailItem.SetUIActive(true);
		}

		// Token: 0x06044948 RID: 280904 RVA: 0x011D423C File Offset: 0x011D243C
		private void PlayPendingPhaseSequence()
		{
			string pendingPhaseSequence = this.PendingPhaseSequence;
			this.PendingPhaseSequence = null;
			if (pendingPhaseSequence == null || this.IsFinishing)
			{
				return;
			}
			base.PlayOrReplaySequence(pendingPhaseSequence, false, null);
		}

		// Token: 0x06044949 RID: 280905 RVA: 0x011D4274 File Offset: 0x011D2474
		private void ResetTrailMove()
		{
			this.IsTrailMoving = false;
			this.TrailElapsedMs = 0f;
			this.TrailDuration = 1000f;
			this.TrailStartPos = null;
			this.TrailCurveX = null;
			this.TrailCurveY = null;
			UUIItem trailItem = this.TrailItem;
			if (trailItem == null)
			{
				return;
			}
			trailItem.SetUIActive(false);
		}

		// Token: 0x0604494A RID: 280906 RVA: 0x011D42C4 File Offset: 0x011D24C4
		private UniTask PreloadTrailCurves()
		{
			QteHourglassView.<PreloadTrailCurves>d__51 <PreloadTrailCurves>d__;
			<PreloadTrailCurves>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PreloadTrailCurves>d__.<>4__this = this;
			<PreloadTrailCurves>d__.<>1__state = -1;
			<PreloadTrailCurves>d__.<>t__builder.Start<QteHourglassView.<PreloadTrailCurves>d__51>(ref <PreloadTrailCurves>d__);
			return <PreloadTrailCurves>d__.<>t__builder.Task;
		}

		// Token: 0x0604494B RID: 280907 RVA: 0x011D4307 File Offset: 0x011D2507
		private string GetTrailCurvePath([Nullable(2)] string curvePath, string defaultPath)
		{
			if (!StringUtils.IsEmpty(curvePath))
			{
				return curvePath;
			}
			return defaultPath;
		}

		// Token: 0x0604494C RID: 280908 RVA: 0x011D4314 File Offset: 0x011D2514
		[return: Nullable(2)]
		private FloatCurve GetLoadedTrailCurve(string curvePath)
		{
			FloatCurve result;
			if (curvePath.Length <= 0 || !this.TrailCurveCache.TryGetValue(curvePath, out result))
			{
				return null;
			}
			return result;
		}

		// Token: 0x0604494D RID: 280909 RVA: 0x011D4340 File Offset: 0x011D2540
		[return: Nullable(new byte[]
		{
			0,
			2
		})]
		private UniTask<FloatCurve> LoadTrailCurve(string curvePath)
		{
			QteHourglassView.<LoadTrailCurve>d__54 <LoadTrailCurve>d__;
			<LoadTrailCurve>d__.<>t__builder = AsyncUniTaskMethodBuilder<FloatCurve>.Create();
			<LoadTrailCurve>d__.<>4__this = this;
			<LoadTrailCurve>d__.curvePath = curvePath;
			<LoadTrailCurve>d__.<>1__state = -1;
			<LoadTrailCurve>d__.<>t__builder.Start<QteHourglassView.<LoadTrailCurve>d__54>(ref <LoadTrailCurve>d__);
			return <LoadTrailCurve>d__.<>t__builder.Task;
		}

		// Token: 0x0604494E RID: 280910 RVA: 0x011D438C File Offset: 0x011D258C
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

		// Token: 0x040262BE RID: 156350
		private const float TIME = 1000f;

		// Token: 0x040262BF RID: 156351
		private const int TOTAL_QTE_COUNT = 3;

		// Token: 0x040262C0 RID: 156352
		private List<IQteHourglassConfig> QteConfigs = new List<IQteHourglassConfig>();

		// Token: 0x040262C1 RID: 156353
		private int ActiveQteHandleId;

		// Token: 0x040262C2 RID: 156354
		private QteHourglassView.EHourglassState State;

		// Token: 0x040262C3 RID: 156355
		private bool IsFinishing;

		// Token: 0x040262C4 RID: 156356
		private bool AutoStartQte;

		// Token: 0x040262C5 RID: 156357
		[Nullable(new byte[]
		{
			1,
			2
		})]
		private readonly IQteHourglassCompletedQteInfo[] CompletedQteInfos = new IQteHourglassCompletedQteInfo[3];

		// Token: 0x040262C6 RID: 156358
		private readonly HashSet<int> CompletedQteHandleIds = new HashSet<int>();

		// Token: 0x040262C7 RID: 156359
		[Nullable(2)]
		private UUIItem FillItem;

		// Token: 0x040262C8 RID: 156360
		[Nullable(2)]
		private UUIItem TrailItem;

		// Token: 0x040262C9 RID: 156361
		[Nullable(2)]
		private FloatCurve TrailCurveX;

		// Token: 0x040262CA RID: 156362
		[Nullable(2)]
		private FloatCurve TrailCurveY;

		// Token: 0x040262CB RID: 156363
		private float TrailDuration = 1000f;

		// Token: 0x040262CC RID: 156364
		private bool IsTrailMoving;

		// Token: 0x040262CD RID: 156365
		private float TrailElapsedMs;

		// Token: 0x040262CE RID: 156366
		[Nullable(2)]
		private Vector TrailStartPos;

		// Token: 0x040262CF RID: 156367
		private readonly Vector TrailEndPos = Vector.Create();

		// Token: 0x040262D0 RID: 156368
		private readonly Vector TrailPos = Vector.Create();

		// Token: 0x040262D1 RID: 156369
		[Nullable(2)]
		private string PendingPhaseSequence;

		// Token: 0x040262D2 RID: 156370
		private string DefaultTrailCurveXPath = "";

		// Token: 0x040262D3 RID: 156371
		private string DefaultTrailCurveYPath = "";

		// Token: 0x040262D4 RID: 156372
		[Nullable(new byte[]
		{
			1,
			1,
			2
		})]
		private readonly Dictionary<string, FloatCurve> TrailCurveCache = new Dictionary<string, FloatCurve>();

		// Token: 0x0200CB49 RID: 52041
		[NullableContext(0)]
		private enum EComp
		{
			// Token: 0x0403E644 RID: 255556
			Fill,
			// Token: 0x0403E645 RID: 255557
			Trail
		}

		// Token: 0x0200CB4A RID: 52042
		[NullableContext(0)]
		private enum EHourglassState
		{
			// Token: 0x0403E647 RID: 255559
			WaitStart,
			// Token: 0x0403E648 RID: 255560
			WaitQte1,
			// Token: 0x0403E649 RID: 255561
			WaitPhaseA,
			// Token: 0x0403E64A RID: 255562
			WaitQte2,
			// Token: 0x0403E64B RID: 255563
			WaitPhaseB,
			// Token: 0x0403E64C RID: 255564
			WaitQte3,
			// Token: 0x0403E64D RID: 255565
			WaitPhaseC,
			// Token: 0x0403E64E RID: 255566
			WaitClose,
			// Token: 0x0403E64F RID: 255567
			Ended
		}

		// Token: 0x0200CB4B RID: 52043
		[Nullable(0)]
		private class EHourglassSequence
		{
			// Token: 0x0403E650 RID: 255568
			public const string PhaseA = "PhaseA";

			// Token: 0x0403E651 RID: 255569
			public const string PhaseB = "PhaseB";

			// Token: 0x0403E652 RID: 255570
			public const string PhaseC = "PhaseC";
		}
	}
}
