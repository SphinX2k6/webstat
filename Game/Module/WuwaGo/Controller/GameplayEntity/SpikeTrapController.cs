using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;
using AkiClient.Game.Aki.Data.Gameplay.WuWaGo;
using CSharpScript.Game.Module.WuwaGo.Controller.GameMode;
using CSharpScript.Game.Module.WuwaGo.Model;
using CSharpScript.Game.Module.WuwaGo.Model.GameplayEntity;
using CSharpScript.Game.Module.WuwaGo.Model.Role;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.WuwaGo.Controller.GameplayEntity
{
	// Token: 0x02004B15 RID: 19221
	[NullableContext(1)]
	[Nullable(0)]
	public class SpikeTrapController : GameplayEntityControllerBase
	{
		// Token: 0x0603220B RID: 205323 RVA: 0x00C8B418 File Offset: 0x00C89618
		public SpikeTrapController(WuWaGoGameplayEntityBase entity, WuWaGoGameData gameData, WuWaGoGameModeBase gameMode) : base(entity, gameData, gameMode)
		{
		}

		// Token: 0x17008598 RID: 34200
		// (get) Token: 0x0603220C RID: 205324 RVA: 0x00C8B423 File Offset: 0x00C89623
		private WuWaGoSpikeTrapEntity SpikeTrap
		{
			get
			{
				return this.Entity as WuWaGoSpikeTrapEntity;
			}
		}

		// Token: 0x0603220D RID: 205325 RVA: 0x00C8B430 File Offset: 0x00C89630
		protected override bool OnCreate()
		{
			if (!base.OnCreate())
			{
				return false;
			}
			this.IsDestroyed = false;
			WuWaGoGrid gridById = this.GameData.GetGridById(this.Entity.StandGridId);
			int? num = (gridById != null) ? new int?(gridById.OccupiedUnitId) : null;
			this.SpikeTrap.ResetOccupantTrackingBaseline(num.GetValueOrDefault());
			base.RegisterAttachedGridMoveParticipant();
			return true;
		}

		// Token: 0x0603220E RID: 205326 RVA: 0x00C8B497 File Offset: 0x00C89697
		protected override void OnDestroy()
		{
			base.OnDestroy();
			this.IsDestroyed = true;
			this.SinkPresentationCancelToken++;
			base.UnregisterAttachedGridMoveParticipant();
		}

		// Token: 0x0603220F RID: 205327 RVA: 0x00C8B4BA File Offset: 0x00C896BA
		public override void OnRollbackRestore()
		{
			this.SinkPresentationCancelToken++;
		}

		// Token: 0x06032210 RID: 205328 RVA: 0x00C8B4CC File Offset: 0x00C896CC
		protected override UniTask OnExecuteAction()
		{
			SpikeTrapController.<OnExecuteAction>d__14 <OnExecuteAction>d__;
			<OnExecuteAction>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnExecuteAction>d__.<>4__this = this;
			<OnExecuteAction>d__.<>1__state = -1;
			<OnExecuteAction>d__.<>t__builder.Start<SpikeTrapController.<OnExecuteAction>d__14>(ref <OnExecuteAction>d__);
			return <OnExecuteAction>d__.<>t__builder.Task;
		}

		// Token: 0x06032211 RID: 205329 RVA: 0x00C8B510 File Offset: 0x00C89710
		private int GetFirstSinkDepthCm()
		{
			BP_WuWaGo_C setting = WuWaGoGlobal.Setting;
			int? num = (setting != null) ? new int?(setting.SpikeFallHeight) : null;
			if (num != null && num.GetValueOrDefault() > 0)
			{
				return num.Value;
			}
			return SpikeTrapController.DefaultFirstSinkDepthCm;
		}

		// Token: 0x06032212 RID: 205330 RVA: 0x00C8B55C File Offset: 0x00C8975C
		private UniTask TakeAttackOnRole(WuWaGoRole role)
		{
			SpikeTrapController.<TakeAttackOnRole>d__16 <TakeAttackOnRole>d__;
			<TakeAttackOnRole>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<TakeAttackOnRole>d__.<>4__this = this;
			<TakeAttackOnRole>d__.role = role;
			<TakeAttackOnRole>d__.<>1__state = -1;
			<TakeAttackOnRole>d__.<>t__builder.Start<SpikeTrapController.<TakeAttackOnRole>d__16>(ref <TakeAttackOnRole>d__);
			return <TakeAttackOnRole>d__.<>t__builder.Task;
		}

		// Token: 0x06032213 RID: 205331 RVA: 0x00C8B5A8 File Offset: 0x00C897A8
		private UniTask PlaySinkOnRole(WuWaGoRole role, int depthCm, int durationMs)
		{
			SpikeTrapController.<PlaySinkOnRole>d__17 <PlaySinkOnRole>d__;
			<PlaySinkOnRole>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlaySinkOnRole>d__.<>4__this = this;
			<PlaySinkOnRole>d__.role = role;
			<PlaySinkOnRole>d__.depthCm = depthCm;
			<PlaySinkOnRole>d__.durationMs = durationMs;
			<PlaySinkOnRole>d__.<>1__state = -1;
			<PlaySinkOnRole>d__.<>t__builder.Start<SpikeTrapController.<PlaySinkOnRole>d__17>(ref <PlaySinkOnRole>d__);
			return <PlaySinkOnRole>d__.<>t__builder.Task;
		}

		// Token: 0x06032214 RID: 205332 RVA: 0x00C8B604 File Offset: 0x00C89804
		[NullableContext(0)]
		private UniTask<bool> WaitSinkStartDelay(int expectedToken)
		{
			SpikeTrapController.<WaitSinkStartDelay>d__18 <WaitSinkStartDelay>d__;
			<WaitSinkStartDelay>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<WaitSinkStartDelay>d__.<>4__this = this;
			<WaitSinkStartDelay>d__.expectedToken = expectedToken;
			<WaitSinkStartDelay>d__.<>1__state = -1;
			<WaitSinkStartDelay>d__.<>t__builder.Start<SpikeTrapController.<WaitSinkStartDelay>d__18>(ref <WaitSinkStartDelay>d__);
			return <WaitSinkStartDelay>d__.<>t__builder.Task;
		}

		// Token: 0x06032215 RID: 205333 RVA: 0x00C8B650 File Offset: 0x00C89850
		private bool TryResolveSinkTargetWorldPosition(WuWaGoRole role, int depthCm, Vector @out)
		{
			WuWaGoGrid gridById = this.GameData.GetGridById(role.StandGridId);
			Transform originTransform = this.GameData.OriginTransform;
			if (gridById == null || originTransform == null || depthCm <= 0)
			{
				return false;
			}
			Vector vector = Vector.Create();
			if (!this.TryResolveGridSurfaceNormalLocal(gridById, vector))
			{
				return false;
			}
			Vector v = vector.Multiply((double)(-(double)depthCm), Vector.Create());
			Vector vector2 = Vector.Create();
			originTransform.TransformVector(v, vector2);
			Vector.Create(role.GetWorldLocation()).Addition(vector2, @out);
			return true;
		}

		// Token: 0x06032216 RID: 205334 RVA: 0x00C8B6D4 File Offset: 0x00C898D4
		private bool TryResolveGridSurfaceNormalLocal(WuWaGoGrid grid, Vector @out)
		{
			EGridShape gridShape = grid.GridShape;
			if (gridShape != EGridShape.Vertical)
			{
				if (gridShape == EGridShape.Horizontal)
				{
					@out.DeepCopy(Vector.UpVectorProxy);
					return true;
				}
				return false;
			}
			else
			{
				if (grid.WallFrame == null)
				{
					return false;
				}
				@out.Set((double)(-(double)grid.WallFrame.WallNormalX * grid.WallFrame.OwnerSign), (double)(-(double)grid.WallFrame.WallNormalY * grid.WallFrame.OwnerSign), 0.0);
				return true;
			}
		}

		// Token: 0x0401D4C9 RID: 120009
		private static readonly int SinkStartDelayMs = 300;

		// Token: 0x0401D4CA RID: 120010
		private static readonly int DefaultFirstSinkDepthCm = 40;

		// Token: 0x0401D4CB RID: 120011
		private static readonly int FirstSinkDurationMs = 50;

		// Token: 0x0401D4CC RID: 120012
		private static readonly int FallSinkDepthCm = 180;

		// Token: 0x0401D4CD RID: 120013
		private static readonly int FallSinkDurationMs = 100;

		// Token: 0x0401D4CE RID: 120014
		private static readonly int SinkTickIntervalMs = 20;

		// Token: 0x0401D4CF RID: 120015
		private bool IsDestroyed;

		// Token: 0x0401D4D0 RID: 120016
		private int SinkPresentationCancelToken;
	}
}
