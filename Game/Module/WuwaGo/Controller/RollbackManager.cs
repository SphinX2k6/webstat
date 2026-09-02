using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Gameplay.WuWaGo;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.WuwaGo.Controller.GameMode;
using CSharpScript.Game.Module.WuwaGo.Model;
using CSharpScript.Game.Module.WuwaGo.Model.Role;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.WuwaGo.Controller
{
	// Token: 0x02004AF2 RID: 19186
	[NullableContext(1)]
	[Nullable(0)]
	public class RollbackManager
	{
		// Token: 0x06032054 RID: 204884 RVA: 0x00C83FF8 File Offset: 0x00C821F8
		public RollbackManager(WuWaGoGameModeBase gameMode, WuWaGoGameData gameData)
		{
			this.GameMode = gameMode;
			this.GameData = gameData;
			this.GameData.RollbackPreStates.RegisterCommitHandler(new Action<Dictionary<int, IRollbackCapture>>(this.HandleCommit));
		}

		// Token: 0x1700856A RID: 34154
		// (get) Token: 0x06032055 RID: 204885 RVA: 0x00C84035 File Offset: 0x00C82235
		public int Count
		{
			get
			{
				return this.Stack.Count;
			}
		}

		// Token: 0x1700856B RID: 34155
		// (get) Token: 0x06032056 RID: 204886 RVA: 0x00C84042 File Offset: 0x00C82242
		public bool IsAvailable
		{
			get
			{
				return !this.IsRestoring && this.IsAcceptingInput && (this.Stack.Count > 0 || this.HasUnrolledDrops);
			}
		}

		// Token: 0x1700856C RID: 34156
		// (get) Token: 0x06032057 RID: 204887 RVA: 0x00C8406C File Offset: 0x00C8226C
		public bool IsRestoring
		{
			get
			{
				return this.CurrentRestoreJob != null;
			}
		}

		// Token: 0x06032058 RID: 204888 RVA: 0x00C84077 File Offset: 0x00C82277
		public void SetAcceptingInput(bool accept)
		{
			if (this.IsAcceptingInput == accept)
			{
				return;
			}
			this.IsAcceptingInput = accept;
			this.RefreshAvailable();
		}

		// Token: 0x06032059 RID: 204889 RVA: 0x00C84090 File Offset: 0x00C82290
		public void BeginPlayerActionTracking()
		{
			if (this.GetMaxRollbackCount() <= 0)
			{
				return;
			}
			this.GameData.RollbackPreStates.Begin();
		}

		// Token: 0x0603205A RID: 204890 RVA: 0x00C840AC File Offset: 0x00C822AC
		public void FlushPendingPlayerActionTracking()
		{
			this.GameData.RollbackPreStates.FlushPendingCommit();
		}

		// Token: 0x0603205B RID: 204891 RVA: 0x00C840BE File Offset: 0x00C822BE
		public void ResetPlayerActionCaptures()
		{
			this.GameData.RollbackPreStates.ResetCaptures();
		}

		// Token: 0x0603205C RID: 204892 RVA: 0x00C840D0 File Offset: 0x00C822D0
		public void ResetForSavePoint()
		{
			this.GameData.RollbackPreStates.Discard();
			this.Stack.Clear();
			this.HasUnrolledDrops = false;
			this.CaptureSavePointSnapshot();
			this.RefreshAvailable();
		}

		// Token: 0x0603205D RID: 204893 RVA: 0x00C84100 File Offset: 0x00C82300
		public void CaptureSavePointSnapshot()
		{
			this.SavePointSnapshot = RollbackManager.CaptureAllUnits(this.GameData);
		}

		// Token: 0x0603205E RID: 204894 RVA: 0x00C84113 File Offset: 0x00C82313
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public IReadOnlyList<IRollbackCapture> GetSavePointSnapshot()
		{
			return this.SavePointSnapshot;
		}

		// Token: 0x0603205F RID: 204895 RVA: 0x00C8411C File Offset: 0x00C8231C
		public UniTask RollbackToLastStepAsync()
		{
			RollbackManager.<RollbackToLastStepAsync>d__25 <RollbackToLastStepAsync>d__;
			<RollbackToLastStepAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RollbackToLastStepAsync>d__.<>4__this = this;
			<RollbackToLastStepAsync>d__.<>1__state = -1;
			<RollbackToLastStepAsync>d__.<>t__builder.Start<RollbackManager.<RollbackToLastStepAsync>d__25>(ref <RollbackToLastStepAsync>d__);
			return <RollbackToLastStepAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06032060 RID: 204896 RVA: 0x00C84160 File Offset: 0x00C82360
		public UniTask RollbackToSavePointAsync()
		{
			RollbackManager.<RollbackToSavePointAsync>d__26 <RollbackToSavePointAsync>d__;
			<RollbackToSavePointAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RollbackToSavePointAsync>d__.<>4__this = this;
			<RollbackToSavePointAsync>d__.<>1__state = -1;
			<RollbackToSavePointAsync>d__.<>t__builder.Start<RollbackManager.<RollbackToSavePointAsync>d__26>(ref <RollbackToSavePointAsync>d__);
			return <RollbackToSavePointAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06032061 RID: 204897 RVA: 0x00C841A4 File Offset: 0x00C823A4
		public static List<IRollbackCapture> CaptureAllUnits(WuWaGoGameData gameData)
		{
			List<IRollbackCapture> list = new List<IRollbackCapture>();
			WuWaGoMainControlRole mainControlRole = gameData.MainControlRole;
			IRollbackCapture rollbackCapture = (mainControlRole != null) ? mainControlRole.CaptureRollback() : null;
			if (rollbackCapture != null)
			{
				list.Add(rollbackCapture);
			}
			foreach (WuWaGoBaseUnit wuWaGoBaseUnit in gameData.AllUnits.Values)
			{
				if (wuWaGoBaseUnit != mainControlRole)
				{
					IRollbackCapture rollbackCapture2 = wuWaGoBaseUnit.CaptureRollback();
					if (rollbackCapture2 != null)
					{
						list.Add(rollbackCapture2);
					}
				}
			}
			return list;
		}

		// Token: 0x06032062 RID: 204898 RVA: 0x00C84238 File Offset: 0x00C82438
		public UniTask RestoreCapturesAsync(IReadOnlyList<IRollbackCapture> captures)
		{
			RollbackManager.<RestoreCapturesAsync>d__28 <RestoreCapturesAsync>d__;
			<RestoreCapturesAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RestoreCapturesAsync>d__.<>4__this = this;
			<RestoreCapturesAsync>d__.captures = captures;
			<RestoreCapturesAsync>d__.<>1__state = -1;
			<RestoreCapturesAsync>d__.<>t__builder.Start<RollbackManager.<RestoreCapturesAsync>d__28>(ref <RestoreCapturesAsync>d__);
			return <RestoreCapturesAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06032063 RID: 204899 RVA: 0x00C84283 File Offset: 0x00C82483
		public void TickYield()
		{
			if (this.CurrentRestoreJob != null)
			{
				this.AdvanceRestoreJob();
			}
		}

		// Token: 0x06032064 RID: 204900 RVA: 0x00C84294 File Offset: 0x00C82494
		public void RefreshAvailable()
		{
			bool isAvailable = this.IsAvailable;
			if (isAvailable == this.LastEmittedAvailable)
			{
				return;
			}
			this.LastEmittedAvailable = isAvailable;
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnWuWaGoRollbackAvailable, isAvailable);
		}

		// Token: 0x06032065 RID: 204901 RVA: 0x00C842CC File Offset: 0x00C824CC
		public void Clear()
		{
			this.Stack.Clear();
			this.SavePointSnapshot = null;
			this.HasUnrolledDrops = false;
			this.LastEmittedAvailable = false;
			this.IsAcceptingInput = false;
			if (this.CurrentRestoreJob != null)
			{
				RollbackManager.RestoreJob currentRestoreJob = this.CurrentRestoreJob;
				this.CurrentRestoreJob = null;
				this.GameData.RollbackPreStates.SetSuppressed(false);
				this.GameData.EndGridLinkBatch();
				currentRestoreJob.OnDone();
			}
			this.GameData.RollbackPreStates.Discard();
		}

		// Token: 0x06032066 RID: 204902 RVA: 0x00C8434C File Offset: 0x00C8254C
		private void HandleCommit(Dictionary<int, IRollbackCapture> captures)
		{
			if (captures.Count == 0)
			{
				return;
			}
			WuWaGoRollbackSnapshot item = WuWaGoRollbackSnapshot.CreateFromCaptures(this.GameData.Round, captures);
			this.Stack.Add(item);
			int maxRollbackCount = this.GetMaxRollbackCount();
			if (this.Stack.Count > maxRollbackCount)
			{
				this.Stack.RemoveAt(0);
				this.HasUnrolledDrops = true;
			}
			this.RefreshAvailable();
		}

		// Token: 0x06032067 RID: 204903 RVA: 0x00C843B0 File Offset: 0x00C825B0
		private UniTask RestoreSavePointInternalAsync()
		{
			RollbackManager.<RestoreSavePointInternalAsync>d__33 <RestoreSavePointInternalAsync>d__;
			<RestoreSavePointInternalAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RestoreSavePointInternalAsync>d__.<>4__this = this;
			<RestoreSavePointInternalAsync>d__.<>1__state = -1;
			<RestoreSavePointInternalAsync>d__.<>t__builder.Start<RollbackManager.<RestoreSavePointInternalAsync>d__33>(ref <RestoreSavePointInternalAsync>d__);
			return <RestoreSavePointInternalAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06032068 RID: 204904 RVA: 0x00C843F4 File Offset: 0x00C825F4
		private void StartRestoreJob(IReadOnlyList<IRollbackCapture> captures, Action onDone)
		{
			this.GameData.RollbackPreStates.Discard();
			this.GameData.BeginGridLinkBatch();
			this.GameData.RollbackPreStates.SetSuppressed(true);
			this.CurrentRestoreJob = new RollbackManager.RestoreJob
			{
				Captures = captures,
				Index = 0,
				OnDone = onDone
			};
			this.RefreshAvailable();
			if (captures.Count == 0)
			{
				this.FinishRestoreJob();
			}
		}

		// Token: 0x06032069 RID: 204905 RVA: 0x00C84464 File Offset: 0x00C82664
		private void AdvanceRestoreJob()
		{
			RollbackManager.RestoreJob currentRestoreJob = this.CurrentRestoreJob;
			int num = 16;
			int num2 = Math.Min(currentRestoreJob.Index + num, currentRestoreJob.Captures.Count);
			for (int i = currentRestoreJob.Index; i < num2; i++)
			{
				currentRestoreJob.Captures[i].Restore();
			}
			currentRestoreJob.Index = num2;
			if (num2 >= currentRestoreJob.Captures.Count)
			{
				this.FinishRestoreJob();
			}
		}

		// Token: 0x0603206A RID: 204906 RVA: 0x00C844D4 File Offset: 0x00C826D4
		private void FinishRestoreJob()
		{
			RollbackManager.RestoreJob currentRestoreJob = this.CurrentRestoreJob;
			this.CurrentRestoreJob = null;
			this.GameData.RollbackPreStates.SetSuppressed(false);
			this.GameData.RebuildGirdsMap();
			this.GameData.EndGridLinkBatch();
			this.GameMode.NotifyGameplayEntityLinkServiceRollbackRestore();
			this.GameMode.RestoreDeactivatedRoleControllersFromRollback();
			this.GameMode.NotifyAllControllersRollbackRestore();
			this.RefreshAvailable();
			currentRestoreJob.OnDone();
		}

		// Token: 0x0603206B RID: 204907 RVA: 0x00C84546 File Offset: 0x00C82746
		private int GetMaxRollbackCount()
		{
			BP_WuWaGo_C setting = WuWaGoGlobal.Setting;
			if (setting == null)
			{
				return 3;
			}
			return setting.MaxRollbackCount;
		}

		// Token: 0x0401D40E RID: 119822
		private const int DEFAULT_MAX_ROLLBACK_COUNT = 3;

		// Token: 0x0401D40F RID: 119823
		private const int DEFAULT_RESTORE_BATCH_SIZE = 16;

		// Token: 0x0401D410 RID: 119824
		private readonly List<WuWaGoRollbackSnapshot> Stack = new List<WuWaGoRollbackSnapshot>();

		// Token: 0x0401D411 RID: 119825
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private IReadOnlyList<IRollbackCapture> SavePointSnapshot;

		// Token: 0x0401D412 RID: 119826
		private bool HasUnrolledDrops;

		// Token: 0x0401D413 RID: 119827
		private bool LastEmittedAvailable;

		// Token: 0x0401D414 RID: 119828
		private bool IsAcceptingInput;

		// Token: 0x0401D415 RID: 119829
		[Nullable(2)]
		private RollbackManager.RestoreJob CurrentRestoreJob;

		// Token: 0x0401D416 RID: 119830
		private readonly WuWaGoGameModeBase GameMode;

		// Token: 0x0401D417 RID: 119831
		private readonly WuWaGoGameData GameData;

		// Token: 0x0200AB55 RID: 43861
		[Nullable(0)]
		[RequiredMember]
		private class RestoreJob
		{
			// Token: 0x0604BAD5 RID: 309973 RVA: 0x0149348A File Offset: 0x0149168A
			[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
			[CompilerFeatureRequired("RequiredMembers")]
			public RestoreJob()
			{
			}

			// Token: 0x040354F3 RID: 218355
			[RequiredMember]
			public IReadOnlyList<IRollbackCapture> Captures;

			// Token: 0x040354F4 RID: 218356
			public int Index;

			// Token: 0x040354F5 RID: 218357
			[RequiredMember]
			public Action OnDone;
		}
	}
}
